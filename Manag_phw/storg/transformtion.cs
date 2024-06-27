using Manag_ph.classs_table;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Manag_ph.storg
{
    class transformtion
    {




       public void Auto_calc_sum()
        {

            var vd = Application.OpenForms["Main"] as Main;

            double sum_pric = 0;
            double sum_pro = 0;
            double sum_prive = 0;
            for (int i = 0; i < vd.dgv_tranformtion_dgv.Rows.Count; i++)
            {
                int new_quity = Convert.ToInt32(vd.dgv_tranformtion_dgv.Rows[i].Cells[4].Value);

                if (new_quity != 0)
                {
                    double price_tran = Convert.ToDouble(vd.dgv_tranformtion_dgv.Rows[i].Cells[6].Value);
                    double pro_tran = Convert.ToDouble(vd.dgv_tranformtion_dgv.Rows[i].Cells[7].Value);
                    sum_pric += Convert.ToDouble(price_tran * new_quity);
                    sum_pro += Convert.ToDouble(pro_tran * new_quity);
                    sum_prive = sum_pric - sum_pro;
                }
            }
            vd.lbl_sum_Trans_pric.Text = sum_pric.ToString("N0");
            vd.lbl_sum_Trans_pro.Text = sum_pro.ToString("N0");
            vd.lbl_sum_Trans_prive.Text = sum_prive.ToString("N0");
            vd.lbl_sum_Trans_Item.Text = vd.dgv_tranformtion_dgv.Rows.Count.ToString();



        }



        public void Txt_num_storg_send_KeyPress_(object sender, KeyPressEventArgs e)
        {

            var vd = Application.OpenForms["Main"] as Main;

            if (e.KeyChar == (Char)Keys.Enter)
            {
                if (vd.txt_num_storg_send.Text.Trim() != string.Empty)
                {
                    DataRow Data_Rows_Storg = DB_Add_delete_update_.Database.ds.Tables["Storg"].Rows.Find(Convert.ToInt32(vd.txt_num_storg_send.Text));
                    if (Data_Rows_Storg != null)
                    {
                        vd.txt_name_storg_send.Text = Data_Rows_Storg[1].ToString();
                    }
                    else
                    {
                        MessageBox.Show("الرقم المدخل ليس موجود");
                    }
                }

            }
            if (!(char.IsDigit(e.KeyChar)) && e.KeyChar != (Char)Keys.Back)
            {
                e.Handled = true;
            }
        }


        public void Txt_num_storg_Trans_KeyPress_(object sender, KeyPressEventArgs e)
        {
            var vd = Application.OpenForms["Main"] as Main;

            if (e.KeyChar == (Char)Keys.Enter)
            {
                if (vd.txt_num_storg_Trans.Text.Trim() != string.Empty)
                {
                    DataRow Data_Rows_Storg = DB_Add_delete_update_.Database.ds.Tables["Storg"].Rows.Find(Convert.ToInt32(vd.txt_num_storg_Trans.Text));
                    if (Data_Rows_Storg != null)
                    {
                        vd.txt_name_storg_Trans.Text = Data_Rows_Storg[1].ToString();
                    }
                    else
                    {
                        MessageBox.Show("الرقم المدخل ليس موجود");
                    }
                }

            }
            if (!(char.IsDigit(e.KeyChar)) && e.KeyChar != (Char)Keys.Back)
            {
                e.Handled = true;
            }
        }

        public void Dgv_tranformtion_CellEndEdit_(object sender, DataGridViewCellEventArgs e)
        {
            var vd = Application.OpenForms["Main"] as Main;

            if (vd.dgv_tranformtion_dgv.CurrentCell.ColumnIndex == 0)
            {
                DataRow[] dr_sum = DB_Add_delete_update_.Database.ds.Tables["sum_storg_Item"].Select("Storg_no = " + Convert.ToInt32(vd.txt_num_storg_send.Text));
                if (dr_sum.Count() != 0)
                {
                    DataRow[] dr = DB_Add_delete_update_.Database.ds.Tables["Item_storg"].Select("Item_no = " + Convert.ToInt32(vd.dgv_tranformtion_dgv.CurrentRow.Cells[0].Value));

                    if (dr.Count() != 0)
                    {
                        forms.Item_transfromtion m1 = new forms.Item_transfromtion();
                        m1.ShowDialog();
                        Auto_calc_sum();

                    }
                    else
                    {
                        MessageBox.Show("الصنف ليس موجود");
                    }

                }
            }
            else
            {
                if (vd.dgv_tranformtion_dgv.CurrentCell.ColumnIndex == 4)
                {
                    if (Convert.ToInt32(vd.dgv_tranformtion_dgv.CurrentRow.Cells[4].Value) > Convert.ToInt32(vd.dgv_tranformtion_dgv.CurrentRow.Cells[3].Value))
                    {
                        MessageBox.Show("الكمية المحولة الكبر من الكمية المخزنة");
                        vd.dgv_tranformtion_dgv.CurrentRow.Cells[4].Value = 0;
                    }
                    else
                    {
                        Auto_calc_sum();
                    }
                }


            }

        }

        public void Dgv_tranformtion_EditingControlShowing_(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            var vd = Application.OpenForms["Main"] as Main;

            if (vd.dgv_tranformtion_dgv.CurrentCell.ColumnIndex == 0 || vd.dgv_tranformtion_dgv.CurrentCell.ColumnIndex == 4)
            {

                if (e.Control is TextBox && e.Control != null)
                {
                    e.Control.KeyPress += delegate (object Mysend, KeyPressEventArgs Mye)
                    {
                        if (!(char.IsDigit(Mye.KeyChar)) && Mye.KeyChar != (Char)Keys.Back)
                        {
                            Mye.Handled = true;
                        }


                    };
                }
            }



        }

        public void Btn_trans_Items_(object sender, EventArgs e)
        {
            var vd = Application.OpenForms["Main"] as Main;


            for (int i = 0; i < vd.dgv_tranformtion_dgv.Rows.Count; i++)
            {
                double pric = 0;
                double pro = 0;
                int sum_qity = 0;
                double sum_sell_pric = 0;
                double sum_sell_pro = 0;
                double sum_Profit = 0;


                int Qity = 0;
                DateTime Expe;
                int bons = 0;
                int disc = 0;
                int storg_tex = 0;
                double storg_profit = 0;
                double sell_pro = 0;
                double sell_pric = 0;
                int Items_update = 0;
                int unit_update = 0;
                int sum_num_update = 0;
                int type_unit_update = 0;


                //MessageBox.Show(Qity + " Ansh");


                DataRow dr_sum_update = DB_Add_delete_update_.Database.ds.Tables["sum_storg_Item"].Rows.Find(Convert.ToInt32(vd.dgv_tranformtion_dgv.Rows[i].Cells[12].Value));
                DataRow dr_test = DB_Add_delete_update_.Database.ds.Tables["Item_storg"].Rows.Find(vd.dgv_tranformtion_dgv.Rows[i].Cells[11].Value);
                DataRow[] dr_unit_Item_update = DB_Add_delete_update_.Database.ds.Tables["unite_items"].Select("item_no =" + Convert.ToInt32(vd.dgv_tranformtion_dgv.Rows[i].Cells[0].Value));

                //=================================
                //مهم التحويلات
                if (vd.dgv_tranformtion_dgv.Rows[i].Cells[2] != null)
                {

                    //===============================================
                    //اذ كان نوع الادخال وحدة كبرا

                    if (Convert.ToInt32(dr_test[12]) == 1)
                    { // ونوع التحوبل اذ كان كبرا وعند التحويل كبير
                        if (Convert.ToInt32(vd.dgv_tranformtion_dgv.Rows[i].Cells[9].Value) == 1)
                        {

                            //تعديل الصنف 
                            //================================================================================
                            Qity = (Convert.ToInt32(dr_test[1]) - Convert.ToInt32(vd.dgv_tranformtion_dgv.Rows[i].Cells[4].Value));
                            //MessageBox.Show(Qity+" kob");
                            Expe = Convert.ToDateTime(vd.dgv_tranformtion_dgv.Rows[i].Cells[5].Value);
                            bons = Convert.ToInt32(dr_test[3]);
                            disc = Convert.ToInt32(dr_test[4]);
                            storg_tex = Convert.ToInt32(dr_test[5]);
                            storg_profit = Convert.ToInt32(dr_test[6]);
                            sell_pro = Convert.ToInt32(dr_test[7]);
                            sell_pric = Convert.ToInt32(dr_test[8]);
                            Items_update = Convert.ToInt32(dr_test[9]);
                            unit_update = Convert.ToInt32(dr_test[10]);
                            sum_num_update = Convert.ToInt32(dr_test[11]);
                            type_unit_update = Convert.ToInt32(dr_test[12]);

                            int reslt = Convert.ToInt32(vd.dgv_tranformtion_dgv.Rows[i].Cells[4].Value) * Convert.ToInt32(dr_unit_Item_update[0][4]);


                            int Quity_avrg_up = Convert.ToInt32(dr_test[13]) - reslt;


                            int Quity_smool_up = Convert.ToInt32(dr_test[14]) - (reslt * Convert.ToInt32(dr_unit_Item_update[0][5]));
                            MessageBox.Show(Qity + "");
                            object[] update_Items = { "", Qity, Convert.ToDateTime(Expe.ToString("d")), bons, disc, storg_tex, storg_profit, sell_pro, sell_pric, Items_update, unit_update, sum_num_update, type_unit_update, Quity_avrg_up, Quity_smool_up };
                            new classs_table.Items_Tools().update_Rows_Table_Database("Item_storg", vd.dgv_tranformtion_dgv.Rows[i].Cells[11].Value.ToString(), update_Items);



                        }
                        //اذا كان نوع التحويل متوسط وعند الادخال كبير
                        else if (Convert.ToInt32(vd.dgv_tranformtion_dgv.Rows[i].Cells[9].Value) == 2)
                        {
                            //تعديل المجاميع
                            //====================================================

                            //تعديل الصنف 
                            //================================================================================

                            Qity = Convert.ToInt32(dr_test[1]) - (Convert.ToInt32(vd.dgv_tranformtion_dgv.Rows[i].Cells[4].Value) / Convert.ToInt32(dr_unit_Item_update[0][4]));
                            MessageBox.Show(Qity + " الكمية");
                            Expe = Convert.ToDateTime(vd.dgv_tranformtion_dgv.Rows[i].Cells[5].Value);
                            bons = Convert.ToInt32(dr_test[3]);
                            disc = Convert.ToInt32(dr_test[4]);
                            storg_tex = Convert.ToInt32(dr_test[5]);
                            storg_profit = Convert.ToInt32(dr_test[6]);
                            sell_pro = Convert.ToInt32(dr_test[7]);
                            sell_pric = Convert.ToInt32(dr_test[8]);
                            Items_update = Convert.ToInt32(dr_test[9]);
                            unit_update = Convert.ToInt32(dr_test[10]);
                            sum_num_update = Convert.ToInt32(dr_test[11]);
                            type_unit_update = Convert.ToInt32(dr_test[12]);

                            int reslt = Convert.ToInt32(vd.dgv_tranformtion_dgv.Rows[i].Cells[3].Value) - Convert.ToInt32(vd.dgv_tranformtion_dgv.Rows[i].Cells[4].Value);

                            int Quity_avrg_up = Convert.ToInt32(dr_test[13]) - reslt;
                            int Quity_smool_up = Convert.ToInt32(dr_test[14]) - (Quity_avrg_up * Convert.ToInt32(dr_unit_Item_update[0][5]));
                            Quity_avrg_up = Convert.ToInt32(dr_test[13]) - Convert.ToInt32(vd.dgv_tranformtion_dgv.Rows[i].Cells[4].Value);
                            object[] update_Items = { "", Qity, Convert.ToDateTime(Expe.ToString("d")), bons, disc, storg_tex, storg_profit, sell_pro, sell_pric, Items_update, unit_update, sum_num_update, type_unit_update, Quity_avrg_up, Quity_smool_up };
                            new classs_table.Items_Tools().update_Rows_Table_Database("Item_storg", vd.dgv_tranformtion_dgv.Rows[i].Cells[11].Value.ToString(), update_Items);

                            //اذا كان نوع التحويل صغير وعند الادخال كبير
                        }
                        else if (Convert.ToInt32(vd.dgv_tranformtion_dgv.Rows[i].Cells[9].Value) == 3)
                        {
                            //تعديل المجاميع
                            //====================================================

                            //تعديل الصنف 
                            //================================================================================

                            Qity = Convert.ToInt32(dr_test[1]) - ((Convert.ToInt32(vd.dgv_tranformtion_dgv.Rows[i].Cells[3].Value) - Convert.ToInt32(vd.dgv_tranformtion_dgv.Rows[i].Cells[4].Value)) / Convert.ToInt32(dr_unit_Item_update[0][5])) / Convert.ToInt32(dr_unit_Item_update[0][4]);
                            //MessageBox.Show(Qity+"");
                            Expe = Convert.ToDateTime(vd.dgv_tranformtion_dgv.Rows[i].Cells[5].Value);
                            bons = Convert.ToInt32(dr_test[3]);
                            disc = Convert.ToInt32(dr_test[4]);
                            storg_tex = Convert.ToInt32(dr_test[5]);
                            storg_profit = Convert.ToInt32(dr_test[6]);
                            sell_pro = Convert.ToInt32(dr_test[7]);
                            sell_pric = Convert.ToInt32(dr_test[8]);
                            Items_update = Convert.ToInt32(dr_test[9]);
                            unit_update = Convert.ToInt32(dr_test[10]);
                            sum_num_update = Convert.ToInt32(dr_test[11]);
                            type_unit_update = Convert.ToInt32(dr_test[12]);

                            int reslt = (Convert.ToInt32(vd.dgv_tranformtion_dgv.Rows[i].Cells[3].Value) - Convert.ToInt32(vd.dgv_tranformtion_dgv.Rows[i].Cells[4].Value)) / Convert.ToInt32(dr_unit_Item_update[0][5]);

                            int Quity_avrg_up = Convert.ToInt32(dr_test[13]) - reslt;
                            int Quity_smool_up = (Convert.ToInt32(vd.dgv_tranformtion_dgv.Rows[i].Cells[3].Value) - Convert.ToInt32(vd.dgv_tranformtion_dgv.Rows[i].Cells[4].Value));
                            //MessageBox.Show(Qity + "     " + reslt + "    " + Quity_smool_up);
                            object[] update_Items = { "", Qity, Convert.ToDateTime(Expe.ToString("d")), bons, disc, storg_tex, storg_profit, sell_pro, sell_pric, Items_update, unit_update, sum_num_update, type_unit_update, Quity_avrg_up, Quity_smool_up };
                            new classs_table.Items_Tools().update_Rows_Table_Database("Item_storg", vd.dgv_tranformtion_dgv.Rows[i].Cells[11].Value.ToString(), update_Items);

                        }


                    }
                    //اذا كان نوع الادخال وحدة متوسطة
                    else if (Convert.ToInt32(dr_test[12]) == 2)
                    {//ونوع التحوي وحدة كبرا
                        if (Convert.ToInt32(vd.dgv_tranformtion_dgv.Rows[i].Cells[9].Value) == 1)
                        {
                            //====================================================================================

                            //==================================================================================================================
                            int reslt_quit = (Convert.ToInt32(vd.dgv_tranformtion_dgv.Rows[i].Cells[4].Value) * Convert.ToInt32(dr_unit_Item_update[0][4]));
                            Qity = Convert.ToInt32(dr_test[1]) - reslt_quit;
                            Expe = Convert.ToDateTime(vd.dgv_tranformtion_dgv.Rows[i].Cells[5].Value);
                            bons = Convert.ToInt32(dr_test[3]);
                            disc = Convert.ToInt32(dr_test[4]);
                            storg_tex = Convert.ToInt32(dr_test[5]);
                            storg_profit = Convert.ToInt32(dr_test[6]);
                            sell_pro = Convert.ToInt32(dr_test[7]);
                            sell_pric = Convert.ToInt32(dr_test[8]);
                            Items_update = Convert.ToInt32(dr_test[9]);
                            unit_update = Convert.ToInt32(dr_test[10]);
                            sum_num_update = Convert.ToInt32(dr_test[11]);
                            type_unit_update = Convert.ToInt32(dr_test[12]);

                            int Quity_avrg_up = 0;
                            int Quity_smool_up = Convert.ToInt32(dr_test[14]) - (reslt_quit * Convert.ToInt32(dr_unit_Item_update[0][5]));
                            //MessageBox.Show(Quity_smool_up + "  " + Convert.ToInt32(dr_test[14]) + "   " + Qity);
                            object[] update_Items = { "", Qity, Convert.ToDateTime(Expe.ToString("d")), bons, disc, storg_tex, storg_profit, sell_pro, sell_pric, Items_update, unit_update, sum_num_update, type_unit_update, Quity_avrg_up, Quity_smool_up };
                            new classs_table.Items_Tools().update_Rows_Table_Database("Item_storg", vd.dgv_tranformtion_dgv.Rows[i].Cells[11].Value.ToString(), update_Items);
                        }
                        //ونوع التحويل وحدة وسطاء
                        else if (Convert.ToInt32(vd.dgv_tranformtion_dgv.Rows[i].Cells[9].Value) == 2)
                        {
                            //====================================================================================

                            //==================================================================================================================
                            int reslt_quty = (Convert.ToInt32(vd.dgv_tranformtion_dgv.Rows[i].Cells[4].Value) * Convert.ToInt32(dr_unit_Item_update[0][5]));
                            Qity = (Convert.ToInt32(vd.dgv_tranformtion_dgv.Rows[i].Cells[3].Value) - Convert.ToInt32(vd.dgv_tranformtion_dgv.Rows[i].Cells[4].Value));

                            Expe = Convert.ToDateTime(vd.dgv_tranformtion_dgv.Rows[i].Cells[5].Value);
                            bons = Convert.ToInt32(dr_test[3]);
                            disc = Convert.ToInt32(dr_test[4]);
                            storg_tex = Convert.ToInt32(dr_test[5]);
                            storg_profit = Convert.ToInt32(dr_test[6]);
                            sell_pro = Convert.ToInt32(dr_test[7]);
                            sell_pric = Convert.ToInt32(dr_test[8]);
                            Items_update = Convert.ToInt32(dr_test[9]);
                            unit_update = Convert.ToInt32(dr_test[10]);
                            sum_num_update = Convert.ToInt32(dr_test[11]);
                            type_unit_update = Convert.ToInt32(dr_test[12]);

                            int Quity_avrg_up = 0;
                            int Quity_smool_up = Convert.ToInt32(dr_test[14]) - reslt_quty;
                            object[] update_Items = { "", Qity, Convert.ToDateTime(Expe.ToString("d")), bons, disc, storg_tex, storg_profit, sell_pro, sell_pric, Items_update, unit_update, sum_num_update, type_unit_update, Quity_avrg_up, Quity_smool_up };
                            new Items_Tools().update_Rows_Table_Database("Item_storg", vd.dgv_tranformtion_dgv.Rows[i].Cells[11].Value.ToString(), update_Items);
                        }
                        else if (Convert.ToInt32(vd.dgv_tranformtion_dgv.Rows[i].Cells[9].Value) == 3)
                        {
                            //====================================================================================

                            //==================================================================================================================
                            int resltqut = Convert.ToInt32(dr_test[14]) - Convert.ToInt32(vd.dgv_tranformtion_dgv.Rows[i].Cells[4].Value);
                            Qity = (Convert.ToInt32(resltqut) / Convert.ToInt32(dr_unit_Item_update[0][5]));

                            Expe = Convert.ToDateTime(vd.dgv_tranformtion_dgv.Rows[i].Cells[5].Value);
                            bons = Convert.ToInt32(dr_test[3]);
                            disc = Convert.ToInt32(dr_test[4]);
                            storg_tex = Convert.ToInt32(dr_test[5]);
                            storg_profit = Convert.ToInt32(dr_test[6]);
                            sell_pro = Convert.ToInt32(dr_test[7]);
                            sell_pric = Convert.ToInt32(dr_test[8]);
                            Items_update = Convert.ToInt32(dr_test[9]);
                            unit_update = Convert.ToInt32(dr_test[10]);
                            sum_num_update = Convert.ToInt32(dr_test[11]);
                            type_unit_update = Convert.ToInt32(dr_test[12]);

                            int Quity_avrg_up = 0;
                            int Quity_smool_up = Convert.ToInt32(dr_test[14]) - Convert.ToInt32(vd.dgv_tranformtion_dgv.Rows[i].Cells[4].Value);
                            object[] update_Items = { "", Qity, Convert.ToDateTime(Expe.ToString("d")), bons, disc, storg_tex, storg_profit, sell_pro, sell_pric, Items_update, unit_update, sum_num_update, type_unit_update, Quity_avrg_up, Quity_smool_up };
                            new classs_table.Items_Tools().update_Rows_Table_Database("Item_storg", vd.dgv_tranformtion_dgv.Rows[i].Cells[11].Value.ToString(), update_Items);
                        }


                    }
                    //اذا كان نوع الادخال وحدة صغيرة
                    else if (Convert.ToInt32(dr_test[12]) == 3)
                    {//نوع التحويل وحدة كبيرة
                        if (Convert.ToInt32(vd.dgv_tranformtion_dgv.Rows[i].Cells[9].Value) == 1)
                        {
                            //====================================================================================

                            //==================================================================================================================
                            Qity = Convert.ToInt32(dr_test[1]) - (Convert.ToInt32(vd.dgv_tranformtion_dgv.Rows[i].Cells[4].Value) * (Convert.ToInt32(dr_unit_Item_update[0][4])) * Convert.ToInt32(dr_unit_Item_update[0][5]));

                            Expe = Convert.ToDateTime(vd.dgv_tranformtion_dgv.Rows[i].Cells[5].Value);
                            bons = Convert.ToInt32(dr_test[3]);
                            disc = Convert.ToInt32(dr_test[4]);
                            storg_tex = Convert.ToInt32(dr_test[5]);
                            storg_profit = Convert.ToInt32(dr_test[6]);
                            sell_pro = Convert.ToInt32(dr_test[7]);
                            sell_pric = Convert.ToInt32(dr_test[8]);
                            Items_update = Convert.ToInt32(dr_test[9]);
                            unit_update = Convert.ToInt32(dr_test[10]);
                            sum_num_update = Convert.ToInt32(dr_test[11]);
                            type_unit_update = Convert.ToInt32(dr_test[12]);

                            int Quity_avrg_up = 0;
                            int Quity_smool_up = Qity;
                            object[] update_Items = { "", Qity, Convert.ToDateTime(Expe.ToString("d")), bons, disc, storg_tex, storg_profit, sell_pro, sell_pric, Items_update, unit_update, sum_num_update, type_unit_update, Quity_avrg_up, Quity_smool_up };
                            new classs_table.Items_Tools().update_Rows_Table_Database("Item_storg", vd.dgv_tranformtion_dgv.Rows[i].Cells[11].Value.ToString(), update_Items);
                        }
                        //نوع التحويل وحدة وسطاء
                        else if (Convert.ToInt32(vd.dgv_tranformtion_dgv.Rows[i].Cells[9].Value) == 2)
                        {

                            //==================================================================================================================
                            Qity = Convert.ToInt32(dr_test[1]) - (Convert.ToInt32(vd.dgv_tranformtion_dgv.Rows[i].Cells[4].Value) * Convert.ToInt32(dr_unit_Item_update[0][5]));

                            Expe = Convert.ToDateTime(vd.dgv_tranformtion_dgv.Rows[i].Cells[5].Value);
                            bons = Convert.ToInt32(dr_test[3]);
                            disc = Convert.ToInt32(dr_test[4]);
                            storg_tex = Convert.ToInt32(dr_test[5]);
                            storg_profit = Convert.ToInt32(dr_test[6]);
                            sell_pro = Convert.ToInt32(dr_test[7]);
                            sell_pric = Convert.ToInt32(dr_test[8]);
                            Items_update = Convert.ToInt32(dr_test[9]);
                            unit_update = Convert.ToInt32(dr_test[10]);
                            sum_num_update = Convert.ToInt32(dr_test[11]);
                            type_unit_update = Convert.ToInt32(dr_test[12]);

                            int Quity_avrg_up = 0;
                            int Quity_smool_up = Qity;
                            object[] update_Items = { "", Qity, Convert.ToDateTime(Expe.ToString("d")), bons, disc, storg_tex, storg_profit, sell_pro, sell_pric, Items_update, unit_update, sum_num_update, type_unit_update, Quity_avrg_up, Quity_smool_up };
                            new classs_table.Items_Tools().update_Rows_Table_Database("Item_storg", vd.dgv_tranformtion_dgv.Rows[i].Cells[11].Value.ToString(), update_Items);
                        }
                        //نوع التحويل وحدة صغرا
                        else if (Convert.ToInt32(vd.dgv_tranformtion_dgv.Rows[i].Cells[9].Value) == 3)
                        {
                            //====================================================================================

                            //==================================================================================================================
                            Qity = Convert.ToInt32(dr_test[1]) - Convert.ToInt32(vd.dgv_tranformtion_dgv.Rows[i].Cells[4].Value);

                            Expe = Convert.ToDateTime(vd.dgv_tranformtion_dgv.Rows[i].Cells[5].Value);
                            bons = Convert.ToInt32(dr_test[3]);
                            disc = Convert.ToInt32(dr_test[4]);
                            storg_tex = Convert.ToInt32(dr_test[5]);
                            storg_profit = Convert.ToInt32(dr_test[6]);
                            sell_pro = Convert.ToInt32(dr_test[7]);
                            sell_pric = Convert.ToInt32(dr_test[8]);
                            Items_update = Convert.ToInt32(dr_test[9]);
                            unit_update = Convert.ToInt32(dr_test[10]);
                            sum_num_update = Convert.ToInt32(dr_test[11]);
                            type_unit_update = Convert.ToInt32(dr_test[12]);

                            int Quity_avrg_up = 0;
                            int Quity_smool_up = Qity;
                            object[] update_Items = { "", Qity, Convert.ToDateTime(Expe.ToString("d")), bons, disc, storg_tex, storg_profit, sell_pro, sell_pric, Items_update, unit_update, sum_num_update, type_unit_update, Quity_avrg_up, Quity_smool_up };
                            new classs_table.Items_Tools().update_Rows_Table_Database("Item_storg", vd.dgv_tranformtion_dgv.Rows[i].Cells[11].Value.ToString(), update_Items);
                        }
                    }
                }

                //تعديل المجاميع
                //====================================================
                pric = (Convert.ToDouble(vd.dgv_tranformtion_dgv.Rows[i].Cells[4].Value) * Convert.ToDouble(vd.dgv_tranformtion_dgv.Rows[i].Cells[6].Value));
                pro = (Convert.ToDouble(vd.dgv_tranformtion_dgv.Rows[i].Cells[4].Value) * Convert.ToDouble(vd.dgv_tranformtion_dgv.Rows[i].Cells[7].Value));
                sum_qity = Convert.ToInt32(dr_sum_update[1]);
                sum_sell_pric = Convert.ToDouble(dr_sum_update[2]) - pric;
                sum_sell_pro = Convert.ToDouble(dr_sum_update[3]) - pro;
                sum_Profit = Convert.ToDouble(dr_sum_update[4]) - (pric - pro);
                int Storg_no = Convert.ToInt32(dr_sum_update[5]);
                object[] temp = { "", sum_qity, Convert.ToDouble(sum_sell_pric.ToString("N0")), Convert.ToDouble(sum_sell_pro.ToString("N0")), Convert.ToDouble(sum_Profit.ToString("N0")), Storg_no };
                new classs_table.Items_Tools().update_Rows_Table_Database("sum_storg_Item", dr_sum_update[0].ToString(), temp);
                DataRow dr_Item_storg_update = DB_Add_delete_update_.Database.ds.Tables["Item_storg"].Rows.Find(Convert.ToInt32(vd.dgv_tranformtion_dgv.Rows[i].Cells[11].Value));




            }


            // اضافة بيانات المجاميع الا المخزن المحول الية
            int Auto_num_sum = new open_blans_storg().AoutoNumber("sum_storg_Item", "sum_num");
            int count_sum = Convert.ToInt32(vd.lbl_sum_Trans_Item.Text);
            double sum_sill_prics = Convert.ToDouble(vd.lbl_sum_Trans_pric.Text);
            double sum_sil_prod = Convert.ToDouble(vd.lbl_sum_Trans_pro.Text);
            double sum_Prif = Convert.ToDouble(vd.lbl_sum_Trans_prive.Text);
            int storg_Sum = Convert.ToInt32(vd.txt_num_storg_Trans.Text);
            
            DB_Add_delete_update_.Database.ds.Tables["sum_storg_Item"].Rows.Add(Auto_num_sum, count_sum, sum_sill_prics, sum_sil_prod, sum_Prif, storg_Sum);
            DB_Add_delete_update_.Database.update("sum_storg_Item");
            //اضاف الا جدول التقارير
            int Auto_num_trans = new open_blans_storg().AoutoNumber("Data_Items_Transform_of_storg", "Trans_num");//اضافة بيانات التحويل 
            DateTime dt_tr = Convert.ToDateTime(vd.lbl_DateTime_Trans.Text);//تاريخ التحويل
            string nots = vd.txt_note_trans.Text;//ملاحضات التحويل
            int Storg_trans = Convert.ToInt32(vd.txt_num_storg_send.Text);//المخزن المحول
            int Storg_yue_trans = Convert.ToInt32(vd.txt_num_storg_Trans.Text);//المخزن المتحول الية
            int sum_storg_Item = Auto_num_sum;//رقم المجاميع
            DB_Add_delete_update_.Database.ds.Tables["Data_Items_Transform_of_storg"].Rows.Add(Auto_num_trans, dt_tr, nots, Storg_trans, Storg_yue_trans, sum_storg_Item,Convert.ToInt32(vd.txt_Empoly_number.Caption));//اضافة البيانات 
            DB_Add_delete_update_.Database.update("Data_Items_Transform_of_storg");//ادخال الا قاعدة البيانات

            int num_RP_sum = new classs_table.Items_Tools().AoutoNumber("RP_sum_storg_Item", "id_RP_sum");
            DB_Add_delete_update_.Database.ds.Tables["RP_sum_storg_Item"].Rows.Add(num_RP_sum, count_sum, sum_sill_prics, sum_sil_prod, sum_Prif, Auto_num_trans, storg_Sum);
            DB_Add_delete_update_.Database.update("RP_sum_storg_Item");

            for (int i = 0; i < vd.dgv_tranformtion_dgv.Rows.Count; i++)
            {
                Items_Tools updatess = new Items_Tools();

                DataRow[] temps = DB_Add_delete_update_.Database.ds.Tables["unite_items"].Select("item_no = " + Convert.ToInt32(vd.dgv_tranformtion_dgv.Rows[i].Cells[0].Value));
                int storg_num = new open_blans_storg().AoutoNumber("Item_storg", "storg_num");
                int Qity = Convert.ToInt32(vd.dgv_tranformtion_dgv.Rows[i].Cells[4].Value);
                DateTime Date_end = Convert.ToDateTime(vd.dgv_tranformtion_dgv.Rows[i].Cells[5].Value);
                int bons = 0;
                int disc = 0;
                int storg_tex = 0;
                double storg_profit = 0;
                double sell_pro = Convert.ToDouble(vd.dgv_tranformtion_dgv.Rows[i].Cells[7].Value);
                double sell_pric = Convert.ToDouble(vd.dgv_tranformtion_dgv.Rows[i].Cells[6].Value);
                int Item_no = Convert.ToInt32(vd.dgv_tranformtion_dgv.Rows[i].Cells[0].Value);
                int unit_num = Convert.ToInt32(vd.dgv_tranformtion_dgv.Rows[i].Cells[10].Value);
                int sum_num = Auto_num_sum;
                int type_unit = Convert.ToInt32(vd.dgv_tranformtion_dgv.Rows[i].Cells[9].Value);

                //لم اكملة عادنا عند اضافة الاصناف الجديدة
                int Qity_avrg = 0;
                int Qity_smoll = 0;

                if (type_unit == 1)
                {
                    Qity_avrg = Convert.ToInt32(temps[0][4]) * Qity;
                    Qity_smoll = Qity_avrg * Convert.ToInt32(temps[0][5]);
                }
                else if (type_unit == 2)
                {
                    Qity_smoll = Qity * Convert.ToInt32(temps[0][5]);
                }
                else
                {
                    Qity_smoll = Qity;
                }
                DB_Add_delete_update_.Database.ds.Tables["Item_storg"].Rows.Add(storg_num, Qity, Date_end, bons, disc, storg_tex, storg_profit, sell_pro, sell_pric, Item_no, unit_num, sum_num, type_unit, Qity_avrg, Qity_smoll);//اضافة البيانات 
                DB_Add_delete_update_.Database.update("Item_storg");//ادخال الا قاعدة البيانات

                String name_unit = vd.dgv_tranformtion_dgv.Rows[i].Cells[2].Value.ToString();
                int num_RP_Item_trans = new classs_table.Items_Tools().AoutoNumber("RP_Item_transform", "id_RP_Item");
                DB_Add_delete_update_.Database.ds.Tables["RP_Item_transform"].Rows.Add(num_RP_Item_trans, Item_no, name_unit, Qity, Date_end, sell_pric, sell_pro, num_RP_sum);
                DB_Add_delete_update_.Database.update("RP_Item_transform");

            }
            MessageBox.Show("تم التحويل بنجاح","تحويل",MessageBoxButtons.OK,MessageBoxIcon.Information);
            vd.dgv_tranformtion_dgv.Rows.Clear();
        }

    }
}
