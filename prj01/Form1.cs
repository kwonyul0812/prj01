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
    public partial class Form1 : Form
    { // 로그인

        DBClass dbc = new DBClass();
        bool loginCheck = false; // 로그인 상태 확인

        public Form1()
        {
            InitializeComponent();
            dbc.DB_Access(); // db 연결
        }

        private void createAccoutBtn_Click(object sender, EventArgs e) 
        { // 회원 가입 버튼 클릭
            Form2 form2 = new Form2();
            form2.ShowDialog();
        }

        private void LoginBtn_Click(object sender, EventArgs e)
        {
            String id = IdTextBox.Text;
            String password = PwTextBox.Text;

            String selectQuery = "SELECT member_no, id, password FROM member";

            dbc.Comm.CommandText = selectQuery;
            dbc.Dr = dbc.Comm.ExecuteReader();
            

            while (dbc.Dr.Read())
            {
                if(dbc.Dr.GetString(1).Equals(id) && dbc.Dr.GetString(2).Equals(password))
                {
                    dbc.MemberNo = (int)dbc.Dr.GetDecimal(0);
                    Form3 form3 = new Form3(dbc.MemberNo);
                    form3.ShowDialog();
                    loginCheck = true;
                    break;
                }
                loginCheck = false;
            }
            if (!loginCheck) // 로그인 실패시
            {
                MessageBox.Show("로그인 정보를 확인해주세요");
            }

        }
    }
}
