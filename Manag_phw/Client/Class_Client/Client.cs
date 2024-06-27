using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace Manag_ph.Client.Class_Client
{
    class Client
    {
        ErrorProvider ero = new ErrorProvider();
        classs_table.Items_Tools to2 = new classs_table.Items_Tools();

        public void ClearData(string name_Table, string name_column_ID, TextBox name_text)
        {

            var vr = Application.OpenForms["Main"] as Main;

            //  int numItem = Convert.ToInt32(DB_Add_delete_update_.Database.ds.Tables[name_Table].Compute(name_column_ID, "")) + 1;
            int numItem = to.AoutoNumber(name_Table, name_column_ID);
            name_text.Text = numItem.ToString();

            vr.txt_name_clin.Clear();
            vr.txt_phon_clin.Text = "0";
            vr.txt_phon_clin2.Text = "0";
            vr.txt_max_bill.Text = "0";
            vr.txt_max_cloud.Text = "0";
            vr.ch_link_clin.Checked = false;
            vr.ch_stop_clin.Checked = false;
            vr.txt_address_clin.Clear();
            vr.txt_Disco_rate.Text = "0";

            vr.txt_soct_clin.Text = "0";
            vr.txt_Deco_clin.Text = "0";

            //com_name_link.Items.Clear();
            //com_link.Items.IndexOf(-1);
        }
        classs_table.Items_Tools to = new classs_table.Items_Tools();
        public void BarButtonItem9_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var vr = Application.OpenForms["Main"] as Main;

            vr.View_And_serch.Hide();   //اخفاء وجهة البحث
            vr.Add_Item.Hide();          //اخفاء وجهة الاضافه
            //vr.navig_supplier.Hide();    //اخفاء واجهة الموردين
            vr.add_client.Show();
            //DateTime dtm = new DateTime();


            vr.dgv_clin_dgv.DataSource = DB_Add_delete_update_.Database.ds.Tables["Clien"];    //ارجاع البيانات من جدول الموردين الى الجدول في الواجهه

            vr.dgv_clin_dgv.Columns[10].Visible = false;


            //cod, name_clin, address_clin, stop_clin, link_clin, Phon_clin1, Phon_clin2, max_cloud, Diosc_rate, max_bill, stoc_cod, dat_start_clin
            vr.dgv_clin_dgv.Columns[0].HeaderText = "كود العميل";
            vr.dgv_clin_dgv.Columns[1].HeaderText = "اسم العميل";
            vr.dgv_clin_dgv.Columns[2].HeaderText = "عنوان العميل";
            vr.dgv_clin_dgv.Columns[3].HeaderText = "ايقاف العميل";
            vr.dgv_clin_dgv.Columns[4].HeaderText = "يرتبط";
            vr.dgv_clin_dgv.Columns[5].HeaderText = "هاتف العميل";
            vr.dgv_clin_dgv.Columns[6].HeaderText = "هاتف العميل2";
            vr.dgv_clin_dgv.Columns[7].HeaderText = " حد السحب";
            vr.dgv_clin_dgv.Columns[8].HeaderText = "نسبة الخصم";
            vr.dgv_clin_dgv.Columns[9].HeaderText = "حد الفاتورة";
            vr.dgv_clin_dgv.Columns[10].HeaderText = "كود الرصيد";
            vr.dgv_clin_dgv.Columns[11].HeaderText = "تاريخ التعامل";



            DataTable dt = new DataTable();
            dt.Columns.Add("id");
            dt.Columns.Add("name");
            dt.Rows.Add(1, "لايوجد");
            dt.Rows.Add(2, "موضف");
            dt.Rows.Add(3, "مورد");



            vr.com_link.DataSource = dt;
            vr.com_link.DisplayMember = "name";
            vr.com_link.ValueMember = "id";


            vr.ch_link_clin.Checked = false;
            vr.ch_stop_clin.Checked = false;
            //to2.Style_DataGridView(vr.dgv_clin_dgv);//دالة تنسيق الجدول

            vr.dgv_clin_dgv.ClearSelection();

            ClearData("Clien", "num_clin", vr.txt_num_clin);

        }


        public void Button8_Click_Clinte(object sender, EventArgs e)
        {
            var vr = Application.OpenForms["Main"] as Main;

            int num_clin;
            string name_clin;
            string address_clin;
            string Diosc_rate;
            string max_bill;
            string max_cloud;
            bool stop_clin;
            bool link_clin;
            string Phon_clin1;
            string Phon_clin2;
            DateTime dat_start_clin;
            //string xx;
            int Dbt_clin;
            int Crdt_clin;
            bool Add_Balance = false;

           // int cod = Convert.ToInt32(DB_Add_delete_update_.Database.ds.Tables["Clien"].Compute("max(num_clin)", "")) + 1;
          

            int cod = to.AoutoNumber("Clien", "num_clin");
            num_clin = Convert.ToInt32(cod);
            name_clin = vr.txt_name_clin.Text;
            address_clin = vr.txt_address_clin.Text;
            Diosc_rate = vr.txt_Disco_rate.Text;
            max_bill = vr.txt_max_bill.Text;
            max_cloud = vr.txt_max_cloud.Text;
            Phon_clin1 = vr.txt_phon_clin.Text == string.Empty ? "0" : vr.txt_phon_clin.Text;
            Phon_clin2 = vr.txt_phon_clin2.Text == string.Empty ? "0" : vr.txt_phon_clin2.Text;
            stop_clin = vr.ch_stop_clin.Checked == true ? true : false;
            link_clin = vr.ch_link_clin.Checked == true ? true : false;
            dat_start_clin = Convert.ToDateTime(vr.dtm_stsr_clin.Value.ToString());


            Dbt_clin = Convert.ToInt32(vr.txt_Deco_clin.Text);
            Crdt_clin = Convert.ToInt32(vr.txt_soct_clin.Text);



            int stoc_cods = to.AoutoNumber("Stock_client", "num_stok");
          //  Convert.ToInt32(DB_Add_delete_update_.Database.ds.Tables["Stock_client"].Compute("max(num_stok)", "")) + 1;
            ///////////////////////////////////
            vr.btn_add_bln_clin_btn.Click += (sende, a) =>
            {
                Add_Balance = true;
            };

           // int stoc_cods = Convert.ToInt32(DB_Add_delete_update_.Database.ds.Tables["Stock_client"].Compute("max(num_stok)", "")) + 1;

            int id_user = 1;

            DataRow dr_Emplooy = DB_Add_delete_update_.Database.ds.Tables["TB_Employees"].Rows.Find(id_user);

            string name_user = dr_Emplooy[1].ToString();

            int Id_Typ_Ac;
            string name_Typ_Accou;

            int Id = 1;
            //if (vr.com_Typ_Account.SelectedIndex == 0)
            //{
            //    Id = 1;
            //}
            //if (vr.com_Typ_Account.SelectedIndex == 1)
            //{
            //    Id = 2;
            //}
            //if (vr.com_Typ_Account.SelectedIndex == 2)
            //{
            //    Id = 3;
            //}
            ////////////////////////////////////////////////////////
            if (vr.txt_name_clin.Text.Trim() != string.Empty && vr.txt_phon_clin.Text != "0")

            {
                double sum = Crdt_clin - Dbt_clin;
                //اضافة البيانات الى الجداول
                DB_Add_delete_update_.Database.ds.Tables["Clien"].Rows.Add(cod, name_clin, address_clin, stop_clin, link_clin, Phon_clin1, Phon_clin2, max_cloud, Diosc_rate, max_bill, cod, dat_start_clin);
                DB_Add_delete_update_.Database.ds.Tables["Stock_client"].Rows.Add(cod, Crdt_clin, Dbt_clin, Add_Balance,sum);

            }
            else
            {
                ero.SetError(vr.txt_name_clin, "يرجاء ملى الحقل");
                ero.SetError(vr.txt_phon_clin, "يرجاء ملى الحقل");

                return;
            }

            DB_Add_delete_update_.Database.update("Stock_client");
            DB_Add_delete_update_.Database.update("Clien");


            int Link_cod = to.AoutoNumber("Link_supplier", "num_Link");//Convert.ToInt32(DB_Add_delete_update_.Database.ds.Tables["Link_supplier"].Compute("max(num_Link)", "")) + 1;




            if (vr.ch_link_clin.Checked == true)
            {
                int cod_link = (int)vr.com_name_link.SelectedValue;

                string tayp_link = vr.com_link.SelectedValue + "";
                string name_link = vr.com_name_link.SelectedValue.ToString();
                DB_Add_delete_update_.Database.ds.Tables["Link_supplier"].Rows.Add(Link_cod, cod_link, tayp_link, name_link, cod);
            }




            DB_Add_delete_update_.Database.update("Link_supplier");




            vr.btn_New_clin_btn.PerformClick();
            ClearData("Clien", "num_clin", vr.txt_num_clin);
        }




        public void Btn_New_Clinte_Click(object sender, EventArgs e)
        {
            var vr = Application.OpenForms["Main"] as Main;

            vr.btn_delete_clin_btn.Enabled = false;
            vr.btn_update_clin_btn.Enabled = false;
            vr.btn_add_clin_btn.Enabled = true;

            ClearData("Clien", "num_clin", vr.txt_num_clin);
        }


        public void Btn_delete_Clinte_Click(object sender, EventArgs e)
        {

            var vr = Application.OpenForms["Main"] as Main;

            if (vr.dgv_clin_dgv.CurrentRow != null)
            {

                DialogResult dr = MessageBox.Show("هل تريد بالفعل حذف الصنف المحدد", "حذف", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2);
                if (dr == DialogResult.Yes)
                {
                    int cod_clin = (int)vr.dgv_clin_dgv.CurrentRow.Cells[0].Value;
                    int cod_stoc = (int)vr.dgv_clin_dgv.CurrentRow.Cells[10].Value;

                   // int Link_cod = Convert.ToInt32(DB_Add_delete_update_.Database.ds.Tables["Link_supplier"].Compute("max(num_clin)", ""));
                    int Link_cod = to.AoutoNumber("Link_supplier", "num_Link");
                    for (int i = 1; i <= Link_cod; i++)
                    {
                        if (vr.ch_link_clin.Checked == true && cod_clin == Link_cod)
                        {
                            MessageBox.Show("تم الحذف بنجاح", cod_clin + "حذف" + Link_cod, MessageBoxButtons.OK, MessageBoxIcon.Information);

                            DB_Add_delete_update_.Database.ds.Tables["Link_supplier"].Rows.Remove(DB_Add_delete_update_.Database.ds.Tables["Link_supplier"].Rows.Find(cod_clin));

                        }

                    }

                    DB_Add_delete_update_.Database.ds.Tables["Clien"].Rows.Remove(DB_Add_delete_update_.Database.ds.Tables["Clien"].Rows.Find(cod_clin));
                    DB_Add_delete_update_.Database.ds.Tables["Stock_client"].Rows.Remove(DB_Add_delete_update_.Database.ds.Tables["Stock_client"].Rows.Find(cod_stoc));

                    MessageBox.Show("تم الحذف بنجاح", "حذف", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    new classs_table.Items_Tools().insertItem(1, "Delete_Link_clin", "@num_clin", cod_clin, SqlDbType.Int);
                    //حذف العميل 
                    new classs_table.Items_Tools().insertItem(1, "Delete_clin", "@num_clin", cod_clin, SqlDbType.Int);
                    //حذف الرصيد العميل
                    new classs_table.Items_Tools().insertItem(1, "Delete_stoc_clin", "@num_stoc", cod_stoc, SqlDbType.Int);
                }
                DB_Add_delete_update_.Database.update("Link_supplier");
                DB_Add_delete_update_.Database.update("Clien");
                DB_Add_delete_update_.Database.update("Stock_client");

            }
        }



        public void Btn_update_Clinte_Click(object sender, EventArgs e)
        {
            var vr = Application.OpenForms["Main"] as Main;

            int cod = (int)vr.dgv_clin_dgv.CurrentRow.Cells[0].Value;
            DataRow dr_clin = DB_Add_delete_update_.Database.ds.Tables["Clien"].Rows.Find(cod);


            int dr_indx = DB_Add_delete_update_.Database.ds.Tables["Clien"].Rows.IndexOf(dr_clin);

            //(cod , name_clin , address_clin , stop_clin , link_clin , Phon_clin1 , Phon_clin2, max_cloud, Diosc_rate, max_bill, stoc_cod

            DB_Add_delete_update_.Database.ds.Tables["Clien"].Rows[dr_indx][1] = vr.txt_name_clin.Text;
            DB_Add_delete_update_.Database.ds.Tables["Clien"].Rows[dr_indx][2] = vr.txt_address_clin.Text;
            DB_Add_delete_update_.Database.ds.Tables["Clien"].Rows[dr_indx][3] = vr.ch_stop_clin.Checked ? true : false;
            DB_Add_delete_update_.Database.ds.Tables["Clien"].Rows[dr_indx][4] = vr.ch_link_clin.Checked ? true : false;
            DB_Add_delete_update_.Database.ds.Tables["Clien"].Rows[dr_indx][5] = vr.txt_phon_clin.Text;
            DB_Add_delete_update_.Database.ds.Tables["Clien"].Rows[dr_indx][6] = vr.txt_phon_clin2.Text;
            DB_Add_delete_update_.Database.ds.Tables["Clien"].Rows[dr_indx][7] = vr.txt_max_cloud.Text;
            DB_Add_delete_update_.Database.ds.Tables["Clien"].Rows[dr_indx][8] = vr.txt_Disco_rate.Text;
            DB_Add_delete_update_.Database.ds.Tables["Clien"].Rows[dr_indx][9] = vr.txt_max_bill.Text;
            DB_Add_delete_update_.Database.ds.Tables["Clien"].Rows[dr_indx][11] = vr.dtm_stsr_clin.Text;

            DB_Add_delete_update_.Database.update("Clien");

            int cod_scot = (int)vr.dgv_clin_dgv.CurrentRow.Cells[10].Value;

            DataRow dr_scot_clin = DB_Add_delete_update_.Database.ds.Tables["Stock_client"].Rows.Find(cod_scot);

            int index = DB_Add_delete_update_.Database.ds.Tables["Stock_client"].Rows.IndexOf(dr_scot_clin);

            DB_Add_delete_update_.Database.ds.Tables["Stock_client"].Rows[Convert.ToInt32(index)][1] = Convert.ToInt32(vr.txt_soct_clin.Text);
            DB_Add_delete_update_.Database.ds.Tables["Stock_client"].Rows[Convert.ToInt32(index)][2] = Convert.ToInt32(vr.txt_Deco_clin.Text);

            DB_Add_delete_update_.Database.update("Stock_client");



            if (vr.ch_link_clin.Checked == false)
            {
                new classs_table.Items_Tools().insertItem(1, "Delete_Link_clin", "@num_clin", cod, SqlDbType.Int);
            }

            if (Convert.ToBoolean(vr.dgv_clin_dgv.CurrentRow.Cells[4].Value) == true)
            {
                DataRow[] dr_Link = DB_Add_delete_update_.Database.ds.Tables["Link_supplier"].Select("num_clin = " + cod);
                if (dr_Link.Count() == 0)
                {

                    int Link_cod = to.AoutoNumber("Link_supplier", "num_Link");

                    if (vr.ch_link_clin.Checked == true)
                    {
                        int cod_link2 = (int)vr.com_name_link.SelectedValue;

                        string tayp_link = vr.com_link.SelectedValue + "";
                        string name_link = vr.com_name_link.SelectedValue.ToString();
                        DB_Add_delete_update_.Database.ds.Tables["Link_supplier"].Rows.Add(Link_cod, cod_link2, tayp_link, name_link, cod);
                    }
                }
                else
                {

                    int dr_lin = DB_Add_delete_update_.Database.ds.Tables["Link_supplier"].Rows.IndexOf(dr_Link[0]);
                    int cod_link = (int)vr.com_name_link.SelectedValue;
                    DB_Add_delete_update_.Database.ds.Tables["Link_supplier"].Rows[dr_lin][1] = (int)vr.com_name_link.SelectedValue;
                    // DB_Add_delete_update_.Database.ds.Tables["Link_supplier"].Rows[dr_lin][2] = Convert.ToInt32(com_name_link.SelectedIndex);
                    DB_Add_delete_update_.Database.ds.Tables["Link_supplier"].Rows[dr_lin][2] = vr.com_link.SelectedValue;
                    DB_Add_delete_update_.Database.ds.Tables["Link_supplier"].Rows[dr_lin][3] = vr.com_name_link.SelectedValue;
                }
            }

            DB_Add_delete_update_.Database.update("Link_supplier");

            vr.btn_New_clin_btn.PerformClick();
        }



        public void Dgv_Clinte_SelectionChanged(object sender, EventArgs e)
        {
            var vr = Application.OpenForms["Main"] as Main;

            vr.btn_delete_clin_btn.Enabled = true;
            vr.btn_update_clin_btn.Enabled = true;
            vr.btn_add_clin_btn.Enabled = false;
            int id = Convert.ToInt32(vr.dgv_clin_dgv.CurrentRow.Cells[0].Value);
            object[] dr;
            dr = DB_Add_delete_update_.Database.ds.Tables["Clien"].Rows.Find(id).ItemArray;

            //(cod , name_clin , address_clin , stop_clin , link_clin , Phon_clin1 , Phon_clin2, max_cloud, Diosc_rate, max_bill, stoc_cod

            if (vr.dgv_clin_dgv.CurrentRow != null)
            {
                vr.txt_num_clin.Text = dr[0].ToString();
                vr.txt_name_clin.Text = dr[1].ToString();
                vr.txt_address_clin.Text = dr[2].ToString();
                vr.ch_stop_clin.Checked = Convert.ToBoolean(dr[3].ToString()) == true ? true : false;
                vr.ch_link_clin.Checked = Convert.ToBoolean(dr[4].ToString()) == true ? true : false;
                vr.txt_phon_clin.Text = dr[5].ToString();
                vr.txt_phon_clin2.Text = dr[6].ToString();
                vr.txt_max_cloud.Text = dr[7].ToString();
                vr.txt_Disco_rate.Text = dr[8].ToString();
                vr.txt_max_bill.Text = dr[9].ToString();
                vr.dtm_stsr_clin.Text = dr[11].ToString();           //DB_Add_delete_update_.Database.ds.Tables["Client"].Rows[dr_indx][10] = dtm_stsr_clin.Text;

                int id_stoc = Convert.ToInt32(vr.dgv_clin_dgv.CurrentRow.Cells[10].Value.ToString());
                DataRow[] dr_stoc = DB_Add_delete_update_.Database.ds.Tables["Stock_client"].Select("num_stok =" + id_stoc);

                if (dr_stoc.Count() !=0)
                {
                    vr.txt_soct_clin.Text = dr_stoc[0][1].ToString();
                    vr.txt_Deco_clin.Text = dr_stoc[0][2].ToString();

                    if (Convert.ToBoolean(dr_stoc[0][3]) != true && Convert.ToInt32(dr_stoc[0][1]) == 0 && Convert.ToInt32(dr_stoc[0][2]) == 0)
                    {
                        // vr.btn_Add_Balanc_clin.Enabled = true;
                        vr.btn_add_bln_clin_btn.Enabled = true;
                    }
                    else
                    {
                        //vr.btn_Add_Balanc_clin.Enabled = false;
                        vr.btn_add_bln_clin_btn.Enabled = false;
                    }

                }
                else
                {
                    vr.txt_soct_clin.Text = "0";//dr_stoc[0][1].ToString();
                    vr.txt_Deco_clin.Text = "0";//dr_stoc[0][2].ToString();
                }


            }

            //
            if (vr.ch_link_clin.Checked)
            {

                //DataRow[] az = DB_Add_delete_update_.Database.ds.Tables["Link_supplier"].Select("num_clin = " + id);
                //if (az.Count() != 0)
                //{

                //    if (Convert.ToInt32(az[0][2]) == 1)
                //    {
                //        vr.com_link.SelectedIndex = 0;
                //    }
                //    else if (Convert.ToInt32(az[0][2]) == 2)
                //    {
                //        vr.com_link.SelectedIndex = 1;
                //    }
                //    else if (Convert.ToInt32(az[0][2]) == 3)
                //    {
                //        vr.com_link.SelectedIndex = 2;
                //    //    int num = Convert.ToInt32(az[0][3]);
                //    //    vr.com_name_link.SelectedIndex = (num - 1);
                //    }
                //}


                ///////////////////////////////////////////////////////////////////////////////////////////////////////////////
                ///

                DataRow[] az = DB_Add_delete_update_.Database.ds.Tables["Link_supplier"].Select("id_clin = " + id);
                if (az.Count() != 0)
                {

                    if (Convert.ToInt32(az[0][2]) == 2)
                    {
                        to2.Fill_Combox(vr.com_name_link, "TB_Employees");
                        vr.com_link.SelectedValue = 2;
                        vr.com_name_link.SelectedValue = Convert.ToInt32(az[0][3]);
                    }
                    else if (Convert.ToInt32(az[0][2]) == 3)
                    {
                        to2.Fill_Combox(vr.com_name_link, "Supplier");
                        vr.com_link.SelectedValue = 3;
                        vr.com_name_link.SelectedValue = Convert.ToInt32(az[0][3]);
                        //  DataRow[] cl = DB_Add_delete_update_.Database.ds.Tables["Clien"].Select("num_clin = " + az[0][5]);
                        //  vr.com_name_link.SelectedValue = cl[0][1];
                    }
                    else if (Convert.ToInt32(az[0][2]) == 1)
                    {


                        vr.com_link.SelectedValue = 1;
                        //   vr.com_name_link.ResetText() ;
                        vr.com_name_link.Enabled = false;

                    }

                }

            }
        }


        public void Ch_link_Clinte_CheckedChanged(object sender, EventArgs e)
        {
            var vr = Application.OpenForms["Main"] as Main;

            if (vr.ch_link_clin.Checked == true)
            {
                vr.com_name_link.Enabled = true;
                vr.com_link.Enabled = true;
            }
            else
            {
                vr.com_name_link.Enabled = false;
                vr.com_link.Enabled = false;
            }
        }

    }
}
