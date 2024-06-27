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
    public partial class Frm_incentives_allowances : Form
    {
        public Frm_incentives_allowances()
        {
            InitializeComponent();
        }

        private void Panl_Emp_discount_problem_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Btn_add_Emp_incertives_allowances_btn_Click(object sender, EventArgs e)
        {
            Employlee.Emp_forms.Frm_view_abs_Emp fr = new Frm_view_abs_Emp();
            fr.numForm = 4;
            fr.ShowDialog();
        }

        private void Txt_code_Emp_incertives_allowances_DoubleClick(object sender, EventArgs e)
        {
            Employlee.Emp_forms.Frm_view_abs_Emp fr = new Frm_view_abs_Emp();
            fr.numForm = 4;
            fr.ShowDialog();
        }

        private void Btn_save_incertives_allowances_Click(object sender, EventArgs e)
        {
            var n = Application.OpenForms["Main"] as Main;

            int code_now = new classs_table.Items_Tools().AoutoNumber("TB_incentives_allowances", "code");
            string date_month = dateTime_month_incertives_allowances.Value.ToString("yyyy-MM");
            string date_day = dateTime_month_incertives_allowances.Value.ToString("yyyy-MM-dd");
            double Enter_value = 0;
            string nots = txt_nots_incertives_allowances.Text != string.Empty.Trim() ? txt_nots_incertives_allowances.Text : "";
            int num_Emp = txt_code_Emp_incertives_allowances.Text != string.Empty.Trim() ? Convert.ToInt32(txt_code_Emp_incertives_allowances.Text) : 0;
            string date_now = DateTime.Now.ToString("yyyy-MM-dd HH:mm");

            int Id_user = Convert.ToInt32(n.txt_Empoly_number.Caption);     // رقم المستخدم


            if (txt_value_incertives_allowances.Text != string.Empty.Trim())
            {
               Enter_value  = Convert.ToDouble(txt_value_incertives_allowances.Text);


            }
            if (Enter_value != 0)
            {
                if (num_Emp != 0)
                {

                    DB_Add_delete_update_.Database.ds.Tables["TB_incentives_allowances"].Rows.Add(code_now,  //رقم العمليه
                                                                                              date_month,  // تاريخ السنة والشهر
                                                                                              num_Emp,          //رقم الموظف
                                                                                              Enter_value,  //قيمة الحافز
                                                                                              date_day,   // تاريخ اليوم 
                                                                                              nots,           // ملاحظة
                                                                                              date_now,          // تاريخ حفظ العملية
                                                                                              Id_user   //رقم المستخدم 
                                                                                                     );
                    DB_Add_delete_update_.Database.update("TB_incentives_allowances");

                    MessageBox.Show(" ! تم حفظ الحافز للموظف ( " + txt_name_Emp_incertives_allowances.Text + " )");

                    txt_value_incertives_allowances.Text = "0";
                    txt_nots_incertives_allowances.Text = "";
                    txt_code_Emp_incertives_allowances.Text = "";
                    txt_name_Emp_incertives_allowances.Text = "";
                    dateTime_month_incertives_allowances.Value = DateTime.Now;



                }
                else
                {
                    MessageBox.Show(" ! يرجا اختيار الموظف ");
                    txt_code_Emp_incertives_allowances.Focus();
                }
            }
            else
            {
                MessageBox.Show(" ! قيمة الحافز ( صفر ) يُرجا إضافة قيمة الحافز  ");

                txt_value_incertives_allowances.Focus();

            }


        }

        private void Btn_close_incertives_allowances_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
