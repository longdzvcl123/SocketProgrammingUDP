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

namespace Client
{
    public partial class clientForm : Form
    {
        public Socket socketClient;                                         //Socket of client
        private const int bufSize = 8 * 1024;                               //Size of buffer
        private State state = new State();                                  //class initialize buffer
        private EndPoint epFrom = new IPEndPoint(IPAddress.Any, 0);         //IP and Port from 
        private AsyncCallback recv = null;
        public static string data;                                          //Data from server
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

                    byte[] req = new byte[bytes];
                    Array.Copy(state.buffer, req, bytes);

                    data = Encoding.UTF8.GetString(req);

                    if (data == "Disconnection")
                        disconnectFromServer();

                    if (data == "Agree to connect")
                        MessageBox.Show("Connection complete!", "Notify", MessageBoxButtons.OK);

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
                DialogResult res = MessageBox.Show("  Server has been disconnected!!!\nDo you want to close client?", "Notify"
                    , MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (res == DialogResult.Yes) this.Close();

                socketClient.Shutdown(SocketShutdown.Both);
                socketClient.Disconnect(true);

            }
            catch { }
        }

        //Xu li Toolbox tu Form
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

        private void connectServer_Click(object sender, EventArgs e)
        {
            try
            {
                socketClient = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
                socketClient.Connect(new IPEndPoint(IPAddress.Parse(ipBox.Text), Int32.Parse(portBox.Text)));
                epFrom = new IPEndPoint(IPAddress.Parse(ipBox.Text), Int32.Parse(portBox.Text));

                receiveData();
                sendRequest("Connection...");

            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void disconnectServer_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult res = MessageBox.Show("  Disconnect from the server!!!\nDo you want to close client?", "Notify"
                  , MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (res == DialogResult.Yes) this.Close();

                sendRequest("Disconnection!!!");

                socketClient.Shutdown(SocketShutdown.Both);
                socketClient.Disconnect(true);
            }
            catch { }
        }

        private void displayAll_Click(object sender, EventArgs e)
        {
            try
            {
                ManyObj Objs = new ManyObj();
                sendRequest("Send all locations");
                Objs.Show();
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
                OneObj Obj = new OneObj();
                if (ordinalNumber.Text != "Enter ordinal number")
                {
                    sendRequest(ordinalNumber.Text);
                    if (data == "No data!!!") 
                    {
                        MessageBox.Show("The server does not have this data !", "No data", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else {
                        Obj.Show();
                    }
                }
                else
                {
                    MessageBox.Show("You have not entered the request!!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ordinalNumber_Click(object sender, EventArgs e)
        {
            if (ordinalNumber.Text != "Enter ordinal number") return;
            ordinalNumber.Text = "";
            ordinalNumber.ForeColor = Color.Black;
        }

        private void ordinalNumber_Leave(object sender, EventArgs e)
        {
            if (ordinalNumber.Text != "") return;
            ordinalNumber.Text = "Enter ordinal number";
            ordinalNumber.ForeColor = Color.Gray;
        }
    }
}
