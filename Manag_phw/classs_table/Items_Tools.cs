using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using System.Windows.Forms;
using System.Drawing;
using DevExpress.XtraEditors;
using ComboBox = DevExpress.XtraEditors.ComboBox;
using System.Reflection.Emit;
using Label = System.Windows.Forms.Label;
using DevExpress.XtraBars.Navigation;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Windows.Forms;
using DevExpress.XtraReports.UI;
using System.Globalization;
using DevExpress.CodeParser;

namespace Manag_ph.classs_table
{
    class Items_Tools
    {
        public void insertItem(params object[] sum)
        {
            int num = Convert.ToInt32(sum[0]);
            SqlParameter[] param = new SqlParameter[num];
            DB_Add_delete_update_.Database m1 = new DB_Add_delete_update_.Database();
            int co = 0;
            for (int i = 2; i < num + 2; i++)
            {
                param[co] = new SqlParameter(sum[i].ToString(), (SqlDbType)sum[i + (num + num)]);
                param[co].Value = sum[i + num];

                co++;
            }
            m1.Execute(sum[1].ToString(), param);
        }

        //دالة لتوين اليبل الخاص بتكست الفاضي
        public void Check_Text_Empty(TextBox txt, LabelControl lbl)
        {
            if (txt.Text.Trim() != string.Empty)
            {


                lbl.ForeColor = Color.Black;

            }
            else
            {
                lbl.ForeColor = Color.Red;
            }
        }
        //دالة لتحقق من التكست بكس اذا كانت تحتوي علا رفم 
        public bool CheackTextNumbers(TextBox txt)
        {
            bool b;
            string str = txt.Text.Trim();
            if (str.Contains("1") || str.Contains("2") || str.Contains("3") || str.Contains("4") || str.Contains("5") || str.Contains("6") || str.Contains("7") || str.Contains("8") || str.Contains("9"))
            {
                b = false;
            }
            else
            {
                b = true;
            }

            return b;
        }


        public double Calc_un(TextBox txt_Reslt, TextBox txt_num_Main)
        {
            double reslt = 0;
            if (txt_Reslt.Text.Trim() != string.Empty && (!CheackTextNumbers(txt_Reslt)))
            {
                if (txt_num_Main.Text.Trim() != string.Empty && (!CheackTextNumbers(txt_num_Main)))
                {
                    double num1 = Convert.ToDouble(txt_Reslt.Text);
                    double num2 = Convert.ToDouble(txt_num_Main.Text);

                    reslt = num2 / num1;

                }
            }
            return reslt;
        }

