using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.IO;
using System.IO.Compression;
using System.Net.Sockets;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;

namespace DataGraph
{
    public partial class DownloadData : Form
    {
        #region INITIALIZER
        WebClient wc;
        string result = "";
        dynamic stuff;
        private const string Protocol = "http://";
        private const string Directory = "/data/api/getdata.php";
       // private const string DownloadLocation = @"C:\Users\Admin Developer\Desktop\mygad\";
        private const string CompressedLocation = @"E:\Kiting\CSVFiles";
        private string decompressedFileName="";
        private string DownloadLocation = "";


        public DownloadData()
        {
            InitializeComponent();
            iptb.Text = GetLocalIPAddress();
            wc = new WebClient();
        }
        #endregion

        #region UI HANDLER
        private void downloadbtn1_Click(object sender, EventArgs e)
        {
            //get values
            string location = (string)locationcbx.SelectedItem;
            string month = (string)monthcbx.SelectedItem;
            string day = (string)daycbx.SelectedItem;
            string year = (string)yearcbx.SelectedItem;
            string hour = (string)hourcbx.SelectedItem;
            string minute = (string)minutecbx.SelectedItem;
            decompressedFileName = year + "-" + month + "-" + day + "-" + hour + "-" + minute;

            //create the constructor with post type and few data
            string website=Protocol+iptb.Text+Directory;
            statuslabel.Text = "Connecting: "+website;
            try
            {
                MyWebRequest(website, "GET", "location=" + location + "&month=" + month + "&day=" + day + "&year=" + year + "&hour=" + hour + "&minute=" + minute);
                statuslabel.Text = "Requesting Response";
                result = GetResponse();
                stuff = JObject.Parse(result);
                if (stuff["id"] != null)
                {
                    string values = stuff["url"];
                    MessageBox.Show(values);
                    statuslabel.Text = "Downloading";
                    Uri gz = new Uri(values);
                    saveFileDialog1.FileName = decompressedFileName + ".csv.gz";
                    saveFileDialog1.Filter = "GZip (*.gz)|*.gz";
                    saveFileDialog1.Title = "SAVE FILE";
                    if (saveFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                    {
                        DownloadLocation = saveFileDialog1.FileName;
                        wc.DownloadFileAsync(gz, DownloadLocation);
                        wc.DownloadFileCompleted += new AsyncCompletedEventHandler(FileDownloadComplete);
                    }
                }
                else
                {
                    statuslabel.Text = "Nothing Found in the Server";
                }
            }
            catch (ArgumentNullException)
            {
                statuslabel.Text = "Nothing Found in the Server";
            }
            catch (WebException)
            {
                statuslabel.Text = "Failed to connect to the sever!";
            }
        }
        #endregion

        #region UI Listener
        private void Design2Form1_Load(object sender, EventArgs e)
        {
            wc.DownloadProgressChanged += new DownloadProgressChangedEventHandler(FileProgressDownload);
        }

        private void FileDownloadComplete(object sender, AsyncCompletedEventArgs e)
        {
            statuslabel.Text = "Download Completed";
            saveFileDialog1.FileName = decompressedFileName+".csv";
            saveFileDialog1.Filter = "Comma Separated |*.csv";
            saveFileDialog1.Title = "SAVE DECOMPRESSED FILE";
            if (saveFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                decompress(DownloadLocation, saveFileDialog1.FileName);
                statuslabel.Text = "File Compressed";
            }
        }
        void FileProgressDownload(object sender, DownloadProgressChangedEventArgs e)
        {

            //progressBar1.Maximum = (int)e.TotalBytesToReceive / 100;
            //progressBar1.Value = (int)e.BytesReceived / 100;
            

        }
        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                iptb.Enabled = true;
            }
            else
            {
                iptb.Enabled = false;
            }
        }
        #endregion 

        #region WEB CONNECTION methods

        private WebRequest request;
        private Stream dataStream;

