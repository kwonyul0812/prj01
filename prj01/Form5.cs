using Oracle.DataAccess.Client;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Window;

namespace prj01
{
    public partial class Form5 : Form
    {
        DBClass dbc = new DBClass();
        int cartNo;
        int totalPrice = 0; // 총 구매 금액
        int stampUseCount = 0; // 사용할 스탬프 개수
        int orderPrice = 0; // 결제금액
        int ownedStampCount = 0; // 보유중인 스탬프 개수

        DataTable dt = new DataTable();

        public Form5(int cartNo, int memberNo)
        {
            InitializeComponent();
            dbc.MemberNo = memberNo;
            this.cartNo = cartNo;
            dbc.DB_Access();
        }

        public void searchCartDetail()
        {
            String selectQuery = "SELECT i.item_no, sc.name AS sub_category_name, i.name AS item_name, cd.count, cd.total_price FROM cart_detail cd JOIN item i ON cd.item_no = i.item_no JOIN sub_category sc ON i.sub_category_no = sc.sub_category_no  WHERE cart_no = :cartNo ORDER BY i.item_no ASC";

            dbc.Comm.CommandText = selectQuery;
            dbc.Comm.Parameters.Clear();
            dbc.Comm.Parameters.Add("cartNo", cartNo);
            dbc.Dr = dbc.Comm.ExecuteReader();
            dt.Load(dbc.Dr);

            dataGridView1.DataSource = dt;
            dataGridView1.Columns["item_no"].HeaderText = "상품번호";
            dataGridView1.Columns["sub_category_name"].HeaderText = "소분류";
            dataGridView1.Columns["item_name"].HeaderText = "상품명";
            dataGridView1.Columns["count"].HeaderText = "개수";
            dataGridView1.Columns["total_price"].HeaderText = "총 가격";

            dataGridView1.Columns[0].Width = 80;
            dataGridView1.Columns[1].Width = 80;
            dataGridView1.Columns[2].Width = 120;
            dataGridView1.Columns[3].Width = 80;
            dataGridView1.Columns[4].Width = 100;
        }

        public int insertOrders()
        {
            String insertQuery = "INSERT INTO orders (cart_no, order_price) VALUES (:carNo, :orderPrice) RETURNING order_no INTO :newOrderNo";

            dbc.Comm.CommandText = insertQuery;
            dbc.Comm.Parameters.Clear();
            dbc.Comm.Parameters.Add("cartNo", cartNo);
            dbc.Comm.Parameters.Add("orderPrice", Convert.ToInt32(orderPriceTxt.Text));
            OracleParameter outputOrderNo = new OracleParameter("newOrderNo", OracleDbType.Int32)
            {
                Direction = ParameterDirection.Output
            };
            dbc.Comm.Parameters.Add(outputOrderNo);
            int result = dbc.Comm.ExecuteNonQuery();

            if(result > 0)
            {
                return Convert.ToInt32(outputOrderNo.Value.ToString());
            }

            return 0;
        }

        public int updateCart()
        {
            String updateQuery = "UPDATE cart SET is_purchased = 'Y' WHERE cart_no = :cartNo";

            dbc.Comm.CommandText = updateQuery;
            dbc.Comm.Parameters.Clear();
            dbc.Comm.Parameters.Add("cartNo", cartNo);
            int result = dbc.Comm.ExecuteNonQuery();

            return result;
        }

        public int updateStamp(int count)
        {
            String updateQuery = "UPDATE stamp SET count = count + :updateCount WHERE member_no = :memberNo";

            dbc.Comm.CommandText = updateQuery;
            dbc.Comm.Parameters.Clear();
            dbc.Comm.Parameters.Add("updateCount", count);
            dbc.Comm.Parameters.Add("memberNo", dbc.MemberNo);
            int result = dbc.Comm.ExecuteNonQuery();

            return result;
        }

        public int insertStampDetail(int orderNo, int count, char is_used)
        {
            String insertQuery = "INSERT INTO stamp_detail (member_no, order_no, is_used, count) VALUES (:memberNo, :orderNo, :isUsed, :count)";

            dbc.Comm.CommandText = insertQuery;
            dbc.Comm.Parameters.Clear();
            dbc.Comm.Parameters.Add("memberNo", dbc.MemberNo);
            dbc.Comm.Parameters.Add("orderNo", orderNo);
            dbc.Comm.Parameters.Add("isUsed", is_used);
            dbc.Comm.Parameters.Add("count", count);

            int result = dbc.Comm.ExecuteNonQuery();

            return result;
        }

        public void searchStamp(int memberNo)
        {
            String selectQuery = "SELECT count FROM stamp WHERE member_no = :memberNo";

            dbc.Comm.CommandText = selectQuery;
            dbc.Comm.Parameters.Clear();
            dbc.Comm.Parameters.Add("memberNo", memberNo);
            dbc.Dr = dbc.Comm.ExecuteReader();

            if(dbc.Dr.Read())
            {
                ownedStampCount = (int)dbc.Dr.GetDecimal(0);
            }
        }

        private void Form5_Load(object sender, EventArgs e)
        {
            searchCartDetail();
            searchStamp(dbc.MemberNo); // 사용 가능한 스탬프 개수 조회
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                totalPrice += Convert.ToInt32(row.Cells[4].Value);
            }

            ownedStampLabel.Text = ownedStampCount.ToString() + " 개 보유중";
            totalPriceTxt.Text = totalPrice.ToString();
            orderPriceTxt.Text = totalPrice.ToString();


        }

        private void stampCountTxt_TextChanged(object sender, EventArgs e)
        {
            if (stampCountTxt.Text != "")
            {
                stampUseCount = Convert.ToInt32(stampCountTxt.Text);
                if(stampUseCount > ownedStampCount)
                {
                    stampUseCount = ownedStampCount;
                    stampCountTxt.Text = stampUseCount.ToString();
                }
                orderPrice = totalPrice - (150 * stampUseCount);
                orderPriceTxt.Text = orderPrice.ToString();
            } else
            {
                orderPriceTxt.Text = totalPrice.ToString();
                stampUseCount = 0;
            }
        }

        private void stampCountTxt_KeyPress(object sender, KeyPressEventArgs e)
        {
            // 숫자와 백스페이스만 허용
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true; // 입력을 무시
            }
        }

        private void cancelBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void orderBtn_Click(object sender, EventArgs e)
        {
            int buyItemCount = 0; // 구매한 상품 총 개수
            int updateStampCount = 0; // 반영할 스탬프 개수

            int orderNo = insertOrders();
            if (orderNo > 0)
            {
                updateCart(); // 구매완료시 해당카트 구매 처리
                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    buyItemCount += Convert.ToInt32(row.Cells[3].Value); // 구매 상품 개수 누적
                }
                if (stampUseCount > 0)
                { // 사용 스탬프 개수가 0보다 클때
                    insertStampDetail(orderNo, stampUseCount, 'Y'); // 스탬프 내역에 반영
                }
                insertStampDetail(orderNo, buyItemCount, 'N');

                updateStampCount = buyItemCount - stampUseCount;
                updateStamp(updateStampCount); // 스탬프 반영

                MessageBox.Show("결제 성공!");
                this.DialogResult = DialogResult.OK;
            } else
            {
                this.DialogResult = DialogResult.Cancel;
            }
            
            this.Close();
        }
    }
}
