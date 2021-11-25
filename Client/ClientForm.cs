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

namespace Client
{
    public partial class clientForm : Form
    {
        public clientForm()
        {
            InitializeComponent();
        }

        private void sentData_Click(object sender, EventArgs e)
        {
            Client cl = new Client(IPAddress.Parse("127.3.7.9"), 09);
            //cl.Send("test");
        }
    }
}
