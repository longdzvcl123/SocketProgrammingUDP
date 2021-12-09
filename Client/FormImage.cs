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

namespace Client
{
    public partial class FormImage : Form
    {
        
        private Image[] listImage = new Image[3];      //List Image
        public FormImage()
        {
            InitializeComponent();
        }

        private void FormImage_Load(object sender, EventArgs e)
        {
            string dataBefor = clientForm.data1;
            sendRequest(clientForm.idData + "Send image1");
            while (clientForm.data1 == dataBefor) ;
            int n = 0;
            while (true)
            {
                byte[] b = clientForm.data2;
                MemoryStream ms = new MemoryStream(b);
                Image p = Image.FromStream(ms);

                listImage[n++] = p;

                if (n == 1)
                    sendRequest(clientForm.idData + "Send image2");
                else if (n == 2)
                    sendRequest(clientForm.idData + "Send image3");
                else
                    sendRequest("Receive complete!!!");

                while (b == clientForm.data2) ;

                if (clientForm.data1 == "Send complete!!!") break;
            }

            pictureBox1.Image = listImage[0];
            pictureBox2.Image = listImage[1];
            pictureBox3.Image = listImage[2];

            this.DoubleBuffered = true; // minimizes the strutter
        }
        public void sendRequest(string text)
        {
            IPEndPoint ip_port_server = new IPEndPoint(IPAddress.Parse(clientForm.IpServer), Int32.Parse(clientForm.portServer));

            byte[] data = Encoding.ASCII.GetBytes(text);
            clientForm.socketClient.SendTo(data, ip_port_server);
        }
        Image ZoomPicture(Image img, Size size)
        {
            Bitmap bm = new Bitmap(img, Convert.ToInt32(img.Width * size.Width),
                Convert.ToInt32(img.Height * size.Height));
            Graphics gpu = Graphics.FromImage(bm);
            gpu.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
            return bm;
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            if (trackBar1.Value != 0)
            {
                pictureBox1.Image = null;
                pictureBox1.Image = ZoomPicture(listImage[0], new Size(trackBar1.Value, trackBar1.Value));
            }
        }

        private void trackBar2_Scroll(object sender, EventArgs e)
        {
            if (trackBar2.Value != 0)
            {
                pictureBox2.Image = null;
                pictureBox2.Image = ZoomPicture(listImage[1], new Size(trackBar2.Value, trackBar2.Value));
            }
        }

        private void trackBar3_Scroll(object sender, EventArgs e)
        {
            if (trackBar3.Value != 0)
            {
                pictureBox3.Image = null;
                pictureBox3.Image = ZoomPicture(listImage[2], new Size(trackBar3.Value, trackBar3.Value));
            }
        }

        private void closeButton_Click(object sender, EventArgs e)
        {
            listImage = new Image[3];
            this.Hide();
        }
    }
}
