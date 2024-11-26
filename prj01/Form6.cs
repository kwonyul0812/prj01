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
    public partial class Form6 : Form
    {
        DBClass dbc = new DBClass();
        int cartNo;

        DataTable dt1 = new DataTable(); // dataGridView1 용

        public Form6(int memberNo)
        {
            InitializeComponent();
            dbc.MemberNo = memberNo;
            dbc.DB_Access();
        }

        private void Form6_Load(object sender, EventArgs e)
        {
            //selectOrders(); // 회원의 주문내역 조회
        }
    }
}
