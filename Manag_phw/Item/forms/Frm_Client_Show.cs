
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Manag_ph.Daily_accounts.Cash_exchange;
using Manag_ph.Daily_accounts.cash_Supply;
using Manag_ph.Item.forms;

namespace Manag_ph.Item.forms
{
    public partial class Frm_Client_Show : Form
    {
        public Frm_Client_Show()
        {
            InitializeComponent();
        }


        void ShowData()
        {



            var vr1 = Application.OpenForms["Main"] as Main;
            var vr2 = Application.OpenForms["cash_exchange"] as cash_exchange;
            var vr3 = Application.OpenForms["cash_supply"] as cash_supply;


            int num = Convert.ToInt32(dgv_Customer_dgv.CurrentRow.Cells[0].Value);
            DataRow dr_clc = DB_Add_delete_update_.Database.ds.Tables["Stock_client"].Rows.Find(num);


            if (dgv_Customer_dgv.CurrentRow != null)
            {
                if (Convert.ToBoolean(dgv_Customer_dgv.CurrentRow.Cells[3].Value) == false)
                {
                    //هذا الشرط خاص بشاشه الصرف النقدي
                    if (vr1.show_form_doc == 1)
                    {
                        vr2.txt_num_beneficiry.Text = dgv_Customer_dgv.CurrentRow.Cells[0].Value.ToString();
                        vr2.txt_name_beneficiry.Text = dgv_Customer_dgv.CurrentRow.Cells[1].Value.ToString();
                        vr2.txt_Cur_balance.Text = Convert.ToDouble(dr_clc[2]).ToString("N2");
                        vr2.txt_Cur_balance_cred.Text = Convert.ToDouble(dr_clc[1]).ToString("N2");
                        vr2.cash1 = 0;
                        Close();

                        //هذا الشرط خاص بشاشه التوريد النقدي
                    }
                    else if (vr1.show_form_doc == 2)
                    {

                        vr3.txt_num_beneficiry.Text = dgv_Customer_dgv.CurrentRow.Cells[0].Value.ToString();
                        vr3.txt_name_beneficiry.Text = dgv_Customer_dgv.CurrentRow.Cells[1].Value.ToString();
                        vr3.txt_Cur_balance_supp.Text = Convert.ToDouble(dr_clc[2]).ToString("N2");
                        vr3.txt_Cur_balance_cred_supp.Text = Convert.ToDouble(dr_clc[1]).ToString("N2");
                        vr3.cash1 = 0;
                        Close();


                    }


                }
                else
                {
                    MessageBox.Show("العميل موقف", "موقف", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    return;
                }
            }

            ////////////////////////////////////////////////


        }
        private void Frm_Customer_Show_Load(object sender, EventArgs e)
        {

            dgv_Customer_dgv.DataSource = DB_Add_delete_update_.Database.ds.Tables["Clien"];

            dgv_Customer_dgv.Columns[0].HeaderText = "رقم العميل";
            dgv_Customer_dgv.Columns[1].HeaderText = "اسم العميل";
            dgv_Customer_dgv.Columns[3].HeaderText = "موقف";
            dgv_Customer_dgv.Columns[5].HeaderText = "رقم الهاتف (1)";
            dgv_Customer_dgv.Columns[6].HeaderText = "رقم الهاتف (2)";


            dgv_Customer_dgv.Columns[2].Visible = false;
            dgv_Customer_dgv.Columns[4].Visible = false;

            dgv_Customer_dgv.Columns[7].Visible = false;
            dgv_Customer_dgv.Columns[8].Visible = false;
            dgv_Customer_dgv.Columns[9].Visible = false;
            dgv_Customer_dgv.Columns[10].Visible = false;

        }

        private void btn_OK_customer_Click(object sender, EventArgs e)
        {
            ShowData();
        }

        private void dgv_Customer_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            ShowData();
        }

        private void btn_close_customer_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void txt_customer_serch_TextChanged(object sender, EventArgs e)
        {
            DataView dv_clien = new DataView(DB_Add_delete_update_.Database.ds.Tables["Clien"]);
            string str_cli = txt_customer_serch.Text;
            dv_clien.RowFilter = "num_clin + name_clin like '%" + str_cli + "%'";
            dgv_Customer_dgv.DataSource = dv_clien;

        }
    }
}
