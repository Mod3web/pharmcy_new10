//using System;
//using System.Data;
//using System.Windows.Forms;

//namespace Manag_ph.Client.Class_searsh_clinte
//{
//    class Searsh_Clinte
//    {
//        classs_table.Items_Tools to2 = new classs_table.Items_Tools();
//        public void BarButtonItem18_ItemClick()
//        {
//            var vr = Application.OpenForms["Main"] as Main;

//            vr.dgv_search_clin.DataSource = DB_Add_delete_update_.Database.ds.Tables["Clien"];    //ارجاع البيانات من جدول الموردين الى الجدول في الواجهه

//            vr.View_And_serch.Hide();   //اخفاء وجهة البحث
//            vr.Add_Item.Hide();          //اخفاء وجهة الاضافه
//            vr.navig_supplier.Hide();    //فتح واجهة الموردين
//            vr.add_client.Hide();
//            vr.View_And_serch.Hide();

//            vr.nvg_search_clin.Show();

//            to2.Style_DataGridView(vr.dgv_search_clin);//دالة تنسيق الجدول
//        }

//        public void TextBox2_TextChanged_Search_Clinte(object sender, EventArgs e)
//        {
//            var vr = Application.OpenForms["Main"] as Main;

//            int nu = Convert.ToInt32(DB_Add_delete_update_.Database.ds.Tables["Clien"].Compute("max(num_clin)", ""));

//            vr.dgv_search_clin.ClearSelection();
//            DataView dv = new DataView(DB_Add_delete_update_.Database.ds.Tables["Clien"]);
//            string str = vr.txt_searsh_clin.Text;


//            if (vr.rad_stop_clin.Checked)
//            {
//                dv.RowFilter = "num_clin + name_clin + address_clin  +  phon1_clin + phon2_clin + max_cloud   like '%" + str + "%' And   stop_clin= " + 1;
//            }
//            else if (vr.rad_not_stop_clin.Checked)
//            {
//                dv.RowFilter = "num_clin + name_clin + address_clin  +  phon1_clin + phon2_clin + max_cloud   like '%" + str + "%' And   stop_clin= " + 0;
//            }
//            else if (vr.rad_All_clin.Checked)
//            {

//                dv.RowFilter = "num_clin+name_clin+address_clin+stop_clin+Link_clin+phon1_clin+phon2_clin+max_cloud   like '%" + str + "%'";

//            }




//            dv.RowFilter = "num_clin+name_clin+address_clin+stop_clin+Link_clin+phon1_clin+phon2_clin+max_cloud   like '%" + str + "%'";
//            vr.dgv_search_clin.DataSource = dv;
//            vr.dgv_search_clin.ClearSelection();


//        }

//        public void Rad_All_clin_CheckedChanged()
//        {
//            var vr = Application.OpenForms["Main"] as Main;


//            DataView dv = new DataView(DB_Add_delete_update_.Database.ds.Tables["Clien"]);



//            if (vr.rad_stop_clin.Checked)
//            {
//                dv.RowFilter = "num_clin + name_clin + address_clin  +  phon1_clin + phon2_clin + max_cloud   like '%" + vr.txt_searsh_clin.Text + "%' And   stop_clin= " + 1;//+ " And  Link_clin = " + 1
//                vr.dgv_search_clin.DataSource = dv;
//                vr.dgv_search_clin.ClearSelection();
//            }
//            else if (vr.rad_not_stop_clin.Checked)
//            {
//                dv.RowFilter = "num_clin + name_clin + address_clin  +  phon1_clin + phon2_clin + max_cloud   like '%" + vr.txt_searsh_clin.Text + "%' And   stop_clin= " + 0;//+ " And  Link_clin = " + 1
//                vr.dgv_search_clin.DataSource = dv;
//                vr.dgv_search_clin.ClearSelection();
//            }
//            else if (vr.rad_All_clin.Checked)
//            {
//                dv.RowFilter = "num_clin+name_clin+address_clin+stop_clin+Link_clin+phon1_clin+phon2_clin+max_cloud   like '%" + vr.txt_searsh_clin.Text + "%'";
//                vr.dgv_search_clin.DataSource = dv;
//                vr.dgv_search_clin.ClearSelection();
//            }

//            //////////////////////////////////////////////////////////////////////

//        }

//        public void Rad_not_stop_clin_CheckedChanged()
//        {
//            var vr = Application.OpenForms["Main"] as Main;

//            DataView dv = new DataView(DB_Add_delete_update_.Database.ds.Tables["Clien"]);

//            if (vr.rad_not_stop_clin.Checked)
//            {
//                dv.RowFilter = "num_clin + name_clin + address_clin  +  phon1_clin + phon2_clin + max_cloud   like '%" + vr.txt_searsh_clin.Text + "%' And   stop_clin= " + 0;//+ " And  Link_clin = " + 1
//                vr.dgv_search_clin.DataSource = dv;
//                vr.dgv_search_clin.ClearSelection();
//            }

//        }

//        public void Rad_stop_clin_CheckedChanged()
//        {
//            var vr = Application.OpenForms["Main"] as Main;

//            DataView dv = new DataView(DB_Add_delete_update_.Database.ds.Tables["Clien"]);

//            if (vr.rad_stop_clin.Checked)
//            {
//                dv.RowFilter = "num_clin + name_clin + address_clin  +  phon1_clin + phon2_clin + max_cloud   like '%" + vr.txt_searsh_clin.Text + "%' And   stop_clin= " + 1;//+ " And  Link_clin = " + 1
//                vr.dgv_search_clin.DataSource = dv;
//                vr.dgv_search_clin.ClearSelection();

//            }
//        }

//    }
//}
