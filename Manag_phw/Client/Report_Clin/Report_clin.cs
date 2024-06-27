using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Manag_ph.Client.Report_Clin
{
    class Report_clin
    {
        void Fill_EMP()
        {
            var vr = Application.OpenForms["Main"] as Main;
            DataTable dt = new DataTable();

            dt.Columns.Add("num_EMP");
            dt.Columns.Add("name_EMP");
            dt.Rows.Add(0, "الكل");

            DataRow[] dt_EMp = DB_Add_delete_update_.Database.ds.Tables["TB_Employees"].Select("use_program =" + true);
            for (int i = 0; i < dt_EMp.Count(); i++)
            {
                dt.Rows.Add(dt_EMp[i][0], dt_EMp[i][1]);
            }
            vr.com_emp_Rp_clin.DataSource = dt;
            vr.com_emp_Rp_clin.DisplayMember = "name_EMP";
            vr.com_emp_Rp_clin.ValueMember = "num_EMP";

        }


        void Fill_Reasp()
        {
            var vr = Application.OpenForms["Main"] as Main;
            DataTable dt = new DataTable();

            dt.Columns.Add("num_pross", typeof(int));
            dt.Columns.Add("name_pross");
            dt.Rows.Add(0, "الكل");
            dt.Rows.Add(1, "صرف نقدي");
            dt.Rows.Add(2, "توريد نقدي");
            dt.Rows.Add(3, "رصيد افتتاحي");
            dt.Rows.Add(4, " فاتورة مبيعات");
            dt.Rows.Add(5, "مرتجع فاتورة مبيعات");
            dt.Rows.Add(6, "اظافة الى حساب");
            dt.Rows.Add(7, "الخصم من حساب");
           
            vr.com_prev_Rp_clin.DataSource = dt;
            vr.com_prev_Rp_clin.DisplayMember = "name_pross";
            vr.com_prev_Rp_clin.ValueMember = "num_pross";
        }

        public void show_Data()
        {
            Fill_EMP();
            Fill_Reasp();
        }

        public void get_Data_Clin()
        {

            var vr = Application.OpenForms["Main"] as Main;

            if (vr.txt_id_Rp_clin.Text.Trim() != string.Empty)
            {
                DataRow[] dr_cline_find = DB_Add_delete_update_.Database.ds.Tables["Clien"].Select("num_clin =" + vr.txt_id_Rp_clin.Text.Trim());    //.Rows.Find(num);
                if (dr_cline_find.Count() != 0)
                {
                    if (Convert.ToBoolean(dr_cline_find[0][3]) != true)// لو كان موقف
                    {
                        vr.txt_id_Rp_clin.Clear();
                        vr.txt_id_Rp_clin.Text = dr_cline_find[0][0].ToString();
                        vr.txt_name_Rp_clin.Text = dr_cline_find[0][1].ToString();
                    }
                    else
                    {
                        MessageBox.Show("هذا العمبل موقف");
                    }
                }
                else
                {
                    MessageBox.Show("يرجاء التأكد من رقم العميل");
                    return;
                }
            }
        }
        public void sh()
        {
            var vr = Application.OpenForms["Main"] as Main;
            String ss = vr.com_prev_Rp_clin.SelectedValue.ToString();
            String s = vr.com_prev_Rp_clin.Text.ToString();
            String s2 = vr.com_prev_Rp_clin.Items.ToString();
            MessageBox.Show(ss + "\n" + s + "\n" + s2);
        }
        public void serch_Rp_clin()
        {
            DataRow[] dr_Data_clin;


            string query = "";
            var vr = Application.OpenForms["Main"] as Main;
            vr.dgv_Rp_Data_Clin_dgv.Rows.Clear();

            query = " (date_Accont_clin >= '" + vr.dt_ti_from_Rp_cli.Value + "' and date_Accont_clin <= '" + vr.dt_ti_to_Rp_cli.Value + "')";

            if (Convert.ToInt32(vr.com_prev_Rp_clin.SelectedValue) != 0)
            {
                query += " and Typ_pross = '" + vr.com_prev_Rp_clin.Text.ToString() + "'";
            }
            if (Convert.ToInt32(vr.com_emp_Rp_clin.SelectedValue) != 0)
            {

                query += " and id_user = " + vr.com_emp_Rp_clin.SelectedValue;
            }
            if (vr.txt_name_Rp_clin.Text.Trim() != string.Empty && vr.txt_id_Rp_clin.Text.Trim() != string.Empty)
            {
                query += " and id_clin = " + vr.txt_id_Rp_clin.Text;
            }
            else
            {
                MessageBox.Show("يرجاء التحقق من رقم المورد", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }


            dr_Data_clin = DB_Add_delete_update_.Database.ds.Tables["Accounts_Clin"].Select(query);
            for (int i = 0; i < dr_Data_clin.Count(); i++)
            {
                DataRow dr_Emp = DB_Add_delete_update_.Database.ds.Tables["TB_Employees"].Rows.Find(dr_Data_clin[i][3]);
                DataRow dr_clin = DB_Add_delete_update_.Database.ds.Tables["Clien"].Rows.Find(Convert.ToInt32(vr.txt_id_Rp_clin.Text));
                vr.dgv_Rp_Data_Clin_dgv.Rows.Add(
                   dr_clin[1],
                   dr_Emp[1],
                   Convert.ToDateTime(dr_Data_clin[i][8]).ToString("d"),
                   dr_Data_clin[i][7],
                   dr_Data_clin[i][5],
                    dr_Data_clin[i][6],
                   dr_Data_clin[i][9]
                    );
            }

        }
    }
}
