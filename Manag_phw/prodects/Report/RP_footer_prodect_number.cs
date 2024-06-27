using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Manag_ph.prodects.Report
{
    class RP_footer_prodect_number
    {

        DataRow[] dr_df;
        DataRow dr_df_find;

        public void serch_footer_prodect_number(int type_serch)
        {
            var vr = Application.OpenForms["Main"] as Main;
            bool temp = false;
            if (type_serch == 0)
            {
                dr_df_find = DB_Add_delete_update_.Database.ds.Tables["Data_Footer"].Rows.Find(vr.txt_footter_id_RP_num.Text.Trim());
                temp = dr_df_find != null ? true : false;
            }
            else if (type_serch == 1)
            {
                dr_df = DB_Add_delete_update_.Database.ds.Tables["Data_Footer"].Select("Foot_number = '" + vr.txt_footter_number_RP_num.Text + "' and Foot_supper =" + vr.txt_footter_supper_num_RP_num.Text);
                temp = dr_df.Count() != 0 ? true : false;

            }
            vr.dgv_footer_RP_number_dgv.Rows.Clear();
            //MessageBox.Show(dr_df.Count()+"");
            if (temp)
            {
                object[] storg_data = DB_Add_delete_update_.Database.ds.Tables["Storg"].Rows.Find(type_serch == 1 ? dr_df[0][2] : dr_df_find[2]).ItemArray;
                object[] suppr_data = DB_Add_delete_update_.Database.ds.Tables["Supplier"].Rows.Find(type_serch == 1 ? dr_df[0][4] : dr_df_find[4]).ItemArray;
                object[] sum_data = DB_Add_delete_update_.Database.ds.Tables["sum_storg_Item"].Rows.Find(type_serch == 1 ? dr_df[0][7] : dr_df_find[7]).ItemArray;
                object[] Totle_data = DB_Add_delete_update_.Database.ds.Tables["Totel_Footer_prodeuct"].Rows.Find(type_serch == 1 ? dr_df[0][9] : dr_df_find[9]).ItemArray;
                object[] Emply = DB_Add_delete_update_.Database.ds.Tables["TB_Employees"].Rows.Find(type_serch == 1 ? dr_df[0][10] : dr_df_find[10]).ItemArray;

                vr.txt_footter_id_RP_num.Text = type_serch == 1 ? dr_df[0][0].ToString() : dr_df_find[0].ToString();
                vr.txt_footter_storg_RP_num.Text = storg_data[1].ToString();
                vr.txt_footter_empy_RP_num.Text = Emply[1].ToString();
                vr.txt_footter_Date_foot_RP_num.Text = Convert.ToDateTime(type_serch == 1 ? dr_df[0][5]: dr_df_find[5]).ToString("d");
                vr.txt_footter_Date_creat_RP_num.Text =Convert.ToDateTime(type_serch == 1 ? dr_df[0][11] : dr_df_find[11]).ToString("d");
                vr.txt_footter_type_foot_RP_num.Text = type_serch == 1 ? dr_df[0][3].ToString() : dr_df_find[3].ToString(); ;
                vr.txt_footter_total_begin_RP_num.Text = Convert.ToDouble(Totle_data[1]).ToString("N2");
                vr.txt_footter_Dicount_rate_RP_num.Text = Totle_data[2].ToString();
                vr.txt_footter_Dicount_value_RP_num.Text = Convert.ToDouble( Totle_data[3]).ToString("N2");
                vr.txt_footter_total_return_RP_num.Text = Convert.ToDouble(Totle_data[6]).ToString("N2");
                vr.txt_footter_total_alter_RP_num.Text = Convert.ToDouble(Convert.ToDouble(Totle_data[5]) - Convert.ToDouble(Totle_data[6])).ToString("N2");


                if (type_serch == 0)
                {
                    vr.txt_footter_number_RP_num.Text = dr_df_find[1].ToString();
                    vr.txt_footter_supper_num_RP_num.Text = dr_df_find[4].ToString();
                    vr.txt_footter_supper_name_RP_num.Text = suppr_data[1].ToString();

                }


                DataRow[] dr_Items = DB_Add_delete_update_.Database.ds.Tables["Item_storg"].Select("sum_num =" + (type_serch == 1 ? dr_df[0][7].ToString() : dr_df_find[7].ToString()));

                if (dr_Items.Count() != 0)
                {
                    for (int i = 0; i < dr_Items.Count(); i++)
                    {
                      object[] ob_Item =  DB_Add_delete_update_.Database.ds.Tables["Item"].Rows.Find(dr_Items[i][9]).ItemArray;
                      DataRow[] ob_Item_RP =  DB_Add_delete_update_.Database.ds.Tables["RP_Data_Item_prodect"].Select("num_Item_storg = " + dr_Items[i][0]);
                        if (ob_Item_RP.Count() == 0)
                        {
                            MessageBox.Show("الخطاء امسح بيانات المشتريات القديمات رسالة لماجد");
                            return;
                        }
                        //جلب اسم الوحدة
                        object[] ob_unit = DB_Add_delete_update_.Database.ds.Tables["therpeutic_unite"].Rows.Find(ob_Item_RP[0][3]).ItemArray;
                        double total_sals_pris = Convert.ToDouble((Convert.ToDouble(ob_Item_RP[0][1]) - Convert.ToDouble(ob_Item_RP[0][5])) * Convert.ToDouble(dr_Items[i][8]));
                        double total_sals_prodect = Convert.ToDouble((Convert.ToDouble(ob_Item_RP[0][1]) - Convert.ToDouble(ob_Item_RP[0][5])) * Convert.ToDouble(ob_Item_RP[0][4]));

                        // اضافة البيانات الا الجدول للعرض
                      
                        vr.dgv_footer_RP_number_dgv.Rows.Add(
                        dr_Items[i][9],
                        ob_Item[2],
                        ob_Item[1],
                        ob_unit[1],
                       Convert.ToDateTime( dr_Items[i][2]).ToString("d"),
                        ob_Item_RP[0][1],
                        ob_Item_RP[0][2],
                        ob_Item_RP[0][5],
                        ob_Item_RP[0][6],
                       Convert.ToDouble(dr_Items[i][8]).ToString("N2"),
                       Convert.ToDouble(ob_Item_RP[0][4]).ToString("N2"),
                        Convert.ToDouble(Convert.ToDouble(dr_Items[i][8]) - Convert.ToDouble(ob_Item_RP[0][4])).ToString("N2"),
                        total_sals_pris.ToString("N2"),
                        total_sals_prodect.ToString("N2"),
                        Convert.ToDouble(total_sals_pris - total_sals_prodect).ToString("N2")
                        );

                    }
                }


                vr.lbl_footter_RP_count_Item.Text = vr.dgv_footer_RP_number_dgv.RowCount.ToString();

            }


        }


        public void Show_Report()
        {
            var vr = Application.OpenForms["Main"] as Main;
            RPP_footer_prodects RPP = new RPP_footer_prodects();

            if (vr.dgv_footer_RP_number_dgv.CurrentRow != null)
            {
                DataTable dt = new classs_table.Items_Tools().Fill_DataTable_Columns("dt_RP_footer_Item", new string[] {
                    "Item_no"
                    ,"Item_name_en"
                    ,"unit_name"
                    ,"Date_Expit"
                    ,"qty"
                    ,"poins"
                    ,"qty_return"
                    ,"poins_return"
                    ,"sals_pric"
                    ,"sals_prodect"
                    ,"prift" });

                for (int i = 0; i < vr.dgv_footer_RP_number_dgv.RowCount; i++)
                {
                    dt.Rows.Add(vr.dgv_footer_RP_number_dgv.Rows[i].Cells[0].Value,
                     vr.dgv_footer_RP_number_dgv.Rows[i].Cells[2].Value
                    , vr.dgv_footer_RP_number_dgv.Rows[i].Cells[3].Value
                    , vr.dgv_footer_RP_number_dgv.Rows[i].Cells[4].Value
                    , vr.dgv_footer_RP_number_dgv.Rows[i].Cells[5].Value
                    , vr.dgv_footer_RP_number_dgv.Rows[i].Cells[6].Value
                    , vr.dgv_footer_RP_number_dgv.Rows[i].Cells[7].Value
                    , vr.dgv_footer_RP_number_dgv.Rows[i].Cells[8].Value
                    , vr.dgv_footer_RP_number_dgv.Rows[i].Cells[9].Value
                    , vr.dgv_footer_RP_number_dgv.Rows[i].Cells[10].Value
                    , vr.dgv_footer_RP_number_dgv.Rows[i].Cells[11].Value);
                }

                DataTable dt_Date = new classs_table.Items_Tools().Fill_DataTable_Columns("dt_RP_footer_Data", new string[]{
                    "storg_name"
                    ,"footer_id"
                    ,"footer_num"
                    ,"type_sdad"
                    ,"total_begin"
                    ,"dicount_rate"
                    ,"dicount_value"
                    ,"total_return"
                    ,"total_alter"
                    ,"Date_footer"
                    ,"Empyl_name"
                    ,"supper_name"});

                dt_Date.Rows.Add(
                    vr.txt_footter_storg_RP_num.Text,
                    vr.txt_footter_id_RP_num.Text,
                    vr.txt_footter_number_RP_num.Text,
                    vr.txt_footter_type_foot_RP_num.Text,
                    vr.txt_footter_total_begin_RP_num.Text,//
                    vr.txt_footter_Dicount_rate_RP_num.Text,
                    vr.txt_footter_Dicount_value_RP_num.Text,
                    vr.txt_footter_total_return_RP_num.Text,
                    vr.txt_footter_total_alter_RP_num.Text,//
                    vr.txt_footter_Date_foot_RP_num.Text,
                    vr.txt_footter_empy_RP_num.Text,
                    vr.txt_footter_supper_name_RP_num.Text
                    
                    );

                //new classs_table.Items_Tools().show_CrystalReportView_Tow_DataTavle(dt, dt_Date, vr.CRV_footer_prodect_number, "../../prodects/Report/CR_footer_prodects.rpt");


                RPP.lbl_2.Text = vr.txt_footter_storg_RP_num.Text.ToString();
                //RPP.lbl_2.Text = vr.dgv_footer_prodect_All_RP_dgv.CurrentRow.Cells[2].Value.ToString();//المخزن;
                RPP.xrLabel6.Text = vr.txt_footter_number_RP_num.Text;
                //RPP.xrLabel6.Text = vr.dgv_footer_prodect_All_RP_dgv.CurrentRow.Cells[1].Value.ToString();//رثم الفاتورة
                RPP.lbl_4.Text = vr.txt_footter_Date_foot_RP_num.Text;
                //RPP.lbl_4.Text = vr.dgv_footer_prodect_All_RP_dgv.CurrentRow.Cells[4].Value.ToString();//تاريخ الفاتورة

                RPP.lbl_6.Text = vr.txt_footter_supper_name_RP_num.Text;
                //RPP.lbl_6.Text = vr.dgv_footer_prodect_All_RP_dgv.CurrentRow.Cells[3].Value.ToString();//

                RPP.xrLabel8.Text = vr.txt_footter_empy_RP_num.Text;
                //RPP.xrLabel8.Text = vr.com_Emply_footer_All_RP.Text;//الموظف

                RPP.xrLabel3.Text = vr.txt_footter_total_begin_RP_num.Text;
                //RPP.xrLabel3.Text = Convert.ToDouble(ob_Total[6]).ToString("N2");//قيمة المرتجع
                RPP.xrLabel11.Text = vr.txt_footter_Dicount_rate_RP_num.Text;
                //RPP.xrLabel11.Text = Convert.ToDouble(ob_Total[2]).ToString("N2");//خصم نسبة
                RPP.xrLabel13.Text = vr.txt_footter_Dicount_value_RP_num.Text;
                //RPP.xrLabel13.Text = Convert.ToDouble(ob_Total[3]).ToString("N2");//خصم قيمه
                RPP.xrLabel9.Text = vr.txt_footter_total_return_RP_num.Text;
                //RPP.xrLabel9.Text = Convert.ToDouble(ob_Total[6]).ToString("N2");//قيمة المرتجع
                RPP.xrLabel15.Text = vr.txt_footter_total_alter_RP_num.Text;
                //RPP.xrLabel15.Text = Convert.ToDouble(Convert.ToDouble(ob_Total[5]) - Convert.ToDouble(ob_Total[6])).ToString("N2");//المجموع يعد ناقص القيمة المرتجع
                RPP.xrLabel1.Text = vr.txt_footter_type_foot_RP_num.Text;
                //RPP.xrLabel1.Text = vr.dgv_footer_prodect_All_RP_dgv.CurrentRow.Cells[6].Value.ToString();//طريقة السداد
                new classs_table.Items_Tools().show_Dev_ReportView(dt, RPP);

            }

        }

    }
}
