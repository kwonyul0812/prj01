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
    public partial class Form10 : Form
    {
        DBClass dbc = new DBClass();
        Form9 form9;

        int itemMajorCategory; // 수정할 아이템의 대분류
        int itemSubCategory; // 수정할 아이템의 소분류

        public Form10(Form9 form9)
        {
            InitializeComponent();
            dbc.DB_Access();
            this.form9 = form9;
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
                var item = new ComboBoxItem
                {
                    Value = Convert.ToInt32(dbc.Dr["major_category_no"]), // ID 저장
                    Text = dbc.Dr["name"].ToString() // 이름 저장
                };
                McComboBox.Items.Add(item);
            }

            foreach (ComboBoxItem item in McComboBox.Items)
            {
                if (itemMajorCategory != 0 && item.Value == itemMajorCategory)
                {
                    McComboBox.SelectedItem = item;
                }
            }
        }

        public void searchSubCategory(int majorCategoryNo)
        {
            String selectQuery = "SELECT * FROM sub_category WHERE major_category_no = " + majorCategoryNo;
            dbc.Comm.CommandText = selectQuery;
            dbc.Dr = dbc.Comm.ExecuteReader();

            while (dbc.Dr.Read())
            {
                var item = new ComboBoxItem
                {
                    Value = Convert.ToInt32(dbc.Dr["sub_category_no"]), // ID 저장
                    Text = dbc.Dr["name"].ToString() // 이름 저장
                };
                ScComboBox.Items.Add(item);
            }


        }

        public bool checkTxtBox()
        {
            if (ScComboBox.SelectedItem == null || itemNameTxtBox.Text.Trim() == "" || priceTxtBox.Text.Trim() == "" || stockTxtBox.Text.Trim() == "")
            {
                return false;
            }
            else return true;

        }

        public int addItem()
        {
            String insertQuery = "INSERT INTO item(sub_category_no, name, price, stock) VALUES (:subCategoryNo, :itemName, :itemPrice, :itemStock)";

            ComboBoxItem selectedItem = (ComboBoxItem)ScComboBox.SelectedItem;

            dbc.Comm.CommandText = insertQuery;
            dbc.Comm.Parameters.Clear();
            dbc.Comm.Parameters.Add("subCategoryNo", Convert.ToInt32(selectedItem.Value));
            dbc.Comm.Parameters.Add("itemName", itemNameTxtBox.Text);
            dbc.Comm.Parameters.Add("itemPrice", Convert.ToInt32(priceTxtBox.Text));
            dbc.Comm.Parameters.Add("itemStock", Convert.ToInt32(stockTxtBox.Text));

            int result = dbc.Comm.ExecuteNonQuery();

            return result;
        }

        public int updateItem()
        {
            String updateQuery = @"UPDATE item
                                    SET sub_category_no = :subCategoryNo,
                                        name = :itemName,
                                        price = :itemPrice,
                                        stock = :itemStock
                                    WHERE item_no = :itemNo";

            ComboBoxItem selectedItem = (ComboBoxItem)ScComboBox.SelectedItem;

            dbc.Comm.CommandText = updateQuery;
            dbc.Comm.Parameters.Clear();
            dbc.Comm.Parameters.Add("subCategoryNo", selectedItem.Value);
            dbc.Comm.Parameters.Add("itemName", itemNameTxtBox.Text);
            dbc.Comm.Parameters.Add("itemPrice", Convert.ToInt32(priceTxtBox.Text));
            dbc.Comm.Parameters.Add("itemStock", Convert.ToInt32(stockTxtBox.Text));
            dbc.Comm.Parameters.Add("itemNo", form9.getItemId);

            int result = dbc.Comm.ExecuteNonQuery();
            return result;
        }

        public void searchItem()
        {
            int itemId = form9.getItemId;

            String selectQuery = @"SELECT i.name AS item_name, i.price, i.stock, mc.major_category_no, sc.sub_category_no  
                                    FROM item i
                                    JOIN sub_category sc ON i.sub_category_no = sc.sub_category_no
                                    JOIN major_category mc ON sc.major_category_no = mc.major_category_no
                                    WHERE i.item_no = :itemNo";

            dbc.Comm.CommandText = selectQuery;
            dbc.Comm.Parameters.Clear();
            dbc.Comm.Parameters.Add("itemNo", itemId);
            dbc.Dr = dbc.Comm.ExecuteReader();

            if (dbc.Dr.Read())
            {
                itemNameTxtBox.Text = dbc.Dr.GetString(0);
                priceTxtBox.Text = dbc.Dr.GetDecimal(1).ToString();
                stockTxtBox.Text = dbc.Dr.GetDecimal(2).ToString();
                itemMajorCategory = (int)dbc.Dr.GetDecimal(3);
                itemSubCategory = (int)dbc.Dr.GetDecimal(4);
            }

        }



        private void Form10_Load(object sender, EventArgs e)
        {
            if (form9.getstrCommand == "상품추가")
            {
                label1.Text = "상품추가";
                searchMajorCategory();
                OkBtn.Text = "추가";
            }
            else if (form9.getstrCommand == "상품수정")
            {
                label1.Text = "상품수정";
                searchItem();
                searchMajorCategory();
                foreach (ComboBoxItem item in ScComboBox.Items)
                {
                    if (itemSubCategory != 0 && item.Value == itemSubCategory)
                    {
                        ScComboBox.SelectedItem = item;
                    }
                }
                OkBtn.Text = "수정";
            }

        }

        private void McComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (McComboBox.SelectedItem is ComboBoxItem mc)
            {
                ScComboBox.Items.Clear();
                ScComboBox.Text = "";
                searchSubCategory(mc.Value);
            }
        }

        private void priceTxtBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            // 숫자와 백스페이스만 허용
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true; // 입력을 무시
            }
        }


        private void stockTxtBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            // 숫자와 백스페이스만 허용
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true; // 입력을 무시
            }
        }


        private void OkBtn_Click(object sender, EventArgs e)
        {
            if (!checkTxtBox())
            {
                MessageBox.Show("상품정보를 확인해주세요");
                return;
            }

            if (form9.getstrCommand == "상품추가")
            {
                int result = addItem();
                if (result > 0)
                {
                    this.DialogResult = DialogResult.OK;
                }
                else
                {
                    this.DialogResult = DialogResult.Cancel;
                }
            }
            else if (form9.getstrCommand == "상품수정")
            {
                int result = updateItem();
                if (result > 0)
                {
                    this.DialogResult = DialogResult.OK;
                }
                else
                {
                    this.DialogResult = DialogResult.Cancel;
                }
            }
            this.Close();
        }

        private void CancelBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}
