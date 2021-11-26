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
    }
}
