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
    public partial class Remove : Form
    {
        function fn = new function();
        string query;
        public Remove()
        {
            InitializeComponent();
        }

        private void dellabel_Click(object sender, EventArgs e)
        {
            dellabel.ForeColor = Color.Red;
            dellabel.Text = "*Click On Row To Delete The Item.";
        }

        private void Remove_Load(object sender, EventArgs e)
        {
            dellabel.Text = "How To Delete?";
            dellabel.ForeColor = Color.Blue;
            loadData();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Dashboard ds = new Dashboard();
            this.Hide();
            ds.Show();
        }
        public void loadData()
        {
            query = "select * from items";

            DataSet ds = fn.getData(query);
            dataGridView1.DataSource = ds.Tables[0];
        }

        private void txtsearch_TextChanged(object sender, EventArgs e)
        {

            query = "select * from items where name like '" + txtsearch.Text + "%'";
            DataSet ds = fn.getData(query);
            dataGridView1.DataSource = ds.Tables[0];
       
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (MessageBox.Show("Delete Item?", "Important message", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
            {
                int id = int.Parse(dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString());
                query = "delete from items where iid='" + id + "' ";
                fn.setData(query);
                loadData();
            }
        }
    }
}
