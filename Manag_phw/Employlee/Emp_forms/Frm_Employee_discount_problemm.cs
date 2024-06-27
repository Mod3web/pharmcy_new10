using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Manag_ph.Employlee.Emp_forms
{
    public partial class Frm_Employee_discount_problemm : Form
    {
        public Frm_Employee_discount_problemm()
        {
            InitializeComponent();
        }

        private void Txt_code_Emp_problem_KeyPress(object sender, KeyPressEventArgs e)
        {
            //if (!(char.IsDigit(e.KeyChar)) && e.KeyChar != (Char)Keys.Back)
            //   {
            //       e.Handled = true;
            //   }
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void Txt_value_discount_frmproblem_KeyPress(object sender, KeyPressEventArgs e)
        {
            //if (!(char.IsDigit(e.KeyChar)) && e.KeyChar != (Char)Keys.Back)
            //   {
            //       e.Handled = true;
            //   }
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void Btn_add_Emp_doscount_btn_frmproblem_Click(object sender, EventArgs e)
        {
            Employlee.Emp_forms.Frm_view_abs_Emp fr = new Frm_view_abs_Emp();
            fr.numForm = 3;
            fr.ShowDialog();
        }

        private void Txt_code_Emp_problem_DoubleClick(object sender, EventArgs e)
        {
            Employlee.Emp_forms.Frm_view_abs_Emp fr = new Frm_view_abs_Emp();
            fr.numForm = 3;
            fr.ShowDialog();
        }

        private void Btn_save_discount_btn_frmproblem_Click(object sender, EventArgs e)
        {
            var n = Application.OpenForms["Main"] as Main;

            int code_now = new classs_table.Items_Tools().AoutoNumber("TB_Employee_discount", "code");
            string date_month = dateTime_month_frmproblem.Value.ToString("yyyy-MM");
            string date_day = dateTime_month_frmproblem.Value.ToString("yyyy-MM-dd");
            double value_discount = 0;
            string nots = txt_nots_discount_frmproblem.Text != string.Empty.Trim() ? txt_nots_discount_frmproblem.Text : "";
            int num_Emp = txt_code_Emp_problem.Text != string.Empty.Trim() ? Convert.ToInt32(txt_code_Emp_problem.Text) : 0 ;
            string date_now = DateTime.Now.ToString("yyyy-MM-dd HH:mm");

            int Id_user = Convert.ToInt32(n.txt_Empoly_number.Caption);     // رقم المستخدم


            if (txt_value_discount_frmproblem.Text != string.Empty.Trim())
            {
                value_discount = Convert.ToDouble(txt_value_discount_frmproblem.Text);

               
            }
            if (value_discount !=0 )
            {
                if (num_Emp != 0)
                {

                    DB_Add_delete_update_.Database.ds.Tables["TB_Employee_discount"].Rows.Add(code_now,  //رقم العمليه
                                                                                              date_month,  // تاريخ السنة والشهر
                                                                                              date_day,   // تاريخ اليوم 
                                                                                              value_discount,  //قيمة الخصم
                                                                                              nots,           // ملاحظة
                                                                                              num_Emp,          //رقم الموظف
                                                                                              date_now,          // تاريخ حفظ العملية
                                                                                              Id_user   //رقم المستخدم 
                                                                                                     );
                    DB_Add_delete_update_.Database.update("TB_Employee_discount");

                    MessageBox.Show(" ! تم حفظ خصم على الموظف ( "+ txt_name_Emp__frmproblem.Text + " )");

                    txt_value_discount_frmproblem.Text = "0";
                    txt_nots_discount_frmproblem.Text = "";
                    txt_code_Emp_problem.Text = "";
                    txt_name_Emp__frmproblem.Text = "";
                    dateTime_month_frmproblem.Value = DateTime.Now;



                }
                else
                {
                    MessageBox.Show(" ! يرجا اختيار موظف ");
                    txt_code_Emp_problem.Focus();
                }
            }
            else
            {
                MessageBox.Show(" ! قيمة الخصم ( صفر ) يُرجا إضافة قيمة للخصم  ");

                txt_value_discount_frmproblem.Focus();

            }

        }

        private void Txt_code_Emp_problem_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
