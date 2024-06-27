using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Manag_ph.storg.Report
{
    class RP_Item_Expirt_Item
    {

        void Fill_com_Storg_Item_Expirt_RP()
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
            vr.com_RP_Storg_Expirt.DataSource = dt;
            vr.com_RP_Storg_Expirt.DisplayMember = "Storg_Name";
            vr.com_RP_Storg_Expirt.ValueMember = "Storg_id";
        }

        void Fill_com_CompnyExpirt_RP()
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
            vr.com_Compny_RP_Expirt.DataSource = dt;
            vr.com_Compny_RP_Expirt.DisplayMember = "comp_name";
            vr.com_Compny_RP_Expirt.ValueMember = "comp_num";
        }

        public void Fill_All_Data_RP_Expoirt()
        {
            Fill_com_Storg_Item_Expirt_RP();
            Fill_com_CompnyExpirt_RP();
        }

        public void Serch_RP_Item_Storg_Expirt()
        {
            var vr = Application.OpenForms["Main"] as Main;
            vr.dgv_RP_Expert_Item_dgv.Rows.Clear();
            DataTable dt;
      

            int Storg_Value = Convert.ToInt32(vr.com_RP_Storg_Expirt.SelectedValue);
            string name_Storg = vr.com_RP_Storg_Expirt.Text.ToString();
            if (Storg_Value == 0)
            {
                dt = DB_Add_delete_update_.Database.ds.Tables["Item_storg"];

            }
            else
            {
                dt = new classs_table.Items_Tools().GetItems_Storg_All(Storg_Value);
            }
            dt = dt.Select("Date_end >= '" + Convert.ToDateTime(vr.dtp_Expert_RP_on.Text).ToString("d") + "' and Date_end <= '" + Convert.ToDateTime(vr.dtp_Expert_RP_tow.Text).ToString("d")+"'").Count() != 0 ? dt.Select("Date_end >= '" + Convert.ToDateTime(vr.dtp_Expert_RP_on.Text).ToString("d") + "' and Date_end <= '" + Convert.ToDateTime(vr.dtp_Expert_RP_tow.Text).ToString("d") + "'").CopyToDataTable() : null;
            if (dt == null)
            {
                vr.dgv_RP_Expert_Item_dgv.Rows.Clear();
                return;
            }
            if (Convert.ToInt32(vr.com_Compny_RP_Expirt.SelectedValue) == 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    object[] ob_inf_Item = DB_Add_delete_update_.Database.ds.Tables["Item"].Rows.Find(dt.Rows[i][9]).ItemArray;
                    object[] ob_combny = DB_Add_delete_update_.Database.ds.Tables["manufctur_company"].Rows.Find(Convert.ToInt32(ob_inf_Item[10])).ItemArray;
                    object[] ob_unit = DB_Add_delete_update_.Database.ds.Tables["therpeutic_unite"].Rows.Find(Convert.ToInt32(dt.Rows[i][10])).ItemArray;
                    if (vr.ch_drug_Expirt.Checked && vr.ch_drug_not_Expirt.Checked == false)
                    {

                        if (Convert.ToBoolean(ob_inf_Item[6]) == true)
                        {
                            vr.dgv_RP_Expert_Item_dgv.Rows.Add(name_Storg, dt.Rows[i][9], ob_inf_Item[2], ob_inf_Item[1], ob_combny[1], ob_unit[1], Convert.ToDateTime(dt.Rows[i][2]).ToString("d"), dt.Rows[i][1], Convert.ToDouble(dt.Rows[i][7]).ToString("N2"), Convert.ToDouble(dt.Rows[i][8]).ToString("N2")) ;
                        }
                    }
                    else if (vr.ch_drug_Expirt.Checked == false && vr.ch_drug_not_Expirt.Checked == true)
                    {
                        if (Convert.ToBoolean(ob_inf_Item[6]) == false)
                        {
                            vr.dgv_RP_Expert_Item_dgv.Rows.Add(name_Storg, dt.Rows[i][9], ob_inf_Item[2], ob_inf_Item[1], ob_combny[1], ob_unit[1], Convert.ToDateTime(dt.Rows[i][2]).ToString("d"), dt.Rows[i][1], Convert.ToDouble(dt.Rows[i][7]).ToString("N2"), Convert.ToDouble(dt.Rows[i][8]).ToString("N2"));
                        }
                    }
                    else
                    {
                        vr.dgv_RP_Expert_Item_dgv.Rows.Add(name_Storg, dt.Rows[i][9], ob_inf_Item[2], ob_inf_Item[1], ob_combny[1], ob_unit[1], Convert.ToDateTime(dt.Rows[i][2]).ToString("d"), dt.Rows[i][1], Convert.ToDouble(dt.Rows[i][7]).ToString("N2"), Convert.ToDouble(dt.Rows[i][8]).ToString("N2"));

                    }
                }


            }
            else
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    DataRow[] ob_inf_Item = DB_Add_delete_update_.Database.ds.Tables["Item"].Select("Item_no =" + dt.Rows[i][9] + " and comp_num = " + Convert.ToInt32(vr.com_Compny_RP_Expirt.SelectedValue));
                    if (ob_inf_Item.Count() != 0)
                    {


                        object[] ob_combny = DB_Add_delete_update_.Database.ds.Tables["manufctur_company"].Rows.Find(Convert.ToInt32(ob_inf_Item[0][10])).ItemArray;
                        object[] ob_unit = DB_Add_delete_update_.Database.ds.Tables["therpeutic_unite"].Rows.Find(Convert.ToInt32(dt.Rows[i][10])).ItemArray;
                        if (vr.ch_drug_Expirt.Checked && vr.ch_drug_not_Expirt.Checked == false)
                        {

                            if (Convert.ToBoolean(ob_inf_Item[0][6]) == true)
                            {
                                vr.dgv_RP_Expert_Item_dgv.Rows.Add(name_Storg, dt.Rows[i][9], ob_inf_Item[0][2], ob_inf_Item[0][1], ob_combny[1], ob_unit[1], Convert.ToDateTime(dt.Rows[i][2]).ToString("d"), dt.Rows[i][1], Convert.ToDouble(dt.Rows[i][7]).ToString("N2"), Convert.ToDouble(dt.Rows[i][8]).ToString("N2"));
                            }
                        }
                        else if (vr.ch_drug_Expirt.Checked == false && vr.ch_drug_not_Expirt.Checked == true)
                        {
                            if (Convert.ToBoolean(ob_inf_Item[0][6]) == false)
                            {
                                vr.dgv_RP_Expert_Item_dgv.Rows.Add(name_Storg, dt.Rows[i][9], ob_inf_Item[0][2], ob_inf_Item[0][1], ob_combny[1], ob_unit[1], Convert.ToDateTime(dt.Rows[i][2]).ToString("d"), dt.Rows[i][1], Convert.ToDouble(dt.Rows[i][7]).ToString("N2"), Convert.ToDouble(dt.Rows[i][8]).ToString("N2"));
                            }
                        }
                        else
                        {
                            vr.dgv_RP_Expert_Item_dgv.Rows.Add(name_Storg, dt.Rows[i][9], ob_inf_Item[0][2], ob_inf_Item[0][1], ob_combny[1], ob_unit[1], Convert.ToDateTime(dt.Rows[i][2]).ToString("d"), dt.Rows[i][1], Convert.ToDouble(dt.Rows[i][7]).ToString("N2"), Convert.ToDouble(dt.Rows[i][8]).ToString("N2"));

                        }
                    }
                }

            }




            vr.lbl_count_Expirt.Text = vr.dgv_RP_Expert_Item_dgv.Rows.Count.ToString();
        }

        public void show_Report_Item_Storg()
        {
            var vr = Application.OpenForms["Main"] as Main;

            RPP_Item_Export_Item RPP = new RPP_Item_Export_Item();

            DataTable dt_RP_Item_storg = new DataTable("dt_RP_Expoirt");

            dt_RP_Item_storg.Columns.Add("Item_no", typeof(int));
            dt_RP_Item_storg.Columns.Add("Item_name_en", typeof(string));
            dt_RP_Item_storg.Columns.Add("compny_name", typeof(string));
            dt_RP_Item_storg.Columns.Add("unit_name", typeof(string));
            dt_RP_Item_storg.Columns.Add("qty", typeof(int));
            dt_RP_Item_storg.Columns.Add("Storg_name", typeof(string));
            dt_RP_Item_storg.Columns.Add("dtp_one", typeof(string));
            dt_RP_Item_storg.Columns.Add("dtp_tow", typeof(string));
            dt_RP_Item_storg.Columns.Add("Date_end", typeof(string));
            dt_RP_Item_storg.Columns.Add("Compnt_serch", typeof(string));

            for (int i = 0; i < vr.dgv_RP_Expert_Item_dgv.Rows.Count; i++)
            {
                dt_RP_Item_storg.Rows.Add(
                    vr.dgv_RP_Expert_Item_dgv.Rows[i].Cells[1].Value,
                    vr.dgv_RP_Expert_Item_dgv.Rows[i].Cells[3].Value,
                    vr.dgv_RP_Expert_Item_dgv.Rows[i].Cells[4].Value,
                    vr.dgv_RP_Expert_Item_dgv.Rows[i].Cells[5].Value,
                   vr.dgv_RP_Expert_Item_dgv.Rows[i].Cells[7].Value,
                    vr.dgv_RP_Expert_Item_dgv.Rows[i].Cells[0].Value,
                    vr.dtp_Expert_RP_on.Text,
                    vr.dtp_Expert_RP_tow.Text,
                    vr.dgv_RP_Expert_Item_dgv.Rows[i].Cells[6].Value,
                    vr.com_Compny_RP_Expirt.Text);
            }
           // new classs_table.Items_Tools() .show_CrystalReportView(dt_RP_Item_storg, vr.CRV_Expirt, "../../storg/Report/CR_Item_Export_Item.rpt");
            new classs_table.Items_Tools().show_Dev_ReportView(dt_RP_Item_storg, RPP);


        }


    }
}
