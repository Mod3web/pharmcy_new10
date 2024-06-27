using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Manag_ph.storg
{
    class settle_Item
    {


    public void CheckBox1_CheckedChanged_()
        {
            var dr = Application.OpenForms["Main"] as Main;
            dr.dtp_settle1.Enabled = dr.ch_date_settle.Checked ? true : false;
            dr.dtp_settle2.Enabled = dr.ch_date_settle.Checked ? true : false;
        }


        //تعبئة الكمباء الخاص باالمخازن في شاشة التسويات
        public void Fill_com_storg_settle()
        {
            var dr = Application.OpenForms["Main"] as Main;
            dr.com_storg_All.DataSource = DB_Add_delete_update_.Database.ds.Tables["Storg"];
            dr.com_storg_All.DisplayMember = DB_Add_delete_update_.Database.ds.Tables["Storg"].Columns[1].ColumnName;
            dr.com_storg_All.ValueMember = DB_Add_delete_update_.Database.ds.Tables["Storg"].Columns[0].ColumnName;

        }



        public void serch_Item_get_name()
        {
            var dr = Application.OpenForms["Main"] as Main;
            int num = Convert.ToInt32(dr.txt_num_Item_settle.Text.Trim() == string.Empty ? "0" : dr.txt_num_Item_settle.Text.Trim());
            DataRow sr = DB_Add_delete_update_.Database.ds.Tables["Item"].Rows.Find(num);

            if (sr==null)
            {
                MessageBox.Show("الرقم المدخل غير صحيح");
            }
            else
            {
                dr.txt_name_Item_settle.Text = sr[1].ToString();
            }

        }


        public void Fill_resaol_settle()
        {
            var dr = Application.OpenForms["Main"] as Main;

            dr.combox_respos_settl.DataSource = DB_Add_delete_update_.Database.ds.Tables["Reason_settle"];
            dr.combox_respos_settl.DisplayMember = "name_resson_settl";
            dr.combox_respos_settl.ValueMember = "num_reason_settl";
        }


        public void Fill_com_Type_unit_settle()
        {

            var dr = Application.OpenForms["Main"] as Main;

            DataTable dt = new DataTable();
            dt.Columns.Add("num",typeof(int));
            dt.Columns.Add("name", typeof(string));

            dt.Rows.Add(1, "كبراء");
            dt.Rows.Add(2,"وسطاء");
            dt.Rows.Add(3, "صغرا");

            dr.com_Type_unit_settle.DataSource = dt;
            dr.com_Type_unit_settle.DisplayMember = "name";
            dr.com_Type_unit_settle.ValueMember = "num";


        }

        public object getData(string Item_Id,string TableName,int num_column_table)
        {
            DataRow unit_Storg = DB_Add_delete_update_.Database.ds.Tables["Item"].Rows.Find(Convert.ToInt32(Item_Id));

            DataRow compny = DB_Add_delete_update_.Database.ds.Tables[TableName].Rows.Find(Convert.ToInt32(unit_Storg[num_column_table]));

            return compny[1];

        }

        public void Fill_Table_settle() { 
        
            var ao = Application.OpenForms["Main"] as Main;
            ao.dgv_settle_dgv.Rows.Clear();

            DataTable dt = new DataTable();

            for (int i = 0; i < DB_Add_delete_update_.Database.ds.Tables["Item_storg"].Columns.Count; i++)//اضافة اسما الاعمدة الا الجدول الجديد
            {
                dt.Columns.Add(DB_Add_delete_update_.Database.ds.Tables["Item_storg"].Columns[i].ColumnName);

            }

            if (!ao.ch_date_settle.Checked)
            {
                
                if (ao.txt_num_Item_settle.Text.Trim() == string.Empty)// التحقق من انهو لايبحث برقم الصنف
                {
                    int num_storg = Convert.ToInt32(ao.com_storg_All.SelectedValue.ToString());// ايجاد رقم المخزم
                    DataRow[] dr = DB_Add_delete_update_.Database.ds.Tables["sum_storg_Item"].Select("Storg_no = " + num_storg);//اخراج ارقام الاصناف الموجودة في المخزن

                    if (dr.Count() != 0)
                    {
                        for (int i = 0; i < dr.Count(); i++)
                        {
                            DataRow[] new_Item = DB_Add_delete_update_.Database.ds.Tables["Item_storg"].Select("sum_num = " + Convert.ToInt32(dr[i][0]));
                            if (new_Item.Count() != 0)
                            {
                                for (int j = 0; j < new_Item.Count(); j++)
                                {
                                    dt.Rows.Add(new_Item[j].ItemArray);

                                }
                            }
                        }
                    }
                }
                else
                {
                    int num_storg = Convert.ToInt32(ao.com_storg_All.SelectedValue.ToString());// ايجاد رقم المخزم
                    DataRow[] dr = DB_Add_delete_update_.Database.ds.Tables["sum_storg_Item"].Select("Storg_no = " + num_storg);//اخراج ارقام الاصناف الموجودة في المخزن

                    if (dr.Count() != 0)
                    {
                        for (int i = 0; i < dr.Count(); i++)
                        {
                            DataRow[] new_Item = DB_Add_delete_update_.Database.ds.Tables["Item_storg"].Select("sum_num = " + Convert.ToInt32(dr[i][0]) + " AND Item_no = " + Convert.ToInt32(ao.txt_num_Item_settle.Text));
                            if (new_Item.Count() != 0)
                            {
                                for (int j = 0; j < new_Item.Count(); j++)
                                {
                                    dt.Rows.Add(new_Item[j].ItemArray);

                                }
                            }
                        }
                    }
                }
            }else
            {
                DateTime str1 = Convert.ToDateTime(ao.dtp_settle1.Text);
                DateTime str2 = Convert.ToDateTime(ao.dtp_settle2.Text);

                if (ao.txt_num_Item_settle.Text.Trim() == string.Empty)// التحقق من انهو لايبحث برقم الصنف
                {
                    int num_storg = Convert.ToInt32(ao.com_storg_All.SelectedValue.ToString());// ايجاد رقم المخزم
                    DataRow[] dr = DB_Add_delete_update_.Database.ds.Tables["sum_storg_Item"].Select("Storg_no = " + num_storg);//اخراج ارقام الاصناف الموجودة في المخزن

                    if (dr.Count() != 0)
                    {
                        for (int i = 0; i < dr.Count(); i++)
                        {
                            DataRow[] new_Item = DB_Add_delete_update_.Database.ds.Tables["Item_storg"].Select("sum_num = " + Convert.ToInt32(dr[i][0]) + " AND ( Date_end >= '" + str1+ "' AND  Date_end <= '"+ str2+"' )");
                            if (new_Item.Count() != 0)
                            {
                                for (int j = 0; j < new_Item.Count(); j++)
                                {
                                    dt.Rows.Add(new_Item[j].ItemArray);

                                }
                            }
                        }
                    }
                }
                else
                {
                    int num_storg = Convert.ToInt32(ao.com_storg_All.SelectedValue.ToString());// ايجاد رقم المخزم
                    DataRow[] dr = DB_Add_delete_update_.Database.ds.Tables["sum_storg_Item"].Select("Storg_no = " + num_storg);//اخراج ارقام الاصناف الموجودة في المخزن

                    if (dr.Count() != 0)
                    {
                        for (int i = 0; i < dr.Count(); i++)
                        {

                            DataRow[] new_Item = DB_Add_delete_update_.Database.ds.Tables["Item_storg"].Select("sum_num = " + Convert.ToInt32(dr[i][0]) + " AND Item_no = " + Convert.ToInt32(ao.txt_num_Item_settle.Text)+ " AND Date_end >= '"+ str1 +"'");
                            if (new_Item.Count() != 0)
                            {
                                for (int j = 0; j < new_Item.Count(); j++)
                                {
                                    dt.Rows.Add(new_Item[j].ItemArray);

                                }
                            }
                        }
                    }
                }

            }












            for (int i = 0; i < dt.Rows.Count; i++)//تعبئة الجدول بلبيانات
            {
               

                if (ao.txt_num_Item_settle.Text.Trim() == string.Empty)
                {

                    DataRow unit_Storg = DB_Add_delete_update_.Database.ds.Tables["therpeutic_unite"].Rows.Find(dt.Rows[i][10]);// ايجاد الوحد المخزنة
                    if (Convert.ToInt32(ao.com_Type_unit_settle.SelectedValue) == 3)//نوع الفلتر الوحدة الصغرا
                    {
                        DataRow temp = DB_Add_delete_update_.Database.ds.Tables["Item"].Rows.Find(Convert.ToInt32(dt.Rows[i][9]));
                        if (Convert.ToInt32(dt.Rows[i][12]) == 3)//نوع الفلتر الوحدة الصغرا
                        {

                            ao.dgv_settle_dgv.Rows.Add(dt.Rows[i][9], temp[2], temp[1], Convert.ToDateTime(dt.Rows[i][2]).ToString("yyyy/MM/dd"), Convert.ToDateTime(dt.Rows[i][2]).ToString("yyyy/MM/dd"), null, dt.Rows[i][1], dt.Rows[i][1], dt.Rows[i][8], dt.Rows[i][8], dt.Rows[i][7], getData(dt.Rows[i][9].ToString(), "manufctur_company",10), getData(dt.Rows[i][9].ToString(), "nature_of_Item",16), getData(dt.Rows[i][9].ToString(), "sciehtific_collection",12), getData(dt.Rows[i][9].ToString(), "effective_material",15), dt.Rows[i][0], dt.Rows[i][11],0,3);

                            DataGridViewComboBoxCell DGVCB = ao.dgv_settle_dgv.Rows[ao.dgv_settle_dgv.Rows.Count - 1].Cells[5] as DataGridViewComboBoxCell;
                            DataRow[] dr_unit = DB_Add_delete_update_.Database.ds.Tables["unite_items"].Select("Item_no = " + Convert.ToInt32(dt.Rows[i][9]));
                         
                                DataRow dr_unit_Item = DB_Add_delete_update_.Database.ds.Tables["therpeutic_unite"].Rows.Find(Convert.ToInt32(dr_unit[0][3]));
                                DGVCB.Items.Add(dr_unit_Item[1]);
                            DGVCB.Value = DGVCB.Items[0];


                        }

                    }
                    else if (Convert.ToInt32(ao.com_Type_unit_settle.SelectedValue) == 2)//نوع الفلتر الوحدة الوسطاء
                    {
                        DataRow temp = DB_Add_delete_update_.Database.ds.Tables["Item"].Rows.Find(Convert.ToInt32(dt.Rows[i][9]));

                        if (Convert.ToInt32(dt.Rows[i][12]) == 2)//نوع الفلتر الوحدة الوسطاء
                        {
                            ao.dgv_settle_dgv.Rows.Add(dt.Rows[i][9], temp[2], temp[1], Convert.ToDateTime(dt.Rows[i][2]).ToString("yyyy/MM/dd"), Convert.ToDateTime(dt.Rows[i][2]).ToString("yyyy/MM/dd"), null, dt.Rows[i][1], dt.Rows[i][1], dt.Rows[i][8], dt.Rows[i][8], dt.Rows[i][7], getData(dt.Rows[i][9].ToString(), "manufctur_company",10), getData(dt.Rows[i][9].ToString(), "nature_of_Item",16),getData(dt.Rows[i][9].ToString(), "sciehtific_collection",12), getData(dt.Rows[i][9].ToString(), "effective_material",15), dt.Rows[i][0], dt.Rows[i][11],0,2);
                            DataGridViewComboBoxCell DGVCB = ao.dgv_settle_dgv.Rows[ao.dgv_settle_dgv.Rows.Count - 1].Cells[5] as DataGridViewComboBoxCell;
                            DataRow[] dr_unit = DB_Add_delete_update_.Database.ds.Tables["unite_items"].Select("Item_no = " + Convert.ToInt32(dt.Rows[i][9]));
                            for (int j = 2; j < 4; j++)
                            {
                                DataRow dr_unit_Item = DB_Add_delete_update_.Database.ds.Tables["therpeutic_unite"].Rows.Find(Convert.ToInt32(dr_unit[0][j]));
                                DGVCB.Items.Add(dr_unit_Item[1]);
                            }
                            DGVCB.Value = DGVCB.Items[0];
                        }
                    }
                    else if (Convert.ToInt32(ao.com_Type_unit_settle.SelectedValue) == 1)//نوع الفلتر الوحدة كبرا
                    {
                        DataRow temp = DB_Add_delete_update_.Database.ds.Tables["Item"].Rows.Find(Convert.ToInt32(dt.Rows[i][9]));
                        if (Convert.ToInt32(dt.Rows[i][12]) == 1)//نوع الفلتر الوحدة كبرا
                        {

                            //MessageBox.Show(temp.ItemArray[1]+"");


                            ao.dgv_settle_dgv.Rows.Add(dt.Rows[i][9], temp[2], temp[1], Convert.ToDateTime(dt.Rows[i][2]).ToString("yyyy/MM/dd"), Convert.ToDateTime(dt.Rows[i][2]).ToString("yyyy/MM/dd"), null, dt.Rows[i][1], dt.Rows[i][1], dt.Rows[i][8], dt.Rows[i][8], dt.Rows[i][7], getData(dt.Rows[i][9].ToString(), "manufctur_company", 10), getData(dt.Rows[i][9].ToString(), "nature_of_Item", 16), getData(dt.Rows[i][9].ToString(), "sciehtific_collection", 12), getData(dt.Rows[i][9].ToString(), "effective_material", 15), dt.Rows[i][0], dt.Rows[i][11], 0, 1);




                            DataGridViewComboBoxCell DGVCB = ao.dgv_settle_dgv.Rows[ao.dgv_settle_dgv.Rows.Count - 1].Cells[5] as DataGridViewComboBoxCell;
                            DataRow[] dr_unit = DB_Add_delete_update_.Database.ds.Tables["unite_items"].Select("Item_no = " + Convert.ToInt32(dt.Rows[i][9]));
                            for (int j = 1; j < 4; j++)
                            {
                                DataRow dr_unit_Item = DB_Add_delete_update_.Database.ds.Tables["therpeutic_unite"].Rows.Find(Convert.ToInt32(dr_unit[0][j]));
                                DGVCB.Items.Add(dr_unit_Item[1]);
                            }
                            DGVCB.Value = DGVCB.Items[0];
                        }
                    }

                }
                else
                {

                    DataRow unit_Storg = DB_Add_delete_update_.Database.ds.Tables["therpeutic_unite"].Rows.Find(dt.Rows[i][10]);// ايجاد الوحد المخزنة
                    if (Convert.ToInt32(ao.com_Type_unit_settle.SelectedValue) == 3)//نوع الفلتر الوحدة الصغرا
                    {
                        DataRow temp = DB_Add_delete_update_.Database.ds.Tables["Item"].Rows.Find(Convert.ToInt32(dt.Rows[i][9]));
                        if (Convert.ToInt32(dt.Rows[i][12]) == 3)//نوع الفلتر الوحدة الصغرا
                        {

                            ao.dgv_settle_dgv.Rows.Add(dt.Rows[i][9], temp[2], temp[1], Convert.ToDateTime(dt.Rows[i][2]).ToString("yyyy/MM/dd"), Convert.ToDateTime(dt.Rows[i][2]).ToString("yyyy/MM/dd"), null, dt.Rows[i][1], dt.Rows[i][1], dt.Rows[i][8], dt.Rows[i][8], dt.Rows[i][7], getData(dt.Rows[i][9].ToString(), "manufctur_company",10), getData(dt.Rows[i][9].ToString(), "nature_of_Item",16), getData(dt.Rows[i][9].ToString(), "sciehtific_collection",12), getData(dt.Rows[i][9].ToString(), "effective_material",15), dt.Rows[i][0], dt.Rows[i][11],0,3);
                            DataGridViewComboBoxCell DGVCB = ao.dgv_settle_dgv.Rows[ao.dgv_settle_dgv.Rows.Count - 1].Cells[5] as DataGridViewComboBoxCell;
                            DataRow[] dr_unit = DB_Add_delete_update_.Database.ds.Tables["unite_items"].Select("Item_no = " + Convert.ToInt32(dt.Rows[i][9]));
                          
                                DataRow dr_unit_Item = DB_Add_delete_update_.Database.ds.Tables["therpeutic_unite"].Rows.Find(Convert.ToInt32(dr_unit[0][3]));
                            DGVCB.Items.Add(dr_unit_Item[1]);
                            DGVCB.Value = DGVCB.Items[0];
                            //break;
                        }

                    }
                    else if (Convert.ToInt32(ao.com_Type_unit_settle.SelectedValue) == 2)//نوع الفلتر الوحدة الوسطاء
                    {
                        DataRow temp = DB_Add_delete_update_.Database.ds.Tables["Item"].Rows.Find(Convert.ToInt32(dt.Rows[i][9]));

                        if (Convert.ToInt32(dt.Rows[i][12]) == 2)//نوع الفلتر الوحدة الوسطاء
                        {
                            ao.dgv_settle_dgv.Rows.Add(dt.Rows[i][9], temp[2], temp[1], Convert.ToDateTime(dt.Rows[i][2]).ToString("yyyy/MM/dd"), Convert.ToDateTime(dt.Rows[i][2]).ToString("yyyy/MM/dd"), null, dt.Rows[i][1], dt.Rows[i][1], dt.Rows[i][8], dt.Rows[i][8], dt.Rows[i][7], getData(dt.Rows[i][9].ToString(), "manufctur_company",10), getData(dt.Rows[i][9].ToString(), "nature_of_Item",16), getData(dt.Rows[i][9].ToString(), "sciehtific_collection",12), getData(dt.Rows[i][9].ToString(), "effective_material",15), dt.Rows[i][0], dt.Rows[i][11],0,2);
                            DataGridViewComboBoxCell DGVCB = ao.dgv_settle_dgv.Rows[ao.dgv_settle_dgv.Rows.Count - 1].Cells[5] as DataGridViewComboBoxCell;
                            DataRow[] dr_unit = DB_Add_delete_update_.Database.ds.Tables["unite_items"].Select("Item_no = " + Convert.ToInt32(dt.Rows[i][9]));
                            for (int j = 2; j < 4; j++)
                            {
                                DataRow dr_unit_Item = DB_Add_delete_update_.Database.ds.Tables["therpeutic_unite"].Rows.Find(Convert.ToInt32(dr_unit[0][j]));
                                DGVCB.Items.Add(dr_unit_Item[1]);
                            }
                            DGVCB.Value = DGVCB.Items[0];
                            //break;
                        }
                    }
                    else if (Convert.ToInt32(ao.com_Type_unit_settle.SelectedValue) == 1)//نوع الفلتر الوحدة كبرا
                    {
                        DataRow temp = DB_Add_delete_update_.Database.ds.Tables["Item"].Rows.Find(Convert.ToInt32(dt.Rows[i][9]));
                        if (Convert.ToInt32(dt.Rows[i][12]) == 1)//نوع الفلتر الوحدة الوسطاء
                        {
                            ao.dgv_settle_dgv.Rows.Add(dt.Rows[i][9], temp[2], temp[1], Convert.ToDateTime(dt.Rows[i][2]).ToString("yyyy/MM/dd"), Convert.ToDateTime(dt.Rows[i][2]).ToString("yyyy/MM/dd"), null, dt.Rows[i][1], dt.Rows[i][1], dt.Rows[i][8], dt.Rows[i][8], dt.Rows[i][7], getData(dt.Rows[i][9].ToString(), "manufctur_company",10), getData(dt.Rows[i][9].ToString(), "nature_of_Item",16), getData(dt.Rows[i][9].ToString(), "sciehtific_collection",12), getData(dt.Rows[i][9].ToString(), "effective_material",15), dt.Rows[i][0], dt.Rows[i][11],0,1);
                            DataGridViewComboBoxCell DGVCB = ao.dgv_settle_dgv.Rows[ao.dgv_settle_dgv.Rows.Count - 1].Cells[5] as DataGridViewComboBoxCell;
                            DataRow[] dr_unit = DB_Add_delete_update_.Database.ds.Tables["unite_items"].Select("Item_no = " + Convert.ToInt32(dt.Rows[i][9]));
                            for (int j = 1; j < 4; j++)
                            {
                                DataRow dr_unit_Item = DB_Add_delete_update_.Database.ds.Tables["therpeutic_unite"].Rows.Find(Convert.ToInt32(dr_unit[0][j]));
                                DGVCB.Items.Add(dr_unit_Item[1]);
                            }
                            DGVCB.Value = DGVCB.Items[0];
                        }
                        //break;
                    }

                }

            }
            //MessageBox.Show(dt.Rows.Count+"");


        }
        

        public void Dgv_settle_EditingControlShowing_(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            var ao = Application.OpenForms["Main"] as Main;
            if (ao.dgv_settle_dgv.CurrentRow != null)
            {
                if (ao.dgv_settle_dgv.CurrentCell.ColumnIndex == 6 || ao.dgv_settle_dgv.CurrentCell.ColumnIndex == 7 || ao.dgv_settle_dgv.CurrentCell.ColumnIndex == 9)
                {
                    if (e.Control is TextBox)
                    {
                        e.Control.KeyPress += delegate (object Mysned, KeyPressEventArgs Mye)
                        {
                            if (!(char.IsDigit(Mye.KeyChar) || Mye.KeyChar == 8 ))
                            {
                                Mye.Handled = true;
                            }
                        };
                    }



                }else if (ao.dgv_settle_dgv.CurrentCell.ColumnIndex == 5)
                {
                    ComboBox com = new ComboBox();
                    com = e.Control as ComboBox;

                    com.SelectedIndexChanged += delegate (object Mysender, EventArgs Me)
                    {
                        if (ao.com_Type_unit_settle.SelectedIndex == 0)// لو كان يبحث في الوحدة الكبرا
                        {
                            if (com.SelectedIndex == 0)// وييريد التعديل في الوحدة الكبرا
                            {
                                ao.dgv_settle_dgv.Columns[9].ReadOnly = false;
                                int num = Convert.ToInt32(ao.dgv_settle_dgv.CurrentRow.Cells[15].Value);// رقم الصنف المخزن
                                DataRow dr = DB_Add_delete_update_.Database.ds.Tables["Item_storg"].Rows.Find(num);

                                ao.dgv_settle_dgv.CurrentRow.Cells[6].Value = Convert.ToInt32(dr[1]);//الكمية القديمة 
                                ao.dgv_settle_dgv.CurrentRow.Cells[7].Value = Convert.ToInt32(dr[1]);//الكمية الجديدة 

                                ao.dgv_settle_dgv.CurrentRow.Cells[8].Value = Convert.ToInt32(dr[8]);//سعر البيع القديم
                                ao.dgv_settle_dgv.CurrentRow.Cells[9].Value = Convert.ToInt32(dr[8]);//سعر البيع الجديد

                                ao.dgv_settle_dgv.CurrentRow.Cells[10].Value = Convert.ToInt32(dr[7]); //سعر الشراء

                                ao.dgv_settle_dgv.CurrentRow.Cells[18].Value = Convert.ToInt32(1);
                            }
                            else if (com.SelectedIndex == 1)// وييريد التعديل في الوحدة الوسطاء
                            {
                                ao.dgv_settle_dgv.Columns[9].ReadOnly = true;
                                int num = Convert.ToInt32(ao.dgv_settle_dgv.CurrentRow.Cells[15].Value);// رقم الصنف المخزن
                                DataRow dr = DB_Add_delete_update_.Database.ds.Tables["Item_storg"].Rows.Find(num);
                                ao.dgv_settle_dgv.CurrentRow.Cells[6].Value = Convert.ToInt32(dr[13]);//الكمية القديمة في الوحدة  المتوسطة
                                ao.dgv_settle_dgv.CurrentRow.Cells[7].Value = Convert.ToInt32(dr[13]);//الكمية الجديدة في الوحدة  المتوسطة

                                int num_Item = Convert.ToInt32(ao.dgv_settle_dgv.CurrentRow.Cells[0].Value);
                                DataRow[] dr_unit_And_pric = DB_Add_delete_update_.Database.ds.Tables["unite_items"].Select("item_no =" + num_Item);

                                int pric_avrg = Convert.ToInt32(dr[8]);

                                double resolt = pric_avrg / Convert.ToInt32( dr_unit_And_pric[0][4]);

                                ao.dgv_settle_dgv.CurrentRow.Cells[8].Value = resolt.ToString("N0");//سعر البيع الجديد في الوحدة الوسطاء
                                ao.dgv_settle_dgv.CurrentRow.Cells[9].Value = resolt.ToString("N0");//سعر البيع الجديد في الوحدة الوسطاء



                                ao.dgv_settle_dgv.CurrentRow.Cells[18].Value = Convert.ToInt32(2);// اضافة ارقام لنوع الذي يريد تعديلة


                                //===================================
                                //حساب سعر الشرا للوحدة الوسطاء
                                double pric_prodect = Convert.ToDouble(dr[7]);
                                int digtal_unitAvrg = Convert.ToInt32(dr_unit_And_pric[0][4]);
                                double Temp = pric_prodect / digtal_unitAvrg;
                                ao.dgv_settle_dgv.CurrentRow.Cells[10].Value = Convert.ToDouble(Temp);//سعر الشراء الوحدة الوسطا
                                                                                                  //===================================
                            }
                            else if (com.SelectedIndex == 2)// وييريد التعديل في الوحدة الصغرا
                            {
                                ao.dgv_settle_dgv.Columns[9].ReadOnly = true;
                                int num = Convert.ToInt32(ao.dgv_settle_dgv.CurrentRow.Cells[15].Value);// رقم الصنف المخزن
                                DataRow dr = DB_Add_delete_update_.Database.ds.Tables["Item_storg"].Rows.Find(num);
                                ao.dgv_settle_dgv.CurrentRow.Cells[6].Value = Convert.ToInt32(dr[14]);//الكمية القديمة في الوحدة  المتوسطة
                                ao.dgv_settle_dgv.CurrentRow.Cells[7].Value = Convert.ToInt32(dr[14]);//الكمية الجديدة في الوحدة  المتوسطة

                                int num_Item = Convert.ToInt32(ao.dgv_settle_dgv.CurrentRow.Cells[0].Value);
                                DataRow[] dr_unit_And_pric = DB_Add_delete_update_.Database.ds.Tables["unite_items"].Select("item_no =" + num_Item);


                                int pric_avrg = Convert.ToInt32(dr[8]);

                                double resolt = pric_avrg / Convert.ToInt32(dr_unit_And_pric[0][4]);

                                double resolt_smoll = resolt / Convert.ToInt32(dr_unit_And_pric[0][5]);


                                ao.dgv_settle_dgv.CurrentRow.Cells[8].Value = resolt_smoll.ToString("N0");//سعر البيع الجديد في الوحدة الوسطاء
                                ao.dgv_settle_dgv.CurrentRow.Cells[9].Value = resolt_smoll.ToString("N0");//سعر البيع الجديد في الوحدة الوسطاء

                                ao.dgv_settle_dgv.CurrentRow.Cells[18].Value = Convert.ToInt32(3);// اضافة ارقام لنوع الذي يريد تعديلة

                                //===================================
                                //حساب سعر الشرا للوحدة الوسطاء
                                double pric_prodect = Convert.ToDouble(dr[7]);
                                int digtal_unitAvrg = Convert.ToInt32(dr_unit_And_pric[0][4]);// جلب عدد وحداد الوحدة المتوسطة
                                int digtal_unitsmoll = Convert.ToInt32(dr_unit_And_pric[0][5]);// جلب عدد وحداد الوحدة الصغرا
                                double Temp_Avrg = pric_prodect / digtal_unitAvrg;// ايجاد سعر البيع للوحدة الوسطاء
                                double Temp_smoll = Temp_Avrg / digtal_unitsmoll;// ايجاد سعر البيع للوحدة الصغرا
                                ao.dgv_settle_dgv.CurrentRow.Cells[10].Value = Convert.ToDouble(Temp_smoll);//سعر الشراء الوحدة الوسطا
                                //===================================
                            }
                        }
                        else if (ao.com_Type_unit_settle.SelectedIndex == 1)// لو كان يبحث في الوحدة الوسطاء
                        {
                            if (com.SelectedIndex == 0)// وييريد التعديل في الوحدة الوسطاء
                            {
                                ao.dgv_settle_dgv.Columns[9].ReadOnly = false;
                                int num = Convert.ToInt32(ao.dgv_settle_dgv.CurrentRow.Cells[15].Value);// رقم الصنف المخزن
                                DataRow dr = DB_Add_delete_update_.Database.ds.Tables["Item_storg"].Rows.Find(num);

                                ao.dgv_settle_dgv.CurrentRow.Cells[6].Value = Convert.ToInt32(dr[1]);//الكمية القديمة 
                                ao.dgv_settle_dgv.CurrentRow.Cells[7].Value = Convert.ToInt32(dr[1]);//الكمية الجديدة 

                                ao.dgv_settle_dgv.CurrentRow.Cells[8].Value = Convert.ToInt32(dr[8]);//سعر البيع القديم
                                ao.dgv_settle_dgv.CurrentRow.Cells[9].Value = Convert.ToInt32(dr[8]);//سعر البيع الجديد

                                ao.dgv_settle_dgv.CurrentRow.Cells[10].Value = Convert.ToInt32(dr[7]); //سعر الشراء

                                ao.dgv_settle_dgv.CurrentRow.Cells[18].Value = Convert.ToInt32(2);// اضافة ارقام لنوع الذي يريد تعديلة


                            }
                            else if (com.SelectedIndex == 1)// وييريد التعديل في الوحدة الصغرا
                            {
                                ao.dgv_settle_dgv.Columns[9].ReadOnly = true;
                                int num = Convert.ToInt32(ao.dgv_settle_dgv.CurrentRow.Cells[15].Value);// رقم الصنف المخزن
                                DataRow dr = DB_Add_delete_update_.Database.ds.Tables["Item_storg"].Rows.Find(num);
                                ao.dgv_settle_dgv.CurrentRow.Cells[6].Value = Convert.ToInt32(dr[14]);//الكمية القديمة في الوحدة  الصغرا
                                ao.dgv_settle_dgv.CurrentRow.Cells[7].Value = Convert.ToInt32(dr[14]);//الكمية الجديدة في الوحدة  الصغرا

                                int num_Item = Convert.ToInt32(ao.dgv_settle_dgv.CurrentRow.Cells[0].Value);
                                DataRow[] dr_unit_And_pric = DB_Add_delete_update_.Database.ds.Tables["unite_items"].Select("item_no =" + num_Item);

                                int pric_avrg = Convert.ToInt32(dr[8]);

                                double resolt = pric_avrg / Convert.ToInt32(dr_unit_And_pric[0][5]);

                                ao.dgv_settle_dgv.CurrentRow.Cells[8].Value = resolt.ToString("N0");//سعر البيع الجديد في الوحدة الصغرا
                                ao.dgv_settle_dgv.CurrentRow.Cells[9].Value = resolt.ToString("N0");//سعر البيع الجديد في الوحدة الصغرا

                                ao.dgv_settle_dgv.CurrentRow.Cells[18].Value = Convert.ToInt32(3);// اضافة ارقام لنوع الذي يريد تعديلة

                                //===================================
                                //حساب سعر الشرا للوحدة الصغرا
                                double pric_prodect = Convert.ToDouble(dr[7]);
                                int digtal_unitsmoll = Convert.ToInt32(dr_unit_And_pric[0][5]);
                                double Temp = pric_prodect / digtal_unitsmoll;
                                ao.dgv_settle_dgv.CurrentRow.Cells[10].Value = Convert.ToDouble(Temp);//سعر الشراء الوحدة الصغرا
                                //===================================
                            }

                        }
                          
                    };

                }

            }
        }
        public void Button24_Click_(object sender, EventArgs e)
        {
            var dr = Application.OpenForms["Main"] as Main;
            if (dr.dgv_settle_dgv.Rows.Count != 0)
            {


                for (int i = 0; i < dr.dgv_settle_dgv.Rows.Count; i++)
                {
                    if ((dr.dgv_settle_dgv.Rows[i].Cells[3].Value.ToString() != dr.dgv_settle_dgv.Rows[i].Cells[4].Value.ToString()) || (dr.dgv_settle_dgv.Rows[i].Cells[6].Value.ToString() != dr.dgv_settle_dgv.Rows[i].Cells[7].Value.ToString()) || (dr.dgv_settle_dgv.Rows[i].Cells[8].Value.ToString() != dr.dgv_settle_dgv.Rows[i].Cells[9].Value.ToString()))
                    {
                        dr.dgv_settle_dgv.Rows[i].Cells[17].Value = 1;
                    }
                    else
                    {
                        dr.dgv_settle_dgv.Rows[i].Cells[17].Value = 0;

                    }
                }
                bool mass = false;
                for (int i = 0; i < dr.dgv_settle_dgv.Rows.Count; i++)
                {
                    if (Convert.ToInt32(dr.dgv_settle_dgv.Rows[i].Cells[17].Value) == 1)
                    {
                        mass = true;

                        int num_Item_storg = Convert.ToInt32(dr.dgv_settle_dgv.Rows[i].Cells[15].Value);
                        object[] dr_Item_update = DB_Add_delete_update_.Database.ds.Tables["Item_storg"].Rows.Find(num_Item_storg).ItemArray;
                        if ((dr.dgv_settle_dgv.Rows[i].Cells[3].Value.ToString() != dr.dgv_settle_dgv.Rows[i].Cells[4].Value.ToString()))// تعديل تاريخ الانتها
                        {
                            dr_Item_update[2] = dr.dgv_settle_dgv.Rows[i].Cells[4].Value;
                        }
                        if ((dr.dgv_settle_dgv.Rows[i].Cells[6].Value.ToString() != dr.dgv_settle_dgv.Rows[i].Cells[7].Value.ToString()))// تعديل الكمية
                        {

                            if (dr.com_Type_unit_settle.SelectedIndex == 0)
                            {

                                if (Convert.ToInt32(dr.dgv_settle_dgv.Rows[i].Cells[18].Value) == 1)
                                {

                                    int num = Convert.ToInt32(dr.dgv_settle_dgv.Rows[i].Cells[0].Value);
                                    DataRow[] dr_num_avrg = DB_Add_delete_update_.Database.ds.Tables["unite_items"].Select("item_no =" + num);
                                    int num_avrg = Convert.ToInt32(dr_num_avrg[0][4]);// عدد الوحدة الوسطا
                                    int num_smool = Convert.ToInt32(dr_num_avrg[0][5]);// عدد الوحدة الوسطا
                                    int quity = Convert.ToInt32(dr.dgv_settle_dgv.Rows[i].Cells[7].Value);//كمية الوحدة الكبرا
                                    int quity_avrg = quity * num_avrg;
                                    int quilty_smol = quity_avrg * num_smool;
                                    dr_Item_update[1] = quity;
                                    dr_Item_update[13] = quity_avrg;
                                    dr_Item_update[14] = quilty_smol;


                                }
                                else if (Convert.ToInt32(dr.dgv_settle_dgv.Rows[i].Cells[18].Value) == 2)// اذاكان في الوحدة الكبرا ويريد التعديل في الوحدة الوسطاء
                                {
                                    int num = Convert.ToInt32(dr.dgv_settle_dgv.Rows[i].Cells[0].Value);
                                    DataRow[] dr_num_avrg = DB_Add_delete_update_.Database.ds.Tables["unite_items"].Select("item_no =" + num);
                                    int num_avrg = Convert.ToInt32(dr_num_avrg[0][4]);// عدد الوحدة الوسطا
                                    int num_smool = Convert.ToInt32(dr_num_avrg[0][5]);// عدد الوحدة الوسطا
                                    int quity = Convert.ToInt32(dr.dgv_settle_dgv.Rows[i].Cells[7].Value);//كمية الوحدة الوسطا
                                    int quity_new = quity / num_avrg;
                                    int quilty_smol = num_smool * quity;
                                    dr_Item_update[1] = quity_new;
                                    dr_Item_update[13] = quity;
                                    dr_Item_update[14] = quilty_smol;

                                    // لم اكمل التعديل علا الوحدة الصغرا وهو يبحث في الوحدة الكبرا
                                }
                                else if (Convert.ToInt32(dr.dgv_settle_dgv.Rows[i].Cells[18].Value) == 3)
                                {

                                    int num = Convert.ToInt32(dr.dgv_settle_dgv.Rows[i].Cells[0].Value);
                                    DataRow[] dr_num_avrg = DB_Add_delete_update_.Database.ds.Tables["unite_items"].Select("item_no =" + num);
                                    int num_avrg = Convert.ToInt32(dr_num_avrg[0][4]);// عدد الوحدة الوسطا
                                    int num_smool = Convert.ToInt32(dr_num_avrg[0][5]);// عدد الوحدة الصغرا
                                    int quity = Convert.ToInt32(dr.dgv_settle_dgv.Rows[i].Cells[7].Value);//كمية الوحدة الصغرا
                                    int quity_new_Avrg = quity / num_smool;// ايجاد الكمية الوسطا
                                    int quilty_new_Qobra = quity_new_Avrg / num_avrg;// ايجاد الكمية الكبرا
                                    dr_Item_update[1] = quilty_new_Qobra;
                                    dr_Item_update[13] = quity_new_Avrg;
                                    dr_Item_update[14] = quity;

                                }

                            }
                            else if (dr.com_Type_unit_settle.SelectedIndex == 1)
                            {
                                if (Convert.ToInt32(dr.dgv_settle_dgv.Rows[i].Cells[18].Value) == 2)
                                {

                                    int num = Convert.ToInt32(dr.dgv_settle_dgv.Rows[i].Cells[0].Value);
                                    DataRow[] dr_num_avrg = DB_Add_delete_update_.Database.ds.Tables["unite_items"].Select("item_no =" + num);
                                    int num_smool = Convert.ToInt32(dr_num_avrg[0][5]);// عدد الوحدة الصغرا
                                    int quity = Convert.ToInt32(dr.dgv_settle_dgv.Rows[i].Cells[7].Value);//كمية الوحدة الوسطاء
                                    int quilty_new_smoll = quity * num_smool;// ايجاد الكمية الكبرا
                                    dr_Item_update[1] = quity;
                                    dr_Item_update[14] = quilty_new_smoll;

                                }
                                else if (Convert.ToInt32(dr.dgv_settle_dgv.Rows[i].Cells[18].Value) == 3)
                                {

                                    int num = Convert.ToInt32(dr.dgv_settle_dgv.Rows[i].Cells[0].Value);
                                    DataRow[] dr_num_avrg = DB_Add_delete_update_.Database.ds.Tables["unite_items"].Select("item_no =" + num);
                                    int num_smool = Convert.ToInt32(dr_num_avrg[0][5]);// عدد الوحدة الصغرا
                                    int quity = Convert.ToInt32(dr.dgv_settle_dgv.Rows[i].Cells[7].Value);//كمية الوحدة الصغرا
                                    int quilty_new_avrg = quity / num_smool;// ايجاد الكمية الكبرا
                                    dr_Item_update[1] = quilty_new_avrg;
                                    dr_Item_update[14] = quity;

                                }

                            }
                            else if (dr.com_Type_unit_settle.SelectedIndex == 2)
                            {
                                int quity = Convert.ToInt32(dr.dgv_settle_dgv.Rows[i].Cells[7].Value);//كمية الوحدة الصغرا
                                dr_Item_update[1] = quity;
                                dr_Item_update[14] = quity;
                            }




                        }
                        if ((dr.dgv_settle_dgv.Rows[i].Cells[8].Value.ToString() != dr.dgv_settle_dgv.Rows[i].Cells[9].Value.ToString()))// تعديل سعر البيع
                        {
                            dr_Item_update[8] = dr.dgv_settle_dgv.Rows[i].Cells[9].Value;

                            if (dr.com_Type_unit_settle.SelectedIndex == 0)
                            {
                                //DialogResult drs = MessageBox.Show("!!هل تريد تغير سعر البيع للوحدة الكبرا في كرات الصنف", "تغير", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1);
                                //if (drs == DialogResult.Yes)// تغير سعر البيع في كرت الصنف
                                //{
                                    int num_Item = Convert.ToInt32(dr.dgv_settle_dgv.Rows[i].Cells[0].Value);//رقم الصنف
                                    DataRow[] dr_pric_Item = DB_Add_delete_update_.Database.ds.Tables["pric"].Select("Item_no =" + num_Item);// البحث في التسعيرات عن الصنف
                                    object[] oj_One_pric = dr_pric_Item[0].ItemArray;
                                    oj_One_pric[1] = Convert.ToInt32(dr.dgv_settle_dgv.Rows[i].Cells[9].Value);// تعديل كرت الصنف
                                    new classs_table.Items_Tools().update_Rows_Table_Database("pric", dr_pric_Item[0][0].ToString(), oj_One_pric);// تعديل في قواعد البيانات

                                //}
                            }
                            else if (dr.com_Type_unit_settle.SelectedIndex == 1)
                            {
                                //DialogResult drs = MessageBox.Show("!!هل تريد تغير سعر البيع للوحدة الوسطاء في كرات الصنف", "تغير", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1);
                                //if (drs == DialogResult.Yes)// تغير سعر البيع في كرت الصنف
                                //{
                                    int num_Item = Convert.ToInt32(dr.dgv_settle_dgv.Rows[i].Cells[0].Value);//رقم الصنف
                                    DataRow[] dr_pric_Item = DB_Add_delete_update_.Database.ds.Tables["unite_items"].Select("item_no =" + num_Item);// البحث في التسعيرات للوحدات الفرعية عن الصنف
                                    object[] oj_One_pric = dr_pric_Item[0].ItemArray;
                                    oj_One_pric[6] = Convert.ToInt32(dr.dgv_settle_dgv.Rows[i].Cells[9].Value);// تعديل كرت الصنف
                                    new classs_table.Items_Tools().update_Rows_Table_Database_miulty_key("unite_items", new object[] { oj_One_pric[0], oj_One_pric[1], oj_One_pric[2] }, oj_One_pric);// تعديل في قواعد البيانات
                                //}
                            }
                            else if (dr.com_Type_unit_settle.SelectedIndex == 2)
                            {
                                //DialogResult drs = MessageBox.Show("!!هل تريد تغير سعر البيع للوحدة الصغرا في كرات الصنف", "تغير", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1);
                                //if (drs == DialogResult.Yes)// تغير سعر البيع في كرت الصنف
                                //{
                                    int num_Item = Convert.ToInt32(dr.dgv_settle_dgv.Rows[i].Cells[0].Value);//رقم الصنف
                                    DataRow[] dr_pric_Item = DB_Add_delete_update_.Database.ds.Tables["unite_items"].Select("item_no =" + num_Item);// البحث في التسعيرات للوحدات الفرعية عن الصنف
                                    object[] oj_One_pric = dr_pric_Item[0].ItemArray;
                                    oj_One_pric[7] = Convert.ToInt32(dr.dgv_settle_dgv.Rows[i].Cells[9].Value);// تعديل كرت الصنف
                                    new classs_table.Items_Tools().update_Rows_Table_Database_miulty_key("unite_items", new object[] { oj_One_pric[0], oj_One_pric[1], oj_One_pric[2] }, oj_One_pric);// تعديل في قواعد البيانات
                                //}
                            }
                        }

                        // لم اكملة ************
                        if (Convert.ToInt32(dr.dgv_settle_dgv.Rows[i].Cells[17].Value)==1)
                        {
                            int num_Reaspos_settle_repo =  new classs_table.Items_Tools().AoutoNumber("info_update_settle_report", "num_update_settle");
                            int Item_no = Convert.ToInt32(dr.dgv_settle_dgv.Rows[i].Cells[0].Value);
                            string Item_name_ar = dr.dgv_settle_dgv.Rows[i].Cells[1].Value.ToString() != string.Empty ? dr.dgv_settle_dgv.Rows[i].Cells[1].Value.ToString() : null ;
                            string Item_name_en = dr.dgv_settle_dgv.Rows[i].Cells[2].Value.ToString() != string.Empty ? dr.dgv_settle_dgv.Rows[i].Cells[1].Value.ToString() : null;
                            string Item_Compny_name = dr.dgv_settle_dgv.Rows[i].Cells[11].Value.ToString();
                            DataRow[] dr_unit = DB_Add_delete_update_.Database.ds.Tables["therpeutic_unite"].Select("unit_name ='" + dr.dgv_settle_dgv.Rows[i].Cells[5].Value.ToString() + "'");
                            int num_unit = Convert.ToInt32(dr_unit[0][0]);
                            DateTime dt_begin =Convert.ToDateTime( dr.dgv_settle_dgv.Rows[i].Cells[3].Value);
                            DateTime dt_end = Convert.ToDateTime(dr.dgv_settle_dgv.Rows[i].Cells[3].Value);
                            int Quity_begin =Convert.ToInt32( dr.dgv_settle_dgv.Rows[i].Cells[6].Value);
                            int Quity_end = Convert.ToInt32(dr.dgv_settle_dgv.Rows[i].Cells[7].Value);
                            double pric_begin = Convert.ToDouble(dr.dgv_settle_dgv.Rows[i].Cells[8].Value);
                            double pric_end = Convert.ToDouble(dr.dgv_settle_dgv.Rows[i].Cells[9].Value);
                            float pric_prodect = Convert.ToInt32(dr.dgv_settle_dgv.Rows[i].Cells[10].Value);
                            int num_reapos_settle = Convert.ToInt32(dr.combox_respos_settl.SelectedValue);
                            string Date_settle = dr.lbl_Date_Time_settle.Text;
                            int Storg_num = Convert.ToInt32(dr.com_storg_All.SelectedValue);
                            DataRow dr_Item_ = DB_Add_delete_update_.Database.ds.Tables["Item"].Rows.Find(Item_no);
                            DataRow dr_cmony_ = DB_Add_delete_update_.Database.ds.Tables["manufctur_company"].Rows.Find(dr_Item_[10]);
                            DB_Add_delete_update_.Database.ds.Tables["info_update_settle_report"].Rows.Add(num_Reaspos_settle_repo, Item_no, dr_cmony_[0], num_unit, dt_begin.ToString("d"), dt_end.ToString("d"), Quity_begin, Quity_end, pric_begin, pric_end, pric_prodect, num_reapos_settle,Convert.ToInt32(dr.txt_Empoly_number.Caption), Date_settle, Storg_num);
                            DB_Add_delete_update_.Database.update("info_update_settle_report");
                        }


                        new classs_table.Items_Tools().update_Rows_Table_Database("Item_storg", num_Item_storg.ToString(), dr_Item_update);


                        

                    }
                }
                if (mass)
                {
                    MessageBox.Show("تم التحديث بنجاح", "تحديث", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    dr.btn_serch_settle_btn.PerformClick();
                    mass = false;

                }
                else
                {
                    MessageBox.Show("لم يتم تعديل اي صنف", "تحديث", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                }

                
            }
        }

    }
}
