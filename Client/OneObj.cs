using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO.MemoryMappedFiles;

namespace Client
{
    public partial class OneObj : Form
    {
        public OneObj()
        {
            InitializeComponent();
        }
        public void sendRequest(string text)
        {
            IPEndPoint ip_port_server = new IPEndPoint(IPAddress.Parse(clientForm.IpServer), Int32.Parse(clientForm.portServer));

            byte[] data = Encoding.ASCII.GetBytes(text);
            clientForm.socketClient.SendTo(data, ip_port_server);
        }

        private void OneObj_Load(object sender, EventArgs e)
        {
            string tmp = clientForm.data1;
            string id = "", name = "", latitude = "", longtitude = "", allegory = "";

            for (int i = 1; i <= 4; i++)
            {
                string str;
                int index = tmp.IndexOf('-');
                str = tmp.Substring(0, index);
                switch (i)
                {
                    case 1:
                        id = str;
                        break;
                    case 2:
                        name = str;
                        break;
                    case 3:
                        latitude = str;
                        break;
                    case 4:
                        longtitude = str;
                        allegory = tmp.Substring(index + 1);
                        break;
                }
                tmp = tmp.Substring(index + 1);
            }
            richTextBox1.Text = "Id: " + id + "\nName: " + name + "\nLocation:\n-Latitude: " +
                latitude + "\n-Longtitude: " + longtitude + "\nAllegory: " + allegory + "\n";

            sendRequest(clientForm.idData + "Send image1");
            }

        private void button1_Click(object sender, EventArgs e)
        {
            clientForm.img = new FormImage();
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                clientForm.img.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
    }
}
