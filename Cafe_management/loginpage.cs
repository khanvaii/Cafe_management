using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Cafe_management
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Dashboard ds = new Dashboard("Guest");
            ds.Show();
            this.Hide();
        }

        private void btnlogin_Click(object sender, EventArgs e)
        {
            if(txtusername.Text=="kausal" && txtpassword.Text=="khan")
            {
                Dashboard ds = new Dashboard("Admin");
               
                ds.Show();
                this.Hide();

            }
            else
            {
                Form1 fm = new Form1();
                fm.Show();
            }
        }
    }
}
