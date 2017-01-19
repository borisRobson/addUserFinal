using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.Diagnostics;

using Emgu.CV;
using Emgu.CV.Structure;
using Emgu.CV.CvEnum;
using System.IO;
using System.Xml;

using CodePlex.JPMikkers.TFTP.Client;
using System.Net;
using System.Globalization;
using System.Linq;
using System.Net.Sockets;
using System.Threading.Tasks;
using System.Threading;

namespace Test
{
    public partial class Form1 : Form
    {
        private Capture _capture;
        private Image<Bgr, byte> _currentFrame;
        private Image<Gray, byte> _face;
        private Image<Gray, byte> _greyImg;
        Stopwatch st;
        private System.Windows.Forms.Timer _imgTimer;

        private System.Windows.Forms.Timer _captureTimer;
        private string _facename = "";
        private int _fileNum = 0;
        private int _numCaptures = 10;

        CascadeClassifier faceDetector;
        Classifier_Train Eigen_Rec;
       
        List<string> NamestoWrite = new List<string>();
        List<string> NamesforFile = new List<string>();
        XmlDocument docu = new XmlDocument();

        private string _hostPort;
        private string _panelipv6 = "fe80::20b:d6ff:fe";

        private TFTPClient.Settings _tftpSettings;
        IPEndPoint endpoint = null;


        public Form1()
        {
            InitializeComponent();

            _imgTimer = new System.Windows.Forms.Timer();
            _imgTimer.Interval = 10;
            _imgTimer.Tick += FrameGrabber;

            _captureTimer = new System.Windows.Forms.Timer();
            _captureTimer.Interval = 10;
            _captureTimer.Tick += _captureTimer_Tick;

            faceDetector = new CascadeClassifier("haarcascade_frontalface_default.xml");
            st = new Stopwatch();
            Eigen_Rec = new Classifier_Train(Application.StartupPath + "\\CapturedFaces");
            Eigen_Rec.Set_Eigen_Threshold = 1500;

            if (chkDefault.Checked)
                txtPanelSN.Enabled = false;

            _tftpSettings = new TFTPClient.Settings();
            _tftpSettings.OnProgress = OnProgress;

            
            StartGrabber();
        }
               

