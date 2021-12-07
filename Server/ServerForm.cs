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
using System.Net.Sockets;
using Newtonsoft.Json;
using System.IO;
using System.Drawing.Imaging;

namespace Server
{ 
    public partial class serverForm : Form
    {
        private Socket socketServer = null;                                    //Socket cua server
        private const int bufSize = 70000;                                     //Kich thuoc cua buffer
        private State state = new State();                                     //Class khoi tao buffer
        private EndPoint epFrom = new IPEndPoint(IPAddress.Any, 0);            //Khoi tao bien chua Ip-Port
        private AsyncCallback recv = null;
        public string request;                                                 //Yeu cau cua client
        private List<EndPoint> listClient = new List<EndPoint>();              //Danh sach cac client da ket noi
        public serverForm()
        {
            InitializeComponent();
        }
        public class State
        {
            public byte[] buffer = new byte[bufSize];
        }

        private void sendDataTo(string text)
        {
            byte[] data = Encoding.ASCII.GetBytes(text);
            socketServer.SendTo(data, epFrom);
        }

        private void receiveRequest()
        {
            socketServer.BeginReceiveFrom(state.buffer, 0, bufSize, SocketFlags.None, ref epFrom, recv = (ar) =>
            {
                try
                {
                    State so = (State)ar.AsyncState;
                    int bytes = socketServer.EndReceiveFrom(ar, ref epFrom);
                    socketServer.BeginReceiveFrom(so.buffer, 0, bufSize, SocketFlags.None, ref epFrom, recv, so);

                    //Xu li du lieu nhan
                    byte[] req = new byte[bytes];
                    Array.Copy(state.buffer, req, bytes);

                    request = Encoding.UTF8.GetString(req);
                    if (request == "Connection...")
                    {
                        listClient.Add(epFrom);
                        sendDataTo("Agree to connect");
                    }
                    else if (request == "Disconnection!!!")
                    {
                        listClient.Remove(epFrom);
                        sendDataTo("Complete disconnection!!!");
                    }
                    else if (request == "Receive complete!!!")
                    {
                        sendDataTo("Send complete!!!");
                    }
                    else if (request == "Send all locations")
                    {
                        string data = takeManyObjs();
                        sendDataTo(data);
                    }
                    else if (request.Contains("Send image"))
                    {
                        string idData = request.Substring(0, 1);
                        if (request[1] == '0')
                        {
                            idData += '0';
                        }
                        string numImage = request.Replace(idData + "Send ", "");
                        sendImage(idData, numImage);
                        request = request.Substring(idData.Length - 1);
                    }
                    else
                    {
                        sendOneObj(request);
                    }
                    this.Invoke(new MethodInvoker(delegate
                    {
                        richTextBox1.Text += "\nRequest from " + epFrom.ToString() + ": " + request;
                    }));

                    Array.Clear(state.buffer, 0, bufSize);
                }
                catch { }

            }, state);
        }
        private void sendImage(string n, string numImage)
        {
            dynamic readJson = JsonConvert.DeserializeObject(File.ReadAllText("Data.json"));
            string nameImage = readJson[n][numImage];

            MemoryStream ms = new MemoryStream();
            Bitmap bmp = new Bitmap(nameImage);
            bmp.Save(ms, ImageFormat.Jpeg);

            socketServer.SendTo(ms.ToArray(), epFrom);
        }
        private void sendOneObj(string n)
        {
            try
            {
                string str = "";
                dynamic readJson = JsonConvert.DeserializeObject(File.ReadAllText("Data.json"));

                str = n + "-" + readJson[n]["name"] + "-" + readJson[n]["longitude"]
                    + "-" + readJson[n]["latitude"] + "-" + readJson[n]["allegory"];
                sendDataTo(str);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        private string takeManyObjs()
        {
            string str = "";

            dynamic readJson = JsonConvert.DeserializeObject(File.ReadAllText("Data.json"));

            for (int i = 1; i <= 10; i++)
            {
                string num = i.ToString();
                str += "Id: " + num + "\nName: " + readJson[num]["name"]
                    + "\nLocation: \n-Latitude: " + readJson[num]["latitude"] +
                    "\n-Longitude: " + readJson[num]["longitude"] + "\nAllegory: " + readJson[num]["allegory"] + "\n\n";
            }
            return str;
        }
        
        //Xu ly toolbox theo form
        private void ipBox_Click(object sender, EventArgs e)
        {
            if (ipBox.Text != "Enter IP") return;
            ipBox.Text = "";
            ipBox.ForeColor = Color.Black;
        }

        private void ipBox_Leave(object sender, EventArgs e)
        {
            if (ipBox.Text != "") return;
            ipBox.Text = "Enter IP";
            ipBox.ForeColor = Color.Gray;
        }

        private void portBox_Click(object sender, EventArgs e)
        {
            if (portBox.Text != "Enter port") return;
            portBox.Text = "";
            portBox.ForeColor = Color.Black;
        }

        private void portBox_Leave(object sender, EventArgs e)
        {
            if (portBox.Text != "") return;
            portBox.Text = "Enter port";
            portBox.ForeColor = Color.Gray;
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                ipBox.Text = "127.3.7.9";
                portBox.Text = "9";
                ipBox.ForeColor = portBox.ForeColor = Color.Black;
            }
            else
            {
                ipBox.Text = "Enter IP";
                portBox.Text = "Enter port";
                ipBox.ForeColor = portBox.ForeColor = Color.Gray;
            }
        } 
        private void openConnection(object sender, EventArgs e)
        {
            try
            {
                socketServer = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
                socketServer.SetSocketOption(SocketOptionLevel.IP, SocketOptionName.ReuseAddress, true);
                socketServer.Bind(new IPEndPoint(IPAddress.Parse(ipBox.Text), Int32.Parse(portBox.Text)));

                receiveRequest();
                richTextBox1.Text += "\nServer listening!!!\n";
            }
            catch (Exception ex)
            {
                richTextBox1.Text += ex.Message.ToString() + "\n";
            }
        }
        private void stopConnect_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult result = MessageBox.Show("Do you want to stop the connection?", "Norification",
                MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);

                if (result == DialogResult.Yes)
                {
                    string text = "Disconnection";
                    for(int i = 0; i < listClient.Count; i++)
                    {
                        byte[] data = Encoding.ASCII.GetBytes(text);
                        socketServer.SendTo(data, listClient[i]);
                    }
                    this.Invoke(new MethodInvoker(delegate
                    {
                        richTextBox1.Text += "\nDisconnection...";
                    }));

                    checkBox1.Checked = false;
                    ipBox.Text = "Enter IP"; ipBox.ForeColor = Color.Gray;
                    portBox.Text = "Enter port"; portBox.ForeColor = Color.Gray;
                    recv = null;
                    socketServer.Close();
                }
            }
            catch { }
        }
    }
}
