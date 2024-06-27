using Manag_ph.classs_table;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Manag_ph.storg
{
    class update_Open_storg
    {


        double prodect = 0;
        double tex = 0;
        double descount = 0;

        public bool Check_Empty_Item_storg(DataGridView dgv)
        {
            bool ch = true;
            for (int i = 0; i < dgv.Rows.Count; i++)
            {
                double temp = Convert.ToDouble(dgv.Rows[i].Cells[6].Value);
                object str = dgv.Rows[i].Cells[5].Value;
                object qut = dgv.Rows[i].Cells[3].Value;
                object price = dgv.Rows[i].Cells[6].Value;
                object prodect = dgv.Rows[i].Cells[9].Value;

                if (dgv.Rows[i].Cells[2].Value == null)
                {
                    MessageBox.Show("يرجا حذف الاسطر الفاضية ");
                    ch = false;
                    i = dgv.Rows.Count;
                }
                else if (temp == null || temp <= 0)
                {

                    MessageBox.Show("يرجا ملاء سعر البيع");
                    ch = false;
                    i = dgv.Rows.Count;
                }
                else if (str == null)
                {
                    MessageBox.Show("يرجا ملاء تاريخ الانتها");
                    ch = false;
                    i = dgv.Rows.Count;
                }
                else if (qut == null || Convert.ToInt32(qut) == 0)
                {
                    MessageBox.Show("يرجا ملاء الكميات");
                    ch = false;
                    i = dgv.Rows.Count;

                }
                else if (Convert.ToDouble(price) < Convert.ToDouble(prodect))
                {
                    MessageBox.Show("سعر البيع اصغر من سعر الشر ");
                    ch = false;
                    i = dgv.Rows.Count;
                }


            }
            return ch;
        }

        public double Calc_protect_cobtl(string tableName, int numUnit)
        {
            var vr = Application.OpenForms["Main"] as Main;
            double reslt = 0;
            //سعر الشرا للوحدة الكبرا
            double pres_Prodect = Convert.ToDouble(Items_Tools.Dataunit.Tables[tableName].Rows[0][2]);


            //سعر الشراء للوحدة الوسطاء
            double num_unitavrg = Convert.ToDouble(Items_Tools.Dataunit.Tables[tableName].Rows[1][2]);
            //جلب سعر الشرا للوحدة المتوسطة
            double reslt_avrg = pres_Prodect / num_unitavrg;
            if (numUnit == 1)
            {
                reslt = pres_Prodect;
            }
            else if (numUnit == 2)
            {

                reslt = reslt_avrg;
            }
            else if (numUnit == 3)
            {
                //عدد الوحدات الصغرا
                double num_unit_smool = Convert.ToDouble(Items_Tools.Dataunit.Tables[tableName].Rows[2][2]);
                //جلب سعر الشرا للوحدة الصغرا
                double reslt_somml = reslt_avrg / num_unit_smool;
                reslt = reslt_somml;
            }

            return reslt;

        }

        public void serch_number(object sender, KeyPressEventArgs e)
        {
            var dr = Application.OpenForms["Main"] as Main;
            //للبحث عن الرقم لتعديل في المخزون الافتتاحي
            if (e.KeyChar == (Char)Keys.Enter)
            {
                if (dr.txt_num_stor.Text.Trim() != string.Empty)
                {
                    DataRow Data_Rows_Storg = DB_Add_delete_update_.Database.ds.Tables["Storg"].Rows.Find(Convert.ToInt32(dr.txt_num_stor.Text));
                    if (Data_Rows_Storg != null)
                    {
                        dr.txt_name_storg.Text = Data_Rows_Storg[1].ToString();
                    }
                    else
                    {
                        MessageBox.Show("الرقم المدخل ليس موجود");
                    }
                }

            }
            if (!(char.IsDigit(e.KeyChar)) && e.KeyChar != (Char)Keys.Back)
            {
                e.Handled = true;
            }
        }

        // دالة للبحث والتعديل عن المخزون الافتتاحي
        public void update_open_storg_serch(object sender, KeyPressEventArgs e)
        {
            var dr = Application.OpenForms["Main"] as Main;


            if (e.KeyChar == (Char)Keys.Enter)
            {
                dr.dgv_open_storg_update_dgv.Rows.Clear();
                int numSerch = MyTool_1.GetNmberOnly(dr.txt_num_sum.Text);
                //اضافة البيانات المجموعة
                DataRow Data_Rows_sum_storg = DB_Add_delete_update_.Database.ds.Tables["sum_storg_Item"].Rows.Find(numSerch);
                if (Data_Rows_sum_storg == null)
                {
                    MessageBox.Show("تئكد من الرقم المدخل");
                }
                else
                {
                    dr.blb_count_update.Text = Data_Rows_sum_storg[1].ToString();
                    dr.blb_Totl_pric_update.Text = Data_Rows_sum_storg[2].ToString();
                    dr.lbl_Totle_prodect_update.Text = Data_Rows_sum_storg[3].ToString();
                    dr.lbl_pro_pric_update.Text = Data_Rows_sum_storg[4].ToString();

                    DataRow Data_Rows_storg = DB_Add_delete_update_.Database.ds.Tables["Storg"].Rows.Find(Data_Rows_sum_storg[5]);
                    DataRow[] Data_Rows_Item_stor = DB_Add_delete_update_.Database.ds.Tables["Item_storg"].Select("sum_num = " + numSerch);
                    dr.txt_num_stor_update.Text = Data_Rows_storg[0].ToString();
                    dr.txt_name_storg_update.Text = Data_Rows_storg[1].ToString();
                    for (int i = 0; i < Data_Rows_Item_stor.Count(); i++)
                    {
                        Items_Tools.DGV_Test(dr.dgv_open_storg_update_dgv, Data_Rows_Item_stor[i][9].ToString());
                        dr.dgv_open_storg_update_dgv.Rows[i].Cells[3].Value = Data_Rows_Item_stor[i][1];//الكميات
                        dr.dgv_open_storg_update_dgv.Rows[i].Cells[4].Value = Data_Rows_Item_stor[i][3];//البونص
                        DateTime det = Convert.ToDateTime(Data_Rows_Item_stor[i][2]);
                        dr.dgv_open_storg_update_dgv.Rows[i].Cells[5].Value = det.Date.ToString("d");
                        dr.dgv_open_storg_update_dgv.Rows[i].Cells[6].Value = Data_Rows_Item_stor[i][8];//سعر البيع
                        dr.dgv_open_storg_update_dgv.Rows[i].Cells[7].Value = Data_Rows_Item_stor[i][4];//الخصم
                        dr.dgv_open_storg_update_dgv.Rows[i].Cells[8].Value = Data_Rows_Item_stor[i][5];//الضريبة
                        dr.dgv_open_storg_update_dgv.Rows[i].Cells[9].Value = Data_Rows_Item_stor[i][7];//سعر البيع
                        dr.dgv_open_storg_update_dgv.Rows[i].Cells[10].Value = Data_Rows_Item_stor[i][6];//سعر الربح
                        DataRow unit_Coms = DB_Add_delete_update_.Database.ds.Tables["therpeutic_unite"].Rows.Find(Data_Rows_Item_stor[i][10]);
                        ((DataGridViewComboBoxCell)dr.dgv_open_storg_update_dgv.Rows[i].Cells[2]).Value = unit_Coms[1];


                    }
                }
            }
        }
        public void Totle_price_update()
        {

            var dr = Application.OpenForms["Main"] as Main;

            double reslt = 0;
            double reslt_prodect = 0;
            int cou = 0;
            for (int i = 0; i < dr.dgv_open_storg_update_dgv.Rows.Count; i++)
            {
                if (dr.dgv_open_storg_update_dgv.Rows[i].Cells[3].Value != null)
                {
                    cou++;
                }
                double temp = Convert.ToDouble(dr.dgv_open_storg_update_dgv.Rows[i].Cells[6].Value);
                double quit = Convert.ToDouble(dr.dgv_open_storg_update_dgv.Rows[i].Cells[3].Value);
                double pons = Convert.ToDouble(dr.dgv_open_storg_update_dgv.Rows[i].Cells[4].Value);
                double cell_prodect = Convert.ToDouble(dr.dgv_open_storg_update_dgv.Rows[i].Cells[9].Value);
                quit += pons;
                reslt += temp * quit;
                reslt_prodect += cell_prodect * quit;
            }
            dr.lbl_Totle_prodect_update.Text = reslt_prodect.ToString("N0");
            dr.blb_Totl_pric_update.Text = reslt.ToString("N0");
            dr.blb_count_update.Text = cou.ToString();
            double prod_pric = reslt - reslt_prodect;
            dr.lbl_pro_pric_update.Text = prod_pric.ToString("N0");
        }
        public void Won_update()
        {
            var dr = Application.OpenForms["Main"] as Main;

            for (int i = 0; i < dr.dgv_open_storg_update_dgv.Rows.Count; i++)
            {
                if (dr.dgv_open_storg_update_dgv.Rows[i].Cells[2].Value != null)
                {
                    double price = Convert.ToDouble(dr.dgv_open_storg_update_dgv.Rows[i].Cells[6].Value);
                    double prodect = Convert.ToDouble(dr.dgv_open_storg_update_dgv.Rows[i].Cells[9].Value);
                    double reslt = price - prodect;
                    dr.dgv_open_storg_update_dgv.Rows[i].Cells[10].Value = reslt.ToString("N0");
                }
            }
        }


        //دالة لتحويل الوحدات او تعديل الوحدات عبر الكبو بكس
        public void Dgv_open_storg_update_EditingControlShowing_(object sender, DataGridViewEditingControlShowingEventArgs e)
        {

            var dr = Application.OpenForms["Main"] as Main;

            if (dr.dgv_open_storg_update_dgv.CurrentCell.ColumnIndex == 0 || dr.dgv_open_storg_update_dgv.CurrentCell.ColumnIndex == 3 || dr.dgv_open_storg_update_dgv.CurrentCell.ColumnIndex == 4 || dr.dgv_open_storg_update_dgv.CurrentCell.ColumnIndex == 6 || dr.dgv_open_storg_update_dgv.CurrentCell.ColumnIndex == 7 || dr.dgv_open_storg_update_dgv.CurrentCell.ColumnIndex == 8 || dr.dgv_open_storg_update_dgv.CurrentCell.ColumnIndex == 9)
            {

                if (e.Control is TextBox && e.Control != null)
                {
                    e.Control.KeyPress += delegate (object Mysend, KeyPressEventArgs Mye)
                    {
                        if (char.IsLetter(Mye.KeyChar) || char.IsPunctuation(Mye.KeyChar) || char.IsSeparator(Mye.KeyChar) || char.IsSymbol(Mye.KeyChar) || char.IsSurrogate(Mye.KeyChar) || char.IsHighSurrogate(Mye.KeyChar) || Mye.KeyChar == (char)Keys.Space)
                        {

                            Mye.Handled = true;
                        }
                    };
                }
            }
            else if (dr.dgv_open_storg_update_dgv.CurrentCell.ColumnIndex == 2)
            {
                ComboBox com = new ComboBox();
                com = e.Control as ComboBox;
                if (com != null)
                {
                    com.SelectedIndexChanged += delegate (object Mysender, EventArgs Me)
                    {
                        string str = dr.dgv_open_storg_update_dgv.CurrentRow.Cells[0].Value.ToString();
                        if (com.SelectedIndex == 0)
                        {
                            double res1 = Convert.ToDouble(Items_Tools.Dataunit.Tables[str].Rows[0][1]);
                            dr.dgv_open_storg_update_dgv.CurrentRow.Cells[6].Value = res1.ToString("N0");

                            dr.dgv_open_storg_update_dgv.CurrentRow.Cells[9].Value = Calc_protect_cobtl(str, 1).ToString("N0");
                            Totle_price_update();
                            Won_update();
                        }
                        else if (com.SelectedIndex == 1)
                        {
                            double res2 = Convert.ToDouble(Items_Tools.Dataunit.Tables[str].Rows[1][1]);
                            dr.dgv_open_storg_update_dgv.CurrentRow.Cells[6].Value = res2.ToString("N0");
                            dr.dgv_open_storg_update_dgv.CurrentRow.Cells[9].Value = Calc_protect_cobtl(str, 2).ToString("N0");
                            Totle_price_update();
                            Won_update();
                        }
                        else if (com.SelectedIndex == 2)
                        {
                            double res3 = Convert.ToDouble(Items_Tools.Dataunit.Tables[str].Rows[2][1]);
                            dr.dgv_open_storg_update_dgv.CurrentRow.Cells[6].Value = res3.ToString("N0");
                            dr.dgv_open_storg_update_dgv.CurrentRow.Cells[9].Value = Calc_protect_cobtl(str, 3).ToString("N0");
                            Totle_price_update();
                            Won_update();
                        }


                    };
                }

            }
        }
        string Amount_update()
        {
            var dr = Application.OpenForms["Main"] as Main;

            string reslt = "";
            if (dr.dgv_open_storg_update_dgv.CurrentCell.ColumnIndex == 7 || dr.dgv_open_storg_update_dgv.CurrentCell.ColumnIndex == 9)
            {
                double pric_protect = prodect;
                double Amunt = (Convert.ToDouble(dr.dgv_open_storg_update_dgv.CurrentRow.Cells[7].Value) * pric_protect) / 100;
                double Totle = pric_protect - Amunt;
                reslt = Totle.ToString("N0");

            }
            return reslt;
        }

        string tex_calc_update()
        {
            var dr = Application.OpenForms["Main"] as Main;

            string reslt = "";
            if (dr.dgv_open_storg_update_dgv.CurrentCell.ColumnIndex == 8)
            {
                double pric_protect = prodect;
                double Amunt = (Convert.ToDouble(dr.dgv_open_storg_update_dgv.CurrentRow.Cells[7].Value) * pric_protect) / 100;
                double Totle = pric_protect - Amunt;
                reslt = Totle.ToString("N0");

            }
            return reslt;
        }

        public void Dgv_open_storg_update_CellEndEdit_()
        {
            //تحديث البيانت بعد كل عملية تعديل في الخلية
            var dr = Application.OpenForms["Main"] as Main;

            if (dr.dgv_open_storg_update_dgv.CurrentCell.ColumnIndex == 7)
            {
                int tepm = Convert.ToInt32(dr.dgv_open_storg_update_dgv.CurrentRow.Cells[7].Value);
                if (tepm >= 100)
                {
                    dr.dgv_open_storg_update_dgv.CurrentRow.Cells[7].Value = "0";
                }
                else
                {
                    dr.dgv_open_storg_update_dgv.CurrentRow.Cells[9].Value = Amount_update();
                }
            }



            if (dr.dgv_open_storg_update_dgv.CurrentCell.ColumnIndex == 8)
            {
                int temp = Convert.ToInt32(dr.dgv_open_storg_update_dgv.CurrentRow.Cells[8].Value);

                if (temp >= 100)
                {
                    dr.dgv_open_storg_update_dgv.CurrentRow.Cells[8].Value = "0";
                }
                else
                {
                    dr.dgv_open_storg_update_dgv.CurrentRow.Cells[9].Value = tex_calc_update();
                }
            }

            Totle_price_update();
            Won_update();
        }
        public void Txt_num_stor_update_KeyPress_(object sender, KeyPressEventArgs e)
        {
            var dr = Application.OpenForms["Main"] as Main;

            //للبحث عن الاصناف من اجل التعديل
            if (e.KeyChar == (Char)Keys.Enter)
            {
                if (dr.txt_num_stor_update.Text.Trim() != string.Empty)
                {
                    DataRow Data_Rows_Storg = DB_Add_delete_update_.Database.ds.Tables["Storg"].Rows.Find(MyTool_1.GetNmberOnly(dr.txt_num_stor_update.Text));
                    if (Data_Rows_Storg != null)
                    {
                        dr.txt_name_storg_update.Text = Data_Rows_Storg[1].ToString();
                    }
                    else
                    {
                        MessageBox.Show("الرقم المدخل ليس موجود");
                    }
                }

            }
            if (!(char.IsDigit(e.KeyChar)) && e.KeyChar != (Char)Keys.Back)
            {
                e.Handled = true;
            }
        }

        public void event_update_open_buttn()
        {
            // حدث تحديث البيانت الافتتاحية
            var dr = Application.OpenForms["Main"] as Main;


            if (Check_Empty_Item_storg(dr.dgv_open_storg_update_dgv))
                {
                    int sum_qity = Convert.ToInt32(dr.blb_count_update.Text);
                    double sum_sell_pric = Convert.ToDouble(dr.blb_Totl_pric_update.Text);
                    double sum_sell_pro = Convert.ToDouble(dr.lbl_Totle_prodect_update.Text);
                    double sum_Profit = Convert.ToDouble(dr.lbl_pro_pric_update.Text);
                    int Storg_no = Convert.ToInt32(dr.txt_num_stor_update.Text.Trim());
                    object[] temp = { "", sum_qity, sum_sell_pric, sum_sell_pro, sum_Profit, Storg_no };
                new classs_table.Items_Tools().update_Rows_Table_Database("sum_storg_Item", dr.txt_num_sum.Text, temp);
                    DataRow[] Data_Rows_Item_stor = null;
                    if (dr.txt_num_sum.Text.Trim() != string.Empty)
                    {
                        Data_Rows_Item_stor = DB_Add_delete_update_.Database.ds.Tables["Item_storg"].Select("sum_num = " + Convert.ToInt32(dr.txt_num_sum.Text));
                    }

                    for (int i = 0; i < dr.dgv_open_storg_update_dgv.Rows.Count; i++)
                    {
                        if (Data_Rows_Item_stor != null)
                        {

                            int type_unit = 0;
                            if (((DataGridViewComboBoxCell)dr.dgv_open_storg_update_dgv.Rows[i].Cells[2]).Items[0].ToString() == ((DataGridViewComboBoxCell)dr.dgv_open_storg_update_dgv.Rows[i].Cells[2]).Value.ToString())
                            {
                                type_unit = 1;
                            }
                            else if (((DataGridViewComboBoxCell)dr.dgv_open_storg_update_dgv.Rows[i].Cells[2]).Items[1].ToString() == ((DataGridViewComboBoxCell)dr.dgv_open_storg_update_dgv.Rows[i].Cells[2]).Value.ToString())
                            {
                                type_unit = 2;
                            }
                            else if (((DataGridViewComboBoxCell)dr.dgv_open_storg_update_dgv.Rows[i].Cells[2]).Items[2].ToString() == ((DataGridViewComboBoxCell)dr.dgv_open_storg_update_dgv.Rows[i].Cells[2]).Value.ToString())
                            {
                                type_unit = 3;
                            }

                            string num = dr.dgv_open_storg_update_dgv.Rows[i].Cells[0].Value.ToString();
                            string str = Items_Tools.Dataunit.Tables[num].Rows[1][2].ToString();
                            string str2 = Items_Tools.Dataunit.Tables[num].Rows[2][2].ToString();



                            int Qity = Convert.ToInt32(dr.dgv_open_storg_update_dgv.Rows[i].Cells[3].Value);
                            DateTime Expe = Convert.ToDateTime(dr.dgv_open_storg_update_dgv.Rows[i].Cells[5].Value);
                            int bons = Convert.ToInt32(dr.dgv_open_storg_update_dgv.Rows[i].Cells[4].Value);
                            int disc = Convert.ToInt32(dr.dgv_open_storg_update_dgv.Rows[i].Cells[7].Value);
                            int storg_tex = Convert.ToInt32(dr.dgv_open_storg_update_dgv.Rows[i].Cells[8].Value);
                            double storg_profit = Convert.ToDouble(dr.dgv_open_storg_update_dgv.Rows[i].Cells[10].Value);
                            double sell_pro = Convert.ToDouble(dr.dgv_open_storg_update_dgv.Rows[i].Cells[9].Value);
                            double sell_pric = Convert.ToDouble(dr.dgv_open_storg_update_dgv.Rows[i].Cells[6].Value);

                            string temp_unit_name_update = dr.dgv_open_storg_update_dgv.Rows[i].Cells[2].Value.ToString();
                            DataRow[] unit_num_Item_update = DB_Add_delete_update_.Database.ds.Tables["therpeutic_unite"].Select(" unit_name = '" + temp_unit_name_update + "'");
                            int unit_num_update = Convert.ToInt32(unit_num_Item_update[0][0]);

                            int num_unit_avrg = 0;
                            int num_unit_smool = 0;
                            if (type_unit == 1)
                            {//عدد الوحداد الوسطا
                                num_unit_avrg = Qity * Convert.ToInt32(str);
                                // عدد الوحدات الصغر
                                num_unit_smool = num_unit_avrg * Convert.ToInt32(str2);
                                MessageBox.Show(str2 + "");
                            }
                            else if (type_unit == 2)
                            {

                                num_unit_smool = Qity * Convert.ToInt32(str2);

                            }
                            else if (type_unit == 3)
                            {
                                num_unit_smool = Qity;
                            }

                            int Item_no = Convert.ToInt32(dr.dgv_open_storg_update_dgv.Rows[i].Cells[0].Value);

                            object[] Temp2 = { "", Qity, Expe.ToString("d"), bons, disc, storg_tex, storg_profit, sell_pro, sell_pric, Item_no, unit_num_update, Convert.ToInt32(dr.txt_num_sum.Text), type_unit, num_unit_avrg, num_unit_smool };
                            ;

                        new classs_table.Items_Tools().update_Rows_Table_Database("Item_storg", Data_Rows_Item_stor[i][0].ToString(), Temp2);

                        }
                        else
                        {
                            MessageBox.Show("لايوجد بيانات");
                        }

                    }
                    MessageBox.Show("تم التعديل بنجاح");
                    dr.dgv_open_storg_update_dgv.Rows.Clear();

                }



            
        }

    }
}
