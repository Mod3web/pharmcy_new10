using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace Manag_ph.Supplier.supplier
{
    class Balanse
    {



        classs_table.Items_Tools to = new classs_table.Items_Tools();

        public void Show_Balanse_Frm()
        {
            var vr = Application.OpenForms["Main"] as Main;
            //to.Style_DataGridView(vr.dgv_Balanse_Add_sup_dgv);
            vr.nav_Balance_supp.Show();
            vr.navig_supplire.Hide();
            btn_Balance_Add();
            vr.txt_Creditor_sup.Text = "0";
            vr.txt_Debtor_sup.Text = "0";
        }

        public void Dgv_bln_clin()
        {
            var vr = Application.OpenForms["Main"] as Main;
            //to.Style_DataGridView(vr.dgv_bln_clin_new_dgv);
            int num_max = Convert.ToInt32(DB_Add_delete_update_.Database.ds.Tables["Supplier"].Compute("max(num_supp)", "").ToString()) + 1;

            int num = vr.txt_num_supp.Text == String.Empty ? 1 : Convert.ToInt32(vr.txt_num_supp.Text);
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
                vr.btn_Save_Blance_btn.Enabled = true;
            }
            else
            {

                int id = Convert.ToInt32(vr.dgv_Balanse_Add_sup_dgv.CurrentRow.Cells[0].Value.ToString());
                DataRow[] dr_Calc = DB_Add_delete_update_.Database.ds.Tables["Calc_supply"].Select("num_calc =" + id);
                if (Convert.ToBoolean(dr_Calc[0][4]) != true && Convert.ToDouble(dr_Calc[0][1]) == 0 && Convert.ToDouble(dr_Calc[0][2]) == 0)
                {
                    vr.btn_Save_Blance_btn.Enabled = true;
                }
                else
                {
                    vr.btn_Save_Blance_btn.Enabled = false;
                }
            }
        }

        public void Get_IndexDatagrid(int cont)
        {
            var vr = Application.OpenForms["Main"] as Main;
            int num_max = to.AoutoNumber("Supplier", "num_supp");
            //if (DB_Add_delete_update_.Database.ds.Tables["Supplier"].Rows.Count != 0)
            //{
            //    num_max = Convert.ToInt32(DB_Add_delete_update_.Database.ds.Tables["Supplier"].Compute("max(num_supp)", "").ToString()) + 1;
            //}
            //else
            //{
            //    num_max = 1;
            //}
            int id = Convert.ToInt32(vr.txt_num_supp.Text);

            if (num_max >= 0 && num_max > vr.dgv_supplier_dgv.Rows.Count)
            {

                DataRow dr_add_bala = DB_Add_delete_update_.Database.ds.Tables["Supplier"].Rows.Find(id);
                DataRow dr_add_calc_sup = DB_Add_delete_update_.Database.ds.Tables["Calc_supply"].Rows.Find(id);

                double sum = Convert.ToDouble(dr_add_calc_sup[1]) - Convert.ToDouble(dr_add_calc_sup[2]);
                vr.dgv_Balanse_Add_sup_dgv.Rows.Add(
                            cont,
                            dr_add_bala[1],
                            dr_add_bala[2],
                            dr_add_calc_sup[2],
                            dr_add_calc_sup[1],
                           dr_add_calc_sup[3]);

                vr.dgv_Balanse_Add_sup_dgv.Rows[cont].Selected = true;
            }
        }

        public void Get_IndexDatagrid2()
        {
            var vr = Application.OpenForms["Main"] as Main;
            vr.txt_Debtor_sup.Text = "0";
            vr.txt_Creditor_sup.Text = "0";
            vr.dgv_Balanse_Add_sup_dgv.Rows.Clear();
            int cod = 0;
            int con = Convert.ToInt32(DB_Add_delete_update_.Database.ds.Tables["Supplier"].Compute("count(num_supp)", "").ToString());
            for (int i = 0; i < con; i++)
            {
                if (DB_Add_delete_update_.Database.ds.Tables["Supplier"].Rows[i][0] != null)
                {
                    cod = Convert.ToInt32(DB_Add_delete_update_.Database.ds.Tables["Supplier"].Rows[i][0].ToString());
                    DataRow dr_add_bala = DB_Add_delete_update_.Database.ds.Tables["Supplier"].Rows.Find(cod);
                    DataRow dr_Calc = DB_Add_delete_update_.Database.ds.Tables["Calc_supply"].Rows.Find(cod); //Convert.ToInt32(dr_add_bala[i][6])
                    double total = Convert.ToDouble(dr_Calc[1]) + Convert.ToDouble(dr_Calc[2]);
                    vr.dgv_Balanse_Add_sup_dgv.Rows.Add(
                     dr_add_bala[0],
                     dr_add_bala[1],
                     dr_add_bala[2],
                     dr_add_bala[7],
                     dr_Calc[2],
                     dr_Calc[1],
                     dr_Calc[3]
                     );

                }
            }


        }

        public void select_Row(int id, int cod)
        {
            var vr = Application.OpenForms["Main"] as Main;
            DataRow[] dr_add_calc_sup = DB_Add_delete_update_.Database.ds.Tables["Calc_supply"].Select("num_calc =" + cod);

            if (id == Convert.ToInt32(dr_add_calc_sup[0][0]))
            {
                if (vr.dgv_Balanse_Add_sup_dgv.SelectedCells.Count > 0)
                {
                    if (Convert.ToInt32(dr_add_calc_sup[0][0]) != 0)
                    {
                        if (Convert.ToInt32(vr.dgv_supplier_dgv.CurrentRow.Cells[0].Value) == id)
                        {
                            //  MessageBox.Show(vr.dgv_supplier.RowCount + "");
                            int ind = vr.dgv_supplier_dgv.CurrentRow.Cells[0].RowIndex;
                            vr.dgv_Balanse_Add_sup_dgv.Rows[ind].Selected = true;
                        }
                    }
                }
            }
        }

        public void btn_Balance_Add()
        {
            var vr = Application.OpenForms["Main"] as Main;
            vr.navig_supplire.Hide();
            vr.nav_Balance_supp.Show();
            int cod = 0;
            vr.dgv_Balanse_Add_sup_dgv.Rows.Clear();

            int num = vr.txt_num_supp.Text == String.Empty ? 1 : Convert.ToInt32(vr.txt_num_supp.Text);
            ////int num = 0;
            //if (Convert.ToInt32(vr.txt_num_supp.Text) != Convert.ToInt32(DB_Add_delete_update_.Database.ds.Tables["Supplier"].Compute("max(num_supp)", "").ToString()))
            //{

            //    num = Convert.ToInt32(vr.txt_num_supp.Text);
            //}
            //else
            //{
            //    num = 1;
            //}

            int con = Convert.ToInt32(DB_Add_delete_update_.Database.ds.Tables["Supplier"].Compute("count(num_supp)", "").ToString());
            vr.txt_Debtor_sup.Text = "0";
            vr.txt_Creditor_sup.Text = "0";
            for (int i = 0; i < con; i++)
            {
                if (DB_Add_delete_update_.Database.ds.Tables["Supplier"].Rows[i][0] != null)
                {
                    cod = Convert.ToInt32(DB_Add_delete_update_.Database.ds.Tables["Supplier"].Rows[i][0].ToString());
                    DataRow dr_add_bala = DB_Add_delete_update_.Database.ds.Tables["Supplier"].Rows.Find(cod);
                    DataRow dr_Calc = DB_Add_delete_update_.Database.ds.Tables["Calc_supply"].Rows.Find(cod); //Convert.ToInt32(dr_add_bala[i][6])
                    double total = Convert.ToDouble(dr_Calc[1]) + Convert.ToDouble(dr_Calc[2]);
                    vr.dgv_Balanse_Add_sup_dgv.Rows.Add(
                     dr_add_bala[0],
                     dr_add_bala[1],
                     dr_add_bala[2],
                     dr_add_bala[7],
                     dr_Calc[2],
                     dr_Calc[1],
                     dr_Calc[3]
                     );

                    select_Row(num, cod);
                }
                else
                {
                    MessageBox.Show("jfyrukg");
                }
            }

            int num_max = Convert.ToInt32(DB_Add_delete_update_.Database.ds.Tables["Supplier"].Compute("max(num_supp)", "").ToString()) + 1;
            if (num_max == num)
            {
                Get_IndexDatagrid(con);
            }


        }



        public void Save_Balanse_sup()
        {
            var vr = Application.OpenForms["Main"] as Main;
            double sum;

            int id = Convert.ToInt32(vr.dgv_Balanse_Add_sup_dgv.SelectedCells[0].Value);
            DataRow dr_Calc = DB_Add_delete_update_.Database.ds.Tables["Calc_supply"].Rows.Find(id);
            double Deb = Convert.ToDouble(dr_Calc[1].ToString());
            double ced = Convert.ToDouble(dr_Calc[2].ToString());

            //dr_Calc[1] = ced + Convert.ToDouble(vr.txt_Creditor_sup.Text);
            //dr_Calc[2] = Deb + Convert.ToDouble(vr.txt_Debtor_sup.Text);

            //if (Convert.ToDouble(dr_Calc[1])> Convert.ToDouble(dr_Calc[2])) {
            //    double sum3 = Convert.ToDouble(dr_Calc[1]) - Convert.ToDouble(dr_Calc[2]);

            //  //  MessageBox.Show((-sum3)+"  XXXXXX " + sum3);
            //    dr_Calc[3] = (-sum3);
            //}
            //else
            //{
            //    double sum3 = Convert.ToDouble(dr_Calc[1]) - Convert.ToDouble(dr_Calc[2]);
            //    //MessageBox.Show((-sum3) + "  AAAAA " + sum3);
            //     dr_Calc[3] = sum3;
            //}

            if (Convert.ToDouble(vr.txt_Creditor_sup.Text) > 0 && Convert.ToDouble(vr.txt_Debtor_sup.Text) == 0)
            {
                if (Deb == 0 && ced >= 0)
                {
                    dr_Calc[1] = Math.Abs(ced + Convert.ToDouble(vr.txt_Creditor_sup.Text));
                    dr_Calc[3] = Math.Abs(ced + Convert.ToDouble(vr.txt_Creditor_sup.Text));
                    dr_Calc[4] = true;

                }
                else if (Deb > 0 && ced == 0 && Deb > Convert.ToDouble(vr.txt_Creditor_sup.Text))
                {
                    dr_Calc[2] = Math.Abs(Deb - Convert.ToDouble(vr.txt_Creditor_sup.Text));
                    dr_Calc[3] = Math.Abs(Deb - Convert.ToDouble(vr.txt_Creditor_sup.Text));
                    dr_Calc[4] = true;
                }
                else if (Deb == 0 && ced >= 0 && ced < Convert.ToDouble(vr.txt_Creditor_sup.Text))
                {
                    dr_Calc[1] = Math.Abs(Deb - Convert.ToDouble(vr.txt_Creditor_sup.Text));
                    dr_Calc[3] = Math.Abs(Deb - Convert.ToDouble(vr.txt_Creditor_sup.Text));
                    dr_Calc[4] = true;
                }
            }
            else if (Convert.ToDouble(vr.txt_Creditor_sup.Text) == 0 && Convert.ToDouble(vr.txt_Debtor_sup.Text) > 0)
            {
                if (Deb >= 0 && ced == 0)
                {
                    dr_Calc[2] = Math.Abs(Deb + Convert.ToDouble(vr.txt_Debtor_sup.Text));
                    dr_Calc[3] = Math.Abs(ced + Convert.ToDouble(vr.txt_Debtor_sup.Text));
                    dr_Calc[4] = true;

                }
                else if (Deb >= 0 && ced == 0 && Deb < Convert.ToDouble(vr.txt_Debtor_sup.Text))
                {
                    dr_Calc[1] = Math.Abs(ced - Convert.ToDouble(vr.txt_Debtor_sup.Text));
                    dr_Calc[3] = Math.Abs(ced - Convert.ToDouble(vr.txt_Debtor_sup.Text));
                    dr_Calc[4] = true;
                }
                else if (Deb == 0 && ced >= 0 && ced < Convert.ToDouble(vr.txt_Debtor_sup.Text))
                {
                    dr_Calc[2] = Math.Abs(ced - Convert.ToDouble(vr.txt_Debtor_sup.Text));
                    dr_Calc[3] = Math.Abs(ced - Convert.ToDouble(vr.txt_Debtor_sup.Text));
                    dr_Calc[4] = true;
                }
            }
            else if (Convert.ToDouble(vr.txt_Creditor_sup.Text) > 0 && Convert.ToDouble(vr.txt_Debtor_sup.Text) > 0)
            {
                MessageBox.Show("عذراً \n ( عليك ادخال احد القيم ( دائن او مدين ", "خطاء", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (Convert.ToDouble(vr.txt_Creditor_sup.Text) == 0 && Convert.ToDouble(vr.txt_Debtor_sup.Text) == 0)
            {
                MessageBox.Show("عذراً \n لا يمكن ادخال قيم فارغه ", "خطاء", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }



            vr.dgv_Balanse_Add_sup_dgv.SelectedCells[4].Value = dr_Calc[2];// Deb + Convert.ToDouble(vr.txt_Debtor_sup.Text);
            vr.dgv_Balanse_Add_sup_dgv.SelectedCells[5].Value = dr_Calc[1]; //ced + Convert.ToDouble(vr.txt_Creditor_sup.Text);
            double vv = Deb + Convert.ToDouble(vr.txt_Debtor_sup.Text);
            vr.dgv_Balanse_Add_sup_dgv.SelectedCells[6].Value = dr_Calc[3];   //(Deb + Convert.ToDouble(vr.txt_Debtor_sup.Text)) - (ced + Convert.ToDouble(vr.txt_Creditor_sup.Text));

            Add_Accon();

            DB_Add_delete_update_.Database.update("Calc_supply");
            DB_Add_delete_update_.Database.update("Supplier");
            vr.txt_Debtor_sup.Text = "0";
            vr.txt_Creditor_sup.Text = "0";
        }


        public void check_from_Supp()
        {

            var vr = Application.OpenForms["Main"] as Main;
            int num_max =to.AoutoNumber("Accounts_suppliers", "num_supp");
            //if (DB_Add_delete_update_.Database.ds.Tables["Accounts_suppliers"].Rows.Count != 0)
            //{

            //    num_max = Convert.ToInt32(DB_Add_delete_update_.Database.ds.Tables["Accounts_suppliers"].Compute("max(num_supp)", "").ToString()) + 1;

            //}
            //else
            //{
            //    num_max = 1;
            //}
            int num = Convert.ToInt32(vr.txt_num_supp.Text);
            int id = Convert.ToInt32(vr.dgv_Balanse_Add_sup_dgv.SelectedCells[0].Value);
            if (num == num_max)
            {
                vr.dgv_Balanse_Add_sup_dgv.SelectedCells[4].Value = Convert.ToDouble(vr.txt_Debtor_sup.Text);
                vr.dgv_Balanse_Add_sup_dgv.SelectedCells[5].Value = Convert.ToDouble(vr.txt_Creditor_sup.Text);
                vr.dgv_Balanse_Add_sup_dgv.SelectedCells[6].Value = Convert.ToDouble(vr.txt_Debtor_sup.Text) - Convert.ToDouble(vr.txt_Creditor_sup.Text);
                vr.txt_Dbt_supp.Text = vr.txt_Debtor_sup.Text;
                vr.txt_Crdt_supp.Text = vr.txt_Creditor_sup.Text;
            }
            else
            {
                Save_Balanse_sup();
                // Add_Accon();
            }

        }
        public void Dgv_Balanse_Add_sup_SelectionChanged()
        {
            var vr = Application.OpenForms["Main"] as Main;
            //to.Style_DataGridView(vr.dgv_Balanse_Add_sup_dgv);
            int num_max = Convert.ToInt32(DB_Add_delete_update_.Database.ds.Tables["Supplier"].Compute("max(num_supp)", "").ToString()) + 1;

            int id = Convert.ToInt32(vr.dgv_Balanse_Add_sup_dgv.CurrentRow.Cells[0].Value);
            DataRow dr_Calc = DB_Add_delete_update_.Database.ds.Tables["Calc_supply"].Rows.Find(id);
            if (Convert.ToBoolean(dr_Calc[4]) != true && Convert.ToInt32(dr_Calc[1]) == 0 && Convert.ToInt32(dr_Calc[2]) == 0)
            {
                vr.btn_Save_Blance_btn.Enabled = true;
            }
            else
            {
                vr.btn_Save_Blance_btn.Enabled = false;
            }
        }



        public void Add_Accon()
        {
            var vr = Application.OpenForms["Main"] as Main;



            int id  = to.AoutoNumber("Accounts_suppliers", "num_supp");
            //if (DB_Add_delete_update_.Database.ds.Tables["Accounts_suppliers"].Rows.Count != 0)
            //{
            //    id = Convert.ToInt32(DB_Add_delete_update_.Database.ds.Tables["Accounts_suppliers"].Compute("max(id_Accoun_sup)", "").ToString()) + 1;
            //}
            //else
            //{
            //    id = 1;
            //}
            //int id_supp = 0;
            //if (Convert.ToInt32(vr.txt_num_supp.Text) != null) {
            //    id_supp = Convert.ToInt32(vr.txt_num_supp.Text);
            //}
            //else
            //{
            int id_supp = Convert.ToInt32(vr.dgv_Balanse_Add_sup_dgv.CurrentRow.Cells[0].Value);
            //}

            DataRow dr_sup = DB_Add_delete_update_.Database.ds.Tables["Supplier"].Rows.Find(id_supp);

            string name_sup = dr_sup[1].ToString();

            int id_user = 1;

            DataRow dr_Emplooy = DB_Add_delete_update_.Database.ds.Tables["TB_Employees"].Rows.Find(id_user);

            string name_Emplooy = dr_Emplooy[1].ToString();
            double Debtor = Convert.ToDouble(vr.txt_Debtor_sup.Text);
            double Creditor = Convert.ToDouble(vr.txt_Creditor_sup.Text);
            double balans = 0;
            string Type_Accon = "رصيد افتتاحي";
            DateTime date_add = DateTime.Now;
            if (Convert.ToDouble(vr.txt_Debtor_sup.Text) != 0)
            {
                balans = Convert.ToDouble(vr.txt_Debtor_sup.Text);
            }
            if (Convert.ToDouble(vr.txt_Creditor_sup.Text) != 0)
            {
                balans = Convert.ToDouble(vr.txt_Creditor_sup.Text);
            }
            DB_Add_delete_update_.Database.ds.Tables["Accounts_suppliers"].Rows.Add(id, id_supp, name_sup, id_user, name_Emplooy, Creditor, Debtor, Type_Accon, date_add, balans);


            DataRow dr_Calc = DB_Add_delete_update_.Database.ds.Tables["Calc_supply"].Rows.Find(id_supp);
            // List<double> Accon = Sum_Mny_Debtor(id, id_supp);
            //dr_Calc[1] =    ;// Accon[0];
            //dr_Calc[2] = ;///Accon[1];

            vr.dgv_Balanse_Add_sup_dgv.SelectedCells[4].Value = dr_Calc[2]; //Accon[0];
            vr.dgv_Balanse_Add_sup_dgv.SelectedCells[5].Value = dr_Calc[1];//Accon[1];
            vr.dgv_Balanse_Add_sup_dgv.SelectedCells[6].Value = dr_Calc[3];//Accon[2];

            DB_Add_delete_update_.Database.update("Accounts_suppliers");
            DB_Add_delete_update_.Database.update("Calc_supply");
        }




        public List<double> Sum_Mny_Debtor(int cod, int id_sup)
        {
            List<double> numb = new List<double>();
            int debt = 0;
            int cred = 0;
            int sum = 0;
            int num = Convert.ToInt32(DB_Add_delete_update_.Database.ds.Tables["Accounts_suppliers"].Compute("count(id_Accoun_sup)", "")) - 1;
            for (int i = 0; i <= num; i++)
            {
                if (id_sup == Convert.ToInt32(DB_Add_delete_update_.Database.ds.Tables["Accounts_suppliers"].Rows[i][1].ToString()))
                {
                    debt += Convert.ToInt32(DB_Add_delete_update_.Database.ds.Tables["Accounts_suppliers"].Rows[i][6].ToString());
                    cred += Convert.ToInt32(DB_Add_delete_update_.Database.ds.Tables["Accounts_suppliers"].Rows[i][5].ToString());

                }
            }
            sum = cred - debt;
            numb.Add(debt);
            numb.Add(cred);
            numb.Add(sum);

            return numb;
        }

    }
}
