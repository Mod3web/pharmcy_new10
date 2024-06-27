using Manag_ph.forms;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Manag_ph.classs_table
{
    class Formats
    {
        KeyPressEventArgs e;


        public void Coordinate()
        {
            classs_table.Formats tt = new classs_table.Formats();
            var vr = Application.OpenForms["Main"] as Main;

            List<TextBox> text_box_name = new List<TextBox>();
             KeyPressEventArgs e;
            
            text_box_name.Add(vr.txt_name_supp);
            text_box_name.Add(vr.txt_Address_supp);
            text_box_name.Add(vr.txt_Delgat);
            text_box_name.Add(vr.txt_name_Conus);
            text_box_name.Add(vr.txt_Distbt);
            text_box_name.Add(vr.txt_name_clin);
            text_box_name.Add(vr.txt_Emp_name_ar);
            text_box_name.Add(vr.txt_Emp_name_En);
            text_box_name.Add(vr.txt_name_job_AR);
            text_box_name.Add(vr.txt_name_job_EN);
            text_box_name.Add(vr.txt_Addres_Emp);
            text_box_name.Add(vr.txt_Username_Emp);
            text_box_name.Add(vr.txt_serch_RP_cash_Exchange);
            text_box_name.Add(vr.txt_serch_RP_name_beneficiry_cash_supply);

            //text_box_name.Add(vr.txt_name_Rp_clin);
            //text_box_name.Add(vr.txt_Distbt);

            foreach (var item in text_box_name)
            {

                item.KeyPress += (sende, a) =>
                {
                    //  item.MaxLength = lin;
                    
                    if (!char.IsLetter(a.KeyChar) && !char.IsControl(a.KeyChar) && a.KeyChar ==8  )
                    {
                        a.Handled = true;
                       // Keys.Back = 8;
                    }
                };
            }



            ////////////////////////////////  ارقام هواتف 9
            List<TextBox> text_box_Phon = new List<TextBox>();

            text_box_Phon.Add(vr.txt_Phon_Dlgt);
            text_box_Phon.Add(vr.txt_Phon_Conus);
            text_box_Phon.Add(vr.txt_Phon_Ditdt);
            text_box_Phon.Add(vr.txt_phon_clin);
            text_box_Phon.Add(vr.txt_phon_Emp);
            text_box_Phon.Add(vr.txt_Pon_supp);
            text_box_Phon.Add(vr.txt_Telephon_Emp);

            foreach (var item2 in text_box_Phon)
            {
                item2.KeyPress += (sende, a) =>
                {
                    item2.MaxLength = 9;
                    if (!char.IsNumber(a.KeyChar) && !char.IsControl(a.KeyChar))
                    {
                        a.Handled = true;
                    }
                };
            }

            /////////////////////////////////////////    ارقام فقط
            List<TextBox> text_box_num = new List<TextBox>();


            text_box_num.Add(vr.txt_Debt_blan_clin);
            text_box_num.Add(vr.txt_Cedt_bln_clin);
            text_box_num.Add(vr.txt_Debtor_sup);
            text_box_num.Add(vr.txt_Creditor_sup);
            text_box_num.Add(vr.sell_pric);
            text_box_num.Add(vr.tax_pric_update);
            text_box_num.Add(vr.sell_pric_update);
            text_box_num.Add(vr.Max_DIsc_update);
            text_box_num.Add(vr.txt_limet_dealing);
            text_box_num.Add(vr.txt_max_cloud);
            text_box_num.Add(vr.txt_max_bill);
            text_box_num.Add(vr.txt_Dicount_value_All);
            text_box_num.Add(vr.txt_num_Footer);
            text_box_num.Add(vr.txt_serch_num_foote);

            foreach (var box_num in text_box_num)
            {

                box_num.KeyPress += (sende, a) =>
                {
                    //  item2.MaxLength = 9;
                    if (!char.IsNumber(a.KeyChar) && !char.IsControl(a.KeyChar))
                    {
                        a.Handled = true;
                    }
                };
            }


            ///////////////////////////////////////////////   كود او ID  3
            List<TextBox> text_box_id = new List<TextBox>();

            text_box_id.Add(vr.txt_num_Item_settle);
            text_box_id.Add(vr.txt_num_storg_prodect);
            text_box_id.Add(vr.txt_num_Supplier_prodect);
            text_box_id.Add(vr.txt_num_prodect);
            text_box_id.Add(vr.txt_num_supper_return);
            text_box_id.Add(vr.txt_num_Job);
            text_box_id.Add(vr.txt_num_storg_one);
            text_box_id.Add(vr.txt_num_storg_tow);
            text_box_id.Add(vr.txt_num_Item_RP_Storg_All);
            text_box_id.Add(vr.txt_num_supper_RP_total_return);
            text_box_id.Add(vr.txt_id_Rp_clin);
            text_box_id.Add(vr.txt_Report_id_sup);
            foreach (var box_id in text_box_id)
            {

                box_id.KeyPress += (sende, a) =>
                {
                    box_id.MaxLength = 3;
                    if (!char.IsNumber(a.KeyChar) && !char.IsControl(a.KeyChar))
                    {
                        a.Handled = true;
                    }
                };
            }

            ///////////////////////////////////////////////////////
            List<TextBox> text_box_red = new List<TextBox>();
            ///////////////////red                                 قرائه   
            text_box_red.Add(vr.txt_begin_Dicount_All);
            text_box_red.Add(vr.txt_end_Dico_All);
            text_box_red.Add(vr.txt_return_total);  //تكلفة  المرتجع:
            text_box_red.Add(vr.txt_name_storg_one);
            text_box_red.Add(vr.txt_name_storg_tow);
            text_box_red.Add(vr.txt_name_supper_RP_total_return);
            text_box_red.Add(vr.product_price);
            text_box_red.Add(vr.txt_Distbt);
            text_box_red.Add(vr.txt_name_Rp_clin);
            text_box_red.Add(vr.txt_Report_name_sup);
            foreach (var box_red in text_box_red)
            {

                box_red.KeyPress += (sende, a) =>
                {
                    box_red.ReadOnly = true;

                    //if (!char.IsLetter(a.KeyChar) && !char.IsControl(a.KeyChar))
                    //{
                    //    a.Handled = true;
                    //}
                };
            }



            List<TextBox> text_box_2_num = new List<TextBox>();
            /////////////////////////  2    نسبة الخصوم
            text_box_2_num.Add(vr.txt_Disco_rate);
            text_box_2_num.Add(vr.txt_Dicount_Rate_All);
            text_box_2_num.Add(vr.txt_tax_rapo_All);
            text_box_2_num.Add(vr.disc_parc);
            text_box_2_num.Add(vr.tax_pric);
            text_box_2_num.Add(vr.disc_parc_update);

            foreach (var box_2_num in text_box_2_num)
            {

                box_2_num.KeyPress += (sende, a) =>
                {
                    box_2_num.MaxLength = 2;
                    if (!char.IsNumber(a.KeyChar) && !char.IsControl(a.KeyChar))
                    {
                        a.Handled = true;
                    }
                };
            }



        }

        //public void Coordinate_from()
        //{
        //    classs_table.Formats tt = new classs_table.Formats();
        //    var vr = Application.OpenForms["Main"] as Main;
        //    var vr2 = Application.OpenForms["Type_supply_"] as Type_supply_;

        //    List<TextBox> text_box_id_form = new List<TextBox>();

        //    text_box_id_form.Add(vr2.txt_nun_storg_casher);
        //    text_box_id_form.Add(vr2.txt_num_fund_casher);

        //    foreach (var box_id in text_box_id_form)
        //    {

        //        box_id.KeyPress += (sende, a) =>
        //        {
        //            box_id.MaxLength = 3;
        //            if (!char.IsNumber(a.KeyChar) && !char.IsControl(a.KeyChar))
        //            {
        //                a.Handled = true;
        //            }
        //        };
        //    }
        //}

        public void lab()
        {
            var vr = Application.OpenForms["Main"] as Main;

            List<Label> lab = new List<Label>();
            //lab.Add(vr.label32);
            //lab.Add(vr.label38);
            //lab.Add(vr.label80);
            //lab.Add(vr.label83);
            //lab.Add(vr.label82);
            //lab.Add(vr.label84);
            //lab.Add(vr.label85);
            //lab.Add(vr.label88);
            //lab.Add(vr.label89);
            //lab.Add(vr.label90);
            //lab.Add(vr.lbl_RT_cash_exchange);
            //lab.Add(vr.lbl_RP_cash_supply);
            //lab.Add(vr.labelControl280);
            //lab.Add(vr.lbl_update);
            //lab.Add(vr.labelControl46);
            //lab.Add(vr.labelControl37);
            //lab.Add(vr.labelControl45);
            //lab.Add(vr.labelControl46);
            //lab.Add(vr.labelControl60);
            //lab.Add(vr.labelControl73);
            //lab.Add(vr.labelControl76);
            //lab.Add(vr.labelControl119);
            //lab.Add(vr.labelControl120);
            //lab.Add(vr.label53);
            //lab.Add(vr.lab_title);
            //lab.Add(vr.label77);
            //lab.Add(vr.labelControl137);
            //lab.Add(vr.labelControl147);
            //lab.Add(vr.labelControl147);
            //lab.Add(vr.labelControl146);
            //lab.Add(vr.labelControl145);
            //lab.Add(vr.labelControl140);
            //lab.Add(vr.labelControl155);
            //lab.Add(vr.labelControl156);
            //lab.Add(vr.labelControl163);
            //lab.Add(vr.labelControl170);
            //lab.Add(vr.labelControl172);
            //lab.Add(vr.labelControl207);


            foreach (var item in lab)
            {
                item.Font = new Font("Arial", 20, FontStyle.Bold);
            }

        }



        public void key_number(TextBox tx, int lin, KeyPressEventArgs e)
        {
            tx.MaxLength = lin;
            if (!char.IsNumber(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }


        public void key_String(TextBox tx, int lin, KeyPressEventArgs e)
        {
            tx.MaxLength = lin;
            if (!char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

    }
}
