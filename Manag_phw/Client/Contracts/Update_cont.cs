//using System;
//using System.Collections.Generic;
//using System.Data;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using System.Windows.Forms;

//namespace Manag_ph.Client.Contracts
//{
//    class Update_cont
//    {
//        classs_table.Items_Tools to = new classs_table.Items_Tools();

//        public void ClearData()
//        {

//            var vr = Application.OpenForms["Main"] as Main;

//            int cod = Convert.ToInt32(DB_Add_delete_update_.Database.ds.Tables["Contracts_now"].Compute("max(num_cont)", "")) + 1;
//            vr.txt_num_up_cont.Text = Convert.ToString(cod);


//            //int number = Convert.ToInt32(DB_Add_delete_update_.Database.ds.Tables["Contracts_now"].Compute("max(num_cont)", ""));
//            //vr.txt_number_up_cont.Text = Convert.ToString(number);

//            int numb = Convert.ToInt32(DB_Add_delete_update_.Database.ds.Tables["Contracts"].Compute("count(num_clin)", "num_clin =" + cod));
//            vr.txt_number_up_cont.Text = Convert.ToString(numb);


//            vr.txt_name_up_cont.Clear();
//            vr.txt_credtor_up_cont.Text = "0";
//            vr.txt_Debtor_up_cont.Text = "0";
//            vr.txt_Totel_up_cont.Text = "0";
//            vr.txt_Disco_up_cont.Text = "0";
//            vr.txt_max_up_cont.Text = "0";

//        }
//        public void Open_Update_Contract()
//        {
//            var vr = Application.OpenForms["Main"] as Main;
//            DB_Add_delete_update_.Database.update("Contracts_now");

//            vr.View_And_serch.Hide();   //اخفاء وجهة البحث
//            vr.Add_Item.Hide();          //اخفاء وجهة الاضافه
//            vr.navig_supplier.Hide();    //فتح واجهة الموردين
//            vr.add_client.Hide();
//            vr.View_And_serch.Hide();
//            vr.nvg_search_clin.Hide();
//            vr.nvg_contracts.Hide();
//            vr.nvg_Update_cont.Show();

//            vr.dgv_Update_contar.DataSource = DB_Add_delete_update_.Database.ds.Tables["Contracts_now"];


//            vr.dgv_Update_contar.Columns[0].HeaderText = "كود العقد";
//            vr.dgv_Update_contar.Columns[1].HeaderText = "اسم العقد";
//            vr.dgv_Update_contar.Columns[2].HeaderText = "ايقاف العقد";
//            vr.dgv_Update_contar.Columns[3].HeaderText = "الحد الاقصى";
//            vr.dgv_Update_contar.Columns[4].HeaderText = "حد السحب";
//            vr.dgv_Update_contar.Columns[5].HeaderText = "عدد التأمينات";
//            vr.dgv_Update_contar.Columns[6].HeaderText = "دائن";
//            vr.dgv_Update_contar.Columns[7].HeaderText = "مدين";
//            vr.dgv_Update_contar.Columns[8].HeaderText = "اجمالي";

//            vr.btn_New_up_cont.Enabled = true;
//            vr.btn_Sav_up_con.Enabled =false;
//            vr.btn_update_up_con.Enabled = true;

//            to.Style_DataGridView(vr.dgv_Update_contar);
//            ClearData();
//        }

//        public void New_cont()
//        {
//            var vr = Application.OpenForms["Main"] as Main;

//            vr.btn_New_up_cont.Enabled = false;
//            vr.btn_Sav_up_con.Enabled = true;
//            vr.btn_update_up_con.Enabled = false;

//            ClearData();
//        }
//        ErrorProvider ero = new ErrorProvider();
//        public void Save_cont()
//        {
//            var vr = Application.OpenForms["Main"] as Main;

//            string name;
//            string max_cont;
//            string Dis_cont;
//            bool stop_cont;
//            string crid_cont;
//            string dic_cont;
//            string total;

//            int numb = Convert.ToInt32(DB_Add_delete_update_.Database.ds.Tables["Contracts_now"].Compute("max(num_cont)", ""));
//            string number = Convert.ToString(numb);


//            int cod = Convert.ToInt32(DB_Add_delete_update_.Database.ds.Tables["Contracts_now"].Compute("max(num_cont)", "")) + 1;


//            name = vr.txt_name_up_cont.Text;
//            max_cont = vr.txt_max_up_cont.Text;
//            Dis_cont = vr.txt_Disco_up_cont.Text;
//            crid_cont = vr.txt_credtor_up_cont.Text;
//            dic_cont = vr.txt_Debtor_up_cont.Text;
//            total = vr.txt_Totel_up_cont.Text;
//            stop_cont = vr.ch_stop_up_cont.Checked == true ? true : false;

//            if (vr.txt_name_up_cont.Text.Trim() != string.Empty)
//            {

//                //اضافة البيانات الى الجداول
//                DB_Add_delete_update_.Database.ds.Tables["Contracts_now"].Rows.Add(cod, name, stop_cont, max_cont, Dis_cont, number, crid_cont, dic_cont, total);

//            }
//            else
//            {
//                ero.SetError(vr.txt_name_up_cont, "يرجاء ملى الحقل");


//            }

//            DB_Add_delete_update_.Database.update("Contracts_now");
//            ClearData();
//        }

