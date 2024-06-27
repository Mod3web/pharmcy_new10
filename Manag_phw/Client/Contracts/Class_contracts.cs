using System;
using System.Data;
using System.Windows.Forms;

namespace Manag_ph.Client.Contracts
{
    class Class_contracts
    {
        ErrorProvider ero = new ErrorProvider();
        classs_table.Items_Tools to2 = new classs_table.Items_Tools();

        public void ClearData(string name_Table, string name_column_ID, TextBox name_text)
        {

            var vr = Application.OpenForms["Main"] as Main;

            int numItem = Convert.ToInt32(DB_Add_delete_update_.Database.ds.Tables[name_Table].Compute("count(" + name_column_ID + ")", "")) + 1;
            name_text.Text = numItem.ToString();


            int numb = Convert.ToInt32(DB_Add_delete_update_.Database.ds.Tables["Clients_And_Contracts"].Compute("count(num_cont)", "num_cont =" + numItem));
            vr.txt_num_cont.Text = Convert.ToString(numb);

            //txt_geiv_clin.Clear();
            vr.ch_after_printing_cont.Checked = false;
            vr.ch_before_printing_cont.Checked = true;
            vr.rid_company.Checked = true;
            vr.rid_clin.Checked = false;
            vr.txt_name_cont.Clear();
           // vr.txt_num_cont.Clear();
            vr.txt_max_cloud_cont.Text = "0";
            vr.txt_max_bill_cont.Text = "0";
            vr.txt_Dise_rate_cont.Text = "0";
            vr.txt_Total_cont.Text = "0";

            //vr.btn_Show_Discount_frm.Enabled = true;
        }

        public void Open_Contract()
        {

            var vr = Application.OpenForms["Main"] as Main;

            //vr.View_And_serch.Hide();   //اخفاء وجهة البحث
            //vr.Add_Item.Hide();          //اخفاء وجهة الاضافه
            //vr.navig_supplier.Hide();    //فتح واجهة الموردين
            //vr.add_client.Hide();
            //vr.View_And_serch.Hide();
            //vr.nvg_search_clin.Hide();
            //vr.nvg_contracts.Show();


            vr.dgv_cont_show_dgv.DataSource = DB_Add_delete_update_.Database.ds.Tables["Contracts"];
            // vr.dgv_clin_And_cont.DataSource = DB_Add_delete_update_.Database.ds.Tables["Clients_And_Contracts"].;
            vr.dgv_cont_show_dgv.ClearSelection();
            //  vr.dgv_clin_And_cont.ClearSelection();


            // cod, num_clin, name_clin, name_cont, number_cont, stop_cont, max_coul_cont, Diosc_rate, max_bill, Dise_bill_clin, printing_bill, Applic_Dise);

            vr.dgv_cont_show_dgv.Columns[0].HeaderText = "كود العقد";
            vr.dgv_cont_show_dgv.Columns[1].HeaderText = "رقم العميل";
            vr.dgv_cont_show_dgv.Columns[2].HeaderText = "اسم العميل";
            vr.dgv_cont_show_dgv.Columns[3].HeaderText = "اسم العقد";
            vr.dgv_cont_show_dgv.Columns[4].HeaderText = "عدد العملاء";
            vr.dgv_cont_show_dgv.Columns[5].HeaderText = "ايقاف العقد";
            vr.dgv_cont_show_dgv.Columns[6].HeaderText = " حد السحب";
            vr.dgv_cont_show_dgv.Columns[7].HeaderText = "الخصم";
            vr.dgv_cont_show_dgv.Columns[8].HeaderText = " حد الفاتورة";
            vr.dgv_cont_show_dgv.Columns[9].HeaderText = "نسبة دفع العميل";
            vr.dgv_cont_show_dgv.Columns[10].HeaderText = "تطبيق خصم الفاتوره";
            vr.dgv_cont_show_dgv.Columns[11].HeaderText = "تطبيق الخصم على";
            vr.dgv_cont_show_dgv.Columns[12].HeaderText = "الاجمالي ";


            vr.dgv_clin_And_cont_dgv.Columns[0].HeaderText = "كود عقد العميل";
            vr.dgv_clin_And_cont_dgv.Columns[1].HeaderText = "رقم العقد";
            vr.dgv_clin_And_cont_dgv.Columns[2].HeaderText = "رقم العميل";
            vr.dgv_clin_And_cont_dgv.Columns[3].HeaderText = "اسم العميل";
            vr.dgv_clin_And_cont_dgv.Columns[4].HeaderText = " ايقاف عقد عميل";
            vr.dgv_clin_And_cont_dgv.Columns[5].HeaderText = "عنوان العميل";
            vr.dgv_clin_And_cont_dgv.Columns[6].HeaderText = "هاتف العميل";
            vr.dgv_clin_And_cont_dgv.Columns[7].HeaderText = "حساب العميل";

            vr.txt_geiv_clin.Clear();
            vr.btn_delete_cont_btn.Enabled = true;
            vr.btn_Save_cont_btn.Enabled = false;
            vr.btn_updete_cont_btn.Enabled = true;

            //to2.Style_DataGridView(vr.dgv_cont_show);//دالة تنسيق الجدول
            //to2.Style_DataGridView(vr.dgv_clin_And_cont);//دالة تنسيق الجدول

            ClearData("Contracts", "num_cont", vr.txt_num_clin);
        }
        // Client.Contracts. cc = new Contracts.fro_contra_and_clin();
        //forms.fro_contra_and_clin fr_cont = new forms.fro_contra_and_clin();

