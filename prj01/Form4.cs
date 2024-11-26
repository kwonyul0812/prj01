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

namespace prj01
{
    public partial class Form4 : Form
    { // 상품구매
        DBClass dbc = new DBClass();
        int cartNo;

        DataTable dt1 = new DataTable(); // dataGridView1 용
        DataTable dt2 = new DataTable(); // dataGridView2 용


        public Form4(int memberNo)
        {
            InitializeComponent();
            dbc.MemberNo = memberNo;
            dbc.DB_Access();
            searchMajorCategory();
            searchItem();
            searchCart();
        }

        public class ComboBoxItem
        {
            public int Value { get; set; }
            public string Text { get; set; }

            public override string ToString()
            {
                return Text; // ComboBox에 표시되는 값
            }
        }

        public void searchMajorCategory()
        {
            String selectQuery = "SELECT * FROM major_category";
            dbc.Comm.CommandText = selectQuery;
            dbc.Dr = dbc.Comm.ExecuteReader();

            while (dbc.Dr.Read())
            {
                McComboBox.Items.Add(new ComboBoxItem
                {
                    Value = Convert.ToInt32(dbc.Dr["major_category_no"]), // ID 저장
                    Text = dbc.Dr["name"].ToString() // 이름 저장
                });
            }
        }

        public void searchSubCategory(int majorCategoryNo)
        {
            String selectQuery = "SELECT * FROM sub_category WHERE major_category_no = " + majorCategoryNo;
            dbc.Comm.CommandText = selectQuery;
            dbc.Dr = dbc.Comm.ExecuteReader();

            while (dbc.Dr.Read())
            {
                ScComboBox.Items.Add(new ComboBoxItem
                {
                    Value = Convert.ToInt32(dbc.Dr["sub_category_no"]), // ID 저장
                    Text = dbc.Dr["name"].ToString() // 이름 저장
                });
            }
        }

        public void searchItem()
        {
            String selectQuery = "SELECT i.item_no, sc.name AS sub_category_name, i.name AS item_name, i.price FROM item i JOIN sub_category sc ON i.sub_category_no = sc.sub_category_no ";

            dbc.Comm.CommandText = selectQuery;
            dbc.Dr = dbc.Comm.ExecuteReader();
            dt1.Load(dbc.Dr);

            dataGridView1.DataSource = dt1;

            dataGridView1.Columns["item_no"].HeaderText = "상품번호";
            dataGridView1.Columns["sub_category_name"].HeaderText = "소분류";
            dataGridView1.Columns["item_name"].HeaderText = "상품명";
            dataGridView1.Columns["price"].HeaderText = "가격";

        }

        public void searchItem(Object selectedItem, String searchText)
        {
            if (selectedItem is ComboBoxItem sc)
            {

                String selectQuery = "SELECT i.item_no, sc.name AS sub_category_name, i.name AS item_name, i.price FROM item i JOIN sub_category sc ON i.sub_category_no = sc.sub_category_no WHERE i.sub_category_no =" + sc.Value + "AND i.name LIKE '%" + searchText + "%'";

                dbc.Comm.CommandText = selectQuery;
                dbc.Dr = dbc.Comm.ExecuteReader();
                dt1.Clear(); // DataTable 객체 내 구조는 유지하되 데이터만 지움
                dt1.Load(dbc.Dr);

                dataGridView1.DataSource = dt1;

            }
        }


