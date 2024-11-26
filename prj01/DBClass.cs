
using Oracle.DataAccess.Client;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace prj01
{
    internal class DBClass
    {
        int memberNo; // 로그인한 회원번호

        OracleConnection conn;  // OracleConnection 객체
        OracleCommand comm;     // OracleCommand 객체
        OracleDataReader dr;    // OracleDataReader 객체
        //DataTable dt;           // DataTable 객체



        public int MemberNo { get { return memberNo; } set { memberNo = value; } }
        public OracleConnection Conn { get { return conn; } set { conn = value; } }
        public OracleCommand Comm { get { return comm; } set { comm = value; } }
        public OracleDataReader Dr { get { return dr; } set { dr = value; } }
        //public DataTable Dt { get { return dt; } set { dt = value; } }

        public void DB_Access()
        {
            try
            {
                string conStr = "User Id = kwon; Password = 1234; Data Source = (DESCRIPTION =(ADDRESS = (PROTOCOL = TCP)(HOST = localhost)(PORT = 1521))(CONNECT_DATA = (SERVER = DEDICATED)(SERVICE_NAME = xe))); ";

                conn = new OracleConnection(conStr);
                comm = new OracleCommand();
                comm.Connection = conn;
                conn.Open();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        //public void DB_ObjCreate()
        //{
        //    dt = new DataTable();
        //}
    }
}