        //public TextBox txt_eee;
        //فتح واجهة اختيار العميل لعمل عقد
        public void TextBox3_DoubleClick()
        {
            var vr = Application.OpenForms["Main"] as Main;

            // txt_geiv_clin.Clear();
            vr.txt_geiv_clin.Focus();

            // fr_cont.ShowDialog();
            new Client.Contracts.from_contra.Add_cont_frm().ShowDialog();

            vr.btn_delete_cont_btn.Enabled = false;
            vr.btn_Save_cont_btn.Enabled = true;
            vr.btn_updete_cont_btn.Enabled = false;

            ClearData("Contracts", "num_cont", vr.txt_num_clin);
        }


        // public int num_cont = 0;
        // فتح واجهة اضافة عملاء لعقد
        public void Button9_Click()
        {
            //string name_cont= "" ;
            var vr = Application.OpenForms["Main"] as Main;

            if (vr.dgv_cont_show_dgv.CurrentRow != null)
            {
                if (Convert.ToBoolean(vr.dgv_cont_show_dgv.CurrentRow.Cells[5].Value) != true)
                {
                    // name_cont = dgv_cont_show.CurrentRow.Cells[1].Value.ToString();
                    vr.num_cont = Convert.ToInt32(vr.dgv_cont_show_dgv.CurrentRow.Cells[0].Value);

                    //fr_cont.ShowDialog();
                    DB_Add_delete_update_.Database.update("Clien");

                }
                else
                {
                    MessageBox.Show("هذاء العقد موقف ");
                }
            }
        }


