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
    class Serch
    {


        public void serch_view_Item()
        {

            var sr =  Application.OpenForms["Main"] as Main;

            //string str = sr.txt_Serch_Item.Text;
            string str = classs_table.Items_Tools.get_str_barcode(sr.txt_Serch_Item);
            // الكل الكل
            string All = "[الاسم العربي] + [الاسم الانجليزي] + [الشركة المصنعة] + [طبيعة الصنف] + [مكان الصنف] + [المجموعة العلمية]+[المادة الفعالة] +[كود الصنف] like '%" + str + "%'";
            //الكل وموقف
            string All_stop = "[الاسم العربي] + [الاسم الانجليزي] + [الشركة المصنعة] + [طبيعة الصنف] + [مكان الصنف] + [المجموعة العلمية]+[المادة الفعالة] +[كود الصنف] like '%" + str + "%' And [ايقاف الصنف] = " + 1;
            //الكل ومش موقف
            string All_Nostop = "[الاسم العربي] + [الاسم الانجليزي] + [الشركة المصنعة] + [طبيعة الصنف] + [مكان الصنف] + [المجموعة العلمية]+[المادة الفعالة] +[كود الصنف] like '%" + str + "%' And [ايقاف الصنف] = " + 0;
            //الكل ودواء
            string All_Dow = "[الاسم العربي] + [الاسم الانجليزي] + [الشركة المصنعة] + [طبيعة الصنف] + [مكان الصنف] + [المجموعة العلمية]+[المادة الفعالة] +[كود الصنف] like '%" + str + "%' And [صنف دواء] = " + 1;
            //الكل ومش دواء
            string All_NoDow = "[الاسم العربي] + [الاسم الانجليزي] + [الشركة المصنعة] + [طبيعة الصنف] + [مكان الصنف] + [المجموعة العلمية]+[المادة الفعالة] +[كود الصنف] like '%" + str + "%' And [صنف دواء] = " + 0;

            //دوا وموقف
            string stop_Dow = "[الاسم العربي] + [الاسم الانجليزي] + [الشركة المصنعة] + [طبيعة الصنف] + [مكان الصنف] + [المجموعة العلمية]+[المادة الفعالة] +[كود الصنف] like '%" + str + "%' And [ايقاف الصنف] = " + 1 + " And[صنف دواء] = " + 1;
            //دواء ومش موقف
            string Dow_Nostop = "[الاسم العربي] + [الاسم الانجليزي] + [الشركة المصنعة] + [طبيعة الصنف] + [مكان الصنف] + [المجموعة العلمية]+[المادة الفعالة] +[كود الصنف] like '%" + str + "%' And [ايقاف الصنف] = " + 0 + " And[صنف دواء] = " + 1;
            //مش دواء وموقف
            string NoDow_stop = "[الاسم العربي] + [الاسم الانجليزي] + [الشركة المصنعة] + [طبيعة الصنف] + [مكان الصنف] + [المجموعة العلمية]+[المادة الفعالة] +[كود الصنف] like '%" + str + "%' And [ايقاف الصنف] = " + 1 + " And[صنف دواء] = " + 0;
            //مش دواء ومش موقف
            string Nodow_Nostop = "[الاسم العربي] + [الاسم الانجليزي] + [الشركة المصنعة] + [طبيعة الصنف] + [مكان الصنف] + [المجموعة العلمية]+[المادة الفعالة] +[كود الصنف] like '%" + str + "%' And [ايقاف الصنف] = " + 0 + " And[صنف دواء] = " + 0;



            if (sr.ch_All.Checked && sr.ch_Sp_All.Checked)
            {
                DB_Add_delete_update_.Database.dv.RowFilter = All;
                sr.lbl_count.Text = DB_Add_delete_update_.Database.dv.Count.ToString();
            }
            else if (sr.ch_All.Checked && sr.ch_Stop.Checked)
            {
                DB_Add_delete_update_.Database.dv.RowFilter = All_stop;
                sr.lbl_count.Text = DB_Add_delete_update_.Database.dv.Count.ToString();
            }
            else if (sr.ch_All.Checked && sr.ch_NoStop.Checked)
            {
                DB_Add_delete_update_.Database.dv.RowFilter = All_Nostop;
                sr.lbl_count.Text = DB_Add_delete_update_.Database.dv.Count.ToString();
            }
            else if (sr.ch_Sp_All.Checked && sr.ch_Dow.Checked)
            {
                DB_Add_delete_update_.Database.dv.RowFilter = All_Dow;
                sr.lbl_count.Text = DB_Add_delete_update_.Database.dv.Count.ToString();
            }
            else if (sr.ch_Sp_All.Checked && sr.ch_NoDow.Checked)
            {
                DB_Add_delete_update_.Database.dv.RowFilter = All_NoDow;
                sr.lbl_count.Text = DB_Add_delete_update_.Database.dv.Count.ToString();
            }
            else if (sr.ch_Dow.Checked && sr.ch_Stop.Checked)
            {
                DB_Add_delete_update_.Database.dv.RowFilter = stop_Dow;
                sr.lbl_count.Text = DB_Add_delete_update_.Database.dv.Count.ToString();

            }
            else if (sr.ch_Dow.Checked && sr.ch_NoStop.Checked)
            {
                DB_Add_delete_update_.Database.dv.RowFilter = Dow_Nostop;
                sr.lbl_count.Text = DB_Add_delete_update_.Database.dv.Count.ToString();

            }
            else if (sr.ch_NoDow.Checked && sr.ch_Stop.Checked)
            {
                DB_Add_delete_update_.Database.dv.RowFilter = NoDow_stop;
                sr.lbl_count.Text = DB_Add_delete_update_.Database.dv.Count.ToString();

            }
            else if (sr.ch_NoDow.Checked && sr.ch_NoStop.Checked)
            {
                DB_Add_delete_update_.Database.dv.RowFilter = Nodow_Nostop;
                sr.lbl_count.Text = DB_Add_delete_update_.Database.dv.Count.ToString();

            }
        }
        // جلب بيانات
        public void get_Unit()
        {
            var vr = Application.OpenForms["Main"] as Main; 
            Test t = new Test();
            if (vr.dgvm_dgv.CurrentRow != null)
            {
                int id = Convert.ToInt32(vr.dgvm_dgv.CurrentRow.Cells[0].Value);
                object[] dr;
                dr = DB_Add_delete_update_.Database.ds.Tables["Item"].Rows.Find(id).ItemArray;


                //لجب بيانات الشركات الخ..
                object[] type_of_supply;
                int[] Arr_combpx = { 14, 17, 16, 11 };
                string[] name_table = { "type_of_supply", "reason_for_user", "nature_of_Item", "collection_of_Item" };
                Label[] lbl = { t.lbl_supply, t.lbl_reason, t.lbl_coll_Item, t.lbl_colltion };

                for (int i = 0; i < Arr_combpx.Length; i++)
                {


                    if (!string.IsNullOrEmpty(dr[Arr_combpx[i]].ToString()))
                    {


                        type_of_supply = DB_Add_delete_update_.Database.ds.Tables[name_table[i]].Rows.Find(dr[Arr_combpx[i]]).ItemArray;

                        lbl[i].Text = type_of_supply[1].ToString();
                    }
                    else
                    {

                        lbl[i].Text = "لايوجد";
                    }
                }
                //لجلب بيانات التسعيرات
                DataView dv = new DataView(DB_Add_delete_update_.Database.ds.Tables["pric"]);
                dv.RowFilter = "Item_no =" + id;

                t.lbl_sell_pric.Text = dv[0].Row[4].ToString();
                t.lbl_disc_parc.Text = dv[0].Row[2].ToString();
                t.lbl_tax_price.Text = dv[0].Row[3].ToString();

                MessageBox.Show(dv[0].Row[0].ToString());


                DataView unit = new DataView(DB_Add_delete_update_.Database.ds.Tables["unite_items"]);
                unit.RowFilter = "Item_no = " + id;
                object[] Arry_unit = unit[0].Row.ItemArray;
                // جلب الوحدات الكبيرة والوسط والصغيرة
                // t.lbl_unit_cabtl.Text = DB_Add_delete_update_.Database.ds.Tables["therpeutic_unite"].Rows[(int)Arry_unit[1]][1].ToString();
                DataRow dr_cobtl = DB_Add_delete_update_.Database.ds.Tables["therpeutic_unite"].Rows.Find(Arry_unit[1]);
                t.lbl_unit_cabtl.Text = dr_cobtl[1].ToString();
                // t.lbl_unit_avrg.Text = DB_Add_delete_update_.Database.ds.Tables["therpeutic_unite"].Rows[(int)Arry_unit[2]][1].ToString();
                DataRow dr_avrg = DB_Add_delete_update_.Database.ds.Tables["therpeutic_unite"].Rows.Find(Arry_unit[2]);
                t.lbl_unit_avrg.Text = dr_avrg[1].ToString();
                //t.lbl_unit_smll.Text = DB_Add_delete_update_.Database.ds.Tables["therpeutic_unite"].Rows[(int)Arry_unit[3]][1].ToString();
                DataRow dr_smool = DB_Add_delete_update_.Database.ds.Tables["therpeutic_unite"].Rows.Find(Arry_unit[3]);
                t.lbl_unit_smll.Text = dr_smool[1].ToString();
                // جلب عدد الوحدات الوسطا والصغيرة
                t.lbl_num_avrg.Text = Arry_unit[4].ToString();
                t.lbl_num_smoll.Text = Arry_unit[5].ToString();
                t.lbl_pris_avrg.Text = Arry_unit[6].ToString();
                t.lbl_pris_smoll.Text = Arry_unit[7].ToString();





                t.lbl_name_tg.Text = dr[3].ToString();
                t.lbl_not.Text = dr[9].ToString();
                if (!File.Exists(id + "My,jpg"))
                {
                    File.WriteAllBytes(id + "My.jpg", (byte[])dr[4]);
                    FileStream fs = File.Open(id + "My.jpg", FileMode.Open);


                    Bitmap bt = new Bitmap(fs);
                    fs.Close();
                    t.pictureBox1.Image = bt;
                    t.ShowDialog();

                }


            }
        }

        public void Down_Dro()
        {
            var vd = Application.OpenForms["Main"] as Main;
            if (vd.ch_Stop.Checked)
            {

                if (vd.ch_Dow.Checked)
                {

                    DB_Add_delete_update_.Database.dv.RowFilter = "[صنف دواء]=" + 1;
                    vd.lbl_count.Text = DB_Add_delete_update_.Database.dv.Count.ToString();
                }
                else if (vd.ch_NoDow.Checked)
                {
                    DB_Add_delete_update_.Database.dv.RowFilter = "[صنف دواء]=" + 0;
                    vd.lbl_count.Text = DB_Add_delete_update_.Database.dv.Count.ToString();
                }
                else
                {
                    DB_Add_delete_update_.Database.dv.RowFilter = "";
                    vd.lbl_count.Text = DB_Add_delete_update_.Database.dv.Count.ToString();
                }
            }
            else
            {

            }
        }

        public void serch_drg()
        {
            var vd = Application.OpenForms["Main"] as Main;

            // جاهز دوا
            if (vd.ch_Dow.Checked)
            {
                if (vd.ch_Stop.Checked)
                {
                    DB_Add_delete_update_.Database.dv.RowFilter = "[الاسم العربي] + [الاسم الانجليزي] + [الشركة المصنعة] + [طبيعة الصنف] + [مكان الصنف] + [المجموعة العلمية]+[المادة الفعالة] +[كود الصنف] like '%" + vd.txt_Serch_Item.Text + "%'  And   [صنف دواء]=" + 1 + "  And   [ايقاف الصنف]=" + 1;
                    vd.lbl_count.Text = DB_Add_delete_update_.Database.dv.Count.ToString();
                }
                else if (vd.ch_NoStop.Checked)
                {
                    DB_Add_delete_update_.Database.dv.RowFilter = "[الاسم العربي] + [الاسم الانجليزي] + [الشركة المصنعة] + [طبيعة الصنف] + [مكان الصنف] + [المجموعة العلمية]+[المادة الفعالة] +[كود الصنف] like '%" + vd.txt_Serch_Item.Text + "%'  And   [صنف دواء]=" + 1 + "  And   [ايقاف الصنف]=" + 0;
                    vd.lbl_count.Text = DB_Add_delete_update_.Database.dv.Count.ToString();
                }
                else
                {
                    DB_Add_delete_update_.Database.dv.RowFilter = "[الاسم العربي] + [الاسم الانجليزي] + [الشركة المصنعة] + [طبيعة الصنف] + [مكان الصنف] + [المجموعة العلمية]+[المادة الفعالة] +[كود الصنف] like '%" + vd.txt_Serch_Item.Text + "%'  And   [صنف دواء]=" + 1;
                    vd.lbl_count.Text = DB_Add_delete_update_.Database.dv.Count.ToString();
                }

            }
        }
        //البحث في الصنف
        public void serch_Items()
        {
            var vd = Application.OpenForms["Main"] as Main;
            vd.ch_All.Checked = false;

            if (vd.ch_Stop.Checked)
            {
                if (vd.ch_NoDow.Checked)
                {
                    DB_Add_delete_update_.Database.dv.RowFilter = "[صنف دواء]=" + 0 + "And [ايقاف الصنف] = " + 1;
                    vd.lbl_count.Text = DB_Add_delete_update_.Database.dv.Count.ToString();
                }
                else
                {
                    DB_Add_delete_update_.Database.dv.RowFilter = "[صنف دواء]=" + 0 + "And [ايقاف الصنف] = " + 0;
                    vd.lbl_count.Text = DB_Add_delete_update_.Database.dv.Count.ToString();
                }
            }
        }
        public void All_Drt()
        {
            var vd = Application.OpenForms["Main"] as Main;


            // جاهز البحث في الكل
            if (vd.ch_NoDow.Checked)
            {
                if (vd.ch_Stop.Checked)
                {
                    DB_Add_delete_update_.Database.dv.RowFilter = "[الاسم العربي] + [الاسم الانجليزي] + [الشركة المصنعة] + [طبيعة الصنف] + [مكان الصنف] + [المجموعة العلمية]+[المادة الفعالة] +[كود الصنف] like '%" + vd.txt_Serch_Item.Text + "%'  And   [صنف دواء]=" + 0 + "  And   [ايقاف الصنف]=" + 1;
                    vd.lbl_count.Text = DB_Add_delete_update_.Database.dv.Count.ToString();
                }
                else if (vd.ch_NoStop.Checked)
                {
                    DB_Add_delete_update_.Database.dv.RowFilter = "[الاسم العربي] + [الاسم الانجليزي] + [الشركة المصنعة] + [طبيعة الصنف] + [مكان الصنف] + [المجموعة العلمية]+[المادة الفعالة] +[كود الصنف] like '%" + vd.txt_Serch_Item.Text + "%'  And   [صنف دواء]=" + 0 + "  And   [ايقاف الصنف]=" + 0;
                    vd.lbl_count.Text = DB_Add_delete_update_.Database.dv.Count.ToString();
                }
                else
                {
                    DB_Add_delete_update_.Database.dv.RowFilter = "[الاسم العربي] + [الاسم الانجليزي] + [الشركة المصنعة] + [طبيعة الصنف] + [مكان الصنف] + [المجموعة العلمية]+[المادة الفعالة] +[كود الصنف] like '%" + vd.txt_Serch_Item.Text + "%'  And   [صنف دواء]=" + 0;
                    vd.lbl_count.Text = DB_Add_delete_update_.Database.dv.Count.ToString();
                }

            }
        }
        public void AllDrk_stop()
        {
            var vd = Application.OpenForms["Main"] as Main;
            // جاهز
            if (vd.ch_All.Checked)
            {
                if (vd.ch_Stop.Checked)
                {
                    DB_Add_delete_update_.Database.dv.RowFilter = "[الاسم العربي] + [الاسم الانجليزي] + [الشركة المصنعة] + [طبيعة الصنف] + [مكان الصنف] + [المجموعة العلمية]+[المادة الفعالة] +[كود الصنف] like '%" + vd.txt_Serch_Item.Text + "%' " + " And [ايقاف الصنف]=" + 1;
                    vd.lbl_count.Text = DB_Add_delete_update_.Database.dv.Count.ToString();
                }
                else if (vd.ch_NoStop.Checked)
                {
                    DB_Add_delete_update_.Database.dv.RowFilter = "[الاسم العربي] + [الاسم الانجليزي] + [الشركة المصنعة] + [طبيعة الصنف] + [مكان الصنف] + [المجموعة العلمية]+[المادة الفعالة] +[كود الصنف] like '%" + vd.txt_Serch_Item.Text + "%' And [ايقاف الصنف]=" + 0;
                    vd.lbl_count.Text = DB_Add_delete_update_.Database.dv.Count.ToString();
                }
                else
                {
                    DB_Add_delete_update_.Database.dv.RowFilter = "[الاسم العربي] + [الاسم الانجليزي] + [الشركة المصنعة] + [طبيعة الصنف] + [مكان الصنف] + [المجموعة العلمية]+[المادة الفعالة] +[كود الصنف] like '%" + vd.txt_Serch_Item.Text + "%'";
                    vd.lbl_count.Text = DB_Add_delete_update_.Database.dv.Count.ToString();
                }

            }
        }
        public void All_dar_2()
        {
            var vd = Application.OpenForms["Main"] as Main;
            //جاهز
            if (vd.ch_Stop.Checked)
            {
                if (vd.ch_Dow.Checked)
                {
                    DB_Add_delete_update_.Database.dv.RowFilter = "[الاسم العربي] + [الاسم الانجليزي] + [الشركة المصنعة] + [طبيعة الصنف] + [مكان الصنف] + [المجموعة العلمية]+[المادة الفعالة] +[كود الصنف] like '%" + vd.txt_Serch_Item.Text + "%'  And   [صنف دواء]=" + 1 + "  And   [ايقاف الصنف]=" + 1;
                    vd.lbl_count.Text = DB_Add_delete_update_.Database.dv.Count.ToString();
                }
                else if (vd.ch_NoDow.Checked)
                {
                    DB_Add_delete_update_.Database.dv.RowFilter = "[الاسم العربي] + [الاسم الانجليزي] + [الشركة المصنعة] + [طبيعة الصنف] + [مكان الصنف] + [المجموعة العلمية]+[المادة الفعالة] +[كود الصنف] like '%" + vd.txt_Serch_Item.Text + "%'  And   [صنف دواء]=" + 0 + "  And   [ايقاف الصنف]=" + 1;
                    vd.lbl_count.Text = DB_Add_delete_update_.Database.dv.Count.ToString();
                }
                else
                {
                    DB_Add_delete_update_.Database.dv.RowFilter = "[الاسم العربي] + [الاسم الانجليزي] + [الشركة المصنعة] + [طبيعة الصنف] + [مكان الصنف] + [المجموعة العلمية]+[المادة الفعالة] +[كود الصنف] like '%" + vd.txt_Serch_Item.Text + "%'" + "  And   [ايقاف الصنف]=" + 1;
                    vd.lbl_count.Text = DB_Add_delete_update_.Database.dv.Count.ToString();
                }

            }
        }

        public void NoStoop()
        {
            var vd = Application.OpenForms["Main"] as Main;
            //جاهز
            if (vd.ch_NoStop.Checked)
            {
                if (vd.ch_Dow.Checked)
                {
                    DB_Add_delete_update_.Database.dv.RowFilter = "[الاسم العربي] + [الاسم الانجليزي] + [الشركة المصنعة] + [طبيعة الصنف] + [مكان الصنف] + [المجموعة العلمية]+[المادة الفعالة] +[كود الصنف] like '%" + vd.txt_Serch_Item.Text + "%'  And   [صنف دواء]=" + 1 + "  And   [ايقاف الصنف]=" + 0;
                    vd.lbl_count.Text = DB_Add_delete_update_.Database.dv.Count.ToString();
                }
                else if (vd.ch_NoDow.Checked)
                {
                    DB_Add_delete_update_.Database.dv.RowFilter = "[الاسم العربي] + [الاسم الانجليزي] + [الشركة المصنعة] + [طبيعة الصنف] + [مكان الصنف] + [المجموعة العلمية]+[المادة الفعالة] +[كود الصنف] like '%" + vd.txt_Serch_Item.Text + "%'  And   [صنف دواء]=" + 0 + "  And   [ايقاف الصنف]=" + 0;
                    vd.lbl_count.Text = DB_Add_delete_update_.Database.dv.Count.ToString();
                }
                else
                {
                    DB_Add_delete_update_.Database.dv.RowFilter = "[الاسم العربي] + [الاسم الانجليزي] + [الشركة المصنعة] + [طبيعة الصنف] + [مكان الصنف] + [المجموعة العلمية]+[المادة الفعالة] +[كود الصنف] like '%" + vd.txt_Serch_Item.Text + "%'" + "  And   [ايقاف الصنف]=" + 0;
                    vd.lbl_count.Text = DB_Add_delete_update_.Database.dv.Count.ToString();
                }
            }
        }

        public void ch_sp_All()
        {
            var vd = Application.OpenForms["Main"] as Main;

            //جاهز
            if (vd.ch_Sp_All.Checked)
            {
                if (vd.ch_Dow.Checked)
                {
                    DB_Add_delete_update_.Database.dv.RowFilter = "[الاسم العربي] + [الاسم الانجليزي] + [الشركة المصنعة] + [طبيعة الصنف] + [مكان الصنف] + [المجموعة العلمية]+[المادة الفعالة] +[كود الصنف] like '%" + vd.txt_Serch_Item.Text + "%'  And   [صنف دواء]=" + 1;
                    vd.lbl_count.Text = DB_Add_delete_update_.Database.dv.Count.ToString();
                }
                else if (vd.ch_NoDow.Checked)
                {
                    DB_Add_delete_update_.Database.dv.RowFilter = "[الاسم العربي] + [الاسم الانجليزي] + [الشركة المصنعة] + [طبيعة الصنف] + [مكان الصنف] + [المجموعة العلمية]+[المادة الفعالة] +[كود الصنف] like '%" + vd.txt_Serch_Item.Text + "%'  And   [صنف دواء]=" + 0;
                    vd.lbl_count.Text = DB_Add_delete_update_.Database.dv.Count.ToString();
                }
                else
                {
                    DB_Add_delete_update_.Database.dv.RowFilter = "[الاسم العربي] + [الاسم الانجليزي] + [الشركة المصنعة] + [طبيعة الصنف] + [مكان الصنف] + [المجموعة العلمية]+[المادة الفعالة] +[كود الصنف] like '%" + vd.txt_Serch_Item.Text + "%'";
                    vd.lbl_count.Text = DB_Add_delete_update_.Database.dv.Count.ToString();
                }
            }
        }


    }



}

