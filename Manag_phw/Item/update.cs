using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Manag_ph.Item
{
    class update
    {

        public void updates()
        {
            classs_table.Items_Tools m2 = new classs_table.Items_Tools();

            var up = Application.OpenForms["Main"] as Main;

            m2.Fill_Combox(up.com_copny_update, "manufctur_company");
            m2.Fill_Combox(up.com_nature_update, "nature_of_Item");
            m2.Fill_Combox(up.com_collection_update, "collection_of_Item");
            m2.Fill_Combox(up.com_of_supply_update, "type_of_supply");
            m2.Fill_Combox(up.com_places_items_update, "places_of_items");
            m2.Fill_Combox(up.com_sciehtific_collection_update, "sciehtific_collection");
            m2.Fill_Combox(up.com_effective_material_update, "effective_material");
            m2.Fill_Combox(up.com_reason_update, "reason_for_user");
            m2.Fill_Combox(up.com_unit_smol_update, "therpeutic_unite");
            up.com_unit_avrg_update.DataSource = DB_Add_delete_update_.Database.unit;
            up. com_unit_avrg_update.ValueMember = DB_Add_delete_update_.Database.unit.Columns[1].ColumnName;
            up. com_unit_avrg_update.ValueMember = DB_Add_delete_update_.Database.unit.Columns[0].ColumnName;
            up.com_unit_Comtl_update.DataSource = DB_Add_delete_update_.Database.unit2;
            up.com_unit_Comtl_update.ValueMember = DB_Add_delete_update_.Database.unit2.Columns[1].ColumnName;
            up.com_unit_Comtl_update.ValueMember = DB_Add_delete_update_.Database.unit2.Columns[0].ColumnName;

            //DB_Add_delete_update_.Database.ds.Tables["Item"].Rows.Add(num, str_name_en, str_name_ar, str_name_tg, File.ReadAllBytes(path), ch_frig, ch_drog, ch_const, ch_w_d, str_not, num_compny, num_collection, num_sciehtific_collection, num_places_items, num_of_supply, num_effective_material, num_nature, num_reason);
            if (up.dgvm_dgv.CurrentRow != null)
            {
                int id = Convert.ToInt32(up.dgvm_dgv.CurrentRow.Cells[0].Value);
                object[] dr;
                dr = DB_Add_delete_update_.Database.ds.Tables["Item"].Rows.Find(id).ItemArray;

                up.txt_item_num_update.Text = dr[0].ToString();
                up.txt_item_name_en_update.Text = dr[1].ToString();
                up.txt_Name_ar_update.Text = dr[2].ToString();
                up.lbl_update.Text = "تعديل الصنف :" + dr[2].ToString();
                up.txt_item_tr_update.Text = dr[3].ToString();



                File.WriteAllBytes(id + ".jpg", (byte[])dr[4]);
                //File.Open(id + ".jpg",FileMode.Open);
                FileStream im = File.Open(id + ".jpg", FileMode.Open);
                Bitmap btn = new Bitmap(im);
                //pic_itms_update.Image = Image.FromFile(id + ".jpg");
                up.pic_itms_update.Image = btn;
                im.Close();
                up.ch_item_frig_update.Checked = Convert.ToInt32(dr[5]) == 1 ? true : false;
                up.ch_item_drog_update.Checked = Convert.ToInt32(dr[6]) == 1 ? true : false;
                up.grop_Info_Dow_gbx.Enabled = Convert.ToInt32(dr[6]) == 1 ? true : false;
                up.ch_item_const_update.Checked = Convert.ToInt32(dr[7]) == 1 ? true : false;
                up.ch_item_w_d_update.Checked = Convert.ToInt32(dr[8]) == 1 ? true : false;
                up.txt_item_nots_update.Text = dr[9].ToString();
                up.com_copny_update.SelectedValue = dr[10].ToString();
                up.com_nature_update.SelectedValue = dr[16].ToString();
                up.com_collection_update.SelectedValue = dr[11].ToString();
                up.com_of_supply_update.SelectedValue = dr[14].ToString();
               up. com_places_items_update.SelectedValue = dr[13].ToString();
                if (Convert.ToInt32(dr[6]) == 1)
                {
                    up.com_sciehtific_collection_update.SelectedValue = dr[12].ToString();
                    up.com_effective_material_update.SelectedValue = dr[15].ToString();
                    up.com_reason_update.SelectedValue = dr[17].ToString();
                }
                else
                {
                    up.com_sciehtific_collection_update.SelectedValue = 1;
                    up.com_effective_material_update.SelectedValue = 1;
                    up.com_reason_update.SelectedValue = 1;
                }

                DataRow[] barcode = DB_Add_delete_update_.Database.ds.Tables["barcode"].Select("Item_no =" + id);

                up.txt_barcode_dwaly.Text = barcode[0][1].ToString();
                DataRow[] dr_pric = DB_Add_delete_update_.Database.ds.Tables["pric"].Select("Item_no =" + id);

                up.sell_pric_update.Text = dr_pric[0][1].ToString();
                up.disc_parc_update.Text = dr_pric[0][2].ToString();
                up.tax_pric_update.Text = dr_pric[0][3].ToString();
                up.product_price_update.Text = dr_pric[0][4].ToString();


                DataRow[] dr_multi_unit = DB_Add_delete_update_.Database.ds.Tables["unite_items"].Select("item_no =" + id);

                //MessageBox.Show(dr_multi_unit[0][4]+"");

                up.com_unit_Comtl_update.SelectedValue = (int)dr_multi_unit[0][1];
                up.com_unit_avrg_update.SelectedValue = (int)dr_multi_unit[0][2];
                up.com_unit_smol_update.SelectedValue = (int)dr_multi_unit[0][3];
                up.num_unit_avrg_update.Text = dr_multi_unit[0][4].ToString();
                up.num_unit_smol_update.Text = dr_multi_unit[0][5].ToString();
                up.pric_unit_avrg_update.Text = dr_multi_unit[0][6].ToString();
                up.pric_unit_smol_update.Text = dr_multi_unit[0][7].ToString();


                DataRow[] dealings = DB_Add_delete_update_.Database.ds.Tables["dealings"].Select("Item_num= " + id);
                up.txt_exclusion_update.Text = dealings[0][1].ToString();
                up.txt_order_limit_update.Text = dealings[0][2].ToString();
                up.ch_alloweds_update.Checked =Convert.ToBoolean( dealings[0][2]);
                up.Max_DIsc_update.Text = dealings[0][2].ToString();




            }

        }
        //حدث تحديث الاصناف
        public void update_All()
        {

            var up = Application.OpenForms["Main"] as Main;
            int a = (int)up.dgvm_dgv.CurrentRow.Cells[0].Value;

            if ((up.sell_pric_update.Text.Trim() == string.Empty || new classs_table.Items_Tools().CheackTextNumbers(up.sell_pric_update)) || up.Max_DIsc_update.Text.Trim() == string.Empty || up.disc_parc_update.Text.Trim() == string.Empty ||
      up.tax_pric_update.Text.Trim() == string.Empty || up.product_price_update.Text.Trim() == string.Empty)
            {
                MessageBox.Show("يرجاء ادخال بيانات التسعيرة ", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (up.txt_item_name_en_update.Text.Trim() == string.Empty)
            {
                MessageBox.Show("يرجاء ادخال الاسم الانجليزي ", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                up.txt_item_name_en_update.Focus();
                return;
            }

            object[] dr_Item = DB_Add_delete_update_.Database.ds.Tables["Item"].Rows.Find(a).ItemArray;

            up.pic_itms_update.Image.Save(a + "aaaa.png");


            dr_Item[1] = up.txt_item_name_en_update.Text;
            dr_Item[2] = up.txt_Name_ar_update.Text;
            dr_Item[3] = up.txt_item_tr_update.Text;
            dr_Item[4] = (byte[])File.ReadAllBytes(a + "aaaa.png");
            dr_Item[5] = up.ch_item_frig_update.Checked ? 1 : 0;
            dr_Item[6] = up.ch_item_drog_update.Checked ? 1 : 0;
            dr_Item[7] = up.ch_item_const_update.Checked ? 1 : 0;
            dr_Item[8] = up.ch_item_w_d_update.Checked ? 1 : 0;
            dr_Item[9] = up.txt_item_nots_update.Text;
            dr_Item[10] = up.com_copny_update.SelectedValue;
            dr_Item[11] = up.com_collection_update.SelectedValue;
            dr_Item[12] = up.com_sciehtific_collection_update.SelectedValue;
            dr_Item[13] = up.com_places_items_update.SelectedValue;
            dr_Item[14] = up.com_of_supply_update.SelectedValue;
            dr_Item[15] = up.com_effective_material_update.SelectedValue;
            dr_Item[16] = up.com_nature_update.SelectedValue;
            dr_Item[17] = up.com_reason_update.SelectedValue;
            new classs_table.Items_Tools().update_Rows_Table_Database("Item", dr_Item[0].ToString(), dr_Item);




            //////////////////////////////////////////////////////////////////////////////

            // حق الاصناف
            int a2 = (int)up.dgvm_dgv.CurrentRow.Cells[0].Value;
            DataRow[] dr_Item2 = DB_Add_delete_update_.Database.ds.Tables["pric"].Select("Item_no = " + a2);
            object[] dr_Ite2 = DB_Add_delete_update_.Database.ds.Tables["pric"].Rows.Find(Convert.ToInt32(dr_Item2[0][0])).ItemArray;
            dr_Ite2[1] = up.sell_pric_update.Text;
            dr_Ite2[2] = up.disc_parc_update.Text;
            dr_Ite2[3] = up.tax_pric_update.Text;
            dr_Ite2[4] = up.product_price_update.Text;
            new classs_table.Items_Tools().update_Rows_Table_Database("pric", dr_Ite2[0].ToString(), dr_Ite2);


            //تعديل الباركود
            DataRow[] barcode = DB_Add_delete_update_.Database.ds.Tables["barcode"].Select("Item_no =" + a2);
            object[] barcodeob = DB_Add_delete_update_.Database.ds.Tables["barcode"].Rows.Find(Convert.ToInt32(barcode[0][0])).ItemArray;
            barcodeob[1] = up.txt_barcode_dwaly.Text.Trim() == string.Empty ?"0000000": up.txt_barcode_dwaly.Text.Trim();
            new classs_table.Items_Tools().update_Rows_Table_Database("barcode", barcodeob[0].ToString(), barcodeob);


            // تعديل الوحدات
            DataRow[] dr_multi_unit = DB_Add_delete_update_.Database.ds.Tables["unite_items"].Select("item_no =" + a2);
            object[] ob_unit = dr_multi_unit[0].ItemArray;
            object[] ob_unitPri = dr_multi_unit[0].ItemArray;

            ob_unit[1] = up.com_unit_Comtl_update.SelectedValue;
            ob_unit[2] = up.com_unit_avrg_update.SelectedValue;
            ob_unit[3] = up.com_unit_smol_update.SelectedValue;
            ob_unit[4] = up.num_unit_avrg_update.Text.Trim()==string.Empty ? "1": up.num_unit_avrg_update.Text.Trim();
            ob_unit[5] = up.num_unit_smol_update.Text.Trim() == string.Empty ? "1" : up.num_unit_smol_update.Text.Trim();
            ob_unit[6] = up.pric_unit_avrg_update.Text.Trim() == string.Empty ? "0" : up.pric_unit_avrg_update.Text.Trim(); 
            ob_unit[7] = up.pric_unit_smol_update.Text.Trim() == string.Empty ? "0" : up.pric_unit_smol_update.Text.Trim(); 
            new classs_table.Items_Tools().update_Rows_Table_Database_miulty_key("unite_items",new object[] { ob_unitPri[0], ob_unitPri[1], ob_unitPri[2] }, ob_unit);



            DataRow[] dealings = DB_Add_delete_update_.Database.ds.Tables["dealings"].Select("Item_num =" + a2);
            object[] dealings_up = dealings[0].ItemArray;
            dealings_up[1] = up.txt_exclusion_update.Text;
            dealings_up[2] = up.txt_order_limit_update.Text;
            dealings_up[3] = up.ch_alloweds_update.Checked;
            dealings_up[2] = up.Max_DIsc_update.Text;
            new classs_table.Items_Tools().update_Rows_Table_Database("dealings", dealings_up[0].ToString(), dealings_up);



            DB_Add_delete_update_.Database.dt_View_Item.Clear();
            DB_Add_delete_update_.Database.view_Item();


        }




        public void Cobr_All_update()
        {

            var up = Application.OpenForms["Main"] as Main;
            if ((up.com_unit_smol_update.Text == up.com_unit_avrg_update.Text && up.com_unit_smol_update.Text == up.com_unit_Comtl_update.Text) || up.com_unit_smol_update.Text == up.com_unit_avrg_update.Text)
            {
                up.num_unit_smol_update.Enabled = false;
                up.num_unit_smol_update.Text = "1";
                up.pric_unit_smol_update.Text = up.sell_pric.Text;
            }
            else
            {
                up.num_unit_smol_update.Enabled = true;

            }
            if (up.com_unit_Comtl_update.Text == up.com_unit_avrg_update.Text)
            {
                up.num_unit_avrg_update.Enabled = false;
                up.num_unit_avrg_update.Text = "1";
                up.pric_unit_avrg_update.Text = up.sell_pric.Text;

            }
            else
            {
                up.num_unit_avrg_update.Enabled = true;
            }

            if (up.com_unit_Comtl_update.Text == up.com_unit_avrg_update.Text)
            {
                up.num_unit_avrg_update.Enabled = false;
                up.num_unit_avrg_update.Text = "1";
                up.pric_unit_avrg_update.Text = up.sell_pric.Text;
            }
            else
            {
                up.num_unit_avrg_update.Enabled = true;

            }
        }

        // حدث اختيار الوحدة الوسطا

        public void Avrg_All_update()
        {
            var up = Application.OpenForms["Main"] as Main;
            if (up.com_unit_Comtl_update.Text == up.com_unit_avrg_update.Text)
            {
                up.num_unit_avrg_update.Enabled = false;
                up.num_unit_avrg_update.Text = "1";
                up.pric_unit_avrg_update.Text = up.sell_pric.Text;
            }
            else
            {
                up.num_unit_avrg_update.Enabled = true;
            }

            if (up.com_unit_Comtl_update.Text == up.com_unit_avrg_update.Text)
            {
                up.num_unit_avrg_update.Enabled = false;
                up.num_unit_avrg_update.Text = "1";
                up.pric_unit_avrg_update.Text = up.sell_pric.Text;
            }
            else
            {
                up.num_unit_avrg_update.Enabled = true;

            }

            if ((up.com_unit_smol_update.Text == up.com_unit_avrg_update.Text && up.com_unit_smol_update.Text == up.com_unit_Comtl_update.Text) || up.com_unit_smol_update.Text == up.com_unit_avrg_update.Text)
            {
                up.num_unit_smol_update.Enabled = false;
                up.num_unit_smol_update.Text = "1";
                up.pric_unit_smol_update.Text = up.sell_pric.Text;
            }
            else
            {
                up.num_unit_smol_update.Enabled = true;

            }
        }

        // حدث اختيار الوحدة الصغرا

        public void smoll_All_update()
        {

            var up = Application.OpenForms["Main"] as Main;


            if ((up.com_unit_smol_update.Text == up.com_unit_avrg_update.Text && up.com_unit_smol_update.Text == up.com_unit_Comtl_update.Text) || up.com_unit_smol_update.Text == up.com_unit_avrg_update.Text)
            {
                up.num_unit_smol_update.Enabled = false;
                up.num_unit_smol_update.Text = "1";
                up.pric_unit_smol_update.Text = up.sell_pric.Text;
            }
            else
            {
                up.num_unit_smol_update.Enabled = true;

            }
            if (up.com_unit_Comtl_update.Text == up.com_unit_avrg_update.Text)
            {
                up.num_unit_avrg_update.Enabled = false;
                up.num_unit_avrg_update.Text = "1";
                up.pric_unit_avrg_update.Text = up.sell_pric.Text;
            }
            else
            {
                up.num_unit_avrg_update.Enabled = true;
            }

            if (up.com_unit_Comtl_update.Text == up.com_unit_avrg_update.Text)
            {
                up.num_unit_avrg_update.Enabled = false;
                up.num_unit_avrg_update.Text = "1";
                up.pric_unit_avrg_update.Text = up.sell_pric.Text;
            }
            else
            {
                up.num_unit_avrg_update.Enabled = true;

            }
        }









        // حدث اختيار الوحدة الكبرا
        public void Cobr_All()
        {

            var up = Application.OpenForms["Main"] as Main;
            if ((up.com_unit_smol.Text == up.com_unit_avrg.Text && up.com_unit_smol.Text == up.com_unit_Comtl.Text) || up.com_unit_smol.Text == up.com_unit_avrg.Text)
            {
                up.num_unit_smol.Enabled = false;
                up.num_unit_smol.Text = "1";
                up.pric_unit_smol.Text = up.sell_pric.Text;
            }
            else
            {
                up.num_unit_smol.Enabled = true;

            }
            if (up.com_unit_Comtl.Text == up.com_unit_avrg.Text)
            {
                up.num_unit_avrg.Enabled = false;
                up.num_unit_avrg.Text = "1";
                up.pric_unit_avrg.Text = up.sell_pric.Text;

            }
            else
            {
                up.num_unit_avrg.Enabled = true;
            }

            if (up.com_unit_Comtl.Text == up.com_unit_avrg.Text)
            {
                up.num_unit_avrg.Enabled = false;
                up.num_unit_avrg.Text = "1";
                up.pric_unit_avrg.Text = up.sell_pric.Text;
            }
            else
            {
                up.num_unit_avrg.Enabled = true;

            }
        }

        // حدث اختيار الوحدة الوسطا

        public void Avrg_All()
        {
            var up = Application.OpenForms["Main"] as Main;
            if (up.com_unit_Comtl.Text == up.com_unit_avrg.Text)
            {
                up.num_unit_avrg.Enabled = false;
                up.num_unit_avrg.Text = "1";
                up.pric_unit_avrg.Text = up.sell_pric.Text;
            }
            else
            {
                up.num_unit_avrg.Enabled = true;
            }

            if (up.com_unit_Comtl.Text == up.com_unit_avrg.Text)
            {
                up.num_unit_avrg.Enabled = false;
                up.num_unit_avrg.Text = "1";
                up.pric_unit_avrg.Text = up.sell_pric.Text;
            }
            else
            {
                up.num_unit_avrg.Enabled = true;

            }

            if ((up.com_unit_smol.Text == up.com_unit_avrg.Text && up.com_unit_smol.Text == up.com_unit_Comtl.Text) || up.com_unit_smol.Text == up.com_unit_avrg.Text)
            {
                up.num_unit_smol.Enabled = false;
                up.num_unit_smol.Text = "1";
                up.pric_unit_smol.Text = up.sell_pric.Text;
            }
            else
            {
                up.num_unit_smol.Enabled = true;

            }
        }

        // حدث اختيار الوحدة الصغرا

        public void smoll_All()
        {

            var up = Application.OpenForms["Main"] as Main;


            if ((up.com_unit_smol.Text == up.com_unit_avrg.Text && up.com_unit_smol.Text == up.com_unit_Comtl.Text) || up.com_unit_smol.Text == up.com_unit_avrg.Text)
            {
                up.num_unit_smol.Enabled = false;
                up.num_unit_smol.Text = "1";
                up.pric_unit_smol.Text = up.sell_pric.Text;
            }
            else
            {
                up.num_unit_smol.Enabled = true;

            }
            if (up.com_unit_Comtl.Text == up.com_unit_avrg.Text)
            {
                up.num_unit_avrg.Enabled = false;
                up.num_unit_avrg.Text = "1";
                up.pric_unit_avrg.Text = up.sell_pric.Text;
            }
            else
            {
                up.num_unit_avrg.Enabled = true;
            }

            if (up.com_unit_Comtl.Text == up.com_unit_avrg.Text)
            {
                up.num_unit_avrg.Enabled = false;
                up.num_unit_avrg.Text = "1";
                up.pric_unit_avrg.Text = up.sell_pric.Text;
            }
            else
            {
                up.num_unit_avrg.Enabled = true;

            }
        }

    }
}