        int xxnum_clin;
        // تعديل عقد 
        public void Button13_Click()
        {
            var vr = Application.OpenForms["Main"] as Main;


            string Applic_Dise = "";
            string printing_bill = "";



            if (vr.rid_company.Checked == true)
            {
                Applic_Dise = "الشركه";
            }


            if (vr.rid_clin.Checked == true)
            {
                Applic_Dise = "العميل";
            }
            /////////////////////////////////////

            if (vr.ch_before_printing_cont.Checked == true)
            {
                printing_bill = "قبل الطباعه";
            }


            if (vr.ch_after_printing_cont.Checked == true)
            {
                printing_bill = "بعد الطباعه";
            }
            int cod = (int)vr.dgv_cont_show_dgv.CurrentRow.Cells[0].Value;
            DataRow dr_clin = DB_Add_delete_update_.Database.ds.Tables["Contracts"].Rows.Find(cod);

            int dr_indx = DB_Add_delete_update_.Database.ds.Tables["Contracts"].Rows.IndexOf(dr_clin);

            DataRow[] dr_cl = DB_Add_delete_update_.Database.ds.Tables["Clien"].Select("Disco_rate =" + dr_indx);
           

            DataRow[] dr_con = DB_Add_delete_update_.Database.ds.Tables["Clients_And_Contracts"].Select("num_cont =" + cod);

            int numb = Convert.ToInt32(DB_Add_delete_update_.Database.ds.Tables["Clients_And_Contracts"].Compute("count( num_cont)", "num_cont =" + cod));


            DB_Add_delete_update_.Database.ds.Tables["Contracts"].Rows[dr_indx][1] = Convert.ToInt32(xxnum_clin);
            DB_Add_delete_update_.Database.ds.Tables["Contracts"].Rows[dr_indx][2] = vr.txt_geiv_clin.Text;
            DB_Add_delete_update_.Database.ds.Tables["Contracts"].Rows[dr_indx][3] = vr.txt_name_cont.Text;
            DB_Add_delete_update_.Database.ds.Tables["Contracts"].Rows[dr_indx][4] = Convert.ToInt32(numb);
            DB_Add_delete_update_.Database.ds.Tables["Contracts"].Rows[dr_indx][5] = vr.ch_Pios_or_not_cont.Checked ? true : false;
            DB_Add_delete_update_.Database.ds.Tables["Contracts"].Rows[dr_indx][6] = vr.txt_max_cloud_cont.Text;
            DB_Add_delete_update_.Database.ds.Tables["Contracts"].Rows[dr_indx][7] = Convert.ToInt32(vr.txt_Dise_rate_cont.Text);
            DB_Add_delete_update_.Database.ds.Tables["Contracts"].Rows[dr_indx][8] = Convert.ToInt32(vr.txt_max_bill_cont.Text);
            DB_Add_delete_update_.Database.ds.Tables["Contracts"].Rows[dr_indx][9] = Convert.ToInt32(vr.txt_Dise_bill_clin.Text); 
            DB_Add_delete_update_.Database.ds.Tables["Contracts"].Rows[dr_indx][10] = printing_bill;
            DB_Add_delete_update_.Database.ds.Tables["Contracts"].Rows[dr_indx][11] = Applic_Dise;
            DB_Add_delete_update_.Database.ds.Tables["Contracts"].Rows[dr_indx][12] = Sum_Mny(cod);

            //dr_cl[dr_indx][8] = Convert.ToInt32(vr.txt_Dise_rate_cont.Text);

            DB_Add_delete_update_.Database.update("Contracts");
            DB_Add_delete_update_.Database.update("Clien");
            DB_Add_delete_update_.Database.update("Clients_And_Contracts");


            Sum_Account(xxnum_clin);


        }

       //داله جمع حساب العملا لعقد
        public void Sum_Account(int num_cont )
        {
            int num = Convert.ToInt32(DB_Add_delete_update_.Database.ds.Tables["Contracts"].Compute("count(num_cont)", "")) - 1;
            int sum = 0;
            for (int i = 0; i <= num; i++)
            {
                if (Convert.ToInt32(DB_Add_delete_update_.Database.ds.Tables["Contracts_now"].Rows[num_cont-1][0].ToString()) == Convert.ToInt32(DB_Add_delete_update_.Database.ds.Tables["Contracts"].Rows[i][1]))
                {
                    sum += Convert.ToInt32(DB_Add_delete_update_.Database.ds.Tables["Contracts"].Rows[i][12]);
                    DB_Add_delete_update_.Database.ds.Tables["Contracts_now"].Rows[num_cont-1][8] = Convert.ToString(sum);
                }
                DB_Add_delete_update_.Database.update("Contracts_now");
            }
        }


