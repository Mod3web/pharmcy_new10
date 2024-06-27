using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Manag_ph.Sales.Report
{
    class RP_Sales_Ditiles_Emp
    {

        public void Get_Storg_RP_Sales_Emp_All()
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
            vr.com_Storg_Ditils_Empoly.DataSource = dt;

            vr.com_Storg_Ditils_Empoly.DisplayMember = "Storg_Name";
            vr.com_Storg_Ditils_Empoly.ValueMember = "Storg_id";
        }


        public void Get_All_Employ()
        {
            var vr = Application.OpenForms["Main"] as Main;
            DataTable dt = new DataTable("TB_Employees");
            dt.Columns.Add("Employees_id", typeof(int));
            dt.Columns.Add("Employees_name", typeof(string));
            dt.Rows.Add(0, "الكل");
            for (int i = 0; i < DB_Add_delete_update_.Database.ds.Tables["TB_Employees"].Rows.Count; i++)
            {
                object[] dr_Storg = DB_Add_delete_update_.Database.ds.Tables["TB_Employees"].Rows[i].ItemArray;
                dt.Rows.Add(Convert.ToInt32(dr_Storg[0]), dr_Storg[1].ToString());
            }
            vr.com_Emoly_Sales_Emoly.DataSource = dt;

            vr.com_Emoly_Sales_Emoly.DisplayMember = "Employees_name";
            vr.com_Emoly_Sales_Emoly.ValueMember = "Employees_id";
        }

        public void Search_Ditiles_Sales_Emp()
        {
            var vr = Application.OpenForms["Main"] as Main;
            vr.dgv_Sales_Ditils_Emoloy_dgv.Rows.Clear();
            string query = "(Date_Foot_sals >='" + vr.dtp_Sales_Employ_One.Value + "' And Date_Foot_sals <='" + vr.dtp_Sales_Employ_Tow.Value + "')";
            if ( Convert.ToInt32( vr.com_Storg_Ditils_Empoly.SelectedValue) != 0)
            {
                query += " And num_storg ="+ Convert.ToInt32(vr.com_Storg_Ditils_Empoly.SelectedValue);
            }
            if (Convert.ToInt32(vr.com_Emoly_Sales_Emoly.SelectedValue) != 0)
            {
                query += " And num_emp ="+ Convert.ToInt32(vr.com_Emoly_Sales_Emoly.SelectedValue);
            }
            //DataRow[] dr_Data_footer = DB_Add_delete_update_.Database.ds.Tables["Date_Footer_Sals"].Select(query);
            var groupedByUserId = DB_Add_delete_update_.Database.ds.Tables["Date_Footer_Sals"].Select(query).AsEnumerable().GroupBy(row => row.Field<DateTime>("Date_Foot_sals").Date);
            if (groupedByUserId != null)
            {
                foreach (var group in groupedByUserId)
                {
                    int count_Footer = 0;
                    int Count_Item = 0;
                    double sum_Price_Sales_Footer_begin = 0;
                    double dicount_value = 0;
                    string num_emp = "";
                    foreach (DataRow row in group)
                    {
                        count_Footer++;
                        Count_Item += Convert.ToInt32(row[9]);
                        sum_Price_Sales_Footer_begin += Convert.ToDouble(row[3]);
                        dicount_value += Convert.ToDouble(row[5]);
                        num_emp = row[8].ToString();
                    }
                   object[] dr_emp = DB_Add_delete_update_.Database.ds.Tables["TB_Employees"].Rows.Find(num_emp).ItemArray;
                    vr.dgv_Sales_Ditils_Emoloy_dgv.Rows.Add(
                        group.Key.Date,
                        count_Footer,
                        Count_Item,
                        sum_Price_Sales_Footer_begin.ToString("N2"),
                        dicount_value.ToString("N2"),
                      Convert.ToDouble(sum_Price_Sales_Footer_begin - dicount_value).ToString("N2"),
                      dr_emp[1]
                        ) ;
                }
            }


        }

      

        public void View_Report_Sales_Emp()
        {
            var vr = Application.OpenForms["Main"] as Main;
            File_RP_Sales_Emp RP = new File_RP_Sales_Emp();
            DataTable dt = new classs_table.Items_Tools().Fill_DataTable_Columns("dt_RP_Sales_Emp",new string[] {
                "Date_foot",
                "Count_Footers",
                "Count_Items",
                "value_Footer_begin",
                "Value_Dicounts",
                "Value_Footer_After",
                "Emp_Name",
            });

            for (int i = 0; i < vr.dgv_Sales_Ditils_Emoloy_dgv.Rows.Count; i++)
            {
                dt.Rows.Add(
                    vr.dgv_Sales_Ditils_Emoloy_dgv.Rows[i].Cells[0].Value,
                    vr.dgv_Sales_Ditils_Emoloy_dgv.Rows[i].Cells[1].Value,
                    vr.dgv_Sales_Ditils_Emoloy_dgv.Rows[i].Cells[2].Value,
                    vr.dgv_Sales_Ditils_Emoloy_dgv.Rows[i].Cells[3].Value,
                    vr.dgv_Sales_Ditils_Emoloy_dgv.Rows[i].Cells[4].Value,
                    vr.dgv_Sales_Ditils_Emoloy_dgv.Rows[i].Cells[5].Value,
                    vr.dgv_Sales_Ditils_Emoloy_dgv.Rows[i].Cells[6].Value);
            }
            RP.dtp_One.Text = vr.dtp_Sales_Employ_One.Value.Date.ToString();
            RP.dtp_Tow.Text = vr.dtp_Sales_Employ_Tow.Value.Date.ToString();
            RP.txt_Storg.Text = vr.com_Storg_Ditils_Empoly.Text;

            new classs_table.Items_Tools().show_Dev_ReportView(dt,RP);

        }

    }
}
