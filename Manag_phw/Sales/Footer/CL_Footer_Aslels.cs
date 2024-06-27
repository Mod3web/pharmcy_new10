using Manag_ph.Sales.Footer_sals;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Manag_ph.Sales.Footer
{
    class CL_Footer_Aslels
    {
        public void View_Footer(int num_Footer)
        {
            var vr = Application.OpenForms["Main"] as Main;
            var vr2 = Application.OpenForms["frm_Save_footer_sals"] as frm_Save_footer_sals;
            Sales.Footer.XtraReport1 RP = new Sales.Footer.XtraReport1();
            DataTable dt = new classs_table.Items_Tools().Fill_DataTable_Columns("Footer_Sales", new string[] {
                "count",
                "name",
                "unit",
                "qty",
                "price"
            });

            for (int i = 0; i < vr.dgv_sals_dgv.RowCount; i++)
            {
                object[] ob = null;
                DataGridViewComboBoxCell DGVCB = vr.dgv_sals_dgv.Rows[i].Cells[4] as DataGridViewComboBoxCell;
                int num = Convert.ToInt32(vr.dgv_sals_dgv.Rows[i].Cells[1].Value);
                DataRow[] dr_num_avrg = DB_Add_delete_update_.Database.ds.Tables["unite_items"].Select("item_no =" + num);
                if (Convert.ToInt32(DGVCB.Value) == 1)
                {
                    ob = DB_Add_delete_update_.Database.ds.Tables["therpeutic_unite"].Rows.Find(dr_num_avrg[0][1]).ItemArray;
                }
                else if (Convert.ToInt32(DGVCB.Value) == 2)
                {
                    ob = DB_Add_delete_update_.Database.ds.Tables["therpeutic_unite"].Rows.Find(dr_num_avrg[0][2]).ItemArray;
                }
                else if (Convert.ToInt32(DGVCB.Value) == 3)
                {
                    ob = DB_Add_delete_update_.Database.ds.Tables["therpeutic_unite"].Rows.Find(dr_num_avrg[0][3]).ItemArray;
                }
                dt.Rows.Add(
                    i.ToString(),
                    vr.dgv_sals_dgv.Rows[i].Cells[2].Value,
                    ob[1],
                   vr.dgv_sals_dgv.Rows[i].Cells[5].Value,
                   vr.dgv_sals_dgv.Rows[i].Cells[6].Value);
            }
            RP.txtDateTime.Text = DateTime.Now.ToString();
            RP.txt_name_cline.Text = "الاخ المحترم";
            RP.num_Footer.Text = num_Footer.ToString();
            RP.xrBarCode1.Text = num_Footer.ToString();
            DataRow dt_Emp_use = DB_Add_delete_update_.Database.ds.Tables["TB_LOGIN_EMP"].Rows.Find(new object[] { Convert.ToInt32(vr.txt_user_id_Emp.Caption), vr.txt_user_Emp.Caption });//Convert.ToInt32(vr.txt_user_id_Emp.Caption)
                                                                                                                                                                                           // if (dt_Emp_use.Count()!=0) {

            DataRow dt_Emp_name_use = DB_Add_delete_update_.Database.ds.Tables["TB_Employees"].Rows.Find(dt_Emp_use[4]);
            // }

            RP.txt_totle.Text = vr.txt_begin_Dicount_All_sals.Text;
            RP.desc_value.Text = vr.txt_Dicount_value_All_sals.Text;
            RP.desc_rate.Text = vr.txt_Dicount_Rate_All_sals.Text;
            RP.txt_sales_all.Text = vr.txt_end_Dico_All_sals.Text;
            RP.txt_user_foo.Text = dt_Emp_name_use[1].ToString() ;

            //RP.txt_pad.Text = Convert.ToDouble(vr2.txt_sals_pand_cash.Text).ToString("N2") ;
            //RP.txt_bage.Text = vr2.txt_after_pand_cash.Text;

            new classs_table.Items_Tools().show_Dev_ReportView_footer(dt, RP);

        }
    }
}
