using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Manag_ph.Item.forms;


namespace Manag_ph.Daily_accounts.Cash_exchange
{
    public partial class cash_exchange : Form
    {
        public cash_exchange()
        {
            InitializeComponent();
        }

        public bool show_form = false;

        public int num_count_casher = 0;
        public int num_count_storgs = 0;


        public bool cash_exchange_form = false;

        //داله تنظيف خانات المعلومات الخاصه بالسند واضافه رقم السند الجديد
        private void Clear_All_controls()
        {
            var vr = Application.OpenForms["Main"] as Main;

            //object d = vr.timer1.GetLifetimeService();
            int num_beneficiry = new classs_table.Items_Tools().AoutoNumber("cash_Exchange", "num_bond");
            txt_num_Doc.Text = num_beneficiry.ToString();//رقم المستند 
            ;// تاريخ المستند
            comBox_beneficiry.SelectedIndex = -1; // نوع المسنفيد 
            txt_Paid_val.Text = string.Empty; // القيمة المنصرفة 
            txt_num_beneficiry.Text = "000";    // رقم المستفيد
            txt_name_beneficiry.Text = "";  //  اسم المستفيد 
            txt_Cur_balance.Text = "000";    // الرصيد الحالي
            txt_Remain_balanc.Text = "000";  // الرصيد المتبقي
            txt_Cur_balance_cred.Text = "000";
            comBox_Payment_side.SelectedIndex = 0;  //  جهة دفع النقدي
            txt_Document_Note.Text = "";          // الملاحظات



        }



        //داله اضافه جدول كومبو بوكس للمستفيد
        private void fun1()
        {

            DataTable d1 = new DataTable();
            d1.Columns.Add("code", typeof(int));
            d1.Columns.Add("name", typeof(string));

            d1.Rows.Add(1, "مورد");
            d1.Rows.Add(2, "عميل");
            d1.Rows.Add(3, "موظف");
            d1.Rows.Add(4, "مصروفات تشغيل");

            comBox_beneficiry.DataSource = d1;

            comBox_beneficiry.ValueMember = "code";
            comBox_beneficiry.DisplayMember = "name";


        }
        //داله اضافه جدول كومبو بوكس صرف من 
        // دالة لتعبئة اسماء اصناديق والكاشير في الكبو بكس
        public void fill_Cacher_and_fund()
        {
            var vr = Application.OpenForms["Main"] as Main;
            DataTable dt = new DataTable();
            dt.Columns.Add("code", typeof(int));
            dt.Columns.Add("name", typeof(string));
            DataRow[] dr_fund = DB_Add_delete_update_.Database.ds.Tables["account_fund"].Select();
            DataRow[] dr_Casher = DB_Add_delete_update_.Database.ds.Tables["casher"].Select();


            num_count_storgs = dr_fund.Count();// متغيير ياخذ رقم الاخير من جدول الكاشير 
            num_count_casher = dr_Casher.Count(); ;// متغيير ياخذ رقم الاخير من جدول المخازن 

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

            comBox_Payment_side.DataSource = dt;
            comBox_Payment_side.DisplayMember = "name";
            comBox_Payment_side.ValueMember = "code";



        }




        public int cash1 = 0;
        private void cash_exchange_Load(object sender, EventArgs e)
        {
            var v1 = Application.OpenForms["Main"] as Main;
            v1.show_form_supper = 1;

            //داله لتعبئه الكومبو بكس  ب نوع المستفيد 

            fun1();
            //داله لتعبئه الكومبو بكس  ب اسم المخزن او الصندوق 

            fill_Cacher_and_fund();
            //داله لتنظيف الادوات الذي بالشاشه 

            Clear_All_controls();
            //داله لتعبئه الكومبو بكس  من جدول  نوع مصاريف التشغيل

            tb_type_work();

        }

        //private void true1() {

        //    var vr1 = Application.OpenForms["Frm_Client_Show"] as Frm_Client_Show;
        //    vr1.show_form1 = 1;

        //    show_form = true;

        //}
        private void txt_num_beneficiry_DoubleClick(object sender, EventArgs e)
        {


            //شرط اذا اختار مورد
            if (Convert.ToInt32(comBox_beneficiry.SelectedValue) == 1)
            {


                cash1 = 1;
                DB_Add_delete_update_.Database.update("Supplier");
                DB_Add_delete_update_.Database.update("Calc_supply");
                new Item.forms.frm_Supper_prodect().ShowDialog();


            }

            //شرط اذا اختار عميل
            else if (Convert.ToInt32(comBox_beneficiry.SelectedValue) == 2)
            {

                cash1 = 2;

                DB_Add_delete_update_.Database.update("Clien");
                DB_Add_delete_update_.Database.update("Stock_client");
                new Item.forms.Frm_Client_Show().ShowDialog();

            }
            //شرط اذا اختار موظف
            else if (Convert.ToInt32(comBox_beneficiry.SelectedValue) == 3)
            {

                cash1 = 3;

                new Item.forms.Frm_Emplyees_Show().ShowDialog();

            }
            //true1(); 

        }

