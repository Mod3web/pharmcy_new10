using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Manag_ph.Supplier.supplier
{
    class supplier
    {

        classs_table.Items_Tools to = new classs_table.Items_Tools();

        public void ClearData(string name_Table, string name_column_ID)
        {

            var vr = Application.OpenForms["Main"] as Main;

            //int numItem = Convert.ToInt32(DB_Add_delete_update_.Database.ds.Tables[name_Table].Compute(name_column_ID, "")) + 1;

            int numItem = to.AoutoNumber(name_Table, name_column_ID);
            vr.txt_num_supp.Text = numItem.ToString();

            vr.txt_name_supp.Clear();
            vr.txt_Phon_Dlgt.Text = "0";
            // vr.txt_Pon_supp.Clear();
            vr.txt_name_Conus.Clear();
            vr.txt_Delgat.Clear();
            vr.txt_Dbt_supp.Text = "0";
            vr.txt_Crdt_supp.Text = "0";
            vr.txt_Distbt.Clear();
            vr.ch_Posi_or_not.Checked = false;
            vr.txt_Pon_supp.Text = "0";
            vr.txt_phon_supp2.Text = "0";
            vr.txt_Address_supp.Clear();
            vr.txt_Phon_Conus.Text = "0";
            vr.txt_Phon_Ditdt.Text = "0";
            vr.txt_limet_dealing.Text = "0";
            vr.txt_name_supp.Focus();
            vr.txt_name_supp.SelectAll();
        }

        ErrorProvider ero = new ErrorProvider();
        public void Bt_add_suppl_Click1(object sender, EventArgs e)
        {
            var vr = Application.OpenForms["Main"] as Main;

            //متغيرات 
            int num_supp;
            string name_supp;
            string address_supp;
            string name_Distbt;
            string name_Conus;
            string name_Delgat;
            //bool Position_or_not;
            int Phon_Delgat;
            string Phon_supp1;
            double limet_dealing = 0;
            string Phon_supp2;
            string Phon_Conus;
            string Phon_Ditdt;

            double Dbt_supp;
            double Crdt_supp;


            //ترجع ارقم اوكود المورد الجديد
            //int Delgt = Convert.ToInt32(DB_Add_delete_update_.Database.ds.Tables["Supplier"].Compute("max(num_supp)", "")) + 1;
            int Delgt = to.AoutoNumber("Supplier", "num_supp");

            num_supp = Convert.ToInt32(Delgt);
            if (vr.txt_name_supp.Text.Trim() == string.Empty)
            {
                MessageBox.Show("يرجاء تعبئة اسم المورد", "تنبية", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            name_supp = vr.txt_name_supp.Text;
            address_supp = vr.txt_Address_supp.Text;
            name_Distbt = vr.txt_Distbt.Text;
            name_Conus = vr.txt_name_Conus.Text;
            name_Delgat = vr.txt_Delgat.Text;
            Phon_Delgat = Convert.ToInt32(vr.txt_Phon_Dlgt.Text.Trim() == string.Empty ? "0" : vr.txt_Phon_Dlgt.Text);
            Dbt_supp = vr.txt_Dbt_supp.Text.Trim() != string.Empty ? Convert.ToDouble(vr.txt_Dbt_supp.Text) : 0;
            Crdt_supp = vr.txt_Crdt_supp.Text.Trim() != string.Empty ? Convert.ToDouble(vr.txt_Crdt_supp.Text) : 0;

            bool Add_Balance = false;
            if (vr.txt_limet_dealing.Text != string.Empty)
            {
                if (Convert.ToDouble(vr.txt_limet_dealing.Text) != 0)
                {
                    if (Crdt_supp > Convert.ToDouble(vr.txt_limet_dealing.Text))
                    {
                        MessageBox.Show("رصيد المورد اكبر من حدالتعامل !!!", "تحذير", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    else
                    {
                        limet_dealing = Convert.ToDouble(vr.txt_limet_dealing.Text);
                    }
                    //limet_dealing

                }

            }
            else
            {
                limet_dealing = 0;
            }


            Phon_supp1 = vr.txt_Pon_supp.Text.Trim() == string.Empty ? "0" : vr.txt_Pon_supp.Text;
            Phon_supp2 = vr.txt_phon_supp2.Text.Trim() == string.Empty ? "0" : vr.txt_phon_supp2.Text;
            Phon_Conus = vr.txt_Phon_Conus.Text.Trim() == string.Empty ? "0" : vr.txt_Phon_Conus.Text;
            Phon_Ditdt = vr.txt_Phon_Ditdt.Text.Trim() == string.Empty ? "0" : vr.txt_Phon_Ditdt.Text;
            bool ch_Pos_or = vr.ch_Posi_or_not.Checked == true ? true : false;

            int Delgt2 = to.AoutoNumber("Calc_supply", "num_calc");
            if (vr.txt_name_supp.Text.Trim() != string.Empty || vr.txt_Pon_supp.Text.Trim() != string.Empty)

            {

                double sum = Crdt_supp - Dbt_supp;
                //اضافة البيانات الى الجداول
                DB_Add_delete_update_.Database.ds.Tables["Supplier"].Rows.Add(Delgt, name_supp, address_supp, name_Delgat, ch_Pos_or, Phon_Delgat, Delgt2, Phon_supp1, Phon_supp2, name_Distbt, Phon_Ditdt, name_Conus, Phon_Conus, limet_dealing);
                DB_Add_delete_update_.Database.ds.Tables["Calc_supply"].Rows.Add(Delgt2, Crdt_supp, Dbt_supp, sum, Add_Balance);

                Btn_New_suppl_Click2();
            }
            else
            {
                ero.SetError(vr.txt_name_supp, "يرجاء ملى الحقل");
                ero.SetError(vr.txt_Pon_supp, "يرجاء ملى الحقل");


            }

            // vr.dgv_supplier.DataSource = DB_Add_delete_update_.Database.ds.Tables["Supplier"];


            DB_Add_delete_update_.Database.update("Calc_supply");
            DB_Add_delete_update_.Database.update("Supplier");

            //vr.txt_num_supp.Text = phon.ToString();

            vr.btn_New_suppl_btn.PerformClick();
            ClearData("Supplier", "num_supp");

        }

        public void Btn_Add_supplier_ItemClick2(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

            var vr = Application.OpenForms["Main"] as Main;
            vr.bt_add_suppl_btn.Enabled = true;

            vr.ch_Posi_or_not.Checked = false;
            //to.Style_DataGridView(vr.dgv_supplier_dgv);//دالة تنسيق الجدول
            vr.dgv_supplier_dgv.DataSource = DB_Add_delete_update_.Database.ds.Tables["Supplier"];    //ارجاع البيانات من جدول الموردين الى الجدول في الواجهه



            //vr.dgv_supplier.Rows[2].Visible = false;
            vr.dgv_supplier_dgv.Columns[6].Visible = false;
            vr.dgv_supplier_dgv.Columns[10].Visible = false;
            vr.dgv_supplier_dgv.Columns[12].Visible = false;

            vr.dgv_supplier_dgv.Columns[0].HeaderText = "كود المورد";
            vr.dgv_supplier_dgv.Columns[1].HeaderText = "اسم المورد";
            vr.dgv_supplier_dgv.Columns[2].HeaderText = "عنوان المورد";
            vr.dgv_supplier_dgv.Columns[3].HeaderText = "اسم المندوب";
            vr.dgv_supplier_dgv.Columns[4].HeaderText = "ايقاف التعامل";
            vr.dgv_supplier_dgv.Columns[5].HeaderText = "هاتف المندوب";
            vr.dgv_supplier_dgv.Columns[6].HeaderText = "كود الرصيد";
            vr.dgv_supplier_dgv.Columns[7].HeaderText = "هاتف المورد1 ";
            vr.dgv_supplier_dgv.Columns[8].HeaderText = "هاتف المورد2";
            vr.dgv_supplier_dgv.Columns[9].HeaderText = "اسم الموزع";
            vr.dgv_supplier_dgv.Columns[10].HeaderText = "هاتف الموزع";
            vr.dgv_supplier_dgv.Columns[11].HeaderText = "اسم المتحصل";
            vr.dgv_supplier_dgv.Columns[12].HeaderText = "هاتف المتحصل";
            vr.dgv_supplier_dgv.Columns[13].HeaderText = "حد التعامل";



            //ClearData("Supplier", "num_supp", vr.txt_num_supp); //داله تستقبل اسم الجدول واسم عمود المفتاح الرئيسي لارجاع رقم اكبر رقم وعرضه في txt


        }


        public void Btn_New_suppl_Click2()
        {
            var vr = Application.OpenForms["Main"] as Main;

            vr.btn_delet_suppl_btn.Enabled = false;
            vr.btn_updete_suppl_btn.Enabled = false;
            vr.bt_add_suppl_btn.Enabled = true;
            int Delgt = to.AoutoNumber("Supplier", "num_supp");
            vr.txt_num_supp.Text = Delgt.ToString();
            ClearData("Supplier", "num_supp");

        }


        //تعديل بيانات  
        public void Btn_updete_suppl_Click2(object sender, EventArgs e)
        {
            var vr = Application.OpenForms["Main"] as Main;

            int a = (int)vr.dgv_supplier_dgv.CurrentRow.Cells[0].Value;
            DataRow dr_suup1 = DB_Add_delete_update_.Database.ds.Tables["Supplier"].Rows.Find(a);

            int dr_Suup = DB_Add_delete_update_.Database.ds.Tables["Supplier"].Rows.IndexOf(dr_suup1);



            DB_Add_delete_update_.Database.ds.Tables["Supplier"].Rows[dr_Suup][1] = vr.txt_name_supp.Text;
            DB_Add_delete_update_.Database.ds.Tables["Supplier"].Rows[dr_Suup][2] = vr.txt_Address_supp.Text;
            DB_Add_delete_update_.Database.ds.Tables["Supplier"].Rows[dr_Suup][3] = vr.txt_Delgat.Text;
            DB_Add_delete_update_.Database.ds.Tables["Supplier"].Rows[dr_Suup][4] = vr.ch_Posi_or_not.Checked ? true : false;
            DB_Add_delete_update_.Database.ds.Tables["Supplier"].Rows[dr_Suup][5] = vr.txt_Phon_Dlgt.Text;
            DB_Add_delete_update_.Database.ds.Tables["Supplier"].Rows[dr_Suup][7] = vr.txt_Pon_supp.Text;
            DB_Add_delete_update_.Database.ds.Tables["Supplier"].Rows[dr_Suup][8] = vr.txt_phon_supp2.Text;
            DB_Add_delete_update_.Database.ds.Tables["Supplier"].Rows[dr_Suup][9] = vr.txt_Distbt.Text;
            DB_Add_delete_update_.Database.ds.Tables["Supplier"].Rows[dr_Suup][10] = vr.txt_Phon_Ditdt.Text;
            DB_Add_delete_update_.Database.ds.Tables["Supplier"].Rows[dr_Suup][11] = vr.txt_name_Conus.Text;
            DB_Add_delete_update_.Database.ds.Tables["Supplier"].Rows[dr_Suup][12] = vr.txt_Phon_Conus.Text;
            DB_Add_delete_update_.Database.ds.Tables["Supplier"].Rows[dr_Suup][13] = vr.txt_limet_dealing.Text;


            double limet_dealing = 0;
            ////////////////////////////////////////////////////////////////////////////
            int a2 = (int)vr.dgv_supplier_dgv.CurrentRow.Cells[6].Value;
            object[] dr_Calc_sup = DB_Add_delete_update_.Database.ds.Tables["Calc_supply"].Rows.Find(a2).ItemArray;
            double Crdt_supp = vr.txt_Crdt_supp.Text.Trim() != string.Empty ? Convert.ToInt32(vr.txt_Crdt_supp.Text) : 0;
            if (vr.txt_limet_dealing.Text.Trim() != string.Empty)
            {
                if (Convert.ToDouble(vr.txt_limet_dealing.Text) != 0)
                {
                    if (Crdt_supp > Convert.ToDouble(vr.txt_limet_dealing.Text))
                    {
                        MessageBox.Show("رصيد المورد اكبر من حدالتعامل !!!", "تحذير", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    else
                    {
                        limet_dealing = Convert.ToDouble(vr.txt_limet_dealing.Text);
                    }
                    //limet_dealing

                }

            }
            else
            {
                limet_dealing = 0;
            }
            dr_Calc_sup[1] = vr.txt_Crdt_supp.Text.Trim() != string.Empty ? Convert.ToInt32(vr.txt_Crdt_supp.Text) : 0;
            dr_Calc_sup[2] = vr.txt_Dbt_supp.Text.Trim() != string.Empty ? Convert.ToInt32(vr.txt_Dbt_supp.Text) : 0;
            dr_Calc_sup[3] = dr_Calc_sup[3];// limet_dealing;
            to.update_Rows_Table_Database("Calc_supply", dr_Calc_sup[0].ToString(), dr_Calc_sup);

            DB_Add_delete_update_.Database.update("Supplier");


            vr.btn_New_suppl_btn.PerformClick();
        }


        public void Btn_delet_suppl_Click2(object sender, EventArgs e)
        {
            var vr = Application.OpenForms["Main"] as Main;


            if (vr.dgv_supplier_dgv.CurrentRow != null)
            {
                DialogResult dr = MessageBox.Show("هل تريد بالفعل حذف الصنف المحدد", "حذف", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2);


                int id = (int)vr.dgv_supplier_dgv.CurrentRow.Cells[0].Value;

                int id2 = (int)vr.dgv_supplier_dgv.CurrentRow.Cells[6].Value;

                if (dr == DialogResult.Yes)
                {


                    DB_Add_delete_update_.Database.ds.Tables["Supplier"].Rows.Remove(DB_Add_delete_update_.Database.ds.Tables["Supplier"].Rows.Find(id));
                    DB_Add_delete_update_.Database.ds.Tables["Calc_supply"].Rows.Remove(DB_Add_delete_update_.Database.ds.Tables["Calc_supply"].Rows.Find(id2));


                    MessageBox.Show(id2 + "");


                    MessageBox.Show("تم الحذف بنجاح", "حذف", MessageBoxButtons.OK, MessageBoxIcon.Information);



                    //حذف المورد 
                    new classs_table.Items_Tools().insertItem(1, "Delete_supply", "@num_supp", id, SqlDbType.Int);
                    //حذف الرصيد المورد
                    new classs_table.Items_Tools().insertItem(1, "Delete_Calc_supply", "@num_cal", id2, SqlDbType.Int);
                }


                DB_Add_delete_update_.Database.update("Calc_supply");

                DB_Add_delete_update_.Database.update("Supplier");

            }
        }



        public void Dgv_supplier_SelectionChanged2(object sender, EventArgs e)
        {
            var vr = Application.OpenForms["Main"] as Main;


            if (vr.dgv_supplier_dgv.CurrentRow != null)
            {


                vr.btn_delet_suppl_btn.Enabled = true;
                vr.btn_updete_suppl_btn.Enabled = true;
                vr.bt_add_suppl_btn.Enabled = false;



                int id = Convert.ToInt32(vr.dgv_supplier_dgv.CurrentRow.Cells[0].Value);
                object[] dr;
                dr = DB_Add_delete_update_.Database.ds.Tables["Supplier"].Rows.Find(id).ItemArray;



                vr.txt_num_supp.Text = dr[0].ToString();//dgv_supplier.CurrentRow.Cells[0].Value.ToString();
                vr.txt_name_supp.Text = dr[1].ToString();//dgv_supplier.CurrentRow.Cells[1].Value.ToString();
                vr.txt_Address_supp.Text = dr[2].ToString();//dgv_supplier.CurrentRow.Cells[2].Value.ToString();
                vr.txt_Delgat.Text = dr[3].ToString();//dgv_supplier.CurrentRow.Cells[3].Value.ToString();
                vr.ch_Posi_or_not.Checked = Convert.ToBoolean(dr[4].ToString()) == true ? true : false;//Convert.ToBoolean(dgv_supplier.CurrentRow.Cells[4].Value.ToString())== true ? true : false ;
                vr.txt_Phon_Dlgt.Text = dr[5].ToString();// dgv_supplier.CurrentRow.Cells[6].Value.ToString();
                vr.txt_Pon_supp.Text = dr[7].ToString();//dgv_supplier.CurrentRow.Cells[8].Value.ToString();
                vr.txt_phon_supp2.Text = dr[8].ToString();//dgv_supplier.CurrentRow.Cells[9].Value.ToString();
                vr.txt_Distbt.Text = dr[9].ToString();// dgv_supplier.CurrentRow.Cells[10].Value.ToString();
                vr.txt_Phon_Ditdt.Text = dr[10].ToString();//dgv_supplier.CurrentRow.Cells[5].Value.ToString();
                vr.txt_name_Conus.Text = dr[11].ToString();//dgv_supplier.CurrentRow.Cells[5].Value.ToString();
                vr.txt_Phon_Conus.Text = dr[12].ToString();//dgv_supplier.CurrentRow.Cells[5].Value.ToString();
                vr.txt_limet_dealing.Text = dr[13].ToString();
                int id_cal = Convert.ToInt32(vr.dgv_supplier_dgv.CurrentRow.Cells[6].Value.ToString());
                DataRow[] dr_Calc = DB_Add_delete_update_.Database.ds.Tables["Calc_supply"].Select("num_calc =" + id_cal);

                if (dr_Calc.Count() != 0)
                {
                    vr.txt_Crdt_supp.Text = dr_Calc[0][1].ToString();//dgv_supplier.CurrentRow.Cells[7].Value.ToString();
                    vr.txt_Dbt_supp.Text = dr_Calc[0][2].ToString();//dgv_supplier.CurrentRow.Cells[12].Value.ToString();
                //    vr.txt_limet_dealing.Text = dr_Calc[0][3].ToString();//dgv_supplier.CurrentRow.Cells[12].Value.ToString();


                }






            }
        }


        //دالة البحث في جدول الموردين
        public void TextBox2_TextChanged2(object sender, EventArgs e)
        {
            var vr = Application.OpenForms["Main"] as Main;

            vr.dgv_supplier_dgv.ClearSelection();
            DataView dv = new DataView(DB_Add_delete_update_.Database.ds.Tables["Supplier"]);
            string str = vr.txt_serch_supp.Text;
            dv.RowFilter = "num_supp+name_supp+address_supp+name_dldt+name_Ditbt like '%" + str + "%'";
            vr.dgv_supplier_dgv.DataSource = dv;
            vr.dgv_supplier_dgv.ClearSelection();


        }

        public void Txt_Pon_supp_KeyPress2(object sender, KeyPressEventArgs e)
        {
            var vr = Application.OpenForms["Main"] as Main;
            if (e.KeyChar == (char)Keys.Enter)
            {

                vr.txt_Pon_supp.Clear();

            }
        }



        //if (com_link.SelectedIndex == 1)
        //{
        //    com_name_link.DataSource = DB_Add_delete_update_.Database.ds.Tables["Client"];
        //    com_name_link.DisplayMember = "name_clin";
        //    com_name_link.ValueMember = "num_clin";

        //    //m2.Fill_Combox(com_name_link, "Client");

        //}
        //else if (com_link.SelectedItem == "لايوجد")
        //{

        //    com_name_link.Items.Clear();
        //    com_name_link.DisplayMember = null;
        //    com_name_link.ValueMember = null;
        //    com_name_link.DataSource = null;

        //    com_name_link.Items.Add("لايوجد");
        //    com_name_link.SelectedItem = "لايوجد";
        //}













    }
}

