using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Client
{
    public partial class ManyObj : Form
    {
        public ManyObj()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ManyObj_Load(object sender, EventArgs e)
        {
            richTextBox1.Text = clientForm.data1;
            sendRequest("Receive complete!!!");
        }
        public void sendRequest(string text)
        {
            IPEndPoint ip_port_server = new IPEndPoint(IPAddress.Parse(clientForm.IpServer), Int32.Parse(clientForm.portServer));

            byte[] data = Encoding.ASCII.GetBytes(text);
            clientForm.socketClient.SendTo(data, ip_port_server);
        }
    }
}
