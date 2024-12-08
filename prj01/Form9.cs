using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace prj01
{
    public partial class Form9 : Form
    {
        DBClass dbc = new DBClass();

        int itemId;
        private string strCommand;

        public int getItemId { get { return itemId; } }
        public string getstrCommand { get { return strCommand; } }

        public Form9()
        {
            InitializeComponent();
            dbc.DB_Access();
        }

        public void searchItem()
        {
            String selectQuery = "SELECT i.item_no, sc.name AS sub_category_name, i.name AS item_name, i.price, i.stock FROM item i JOIN sub_category sc ON i.sub_category_no = sc.sub_category_no WHERE i.delCheck = 0";

            dbc.Comm.CommandText = selectQuery;
            dbc.Dr = dbc.Comm.ExecuteReader();

            DataTable dt = new DataTable();

            dt.Load(dbc.Dr);

            dataGridView1.DataSource = dt;

            dataGridView1.Columns["item_no"].HeaderText = "상품번호";
            dataGridView1.Columns["sub_category_name"].HeaderText = "소분류";
            dataGridView1.Columns["item_name"].HeaderText = "상품명";
            dataGridView1.Columns["price"].HeaderText = "가격";
            dataGridView1.Columns["stock"].HeaderText = "재고";

        }

        public int deleteItem()
        {
            String updateQuery = @"UPDATE item SET delCheck = 1 
                                    WHERE item_no = :itemNo";

            dbc.Comm.CommandText = updateQuery;
            dbc.Comm.Parameters.Clear();
            dbc.Comm.Parameters.Add("itemNo", itemId);
            int result = dbc.Comm.ExecuteNonQuery();

            return result;
        }

        private void Form9_Load(object sender, EventArgs e)
        {
            searchItem();
        }

        private void AddItemBtn_Click(object sender, EventArgs e)
        {
            strCommand = "상품추가";
            Form10 form10 = new Form10(this);
            DialogResult result = form10.ShowDialog();
            if(result == DialogResult.OK)
            {
                MessageBox.Show("상품추가 성공!");
                searchItem();
            }
        }

        private void UpdateItemBtn_Click(object sender, EventArgs e)
        {
            strCommand = "상품수정";

            if (dataGridView1.SelectedRows.Count > 0)
            {
                itemId = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells[0].Value);
                Form10 form10 = new Form10(this);
                DialogResult result = form10.ShowDialog();
                if (result == DialogResult.OK)
                {
                    MessageBox.Show("상품수정 성공!");
                    searchItem();
                }
            }
        }

        private void DeleteItemBtn_Click(object sender, EventArgs e)
        {
            strCommand = "상품삭제";

            if (dataGridView1.SelectedRows.Count > 0)
            {
                itemId = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells[0].Value);
                int result = deleteItem();
                if (result > 0)
                {
                    MessageBox.Show("상품삭제 성공!");
                    searchItem();
                }
            }
        }

        private void 상품추가ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            strCommand = "상품추가";
            Form10 form10 = new Form10(this);
            DialogResult result = form10.ShowDialog();
            if (result == DialogResult.OK)
            {
                MessageBox.Show("상품추가 성공!");
                searchItem();
            }
        }

        private void 상품수정ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            strCommand = "상품수정";

            if (dataGridView1.SelectedRows.Count > 0)
            {
                itemId = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells[0].Value);
                Form10 form10 = new Form10(this);
                DialogResult result = form10.ShowDialog();
                if (result == DialogResult.OK)
                {
                    MessageBox.Show("상품수정 성공!");
                    searchItem();
                }
            }
        }

        private void 상품삭제ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            strCommand = "상품삭제";

            if (dataGridView1.SelectedRows.Count > 0)
            {
                itemId = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells[0].Value);
                int result = deleteItem();
                if (result > 0)
                {
                    MessageBox.Show("상품삭제 성공!");
                    searchItem();
                }
            }
        }
    }
}
