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
    public partial class Frm_Discount_Emp : Form
    {
        public Frm_Discount_Emp()
        {
            InitializeComponent();
        }

        private void DateTime_month_ValueChanged(object sender, EventArgs e)
        {
            //MessageBox.Show("" +dateTime_month.Value.Year+"-"+ dateTime_month.Value.Month+"-"+"1");
        }

        private void Btn_add_Emp_doscount_btn_Click(object sender, EventArgs e)
        {

            Employlee.Emp_forms.Frm_view_abs_Emp fr = new Frm_view_abs_Emp();
            fr.numForm = 2;
            fr.ShowDialog();

        }

        private void Txt_code_Emp_DoubleClick(object sender, EventArgs e)
        {

            Employlee.Emp_forms.Frm_view_abs_Emp fr = new Frm_view_abs_Emp();
            fr.numForm = 2;
            fr.ShowDialog();
        }

        private void Txt_value_discount_KeyDown(object sender, KeyEventArgs e)
        {
            double value_end=0;
            if (e.KeyCode == Keys.Enter)
            {
                if (txt_code_Emp.Text != string.Empty.Trim() && txt_name_Emp.Text != string.Empty.Trim())
                {
                    int count_abs =Convert.ToInt32( txt_count_absincs.Text);
                    double val_day = Convert.ToDouble(txt_value_day_absen.Text);

                    if (txt_value_discount.Text != string.Empty.Trim())
                    {
                        double X= Convert.ToDouble( txt_value_discount.Text);
                            if (txt_count_absincs.Text != string.Empty.Trim() && txt_value_day_absen.Text!= string.Empty.Trim())
                            {


                            double Y = count_abs * val_day ;
                                if (X > Y)
                                {
                                    value_end = 0;
                                }
                                else {

                                    value_end =  Y -  X  ;
                                }
                            }
                    }

                }

                txt_value_absen.Text = value_end.ToString();
            }
        }

        private void Btn_save_discount_btn_Click(object sender, EventArgs e)
        {
            var n = Application.OpenForms["Main"] as Main;

            int code_now = new classs_table.Items_Tools().AoutoNumber("TB_Absence_discount", "code");
            string date_month = dateTime_month.Value.ToString("yyyy-MM");
            string date_day = dateTime_month.Value.ToString("yyyy-MM-dd");
            double value_discount = 0;
            string nots = txt_nots_discount.Text;
            int num_Emp = txt_code_Emp.Text != string.Empty.Trim() ? Convert.ToInt32(txt_code_Emp.Text) : 0 ;
            int count_absincs = 0;
            double value_daye_absin = Convert.ToInt32( txt_value_day_absen.Text);
            double value_End = Convert.ToInt32(txt_value_absen.Text);
            string date_now = DateTime.Now.ToString("yyyy-MM-dd HH:mm");

            int Id_user = Convert.ToInt32( n.txt_Empoly_number.Caption );     // رقم المستخدم


            if (txt_value_discount.Text != string.Empty.Trim())
            {
                 value_discount = Convert.ToDouble(txt_value_discount.Text);
            }



            if (Convert.ToInt32(txt_value_discount.Text) > 0)
            {

                if (num_Emp != 0)
                {
                    DB_Add_delete_update_.Database.ds.Tables["TB_Absence_discount"].Rows.Add(code_now,  //رقم العمليه
                                                                                              date_month,  // تاريخ السنة والشهر
                                                                                              date_day,   // تاريخ اليوم 
                                                                                              value_discount,  //قيمة الخصم
                                                                                              nots,           // ملاحظة
                                                                                              num_Emp,          //رقم الموظف
                                                                                              count_absincs,     // عدد  الغياب السابق
                                                                                              value_daye_absin, // قيمة اليوم الغياب
                                                                                              value_End,         // الفيمة النهائية بعد الخصم
                                                                                              date_now,          // تاريخ حفظ العملية
                                                                                              Id_user   //رقم المستخدم 
                                                                                                     );
                    DB_Add_delete_update_.Database.update("TB_Absence_discount");



                    MessageBox.Show(" ! تم إضافة الخصم الى غياب الموظف ( "+ txt_name_Emp.Text + " )" );
                    txt_value_discount.Text = "0";
                    txt_nots_discount.Text = "";
                    txt_code_Emp.Text = "";
                    txt_name_Emp.Text = "";
                    txt_count_absincs.Text = "0";
                    txt_value_day_absen.Text = "0";
                    txt_value_absen.Text = "0";
                    dateTime_month.Value = DateTime.Now;

                }
                else
                {
                    MessageBox.Show(" ! يرجا اختيار موظف ");
                    txt_code_Emp.Focus();


                }
            }
            else
            {
             MessageBox.Show(" ! قيمة الخصم صغيرة يرجا ان تكون قسمة الخصم اكبر من الصفر ");

                txt_value_discount.Focus();
            }

        }

        private void Txt_code_Emp_KeyPress(object sender, KeyPressEventArgs e)
        {
            //if (!(char.IsDigit(e.KeyChar)) && e.KeyChar != (Char)Keys.Back)
            //   {
            //       e.Handled = true;
            //   }
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void Txt_value_discount_KeyPress(object sender, KeyPressEventArgs e)
        {
            //if (!(char.IsDigit(e.KeyChar)) && e.KeyChar != (Char)Keys.Back)
            //   {
            //       e.Handled = true;
            //   }
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void Btn_close_discount_btn_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
