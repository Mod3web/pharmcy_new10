using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using CrystalDecisions.CrystalReports.Engine;
using System.Threading.Tasks;
using System.Windows.Forms;
using CrystalDecisions.Windows.Forms;

namespace Manag_ph.storg.Report
{
    class RP_storg_Item
    {


        void Fill_com_Storg_Item_RP()
        {
            var vr = Application.OpenForms["Main"] as Main;
            DataTable dt = new DataTable("Storg");
            dt.Columns.Add("Storg_id",typeof(int));
            dt.Columns.Add("Storg_Name");
            dt.Rows.Add(0, "الكل");

            for (int i = 0; i < DB_Add_delete_update_.Database.ds.Tables["Storg"].Rows.Count; i++)
            {

                object[] dr = DB_Add_delete_update_.Database.ds.Tables["Storg"].Rows[i].ItemArray;
                dt.Rows.Add(Convert.ToInt32(dr[0]), dr[1].ToString());
            }
            vr.com_Storg_RP_Item_All.DataSource = dt;
            vr.com_Storg_RP_Item_All.DisplayMember = "Storg_Name";
            vr.com_Storg_RP_Item_All.ValueMember = "Storg_id";
        }

        void Fill_com_unit_Type_RP()
        {
            var vr = Application.OpenForms["Main"] as Main;
            DataTable dt = new DataTable("Storg");
            dt.Columns.Add("unit_id",typeof(int));
            dt.Columns.Add("unit_Name");
            dt.Rows.Add(0, "الكل");
            dt.Rows.Add(1, "كبراء");
            dt.Rows.Add(2, "وسطاء");
            dt.Rows.Add(3, "صغراء");
            vr.com_unit_Type_RP_storg.DataSource = dt;
            vr.com_unit_Type_RP_storg.DisplayMember = "unit_Name";
            vr.com_unit_Type_RP_storg.ValueMember = "unit_id";
        }
        public void Fill_Com_Filter_RP()
        {
            Fill_com_Storg_Item_RP();
            Fill_com_unit_Type_RP();
        }

        public void Serch_RP_Item_Storg()
        {
            var vr = Application.OpenForms["Main"] as Main;
            vr. dgv_RP_Item_Storg_dgv.Rows.Clear();
            DataTable dt;
            bool check_select_unit = false;

            int Storg_Value = Convert.ToInt32(vr.com_Storg_RP_Item_All.SelectedValue);
            string name_Storg = vr.com_Storg_RP_Item_All.Text.ToString();
            if (Storg_Value == 0)
            {
                dt = DB_Add_delete_update_.Database.ds.Tables["Item_storg"];

            }
            else
            {
                dt = new classs_table.Items_Tools().GetItems_Storg_All(Storg_Value);
            }

            if (Convert.ToInt32(vr.com_unit_Type_RP_storg.SelectedValue) != 0)
            {
                check_select_unit = true;

            }


            if (vr.txt_name_Item_RP_Storg_All.Text != string.Empty)
            {
                DataRow[] dr_Item = check_select_unit ? dt.Select("Item_no = " + Convert.ToInt32(vr.txt_num_Item_RP_Storg_All.Text.Trim()) + " and type_unit = " + vr.com_unit_Type_RP_storg.SelectedValue) : dt.Select("Item_no = " + Convert.ToInt32(vr.txt_num_Item_RP_Storg_All.Text.Trim()));
                for (int i = 0; i < dr_Item.Count(); i++)
                {
                    object[] ob_inf_Item = DB_Add_delete_update_.Database.ds.Tables["Item"].Rows.Find(dr_Item[i][9]).ItemArray;
                    object[] ob_combny = DB_Add_delete_update_.Database.ds.Tables["manufctur_company"].Rows.Find(Convert.ToInt32(ob_inf_Item[10])).ItemArray;
                    object[] ob_unit = DB_Add_delete_update_.Database.ds.Tables["therpeutic_unite"].Rows.Find(Convert.ToInt32(dr_Item[i][10])).ItemArray;
                    if (vr.ch_drug_RP.Checked && vr.ch_drug_nots_RP.Checked == false)
                    {

                        if (Convert.ToBoolean(ob_inf_Item[6]) == true)
                        {
                            vr.dgv_RP_Item_Storg_dgv.Rows.Add(name_Storg, dr_Item[i][9], ob_inf_Item[2], ob_inf_Item[1], ob_combny[1], ob_unit[1], dr_Item[i][1], Convert.ToDouble(dr_Item[i][7]).ToString("N2"), Convert.ToDouble(dr_Item[i][8]).ToString("N2"));

                        }
                    }
                    else if (vr.ch_drug_RP.Checked == false && vr.ch_drug_nots_RP.Checked == true)
                    {
                        if (Convert.ToBoolean(ob_inf_Item[6]) == false)
                        {
                            vr.dgv_RP_Item_Storg_dgv.Rows.Add(name_Storg, dr_Item[i][9], ob_inf_Item[2], ob_inf_Item[1], ob_combny[1], ob_unit[1], dr_Item[i][1], Convert.ToDouble(dr_Item[i][7]).ToString("N2"), Convert.ToDouble(dr_Item[i][8]).ToString("N2"));

                        }
                    }
                    else
                    {
                        vr.dgv_RP_Item_Storg_dgv.Rows.Add(name_Storg, dr_Item[i][9], ob_inf_Item[2], ob_inf_Item[1], ob_combny[1], ob_unit[1], dr_Item[i][1], Convert.ToDouble(dr_Item[i][7]).ToString("N2"), Convert.ToDouble(dr_Item[i][8]).ToString("N2"));

                    }
                }
            }
            else
            {
                try
                {
                    dt = check_select_unit ? dt.Select("type_unit = " + vr.com_unit_Type_RP_storg.SelectedValue).CopyToDataTable() : dt;
                }
                catch 
                {
                    throw new Exception("No Data");
                    return;
                }

                //dt = check_select_unit ? dt.Select("type_unit = " + vr.com_unit_Type_RP_storg.SelectedValue).CopyToDataTable() : dt;

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    object[] ob_inf_Item = DB_Add_delete_update_.Database.ds.Tables["Item"].Rows.Find(dt.Rows[i][9]).ItemArray;
                    object[] ob_combny = DB_Add_delete_update_.Database.ds.Tables["manufctur_company"].Rows.Find(Convert.ToInt32(ob_inf_Item[10])).ItemArray;
                    object[] ob_unit = DB_Add_delete_update_.Database.ds.Tables["therpeutic_unite"].Rows.Find(Convert.ToInt32(dt.Rows[i][10])).ItemArray;



                    if (vr.ch_drug_RP.Checked && vr.ch_drug_nots_RP.Checked == false)
                    {

                        if (Convert.ToBoolean(ob_inf_Item[6]) == true)
                        {

                            vr.dgv_RP_Item_Storg_dgv.Rows.Add(name_Storg, dt.Rows[i][9], ob_inf_Item[2], ob_inf_Item[1], ob_combny[1], ob_unit[1], dt.Rows[i][1], Convert.ToDouble(dt.Rows[i][7]).ToString("N2"), Convert.ToDouble(dt.Rows[i][8]).ToString("N2"));
                        }
                    }
                    else if (vr.ch_drug_RP.Checked == false && vr.ch_drug_nots_RP.Checked == true)
                    {
                        if (Convert.ToBoolean(ob_inf_Item[6]) == false)
                        {
                            vr.dgv_RP_Item_Storg_dgv.Rows.Add(name_Storg, dt.Rows[i][9], ob_inf_Item[2], ob_inf_Item[1], ob_combny[1], ob_unit[1], dt.Rows[i][1], Convert.ToDouble(dt.Rows[i][7]).ToString("N2"), Convert.ToDouble(dt.Rows[i][8]).ToString("N2"));
                        }
                    }
                    else
                    {
                        vr.dgv_RP_Item_Storg_dgv.Rows.Add(name_Storg, dt.Rows[i][9], ob_inf_Item[2], ob_inf_Item[1], ob_combny[1], ob_unit[1], dt.Rows[i][1], Convert.ToDouble(dt.Rows[i][7]).ToString("N2"), Convert.ToDouble(dt.Rows[i][8]).ToString("N2"));

                    }



                }
            }