//        public void selected_Dgv()
//        {
//            var vr = Application.OpenForms["Main"] as Main;

//            vr.btn_New_up_cont.Enabled = true;
//            vr.btn_Sav_up_con.Enabled = false;
//            vr.btn_update_up_con.Enabled = true;

//            int cod = Convert.ToInt32(vr.dgv_Update_contar.CurrentRow.Cells[0].Value);

//            object []dr;
//            dr = DB_Add_delete_update_.Database.ds.Tables["Contracts_now"].Rows.Find(cod).ItemArray;

//            if (vr.dgv_Update_contar.CurrentRow != null)
//            {
//                vr.txt_num_up_cont.Text = dr[0].ToString();
//                vr.txt_name_up_cont.Text = dr[1].ToString();
//                vr.txt_max_up_cont.Text  = dr[3].ToString() ;
//                vr.txt_Disco_up_cont.Text = dr[4].ToString();
//                vr.txt_number_up_cont.Text = DB_Add_delete_update_.Database.ds.Tables["Contracts"].Compute("count(num_clin)", "num_clin =" + cod).ToString();
//                vr.txt_credtor_up_cont.Text = Sum_Mny(cod).ToString();
//                vr.txt_Debtor_up_cont.Text  = dr[7].ToString();
//                int x = Convert.ToInt32(Sum_Mny(cod)) - Convert.ToInt32(dr[7]) ;
//                vr.txt_Totel_up_cont.Text =Convert.ToString(x); 
//                vr.ch_stop_up_cont.Checked = Convert.ToBoolean(dr[2].ToString());
//            }

//         //   MessageBox.Show(Sum_Mny(cod).ToString());
          
//        }


//        public int Sum_Mny(int cod)
//        {
//            int sum = 0;
//            int num = Convert.ToInt32(DB_Add_delete_update_.Database.ds.Tables["Contracts"].Compute("count(num_cont)", ""))-1 ;

//               object []dr;
//            dr = DB_Add_delete_update_.Database.ds.Tables["Contracts_now"].Rows.Find(cod).ItemArray;

//            for (int i=0;i <= num ; i++)
//            {

//                if (cod == Convert.ToInt32(DB_Add_delete_update_.Database.ds.Tables["Contracts"].Rows[i][1].ToString()))
//                {
//                    sum += Convert.ToInt32(DB_Add_delete_update_.Database.ds.Tables["Contracts"].Rows[i][12].ToString());
//                }
//            }
            
//            return sum + Convert.ToInt32(dr[6]);
//        }


//        public void Updat_cont()
//        {
//            var vr = Application.OpenForms["Main"] as Main;

//            int cod = Convert.ToInt32(vr.dgv_Update_contar.CurrentRow.Cells[0].Value);
//            DataRow dr_cont_new = DB_Add_delete_update_.Database.ds.Tables["Contracts_now"].Rows.Find(cod);

//            int dr_indx = DB_Add_delete_update_.Database.ds.Tables["Contracts_now"].Rows.IndexOf(dr_cont_new);

//            if (vr.txt_name_up_cont.Text.Trim() != string.Empty) {
//                DB_Add_delete_update_.Database.ds.Tables["Contracts_now"].Rows[dr_indx][1] = vr.txt_name_up_cont.Text;
//                DB_Add_delete_update_.Database.ds.Tables["Contracts_now"].Rows[dr_indx][2] = vr.ch_stop_up_cont.Checked == true ? true : false;
//                DB_Add_delete_update_.Database.ds.Tables["Contracts_now"].Rows[dr_indx][3] = vr.txt_max_up_cont.Text;
//                DB_Add_delete_update_.Database.ds.Tables["Contracts_now"].Rows[dr_indx][4] = vr.txt_Disco_up_cont.Text;
//                DB_Add_delete_update_.Database.ds.Tables["Contracts_now"].Rows[dr_indx][5] = DB_Add_delete_update_.Database.ds.Tables["Contracts"].Compute("count(num_clin)", "num_clin =" + cod).ToString(); 
//                DB_Add_delete_update_.Database.ds.Tables["Contracts_now"].Rows[dr_indx][6] = vr.txt_credtor_up_cont.Text;
//                DB_Add_delete_update_.Database.ds.Tables["Contracts_now"].Rows[dr_indx][7] =  vr.txt_Debtor_up_cont.Text;
//                DB_Add_delete_update_.Database.ds.Tables["Contracts_now"].Rows[dr_indx][8] = vr.txt_Totel_up_cont.Text;                   // Sum_Mny(cod).ToString(); 

//            }

//            DB_Add_delete_update_.Database.update("Contracts_now");


//            int num = Convert.ToInt32(DB_Add_delete_update_.Database.ds.Tables["Contracts"].Compute("count(num_cont)", ""))-1 ;
//            for (int i =0;i<=num;i++) {
//                if (cod == Convert.ToInt32(DB_Add_delete_update_.Database.ds.Tables["Contracts"].Rows[i][1].ToString())) {

//                    DB_Add_delete_update_.Database.ds.Tables["Contracts"].Rows[i][2] =  DB_Add_delete_update_.Database.ds.Tables["Contracts_now"].Rows[dr_indx][1].ToString();
//                }
//                DB_Add_delete_update_.Database.update("Contracts");
//            }

//        }
//    }


//}