        // اضافة عقد جديد
        public void Add_Contract()
        {

            var vr = Application.OpenForms["Main"] as Main;

            //int num_cli = int_num();

            string name_clin;
            int num_clin;
            string name_cont;
            int number_cont;
            int max_coul_cont;
            bool stop_cont;
            string printing_bill = "";
            int Diosc_rate;
            int max_bill;
            string Applic_Dise = "";
            int Dise_bill_clin;
            string total;


            if (vr.rid_company.Checked == true)
            {
                Applic_Dise = "الشركه";
            }


            if (vr.rid_clin.Checked == true)
            {
                Applic_Dise = "العميل";
            }
            /////////////////////////////////////

            if (vr.ch_before_printing_cont.Checked == true)
            {
                printing_bill = "قبل الطباعه";
            }


            if (vr.ch_after_printing_cont.Checked == true)
            {
                printing_bill = "بعد الطباعه";
            }

            TextBox str = new TextBox();
            int cod = Convert.ToInt32(DB_Add_delete_update_.Database.ds.Tables["Contracts"].Compute("max(num_cont)", ""))+1 ;

            int numb = Convert.ToInt32(DB_Add_delete_update_.Database.ds.Tables["Clients_And_Contracts"].Compute("count(num_cont)", "num_cont =" + cod));

            name_clin = vr.txt_geiv_clin.Text;
            num_clin = vr.num_cli;
            name_cont = vr.txt_name_cont.Text;
            number_cont = numb;
            max_coul_cont = Convert.ToInt32(vr.txt_max_cloud_cont.Text);
            max_bill = Convert.ToInt32(vr.txt_max_bill_cont.Text);
            Diosc_rate = Convert.ToInt32(vr.txt_Dise_rate_cont.Text);
            Dise_bill_clin = Convert.ToInt32(vr.txt_Dise_bill_clin.Text);
            total = vr.txt_Total_cont.Text;

            stop_cont = vr.ch_Pios_or_not_cont.Checked == true ? true : false;
            //////////////////////////////////////////////////####################################


            if (vr.txt_geiv_clin.Text.Trim() != string.Empty || vr.txt_name_cont.Text.Trim() != string.Empty)
            {

                //اضافة البيانات الى الجداول
                DB_Add_delete_update_.Database.ds.Tables["Contracts"].Rows.Add(cod, num_clin, name_clin, name_cont, number_cont, stop_cont, max_coul_cont, Diosc_rate, max_bill, Dise_bill_clin, printing_bill, Applic_Dise ,total);

            }
            else
            {
                ero.SetError(vr.txt_geiv_clin, "يرجاء ملى الحقل");
                ero.SetError(vr.txt_name_cont, "يرجاء ملى الحقل");


            }

            DB_Add_delete_update_.Database.update("Contracts");




            // txt_geiv_clin.PerformLayout()
            ClearData("Contracts", "num_cont", str);
        }

        public void Txt_Dise_rate_cont_TextChanged()
        {
            var vr = Application.OpenForms["Main"] as Main;
            //if (vr.txt_Dise_rate_cont.Text != string.Empty)
            //{
            //    int num = Convert.ToInt32(vr.txt_Dise_rate_cont.Text);


            //    if (vr.rid_company.Checked)
            //    {
            //        // rid_clin.Checked = false;
            //        vr.txt_Dise_bill_clin.Text = (100 - num).ToString();
            //    }


            //    if (vr.rid_clin.Checked)
            //    {
            //        //rid_company.Checked = false;
            //        vr.txt_Dise_bill_clin.Text = num.ToString();
            //    }
            //}


        }

        public int Sum_Mny(int cod)
        {
            int sum = 0;
            int num = Convert.ToInt32(DB_Add_delete_update_.Database.ds.Tables["Clients_And_Contracts"].Compute("count(num_cont)", "")) - 1;
            for (int i = 0; i <= num; i++)
            {

                if (cod == Convert.ToInt32(DB_Add_delete_update_.Database.ds.Tables["Clients_And_Contracts"].Rows[i][1].ToString()))
                {
                    sum += Convert.ToInt32(DB_Add_delete_update_.Database.ds.Tables["Clients_And_Contracts"].Rows[i][7].ToString());
                }
            }

            return sum;
        }

