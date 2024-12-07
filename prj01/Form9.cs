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

        private string strCommand;
        public string getstrCommand { get { return strCommand; } }

        public Form9()
        {
            InitializeComponent();
            dbc.DB_Open();
        }

        public void searchItem()
        {
            String selectQuery = "SELECT i.item_no, sc.name AS sub_category_name, i.name AS item_name, i.price, i.stock FROM item i JOIN sub_category sc ON i.sub_category_no = sc.sub_category_no ";

            dbc.Comm.CommandText = selectQuery;
            dbc.Da.SelectCommand = dbc.Comm;
            dbc.Ds.Clear();
            dbc.Da.Fill(dbc.Ds);

            dataGridView1.DataSource = dbc.Ds.Tables[0];

            dataGridView1.Columns["item_no"].HeaderText = "상품번호";
            dataGridView1.Columns["sub_category_name"].HeaderText = "소분류";
            dataGridView1.Columns["item_name"].HeaderText = "상품명";
            dataGridView1.Columns["price"].HeaderText = "가격";
            dataGridView1.Columns["stock"].HeaderText = "재고";

        }

        private void Form9_Load(object sender, EventArgs e)
        {
            searchItem();
        }

        private void AddItemBtn_Click(object sender, EventArgs e)
        {
            strCommand = "상품추가";
            Form10 form10 = new Form10(this);
            form10.ShowDialog();
        }

        private void UpdateItemBtn_Click(object sender, EventArgs e)
        {
            strCommand = "상품수정";
        }
    }
}
