﻿using Oracle.DataAccess.Client;
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
        int totalPrice = 0;
        int stampUseCount;
        int orderPrice = 0;
        int itemCount = 0;

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
            String updateQuery = "UPDATE stamp SET count = count + :count WHERE member_no = :memberNo";

            dbc.Comm.CommandText = updateQuery;
            dbc.Comm.Parameters.Clear();
            dbc.Comm.Parameters.Add("count", count);
            dbc.Comm.Parameters.Add("memberNo", dbc.MemberNo);
            int result = dbc.Comm.ExecuteNonQuery();

            return result;
        }

        private void Form5_Load(object sender, EventArgs e)
        {
            searchCartDetail();
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                //itemCount += Convert.ToInt32(row.Cells[3].Value); // 구매 상품 개수 (스탬프 적립시 사용)
                totalPrice += Convert.ToInt32(row.Cells[4].Value);
            }

            totalPriceTxt.Text = totalPrice.ToString();
            orderPriceTxt.Text = totalPrice.ToString();


        }

        private void stampCountTxt_TextChanged(object sender, EventArgs e)
        {
            if (stampCountTxt.Text != "")
            {
                stampUseCount = Convert.ToInt32(stampCountTxt.Text);
                orderPrice = totalPrice - (150 * stampUseCount);
                orderPriceTxt.Text = orderPrice.ToString();
            } else
            {
                orderPriceTxt.Text = totalPrice.ToString();
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
            int itemCount = 0; // 구매한 상품 총 개수
            int useStampCount; // 사용할 스탬프 개수
            bool useStamp = false;

            int orderNo = insertOrders();
            if (orderNo > 0)
            {
                updateCart(); // 구매완료시 해당카트 구매 처리
                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    itemCount += Convert.ToInt32(row.Cells[3].Value); // 구매 상품 개수 누적
                }
                updateStamp(itemCount); // 구매 개수 만큼 스탬프 적립

                // ******* 적립 소모 여부에 따라 스탬프 적립/소모 내역 반영
                //insertStampDetail(orderNo, itemCount, useStamp); 

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
