using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Manag_ph.Accounts.Account_Disco_add;

namespace Manag_ph.Item.forms
{
    public partial class frm_casher_And_fund : Form
    {
        public frm_casher_And_fund()
        {
            InitializeComponent();
        }

        private void Frm_casher_And_fund_Load(object sender, EventArgs e)
        {
            // اضافة بيانات الصندوق والكاشير الا الجدول معا حساباتهم    
            DataRow[] dr_fund = DB_Add_delete_update_.Database.ds.Tables["account_fund"].Select();
            DataRow[] dr_fund_sals = DB_Add_delete_update_.Database.ds.Tables["fund_sals"].Select();


            DataRow[] dr_Casher = DB_Add_delete_update_.Database.ds.Tables["casher"].Select();
            DataRow[] dr_Casher_Account = DB_Add_delete_update_.Database.ds.Tables["casher_account"].Select();

            for (int i = 0; i < dr_fund.Count(); i++)
            {
                if (Convert.ToBoolean(dr_fund[i][3]) == false)
                {
                    dataGridView1_dgv.Rows.Add(dr_fund[i][0], dr_fund[i][1], Convert.ToDouble(dr_fund_sals[i][1]).ToString("N2"),"1");
                }
            }
            for (int i = 0; i < dr_Casher.Count(); i++)
            {
                if (Convert.ToBoolean(dr_Casher[i][2]) == false)
                {
                    dataGridView1_dgv.Rows.Add(dr_Casher[i][0], dr_Casher[i][1], Convert.ToDouble(dr_Casher_Account[i][1]).ToString("N2"),"2");
                }
            }

        }


        // متغيرات من يتم التعديل عليها من الفورم التي تفتح
        public bool show_Dicount = false;
        public bool show_Add = false;


        void fill_Data_casher_or_fund()
        {
            // اضافة بيانات الكاشير او الصندوق المختار الا شاشة خصم من المئسسة
            if (dataGridView1_dgv.CurrentRow != null)
            {
                var vr = Application.OpenForms["frm_Discount_account_pharna"] as frm_Discount_account_pharna;
                var vr1 = Application.OpenForms["frm_Add_account_pharna"] as frm_Add_account_pharna;
                if (show_Dicount == true)
                {

                    vr.txt_num_supper_discou_acco_add.Text = dataGridView1_dgv.CurrentRow.Cells[0].Value.ToString();
                    vr.txt_name_supper_discou_acco_add.Text = dataGridView1_dgv.CurrentRow.Cells[1].Value.ToString();
                    vr.txt_Deitor_supper_discou_acco_add.Text = dataGridView1_dgv.CurrentRow.Cells[2].Value.ToString();
                    vr.type.Text = dataGridView1_dgv.CurrentRow.Cells[3].Value.ToString();
                    Close();
                    show_Dicount = false;
                }
                else if (show_Add)
                {
                    vr1.txt_num_supper_discou_acco_add.Text = dataGridView1_dgv.CurrentRow.Cells[0].Value.ToString();
                    vr1.txt_name_supper_discou_acco_add.Text = dataGridView1_dgv.CurrentRow.Cells[1].Value.ToString();
                    vr1.txt_Deitor_supper_discou_acco_add.Text = dataGridView1_dgv.CurrentRow.Cells[2].Value.ToString();
                    vr1.type.Text = dataGridView1_dgv.CurrentRow.Cells[3].Value.ToString();
                    show_Add = false;
                    Close();
                }
            }
        }

        private void DataGridView1_SelectionChanged(object sender, EventArgs e)
        {
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            fill_Data_casher_or_fund();

        }

        private void Button2_Click(object sender, EventArgs e)
        {

        }

        private void DataGridView1_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            fill_Data_casher_or_fund();
        }
    }
}
