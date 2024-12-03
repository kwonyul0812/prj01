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

        public void login(String id, String password, int loginType)
        {
            String selectQuery = @"SELECT member_no FROM member 
                                    WHERE id = :id AND password = :password AND member_type_no = :memberTypeNo";

            dbc.Comm.CommandText = selectQuery;
            dbc.Comm.Parameters.Clear();
            dbc.Comm.Parameters.Add("id", id);
            dbc.Comm.Parameters.Add("password", password);
            dbc.Comm.Parameters.Add("memberTypeNo", loginType);
            dbc.Dr = dbc.Comm.ExecuteReader();

            if(dbc.Dr.Read())
            {
                dbc.MemberNo = (int)dbc.Dr.GetDecimal(0);
                if (loginType == 1)
                {
                    Form3 form3 = new Form3(dbc.MemberNo);
                    form3.ShowDialog();
                }
                if(loginType == 2)
                {
                    Form9 form9 = new Form9();
                    form9.ShowDialog();
                }

            } else
            {
                MessageBox.Show("로그인 정보를 확인해주세요");
            }


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

            if (radioButton1.Checked) // 관리자 로그인시
            {
                login(id, password, 2);
            }
            else if (radioButton2.Checked) // 일반회원 로그인시
            {
                login(id, password, 1);
            } else
            {
                MessageBox.Show("로그인 유형을 선택해주세요");
            }
        }
    }
}
