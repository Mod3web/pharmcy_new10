using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Manag_ph.Daily_accounts.CR_Daily_accounts
{
    class RP_cash__supply
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
            //dt.Rows.Add(0, "الكل");
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
            vr.cbx_RP_name_Payment_side_cash_supply.DataSource = dt;

            vr.cbx_RP_name_Payment_side_cash_supply.DisplayMember = "account_fund_Name";
            vr.cbx_RP_name_Payment_side_cash_supply.ValueMember = "account_fund_id";
        }

        //داله لتعبه كبوبكس بالمستفيدين
        public void Get_beneficiary_RP_cash_supply()
        {
            var vr = Application.OpenForms["Main"] as Main;
            DataTable dt = new DataTable("type_beneficiary");
            dt.Columns.Add("benef_id", typeof(int));
            dt.Columns.Add("benef_Name", typeof(string));
            dt.Rows.Add(0, "الكل");
            dt.Rows.Add(1, "المورد");
            dt.Rows.Add(2, "العميل");
            dt.Rows.Add(3, "الموظف");
            //dt.Rows.Add(4, "مصاريف تشغيل");

            vr.cbx_RP_name_Benf_Type_cash_supply.DataSource = dt;

            vr.cbx_RP_name_Benf_Type_cash_supply.DisplayMember = "benef_Name";
            vr.cbx_RP_name_Benf_Type_cash_supply.ValueMember = "benef_id";
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
            vr.Dgv_RP_cash_supply_dgv.Rows.Clear();

            DB_Add_delete_update_.Database.update("cash_supply");

            DataView dview_cash_supply = new DataView(DB_Add_delete_update_.Database.ds.Tables["cash_supply"]);
            ////////////////////////////////////////////////////////تتعديل
            int num_the_type_ss = 0;


            DataRow[] dr_fund2 = DB_Add_delete_update_.Database.ds.Tables["account_fund"].Select("fund_stop = " + false);
            DataRow[] dr_Casher2 = DB_Add_delete_update_.Database.ds.Tables["casher"].Select("casher_stop = " + false);


            if (vr.cbx_RP_name_Payment_side_cash_supply.SelectedIndex > 0 && vr.cbx_RP_name_Payment_side_cash_supply.SelectedIndex <= dr_fund2.Count())
            {
                num_the_type_ss = 1;

            }
            //else if (comBox_supply_to.SelectedIndex  >= dr_Casher2.Count() && comBox_supply_to.SelectedIndex  < dr_Casher2.Count()+dr_fund2.Count() )
            else if (vr.cbx_RP_name_Payment_side_cash_supply.SelectedIndex > dr_fund2.Count() && vr.cbx_RP_name_Payment_side_cash_supply.SelectedIndex <= dr_fund2.Count() + dr_Casher2.Count())
            {
                num_the_type_ss = 2;
            }
            //////////////////////////////////////////////////////

            //string str = vr.txt_serch_RP_cash_Exchange.Text;

            string query = "(Doc_creat_date >='" + vr.Dtime_one_Rp_cash_supply.Value + "' And Doc_creat_date <='" + vr.Dtime_two_Rp_cash_supply.Value + "')";



            if (vr.txt_serch_RP_name_beneficiry_cash_supply.Text.Trim() != string.Empty)
            {
                dview_cash_supply.RowFilter = "name_beneficiry  like '%" + vr.txt_serch_RP_name_beneficiry_cash_supply.Text + "%'";
                query += " And num_beneficiry =" + Convert.ToInt32(dview_cash_supply[0][5]);


            }
            if (Convert.ToInt32(vr.cbx_RP_name_Benf_Type_cash_supply.SelectedValue) != 0)
            {
                query += " And num_Benf_Type =" + vr.cbx_RP_name_Benf_Type_cash_supply.SelectedValue;
            }
            if (Convert.ToInt32(vr.cbx_RP_name_Payment_side_cash_supply.SelectedValue) != 0)
            {
                query += " And num_Payment_side =" + vr.cbx_RP_name_Payment_side_cash_supply.SelectedValue + " And num_type_Payment_side =" + num_the_type_ss;
            }

            var groupeDB_cash_supply = DB_Add_delete_update_.Database.ds.Tables["cash_supply"].Select(query).AsEnumerable().GroupBy(row => row.Field<DateTime>("Doc_creat_date"));
            if (groupeDB_cash_supply != null)

            {

                foreach (var group in groupeDB_cash_supply)
                {
                    int count_cash_exchange = 0;
                    string date_cash_supply = "";
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
                        date_cash_supply = Row[1].ToString();
                        name_Benf_Type = Row[3].ToString();
                        Value_Expe = Convert.ToDouble(Row[4]);
                        name_beneficiry = Row[6].ToString();
                        Curr_balance = Convert.ToDouble(Row[7]);
                        Remain_balan = Convert.ToDouble(Row[8]);
                        name_Payment_side = Row[9].ToString();
                        Document_Note = Row[10].ToString();
                        Name_Emp = Row[11].ToString();

                        vr.Dgv_RP_cash_supply_dgv.Rows.Add(
                                date_cash_supply,//
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
        public void View_Report_cash_supply()
        {
            var vr = Application.OpenForms["Main"] as Main;
            //File_RP_Sales_Emp RP = new File_RP_Sales_Emp();
            xr_RP_cash_supply RP = new xr_RP_cash_supply();

            DataTable dt = new classs_table.Items_Tools().Fill_DataTable_Columns("dt_RP_cash_supply", new string[] {
                             "date_cash_supply",
                             "name_Benf_Type" ,
                            "name_beneficiry"  ,
                             "Value_Expe" ,
                            "Curr_balance",
                            "Remain_balan",
                            "name_Payment_side" ,
                            "Document_Note ",
                            "Name_Emp"
            });
            int totale_supply = 0;
            for (int i = 0; i < vr.Dgv_RP_cash_supply_dgv.Rows.Count; i++)
            {
                dt.Rows.Add(
                    vr.Dgv_RP_cash_supply_dgv.Rows[i].Cells[0].Value,
                    vr.Dgv_RP_cash_supply_dgv.Rows[i].Cells[1].Value,
                    vr.Dgv_RP_cash_supply_dgv.Rows[i].Cells[2].Value,
                    vr.Dgv_RP_cash_supply_dgv.Rows[i].Cells[3].Value,
                    vr.Dgv_RP_cash_supply_dgv.Rows[i].Cells[4].Value,
                    vr.Dgv_RP_cash_supply_dgv.Rows[i].Cells[5].Value,
                    vr.Dgv_RP_cash_supply_dgv.Rows[i].Cells[6].Value,
                    vr.Dgv_RP_cash_supply_dgv.Rows[i].Cells[7].Value,
                    vr.Dgv_RP_cash_supply_dgv.Rows[i].Cells[8].Value
                    );
                // هذا يعطينا مجموع المبلغ المورد
                totale_supply += Convert.ToInt32(vr.Dgv_RP_cash_supply_dgv.Rows[i].Cells[3].Value);

            }

            RP.dtp_One_RP_cash_supply.Text = vr.Dtime_one_Rp_cash_supply.Value.Date.ToString();
            RP.dtp_Tow_RP_cash_supply.Text = vr.Dtime_two_Rp_cash_supply.Value.Date.ToString();
            RP.txt_Storg_RP_cash_supply.Text = vr.cbx_RP_name_Payment_side_cash_supply.Text;
            RP.xrtxtRP_num_pross_RP_Cash_supply.Text = vr.Dgv_RP_cash_supply_dgv.Rows.Count.ToString();
            RP.xrtxtRP_total_supply.Text = totale_supply.ToString();
            //RP.xrtxtRP_amount_exchange_written.Text =  (totale_exchange).ToString();

            double temp = Convert.ToDouble(totale_supply);
            RP.xrtxtRP_amount_supply_written.Text = MOJ.General.ConvertToLetters(Convert.ToDecimal(temp.ToString("N0")), "ريال", "ريال");



            //داله جاهزه لتعبئة التقرير للطباعة
            new classs_table.Items_Tools().show_Dev_ReportView(dt, RP);

        }

        public void serch_text_and_combox_cash_supply()
        {
            //تعديل
            var a = Application.OpenForms["Main"] as Main;
            if (Convert.ToInt32(a.cbx_RP_name_Benf_Type_cash_supply.SelectedIndex) == 0)
            {
                a.lbl_RP_name_beneficiry_cash_supply.Enabled = false;
                a.txt_serch_RP_name_beneficiry_cash_supply.Clear();
                a.txt_serch_RP_name_beneficiry_cash_supply.Enabled = false;
                a.Dgv_RP_cash_supply_dgv.Rows.Clear();
            }
            else if (Convert.ToInt32(a.cbx_RP_name_Benf_Type_cash_supply.SelectedIndex) == 1)
            {
                a.lbl_RP_name_beneficiry_cash_supply.Enabled = true;
                a.txt_serch_RP_name_beneficiry_cash_supply.Clear();

                a.txt_serch_RP_name_beneficiry_cash_supply.Enabled = true;
                a.Dgv_RP_cash_supply_dgv.Rows.Clear();

            }
            else if (Convert.ToInt32(a.cbx_RP_name_Benf_Type_cash_supply.SelectedIndex) == 2)
            {
                a.lbl_RP_name_beneficiry_cash_supply.Enabled = true;
                a.txt_serch_RP_name_beneficiry_cash_supply.Clear();
                a.txt_serch_RP_name_beneficiry_cash_supply.Enabled = true;
                a.Dgv_RP_cash_supply_dgv.Rows.Clear();

            }
            else if (Convert.ToInt32(a.cbx_RP_name_Benf_Type_cash_supply.SelectedIndex) == 3)
            {
                a.lbl_RP_name_beneficiry_cash_supply.Enabled = true;
                a.txt_serch_RP_name_beneficiry_cash_supply.Clear();
                a.txt_serch_RP_name_beneficiry_cash_supply.Enabled = true;
                a.Dgv_RP_cash_supply_dgv.Rows.Clear();

            }
            //else if (Convert.ToInt32(a.cbx_RP_name_Benf_Type_cash_supply.SelectedIndex) == 4)
            //{
            //    a.lbl_serch_RP_cash_Exchange.Enabled = false;
            //    a.txt_serch_RP_cash_Exchange.Clear();
            //    a.txt_serch_RP_cash_Exchange.Enabled = false;
            //}


        }

        }
    }
