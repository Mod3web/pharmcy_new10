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
    public partial class frm_Account_cline_disc : Form
    {
        public frm_Account_cline_disc()
        {
            InitializeComponent();
        }

        private void Frm_Account_cline_disc_Load(object sender, EventArgs e)
        {
            new classs_table.My_tool_2().fill_com_alhrca(com_sbb_alhrcka);
        }

        private void Txt_num_supper_discou_acco_add_KeyDown(object sender, KeyEventArgs e)
        {
            new classs_table.Items_Tools().Fill_Cline_set_id_get_name(txt_num_supper_discou_acco_add, txt_name_supper_discou_acco_add, txt_Deitor_supper_discou_acco_add, e);
        }

        private void Txt_sals_discount_EditValueChanged(object sender, EventArgs e)
        {
            // حساب رصيد المورد بعد الخصم
            if (txt_sals_discount.Text.Trim() != string.Empty)
            {
                DataRow dr_Accou_Sup = DB_Add_delete_update_.Database.ds.Tables["Stock_client"].Rows.Find(txt_num_supper_discou_acco_add.Text.Trim());

                if (txt_num_supper_discou_acco_add.Text.Trim() != string.Empty)
                {
                    //if (Convert.ToDouble(txt_Deitor_supper_discou_acco_add.Text) >= Convert.ToDouble(txt_sals_discount.Text) )
                    //{
                    //    if (Convert.ToDouble(dr_Accou_Sup[2]) > 0 || Convert.ToDouble(dr_Accou_Sup[1]) > 0)
                    //    {
                            txt_sals_begin_calc.Text = Convert.ToDouble(Convert.ToDouble(txt_Deitor_supper_discou_acco_add.Text) - Convert.ToDouble(txt_sals_discount.Text)).ToString("N2");
                    //    }
                    //    else if (Convert.ToDouble(dr_Accou_Sup[1]) == 0 || Convert.ToDouble(dr_Accou_Sup[1]) == 0)
                    //    {
                    //        MessageBox.Show("لايمكن الخصم", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    //        return;
                    //    }
                    //}
                    //else
                    //{
                    //    MessageBox.Show("المبلغ تكبر من الحساب ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    //}



                }
                else
                {
                    MessageBox.Show("يرجاء ادخال العميل اولان", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
        }


        void Save_Data_Report()
        {
            var vr = Application.OpenForms["Main"] as Main;
            int num = new classs_table.Items_Tools().AoutoNumber("Report_Account_Discount", "num_Re_Acc_dis");

            DB_Add_delete_update_.Database.ds.Tables["Report_Account_Discount"].Rows.Add(
                num,// الكود
                DateTime.Now,// تاريح الخصم
                "عميل",// النوع
                null,
                txt_num_supper_discou_acco_add.Text.Trim(),// رقم العميل
                txt_Deitor_supper_discou_acco_add.Text,//الرصيد قبل
                txt_sals_discount.Text.Trim(),// قيمة الخصم
                txt_sals_begin_calc.Text.Trim(),// الرصيد بعد
               Convert.ToInt32(com_sbb_alhrcka.SelectedValue),// سبب الحركة
                txt_Not.Text.Trim(),// الملاحظة
vr.txt_Empoly_number.Caption);
            DB_Add_delete_update_.Database.update("Report_Account_Discount");
        }



        private void Button2_btn_Click(object sender, EventArgs e)
        {
            var vr = Application.OpenForms["Main"] as Main;
            DataRow dt_Emp_use = DB_Add_delete_update_.Database.ds.Tables["TB_LOGIN_EMP"].Rows.Find(new object[] { Convert.ToInt32(vr.txt_user_id_Emp.Caption), vr.txt_user_Emp.Caption });//Convert.ToInt32(vr.txt_user_id_Emp.Caption)
                                                                                                                                                                                           // if (dt_Emp_use.Count()!=0) {

            DataRow dt_Emp_name_use = DB_Add_delete_update_.Database.ds.Tables["TB_Employees"].Rows.Find(dt_Emp_use[4]);

            // تعديل رصيد المورد بعد الحركة
            if (Convert.ToDouble(txt_sals_begin_calc.Text) >= 0)
            {

                object[] ob_calc = DB_Add_delete_update_.Database.ds.Tables["Clien"].Rows.Find(txt_num_supper_discou_acco_add.Text).ItemArray;
                object[] ob_calc_supper = DB_Add_delete_update_.Database.ds.Tables["Stock_client"].Rows.Find(ob_calc[10]).ItemArray;
                int num_max_Ciln = new classs_table.Items_Tools().AoutoNumber("Accounts_Clin", "ID_Accoun_Clin");
                if (com_sbb_alhrcka.SelectedValue.ToString() != String.Empty)
                {
                    if (Convert.ToDouble(ob_calc_supper[2]) > 0 && Convert.ToDouble(ob_calc_supper[1]) == 0 && Convert.ToDouble(ob_calc_supper[2]) >= Convert.ToDouble(txt_sals_discount.Text))
                    {
                       double Sum = Math.Abs(Convert.ToDouble(txt_Deitor_supper_discou_acco_add.Text) - Convert.ToDouble(txt_sals_discount.Text));

                        ob_calc_supper[2] = Sum.ToString("N2");
                        ob_calc_supper[1] = 0;
                        ob_calc_supper[4] = Sum.ToString("N2");
                    }
                    else if (Convert.ToDouble(ob_calc_supper[2]) > 0 && Convert.ToDouble(ob_calc_supper[1]) == 0 && Convert.ToDouble(ob_calc_supper[2]) < Convert.ToDouble(txt_sals_discount.Text))
                    {
                        double Sum = Math.Abs(Convert.ToDouble(txt_sals_discount.Text) -  Convert.ToDouble(txt_Deitor_supper_discou_acco_add.Text)) ;

                        ob_calc_supper[1] = Sum.ToString("N2");
                        ob_calc_supper[2] = 0;
                        ob_calc_supper[4] = Sum.ToString("N2");
                    }
                    else if (Convert.ToDouble(ob_calc_supper[1]) > 0 && Convert.ToDouble(ob_calc_supper[2]) == 0 && Convert.ToDouble(ob_calc_supper[1]) >= Convert.ToDouble(txt_sals_discount.Text))
                    {
                        double Sum = Math.Abs(Convert.ToDouble(txt_Deitor_supper_discou_acco_add.Text) - Convert.ToDouble(txt_sals_discount.Text)) ;

                        ob_calc_supper[1] = Sum.ToString("N2");
                        ob_calc_supper[2] = 0;
                        ob_calc_supper[4] = Sum.ToString("N2");
                    }
                    else if (Convert.ToDouble(ob_calc_supper[1]) > 0 && Convert.ToDouble(ob_calc_supper[1]) == 0 && Convert.ToDouble(ob_calc_supper[1]) < Convert.ToDouble(txt_sals_discount.Text))
                    {
                        double Sum = Math.Abs(Convert.ToDouble(txt_Deitor_supper_discou_acco_add.Text)- Convert.ToDouble(txt_sals_discount.Text) );

                        ob_calc_supper[2] = Sum.ToString("N2");
                        ob_calc_supper[1] = 0;
                        ob_calc_supper[4] = Sum.ToString("N2");
                    }
                    else if (Convert.ToDouble(ob_calc_supper[2]) == 0 &&Convert.ToDouble(ob_calc_supper[1]) == 0 )
                    {

                          MessageBox.Show("لايمكن الخصم", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                          return;

                        //double Sum = Convert.ToDouble(txt_Deitor_supper_discou_acco_add.Text) - Convert.ToDouble(txt_sals_discount.Text);

                        //ob_calc_supper[2] = Sum.ToString("N2");
                        //ob_calc_supper[1] = 0;
                        //ob_calc_supper[4] = Sum.ToString("N2");
                    }


                   
                    new classs_table.Items_Tools().update_Rows_Table_Database("Stock_client", ob_calc_supper[0].ToString(), ob_calc_supper);
                    Save_Data_Report();
                    DB_Add_delete_update_.Database.ds.Tables["Accounts_Clin"].Rows.Add(
                            num_max_Ciln,
                            ob_calc[0],
                            ob_calc[1],
                            dt_Emp_name_use[0],//data_user[0][0],
                            dt_Emp_name_use[1], // dt_Emp_name_use[1].ToString(),
                            ob_calc_supper[1],
                            ob_calc_supper[2],// Convert.ToDouble(txt_Remain_balanc_supp.Text),
                            "الخصم من حساب",
                             DateTime.Now,
                             Convert.ToDouble(txt_sals_discount.Text)
                             );


                    //txt_sals_begin_calc.Text;
                    DB_Add_delete_update_.Database.update("Accounts_Clin");
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
                MessageBox.Show("الرصيد بعد الحركة باسالب", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        private void Button3_btn_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void Txt_sals_discount_KeyPress(object sender, KeyPressEventArgs e)
        {

            if (!char.IsNumber(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                        e.Handled = true;
            }
         }
    }
}