        public void Dgv_cont_show_SelectionChanged()
        {
            var vr = Application.OpenForms["Main"] as Main;
            vr.btn_delete_cont_btn.Enabled = true;
            vr.btn_Save_cont_btn.Enabled = false;
            vr.btn_updete_cont_btn.Enabled = true;
            //vr.btn_Show_Discount_frm.Enabled = false;

            int id = Convert.ToInt32(vr.dgv_cont_show_dgv.CurrentRow.Cells[0].Value);
            object[] dr;
            dr = DB_Add_delete_update_.Database.ds.Tables["Contracts"].Rows.Find(id).ItemArray;

            //cod, num_clin, name_clin, name_cont, number_cont, stop_cont, max_coul_cont, Diosc_rate, max_bill, Dise_bill_clin, printing_bill, Applic_Dise
            int cod = Convert.ToInt32(DB_Add_delete_update_.Database.ds.Tables["Clients_And_Contracts"].Compute("max(num_Clin_cont)", "")) + 1;

            int numb = Convert.ToInt32(DB_Add_delete_update_.Database.ds.Tables["Clients_And_Contracts"].Compute("count(num_cont)", "num_cont =" + id));

            if (vr.dgv_cont_show_dgv.CurrentRow != null)
            {
                //txt_num_clin.Text = dr[0].ToString();
                xxnum_clin = Convert.ToInt32(dr[1].ToString());
                vr.txt_geiv_clin.Text = dr[2].ToString();
                vr.txt_name_cont.Text = dr[3].ToString();
                vr.txt_num_cont.Text = numb.ToString();

                vr.ch_Pios_or_not_cont.Checked = Convert.ToBoolean(dr[5].ToString()) == true ? true : false;
                vr.txt_max_cloud_cont.Text = dr[6].ToString();
                vr.txt_Dise_rate_cont.Text = dr[7].ToString();
                vr.txt_max_bill_cont.Text = dr[8].ToString();
                vr.txt_Dise_bill_clin.Text = dr[9].ToString();
                vr.txt_Total_cont.Text = Sum_Mny(id).ToString();
                string str = dr[10].ToString();
                string str2 = dr[11].ToString();


                if (vr.ch_before_printing_cont.Text == dr[10].ToString())
                {
                    vr.ch_before_printing_cont.Checked = true;
                    vr.ch_after_printing_cont.Checked = false;
                }
                if (vr.ch_after_printing_cont.Text == dr[10].ToString())
                {
                    vr.ch_after_printing_cont.Checked = true;
                    vr.ch_before_printing_cont.Checked = false;
                }
                ///////////////////////////////////////////////////

                if (vr.rid_company.Text == dr[11].ToString())
                {
                    vr.rid_company.Checked = true;
                    //  rid_clin.Checked = false;
                }
                if (vr.rid_clin.Text == dr[11].ToString())
                {
                    vr.rid_clin.Checked = true;
                    // rid_company.Checked = false;
                }

               // object zz = Convert.ToInt32(dr[0].ToString());

               // vr.dgv_clin_And_cont.DataSource = DB_Add_delete_update_.Database.ds.Tables["Clients_And_Contracts"].Select("num_cont = " + id);

                DataView dv = new DataView(DB_Add_delete_update_.Database.ds.Tables["Clients_And_Contracts"]);

                dv.RowFilter = "num_cont = " + id;

                vr.dgv_clin_And_cont_dgv.DataSource = dv;

                vr.dgv_clin_And_cont_dgv.Columns[0].HeaderText = "كود عقد العميل";
                vr.dgv_clin_And_cont_dgv.Columns[1].HeaderText = "رقم العقد";
                vr.dgv_clin_And_cont_dgv.Columns[2].HeaderText = "رقم العميل";
                vr.dgv_clin_And_cont_dgv.Columns[3].HeaderText = "اسم العميل";
                vr.dgv_clin_And_cont_dgv.Columns[4].HeaderText = " ايقاف عقد عميل";
                vr.dgv_clin_And_cont_dgv.Columns[5].HeaderText = "عنوان العميل";
                vr.dgv_clin_And_cont_dgv.Columns[6].HeaderText = "هاتف العميل";
                vr.dgv_clin_And_cont_dgv.Columns[7].HeaderText = "حساب العميل";

            }
        }

