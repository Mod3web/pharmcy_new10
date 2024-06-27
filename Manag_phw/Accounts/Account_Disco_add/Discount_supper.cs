using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Manag_ph.Accounts.Account_Disco_add
{
    public partial class Discount_supper : Form
    {
        public Discount_supper()
        {
            InitializeComponent();
        }



        private void Discount_supper_Load(object sender, EventArgs e)
        {
            new classs_table.My_tool_2().fill_com_alhrca(com_sbb_alhrcka);
        }

        private void Txt_num_supper_discou_acco_add_KeyDown(object sender, KeyEventArgs e)
        {
            // دالة لتعبئة اسم المورد ورصيدة
            new classs_table.Items_Tools().Fill_supper_set_id_get_name(txt_num_supper_discou_acco_add, txt_name_supper_discou_acco_add, txt_Deitor_supper_discou_acco_add, e);

        }

        private void TextEdit4_EditValueChanged(object sender, EventArgs e)
        {
            //txt_num_supper_discou_acco_add
            // حساب رصيد المورد بعد الخصم

            if (txt_sals_discount.Text.Trim() != string.Empty)
            {
                DataRow dr_Accou_Clne = DB_Add_delete_update_.Database.ds.Tables["Calc_supply"].Rows.Find(txt_num_supper_discou_acco_add.Text.Trim());

                   
                if (txt_name_supper_discou_acco_add.Text.Trim() != string.Empty)
                {


                           txt_sals_begin_calc.Text = Convert.ToDouble(Convert.ToDouble(txt_Deitor_supper_discou_acco_add.Text) - Convert.ToDouble(txt_sals_discount.Text)).ToString("N2");

                    //if (Convert.ToDouble(txt_Deitor_supper_discou_acco_add.Text) >= Convert.ToDouble(txt_sals_discount.Text))
                    //{
                    //    if (Convert.ToDouble(dr_Accou_Clne[2]) > 0 || Convert.ToDouble(dr_Accou_Clne[1]) > 0)
                    //    {
                    //        txt_sals_begin_calc.Text = Convert.ToDouble(Convert.ToDouble(txt_Deitor_supper_discou_acco_add.Text) - Convert.ToDouble(txt_sals_discount.Text)).ToString("N2");
                    //    }
                    //    else if (Convert.ToDouble(dr_Accou_Clne[1]) == 0 || Convert.ToDouble(dr_Accou_Clne[1]) == 0)
                    //    {
                    //        MessageBox.Show("لايمكن الخصم  ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    //        return;
                    //    }
                   // }
                //else
                //    {
                //        MessageBox.Show("المبلغ اكبر من الحساب ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //    }
                    ////if (Convert.ToDouble( dr_Accou_Clne[2]) >0)
                    ////{
                    ////    txt_sals_begin_calc.Text = Convert.ToDouble(Convert.ToDouble(txt_Deitor_supper_discou_acco_add.Text) - Convert.ToDouble(txt_sals_discount.Text)).ToString("N2");
                    ////}
                    ////else if(Convert.ToDouble(dr_Accou_Clne[1]) >0)
                    ////{
                    ////    MessageBox.Show("لايمكن الخصم لان حسابه " + Convert.ToDouble(dr_Accou_Clne[1]) + " دائن ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    ////}
                    ////else
                    ////{
                    ////    txt_sals_begin_calc.Text = "";//Convert.ToDouble(Convert.ToDouble(txt_Deitor_supper_discou_acco_add.Text) + Convert.ToDouble(txt_sals_discount.Text)).ToString("N2");

                    ////}
                }
                else
                {
                    MessageBox.Show(" يرجاء ادخال المورد اولاً ","Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
                    return;
                }
            }
        }

        void Save_Data_Report()
        {
            var vr = Application.OpenForms["Main"] as Main;
            int num = new classs_table.Items_Tools().AoutoNumber("Report_Account_Discount", "num_Re_Acc_dis");

            //txt_sals_begin_calc
            DB_Add_delete_update_.Database.ds.Tables["Report_Account_Discount"].Rows.Add(
                num,// الكود
                DateTime.Now,// تاريح الخصم
                "مورد",// النوع
                null,
                txt_num_supper_discou_acco_add.Text.Trim(),// رقم المورد
                txt_Deitor_supper_discou_acco_add.Text,//الرصيد قبل
                txt_sals_discount.Text.Trim(),// قيمة الخصم
                txt_sals_begin_calc.Text.Trim(),// الرصيد بعد
               Convert.ToInt32(com_sbb_alhrcka.SelectedValue),// سبب الحركة
                txt_Not.Text.Trim(),// الملاحظة
                vr.txt_Empoly_number.Caption);
            DB_Add_delete_update_.Database.update("Report_Account_Discount");
        }
        private void Button2_Click(object sender, EventArgs e)
        {
            // تعديل رصيد المورد بعد الحركة
            if (Convert.ToDouble(txt_sals_begin_calc.Text) >= 0)
            {
                var vr = Application.OpenForms["Main"] as Main;
                DataRow dt_Emp_use = DB_Add_delete_update_.Database.ds.Tables["TB_LOGIN_EMP"].Rows.Find(new object[] { Convert.ToInt32(vr.txt_user_id_Emp.Caption), vr.txt_user_Emp.Caption });//Convert.ToInt32(vr.txt_user_id_Emp.Caption)
                DataRow dt_Emp_name_use = DB_Add_delete_update_.Database.ds.Tables["TB_Employees"].Rows.Find(dt_Emp_use[4]);
                int num_max = new classs_table.Items_Tools().AoutoNumber("Accounts_suppliers", "id_Accoun_sup");
                object[] ob_calc =  DB_Add_delete_update_.Database.ds.Tables["Supplier"].Rows.Find(txt_num_supper_discou_acco_add.Text).ItemArray;
                object[] ob_calc_supper = DB_Add_delete_update_.Database.ds.Tables["Calc_supply"].Rows.Find(ob_calc[6]).ItemArray;
                if (com_sbb_alhrcka.Text != String.Empty )
                {

                    if (Convert.ToDouble(ob_calc_supper[2]) > 0 && Convert.ToDouble(ob_calc_supper[1]) == 0 && Convert.ToDouble(ob_calc_supper[2]) >= Convert.ToDouble(txt_sals_discount.Text))
                    {
                        double sum = Math.Abs(Convert.ToDouble(txt_Deitor_supper_discou_acco_add.Text) - Convert.ToDouble(txt_sals_discount.Text));

                        ob_calc_supper[1] = 0;
                        ob_calc_supper[2] = sum.ToString("N2");
                        ob_calc_supper[3] = sum.ToString("N2");
                    }
                    else if (Convert.ToDouble(ob_calc_supper[2]) > 0 && Convert.ToDouble(ob_calc_supper[1]) == 0 && Convert.ToDouble(ob_calc_supper[2]) < Convert.ToDouble(txt_sals_discount.Text))
                    {
                        double sum = Math.Abs(Convert.ToDouble(txt_sals_discount.Text) - Convert.ToDouble(txt_Deitor_supper_discou_acco_add.Text));
                        ob_calc_supper[1] = sum.ToString("N2");
                        ob_calc_supper[2] = 0;
                        ob_calc_supper[3] = sum.ToString("N2");
                    }
                    else if (Convert.ToDouble(ob_calc_supper[2]) == 0 && Convert.ToDouble(ob_calc_supper[1]) > 0 && Convert.ToDouble(ob_calc_supper[1]) >= Convert.ToDouble(txt_sals_discount.Text))
                    {
                        double sum = Math.Abs(Convert.ToDouble(txt_Deitor_supper_discou_acco_add.Text) - Convert.ToDouble(txt_sals_discount.Text));

                        ob_calc_supper[1] = sum.ToString("N2");
                        ob_calc_supper[2] = 0;
                        ob_calc_supper[3] = sum.ToString("N2");
                    }
                    else if (Convert.ToDouble(ob_calc_supper[2]) == 0 && Convert.ToDouble(ob_calc_supper[1]) > 0 && Convert.ToDouble(ob_calc_supper[1]) < Convert.ToDouble(txt_sals_discount.Text))
                    {
                        double sum = Math.Abs(Convert.ToDouble(txt_Deitor_supper_discou_acco_add.Text) - Convert.ToDouble(txt_sals_discount.Text));

                        ob_calc_supper[2] = sum.ToString("N2");
                        ob_calc_supper[1] = 0;
                        ob_calc_supper[3] = sum.ToString("N2");
                    }
                    else if (Convert.ToDouble(ob_calc_supper[2]) == 0 && Convert.ToDouble(ob_calc_supper[1]) == 0)
                    {
                        MessageBox.Show("لايمكن الخصم  ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                        //ob_calc_supper[1] = txt_sals_begin_calc.Text;
                        //ob_calc_supper[3] = Convert.ToDouble(ob_calc_supper[2]);
                    }

                    //txt_sals_begin_calc.Text;
                    new classs_table.Items_Tools().update_Rows_Table_Database("Calc_supply", ob_calc_supper[0].ToString(), ob_calc_supper);
                    Save_Data_Report();
                    DB_Add_delete_update_.Database.ds.Tables["Accounts_suppliers"].Rows.Add(
                                      num_max,
                                      ob_calc[0],
                                      ob_calc[1],
                                      dt_Emp_name_use[0],//data_user[0][0],
                                      dt_Emp_name_use[1], // dt_Emp_name_use[1].ToString(),
                                      ob_calc_supper[1],
                                      ob_calc_supper[2],
                                      "الخصم من حساب",
                                      DateTime.Now,
                                      Convert.ToDouble(txt_sals_discount.Text)
                                );
                    
                    DB_Add_delete_update_.Database.update("Accounts_suppliers");

                    MessageBox.Show("تم التعديل  الخصم بنجاح", "save", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Close();
                }
                else
                {
                    MessageBox.Show("يرجاء اضافة اسباب الخصم");
                }
            }
            else
            {
                MessageBox.Show("الرصيد بعد الحركة باسالب","Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
                return;
            }
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void Txt_num_supper_discou_acco_add_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void Txt_sals_discount_KeyDown(object sender, KeyEventArgs e)
        {
           
        }

        private void Txt_sals_discount_KeyPress(object sender, KeyPressEventArgs e)
        {
                    if ( !char.IsNumber(e.KeyChar) && !char.IsControl(e.KeyChar))
                    {
                        e.Handled = true;
                    }
          
        }
    }
}