            vr.lbl_count_Item_RP_storg.Text = vr.dgv_RP_Item_Storg_dgv.Rows.Count.ToString();
        }

        public void show_Report_Item_Storg()
        {
            var vr = Application.OpenForms["Main"] as Main;

            RPP_Item_Storg RPP = new RPP_Item_Storg();

            DataTable dt_RP_Item_storg = new DataTable("dt_RP_Item_storg");

            dt_RP_Item_storg.Columns.Add("Item_no", typeof(int));
            dt_RP_Item_storg.Columns.Add("Item_name_en", typeof(string));
            dt_RP_Item_storg.Columns.Add("compny_name", typeof(string));
            dt_RP_Item_storg.Columns.Add("unit_name", typeof(string));
            dt_RP_Item_storg.Columns.Add("qty", typeof(int));
            dt_RP_Item_storg.Columns.Add("sell_prod", typeof(double));
            dt_RP_Item_storg.Columns.Add("sell_pric", typeof(double));
            dt_RP_Item_storg.Columns.Add("sum_sell_prod", typeof(double));
            dt_RP_Item_storg.Columns.Add("sum_sell_pric", typeof(double));
            dt_RP_Item_storg.Columns.Add("Storg_name", typeof(string));
            dt_RP_Item_storg.Columns.Add("unit_serch_name", typeof(string));

            for (int i = 0; i < vr.dgv_RP_Item_Storg_dgv.Rows.Count; i++)
            {

                double sum_sell_prod = Convert.ToDouble(vr.dgv_RP_Item_Storg_dgv.Rows[i].Cells[7].Value) * Convert.ToDouble(vr.dgv_RP_Item_Storg_dgv.Rows[i].Cells[6].Value);
                double sum_sell_pric = Convert.ToDouble(vr.dgv_RP_Item_Storg_dgv.Rows[i].Cells[8].Value) * Convert.ToDouble(vr.dgv_RP_Item_Storg_dgv.Rows[i].Cells[6].Value);


                dt_RP_Item_storg.Rows.Add(vr.dgv_RP_Item_Storg_dgv.Rows[i].Cells[1].Value, vr.dgv_RP_Item_Storg_dgv.Rows[i].Cells[3].Value, vr.dgv_RP_Item_Storg_dgv.Rows[i].Cells[4].Value, vr.dgv_RP_Item_Storg_dgv.Rows[i].Cells[5].Value, vr.dgv_RP_Item_Storg_dgv.Rows[i].Cells[6].Value, vr.dgv_RP_Item_Storg_dgv.Rows[i].Cells[7].Value, vr.dgv_RP_Item_Storg_dgv.Rows[i].Cells[8].Value, sum_sell_prod.ToString("N2"), sum_sell_pric.ToString("N2"), vr.com_Storg_RP_Item_All.Text, vr.com_unit_Type_RP_storg.Text);
            }
            new classs_table.Items_Tools().show_CrystalReportView(dt_RP_Item_storg, vr.crv_Item_Storg, "../../storg/Report/CR_Item_Storg.rpt");
            new classs_table.Items_Tools().show_Dev_ReportView(dt_RP_Item_storg, RPP);



        }


    }
}
