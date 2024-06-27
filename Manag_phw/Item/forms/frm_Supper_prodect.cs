using Manag_ph.Daily_accounts.Cash_exchange;
using Manag_ph.Daily_accounts.cash_Supply;
using Manag_ph.forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Manag_ph.Item.forms
{
    public partial class frm_Supper_prodect : Form
    {
        public frm_Supper_prodect()
        {
            InitializeComponent();
        }

        void ShowData()
        {
            var vr = Application.OpenForms["Main"] as Main;
            var vr2 = Application.OpenForms["frm_pay_bill"] as frm_pay_bill;
            var vr3 = Application.OpenForms["cash_supply"] as cash_supply;
            var vr4 = Application.OpenForms["cash_exchange"] as cash_exchange;
            int num = Convert.ToInt32(dgv_supper_dgv.CurrentRow.Cells[6].Value);
            DataRow dr_clc = DB_Add_delete_update_.Database.ds.Tables["Calc_supply"].Rows.Find(num);


            if (dgv_supper_dgv.CurrentRow != null)
            {
                if (Convert.ToInt32(dgv_supper_dgv.CurrentRow.Cells[4].Value) == 0)
                {
                    if (vr.show_supper)
                    {
                        vr.txt_num_Supplier_prodect.Text = dgv_supper_dgv.CurrentRow.Cells[0].Value.ToString();
                        vr.txt_name_Supplier_prodect.Text = dgv_supper_dgv.CurrentRow.Cells[1].Value.ToString();
                        vr.txt_calc_Supplier_prodect.Text = Convert.ToDouble(dr_clc[3]).ToString("N2");
                        vr.show_supper = false;
                        Close();
                    }
                    else if (vr.show_supper_return)
                    {
                        vr.txt_num_supper_return.Text = dgv_supper_dgv.CurrentRow.Cells[0].Value.ToString();
                        vr.txt_name_supper_returns.Text = dgv_supper_dgv.CurrentRow.Cells[1].Value.ToString();
                        vr.show_supper_return = false;
                        Close();

                    }
                    else if (vr.show_form_doc == 2)
                    {

                        vr3.txt_name_beneficiry.Text = dgv_supper_dgv.CurrentRow.Cells[1].Value.ToString();
                        vr3.txt_num_beneficiry.Text = dgv_supper_dgv.CurrentRow.Cells[0].Value.ToString();
                        vr3.txt_Cur_balance_supp.Text = Convert.ToDouble(dr_clc[2]).ToString("N2");
                        vr3.txt_Cur_balance_cred_supp.Text = Convert.ToDouble(dr_clc[1]).ToString("N2");
                        // vr3.cash_supply_form = false;
                        Close();

                    }
                    else if (vr.show_form_doc == 1)
                    {
                        vr4.txt_name_beneficiry.Text = dgv_supper_dgv.CurrentRow.Cells[1].Value.ToString();
                        vr4.txt_num_beneficiry.Text = dgv_supper_dgv.CurrentRow.Cells[0].Value.ToString();
                        vr4.txt_Cur_balance.Text = Convert.ToDouble(dr_clc[2]).ToString("N2");
                        vr4.txt_Cur_balance_cred.Text = Convert.ToDouble(dr_clc[1]).ToString("N2");
                        //vr4.cash_exchange_form=false;
                        Close();
                    }

                    else if (vr2.show_frm_suppr)
                    {

                        vr2.txt_num_supper.Text = dgv_supper_dgv.CurrentRow.Cells[0].Value.ToString();
                        vr2.txt_name_supper.Text = dgv_supper_dgv.CurrentRow.Cells[1].Value.ToString();
                        vr2.txt_name_couns.Text = dgv_supper_dgv.CurrentRow.Cells[11].Value.ToString();
                        vr2.txt_Crdt_supp.Text = Convert.ToDouble(dr_clc[1]).ToString("N0");
                        vr2.txt_Dbt_supp.Text = Convert.ToDouble(dr_clc[2]).ToString("N0");

                        Close();
                    }
                }
                else
                {
                    MessageBox.Show("المورد موقف", "موقف", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    return;
                }
            }
        }

        private void Frm_Supper_prodect_Load(object sender, EventArgs e)
        {
            dgv_supper_dgv.DataSource = DB_Add_delete_update_.Database.ds.Tables["Supplier"];

            dgv_supper_dgv.Columns[0].HeaderText = "رقم المورد";
            dgv_supper_dgv.Columns[1].HeaderText = "اسم المورد";
            dgv_supper_dgv.Columns[4].HeaderText = "موقف";
            dgv_supper_dgv.Columns[7].HeaderText = "رقم الهاتف (1)";
            dgv_supper_dgv.Columns[8].HeaderText = "رقم الهاتف (2)";


            dgv_supper_dgv.Columns[2].Visible = false;
            dgv_supper_dgv.Columns[3].Visible = false;
            dgv_supper_dgv.Columns[5].Visible = false;
            dgv_supper_dgv.Columns[6].Visible = false;


            dgv_supper_dgv.Columns[9].Visible = false;
            dgv_supper_dgv.Columns[10].Visible = false;

            dgv_supper_dgv.Columns[11].Visible = false;
            dgv_supper_dgv.Columns[12].Visible = false;

        }

        private void Button1_Click(object sender, EventArgs e)
        {
            ShowData();
        }


        private void Dgv_supper_RowHeaderMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {

        }

        private void Button3_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void Txt_supper_serch_TextChanged(object sender, EventArgs e)
        {
            DataView dv = new DataView(DB_Add_delete_update_.Database.ds.Tables["Supplier"]);
            string str = txt_supper_serch.Text;
            dv.RowFilter = "num_supp + name_supp like '%" + str + "%'";
            dgv_supper_dgv.DataSource = dv;
        }

        private void Dgv_supper_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            ShowData();
        }

        private void Frm_Supper_prodect_FormClosing(object sender, FormClosingEventArgs e)
        {

        }

        private void Frm_Supper_prodect_FormClosed(object sender, FormClosedEventArgs e)
        {
            //var vr2 = Application.OpenForms["frm_pay_bill"] as frm_pay_bill;
            //if (vr2.show_frm_suppr)
            //{
            //    vr2.txt_num_supper.Text = "0";
            //    vr2.txt_name_supper.Clear();
            //    vr2.txt_name_couns.Clear();
            //    vr2.txt_num_footer.Enabled = false;
            //    vr2.show_frm_suppr = false;
            //    Close();
            //}
        }
    }
}

