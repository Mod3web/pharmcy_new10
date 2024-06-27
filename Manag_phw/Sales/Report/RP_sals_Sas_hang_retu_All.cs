using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace Manag_ph.Sales.Report
{
    class RP_sals_Sas_hang_retu_All
    {
        DataRow[] dr_Cline_footer_sals;
        DataRow[] dr_Return_foot_sals;
        DataRow dr_Clon_inf;

        public void RP_Serch_And_View_Data_sals()
        {

            var vr = Application.OpenForms["Main"] as Main;
            vr.dgv_data_footer_RP_sals_All_dgv.Rows.Clear();
            string query = "(Date_Foot_sals >= '" + vr.dtp_RP_sals_All_one.Value + "' And  Date_Foot_sals <= '" + vr.dtp_RP_sals_All_tow.Value + "')";
            if (vr.ch_cahs_RP_sals_All.Checked && vr.ch_yuo_RP_sals_All.Checked && vr.ch_hanging_RP_sals_All.Checked)
            {

            }
            else if (vr.ch_cahs_RP_sals_All.Checked && vr.ch_yuo_RP_sals_All.Checked)
            {
                query += " and type_pross_sals <> " + 3;
            }
            else if (vr.ch_cahs_RP_sals_All.Checked && vr.ch_hanging_RP_sals_All.Checked)
            {
                query += "and type_pross_sals <> " + 2;
            }
            else if (vr.ch_hanging_RP_sals_All.Checked && vr.ch_yuo_RP_sals_All.Checked)
            {
                query += " and type_pross_sals <> " + 1;
            }
            else if (vr.ch_cahs_RP_sals_All.Checked)
            {
                query += " and type_pross_sals = " + 1;
            }
            else if (vr.ch_yuo_RP_sals_All.Checked)
            {
                query += "and type_pross_sals = " + 2;

            }
            else if (vr.ch_hanging_RP_sals_All.Checked)
            {
                query += "and type_pross_sals = " + 3;

            }


            if (vr.txt_name_storg_RP_sals_All.Text != string.Empty)
            {
                query += " and num_storg = " + vr.txt_num_storg_RP_sals_All.Text;
            }


            // البحث بلعميل
            if (vr.txt_name_CLine_RP_sals_All.Text != string.Empty)
            {
                dr_Cline_footer_sals = DB_Add_delete_update_.Database.ds.Tables["cline_footer"].Select("num_Cline = " + vr.txt_num_CLine_RP_sals_All.Text);
            }
            else
            {
                dr_Cline_footer_sals = DB_Add_delete_update_.Database.ds.Tables["cline_footer"].Select();
            }

            // بحث بصنف
            //if (vr.txt_name_Item_RP_sals_All.Text != string.Empty)
            //{
            //    query += "num_storg =" + vr.txt_num_Item_RP_sals_All.Text;
            //}

            if (vr.txt_num_footer_RP_sals_All.Text != string.Empty)
            {
                query += " and num_storg = " + vr.txt_num_footer_RP_sals_All.Text;
            }

            if (true)
            {

            }

            //dr_foot_Data = DB_Add_delete_update_.Database.ds.Tables["Date_Footer_Sals"].Select(query);

            if (vr.txt_name_CLine_RP_sals_All.Text != string.Empty)
            {
                for (int i = 0; i < dr_Cline_footer_sals.Count(); i++)
                {
                    DataRow dr_foot_Data = DB_Add_delete_update_.Database.ds.Tables["Date_Footer_Sals"].Rows.Find(dr_Cline_footer_sals[i][1]);
                    DataRow dr_foot_Emp = DB_Add_delete_update_.Database.ds.Tables["TB_Employees"].Rows.Find(dr_foot_Data[8]);
                    DataRow dr_Clon_inf = DB_Add_delete_update_.Database.ds.Tables["Clien"].Rows.Find(dr_Cline_footer_sals[i][2]);
                    string num_cline = "";
                    if (dr_Clon_inf != null)
                    {
                        num_cline = dr_Clon_inf[1].ToString(); ;
                    }
                    else
                    {
                        num_cline = "0";

                    }
                    string type_foot = "";
                    if (Convert.ToInt32(dr_foot_Data[7]) == 1)
                    {
                        type_foot = "كاش";
                    }
                    else if (Convert.ToInt32(dr_foot_Data[7]) == 2)
                    {
                        type_foot = "اجل";

                    }
                    else
                    {
                        type_foot = "معلقة";

                    }
                    double Total_foot_begin = 0;
                    double Total_return = 0;
                    double Total_After_Dico = 0;
                    if (Convert.ToBoolean(dr_foot_Data[16]))
                    {


                        dr_Return_foot_sals = DB_Add_delete_update_.Database.ds.Tables["Return_footer_sals"].Select("num_footer_sals =" + dr_foot_Data[0]);

                        for (int j = 0; j < dr_Return_foot_sals.Count(); j++)
                        {
                            Total_foot_begin += Convert.ToDouble(dr_Return_foot_sals[j][4]);
                            Total_return += Convert.ToDouble(dr_Return_foot_sals[j][3]);
                            Total_After_Dico += Convert.ToDouble(dr_Return_foot_sals[j][5]);
                        }
                        Total_After_Dico = Total_After_Dico - Total_return;
                        Total_return = Convert.ToDouble(Total_foot_begin - Total_return);
                    }
                    else
                    {
                        Total_foot_begin = Convert.ToDouble(dr_foot_Data[3]);
                        Total_return = Convert.ToDouble(dr_foot_Data[3]);
                        Total_After_Dico = Convert.ToDouble(dr_foot_Data[6]);
                    }
                    vr.dgv_data_footer_RP_sals_All_dgv.Rows.Add(
                        dr_foot_Data[0],
                        type_foot,
                        dr_Cline_footer_sals[i][2],
                        dr_Clon_inf[1],
                        dr_foot_Data[2],
                        dr_foot_Data[9],
                       Convert.ToDouble(dr_foot_Data[6]).ToString("N2"),// المجمموع
                       Convert.ToDouble(dr_foot_Data[13]).ToString("N2"),// المدفوع
                          Total_foot_begin.ToString("N2"), // القيمة قبل المرتجع والخصم
                          Total_return.ToString("N2"), // القيمة بعد المرتجع
                          Total_After_Dico.ToString("N2"), // القيمة بعد الخصم
                          dr_foot_Data[4],
                          dr_foot_Data[15],
                          dr_foot_Emp[1]

                        );


                }
            }
            else
            {
                DataRow[] dr_foot_Data = DB_Add_delete_update_.Database.ds.Tables["Date_Footer_Sals"].Select(query);

                double totil_begin_Return = 0;
                double totil_After_Return = 0;
                double Total_after_Discount = 0;
                double Total_sels_After_All = 0;
                double Total_sels_poid_All = 0;
                for (int i = 0; i < dr_foot_Data.Count(); i++)
                {

                    DataRow dr_foot_Emp = DB_Add_delete_update_.Database.ds.Tables["TB_Employees"].Rows.Find(dr_foot_Data[i][8]);

                    if (dr_Cline_footer_sals.Count() > i)
                    {

                        dr_Clon_inf = DB_Add_delete_update_.Database.ds.Tables["Clien"].Rows.Find(dr_Cline_footer_sals[i][2]);
                    }

                    string num_cline = "";
                    string name_Clin = "";
                    if (dr_Cline_footer_sals.Count() > i)
                    {
                        num_cline = dr_Clon_inf[0].ToString();
                        name_Clin = dr_Cline_footer_sals[i][2].ToString();
                    }
                    else
                    {
                        num_cline = "0";
                        name_Clin = dr_foot_Data[i][12].ToString();
                    }
                    string type_foot = "";
                    if (Convert.ToInt32(dr_foot_Data[i][7]) == 1)
                    {
                        type_foot = "كاش";
                    }
                    else if (Convert.ToInt32(dr_foot_Data[i][7]) == 2)
                    {
                        type_foot = "اجل";

                    }
                    else
                    {
                        type_foot = "معلقة";

                    }
                    double Total_foot_begin = 0;
                    double Total_return = 0;
                    double Total_After_Dico = 0;

                    if (Convert.ToBoolean(dr_foot_Data[i][16]))
                    {


                        dr_Return_foot_sals = DB_Add_delete_update_.Database.ds.Tables["Return_footer_sals"].Select("num_footer_sals =" + dr_foot_Data[i][0]);
                        for (int j = 0; j < dr_Return_foot_sals.Count(); j++)
                        {
                            Total_foot_begin += Convert.ToDouble(dr_Return_foot_sals[j][4]);
                            Total_return += Convert.ToDouble(dr_Return_foot_sals[j][3]);
                            Total_After_Dico += Convert.ToDouble(dr_Return_foot_sals[j][5]);
                        }
                        Total_After_Dico = Total_After_Dico - Total_return;
                        Total_return = Convert.ToDouble(Total_foot_begin - Total_return);
                    }
                    else
                    {
                        Total_foot_begin = Convert.ToDouble(dr_foot_Data[i][3]);
                        Total_return = Convert.ToDouble(dr_foot_Data[i][3]);
                        Total_After_Dico = Convert.ToDouble(dr_foot_Data[i][6]);
                    }

                    vr.dgv_data_footer_RP_sals_All_dgv.Rows.Add(
                        dr_foot_Data[i][0],
                        type_foot,
                        num_cline,
                       name_Clin,
                        dr_foot_Data[i][2],
                        dr_foot_Data[i][9],
                       Convert.ToDouble(dr_foot_Data[i][6]).ToString("N2"),// المجمموع
                       Convert.ToDouble(dr_foot_Data[i][13]).ToString("N2"),// المدفوع
                          Total_foot_begin.ToString("N2"), // القيمة قبل المرتجع والخصم
                          Total_return.ToString("N2"), // القيمة بعد المرتجع
                          Total_After_Dico.ToString("N2"), // القيمة بعد الخصم
                          dr_foot_Data[i][4],
                          dr_foot_Data[i][15],
                          dr_foot_Emp[1]);
                    totil_begin_Return += Total_foot_begin;
                    totil_After_Return += Total_return;
                    Total_after_Discount += Total_After_Dico;
                    Total_sels_After_All += Convert.ToDouble(dr_foot_Data[i][6]);
                    Total_sels_poid_All += Convert.ToDouble(dr_foot_Data[i][13]);

                    if (Convert.ToBoolean(dr_foot_Data[i][16]))
                    {
                        vr.dgv_data_footer_RP_sals_All_dgv.Rows[i].DefaultCellStyle.BackColor = Color.LightSteelBlue;
                    }

                }
                vr.txt_totil_sales_poid.Text = Total_sels_poid_All.ToString("N2");
                vr.txt_totil_sales_after_All.Text = Total_sels_After_All.ToString("N2");
                vr.txt_totil_after_Dicount.Text = Total_after_Discount.ToString("N2");
                vr.txt_totil_Discount_value.Text = (totil_After_Return - Total_after_Discount).ToString("N2");
                vr.txt_totil_after_return.Text = totil_After_Return.ToString("N2");
                vr.txt_totil_Return.Text = (totil_begin_Return - totil_After_Return).ToString("N2");
                vr.txt_count_footer_RP_All.Text = vr.dgv_data_footer_RP_sals_All_dgv.RowCount.ToString();
                vr.txt_totil_begin_return.Text = totil_begin_Return.ToString("N2");
            }


        }
        public void Dgv_data_footer_RP_sals_All_SelectionChanged_()
        {
            var vr = Application.OpenForms["Main"] as Main;
            vr.dgv_Item_footer_RP_sals_All_dgv.Rows.Clear();
            if (vr.dgv_data_footer_RP_sals_All_dgv.CurrentRow != null)
            {
                DataRow[] dr_Item_sals = DB_Add_delete_update_.Database.ds.Tables["Item_footer_Sals"].Select("num_foot_Sals =" + vr.dgv_data_footer_RP_sals_All_dgv.CurrentRow.Cells[0].Value);
                if (dr_Item_sals.Count() != 0)
                {
                    for (int i = 0; i < dr_Item_sals.Count(); i++)
                    {
                        DataRow Item = DB_Add_delete_update_.Database.ds.Tables["Item"].Rows.Find((int)dr_Item_sals[i][1]);
                        DataRow Item_storg = DB_Add_delete_update_.Database.ds.Tables["Item_storg"].Rows.Find((int)dr_Item_sals[i][3]);
                        DataRow[] dr_unit_pro = DB_Add_delete_update_.Database.ds.Tables["unite_items"].Select("Item_no = " + Item[0]);// جلب بيانات الوحداد
                        DataRow dr_unit_pro_type;
                        if (Convert.ToInt32(dr_Item_sals[i][5]) == 1)
                        {

                            dr_unit_pro_type = DB_Add_delete_update_.Database.ds.Tables["therpeutic_unite"].Rows.Find(Convert.ToInt32(dr_unit_pro[0][1]));
                        }
                        else if (Convert.ToInt32(dr_Item_sals[i][5]) == 2)
                        {
                            dr_unit_pro_type = DB_Add_delete_update_.Database.ds.Tables["therpeutic_unite"].Rows.Find(Convert.ToInt32(dr_unit_pro[0][2]));

                        }
                        else
                        {
                            dr_unit_pro_type = DB_Add_delete_update_.Database.ds.Tables["therpeutic_unite"].Rows.Find(Convert.ToInt32(dr_unit_pro[0][3]));

                        }
                        string unit_name_return = "";
                        int qty_Item_return = 0;
                        double sum_sals_Item_return = 0;
                        if (Convert.ToBoolean(dr_Item_sals[i][4]))
                        {

                            DataRow[] dr_Item_return = DB_Add_delete_update_.Database.ds.Tables["Return_Item_sals"].Select("num_Item_sals =" + dr_Item_sals[i][0]);
                            if (dr_Item_return.Count() != 0)
                            {
                                unit_name_return = dr_Item_return[0][2].ToString();
                                qty_Item_return = Convert.ToInt32(dr_Item_return[0][3]);
                                sum_sals_Item_return = Convert.ToDouble(dr_Item_return[0][4]);
                            }
                        }

                        vr.dgv_Item_footer_RP_sals_All_dgv.Rows.Add(
                            dr_Item_sals[i][1],// رقم الصنف
                            Item[1],// اسم الصنف
                            Item_storg[1],// الرصيد المتبقيي من الصنف
                            Item_storg[2],// الرصيد المتبقيي من الصنف
                            dr_unit_pro_type[1],// وحدة البيع
                            dr_Item_sals[i][4], // كمية البيع
                            unit_name_return,// اسم الوحدة المرتجعة
                            qty_Item_return,// كمية المرتجع
                            Convert.ToDouble(dr_Item_sals[i][6]).ToString("N2"),
                            Convert.ToDouble(Convert.ToDouble(dr_Item_sals[i][6]) * Convert.ToDouble(dr_Item_sals[i][4])).ToString("N2"),// مجموع سعر البيع بدون الخصم والمرتجع
                            sum_sals_Item_return.ToString("N2"),// احمالي المرتجع
                            Convert.ToInt32(dr_Item_sals[i][7]),// نسبة الخصم
                            Convert.ToDouble(dr_Item_sals[i][8]).ToString("N2"), // قيمة الخصم
                            Convert.ToDouble(Convert.ToDouble(dr_Item_sals[i][10]) - sum_sals_Item_return).ToString("N2")// مجموع سعر البيع بعد الخصم والمرتجع

                            );

                    }

                }
            }
        }

        public void Fill_RP()
        {
            var vr = Application.OpenForms["Main"] as Main;
            if (vr.dgv_data_footer_RP_sals_All_dgv.Rows.Count != 0)
            {

                File_RP_footer_sales_All rp = new File_RP_footer_sales_All();

                DataTable dt = new classs_table.Items_Tools().Fill_DataTable_Columns("dt_RP_footer_one_All", new string[] {
                "Item_no",
                "Item_name",
                "Date_Expre",
                "unit_sales",
                "qty_sales",
                "pric_sales",
                "unit_return",
                "qty_return",
                "value_dicount",
                "foot_num",
                "foot_type",
                "Date_foot",
                "Cline_name",
                "totil_begin_All",
                "totil_after_return",
                "totil_paind",
            });
                for (int i = 0; i < vr.dgv_Item_footer_RP_sals_All_dgv.RowCount; i++)
                {

                    dt.Rows.Add(
                        vr.dgv_Item_footer_RP_sals_All_dgv.Rows[i].Cells[0].Value,
                        vr.dgv_Item_footer_RP_sals_All_dgv.Rows[i].Cells[1].Value,
                     Convert.ToDateTime(vr.dgv_Item_footer_RP_sals_All_dgv.Rows[i].Cells[3].Value).ToString("d"),
                        vr.dgv_Item_footer_RP_sals_All_dgv.Rows[i].Cells[4].Value,
                        vr.dgv_Item_footer_RP_sals_All_dgv.Rows[i].Cells[5].Value,
                        vr.dgv_Item_footer_RP_sals_All_dgv.Rows[i].Cells[8].Value,
                        vr.dgv_Item_footer_RP_sals_All_dgv.Rows[i].Cells[6].Value,
                        vr.dgv_Item_footer_RP_sals_All_dgv.Rows[i].Cells[7].Value,
                        vr.dgv_Item_footer_RP_sals_All_dgv.Rows[i].Cells[12].Value);
                }
                rp.txt_code_footer.Text = vr.dgv_data_footer_RP_sals_All_dgv.CurrentRow.Cells[0].Value.ToString();
                rp.txt_type_footer.Text = vr.dgv_data_footer_RP_sals_All_dgv.CurrentRow.Cells[1].Value.ToString();
                rp.txt_name_Cline.Text = vr.dgv_data_footer_RP_sals_All_dgv.CurrentRow.Cells[3].Value.ToString();
                rp.txt_Date_foot.Text = vr.dgv_data_footer_RP_sals_All_dgv.CurrentRow.Cells[4].Value.ToString();
                rp.txt_count_Item.Text = vr.dgv_data_footer_RP_sals_All_dgv.CurrentRow.Cells[5].Value.ToString();
                rp.txt_totil_begin_All.Text = vr.dgv_data_footer_RP_sals_All_dgv.CurrentRow.Cells[6].Value.ToString();
                rp.txt_totil_begin_return.Text = vr.dgv_data_footer_RP_sals_All_dgv.CurrentRow.Cells[8].Value.ToString();
                rp.txt_totil_after_return.Text = vr.dgv_data_footer_RP_sals_All_dgv.CurrentRow.Cells[9].Value.ToString();
                rp.txt_value_discount.Text = Convert.ToDouble(Convert.ToDouble(vr.dgv_data_footer_RP_sals_All_dgv.CurrentRow.Cells[9].Value) - Convert.ToDouble(vr.dgv_data_footer_RP_sals_All_dgv.CurrentRow.Cells[10].Value)).ToString("N2");
                rp.txt_totil_after_value_discount.Text = vr.dgv_data_footer_RP_sals_All_dgv.CurrentRow.Cells[10].Value.ToString();
                rp.txt_totil_paind.Text = vr.dgv_data_footer_RP_sals_All_dgv.CurrentRow.Cells[7].Value.ToString();
                if (Convert.ToDecimal(vr.dgv_data_footer_RP_sals_All_dgv.CurrentRow.Cells[7].Value) > 0)
                {
                    double temp = Convert.ToDouble(vr.dgv_data_footer_RP_sals_All_dgv.CurrentRow.Cells[7].Value);
                    rp.txt_totil_paind_text.Text = MOJ.General.ConvertToLetters(Convert.ToDecimal(temp.ToString("N0")), "ريال", "ريال");
                }
                else
                {
                    double temp = Math.Abs(Convert.ToDouble(vr.dgv_data_footer_RP_sals_All_dgv.CurrentRow.Cells[7].Value));
                    rp.txt_totil_paind_text.Text = MOJ.General.ConvertToLetters(Convert.ToDecimal(temp.ToString("N0")), "ريال", "ريال");

                }
                new classs_table.Items_Tools().show_Dev_ReportView(dt, rp);
            }
        }

        public void Print_Footer_RP_All()
        {
            var vr = Application.OpenForms["Main"] as Main;
            if (vr.dgv_data_footer_RP_sals_All_dgv.Rows.Count != 0)
            {
                File_RP_footer_sales_Print_All rp = new File_RP_footer_sales_Print_All();
                //XtraReport1 rp = new XtraReport1();

                DataTable dt = new classs_table.Items_Tools().Fill_DataTable_Columns("dt_RP_footer_one_All", new string[] {
                "Item_no",
                "Item_name",
                "Date_Expre",
                "unit_sales",
                "qty_sales",
                "pric_sales",
                "unit_return",
                "qty_return",
                "value_dicount",
                "foot_num",
                "foot_type",
                "Date_foot",
                "Cline_name",
                "totil_begin_All",
                "totil_after_return",
                "totil_paind",
            });
                for (int j = 0; j < vr.dgv_data_footer_RP_sals_All_dgv.Rows.Count; j++)
                {
                    DataRow[] dr_Item_sals = DB_Add_delete_update_.Database.ds.Tables["Item_footer_Sals"].Select("num_foot_Sals =" + vr.dgv_data_footer_RP_sals_All_dgv.Rows[j].Cells[0].Value);
                    if (dr_Item_sals.Count() != 0)
                    {
                        for (int i = 0; i < dr_Item_sals.Count(); i++)
                        {
                            DataRow Item = DB_Add_delete_update_.Database.ds.Tables["Item"].Rows.Find((int)dr_Item_sals[i][1]);
                            DataRow Item_storg = DB_Add_delete_update_.Database.ds.Tables["Item_storg"].Rows.Find((int)dr_Item_sals[i][3]);
                            DataRow[] dr_unit_pro = DB_Add_delete_update_.Database.ds.Tables["unite_items"].Select("Item_no = " + Item[0]);// جلب بيانات الوحداد
                            DataRow dr_unit_pro_type;
                            if (Convert.ToInt32(dr_Item_sals[i][5]) == 1)
                            {

                                dr_unit_pro_type = DB_Add_delete_update_.Database.ds.Tables["therpeutic_unite"].Rows.Find(Convert.ToInt32(dr_unit_pro[0][1]));
                            }
                            else if (Convert.ToInt32(dr_Item_sals[i][5]) == 2)
                            {
                                dr_unit_pro_type = DB_Add_delete_update_.Database.ds.Tables["therpeutic_unite"].Rows.Find(Convert.ToInt32(dr_unit_pro[0][2]));

                            }
                            else
                            {
                                dr_unit_pro_type = DB_Add_delete_update_.Database.ds.Tables["therpeutic_unite"].Rows.Find(Convert.ToInt32(dr_unit_pro[0][3]));

                            }
                            string unit_name_return = "";
                            int qty_Item_return = 0;
                            double sum_sals_Item_return = 0;
                            if (Convert.ToBoolean(dr_Item_sals[i][4]))
                            {

                                DataRow[] dr_Item_return = DB_Add_delete_update_.Database.ds.Tables["Return_Item_sals"].Select("num_Item_sals =" + dr_Item_sals[i][0]);
                                if (dr_Item_return.Count() != 0)
                                {
                                    unit_name_return = dr_Item_return[0][2].ToString();
                                    qty_Item_return = Convert.ToInt32(dr_Item_return[0][3]);
                                    sum_sals_Item_return = Convert.ToDouble(dr_Item_return[0][4]);
                                }
                            }
                            dt.Rows.Add(
                                         dr_Item_sals[i][1],// رقم الصنف
                                        Item[1],// اسم الصنف
                                        Convert.ToDateTime(  Item_storg[2]).ToString("d"),// التاريخ
                                         dr_unit_pro_type[1],
                                         dr_Item_sals[i][4],
                                         Convert.ToDouble(dr_Item_sals[i][6]).ToString("N2"),// سعر البيع
                                         unit_name_return,// وحدة المرتجع
                                          qty_Item_return,// كمية المرتجع
                                           Convert.ToDouble(dr_Item_sals[i][8]).ToString("N2"),// قيمة الخصم
                                           vr.dgv_data_footer_RP_sals_All_dgv.Rows[j].Cells[0].Value,// رقم الفاتورة
                                           vr.dgv_data_footer_RP_sals_All_dgv.Rows[j].Cells[1].Value,//نوع الفاتورة
                                         Convert.ToDateTime(vr.dgv_data_footer_RP_sals_All_dgv.Rows[j].Cells[4].Value).ToString("d"),// تاريخ الفاتورة
                                           vr.dgv_data_footer_RP_sals_All_dgv.Rows[j].Cells[3].Value,//اسم العميل
                                           vr.dgv_data_footer_RP_sals_All_dgv.Rows[j].Cells[6].Value,//الاجمالي
                                           vr.dgv_data_footer_RP_sals_All_dgv.Rows[j].Cells[9].Value,//الاجمالي بعد المرتجع
                                           vr.dgv_data_footer_RP_sals_All_dgv.Rows[j].Cells[7].Value// المدفوع
                                          );
                        }
                    }
                }
                rp.txt_count_Item.Text = vr.txt_count_footer_RP_All.Text;
                rp.txt_totil_begin_All.Text = vr.txt_totil_begin_return.Text;
                rp.txt_totil_begin_return.Text = vr.txt_totil_Return.Text;
                rp.txt_totil_after_return.Text = vr.txt_totil_after_return.Text;
                rp.txt_value_discount.Text = vr.txt_totil_Discount_value.Text;
                rp.txt_totil_after_value_discount.Text = vr.txt_totil_after_Dicount.Text;
                rp.txt_totil_paind.Text = vr.txt_totil_sales_after_All.Text;
                rp.txt_Sales_dorg.Text = vr.txt_totil_sales_poid.Text;
                double temp = Convert.ToDouble(vr.txt_totil_sales_poid.Text);
                rp.txt_totil_paind_text.Text = MOJ.General.ConvertToLetters(Convert.ToDecimal(temp.ToString("N0")), "ريال", "ريال");
                new classs_table.Items_Tools().show_Dev_ReportView(dt, rp);

            }
        }
    }
}
