using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Manag_ph.Client.Class_Client
{
    class Class_Blan_clin
    {
        classs_table.Items_Tools to = new classs_table.Items_Tools();

        public void Show_blnFrm_clin()
        {
            var vr = Application.OpenForms["Main"] as Main;
            //to.Style_DataGridView(vr.dgv_bln_clin_new_dgv);
            vr.nav_Bln_Clin_Show.Show();
            vr.add_client.Hide();

            //vr.navig_supplier.Hide();
            btn_baln_add_clin();
            vr.txt_Cedt_bln_clin.Text = "0";
            vr.txt_Debt_blan_clin.Text = "0";
        }

        public void Get_indexData_cl(int clin)
        {
            var vr = Application.OpenForms["Main"] as Main;
            int num_max = Convert.ToInt32(DB_Add_delete_update_.Database.ds.Tables["Clien"].Compute("max(num_clin)", "").ToString()) + 1;

            int id = Convert.ToInt32(vr.txt_num_clin.Text);

            if (num_max == id)
            {
                if (num_max >= 0 && num_max > vr.dgv_clin_dgv.Rows.Count)
                {
                    //txt_Deco_clin.
                    double sum = Convert.ToDouble(vr.txt_Deco_clin.Text) - Convert.ToDouble(vr.txt_soct_clin.Text);
                    DataRow dr_stoc = DB_Add_delete_update_.Database.ds.Tables["Stock_client"].Rows.Find(clin);
                    DataRow dr_add_bala = DB_Add_delete_update_.Database.ds.Tables["Clien"].Rows.Find(clin);
                    vr.dgv_bln_clin_new_dgv.Rows.Add(
                              clin,//Convert.ToInt32(vr.txt_num_clin.Text),
                               dr_add_bala[1], //vr.txt_name_clin.Text,
                               dr_add_bala[2],//vr.txt_address_clin.Text,
                               dr_stoc[2],  // vr.txt_Deco_clin.Text,
                               dr_stoc[1],   //  vr.txt_soct_clin.Text,
                               dr_stoc[4]
                        );
                    vr.dgv_bln_clin_new_dgv.Rows[clin].Selected = true;
                }

            }
        }


        public void selected_Row(int id, int cod)
        {
            var vr = Application.OpenForms["Main"] as Main;
            DataRow[] dr_add_calc_sup = DB_Add_delete_update_.Database.ds.Tables["Stock_client"].Select("num_stok =" + cod);

            if (id == Convert.ToInt32(dr_add_calc_sup[0][0]))
            {
                if (vr.dgv_bln_clin_new_dgv.SelectedCells.Count > 0)
                {
                    if (Convert.ToInt32(dr_add_calc_sup[0][0]) != 0)
                    {
                        if (Convert.ToInt32(vr.dgv_clin_dgv.CurrentRow.Cells[0].Value) == id)
                        {
                            //  MessageBox.Show(vr.dgv_supplier.RowCount + "");
                            int ind = vr.dgv_clin_dgv.CurrentRow.Cells[0].RowIndex;
                            vr.dgv_bln_clin_new_dgv.Rows[ind].Selected = true;
                        }
                    }
                }
            }

        }

        //public void Get_indexData_cl2()
        //{
        //    var vr = Application.OpenForms["Main"] as Main;
        //    vr.dgv_bln_clin_new_dgv.Rows.Clear();
        //    vr.txt_Cedt_bln_clin.Text = "0";
        //    vr.txt_Debt_blan_clin.Text = "0";

        //    int num_max = Convert.ToInt32(DB_Add_delete_update_.Database.ds.Tables["Clien"].Compute("max(num_clin)", "").ToString()) + 1;

        //    if (num_max >= 0 && num_max > vr.dgv_clin_dgv.Rows.Count)
        //    {
        //        double sum = Convert.ToDouble(vr.txt_Deco_clin.Text) - Convert.ToDouble(vr.txt_soct_clin.Text);
        //        vr.dgv_bln_clin_new_dgv.Rows.Add(
        //                  1,
        //                   vr.txt_name_clin.Text,
        //                   vr.txt_address_clin.Text,
        //                   vr.txt_soct_clin.Text,
        //                   vr.txt_Deco_clin.Text,
        //                   sum
        //            );
        //        vr.dgv_bln_clin_new_dgv.Rows[1].Selected = true;
        //    }

        //}




        public void btn_baln_add_clin()
        {
            var vr = Application.OpenForms["Main"] as Main;
            vr.nav_Bln_Clin_Show.Show();
            vr.add_client.Hide();
            //Show_Balanse_Frm();
            int cod = 0;
            vr.dgv_bln_clin_new_dgv.Rows.Clear();
            int num = Convert.ToInt32(vr.txt_num_clin.Text);
            int con = Convert.ToInt32(DB_Add_delete_update_.Database.ds.Tables["Clien"].Compute("count(num_clin)", "").ToString());
            MessageBox.Show(con + "");

            vr.txt_Debt_blan_clin.Text = "0";
            vr.txt_Cedt_bln_clin.Text = "0";
            for (int i = 0; i < con; i++)
            {
                if (DB_Add_delete_update_.Database.ds.Tables["Clien"].Rows[i][0] != null)
                {
                    cod = Convert.ToInt32(DB_Add_delete_update_.Database.ds.Tables["Clien"].Rows[i][0].ToString());
                    DataRow dr_add_bala = DB_Add_delete_update_.Database.ds.Tables["Clien"].Rows.Find(cod);
                    DataRow dr_Calc = DB_Add_delete_update_.Database.ds.Tables["Stock_client"].Rows.Find(cod); //Convert.ToInt32(dr_add_bala[i][6])
                    double total = Convert.ToDouble(dr_Calc[1]) + Convert.ToDouble(dr_Calc[2]);
                    vr.dgv_bln_clin_new_dgv.Rows.Add(
                     dr_add_bala[0],
                     dr_add_bala[1],
                     dr_add_bala[2],
                     dr_add_bala[5],
                     dr_Calc[2],
                     dr_Calc[1],
                     dr_Calc[4]
                     );

                    selected_Row(num, cod);
                }
                else
                {
                    MessageBox.Show("jfyrukg");
                }
            }

            int num_max = Convert.ToInt32(DB_Add_delete_update_.Database.ds.Tables["Clien"].Compute("max(num_clin)", "").ToString()) + 1;
            if (num_max == num)
            {
                Get_indexData_cl(con);
            }
        }



        public void seva_bln_clin()
        {
            var vr = Application.OpenForms["Main"] as Main;
            double sum;

            int id = Convert.ToInt32(vr.dgv_bln_clin_new_dgv.SelectedCells[0].Value);
            DataRow dr_Calc = DB_Add_delete_update_.Database.ds.Tables["Stock_client"].Rows.Find(id);
            double Deb = Convert.ToDouble(dr_Calc[1].ToString());
            double ced = Convert.ToDouble(dr_Calc[2].ToString());

            if (Convert.ToDouble(vr.txt_Cedt_bln_clin.Text) > 0 && Convert.ToDouble(vr.txt_Debt_blan_clin.Text) == 0)
            {
                if (Deb == 0 && ced >= 0)
                {
                    dr_Calc[1] = Math.Abs(ced + Convert.ToDouble(vr.txt_Cedt_bln_clin.Text));// ced + Convert.ToDouble(vr.txt_Cedt_bln_clin.Text);
                    dr_Calc[4] = Math.Abs( ced + Convert.ToDouble(vr.txt_Cedt_bln_clin.Text));
                    dr_Calc[3] = true;
                }
                else if (Deb > 0 && ced == 0 && Deb > Convert.ToDouble(vr.txt_Cedt_bln_clin.Text))
                {
                    dr_Calc[2] = Math.Abs(Deb - Convert.ToDouble(vr.txt_Cedt_bln_clin.Text));
                    dr_Calc[4] = Math.Abs(Deb - Convert.ToDouble(vr.txt_Cedt_bln_clin.Text));
                    dr_Calc[3] = true;
                }
                else if (Deb == 0 && ced >= 0 && ced < Convert.ToDouble(vr.txt_Debt_blan_clin.Text))
                {
                    dr_Calc[1] = Math.Abs(Deb - Convert.ToDouble(vr.txt_Cedt_bln_clin.Text));
                    dr_Calc[4] = Math.Abs(Deb - Convert.ToDouble(vr.txt_Cedt_bln_clin.Text));
                    dr_Calc[3] = true;
                }
            }
            else if (Convert.ToDouble(vr.txt_Cedt_bln_clin.Text) == 0 && Convert.ToDouble(vr.txt_Debt_blan_clin.Text) > 0)
            {
                if (Deb >= 0 && ced == 0)
                {
                    dr_Calc[2] = Math.Abs(Deb + Convert.ToDouble(vr.txt_Debt_blan_clin.Text));
                    dr_Calc[4] = Math.Abs(ced + Convert.ToDouble(vr.txt_Debt_blan_clin.Text));
                    dr_Calc[3] = true;

                }
                else if (Deb >= 0 && ced == 0 && Deb < Convert.ToDouble(vr.txt_Debt_blan_clin.Text))
                {
                    dr_Calc[1] = Math.Abs(ced - Convert.ToDouble(vr.txt_Debt_blan_clin.Text));
                    dr_Calc[4] = Math.Abs(ced - Convert.ToDouble(vr.txt_Debt_blan_clin.Text));
                    dr_Calc[3] = true;
                }
                else if (Deb == 0 && ced >= 0 && ced < Convert.ToDouble(vr.txt_Debt_blan_clin.Text))
                {
                    dr_Calc[2] = Math.Abs(ced - Convert.ToDouble(vr.txt_Debt_blan_clin.Text));
                    dr_Calc[4] = Math.Abs(ced - Convert.ToDouble(vr.txt_Debt_blan_clin.Text));
                    dr_Calc[3] = true;
                }
            }
            else if (Convert.ToDouble(vr.txt_Cedt_bln_clin.Text) >= 0 && Convert.ToDouble(vr.txt_Debt_blan_clin.Text) >= 0)
            {
                MessageBox.Show("عذراً \n ( عليك ادخال احد القيم( دائن او مدين ", "خطاء", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (Convert.ToDouble(vr.txt_Cedt_bln_clin.Text) == 0 && Convert.ToDouble(vr.txt_Debt_blan_clin.Text) == 0)
            {
                MessageBox.Show("عذراً \n لا يمكن ادخال قيم فارغه ", "خطاء", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }




            //    dr_Calc[1] = ced + Convert.ToDouble(vr.txt_Cedt_bln_clin.Text);
            //dr_Calc[2] = Deb + Convert.ToDouble(vr.txt_Debt_blan_clin.Text);

            //if (Convert.ToDouble(dr_Calc[1]) > Convert.ToDouble(dr_Calc[2]))
            //{
            //    double sum3 = Convert.ToDouble(dr_Calc[1]) - Convert.ToDouble(dr_Calc[2]);

            //    //  MessageBox.Show((-sum3)+"  XXXXXX " + sum3);
            //    dr_Calc[4] = (-sum3);
            //}
            //else
            //{
            //    double sum3 = Convert.ToDouble(dr_Calc[1]) - Convert.ToDouble(dr_Calc[2]);
            //    //MessageBox.Show((-sum3) + "  AAAAA " + sum3);
            //    dr_Calc[4] = sum3;
            //}



            //  dr_Calc[4] = 
            vr.dgv_bln_clin_new_dgv.SelectedCells[4].Value = dr_Calc[2];// Deb + Convert.ToDouble(vr.txt_Debt_blan_clin.Text);
            vr.dgv_bln_clin_new_dgv.SelectedCells[5].Value = dr_Calc[1];//ced + Convert.ToDouble(vr.txt_Cedt_bln_clin.Text);
            double vv = Deb + Convert.ToDouble(vr.txt_Debt_blan_clin.Text);
            vr.dgv_bln_clin_new_dgv.SelectedCells[6].Value = dr_Calc[4];//(Deb + Convert.ToDouble(vr.txt_Debt_blan_clin.Text)) - (ced + Convert.ToDouble(vr.txt_Cedt_bln_clin.Text));





            add_acon_bln_clin();

            vr.txt_Deco_clin.Text = vr.txt_Debt_blan_clin.Text;
            vr.txt_soct_clin.Text = vr.txt_Cedt_bln_clin.Text;

            vr.dgv_bln_clin_new_dgv.SelectedRows[0].Cells[0].Value = id;


            DB_Add_delete_update_.Database.update("Stock_client");
            DB_Add_delete_update_.Database.update("Clien");
            vr.txt_Debt_blan_clin.Text = "0";
            vr.txt_Cedt_bln_clin.Text = "0";
        }



        public void ch_frm_clin()
        {
            var vr = Application.OpenForms["Main"] as Main;
            int num_max = Convert.ToInt32(DB_Add_delete_update_.Database.ds.Tables["Clien"].Compute("max(num_clin)", "").ToString()) + 1;
            int num = Convert.ToInt32(vr.txt_num_clin.Text);
            int id = Convert.ToInt32(vr.dgv_bln_clin_new_dgv.SelectedCells[0].Value);
            DataRow dr_Calc = DB_Add_delete_update_.Database.ds.Tables["Stock_client"].Rows.Find(id);
            if (num == num_max)
            {

                vr.dgv_bln_clin_new_dgv.SelectedCells[4].Value = dr_Calc[2]; //Convert.ToDouble(vr.txt_Debt_blan_clin.Text);
                vr.dgv_bln_clin_new_dgv.SelectedCells[5].Value = dr_Calc[1];//Convert.ToDouble(vr.txt_Cedt_bln_clin.Text);
                vr.dgv_bln_clin_new_dgv.SelectedCells[6].Value = dr_Calc[4];//Convert.ToDouble(vr.txt_Debt_blan_clin.Text) - Convert.ToDouble(vr.txt_Cedt_bln_clin.Text);
                vr.txt_Deco_clin.Text = vr.txt_Debt_blan_clin.Text;
                vr.txt_soct_clin.Text = vr.txt_Cedt_bln_clin.Text;
            }
            else
            {
                seva_bln_clin();
                // Add_Accon();
            }
        }

        public void Dgv_bln_clin()
        {
            var vr = Application.OpenForms["Main"] as Main;
            //to.Style_DataGridView(vr.dgv_bln_clin_new_dgv);
            // int num_max = Convert.ToInt32(DB_Add_delete_update_.Database.ds.Tables["Clien"].Compute("max(num_clin)", "").ToString()) + 1;
             int num_max = to.AoutoNumber("Clien", "num_clin");
             int num = vr.txt_num_clin.Text == String.Empty ? 1 : Convert.ToInt32(vr.txt_num_clin.Text);
            //if (vr.txt_num_clin.Text  )// != Convert.ToInt32(DB_Add_delete_update_.Database.ds.Tables["Clien"].Compute("max(num_clin)", "").ToString()))
            //{

            //    num = Convert.ToInt32(vr.txt_num_clin.Text);
            //}
            //else
            //{
            //    num = 1;
            //}
            if (num == num_max)
            {
                vr.btn_save_bln_clin_btn.Enabled = true;
            }
            else
            {

                int id = Convert.ToInt32(vr.dgv_bln_clin_new_dgv.CurrentRow.Cells[0].Value.ToString());
                DataRow[] dr_Calc = DB_Add_delete_update_.Database.ds.Tables["Stock_client"].Select("num_stok =" + id);
                if (Convert.ToBoolean(dr_Calc[0][3]) != true && Convert.ToDouble(dr_Calc[0][1]) == 0 && Convert.ToDouble(dr_Calc[0][2]) == 0)
                {
                    vr.btn_save_bln_clin_btn.Enabled = true;
                }
                else
                {
                    vr.btn_save_bln_clin_btn.Enabled = false;
                }
            }
        }


        public void add_acon_bln_clin()
        {
            var vr = Application.OpenForms["Main"] as Main;
            int id = to.AoutoNumber("Clien", "num_clin");//Convert.ToInt32(DB_Add_delete_update_.Database.ds.Tables["Accounts_Clin"].Compute("max(ID_Accoun_Clin)", "").ToString()) + 1;


            int id_clin = to.AoutoNumber("Accounts_Clin", "ID_Accoun_Clin");//1;  //= Convert.ToInt32(vr.txt_num_clin.Text);
                                                              //int id;
            //if (DB_Add_delete_update_.Database.ds.Tables["Accounts_Clin"].Rows.Count != 0)
            //{
            //    id_clin = Convert.ToInt32(DB_Add_delete_update_.Database.ds.Tables["Accounts_Clin"].Compute("max(ID_Accoun_Clin)", "").ToString()) + 1;
            //}
            //else
            //{
            //    id_clin = 1;
            //}

            int id_cl = Convert.ToInt32(vr.dgv_bln_clin_new_dgv.CurrentRow.Cells[0].Value);
            DataRow dr_clin = DB_Add_delete_update_.Database.ds.Tables["Clien"].Rows.Find(id_cl);

            string name_clin = dr_clin[1].ToString();
            int id_user = 1;

            DataRow dr_Emplooy = DB_Add_delete_update_.Database.ds.Tables["TB_Employees"].Rows.Find(id_user);

            string name_Emplooy = dr_Emplooy[1].ToString();

            double Debtor = Convert.ToDouble(vr.txt_Debt_blan_clin.Text);
            double Creditor = Convert.ToDouble(vr.txt_Cedt_bln_clin.Text);
            double num = 0;
            string Type_Accon = "رصيد افتتاحي";
            DateTime date_add = DateTime.Now;

            DataRow dr_Calc = DB_Add_delete_update_.Database.ds.Tables["Stock_client"].Rows.Find(id_cl);

            if (Convert.ToDouble(vr.txt_Debt_blan_clin.Text) > 0)
            {
                num = Convert.ToDouble(vr.txt_Debt_blan_clin.Text);
            }
            else if (Convert.ToDouble(vr.txt_Cedt_bln_clin.Text) > 0)
            {
                num = Convert.ToDouble(vr.txt_Cedt_bln_clin.Text);
            }

            DB_Add_delete_update_.Database.ds.Tables["Accounts_Clin"].Rows.Add(id, id_cl, name_clin, id_user, name_Emplooy, dr_Calc[1], dr_Calc[2], Type_Accon, date_add, num);


            // List<double> Accon = Sum_Mny_Deb_clin(id, id_clin);
            //dr_Calc[1] = Accon[0];
            //dr_Calc[2] = Accon[1];


            vr.dgv_bln_clin_new_dgv.SelectedCells[4].Value = dr_Calc[2];// Accon[0];
            vr.dgv_bln_clin_new_dgv.SelectedCells[5].Value = dr_Calc[1];//Accon[1];
            vr.dgv_bln_clin_new_dgv.SelectedCells[6].Value = dr_Calc[4];//Accon[2];
            //   MessageBox.Show(Accon[1] +"      "+ Accon[2]);

            DB_Add_delete_update_.Database.update("Accounts_Clin");
            DB_Add_delete_update_.Database.update("Stock_client");
        }


        public List<double> Sum_Mny_Deb_clin(int cod, int id_sup)
        {
            List<double> numb = new List<double>();
            double debt = 0;
            double cred = 0;
            double sum = 0;

            int num = Convert.ToInt32(DB_Add_delete_update_.Database.ds.Tables["Accounts_Clin"].Compute("count(ID_Accoun_Clin)", "")) - 1;

            for (int i = 0; i <= num; i++)
            {
                int id_acou = Convert.ToInt32(DB_Add_delete_update_.Database.ds.Tables["Accounts_Clin"].Rows[i][1].ToString());
                DataRow dr_stoc = DB_Add_delete_update_.Database.ds.Tables["Stock_client"].Rows.Find(id_acou);
                MessageBox.Show(id_acou + "  %%%%%%%%%%%%%%  " + dr_stoc[0]);
                /* if (Convert.ToInt32( dr_stoc[0]) == id_acou)
                 {

                    *//* debt = 0;
                     cred = 0;
                     sum = 0;*//*
                 }*/
                if (id_sup == Convert.ToInt32(DB_Add_delete_update_.Database.ds.Tables["Accounts_Clin"].Rows[i][1].ToString()))
                {

                    debt += Convert.ToInt32(DB_Add_delete_update_.Database.ds.Tables["Accounts_Clin"].Rows[i][6].ToString());
                    cred += Convert.ToInt32(DB_Add_delete_update_.Database.ds.Tables["Accounts_Clin"].Rows[i][5].ToString());

                    dr_stoc[1] = cred;
                    dr_stoc[2] = debt;
                    sum = cred - debt;
                    numb.Add(debt);
                    numb.Add(cred);
                    numb.Add(sum);

                }


            }

            //   MessageBox.Show(sum+"    "+ cred +"  "+ debt);


            return numb;
        }



        public void pup_Data()
        {
            var vr = Application.OpenForms["Main"] as Main;
            vr.dgv_bln_clin_new_dgv.Rows.Clear();
            vr.txt_Debt_blan_clin.Text = "0";
            vr.txt_Cedt_bln_clin.Text = "0";
            int cod = 0;
            int con = Convert.ToInt32(DB_Add_delete_update_.Database.ds.Tables["Clien"].Compute("count(num_clin)", "").ToString());
            for (int i = 0; i < con; i++)
            {
                if (DB_Add_delete_update_.Database.ds.Tables["Clien"].Rows[i][0] != null)
                {
                    cod = Convert.ToInt32(DB_Add_delete_update_.Database.ds.Tables["Clien"].Rows[i][0].ToString());
                    DataRow dr_add_bala = DB_Add_delete_update_.Database.ds.Tables["Clien"].Rows.Find(cod);
                    DataRow dr_Calc = DB_Add_delete_update_.Database.ds.Tables["Stock_client"].Rows.Find(cod); //Convert.ToInt32(dr_add_bala[i][6])
                    double total = Convert.ToDouble(dr_Calc[1]) + Convert.ToDouble(dr_Calc[2]);
                    vr.dgv_bln_clin_new_dgv.Rows.Add(
                    dr_add_bala[0],
                    dr_add_bala[1],
                    dr_add_bala[2],
                    dr_add_bala[5],
                    dr_Calc[2],
                    dr_Calc[1],
                    dr_Calc[4]
                    );

                }
            }
        }

        //public void selected_Row(int id, int cod)
        //{
        //    var vr = Application.OpenForms["Main"] as Main;
        //    DataRow[] dr_add_calc_sup = DB_Add_delete_update_.Database.ds.Tables["Stock_client"].Select("num_stok =" + cod);

        //    if (id == Convert.ToInt32(dr_add_calc_sup[0][0]))
        //    {
        //        if (vr.dgv_bln_clin_new_dgv.SelectedCells.Count > 0)
        //        {
        //            if (Convert.ToInt32(dr_add_calc_sup[0][0]) != 0)
        //            {
        //                if (Convert.ToInt32(vr.dgv_clin_dgv.CurrentRow.Cells[0].Value) == id)
        //                {
        //                    int ind = vr.dgv_clin_dgv.CurrentRow.Cells[0].RowIndex;
        //                    vr.dgv_bln_clin_new_dgv.Rows[ind].Selected = true;
        //                }
        //            }
        //        }
        //    }

        //}

    }
}
