using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Manag_ph.Sales
{
    class hanging_Add_Delete_update_serch
    {
        public void open_hanging()
        {
            var vr = Application.OpenForms["Main"] as Main;
            DataRow dr = DB_Add_delete_update_.Database.ds.Tables["TB_LOGIN_EMP"].Rows.Find(new object[] { vr.txt_user_id_Emp.Caption, vr.txt_user_Emp.Caption });
            DataRow dr_casher = DB_Add_delete_update_.Database.ds.Tables["casher"].Rows.Find(dr[5]);

            if (dr_casher != null)
            {
                vr.txt_casher_hanging.Text = dr_casher[0].ToString();
                DataRow dr_stirg_sels = DB_Add_delete_update_.Database.ds.Tables["Storg"].Rows.Find(dr_casher[3]);
                vr.txt_num_storg_hanging.Text = dr_stirg_sels[0].ToString();
                vr.txt_name_storg_hanging.Text = dr_stirg_sels[1].ToString();
                new classs_table.Items_Tools().showAndHideForm(vr.hanging_bills);

            }
        }
        void sum_pric()
        {
            var vr = Application.OpenForms["Main"] as Main;
            double sum_pric = 0;
            for (int i = 0; i < vr.dgv_hanging_Item_sals_dgv.Rows.Count; i++)
            {
                if (vr.dgv_hanging_Item_sals_dgv.Rows[i].Visible)
                {


                    if (vr.dgv_hanging_Item_sals_dgv.Rows[i].Cells[6].Value != null)
                    {

                        sum_pric += Convert.ToDouble(vr.dgv_hanging_Item_sals_dgv.Rows[i].Cells[13].Value);
                    }
                }
            }
            vr.txt_value_begin_hanging_All_.Text = sum_pric.ToString("N0");
        }

        void Item_count()
        {
            var vr = Application.OpenForms["Main"] as Main;
            int Count_Item = 0;
            for (int i = 0; i < vr.dgv_hanging_Item_sals_dgv.Rows.Count; i++)
            {
                if (vr.dgv_hanging_Item_sals_dgv.Rows[i].Cells[3].Value != null)
                {
                    Count_Item += 1;
                }
            }
            vr.txt_count_Data_hanging.Text = Count_Item.ToString();
        }
        public void Totil_All_Fotter_sals()
        {
            Amunt();
            sum_qty_pric();
            sum_pric();
            Totil_All_sals();

        }
        void sum_qty_pric()
        {
            var vr = Application.OpenForms["Main"] as Main;
            if (vr.dgv_hanging_Item_sals_dgv.CurrentRow != null)
            {

                vr.dgv_hanging_Item_sals_dgv.CurrentRow.Cells[13].Value = Convert.ToDouble(Convert.ToInt32(vr.dgv_hanging_Item_sals_dgv.CurrentRow.Cells[5].Value) * Convert.ToDouble(vr.dgv_hanging_Item_sals_dgv.CurrentRow.Cells[12].Value)).ToString("N2");
            }

        }

        public void Item_count_hanging()
        {
            var vr = Application.OpenForms["Main"] as Main;
            int Count_Item = 0;
            for (int i = 0; i < vr.dgv_hanging_Item_sals_dgv.Rows.Count; i++)
            {
                if (vr.dgv_hanging_Item_sals_dgv.Rows[i].Visible)
                {
                    if (vr.dgv_hanging_Item_sals_dgv.Rows[i].Cells[3].Value != null)
                    {
                        Count_Item += 1;
                    }
                }
            }
            vr.txt_count_Data_hanging.Text = Count_Item.ToString();
        }
        void Totil_All_sals()
        {
            var vr = Application.OpenForms["Main"] as Main;
            if (vr.dgv_hanging_Item_sals_dgv.Rows.Count != 0)
            {


                if (vr.txt_Dicount_rate_hanging_All_.Text != string.Empty)
                {
                    double All_begin = Convert.ToDouble(vr.txt_value_begin_hanging_All_.Text);
                    double Dico = Convert.ToDouble(vr.txt_Dicount_rate_hanging_All_.Text) / 100;

                    double resolt1 = All_begin * Dico;
                    double resolt2 = All_begin - resolt1;

                    vr.txt_value_after_hanging.Text = resolt2.ToString("N2");
                }
                else
                {
                    vr.txt_value_after_hanging.Text = vr.txt_value_begin_hanging_All_.Text;
                }


                if (vr.txt_Dicount_value_hanging_All_.Text != string.Empty)
                {
                    double All_begin = Convert.ToDouble(vr.txt_value_after_hanging.Text);
                    double Dico = Convert.ToDouble(vr.txt_Dicount_value_hanging_All_.Text);
                    if (Dico >= All_begin)
                    {
                        MessageBox.Show("الخصم اكبر من الرصيد الكلي ", "تحذير", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        vr.txt_Dicount_value_hanging_All_.Text = "0.00";
                    }
                    else
                    {
                        double resolt1 = All_begin - Dico;
                        vr.txt_value_after_hanging.Text = resolt1.ToString("N2");

                    }
                }
                // خصم المبلغ المدفوع
                double paind = vr.txt_paind_hanging.Text.Trim() != string.Empty ? Convert.ToDouble(vr.txt_paind_hanging.Text) : 0;
                vr.txt_value_after_hanging.Text = Convert.ToDouble(Convert.ToDouble(vr.txt_value_after_hanging.Text) - paind).ToString("N2");
            }
        }

        void Amunt()
        {
            var vr = Application.OpenForms["Main"] as Main;
            if (vr.dgv_hanging_Item_sals_dgv.CurrentRow != null)
            {


                if (vr.dgv_hanging_Item_sals_dgv.CurrentRow.Cells[10].Value != null)
                {
                    double All_begin = Convert.ToDouble(vr.dgv_hanging_Item_sals_dgv.CurrentRow.Cells[9].Value);
                    double Dico = Convert.ToDouble(vr.dgv_hanging_Item_sals_dgv.CurrentRow.Cells[10].Value) / 100;

                    double resolt1 = All_begin * Dico;
                    double resolt2 = All_begin - resolt1;

                    vr.dgv_hanging_Item_sals_dgv.CurrentRow.Cells[12].Value = resolt2.ToString("N2");
                }
                else
                {
                    vr.dgv_hanging_Item_sals_dgv.CurrentRow.Cells[12].Value = vr.dgv_hanging_Item_sals_dgv.CurrentRow.Cells[9].Value;
                }


                if (vr.dgv_hanging_Item_sals_dgv.CurrentRow.Cells[11].Value != null)
                {
                    double All_begin = Convert.ToDouble(vr.dgv_hanging_Item_sals_dgv.CurrentRow.Cells[12].Value);
                    double Dico = Convert.ToDouble(vr.dgv_hanging_Item_sals_dgv.CurrentRow.Cells[11].Value);
                    if (Dico >= All_begin)
                    {
                        MessageBox.Show("الخصم اكبر من الرصيد الكلي ", "تحذير", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        vr.dgv_hanging_Item_sals_dgv.CurrentRow.Cells[11].Value = "0";
                    }
                    else
                    {
                        double resolt1 = All_begin - Dico;
                        vr.dgv_hanging_Item_sals_dgv.CurrentRow.Cells[12].Value = resolt1.ToString("N2");

                    }

                }
            }
        }

        // دالة تعبئة الاصناف 
        public void fill_Com_(int Item_num, int Item_storg_num, int unit_current)
        {
            var vr = Application.OpenForms["Main"] as Main;
            DataRow dr_row = DB_Add_delete_update_.Database.ds.Tables["Item"].Rows.Find(Item_num);// جلب بيانات الصنف كامل
            DataRow dr_Item_storg = DB_Add_delete_update_.Database.ds.Tables["Item_storg"].Rows.Find(Item_storg_num);// جلب بيانات الصنف كامل

            DataGridViewComboBoxCell DGV_Prodect = vr.dgv_hanging_Item_sals_dgv.Rows[vr.dgv_hanging_Item_sals_dgv.Rows.Count - 1].Cells[4] as DataGridViewComboBoxCell;// تحويل عمود الوحداد الا كمبو بكس
            DataRow[] dr_unit_pro = DB_Add_delete_update_.Database.ds.Tables["unite_items"].Select("Item_no = " + Item_num);// جلب بيانات الوحداد

            for (int i = 0; i < vr.dgv_hanging_Item_sals_dgv.Rows.Count; i++)
            {
                if (vr.dgv_hanging_Item_sals_dgv.Rows[i].Cells[15].Value != null)
                {
                    if (vr.dgv_hanging_Item_sals_dgv.Rows[i].Cells[15].Value != dr_Item_storg[0])
                    {
                        MessageBox.Show("لا يمكن اضافة  الصنف اكثر من مرة");
                        vr.dgv_hanging_Item_sals_dgv.Rows.Remove(vr.dgv_hanging_Item_sals_dgv.CurrentRow);
                        return;

                    }
                }
            }

            DataRow dr_unit_pro_kptol = DB_Add_delete_update_.Database.ds.Tables["therpeutic_unite"].Rows.Find(Convert.ToInt32(dr_unit_pro[0][1]));
            DataRow dr_unit_pro_avrg = DB_Add_delete_update_.Database.ds.Tables["therpeutic_unite"].Rows.Find(Convert.ToInt32(dr_unit_pro[0][2]));
            DataRow dr_unit_pro_smool = DB_Add_delete_update_.Database.ds.Tables["therpeutic_unite"].Rows.Find(Convert.ToInt32(dr_unit_pro[0][3]));
            DataRow dr_unit_sals = DB_Add_delete_update_.Database.ds.Tables["therpeutic_unite"].Rows.Find(Convert.ToInt32(dr_unit_pro[0][8]));
            vr.dgv_hanging_Item_sals_dgv.Rows[vr.dgv_hanging_Item_sals_dgv.Rows.Count - 1].Cells[2].Value = dr_row[1].ToString();// اسم الصنف
            vr.dgv_hanging_Item_sals_dgv.Rows[vr.dgv_hanging_Item_sals_dgv.Rows.Count - 1].Cells[3].Value = Convert.ToDateTime(dr_Item_storg[2]).ToString("d");// تاريخ الصلاحية
            vr.dgv_hanging_Item_sals_dgv.Rows[vr.dgv_hanging_Item_sals_dgv.Rows.Count - 1].Cells[5].Value = "1";// الكمية
            vr.dgv_hanging_Item_sals_dgv.Rows[vr.dgv_hanging_Item_sals_dgv.Rows.Count - 1].Cells[7].Value = dr_Item_storg[1];// الكمية

            //DGV_Prodect.Items.Clear();

            DataRow[] dr_dealing = DB_Add_delete_update_.Database.ds.Tables["dealings"].Select("Item_num = " + Item_num);
            vr.dgv_hanging_Item_sals_dgv.Rows[vr.dgv_hanging_Item_sals_dgv.Rows.Count - 1].Cells[8].Value = dr_dealing.Count() == 0 ? "0" : dr_dealing[0][2];// حد الطلب
            vr.dgv_hanging_Item_sals_dgv.Rows[vr.dgv_hanging_Item_sals_dgv.Rows.Count - 1].Cells[9].Value = Convert.ToDouble(dr_Item_storg[8]).ToString("N2");//  سعر البيع قبل الخصم
            vr.dgv_hanging_Item_sals_dgv.Rows[vr.dgv_hanging_Item_sals_dgv.Rows.Count - 1].Cells[10].Value = "0";//  نسبة الخصم
            vr.dgv_hanging_Item_sals_dgv.Rows[vr.dgv_hanging_Item_sals_dgv.Rows.Count - 1].Cells[11].Value = "0";//  قيمة الخصم 
            vr.dgv_hanging_Item_sals_dgv.Rows[vr.dgv_hanging_Item_sals_dgv.Rows.Count - 1].Cells[12].Value = Convert.ToDouble(dr_Item_storg[8]).ToString("N2");//  قيمة بعد الخصم 
            vr.dgv_hanging_Item_sals_dgv.Rows[vr.dgv_hanging_Item_sals_dgv.Rows.Count - 1].Cells[13].Value = Convert.ToDouble(dr_Item_storg[8]).ToString("N2");// الاجمالي
            vr.dgv_hanging_Item_sals_dgv.Rows[vr.dgv_hanging_Item_sals_dgv.Rows.Count - 1].Cells[15].Value = dr_Item_storg[0];// الاجمالي

            // عرض الوحدة التي تم ادخال الصنف الا المخزن بها والوحدات التي اصغر منها

            DataTable dt = new DataTable();
            dt.Columns.Add("num", typeof(int));
            dt.Columns.Add("name", typeof(string));

            if (Convert.ToInt32(dr_Item_storg[12]) == 1)
            {
                dt.Rows.Add(1, dr_unit_pro_kptol[1].ToString());
                dt.Rows.Add(2, dr_unit_pro_avrg[1].ToString());
                dt.Rows.Add(3, dr_unit_pro_smool[1].ToString());

            }
            else if (Convert.ToInt32(dr_Item_storg[12]) == 2)
            {
                dt.Rows.Add(2, dr_unit_pro_avrg[1].ToString());
                dt.Rows.Add(3, dr_unit_pro_smool[1].ToString());
            }
            else if (Convert.ToInt32(dr_Item_storg[12]) == 3)
            {
                dt.Rows.Add(3, dr_unit_pro_smool[1].ToString());

            }
            DGV_Prodect.DataSource = dt;
            DGV_Prodect.DisplayMember = "name";
            DGV_Prodect.ValueMember = "num";
            DGV_Prodect.Value = unit_current;
            vr.dgv_hanging_Item_sals_dgv.Rows[vr.dgv_hanging_Item_sals_dgv.Rows.Count - 1].Cells[6].Value = Convert.ToDouble(dr_Item_storg[8]).ToString("N2");// سعر البيع


        }

        // دالة البحث عن الفواتير المعلقة
        public void serch_hanging()
        {

            var vr = Application.OpenForms["Main"] as Main;


            vr.dgv_hanging_Data_footer_dgv.Rows.Clear();
            string query = "type_pross_sals =" + 3;

            // رقم المخون
            if (vr.txt_num_storg_hanging.Text.Trim() != string.Empty)
            {
                query += " and num_storg =" + vr.txt_num_storg_hanging.Text.Trim();

            }
            else
            {
                MessageBox.Show("يرجاء ادخال رقم المخزن", "Eroor", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            // رقم الفاتورة
            if (vr.txt_num_footer_sals_hang.Text.Trim() != string.Empty)
            {
                query += " and num_foot_sals =" + vr.txt_num_footer_sals_hang.Text.Trim();
            }
            //اسم العميل
            if (vr.txt_name_Cline_footer_hanging.Text.Trim() != string.Empty)
            {
                query += " and name_cline = '" + vr.txt_name_Cline_footer_hanging.Text.Trim() + "'";

            }
            DataRow[] dr_Data_Footer_Sals = DB_Add_delete_update_.Database.ds.Tables["Date_Footer_Sals"].Select(query);
            if (dr_Data_Footer_Sals.Count() != 0)
            {
                for (int i = 0; i < dr_Data_Footer_Sals.Count(); i++)
                {
                    object[] ob_Emp = DB_Add_delete_update_.Database.ds.Tables["TB_Employees"].Rows.Find(dr_Data_Footer_Sals[i][8]).ItemArray;
                    vr.dgv_hanging_Data_footer_dgv.Rows.Add(
                         dr_Data_Footer_Sals[i][0],
                         dr_Data_Footer_Sals[i][9],
                     Convert.ToDouble(dr_Data_Footer_Sals[i][3]).ToString("N2"),
                     Convert.ToDouble(dr_Data_Footer_Sals[i][13]).ToString("N2"),
                         dr_Data_Footer_Sals[i][12],
                         Convert.ToDouble(dr_Data_Footer_Sals[i][3]).ToString("N2"),
                         dr_Data_Footer_Sals[i][4],
                         Convert.ToDouble(dr_Data_Footer_Sals[i][5]).ToString("N2"),
                         dr_Data_Footer_Sals[i][6],
                         dr_Data_Footer_Sals[i][2],
                         ob_Emp[1],
                         dr_Data_Footer_Sals[i][15]
                        ); ;
                }
            }

        }

        public void Dgv_hanging_Data_footer_SelectionChanged_()
        {
            var vr = Application.OpenForms["Main"] as Main;
            vr.dgv_hanging_Item_sals_dgv.Rows.Clear();

            if (vr.dgv_hanging_Data_footer_dgv.CurrentRow != null)
            {
                vr.txt_count_Data_hanging.Text = vr.dgv_hanging_Data_footer_dgv.CurrentRow.Cells[1].Value.ToString();// عدد الاصناف
                vr.txt_value_begin_hanging_All_.Text = vr.dgv_hanging_Data_footer_dgv.CurrentRow.Cells[2].Value.ToString();// الاجمالي قبل الخصم
                vr.txt_Dicount_rate_hanging_All_.Text = vr.dgv_hanging_Data_footer_dgv.CurrentRow.Cells[6].Value.ToString();//   الخصم
                vr.txt_Dicount_value_hanging_All_.Text = vr.dgv_hanging_Data_footer_dgv.CurrentRow.Cells[7].Value.ToString();//   الخصم قيمة
                vr.txt_paind_hanging.Text = vr.dgv_hanging_Data_footer_dgv.CurrentRow.Cells[3].Value.ToString();// المدفوع
                vr.txt_note_hanging.Text = vr.dgv_hanging_Data_footer_dgv.CurrentRow.Cells[11].Value.ToString();//الملاحظة
                vr.txt_value_after_hanging.Text = Convert.ToDouble(Convert.ToDouble(vr.dgv_hanging_Data_footer_dgv.CurrentRow.Cells[8].Value) - Convert.ToDouble(vr.dgv_hanging_Data_footer_dgv.CurrentRow.Cells[3].Value)).ToString("N2");//الصافي
                DataRow[] dr_Item_hangiun = DB_Add_delete_update_.Database.ds.Tables["Item_footer_Sals"].Select("num_foot_Sals= " + vr.dgv_hanging_Data_footer_dgv.CurrentRow.Cells[0].Value);
                for (int i = 0; i < dr_Item_hangiun.Count(); i++)
                {

                    vr.dgv_hanging_Item_sals_dgv.Rows.Add(
                    null,
                    Convert.ToInt32(dr_Item_hangiun[i][1]));
                    fill_Com_(Convert.ToInt32(dr_Item_hangiun[i][1]), Convert.ToInt32(dr_Item_hangiun[i][3]), Convert.ToInt32(dr_Item_hangiun[i][5]));
                    vr.dgv_hanging_Item_sals_dgv.Rows[vr.dgv_hanging_Item_sals_dgv.Rows.Count - 1].Cells[5].Value = dr_Item_hangiun[i][4].ToString(); // تعبئة الكمية التي تم تعليقها
                    vr.dgv_hanging_Item_sals_dgv.Rows[vr.dgv_hanging_Item_sals_dgv.Rows.Count - 1].Cells[10].Value = dr_Item_hangiun[i][7]; // تعبئة الخصم نسبة   
                    vr.dgv_hanging_Item_sals_dgv.Rows[vr.dgv_hanging_Item_sals_dgv.Rows.Count - 1].Cells[11].Value = Convert.ToDouble(dr_Item_hangiun[i][8]).ToString("N2"); // تعبئة الخصم نسبة   
                    vr.dgv_hanging_Item_sals_dgv.Rows[vr.dgv_hanging_Item_sals_dgv.Rows.Count - 1].Cells[12].Value = Convert.ToDouble(dr_Item_hangiun[i][9]).ToString("N2"); // تعبئة الخصم قيمة   
                    vr.dgv_hanging_Item_sals_dgv.Rows[vr.dgv_hanging_Item_sals_dgv.Rows.Count - 1].Cells[13].Value = Convert.ToDouble(dr_Item_hangiun[i][10]).ToString("N2"); // تعبئة الخصم قيمة   
                    vr.dgv_hanging_Item_sals_dgv.Rows[vr.dgv_hanging_Item_sals_dgv.Rows.Count - 1].Cells[16].Value = dr_Item_hangiun[i][0].ToString(); // تعبئة الخصم قيمة   
                }
            }
        }

        public void serch_storg(object sender, KeyEventArgs e)
        {
            var vr = Application.OpenForms["Main"] as Main;

            if (e.KeyCode == Keys.Enter)
            {
                if (vr.txt_num_storg_hanging.Text.Trim() != string.Empty)
                {
                    DataRow dr_supper = DB_Add_delete_update_.Database.ds.Tables["Storg"].Rows.Find(vr.txt_num_storg_hanging.Text.Trim());
                    if (dr_supper != null)
                    {

                        vr.txt_name_storg_hanging.Text = dr_supper[1].ToString();
                    }
                    else
                    {
                        MessageBox.Show("يرجاء التحقق من رقم المخزن", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        vr.txt_name_storg_hanging.Text = "";
                        vr.txt_num_storg_hanging.Text = "";
                        vr.txt_num_storg_hanging.Focus();
                        vr.txt_num_storg_hanging.SelectAll();
                    }
                }
            }
        }
        public void Dgv_hanging_Item_sals_EditingControlShowing_(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            // دالة تقوم بهندلة الارقام
            var vr = Application.OpenForms["Main"] as Main;
            if (vr.dgv_hanging_Item_sals_dgv.CurrentRow != null)
            {
                if (vr.dgv_hanging_Item_sals_dgv.CurrentCell.ColumnIndex == 1)
                {
                    if (e.Control is TextBox)
                    {
                        e.Control.KeyPress += delegate (object Mysend, KeyPressEventArgs Mye)
                        {
                            Mye.Handled = false;

                        };
                    }
                }
                if (vr.dgv_hanging_Item_sals_dgv.CurrentCell.ColumnIndex == 5 || vr.dgv_hanging_Item_sals_dgv.CurrentCell.ColumnIndex == 10 || vr.dgv_hanging_Item_sals_dgv.CurrentCell.ColumnIndex == 11)
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
                else if (vr.dgv_hanging_Item_sals_dgv.CurrentCell.ColumnIndex == 4)
                {
                    ComboBox com = new ComboBox();
                    com = e.Control as ComboBox;

                    com.SelectedIndexChanged += delegate (object Mysender, EventArgs Me)
                    {
                        DataRow dr_Item_storg = DB_Add_delete_update_.Database.ds.Tables["Item_storg"].Rows.Find(vr.dgv_hanging_Item_sals_dgv.CurrentRow.Cells[15].Value);
                        DataRow[] dr_unit = DB_Add_delete_update_.Database.ds.Tables["unite_items"].Select("item_no =" + dr_Item_storg[9]);
                        double sals_pric = Convert.ToDouble(dr_Item_storg[8]);
                        double temp = Convert.ToDouble(dr_Item_storg[8]);
                        string qty = "";
                        // تحديد الوحدة التي تم ادخالها ثم تحديد ثم تحديد الكمية
                        if (Convert.ToInt32(dr_Item_storg[12]) == 1)
                        {
                            if (com.SelectedIndex == 0)
                            {
                                qty = dr_Item_storg[1].ToString();

                            }// لو كان الادخال وحدة كبرا والبيع وحدة وسطاء
                            else if (com.SelectedIndex == 1)
                            {
                                qty = dr_Item_storg[13].ToString();
                                sals_pric = Convert.ToDouble(temp / Convert.ToInt32(dr_unit[0][4]));

                            }// لو كان الادخال وحدة كبرا والبيع وحدة صغرا
                            else if (com.SelectedIndex == 2)
                            {
                                qty = dr_Item_storg[14].ToString();
                                double sals_pric_avrg = Convert.ToDouble(temp / Convert.ToInt32(dr_unit[0][4]));
                                sals_pric = Convert.ToDouble(sals_pric_avrg / Convert.ToInt32(dr_unit[0][5]));

                            }
                        }// لو كان الادخال وحدة وسطاء 
                        else if (Convert.ToInt32(dr_Item_storg[12]) == 2)
                        {
                            // لو كان الادخال وحدة وسطاء والبيع وحدة وسطاء
                            if (com.SelectedIndex == 0)
                            {
                                qty = dr_Item_storg[1].ToString();
                                sals_pric = Convert.ToDouble(dr_Item_storg[8]);
                            }// لو كان الادخال وحدة وسطاء والبيع وحدة صغرا
                            else if (com.SelectedIndex == 1)
                            {
                                qty = dr_Item_storg[14].ToString();
                                sals_pric = Convert.ToDouble(temp / Convert.ToInt32(dr_unit[0][5]));

                            }
                        }// لو كان الادخال وحدة صغرا والبيع وحدة صغرا
                        else if (Convert.ToInt32(dr_Item_storg[12]) == 3)
                        {

                            qty = dr_Item_storg[1].ToString();
                            sals_pric = Convert.ToDouble(dr_Item_storg[8]);

                        }
                        vr.dgv_hanging_Item_sals_dgv.CurrentRow.Cells[6].Value = sals_pric.ToString("N2");// سعر البيع الجديد
                        vr.dgv_hanging_Item_sals_dgv.CurrentRow.Cells[5].Value = "1";// الكية
                        vr.dgv_hanging_Item_sals_dgv.CurrentRow.Cells[7].Value = qty;// الكمية
                        vr.dgv_hanging_Item_sals_dgv.CurrentRow.Cells[9].Value = sals_pric.ToString("N2");// السعر قبل الخصم
                        vr.dgv_hanging_Item_sals_dgv.CurrentRow.Cells[10].Value = "0";// نسبة الخصم
                        vr.dgv_hanging_Item_sals_dgv.CurrentRow.Cells[11].Value = "0";// قيمة الخصم
                        vr.dgv_hanging_Item_sals_dgv.CurrentRow.Cells[12].Value = sals_pric.ToString("N2");//  السعر بعد الخصم
                        vr.dgv_hanging_Item_sals_dgv.CurrentRow.Cells[13].Value = sals_pric.ToString("N2");// مجموع سعر البيع
                        Totil_All_Fotter_sals();

                    };
                }
            }
        }

        public void Dgv_hanging_Item_sals_CellEndEdit()
        {
            // ترتيب تواريخ الصلاحية تصاعدي  معا فلترت الاصناف التي الرصيد صغر
            var vr = Application.OpenForms["Main"] as Main;
            if (vr.dgv_hanging_Item_sals_dgv.CurrentRow != null)
            {
                if (vr.dgv_hanging_Item_sals_dgv.CurrentCell.ColumnIndex == 1)
                {

                    if (vr.dgv_hanging_Item_sals_dgv.CurrentRow.Cells[1].Value != null)
                    {


                        DataTable dt = new classs_table.Items_Tools().GetItems_Storg_All(Convert.ToInt32(vr.txt_num_storg_hanging.Text));

                        if (vr.dgv_hanging_Item_sals_dgv.CurrentRow.Cells[1].Value.ToString().Count() >= 6)
                        {
                            DataRow[] dr_barcode = DB_Add_delete_update_.Database.ds.Tables["barcode"].Select("barcode_internath =" + vr.dgv_hanging_Item_sals_dgv.CurrentRow.Cells[1].Value.ToString());
                            if (dr_barcode.Count() != 0)
                            {
                                vr.dgv_hanging_Item_sals_dgv.CurrentRow.Cells[1].Value = dr_barcode[0][3];
                            }
                            else
                            {
                                MessageBox.Show("يرجاء التحقق من الصنف", "Eroor", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                remove_row_hanging();
                                return;
                            }
                        }


                        try
                        {
                            DataRow[] dr_Item_Storgh = dt.Select("Item_no = " + vr.dgv_hanging_Item_sals_dgv.CurrentRow.Cells[1].Value);
                        }
                        catch
                        {
                            remove_row_hanging();
                            throw new Exception("Error barco");
                            return;
                        }

                        DataRow[] dr_Item_Storg = dt.Select("Item_no = " + vr.dgv_hanging_Item_sals_dgv.CurrentRow.Cells[1].Value);

                        if (dr_Item_Storg.Count() != 0)
                        {

                            List<int> num_Item_storg_begin = new List<int>(); // تحفظ رقم الصنف الذي يوجد فية كميات
                            Dictionary<int, DateTime> Trteb = new Dictionary<int, DateTime>(); // تحفظ تاريخ الصنف معا رقمة 
                            for (int i = 0; i < dr_Item_Storg.Count(); i++)
                            {
                                if (Convert.ToInt32(dr_Item_Storg[i][14]) > 0) // فلترت الاصناف التي الكمية صفر
                                {
                                    if (Convert.ToDateTime(dr_Item_Storg[i][2]) > DateTime.Now) // فلترت التواريخ المنتهية
                                    {

                                        Trteb.Add(Convert.ToInt32(dr_Item_Storg[i][0]), Convert.ToDateTime(dr_Item_Storg[i][2]));// حفظ الرقم معا تاريخ الصلاحية
                                        num_Item_storg_begin.Add((int)dr_Item_Storg[i][0]);// حفظ الرقم المفلتر
                                    }
                                }

                            }
                            if (Trteb.Count != 0)
                            {

                                if (Trteb.Count == 1)
                                {
                                    object[] ob_Item_storg = DB_Add_delete_update_.Database.ds.Tables["Item_storg"].Rows.Find(num_Item_storg_begin[0]).ItemArray;
                                    object[] ob_Item = DB_Add_delete_update_.Database.ds.Tables["Item"].Rows.Find(ob_Item_storg[9]).ItemArray;
                                    new Sales_open_Add().fill_Com_(vr.dgv_hanging_Item_sals_dgv, Convert.ToInt32(ob_Item[0]), Convert.ToInt32(ob_Item_storg[0]));
                                    Totil_All_Fotter_sals();
                                    Item_count_hanging();
                                }
                                else
                                {
                                    // لو كان اكثر من صنف من نفس الرقم
                                    new Sales.hanging.frm_hanging_multe_Item().ShowDialog();
                                    Item_count_hanging();
                                }


                                //}

                            }

                        }
                        else
                        {
                            MessageBox.Show("يرجاء التحقق من الصنف", "Eroor", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            vr.dgv_hanging_Item_sals_dgv.CurrentRow.Cells[2].Value = null;
                            vr.dgv_hanging_Item_sals_dgv.CurrentRow.Cells[3].Value = null;
                            vr.dgv_hanging_Item_sals_dgv.CurrentRow.Cells[4].Value = null;
                            vr.dgv_hanging_Item_sals_dgv.CurrentRow.Cells[5].Value = null;
                            vr.dgv_hanging_Item_sals_dgv.CurrentRow.Cells[6].Value = null;
                            vr.dgv_hanging_Item_sals_dgv.CurrentRow.Cells[7].Value = null;
                            vr.dgv_hanging_Item_sals_dgv.CurrentRow.Cells[8].Value = null;
                            vr.dgv_hanging_Item_sals_dgv.CurrentRow.Cells[9].Value = null;
                            vr.dgv_hanging_Item_sals_dgv.CurrentRow.Cells[10].Value = null;
                            vr.dgv_hanging_Item_sals_dgv.CurrentRow.Cells[11].Value = null;
                            vr.dgv_hanging_Item_sals_dgv.CurrentRow.Cells[12].Value = null;
                            vr.dgv_hanging_Item_sals_dgv.CurrentRow.Cells[13].Value = null;
                            vr.dgv_hanging_Item_sals_dgv.CurrentRow.Cells[14].Value = null;
                            vr.dgv_hanging_Item_sals_dgv.CurrentRow.Cells[15].Value = null;
                            return;
                        }
                    }
                    //Totil_All_Fotter_sals();
                }
                else if (vr.dgv_hanging_Item_sals_dgv.CurrentCell.ColumnIndex == 5)
                {
                    if (vr.dgv_hanging_Item_sals_dgv.CurrentRow.Cells[5].Value == null)
                    {
                        vr.dgv_hanging_Item_sals_dgv.CurrentRow.Cells[5].Value = "1";
                    }
                    else
                    {
                        if (Convert.ToInt32(vr.dgv_hanging_Item_sals_dgv.CurrentRow.Cells[5].Value) > Convert.ToInt32(vr.dgv_hanging_Item_sals_dgv.CurrentRow.Cells[7].Value))
                        {
                            MessageBox.Show("الكمية المدخلة اكبر من  الرصيد", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            vr.dgv_hanging_Item_sals_dgv.CurrentRow.Cells[5].Value = "1";
                        }
                        else if (Convert.ToInt32(vr.dgv_hanging_Item_sals_dgv.CurrentRow.Cells[5].Value) == 0)
                        {
                            vr.dgv_hanging_Item_sals_dgv.CurrentRow.Cells[5].Value = "1";
                        }
                    }
                    Totil_All_Fotter_sals();

                }
                else if (vr.dgv_hanging_Item_sals_dgv.CurrentCell.ColumnIndex == 10 || vr.dgv_hanging_Item_sals_dgv.CurrentCell.ColumnIndex == 11)
                {
                    DataRow[] dr_deal = DB_Add_delete_update_.Database.ds.Tables["dealings"].Select("Item_num = '" + vr.dgv_hanging_Item_sals_dgv.CurrentRow.Cells[1].Value + "'");
                    if (dr_deal.Count() != 0)
                    {
                        if (Convert.ToBoolean(dr_deal[0][3]) == false)// التحقق من انهو مسموح بلخصم
                        {
                            MessageBox.Show("ليس مسموح لصنف هذا بالخص", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            vr.dgv_hanging_Item_sals_dgv.CurrentRow.Cells[10].Value = "0";
                            vr.dgv_hanging_Item_sals_dgv.CurrentRow.Cells[11].Value = "0";
                            return;
                        }

                        if (vr.dgv_hanging_Item_sals_dgv.CurrentCell.ColumnIndex == 10)// فلترت النسبة  الخثص المئوية
                        {

                            if (vr.dgv_hanging_Item_sals_dgv.CurrentRow.Cells[10].Value != null)
                            {
                                if (Convert.ToInt32(vr.dgv_hanging_Item_sals_dgv.CurrentRow.Cells[10].Value) > Convert.ToInt32(dr_deal[0][4])) // التحقق من الحد الاقصاء للخصم
                                {
                                    MessageBox.Show("الخصم اكبر من من الحد المسموح", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    vr.dgv_hanging_Item_sals_dgv.CurrentRow.Cells[10].Value = "0";
                                }
                            }
                        }

                        if (vr.dgv_hanging_Item_sals_dgv.CurrentCell.ColumnIndex == 11)// فلترت قيمة الخصم 
                        {

                            if (vr.dgv_hanging_Item_sals_dgv.CurrentRow.Cells[11].Value != null)
                            {
                                int sum_valu_disco = Convert.ToInt32(dr_deal[0][4]) - Convert.ToInt32(vr.dgv_hanging_Item_sals_dgv.CurrentRow.Cells[10].Value);

                                if (sum_valu_disco > 0) // التحقق من الحد الاقصاء للخصم
                                {
                                    // حساب نسبة الخصم الباقية وتحويلها الا قيمة ومقارنتها بلقيمة المخصومة والتحقق منها
                                    double All_begin = Convert.ToDouble(vr.dgv_hanging_Item_sals_dgv.CurrentRow.Cells[12].Value);
                                    double Dico = Convert.ToDouble(sum_valu_disco) / 100;

                                    double resolt1 = All_begin * Dico;
                                    double resolt2 = All_begin - resolt1;

                                    double resolu_sum_dic_val = All_begin - resolt2;
                                    if (Convert.ToDouble(vr.dgv_hanging_Item_sals_dgv.CurrentRow.Cells[11].Value) > resolu_sum_dic_val)
                                    {
                                        MessageBox.Show("قيمة الخصم اكبر من المسموحة", "Eroor", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                        vr.dgv_hanging_Item_sals_dgv.CurrentRow.Cells[11].Value = "0";
                                    }
                                }
                                else
                                {
                                    MessageBox.Show("لقد تم استخدام كل الخصم المسموح", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    vr.dgv_hanging_Item_sals_dgv.CurrentRow.Cells[11].Value = "0";

                                }
                            }
                        }




                    }
                    Totil_All_Fotter_sals();
                }

            }




        }

        public void remove_row_hanging()
        {
            var vr = Application.OpenForms["Main"] as Main;
            if (vr.dgv_hanging_Item_sals_dgv.CurrentRow != null)
            {
                if (vr.dgv_hanging_Item_sals_dgv.CurrentRow.Cells[16].Value != null)
                {

                    vr.dgv_hanging_Item_sals_dgv.CurrentRow.Visible = false;
                }
                else
                {

                vr.dgv_hanging_Item_sals_dgv.Rows.RemoveAt(vr.dgv_hanging_Item_sals_dgv.CurrentRow.Index);
                }
                Totil_All_Fotter_sals();
            }
            Item_count_hanging();
        }

    }
}
