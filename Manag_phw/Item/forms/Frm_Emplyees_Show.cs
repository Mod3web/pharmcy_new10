using Manag_ph.Daily_accounts.Cash_exchange;
using Manag_ph.Daily_accounts.cash_Supply;
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
    public partial class Frm_Emplyees_Show : Form
    {
        public Frm_Emplyees_Show()
        {
            InitializeComponent();
        }


        private void txt_supper_serch_TextChanged(object sender, EventArgs e)
        {
            DataView dview_emp = new DataView(DB_Add_delete_update_.Database.ds.Tables["TB_Employees"]);
            string str = txt_Emplyee_serch.Text;
            dview_emp.RowFilter = "id_EMP + name_AR_EMP like '%" + str + "%'";
            dgv_Emplyee_dgv.DataSource = dview_emp;
        }

        private void load_tb_Emp()
        {

            dgv_Emplyee_dgv.DataSource = DB_Add_delete_update_.Database.ds.Tables["TB_Employees"];

            dgv_Emplyee_dgv.Columns[0].HeaderText = "رقم الموظف";
            dgv_Emplyee_dgv.Columns[1].HeaderText = "اسم الموظف";
            dgv_Emplyee_dgv.Columns[13].HeaderText = "موظف موقف";
            dgv_Emplyee_dgv.Columns[4].HeaderText = "هاتف الموظف";
            dgv_Emplyee_dgv.Columns[5].HeaderText = "هاتف ارضي الموظف";


            dgv_Emplyee_dgv.Columns[2].Visible = false;
            dgv_Emplyee_dgv.Columns[3].Visible = false;
            dgv_Emplyee_dgv.Columns[6].Visible = false;
            dgv_Emplyee_dgv.Columns[7].Visible = false;
            dgv_Emplyee_dgv.Columns[8].Visible = false;
            dgv_Emplyee_dgv.Columns[9].Visible = false;
            dgv_Emplyee_dgv.Columns[10].Visible = false;
            dgv_Emplyee_dgv.Columns[11].Visible = false;
            dgv_Emplyee_dgv.Columns[12].Visible = false;
            dgv_Emplyee_dgv.Columns[14].Visible = false;
            dgv_Emplyee_dgv.Columns[15].Visible = false;
            dgv_Emplyee_dgv.Columns[16].Visible = false;



        }


        private void Frm_Emplyees_Show_Load(object sender, EventArgs e)
        {

            load_tb_Emp();


        }
        private void show_data_info_Emp()
        {

            var vr1 = Application.OpenForms["cash_exchange"] as cash_exchange;
            var vr2 = Application.OpenForms["cash_supply"] as cash_supply;
            var vr = Application.OpenForms["Main"] as Main;



            int num_Emp = Convert.ToInt32(dgv_Emplyee_dgv.CurrentRow.Cells[0].Value);
            DataRow dt_R_Emp = DB_Add_delete_update_.Database.ds.Tables["Emplyee_account"].Rows.Find(num_Emp);

            if (dgv_Emplyee_dgv.CurrentRow.Cells != null)
            {

                if (Convert.ToInt32(dgv_Emplyee_dgv.CurrentRow.Cells[13].Value) == 0)
                {
                    //هذا الشرط خاص بشاشه الصرف النقدي

                    if (vr.show_form_doc == 1)
                    {
                        if (dt_R_Emp != null)
                        {
                            vr1.txt_num_beneficiry.Text = dgv_Emplyee_dgv.CurrentRow.Cells[0].Value.ToString();
                            vr1.txt_name_beneficiry.Text = dgv_Emplyee_dgv.CurrentRow.Cells[1].Value.ToString();
                            vr1.txt_Cur_balance.Text = Convert.ToDouble(dt_R_Emp[2]).ToString("N2");
                            vr1.txt_Cur_balance_cred.Text = Convert.ToDouble(dt_R_Emp[1]).ToString("N2");
                            Close();
                        }
                        else
                        {
                            MessageBox.Show("حساب الموظف غير مفعل !");
                            Close();
                        }

                    }
                    //هذا الشرط خاص بشاشه التوريد النقدي

                    else if (vr.show_form_doc == 2)
                    {
                        if (dt_R_Emp != null)
                        {
                            vr2.txt_num_beneficiry.Text = dgv_Emplyee_dgv.CurrentRow.Cells[0].Value.ToString();
                            vr2.txt_name_beneficiry.Text = dgv_Emplyee_dgv.CurrentRow.Cells[1].Value.ToString();
                            vr2.txt_Cur_balance_supp.Text = Convert.ToDouble(dt_R_Emp[2]).ToString("N2");
                            vr2.txt_Cur_balance_cred_supp.Text = Convert.ToDouble(dt_R_Emp[1]).ToString("N2");
                            Close();
                        }
                        else
                        {
                            MessageBox.Show("حساب الموظف غير مفعل !");
                            Close();
                        }

                    }

                }
                else
                {

                    MessageBox.Show(" الموظف موقف", "موقف", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    return;

                }


            }




        }

        private void btn_OK_Emplyee_Click(object sender, EventArgs e)
        {
            show_data_info_Emp();
        }

        private void dgv_Emplyee_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            show_data_info_Emp();
        }

        private void btn_close_Emplyee_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
