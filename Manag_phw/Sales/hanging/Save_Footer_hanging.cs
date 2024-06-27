using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Manag_ph.Sales.hanging
{
    class Save_Footer_hanging
    {

        public void Save_and_update_Footer_hanging_Item()
        {
            
            var dr = Application.OpenForms["Main"] as Main;
            var dr_frm = Application.OpenForms["frm_save_hanging"] as frm_save_hanging;
            if (dr.dgv_hanging_Item_sals_dgv.CurrentRow != null)
            {
                //***********
                // تعديل بيانات الفاتورة المعلقة
                int Data_Footer_hang_num = Convert.ToInt32(dr.dgv_hanging_Data_footer_dgv.CurrentRow.Cells[0].Value);
                object[] ob_DataFooter_Hang = DB_Add_delete_update_.Database.ds.Tables["Date_Footer_Sals"].Rows.Find(Data_Footer_hang_num).ItemArray;


                ob_DataFooter_Hang[3] = Convert.ToDouble(dr.txt_value_begin_hanging_All_.Text).ToString("N2");// المبلغ قبل الخصوم
                ob_DataFooter_Hang[4] = Convert.ToInt32(dr.txt_Dicount_rate_hanging_All_.Text);// خص نسبة
                ob_DataFooter_Hang[5] = Convert.ToDouble(dr.txt_Dicount_value_hanging_All_.Text).ToString("N2");// خصم قيمة
                ob_DataFooter_Hang[6] = Convert.ToDouble(dr.txt_value_after_hanging.Text).ToString("N2");// صافي الحساب
                ob_DataFooter_Hang[7] = 1;// نوع عملية البيع واحد يعني كاش
                ob_DataFooter_Hang[9] = dr.txt_count_Data_hanging.Text;// عدد الاصناف                                                      
                ob_DataFooter_Hang[13] = dr_frm.txt_after_pand_cash.Text;// المبلغ المتبقي
                ob_DataFooter_Hang[14] = dr_frm.txt_sals_begin_cash.Text;// المبلغ المتبقي
                ob_DataFooter_Hang[15] = dr.txt_note_hanging.Text;
                ob_DataFooter_Hang[16] = false;
                new classs_table.Items_Tools().update_Rows_Table_Database("Date_Footer_Sals", ob_DataFooter_Hang[0].ToString(), ob_DataFooter_Hang);


                //************
                for (int i = 0; i < dr.dgv_hanging_Item_sals_dgv.RowCount; i++)
                {
                    int num_Item_storg = Convert.ToInt32(dr.dgv_hanging_Item_sals_dgv.Rows[i].Cells[15].Value); // جلب رقم الصنف المخزن من اجل تعديل الكمية
                    object[] dr_Item_update = DB_Add_delete_update_.Database.ds.Tables["Item_storg"].Rows.Find(num_Item_storg).ItemArray;// جلب كل بيانات الصنف المخزن من اجل التعديل
                    DataGridViewComboBoxCell DGVCB = dr.dgv_hanging_Item_sals_dgv.Rows[i].Cells[4] as DataGridViewComboBoxCell;



                    //MessageBox.Show(Convert.ToInt32(dr_Item_update[10]) + "      "+ Convert.ToInt32(DGVCB.Value));
                    //if (Convert.ToInt32(dr_Item_update[10]) == 1 && Convert.ToInt32(DGVCB.Value)==1)
                    //{

                    //}


                    //return;

                    if (!dr.dgv_hanging_Item_sals_dgv.Rows[i].Visible)
                    {
                        new classs_table.Items_Tools().Delete_Rows_Table_Database("Item_footer_Sals", dr.dgv_hanging_Item_sals_dgv.Rows[i].Cells[16].Value.ToString());
                    }
                    if (dr.dgv_hanging_Item_sals_dgv.Rows[i].Cells[16].Value == null)
                    {

                        // حفظ اصناف الفاتورة
                        int num_Item_Foot = new classs_table.Items_Tools().AoutoNumber("Item_footer_Sals", "num_Item_sals");
                        DB_Add_delete_update_.Database.ds.Tables["Item_footer_Sals"].Rows.Add(
                            num_Item_Foot,
                            dr.dgv_hanging_Item_sals_dgv.Rows[i].Cells[1].Value,
                            ob_DataFooter_Hang[0],
                            dr.dgv_hanging_Item_sals_dgv.Rows[i].Cells[15].Value,
                            dr.dgv_hanging_Item_sals_dgv.Rows[i].Cells[5].Value,
                            DGVCB.Value,
                              dr.dgv_hanging_Item_sals_dgv.Rows[i].Cells[9].Value,
                              dr.dgv_hanging_Item_sals_dgv.Rows[i].Cells[10].Value,
                              dr.dgv_hanging_Item_sals_dgv.Rows[i].Cells[11].Value,
                              dr.dgv_hanging_Item_sals_dgv.Rows[i].Cells[12].Value,
                              dr.dgv_hanging_Item_sals_dgv.Rows[i].Cells[13].Value,
                              false);

                    }
                    else if (dr.dgv_hanging_Item_sals_dgv.Rows[i].Cells[16].Value != null && dr.dgv_hanging_Item_sals_dgv.Rows[i].Visible == true)
                    {
                        //MessageBox.Show(dr.dgv_hanging_Item_sals.Rows[i].Cells[16].Value+"");
                        object[] dr_Item_hanging_update = DB_Add_delete_update_.Database.ds.Tables["Item_footer_Sals"].Rows.Find(dr.dgv_hanging_Item_sals_dgv.Rows[i].Cells[16].Value).ItemArray;// جلب بيانات الصنف المعلق من اجل التعديل 
                        dr_Item_hanging_update[4] = dr.dgv_hanging_Item_sals_dgv.Rows[i].Cells[5].Value;// الكمية المباعة
                        dr_Item_hanging_update[5] = DGVCB.Value;// نوع الوحدة المباعة
                        dr_Item_hanging_update[6] = Convert.ToDouble(dr.dgv_hanging_Item_sals_dgv.Rows[i].Cells[9].Value).ToString("N2");// السعر قبل الخصم
                        dr_Item_hanging_update[7] = Convert.ToInt32(dr.dgv_hanging_Item_sals_dgv.Rows[i].Cells[10].Value);// الخصم نسبة
                        dr_Item_hanging_update[8] = Convert.ToDouble(dr.dgv_hanging_Item_sals_dgv.Rows[i].Cells[11].Value).ToString("N2");// الخصم قيمة 
                        dr_Item_hanging_update[9] = Convert.ToDouble(dr.dgv_hanging_Item_sals_dgv.Rows[i].Cells[12].Value).ToString("N2");// السعر بعد الخصم
                        dr_Item_hanging_update[10] = Convert.ToDouble(dr.dgv_hanging_Item_sals_dgv.Rows[i].Cells[13].Value).ToString("N2");// اجمالي سعر البيع
                        dr_Item_hanging_update[11] = false; 
                        new classs_table.Items_Tools().update_Rows_Table_Database("Item_footer_Sals", dr_Item_hanging_update[0].ToString(), dr_Item_hanging_update);// تعديل الاصناف
                    }

                    // تعديل الكميات في قاعدة البيانات
                    if (Convert.ToInt32(dr_Item_update[12]) == 1)
                    {
                        if (Convert.ToInt32(DGVCB.Value) == 1)
                        {

                            int num = Convert.ToInt32(dr.dgv_hanging_Item_sals_dgv.Rows[i].Cells[1].Value);
                            DataRow[] dr_num_avrg = DB_Add_delete_update_.Database.ds.Tables["unite_items"].Select("item_no =" + num);
                            int num_avrg = Convert.ToInt32(dr_num_avrg[0][4]);// عدد الوحدة الوسطا
                            int num_smool = Convert.ToInt32(dr_num_avrg[0][5]);// عدد الوحدة الوسطا
                            int quity = Convert.ToInt32(dr.dgv_hanging_Item_sals_dgv.Rows[i].Cells[7].Value) - Convert.ToInt32(dr.dgv_hanging_Item_sals_dgv.Rows[i].Cells[5].Value);//كمية الوحدة الكبرا
                            int quity_avrg = quity * num_avrg;
                            int quilty_smol = quity_avrg * num_smool;
                            dr_Item_update[1] = quity;
                            dr_Item_update[13] = quity_avrg;
                            dr_Item_update[14] = quilty_smol;
                        }
                        else if (Convert.ToInt32(DGVCB.Value) == 2)// اذاكان في الوحدة الكبرا ويريد التعديل في الوحدة الوسطاء
                        {
                            int num = Convert.ToInt32(dr.dgv_hanging_Item_sals_dgv.Rows[i].Cells[1].Value);
                            DataRow[] dr_num_avrg = DB_Add_delete_update_.Database.ds.Tables["unite_items"].Select("item_no =" + num);
                            int num_avrg = Convert.ToInt32(dr_num_avrg[0][4]);// عدد الوحدة الوسطا
                            int num_smool = Convert.ToInt32(dr_num_avrg[0][5]);// عدد الوحدة الوسطا
                            int quity = Convert.ToInt32(dr.dgv_hanging_Item_sals_dgv.Rows[i].Cells[7].Value) - Convert.ToInt32(dr.dgv_hanging_Item_sals_dgv.Rows[i].Cells[5].Value);//كمية الوحدة الوسطا
                            int quity_new = quity / num_avrg;
                            int quilty_smol = num_smool * quity;
                            dr_Item_update[1] = quity_new;
                            dr_Item_update[13] = quity;
                            dr_Item_update[14] = quilty_smol;

                            // لم اكمل التعديل علا الوحدة الصغرا وهو يبحث في الوحدة الكبرا
                        }
                        else if (Convert.ToInt32(DGVCB.Value) == 3)
                        {

                            int num = Convert.ToInt32(dr.dgv_hanging_Item_sals_dgv.Rows[i].Cells[1].Value);
                            DataRow[] dr_num_avrg = DB_Add_delete_update_.Database.ds.Tables["unite_items"].Select("item_no =" + num);
                            int num_avrg = Convert.ToInt32(dr_num_avrg[0][4]);// عدد الوحدة الوسطا
                            int num_smool = Convert.ToInt32(dr_num_avrg[0][5]);// عدد الوحدة الصغرا
                            int quity = Convert.ToInt32(dr.dgv_hanging_Item_sals_dgv.Rows[i].Cells[7].Value) - Convert.ToInt32(dr.dgv_hanging_Item_sals_dgv.Rows[i].Cells[5].Value);//كمية الوحدة الصغرا
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

                            int num = Convert.ToInt32(dr.dgv_hanging_Item_sals_dgv.Rows[i].Cells[1].Value);
                            DataRow[] dr_num_avrg = DB_Add_delete_update_.Database.ds.Tables["unite_items"].Select("item_no =" + num);
                            int num_smool = Convert.ToInt32(dr_num_avrg[0][5]);// عدد الوحدة الصغرا
                            int quity = Convert.ToInt32(dr.dgv_hanging_Item_sals_dgv.Rows[i].Cells[7].Value) - Convert.ToInt32(dr.dgv_hanging_Item_sals_dgv.Rows[i].Cells[5].Value); ;//كمية الوحدة الوسطاء
                            int quilty_new_smoll = quity * num_smool;// ايجاد الكمية الكبرا
                            dr_Item_update[1] = quity;
                            dr_Item_update[14] = quilty_new_smoll;

                        }
                        else if (Convert.ToInt32(DGVCB.Value) == 3)
                        {

                            int num = Convert.ToInt32(dr.dgv_hanging_Item_sals_dgv.Rows[i].Cells[1].Value);
                            DataRow[] dr_num_avrg = DB_Add_delete_update_.Database.ds.Tables["unite_items"].Select("item_no =" + num);
                            int num_smool = Convert.ToInt32(dr_num_avrg[0][5]);// عدد الوحدة الصغرا
                            int quity = Convert.ToInt32(dr.dgv_hanging_Item_sals_dgv.Rows[i].Cells[7].Value) - Convert.ToInt32(dr.dgv_hanging_Item_sals_dgv.Rows[i].Cells[5].Value);//كمية الوحدة الصغرا
                            int quilty_new_avrg = quity / num_smool;// ايجاد الكمية الكبرا
                            dr_Item_update[1] = quilty_new_avrg;
                            dr_Item_update[14] = quity;

                        }

                    }
                    else if (Convert.ToInt32(dr_Item_update[12]) == 3)
                    {
                        int quity = Convert.ToInt32(dr.dgv_hanging_Item_sals_dgv.Rows[i].Cells[7].Value) - Convert.ToInt32(dr.dgv_hanging_Item_sals_dgv.Rows[i].Cells[5].Value);//كمية الوحدة الصغرا
                        dr_Item_update[1] = quity;
                        dr_Item_update[14] = quity;
                    }



                    if (Convert.ToInt32(dr_Item_update[1]) < 0 && Convert.ToInt32(dr_Item_update[14]) < 0 && Convert.ToInt32(dr_Item_update[13]) < 0)
                    {
                        MessageBox.Show("الكمية المباعة اكبر من الموجودة في المخزن");
                        return;
                    }


                    DB_Add_delete_update_.Database.update("Item_footer_Sals");
                    new classs_table.Items_Tools().update_Rows_Table_Database("Item_storg", dr_Item_update[0].ToString(), dr_Item_update);


                }

                object[] ob_casher = DB_Add_delete_update_.Database.ds.Tables["casher"].Rows.Find(dr.txt_casher_hanging.Text).ItemArray;
                object[] ob_casher_Account = DB_Add_delete_update_.Database.ds.Tables["casher_account"].Rows.Find(ob_casher[5]).ItemArray;
                ob_casher_Account[1] = Convert.ToDouble(Convert.ToDouble(ob_casher_Account[1]) + Convert.ToDouble(dr.txt_value_after_hanging.Text)).ToString("N2");
                new classs_table.Items_Tools().update_Rows_Table_Database("casher_account", ob_casher_Account[0].ToString(), ob_casher_Account);

                String Query = "id_login = " + dr.txt_user_id_Emp.Caption + " And " + "UserName = " + dr.txt_user_Emp.Caption + " And isLoock =" + false;
                DataRow[] dr_unlock = DB_Add_delete_update_.Database.ds.Tables["Unlook_Box"].Select(Query);
                if (dr_unlock.Count() != 0)
                {
                    object[] ob_ditils = DB_Add_delete_update_.Database.ds.Tables["unlock_ditils"].Rows.Find(dr_unlock[0][0]).ItemArray;
                    ob_ditils[5] = Convert.ToDouble(ob_ditils[5]) + Convert.ToDouble(dr_frm.txt_sals_begin_cash.Text);
                    new classs_table.Items_Tools().update_Rows_Table_Database("unlock_ditils", ob_ditils[0].ToString(), ob_ditils);
                }

                dr.dgv_hanging_Data_footer_dgv.Rows.Clear();
                dr.dgv_hanging_Item_sals_dgv.Rows.Clear();
                dr.txt_note_hanging.Text = "";
                dr.txt_value_begin_hanging_All_.Text = "0.00";
                dr.txt_Dicount_rate_hanging_All_.Text = "0";
                dr.txt_Dicount_value_hanging_All_.Text = "0.00";
                dr.txt_value_after_hanging.Text = "0.00";
                MessageBox.Show("تم الحفظ بنجاج", "فاتورة مبيعات", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
        }

    }
}

