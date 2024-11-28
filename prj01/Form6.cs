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
    public partial class Form6 : Form
    {
        DBClass dbc = new DBClass();
        int cartNo;

        DataTable dt1 = new DataTable(); // dataGridView1 용
        DataTable dt2 = new DataTable(); // dataGridView2 용



        public Form6(int memberNo)
        {
            InitializeComponent();
            dbc.MemberNo = memberNo;
            dbc.DB_Access();
        }

        public void searchOrders()
        {
            DateTime startDate = dateTimePicker1.Value.Date;
            DateTime endDate = dateTimePicker2.Value.Date.AddDays(1).AddSeconds(-1);

            String selectQuery = @"SELECT o.order_no, o.cart_no, TO_CHAR(o.order_date, 'YYYY-MM-DD') AS order_date, o.order_price 
                                    FROM orders o 
                                    JOIN cart c ON o.cart_no = c.cart_no 
                                    WHERE c.member_no = :memberNo 
                                    AND o.order_date BETWEEN :startDate AND :endDate
                                    ORDER BY o.order_no DESC";

            dbc.Comm.CommandText = selectQuery;
            dbc.Comm.Parameters.Clear();
            dbc.Comm.Parameters.Add("memberNo", dbc.MemberNo);
            dbc.Comm.Parameters.Add("startDate", startDate);
            dbc.Comm.Parameters.Add("endDate", endDate);
            dbc.Dr = dbc.Comm.ExecuteReader();

            dt1.Clear();
            dt1.Load(dbc.Dr);

            if (dt1.Rows.Count == 0)
            {
                MessageBox.Show("조회된 결과가 없습니다.");
            }
            else
            {
                dataGridView1.DataSource = dt1;

                dataGridView1.Columns["order_no"].HeaderText = "주문번호";
                dataGridView1.Columns["cart_no"].HeaderText = "장바구니 번호";
                dataGridView1.Columns["order_date"].HeaderText = "주문날짜";
                dataGridView1.Columns["order_price"].HeaderText = "결제금액";
            }
        }
        public void searchCartDetail(int cartNo)
        {
            String selectQuery = @"SELECT i.item_no, sc.name AS sub_category_name, i.name AS item_name, cd.count, cd.total_price 
                                    FROM cart_detail cd 
                                    JOIN item i ON cd.item_no = i.item_no 
                                    JOIN sub_category sc ON i.sub_category_no = sc.sub_category_no  
                                    WHERE cart_no = :cartNo 
                                    ORDER BY i.item_no ASC";

            dbc.Comm.CommandText = selectQuery;
            dbc.Comm.Parameters.Clear();
            dbc.Comm.Parameters.Add("cartNo", cartNo);
            dbc.Dr = dbc.Comm.ExecuteReader();
            dt2.Clear();
            dt2.Load(dbc.Dr);


            dataGridView2.DataSource = dt2;

            dataGridView2.Columns["item_no"].HeaderText = "상품번호";
            dataGridView2.Columns["sub_category_name"].HeaderText = "소분류";
            dataGridView2.Columns["item_name"].HeaderText = "상품명";
            dataGridView2.Columns["count"].HeaderText = "개수";
            dataGridView2.Columns["total_price"].HeaderText = "총 가격";
        }

        public void setDateTimePicker()
        {
            dateTimePicker1.Format = DateTimePickerFormat.Custom;
            dateTimePicker1.CustomFormat = "yyyy-MM-dd";
            dateTimePicker1.MaxDate = DateTime.Now;
            dateTimePicker1.Value = DateTime.Now.AddDays(-7);

            dateTimePicker2.Format = DateTimePickerFormat.Custom;
            dateTimePicker2.CustomFormat = "yyyy-MM-dd";
            dateTimePicker2.MaxDate = DateTime.Now;
            dateTimePicker2.Value = DateTime.Now;

        }

        private void Form6_Load(object sender, EventArgs e)
        {
            setDateTimePicker();
            searchOrders(); // 회원의 주문내역 조회
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            var value = dataGridView1.Rows[e.RowIndex].Cells[1].Value;

            if (value != null && value != DBNull.Value)
            {
                cartNo = Convert.ToInt32(value);
                searchCartDetail(cartNo);
            }

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            if (dateTimePicker1.Value > dateTimePicker2.Value)
            {
                dateTimePicker1.Value = dateTimePicker2.Value;
            }
        }

        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {
            if (dateTimePicker2.Value < dateTimePicker1.Value)
            {
                dateTimePicker1.Value = dateTimePicker2.Value;
            }
        }

        private void searchBtn_Click(object sender, EventArgs e)
        {
            dt2.Clear();
            searchOrders();
        }
    }
}
