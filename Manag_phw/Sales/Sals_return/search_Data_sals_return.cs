using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Manag_ph.Sales.Sals_return
{
    class search_Data_sals_return
    {

        DataRow[] dr_Cline;
        public void open_frm_sals_return()
        {

            var vr = Application.OpenForms["Main"] as Main;
            DataRow dr = DB_Add_delete_update_.Database.ds.Tables["TB_LOGIN_EMP"].Rows.Find(new object[] { vr.txt_user_id_Emp.Caption, vr.txt_user_Emp.Caption });
            DataRow dr_casher = DB_Add_delete_update_.Database.ds.Tables["casher"].Rows.Find(dr[5]);

            if (dr_casher != null)
            {
                vr.txt_casher_num_sals_return.Text = dr_casher[0].ToString();
                DataRow dr_stirg_sels = DB_Add_delete_update_.Database.ds.Tables["Storg"].Rows.Find(dr_casher[3]);
                vr.txt_num_Storg_sals_return.Text = dr_stirg_sels[0].ToString();
                vr.txt_name_Storg_sals_return.Text = dr_stirg_sels[1].ToString();
                new classs_table.Items_Tools().showAndHideForm(vr.sals_return);
            }
            //txt_account_Cline_sals_return
        }

        public void Add_Cline_sals_return(object sender, KeyEventArgs e)
        {
            var vr = Application.OpenForms["Main"] as Main;

            if (e.KeyCode == Keys.Enter)
            {
                if (vr.rb_yup_sals_return.Checked)
                {
                    //txt_num_footer_sals_return
                    //rb_yup_sals_return
                    if (vr.txt_num_or_phone_cline_sals_retrn.Text.Trim() != string.Empty)
                    {
                        // جلب بيانات العميل وحساباتهم
                        //   DataRow inf_clin = DB_Add_delete_update_.Database.ds.Tables["cline_footer"].Rows.Find(dr_Data_footer_sals_return[i][0]);
                        DataRow dr_cline_find = DB_Add_delete_update_.Database.ds.Tables["Clien"].Rows.Find(vr.txt_num_or_phone_cline_sals_retrn.Text.Trim());
                        DataRow[] dr_cline_select = DB_Add_delete_update_.Database.ds.Tables["Clien"].Select("phon1_clin = " + vr.txt_num_or_phone_cline_sals_retrn.Text.Trim() + "");


                        if (dr_cline_find != null)
                        {
                            if (Convert.ToBoolean(dr_cline_find[3]) != true)// لو كان  الموظف موقف
                            {
                                vr.txt_num_or_phone_cline_sals_retrn.Text = dr_cline_find[0].ToString();
                                vr.txt_name_cline_sals_return.Text = dr_cline_find[1].ToString();
                                DataRow dr_Account = DB_Add_delete_update_.Database.ds.Tables["Stock_client"].Rows.Find(dr_cline_find[10]);
                                vr.txt_account_Cline_sals_return.Text = dr_Account[4].ToString();

                                if (Convert.ToDouble(dr_Account[1]) == 0 && Convert.ToDouble(dr_Account[2]) > 0)
                                {
                                    vr.label_Dbtet_sels_footr.Text = "مدين";
                                }
                                else if (Convert.ToDouble(dr_Account[1]) >= 0 && Convert.ToDouble(dr_Account[2]) == 0)
                                {
                                    vr.label_Dbtet_sels_footr.Text = "دائن";
                                }
                                }
                            else
                            {
                                MessageBox.Show("هذا العمبل موقف");
                                vr.txt_name_cline_sals_return.Text = "";
                                vr.txt_account_Cline_sals_return.Text = "";
                                vr.txt_num_or_phone_cline_sals_retrn.SelectAll();
                                return;
                            }

                        }
                        else if (dr_cline_select.Count() != 0)
                        {
                            if (Convert.ToBoolean(dr_cline_select[0][3]) != true)// لو كان  الموظف موقف
                            {
                                vr.txt_num_or_phone_cline_sals_retrn.Text = dr_cline_select[0][0].ToString();
                                vr.txt_name_cline_sals_return.Text = dr_cline_select[0][1].ToString();
                                DataRow dr_Account = DB_Add_delete_update_.Database.ds.Tables["Stock_client"].Rows.Find(dr_cline_select[0][10]);
                                vr.txt_account_Cline_sals_return.Text = dr_Account[4].ToString();
                            }

                            else
                            {
                                MessageBox.Show("هذا العمبل موقف");
                                vr.txt_name_cline_sals_return.Text = "";
                                vr.txt_account_Cline_sals_return.Text = "";
                                vr.txt_num_or_phone_cline_sals_retrn.SelectAll();
                                return;
                            }
                        }
                        else
                        {
                            MessageBox.Show("يرجاء التحقق من المدخلات", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            vr.txt_name_cline_sals_return.Text = "";
                            vr.txt_account_Cline_sals_return.Text = "";
                            vr.txt_num_or_phone_cline_sals_retrn.SelectAll();

                        }
                    }
                }
                else
                {
                    MessageBox.Show("يجب تحويل نوع الفاتورة اجل ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
        }

        public void serch_Data_Sals_return()
        {

            var vr = Application.OpenForms["Main"] as Main;
            vr.dgv_data_footer_sals_return_dgv.Rows.Clear();
            vr.dgv_Item_footer_sals_return_dgv.Rows.Clear();
            string query = null;
            if (vr.rb_cash_sals_return.Checked)// لو كان يبحث عن الفواتير الكاش
            {
                query = "type_pross_sals =" + "1";
                if (vr.txt_num_footer_sals_return.Text.Trim() != string.Empty)
                {
                    query += " and num_foot_sals = " + vr.txt_num_footer_sals_return.Text.Trim();
                }

            }
            else
            {// لوكانت اجل
                query = "type_pross_sals = " + "2";

                if (vr.txt_num_footer_sals_return.Text != string.Empty)
                {
                    query += " and num_foot_sals = " + vr.txt_num_footer_sals_return.Text.Trim();

                }
                else if (vr.txt_account_Cline_sals_return.Text.Trim() != string.Empty)
                {
                    dr_Cline = DB_Add_delete_update_.Database.ds.Tables["cline_footer"].Select("num_Cline = " + vr.txt_num_or_phone_cline_sals_retrn.Text);
                    if (dr_Cline.Count() == 0)
                    {
                        MessageBox.Show("العميل ليس لدية اي فواتير", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }
                else
                {
                    MessageBox.Show("يرجاء ادخال رقم الفاتورة او رقم العميل","Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
                    return;
                }
            }


            //كاش
            if (vr.rb_cash_sals_return.Checked)
            {
                DataRow[] dr_Data_footer_sals_return = DB_Add_delete_update_.Database.ds.Tables["Date_Footer_Sals"].Select(query);
                if (dr_Data_footer_sals_return.Count() != 0)
                {
                    for (int i = 0; i < dr_Data_footer_sals_return.Count(); i++)
                    {
                        DataRow inf_Emp = DB_Add_delete_update_.Database.ds.Tables["TB_Employees"].Rows.Find(dr_Data_footer_sals_return[i][8]);
                        vr.dgv_data_footer_sals_return_dgv.Rows.Add(
                            dr_Data_footer_sals_return[i][0],// رقم الفاتورة
                            dr_Data_footer_sals_return[i][9],// عدد الاصناف
                            Convert.ToDouble(dr_Data_footer_sals_return[i][3]).ToString("N2"),// اجمالي الفاتورة
                          "كاش",// نوع الفاتورة
                             dr_Data_footer_sals_return[i][12],// اسم العميل
                            Convert.ToDouble(dr_Data_footer_sals_return[i][3]).ToString("N2"),// اجمالي الفاتورة قبل الخصوم
                             dr_Data_footer_sals_return[i][4],//  خصم نسبة
                           Convert.ToDouble(dr_Data_footer_sals_return[i][5]).ToString("N2"),// خصم قيمة
                             dr_Data_footer_sals_return[i][6],// خصم قيمة
                             "0",
                             "0",
                             dr_Data_footer_sals_return[i][2],// تاريخ الفاتورة
                            inf_Emp[1],//  الموظف      
                             dr_Data_footer_sals_return[i][15]
                            );

                    }
                }
            }
            else
            {
                DataRow[] dr_Data_footer_sals_return = DB_Add_delete_update_.Database.ds.Tables["Date_Footer_Sals"].Select(query);

                for (int i = 0; i < dr_Data_footer_sals_return.Count(); i++)
                {
                    DataRow inf_Emp = DB_Add_delete_update_.Database.ds.Tables["TB_Employees"].Rows.Find(dr_Data_footer_sals_return[i][8]);
        
                vr.dgv_data_footer_sals_return_dgv.Rows.Add(
                        dr_Data_footer_sals_return[i][0],// رقم الفاتورة
                        dr_Data_footer_sals_return[i][9],// عدد الاصناف
                        dr_Data_footer_sals_return[i][3],// اجمالي الفاتورة
                        "اجل",// نوع الفاتورة
                         dr_Data_footer_sals_return[i][12],// اسم العميل
                         dr_Data_footer_sals_return[i][3],// اجمالي الفاتورة قبل الخصوم
                         dr_Data_footer_sals_return[i][4],//  خصم نسبة
                         dr_Data_footer_sals_return[i][5],// خصم قيمة
                         dr_Data_footer_sals_return[i][6],// خصم قيمة
                         dr_Data_footer_sals_return[i][13],// المدفوع
                         dr_Data_footer_sals_return[i][14],// الباقي
                         dr_Data_footer_sals_return[i][2],// تاريخ الفاتورة
                        inf_Emp[1],//  الموظف      
                         dr_Data_footer_sals_return[i][15]
                        );
                }
            }


        }
        public void fill_Com_(int Item_num, int Item_storg_num, int unit_current)
        {
            var vr = Application.OpenForms["Main"] as Main;
            DataRow dr_row = DB_Add_delete_update_.Database.ds.Tables["Item"].Rows.Find(Item_num);// جلب بيانات الصنف كامل
            DataRow dr_Item_storg = DB_Add_delete_update_.Database.ds.Tables["Item_storg"].Rows.Find(Item_storg_num);// جلب بيانات الصنف كامل

            DataGridViewComboBoxCell DGV_Prodect = vr.dgv_Item_footer_sals_return_dgv.Rows[vr.dgv_Item_footer_sals_return_dgv.Rows.Count - 1].Cells[3] as DataGridViewComboBoxCell;// تحويل عمود الوحداد الا كمبو بكس
            DataRow[] dr_unit_pro = DB_Add_delete_update_.Database.ds.Tables["unite_items"].Select("Item_no = " + Item_num);// جلب بيانات الوحداد

            DataRow dr_unit_pro_kptol = DB_Add_delete_update_.Database.ds.Tables["therpeutic_unite"].Rows.Find(Convert.ToInt32(dr_unit_pro[0][1]));
            DataRow dr_unit_pro_avrg = DB_Add_delete_update_.Database.ds.Tables["therpeutic_unite"].Rows.Find(Convert.ToInt32(dr_unit_pro[0][2]));
            DataRow dr_unit_pro_smool = DB_Add_delete_update_.Database.ds.Tables["therpeutic_unite"].Rows.Find(Convert.ToInt32(dr_unit_pro[0][3]));
            DataRow dr_unit_sals = DB_Add_delete_update_.Database.ds.Tables["therpeutic_unite"].Rows.Find(Convert.ToInt32(dr_unit_pro[0][8]));
            vr.dgv_Item_footer_sals_return_dgv.Rows[vr.dgv_Item_footer_sals_return_dgv.Rows.Count - 1].Cells[1].Value = dr_row[1].ToString();// اسم الصنف
            vr.dgv_Item_footer_sals_return_dgv.Rows[vr.dgv_Item_footer_sals_return_dgv.Rows.Count - 1].Cells[2].Value = Convert.ToDateTime(dr_Item_storg[2]).ToString("d");// تاريخ الصلاحية

            vr.dgv_Item_footer_sals_return_dgv.Rows[vr.dgv_Item_footer_sals_return_dgv.Rows.Count - 1].Cells[7].Value = "0.00";// سعر المرتجع
            vr.dgv_Item_footer_sals_return_dgv.Rows[vr.dgv_Item_footer_sals_return_dgv.Rows.Count - 1].Cells[8].Value = "0.00"; // المرتجع بعد الخصم
            vr.dgv_Item_footer_sals_return_dgv.Rows[vr.dgv_Item_footer_sals_return_dgv.Rows.Count - 1].Cells[14].Value = "0.00";// اجمالي المرتجع

            DataRow[] dr_dealing = DB_Add_delete_update_.Database.ds.Tables["dealings"].Select("Item_num = " + Item_num);




            // عرض الوحدة التي تم ادخال الصنف الا المخزن بها والوحدات التي اصغر منها

            DataTable dt = new DataTable();
            dt.Columns.Add("num", typeof(int));
            dt.Columns.Add("name", typeof(string));

            if (unit_current == 1)
            {
                dt.Rows.Add(1, dr_unit_pro_kptol[1].ToString());
                dt.Rows.Add(2, dr_unit_pro_avrg[1].ToString());
                dt.Rows.Add(3, dr_unit_pro_smool[1].ToString());

            }
            else if (unit_current == 2)
            {
                dt.Rows.Add(2, dr_unit_pro_avrg[1].ToString());
                dt.Rows.Add(3, dr_unit_pro_smool[1].ToString());
            }
            else if (unit_current == 3)
            {
                dt.Rows.Add(3, dr_unit_pro_smool[1].ToString());

            }
            DGV_Prodect.DataSource = dt;
            DGV_Prodect.DisplayMember = "name";
            DGV_Prodect.ValueMember = "num";
            DGV_Prodect.Value = unit_current;
        }

        public void dgv_data_sals_return_()
        {
            var vr = Application.OpenForms["Main"] as Main;
            vr.dgv_Item_footer_sals_return_dgv.Rows.Clear();
            if (vr.dgv_data_footer_sals_return_dgv.CurrentRow != null)
            {
                DataRow[] dr_Item = DB_Add_delete_update_.Database.ds.Tables["Item_footer_Sals_And_Return"].Select("num_foot_Sals =" + vr.dgv_data_footer_sals_return_dgv.CurrentRow.Cells[0].Value);
                if (dr_Item.Count() != 0)
                {
                    vr.txt_count_sals_return.Text = vr.dgv_data_footer_sals_return_dgv.CurrentRow.Cells[1].Value.ToString();// عدد الاصناف
                    vr.txt_begin_sals_return.Text = Convert.ToDouble(vr.dgv_data_footer_sals_return_dgv.CurrentRow.Cells[2].Value).ToString("N2");// الاجمالي قبل الخصم
                    vr.txt_Dicunt_rate_sals_return.Text = vr.dgv_data_footer_sals_return_dgv.CurrentRow.Cells[6].Value.ToString();// خصم نسبة
                    vr.txt_Dicunt_value_sals_return.Text = Convert.ToDouble(vr.dgv_data_footer_sals_return_dgv.CurrentRow.Cells[7].Value).ToString("N2");// خصم قيمة
                    vr.txt_note_sals_return.Text = vr.dgv_data_footer_sals_return_dgv.CurrentRow.Cells[13].Value.ToString();//  الملاحظة 
                    vr.txt_after_sals_return.Text = "0.00";//  الصافي 
                    vr.txt_value_sals_return.Text = "0.00";//  قيمة المرتجع 
                    for (int i = 0; i < dr_Item.Count(); i++)
                    {
                        vr.dgv_Item_footer_sals_return_dgv.Rows.Add();
                        fill_Com_((int)dr_Item[i][1], (int)dr_Item[i][3], (int)dr_Item[i][5]);
                        vr.dgv_Item_footer_sals_return_dgv.Rows[vr.dgv_Item_footer_sals_return_dgv.Rows.Count - 1].Cells[0].Value = dr_Item[i][1];// رقم الصنف
                        vr.dgv_Item_footer_sals_return_dgv.Rows[vr.dgv_Item_footer_sals_return_dgv.Rows.Count - 1].Cells[4].Value = dr_Item[i][4];// الكمية المباعة
                        vr.dgv_Item_footer_sals_return_dgv.Rows[vr.dgv_Item_footer_sals_return_dgv.Rows.Count - 1].Cells[5].Value = "0";// الكمية المرتجع
                        vr.dgv_Item_footer_sals_return_dgv.Rows[vr.dgv_Item_footer_sals_return_dgv.Rows.Count - 1].Cells[6].Value = Convert.ToDouble(dr_Item[i][6]).ToString("N2");// سعر البيع  
                        vr.dgv_Item_footer_sals_return_dgv.Rows[vr.dgv_Item_footer_sals_return_dgv.Rows.Count - 1].Cells[9].Value = Convert.ToDouble(dr_Item[i][6]).ToString("N2");// سعر البيع قبل الخصم
                        vr.dgv_Item_footer_sals_return_dgv.Rows[vr.dgv_Item_footer_sals_return_dgv.Rows.Count - 1].Cells[10].Value = dr_Item[i][7];// نسبة الخصم
                        vr.dgv_Item_footer_sals_return_dgv.Rows[vr.dgv_Item_footer_sals_return_dgv.Rows.Count - 1].Cells[11].Value = Convert.ToDouble(dr_Item[i][8]).ToString("N2");// قيمة الخصم
                        vr.dgv_Item_footer_sals_return_dgv.Rows[vr.dgv_Item_footer_sals_return_dgv.Rows.Count - 1].Cells[12].Value = Convert.ToDouble(dr_Item[i][9]).ToString("N2");// قيمة بعد الخصم
                        vr.dgv_Item_footer_sals_return_dgv.Rows[vr.dgv_Item_footer_sals_return_dgv.Rows.Count - 1].Cells[13].Value = Convert.ToDouble(dr_Item[i][10]).ToString("N2");// قيمة بعد الخصم
                        vr.dgv_Item_footer_sals_return_dgv.Rows[vr.dgv_Item_footer_sals_return_dgv.Rows.Count - 1].Cells[16].Value = dr_Item[i][3];// رقم الصنف المخزن
                        vr.dgv_Item_footer_sals_return_dgv.Rows[vr.dgv_Item_footer_sals_return_dgv.Rows.Count - 1].Cells[17].Value = dr_Item[i][0];// رقم الصنف في المبيعات
                        //if (Convert.ToBoolean(dr_Item[i][11]))
                        //{
                        //    vr.dgv_Item_footer_sals_return_dgv.Rows[vr.dgv_Item_footer_sals_return_dgv.Rows.Count - 1].DefaultCellStyle.BackColor = Color.LightSteelBlue;
                        //    vr.dgv_Item_footer_sals_return_dgv.Rows[vr.dgv_Item_footer_sals_return_dgv.Rows.Count - 1].Cells[5].ReadOnly = true;
                        //    vr.dgv_Item_footer_sals_return_dgv.Rows[vr.dgv_Item_footer_sals_return_dgv.Rows.Count - 1].Cells[3].ReadOnly = true;
                        //}
                    }
                }
            }
        }
        public void dgv_Item_footer_sals_return_EditingControlShowing_(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            // دالة تقوم بهندلة الارقام
            var vr = Application.OpenForms["Main"] as Main;


            if (vr.dgv_Item_footer_sals_return_dgv.CurrentRow != null)
            {
                if (vr.dgv_Item_footer_sals_return_dgv.CurrentCell.ColumnIndex == 5)
                {
                    if (e.Control is TextBox)
                    {
                        e.Control.KeyPress += delegate (object Mysned, KeyPressEventArgs Mye)
                        {
                            if (!(char.IsDigit(Mye.KeyChar) || Mye.KeyChar == 8))
                            {
                                Mye.Handled = true;
                            }
                        };
                    }
                }
                else if (vr.dgv_Item_footer_sals_return_dgv.CurrentCell.ColumnIndex == 3)
                {
                    ComboBox com = new ComboBox();
                    com = e.Control as ComboBox;

                    com.SelectedIndexChanged += delegate (object Mysender, EventArgs Me)
                    {
                        DataRow dr_Item_sals = DB_Add_delete_update_.Database.ds.Tables["Item_footer_Sals_And_Return"].Rows.Find(vr.dgv_Item_footer_sals_return_dgv.CurrentRow.Cells[17].Value);
                        DataRow dr_Item_storg = DB_Add_delete_update_.Database.ds.Tables["Item_storg"].Rows.Find(vr.dgv_Item_footer_sals_return_dgv.CurrentRow.Cells[16].Value);
                        DataRow[] dr_unit = DB_Add_delete_update_.Database.ds.Tables["unite_items"].Select("item_no =" + dr_Item_storg[9]);
                        double sals_pric_begin = Convert.ToDouble(dr_Item_sals[6]);
                        double sals_pric_after = Convert.ToDouble(dr_Item_storg[8]);
                        double temp = Convert.ToDouble(dr_Item_storg[8]);
                        string qty = "";
                        double Dicount_Rate = 0;

                        // تحديد الوحدة التي تم ادخالها ثم تحديد ثم تحديد الكمية
                        if (Convert.ToInt32(dr_Item_sals[5]) == 1)
                        {
                            if (com.SelectedIndex == 0)
                            {
                                qty = dr_Item_sals[4].ToString();
                                sals_pric_begin = Convert.ToDouble(dr_Item_sals[6]);
                                sals_pric_after = Convert.ToDouble(dr_Item_sals[9]);
                                Dicount_Rate = Convert.ToDouble(dr_Item_sals[8]);

                            }// لو كان الادخال وحدة كبرا والبيع وحدة وسطاء
                            else if (com.SelectedIndex == 1)
                            {
                                //qty = Convert.ToInt32(Convert.ToInt32(dr_Item_sals[12]) * Convert.ToInt32(dr_unit[0][4])).ToString();
                                qty = Convert.ToInt32(dr_Item_sals[12]).ToString();
                                sals_pric_begin = Convert.ToDouble(dr_Item_sals[6]) / Convert.ToInt32(dr_unit[0][4]);
                                sals_pric_after = Convert.ToDouble(dr_Item_sals[9]) / Convert.ToInt32(dr_unit[0][4]);
                                Dicount_Rate = Convert.ToDouble(dr_Item_sals[8]) != 0? Convert.ToDouble(Convert.ToDouble(dr_Item_sals[8]) / Convert.ToInt32(qty)) : 0;


                            }// لو كان الادخال وحدة كبرا والبيع وحدة صغرا
                            else if (com.SelectedIndex == 2)
                            {
                                //int qty_avrg = Convert.ToInt32(dr_Item_sals[4]) * Convert.ToInt32(dr_unit[0][4]);
                                //qty = Convert.ToInt32(Convert.ToInt32(qty_avrg) * Convert.ToInt32(dr_unit[0][5])).ToString();
                                qty = Convert.ToInt32(dr_Item_sals[13]).ToString();
                                double sals_pric_avrg_begin = Convert.ToDouble(Convert.ToDouble(dr_Item_sals[6]) / Convert.ToInt32(dr_unit[0][4]));
                                sals_pric_begin = Convert.ToDouble(sals_pric_avrg_begin / Convert.ToInt32(dr_unit[0][5]));

                                double sals_pric_avrg = Convert.ToDouble(Convert.ToDouble(dr_Item_sals[9]) / Convert.ToInt32(dr_unit[0][4]));
                                sals_pric_after = Convert.ToDouble(sals_pric_avrg / Convert.ToInt32(dr_unit[0][5]));



                                Dicount_Rate = Convert.ToDouble(dr_Item_sals[8]) != 0 ? Convert.ToDouble(Convert.ToDouble(dr_Item_sals[8]) / Convert.ToInt32(qty)) : 0;

                            }

                        }// لو كان الادخال وحدة وسطاء 
                        else if (Convert.ToInt32(dr_Item_sals[5]) == 2)
                        {
                            // لو كان الادخال وحدة وسطاء والبيع وحدة وسطاء
                            if (com.SelectedIndex == 0)
                            {
                                qty = dr_Item_sals[4].ToString();
                                sals_pric_after = Convert.ToDouble(dr_Item_sals[9]);
                                sals_pric_begin = Convert.ToDouble(dr_Item_sals[6]);
                                Dicount_Rate = Convert.ToDouble(dr_Item_sals[8]);

                            }// لو كان الادخال وحدة وسطاء والبيع وحدة صغرا
                            else if (com.SelectedIndex == 1)
                            {
                                //qty = Convert.ToInt32(Convert.ToInt32(dr_Item_sals[4]) * Convert.ToInt32(dr_unit[0][5])).ToString();
                                qty = Convert.ToInt32(dr_Item_sals[13]).ToString();
                                sals_pric_begin = Convert.ToDouble(Convert.ToDouble(dr_Item_sals[6]) / Convert.ToInt32(dr_unit[0][5]));
                                sals_pric_after = Convert.ToDouble(Convert.ToDouble(dr_Item_sals[9]) / Convert.ToInt32(dr_unit[0][5]));
                                Dicount_Rate = Convert.ToDouble(dr_Item_sals[8]) != 0 ? Convert.ToDouble(Convert.ToDouble(dr_Item_sals[8]) / Convert.ToInt32(qty)) : 0;

                            }

                        }// لو كان الادخال وحدة صغرا والبيع وحدة صغرا
                        else if (Convert.ToInt32(dr_Item_sals[5]) == 3)
                        {

                            qty = dr_Item_sals[4].ToString();
                            sals_pric_after = Convert.ToDouble(dr_Item_sals[9]);
                            sals_pric_begin = Convert.ToDouble(dr_Item_sals[6]);
                            Dicount_Rate = Convert.ToDouble(dr_Item_sals[8]);


                        }
                        vr.dgv_Item_footer_sals_return_dgv.CurrentRow.Cells[6].Value = sals_pric_begin.ToString("N2");// سعر البيع الجديد
                        vr.dgv_Item_footer_sals_return_dgv.CurrentRow.Cells[4].Value = qty;// الكمية
                        vr.dgv_Item_footer_sals_return_dgv.CurrentRow.Cells[5].Value = "0";// كمية المرتجع
                        vr.dgv_Item_footer_sals_return_dgv.CurrentRow.Cells[7].Value = "0";// سعر المرتجع
                        vr.dgv_Item_footer_sals_return_dgv.CurrentRow.Cells[9].Value = sals_pric_begin.ToString("N2");// السعر قبل الخصم
                        vr.dgv_Item_footer_sals_return_dgv.CurrentRow.Cells[11].Value = Dicount_Rate.ToString("N4");// خصم قيمة
                        vr.dgv_Item_footer_sals_return_dgv.CurrentRow.Cells[12].Value = sals_pric_after.ToString("N2");// السعر قبل الخصم
                        Totil_All_Fotter_sals();
                        Account_Dicount_Rate_val();

                    };
                }
            }
        }
        public void dgv_Item_footer_sals_return_CellEndEdit_(object sender, DataGridViewCellEventArgs e)
        {
            // ترتيب تواريخ الصلاحية تصاعدي  معا فلترت الاصناف التي الرصيد صغر
            var vr = Application.OpenForms["Main"] as Main;
            if (vr.dgv_Item_footer_sals_return_dgv.CurrentRow != null)
            {
                if (vr.dgv_Item_footer_sals_return_dgv.CurrentCell.ColumnIndex == 5)
                {

                    if (vr.dgv_Item_footer_sals_return_dgv.CurrentRow.Cells[5].Value != null)
                    {

                        if (Convert.ToInt32(vr.dgv_Item_footer_sals_return_dgv.CurrentRow.Cells[5].Value) > Convert.ToInt32(vr.dgv_Item_footer_sals_return_dgv.CurrentRow.Cells[4].Value))
                        {
                            MessageBox.Show("الكمية المرجعة اكبر من الرصيد", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            vr.dgv_Item_footer_sals_return_dgv.CurrentRow.Cells[5].Value = "0";
                            Account_Dicount_Rate_val();
                            return;
                        }
                        else
                        {
                            vr.dgv_Item_footer_sals_return_dgv.CurrentRow.Cells[7].Value = vr.dgv_Item_footer_sals_return_dgv.CurrentRow.Cells[6].Value;
                            Account_Dicount_Rate_val();
                        }

                    }
                    else
                    {
                        vr.dgv_Item_footer_sals_return_dgv.CurrentRow.Cells[5].Value = "0";
                    }
                }
            }


        }


        void Account_Dicount_Rate_val()
        {
            var vr = Application.OpenForms["Main"] as Main;

            if (vr.dgv_Item_footer_sals_return_dgv.CurrentRow != null)
            {
                if (Convert.ToDouble(vr.dgv_Item_footer_sals_return_dgv.CurrentRow.Cells[11].Value) != 0)
                {
                    vr.dgv_Item_footer_sals_return_dgv.CurrentRow.Cells[8].Value = Convert.ToDouble(vr.dgv_Item_footer_sals_return_dgv.CurrentRow.Cells[12].Value).ToString("N2");// سعر المرتجع بعد يكون هو سعر المرتجع قبل الخصم اذا كان لا يوجد خصم

                }
                else
                {
                    vr.dgv_Item_footer_sals_return_dgv.CurrentRow.Cells[8].Value = Convert.ToDouble(vr.dgv_Item_footer_sals_return_dgv.CurrentRow.Cells[12].Value).ToString("N2");// سعر المرتجع بعد يكون هو سعر المرتجع قبل الخصم اذا كان لا يوجد خصم
                }

                vr.dgv_Item_footer_sals_return_dgv.CurrentRow.Cells[14].Value = Convert.ToDouble(Convert.ToDouble(vr.dgv_Item_footer_sals_return_dgv.CurrentRow.Cells[8].Value) * Convert.ToInt32(vr.dgv_Item_footer_sals_return_dgv.CurrentRow.Cells[5].Value)).ToString("N2");// حساب مجموع سعر المرتجع

                Totil_All_Fotter_sals();

            }
        }


        void sum_qty_pric()
        {
            var vr = Application.OpenForms["Main"] as Main;
            if (vr.dgv_Item_footer_sals_return_dgv.CurrentRow != null)
            {
                if (vr.dgv_Item_footer_sals_return_dgv.CurrentRow.Cells[4].Value != null && vr.dgv_Item_footer_sals_return_dgv.CurrentRow.Cells[4].Value != "")
                {

                    vr.dgv_Item_footer_sals_return_dgv.CurrentRow.Cells[13].Value = Convert.ToDouble(Convert.ToInt32(vr.dgv_Item_footer_sals_return_dgv.CurrentRow.Cells[4].Value) * Convert.ToDouble(vr.dgv_Item_footer_sals_return_dgv.CurrentRow.Cells[12].Value)).ToString("N2");
                }
            }

        }
        void sum_pric()
        {
            var vr = Application.OpenForms["Main"] as Main;
            double sum_pric = 0;
            for (int i = 0; i < vr.dgv_Item_footer_sals_return_dgv.Rows.Count; i++)
            {
                if (vr.dgv_Item_footer_sals_return_dgv.Rows[i].Visible)
                {
                    if (vr.dgv_Item_footer_sals_return_dgv.Rows[i].Cells[6].Value != null)
                    {

                        sum_pric += Convert.ToDouble(vr.dgv_Item_footer_sals_return_dgv.Rows[i].Cells[14].Value);
                    }
                }
            }


            vr.txt_value_sals_return.Text = sum_pric.ToString("N2");
            if (Convert.ToDouble(vr.txt_Dicunt_value_sals_return.Text.Trim()) != 0 )
            {
                double accou_dic = Convert.ToDouble(Convert.ToDouble(vr.txt_Dicunt_value_sals_return.Text) /Convert.ToDouble(vr.txt_begin_sals_return.Text));
                double accoun_munt = Convert.ToDouble(Convert.ToDouble(vr.txt_value_sals_return.Text) * accou_dic);
                vr.txt_after_sals_return.Text = Convert.ToDouble(Convert.ToDouble(vr.txt_value_sals_return.Text) - accoun_munt).ToString("N2"); 
            }
            else
            {

                vr.txt_after_sals_return.Text = vr.txt_value_sals_return.Text;

            }
        }
        public void Totil_All_Fotter_sals()
        {
            //Amunt();
            sum_qty_pric();
            sum_pric();
            //Totil_All_sals();

        }

        ////////////////////////////////////////////////////////////////
        ///
        public void Add_Cline_sals_return_in_txt_id_sls (object sender, KeyEventArgs e)
        {
            var vr = Application.OpenForms["Main"] as Main;

            if (e.KeyCode == Keys.Enter)
            {
                if (vr.rb_yup_sals_return.Checked)
                {
                    //txt_num_footer_sals_return
                    //rb_yup_sals_return
                    if (vr.txt_num_footer_sals_return.Text.Trim() != string.Empty)
                    {
                        // جلب بيانات العميل وحساباتهم
                        DataRow[] inf_clin = DB_Add_delete_update_.Database.ds.Tables["cline_footer"].Select("num_footer =" + vr.txt_num_footer_sals_return.Text.Trim());
                        if (inf_clin.Count() != 0)
                        {
                        DataRow dr_cline_find = DB_Add_delete_update_.Database.ds.Tables["Clien"].Rows.Find(inf_clin[0][2]);
                        if (dr_cline_find != null)
                        {
                            if (Convert.ToBoolean(dr_cline_find[3]) != true)// لو كان  الموظف موقف
                            {
                                vr.txt_num_or_phone_cline_sals_retrn.Text = dr_cline_find[0].ToString();
                                vr.txt_name_cline_sals_return.Text = dr_cline_find[1].ToString();
                                DataRow dr_Account = DB_Add_delete_update_.Database.ds.Tables["Stock_client"].Rows.Find(dr_cline_find[10]);
                                vr.txt_account_Cline_sals_return.Text = dr_Account[4].ToString();
                                    if (Convert.ToDouble(dr_Account[1]) == 0 && Convert.ToDouble(dr_Account[2]) > 0)
                                    {
                                        vr.label_Dbtet_sels_footr.Text = String.Format("مدين");//  "مدين";
                                    }
                                    else if (Convert.ToDouble(dr_Account[1]) >= 0 && Convert.ToDouble(dr_Account[2]) == 0)
                                    {
                                        vr.label_Dbtet_sels_footr.Text = String.Format("دائن");// "دائن";
                                    }
                                }
                            else
                            {
                                MessageBox.Show("هذا العمبل موقف");
                                vr.txt_name_cline_sals_return.Text = "";
                                vr.txt_account_Cline_sals_return.Text = "";
                                vr.txt_num_footer_sals_return.Text = "";
                                vr.txt_num_or_phone_cline_sals_retrn.SelectAll();
                                return;
                            }

                        }

                        else
                        {
                            MessageBox.Show("يرجاء التحقق من المدخلات", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            vr.txt_name_cline_sals_return.Text = "";
                            vr.txt_account_Cline_sals_return.Text = "";
                            vr.txt_num_footer_sals_return.Text = "";
                            ; vr.txt_num_or_phone_cline_sals_retrn.SelectAll();

                        }
                        }
                        else
                        {
                            MessageBox.Show("يرجاء التحقق من رقم الفاتورة الاجل");
                            vr.txt_account_Cline_sals_return.Text = "0";
                            vr.txt_name_cline_sals_return.Text = "";
                            vr.txt_num_or_phone_cline_sals_retrn.Text = "";
                            return;
                        }
                }
                }
                else
                {
                    MessageBox.Show("يجب تحويل نوع الفاتورة اجل ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
        }

    }
}
