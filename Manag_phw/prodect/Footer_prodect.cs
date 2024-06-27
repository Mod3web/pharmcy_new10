using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Manag_ph.prodect
{
    class Footer_prodect
    {

        double Resolt_Discount = 0;

        double Temp_cells_end = 0;

        int num_unit_selct_dgv = 0;


        public int num_unit_selct_dgv_
        {
            get { return num_unit_selct_dgv; }
            set { num_unit_selct_dgv = value; }
        }



        public double Temp_cells_end_
        {
            get { return Temp_cells_end; }
            set { Temp_cells_end = value; }
        }


        public void Txt_amount_paid_TextChanged_()
        {
            var vr = Application.OpenForms["Main"] as Main;

            if (vr.txt_amount_paid.Text!=string.Empty)
            {
                calc_tream_amou();
            }
            else
            {
                return;
            }
        }

        public void _Txt_num__KeyDown_1(object sender, KeyEventArgs e)
        {
            var vr = Application.OpenForms["Main"] as Main;
            if (e.KeyCode == Keys.Enter)
            {
                int num_supper = vr.txt_num_Supplier_prodect.Text.Trim() == string.Empty ? 0 : Convert.ToInt32(vr.txt_num_Supplier_prodect.Text.Trim());
                DataRow dr_supperr_prodect = DB_Add_delete_update_.Database.ds.Tables["Supplier"].Rows.Find(num_supper);
                if (dr_supperr_prodect != null)
                {
                    if (Convert.ToInt32(dr_supperr_prodect[4]) == 0)
                    {
                        int num_calc_supper_pro = Convert.ToInt32(dr_supperr_prodect[6]);
                        DataRow dr_supperr_calc_prodect = DB_Add_delete_update_.Database.ds.Tables["Calc_supply"].Rows.Find(num_calc_supper_pro);

                        vr.txt_calc_Supplier_prodect.Text = Convert.ToDouble(dr_supperr_calc_prodect[2]).ToString("N0");
                        vr.txt_num_Supplier_prodect.Text = dr_supperr_prodect[0].ToString();
                        vr.txt_name_Supplier_prodect.Text = dr_supperr_prodect[1].ToString();



                    }
                    else
                    {
                        MessageBox.Show($" المورد {dr_supperr_prodect[1].ToString()}  موقف  ", "توقيف");

                    }
                }
                else
                {
                    MessageBox.Show("الرقم المدخل غير صحيح", "لايوجد");
                    vr.txt_name_storg_prodect.Text = "";
                }
            }
        }

        public void fill_com_typr_prodect()
        {
            var vr = Application.OpenForms["Main"] as Main;
            DataTable dt = new DataTable();
            dt.Columns.Add("name", typeof(string));
            dt.Columns.Add("id", typeof(int));
            dt.Rows.Add("اجل", 1);

            vr.com_type_prodect.DisplayMember = "name";
            vr.com_type_prodect.ValueMember = "id";
            vr.com_type_prodect.DataSource = dt;




        }

        //جلب الكميات السابقة لصنف في المخزن بنا علا الوحدات
        public void get_qutly_old(int Type_unit)
        {
            var vr = Application.OpenForms["Main"] as Main;

            int Num_Item_prodect = Convert.ToInt32(vr.dgv_prodect.CurrentRow.Cells[1].Value);
            DataTable dt_Items_storg = new DataTable();

            dt_Items_storg = new classs_table.Items_Tools().GetItems_Storg_All(Convert.ToInt32(vr.txt_num_storg_prodect.Text));

            DataRow[] dr_Items_s = dt_Items_storg.Select("Item_no = " + Num_Item_prodect + " and type_unit = " + Type_unit);
            if (dr_Items_s.Count() != 0)
            {
                int All_qutyle = 0;
                for (int i = 0; i < dr_Items_s.Count(); i++)
                {
                    All_qutyle += Convert.ToInt32(dr_Items_s[i][1]);
                }
                vr.dgv_prodect.CurrentRow.Cells[7].Value = All_qutyle;

            }
            else
            {
                vr.dgv_prodect.CurrentRow.Cells[7].Value = 0;

            }
        }


        public void calc_tream_amou()
        {
            var vr = Application.OpenForms["Main"] as Main;
            if (vr.txt_amount_paid.Text.Trim()!=string.Empty)
            {
                if (Convert.ToDouble(vr.txt_amount_paid.Text.Trim()) > Convert.ToDouble(vr.txt_end_Dico_All.Text))
                {
                    MessageBox.Show("المبلغ المدفوع اكبر من المبلغ المستحق", "Error", MessageBoxButtons.OK,MessageBoxIcon.Error);
                    vr.txt_amount_paid.Text = "0";
                    vr.txt_amount_paid.Focus();
                    vr.txt_amount_paid.SelectAll();
                    return;
                }
                vr.txt_term_amoun.Text = (Convert.ToDouble(vr.txt_end_Dico_All.Text) - Convert.ToDouble(vr.txt_amount_paid.Text)).ToString("N0");
            }
            else
            {
                vr.txt_term_amoun.Text = Convert.ToDouble(vr.txt_end_Dico_All.Text).ToString("N0");

            }
        }

        public void Totil_All_Fotter()
        {
            var vr = Application.OpenForms["Main"] as Main;

            int Dicount_Rate_All = 0;
            int Dicount_value_All = 0;

            if (vr.txt_Dicount_Rate_All.Text != string.Empty)
            {
                double All_begin = Convert.ToDouble(vr.txt_begin_Dicount_All.Text);
                double Dico = Convert.ToDouble(vr.txt_Dicount_Rate_All.Text) / 100;

                double resolt1 = All_begin * Dico;
                double resolt2 = All_begin - resolt1;

                vr.txt_end_Dico_All.Text = resolt2.ToString("N0");
                calc_tream_amou();


            }
            else
            {
                vr.txt_end_Dico_All.Text = vr.txt_begin_Dicount_All.Text;
                calc_tream_amou();
            }


            if (vr.txt_Dicount_value_All.Text != string.Empty)
            {
                double All_begin = Convert.ToDouble(vr.txt_end_Dico_All.Text);
                double Dico = Convert.ToDouble(vr.txt_Dicount_value_All.Text);
                if (Dico >= All_begin)
                {
                    MessageBox.Show("الخصم اكبر من الرصيد الكلي ", "تحذير", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    vr.txt_Dicount_value_All.Text = "0";
                }
                else
                {
                    double resolt1 = All_begin - Dico;
                    vr.txt_end_Dico_All.Text = resolt1.ToString("N0");
                    calc_tream_amou();
                }

            }


        }

        public void Totil()
        {
            var vr = Application.OpenForms["Main"] as Main;
            int count_item = 0;
            double Totel_Pris = 0;
            double Totel_prifix = 0;
            double Totel_prodect = 0;

            double Totel_Begin_Dic_All = 0;

            for (int i = 0; i < vr.dgv_prodect.Rows.Count; i++)
            {
                if (vr.dgv_prodect.Rows[i].Cells[14].Value.ToString() != "null")
                {
                    count_item++;
                    Totel_Pris += Convert.ToDouble(vr.dgv_prodect.Rows[i].Cells[8].Value) * Convert.ToInt32(vr.dgv_prodect.Rows[i].Cells[4].Value);
                    Totel_prifix += Convert.ToDouble(vr.dgv_prodect.Rows[i].Cells[12].Value);
                    Totel_prodect += Convert.ToDouble(vr.dgv_prodect.Rows[i].Cells[13].Value);
                    Totel_Begin_Dic_All += Convert.ToDouble(vr.dgv_prodect.Rows[i].Cells[13].Value);
                }

            }
            vr.txt_begin_Dicount_All.Text = Totel_Begin_Dic_All.ToString("N0");
            vr.lbl_count_Item.Text = count_item.ToString();
            vr.lbl_count_pric.Text = Totel_Pris.ToString("N0");
            vr.lbl_count_prifix.Text = (Totel_Pris - Totel_prodect).ToString("N0");
            vr.lbl_Count_prodect.Text = Totel_prodect.ToString("N0");

            Totil_All_Fotter();
        }


        double Temp_Dicount = 0;
        public void Discount_calc_prodect()
        {
            var vr = Application.OpenForms["Main"] as Main;

            double sell = Convert.ToDouble(vr.dgv_prodect.CurrentRow.Cells[14].Value);
            double pric_ns = Convert.ToDouble(vr.dgv_prodect.CurrentRow.Cells[9].Value) / 100;
            double reslt = sell * pric_ns;
            double reslt2 = sell - reslt;
            Temp_Dicount = reslt2;
            vr.dgv_prodect.CurrentRow.Cells[11].Value = reslt2.ToString("N0");

            double pric = Convert.ToDouble(vr.dgv_prodect.CurrentRow.Cells[8].Value);
            double prode = Convert.ToDouble(vr.dgv_prodect.CurrentRow.Cells[11].Value);
            double resolt = pric - prode;
            vr.dgv_prodect.CurrentRow.Cells[12].Value = Convert.ToDouble(resolt).ToString("N0");

            int qutly = Convert.ToInt32(vr.dgv_prodect.CurrentRow.Cells[4].Value);
            double prodect = Convert.ToDouble(vr.dgv_prodect.CurrentRow.Cells[11].Value);
            checked
            {
                double resol = prodect * qutly;
                vr.dgv_prodect.CurrentRow.Cells[13].Value = resol.ToString("N0");
            }


            Aotm_tax();


        }
        public void Aotm_tax()
        {
            var vr = Application.OpenForms["Main"] as Main;
            double tax = Convert.ToDouble(vr.dgv_prodect.CurrentRow.Cells[10].Value) / 100;
            double prodect = Temp_Dicount;

            double reslt = prodect * tax;

            double reslt2 = prodect - reslt;
            vr.dgv_prodect.CurrentRow.Cells[11].Value = reslt2.ToString("N0");
            double pric = Convert.ToDouble(vr.dgv_prodect.CurrentRow.Cells[8].Value);
            double prode = Convert.ToDouble(vr.dgv_prodect.CurrentRow.Cells[11].Value);
            double resolt = pric - prode;
            vr.dgv_prodect.CurrentRow.Cells[12].Value = Convert.ToDouble(resolt).ToString("N0");

            int qutly = Convert.ToInt32(vr.dgv_prodect.CurrentRow.Cells[4].Value);
            double prodects = Convert.ToDouble(vr.dgv_prodect.CurrentRow.Cells[11].Value);
            checked
            {
                double resol = prodects * qutly;
                vr.dgv_prodect.CurrentRow.Cells[13].Value = resol.ToString("N0");
            }

        }
        public void _DataGridView5_CellEndEdit()
        {
            var vr = Application.OpenForms["Main"] as Main;


            if (vr.dgv_prodect.CurrentCell.ColumnIndex == 1)
            {
                int Num_Item_prodect = vr.dgv_prodect.CurrentRow.Cells[1].Value.ToString() != "" ? Convert.ToInt32(vr.dgv_prodect.CurrentRow.Cells[1].Value) : 0;

                DataRow dr_row = DB_Add_delete_update_.Database.ds.Tables["Item"].Rows.Find(Num_Item_prodect);
                if (Convert.ToInt32(dr_row[8]) == 0)
                {
                    if (vr.txt_name_storg_prodect.Text != "" || vr.txt_name_Supplier_prodect.Text != "")
                    {

                        DataRow[] dr_pric = DB_Add_delete_update_.Database.ds.Tables["pric"].Select("Item_no = " + Num_Item_prodect);

                        DataRow[] dr_unit_pro = DB_Add_delete_update_.Database.ds.Tables["unite_items"].Select("Item_no = " + Num_Item_prodect);
                        DataGridViewComboBoxCell DGV_Prodect = vr.dgv_prodect.CurrentRow.Cells[3] as DataGridViewComboBoxCell;
                        if (dr_row != null)
                        {
                            DataRow dr_unit_pro_kptol = DB_Add_delete_update_.Database.ds.Tables["therpeutic_unite"].Rows.Find(Convert.ToInt32(dr_unit_pro[0][1]));
                            DataRow dr_unit_pro_avrg = DB_Add_delete_update_.Database.ds.Tables["therpeutic_unite"].Rows.Find(Convert.ToInt32(dr_unit_pro[0][2]));
                            DataRow dr_unit_pro_smool = DB_Add_delete_update_.Database.ds.Tables["therpeutic_unite"].Rows.Find(Convert.ToInt32(dr_unit_pro[0][3]));
                            vr.dgv_prodect.CurrentRow.Cells[2].Value = dr_row[1].ToString();
                            DGV_Prodect.Items.Clear();
                            vr.dgv_prodect.CurrentRow.Cells[15].Value = $"{ dr_unit_pro_kptol[0].ToString()} " + $";{dr_unit_pro_avrg[0].ToString()} " + $";{dr_unit_pro_smool[0].ToString()}";
                            vr.dgv_prodect.CurrentRow.Cells[16].Value = 1;
                            DGV_Prodect.Items.AddRange(new object[] { dr_unit_pro_kptol[1].ToString(), dr_unit_pro_avrg[1].ToString(), dr_unit_pro_smool[1].ToString() });
                            DGV_Prodect.Value = DGV_Prodect.Items[0];
                            if (!vr.prodect_open_Items)
                            {
                                vr.dgv_prodect.CurrentRow.Cells[4].Value = 1;
                                vr.dgv_prodect.CurrentRow.Cells[6].Value = 0;

                            }

                            get_qutly_old(1);

                            vr.dgv_prodect.CurrentRow.Cells[8].Value = Convert.ToDouble(dr_pric[0][1]).ToString("N0");
                            vr.dgv_prodect.CurrentRow.Cells[9].Value = Convert.ToInt32(dr_pric[0][2]);
                            vr.dgv_prodect.CurrentRow.Cells[10].Value = Convert.ToInt32(dr_pric[0][3]);
                            vr.dgv_prodect.CurrentRow.Cells[11].Value = Convert.ToDouble(dr_pric[0][4]).ToString("N0");
                            vr.dgv_prodect.CurrentRow.Cells[12].Value = Convert.ToDouble(Convert.ToDouble(vr.dgv_prodect.CurrentRow.Cells[8].Value) - Convert.ToDouble(vr.dgv_prodect.CurrentRow.Cells[11].Value)).ToString("N0");
                            vr.dgv_prodect.CurrentRow.Cells[13].Value = Convert.ToDouble(dr_pric[0][4]).ToString("N0");
                            vr.dgv_prodect.CurrentRow.Cells[14].Value = Convert.ToDouble(dr_pric[0][4]).ToString("N0");

                            Totil();
                        }
                        else
                        {
                            MessageBox.Show("الصنف ليس موجود");
                        }


                    }
                    else
                    {
                        MessageBox.Show("يرجاء ادخال بيانات الفاتورة");

                    }


                }
                else
                {
                    MessageBox.Show("الصنف المدخل تم ايقاف التعامل معة");
                    vr.dgv_prodect.Rows.RemoveAt(vr.dgv_prodect.CurrentRow.Index);
                    if (vr.dgv_prodect.Rows.Count == 0)
                    {
                        vr.txt_begin_Dicount_All.Text = "000";
                        vr.lbl_count_Item.Text = "000";
                        vr.lbl_count_pric.Text = "000";
                        vr.lbl_count_prifix.Text = "000";
                        vr.lbl_Count_prodect.Text = "000";

                        vr.txt_Dicount_Rate_All.Text = "000";
                        vr.txt_Dicount_value_All.Text = "000";
                        vr.txt_end_Dico_All.Text = "000";
                        vr.txt_begin_Dicount_All.Text = "000";
                    }
                    else
                    {
                        Totil();
                        Discount_calc_prodect();
                    }


                }
            }
            else if (vr.dgv_prodect.CurrentCell.ColumnIndex == 4)
            {
                if (vr.dgv_prodect.CurrentRow.Cells[4].Value != "" || Convert.ToInt32(vr.dgv_prodect.CurrentRow.Cells[4].Value) != 0)
                {
                    int qutly = Convert.ToInt32(vr.dgv_prodect.CurrentRow.Cells[4].Value);

                    double prodect = Convert.ToDouble(vr.dgv_prodect.CurrentRow.Cells[11].Value);
                    checked
                    {
                        double resol = prodect * qutly;

                        vr.dgv_prodect.CurrentRow.Cells[13].Value = resol.ToString("N0");
                        Totil();
                    }


                }
                else
                {
                    vr.dgv_prodect.CurrentRow.Cells[4].Value = 1;
                }

            }
            else if (vr.dgv_prodect.CurrentCell.ColumnIndex == 9)
            {
                Discount_calc_prodect();
                Totil();
            }
            else if (vr.dgv_prodect.CurrentCell.ColumnIndex == 10)
            {
                Discount_calc_prodect();
                Aotm_tax();
                Totil();

            }
            else if (vr.dgv_prodect.CurrentCell.ColumnIndex == 8)
            {
                Totil();
            }
            else if (vr.dgv_prodect.CurrentCell.ColumnIndex == 11)
            {
                Discount_calc_prodect();
                Aotm_tax();
                Totil();


            }

        }

        public void Dgv_prodect_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            var vr = Application.OpenForms["Main"] as Main;

            if (vr.dgv_prodect.CurrentRow != null)
            {
                if (vr.dgv_prodect.CurrentCell.ColumnIndex == 1 || vr.dgv_prodect.CurrentCell.ColumnIndex == 4 || vr.dgv_prodect.CurrentCell.ColumnIndex == 6 || vr.dgv_prodect.CurrentCell.ColumnIndex == 7 || vr.dgv_prodect.CurrentCell.ColumnIndex == 8 || vr.dgv_prodect.CurrentCell.ColumnIndex == 9 || vr.dgv_prodect.CurrentCell.ColumnIndex == 10 || vr.dgv_prodect.CurrentCell.ColumnIndex == 11)
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
                else if (vr.dgv_prodect.CurrentCell.ColumnIndex == 3)
                {
                    ComboBox com = new ComboBox();
                    com = e.Control as ComboBox;

                    com.SelectedIndexChanged += delegate (object Mysender, EventArgs Me)
                    {
                        if (com.SelectedIndex == 0)
                        {

                            int Num_Item_prodect = Convert.ToInt32(vr.dgv_prodect.CurrentRow.Cells[1].Value);
                            DataRow[] dr_unit_pri = DB_Add_delete_update_.Database.ds.Tables["unite_items"].Select("item_no = " + Num_Item_prodect);

                            DataRow[] dr_pric = DB_Add_delete_update_.Database.ds.Tables["pric"].Select("Item_no = " + Num_Item_prodect);
                            vr.dgv_prodect.CurrentRow.Cells[4].Value = 1;
                            vr.dgv_prodect.CurrentRow.Cells[8].Value = Convert.ToDouble(dr_pric[0][1]).ToString("N0");
                            vr.dgv_prodect.CurrentRow.Cells[11].Value = Convert.ToDouble(dr_pric[0][4]).ToString("N0");
                            vr.dgv_prodect.CurrentRow.Cells[14].Value = Convert.ToDouble(dr_pric[0][4]).ToString("N0");
                            vr.dgv_prodect.CurrentRow.Cells[9].Value = 0;
                            vr.dgv_prodect.CurrentRow.Cells[10].Value = 0;

                            vr.dgv_prodect.CurrentRow.Cells[16].Value = 1;

                            double pric = Convert.ToDouble(vr.dgv_prodect.CurrentRow.Cells[8].Value);
                            double prode = Convert.ToDouble(vr.dgv_prodect.CurrentRow.Cells[11].Value);
                            double resolt = pric - prode;
                            vr.dgv_prodect.CurrentRow.Cells[12].Value = Convert.ToDouble(resolt).ToString("N0");
                            vr.dgv_prodect.CurrentRow.Cells[13].Value = Convert.ToDouble(vr.dgv_prodect.CurrentRow.Cells[11].Value).ToString("N0");




                            get_qutly_old(1);
                            Totil();

                        }
                        else if (com.SelectedIndex == 1)
                        {
                            int Num_Item_prodect = Convert.ToInt32(vr.dgv_prodect.CurrentRow.Cells[1].Value);
                            DataRow[] dr_unit_pri = DB_Add_delete_update_.Database.ds.Tables["unite_items"].Select("item_no = " + Num_Item_prodect);

                            DataRow[] dr_pric = DB_Add_delete_update_.Database.ds.Tables["pric"].Select("Item_no = " + Num_Item_prodect);
                            vr.dgv_prodect.CurrentRow.Cells[4].Value = 1;
                            vr.dgv_prodect.CurrentRow.Cells[8].Value = Convert.ToDouble(dr_unit_pri[0][6]).ToString("N0");
                            vr.dgv_prodect.CurrentRow.Cells[11].Value = Convert.ToDouble(Convert.ToDouble(dr_pric[0][4]) / Convert.ToInt32(dr_unit_pri[0][4])).ToString("N0");
                            vr.dgv_prodect.CurrentRow.Cells[9].Value = 0;
                            vr.dgv_prodect.CurrentRow.Cells[10].Value = 0;
                            vr.dgv_prodect.CurrentRow.Cells[14].Value = Convert.ToDouble(Convert.ToDouble(dr_pric[0][4]) / Convert.ToInt32(dr_unit_pri[0][4])).ToString("N0");

                            vr.dgv_prodect.CurrentRow.Cells[16].Value = 2;


                            double pric = Convert.ToDouble(vr.dgv_prodect.CurrentRow.Cells[8].Value);
                            double prode = Convert.ToDouble(vr.dgv_prodect.CurrentRow.Cells[11].Value);
                            double resolt = pric - prode;
                            vr.dgv_prodect.CurrentRow.Cells[12].Value = Convert.ToDouble(resolt).ToString("N0");
                            vr.dgv_prodect.CurrentRow.Cells[13].Value = Convert.ToDouble(vr.dgv_prodect.CurrentRow.Cells[11].Value).ToString("N0");


                            get_qutly_old(2);
                            Totil();
                        }
                        else if (com.SelectedIndex == 2)
                        {
                            int Num_Item_prodect = Convert.ToInt32(vr.dgv_prodect.CurrentRow.Cells[1].Value);
                            DataRow[] dr_unit_pri = DB_Add_delete_update_.Database.ds.Tables["unite_items"].Select("item_no = " + Num_Item_prodect);

                            DataRow[] dr_pric = DB_Add_delete_update_.Database.ds.Tables["pric"].Select("Item_no = " + Num_Item_prodect);
                            vr.dgv_prodect.CurrentRow.Cells[4].Value = 1;
                            vr.dgv_prodect.CurrentRow.Cells[8].Value = Convert.ToDouble(dr_unit_pri[0][7]).ToString("N0");
                            vr.dgv_prodect.CurrentRow.Cells[9].Value = 0;
                            vr.dgv_prodect.CurrentRow.Cells[10].Value = 0;

                            vr.dgv_prodect.CurrentRow.Cells[16].Value = 3;


                            double resolt_avrg = Convert.ToDouble(Convert.ToDouble(dr_pric[0][4]) / Convert.ToInt32(dr_unit_pri[0][4]));
                            double resolt_smool = resolt_avrg / Convert.ToInt32(dr_unit_pri[0][5]);

                            vr.dgv_prodect.CurrentRow.Cells[11].Value = resolt_smool.ToString("N0");
                            vr.dgv_prodect.CurrentRow.Cells[14].Value = resolt_smool.ToString("N0");



                            double pric = Convert.ToDouble(vr.dgv_prodect.CurrentRow.Cells[8].Value);
                            double prode = Convert.ToDouble(vr.dgv_prodect.CurrentRow.Cells[11].Value);
                            double resolt = pric - prode;
                            vr.dgv_prodect.CurrentRow.Cells[12].Value = Convert.ToDouble(resolt).ToString("N0");
                            vr.dgv_prodect.CurrentRow.Cells[13].Value = Convert.ToDouble(vr.dgv_prodect.CurrentRow.Cells[11].Value).ToString("N0");

                            get_qutly_old(3);
                            Totil();
                        }
                    };

                }
            }
        }

        public void Save_data_And_Footer_All()
        {
            var vr = Application.OpenForms["Main"] as Main;


            if (vr.txt_name_storg_prodect.Text == string.Empty)
            {
                vr.checkData = false;
                MessageBox.Show("يرجاء تعبئة بيانات المخازن", "حفض", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            else if (vr.txt_name_Supplier_prodect.Text == string.Empty)
            {
                vr.checkData = false;
                MessageBox.Show("يرجاء تعبئة بيانات المورد", "حفض", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            else if (vr.txt_num_Footer.Text.Trim() == string.Empty)
            {
               
                vr.checkData = false;
                MessageBox.Show("يرجاء تعبئة رقم الفاتورة", "حفض", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
           
            else if (vr.dgv_prodect.Rows.Count == 0 || vr.dgv_prodect.CurrentRow.Cells[14].Value.ToString() == "null")
            {
                vr.checkData = false;
                MessageBox.Show("يرجاء تعبئة الجدول", "حفض", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                if (vr.dgv_prodect.CurrentRow != null)
                {
                    for (int i = 0; i < vr.dgv_prodect.Rows.Count; i++)
                    {
                        if (vr.dgv_prodect.Rows[i].Cells[14].Value.ToString() == "null")
                        {
                            vr.checkData = false;
                            MessageBox.Show("يوجد صفوف فارفة", "حفض", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            break;

                        }
                        else if (vr.dgv_prodect.Rows[i].Cells[4].Value == null || Convert.ToInt32(vr.dgv_prodect.Rows[i].Cells[4].Value) == 0)
                        {
                            vr.checkData = false;
                            MessageBox.Show($" {i + 1}  يرجاء التئكدم من كميات الاصناف في الصف", "حفض", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            break;
                        }
                        else if (vr.dgv_prodect.Rows[i].Cells[5].Value == null)
                        {
                            vr.checkData = false;
                            MessageBox.Show($" {i + 1} يرجاء التئكدم من تاريخ الصلاحية  في الصف ", "حفض", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            break;

                        }

                    }
                }
            }

            DataRow[] dr_check_Isnull = DB_Add_delete_update_.Database.ds.Tables["Data_Footer"].Select("Foot_number = '"+ vr.txt_num_Footer.Text +"' and Foot_supper = "+ Convert.ToInt32(vr.txt_num_Supplier_prodect.Text));
            if (dr_check_Isnull.Count()!=0)
            {
                MessageBox.Show("رقم الفاتورة قد تم اضافتة من قبل يرجاء التئكد من رقم الفاتورة","Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
                return;
            }
            // لم اكمل 
            if (vr.checkData)
            {

                object[] ob_supper = DB_Add_delete_update_.Database.ds.Tables["Calc_supply"].Rows.Find(vr.txt_num_Supplier_prodect.Text == string.Empty ? 0 : Convert.ToInt32(vr.txt_num_Supplier_prodect.Text)).ItemArray;
                if (ob_supper.Count() == 0)
                {

                    MessageBox.Show("يرجاء التئكد من رقم المورد", "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (Convert.ToDouble(ob_supper[3]) != 0)
                {
                    if ((Convert.ToDouble(vr.txt_term_amoun.Text.Trim())+ Convert.ToDouble(ob_supper[2])) > Convert.ToDouble(ob_supper[3]))
                    {
                        MessageBox.Show("المبلغ الباقي اكبر من حد التعامل معا المورد", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }

                int sum_num = new classs_table.Items_Tools().AoutoNumber("sum_storg_Item", "sum_num");
                int sum_DataFooter = new classs_table.Items_Tools().AoutoNumber("Data_Footer", "Foot_code");
                int Totel_DataFooter = new classs_table.Items_Tools().AoutoNumber("Totel_Footer_prodeuct", "Totel_num");



                double Dicount_Rate_All = 0;
                double Dicount_value_All = 0;
                double tax_rapo_All = 0;

                if (vr.txt_Dicount_Rate_All.Text.Trim() != string.Empty)
                {
                    Dicount_Rate_All = Convert.ToDouble(vr.txt_Dicount_Rate_All.Text.Trim());
                }

                if (vr.txt_Dicount_value_All.Text.Trim() != string.Empty)
                {
                    Dicount_Rate_All = Convert.ToDouble(vr.txt_Dicount_value_All.Text.Trim());
                }

                if (vr.txt_tax_rapo_All.Text.Trim() != string.Empty)
                {
                    tax_rapo_All = Convert.ToDouble(vr.txt_tax_rapo_All.Text.Trim());
                }

                object[] ob_suppers = DB_Add_delete_update_.Database.ds.Tables["Supplier"].Rows.Find(Convert.ToInt32(vr.txt_num_Supplier_prodect.Text)).ItemArray;
                object[] ob_supper_calc = DB_Add_delete_update_.Database.ds.Tables["Calc_supply"].Rows.Find(Convert.ToInt32(ob_suppers[6])).ItemArray;
                ob_supper_calc[2] = Convert.ToDouble(ob_supper_calc[2]) + Convert.ToDouble(vr.txt_term_amoun.Text);

                new classs_table.Items_Tools().update_Rows_Table_Database("Calc_supply", ob_supper_calc[0].ToString(), ob_supper_calc);


                DB_Add_delete_update_.Database.ds.Tables["sum_storg_Item"].Rows.Add(sum_num, Convert.ToInt32(vr.lbl_count_Item.Text), Convert.ToDouble(vr.lbl_count_pric.Text), Convert.ToDouble(vr.lbl_Count_prodect.Text), Convert.ToDouble(vr.lbl_count_prifix.Text), Convert.ToInt32(vr.txt_num_storg_prodect.Text));
                DB_Add_delete_update_.Database.ds.Tables["Totel_Footer_prodeuct"].Rows.Add(Totel_DataFooter, Convert.ToDouble(vr.txt_begin_Dicount_All.Text), Dicount_Rate_All, Dicount_value_All, tax_rapo_All, Convert.ToDouble(vr.txt_end_Dico_All.Text));
                DB_Add_delete_update_.Database.ds.Tables["Data_Footer"].Rows.Add(sum_DataFooter, vr.txt_num_Footer.Text, Convert.ToInt32(vr.txt_num_storg_prodect.Text), null, Convert.ToInt32(vr.txt_num_Supplier_prodect.Text), Convert.ToDateTime(vr.dtp_Footer_prodect.Text).ToString("d"), vr.txt_nots_prodect.Text, sum_num, null, Totel_DataFooter);


                DB_Add_delete_update_.Database.update("sum_storg_Item");
                DB_Add_delete_update_.Database.update("Totel_Footer_prodeuct");
                DB_Add_delete_update_.Database.update("Data_Footer");


                // لم اكمل اضافة الاصناف من الجدول الا قاعدة البيانات
                //MessageBox.Show("  out loop ", "حفظ", MessageBoxButtons.OK, MessageBoxIcon.Information);

                for (int i = 0; i < vr.dgv_prodect.Rows.Count; i++)
                {
                    int Item_storg_num = new classs_table.Items_Tools().AoutoNumber("Item_storg", "storg_num");
                    int Qutly = Convert.ToInt32(vr.dgv_prodect.Rows[i].Cells[4].Value);
                    DateTime dt_pr = Convert.ToDateTime(vr.dgv_prodect.Rows[i].Cells[5].Value);
                    int pons = Convert.ToInt32(vr.dgv_prodect.Rows[i].Cells[6].Value);
                    int Rate_Discount = Convert.ToInt32(vr.dgv_prodect.Rows[i].Cells[9].Value);
                    int Rate_tax = Convert.ToInt32(vr.dgv_prodect.Rows[i].Cells[10].Value) == 0 ? 0 : Convert.ToInt32(vr.dgv_prodect.Rows[i].Cells[10].Value);
                    double value_profix = Convert.ToDouble(vr.dgv_prodect.Rows[i].Cells[12].Value) == 0.0 ? 0 : Convert.ToDouble(vr.dgv_prodect.Rows[i].Cells[12].Value);
                    double sell_prodect = Convert.ToDouble(vr.dgv_prodect.Rows[i].Cells[11].Value);
                    double sell_pric = Convert.ToDouble(vr.dgv_prodect.Rows[i].Cells[8].Value);
                    int Item_no = Convert.ToInt32(vr.dgv_prodect.Rows[i].Cells[1].Value);

                    string[] dd = vr.dgv_prodect.Rows[i].Cells[15].Value.ToString().Split(';');

                    int unit_num = 0;
                    int quity_avrg = 0;
                    int quity_smool = 0;
                    DataRow[] dr_unit_All = DB_Add_delete_update_.Database.ds.Tables["unite_items"].Select("item_no = " + Item_no);
                    int unit_dgv_num_Test = Convert.ToInt32(vr.dgv_prodect.Rows[i].Cells[16].Value);
                    if (unit_dgv_num_Test == 1)
                    {
                        int num_avrg = Convert.ToInt32(dr_unit_All[0][4]);
                        int num_smool = Convert.ToInt32(dr_unit_All[0][5]);
                        quity_avrg = Qutly * num_avrg;
                        quity_smool = quity_avrg * num_smool;
                        unit_num = Convert.ToInt32(dd[0].Trim());
                    }
                    else if (unit_dgv_num_Test == 2)
                    {
                        int num_smool = Convert.ToInt32(dr_unit_All[0][5]);
                        quity_smool = Qutly * num_smool;

                        unit_num = Convert.ToInt32(dd[1].Trim());
                    }
                    else
                    {
                        quity_smool = Qutly;
                        unit_num = Convert.ToInt32(dd[2].Trim());
                    }

                    DB_Add_delete_update_.Database.ds.Tables["Item_storg"].Rows.Add(Item_storg_num, Qutly, dt_pr.ToString("d"), pons, Rate_Discount, Rate_tax, value_profix, sell_prodect, sell_pric, Item_no, unit_num, sum_num, unit_dgv_num_Test, quity_avrg, quity_smool);
                    DB_Add_delete_update_.Database.update("Item_storg");
                    //MessageBox.Show("  mmm ", "حفظ", MessageBoxButtons.OK, MessageBoxIcon.Information);


                }


                MessageBox.Show("تم الحفظ بنجاح ", "حفظ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                vr.dgv_prodect.Rows.Clear();
            }

        }
    }
}
