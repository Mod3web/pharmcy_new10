using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Manag_ph.storg.Report
{
    class RP_update_sals
    {



        void Fill_com_Storg_Item_update_sals()
        {
            var vr = Application.OpenForms["Main"] as Main;
            DataTable dt = new DataTable("Storg");
            dt.Columns.Add("Storg_id", typeof(int));
            dt.Columns.Add("Storg_Name");
            dt.Rows.Add(0, "الكل");

            for (int i = 0; i < DB_Add_delete_update_.Database.ds.Tables["Storg"].Rows.Count; i++)
            {

                object[] dr = DB_Add_delete_update_.Database.ds.Tables["Storg"].Rows[i].ItemArray;
                dt.Rows.Add(Convert.ToInt32(dr[0]), dr[1].ToString());
            }
            vr.com_Storg_update_sals.DataSource = dt;
            vr.com_Storg_update_sals.DisplayMember = "Storg_Name";
            vr.com_Storg_update_sals.ValueMember = "Storg_id";
        }

        void Fill_com_Compny_update_sals()
        {
            var vr = Application.OpenForms["Main"] as Main;
            DataTable dt = new DataTable("manufctur_company");
            dt.Columns.Add("comp_num", typeof(int));
            dt.Columns.Add("comp_name");
            dt.Rows.Add(0, "الكل");

            for (int i = 0; i < DB_Add_delete_update_.Database.ds.Tables["manufctur_company"].Rows.Count; i++)
            {

                object[] dr = DB_Add_delete_update_.Database.ds.Tables["manufctur_company"].Rows[i].ItemArray;
                dt.Rows.Add(Convert.ToInt32(dr[0]), dr[1].ToString());
            }
            vr.com_cmpny_update_sals.DataSource = dt;
            vr.com_cmpny_update_sals.DisplayMember = "comp_name";
            vr.com_cmpny_update_sals.ValueMember = "comp_num";
        }

        void Fill_Emply()
        {
            var vr = Application.OpenForms["Main"] as Main;

            vr.com_Emply_update_sals.DataSource = DB_Add_delete_update_.Database.ds.Tables["TB_Employees"];
            vr.com_Emply_update_sals.DisplayMember = "name_AR_EMP";
            vr.com_Emply_update_sals.ValueMember = "id_EMP";
        }

        public void Fill_All_Data_RP_update_sals()
        {
            Fill_Emply();
            Fill_com_Compny_update_sals();
            Fill_com_Storg_Item_update_sals();
        }

        public void Serch_update_sals()
        {
            var vr = Application.OpenForms["Main"] as Main;
            DataTable dt_update_qty = new DataTable();
            vr.dgv_update_sals_dgv.Rows.Clear();
            int Storg_num = Convert.ToInt32(vr.com_Storg_update_sals.SelectedValue);
            int Cmony_num = Convert.ToInt32(vr.com_cmpny_update_sals.SelectedValue);
            int Emply_num = Convert.ToInt32(vr.com_Emply_update_sals.SelectedValue);
            if (Storg_num == 0 && Cmony_num == 0)
            {
                dt_update_qty = DB_Add_delete_update_.Database.ds.Tables["info_update_settle_report"].Select("id_EMP = " + Emply_num + " and (Date_settle >= '" + vr.dtp_update_sals_one.Value + "' and Date_settle <= '" + vr.dtp_update_sals_tow.Value + "')").Count() != 0 ? DB_Add_delete_update_.Database.ds.Tables["info_update_settle_report"].Select("id_EMP = " + Emply_num + " and (Date_settle >= '" + vr.dtp_update_sals_one.Value + "' and Date_settle <= '" + vr.dtp_update_sals_tow.Value + "')").CopyToDataTable() : null;

            }
            else if (Storg_num != 0 && Cmony_num != 0)
            {
                dt_update_qty = DB_Add_delete_update_.Database.ds.Tables["info_update_settle_report"].Select("id_EMP = " + Emply_num + " and (Date_settle >= '" + vr.dtp_update_sals_one.Value + "' and Date_settle <= '" + vr.dtp_update_sals_tow.Value + "') and (Storg_num =" + Storg_num + " and num_compny =" + Cmony_num + ")").Count() != 0 ? DB_Add_delete_update_.Database.ds.Tables["info_update_settle_report"].Select("id_EMP = " + Emply_num + " and (Date_settle >= '" + vr.dtp_update_sals_one.Value + "' and Date_settle <= '" + vr.dtp_update_sals_tow.Value + "') and (Storg_num =" + Storg_num + " and num_compny =" + Cmony_num + ")").CopyToDataTable() : null;

            }
            else if (Storg_num != 0)
            {
                dt_update_qty = DB_Add_delete_update_.Database.ds.Tables["info_update_settle_report"].Select("id_EMP = " + Emply_num + " and (Date_settle >= '" + vr.dtp_update_sals_one.Value + "' and Date_settle <= '" + vr.dtp_update_sals_tow.Value + "') and Storg_num =" + Storg_num).Count() != 0 ? dt_update_qty = DB_Add_delete_update_.Database.ds.Tables["info_update_settle_report"].Select("id_EMP = " + Emply_num + " and (Date_settle >= '" + vr.dtp_update_sals_one.Value + "' and Date_settle <= '" + vr.dtp_update_sals_tow.Value + "') and Storg_num =" + Storg_num).CopyToDataTable() : null;


            }
            else if (Cmony_num != 0)
            {
                dt_update_qty = DB_Add_delete_update_.Database.ds.Tables["info_update_settle_report"].Select("id_EMP = " + Emply_num + " and (Date_settle >= '" + vr.dtp_update_sals_one.Value + "' and Date_settle <= '" + vr.dtp_update_sals_tow.Value + "') and num_compny =" + Cmony_num).Count() != 0 ? dt_update_qty = DB_Add_delete_update_.Database.ds.Tables["info_update_settle_report"].Select("id_EMP = " + Emply_num + " and (Date_settle >= '" + vr.dtp_update_sals_one.Value + "' and Date_settle <= '" + vr.dtp_update_sals_tow.Value + "') and num_compny =" + Cmony_num).CopyToDataTable() : null;

            }


            if (dt_update_qty != null)
            {
                if (dt_update_qty.Rows.Count != 0)
                {
                    for (int i = 0; i < dt_update_qty.Rows.Count; i++)
                    {
                        if (Convert.ToInt32(dt_update_qty.Rows[i][8]) != Convert.ToInt32(dt_update_qty.Rows[i][9]))
                        {
                            object[] obj_Item = DB_Add_delete_update_.Database.ds.Tables["Item"].Rows.Find(dt_update_qty.Rows[i][1]).ItemArray;
                            object[] obj_Cmpny = DB_Add_delete_update_.Database.ds.Tables["manufctur_company"].Rows.Find(dt_update_qty.Rows[i][2]).ItemArray;
                            object[] obj_unit = DB_Add_delete_update_.Database.ds.Tables["therpeutic_unite"].Rows.Find(dt_update_qty.Rows[i][3]).ItemArray;
                            double sell_pric = Convert.ToDouble(dt_update_qty.Rows[i][9]);
                            vr.dgv_update_sals_dgv.Rows.Add(vr.com_Storg_update_sals.Text, dt_update_qty.Rows[i][1], obj_Item[2], obj_Item[1], obj_Cmpny[1], obj_unit[1], Convert.ToInt32(dt_update_qty.Rows[i][8]).ToString("N2"), Convert.ToInt32(dt_update_qty.Rows[i][9]).ToString("N2"), "", Convert.ToDateTime(dt_update_qty.Rows[i][13]).ToString("d"));
                            double asp = Convert.ToDouble(dt_update_qty.Rows[i][9]) - Convert.ToDouble(dt_update_qty.Rows[i][8]);
                            vr.dgv_update_sals_dgv.Rows[vr.dgv_update_sals_dgv.Rows.Count - 1].Cells[8].Value = asp.ToString("N2");
                            if (asp >= 0)
                            {
                                vr.dgv_update_sals_dgv.Rows[vr.dgv_update_sals_dgv.Rows.Count - 1].Cells[8].Style.BackColor = Color.RoyalBlue;
                            }
                            else
                            {
                                vr.dgv_update_sals_dgv.Rows[vr.dgv_update_sals_dgv.Rows.Count - 1].Cells[8].Style.BackColor = Color.Tomato;
                            }
                        }
                    }
                }

            }
            vr.lbl_count_update_sals.Text = vr.dgv_update_sals_dgv.RowCount.ToString();


        }



        public void show_crv_update_sals()
        {
            var vr = Application.OpenForms["Main"] as Main;
            if (vr.dgv_update_sals_dgv.RowCount != 0)
            {

                RPP_dpdate_sals RPP = new RPP_dpdate_sals();
                DataTable dt = new DataTable("dt_RP_update_Sals");
                dt.Columns.Add("Item_no");
                dt.Columns.Add("Item_name_en");
                dt.Columns.Add("compny_name");
                dt.Columns.Add("unit_name");
                dt.Columns.Add("Sals_pric_begin");
                dt.Columns.Add("Sals_pric_end");
                dt.Columns.Add("Date_update");
                dt.Columns.Add("Storg_name");
                dt.Columns.Add("Emply_name");
                dt.Columns.Add("compny_name_serch");
                dt.Columns.Add("Date_one");
                dt.Columns.Add("Date_tow");
                dt.Columns.Add("sum_sals");
                for (int i = 0; i < vr.dgv_update_sals_dgv.RowCount; i++)
                {

                    dt.Rows.Add(vr.dgv_update_sals_dgv.Rows[i].Cells[1].Value,
                        vr.dgv_update_sals_dgv.Rows[i].Cells[3].Value,
                        vr.dgv_update_sals_dgv.Rows[i].Cells[4].Value,
                        vr.dgv_update_sals_dgv.Rows[i].Cells[5].Value,
                        vr.dgv_update_sals_dgv.Rows[i].Cells[6].Value,
                      vr.dgv_update_sals_dgv.Rows[i].Cells[7].Value,
                       vr.dgv_update_sals_dgv.Rows[i].Cells[9].Value,
                       vr.com_Storg_update_sals.Text,
                       vr.com_Emply_update_sals.Text,
                       vr.com_cmpny_update_sals.Text,
                       vr.dtp_update_sals_one.Text,
                       vr.dtp_update_sals_tow.Text,
                        vr.dgv_update_sals_dgv.Rows[i].Cells[8].Value
                       );
                }

                //new classs_table.Items_Tools().show_CrystalReportView(dt, vr.CRV_update_sals, "../../storg/Report/CR_dpdate_sals.rpt");
                new classs_table.Items_Tools().show_Dev_ReportView(dt, RPP);
            }

        }






    }
}