        //داله تحقق من المبلغ الموجود في المخزن او الكاشير هل يكفي او لا 
        private void if_storig_And_cashir()
        {
            DataRow[] dr_casher = DB_Add_delete_update_.Database.ds.Tables["casher"].Select("casher_num = " + comBox_Payment_side.SelectedValue + " and casher_name = '" + comBox_Payment_side.Text + "'");
            DataRow[] dr_fund = DB_Add_delete_update_.Database.ds.Tables["account_fund"].Select("fund_num = " + comBox_Payment_side.SelectedValue + " and fund_name_ar = '" + comBox_Payment_side.Text + "'");
            // لو كان يرد السداد نقد ومن الكاشير
            if (dr_casher.Count() != 0)
            {
                object[] ob_account_casher = DB_Add_delete_update_.Database.ds.Tables["casher_account"].Rows.Find(dr_casher[0][5]).ItemArray;

                // مجموع الرصيد في الدرج معا الرصيد السابق
                double sum_sals_casher_Account = Convert.ToDouble(ob_account_casher[1]);
                // لو كان اقل من صافي الفاتورة
                if (sum_sals_casher_Account >= Convert.ToDouble(txt_Paid_val.Text.Trim()))
                {
                    // ننقص قيمة الفاتورة من رصيد الدرج

                    ob_account_casher[1] = Convert.ToDouble(ob_account_casher[1]) - Convert.ToDouble(txt_Paid_val.Text.Trim());
                    new classs_table.Items_Tools().update_Rows_Table_Database("casher_account", ob_account_casher[0].ToString(), ob_account_casher);
                }
                else
                {
                    MessageBox.Show("المبلغ في الدرج اقل من صافي الفاتورة", "Eroor", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;

                }
            }
            // لو كان يرد السداد نقد ومن الصندوق
            else if (dr_fund.Count() != 0)
            {
                object[] ob_account_fund = DB_Add_delete_update_.Database.ds.Tables["fund_sals"].Rows.Find(dr_fund[0][4]).ItemArray;

                double sum_sals_fund_sals = Convert.ToDouble(ob_account_fund[1]);
                // لو كان اقل من صافي الفاتورة
                if (sum_sals_fund_sals >= Convert.ToDouble(txt_Paid_val.Text.Trim()))
                {
                    // ننقص قيمة الفاتورة من رصيد الصندوق
                    ob_account_fund[1] = Convert.ToDouble(ob_account_fund[1]) - Convert.ToDouble(txt_Paid_val.Text.Trim());
                    new classs_table.Items_Tools().update_Rows_Table_Database("fund_sals", ob_account_fund[0].ToString(), ob_account_fund);
                }
                else
                {
                    MessageBox.Show("المبلغ في الصندوق اقل من صافي الفاتورة", "Eroor", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;

                }

            }

        }

        private void btn_save_cash_exchange_Click(object sender, EventArgs e)
        {

            var vr = Application.OpenForms["Main"] as Main;

            DataRow[] dr_casher = DB_Add_delete_update_.Database.ds.Tables["casher"].Select("casher_num = " + comBox_Payment_side.SelectedValue + " and casher_name = '" + comBox_Payment_side.Text + "'");
            DataRow[] dr_fund = DB_Add_delete_update_.Database.ds.Tables["account_fund"].Select("fund_num = " + comBox_Payment_side.SelectedValue + " and fund_name_ar = '" + comBox_Payment_side.Text + "'");

            //متغير لرقم المستفيد
            int num_bef_type1 = 0;
            ////////////////////////////////////////////////////////تتعديل
            int num_the_type_ss = 0;


            DataRow[] dr_fund2 = DB_Add_delete_update_.Database.ds.Tables["account_fund"].Select("fund_stop = " + false);
            DataRow[] dr_Casher2 = DB_Add_delete_update_.Database.ds.Tables["casher"].Select("casher_stop = " + false);


            if (comBox_Payment_side.SelectedIndex < dr_fund2.Count())
            {
                num_the_type_ss = 1;

            }
            //else if (comBox_supply_to.SelectedIndex  >= dr_Casher2.Count() && comBox_supply_to.SelectedIndex  < dr_Casher2.Count()+dr_fund2.Count() )
            else if (comBox_Payment_side.SelectedIndex == dr_fund2.Count() && comBox_Payment_side.SelectedIndex < dr_fund2.Count() + dr_Casher2.Count())
            {
                num_the_type_ss = 2;
            }
            //////////////////////////////////////////////////////


            if (comBox_beneficiry.SelectedItem != null)
            {

                // اذا لم  يكن نوع المسنفيد مصروفات تشغيل

                if (comBox_beneficiry.SelectedIndex != 3 && comBox_beneficiry.SelectedIndex != -1)
                {


                    if (txt_num_beneficiry.Text.Trim() != string.Empty && txt_name_beneficiry.Text.Trim() != string.Empty)
                    {


                        int num_beneficiry = Convert.ToInt32(txt_num_beneficiry.Text);

                        if (txt_Paid_val.Text.Trim() != string.Empty)
                        {
                            // لو كان يرد السداد نقد ومن الكاشير
                            if (dr_casher.Count() != 0)
                            {
                                object[] ob_account_casher = DB_Add_delete_update_.Database.ds.Tables["casher_account"].Rows.Find(dr_casher[0][5]).ItemArray;

                                // مجموع الرصيد في الدرج معا الرصيد السابق
                                double sum_sals_casher_Account = Convert.ToDouble(ob_account_casher[1]);
                                // لو كان اقل من صافي الفاتورة
                                if (sum_sals_casher_Account >= Convert.ToDouble(txt_Paid_val.Text.Trim()))
                                {
                                    // ننقص قيمة الفاتورة من رصيد الدرج

                                    ob_account_casher[1] = Convert.ToDouble(ob_account_casher[1]) - Convert.ToDouble(txt_Paid_val.Text.Trim());
                                    new classs_table.Items_Tools().update_Rows_Table_Database("casher_account", ob_account_casher[0].ToString(), ob_account_casher);
                                }
                                else
                                {
                                    MessageBox.Show("المبلغ في الدرج اقل من صافي الفاتورة", "Eroor", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    return;

                                }
                            }
                            // لو كان يرد السداد نقد ومن الصندوق
                            else if (dr_fund.Count() != 0)
                            {
                                object[] ob_account_fund = DB_Add_delete_update_.Database.ds.Tables["fund_sals"].Rows.Find(dr_fund[0][4]).ItemArray;

                                double sum_sals_fund_sals = Convert.ToDouble(ob_account_fund[1]);
                                // لو كان اقل من صافي الفاتورة
                                if (sum_sals_fund_sals >= Convert.ToDouble(txt_Paid_val.Text.Trim()))
                                {
                                    // ننقص قيمة الفاتورة من رصيد الصندوق
                                    ob_account_fund[1] = Convert.ToDouble(ob_account_fund[1]) - Convert.ToDouble(txt_Paid_val.Text.Trim());
                                    new classs_table.Items_Tools().update_Rows_Table_Database("fund_sals", ob_account_fund[0].ToString(), ob_account_fund);
                                }
                                else
                                {
                                    MessageBox.Show("المبلغ في الصندوق اقل من صافي الفاتورة", "Eroor", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    return;

                                }

                            }


                            // اذا كان المبلغ المصروف اعلى من رصيد المستفيد ويطلع المتبقي بالسالب يظهر رساله هل تريد تسجيل  المبلغ على المستفيد دائن مننا  

                            if (txt_Remain_balanc.Text.Trim() == String.Empty)
                            {
                                return;
                            }
                            if (Convert.ToDouble(txt_Remain_balanc.Text) < 0)
                            {

                                DialogResult dl_you = MessageBox.Show(" رصيد متبقي سالب تريد تسجيلة بحساب المستفيد دائن \n" + "                                " + txt_Remain_balanc.Text + "", "Eroor", MessageBoxButtons.YesNo, MessageBoxIcon.Information);

                                if (dl_you == DialogResult.Yes)
                                {

                                    //لو كان المستفيد مورد يتم تحديث الرصيد 
                                    //if (comBox_beneficiry.SelectedIndex == 0)
                                    //{
                                    //    num_bef_type1 = 1;
                                    //    DataRow dtr_Cl_Supply = DB_Add_delete_update_.Database.ds.Tables["Calc_supply"].Rows.Find(num_beneficiry);
                                    //    int dr_indx = DB_Add_delete_update_.Database.ds.Tables["Calc_supply"].Rows.IndexOf(dtr_Cl_Supply);


                                    //    double x_supp = Convert.ToDouble(dtr_Cl_Supply[2]);
                                    //    double y_supp = (0) - (Convert.ToDouble(txt_Remain_balanc.Text));

                                    //    DB_Add_delete_update_.Database.ds.Tables["Calc_supply"].Rows[dr_indx][1] =  0 ;
                                    //    DB_Add_delete_update_.Database.ds.Tables["Calc_supply"].Rows[dr_indx][2] = (x_supp) + (y_supp);
                                    //    DB_Add_delete_update_.Database.update("Calc_supply");

                                    //}

                                    ////لو كان المستفيد عميل يتم تحديث الرصيد 
                                    //else if (comBox_beneficiry.SelectedIndex == 1)
                                    //{
                                    //    num_bef_type1 = 2;
                                    //    DataRow dtr_Clien = DB_Add_delete_update_.Database.ds.Tables["Stock_client"].Rows.Find(num_beneficiry);
                                    //    int dr_indx = DB_Add_delete_update_.Database.ds.Tables["Stock_client"].Rows.IndexOf(dtr_Clien);

                                    //    double x_cli =Convert.ToDouble( dtr_Clien[2]);

                                    //    double y_cli = (0) - (Convert.ToDouble(txt_Remain_balanc.Text));

                                    //    DB_Add_delete_update_.Database.ds.Tables["Stock_client"].Rows[dr_indx][1] = 0 ;
                                    //    DB_Add_delete_update_.Database.ds.Tables["Stock_client"].Rows[dr_indx][2] = (x_cli)+(y_cli);
                                    //    DB_Add_delete_update_.Database.update("Stock_client");



                                    //}
                                    //لو كان المستفيد موظف يتم تحديث الرصيد 
                                    // else
                                    //if (comBox_beneficiry.SelectedIndex == 2)
                                    //{

                                    //    num_bef_type1 = 3;
                                    //    DataRow dt_Emp_account = DB_Add_delete_update_.Database.ds.Tables["Emplyee_account"].Rows.Find(num_beneficiry);

                                    //    int num_indx_Emp = DB_Add_delete_update_.Database.ds.Tables["Emplyee_account"].Rows.IndexOf(dt_Emp_account);

                                    //    double x_Emp = Convert.ToDouble(dt_Emp_account[2]);

                                    //    double y_Emp = (0) - (Convert.ToDouble(txt_Remain_balanc.Text));

                                    //    DB_Add_delete_update_.Database.ds.Tables["Emplyee_account"].Rows[num_indx_Emp][2] = (x_Emp) + (y_Emp);
                                    //    DB_Add_delete_update_.Database.ds.Tables["Emplyee_account"].Rows[num_indx_Emp][1] =   0 ;
                                    //    DB_Add_delete_update_.Database.update("Emplyee_account");

                                    //}

                                }
                                else
                                {
                                    //يرجع الا الشاشه 
                                    return;

                                }

                            }


                            //لو كان الرصيد المتبقي موجب يحفظ طبيعي مدين تبع المستفيد
                            if (Convert.ToDouble(txt_Remain_balanc.Text) >= 0)
                            {
                                //لو كان المستفيد مورد يتم تحديث الرصيد 
                                //if (comBox_beneficiry.SelectedIndex == 0)
                                //{
                                //    num_bef_type1 = 1;

                                //    DataRow dtr_Cl_Supply = DB_Add_delete_update_.Database.ds.Tables["Calc_supply"].Rows.Find(num_beneficiry);
                                //    int dr_indx = DB_Add_delete_update_.Database.ds.Tables["Calc_supply"].Rows.IndexOf(dtr_Cl_Supply);
                                //    DB_Add_delete_update_.Database.ds.Tables["Calc_supply"].Rows[dr_indx][1] = Convert.ToDouble(txt_Remain_balanc.Text);
                                //    DB_Add_delete_update_.Database.update("Calc_supply");

                                //}

                                ////لو كان المستفيد عميل يتم تحديث الرصيد 
                                //else if (comBox_beneficiry.SelectedIndex == 1)
                                //{

                                //    num_bef_type1 = 2;

                                //    DataRow dtr_Clien = DB_Add_delete_update_.Database.ds.Tables["Stock_client"].Rows.Find(num_beneficiry);
                                //    int dr_indx = DB_Add_delete_update_.Database.ds.Tables["Stock_client"].Rows.IndexOf(dtr_Clien);
                                //    DB_Add_delete_update_.Database.ds.Tables["Stock_client"].Rows[dr_indx][1] = Convert.ToDouble(txt_Remain_balanc.Text);
                                //    DB_Add_delete_update_.Database.update("Stock_client");


                                //}
                                //لو كان المستفيد موظف يتم تحديث الرصيد 
                                //   else 
                                //if (comBox_beneficiry.SelectedIndex == 2)
                                //{
                                //    num_bef_type1 = 3;


                                //    DataRow dt_Emp_account = DB_Add_delete_update_.Database.ds.Tables["Emplyee_account"].Rows.Find(num_beneficiry);
                                //    int num_indx_Emp = DB_Add_delete_update_.Database.ds.Tables["Emplyee_account"].Rows.IndexOf(dt_Emp_account);
                                //    DB_Add_delete_update_.Database.ds.Tables["Emplyee_account"].Rows[num_indx_Emp][1] = Convert.ToDouble(txt_Remain_balanc.Text);
                                //    DB_Add_delete_update_.Database.update("Emplyee_account");

                                //}

                            }

                            // object[] dt_Emp_name_use = null;
                            DataRow dt_Emp_use = DB_Add_delete_update_.Database.ds.Tables["TB_LOGIN_EMP"].Rows.Find(new object[] { Convert.ToInt32(vr.txt_user_id_Emp.Caption), vr.txt_user_Emp.Caption });//Convert.ToInt32(vr.txt_user_id_Emp.Caption)
                            // if (dt_Emp_use.Count()!=0) {

                            DataRow dt_Emp_name_use = DB_Add_delete_update_.Database.ds.Tables["TB_Employees"].Rows.Find(dt_Emp_use[4]);
                            // }

                            // يتم اضافه او حفظ مستند الدفع 


                            if (comBox_beneficiry.SelectedIndex == 0)
                            {
                                int num_max;
                                if (DB_Add_delete_update_.Database.ds.Tables["Accounts_suppliers"].Rows.Count != 0)
                                {

                                    num_max = Convert.ToInt32(DB_Add_delete_update_.Database.ds.Tables["Accounts_suppliers"].Compute("max(id_Accoun_sup)", "").ToString()) + 1;

                                }
                                else
                                {
                                    num_max = 1;
                                }
                                ///    DataRow dtr_Clien = DB_Add_delete_update_.Database.ds.Tables["Calc_supply"].Rows.Find(num_beneficiry);


                                num_bef_type1 = 1;
                                DataRow dtr_Clien = DB_Add_delete_update_.Database.ds.Tables["Calc_supply"].Rows.Find(num_beneficiry);
                                int dr_indx = DB_Add_delete_update_.Database.ds.Tables["Calc_supply"].Rows.IndexOf(dtr_Clien);

                                int txt_Paid_vall = Convert.ToInt32(txt_Paid_val.Text);
                                if (Convert.ToDouble(txt_Cur_balance.Text) >= txt_Paid_vall && Convert.ToDouble(txt_Cur_balance.Text) != 0)
                                {
                                    if (Convert.ToDouble(txt_Cur_balance.Text) > 0 && Convert.ToDouble(txt_Cur_balance_cred.Text) == 0 && Convert.ToDouble(txt_Cur_balance.Text) > txt_Paid_vall)
                                    {
                                        double txt_Remain_balanc_supps = Convert.ToDouble(txt_Cur_balance.Text) - Convert.ToDouble(txt_Paid_vall);
                                       
                                        DB_Add_delete_update_.Database.ds.Tables["Calc_supply"].Rows[dr_indx][3] = Math.Abs(Convert.ToDouble(txt_Remain_balanc_supps.ToString("N2")));  // txt_Remain_balanc_supps.ToString("N2");
                                        DB_Add_delete_update_.Database.ds.Tables["Calc_supply"].Rows[dr_indx][2] = Math.Abs(Convert.ToDouble(txt_Remain_balanc_supps.ToString("N2")));//txt_Remain_balanc_supps.ToString("N2");
                                        DB_Add_delete_update_.Database.ds.Tables["Calc_supply"].Rows[dr_indx][1] = 0;
                                    }
                                    else if (Convert.ToDouble(txt_Cur_balance.Text) == 0 && Convert.ToDouble(txt_Cur_balance_cred.Text) == 0)
                                    {
                                        double txt_Remain_balanc_supps = Convert.ToDouble(txt_Paid_vall) + Convert.ToDouble(txt_Cur_balance.Text);

                                        DB_Add_delete_update_.Database.ds.Tables["Calc_supply"].Rows[dr_indx][3] = Math.Abs(Convert.ToDouble(txt_Paid_vall.ToString("N2")));  // txt_Paid_vall.ToString("N2");
                                        DB_Add_delete_update_.Database.ds.Tables["Calc_supply"].Rows[dr_indx][1] = Math.Abs(Convert.ToDouble(txt_Paid_vall.ToString("N2")));//txt_Paid_vall.ToString("N2");//txt_Remain_balanc_supps.ToString("N2");
                                        DB_Add_delete_update_.Database.ds.Tables["Calc_supply"].Rows[dr_indx][2] = 0;//Convert.ToDouble(txt_Remain_balanc.Text).ToString("N2");
                                    }
                                    else if (Convert.ToDouble(txt_Cur_balance.Text) == 0 && Convert.ToDouble(txt_Cur_balance_cred.Text) >= 0)
                                    {
                                        double txt_Remain_balanc_supps = Convert.ToDouble(txt_Paid_vall) + Convert.ToDouble(txt_Cur_balance_cred.Text);
                                        DB_Add_delete_update_.Database.ds.Tables["Calc_supply"].Rows[dr_indx][3] = Math.Abs(Convert.ToDouble(txt_Remain_balanc_supps.ToString("N2")));//txt_Remain_balanc_supps.ToString("N2");
                                        DB_Add_delete_update_.Database.ds.Tables["Calc_supply"].Rows[dr_indx][1] = Math.Abs(Convert.ToDouble(txt_Remain_balanc_supps.ToString("N2")));//txt_Remain_balanc_supps.ToString("N2");//txt_Remain_balanc_supps.ToString("N2");
                                        DB_Add_delete_update_.Database.ds.Tables["Calc_supply"].Rows[dr_indx][2] = 0;
                                    }
                                    else if (Convert.ToDouble(txt_Cur_balance.Text) > 0 && Convert.ToDouble(txt_Cur_balance_cred.Text) == 0 && Convert.ToDouble(txt_Cur_balance.Text) <= txt_Paid_vall)
                                    {
                                        double txt_Remain_balanc_supps = Convert.ToDouble(txt_Paid_vall) - Convert.ToDouble(txt_Cur_balance.Text);

                                        DB_Add_delete_update_.Database.ds.Tables["Calc_supply"].Rows[dr_indx][3] = Math.Abs(Convert.ToDouble(txt_Remain_balanc_supps.ToString("N2")));// txt_Remain_balanc_supps.ToString("N2");
                                        DB_Add_delete_update_.Database.ds.Tables["Calc_supply"].Rows[dr_indx][1] = Math.Abs(Convert.ToDouble(txt_Remain_balanc_supps.ToString("N2")));// txt_Remain_balanc_supps.ToString("N2");
                                        DB_Add_delete_update_.Database.ds.Tables["Calc_supply"].Rows[dr_indx][2] = 0;
                                    }

                                    /// توريد جدول الموردين
                                    DataRow[] tb_type = DB_Add_delete_update_.Database.ds.Tables["operating_Expenses"].Select();
                                    DB_Add_delete_update_.Database.ds.Tables["Accounts_suppliers"].Rows.Add(
                                              num_max,
                                              num_beneficiry,
                                              txt_name_beneficiry.Text,
                                              dt_Emp_name_use[0],//data_user[0][0],
                                              dt_Emp_name_use[1],
                                              dtr_Clien[1],
                                              dtr_Clien[2],//  Convert.ToDouble(txt_Remain_balanc.Text),
                                               "صرف نقدي",
                                              DateTime.Now,
                                              Convert.ToDouble(txt_Paid_val.Text)

                                        );
                                    DB_Add_delete_update_.Database.update("Calc_supply");
                                    DB_Add_delete_update_.Database.update("Accounts_suppliers");

                                }
                                else
                                {
                                    MessageBox.Show("قد يكون المبلغ المراد صرفه اكبر من المبلغ المستحق \n ", " يرجاء المراجعه", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    return;
                                }

                            }
                            else if (comBox_beneficiry.SelectedIndex == 1)
                            {

                                int num_max_Ciln;
                                if (DB_Add_delete_update_.Database.ds.Tables["Accounts_Clin"].Rows.Count != 0)
                                {

                                    num_max_Ciln = Convert.ToInt32(DB_Add_delete_update_.Database.ds.Tables["Accounts_Clin"].Compute("max(ID_Accoun_Clin)", "").ToString()) + 1;

                                }
                                else
                                {
                                    num_max_Ciln = 1;
                                }
                                // DataRow dtr_Clien = DB_Add_delete_update_.Database.ds.Tables["Stock_client"].Rows.Find(num_beneficiry);

                                num_bef_type1 = 1;
                                DataRow dtr_Clien = DB_Add_delete_update_.Database.ds.Tables["Stock_client"].Rows.Find(num_beneficiry);
                                int dr_indx = DB_Add_delete_update_.Database.ds.Tables["Stock_client"].Rows.IndexOf(dtr_Clien);
                                int txt_Paid_vall = Convert.ToInt32(txt_Paid_val.Text);

                                //يتم هنا اخذ القيمة الصرف وتنقيص من القيمة الحاليه تبع المستفيد ويوضع الناتج في القيمة المتبقيه

                                if (Convert.ToDouble(txt_Cur_balance.Text) >= txt_Paid_vall && Convert.ToDouble(txt_Cur_balance.Text) != 0)
                                {
                                    if (Convert.ToDouble(txt_Cur_balance.Text) > 0 && Convert.ToDouble(txt_Cur_balance_cred.Text) == 0 && Convert.ToDouble(txt_Cur_balance.Text) > txt_Paid_vall)
                                    {
                                        double txt_Remain_balanc_supps = Convert.ToDouble(txt_Cur_balance.Text) - Convert.ToDouble(txt_Paid_vall);

                                        DB_Add_delete_update_.Database.ds.Tables["Stock_client"].Rows[dr_indx][4] = Math.Abs(Convert.ToDouble(txt_Remain_balanc_supps.ToString("N2")));// txt_Remain_balanc_supps.ToString("N2");
                                        DB_Add_delete_update_.Database.ds.Tables["Stock_client"].Rows[dr_indx][2] = Math.Abs(Convert.ToDouble(txt_Remain_balanc_supps.ToString("N2"))); //txt_Remain_balanc_supps.ToString("N2");
                                        DB_Add_delete_update_.Database.ds.Tables["Stock_client"].Rows[dr_indx][1] = 0;
                                    }
                                    else if (Convert.ToDouble(txt_Cur_balance.Text) == 0 && Convert.ToDouble(txt_Cur_balance_cred.Text) == 0)
                                    {

                                        double txt_Remain_balanc_supps = Convert.ToDouble(txt_Paid_vall) + Convert.ToDouble(txt_Cur_balance.Text);

                                        DB_Add_delete_update_.Database.ds.Tables["Stock_client"].Rows[dr_indx][4] = Math.Abs(Convert.ToDouble(txt_Paid_vall.ToString("N2"))); //txt_Paid_vall.ToString("N2");
                                        DB_Add_delete_update_.Database.ds.Tables["Stock_client"].Rows[dr_indx][1] = Math.Abs(Convert.ToDouble(txt_Paid_vall.ToString("N2")));// txt_Paid_vall.ToString("N2");//txt_Remain_balanc_supps.ToString("N2");
                                        DB_Add_delete_update_.Database.ds.Tables["Stock_client"].Rows[dr_indx][2] = 0;//Convert.ToDouble(txt_Remain_balanc.Text).ToString("N2");
                                    }
                                    else if (Convert.ToDouble(txt_Cur_balance.Text) == 0 && Convert.ToDouble(txt_Cur_balance_cred.Text) >= 0)
                                    {
                                        double txt_Remain_balanc_supps = Convert.ToDouble(txt_Paid_vall) + Convert.ToDouble(txt_Cur_balance_cred.Text);
                                        DB_Add_delete_update_.Database.ds.Tables["Stock_client"].Rows[dr_indx][4] = Math.Abs(Convert.ToDouble(txt_Remain_balanc_supps.ToString("N2")));// txt_Remain_balanc_supps.ToString("N2");
                                        DB_Add_delete_update_.Database.ds.Tables["Stock_client"].Rows[dr_indx][1] = Math.Abs(Convert.ToDouble(txt_Remain_balanc_supps.ToString("N2"))); //txt_Remain_balanc_supps.ToString("N2");//txt_Remain_balanc_supps.ToString("N2");
                                        DB_Add_delete_update_.Database.ds.Tables["Stock_client"].Rows[dr_indx][2] = 0;
                                    }
                                    else if (Convert.ToDouble(txt_Cur_balance.Text) > 0 && Convert.ToDouble(txt_Cur_balance_cred.Text) == 0 && Convert.ToDouble(txt_Cur_balance.Text) <= txt_Paid_vall)
                                    {
                                        double txt_Remain_balanc_supps = Convert.ToDouble(txt_Paid_vall) - Convert.ToDouble(txt_Cur_balance.Text);

                                        DB_Add_delete_update_.Database.ds.Tables["Stock_client"].Rows[dr_indx][4] = Math.Abs(Convert.ToDouble(txt_Remain_balanc_supps.ToString("N2"))); //txt_Remain_balanc_supps.ToString("N2");
                                        DB_Add_delete_update_.Database.ds.Tables["Stock_client"].Rows[dr_indx][1] = Math.Abs(Convert.ToDouble(txt_Remain_balanc_supps.ToString("N2"))); //txt_Remain_balanc_supps.ToString("N2");
                                        DB_Add_delete_update_.Database.ds.Tables["Stock_client"].Rows[dr_indx][2] = 0;
                                    }

                                    ///توريد جدول العملاء

                                    DB_Add_delete_update_.Database.ds.Tables["Accounts_Clin"].Rows.Add(
                                              num_max_Ciln,
                                              num_beneficiry,
                                              txt_name_beneficiry.Text,
                                              dt_Emp_name_use[0],//data_user[0][0],
                                              dt_Emp_name_use[1],
                                              dtr_Clien[1],
                                              dtr_Clien[2],// Convert.ToDouble(txt_Remain_balanc.Text),
                                               "صرف نقدي",
                                               DateTime.Now,
                                              Convert.ToDouble(txt_Paid_val.Text)
                                        );
                                    DB_Add_delete_update_.Database.update("Stock_client");
                                    DB_Add_delete_update_.Database.update("Accounts_Clin");

                                }
                                else
                                {
                                    MessageBox.Show("قد يكون المبلغ المراد صرفه اكبر من المبلغ المستحق \n ", " يرجاء المراجعه", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    return;
                                }

                            }
                            else if (comBox_beneficiry.SelectedIndex == 2)
                            {

                                num_bef_type1 = 3;


                                DataRow dt_Emp_account = DB_Add_delete_update_.Database.ds.Tables["Emplyee_account"].Rows.Find(num_beneficiry);
                                int num_indx_Emp = DB_Add_delete_update_.Database.ds.Tables["Emplyee_account"].Rows.IndexOf(dt_Emp_account);

                                int txt_Paid_vall = Convert.ToInt32(txt_Paid_val.Text);

                                //يتم هنا اخذ القيمة الصرف وتنقيص من القيمة الحاليه تبع المستفيد ويوضع الناتج في القيمة المتبقيه

                                if (Convert.ToDouble(txt_Cur_balance.Text) >= txt_Paid_vall && Convert.ToDouble(txt_Cur_balance.Text) != 0)
                                {
                                    if (Convert.ToDouble(txt_Cur_balance.Text) > 0 && Convert.ToDouble(txt_Cur_balance_cred.Text) == 0 && Convert.ToDouble(txt_Cur_balance.Text) > txt_Paid_vall)
                                    {
                                        double txt_Remain_balanc_supps = Convert.ToDouble(txt_Cur_balance.Text) - Convert.ToDouble(txt_Paid_vall);

                                        DB_Add_delete_update_.Database.ds.Tables["Emplyee_account"].Rows[num_indx_Emp][2] = Math.Abs(Convert.ToDouble(txt_Remain_balanc.Text)).ToString("N2"); //txt_Remain_balanc_supps.ToString("N2");
                                        DB_Add_delete_update_.Database.ds.Tables["Emplyee_account"].Rows[num_indx_Emp][1] = 0;
                                    }
                                    //else if (Convert.ToDouble(txt_Cur_balance.Text) == 0 && Convert.ToDouble(txt_Cur_balance_cred.Text) == 0)
                                    //{
                                    //    double txt_Remain_balanc_supps = Convert.ToDouble(txt_Paid_vall) + Convert.ToDouble(txt_Cur_balance.Text);

                                    //    DB_Add_delete_update_.Database.ds.Tables["Emplyee_account"].Rows[num_indx_Emp][1] = txt_Paid_vall.ToString("N2");//txt_Remain_balanc_supps.ToString("N2");
                                    //    DB_Add_delete_update_.Database.ds.Tables["Emplyee_account"].Rows[num_indx_Emp][2] = 0;//Convert.ToDouble(txt_Remain_balanc.Text).ToString("N2");
                                    //}
                                    else if (Convert.ToDouble(txt_Cur_balance.Text) == 0 && Convert.ToDouble(txt_Cur_balance_cred.Text) >= 0)
                                    {
                                        double txt_Remain_balanc_supps = Convert.ToDouble(txt_Paid_vall) + Convert.ToDouble(txt_Cur_balance_cred.Text);


                                        DB_Add_delete_update_.Database.ds.Tables["Emplyee_account"].Rows[num_indx_Emp][1] = Math.Abs(Convert.ToDouble(txt_Remain_balanc_supps)).ToString("N2");//txt_Remain_balanc_supps.ToString("N2");//txt_Remain_balanc_supps.ToString("N2");
                                        DB_Add_delete_update_.Database.ds.Tables["Emplyee_account"].Rows[num_indx_Emp][2] = 0;
                                    }


                                    else if (Convert.ToDouble(txt_Cur_balance.Text) > 0 && Convert.ToDouble(txt_Cur_balance_cred.Text) == 0 && Convert.ToDouble(txt_Cur_balance.Text) <= txt_Paid_vall)
                                    {
                                        double txt_Remain_balanc_supps = Convert.ToDouble(txt_Paid_vall) - Convert.ToDouble(txt_Cur_balance.Text);

                                        DB_Add_delete_update_.Database.ds.Tables["Emplyee_account"].Rows[num_indx_Emp][1] = Math.Abs(Convert.ToDouble(txt_Remain_balanc_supps)).ToString("N2");// txt_Remain_balanc_supps.ToString("N2");
                                        DB_Add_delete_update_.Database.ds.Tables["Emplyee_account"].Rows[num_indx_Emp][2] = 0;
                                    }

                                }
                                DB_Add_delete_update_.Database.update("Emplyee_account");
                            }


                            //تعديل
                            // لو كان المستفيد مورد يتم تحديث الرصيد

                            if (comBox_beneficiry.SelectedIndex == 0)
                            {
                                num_bef_type1 = 1;
                            }

                            // //لو كان المستفيد عميل يتم تحديث الرصيد 

                            else if (comBox_beneficiry.SelectedIndex == 1)
                            {
                                num_bef_type1 = 2;
                            }
                            ////   لو كان المستفيد موظف يتم تحديث الرصيد
                            ///
                            else if (comBox_beneficiry.SelectedIndex == 2)
                            {

                                num_bef_type1 = 3;
                            }


                            DB_Add_delete_update_.Database.ds.Tables["cash_Exchange"].Rows.Add(Convert.ToInt32(txt_num_Doc.Text),
                                                                                                 lbl_date_time.Text,//
                                                                                                 num_bef_type1,//
                                                                                                 comBox_beneficiry.Text,//

                                                                                                 Convert.ToDouble(txt_Paid_val.Text),//

                                                                                                 num_beneficiry,//
                                                                                                 txt_name_beneficiry.Text,//

                                                                                                 Convert.ToDouble(txt_Cur_balance.Text),//
                                                                                                 Convert.ToDouble(txt_Remain_balanc.Text),//

                                                                                                 comBox_Payment_side.Text, //
                                                                                                 txt_Document_Note.Text,//
                                                                                                 dt_Emp_name_use[1],//
                                                                                                 comBox_Payment_side.SelectedValue,
                                                                                                 //تتعديل
                                                                                                 num_the_type_ss
                                                                                                 ); //
                            //txt_num_Doc.Text = num_beneficiry.ToString();//رقم المستند 

                            DB_Add_delete_update_.Database.update("cash_Exchange");

                            ////////////////////////////////////////////////////////////////////////////////////////
                            String Query = "id_login = " + vr.txt_user_id_Emp.Caption + " And " + "UserName = '" + vr.txt_user_Emp.Caption + "' And isLoock =" + false;
                            DataRow[] dr_unlock = DB_Add_delete_update_.Database.ds.Tables["Unlook_Box"].Select(Query);
                            if (dr_unlock.Count() != 0)
                            {
                                object[] ob_ditils = DB_Add_delete_update_.Database.ds.Tables["unlock_ditils"].Rows.Find(dr_unlock[0][0]).ItemArray;
                                ob_ditils[7] = Convert.ToDouble(ob_ditils[7]) + Convert.ToDouble(txt_Paid_val.Text);
                                new classs_table.Items_Tools().update_Rows_Table_Database("unlock_ditils", ob_ditils[0].ToString(), ob_ditils);
                            }
                            MessageBox.Show("تم الحفظ  ", "good", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            Clear_All_controls();

                        }

                        else
                        {

                            MessageBox.Show("يرجاء ادخال قيمة الصرف ", "Eroor", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            txt_Paid_val.Focus();
                            return;

                        }
                    }

                    else
                    {

                        MessageBox.Show("يرجاء التاكد من رقم واسم المستفيد ", "Eroor", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        txt_num_beneficiry.Focus();
                        return;

                    }

                }


                // لو كان نوع المستفيد مصروفات تشغيل لايوجد كود المستفيد ولا اسم المستفيد ولا الرصيد الحالي ولا الرصيد المتبقي

                else if (comBox_beneficiry.SelectedIndex == 3 && comBox_beneficiry.SelectedIndex != -1)
                {

                    //متغير لرقم المستفيد
                    num_bef_type1 = 4;

                    //لو كان المستفيد اشغال عمل والقيمة المصروفه فارغه  
                    if (txt_Paid_val.Text.Trim() != string.Empty)
                    {

                        //////داله تحقق من المبلغ الموجود في المخزن او الكاشير هل يكفي او لا 
                        //if_storig_And_cashir();

                        // لو كان يرد السداد نقد ومن الكاشير
                        if (dr_casher.Count() != 0)
                        {
                            object[] ob_account_casher = DB_Add_delete_update_.Database.ds.Tables["casher_account"].Rows.Find(dr_casher[0][5]).ItemArray;

                            // مجموع الرصيد في الدرج معا الرصيد السابق
                            double sum_sals_casher_Account = Convert.ToDouble(ob_account_casher[1]);
                            // لو كان اقل من صافي الفاتورة
                            if (sum_sals_casher_Account >= Convert.ToDouble(txt_Paid_val.Text.Trim()))
                            {
                                // ننقص قيمة الفاتورة من رصيد الدرج

                                ob_account_casher[1] = Convert.ToDouble(ob_account_casher[1]) - Convert.ToDouble(txt_Paid_val.Text.Trim());
                                new classs_table.Items_Tools().update_Rows_Table_Database("casher_account", ob_account_casher[0].ToString(), ob_account_casher);
                            }
                            else
                            {
                                MessageBox.Show("المبلغ في الدرج اقل من صافي الفاتورة", "Eroor", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return;

                            }
                        }
                        // لو كان يرد السداد نقد ومن الصندوق
                        else if (dr_fund.Count() != 0)
                        {
                            object[] ob_account_fund = DB_Add_delete_update_.Database.ds.Tables["fund_sals"].Rows.Find(dr_fund[0][4]).ItemArray;

                            double sum_sals_fund_sals = Convert.ToDouble(ob_account_fund[1]);
                            // لو كان اقل من صافي الفاتورة
                            if (sum_sals_fund_sals >= Convert.ToDouble(txt_Paid_val.Text.Trim()))
                            {
                                // ننقص قيمة الفاتورة من رصيد الصندوق
                                ob_account_fund[1] = Convert.ToDouble(ob_account_fund[1]) - Convert.ToDouble(txt_Paid_val.Text.Trim());
                                new classs_table.Items_Tools().update_Rows_Table_Database("fund_sals", ob_account_fund[0].ToString(), ob_account_fund);
                            }
                            else
                            {
                                MessageBox.Show("المبلغ في الصندوق اقل من صافي الفاتورة", "Eroor", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return;

                            }

                        }


                        if (coBox_type_work.Text.Trim() != string.Empty)
                        {
                            DataRow dt_Emp_use = DB_Add_delete_update_.Database.ds.Tables["TB_LOGIN_EMP"].Rows.Find(new object[] { Convert.ToInt32(vr.txt_user_id_Emp.Caption), vr.txt_user_Emp.Caption });//Convert.ToInt32(vr.txt_user_id_Emp.Caption)
                            // if (dt_Emp_use.Count()!=0) {

                            DataRow dt_Emp_name_use = DB_Add_delete_update_.Database.ds.Tables["TB_Employees"].Rows.Find(dt_Emp_use[4]);

                            // يتم اضافه او حفظ مستند الدفع 
                            DB_Add_delete_update_.Database.ds.Tables["cash_Exchange"].Rows.Add(Convert.ToInt32(txt_num_Doc.Text),
                                                                                               lbl_date_time.Text,
                                                                                               num_bef_type1,
                                                                                               comBox_beneficiry.Text,
                                                                                               Convert.ToDouble(txt_Paid_val.Text),
                                                                                               0,
                                                                                               coBox_type_work.Text,
                                                                                               0,
                                                                                               0,
                                                                                               comBox_Payment_side.Text,
                                                                                               txt_Document_Note.Text,
                                                                                               dt_Emp_name_use[1],
                                                                                               //تعديل
                                                                                               comBox_Payment_side.SelectedValue,
                                                                                               //تتعديل
                                                                                               num_the_type_ss);

                            DB_Add_delete_update_.Database.update("cash_Exchange");
                            String Query = "id_login = " + vr.txt_user_id_Emp.Caption + " And " + "UserName = '" + vr.txt_user_Emp.Caption + "' And isLoock =" + false;
                            DataRow[] dr_unlock = DB_Add_delete_update_.Database.ds.Tables["Unlook_Box"].Select(Query);
                            if (dr_unlock.Count() != 0)
                            {
                                object[] ob_ditils = DB_Add_delete_update_.Database.ds.Tables["unlock_ditils"].Rows.Find(dr_unlock[0][0]).ItemArray;
                                ob_ditils[7] = Convert.ToDouble(ob_ditils[7]) + Convert.ToDouble(txt_Paid_val.Text);
                                new classs_table.Items_Tools().update_Rows_Table_Database("unlock_ditils", ob_ditils[0].ToString(), ob_ditils);
                            }
                            MessageBox.Show("تم الحفظ  ", "", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            Clear_All_controls();
                        }

                        else
                        {

                            MessageBox.Show("يرجاء اختيار نوع مصروف التشغيل", "Eroor", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            coBox_type_work.Focus();
                            return;

                        }
                    }
                    else
                    {
                        MessageBox.Show("يرجاء ادخال قيمة الصرف ", "Eroor", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        txt_Paid_val.Focus();
                        return;

                    }
                }

            }

            //اذا لم تختار مستفيد
            else
            {
                MessageBox.Show("يرجاء اختيار مستفيد", "Eroor", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;

            }

        }



        private void txt_Paid_val_TextChanged(object sender, EventArgs e)
        {

        }

        private void comBox_beneficiry_SelectedIndexChanged(object sender, EventArgs e)
        {
            //داله تفعيل معلومات الشخص او يقفلها 
            Enbl_Gro_box_info();


        }


        //داله لتعبئه الكومبو بكس  من جدول  نوع مصاريف التشغيل
        private void tb_type_work()
        {

            DataTable dt_type_work = new DataTable();

            dt_type_work.Columns.Add("code", typeof(int));
            dt_type_work.Columns.Add("name", typeof(string));

            DataRow[] tb_type = DB_Add_delete_update_.Database.ds.Tables["operating_Expenses"].Select();

            int num_count = tb_type.Count();
            for (int i = 0; i < num_count; i++)
            {
                if (Convert.ToBoolean(tb_type[i][2]) == false)
                {
                    dt_type_work.Rows.Add(tb_type[i][0], tb_type[i][1]);
                }
            }


            coBox_type_work.DataSource = dt_type_work;
            coBox_type_work.DisplayMember = "name";
            coBox_type_work.ValueMember = "code";

        }

        //داله لو تم اختيار من الكمبو بكس  مصاريف تشغيل يخفي معلومات الموظف او العميل او المورد 
        private void Enbl_Gro_box_info()
        {


            if (comBox_beneficiry.SelectedIndex == -1 || comBox_beneficiry.SelectedIndex == 0 || comBox_beneficiry.SelectedIndex == 1 || comBox_beneficiry.SelectedIndex == 2)
            {
                groBox_info_beneficiry.Enabled = true;
                coBox_type_work.Visible = false;
                lab_type_work.Visible = false;


            }
            else
            {
                groBox_info_beneficiry.Enabled = false;

                coBox_type_work.Visible = true;
                lab_type_work.Visible = true;



            }




        }
        private void comBox_beneficiry_SelectedValueChanged(object sender, EventArgs e)
        {


        }

        private void btn_close_cash_exchange_Click(object sender, EventArgs e)
        {
            Close();

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void coBox_type_work_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btn_select_beneficiry_Click(object sender, EventArgs e)
        {
            //true1();
            if (Convert.ToInt32(comBox_beneficiry.SelectedValue) == 1)
            {


                cash1 = 1;
                new Item.forms.frm_Supper_prodect().ShowDialog();

            }

            //شرط اذا اختار عميل
            else if (Convert.ToInt32(comBox_beneficiry.SelectedValue) == 2)
            {

                cash1 = 2;
                new Item.forms.Frm_Client_Show().ShowDialog();

            }
            //شرط اذا اختار موظف
            else if (Convert.ToInt32(comBox_beneficiry.SelectedValue) == 3)
            {

                cash1 = 3;
                new Item.forms.Frm_Emplyees_Show().ShowDialog();

            }
        }




        DateTime dtime_new;

        private void timer1_Tick_1(object sender, EventArgs e)
        {

            lbl_date_time.Text = DateTime.Now.ToString("MM/dd/yyyy hh:mm tt");


        }

        private void txt_Paid_val_KeyPress(object sender, KeyPressEventArgs e)
        {

            ////////////////////////
            if (!(char.IsDigit(e.KeyChar) || e.KeyChar == 8))
            {

                e.Handled = true;
            }

            //if (txt_Paid_val.Text.Trim() != string.Empty)
            //{
            //    //يتم هنا اخذ القيمة التوريد وتنقيص من القيمة الحاليه تبع المستفيد ويوضع الناتج في القيمة المتبقيه
            //    txt_Remain_balanc.Text = Convert.ToDouble(Convert.ToDouble(txt_Cur_balance.Text) - Convert.ToDouble(txt_Paid_val.Text)).ToString("N2");
            //}
            //else if (txt_Paid_val.Text.Trim() == string.Empty)
            //{

            //    txt_Remain_balanc.Text = string.Empty;
            //}
        }

        private void txt_Paid_val_TextChanged_1(object sender, EventArgs e)
        {
            if (txt_Paid_val.Text.Trim() != string.Empty)
            {
                int txt_Paid_vall = Convert.ToInt32(txt_Paid_val.Text);

                //يتم هنا اخذ القيمة الصرف وتنقيص من القيمة الحاليه تبع المستفيد ويوضع الناتج في القيمة المتبقيه
                if (Convert.ToDouble(txt_Cur_balance.Text) > 0 && Convert.ToDouble(txt_Cur_balance_cred.Text) == 0 && Convert.ToDouble(txt_Cur_balance.Text) > txt_Paid_vall)
                {
                    double txt_Remain_balanc_supps = Convert.ToDouble(txt_Cur_balance.Text) - Convert.ToDouble(txt_Paid_vall);

                    txt_Remain_balanc.Text = txt_Remain_balanc_supps.ToString("N2");
                }
                //else if (Convert.ToDouble(txt_Cur_balance.Text) == 0 && Convert.ToDouble(txt_Cur_balance_cred.Text) == 0)
                //{
                //    double txt_Remain_balanc_supps = Convert.ToDouble(txt_Paid_vall) + Convert.ToDouble(txt_Cur_balance_cred.Text);

                //    txt_Remain_balanc.Text = txt_Paid_vall.ToString("N2");
                //  // txt_Cur_balance_cred.Text = txt_Remain_balanc_supps.ToString("N2");
                //}
                else if (Convert.ToDouble(txt_Cur_balance.Text) == 0 && Convert.ToDouble(txt_Cur_balance_cred.Text) >= 0)
                {
                    double num = Convert.ToDouble(txt_Cur_balance_cred.Text);
                    double txt_Remain_balanc_supps = Convert.ToDouble(txt_Paid_vall) + Convert.ToDouble(txt_Cur_balance_cred.Text);

                    txt_Remain_balanc.Text = txt_Remain_balanc_supps.ToString("N2");
                    //   //  txt_Cur_balance_cred.Text = txt_Remain_balanc_supps.ToString("N2");//txt_Remain_balanc_supps.ToString("N2");
                }
                else if (Convert.ToDouble(txt_Cur_balance.Text) > 0 && Convert.ToDouble(txt_Cur_balance_cred.Text) == 0 && Convert.ToDouble(txt_Cur_balance.Text) <= txt_Paid_vall)
                {
                    double txt_Remain_balanc_supps = Convert.ToDouble(txt_Paid_vall) - Convert.ToDouble(txt_Cur_balance.Text);

                    txt_Remain_balanc.Text = txt_Remain_balanc_supps.ToString("N2");
                    // txt_Cur_balance_cred.Text = txt_Remain_balanc_supps.ToString("N2");
                }

            }
            else if (txt_Paid_val.Text.Trim() == string.Empty)
            {

                txt_Remain_balanc.Text = null;
            }

        }

        private void Label11_Click(object sender, EventArgs e)
        {

        }

        private void Txt_num_beneficiry_DoubleClick_1(object sender, EventArgs e)
        {

            //شرط اذا اختار مورد
            if (Convert.ToInt32(comBox_beneficiry.SelectedValue) == 1)
            {


                cash1 = 1;
                DB_Add_delete_update_.Database.update("Supplier");
                DB_Add_delete_update_.Database.update("Calc_supply");
                new Item.forms.frm_Supper_prodect().ShowDialog();


            }

            //شرط اذا اختار عميل
            else if (Convert.ToInt32(comBox_beneficiry.SelectedValue) == 2)
            {

                cash1 = 2;

                DB_Add_delete_update_.Database.update("Clien");
                DB_Add_delete_update_.Database.update("Stock_client");
                new Item.forms.Frm_Client_Show().ShowDialog();

            }
            //شرط اذا اختار موظف
            else if (Convert.ToInt32(comBox_beneficiry.SelectedValue) == 3)
            {

                cash1 = 3;
                new Item.forms.Frm_Emplyees_Show().ShowDialog();

            }
        }
    }
}