        public string AutoNumberItem()
        {
            string str = "";
            int Auto = 1;
            if (DB_Add_delete_update_.Database.ds.Tables["Item"].Rows.Count > 0)
            {
                Auto = Convert.ToInt32(DB_Add_delete_update_.Database.ds.Tables["Item"].Compute("max(Item_no)", "")) + 1;
                str = Auto.ToString();
            }
            else
            {
                str = Auto.ToString();
            }
            return str;
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



        public void Fill_Combox(System.Windows.Forms.ComboBox combox, string nameTable)
        {
            combox.DataSource = DB_Add_delete_update_.Database.ds.Tables[nameTable];
            combox.DisplayMember = DB_Add_delete_update_.Database.ds.Tables[nameTable].Columns[1].ColumnName;
            combox.ValueMember = DB_Add_delete_update_.Database.ds.Tables[nameTable].Columns[0].ColumnName;


        }
        //تابع
        public static DataSet Dataunit = new DataSet();
        //دالة للبحث عن صنف وملا الجدول مهم
        public static void DGV_Test(DataGridView dgv_open_storg, string Item_nos)
        {
            string Item_no1 = "";

            if (Item_nos != null)
            {

                dgv_open_storg.Rows.Add();
                int count = dgv_open_storg.Rows.Count;
                string Item_no = Item_nos;
                if (Item_no.Trim() != string.Empty)
                {
                    dgv_open_storg.Rows[count - 1].Cells[0].Value = Item_no;
                    int num = Convert.ToInt32(Item_no);
                    DataRow[] drItem = DB_Add_delete_update_.Database.ds.Tables["Item"].Select("Item_no =" + num);
                    if (drItem.Count() != 0)
                    {
                        dgv_open_storg.Rows[count - 1].Cells[1].Value = drItem[0][1].ToString();

                        DataGridViewComboBoxCell comboBoxCell = (dgv_open_storg.Rows[count - 1].Cells[2] as DataGridViewComboBoxCell);
                        //جلب بيانات الوحداد والتسعيرات والكميات
                        DataRow[] dr_unit = DB_Add_delete_update_.Database.ds.Tables["unite_items"].Select("item_no =" + num);
                        DataRow[] dr_pricc = DB_Add_delete_update_.Database.ds.Tables["pric"].Select("item_no =" + num);
                        List<string> list = new List<string>();
                        for (int i = 1; i <= 3; i++)
                        {
                            DataRow Item_unit3 = DB_Add_delete_update_.Database.ds.Tables["therpeutic_unite"].Rows.Find(dr_unit[0][i]);
                            list.Add(Item_unit3[1].ToString());
                        }
                        DataTable dt = new DataTable();
                        dt.TableName = num + "";
                        dt.Columns.Add("unit_unit");
                        dt.Columns.Add("unit_pric");
                        dt.Columns.Add("unit_num");
                        //جدول بيانات  الوحدات والتسعيرات والكميات
                        dt.Rows.Add(list[0], dr_pricc[0][1], dr_pricc[0][4]);
                        dt.Rows.Add(list[1], dr_unit[0][6], dr_unit[0][4]);
                        dt.Rows.Add(list[2], dr_unit[0][7], dr_unit[0][5]);
                        //تعبئة الكمبو بكس بلجدول
                        comboBoxCell.Items.Clear();

                        comboBoxCell.Items.AddRange(dt.Rows[0][0], dt.Rows[1][0], dt.Rows[2][0]);
                        comboBoxCell.Value = comboBoxCell.Items[0];



                        if (!classs_table.Items_Tools.Dataunit.Tables.Contains(num.ToString()))
                        {
                            classs_table.Items_Tools.Dataunit.Tables.Add(dt);
                        }

                    }
                    else
                    {

                        var vr = Application.OpenForms["Main"] as Main;
                        MessageBox.Show("لايوجد صنف بهاذا الرقم", "لايوجد");
                        if (vr.Datagridview_Type_barcode == 0)
                        {
                            vr.dgv_open_storg_dgv.Rows.Remove(vr.dgv_open_storg_dgv.CurrentRow);
                            return;
                        }



                    }
                }
                else
                {
                    MessageBox.Show("يرجا التاكد من المدخلات ");

                }

            }

            if (dgv_open_storg.CurrentCell.ColumnIndex == 0 && Item_nos == null)
            {

                Item_no1 = dgv_open_storg.CurrentRow.Cells[0].Value + "";
                if (Item_no1.Count() >= 5)
                {
                    DataRow[] barcode = DB_Add_delete_update_.Database.ds.Tables["barcode"].Select("barcode_internath = '" + Item_no1 + "'");
                    if (barcode.Count() != 0)
                    {
                        Item_no1 = barcode[0][3].ToString();
                        dgv_open_storg.CurrentRow.Cells[0].Value = Item_no1;
                    }
                    else
                    {
                        MessageBox.Show("لايوجد صنف بهاذا الرقم", "لايوجد");
                        dgv_open_storg.Rows.Remove(dgv_open_storg.CurrentRow);
                        new storg.open_blans_storg().Totle_price();
                        return;
                    }
                }

                if (Item_no1.Trim() != string.Empty)
                {
                    //int num = Convert.ToInt32(Item_no1);
                    string num = Item_no1;

                    DataRow[] drItem = DB_Add_delete_update_.Database.ds.Tables["Item"].Select("Item_no = '" + num + "'");
                    if (drItem.Count() != 0)
                    {
                        if (Convert.ToBoolean(drItem[0][8]) == false)
                        {
                            dgv_open_storg.CurrentRow.Cells[1].Value = drItem[0][1].ToString();
                            dgv_open_storg.CurrentRow.Cells[3].Value = "1";
                            dgv_open_storg.CurrentRow.Cells[4].Value = "0";
                            dgv_open_storg.CurrentRow.Cells[7].Value = "0";
                            dgv_open_storg.CurrentRow.Cells[8].Value = "0";
                            DataGridViewComboBoxColumn dgv_com = (DataGridViewComboBoxColumn)dgv_open_storg.Columns[2];
                            DataGridViewComboBoxCell comboBoxCell = (dgv_open_storg.CurrentRow.Cells[2] as DataGridViewComboBoxCell);
                            //جلب بيانات الوحداد والتسعيرات والكميات
                            DataRow[] dr_unit = DB_Add_delete_update_.Database.ds.Tables["unite_items"].Select("item_no =" + num);
                            DataRow[] dr_pricc = DB_Add_delete_update_.Database.ds.Tables["pric"].Select("item_no =" + num);
                            List<string> list = new List<string>();
                            for (int i = 1; i <= 3; i++)
                            {
                                DataRow Item_unit3 = DB_Add_delete_update_.Database.ds.Tables["therpeutic_unite"].Rows.Find(dr_unit[0][i]);
                                list.Add(Item_unit3[1].ToString());
                            }
                            DataTable dt = new DataTable();
                            dt.TableName = num + "";
                            // MessageBox.Show(num+" num");
                            dt.Columns.Add("unit_unit");
                            dt.Columns.Add("unit_pric");
                            dt.Columns.Add("unit_num");
                            //جدول بيانات  الوحدات والتسعيرات والكميات
                            dt.Rows.Add(list[0], dr_pricc[0][1], dr_pricc[0][4]);
                            dt.Rows.Add(list[1], dr_unit[0][6], dr_unit[0][4]);
                            dt.Rows.Add(list[2], dr_unit[0][7], dr_unit[0][5]);
                            //تعبئة الكمبو بكس بلجدول
                            comboBoxCell.Items.Clear();
                            comboBoxCell.Items.AddRange(dt.Rows[0][0], dt.Rows[1][0], dt.Rows[2][0]);
                            comboBoxCell.Value = comboBoxCell.Items[0];
                            dgv_open_storg.CurrentRow.Cells[6].Value = dt.Rows[0][1];
                            dgv_open_storg.CurrentRow.Cells[9].Value = dt.Rows[0][2];
                            dgv_open_storg.CurrentRow.Cells[9].Value = dt.Rows[0][2];
                            //Totle_price();
                            if (!Dataunit.Tables.Contains(num.ToString()))
                            {
                                Dataunit.Tables.Add(dt);
                            }
                        }
                        else
                        {
                            MessageBox.Show("تم ايقاف التعامل معاء الصنف", "ايقاف");
                            dgv_open_storg.Rows.Remove(dgv_open_storg.CurrentRow);
                            new storg.open_blans_storg().Totle_price();
                        }
                    }
                    else
                    {
                        MessageBox.Show("لايوجد صنف بهاذا الرقم", "لايوجد");
                        dgv_open_storg.Rows.Remove(dgv_open_storg.CurrentRow);
                        new storg.open_blans_storg().Totle_price();
                    }
                }
                else
                {
                    MessageBox.Show("يرجا التاكد من المدخلات [ " + dgv_open_storg.CurrentCell.Value + " ]");

                }


            }
        }


        static double Calc_protect_cobtl(string tableName, int numUnit)
        {
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
        //دالة لحساب المجموع الاصناف ويعر الشرا والبيع والربح
        public static void Totle_price(DataGridView dgv_open_storg, Label lbl_Totle_prodect, Label blb_Totl_pric, Label blb_count, Label lbl_pro_pric)
        {
            double reslt = 0;
            double reslt_prodect = 0;
            int cou = 0;
            for (int i = 0; i < dgv_open_storg.Rows.Count; i++)
            {
                if (dgv_open_storg.Rows[i].Cells[3].Value != null)
                {
                    cou++;
                }
                double temp = Convert.ToDouble(dgv_open_storg.Rows[i].Cells[6].Value);
                double quit = Convert.ToDouble(dgv_open_storg.Rows[i].Cells[3].Value);
                double pons = Convert.ToDouble(dgv_open_storg.Rows[i].Cells[4].Value);
                double cell_prodect = Convert.ToDouble(dgv_open_storg.Rows[i].Cells[9].Value);
                quit += pons;
                reslt += temp * quit;
                reslt_prodect += cell_prodect;
            }
            lbl_Totle_prodect.Text = reslt_prodect.ToString("N0");
            blb_Totl_pric.Text = reslt.ToString("N0");
            blb_count.Text = cou.ToString();
            double prod_pric = reslt - reslt_prodect;
            lbl_pro_pric.Text = prod_pric.ToString("N0");
        }
        // دالة لحساب الربح لصنف الواحد داخل الجدول
        public static void Won(DataGridView dgv_open_storg)
        {
            for (int i = 0; i < dgv_open_storg.Rows.Count; i++)
            {
                if (dgv_open_storg.Rows[i].Cells[2].Value != null)
                {
                    double price = Convert.ToDouble(dgv_open_storg.Rows[i].Cells[6].Value);
                    double prodect = Convert.ToDouble(dgv_open_storg.Rows[i].Cells[9].Value);
                    double reslt = price - prodect;
                    dgv_open_storg.Rows[i].Cells[10].Value = reslt.ToString("N0");
                }
            }
        }
        //دالة للحد الخاص بلجدول Edit Control Showing لتحك بلكمبو بكس
        public static void Controcl_Shonk(DataGridView dgv, DataGridViewEditingControlShowingEventArgs e, Label lbl_Totle_prodect, Label blb_Totl_pric, Label blb_count, Label lbl_pro_pric)
        {

            var fr = Application.OpenForms["Main"] as Main;

            if (fr.dgv_open_storg_dgv.CurrentCell.ColumnIndex == 0 || fr.dgv_open_storg_dgv.CurrentCell.ColumnIndex == 3 || fr.dgv_open_storg_dgv.CurrentCell.ColumnIndex == 4 || fr.dgv_open_storg_dgv.CurrentCell.ColumnIndex == 6 || fr.dgv_open_storg_dgv.CurrentCell.ColumnIndex == 7 || fr.dgv_open_storg_dgv.CurrentCell.ColumnIndex == 8 || fr.dgv_open_storg_dgv.CurrentCell.ColumnIndex == 9)
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
            else if (fr.dgv_open_storg_dgv.CurrentCell.ColumnIndex == 2)
            {
                ComboBox com = new ComboBox();
                com = e.Control as ComboBox;
                if (com != null)
                {
                    com.SelectedIndexChanged += delegate (object Mysender, EventArgs Me)
                    {
                        string str = fr.dgv_open_storg_dgv.CurrentRow.Cells[0].Value.ToString();
                        if (com.SelectedIndex == 0)
                        {
                            double res1 = Convert.ToDouble(Items_Tools.Dataunit.Tables[str].Rows[0][1]);
                            fr.dgv_open_storg_dgv.CurrentRow.Cells[6].Value = res1.ToString("N0");

                            fr.dgv_open_storg_dgv.CurrentRow.Cells[9].Value = Calc_protect_cobtl(str, 1).ToString("N0");
                            Totle_price(fr.dgv_open_storg_dgv, lbl_Totle_prodect, blb_Totl_pric, blb_count, lbl_pro_pric);
                            Won(fr.dgv_open_storg_dgv);
                        }
                        else if (com.SelectedIndex == 1)
                        {
                            double res2 = Convert.ToDouble(Items_Tools.Dataunit.Tables[str].Rows[1][1]);
                            fr.dgv_open_storg_dgv.CurrentRow.Cells[6].Value = res2.ToString("N0");
                            fr.dgv_open_storg_dgv.CurrentRow.Cells[9].Value = Calc_protect_cobtl(str, 2).ToString("N0");
                            Totle_price(fr.dgv_open_storg_dgv, lbl_Totle_prodect, blb_Totl_pric, blb_count, lbl_pro_pric);
                            Won(fr.dgv_open_storg_dgv);
                        }
                        else if (com.SelectedIndex == 2)
                        {
                            double res3 = Convert.ToDouble(Items_Tools.Dataunit.Tables[str].Rows[2][1]);
                            fr.dgv_open_storg_dgv.CurrentRow.Cells[6].Value = res3.ToString("N0");
                            fr.dgv_open_storg_dgv.CurrentRow.Cells[9].Value = Calc_protect_cobtl(str, 3).ToString("N0");
                            Totle_price(fr.dgv_open_storg_dgv, lbl_Totle_prodect, blb_Totl_pric, blb_count, lbl_pro_pric);
                            Won(fr.dgv_open_storg_dgv);
                        }
                    };
                }

            }
        }
        // دلة لتسيق الجداول
        //public void Style_DataGridView(DataGridView dgv)
        //{
        //    dgv.RowHeadersVisible = false;
        //    dgv.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(238, 239, 249);
        //    //dgvm.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
        //    dgv.DefaultCellStyle.SelectionBackColor = Color.SeaGreen;
        //    dgv.BackgroundColor = Color.FromArgb(30, 30, 30);
        //    dgv.Font = new Font("Arial", 12);
        //    dgv.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
        //    dgv.EnableHeadersVisualStyles = false;
        //    dgv.ColumnHeadersDefaultCellStyle.Font = new Font("Arial", 12, FontStyle.Bold);
        //    dgv.RowsDefaultCellStyle.Font = new Font("Arial", 11);
        //    dgv.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
        //    dgv.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(37, 37, 38);
        //    dgv.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
        //    dgv.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

        //}


        // دلة لتسيق الجداول
        //public void Style_DataGridView_Mine(DataGridView dgv)
        //{
        //    dgv.RowHeadersVisible = false;
        //    //dgv.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(238, 239, 249);
        //    //dgvm.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
        //    dgv.DefaultCellStyle.SelectionBackColor = Color.FromArgb(250, 200, 90);
        //    dgv.BackgroundColor = Color.FromArgb(30, 30, 30);
        //    dgv.Font = new Font("Arial", 12);
        //    dgv.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
        //    dgv.EnableHeadersVisualStyles = false;
        //    dgv.ColumnHeadersDefaultCellStyle.Font = new Font("Arial", 12, FontStyle.Bold);
        //    dgv.RowsDefaultCellStyle.Font = new Font("Arial", 11);
        //    dgv.ColumnHeadersDefaultCellStyle.ForeColor = Color.Black;
        //    dgv.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(180, 200, 230);
        //    dgv.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
        //    dgv.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

        //}

        // دلة لتسيق الجداول
        //public void Style_DataGridView_2(DataGridView dgv)
        //{
        //    Style_DataGridView(dgv);
        //    dgv.AlternatingRowsDefaultCellStyle.BackColor = new DataGridView().AlternatingRowsDefaultCellStyle.BackColor;

        //    dgv.BackgroundColor = Color.FromArgb(0, 0, 63);
        //    dgv.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(65, 94, 117);
        //}


        // دلة لتسيق الجداول
        //public void Style_DataGridView_Jon_1_2(DataGridView dgv)
        //{
        //    Style_DataGridView(dgv);
        //    dgv.AlternatingRowsDefaultCellStyle.BackColor = new DataGridView().AlternatingRowsDefaultCellStyle.BackColor;

        //}


        //دالة لحذ صف واحد من قاعدة البيانات تستقبل اسم الجدول والبريمري كاي
        public void Delete_Rows_Table_Database(string TabelName, string Num_primry_key)
        {
            DataRow Data_update_storg = DB_Add_delete_update_.Database.ds.Tables[TabelName].Rows.Find(MyTool_1.GetNmberOnly(Num_primry_key));
            int Row_sum_Index_ubdate = DB_Add_delete_update_.Database.ds.Tables[TabelName].Rows.IndexOf(Data_update_storg);
            DB_Add_delete_update_.Database.ds.Tables[TabelName].Rows[Row_sum_Index_ubdate].Delete();
            DB_Add_delete_update_.Database.update(TabelName);
        }

        public void Delete_Rows_Table_Database_Miulty_Key(string TabelName, object[] Num_primry_key)
        {
            DataRow Data_update_storg = DB_Add_delete_update_.Database.ds.Tables[TabelName].Rows.Find(Num_primry_key);
            int Row_sum_Index_ubdate = DB_Add_delete_update_.Database.ds.Tables[TabelName].Rows.IndexOf(Data_update_storg);
            DB_Add_delete_update_.Database.ds.Tables[TabelName].Rows[Row_sum_Index_ubdate].Delete();
            DB_Add_delete_update_.Database.update(TabelName);
        }


        //دالة لتحديث صف واحد تستقبل اسم الجدول والبريمري كاي والبيانت اللجديدة بدون الربيمري
        public void update_Rows_Table_Database(string TabelName, string Num_primry_key, object[] Rows)
        {




            int num = MyTool_1.GetNmberOnly(Num_primry_key);
            DataRow Data_update_storg = DB_Add_delete_update_.Database.ds.Tables[TabelName].Rows.Find(num);
            if (Data_update_storg != null)
            {


                int Row_sum_Index_ubdate = DB_Add_delete_update_.Database.ds.Tables[TabelName].Rows.IndexOf(Data_update_storg);
                for (int i = 0; i < DB_Add_delete_update_.Database.ds.Tables[TabelName].Columns.Count; i++)
                {
                    if (i != 0)
                    {
                        DB_Add_delete_update_.Database.ds.Tables[TabelName].Rows[Row_sum_Index_ubdate][i] = Rows[i];

                    }
                }
                DB_Add_delete_update_.Database.update(TabelName);
            }
            else
            {
                MessageBox.Show("الرقم غير صحيح");
            }

        }
        // \الة لتعديل صف لاكن اكثر من برامري كاي
        public void update_Rows_Table_Database_miulty_key(string TabelName, object[] primarys, object[] Rows)
        {

            DataRow Data_update_storg = DB_Add_delete_update_.Database.ds.Tables[TabelName].Rows.Find(primarys);
            if (Data_update_storg != null)
            {


                int Row_sum_Index_ubdate = DB_Add_delete_update_.Database.ds.Tables[TabelName].Rows.IndexOf(Data_update_storg);
                for (int i = 0; i < DB_Add_delete_update_.Database.ds.Tables[TabelName].Columns.Count; i++)
                {
                    if (i != 0)
                    {
                        DB_Add_delete_update_.Database.ds.Tables[TabelName].Rows[Row_sum_Index_ubdate][i] = Rows[i];

                    }
                }
                DB_Add_delete_update_.Database.update(TabelName);
            }
            else
            {
                MessageBox.Show("الرقم غير صحيح");
            }

        }
        //دالة لجلب الاصناف كامل في المخزن المحدد
        public DataTable GetItems_Storg_All(int Number_storg)
        {
            DataTable dt_Item = new DataTable();

            for (int i = 0; i < DB_Add_delete_update_.Database.ds.Tables["Item_storg"].Columns.Count; i++)//اضافة اسما الاعمدة الا الجدول الجديد
            {
                dt_Item.Columns.Add(DB_Add_delete_update_.Database.ds.Tables["Item_storg"].Columns[i].ColumnName, DB_Add_delete_update_.Database.ds.Tables["Item_storg"].Columns[i].DataType);

            }

            DataRow[] dr = DB_Add_delete_update_.Database.ds.Tables["sum_storg_Item"].Select("Storg_no = " + Number_storg);//اخراج ارقام الاصناف الموجودة في المخزن

            if (dr.Count() != 0)
            {
                for (int i = 0; i < dr.Count(); i++)
                {
                    DataRow[] new_Item = DB_Add_delete_update_.Database.ds.Tables["Item_storg"].Select("sum_num = " + Convert.ToInt32(dr[i][0]));
                    if (new_Item.Count() != 0)
                    {
                        for (int j = 0; j < new_Item.Count(); j++)
                        {
                            dt_Item.Rows.Add(new_Item[j].ItemArray);
                        }
                    }
                }
            }


            return dt_Item;
        }

        public void showAndHideForm(NavigationPage show)
        {
            var vr = Application.OpenForms["Main"] as Main;

            List<NavigationPage> li = new List<NavigationPage>();
            li.Add(vr.nav_return_prodect);
            li.Add(vr.settle_Items);
            li.Add(vr.View_And_serch);
            li.Add(vr.Add_Item);
            li.Add(vr.update_Item);
            li.Add(vr.Add_Storg);
            li.Add(vr.open_balanc_storg);
            li.Add(vr.update_Item_storg);
            li.Add(vr.bdails_page);
            li.Add(vr.purchases_bill);
            li.Add(vr.add_client);
            li.Add(vr.TransFormation);
            li.Add(vr.Report_Transform_on_storg);
            li.Add(vr.navig_supplire);
            li.Add(vr.nvg_contracts);
            li.Add(vr.page_show_All_Empl);
            li.Add(vr.jobs);
            li.Add(vr.Emplyes_page);
            li.Add(vr.pawers_Emp);
            li.Add(vr.Report_Item_Storg);
            li.Add(vr.Report_Item_Expirt);
            li.Add(vr.Report_update_qty);
            li.Add(vr.Report_update_Date_Expirt);
            li.Add(vr.Report_update_salse);
            li.Add(vr.Report_Footer_prodect_All);
            li.Add(vr.Report_Footer_prodect_num);
            li.Add(vr.Report_total_return_supper);
            li.Add(vr.Report_dons_supper);
            li.Add(vr.fund_Account);
            li.Add(vr.sals);
            li.Add(vr.hanging_bills);
            li.Add(vr.sals_return);
            li.Add(vr.Report_sals_return);
            li.Add(vr.Report_sales_Item_All);
            li.Add(vr.Report_Sales_Footer_Return);
            li.Add(vr.Report_Sales_Footer_Employ);
            li.Add(vr.nav_Bln_Clin_Show);
            li.Add(vr.Report_unlock_casher);
            li.Add(vr.Report_Reasons_disco_Add);
            li.Add(vr.Report_cash_supply);
            li.Add(vr.Report_cash_exchange);
            li.Add(vr.nav_Balance_supp);
            li.Add(vr.RP_Search_Report_Account_Add);
            li.Add(vr.Nav_Main);
            li.Add(vr.Report_Supp);
            li.Add(vr.Report_Clint);
            li.Add(vr.nav_report_short);



            for (int i = 0; i < li.Count; i++)
            {
                if (li[i] == show)
                {
                    li[i].Show();
                }
                else
                {
                    li[i].Hide();
                }
            }
        }

        //دالة تعرض التقرير
        public void show_CrystalReportView(DataTable DataTable, CrystalReportViewer CrystalReportView, string pathRP)
        {
            ReportDocument rd = new ReportDocument();
            rd.Load(pathRP);
            DataSet ds = new DataSet();
            ds.Tables.Add(DataTable);
            rd.SetDataSource(ds);
            CrystalReportView.Refresh();
            CrystalReportView.ReportSource = rd;
            CrystalReportView.Refresh();
        }        //  دالة تعرض التقرير وتستقبل جدولين
        public void show_CrystalReportView_Tow_DataTavle(DataTable DataTable_one, DataTable DataTable_Tow, CrystalReportViewer CrystalReportView, string pathRP)
        {
            ReportDocument rd = new ReportDocument();
            rd.Load(pathRP);
            DataSet ds = new DataSet();
            ds.Tables.Add(DataTable_one);
            ds.Tables.Add(DataTable_Tow);
            rd.SetDataSource(ds);
            CrystalReportView.Refresh();
            CrystalReportView.ReportSource = rd;
            CrystalReportView.Refresh();
        }
        public DataTable Fill_DataTable_Columns(string NameTable, string[] NameColumn)
        {
            DataTable dt = new DataTable(NameTable);

            for (int i = 0; i < NameColumn.Count(); i++)
            {
                dt.Columns.Add(NameColumn[i]);
            }

            return dt;
        }



        // اضاف بيانات المورد الا التكستات يكون في الحدث
        public void Fill_supper_set_id_get_name(TextBox txt_num, TextBox txt_Name, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                if (txt_num.Text.Trim() != string.Empty)
                {
                    DataRow dr_supper = DB_Add_delete_update_.Database.ds.Tables["Supplier"].Rows.Find(txt_num.Text.Trim());
                    if (dr_supper != null)
                    {
                        txt_Name.Text = dr_supper[1].ToString();
                    }
                    else
                    {
                        MessageBox.Show("يرجاء التحقق من رقم المورد", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        txt_Name.Text = "";
                        txt_num.Focus();
                        txt_num.SelectAll();
                    }
                }
            }
        }

        public void Fill_supper_set_id_get_name(TextEdit txt_num, TextEdit txt_Name, TextEdit txt_calc, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                if (txt_num.Text.Trim() != string.Empty)
                {
                    DataRow dr_supper = DB_Add_delete_update_.Database.ds.Tables["Supplier"].Rows.Find(txt_num.Text.Trim());
                    if (dr_supper != null)
                    {
                        object[] ob_calc_supper = DB_Add_delete_update_.Database.ds.Tables["Calc_supply"].Rows.Find(dr_supper[6]).ItemArray;
                        txt_Name.Text = dr_supper[1].ToString();
                        txt_calc.Text = Convert.ToDouble(ob_calc_supper[3]).ToString("N2");
                    }
                    else
                    {
                        MessageBox.Show("يرجاء التحقق من رقم المورد", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        txt_Name.Text = "";
                        txt_calc.Text = "";
                        txt_num.Focus();
                        txt_num.SelectAll();
                    }
                }
            }
        }

        public void Fill_Cline_set_id_get_name(TextEdit txt_num, TextEdit txt_Name, TextEdit txt_calc, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                if (txt_num.Text.Trim() != string.Empty)
                {
                    DataRow dr_supper = DB_Add_delete_update_.Database.ds.Tables["Clien"].Rows.Find(txt_num.Text.Trim());
                    if (dr_supper != null)
                    {
                        object[] ob_calc_supper = DB_Add_delete_update_.Database.ds.Tables["Stock_client"].Rows.Find(dr_supper[10]).ItemArray;
                        txt_Name.Text = dr_supper[1].ToString();
                        txt_calc.Text = Convert.ToDouble(ob_calc_supper[4]).ToString("N2");
                    }
                    else
                    {
                        MessageBox.Show("يرجاء التحقق من رقم العميل", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        txt_Name.Text = "";
                        txt_calc.Text = "";
                        txt_num.Focus();
                        txt_num.SelectAll();
                    }
                }
            }
        }


        public void show_Dev_ReportView(DataTable DataTable, XtraReport xtr_Report)
        {
            Report.View_Report Doc = new Report.View_Report();
            DataSet ds = new DataSet1();
            ds.Tables[DataTable.TableName].Clear();
            foreach (DataRow Row in DataTable.Rows)
            {

                ds.Tables[DataTable.TableName].ImportRow(Row);
            }
            xtr_Report.DataSource = ds;
            xtr_Report.RequestParameters = false;
            Doc.documentViewer1.DocumentSource = xtr_Report;
            Doc.documentViewer1.Refresh();
            Doc.ShowDialog();
        }
        public void show_Dev_ReportView_footer(DataTable DataTable, XtraReport xtr_Report)
        {
            Report.View_Report Doc = new Report.View_Report();
            DataSet ds = new DataSet1();
            ds.Tables[DataTable.TableName].Clear();
            foreach (DataRow Row in DataTable.Rows)
            {

                ds.Tables[DataTable.TableName].ImportRow(Row);
            }
            xtr_Report.DataSource = ds;
            xtr_Report.RequestParameters = false;
            Doc.documentViewer1.DocumentSource = xtr_Report;
            Doc.documentViewer1.Refresh();
            xtr_Report.Print();
            //Doc.ShowDialog();
        }

        //public void Set_DataGridView_DataTimePicker(DataGridView dgv, DateTimePicker dtp, Rectangle Rect, string ColumnName, DataGridViewCellEventArgs e)
        //{
        //    if (dgv.Columns[e.ColumnIndex].Name == ColumnName)
        //    {

        //        Rect = dgv.GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, true);
        //        dtp.Size = new Size(Rect.Width, Rect.Height);
        //        dtp.Location = new Point(Rect.X, Rect.Y);
        //        dtp.Visible = true;
        //    }
        //    else
        //    {
        //        dtp.Visible = false;
        //    }
        //}


        static public string get_str_barcode(TextBox textBox)
        {
            var sr = Application.OpenForms["Main"] as Main;
            string str = textBox.Text;
            string str2 = textBox.Text;



            DataRow[] dt_barcod = DB_Add_delete_update_.Database.ds.Tables["barcode"].Select();

            if (textBox.Text.Trim() != string.Empty)
            {

                if (dt_barcod.Count() != 0)
                {

                    for (int i = 0; i < dt_barcod.Count(); i++)
                    {
                        // فور على كل الجدول ثم شرط لو النص يساوي نفس العمود احد 
                        if (dt_barcod[i][1].ToString() == textBox.Text)
                        {
                            str = dt_barcod[i][3].ToString();
                            //MessageBox.Show(str);
                            break;
                        }

                    }
                }
                else
                {
                    str = str2;
                }
            }


            return str;




        }


        private static InputLanguage GetInputLanguageByName(string inputName)
        {
            foreach (InputLanguage lang in InputLanguage.InstalledInputLanguages)
            {
                if (lang.Culture.EnglishName.ToLower().StartsWith(inputName))
                {
                    return lang;
                }
            }
            return null;
        }
        public void SetKeyboardLayout(String Name_language)
        {
            InputLanguage.CurrentInputLanguage = GetInputLanguageByName(Name_language);
        }


        public void Set_And_Vildet_Date(DataGridView dataGridView1, int Column_Index_Date, DataGridViewCellValidatingEventArgs e)
        {
            if (dataGridView1.CurrentRow != null)
            {
                if (e.ColumnIndex == Column_Index_Date)
                {

                    string DateFormat;
                    DateFormat = e.FormattedValue.ToString();

                    string[] formats = {
                    "dd/MM/yy", "d/MM/yy", "dd/M/yy", "d/MM/yyyy","dd/MM/yyyy","d/M/yyyy","d/M/yy","dd/M/yyyy",
                     "dd-MM-yy", "d-MM-yy", "dd-M-yy", "d-MM-yyyy","dd-MM-yyyy","d-M-yyyy","d-M-yy","dd-M-yyyy",
                     "dd.MM.yy", "d.MM.yy", "dd.M.yy", "d.MM.yyyy","dd.MM.yyyy","d.M.yyyy","d.M.yy","dd.M.yyyy",
                     };

                    DateTime dt;

                    if (DateTime.TryParse(DateFormat, out dt))
                    {
                        if (dt.Year >= DateTime.Now.Year && dt.Year <= 2099)
                        {
                            string formattedDate1 = dt.ToString("dd/MM/yyyy");
                            e.Cancel = false;
                            dataGridView1.CurrentCell.Value = formattedDate1;

                            dataGridView1.RefreshEdit();
                        }
                        else
                        {
                            e.Cancel = true;
                        }
                    }
                    else
                    {
                        // التحقق من تنسيقات محددة باستخدام DateTime.TryParseExact
                        foreach (string format in formats)
                        {
                            if (DateTime.TryParseExact(DateFormat, format, null, DateTimeStyles.None, out dt))
                            {
                                // التأكد من صحة العام 
                                if (dt.Year >= 1900 && dt.Year <= 2099)
                                {
                                    e.Cancel = false;
                                    string formattedDate1 = dt.ToString("dd/MM/yyyy");
                                    dataGridView1.CurrentCell.Value = formattedDate1;
                                    dataGridView1.RefreshEdit();
                                    break;
                                }
                                else
                                {
                                    e.Cancel = true;

                                }
                            }
                        }

                        if (dt == DateTime.MinValue) // لم يتم تحويل التاريخ
                        {
                            e.Cancel = true;

                        }
                    }
                }
            }
        }


        public void get_data_Item_or_barcode(TextEdit txt_num_or_id, TextEdit txt_name_Item)
        {
            if (txt_num_or_id.Text.Trim() != string.Empty)
            {
                DataRow[] dr_Item_bar = DB_Add_delete_update_.Database.ds.Tables["barcode"].Select("barcode_internath ='" + txt_num_or_id.Text.Trim() + "'");
                DataRow[] dr_Item_loca = DB_Add_delete_update_.Database.ds.Tables["barcode"].Select("barcode_local ='" + txt_num_or_id.Text.Trim() + "'");
                if (dr_Item_bar.Count() != 0)
                {
                    
                    DataRow dr_Item1 = DB_Add_delete_update_.Database.ds.Tables["Item"].Rows.Find(dr_Item_bar[0][3]);
                    txt_num_or_id.Text = dr_Item1[0].ToString();
                    txt_name_Item.Text = dr_Item1[1].ToString();
                    return;
                }
                else if (dr_Item_loca.Count() != 0)
                {
                    DataRow dr_Item1 = DB_Add_delete_update_.Database.ds.Tables["Item"].Rows.Find(dr_Item_loca[0][3]);
                    txt_num_or_id.Text = dr_Item1[0].ToString();
                    txt_name_Item.Text = dr_Item1[1].ToString();
                    return;
                }


                try
                {
                    DataRow[] dr_Item2 = DB_Add_delete_update_.Database.ds.Tables["Item"].Select("Item_no ='" + txt_num_or_id.Text.Trim() + "'");
                }
                catch
                {
                    txt_num_or_id.Text = "";
                    txt_name_Item.Text = "";
                    return;
                }
                DataRow[] dr_Item = DB_Add_delete_update_.Database.ds.Tables["Item"].Select("Item_no ='" + txt_num_or_id.Text.Trim() + "'");
                if (dr_Item.Count() != 0)
                {
                    txt_num_or_id.Text = dr_Item[0][0].ToString();
                    txt_name_Item.Text = dr_Item[0][1].ToString();
                }

            }
            else
            {
                txt_num_or_id.Text = "";
                txt_name_Item.Text = "";
            }
        }
    }
}
