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

namespace Server
{
    public partial class serverForm : Form
    {
        private Socket socketServer;
        private const int bufSize = 20 * 1024;
        private State state = new State();
        private EndPoint epFrom = new IPEndPoint(IPAddress.Any, 0); //
        private AsyncCallback recv = null;
        public string request;
        //private List<EndPoint> ClientSockets;  // EndPoint : IP-Port
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

                    byte[] req = new byte[bytes];
                    Array.Copy(state.buffer, req, bytes);

                    request = Encoding.UTF8.GetString(req);

                    this.Invoke(new MethodInvoker(delegate
                    {
                        richTextBox1.Text += "\nRequest from " + epFrom.ToString() + ": " + request;
                    }));

                    Array.Clear(state.buffer, 0, bufSize);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("ReceiveData Error: " + ex.Message, "UDP Server", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }, state);
        }

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
                richTextBox1.Text += "Server listening!!!\n";
            }
            catch (Exception ex)
            {
                richTextBox1.Text += ex.Message.ToString() + "\n";
            }
        }
        private void stopConnect_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Do you want to stop the connection?", "Exit",
                MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);

            socketServer.Close();
            if (result == DialogResult.Yes)
                this.Close();
        }
    }
}