        private void StartGrabber()
        {
            try
            {
                _capture = new Capture();
                _capture.QueryFrame();
            }
            catch(NullReferenceException)
            {
                MessageBox.Show("Failed to open camera, check connection", "Camera Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if(File.Exists(Application.StartupPath + "\\CapturedFaces\\Recogniser.EFR"))
                Eigen_Rec.Load_Eigen_Recogniser(Application.StartupPath + "\\CapturedFaces\\Recogniser.EFR");
            
            
            _imgTimer.Start();
        }

        private void FrameGrabber(object sender, EventArgs e)
        {
            _currentFrame = _capture.QueryFrame().Resize(320, 240, INTER.CV_INTER_CUBIC);

            DetectFace();
            
            imgboxCam.Image = _currentFrame;

            if(Eigen_Rec.IsTrained && _face != null)
            {
                string name = Eigen_Rec.Recognise(_face);
                int match_value = (int)Eigen_Rec.Get_Eigen_Distance;
                txtRecognised.Text = name;
                lblValue.Text = match_value.ToString();                
            }            
        }
        
        private  void DetectFace()
        {
            st.Start();
            _greyImg = _currentFrame.Convert<Gray, byte>();         
            
            Rectangle[] faces = faceDetector.DetectMultiScale(_greyImg, 1.2, 10, new Size(20, 20), Size.Empty);
            
            for(int i = 0; i < faces.Length; i++)
            {
                _currentFrame.Draw(faces[i], new Bgr(Color.Red), 2);
                _face = _greyImg.Copy(faces[i]).Resize(100, 100, INTER.CV_INTER_CUBIC);
                _face._EqualizeHist();
            }            

            st.Reset();
        }

        private void btnAddUser_Click(object sender, EventArgs e)
        {
            //confirm name entered
            if (txtUserName.Text == "")
            {
                MessageBox.Show("Enter user name", "No User Name", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            //check directory exists
            if (!Directory.Exists(Application.StartupPath + "\\CapturedFaces"))
            {
                Directory.CreateDirectory(Application.StartupPath + "\\CapturedFaces");
            }           

            _captureTimer.Start();
        }

        private void _captureTimer_Tick(object sender, EventArgs e)
        {   
            if(_fileNum == _numCaptures)
            {
                _captureTimer.Stop();
                _fileNum = 0;
                TrainRecogniser();
                return;
            }

            if (_face == null)
                return;

            _facename = txtUserName.Text + _fileNum + ".jpg";

            //check for xml name file
            if (!File.Exists(Application.StartupPath + "\\CapturedFaces\\TrainedLabels.xml"))
            {
                FileStream FS_Faces = File.OpenWrite(Application.StartupPath + "\\CapturedFaces\\TrainedLabels.xml");
                using (XmlWriter writer = XmlWriter.Create(FS_Faces))
                {
                    writer.WriteStartDocument();
                    writer.WriteStartElement("Faces_For_Training");

                    writer.WriteStartElement("FACE");
                    writer.WriteElementString("NAME", txtUserName.Text);
                    writer.WriteElementString("FILE", _facename);
                    writer.WriteEndElement();

                    writer.WriteEndElement();
                    writer.WriteEndDocument();
                }

                FS_Faces.Close();
            }
            else
            {
                bool loading = true;
                while(loading)
                {
                    try
                    {
                        docu.Load(Application.StartupPath + "\\CapturedFaces\\TrainedLabels.xml");
                        loading = false;
                    }
                    catch
                    {
                        docu = null;
                        docu = new XmlDocument();
                    }
                }

                //get the root element
                XmlElement root = docu.DocumentElement;

                XmlElement face_D = docu.CreateElement("FACE");
                XmlElement name_D = docu.CreateElement("NAME");
                XmlElement file_D = docu.CreateElement("FILE");

                name_D.InnerText = txtUserName.Text;
                file_D.InnerText = _facename;

                face_D.AppendChild(name_D);
                face_D.AppendChild(file_D);

                root.AppendChild(face_D);

                docu.Save(Application.StartupPath + "\\CapturedFaces\\TrainedLabels.xml");
            }
            
            _face.Save(Application.StartupPath + "\\CapturedFaces\\" + _facename);

            _fileNum++;
        }

        private void TrainRecogniser()
        {
            Eigen_Rec.Retrain(Application.StartupPath + "\\CapturedFaces");
        }

        private void btnSaveRec_Click(object sender, EventArgs e)
        {
            Eigen_Rec.Save_Eigen_Recogniser(Application.StartupPath + "\\CapturedFaces\\Recogniser.EFR");
            txtLog.AppendText("Recogniser Saved\n");
        }

        private void chkDefault_CheckedChanged(object sender, EventArgs e)
        {
            txtPanelSN.Enabled = (chkDefault.Checked) ? false : true;
        }

        private void getHostPort()
        {
            string strHostName = System.Net.Dns.GetHostName(); ;
            IPHostEntry ipEntry = System.Net.Dns.GetHostEntry(strHostName);
            IPAddress[] addr = ipEntry.AddressList;
            
            if (addr[0].AddressFamily == System.Net.Sockets.AddressFamily.InterNetworkV6)
            {
                string host = addr[0].ToString();
                char delim = '%';
                _hostPort = "%" + host.Split(delim)[1];
            }
        }

        private void btnSendRec_Click(object sender, EventArgs e)
        {
            if(endpoint == null)
            {
                getHostPort();

                Int32 sn = Int32.Parse(txtPanelSN.Text);
                string hex = sn.ToString("x");

                _panelipv6 += hex.Substring(0, 2) + ":" + hex.Substring(2) + _hostPort;

                endpoint = ResolveServer(_panelipv6);
            }            

            string recogniser = "Recogniser.EFR";
            string labels = "Labels.xml";

            string recPath = Application.StartupPath + "\\CapturedFaces\\" + recogniser;
            string labelPath = Application.StartupPath + "\\CapturedFaces\\" + labels;
  
            send(endpoint, labelPath, labels);
            send(endpoint, recPath, recogniser);
            
        }

        private async void send(IPEndPoint endpoint, string local, string file)
        {
            CancellationTokenSource source = new CancellationTokenSource();
            var upload = await Task.Factory.StartNew(() => sendFile(endpoint, local, file, source.Token));
        }

        private Task sendFile(IPEndPoint endpoint, string local, string file, CancellationToken token)
        {
            if (token.IsCancellationRequested)
                token.ThrowIfCancellationRequested();

            return Task.Factory.StartNew(() => TFTPClient.Upload(endpoint, local, file, _tftpSettings));
        }

        private void OnProgress(object sender, TFTPClient.ProgressEventArgs e)
        {
            if (InvokeRequired)
            {
                Invoke(new EventHandler<TFTPClient.ProgressEventArgs>(OnProgress), sender, e);
            }
            else
            {
                txtLog.AppendText(string.Format("({0}/{1} bytes) {2}\n", e.Transferred, (e.TransferSize >= 0) ? e.TransferSize.ToString() : "?", e.Filename));
                if (e.Transferred == e.TransferSize)
                    txtLog.AppendText(e.Filename + " Sent successfully\n");
            }
        }

        private static IPEndPoint ResolveServer(string server)
        {
            // nested functions are cool
            Func<string, int, int> ParseIntDefault = (str, def) =>
            {
                int val;
                return int.TryParse(str, out val) ? val : def;
            };

            IPEndPoint result = null;
            IPAddress address;
            int port = 69;

            // attempt to parse it as a ipv6 address
            var parts = server.Split(new string[] { "[", "]:" }, StringSplitOptions.RemoveEmptyEntries);

            if (parts.Length > 0 && IPAddress.TryParse(parts[0], out address))
            {
                if (parts.Length > 1) port = ParseIntDefault(parts[1], 69);
                result = new IPEndPoint(address, port);
            }
            else
            {
                // no luck, try it as a ipv4 address
                parts = server.Split(new string[] { ":" }, StringSplitOptions.RemoveEmptyEntries);

                if (parts.Length > 0)
                {
                    if (parts.Length > 1) port = ParseIntDefault(parts[1], 69);

                    if (IPAddress.TryParse(parts[0], out address))
                    {
                        result = new IPEndPoint(address, port);
                    }
                    else
                    {
                        // still nothing, resolve the hostname
                        var addressList = Dns.GetHostEntry(parts[0]).AddressList;

                        // prefer ipv4 addresses, fall back to ipv6
                        address = addressList.Where(x => x.AddressFamily == AddressFamily.InterNetwork).FirstOrDefault() ??
                                    addressList.Where(x => x.AddressFamily == AddressFamily.InterNetworkV6).FirstOrDefault();

                        if (address != null)
                        {
                            result = new IPEndPoint(address, port);
                        }
                    }
                }
            }

            if (result == null)
            {
                throw new ArgumentException("Couldn't resolve the hostname or IP address");
            }

            return result;
        }

        private void btnUpdateRec_Click(object sender, EventArgs e)
        {
            if (Eigen_Rec.Retrain())
                txtLog.AppendText("Recogniser updated successfully\n");
            else
                txtLog.AppendText("Error updating recogniser, check filepaths\n");
        }
    }
}