        private string status;

        public String Status
        {
            get
            {
                return status;
            }
            set
            {
                status = value;
            }
        }

        public void MyWebRequest(string url, string method, string data)
        {
            request = WebRequest.Create(url);
            if (method.Equals("GET") || method.Equals("POST"))
            {
                // Set the Method property of the request to POST.
                request.Method = method;
            }
            else
            {
                throw new Exception("Invalid Method Type");
            }

            // Create POST data and convert it to a byte array.
            string postData = data;

            if (request.Method == "POST")
            {
                // Create POST data and convert it to a byte array.
                byte[] byteArray = Encoding.UTF8.GetBytes(data);

                // Set the ContentType property of the WebRequest.
                request.ContentType = "application/x-www-form-urlencoded";

                // Set the ContentLength property of the WebRequest.
                request.ContentLength = byteArray.Length;
                // Get the request stream.
                dataStream = request.GetRequestStream();

                // Write the data to the request stream.
                dataStream.Write(byteArray, 0, byteArray.Length);

                // Close the Stream object.
                dataStream.Close();
            }
            else
            {
                String finalUrl = string.Format("{0}{1}", url, "?" + data);
                request = WebRequest.Create(finalUrl);

                WebResponse response = request.GetResponse();

                //Now, we read the response (the string), and output it.
                dataStream = response.GetResponseStream();
            }



        }

        public string GetResponse()
        {
            // Get the original response.
            WebResponse response = request.GetResponse();

            this.Status = ((HttpWebResponse)response).StatusDescription;

            // Get the stream containing all content returned by the requested server.
            dataStream = response.GetResponseStream();

            // Open the stream using a StreamReader for easy access.
            StreamReader reader = new StreamReader(dataStream);

            // Read the content fully up to the end.
            string responseFromServer = reader.ReadToEnd();

            // Clean up the streams.
            reader.Close();
            dataStream.Close();
            response.Close();

            return responseFromServer;
        }

        #endregion
        #region DECOMPRESSION method
        public void decompress(string gzip, string filenew)
        {
            try
            {
                FileStream sourceFileStream = File.OpenRead(gzip);
                FileStream destFileStream = File.Create(filenew);

                GZipStream decompressingStream = new GZipStream(sourceFileStream,
                    CompressionMode.Decompress);
                int byteRead;
                while ((byteRead = decompressingStream.ReadByte()) != -1)
                {
                    destFileStream.WriteByte((byte)byteRead);
                }

                decompressingStream.Close();
                sourceFileStream.Close();
                destFileStream.Close();
            }
            catch (FileNotFoundException)
            {
                MessageBox.Show("Error: File Not Found");
            }
        }
        #endregion
        #region Getting Ip Adress
        public string GetLocalIPAddress()
        {
            var host = Dns.GetHostEntry(Dns.GetHostName());
            foreach (var ip in host.AddressList)
            {
                if (ip.AddressFamily == AddressFamily.InterNetwork)
                {
                    return ip.ToString();
                }
            }
            throw new Exception("No network adapters with an IPv4 address in the system!");
        }
        #endregion

        private void open_Click(object sender, EventArgs e)
        {
            locationcbx.Items.Clear();
            //create the constructor with post type and few data
            string website = Protocol + iptb.Text + "/data/api/getdatalocation.php";
            statuslabel.Text = "Connecting: " + website;
            try
            {
                MyWebRequest(website, "GET", "");
                result = GetResponse();
                JObject rss = JObject.Parse(result);
                JArray item = (JArray)rss["location"];
                foreach (string s in item)
                {
                    locationcbx.Items.Add(s);
                }
            }
            catch (ArgumentNullException)
            {
                statuslabel.Text = "Nothing Found in the Server";
            }
            catch (WebException)
            {
                statuslabel.Text = "Failure to Connect to the Server";
            }
            statuslabel.Text = "Generate Complete!";
        }
    }
}
