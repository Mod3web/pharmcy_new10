using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Manag_ph.Sales.Report
{
    class RP_Sales_Footer_Return_Date
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
            vr.Com_Storg_RP_Sales_Date_Return.DataSource = dt;

            vr.Com_Storg_RP_Sales_Date_Return.DisplayMember = "Storg_Name";
            vr.Com_Storg_RP_Sales_Date_Return.ValueMember = "Storg_id";
        }

        public void Search_Data_Sales_Data_And_Item_Return()
        {
            var vr = Application.OpenForms["Main"] as Main;

            vr.dgv_Data_Return_Date_dgv.Rows.Clear();

            string query = "(Date_Return >='" + vr.dtp_Storg_RP_Sales_Date_Return_One.Value + "' And Date_Return <='" + vr.dtp_Storg_RP_Sales_Date_Return_Tow.Value + "')";
            string query_DataFooter = "isReturn =" +true;
            if (Convert.ToInt32( vr.Com_Storg_RP_Sales_Date_Return.SelectedValue)!= 0)
            {
                query_DataFooter += " And num_storg =" + Convert.ToInt32(vr.Com_Storg_RP_Sales_Date_Return.SelectedValue);
            }

            if (vr.txt_Report_Sales_Cline_name.Text.Trim() != String.Empty && vr.txt_Report_Sales_Cline_num.Text.Trim() != string.Empty)
            {
                query += " And num_Cline =" + vr.txt_Report_Sales_Cline_num.Text.Trim();
            }
            DataRow[] dr_Data_Return = DB_Add_delete_update_.Database.ds.Tables["Return_footer_sals"].Select(query);
            DataRow[] dr_Data_Footer_Sales = DB_Add_delete_update_.Database.ds.Tables["Date_Footer_Sals"].Select(query_DataFooter);

            if (dr_Data_Footer_Sales != null)
            {
                for (int i = 0; i < dr_Data_Footer_Sales.Count(); i++)
                {

                    DataRow[] dr_Item_Footer_sales = DB_Add_delete_update_.Database.ds.Tables["Item_footer_Sals"].Select("num_foot_Sals =" + dr_Data_Footer_Sales[i][0] + " And isReturn = " + true);
                    double sum_Price_Retirn_All = 0;
                    for (int j = 0; j < dr_Item_Footer_sales.Count(); j++)
                    {
                        DataRow[] dr_Item_Footer_sales_Return = DB_Add_delete_update_.Database.ds.Tables["Return_Item_sals"].Select("num_Item_sals =" + dr_Item_Footer_sales[j][0]);
                        sum_Price_Retirn_All += Convert.ToDouble(dr_Item_Footer_sales_Return[0][4]);
                    }
                    for (int j = 0; j < dr_Data_Return.Count(); j++)
                    {
                        if (dr_Data_Footer_Sales[i][0].ToString() == dr_Data_Return[j][1].ToString())
                        {
                          object[] dr_Emplay =  DB_Add_delete_update_.Database.ds.Tables["TB_Employees"].Rows.Find(dr_Data_Return[j][6]).ItemArray;
                            vr.dgv_Data_Return_Date_dgv.Rows.Add(
                                dr_Data_Footer_Sales[i][0],// رقم الفاتورة
                                dr_Data_Return[j][2] != null ? dr_Data_Return[j][2] : "",
                                 dr_Data_Footer_Sales[i][12],// اسم العميل
                                 dr_Data_Footer_Sales[i][9],//كمية الاصناف
                                dr_Item_Footer_sales.Count(),// الكمية المرتجعة
                                Convert.ToDouble( dr_Data_Footer_Sales[i][6]).ToString("N0"),// سعر البيع
                                sum_Price_Retirn_All.ToString("N2"),
                              dr_Emplay[1]);
                            j = dr_Data_Return.Count();
                        }
                    }


                }
            }



        }

        public void DataGradview_SelectChang()
        {
            var vr = Application.OpenForms["Main"] as Main;
            vr.dgv_RP_Item_foot_Return_Date_dgv.Rows.Clear();
            if (vr.dgv_Data_Return_Date_dgv.CurrentRow != null)
            {
              DataRow[] dr_Item_foot_Sales =  DB_Add_delete_update_.Database.ds.Tables["Item_footer_Sals"].Select("num_foot_Sals = " + vr.dgv_Data_Return_Date_dgv.CurrentRow.Cells[0].Value);
                if (dr_Item_foot_Sales != null)
                {
                    for (int i = 0; i < dr_Item_foot_Sales.Count(); i++)
                    {
                        object[] ob_Item = DB_Add_delete_update_.Database.ds.Tables["Item"].Rows.Find(dr_Item_foot_Sales[i][1]).ItemArray;
                        DataRow[] Return_Item_sals = DB_Add_delete_update_.Database.ds.Tables["Return_Item_sals"].Select("num_Item_sals ="+dr_Item_foot_Sales[i][0]);
                        vr.dgv_RP_Item_foot_Return_Date_dgv.Rows.Add(
                            dr_Item_foot_Sales[i][1],// رقم الصنف
                            ob_Item[1],// اسم الصنف
                            Return_Item_sals[0][2],// الوحدة
                            Return_Item_sals[0][3],// الكمية
                           Convert.ToDouble( dr_Item_foot_Sales[i][9]).ToString("N2"),//سعر البيع
                           Convert.ToDouble( Convert.ToDouble( Return_Item_sals[0][4]) / Convert.ToDouble(Return_Item_sals[0][3])).ToString("N2"),//سعر المرتجع
                            Convert.ToDouble(dr_Item_foot_Sales[i][10]).ToString("N2"),//اجمالي البيع
                            Convert.ToDouble(Return_Item_sals[0][4]));// اجمالي المرتجع
                    }
                }


            }
        }

        public void ViewReport_Item_Return()
        {
            var vr = Application.OpenForms["Main"] as Main;
            DataTable dt = new classs_table.Items_Tools().Fill_DataTable_Columns("dt_RP_Data_Footer_Return", new string[] {
                "num_footer",
                "num_Cline",
                "name_Cline",
                "qty_sales",
                "qty_return",
                "price_begin",
                "price_After",
                "num_Item",
                "name_Item",
                "name_unite",
                "qty",
                "price_Sales",
                "price_return",
                "sum_sales",
                "sum_return"
            });

            if (vr.dgv_Data_Return_Date_dgv.Rows.Count != 0 && vr.dgv_RP_Item_foot_Return_Date_dgv.Rows.Count != 0)
            {
                for (int i = 0; i < vr.dgv_Data_Return_Date_dgv.Rows.Count; i++)
                {
              DataRow[] dr_Item_foot_Sales =  DB_Add_delete_update_.Database.ds.Tables["Item_footer_Sals"].Select("num_foot_Sals = " + vr.dgv_Data_Return_Date_dgv.Rows[i].Cells[0].Value);
                    if (dr_Item_foot_Sales != null)
                    {
                        for (int j = 0; j < dr_Item_foot_Sales.Count(); j++)
                        {
                            object[] ob_Item = DB_Add_delete_update_.Database.ds.Tables["Item"].Rows.Find(dr_Item_foot_Sales[j][1]).ItemArray;
                            DataRow[] Return_Item_sals = DB_Add_delete_update_.Database.ds.Tables["Return_Item_sals"].Select("num_Item_sals =" + dr_Item_foot_Sales[j][0]);
                            dt.Rows.Add(
                                vr.dgv_Data_Return_Date_dgv.Rows[i].Cells[0].Value,
                                vr.dgv_Data_Return_Date_dgv.Rows[i].Cells[1].Value,
                                vr.dgv_Data_Return_Date_dgv.Rows[i].Cells[2].Value,
                                vr.dgv_Data_Return_Date_dgv.Rows[i].Cells[3].Value,
                                vr.dgv_Data_Return_Date_dgv.Rows[i].Cells[4].Value,
                                vr.dgv_Data_Return_Date_dgv.Rows[i].Cells[5].Value,
                                vr.dgv_Data_Return_Date_dgv.Rows[i].Cells[6].Value,
                                dr_Item_foot_Sales[j][1],// رقم الصنف
                                ob_Item[1],// اسم الصنف
                                Return_Item_sals[0][2],// الوحدة
                                Return_Item_sals[0][3],// الكمية
                               Convert.ToDouble(dr_Item_foot_Sales[j][9]).ToString("N2"),//سعر البيع
                               Convert.ToDouble(Convert.ToDouble(Return_Item_sals[0][4]) / Convert.ToDouble(Return_Item_sals[0][3])).ToString("N2"),//سعر المرتجع
                                Convert.ToDouble(dr_Item_foot_Sales[j][10]).ToString("N2"),//اجمالي البيع
                                Convert.ToDouble(Return_Item_sals[0][4]));
                        }
                    }

                }
                File_RP_footer_sales_Item_Date RP = new File_RP_footer_sales_Item_Date();
                RP.lbl_DateTime_searchOne.Text = vr.dtp_Storg_RP_Sales_Date_Return_One.Text;
                RP.lbl_DateTime_searchTow.Text = vr.dtp_Storg_RP_Sales_Date_Return_Tow.Text;
                new classs_table.Items_Tools().show_Dev_ReportView(dt,RP);
            }



        }

    }

}
