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
    public partial class Dashboard : Form
    {
        public Dashboard()
        {
            InitializeComponent();
        }

        public Dashboard(string user)
        {
            InitializeComponent();
            if(user=="Guest")
            {
                btnadd.Hide();
                btnupdate.Hide();
                btnremove.Hide();
            }
            else if(user=="Admin")
            {
                btnadd.Show();
                btnupdate.Show();
                btnremove.Show();
            }
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            Remove rm = new Remove();
            rm.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Form2 pc = new Form2();
            pc.Show();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Form1 fm = new Form1();
            this.Hide();
            fm.Show();
        }
        int num = 0;

        private void timer1_Tick(object sender, EventArgs e)
        {
            if(num==0)
            {

                labelBanner.Location = new Point(94, 427);
                labelBanner.ForeColor = Color.Orange;
                num++;
            }
            else if(num==1)
            {

                labelBanner.Location = new Point(215, 427);
                labelBanner.ForeColor = Color.Green;
                num++;
            }
            else if(num==2)
            {

                labelBanner.Location = new Point(390, 427);
                labelBanner.ForeColor = Color.RoyalBlue;
                num=0;
            }

                 
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            timer1.Start();

        }

        private void btnadd_Click(object sender, EventArgs e)
        {
            
            additem ad = new additem();
           
            
            ad.Show();
            
           
           
           

            

        }

        private void btnupdate_Click(object sender, EventArgs e)
        {
            update up = new update();
            up.Show();
         
            

        }
    }
}
