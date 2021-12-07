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
using System.Threading;

namespace Client
{
    public partial class clientForm : Form
    {
        public static Socket socketClient;                                  //Socket cua client
        private const int bufSize = 70000;                                  //Kich thuoc cua buffer
        private State state = new State();                                  //class khoi tao buffer
        private EndPoint epFrom = new IPEndPoint(IPAddress.Any, 0);         //Khoi tao bien chua Ip-Port 
        private AsyncCallback recv = null;
        public static string IpServer;                                      //Ip cua server da ket noi
        public static string portServer;                                    //Port cuar server da ket noi
        public static OneObj Obj = new OneObj();                            //Khoi tao form cua mot dia diem
        public static ManyObj Objs = new ManyObj();                         //Khoi tao form cua nhieu dia diem
        public static FormImage img = new FormImage();                      //Khoi tao form cua cac hinh anh
        public static string data1;                                         //Data nhan tu server (kieu chuoi)
        public static byte[] data2;                                         //Data nhan tu server (kieu Byte)
        public static string idData = null;
        public clientForm()
        {
            InitializeComponent();
        }
        public class State
        {
            public byte[] buffer = new byte[bufSize];
        }
        private void receiveData()
        {
            socketClient.BeginReceiveFrom(state.buffer, 0, bufSize, SocketFlags.None, ref epFrom, recv = (ar) =>
            {
                try
                {
                    State so = (State)ar.AsyncState;
                    int bytes = socketClient.EndReceiveFrom(ar, ref epFrom);
                    socketClient.BeginReceiveFrom(so.buffer, 0, bufSize, SocketFlags.None, ref epFrom, recv, so);

                    //Xu ly du lieu nhan
                    byte[] req = new byte[bytes];
                    Array.Copy(state.buffer, req, bytes);

                    data1 = Encoding.UTF8.GetString(req);
                    data2 = req;

                    if (data1 == "Disconnection")
                        disconnectFromServer();

                    if (data1 == "Agree to connect")
                        MessageBox.Show("Connection complete!", "Notification from client", MessageBoxButtons.OK, MessageBoxIcon.Question);
                    Array.Clear(state.buffer, 0, bufSize);

                }
                catch (Exception ex)
                {
                    MessageBox.Show("ReceiveData Error: " + ex.Message, "UDP Client", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }, state);
        }

        public void sendRequest(string text)
        {
            byte[] data = Encoding.ASCII.GetBytes(text);
            socketClient.SendTo(data, epFrom);
        }
        private void disconnectFromServer()
        {
            try
            {
                DialogResult res = MessageBox.Show("Server has been disconnected!!!\nDo you want to close client?", "Notification from client"
                    , MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (res == DialogResult.Yes) this.Close();
                setFromClear();
                socketClient.Shutdown(SocketShutdown.Both);
                socketClient.Disconnect(true);

            }
            catch { }
        }
        private void setFromClear()
        {
            checkBox1.Checked = false;
            ipBox.Text = "Enter IP";                            ipBox.ForeColor = Color.Gray;
            portBox.Text = "Enter port";                        portBox.ForeColor = Color.Gray;
            ordinalNumber.Text = "Enter ordinal number (1-10)"; ordinalNumber.ForeColor = Color.Gray;
        }

        //Xu li Toolbox cua Form
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

        private void ordinalNumber_Click(object sender, EventArgs e)
        {
            if (ordinalNumber.Text != "Enter ordinal number (1-10)") return;
            ordinalNumber.Text = "";
            ordinalNumber.ForeColor = Color.Black;
        }

        private void ordinalNumber_Leave(object sender, EventArgs e)
        {
            if (ordinalNumber.Text != "") return;
            ordinalNumber.Text = "Enter ordinal number (1-10)";
            ordinalNumber.ForeColor = Color.Gray;
        }
        private void connectServer_Click(object sender, EventArgs e)
        {
            try
            {
                socketClient = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
                socketClient.Connect(new IPEndPoint(IPAddress.Parse(ipBox.Text), Int32.Parse(portBox.Text)));
                epFrom = new IPEndPoint(IPAddress.Parse(ipBox.Text), Int32.Parse(portBox.Text));

                IpServer = ipBox.Text; portServer = portBox.Text;

                receiveData();
                sendRequest("Connection...");

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void disconnectServer_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult res = MessageBox.Show("Do you want to disconnect from the server?", "Notification from client"
                  , MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (res == DialogResult.Yes)
                {
                    this.Close();
                    sendRequest("Disconnection!!!");

                    setFromClear();

                    socketClient.Shutdown(SocketShutdown.Both);
                    socketClient.Disconnect(true);
                }
                else return;
            }
            catch { }
        }

        private void displayAll_Click(object sender, EventArgs e)
        {
            try
            {
                sendRequest("Send all locations");
                string dataBef = data1;
                while (true)
                {
                    if (data1 != dataBef)
                        break;
                }
                Objs.ShowDialog();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void search_Click(object sender, EventArgs e)
        {
            try
            {
                int num = Int32.Parse(ordinalNumber.Text);

                if (ordinalNumber.Text != "Enter ordinal number (1-10)" && num > 0 && num <= 10)
                {
                    sendRequest(num.ToString());
                    if (data1 == "No data!!!")
                    {
                        MessageBox.Show("The server does not have this data !", "No data", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        idData = num.ToString();
                        string dataBef = data1;
                        while (true)
                        {
                            if (data1 != dataBef)
                                break;
                        }
                        Obj.ShowDialog();
                    }
                }
                else
                {
                    MessageBox.Show("You have not entered the request or Incorrect request!!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
