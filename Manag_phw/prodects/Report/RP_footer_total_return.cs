using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Manag_ph.prodects.Report
{
    class RP_footer_total_return
    {



        public void save_Data_Return()
        {
            var vr = Application.OpenForms["Main"] as Main;
            vr.dgv_total_footer_return_dgv.Rows.Clear();
            if (vr.txt_num_supper_RP_total_return.Text.Trim() != string.Empty)
            {
                string query = "supper_num =" + vr.txt_num_supper_RP_total_return.Text;
                if (vr.ch_date_total_return.Checked)
                {
                    query += " and (Date_return >= '" + vr.dtp_total_footer_total_return_one.Value + "' and  Date_return <= '" + vr.dtp_total_footer_total_return_tow.Value + "')";
                }

                DataRow[] dr_Data_total_return = DB_Add_delete_update_.Database.ds.Tables["RP_Total_return"].Select(query);
                if (dr_Data_total_return.Count() != 0)
                {
                    for (int i = 0; i < dr_Data_total_return.Count(); i++)
                    {
                        DataRow dr_supper = DB_Add_delete_update_.Database.ds.Tables["Supplier"].Rows.Find(dr_Data_total_return[i][4]);
                        DataRow dr_DataFooter = DB_Add_delete_update_.Database.ds.Tables["Data_Footer"].Rows.Find(dr_Data_total_return[i][1]);
                        DataRow dr_total_footer = DB_Add_delete_update_.Database.ds.Tables["Totel_Footer_prodeuct"].Rows.Find(dr_DataFooter[9]);
                        DataRow dr_Emp = DB_Add_delete_update_.Database.ds.Tables["TB_Employees"].Rows.Find(dr_Data_total_return[i][3]);

                        vr.dgv_total_footer_return_dgv.Rows.Add(dr_Data_total_return[i][0], dr_Data_total_return[i][1], dr_DataFooter[1], Convert.ToDateTime(dr_DataFooter[5]).ToString("d"), dr_Emp[1], dr_supper[1], Convert.ToDateTime(dr_Data_total_return[i][2]).ToString("d"), Convert.ToDouble(dr_Data_total_return[i][5]).ToString("N2"),Convert.ToDouble(dr_total_footer[5]).ToString("N2"));
                    }
                }
            }

        }

        public void show_CRV_total_return()
        {
            //MessageBox.Show("insid_method");
            var vr = Application.OpenForms["Main"] as Main;
            DataTable dt = new classs_table.Items_Tools().Fill_DataTable_Columns("dt_RP_total_footer_return", new string[] { "total_code",
                    "footer_code",
                    "footer_number",
                    "Date_footer",
                    "Empy_name",
                    "supper_name",
                    "Date_footer_return",
                    "sals_total",
                    "total_footer_alter"});

            dt.Columns["sals_total"].DataType = typeof(double);


            //MessageBox.Show("insid_if");

            RPP_footer_total_return RPP = new RPP_footer_total_return();
                for (int i = 0; i < vr.dgv_total_footer_return_dgv.RowCount; i++)
                {
                    dt.Rows.Add(
                        vr.dgv_total_footer_return_dgv.Rows[i].Cells[0].Value,
                        vr.dgv_total_footer_return_dgv.Rows[i].Cells[1].Value,
                        vr.dgv_total_footer_return_dgv.Rows[i].Cells[2].Value,
                        vr.dgv_total_footer_return_dgv.Rows[i].Cells[3].Value,
                        vr.dgv_total_footer_return_dgv.Rows[i].Cells[4].Value,
                        vr.dgv_total_footer_return_dgv.Rows[i].Cells[5].Value,
                        vr.dgv_total_footer_return_dgv.Rows[i].Cells[6].Value,
                        vr.dgv_total_footer_return_dgv.Rows[i].Cells[7].Value,
                        vr.dgv_total_footer_return_dgv.Rows[i].Cells[8].Value

                        );
               

            }
            if (vr.dgv_total_footer_return_dgv.RowCount != 0)
            {
            //new classs_table.Items_Tools().show_CrystalReportView(dt, vr.CRV_total_footer_return, "../../prodects/Report/CR_footer_total_return.rpt");
               new classs_table.Items_Tools().show_Dev_ReportView(dt,RPP);
            }

      



        }

    }
}
