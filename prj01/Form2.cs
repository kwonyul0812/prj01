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
using System.Xml.Linq;

namespace prj01
{
    public partial class Form2 : Form
    { // 회원가입

        DBClass dbc = new DBClass();

        public Form2()
        {
            InitializeComponent();
            dbc.DB_Access();
        }


        private void createBtn_Click(object sender, EventArgs e)
        {
            try
            {
                string id = IdTextBox.Text;
                string password = PwTextBox.Text;
                string name = NameTextBox.Text;
                string phone = PhoneTextBox.Text;


                string insertQuery = "INSERT INTO member (id, password, name, phone, member_type_no) VALUES (:id, :password, :name, :phone, 1) RETURNING member_no INTO :newMemberNo";

                dbc.Comm.CommandText = insertQuery;
                dbc.Comm.Parameters.Add("id", id);
                dbc.Comm.Parameters.Add("password", password);
                dbc.Comm.Parameters.Add("name", name);
                dbc.Comm.Parameters.Add("phone", phone);

                OracleParameter outputMemberNoParam = new OracleParameter("newMemberNo", OracleDbType.Int32)
                { // 생성된 member_no 값을 리턴받기 위한 객체
                    Direction = ParameterDirection.Output
                };
                dbc.Comm.Parameters.Add(outputMemberNoParam); // 출력값을 저장하기위한 파라미터 추가
                dbc.Comm.ExecuteNonQuery();

                int memberNo = Convert.ToInt32(outputMemberNoParam.Value.ToString());

                // 생성된 memberNo를 이용하여 stamp 테이블의 데이터 추가
                insertQuery = "INSERT INTO stamp (member_no) VALUES (" + memberNo + ")";
                dbc.Comm.CommandText = insertQuery;
                dbc.Comm.ExecuteNonQuery();

                MessageBox.Show("회원가입 성공!");

                this.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void cancelBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
