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
    public partial class Form2 : Form
    {
        function fn = new function();
        string query;
        public Form2()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            string category = combocategory.Text;
            query = "select name from items where category='" + category + "' and name like '"+txtsearch.Text+"%'";
            DataSet ds = fn.getData(query);
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                listBox1.Items.Add(ds.Tables[0].Rows[i][0].ToString());
            }



        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void combocategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            string category = combocategory.Text;
            query = "select name from items where category='" + category + "'";
            DataSet ds = fn.getData(query);
            for(int i=0;i<ds.Tables[0].Rows.Count;i++)
            {
                listBox1.Items.Add(ds.Tables[0].Rows[i][0].ToString());
            }


        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            numquantity.ResetText();
            textprice.Clear();

            string text = listBox1.GetItemText(listBox1.SelectedItem);
            txtitemname.Text = text;
            query = "select price from items where name='" + text + "'";
            DataSet ds = fn.getData(query);

            try
            {
                txtprice.Text = ds.Tables[0].Rows[0][0].ToString();
            }
            catch { }
        }

        private void numquantity_ValueChanged(object sender, EventArgs e)
        {
            Int64 quan = Int64.Parse(numquantity.Value.ToString());
            Int64 price = Int64.Parse(txtprice.Text);
            textprice.Text = (quan * price).ToString();
        }


        int amount;
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                amount = int.Parse(dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString());
            }
            catch { }

        }

        
        private void btnremove_Click(object sender, EventArgs e)
        {
            try
            {
                dataGridView1.Rows.RemoveAt(this.dataGridView1.SelectedRows[0].Index);
            }
            catch { }
            total -= amount;
            lbltotalamount.Text = "Rs. " + total;
        }
        protected int n, total = 0;

        private void button1_Click(object sender, EventArgs e)
        {
            Dashboard ds = new Dashboard();
            this.Hide();
            ds.Show();
        }

        private void btnorder_Click(object sender, EventArgs e)
        {
            if (textprice.Text != "0" && textprice.Text != "")
            {
                n = dataGridView1.Rows.Add();
                dataGridView1.Rows[n].Cells[0].Value = txtitemname.Text;
                dataGridView1.Rows[n].Cells[1].Value = txtprice.Text;
                dataGridView1.Rows[n].Cells[2].Value = numquantity.Value;
                dataGridView1.Rows[n].Cells[3].Value = textprice.Text;

                total += int.Parse(textprice.Text);
                lbltotalamount.Text = "Rs. " + total;
            }
            else
            {
                MessageBox.Show("Minimum Quantity needs to be 1", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }

        }
    }
}