        public bool checkCategory()
        {
            if ((McComboBox.SelectedItem != null) && (ScComboBox.SelectedItem != null))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool checkItem()
        {
            if ((itemNoTxtBox.Text != "") && (scNameTxtBox.Text != "") && (itemNameTxtBox.Text != "") && (priceTxtBox.Text != "") && (countTxtBox.Text != ""))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public void createCart()
        {
            String insertQuery = "INSERT INTO cart(member_no, is_purchased) VALUES (:memberNo, 'N') RETURNING cart_no INTO :newCartNo";

            dbc.Comm.CommandText = insertQuery;
            //dbc.Comm.Parameters.Add("memberNo", dbc.MemberNo);

            OracleParameter outputCartNoParam = new OracleParameter("newCartNo", OracleDbType.Int32)
            {
                Direction = ParameterDirection.Output
            };
            dbc.Comm.Parameters.Add(outputCartNoParam);
            dbc.Comm.ExecuteNonQuery();
            cartNo = Convert.ToInt32(outputCartNoParam.Value.ToString());
        }

        public void searchCart()
        {
            try
            {
                String selectQuery = "SELECT cart_no FROM cart WHERE member_no = :memberNo AND is_purchased = 'N'";

                dbc.Comm.CommandText = selectQuery;
                dbc.Comm.Parameters.Clear();
                dbc.Comm.Parameters.Add("memberNo", dbc.MemberNo);
                dbc.Dr = dbc.Comm.ExecuteReader();

                if (dbc.Dr.Read())
                {
                    cartNo = Convert.ToInt32(dbc.Dr.GetDecimal(0));
                }
                else
                {
                    createCart();
                }

            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

        public void insertCartDetail()
        {
            try
            {
                int pricePerItem = Convert.ToInt32(priceTxtBox.Text);
                int count = Convert.ToInt32(countTxtBox.Text);
                int totalPrice = pricePerItem * count;

                String insertQuery = "INSERT INTO cart_detail (cart_no, item_no, count, total_price) VALUES (:cartNo, :itemNo, :count, :totalPrice)";


                dbc.Comm.CommandText = insertQuery;
                dbc.Comm.Parameters.Clear();
                dbc.Comm.Parameters.Add("cartNo", cartNo);
                dbc.Comm.Parameters.Add("itemNo", Convert.ToInt32(itemNoTxtBox.Text));
                dbc.Comm.Parameters.Add("count", count);
                dbc.Comm.Parameters.Add("totalPrice", totalPrice);

                int result = dbc.Comm.ExecuteNonQuery();
                if (result > 0)
                {
                    MessageBox.Show("장바구니 담기 성공!");
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }
        public void updateCartDetail()
        {
            try
            {
                int pricePerItem = Convert.ToInt32(priceTxtBox.Text);
                int count = Convert.ToInt32(countTxtBox.Text);
                int totalPrice = pricePerItem * count;

                String updateQuery = "UPDATE cart_detail SET count = :count, total_price = :totalPrice WHERE cart_no = :cartNo AND item_no = :itemNo";

                dbc.Comm.CommandText = updateQuery;
                dbc.Comm.Parameters.Clear();
                dbc.Comm.Parameters.Add("count", count);
                dbc.Comm.Parameters.Add("totalPrice", totalPrice);
                dbc.Comm.Parameters.Add("cartNo", cartNo);
                dbc.Comm.Parameters.Add("itemNo", itemNoTxtBox.Text);

                int result = dbc.Comm.ExecuteNonQuery();
                if (result > 0)
                {
                    MessageBox.Show("장바구니 수정 성공!");
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }


        }

        public void searchCartDetail()
        {
            try
            {
                String selectQuery = "SELECT i.item_no, sc.name AS sub_category_name, i.name AS item_name, cd.count, cd.total_price FROM cart_detail cd JOIN item i ON cd.item_no = i.item_no JOIN sub_category sc ON i.sub_category_no = sc.sub_category_no  WHERE cart_no = :cartNo ORDER BY i.item_no ASC";

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
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

        public bool isItemFound()
        {
            foreach (DataGridViewRow row in dataGridView2.Rows)
            {
                if (row.Cells[0].Value != null && row.Cells[0].Value.ToString() == itemNoTxtBox.Text)
                {
                    return true;
                }
            }
            return false;
        }

        public int deleteCartDetail(int itemNo)
        {
            String deleteQuery = "DELETE FROM cart_detail WHERE item_no = :itemNo AND cart_no = :cartNo";

            dbc.Comm.CommandText = deleteQuery;
            dbc.Comm.Parameters.Clear();
            dbc.Comm.Parameters.Add("itemNo", itemNo);
            dbc.Comm.Parameters.Add("cartNo", cartNo);
            int result = dbc.Comm.ExecuteNonQuery();

            return result;
        }
        public int deleteAllCD()
        {
            String deleteQuery = "DELETE FROM cart_detail WHERE cart_no = :cartNo";

            dbc.Comm.CommandText = deleteQuery;
            dbc.Comm.Parameters.Clear();
            dbc.Comm.Parameters.Add("cartNo", cartNo);
            int result = dbc.Comm.ExecuteNonQuery();
            return result;
        }


        private void Form4_Load(object sender, EventArgs e)
        {
            // 장바구니 상세 조회
            searchCartDetail();

        }

        private void McComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (McComboBox.SelectedItem is ComboBoxItem mc)
            {
                ScComboBox.Items.Clear();
                ScComboBox.Text = "";
                SearchTextBox.Text = "";
                searchSubCategory(mc.Value);
            }
        }

        private void SearchBtn_Click(object sender, EventArgs e)
        {
            if (!checkCategory())
            {
                MessageBox.Show("카테고리를 선택해주세요");
                return;
            }
            else
            {
                searchItem(ScComboBox.SelectedItem, SearchTextBox.Text);
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                // 선택된 행의 셀 값 가져오기
                String itemNo = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
                String scName = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
                String itemName = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
                String price = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();

                // 텍스트 박스에 선택한 정보 넣기
                itemNoTxtBox.Text = itemNo;
                scNameTxtBox.Text = scName;
                itemNameTxtBox.Text = itemName;
                priceTxtBox.Text = price;
                countTxtBox.Text = "";
            }
        }

        private void txtClearBtn_Click(object sender, EventArgs e)
        {
            itemNoTxtBox.Text = "";
            scNameTxtBox.Text = "";
            itemNameTxtBox.Text = "";
            priceTxtBox.Text = "";
            countTxtBox.Text = "";
        }

        private void countTxtBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            // 숫자와 백스페이스만 허용
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true; // 입력을 무시
            }
        }

        private void addCartBtn_Click(object sender, EventArgs e)
        {
            if (!checkItem())
            {
                MessageBox.Show("상품 정보를 확인해주세요");
                return;
            }
            if (!isItemFound())
            {
                insertCartDetail();
                searchCartDetail();
            }
            else
            {
                updateCartDetail();
                searchCartDetail();
            }
        }

        private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                // 선택된 행의 셀 값 가져오기
                String itemNo = dataGridView2.Rows[e.RowIndex].Cells[0].Value.ToString();
                String scName = dataGridView2.Rows[e.RowIndex].Cells[1].Value.ToString();
                String itemName = dataGridView2.Rows[e.RowIndex].Cells[2].Value.ToString();
                int count = Convert.ToInt32(dataGridView2.Rows[e.RowIndex].Cells[3].Value);
                int total_price = Convert.ToInt32(dataGridView2.Rows[e.RowIndex].Cells[4].Value);

                // 텍스트 박스에 선택한 정보 넣기
                itemNoTxtBox.Text = itemNo;
                scNameTxtBox.Text = scName;
                itemNameTxtBox.Text = itemName;
                priceTxtBox.Text = (total_price / count).ToString();
                countTxtBox.Text = count.ToString();
            }
        }

        private void deleteCDBtn_Click(object sender, EventArgs e)
        {
            if (dataGridView2.SelectedRows.Count > 0)
            {
                int count = 0;
                foreach (DataGridViewRow row in dataGridView2.SelectedRows)
                {
                    int itemNo = Convert.ToInt32(row.Cells[0].Value);
                    count += deleteCartDetail(itemNo);
                }
                if (count > 0)
                {
                    MessageBox.Show(count + "개 삭제 성공!");
                }
                searchCartDetail();
            }
            else
            {
                MessageBox.Show("행을 선택해주세요");
            }
        }

        private void clearCDBtn_Click(object sender, EventArgs e)
        {
            int result = deleteAllCD();
            if (result > 0)
            {
                MessageBox.Show("장바구니 초기화 성공!");
            }
            else
            {
                MessageBox.Show("초기화할 정보가 없습니다");
            }
            searchCartDetail();
        }

        private void buyBtn_Click(object sender, EventArgs e)
        {
            if (dataGridView2.Rows.Count > 0)
            {
                Form5 form5 = new Form5(cartNo, dbc.MemberNo); // 결제창
                DialogResult result = form5.ShowDialog();

                if (result == DialogResult.OK)
                {
                    searchCart();
                    searchCartDetail();
                }
            }
            else
            {
                MessageBox.Show("구매할 상품이 없습니다");
            }
        }
    }
}
