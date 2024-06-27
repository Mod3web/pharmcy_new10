using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Manag_ph.Sales.Footer_sals;

namespace Manag_ph.Sales
{
    class Save_Footer_Sals
    {
        object[] ob_cline;
        object[] ob_cline_Account;
        classs_table.Items_Tools to = new classs_table.Items_Tools();
        public void Save_Footer_Item()
        {
            var dr = Application.OpenForms["Main"] as Main;
            var dr_frm = Application.OpenForms["frm_Save_footer_sals"] as frm_Save_footer_sals;
            var dr_frm_Cli = Application.OpenForms["frm_save_sals_Cline"] as frm_save_sals_Cline;
            if (dr.dgv_sals_dgv.CurrentRow != null)
            {


                if (dr.rb_cash_sals.Checked || dr.rb_yup_sals.Checked)
                {

                    int Type_pross_sas = 1;
                    if (dr.rb_yup_sals.Checked)
                    {
                        Type_pross_sas = 2;

                        ob_cline = DB_Add_delete_update_.Database.ds.Tables["Clien"].Rows.Find(dr.txt_num_cline_sals.Text.Trim()).ItemArray;
                        ob_cline_Account = DB_Add_delete_update_.Database.ds.Tables["Stock_client"].Rows.Find(ob_cline[10]).ItemArray;
                        // التحقق من المبغ المتبقي اكبر اصغر من حد التعامل
                       
                        double sum = Math.Abs(Convert.ToDouble(dr_frm_Cli.txt_after_pand_cash.Text)) + Convert.ToDouble(ob_cline_Account[1]);                    ///Convert.ToDouble(ob_cline[7])
                        // التحقق من المبغ المتبقي اكبر اصغر من حد التعامل
                        if (Convert.ToDouble(ob_cline[9]) == 0)
                        {

                        }
                        //txt_after_pand_cash
                        else if (Math.Abs(Convert.ToDouble(dr_frm_Cli.txt_after_pand_cash.Text)) > Convert.ToDouble(ob_cline[9]))
                        {
                            MessageBox.Show("المبغ المتبقي اكبر من حد الفاتورة مع العميل");
                            return;
                        }
                        else if ((Math.Abs(Convert.ToDouble(dr_frm_Cli.txt_after_pand_cash.Text)) + Convert.ToDouble(ob_cline_Account[1])) > Convert.ToDouble(ob_cline[7]))
                        {
                            MessageBox.Show("المبغ المتبقي اكبر من حد التعامل مع العميل");
                            return;
                        }


                    }
               
                    // حفظ بيانات الفاتورة
                    int num_DateFoot = new classs_table.Items_Tools().AoutoNumber("Date_Footer_Sals", "num_foot_sals");
                    DB_Add_delete_update_.Database.ds.Tables["Date_Footer_Sals"].Rows.Add(
                        num_DateFoot,// رقم الفاتورة
                        num_DateFoot.ToString()// الباركود
                        , DateTime.Now,// تاريخ الفاتورة
                       dr.txt_begin_Dicount_All_sals.Text,// المبلغ قبل الخصوم
                       dr.txt_Dicount_Rate_All_sals.Text,// خص نسبة
                       dr.txt_Dicount_value_All_sals.Text,// خصم قيمة
                       dr.txt_end_Dico_All_sals.Text,// صافي الحساب
                        Type_pross_sas,// نوع عملية البيع واحد يعني كاش
                                       /* dr.txt_user_id_Emp.Caption,/*//// رقم الموضف
                       dr.txt_Empoly_number.Caption,
                        dr.dgv_sals_dgv.RowCount,// عدد الاصناف
                        dr.txt_id_storg_sels.Text,// رقم المخزن
                        dr.txt_id_casher.Text, // رقم الكاشي
                        dr.txt_name_cline_sals.Text,// اسم العميل ان وجد
                       dr.rb_yup_sals.Checked == true ? dr_frm_Cli.txt_sals_pand_cash.Text: dr_frm.txt_sals_begin_cash.Text,// المبلغ المدفوع
                         dr.rb_yup_sals.Checked == true ? Math.Abs(Convert.ToDouble(dr_frm_Cli.txt_after_pand_cash.Text)).ToString("N2") : dr_frm.txt_after_pand_cash.Text,// المبلغ المتبقي
                        dr.txt_note_footer_sals.Text,false);
                    DB_Add_delete_update_.Database.update("Date_Footer_Sals");


                    DataRow dt_Emp_name_use = DB_Add_delete_update_.Database.ds.Tables["TB_Employees"].Rows.Find(dr.txt_Empoly_number.Caption);
                    int id_clin = to.AoutoNumber("Accounts_Clin", "ID_Accoun_Clin");

                    if (dr.rb_yup_sals.Checked)
                    {

                        //ob_cline =
                        double resoult = Convert.ToDouble(ob_cline_Account[1]) - Math.Abs(Convert.ToDouble(dr_frm_Cli.txt_after_pand_cash.Text));

                        if (Convert.ToDouble(ob_cline_Account[1])>=0 && Convert.ToDouble(ob_cline_Account[2]) == 0 )
                        {
                            double resoult1 = Convert.ToDouble(ob_cline_Account[1]) + Math.Abs(Convert.ToDouble(dr_frm_Cli.txt_after_pand_cash.Text));
                            ob_cline_Account[1] = Math.Abs(Convert.ToDouble(resoult1.ToString("N2")));
                            ob_cline_Account[2] = 0;
                            ob_cline_Account[4] = Math.Abs(Convert.ToDouble(resoult1.ToString("N2")));
                        }
                        else if (Convert.ToDouble(ob_cline_Account[1]) == 0 && Convert.ToDouble(ob_cline_Account[2]) >= 0 && Convert.ToDouble(ob_cline_Account[2]) > Math.Abs(Convert.ToDouble(dr_frm_Cli.txt_after_pand_cash.Text)))
                        {
                            double resoult2 = Convert.ToDouble(ob_cline_Account[2]) - Math.Abs(Convert.ToDouble(dr_frm_Cli.txt_after_pand_cash.Text));
                            ob_cline_Account[1] = 0;
                            ob_cline_Account[2] = Math.Abs(Convert.ToDouble(resoult2.ToString("N2")));
                            ob_cline_Account[4] = Math.Abs(Convert.ToDouble(resoult2.ToString("N2")));
                        }
                        else if (Convert.ToDouble(ob_cline_Account[1]) == 0 && Convert.ToDouble(ob_cline_Account[2]) >= 0 && Convert.ToDouble(ob_cline_Account[2]) < Math.Abs(Convert.ToDouble(dr_frm_Cli.txt_after_pand_cash.Text)))
                        {
                            double resoult3 = Convert.ToDouble(ob_cline_Account[2]) - Math.Abs(Convert.ToDouble(dr_frm_Cli.txt_after_pand_cash.Text));
                            ob_cline_Account[1] = Math.Abs(Convert.ToDouble(resoult3.ToString("N2")));
                            ob_cline_Account[2] = 0;
                            ob_cline_Account[4] = Math.Abs(Convert.ToDouble(resoult3.ToString("N2")));
                        }
                        ////////////////////////

                        DB_Add_delete_update_.Database.ds.Tables["Accounts_Clin"].Rows.Add(
                                 id_clin,
                                 dr.txt_num_cline_sals.Text,
                                 dr.txt_name_cline_sals.Text,
                                 dt_Emp_name_use[0],
                                 dt_Emp_name_use[1],
                                 ob_cline_Account[1],
                                 ob_cline_Account[2],
                                 " فاتورة مبيعات",
                                 DateTime.Now,
                                 Math.Abs(Convert.ToDouble(dr_frm_Cli.txt_after_pand_cash.Text))
                                 );
                        DB_Add_delete_update_.Database.update("Accounts_Clin");
                        DB_Add_delete_update_.Database.update("Stock_client");
                        //ob_cline_Account[2] = Convert.ToDouble(Convert.ToDouble(ob_cline_Account[2]) + Math.Abs(Convert.ToDouble(dr_frm_Cli.txt_after_pand_cash.Text))).ToString("N2");
                        new classs_table.Items_Tools().update_Rows_Table_Database("Stock_client", ob_cline_Account[0].ToString(), ob_cline_Account);// تحديث حسابات العميل 
                        int num_clin_ffo_au = new classs_table.Items_Tools().AoutoNumber("cline_footer", "num_okay");// اجاد رقم بيانات الفاتورة الاجل
                        DB_Add_delete_update_.Database.ds.Tables["cline_footer"].Rows.Add(num_clin_ffo_au, num_DateFoot, ob_cline[0], dr_frm_Cli.txt_sals_pand_cash.Text, Math.Abs(Convert.ToDouble(dr_frm_Cli.txt_after_pand_cash.Text)));// اضافة بيانات العميل والفاتورة والمدفوع والباقي
                        DB_Add_delete_update_.Database.update("cline_footer");
                    }

                    for (int i = 0; i < dr.dgv_sals_dgv.RowCount; i++)
                    {
                        int num_Item_storg = Convert.ToInt32(dr.dgv_sals_dgv.Rows[i].Cells[15].Value);
                        object[] dr_Item_update = DB_Add_delete_update_.Database.ds.Tables["Item_storg"].Rows.Find(num_Item_storg).ItemArray;
                        DataGridViewComboBoxCell DGVCB = dr.dgv_sals_dgv.Rows[i].Cells[4] as DataGridViewComboBoxCell;

                        // حفظ اصناف الفاتورة
                        int num_Item_Foot = new classs_table.Items_Tools().AoutoNumber("Item_footer_Sals", "num_Item_sals");
                        DB_Add_delete_update_.Database.ds.Tables["Item_footer_Sals"].Rows.Add(
                            num_Item_Foot,
                            dr.dgv_sals_dgv.Rows[i].Cells[1].Value,
                            num_DateFoot,
                            dr.dgv_sals_dgv.Rows[i].Cells[15].Value,
                            dr.dgv_sals_dgv.Rows[i].Cells[5].Value,
                            DGVCB.Value,
                              dr.dgv_sals_dgv.Rows[i].Cells[9].Value,
                              dr.dgv_sals_dgv.Rows[i].Cells[10].Value,
                              dr.dgv_sals_dgv.Rows[i].Cells[11].Value,
                              dr.dgv_sals_dgv.Rows[i].Cells[12].Value,
                              dr.dgv_sals_dgv.Rows[i].Cells[13].Value,
                              false);



                        DataRow[] dr_unit_All = DB_Add_delete_update_.Database.ds.Tables["unite_items"].Select("item_no = " + dr.dgv_sals_dgv.Rows[i].Cells[1].Value);
                        int Qutly = Convert.ToInt32(dr.dgv_sals_dgv.Rows[i].Cells[5].Value);
                        int unit_num = 0;
                        int quity_avrg2 = 0;
                        int quity_smool = 0;
                        if (Convert.ToInt32(DGVCB.Value) == 1)
                        {
                            int num_avrg = Convert.ToInt32(dr_unit_All[0][4]);
                            int num_smool = Convert.ToInt32(dr_unit_All[0][5]);
                            quity_avrg2 = Qutly * num_avrg;
                            quity_smool = quity_avrg2 * num_smool;
                            unit_num = 1;
                        }
                        else if (Convert.ToInt32(DGVCB.Value) == 2)
                        {
                            int num_smool = Convert.ToInt32(dr_unit_All[0][5]);
                            quity_smool = Qutly * num_smool;

                            unit_num = 2;
                        }
                        else
                        {
                            quity_smool = Qutly;
                            unit_num = 3;
                        }


                        int num_Item_Foot_and_Return = new classs_table.Items_Tools().AoutoNumber("Item_footer_Sals_And_Return", "num_Item_sals");
                        DB_Add_delete_update_.Database.ds.Tables["Item_footer_Sals_And_Return"].Rows.Add(
                            num_Item_Foot_and_Return,
                            dr.dgv_sals_dgv.Rows[i].Cells[1].Value,
                            num_DateFoot,
                            dr.dgv_sals_dgv.Rows[i].Cells[15].Value,
                            dr.dgv_sals_dgv.Rows[i].Cells[5].Value,
                            DGVCB.Value,
                              dr.dgv_sals_dgv.Rows[i].Cells[9].Value,
                              dr.dgv_sals_dgv.Rows[i].Cells[10].Value,
                              dr.dgv_sals_dgv.Rows[i].Cells[11].Value,
                              dr.dgv_sals_dgv.Rows[i].Cells[12].Value,
                              dr.dgv_sals_dgv.Rows[i].Cells[13].Value,
                              false,
                              quity_avrg2,
                              quity_smool
                              );


                        // تعديل الكميات في قاعدة البيانات
                        if (Convert.ToInt32(dr_Item_update[12]) == 1)
                        {
                            if (Convert.ToInt32(DGVCB.Value) == 1)
                            {

                                int num = Convert.ToInt32(dr.dgv_sals_dgv.Rows[i].Cells[1].Value);
                                DataRow[] dr_num_avrg = DB_Add_delete_update_.Database.ds.Tables["unite_items"].Select("item_no =" + num);
                                int num_avrg = Convert.ToInt32(dr_num_avrg[0][4]);// عدد الوحدة الوسطا
                                int num_smool = Convert.ToInt32(dr_num_avrg[0][5]);// عدد الوحدة الوسطا
                                int quity = Convert.ToInt32(dr.dgv_sals_dgv.Rows[i].Cells[7].Value) - Convert.ToInt32(dr.dgv_sals_dgv.Rows[i].Cells[5].Value);//كمية الوحدة الكبرا
                                int quity_avrg = quity * num_avrg;
                                int quilty_smol = quity_avrg * num_smool;
                                dr_Item_update[1] = quity;
                                dr_Item_update[13] = quity_avrg;
                                dr_Item_update[14] = quilty_smol;
                            }
                            else if (Convert.ToInt32(DGVCB.Value) == 2)// اذاكان في الوحدة الكبرا ويريد التعديل في الوحدة الوسطاء
                            {
                                int num = Convert.ToInt32(dr.dgv_sals_dgv.Rows[i].Cells[1].Value);
                                DataRow[] dr_num_avrg = DB_Add_delete_update_.Database.ds.Tables["unite_items"].Select("item_no =" + num);
                                int num_avrg = Convert.ToInt32(dr_num_avrg[0][4]);// عدد الوحدة الوسطا
                                int num_smool = Convert.ToInt32(dr_num_avrg[0][5]);// عدد الوحدة الوسطا
                                int quity = Convert.ToInt32(dr.dgv_sals_dgv.Rows[i].Cells[7].Value) - Convert.ToInt32(dr.dgv_sals_dgv.Rows[i].Cells[5].Value);//كمية الوحدة الوسطا
                                int quity_new = quity / num_avrg;
                                int quilty_smol = num_smool * quity;
                                dr_Item_update[1] = quity_new;
                                dr_Item_update[13] = quity;
                                dr_Item_update[14] = quilty_smol;

                                // لم اكمل التعديل علا الوحدة الصغرا وهو يبحث في الوحدة الكبرا
                            }
                            else if (Convert.ToInt32(DGVCB.Value) == 3)
                            {

                                int num = Convert.ToInt32(dr.dgv_sals_dgv.Rows[i].Cells[1].Value);
                                DataRow[] dr_num_avrg = DB_Add_delete_update_.Database.ds.Tables["unite_items"].Select("item_no =" + num);
                                int num_avrg = Convert.ToInt32(dr_num_avrg[0][4]);// عدد الوحدة الوسطا
                                int num_smool = Convert.ToInt32(dr_num_avrg[0][5]);// عدد الوحدة الصغرا
                                int quity = Convert.ToInt32(dr.dgv_sals_dgv.Rows[i].Cells[7].Value) - Convert.ToInt32(dr.dgv_sals_dgv.Rows[i].Cells[5].Value);//كمية الوحدة الصغرا
                                int quity_new_Avrg = quity / num_smool;// ايجاد الكمية الوسطا
                                int quilty_new_Qobra = quity_new_Avrg / num_avrg;// ايجاد الكمية الكبرا
                                dr_Item_update[1] = quilty_new_Qobra;
                                dr_Item_update[13] = quity_new_Avrg;
                                dr_Item_update[14] = quity;

                            }

                        }
                        else if (Convert.ToInt32(dr_Item_update[12]) == 2)
                        {


                            if (Convert.ToInt32(DGVCB.Value) == 2)
                            {

                                int num = Convert.ToInt32(dr.dgv_sals_dgv.Rows[i].Cells[1].Value);
                                DataRow[] dr_num_avrg = DB_Add_delete_update_.Database.ds.Tables["unite_items"].Select("item_no =" + num);
                                int num_smool = Convert.ToInt32(dr_num_avrg[0][5]);// عدد الوحدة الصغرا
                                int quity = Convert.ToInt32(dr.dgv_sals_dgv.Rows[i].Cells[7].Value) - Convert.ToInt32(dr.dgv_sals_dgv.Rows[i].Cells[5].Value); ;//كمية الوحدة الوسطاء
                                int quilty_new_smoll = quity * num_smool;// ايجاد الكمية الكبرا
                                dr_Item_update[1] = quity;
                                dr_Item_update[14] = quilty_new_smoll;

                            }
                            else if (Convert.ToInt32(DGVCB.Value) == 3)
                            {

                                int num = Convert.ToInt32(dr.dgv_sals_dgv.Rows[i].Cells[1].Value);
                                DataRow[] dr_num_avrg = DB_Add_delete_update_.Database.ds.Tables["unite_items"].Select("item_no =" + num);
                                int num_smool = Convert.ToInt32(dr_num_avrg[0][5]);// عدد الوحدة الصغرا
                                int quity = Convert.ToInt32(dr.dgv_sals_dgv.Rows[i].Cells[7].Value) - Convert.ToInt32(dr.dgv_sals_dgv.Rows[i].Cells[5].Value);//كمية الوحدة الصغرا
                                int quilty_new_avrg = quity / num_smool;// ايجاد الكمية الكبرا
                                dr_Item_update[1] = quilty_new_avrg;
                                dr_Item_update[14] = quity;

                            }

                        }
                        else if (Convert.ToInt32(dr_Item_update[12]) == 3)
                        {
                            int quity = Convert.ToInt32(dr.dgv_sals_dgv.Rows[i].Cells[7].Value) - Convert.ToInt32(dr.dgv_sals_dgv.Rows[i].Cells[5].Value);//كمية الوحدة الصغرا
                            dr_Item_update[1] = quity;
                            dr_Item_update[14] = quity;
                        }


                        DB_Add_delete_update_.Database.update("Item_footer_Sals");
                        DB_Add_delete_update_.Database.update("Item_footer_Sals_And_Return");
                        new classs_table.Items_Tools().update_Rows_Table_Database("Item_storg", dr_Item_update[0].ToString(), dr_Item_update);

                    }

                    object[] ob_casher = DB_Add_delete_update_.Database.ds.Tables["casher"].Rows.Find(dr.txt_id_casher.Text).ItemArray;
                    object[] ob_casher_Account = DB_Add_delete_update_.Database.ds.Tables["casher_account"].Rows.Find(ob_casher[5]).ItemArray;
                    if (dr.rb_yup_sals.Checked)
                    {
                        // لوكان مفعل اجل يحفظ الباقي من الفاتورة
                        ob_casher_Account[1] = Convert.ToDouble(Convert.ToDouble(ob_casher_Account[1]) + Convert.ToDouble(dr_frm_Cli.txt_sals_pand_cash.Text)).ToString("N2");

                    }
                    else
                    {
                        // لو كان كاش يحفظ المبلغ كامل
                        ob_casher_Account[1] = Convert.ToDouble(Convert.ToDouble(ob_casher_Account[1]) + Convert.ToDouble(dr.txt_end_Dico_All_sals.Text)).ToString("N2");
                    }
                    new classs_table.Items_Tools().update_Rows_Table_Database("casher_account", ob_casher_Account[0].ToString(), ob_casher_Account);
                    
                     new Footer.CL_Footer_Aslels().View_Footer(num_DateFoot);
                    dr.dgv_sals_dgv.Rows.Clear();
                    dr.txt_note_footer_sals.Text = "";
                    dr.txt_begin_Dicount_All_sals.Text = "0.00";
                    dr.txt_Dicount_Rate_All_sals.Text = "0";
                    dr.txt_Dicount_value_All_sals.Text = "0.00";
                    dr.txt_end_Dico_All_sals.Text = "0.00";


                    // حفظ قيمة الفاتورة الا بيانات الموضف من اجل اقفال الكاشير
                    if (dr.rb_cash_sals.Checked)
                    {
                        String Query = "id_login = " + dr.txt_user_id_Emp.Caption + " And " + "UserName = '" + dr.txt_user_Emp.Caption + "' And isLoock =" + false;
                        DataRow[] dr_unlock = DB_Add_delete_update_.Database.ds.Tables["Unlook_Box"].Select(Query);
                        if (dr_unlock.Count() != 0)
                        {
                            object[] ob_ditils = DB_Add_delete_update_.Database.ds.Tables["unlock_ditils"].Rows.Find(dr_unlock[0][0]).ItemArray;
                            ob_ditils[5] = Convert.ToDouble(ob_ditils[5]) + Convert.ToDouble(dr_frm.txt_sals_begin_cash.Text);
                            new classs_table.Items_Tools().update_Rows_Table_Database("unlock_ditils", ob_ditils[0].ToString(), ob_ditils);
                        }
                    }else if (dr.rb_yup_sals.Checked)
                    {
                        if (dr_frm_Cli.txt_sals_pand_cash.Text.Trim() != string.Empty)
                        {
                            String Query = "id_login = " + dr.txt_user_id_Emp.Caption + " And " + "UserName = '" + dr.txt_user_Emp.Caption + "' And isLoock =" + false;
                            DataRow[] dr_unlock = DB_Add_delete_update_.Database.ds.Tables["Unlook_Box"].Select(Query);
                            if (dr_unlock.Count() != 0)
                            {
                                object[] ob_ditils = DB_Add_delete_update_.Database.ds.Tables["unlock_ditils"].Rows.Find(dr_unlock[0][0]).ItemArray;
                                ob_ditils[5] = Convert.ToDouble(ob_ditils[5]) + Convert.ToDouble(dr_frm_Cli.txt_sals_pand_cash.Text);
                                new classs_table.Items_Tools().update_Rows_Table_Database("unlock_ditils", ob_ditils[0].ToString(), ob_ditils);
                            }
                        }
                    }

                   
                   MessageBox.Show("تم الحفظ بنجاج", "فاتورة مبيعات", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

    }
}
