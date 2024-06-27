using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Windows.Forms;

namespace Manag_ph.Sales
{
    class Sales_open_Add
    {
        public void open_Sales()
        {
            var vr = Application.OpenForms["Main"] as Main;
            DataRow dr = DB_Add_delete_update_.Database.ds.Tables["TB_LOGIN_EMP"].Rows.Find(new object[] { vr.txt_user_id_Emp.Caption, vr.txt_user_Emp.Caption });
            DataRow dr_casher = DB_Add_delete_update_.Database.ds.Tables["casher"].Rows.Find(dr[5]);

            if (dr_casher != null)
            {
                vr.txt_id_casher.Text = dr_casher[0].ToString();
                vr.txt_name_cacher.Text = dr_casher[1].ToString();
                DataRow dr_stirg_sels = DB_Add_delete_update_.Database.ds.Tables["Storg"].Rows.Find(dr_casher[3]);
                vr.txt_id_storg_sels.Text = dr_stirg_sels[0].ToString();
                vr.txt_name_storg_sels.Text = dr_stirg_sels[1].ToString();
                new classs_table.Items_Tools().showAndHideForm(vr.sals);
            }
        }


        void sum_pric()
        {
            var vr = Application.OpenForms["Main"] as Main;
            double sum_pric = 0;
            for (int i = 0; i < vr.dgv_sals_dgv.Rows.Count; i++)
            {
                if (vr.dgv_sals_dgv.Rows[i].Cells[6].Value != null)
                {

                    sum_pric += Convert.ToDouble(vr.dgv_sals_dgv.Rows[i].Cells[13].Value);
                }
            }
            vr.txt_begin_Dicount_All_sals.Text = sum_pric.ToString("N2");
        }

