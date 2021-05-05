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
    public partial class update : Form
    {
        function fn = new function();
        string query;
        public update()
        {
            InitializeComponent();
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void update_Load(object sender, EventArgs e)
        {
           
            loadData();
          
        }
        public void loadData()
        {
            query = "select * from items";
           
            DataSet ds = fn.getData(query);
            dataGridView1.DataSource = ds.Tables[0];
        }

        private void txtsearchitemname_TextChanged(object sender, EventArgs e)
        {
            query = "select * from items where name like '" + txtsearchitemname.Text + "%'";
            loadData();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            Dashboard ds = new Dashboard();
            this.Hide();
            ds.Show();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        int id;

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            id = int.Parse(dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString());
            string category = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
            string name = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
            int price = int.Parse(dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString());

            txtcategory.Text = category;
            txtname.Text = name;
            txtprice.Text = price.ToString();

        }

        private void btnupdate_Click(object sender, EventArgs e)
        {
            query = "update items set name='"+txtname.Text+"',category='"+txtcategory.Text+"',price='"+txtprice.Text+"' where iid="+id+"";
            fn.setData(query);
            loadData();

            txtname.Clear();
            txtcategory.Clear();
            txtprice.Clear();
        }
    }
}
