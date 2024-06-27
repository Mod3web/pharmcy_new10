using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace Manag_ph.Item
{
    class Item
    {

        int num;

        string str_name_ar;
        string str_name_en;
        string str_name_tg;
        string str_not;
        int ch_drog;
        int ch_const;
        int ch_frig;
        int ch_w_d;

        string barcode_inter;//باركوج دولي
        string barcode_local;//باركود مخلي

        int exclusion;//الحد الاقصا
        int order_limit;//حد الطلب
        int allowed;//مسموح بلخصم
        int discount;// نسبة الخصم



        int num_compny;
        int num_nature;
        int num_collection;
        int num_of_supply;
        int num_places_items;


        int num_sciehtific_collection;
        int num_effective_material;
        int num_reason;


        double num_sell_pric;
        double num_Max_DIsc;
        double num_disc_parc;
        double num_tax_pric;
        double num_product_price;

        string path = null;

        int num_unit_coptl;
        int num_unit_sales;//وحدة البيع




        int unit_avrg;
        int number_unit_avrg;
        double number_pric_unit_avrg;



        int unit_smoll;
        int number_unit_smoll;
        double number_pric_unit_smoll;

        public string Path
        {
            get { return path; }
            set { path = value; }
        }

        public void ClearData()
        {
            var vr = Application.OpenForms["Main"] as Main;

            int numItem = new classs_table.Items_Tools().AoutoNumber("Item", "Item_no");
            vr.txt_item_num.Text = numItem.ToString();
            vr.txt_item_name_en.Clear();
            vr.txt_item_nots.Clear();
            vr.txt_Name_ar.Clear();
            vr.txt_item_tr.Clear();
            vr.txt_barcode_enter.Clear();
            vr.ch_item_drog.Checked = true;
            vr.ch_item_const.Checked = false;
            vr.ch_item_frig.Checked = false;
            vr.ch_item_w_d.Checked = false;

            vr.txt_exclusion.Text = "";


            vr.sell_pric.Text = "0";
            vr.Max_DIsc.Text = "0";
            vr.disc_parc.Text = "0";
            vr.tax_pric.Text = "0";
            vr.product_price.Text = "0";
            vr.num_unit_avrg.Text = "1";
            vr.pric_unit_avrg.Text = "0";
            vr.num_unit_smol.Text = "1";
            vr.pric_unit_smol.Text = "0";
            //vr.Aoumn_befor = "";

            //vr.pic_itms.Image = Image.FromFile("unKnown.png");
            path = "unKnown.png";
            vr.txt_Name_ar.Focus();
            vr.txt_Name_ar.SelectAll();
            //vr.pic_itms.Image = Image.FromFile("unKnown.png");


        }


        public void AddDataItem()
        {
            classs_table.Items_Tools m2 = new classs_table.Items_Tools();
            var vr = Application.OpenForms["Main"] as Main;

            //البيانات الاساسية
            num = Convert.ToInt32(vr.txt_item_num.Text);//رقم الصنف
            str_name_ar = vr.txt_Name_ar.Text;//الاسم العربي
            str_name_en = vr.txt_item_name_en.Text;//الاسم الانجليزي
            str_name_tg = vr.txt_item_tr.Text;//الاسم التجاري
            string str_not = vr.txt_item_nots.Text;//
            ch_drog = vr.ch_item_drog.Checked ? 1 : 0;//هل هو دوا
            ch_const = vr.ch_item_const.Checked ? 1 : 0;//قبل للارجاع
            ch_frig = vr.ch_item_frig.Checked ? 1 : 0;//صنف  ثلاجة
            ch_w_d = vr.ch_item_w_d.Checked ? 1 : 0;//ايقاف التعامل معا الصنف



            barcode_inter = vr.txt_barcode_enter.Text.Trim() == string.Empty ? null : vr.txt_barcode_enter.Text;//باكود دولي

            //انشاء باركود محلي
            if (vr.ch_barcode.Checked)
            {
                string str = new Random().Next(100000000, 1000000000).ToString();
                barcode_local = str;
            }
            else
            {
                barcode_local = null;
            }

            exclusion = vr.txt_exclusion.Text.Trim() == string.Empty ? 0 : Convert.ToInt32(vr.txt_exclusion.Text);
            order_limit = Convert.ToInt32(order_limit);
            allowed = vr.ch_alloweds.Checked ? 1 : 0;
            discount = vr.Max_DIsc.Text.Trim() == string.Empty ? 0 : Convert.ToInt32(vr.Max_DIsc.Text);


            //بيانات الاصناف
            num_compny = Convert.ToInt32(vr.com_copny.SelectedValue);//الشركة
            num_nature = Convert.ToInt32(vr.com_nature.SelectedValue);//طبيعة الصنف
            num_collection = Convert.ToInt32(vr.com_collection.SelectedValue); //المجموعة
            num_of_supply = Convert.ToInt32(vr.com_of_supply.SelectedValue);//منشا الصنف
            num_places_items = Convert.ToInt32(vr.com_places_items.SelectedValue);//مكان تخزين الصنف

            //البيانات الطبية

            num_sciehtific_collection = Convert.ToInt32(vr.com_sciehtific_collection.SelectedValue);//المجموعة العليمة
            num_effective_material = Convert.ToInt32(vr.com_effective_material.SelectedValue);//المادة الفعالة
            num_reason = Convert.ToInt32(vr.com_reason.SelectedValue);//سبب الاستخدام

            //التسعيرة
            num_sell_pric = vr.sell_pric.Text.Trim() != string.Empty ? Convert.ToDouble(vr.sell_pric.Text) : 0;//سعر الشر
            num_Max_DIsc = vr.Max_DIsc.Text.Trim() != string.Empty ? Convert.ToDouble(vr.Max_DIsc.Text) : 0;//اعلا خصم 
            num_disc_parc = vr.disc_parc.Text.Trim() != string.Empty ? Convert.ToDouble(vr.disc_parc.Text) : 0;// نسبة الخصم
            num_tax_pric = vr.tax_pric.Text.Trim() != string.Empty ? Convert.ToDouble(vr.tax_pric.Text) : 0; //الضريبة
            num_product_price = vr.product_price.Text.Trim() != string.Empty ? Convert.ToDouble(vr.product_price.Text) : 0; //سعر البيع


            //الوحدات
            num_unit_coptl = Convert.ToInt32(vr.com_unit_Comtl.SelectedValue);//الوحدة الكبر


            unit_avrg = Convert.ToInt32(vr.com_unit_avrg.SelectedValue);// الوحدة المتوسطة
            number_unit_avrg = vr.num_unit_avrg.Text.Trim() != string.Empty ? Convert.ToInt32(vr.num_unit_avrg.Text) : 1;//عدد الوحدات المتوسطة
            number_pric_unit_avrg = vr.pric_unit_avrg.Text.Trim() != string.Empty ? Convert.ToDouble(vr.pric_unit_avrg.Text) : 1;//سعر الوحدة المتوسطة


            unit_smoll = Convert.ToInt32(vr.com_unit_smol.SelectedValue); // الوحدة الصغرا
            number_unit_smoll = vr.num_unit_smol.Text.Trim() != string.Empty ? Convert.ToInt32(vr.num_unit_smol.Text) : 0;//عدد الوحدات الصغرا
            number_pric_unit_smoll = vr.pric_unit_smol.Text.Trim() != string.Empty ? Convert.ToDouble(vr.pric_unit_smol.Text) : 0; //سعر الوحدة الصغرا


            num_unit_sales = Convert.ToInt32(vr.com_unit_sals.SelectedValue); // وحودة البيع





            bool b_name = false;
            bool b_pric = false;
            bool b_unit = false;






            if (vr.txt_item_name_en.Text.Trim() == string.Empty)
            {
                MessageBox.Show("يرجاء ادخال الاسم الانجليزي ", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                vr.txt_item_name_en.Focus();
                return;
            }
            else
            {
                b_name = true;
            }

            if ((vr.sell_pric.Text.Trim() == string.Empty || m2.CheackTextNumbers(vr.sell_pric)) || vr.Max_DIsc.Text.Trim() == string.Empty || vr.disc_parc.Text.Trim() == string.Empty ||
                 vr.tax_pric.Text.Trim() == string.Empty || vr.product_price.Text.Trim() == string.Empty)
            {
                MessageBox.Show("يرجاء ادخال بيانات التسعيرة ", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else
            {
                b_pric = true;
            }

            if (vr.num_unit_avrg.Text.Trim() == string.Empty || vr.pric_unit_avrg.Text.Trim() == string.Empty || vr.num_unit_smol.Text.Trim() == string.Empty ||
                vr.pric_unit_smol.Text.Trim() == string.Empty)
            {
                MessageBox.Show("يرجاء ادخال بيانات الوحدات ", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else
            {
                b_unit = true;
            }


            if (b_name && b_pric && b_unit)
            {
                //اضاف بيانات الاصناف
                if (!vr.ch_item_drog.Checked)
                {
                    DB_Add_delete_update_.Database.ds.Tables["Item"].Rows.Add(num, str_name_en, str_name_ar, str_name_tg, File.ReadAllBytes(path), ch_frig, ch_drog, ch_const, ch_w_d, str_not, num_compny, num_collection, null, num_places_items, num_of_supply, null, num_nature, null);
                }
                else
                {
                    DB_Add_delete_update_.Database.ds.Tables["Item"].Rows.Add(num, str_name_en, str_name_ar, str_name_tg, File.ReadAllBytes(path), ch_frig, ch_drog, ch_const, ch_w_d, str_not, num_compny, num_collection, num_sciehtific_collection, num_places_items, num_of_supply, num_effective_material, num_nature, num_reason);

                }

                //جلب الرقم التلقائي
                //int num_price = Convert.ToInt32(DB_Add_delete_update_.Database.ds.Tables["pric"].Compute("max(pric_num)", "")) + 1;
                int num_price = new classs_table.Items_Tools().AoutoNumber("pric", "pric_num"); 

                //ضفة بيانات التسعيرات
                DB_Add_delete_update_.Database.ds.Tables["pric"].Rows.Add(num_price, num_sell_pric, num_disc_parc, num_tax_pric, num_product_price, num);

                //اضافة بيانات الوحدات
                DB_Add_delete_update_.Database.ds.Tables["unite_items"].Rows.Add(num, num_unit_coptl, unit_avrg, unit_smoll, number_unit_avrg, number_unit_smoll, number_pric_unit_avrg, number_pric_unit_smoll, num_unit_sales);
                int num_barcode = new classs_table.Items_Tools().AoutoNumber("barcode", "barcode_num");// اجاد الرقم التلقائي للباركود
                DB_Add_delete_update_.Database.ds.Tables["barcode"].Rows.Add(num_barcode, barcode_inter, barcode_local, num);// اضافة الباركود


                
                int dealings_num = new classs_table.Items_Tools().AoutoNumber("dealings", "deali_num");// اجاد الرقم التلقائي قيود التعامل
                DB_Add_delete_update_.Database.ds.Tables["dealings"].Rows.Add(dealings_num, exclusion, order_limit, allowed, discount,num);// اضافة القيود
                MessageBox.Show("تم الاضافة بنجاح", "اضافة", MessageBoxButtons.OK, MessageBoxIcon.Information);

                vr.txt_barcode_enter.Focus();

                DB_Add_delete_update_.Database.update("Item");
                DB_Add_delete_update_.Database.update("pric");
                DB_Add_delete_update_.Database.update("unite_items");
                DB_Add_delete_update_.Database.update("barcode");
                DB_Add_delete_update_.Database.update("dealings");



                ///test
                ///
                if (!vr.ch_item_drog.Checked)
                {
                    DB_Add_delete_update_.Database.dt_View_Item.Rows.Add(num, str_name_ar, str_name_en, ch_frig, ch_drog, ch_const, ch_w_d, vr.com_copny.Text, vr.com_nature.Text, null, num_sell_pric, vr.com_places_items.Text, null); ;
                }
                else
                {
                    DB_Add_delete_update_.Database.dt_View_Item.Rows.Add(num, str_name_ar, str_name_en, ch_frig, ch_drog, ch_const, ch_w_d, vr.com_copny.Text, vr.com_nature.Text, vr.com_effective_material.Text, num_sell_pric, vr.com_places_items.Text, vr.com_sciehtific_collection.Text); ;

                }
                ClearData();
            }

        }


        public void Add_picr()
        {
            var vr = Application.OpenForms["Main"] as Main;
            path = vr.pic_itms.ImageLocation;
            OpenFileDialog ofd = new OpenFileDialog();

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                path = ofd.FileName;
                vr.pic_itms.Image = Image.FromFile(ofd.FileName);
                if (path == null || string.IsNullOrEmpty(path))
                {
                    path = vr.pic_itms.ImageLocation;
                }
            }
        }




    }
}