        // حساب الخصم الكلي 
        public void Totil_All_Fotter_sals()
        {
            Amunt();
            sum_qty_pric();
            sum_pric();
            Totil_All_sals();
            Item_count();

        }
        void Totil_All_sals()
        {

            var vr = Application.OpenForms["Main"] as Main;
            if (vr.dgv_sals_dgv.Rows.Count != 0)
            {
                if (vr.txt_Dicount_Rate_All_sals.Text != string.Empty)
                {
                    double All_begin = Convert.ToDouble(vr.txt_begin_Dicount_All_sals.Text);
                    double Dico = Convert.ToDouble(vr.txt_Dicount_Rate_All_sals.Text) / 100;

                    double resolt1 = All_begin * Dico;
                    double resolt2 = All_begin - resolt1;

                    vr.txt_end_Dico_All_sals.Text = resolt2.ToString("N2");
                }
                else
                {
                    vr.txt_end_Dico_All_sals.Text = vr.txt_begin_Dicount_All_sals.Text;
                }


                if (vr.txt_Dicount_value_All_sals.Text != string.Empty)
                {
                    double All_begin = Convert.ToDouble(vr.txt_end_Dico_All_sals.Text);
                    double Dico = Convert.ToDouble(vr.txt_Dicount_value_All_sals.Text);
                    if (Dico >= All_begin)
                    {
                        MessageBox.Show("الخصم اكبر من الرصيد الكلي ", "تحذير", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        vr.txt_Dicount_value_All_sals.Text = "0.00";
                    }
                    else
                    {
                        double resolt1 = All_begin - Dico;
                        vr.txt_end_Dico_All_sals.Text = resolt1.ToString("N2");

                    }
                }
            }

        }
        // حساب الخص لصنق
        void Amunt()
        {
            var vr = Application.OpenForms["Main"] as Main;
            if (vr.dgv_sals_dgv.CurrentRow != null)
            {

                if (vr.dgv_sals_dgv.CurrentRow.Cells[10].Value != null)
            {
                double All_begin = Convert.ToDouble(vr.dgv_sals_dgv.CurrentRow.Cells[9].Value);
                double Dico = Convert.ToDouble(vr.dgv_sals_dgv.CurrentRow.Cells[10].Value) / 100;

                double resolt1 = All_begin * Dico;
                double resolt2 = All_begin - resolt1;

                vr.dgv_sals_dgv.CurrentRow.Cells[12].Value = resolt2.ToString("N2");
            }
            else
            {
                vr.dgv_sals_dgv.CurrentRow.Cells[12].Value = vr.dgv_sals_dgv.CurrentRow.Cells[9].Value;
            }


            if (vr.dgv_sals_dgv.CurrentRow.Cells[11].Value != null)
            {
                double All_begin = Convert.ToDouble(vr.dgv_sals_dgv.CurrentRow.Cells[12].Value);
                double Dico = Convert.ToDouble(vr.dgv_sals_dgv.CurrentRow.Cells[11].Value);
                if (Dico >= All_begin)
                {
                    MessageBox.Show("الخصم اكبر من الرصيد الكلي ", "تحذير", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    vr.dgv_sals_dgv.CurrentRow.Cells[11].Value = "0";
                }
                else
                {
                    double resolt1 = All_begin - Dico;
                    vr.dgv_sals_dgv.CurrentRow.Cells[12].Value = resolt1.ToString("N2");

                }

            }
        }

        }





        public void Add_Cline(object sender, KeyEventArgs e)
        {
            var vr = Application.OpenForms["Main"] as Main;

            if (e.KeyCode == Keys.Enter)
            {
                if (vr.rb_yup_sals.Checked)
                {
                    if (vr.txt_num_cline_sals.Text.Trim() != string.Empty)
                    {
                        // جلب بيانات العميل وحساباتهم
                        DataRow dr_cline_find = DB_Add_delete_update_.Database.ds.Tables["Clien"].Rows.Find(vr.txt_num_cline_sals.Text.Trim());
                        DataRow[] dr_cline_select = DB_Add_delete_update_.Database.ds.Tables["Clien"].Select("phon1_clin = " + vr.txt_num_cline_sals.Text.Trim() + "");
                        //DataRow []dr_cline_cont = DB_Add_delete_update_.Database.ds.Tables["Clients_And_Contracts"].Select("num_clin = " + dr_cline_find[0] + "");
                        //DataRow dr_cont = DB_Add_delete_update_.Database.ds.Tables["Contracts"].Rows.Find(dr_cline_find[1]);
                        //DataRow dr_con_now = DB_Add_delete_update_.Database.ds.Tables["Contracts_now"].Rows.Find(dr_cont[1]);

                        if (dr_cline_find != null)
                        {

                            if (Convert.ToBoolean(dr_cline_find[3]) != true)// لو كان  الموظف موقف
                            {

                              //  vr.using_contracr.Visible = true;
                                vr.txt_num_cline_sals.Text = dr_cline_find[0].ToString();
                                vr.txt_name_cline_sals.Text = dr_cline_find[1].ToString();
                                DataRow dr_Account = DB_Add_delete_update_.Database.ds.Tables["Stock_client"].Rows.Find(dr_cline_find[10]);
                                vr.txt_deictor_cline_sals.Text = dr_Account[4].ToString();

                                if (Convert.ToDouble(dr_Account[1]) == 0 && Convert.ToDouble(dr_Account[2]) > 0)
                                {
                                    vr.label_Dbtet_sels.Text = String.Format("مدين");//  "مدين";
                                }
                                else if (Convert.ToDouble(dr_Account[1]) >= 0 && Convert.ToDouble(dr_Account[2]) == 0)
                                {
                                    vr.label_Dbtet_sels.Text = String.Format("دائن");// "دائن";
                                }

                            }
                            else
                            {
                                MessageBox.Show("هذا العمبل موقف");
                                vr.txt_name_cline_sals.Text = "";
                                vr.txt_deictor_cline_sals.Text = "";
                                vr.txt_num_cline_sals.SelectAll();
                                return;
                            }

                        }
                        else if (dr_cline_select.Count() != 0)
                        {
                            if (Convert.ToBoolean(dr_cline_select[0][3]) != true)// لو كان  الموظف موقف
                            {
                                vr.txt_num_cline_sals.Text = dr_cline_select[0][0].ToString();
                                vr.txt_name_cline_sals.Text = dr_cline_select[0][1].ToString();
                                DataRow dr_Account = DB_Add_delete_update_.Database.ds.Tables["Stock_client"].Rows.Find(dr_cline_select[0][10]);
                                vr.txt_deictor_cline_sals.Text = dr_Account[4].ToString();
                            }

                            else
                            {
                                MessageBox.Show("هذا الموظف موقف");
                                vr.txt_name_cline_sals.Text = "";
                                vr.txt_deictor_cline_sals.Text = "";
                                vr.txt_num_cline_sals.SelectAll();
                                return;
                            }
                        }
                        else
                        {
                            MessageBox.Show("يرجاء التحقق من المدخلات", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            vr.txt_name_cline_sals.Text = "";
                            vr.txt_deictor_cline_sals.Text = "";
                            vr.txt_num_cline_sals.SelectAll();

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

        public void Dgv_sals_EditingControlShowing_(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            // دالة تقوم بهندلة الارقام
            var vr = Application.OpenForms["Main"] as Main;



            if (vr.dgv_sals_dgv.CurrentRow != null)
            {
                if (vr.dgv_sals_dgv.CurrentCell.ColumnIndex == 1 )
                {
                    if (e.Control is TextBox)
                    {
                        e.Control.KeyPress += delegate (object Mysend, KeyPressEventArgs Mye)
                        {
                            Mye.Handled = false;
                        };
                    }
                }
                if (vr.dgv_sals_dgv.CurrentCell.ColumnIndex == 5 || vr.dgv_sals_dgv.CurrentCell.ColumnIndex == 10 || vr.dgv_sals_dgv.CurrentCell.ColumnIndex == 11)
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
                else if (vr.dgv_sals_dgv.CurrentCell.ColumnIndex == 4)
                {
                    ComboBox com = new ComboBox();
                    com = e.Control as ComboBox;

                    com.SelectedIndexChanged += delegate (object Mysender, EventArgs Me)
                    {
                        DataRow dr_Item_storg = DB_Add_delete_update_.Database.ds.Tables["Item_storg"].Rows.Find(vr.dgv_sals_dgv.CurrentRow.Cells[15].Value);
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
                        vr.dgv_sals_dgv.CurrentRow.Cells[6].Value = sals_pric.ToString("N2");// سعر البيع الجديد
                        vr.dgv_sals_dgv.CurrentRow.Cells[5].Value = "1";// الكية
                        vr.dgv_sals_dgv.CurrentRow.Cells[7].Value = qty;// الرصيد
                        vr.dgv_sals_dgv.CurrentRow.Cells[9].Value = sals_pric.ToString("N2");// السعر قبل الخصم
                        vr.dgv_sals_dgv.CurrentRow.Cells[10].Value = "0";// نسبة الخصم
                        vr.dgv_sals_dgv.CurrentRow.Cells[11].Value = "0";// قيمة الخصم
                        vr.dgv_sals_dgv.CurrentRow.Cells[12].Value = sals_pric.ToString("N2");//  السعر بعد الخصم
                        vr.dgv_sals_dgv.CurrentRow.Cells[13].Value = sals_pric.ToString("N2");// مجموع سعر البيع
                        Totil_All_Fotter_sals();

                    };
                }
            }
        }


        // دالة لتعبئة جدول المبيعات بالبيانات
        public void fill_Com_(DataGridView dgv, int Item_num, int Item_storg_num, int unit_type = -1)
        {
            if (dgv.CurrentRow != null)
            {


                DataRow dr_row = DB_Add_delete_update_.Database.ds.Tables["Item"].Rows.Find(Item_num);// جلب بيانات الصنف كامل
                DataRow dr_Item_storg = DB_Add_delete_update_.Database.ds.Tables["Item_storg"].Rows.Find(Item_storg_num);// جلب بيانات الصنف كامل

                DataGridViewComboBoxCell DGV_Prodect = dgv.CurrentRow.Cells[4] as DataGridViewComboBoxCell;// تحويل عمود الوحداد الا كمبو بكس
                DataRow[] dr_unit_pro = DB_Add_delete_update_.Database.ds.Tables["unite_items"].Select("Item_no = " + Item_num);// جلب بيانات الوحداد

                for (int i = 0; i < dgv.Rows.Count; i++)
                {
                    if (dgv.Rows[i].Cells[15].Value != null)
                    {
                        if (Convert.ToInt32(dgv.Rows[i].Cells[15].Value.ToString().Trim()) == Convert.ToInt32(dr_Item_storg[0]))
                        {
                          
                            MessageBox.Show("لا يمكن اضافة  الصنف اكثر من مرة");
                            dgv.Rows.Remove(dgv.CurrentRow);
                            return;
                            
                        }
                    }
                }

                DataRow dr_unit_pro_kptol = DB_Add_delete_update_.Database.ds.Tables["therpeutic_unite"].Rows.Find(Convert.ToInt32(dr_unit_pro[0][1]));
                DataRow dr_unit_pro_avrg = DB_Add_delete_update_.Database.ds.Tables["therpeutic_unite"].Rows.Find(Convert.ToInt32(dr_unit_pro[0][2]));
                DataRow dr_unit_pro_smool = DB_Add_delete_update_.Database.ds.Tables["therpeutic_unite"].Rows.Find(Convert.ToInt32(dr_unit_pro[0][3]));
                DataRow dr_unit_sals = DB_Add_delete_update_.Database.ds.Tables["therpeutic_unite"].Rows.Find(Convert.ToInt32(dr_unit_pro[0][8]));
                dgv.CurrentRow.Cells[2].Value = dr_row[1].ToString();// اسم الصنف
                dgv.CurrentRow.Cells[3].Value = Convert.ToDateTime(dr_Item_storg[2]).ToString("d");// تاريخ الصلاحية
                dgv.CurrentRow.Cells[5].Value = "1";// الكمية
                dgv.CurrentRow.Cells[7].Value = dr_Item_storg[1];// الكمية

                //DGV_Prodect.Items.Clear();

                DataRow[] dr_dealing = DB_Add_delete_update_.Database.ds.Tables["dealings"].Select("Item_num = " + Item_num);
                dgv.CurrentRow.Cells[8].Value = dr_dealing.Count() == 0 ? "0" : dr_dealing[0][2];// حد الطلب
                dgv.CurrentRow.Cells[9].Value = Convert.ToDouble(dr_Item_storg[8]).ToString("N2");//  سعر البيع قبل الخصم
                dgv.CurrentRow.Cells[10].Value = "0";//  نسبة الخصم
                dgv.CurrentRow.Cells[11].Value = "0";//  قيمة الخصم 
                dgv.CurrentRow.Cells[12].Value = Convert.ToDouble(dr_Item_storg[8]).ToString("N2");//  قيمة بعد الخصم 
                dgv.CurrentRow.Cells[13].Value = Convert.ToDouble(dr_Item_storg[8]).ToString("N2");// الاجمالي
                dgv.CurrentRow.Cells[15].Value = dr_Item_storg[0];// رقم الصنف المخزن

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
                if (unit_type != -1)
                {
                    DGV_Prodect.Value = unit_type;
                }
                else
                {

                    DGV_Prodect.Value = dt.Rows[0][0];
                }
                dgv.CurrentRow.Cells[6].Value = Convert.ToDouble(dr_Item_storg[8]).ToString("N2");// سعر البيع

            }

        }
        void sum_qty_pric()
        {
            var vr = Application.OpenForms["Main"] as Main;
            if (vr.dgv_sals_dgv.CurrentRow != null)
            {
                vr.dgv_sals_dgv.CurrentRow.Cells[13].Value = Convert.ToDouble(Convert.ToInt32(vr.dgv_sals_dgv.CurrentRow.Cells[5].Value) * Convert.ToDouble(vr.dgv_sals_dgv.CurrentRow.Cells[12].Value)).ToString("N2");
            }
        }

        // حساب عدد الاصناف
        void Item_count()
        {
            var vr = Application.OpenForms["Main"] as Main;
            int Count_Item = 0;
            for (int i = 0; i < vr.dgv_sals_dgv.Rows.Count; i++)
            {
                if (vr.dgv_sals_dgv.Rows[i].Cells[3].Value != null)
                {
                    Count_Item += 1;
                }
            }
            vr.txt_Count_Item_sals.Text = Count_Item.ToString();
        }

        public void Dgv_sals_CellEndEdit_()
        {
            // ترتيب تواريخ الصلاحية تصاعدي  معا فلترت الاصناف التي الرصيد صغر
            var vr = Application.OpenForms["Main"] as Main;
            if (vr.dgv_sals_dgv.CurrentRow != null)
            {
                if (vr.dgv_sals_dgv.CurrentCell.ColumnIndex == 1)
                {

                    if (vr.dgv_sals_dgv.CurrentRow.Cells[1].Value != null)
                    {
                        DataTable dt = new classs_table.Items_Tools().GetItems_Storg_All(Convert.ToInt32(vr.txt_id_storg_sels.Text));

                       
                        if (vr.dgv_sals_dgv.CurrentRow.Cells[1].Value.ToString().Count() >= 5)
                        {
                          DataRow[] dr_barcode=  DB_Add_delete_update_.Database.ds.Tables["barcode"].Select("barcode_internath ='"+ vr.dgv_sals_dgv.CurrentRow.Cells[1].Value.ToString()+"'");
                            if (dr_barcode.Count() !=0)
                            {
                                vr.dgv_sals_dgv.CurrentRow.Cells[1].Value = dr_barcode[0][3];
                            }
                            else
                            {
                                MessageBox.Show("يرجاء التحقق من الصنف", "Eroor", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                Remove_Rows();
                                return;
                            }
                        }

                        try
                        {
                            DataRow[] dr_Item_Storgh = dt.Select("Item_no = " + vr.dgv_sals_dgv.CurrentRow.Cells[1].Value);
                        }
                        catch
                        {
                            Remove_Rows();
                            throw new Exception("Error barco");
                        }

                        DataRow[] dr_Item_Storg = dt.Select("Item_no = " + vr.dgv_sals_dgv.CurrentRow.Cells[1].Value);

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
                                   
                                    fill_Com_(vr.dgv_sals_dgv, Convert.ToInt32(ob_Item[0]), Convert.ToInt32(ob_Item_storg[0]));
                                    Totil_All_Fotter_sals();
                                    Item_count();
                                }
                                else
                                {
                                    // لو كان اكثر من صنف من نفس الرقم
                                    new frm_sals_multe_Item().ShowDialog();
                                }


                                //}

                            }
                            else
                            {
                                MessageBox.Show("لم يعد هناك رصيد من هذا الصنف", "Eroor", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                Remove_Rows();
                                return;
                            }

                        }
                        else
                        {
                            MessageBox.Show("يرجاء التحقق من الصنف", "Eroor", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            Remove_Rows();
                            //vr.dgv_sals_dgv.CurrentRow.Cells[2].Value = null;
                            //vr.dgv_sals_dgv.CurrentRow.Cells[3].Value = null;
                            //vr.dgv_sals_dgv.CurrentRow.Cells[4].Value = null;
                            //vr.dgv_sals_dgv.CurrentRow.Cells[5].Value = null;
                            //vr.dgv_sals_dgv.CurrentRow.Cells[6].Value = null;
                            //vr.dgv_sals_dgv.CurrentRow.Cells[7].Value = null;
                            //vr.dgv_sals_dgv.CurrentRow.Cells[8].Value = null;
                            //vr.dgv_sals_dgv.CurrentRow.Cells[9].Value = null;
                            //vr.dgv_sals_dgv.CurrentRow.Cells[10].Value = null;
                            //vr.dgv_sals_dgv.CurrentRow.Cells[11].Value = null;
                            //vr.dgv_sals_dgv.CurrentRow.Cells[12].Value = null;
                            //vr.dgv_sals_dgv.CurrentRow.Cells[13].Value = null;
                            //vr.dgv_sals_dgv.CurrentRow.Cells[14].Value = null;
                            //vr.dgv_sals_dgv.CurrentRow.Cells[15].Value = null;
                            return;
                        }
                    }
                    //Totil_All_Fotter_sals();
                }
                else if (vr.dgv_sals_dgv.CurrentCell.ColumnIndex == 5)
                {
                    if (vr.dgv_sals_dgv.CurrentRow.Cells[5].Value == null)
                    {
                        vr.dgv_sals_dgv.CurrentRow.Cells[5].Value = "1";
                    }
                    else
                    {
                        if (Convert.ToInt32(vr.dgv_sals_dgv.CurrentRow.Cells[5].Value) > Convert.ToInt32(vr.dgv_sals_dgv.CurrentRow.Cells[7].Value))
                        {
                            MessageBox.Show("الكمية المدخلة اكبر من  الرصيد", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            vr.dgv_sals_dgv.CurrentRow.Cells[5].Value = "1";
                        }
                        else if (Convert.ToInt32(vr.dgv_sals_dgv.CurrentRow.Cells[5].Value) == 0)
                        {
                            vr.dgv_sals_dgv.CurrentRow.Cells[5].Value = "1";
                        }
                    }
                    Totil_All_Fotter_sals();
                   if (vr.dgv_sals_dgv.CurrentCell.ColumnIndex != 4)
                    {

                        //vr.dgv_sals_dgv.CurrentRow.Cells[0].Selected = true;
                    }


                }
                else if (vr.dgv_sals_dgv.CurrentCell.ColumnIndex == 10 || vr.dgv_sals_dgv.CurrentCell.ColumnIndex == 11)
                {
                    DataRow[] dr_deal = DB_Add_delete_update_.Database.ds.Tables["dealings"].Select("Item_num = '" + vr.dgv_sals_dgv.CurrentRow.Cells[1].Value + "'");
                    if (dr_deal.Count() != 0)
                    {
                        if (Convert.ToBoolean(dr_deal[0][3]) == false)// التحقق من انهو مسموح بلخصم
                        {
                            MessageBox.Show("ليس مسموح لصنف هذا بالخص", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            vr.dgv_sals_dgv.CurrentRow.Cells[10].Value = "0";
                            vr.dgv_sals_dgv.CurrentRow.Cells[11].Value = "0";
                            return;
                        }

                        if (vr.dgv_sals_dgv.CurrentCell.ColumnIndex == 10)// فلترت النسبة  الخثص المئوية
                        {

                            if (vr.dgv_sals_dgv.CurrentRow.Cells[10].Value != null)
                            {
                                if (Convert.ToInt32(vr.dgv_sals_dgv.CurrentRow.Cells[10].Value) > Convert.ToInt32(dr_deal[0][4])) // التحقق من الحد الاقصاء للخصم
                                {
                                    MessageBox.Show("الخصم الكبر من من الحد المسموح", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    vr.dgv_sals_dgv.CurrentRow.Cells[10].Value = "0";
                                }
                            }
                        }

                        if (vr.dgv_sals_dgv.CurrentCell.ColumnIndex == 11)// فلترت قيمة الخصم 
                        {

                            if (vr.dgv_sals_dgv.CurrentRow.Cells[11].Value != null)
                            {
                                int sum_valu_disco = Convert.ToInt32(dr_deal[0][4]) - Convert.ToInt32(vr.dgv_sals_dgv.CurrentRow.Cells[10].Value);

                                if (sum_valu_disco > 0) // التحقق من الحد الاقصاء للخصم
                                {
                                    // حساب نسبة الخصم الباقية وتحويلها الا قيمة ومقارنتها بلقيمة المخصومة والتحقق منها
                                    double All_begin = Convert.ToDouble(vr.dgv_sals_dgv.CurrentRow.Cells[12].Value);
                                    double Dico = Convert.ToDouble(sum_valu_disco) / 100;

                                    double resolt1 = All_begin * Dico;
                                    double resolt2 = All_begin - resolt1;

                                    double resolu_sum_dic_val = All_begin - resolt2;
                                    if (Convert.ToDouble(vr.dgv_sals_dgv.CurrentRow.Cells[11].Value) > resolu_sum_dic_val)
                                    {
                                        MessageBox.Show("قيمة الخصم اكبر من المسموحة", "Eroor", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                        vr.dgv_sals_dgv.CurrentRow.Cells[11].Value = "0";
                                    }
                                }
                                else
                                {
                                    MessageBox.Show("لقد تم استخدام كل الخصم المسموح", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    vr.dgv_sals_dgv.CurrentRow.Cells[11].Value = "0";

                                }
                            }
                        }




                    }
                    Totil_All_Fotter_sals();
                }

            }

           


        }
        public void Txt_Dicount_Rate_All_sals_KeyUp_(object sender, KeyEventArgs e)
        {
            var vr = Application.OpenForms["Main"] as Main;
            if (vr.txt_Dicount_Rate_All_sals.Text.Trim() != string.Empty)
            {
                if (Convert.ToInt32(vr.txt_Dicount_Rate_All_sals.Text.Trim()) > 100)
                {
                    vr.txt_Dicount_Rate_All_sals.Text = "0";
                    vr.txt_Dicount_Rate_All_sals.SelectAll();

                }
                else
                {
                    Totil_All_sals();
                }
            }
            else
            {
                vr.txt_Dicount_Rate_All_sals.Text = "0";
                vr.txt_Dicount_Rate_All_sals.SelectAll();
            }
        }

        public void Txt_Dicount_Value_All_sals_Keyup_(object sender, KeyEventArgs e)
        {
            var vr = Application.OpenForms["Main"] as Main;
            if (vr.txt_Dicount_value_All_sals.Text.Trim() != string.Empty)
            {
                if (Convert.ToInt32(vr.txt_Dicount_value_All_sals.Text.Trim()) > Convert.ToDouble(vr.txt_end_Dico_All_sals.Text))
                {
                    vr.txt_Dicount_value_All_sals.Text = "0";
                    vr.txt_Dicount_value_All_sals.SelectAll();

                }
                else
                {
                    Totil_All_sals();
                }
            }
            else
            {
                vr.txt_Dicount_value_All_sals.Text = "0";
                vr.txt_Dicount_value_All_sals.SelectAll();
            }
        }

        public void Remove_Rows()
        {
            var vr = Application.OpenForms["Main"] as Main;

            if (vr.dgv_sals_dgv.CurrentRow != null)
            {
                vr.dgv_sals_dgv.Rows.RemoveAt(vr.dgv_sals_dgv.CurrentRow.Index);
                //if (Convert.ToDouble(vr.txt_end_Dico_All_sals.Text) <=0)
                //{
                //    Item_count();
                //    Totil_All_sals();
                //}
                //else
                //{
                //    Item_count();
                //    Totil_All_sals();
                //}
                check_Data_of_Row_And_Remove();
                //Totil_All_Fotter_sals();
            }
        }

        public void check_Data_of_Row_And_Remove()
        {
            var vr = Application.OpenForms["Main"] as Main;
            bool checkitem = false;
            for (int i = 0; i < vr.dgv_sals_dgv.RowCount; i++)
            {
                if (vr.dgv_sals_dgv.Rows[i].Cells[6].Value == null)
                {
                    vr.dgv_sals_dgv.Rows.RemoveAt(i);
                    if (!checkitem)
                    {
                        vr.txt_end_Dico_All_sals.Text = "0.00";
                        vr.txt_Count_Item_sals.Text = "0";
                        vr.txt_begin_Dicount_All_sals.Text = "0.00";
                        vr.txt_Dicount_value_All_sals.Text = "0.00";
                        vr.txt_Dicount_Rate_All_sals.Text = "0";
                    }
                }
                else
                {
                    checkitem = true;
                    Totil_All_Fotter_sals();
                }
            }
            if (vr.dgv_sals_dgv.RowCount==0)
            {
                vr.txt_end_Dico_All_sals.Text = "0.00";
                vr.txt_Count_Item_sals.Text = "0";
                vr.txt_begin_Dicount_All_sals.Text = "0.00";
                vr.txt_Dicount_value_All_sals.Text = "0.00";
                vr.txt_Dicount_Rate_All_sals.Text = "0";
            }
        }
        public bool check_Blance()
        {
            var vr = Application.OpenForms["Main"] as Main;

            for (int i = 0; i < vr.dgv_sals_dgv.Rows.Count; i++)
            {
                if ( Convert.ToInt64(vr.dgv_sals_dgv.Rows[i].Cells[7].Value) <= 0)
                {
                  
                    return true ;
                }
            }
            return false;

        }
    }
}
