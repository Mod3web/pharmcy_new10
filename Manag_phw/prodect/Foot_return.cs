using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Manag_ph.prodect
{
    class Foot_return
    {
        int num_qutly_return_;


        void chackReturn(int index)
        {
            var vr = Application.OpenForms["Main"] as Main;
            if (Convert.ToDouble(vr.dgv_return_prodect.CurrentRow.Cells[index].Value) > 0)
            {
                vr.dgv_return_prodect.CurrentRow.Cells[13].Value = 1;
            }
            else
            {
                vr.dgv_return_prodect.CurrentRow.Cells[13].Value = 0;

            }

        }

        public void Sacve_Prodect_return()
        {
            var vr = Application.OpenForms["Main"] as Main;
            bool temp = false;
            for (int i = 0; i < vr.dgv_return_prodect.Rows.Count; i++)
            {
                if (Convert.ToInt32(vr.dgv_return_prodect.Rows[i].Cells[13].Value) == 1)
                {
                    temp = true;

                }
            }

            if (vr.dgv_return_prodect.Rows.Count != 0 && temp)
            {
                DataRow dr_Data_Fott = DB_Add_delete_update_.Database.ds.Tables["Data_Footer"].Rows.Find(Convert.ToInt32(vr.lbl_num_Fottr.Text));
                object[] dr_sum_Storg = DB_Add_delete_update_.Database.ds.Tables["sum_storg_Item"].Rows.Find(Convert.ToInt32(dr_Data_Fott[7])).ItemArray;
                object[] dr_Totil_footr = DB_Add_delete_update_.Database.ds.Tables["Totel_Footer_prodeuct"].Rows.Find(Convert.ToInt32(dr_Data_Fott[9])).ItemArray;


                object[] ob_Data_supper = DB_Add_delete_update_.Database.ds.Tables["Supplier"].Rows.Find(Convert.ToInt32(vr.txt_num_supper_return.Text)).ItemArray;
                object[] ob_Data_Calco = DB_Add_delete_update_.Database.ds.Tables["Calc_supply"].Rows.Find(Convert.ToInt32(ob_Data_supper[6])).ItemArray;

                double resolt = Convert.ToDouble(ob_Data_Calco[2]) - Convert.ToDouble(vr.txt_return_total.Text);
                if (resolt >= 0)
                {
                    ob_Data_Calco[2] = resolt;
                    new classs_table.Items_Tools().update_Rows_Table_Database("Calc_supply", ob_Data_Calco[0].ToString(), ob_Data_Calco);
                }
                else
                {
                    ob_Data_Calco[2] = 0;
                    ob_Data_Calco[1] = Math.Abs(resolt);

                    DialogResult dr = MessageBox.Show($"رصيد المرتجع اكبر من رصيد المورد هل تريد ان يكون المورد مدين بمبلغ{Convert.ToDouble(ob_Data_Calco[1]).ToString("N0")}", "تنبية", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                    if (dr==DialogResult.Yes)
                    {

                    new classs_table.Items_Tools().update_Rows_Table_Database("Calc_supply", ob_Data_Calco[0].ToString(), ob_Data_Calco);
                    }
                    else
                    {
                        return;
                    }
                  
                }


                for (int i = 0; i < vr.dgv_return_prodect.Rows.Count; i++)
                {
                    if (Convert.ToInt32(vr.dgv_return_prodect.Rows[i].Cells[13].Value) == 1)
                    {

                        dr_sum_Storg[2] = Convert.ToDouble(Convert.ToDouble(dr_sum_Storg[2]) - (Convert.ToDouble(vr.dgv_return_prodect.Rows[i].Cells[7].Value) * Convert.ToInt32(vr.dgv_return_prodect.Rows[i].Cells[4].Value))).ToString("N0");
                        dr_sum_Storg[3] = Convert.ToDouble(Convert.ToDouble(dr_sum_Storg[3]) - (Convert.ToDouble(vr.dgv_return_prodect.Rows[i].Cells[8].Value) * Convert.ToInt32(vr.dgv_return_prodect.Rows[i].Cells[4].Value))).ToString("N0");

                        object[] dr_Item = DB_Add_delete_update_.Database.ds.Tables["Item_storg"].Rows.Find(Convert.ToInt32(vr.dgv_return_prodect.Rows[i].Cells[14].Value)).ItemArray;
                        dr_Item[1] = Convert.ToInt32(vr.dgv_return_prodect.Rows[i].Cells[6].Value) - Convert.ToInt32(vr.dgv_return_prodect.Rows[i].Cells[4].Value);//تعديل الكمية الكمبة
                        DataRow[] dr_unit = DB_Add_delete_update_.Database.ds.Tables["unite_items"].Select("item_no = " + dr_Item[9]); //جلب عدد الوحداد 


                        if (Convert.ToInt32(dr_Item[12]) == 1)
                        {
                            int num_Avrg = Convert.ToInt32(vr.dgv_return_prodect.Rows[i].Cells[4].Value) * Convert.ToInt32(dr_unit[0][4]);//حساب الوحداد الوسطاء
                            dr_Item[13] = Convert.ToInt32(dr_Item[13]) - num_Avrg;//ناتج الوحدات الوسطاء
                            int sum_smool = num_Avrg * Convert.ToInt32(dr_unit[0][5]);// حساب كمية الوحدة الصغرا 
                            dr_Item[14] = sum_smool;

                        }
                        else if (Convert.ToInt32(dr_Item[12]) == 2)
                        {
                            int sum_smool = Convert.ToInt32(dr_Item[1]) * Convert.ToInt32(dr_unit[0][5]);// حساب كمية الوحدة الصغرا 
                            dr_Item[14] = sum_smool;
                            //MessageBox.Show(sum_smool + "");

                        }
                        else if (Convert.ToInt32(dr_Item[12]) == 3)
                        {
                            dr_Item[14] = dr_Item[1]; //تحديث الوحدة الصغرا

                        }
                        new classs_table.Items_Tools().update_Rows_Table_Database("Item_storg", dr_Item[0].ToString(), dr_Item);



                    }
                }


                dr_sum_Storg[4] = (Convert.ToDouble(dr_sum_Storg[2]) - Convert.ToDouble(dr_sum_Storg[3])).ToString("N0");

                dr_Totil_footr[1] = dr_sum_Storg[3];

                if (Convert.ToInt32(dr_Totil_footr[2]) != 0)
                {
                    double All_begin = Convert.ToDouble(dr_sum_Storg[3]);
                    double Dico = Convert.ToDouble(dr_Totil_footr[2]) / 100;

                    double resolt1 = All_begin * Dico;
                    double resolt2 = All_begin - resolt1;

                    dr_Totil_footr[5] = resolt2 == 0 ? 0.ToString() : (Convert.ToDouble(dr_Totil_footr[5]) - resolt2).ToString("N0");
                }
                else
                {
                    dr_Totil_footr[5] = dr_Totil_footr[1];
                }
               

                new classs_table.Items_Tools().update_Rows_Table_Database("sum_storg_Item", dr_sum_Storg[0].ToString(), dr_sum_Storg);
                new classs_table.Items_Tools().update_Rows_Table_Database("Totel_Footer_prodeuct", dr_Totil_footr[0].ToString(), dr_Totil_footr);



                MessageBox.Show("تم التعديل بنجاح ", "ارجاع", MessageBoxButtons.OK, MessageBoxIcon.Information);

                vr.dgv_return_prodect.Rows.Clear();
                vr.txt_name_supper_returns.Clear();
                vr.txt_num_supper_return.Clear();
                vr.txt_num_supper_return.Clear();




            }
        }

        public void Edting_Control_shawing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            var vr = Application.OpenForms["Main"] as Main;
            if (vr.dgv_return_prodect.CurrentRow != null)
            {
                if (vr.dgv_return_prodect.CurrentCell.ColumnIndex == 4 || vr.dgv_return_prodect.CurrentCell.ColumnIndex == 5)
                {
                    if (e.Control is TextBox)
                    {
                        e.Control.KeyPress += delegate (object Mysned, KeyPressEventArgs Mye)
                        {
                            if (!(char.IsDigit(Mye.KeyChar) || Mye.KeyChar == 8))
                            {
                                Mye.Handled = true;
                            }
                        };
                    }
                }
            }
        }

        public void Dgv_return_prodect_CellEndEdit_(object sender, DataGridViewCellEventArgs e)
        {
            var vr = Application.OpenForms["Main"] as Main;

            bool temp = true;


            if (vr.dgv_return_prodect.CurrentCell.ColumnIndex == 4)
            {
                if (Convert.ToInt32(vr.dgv_return_prodect.CurrentRow.Cells[4].Value) > Convert.ToInt32(vr.dgv_return_prodect.CurrentRow.Cells[9].Value))
                {
                    temp = false;
                    MessageBox.Show("الكمية المحولة اكبر من الكمية المخزنة", "تحذير", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    vr.dgv_return_prodect.CurrentCell.Value = num_qutly_return_.ToString();
                }
                else if (vr.dgv_return_prodect.CurrentRow.Cells[4].Value == null)
                {
                    vr.dgv_return_prodect.CurrentCell.Value = num_qutly_return_.ToString();
                }

                chackReturn(4);
            }
            else if (vr.dgv_return_prodect.CurrentCell.ColumnIndex == 5)
            {
                if (Convert.ToInt32(vr.dgv_return_prodect.CurrentRow.Cells[5].Value) > Convert.ToInt32(vr.dgv_return_prodect.CurrentRow.Cells[11].Value))
                {
                    temp = false;
                    MessageBox.Show("البونص المحولة اكبر من البونص المخزن", "تحذير", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    vr.dgv_return_prodect.CurrentCell.Value = num_qutly_return_.ToString();
                }
                else if (vr.dgv_return_prodect.CurrentRow.Cells[5].Value == null)
                {
                    vr.dgv_return_prodect.CurrentCell.Value = num_qutly_return_.ToString();
                }

                chackReturn(5);

            }

            if (temp)
            {


                double total = 0.0;

                for (int i = 0; i < vr.dgv_return_prodect.Rows.Count; i++)
                {
                    if (Convert.ToInt32(vr.dgv_return_prodect.Rows[i].Cells[4].Value) != 0)
                    {
                        total += Convert.ToDouble(vr.dgv_return_prodect.Rows[i].Cells[4].Value) * Convert.ToDouble(vr.dgv_return_prodect.Rows[i].Cells[8].Value);
                    }
                }

                vr.txt_return_total.Text = total.ToString("N0");

            }

        }

        public void Dgv_return_prodect_CellBeginEdit_(object sender, DataGridViewCellCancelEventArgs e)
        {
            var vr = Application.OpenForms["Main"] as Main;

            if (vr.dgv_return_prodect.CurrentRow != null)
            {
                if (vr.dgv_return_prodect.CurrentCell.ColumnIndex == 4)
                {

                    num_qutly_return_ = Convert.ToInt32(vr.dgv_return_prodect.CurrentRow.Cells[4].Value);
                }
                else if (vr.dgv_return_prodect.CurrentCell.ColumnIndex == 5)
                {
                    num_qutly_return_ = Convert.ToInt32(vr.dgv_return_prodect.CurrentRow.Cells[5].Value);
                }
            }



        }

        public void Txt_serch_num_footer_KeyDown_(object sender, KeyEventArgs e)
        {
            var vr = Application.OpenForms["Main"] as Main;
            if (e.KeyCode == Keys.Enter)
            {
                if (vr.txt_serch_num_foote.Text.Trim() != string.Empty && vr.txt_name_supper_returns.Text != string.Empty)
                {

                    DataRow[] dr_footer = DB_Add_delete_update_.Database.ds.Tables["Data_Footer"].Select("Foot_number = '" + vr.txt_serch_num_foote.Text + "' and Foot_supper = " + Convert.ToInt32(vr.txt_num_supper_return.Text));
                    if (dr_footer.Count() == 0)
                    {
                        MessageBox.Show("يرجاء التئكد من رقم  الفاتورة" + dr_footer.Count());
                    }
                    else
                    {
                        vr.dgv_return_prodect.Rows.Clear();

                        DataRow dr_storg = DB_Add_delete_update_.Database.ds.Tables["Storg"].Rows.Find(Convert.ToInt32(dr_footer[0][2]));

                        DataRow Foot_Totil = DB_Add_delete_update_.Database.ds.Tables["Totel_Footer_prodeuct"].Rows.Find(Convert.ToInt32(dr_footer[0][9]));
                        DataRow[] Item_return_prodect = DB_Add_delete_update_.Database.ds.Tables["Item_storg"].Select("sum_num =" + Convert.ToInt32(dr_footer[0][7]));
                        for (int i = 0; i < Item_return_prodect.Count(); i++)
                        {
                            DataRow Item_GetName = DB_Add_delete_update_.Database.ds.Tables["Item"].Rows.Find(Convert.ToInt32(Item_return_prodect[i][9]));
                            DataRow unit_GetName = DB_Add_delete_update_.Database.ds.Tables["therpeutic_unite"].Rows.Find(Convert.ToInt32(Item_return_prodect[i][10]));


                            vr.dgv_return_prodect.Rows.Add((i + 1).ToString(), Item_return_prodect[i][9], Item_GetName[2], unit_GetName[1], "0", "0", (Convert.ToInt32(Item_return_prodect[i][1]) + Convert.ToInt32(Item_return_prodect[i][3])), Item_return_prodect[i][8], Item_return_prodect[i][7], Item_return_prodect[i][1], Convert.ToDateTime(Item_return_prodect[i][2]).ToString("d"), Item_return_prodect[i][3], "0", 0, Item_return_prodect[i][0]);
                        }

                        vr.txt_return_prodect_totil.Text = Convert.ToDouble(Foot_Totil[5]).ToString("N0");
                        vr.txt_name_storg_retuen.Text = dr_storg[1].ToString();
                        vr.txt_num_storg_retuen.Text = dr_footer[0][2].ToString();
                        vr.lbl_num_Fottr.Text = dr_footer[0][0].ToString();

                    }


                }
                else if (vr.txt_name_supper_returns.Text == string.Empty)
                {
                    MessageBox.Show("يرجاء تعبئة المورد");

                }
            }
        }


        public void Txt_num_supper_return_KeyDown_(object sender, KeyEventArgs e)
        {
            var vr = Application.OpenForms["Main"] as Main;
            if (e.KeyCode == Keys.Enter)
            {
                int num_supper = vr.txt_num_supper_return.Text.Trim() == string.Empty ? 0 : Convert.ToInt32(vr.txt_num_supper_return.Text.Trim());
                DataRow dr_supperr_prodect = DB_Add_delete_update_.Database.ds.Tables["Supplier"].Rows.Find(num_supper);
                if (dr_supperr_prodect != null)
                {
                    if (Convert.ToInt32(dr_supperr_prodect[4]) == 0)
                    {

                        vr.txt_num_supper_return.Text = dr_supperr_prodect[0].ToString();
                        vr.txt_name_supper_returns.Text = dr_supperr_prodect[1].ToString();



                    }
                    else
                    {
                        MessageBox.Show($" المورد {dr_supperr_prodect[1].ToString()}  موقف  ", "توقيف");

                    }
                }
                else
                {
                    MessageBox.Show("الرقم المدخل غير صحيح", "لايوجد");
                    vr.txt_name_supper_returns.Text = "";
                }
            }
        }

    }
}
