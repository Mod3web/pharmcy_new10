using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Manag_ph.Sales.Report
{
    class RP_sals_Item_date
    {
        public void Get_Storg_RP_Sales_Item_All()
        {
            var vr = Application.OpenForms["Main"] as Main;
            DataTable dt = new DataTable("Storg");
            dt.Columns.Add("Storg_id", typeof(int));
            dt.Columns.Add("Storg_Name", typeof(string));
            dt.Rows.Add(0, "الكل");
            for (int i = 0; i < DB_Add_delete_update_.Database.ds.Tables["Storg"].Rows.Count; i++)
            {
                object[] dr_Storg = DB_Add_delete_update_.Database.ds.Tables["Storg"].Rows[i].ItemArray;
                dt.Rows.Add(Convert.ToInt32(dr_Storg[0]), dr_Storg[1].ToString());
            }
            vr.Com_Storg_RP_sales_Item.DataSource = dt;

            vr.Com_Storg_RP_sales_Item.ValueMember = "Storg_Name";
            vr.Com_Storg_RP_sales_Item.ValueMember = "Storg_id";
        }

        public void Search_Item_Sales_All()
        {
            var vr = Application.OpenForms["Main"] as Main;
            vr.dgv_RP_Sales_Item_All_dgv.Rows.Clear();

            string query = "(Date_Foot_sals >= '" + vr.dtp_RP_Sales_Item_All_One.Value + "' And  Date_Foot_sals <= '" + vr.dtp_RP_Sales_Item_All_Tow.Value + "')";


            if (Convert.ToInt32(vr.Com_Storg_RP_sales_Item.SelectedValue) != 0)
            {
                query += " And num_storg =" + Convert.ToInt32(vr.Com_Storg_RP_sales_Item.SelectedValue);
            }


            DataRow[] dr = DB_Add_delete_update_.Database.ds.Tables["Date_Footer_Sals"].Select(query);
            if (dr != null)
            {
                for (int i = 0; i < dr.Count(); i++)
                {
                    string query_Item = "num_foot_Sals =" + dr[i][0];
                    if (vr.txt_Name_Item_RP_Sales_Item.Text.Trim() != string.Empty && vr.txt_Item_RP_Sales_Item.Text.Trim() != string.Empty)
                    {
                        query_Item += " And num_Item =" + vr.txt_Item_RP_Sales_Item.Text;
                    }
                    DataRow[] dr_Item = DB_Add_delete_update_.Database.ds.Tables["Item_footer_Sals"].Select(query_Item);
                    if (dr_Item != null)
                    {
                        for (int j = 0; j < dr_Item.Count(); j++)
                        {



                            object[] ob_Item = DB_Add_delete_update_.Database.ds.Tables["Item"].Rows.Find(dr_Item[j][1]).ItemArray;// جلب اسم الصنف
                            object[] ob_Compny = DB_Add_delete_update_.Database.ds.Tables["manufctur_company"].Rows.Find(ob_Item[10]).ItemArray;// جلب اسم الشركة
                            DataRow[] dr_unitsAll = DB_Add_delete_update_.Database.ds.Tables["unite_items"].Select("item_no = " + dr_Item[j][1]);// جلب االوحدة المباعة
                            DataRow dr_unit_pro_type;

                            object[] Item_Storg = DB_Add_delete_update_.Database.ds.Tables["Item_storg"].Rows.Find(dr_Item[j][3]).ItemArray;// جلب الرصيد الباقي 

                            if (Convert.ToInt32(dr_Item[j][5]) == 1)
                            {

                                dr_unit_pro_type = DB_Add_delete_update_.Database.ds.Tables["therpeutic_unite"].Rows.Find(Convert.ToInt32(dr_unitsAll[0][1]));
                            }
                            else if (Convert.ToInt32(dr_Item[j][5]) == 2)
                            {
                                dr_unit_pro_type = DB_Add_delete_update_.Database.ds.Tables["therpeutic_unite"].Rows.Find(Convert.ToInt32(dr_unitsAll[0][2]));

                            }
                            else
                            {
                                dr_unit_pro_type = DB_Add_delete_update_.Database.ds.Tables["therpeutic_unite"].Rows.Find(Convert.ToInt32(dr_unitsAll[0][3]));

                            }


                            // للبحث عن الشكرة المصنعة
                            if (vr.txt_id_Compny_RP_Sales_Item.Text.Trim() != string.Empty && vr.txt_id_Compny_RP_Sales_Item.Text.Trim() != string.Empty)
                            {
                                if (vr.txt_Name_Compny_RP_Sales_Item.Text.Trim() == ob_Compny[1].ToString())
                                {
                                    vr.dgv_RP_Sales_Item_All_dgv.Rows.Add(
                                            dr_Item[j][1],//رقم الصنف
                                            ob_Item[1],// اسم الصنف
                                            ob_Compny[1],// اسم الشركة
                                            dr_Item[j][4],// كمية البيع
                                            dr_unit_pro_type[1],// الوحدة المباعة
                                            Item_Storg[1],// الرصيد المتبق
                                          Convert.ToDateTime(Item_Storg[2]).ToString("d"),// تاريخ الصلاحية
                                            dr_Item[j][9],//  سعر البيع
                                            dr_Item[j][10]
                                            );// اجمالي البيع
                                }
                            }
                            else
                            {
                                vr.dgv_RP_Sales_Item_All_dgv.Rows.Add(
                                        dr_Item[j][1],//رقم الصنف
                                        ob_Item[1],// اسم الصنف
                                        ob_Compny[1],// اسم الشركة
                                        dr_Item[j][4],// كمية البيع
                                        dr_unit_pro_type[1],// الوحدة المباعة
                                        Item_Storg[1],// الرصيد المتبق
                                        Item_Storg[2],// تاريخ الصلاحية
                                      Convert.ToDouble(dr_Item[j][9]).ToString("N2"),//  سعر البيع
                                      Convert.ToDouble(dr_Item[j][10]).ToString("N2")
                                        );// اجمالي البيع
                            }
                        }

                    }

                }
            }

        }

        public void View_Report_Sales_Itam_All()
        {
            var vr = Application.OpenForms["Main"] as Main;
            if (vr.dgv_RP_Sales_Item_All_dgv.Rows.Count != 0)
            {
                File_RP_footer_sales_Item rp = new File_RP_footer_sales_Item();

                DataTable dt = new classs_table.Items_Tools().Fill_DataTable_Columns("dt_RP_foot_Saler_Item_All", new string[] {
                    "Item_no",
                    "Item_name_en",
                    "compny_name",
                    "qty_sales",
                    "unit_sales",
                    "qty_new",
                    "Extra_Date",
                    "Sales_price",
                    "sum_sell_pric",
                });

                double sum_Total = 0;
                for (int i = 0; i < vr.dgv_RP_Sales_Item_All_dgv.Rows.Count; i++)
                {
                    sum_Total += Convert.ToDouble(vr.dgv_RP_Sales_Item_All_dgv.Rows[i].Cells[8].Value);
                    dt.Rows.Add(
                        vr.dgv_RP_Sales_Item_All_dgv.Rows[i].Cells[0].Value,
                        vr.dgv_RP_Sales_Item_All_dgv.Rows[i].Cells[1].Value,
                        vr.dgv_RP_Sales_Item_All_dgv.Rows[i].Cells[2].Value,
                        vr.dgv_RP_Sales_Item_All_dgv.Rows[i].Cells[3].Value,
                        vr.dgv_RP_Sales_Item_All_dgv.Rows[i].Cells[4].Value,
                        vr.dgv_RP_Sales_Item_All_dgv.Rows[i].Cells[5].Value,
                        vr.dgv_RP_Sales_Item_All_dgv.Rows[i].Cells[6].Value,
                        vr.dgv_RP_Sales_Item_All_dgv.Rows[i].Cells[7].Value,
                        vr.dgv_RP_Sales_Item_All_dgv.Rows[i].Cells[8].Value
                        ) ;
                }
                rp.lbl_DateTime_searchOne.Text = vr.dtp_RP_Sales_Item_All_One.Value.ToString();
                rp.lbl_DateTime_searchTow.Text = vr.dtp_RP_Sales_Item_All_Tow.Value.ToString();
                rp.txt_count_Item.Text = vr.dgv_RP_Sales_Item_All_dgv.Rows.Count.ToString();
                rp.txt_totil_begin_All.Text = sum_Total.ToString("N2");
                new classs_table.Items_Tools().show_Dev_ReportView(dt,rp);

            }

        }
    }
}
