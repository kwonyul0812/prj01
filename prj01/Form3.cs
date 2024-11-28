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
    public partial class Form3 : Form
    {
        DBClass dbc = new DBClass();
        Form4 form4; // 상품구매
        Form6 form6; // 구매내역
        Form7 form7; // 스탬프
        
        public Form3(int memberNo)
        {
            InitializeComponent();
            dbc.MemberNo = memberNo;
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            form4 = new Form4(dbc.MemberNo);
            form4.MdiParent = this;
            form4.Show(); //Mdi폼의 자식은 Show()모달리스만 사용 가능           
        }

        private void 상품구매ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (form4 == null || form4.IsDisposed) 
            {
                form4 = new Form4(dbc.MemberNo);
                form4.MdiParent = this;
                form4.Show();
            }
        }

        private void 결제내역ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (form6 == null || form6.IsDisposed)
            {
                form6 = new Form6(dbc.MemberNo);
                form6.MdiParent = this;
                form6.Show();
            }
        }

        private void 스탬프ToolStripMenuItem_Click(object sender, EventArgs e)
        {
                form7 = new Form7(dbc.MemberNo);
                form7.ShowDialog();
        }

        private void 회원정보ToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }


    }
}
