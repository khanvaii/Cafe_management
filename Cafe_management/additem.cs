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
    public partial class additem : Form
    {
        function fn = new function();
        string query;

        public additem()
        {
            InitializeComponent();
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void btnadditem_Click(object sender, EventArgs e)
        {
            query = "insert into items (name,category,price) values('" + textitem.Text + "','" + textcategory.Text + "','" + textprice.Text + "')";
            fn.setData(query);
            clearall();
        }
        public void clearall()
        {

            textcategory.SelectedIndex = -1;
            textitem.Clear();
            textprice.Clear();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Dashboard ds = new Dashboard();
            this.Hide();
            ds.Show();
            
        }
    }
}

