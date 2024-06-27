using Manag_ph.classs_table;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Manag_ph.storg
{
    class open_blans_storg
    {

        double prodect = 0;
        double tex = 0;
        double descount = 0;


        public double prodects
        {
            get { return prodect; }
            set { prodect = value; }

        }

        public double texs
        {
            get { return tex; }
            set { tex = value; }

        }

        public double descounts
        {
            get { return descounts; }
            set { descounts = value; }

        }


        public void Totle_price()
        {
            var vr = Application.OpenForms["Main"] as Main;

            double reslt = 0;
            double reslt_prodect = 0;
            int cou = 0;
            for (int i = 0; i < vr.dgv_open_storg_dgv.Rows.Count; i++)
            {
                if (vr.dgv_open_storg_dgv.Rows[i].Cells[3].Value != null)
                {
                    cou++;
                }
                double temp = Convert.ToDouble(vr.dgv_open_storg_dgv.Rows[i].Cells[6].Value);
                double quit = Convert.ToDouble(vr.dgv_open_storg_dgv.Rows[i].Cells[3].Value);
                double pons = Convert.ToDouble(vr.dgv_open_storg_dgv.Rows[i].Cells[4].Value);
                double cell_prodect = Convert.ToDouble(vr.dgv_open_storg_dgv.Rows[i].Cells[9].Value);
                quit += pons;
                reslt += temp * quit;
                reslt_prodect += cell_prodect * quit;
            }
            vr.lbl_Totle_prodect.Text = reslt_prodect.ToString("N0");
            vr.blb_Totl_pric.Text = reslt.ToString("N0");
            vr.blb_count.Text = cou.ToString();
            double prod_pric = reslt - reslt_prodect;
            vr.lbl_pro_pric.Text = prod_pric.ToString("N0");
        }

        public void Won()
        {
            var vr = Application.OpenForms["Main"] as Main;
            for (int i = 0; i < vr.dgv_open_storg_dgv.Rows.Count; i++)
            {
                if (vr.dgv_open_storg_dgv.Rows[i].Cells[2].Value != null)
                {
                    double price = Convert.ToDouble(vr.dgv_open_storg_dgv.Rows[i].Cells[6].Value);
                    double prodect = Convert.ToDouble(vr.dgv_open_storg_dgv.Rows[i].Cells[9].Value);
                    double reslt = price - prodect;
                    vr.dgv_open_storg_dgv.Rows[i].Cells[10].Value = reslt.ToString("N0");
                }
            }
        }


        public double Calc_protect_cobtl(string tableName, int numUnit)
        {
            var vr = Application.OpenForms["Main"] as Main;
            double reslt = 0;
            //سعر الشرا للوحدة الكبرا
            double pres_Prodect = Convert.ToDouble(Items_Tools.Dataunit.Tables[tableName].Rows[0][1]);

            MessageBox.Show(pres_Prodect+"");
            //سعر الشراء للوحدة الوسطاء
            double num_unitavrg = Convert.ToDouble(Items_Tools.Dataunit.Tables[tableName].Rows[1][1]);
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
                double num_unit_smool = Convert.ToDouble(Items_Tools.Dataunit.Tables[tableName].Rows[2][1]);
                //جلب سعر الشرا للوحدة الصغرا
                double reslt_somml = reslt_avrg / num_unit_smool;
                reslt = reslt_somml;
            }

            return reslt;

        }

        public string Amount()
        {
            var vr = Application.OpenForms["Main"] as Main;

            string reslt = "";
            if (vr.dgv_open_storg_dgv.CurrentCell.ColumnIndex == 7 || vr.dgv_open_storg_dgv.CurrentCell.ColumnIndex == 9)
            {
                double pric_protect = prodect;
                double Amunt = (Convert.ToDouble(vr.dgv_open_storg_dgv.CurrentRow.Cells[7].Value) * pric_protect) / 100;
                double Totle = pric_protect - Amunt;
                reslt = Totle.ToString("N0");

            }
            return reslt;
        }

        string tex_calc()
        {
            var vr = Application.OpenForms["Main"] as Main;

            string reslt = "";
            if (vr.dgv_open_storg_dgv.CurrentCell.ColumnIndex == 8)
            {
                double pric_protect = prodect;
                double Amunt = (Convert.ToDouble(vr.dgv_open_storg_dgv.CurrentRow.Cells[7].Value) * pric_protect) / 100;
                double Totle = pric_protect - Amunt;
                reslt = Totle.ToString("N0");

            }
            return reslt;
        }

        public void EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            var vr = Application.OpenForms["Main"] as Main;

            //دالة لتحكم بالوحدات والاسعار الخاصة بلوحدات


            if (vr.dgv_open_storg_dgv.CurrentCell.ColumnIndex == 5|| vr.dgv_open_storg_dgv.CurrentCell.ColumnIndex == 0)
            {

                if (e.Control is TextBox)
                {
                    e.Control.KeyPress += delegate (object Mysend, KeyPressEventArgs Mye)
                    {
                            Mye.Handled = false;

                    };
                }


            }


            if (vr.dgv_open_storg_dgv.CurrentCell.ColumnIndex == 3 || vr.dgv_open_storg_dgv.CurrentCell.ColumnIndex == 4 || vr.dgv_open_storg_dgv.CurrentCell.ColumnIndex == 6 || vr.dgv_open_storg_dgv.CurrentCell.ColumnIndex == 7 || vr.dgv_open_storg_dgv.CurrentCell.ColumnIndex == 8 || vr.dgv_open_storg_dgv.CurrentCell.ColumnIndex == 9)
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
            else if (vr.dgv_open_storg_dgv.CurrentCell.ColumnIndex == 2)
            {

                ComboBox com = new ComboBox();
                com = e.Control as ComboBox;
                if (com != null)
                {
                    com.SelectedIndexChanged += delegate (object Mysender, EventArgs Me)
                    {
                        string str = vr.dgv_open_storg_dgv.CurrentRow.Cells[0].Value.ToString();
                        if (com.SelectedIndex == 0)
                        {
                            double res1 = Convert.ToDouble(Items_Tools.Dataunit.Tables[str].Rows[0][1]);
                            vr.dgv_open_storg_dgv.CurrentRow.Cells[6].Value = res1.ToString("N0");

                            vr.dgv_open_storg_dgv.CurrentRow.Cells[9].Value = res1.ToString("N0");
                            Totle_price();
                            Won();
                        }
                        else if (com.SelectedIndex == 1)
                        {
                            
                            double res2 = Convert.ToDouble(Items_Tools.Dataunit.Tables[str].Rows[1][1]);
                            vr.dgv_open_storg_dgv.CurrentRow.Cells[6].Value = res2.ToString("N0");
                            vr.dgv_open_storg_dgv.CurrentRow.Cells[9].Value = res2.ToString("N0");
                            Totle_price();
                            Won();
                        }
                        else if (com.SelectedIndex == 2)
                        {
                            double res3 = Convert.ToDouble(Items_Tools.Dataunit.Tables[str].Rows[2][1]);
                            vr.dgv_open_storg_dgv.CurrentRow.Cells[6].Value = res3.ToString("N0");
                            vr.dgv_open_storg_dgv.CurrentRow.Cells[9].Value = res3.ToString("N0");
                            Totle_price();
                            Won();
                        }


                    };
                }

            }
        }
        //الدالة الاساسية لعرض لبحث وعرض البيانات  في الجدول
        public void view_And_serch()
        {
            var vr = Application.OpenForms["Main"] as Main;
            if (vr.dgv_open_storg_dgv.CurrentRow != null)
            {

                if (vr.dgv_open_storg_dgv.CurrentCell.ColumnIndex == 7)
                {
                    int tepm = Convert.ToInt32(vr.dgv_open_storg_dgv.CurrentRow.Cells[7].Value);
                    if (tepm >= 100)
                    {
                        vr.dgv_open_storg_dgv.CurrentRow.Cells[7].Value = "0";
                    }
                    else
                    {
                        vr.dgv_open_storg_dgv.CurrentRow.Cells[9].Value = Amount();
                    }
                }
                if (vr.dgv_open_storg_dgv.CurrentCell.ColumnIndex == 8)
                {
                    int temp = Convert.ToInt32(vr.dgv_open_storg_dgv.CurrentRow.Cells[8].Value);

                    if (temp >= 100)
                    {
                        vr.dgv_open_storg_dgv.CurrentRow.Cells[8].Value = "0";
                    }
                    else
                    {
                        vr.dgv_open_storg_dgv.CurrentRow.Cells[9].Value = tex_calc();
                    }
                }

                Totle_price();
                Won();
                if (vr.dgv_open_storg_dgv.CurrentCell.ColumnIndex!=2)
                {

                   
                }
                //if (
                // (vr.dgv_open_storg_dgv.SelectedCells[2].RowIndex != vr.dgv_open_storg_dgv.CurrentCell.RowIndex) || (vr.dgv_open_storg_dgv.SelectedCells[2].ColumnIndex != vr.dgv_open_storg_dgv.CurrentCell.ColumnIndex))
                //{
                //    vr.dgv_open_storg_dgv.Rows[vr.dgv_open_storg_dgv.CurrentRow.Index].Cells[1].Selected = true;
                //}


            }
        }

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
                else if (str == null || str.ToString().Trim() == string.Empty)
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


        public int AoutoNumber(string TableName, string ColumnName)
        {
            int Autonum_Item_storg = 1;
            if (DB_Add_delete_update_.Database.ds.Tables[TableName].Rows.Count != 0)
            {

                Autonum_Item_storg = Convert.ToInt32(DB_Add_delete_update_.Database.ds.Tables[TableName].Compute("max(" + ColumnName + ")", "")) + 1;

            }
            else
            {
                Autonum_Item_storg = 1;
            }
            return Autonum_Item_storg;
        }



        public void Save_Data_Storg()
        {
            var vr = Application.OpenForms["Main"] as Main;
            //  لحفظ البيانات الافتتاحية
            if (vr.txt_name_storg.Text != string.Empty && vr.txt_num_stor.Text != string.Empty)
            {


                if (vr.dgv_open_storg_dgv.Rows.Count != 0)
                {
                    if (Check_Empty_Item_storg(vr.dgv_open_storg_dgv))
                    {

                        int Aouto_sum = AoutoNumber("sum_storg_Item", "sum_num");
                        int sum_qity = Convert.ToInt32(vr.blb_count.Text);
                        double sum_sell_pric = Convert.ToDouble(vr.blb_Totl_pric.Text);
                        double sum_sell_pro = Convert.ToDouble(vr.lbl_Totle_prodect.Text);
                        double sum_Profit = Convert.ToDouble(vr.lbl_pro_pric.Text);
                        int Storg_no = Convert.ToInt32(vr.txt_num_stor.Text.Trim());
                        DB_Add_delete_update_.Database.ds.Tables["sum_storg_Item"].Rows.Add(Aouto_sum, sum_qity, sum_sell_pric, sum_sell_pro, sum_Profit, Storg_no);
                        DB_Add_delete_update_.Database.update("sum_storg_Item");


                        //string num = dgv_open_storg.Rows[0].Cells[0].Value.ToString();
                        //string str = Items_Tools.Dataunit.Tables[num].Rows[1][2].ToString();
                        //string str2 = Items_Tools.Dataunit.Tables[num].Rows[2][2].ToString();


                        for (int i = 0; i < vr.dgv_open_storg_dgv.Rows.Count; i++)
                        {
                            string num = vr.dgv_open_storg_dgv.Rows[i].Cells[0].Value.ToString();
                            string str = Items_Tools.Dataunit.Tables[num].Rows[1][2].ToString();
                            string str2 = Items_Tools.Dataunit.Tables[num].Rows[2][2].ToString();

                            int type_unit = 0;
                            if (((DataGridViewComboBoxCell)vr.dgv_open_storg_dgv.Rows[i].Cells[2]).Items[0].ToString() == ((DataGridViewComboBoxCell)vr.dgv_open_storg_dgv.Rows[i].Cells[2]).Value.ToString())
                            {
                                //كبيرة
                                type_unit = 1;
                                //MessageBox.Show("كبرا");
                            }
                            else if (((DataGridViewComboBoxCell)vr.dgv_open_storg_dgv.Rows[i].Cells[2]).Items[1].ToString() == ((DataGridViewComboBoxCell)vr.dgv_open_storg_dgv.Rows[i].Cells[2]).Value.ToString())
                            {
                                //متوسطة
                                type_unit = 2;
                                //MessageBox.Show("متوسطة");
                            }
                            else if (((DataGridViewComboBoxCell)vr.dgv_open_storg_dgv.Rows[i].Cells[2]).Items[2].ToString() == ((DataGridViewComboBoxCell)vr.dgv_open_storg_dgv.Rows[i].Cells[2]).Value.ToString())
                            {
                                //صغيرة
                                type_unit = 3;
                                //MessageBox.Show("صغرا");
                            }

                            int Aouto = AoutoNumber("Item_storg", "storg_num");
                            int Qity = Convert.ToInt32(vr.dgv_open_storg_dgv.Rows[i].Cells[3].Value);
                            DateTime Expe = Convert.ToDateTime(vr.dgv_open_storg_dgv.Rows[i].Cells[5].Value);
                            int bons = Convert.ToInt32(vr.dgv_open_storg_dgv.Rows[i].Cells[4].Value);
                            int disc = Convert.ToInt32(vr.dgv_open_storg_dgv.Rows[i].Cells[7].Value);
                            int storg_tex = Convert.ToInt32(vr.dgv_open_storg_dgv.Rows[i].Cells[8].Value);
                            double storg_profit = Convert.ToDouble(vr.dgv_open_storg_dgv.Rows[i].Cells[10].Value);
                            double sell_pro = Convert.ToDouble(vr.dgv_open_storg_dgv.Rows[i].Cells[9].Value);
                            double sell_pric = Convert.ToDouble(vr.dgv_open_storg_dgv.Rows[i].Cells[6].Value);
                            int Item_no = Convert.ToInt32(vr.dgv_open_storg_dgv.Rows[i].Cells[0].Value);

                            string temp_unit_name = vr.dgv_open_storg_dgv.Rows[i].Cells[2].Value.ToString();
                            DataRow[] unit_num_Item = DB_Add_delete_update_.Database.ds.Tables["therpeutic_unite"].Select(" unit_name = '" + temp_unit_name + "'");
                            int unit_num = Convert.ToInt32(unit_num_Item[0][0]);
                            int sum_num = Aouto_sum;

                            int num_unit_avrg = 0;
                            int num_unit_smool = 0;
                            if (type_unit == 1)
                            {//عدد الوحداد الوسطا
                                num_unit_avrg = Qity * Convert.ToInt32(str);
                                // عدد الوحدات الصغر
                                num_unit_smool = num_unit_avrg * Convert.ToInt32(str2);

                            }
                            else if (type_unit == 2)
                            {

                                num_unit_smool = Qity * Convert.ToInt32(str2);

                            }
                            else if (type_unit == 3)
                            {
                                num_unit_smool = Qity;
                            }



                            DB_Add_delete_update_.Database.ds.Tables["Item_storg"].Rows.Add(Aouto, Qity, Expe.ToString("d"), bons, disc, storg_tex, storg_profit, sell_pro, sell_pric, Item_no, unit_num, sum_num, type_unit, num_unit_avrg, num_unit_smool);
                        }
                        DB_Add_delete_update_.Database.update("Item_storg");
                        MessageBox.Show("تم الاضافة بنجاح", "اضافة", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        vr.dgv_open_storg_dgv.Rows.Clear();
                        vr.blb_count.Text = "000";
                        vr.blb_Totl_pric.Text = "000";
                        vr.lbl_Totle_prodect.Text = "000";
                        vr.lbl_pro_pric.Text = "000";

                        vr.txt_sum_num.Text = AoutoNumber("sum_storg_Item", "sum_num").ToString();

                    }
                }
            }
            else
            {
                MessageBox.Show("يرجاء ادخال المخزن");
            }
        }



    }
}
