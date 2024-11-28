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
    public partial class Form7 : Form
    {
        DBClass dbc = new DBClass();

        public Form7(int memberNo)
        {
            InitializeComponent();
            dbc.MemberNo = memberNo;
            dbc.DB_Access();
        }

        public void searchStampDetail()
        {
            String selectQuery = @"SELECT sd.stamp_detail_no, 
                                          sd.order_no, 
                                          TO_CHAR(o.order_date, 'yyyy-MM-dd'),
                                          CASE
                                              WHEN is_used = 'Y' THEN '사용'
                                              WHEN is_used = 'N' THEN '적립'
                                          END,
                                          sd.count 
                                          FROM stamp_detail sd 
                                          JOIN orders o ON sd.order_no = o.order_no
                                          WHERE member_no = :memberNo
                                          ORDER BY sd.stamp_detail_no DESC";

            dbc.Comm.CommandText = selectQuery;
            dbc.Comm.Parameters.Add("memberNo", dbc.MemberNo);
            dbc.Dr = dbc.Comm.ExecuteReader();

            while(dbc.Dr.Read())
            {
                ListViewItem item = new ListViewItem(dbc.Dr[0].ToString());
                item.SubItems.Add(dbc.Dr[1].ToString());
                item.SubItems.Add(dbc.Dr[2].ToString());
                item.SubItems.Add(dbc.Dr[3].ToString());
                item.SubItems.Add(dbc.Dr[4].ToString());
                listView1.Items.Add(item);
            }
        }

        public void searchStamp()
        {
            String selectQuery = @"SELECT m.name, s.count
                                    FROM member m 
                                    JOIN stamp s ON m.member_no = s.member_no
                                    WHERE m.member_no = :memberNo";
            
            dbc.Comm.CommandText = selectQuery;
            dbc.Dr = dbc.Comm.ExecuteReader();

            if(dbc.Dr.Read())
            {
                String name = dbc.Dr[0].ToString();
                String count = dbc.Dr[1].ToString();

                label1.Text = name + "님은 현재";
                label2.Text = count + "개 보유중 입니다.";
            }

        }




        private void Form7_Load(object sender, EventArgs e)
        {
            searchStampDetail();
            searchStamp();
        }


    }
}
