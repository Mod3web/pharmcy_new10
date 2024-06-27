using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Manag_ph.Supplier.Report_Supp
{
    class Report_sup
    {

        void Fill_EMP()
        {
            var vr = Application.OpenForms["Main"] as Main;
            DataTable dt = new DataTable();

            dt.Columns.Add("num_EMP");
            dt.Columns.Add("name_EMP");
            dt.Rows.Add("0", "الكل");
            DataRow[] dt_EMp = DB_Add_delete_update_.Database.ds.Tables["TB_Employees"].Select("use_program =" + true);
            for (int i = 0; i < dt_EMp.Count(); i++)
            {
                dt.Rows.Add(dt_EMp[i][0], dt_EMp[i][1]);
            }
            vr.com_empel_Rep_sup.DataSource = dt;
            vr.com_empel_Rep_sup.DisplayMember = "name_EMP";
            vr.com_empel_Rep_sup.ValueMember = "num_EMP";

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
            dt.Rows.Add(4, "فاتورة مشتريات");
            dt.Rows.Add(5, " مرتجع فاتورة مشتريات");
            dt.Rows.Add(6, "اظافة الى حساب");
            dt.Rows.Add(7, "الخصم من حساب");

            vr.com_Report_sup.DataSource = dt;
            vr.com_Report_sup.DisplayMember = "name_pross";
            vr.com_Report_sup.ValueMember = "num_pross";
        }

        public void show_Data()
        {
            Fill_EMP();
            Fill_Reasp();
        }

        public void get_Data_Supp()
        {

            var vr = Application.OpenForms["Main"] as Main;

            if (vr.txt_Report_id_sup.Text.Trim() != string.Empty)
            {
                DataRow[] dr_cline_find = DB_Add_delete_update_.Database.ds.Tables["Supplier"].Select("num_supp =" + vr.txt_Report_id_sup.Text.Trim());
                if (dr_cline_find.Count() != 0)
                {
                    if (Convert.ToBoolean(dr_cline_find[0][4]) != true)// لو كان  الموظف موقف
                    {
                        vr.txt_Report_id_sup.Clear();
                        vr.txt_Report_id_sup.Text = dr_cline_find[0][0].ToString();
                        vr.txt_Report_name_sup.Text = dr_cline_find[0][1].ToString();
                    }
                    else
                    {
                        MessageBox.Show("هذا المورد موقف");
                    }
                }
                else
                {
                    MessageBox.Show("يرجاء التأكد من رقم المورد ");
                    return;
                }
            }
        }

        public void sh()
        {
            var vr = Application.OpenForms["Main"] as Main;
            String ss = vr.com_Report_sup.SelectedValue.ToString();
            String s = vr.com_Report_sup.Text.ToString();
            String s2 = vr.com_Report_sup.Items.ToString();
          
        }
        public void serch_Rp_supper()
        {
            DataRow[] dr_Data_bond;


            string query = "";
            var vr = Application.OpenForms["Main"] as Main;
            vr.dt_grd_Rep_sup_bgv.Rows.Clear();

            query = " (date_add >= '" + vr.dat_tim_Rep_from_sup.Value + "' and date_add <= '" + vr.dat_tim_Rep_to_sup.Value + "')";

            if (Convert.ToInt32(vr.com_Report_sup.SelectedValue) != 0)
            {
                query += " and Type_process = '" + vr.com_Report_sup.Text.ToString() + "'";
            }
            if (Convert.ToInt32(vr.com_empel_Rep_sup.SelectedValue) != 0)
            {

                query += " and id_user = " + vr.com_empel_Rep_sup.SelectedValue;
            }
            if (vr.txt_Report_name_sup.Text.Trim() != string.Empty && vr.txt_Report_id_sup.Text.Trim() != string.Empty)
            {
                query += " and id_supp = " + vr.txt_Report_id_sup.Text;
            }
            else
            {
                MessageBox.Show("يرجاء التحقق من رقم المورد", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            dr_Data_bond = DB_Add_delete_update_.Database.ds.Tables["Accounts_suppliers"].Select(query);
            for (int i = 0; i < dr_Data_bond.Count(); i++)
            {
                DataRow dr_Emp = DB_Add_delete_update_.Database.ds.Tables["TB_Employees"].Rows.Find(dr_Data_bond[i][3]);
                DataRow dr_supper = DB_Add_delete_update_.Database.ds.Tables["Supplier"].Rows.Find(Convert.ToInt32(vr.txt_Report_id_sup.Text));
                vr.dt_grd_Rep_sup_bgv.Rows.Add(
                   dr_supper[1],
                   dr_Emp[1],
                   Convert.ToDateTime(dr_Data_bond[i][8]).ToString("d"),
                   dr_Data_bond[i][7],
                   dr_Data_bond[i][5],
                   dr_Data_bond[i][6],
                   dr_Data_bond[i][9]
                    );
            }

        }

        public void show_Report()
        {
            var vr = Application.OpenForms["Main"] as Main;
            DataTable dt = new classs_table.Items_Tools().Fill_DataTable_Columns("Rp_Account_supp", new string[]
               {
                       "id_sup"
                       ,"name_sup"
                       ,"name_emp"
                       ,"preview"
                       ,"date_cre_from"
                       ,"date_cre_to"
                       ,"Amount",
                       "Total"
                       });

            dt.Columns[10].DataType = typeof(byte[]);

            if (!vr.ch_bond_supper.Checked)
            {
                for (int i = 0; i < vr.dt_grd_Rep_sup_bgv.RowCount; i++)
                {
                    dt.Rows.Add
                        (
                        vr.dt_grd_Rep_sup_bgv.Rows[i].Cells[0].Value,
                        vr.dt_grd_Rep_sup_bgv.Rows[i].Cells[1].Value,
                        vr.dt_grd_Rep_sup_bgv.Rows[i].Cells[2].Value,
                        vr.dt_grd_Rep_sup_bgv.Rows[i].Cells[3].Value,
                        vr.dt_grd_Rep_sup_bgv.Rows[i].Cells[4].Value,
                        vr.dt_grd_Rep_sup_bgv.Rows[i].Cells[5].Value,
                        vr.dat_tim_Rep_from_sup.Value.ToString("d"),
                        vr.dat_tim_Rep_to_sup.Value.ToString("d"),
                        vr.dt_grd_Rep_sup_bgv.Rows[i].Cells[9].Value
                        //  MOJ.General.ConvertToLetters(Convert.ToDecimal(Convert.ToDouble(vr.dt_grd_Rep_sup_bgv.Rows[i].Cells[6].Value)), "ريال", "ريال")

                        );
                }
            }


            new classs_table.Items_Tools().show_CrystalReportView(dt, vr.CRV_bond_supper, "../../prodects/Report/CR_bond_supper.rpt");




        }
    }
}
