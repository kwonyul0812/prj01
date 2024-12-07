
using Oracle.DataAccess.Client;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
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
        OracleDataAdapter da;
        DataSet ds;
        OracleCommandBuilder myCommandBuilder;



        public int MemberNo { get { return memberNo; } set { memberNo = value; } }
        public OracleConnection Conn { get { return conn; } set { conn = value; } }
        public OracleCommand Comm { get { return comm; } set { comm = value; } }
        public OracleDataReader Dr { get { return dr; } set { dr = value; } }
        //public DataTable Dt { get { return dt; } set { dt = value; } }

        public OracleDataAdapter Da { get { return da; } set { da = value; } }
        public DataSet Ds { get { return ds; } set { ds = value; } }
        public OracleCommandBuilder MyCommandBuilder { get { return myCommandBuilder; } set { myCommandBuilder = value; } }


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

        public void DB_Open()
        {
            try
            {
                string conStr = "User Id = kwon; Password = 1234; Data Source = (DESCRIPTION =(ADDRESS = (PROTOCOL = TCP)(HOST = localhost)(PORT = 1521))(CONNECT_DATA = (SERVER = DEDICATED)(SERVICE_NAME = xe))); ";

                conn = new OracleConnection(conStr);
                da = new OracleDataAdapter();
                comm = new OracleCommand();
                comm.Connection = conn;
                conn.Open();

                ds = new DataSet();
                
            }
            catch (DataException DE)
            {
                MessageBox.Show(DE.Message);
            }
        }
    }
}