        public void Btn_delete_cont_Click()
        {
            var vr = Application.OpenForms["Main"] as Main;

            if (vr.dgv_cont_show_dgv.CurrentRow != null)
            {
                DialogResult dr = MessageBox.Show("هل تريد بالفعل حذف الصنف المحدد", "حذف", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2);
                if (dr == DialogResult.Yes)
                {
                    int id = (int)vr.dgv_cont_show_dgv.CurrentRow.Cells[0].Value;
                    bool b = true;
                    if (b != Convert.ToBoolean(vr.dgv_cont_show_dgv.CurrentRow.Cells[5].Value))
                    {
                        DB_Add_delete_update_.Database.ds.Tables["Contracts"].Rows.Remove(DB_Add_delete_update_.Database.ds.Tables["Contracts"].Rows.Find(id));

                        MessageBox.Show("تم الحذف بنجاح", "حذف", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        new classs_table.Items_Tools().insertItem(1, "Delete_clin_contracts", "@num_cont", id, SqlDbType.Int);
                    }
                    else
                    {
                        MessageBox.Show("العميل موقف  يرجا اتاكد من حسابه اولا");
                    }

                }
                DB_Add_delete_update_.Database.update("Contracts");

            }
        }

        public void Button10_Click_1()
        {
            var vr = Application.OpenForms["Main"] as Main;

            int id = (int)vr.dgv_clin_And_cont_dgv.CurrentRow.Cells[0].Value;
            bool b = true;
            int num_clin = (int)vr.dgv_clin_And_cont_dgv.CurrentRow.Cells[2].Value;
            DataRow dr_clin = DB_Add_delete_update_.Database.ds.Tables["Clien"].Rows.Find(num_clin);
            int dr_indx = DB_Add_delete_update_.Database.ds.Tables["Clien"].Rows.IndexOf(dr_clin);

           
            if (vr.dgv_clin_And_cont_dgv.CurrentRow != null)
            {
                DialogResult dr = MessageBox.Show("هل تريد بالفعل حذف الصنف المحدد", "حذف", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2);
                if (dr == DialogResult.Yes)
                {

                    if (b != Convert.ToBoolean(vr.dgv_clin_And_cont_dgv.CurrentRow.Cells[4].Value))
                    {
                        if (Convert.ToInt32(vr.dgv_clin_And_cont_dgv.CurrentRow.Cells[7].Value) == 0) {
                            DB_Add_delete_update_.Database.ds.Tables["Clients_And_Contracts"].Rows.Remove(DB_Add_delete_update_.Database.ds.Tables["Clients_And_Contracts"].Rows.Find(id));

                            MessageBox.Show("تم الحذف بنجاح", "حذف", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            new classs_table.Items_Tools().insertItem(1, "Delete_clin_And_contracts", "@num_clin_cont", id, SqlDbType.Int);

                            DB_Add_delete_update_.Database.ds.Tables["Clien"].Rows[dr_indx][8] = "0";
                        }
                        else
                        {
                            MessageBox.Show(vr.dgv_clin_And_cont_dgv.CurrentRow.Cells[7].Value + "المتبقي من حساب العميل هو");

                        }
                    }
                    else
                    {
                        MessageBox.Show("العميل موقف  يرجا اتاكد من حسابه اولااو قد يكون حسابه غير مصفر");
                    }
                }
                DB_Add_delete_update_.Database.update("Clients_And_Contracts");
                DB_Add_delete_update_.Database.update("Clien");

            }
        }


        public void Button11_Click()
        {
            var vr = Application.OpenForms["Main"] as Main;

            int cod = (int)vr.dgv_clin_And_cont_dgv.CurrentRow.Cells[0].Value;
            DataRow dr_clin = DB_Add_delete_update_.Database.ds.Tables["Clients_And_Contracts"].Rows.Find(cod);


            int dr_indx = DB_Add_delete_update_.Database.ds.Tables["Clients_And_Contracts"].Rows.IndexOf(dr_clin);

            //cod, num_clin, name_clin, name_cont, number_cont, stop_cont, max_coul_cont, Diosc_rate, max_bill, Dise_bill_clin, printing_bill, Applic_Dise
            bool bo = true;//Convert.ToBoolean(dgv_clin_And_cont.CurrentRow.Cells[4].Value);

            if (bo == Convert.ToBoolean(vr.dgv_clin_And_cont_dgv.CurrentRow.Cells[4].Value))
            {
                DB_Add_delete_update_.Database.ds.Tables["Clients_And_Contracts"].Rows[dr_indx][4] = false;

            }
            else
            {
                DB_Add_delete_update_.Database.ds.Tables["Clients_And_Contracts"].Rows[dr_indx][4] = bo;

            }
        }

        public void Rid_clin_CheckedChanged()
        {
            var vr = Application.OpenForms["Main"] as Main;

            int num = Convert.ToInt32(vr.txt_Dise_rate_cont.Text);

            if (vr.rid_clin.Checked == true)
            {
                //rid_company.Checked = false;
                vr.txt_Dise_bill_clin.Text = num.ToString();
            }
            else
            {
                vr.txt_Dise_bill_clin.Text = (100 - num).ToString();
            }
        }

        public void Open_form_Discount()
        {
            Discount_cont_frm fr = new Discount_cont_frm();

            fr.ShowDialog();

            
        }
    }
}
