using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Manag_ph.Daily_accounts.CR_Daily_accounts
{
    class RP_cash_exchange
    {

        //داله لتعبه كبوبكس بالصناديق
        public void Get_account_fund_All()
        {
            var vr = Application.OpenForms["Main"] as Main;
            DataTable dt = new DataTable("account_fund");
            dt.Columns.Add("account_fund_id", typeof(int));
            dt.Columns.Add("account_fund_Name", typeof(string));
            DataRow[] dr_fund = DB_Add_delete_update_.Database.ds.Tables["account_fund"].Select();
            DataRow[] dr_Casher = DB_Add_delete_update_.Database.ds.Tables["casher"].Select();

            dt.Rows.Add(0, "الكل");

            for (int i = 0; i < dr_fund.Count(); i++)
            {
                if (Convert.ToBoolean(dr_fund[i][3]) == false)
                {
                    dt.Rows.Add(dr_fund[i][0], dr_fund[i][1]);
                }
            }

            for (int i = 0; i < dr_Casher.Count(); i++)
            {
                if (Convert.ToBoolean(dr_Casher[i][2]) == false)
                {
                    dt.Rows.Add(dr_Casher[i][0], dr_Casher[i][1]);
                }
            }
            //for (int i = 0; i < DB_Add_delete_update_.Database.ds.Tables["account_fund"].Rows.Count; i++)
            //{
            //    object[] dr_Storg = DB_Add_delete_update_.Database.ds.Tables["account_fund"].Rows[i].ItemArray;
            //    dt.Rows.Add(Convert.ToInt32(dr_Storg[0]), dr_Storg[1].ToString());
            //}
            //for (int j = 0; j < DB_Add_delete_update_.Database.ds.Tables["casher"].Rows.Count; j++)
            //{
            //    object[] dr_Storg = DB_Add_delete_update_.Database.ds.Tables["casher"].Rows[j].ItemArray;
            //    dt.Rows.Add(Convert.ToInt32(dr_Storg[0]), dr_Storg[1].ToString());
            //}

            vr.com_Payment_side_RP_cash_exchange.DataSource = dt;

            vr.com_Payment_side_RP_cash_exchange.DisplayMember = "account_fund_Name";
            vr.com_Payment_side_RP_cash_exchange.ValueMember = "account_fund_id";
        }



        //داله لتعبه كبوبكس بالمستفيدين
        public void Get_beneficiary_RP_cash_exchange()
        {
            var vr = Application.OpenForms["Main"] as Main;
            DataTable dt = new DataTable("beneficiary");
            dt.Columns.Add("benef_id", typeof(int));
            dt.Columns.Add("benef_Name", typeof(string));
            dt.Rows.Add(0, "الكل");
            dt.Rows.Add(1, "المورد");
            dt.Rows.Add(2, "العميل");
            dt.Rows.Add(3, "الموظف");
            dt.Rows.Add(4, "مصاريف تشغيل");

            vr.com_beneficiary_RT_cash_exchange.DataSource = dt;

            vr.com_beneficiary_RT_cash_exchange.DisplayMember = "benef_Name";
            vr.com_beneficiary_RT_cash_exchange.ValueMember = "benef_id";
        }

        public void serch_RT_cash_exchange()
        {

            var vr = Application.OpenForms["Main"] as Main;
            vr.dgv_RP_cash_exchange_dgv.Rows.Clear();

            DataView dview_cash_Exchange = new DataView(DB_Add_delete_update_.Database.ds.Tables["cash_Exchange"]);

            ////////////////////////////////////////////////////////تتعديل
            int num_the_type_ss = 0;


            DataRow[] dr_fund2 = DB_Add_delete_update_.Database.ds.Tables["account_fund"].Select("fund_stop = " + false);
            DataRow[] dr_Casher2 = DB_Add_delete_update_.Database.ds.Tables["casher"].Select("casher_stop = " + false);


            if (vr.com_Payment_side_RP_cash_exchange.SelectedIndex > 0 && vr.com_Payment_side_RP_cash_exchange.SelectedIndex <= dr_fund2.Count())
            {
                num_the_type_ss = 1;

            }
            //else if (comBox_supply_to.SelectedIndex  >= dr_Casher2.Count() && comBox_supply_to.SelectedIndex  < dr_Casher2.Count()+dr_fund2.Count() )
            else if (vr.com_Payment_side_RP_cash_exchange.SelectedIndex > dr_fund2.Count() && vr.com_Payment_side_RP_cash_exchange.SelectedIndex <= dr_fund2.Count() + dr_Casher2.Count())
            {
                num_the_type_ss = 2;
            }
            //////////////////////////////////////////////////////

            //string str = vr.txt_serch_RP_cash_Exchange.Text;

            string query = "(Doc_creat_date >='" + vr.Dtime_one_RT_cash_exchange.Value + "' And Doc_creat_date <='" + vr.Dtime_tow_RT_cash_exchange.Value + "')";



            if (vr.txt_serch_RP_cash_Exchange.Text.Trim() != string.Empty)
            {
                dview_cash_Exchange.RowFilter = " name_beneficiry  like '%" + vr.txt_serch_RP_cash_Exchange.Text + "%'";
                query += " And num_beneficiry =" + Convert.ToInt32(dview_cash_Exchange[0][5]);


            }
            if (Convert.ToInt32(vr.com_beneficiary_RT_cash_exchange.SelectedValue) != 0)
            {
                query += " And num_Benf_Type =" + vr.com_beneficiary_RT_cash_exchange.SelectedValue;
            }
            if (Convert.ToInt32(vr.com_Payment_side_RP_cash_exchange.SelectedValue) != 0)
            {

                query += " And num_Payment_side =" + vr.com_Payment_side_RP_cash_exchange.SelectedValue + " And num_type_Payment_side =" + num_the_type_ss;
            }

            //if (vr.txt_serch_RP_cash_Exchange.Text.Trim() != string.Empty)
            //{
            //    query += " And name_beneficiry =" + vr.txt_serch_RP_cash_Exchange.Text;
            //}








            //if (vr.txt_serch_RP_cash_Exchange.Text.Trim() != string.Empty)
            //{
            //    dview_cash_Exchange.RowFilter = "name_beneficiry  like '%" + vr.txt_serch_RP_cash_Exchange.Text + "%'";
            //    //DataRow[] mm = DB_Add_delete_update_.Database.ds.Tables["cash_Exchange"].Select("name_beneficiry =" + vr.txt_serch_RP_cash_Exchange.Text);
            //    MessageBox.Show(dview_cash_Exchange[0][6].ToString());
            //}
            // DataRow[] dr_Data_footer = DB_Add_delete_update_.Database.ds.Tables["cash_Exchange"].Select(query);
            //DataTable dttt = new classs_table.Items_Tools().Fill_DataTable_Columns("dt_RP_Sales_Emp", new string[] {
            //    "Date_foot",
            //    "Count_Footers",
            //    "Count_Items",
            //    "value_Footer_begin",
            //    "Value_Dicounts",
            //    "Value_Footer_After",
            //    "Emp_Name",
            //    "Emp_Name2",
            //    "Emp_Name3",

            //});
            //   DataTable dt = new DataTable();
            var groupeDB_cash_exchange = DB_Add_delete_update_.Database.ds.Tables["cash_Exchange"].Select(query).AsEnumerable().GroupBy(row => row.Field<DateTime>("Doc_creat_date"));
            // var groupeDB_cash_exchange = DB_Add_delete_update_.Database.ds.Tables["cash_Exchange"].Select(query);
            if (groupeDB_cash_exchange != null)

            {

                foreach (var group in groupeDB_cash_exchange)
                {
                    int count_cash_exchange = 0;
                    string date_cash_exch = "";
                    string name_Benf_Type = "";
                    double Value_Expe = 0;
                    string name_beneficiry = "";
                    double Curr_balance = 0;
                    double Remain_balan = 0;
                    string name_Payment_side = "";
                    string Document_Note = "";
                    string Name_Emp = "";





                    foreach (DataRow Row in group)
                    {
                        count_cash_exchange++;
                        date_cash_exch = Row[1].ToString();
                        name_Benf_Type = Row[3].ToString();
                        Value_Expe = Convert.ToDouble(Row[4]);
                        name_beneficiry = Row[6].ToString();
                        Curr_balance = Convert.ToDouble(Row[7]);
                        Remain_balan = Convert.ToDouble(Row[8]);
                        name_Payment_side = Row[9].ToString();
                        Document_Note = Row[10].ToString();
                        Name_Emp = Row[11].ToString();

                        vr.dgv_RP_cash_exchange_dgv.Rows.Add(
                                date_cash_exch,//
                                               //group.Key.Date,
                                name_Benf_Type,
                                name_beneficiry,
                                 Value_Expe,
                                Curr_balance,
                                Remain_balan,
                                name_Payment_side,
                                Document_Note,
                                Name_Emp
                            );



                    }







                }
            }



        }

        //داله عرض التقرير وطباعتة
        public void View_Report_cash_Exchange()
        {
            var vr = Application.OpenForms["Main"] as Main;
            //File_RP_Sales_Emp RP = new File_RP_Sales_Emp();
            xr_RP_cash__exchange RP = new xr_RP_cash__exchange();
            DataTable dt = new classs_table.Items_Tools().Fill_DataTable_Columns("dt_RP_cash_exchange", new string[] {
                             "date_cash_exch",
                             "name_Benf_Type" ,
                            "name_beneficiry"  ,
                             "Value_Expe" ,
                            "Curr_balance",
                            "Remain_balan",
                            "name_Payment_side" ,
                            "Document_Note ",
                            "Name_Emp"
            });
            int totale_exchange = 0;
            for (int i = 0; i < vr.dgv_RP_cash_exchange_dgv.Rows.Count; i++)
            {
                dt.Rows.Add(
                    vr.dgv_RP_cash_exchange_dgv.Rows[i].Cells[0].Value,
                    vr.dgv_RP_cash_exchange_dgv.Rows[i].Cells[1].Value,
                    vr.dgv_RP_cash_exchange_dgv.Rows[i].Cells[2].Value,
                    vr.dgv_RP_cash_exchange_dgv.Rows[i].Cells[3].Value,
                    vr.dgv_RP_cash_exchange_dgv.Rows[i].Cells[4].Value,
                    vr.dgv_RP_cash_exchange_dgv.Rows[i].Cells[5].Value,
                    vr.dgv_RP_cash_exchange_dgv.Rows[i].Cells[6].Value,
                    vr.dgv_RP_cash_exchange_dgv.Rows[i].Cells[7].Value,
                    vr.dgv_RP_cash_exchange_dgv.Rows[i].Cells[8].Value);
                totale_exchange += Convert.ToInt32(vr.dgv_RP_cash_exchange_dgv.Rows[i].Cells[3].Value);

            }
            RP.dtp_One_RP_Cash_exchange.Text = vr.Dtime_one_RT_cash_exchange.Value.Date.ToString();
            RP.dtp_Tow_RP_Cash_exchange.Text = vr.Dtime_tow_RT_cash_exchange.Value.Date.ToString();
            RP.txt_Storg_RP_Cash_exchange.Text = vr.com_Payment_side_RP_cash_exchange.Text;
            RP.xrtxtRP_num_pross_RP_Cash_exchange.Text = vr.dgv_RP_cash_exchange_dgv.Rows.Count.ToString();
            RP.xrtxtRP_total_exchange.Text = totale_exchange.ToString();
            //RP.xrtxtRP_amount_exchange_written.Text =  (totale_exchange).ToString();

            double temp = Convert.ToDouble(totale_exchange);
            RP.xrtxtRP_amount_exchange_written.Text = MOJ.General.ConvertToLetters(Convert.ToDecimal(temp.ToString("N0")), "ريال", "ريال");



            //داله جاهزه لتعبئة التقرير للطباعة

            new classs_table.Items_Tools().show_Dev_ReportView(dt, RP);

        }


        public void serch_text_and_combox()
        {
            //تعديل
            var a = Application.OpenForms["Main"] as Main;
            if (Convert.ToInt32(a.com_beneficiary_RT_cash_exchange.SelectedIndex) == 0)
            {
                a.lbl_serch_RP_cash_Exchange.Enabled = false;
                a.txt_serch_RP_cash_Exchange.Clear();
                a.txt_serch_RP_cash_Exchange.Enabled = false;
                a.dgv_RP_cash_exchange_dgv.Rows.Clear();
            }
            else if (Convert.ToInt32(a.com_beneficiary_RT_cash_exchange.SelectedIndex) == 1)
            {
               a.lbl_serch_RP_cash_Exchange.Enabled = true;
               a.txt_serch_RP_cash_Exchange.Clear();
               
               a.txt_serch_RP_cash_Exchange.Enabled = true;
                a.dgv_RP_cash_exchange_dgv.Rows.Clear();

            }
            else if (Convert.ToInt32(a.com_beneficiary_RT_cash_exchange.SelectedIndex) == 2)
            {
                a.lbl_serch_RP_cash_Exchange.Enabled = true;
                a.txt_serch_RP_cash_Exchange.Clear();
                a.txt_serch_RP_cash_Exchange.Enabled = true;
                a.dgv_RP_cash_exchange_dgv.Rows.Clear();

            }
            else if (Convert.ToInt32(a.com_beneficiary_RT_cash_exchange.SelectedIndex) == 3)
            {
                a.lbl_serch_RP_cash_Exchange.Enabled = true;
                a.txt_serch_RP_cash_Exchange.Clear();
                a.txt_serch_RP_cash_Exchange.Enabled = true;
                a.dgv_RP_cash_exchange_dgv.Rows.Clear();

            }
            else if (Convert.ToInt32(a.com_beneficiary_RT_cash_exchange.SelectedIndex) == 4)
            {
                a.lbl_serch_RP_cash_Exchange.Enabled = false;
                a.txt_serch_RP_cash_Exchange.Clear();
                a.txt_serch_RP_cash_Exchange.Enabled = false;
                a.dgv_RP_cash_exchange_dgv.Rows.Clear();

            }


        }


    }
}
