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
        DBClass dbc= new DBClass();
        Form9 form9;

        public Form10(Form9 form9)
        {
            InitializeComponent();
            dbc.DB_Open();
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
            dbc.Da.SelectCommand = dbc.Comm;
            dbc.Ds.Clear();
            dbc.Da.Fill(dbc.Ds);

            DataTable dt = dbc.Ds.Tables[0];

            // ComboBox에 값 추가
            foreach (DataRow row in dt.Rows)
            {
                McComboBox.Items.Add(new ComboBoxItem
                {
                    Value = Convert.ToInt32(row["major_category_no"]), // ID 저장
                    Text = row["name"].ToString() // 이름 저장
                });
            }
        }

        public void searchSubCategory(int majorCategoryNo)
        {
            String selectQuery = "SELECT * FROM sub_category WHERE major_category_no = " + majorCategoryNo;

            dbc.Comm.CommandText = selectQuery;
            dbc.Da.SelectCommand = dbc.Comm;
            dbc.Ds.Clear();
            dbc.Da.Fill(dbc.Ds);

            DataTable dt = dbc.Ds.Tables[0];

            // ComboBox에 값 추가
            foreach (DataRow row in dt.Rows)
            {
                McComboBox.Items.Add(new ComboBoxItem
                {
                    Value = Convert.ToInt32(row["sub_category_no"]), // ID 저장
                    Text = row["name"].ToString() // 이름 저장
                });
            }
        }


        private void Form10_Load(object sender, EventArgs e)
        {
            if (form9.getstrCommand == "상품추가")
            {
                label1.Text = "상품추가";
            }
        }
    }
}
