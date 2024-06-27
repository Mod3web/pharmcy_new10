using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Manag_ph.Sales.Sals_return
{
    class Save_and_update_unit
    {

        classs_table.Items_Tools to = new classs_table.Items_Tools();
        public void Save_And_update_Item_return()
        {
            var vr = Application.OpenForms["Main"] as Main;
            for (int i = 0; i < vr.dgv_Item_footer_sals_return_dgv.Rows.Count; i++)
            {

                if (Convert.ToDouble(vr.dgv_Item_footer_sals_return_dgv.Rows[i].Cells[5].Value) > 0)
                {
                    DataGridViewComboBoxCell DGV_Prodect = vr.dgv_Item_footer_sals_return_dgv.Rows[i].Cells[3] as DataGridViewComboBoxCell;
                    DataRow[] dr_Item_unit = DB_Add_delete_update_.Database.ds.Tables["unite_items"].Select("item_no = " + vr.dgv_Item_footer_sals_return_dgv.Rows[i].Cells[0].Value);
                    DataRow dr_unit;

                    if (Convert.ToInt32(DGV_Prodect.Value) == 1)
                    {
                        dr_unit = DB_Add_delete_update_.Database.ds.Tables["therpeutic_unite"].Rows.Find(dr_Item_unit[0][1]);
                        //MessageBox.Show(dr_unit[1] + "");
                    }
                    else if (Convert.ToInt32(DGV_Prodect.Value) == 2)
                    {
                        dr_unit = DB_Add_delete_update_.Database.ds.Tables["therpeutic_unite"].Rows.Find(dr_Item_unit[0][2]);
                        //MessageBox.Show(dr_unit[1] + "");
                    }
                    else
                    {
                        dr_unit = DB_Add_delete_update_.Database.ds.Tables["therpeutic_unite"].Rows.Find(dr_Item_unit[0][3]);
                        //MessageBox.Show(dr_unit[1] + "");
                    }
                    object[] ob_Item_sals = DB_Add_delete_update_.Database.ds.Tables["Item_footer_Sals"].Rows.Find(vr.dgv_Item_footer_sals_return_dgv.Rows[i].Cells[17].Value).ItemArray;
                    ob_Item_sals[11] = true;
                    new classs_table.Items_Tools().update_Rows_Table_Database("Item_footer_Sals", ob_Item_sals[0].ToString(), ob_Item_sals);
                    int num_Item_return = new classs_table.Items_Tools().AoutoNumber("Return_Item_sals", "num_Item_return");
                    DB_Add_delete_update_.Database.ds.Tables["Return_Item_sals"].Rows.Add(
                        num_Item_return,
                        ob_Item_sals[0],
                        dr_unit[1],
                         vr.dgv_Item_footer_sals_return_dgv.Rows[i].Cells[5].Value,
                         vr.dgv_Item_footer_sals_return_dgv.Rows[i].Cells[14].Value);
                    DB_Add_delete_update_.Database.update("Return_Item_sals");
                }
            }
        }

        public void Clear_Data_sals_return()
        {
            var vr = Application.OpenForms["Main"] as Main;
            vr.dgv_data_footer_sals_return_dgv.Rows.Clear();
            vr.dgv_Item_footer_sals_return_dgv.Rows.Clear();
            vr.txt_count_sals_return.Text = "0";
            vr.txt_Dicunt_rate_sals_return.Text = "0";
            vr.txt_Dicunt_value_sals_return.Text = "0";
            vr.txt_begin_sals_return.Text = "0.00";
            vr.txt_after_sals_return.Text = "0.00";
            vr.txt_value_sals_return.Text = "0.00";
            vr.txt_num_or_phone_cline_sals_retrn.Text = "";
            vr.txt_name_cline_sals_return.Text = "";
            vr.txt_account_Cline_sals_return.Text = "";
        }
        // دالة لتحديث حسابات العملا في حالت كان نوع الارجاع اجل
        public void Account_Cline()
        {
            var vr = Application.OpenForms["Main"] as Main;
            var vr_cli = Application.OpenForms["frm_save_Acount_Cline_return"] as frm_save_Acount_Cline_return;
            if (vr.txt_account_Cline_sals_return.Text != string.Empty)
            {

                DataRow dr_Clne = DB_Add_delete_update_.Database.ds.Tables["Clien"].Rows.Find(vr.txt_num_or_phone_cline_sals_retrn.Text);
                DataRow dr_Accou_Clne = DB_Add_delete_update_.Database.ds.Tables["Stock_client"].Rows.Find(dr_Clne[10]);

                // التحقق من العميل دائن لو كان مدين نقلب نوع التوريد
                DataRow dt_Emp_use = DB_Add_delete_update_.Database.ds.Tables["TB_LOGIN_EMP"].Rows.Find(new object[] { Convert.ToInt32(vr.txt_user_id_Emp.Caption), vr.txt_user_Emp.Caption });//Convert.ToInt32(vr.txt_user_id_Emp.Caption)

                DataRow dt_Emp_name_use = DB_Add_delete_update_.Database.ds.Tables["TB_Employees"].Rows.Find(dt_Emp_use[4]);
                int id_clin = to.AoutoNumber("Accounts_Clin", "ID_Accoun_Clin");


                if (Convert.ToDouble(dr_Accou_Clne[1]) >= 0 && Convert.ToDouble(dr_Accou_Clne[2]) == 0 && Convert.ToDouble(dr_Accou_Clne[1]) >= Math.Abs(Convert.ToDouble(vr_cli.txt_after_pand_cash.Text)))
                {


                    if (Convert.ToDouble(dr_Accou_Clne[1]) >= 0 && Convert.ToDouble(dr_Accou_Clne[2]) == 0 && Convert.ToDouble(dr_Accou_Clne[1]) > Math.Abs(Convert.ToDouble(vr_cli.txt_after_pand_cash.Text)))
                    {
                        double resoult = Convert.ToDouble(dr_Accou_Clne[1]) - Math.Abs(Convert.ToDouble(vr_cli.txt_after_pand_cash.Text));
                        dr_Accou_Clne[1] = Math.Abs(Convert.ToDouble(resoult.ToString("N2")));
                        dr_Accou_Clne[2] = 0;
                        dr_Accou_Clne[4] = Math.Abs(Convert.ToDouble(resoult.ToString("N2")));
                    }
                    else if (Convert.ToDouble(dr_Accou_Clne[1]) >= 0 && Convert.ToDouble(dr_Accou_Clne[2]) == 0 && Convert.ToDouble(dr_Accou_Clne[1]) <= Math.Abs(Convert.ToDouble(vr_cli.txt_after_pand_cash.Text)))
                    {
                        double resoult = Math.Abs(Convert.ToDouble(vr_cli.txt_after_pand_cash.Text)) - Convert.ToDouble(dr_Accou_Clne[1]);
                        dr_Accou_Clne[2] = Math.Abs(Convert.ToDouble(resoult.ToString("N2")));
                        dr_Accou_Clne[1] = 0;
                        dr_Accou_Clne[4] = Math.Abs(Convert.ToDouble(resoult.ToString("N2")));

                        //    dr_Accou_Clne[2] = "0.00";
                        //   dr_Accou_Clne[1] = Math.Abs(resoult).ToString("N2");
                    }
                    else if (Convert.ToDouble(dr_Accou_Clne[1]) == 0 && Convert.ToDouble(dr_Accou_Clne[2]) >= 0)
                    {
                        double resoult = Convert.ToDouble(dr_Accou_Clne[2]) + Math.Abs(Convert.ToDouble(vr_cli.txt_after_pand_cash.Text));
                        dr_Accou_Clne[2] = Math.Abs(Convert.ToDouble(resoult.ToString("N2")));
                        dr_Accou_Clne[1] = 0;
                        dr_Accou_Clne[4] = Math.Abs(Convert.ToDouble(resoult.ToString("N2")));

                        //    dr_Accou_Clne[2] = "0.00";
                        //   dr_Accou_Clne[1] = Math.Abs(resoult).ToString("N2");
                    }
                    //else if (Convert.ToDouble(dr_Accou_Clne[2]) == 0 && Convert.ToDouble(dr_Accou_Clne[1]) >= 0 && Convert.ToDouble(dr_Accou_Clne[1]) <= Math.Abs(Convert.ToDouble(vr_cli.txt_after_pand_cash.Text)))
                    //{
                    //    double resoult = Math.Abs(Convert.ToDouble(vr_cli.txt_after_pand_cash.Text))-Convert.ToDouble(dr_Accou_Clne[1]) ;
                    //    dr_Accou_Clne[2] = resoult.ToString("N2");
                    //    dr_Accou_Clne[1] = 0;
                    //    dr_Accou_Clne[4] = resoult.ToString("N2");

                    //    //    dr_Accou_Clne[2] = "0.00";
                    //    //   dr_Accou_Clne[1] = Math.Abs(resoult).ToString("N2");
                    //}
                    new classs_table.Items_Tools().update_Rows_Table_Database("Stock_client", dr_Accou_Clne[0].ToString(), dr_Accou_Clne.ItemArray);
                }
                else
                {
                    MessageBox.Show("المبلغ اكبر من حساب العميل", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                DB_Add_delete_update_.Database.ds.Tables["Accounts_Clin"].Rows.Add(
                    id_clin,
                    vr.txt_num_or_phone_cline_sals_retrn.Text,
                    vr.txt_name_cline_sals_return.Text,
                    dt_Emp_name_use[0],
                    dt_Emp_name_use[1],
                    dr_Accou_Clne[1],
                    dr_Accou_Clne[2],
                    "مرتجع فاتورة مبيعات",
                    DateTime.Now,
                    Math.Abs(Convert.ToDouble(vr_cli.txt_after_pand_cash.Text))
                    );
                DB_Add_delete_update_.Database.update("Accounts_Clin");
                update_unit();
            }
        }
        // دالة لتعديل الكميات
        public void update_unit()
        {
            var vr_cli = Application.OpenForms["frm_save_data_return"] as frm_save_data_return;
            var vr_Cline = Application.OpenForms["frm_save_Acount_Cline_return"] as frm_save_Acount_Cline_return;

            var vr = Application.OpenForms["Main"] as Main;

            for (int i = 0; i < vr.dgv_Item_footer_sals_return_dgv.Rows.Count; i++)
            {
                if (Convert.ToInt32(vr.dgv_Item_footer_sals_return_dgv.Rows[i].Cells[5].Value) != 0)
                {
                    DataGridViewComboBoxCell DGVCB = vr.dgv_Item_footer_sals_return_dgv.Rows[i].Cells[3] as DataGridViewComboBoxCell;
                    DataRow dr_Item_update = DB_Add_delete_update_.Database.ds.Tables["Item_storg"].Rows.Find(vr.dgv_Item_footer_sals_return_dgv.Rows[i].Cells[16].Value);
                    DataRow[] dr_count_unit = DB_Add_delete_update_.Database.ds.Tables["unite_items"].Select("item_no =" + vr.dgv_Item_footer_sals_return_dgv.Rows[i].Cells[0].Value);

                    if (Convert.ToInt32(dr_Item_update[12]) == 1) // الوحدة المدخلة كبرا
                    {

                        if (Convert.ToInt32(DGVCB.Value) == 1)
                        {
                            int num_avrg = Convert.ToInt32(dr_count_unit[0][4]);// عدد الوحدة الوسطا
                            int num_smool = Convert.ToInt32(dr_count_unit[0][5]);// عدد الوحدة الوسطا
                            int quity = Convert.ToInt32(vr.dgv_Item_footer_sals_return_dgv.Rows[i].Cells[5].Value);//كمية الوحدة الكبرا
                            int quity_avrg = quity * num_avrg;
                            int quilty_smol = quity_avrg * num_smool;
                            dr_Item_update[1] = Convert.ToInt32(dr_Item_update[1]) + quity;
                            dr_Item_update[13] = Convert.ToInt32(dr_Item_update[13]) + quity_avrg;
                            dr_Item_update[14] = Convert.ToInt32(dr_Item_update[14]) + quilty_smol;


                        }
                        else if (Convert.ToInt32(DGVCB.Value) == 2)// اذاكان في الوحدة الكبرا ويريد التعديل في الوحدة الوسطاء
                        {

                            int num_avrg = Convert.ToInt32(dr_count_unit[0][4]);// عدد الوحدة الوسطا
                            int num_smool = Convert.ToInt32(dr_count_unit[0][5]);// عدد الوحدة الوسطا
                            int quity = Convert.ToInt32(vr.dgv_Item_footer_sals_return_dgv.Rows[i].Cells[5].Value);//كمية الوحدة الوسطا
                            int quity_new = quity / num_avrg;
                            int quilty_smol = num_smool * quity;
                            dr_Item_update[1] = Convert.ToInt32(dr_Item_update[1]) + quity_new;
                            dr_Item_update[13] = Convert.ToInt32(dr_Item_update[13]) + quity;
                            dr_Item_update[14] = Convert.ToInt32(dr_Item_update[14]) + quilty_smol;

                            dr_Item_update[1] = Convert.ToInt32(dr_Item_update[13]) / num_avrg;
                            // لم اكمل التعديل علا الوحدة الصغرا وهو يبحث في الوحدة الكبرا
                        }
                        else if (Convert.ToInt32(DGVCB.Value) == 3)
                        {

                            int num_avrg = Convert.ToInt32(dr_count_unit[0][4]);// عدد الوحدة الوسطا
                            int num_smool = Convert.ToInt32(dr_count_unit[0][5]);// عدد الوحدة الصغرا
                            int quity = Convert.ToInt32(vr.dgv_Item_footer_sals_return_dgv.Rows[i].Cells[5].Value);//كمية الوحدة الصغرا
                            int quity_new_Avrg = quity / num_smool;// ايجاد الكمية الوسطا
                            int quilty_new_Qobra = quity_new_Avrg / num_avrg;// ايجاد الكمية الكبرا
                            dr_Item_update[1] = Convert.ToInt32(dr_Item_update[1]) + quilty_new_Qobra;
                            dr_Item_update[13] = Convert.ToInt32(dr_Item_update[13]) + quity_new_Avrg;
                            dr_Item_update[14] = Convert.ToInt32(dr_Item_update[14]) + quity;


                            dr_Item_update[13] = Convert.ToInt32(dr_Item_update[14]) / num_smool;
                            dr_Item_update[1] = Convert.ToInt32(dr_Item_update[13]) / num_avrg;


                        }


                    }
                    else if (Convert.ToInt32(dr_Item_update[12]) == 2)
                    {
                        if (Convert.ToInt32(DGVCB.Value) == 2)
                        {

                            int num_smool = Convert.ToInt32(dr_count_unit[0][5]);// عدد الوحدة الصغرا
                            int quity = Convert.ToInt32(vr.dgv_Item_footer_sals_return_dgv.Rows[i].Cells[5].Value);//كمية الوحدة الوسطاء
                            int quilty_new_smoll = quity * num_smool;// ايجاد الكمية الكبرا
                            dr_Item_update[1] = Convert.ToInt32(dr_Item_update[1]) + quity;
                            dr_Item_update[14] = Convert.ToInt32(dr_Item_update[14]) + quilty_new_smoll;

                        }
                        else if (Convert.ToInt32(DGVCB.Value) == 3)
                        {
                            int num_smool = Convert.ToInt32(dr_count_unit[0][5]);// عدد الوحدة الصغرا
                            int quity = Convert.ToInt32(vr.dgv_Item_footer_sals_return_dgv.Rows[i].Cells[5].Value);//كمية الوحدة الصغرا
                            int quilty_new_avrg = quity / num_smool;// ايجاد الكمية الكبرا
                            dr_Item_update[1] = Convert.ToInt32(dr_Item_update[1]) + quilty_new_avrg;
                            dr_Item_update[14] = Convert.ToInt32(dr_Item_update[14]) + quity;

                            dr_Item_update[1] = Convert.ToInt32(dr_Item_update[14]) / num_smool;

                        }


                    }
                    else if (Convert.ToInt32(dr_Item_update[12]) == 3)
                    {
                        int quity = Convert.ToInt32(vr.dgv_Item_footer_sals_return_dgv.Rows[i].Cells[5].Value);//كمية الوحدة الصغرا
                        dr_Item_update[1] = Convert.ToInt32(dr_Item_update[1]) + quity;
                        dr_Item_update[14] = Convert.ToInt32(dr_Item_update[14]) + quity;

                    }

                    new classs_table.Items_Tools().update_Rows_Table_Database("Item_storg", dr_Item_update[0].ToString(), dr_Item_update.ItemArray);
                }
            }

            object[] dr_DataFoo_r = DB_Add_delete_update_.Database.ds.Tables["Date_Footer_Sals"].Rows.Find(vr.dgv_data_footer_sals_return_dgv.CurrentRow.Cells[0].Value).ItemArray;

            // تعدي حساب الدرج
            if (vr.rb_cash_sals_return.Checked)
            {
                DataRow dr_casher = DB_Add_delete_update_.Database.ds.Tables["casher"].Rows.Find(vr.txt_casher_num_sals_return.Text);
                object[] bo_Account_chaser = DB_Add_delete_update_.Database.ds.Tables["casher_account"].Rows.Find(dr_casher[5]).ItemArray;
                double resout = Convert.ToDouble(bo_Account_chaser[1]) - Convert.ToDouble(vr.txt_after_sals_return.Text);
                // التحقق من الكاشير انهو يوجد رصيد
                if (resout >= 0)
                {
                    bo_Account_chaser[1] = Convert.ToDouble(Convert.ToDouble(bo_Account_chaser[1]) - Convert.ToDouble(vr.txt_after_sals_return.Text)).ToString("N2");
                    new classs_table.Items_Tools().update_Rows_Table_Database("casher_account", bo_Account_chaser[0].ToString(), bo_Account_chaser);
                }
                else
                {
                    MessageBox.Show("لايوجد رصيد في الصندوق", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                dr_DataFoo_r[13] = Convert.ToDouble(Convert.ToDouble(dr_DataFoo_r[13]) - Convert.ToDouble(vr.txt_after_sals_return.Text)).ToString();
            }

            // اضافة بيانات المرتجع
            int num_return_foot = new classs_table.Items_Tools().AoutoNumber("Return_footer_sals", "num_sals_return");
            DB_Add_delete_update_.Database.ds.Tables["Return_footer_sals"].Rows.Add(
                num_return_foot,
                vr.dgv_data_footer_sals_return_dgv.CurrentRow.Cells[0].Value,
                vr.txt_num_or_phone_cline_sals_retrn.Text != string.Empty ? vr.txt_num_or_phone_cline_sals_retrn.Text : null,
                vr.txt_after_sals_return.Text,
                vr.dgv_data_footer_sals_return_dgv.CurrentRow.Cells[2].Value,
                vr.dgv_data_footer_sals_return_dgv.CurrentRow.Cells[8].Value,
                vr.txt_Empoly_number.Caption,
                DateTime.Now);
            DB_Add_delete_update_.Database.update("Return_footer_sals");
            dr_DataFoo_r[3] = Convert.ToDouble(Convert.ToDouble(dr_DataFoo_r[3]) - Convert.ToDouble(vr.txt_value_sals_return.Text)).ToString();
            dr_DataFoo_r[6] = Convert.ToDouble(Convert.ToDouble(dr_DataFoo_r[6]) - Convert.ToDouble(vr.txt_after_sals_return.Text)).ToString();
            dr_DataFoo_r[16] = true;






            for (int i = 0; i < vr.dgv_Item_footer_sals_return_dgv.Rows.Count; i++)
            {
                if (Convert.ToInt32(vr.dgv_Item_footer_sals_return_dgv.Rows[i].Cells[5].Value) != 0)
                {
                    DataGridViewComboBoxCell DGVCB = vr.dgv_Item_footer_sals_return_dgv.Rows[i].Cells[3] as DataGridViewComboBoxCell;
                    DataRow dr_Item_update = DB_Add_delete_update_.Database.ds.Tables["Item_footer_Sals_And_Return"].Rows.Find( vr.dgv_Item_footer_sals_return_dgv.Rows[i].Cells[17].Value);
                    DataRow[] dr_count_unit = DB_Add_delete_update_.Database.ds.Tables["unite_items"].Select("item_no =" + dr_Item_update[1]);

                    

                    if (Convert.ToInt32(dr_Item_update[5]) == 1)
                    {

                        if (Convert.ToInt32(DGVCB.Value) == 1)
                        {
                            int num_avrg = Convert.ToInt32(dr_count_unit[0][4]);// عدد الوحدة الوسطا
                            int num_smool = Convert.ToInt32(dr_count_unit[0][5]);// عدد الوحدة الوسطا
                            int quity = Convert.ToInt32(vr.dgv_Item_footer_sals_return_dgv.Rows[i].Cells[5].Value);//كمية الوحدة الكبرا
                            int quity_avrg = quity * num_avrg;
                            int quilty_smol = quity_avrg * num_smool;
                            dr_Item_update[4] = Convert.ToInt32(dr_Item_update[4]) - quity;
                            dr_Item_update[12] = Convert.ToInt32(dr_Item_update[12]) - quity_avrg;
                            dr_Item_update[13] = Convert.ToInt32(dr_Item_update[13]) - quilty_smol;

                        }
                        else if (Convert.ToInt32(DGVCB.Value) == 2)// اذاكان في الوحدة الكبرا ويريد التعديل في الوحدة الوسطاء
                        {

                            int num_avrg = Convert.ToInt32(dr_count_unit[0][4]);// عدد الوحدة الوسطا
                            int num_smool = Convert.ToInt32(dr_count_unit[0][5]);// عدد الوحدة الوسطا
                            int quity = Convert.ToInt32(vr.dgv_Item_footer_sals_return_dgv.Rows[i].Cells[5].Value);//كمية الوحدة الوسطا
                            int quity_new = quity / num_avrg;
                            int quilty_smol = num_smool * quity;
                            dr_Item_update[4] = Convert.ToInt32(dr_Item_update[4]) - quity_new;
                            dr_Item_update[12] = Convert.ToInt32(dr_Item_update[12]) - quity;
                            dr_Item_update[13] = Convert.ToInt32(dr_Item_update[13]) - quilty_smol;

                            dr_Item_update[4] = Convert.ToInt32(dr_Item_update[12]) / num_avrg;

                            // لم اكمل التعديل علا الوحدة الصغرا وهو يبحث في الوحدة الكبرا
                        }
                        else if (Convert.ToInt32(DGVCB.Value) == 3)
                        {

                            int num_avrg = Convert.ToInt32(dr_count_unit[0][4]);// عدد الوحدة الوسطا
                            int num_smool = Convert.ToInt32(dr_count_unit[0][5]);// عدد الوحدة الصغرا
                            int quity = Convert.ToInt32(vr.dgv_Item_footer_sals_return_dgv.Rows[i].Cells[5].Value);//كمية الوحدة الصغرا
                            int quity_new_Avrg = quity / num_smool;// ايجاد الكمية الوسطا
                            int quilty_new_Qobra = quity_new_Avrg / num_avrg;// ايجاد الكمية الكبرا
                            dr_Item_update[4] = Convert.ToInt32(dr_Item_update[4]) - quilty_new_Qobra;
                            dr_Item_update[12] = Convert.ToInt32(dr_Item_update[12]) - quity_new_Avrg;
                            dr_Item_update[13] = Convert.ToInt32(dr_Item_update[13]) - quity;


                            dr_Item_update[12] = Convert.ToInt32(dr_Item_update[13]) / num_smool;
                            dr_Item_update[4] = Convert.ToInt32(dr_Item_update[12]) / num_avrg;

                        }

                    }
                    else if (Convert.ToInt32(dr_Item_update[5]) == 2)
                    {
                        if (Convert.ToInt32(DGVCB.Value) == 2)
                        {
                            int num_smool = Convert.ToInt32(dr_count_unit[0][5]);// عدد الوحدة الصغرا
                            int quity = Convert.ToInt32(vr.dgv_Item_footer_sals_return_dgv.Rows[i].Cells[5].Value);//كمية الوحدة الوسطاء
                            int quilty_new_smoll = quity * num_smool;// ايجاد الكمية الكبرا
                            dr_Item_update[4] = Convert.ToInt32(dr_Item_update[4]) - quity;
                            dr_Item_update[13] = Convert.ToInt32(dr_Item_update[13]) - quilty_new_smoll;

                        }
                        else if (Convert.ToInt32(DGVCB.Value) == 3)
                        {
                            int num_smool = Convert.ToInt32(dr_count_unit[0][5]);// عدد الوحدة الصغرا
                            int quity = Convert.ToInt32(vr.dgv_Item_footer_sals_return_dgv.Rows[i].Cells[5].Value);//كمية الوحدة الصغرا
                            int quilty_new_avrg = quity / num_smool;// ايجاد الكمية الكبرا
                            dr_Item_update[4] = Convert.ToInt32(dr_Item_update[4]) - quilty_new_avrg;
                            dr_Item_update[13] = Convert.ToInt32(dr_Item_update[13]) - quity;

                            dr_Item_update[4] = Convert.ToInt32(dr_Item_update[13]) / num_smool;

                        }

                    }
                    else if (Convert.ToInt32(dr_Item_update[5]) == 3)
                    {
                        int quity = Convert.ToInt32(vr.dgv_Item_footer_sals_return_dgv.Rows[i].Cells[5].Value);//كمية الوحدة الصغرا
                        dr_Item_update[4] = Convert.ToInt32(dr_Item_update[4]) - quity;
                        dr_Item_update[13] = Convert.ToInt32(dr_Item_update[13]) - quity;
                    }
                    new classs_table.Items_Tools().update_Rows_Table_Database("Item_footer_Sals_And_Return", dr_Item_update[0].ToString(), dr_Item_update.ItemArray);
                }
             
            }


           








            if (vr.rb_cash_sals_return.Checked)
            {
                String Query = "id_login = " + vr.txt_user_id_Emp.Caption + " And " + "UserName = '" + vr.txt_user_Emp.Caption + "' And isLoock =" + false;
                DataRow[] dr_unlock = DB_Add_delete_update_.Database.ds.Tables["Unlook_Box"].Select(Query);
                if (dr_unlock.Count() != 0)
                {
                    object[] ob_ditils = DB_Add_delete_update_.Database.ds.Tables["unlock_ditils"].Rows.Find(dr_unlock[0][0]).ItemArray;
                    ob_ditils[6] = Convert.ToDouble(ob_ditils[6]) + Convert.ToDouble(vr_cli.txt_sals_begin_cash.Text);
                    new classs_table.Items_Tools().update_Rows_Table_Database("unlock_ditils", ob_ditils[0].ToString(), ob_ditils);
                }
            }
            else if (vr.rb_yup_sals_return.Checked)
            {
                String Query = "id_login = " + vr.txt_user_id_Emp.Caption + " And " + "UserName = '" + vr.txt_user_Emp.Caption + "' And isLoock =" + false;
                DataRow[] dr_unlock = DB_Add_delete_update_.Database.ds.Tables["Unlook_Box"].Select(Query);
                if (dr_unlock.Count() != 0)
                {
                    if (vr_Cline.txt_sals_pand_cash.Text.Trim() != string.Empty)
                    {
                        object[] ob_ditils = DB_Add_delete_update_.Database.ds.Tables["unlock_ditils"].Rows.Find(dr_unlock[0][0]).ItemArray;
                        ob_ditils[6] = Convert.ToDouble(ob_ditils[6]) + Convert.ToDouble(vr_Cline.txt_sals_pand_cash.Text);
                        new classs_table.Items_Tools().update_Rows_Table_Database("unlock_ditils", ob_ditils[0].ToString(), ob_ditils);
                    }
                }
            }



            new classs_table.Items_Tools().update_Rows_Table_Database("Date_Footer_Sals", dr_DataFoo_r[0].ToString(), dr_DataFoo_r);
            Save_And_update_Item_return();
            MessageBox.Show("تم تحديث البيانات بنجاح", "Ssccoufle", MessageBoxButtons.OK, MessageBoxIcon.Information);
            Clear_Data_sals_return();
        }

    }
}
