using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace prj01
{
    public partial class Form8 : Form
    {
        DBClass dbc = new DBClass();
        public Form8(int memberNo)
        {
            InitializeComponent();
            dbc.MemberNo = memberNo;
            dbc.DB_Access();
        }

        public void searchMember()
        {
            String selectQuery = "SELECT id, name, phone FROM member WHERE member_no = :memberNo";

            dbc.Comm.CommandText = selectQuery;
            dbc.Comm.Parameters.Clear();
            dbc.Comm.Parameters.Add("memberNo", dbc.MemberNo);
            dbc.Dr = dbc.Comm.ExecuteReader();

            if (dbc.Dr.Read())
            {
                idTextBox.Text = dbc.Dr.GetString(0);
                nameTextBox.Text = dbc.Dr.GetString(1);
                phoneTextBox.Text = dbc.Dr.GetString(2);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string password = pwTextBox.Text;
            string name = nameTextBox.Text;
            string phone = phoneTextBox.Text;


            string updateQuery = "UPDATE member SET password = :password, name = :name, phone = :phone WHERE member_no = :memberNo";

            dbc.Comm.CommandText = updateQuery;
            dbc.Comm.Parameters.Clear();
            dbc.Comm.Parameters.Add("password", password);
            dbc.Comm.Parameters.Add("name", name);
            dbc.Comm.Parameters.Add("phone", phone);
            dbc.Comm.Parameters.Add("memberNo", dbc.MemberNo);


            int result = dbc.Comm.ExecuteNonQuery();

            if (result > 0)
            {
                MessageBox.Show("수정 성공!");
            }

            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Form8_Load(object sender, EventArgs e)
        {
            searchMember();
        }
    }
}
