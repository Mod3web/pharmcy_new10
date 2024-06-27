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
    public partial class Frm_absences_vacations : Form
    {
        public Frm_absences_vacations()
        {
            InitializeComponent();
        }

        private void Chbox_absences_CheckedChanged(object sender, EventArgs e)
        {
            if (chbox_absences.Checked == true)
            {
                chbox_vacations.Checked = false;
                txt_nots_Emp.Visible = false;
                lbl_nots.Visible = false;

            }
            else if (chbox_absences.Checked == false)
            {
                chbox_vacations.Checked = true;
                txt_nots_Emp.Visible = true;
                lbl_nots.Visible = true;

            }
        }

        private void Txt_code_Emp_TextChanged(object sender, EventArgs e)
        {

        }

        private void Chbox_vacations_CheckedChanged(object sender, EventArgs e)
        {
            if (chbox_vacations.Checked == true)
            {
                chbox_absences.Checked = false;
                txt_nots_Emp.Visible = true;
                lbl_nots.Visible = true;

            }
            else if (chbox_vacations.Checked == false)
            {
                chbox_absences.Checked = true;
                txt_nots_Emp.Visible = false;
                lbl_nots.Visible = false;

            }
        }

        private void Txt_code_Emp_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (txt_code_Emp.Text != string.Empty.Trim())
                {
                    int id_Emp = Convert.ToInt32(txt_code_Emp.Text);
                
                DataRow dr_Emp = DB_Add_delete_update_.Database.ds.Tables["TB_Employees"].Rows.Find(id_Emp);

                    if (dr_Emp != null)
                    {
                        if (Convert.ToBoolean(dr_Emp[13]) != true)
                        {
                            DataRow[] dr_weekly = DB_Add_delete_update_.Database.ds.Tables["TB_Emplyee_days_weekly"].Select("id_Emp =" + id_Emp );
                            int type_abc = 0;
                            if (dr_weekly.Count() != 0)
                            {
                                object[] daysstatic = { dr_weekly[0][2], dr_weekly[0][5], dr_weekly[0][8], dr_weekly[0][11], dr_weekly[0][14], dr_weekly[0][17], dr_weekly[0][20] };
                                int month = Convert.ToInt32( DateTime.Now.Month);
                                int day = Convert.ToInt32( DateTime.Now.Day);

                                
                                if (new DateTime(DateTime.Now.Year, month, day).DayOfWeek.ToString() == "Saturday" && Convert.ToInt32(daysstatic[0]) == 1)
                                {
                                    type_abc = 1;

                                }
                                else if (new DateTime(DateTime.Now.Year, month, day).DayOfWeek.ToString() == "Sunday" && Convert.ToInt32(daysstatic[1]) == 1)
                                {
                                    type_abc = 1;
                               
                                }
                                else if (new DateTime(DateTime.Now.Year, month, day).DayOfWeek.ToString() == "Monday" && Convert.ToInt32(daysstatic[2]) == 1)
                                {
                                    type_abc = 1;
                                  
                                }
                                else if (new DateTime(DateTime.Now.Year, month, day).DayOfWeek.ToString() == "Tuesday" && Convert.ToInt32(daysstatic[3]) == 1)
                                {
                                    type_abc = 1;
                                 
                                }

                                else if (new DateTime(DateTime.Now.Year, month, day).DayOfWeek.ToString() == "Wednesday" && Convert.ToInt32(daysstatic[4]) == 1)
                                {
                                    type_abc = 1;
                                 
                                }

                                else if (new DateTime(DateTime.Now.Year, month, day).DayOfWeek.ToString() == "Thursday" && Convert.ToInt32(daysstatic[5]) == 1)
                                {
                                    type_abc = 1;
                                   
                                }

                                else if (new DateTime(DateTime.Now.Year, month, day).DayOfWeek.ToString() == "Friday" && Convert.ToInt32(daysstatic[6]) == 1)
                                {
                                    type_abc = 1;
                                 
                                }


                            }
                            if (type_abc == 1)
                            {
                                txt_name_Emp.Text = dr_Emp[1].ToString();

                            }
                            else
                            {
                                MessageBox.Show("الموظف في اجازه اعتيادية لا يمكن اضافتة");
                                return;
                            }


                        }
                        else
                        {
                            MessageBox.Show("الموظف موقف");
                            return;
                        }

                    }
                    else
                    {
                        MessageBox.Show("لا يوجد موظف بهذا الرقم");
                        return;

                    }
                }



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

        private void Btn_close_btn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Txt_code_Emp_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            //new Employlee.Emp_forms.Frm_view_abs_Emp().ShowDialog();
        }

        private void Btn_add_Emp_btn_Click(object sender, EventArgs e)
        {
            Employlee.Emp_forms.Frm_view_abs_Emp fr = new Frm_view_abs_Emp();
                fr.numForm = 1; 
            fr.ShowDialog();
            


        }

        private void Frm_absences_vacations_Load(object sender, EventArgs e)
        {

        }

        private void Btn_save_btn_Click(object sender, EventArgs e)
        {
            var n = Application.OpenForms["Main"] as Main;

            DateTime dtimenow = DateTime.Now;
            if (chbox_absences.Checked)
            {
                if (txt_code_Emp.Text != string.Empty.Trim() || txt_name_Emp.Text != string.Empty.Trim())
                {

                   DataRow[] dr_Emp = DB_Add_delete_update_.Database.ds.Tables["TB_Attendance_departure"].Select("id_Emp ='" + txt_code_Emp.Text +"'" + " And day_now ='"+dtimenow.ToString("yyyy-MM-dd") +"'"+ " And type_Attendance ='" + 1 + "'");
                    if (dr_Emp.Count() == 0)
                    {
                        DataRow[] dr_abs_vaca = DB_Add_delete_update_.Database.ds.Tables["TB_absences_vacations"].Select("id_Emp ='" + txt_code_Emp.Text + "'" + " And date_day ='" + dtimenow.ToString("yyyy-MM-dd") + "'");
                        if (dr_abs_vaca.Count() == 0)
                        {

                            int aoutnum = new classs_table.Items_Tools().AoutoNumber("TB_absences_vacations", "code");
                            DB_Add_delete_update_.Database.ds.Tables["TB_absences_vacations"].Rows.Add(aoutnum,
                                                                                                        Convert.ToInt32(txt_code_Emp.Text), //رقم الموظف
                                                                                                        dtimenow.ToString("yyyy-MM"),    //تاريخ الشهر والسنة
                                                                                                        dtimenow.ToString("yyyy-MM-dd"),    //تاريخ اليوم
                                                                                                        1,                                    // اذا كان غياب يساوي واحد
                                                                                                        null,                               // لا توجد ملاحظة عند الغياب
                                                                                                        dtimenow.ToString("yyyy-MM-dd HH:mm"), // تاريه وتوقيت العملية
                                                                                                        n.txt_Empoly_number.Caption);           // رقم المستخدم
                            DB_Add_delete_update_.Database.update("TB_absences_vacations");
                            MessageBox.Show("تم حفظ الغياب");
                            txt_code_Emp.Clear();
                            txt_name_Emp.Clear();
                            txt_nots_Emp.Clear();

                        }
                        else
                        {
                            if (Convert.ToInt32( dr_abs_vaca[0][4] ) == 1)
                            {
                                MessageBox.Show(" ! تم عمل  اليوم غياب للموظف في وقت سابقاً ");
                                return;
                            }else if (Convert.ToInt32(dr_abs_vaca[0][4]) == 2)
                            {
                                MessageBox.Show(" ! تم عمل  اليوم إجازة للموظف في وقت سابقاً ");
                                return;
                            }




                        }


                    }
                    else
                    {
                        MessageBox.Show("  الموظف تم تحضيرة سابقاً لايمكن عمل غياب للموظف ");
                        return;
                    }

                }
                else {
                    MessageBox.Show(" يرجا التحقق من إدخال معلومات الموظف ");
                    return;
                }
            }
            else if (chbox_vacations.Checked)
            {
                if (txt_code_Emp.Text != string.Empty.Trim() || txt_name_Emp.Text != string.Empty.Trim())
                {
                    if (txt_nots_Emp.Text != string.Empty.Trim())
                    {
                        DataRow[] dr_Emp = DB_Add_delete_update_.Database.ds.Tables["TB_Attendance_departure"].Select("id_Emp ='" + txt_code_Emp.Text + "'" + " And day_now ='" + dtimenow.ToString("yyyy-MM-dd") + "'" + " And type_Attendance ='" + 1 + "'");
                        if (dr_Emp.Count() == 0)
                        {
                            DataRow[] dr_abs_vaca = DB_Add_delete_update_.Database.ds.Tables["TB_absences_vacations"].Select("id_Emp ='" + txt_code_Emp.Text + "'" + " And date_day ='" + dtimenow.ToString("yyyy-MM-dd") + "'");
                            if (dr_abs_vaca.Count() == 0)
                            {

                                int aoutnum = new classs_table.Items_Tools().AoutoNumber("TB_absences_vacations", "code");
                            DB_Add_delete_update_.Database.ds.Tables["TB_absences_vacations"].Rows.Add(aoutnum,
                                                                                                       Convert.ToInt32(txt_code_Emp.Text), //رقم الموظف
                                                                                                       dtimenow.ToString("yyyy-MM"),    //تاريخ الشهر والسنة
                                                                                                       dtimenow.ToString("yyyy-MM-dd"),    //تاريخ اليوم
                                                                                                       2,                                    // اذا كان غياب يساوي اثنان
                                                                                                       txt_nots_Emp.Text,                               // يتم حفظ ملاحظة عند الاجازة
                                                                                                       dtimenow.ToString("yyyy-MM-dd HH:mm"), // تاريه وتوقيت العملية
                                                                                                       n.txt_Empoly_number.Caption);           // رقم المستخدم
                            DB_Add_delete_update_.Database.update("TB_absences_vacations");

                            MessageBox.Show("تم حفظ الاجازة");
                            txt_code_Emp.Clear();
                            txt_name_Emp.Clear();
                            txt_nots_Emp.Clear();
                            }
                            else
                            {
                                if (Convert.ToInt32(dr_abs_vaca[0][3]) == 1)
                                {
                                    MessageBox.Show(" ! تم عمل  اليوم غياب للموظف في وقت سابقاً ");
                                    return;
                                }
                                else if (Convert.ToInt32(dr_abs_vaca[0][3]) == 2)
                                {
                                    MessageBox.Show(" ! تم عمل  اليوم إجازة للموظف في وقت سابقاً ");
                                    return;
                                }

                            }
                        }
                        else
                        {
                            MessageBox.Show("  الموظف تم تحضيرة سابقاً لايمكن عمل إجازة للموظف ");
                            return;
                        }

                    }
                    else
                    {
                        DataRow[] dr_Emp = DB_Add_delete_update_.Database.ds.Tables["TB_Attendance_departure"].Select("id_Emp ='" + txt_code_Emp.Text + "'" + " And day_now ='" + dtimenow.ToString("yyyy-MM-dd") + "'" + " And type_Attendance ='" + 1 + "'");
                        if (dr_Emp.Count() == 0)
                        {

                            DataRow[] dr_abs_vaca = DB_Add_delete_update_.Database.ds.Tables["TB_absences_vacations"].Select("id_Emp ='" + txt_code_Emp.Text + "'" + " And date_day ='" + dtimenow.ToString("yyyy-MM-dd") + "'");
                            if (dr_abs_vaca.Count() == 0)
                            {

                                DialogResult res = MessageBox.Show(" هل تريد حفظ الاجازة للموظف بدون ملاحظة ","",MessageBoxButtons.YesNo,MessageBoxIcon.Information);

                                if ( res == DialogResult.Yes)
                                {
                           

                                            int aoutnum = new classs_table.Items_Tools().AoutoNumber("TB_absences_vacations", "code");

                                        DB_Add_delete_update_.Database.ds.Tables["TB_absences_vacations"].Rows.Add(aoutnum,
                                                                                                                   Convert.ToInt32(txt_code_Emp.Text), //رقم الموظف
                                                                                                                   dtimenow.ToString("yyyy-MM"),    //تاريخ الشهر والسنة
                                                                                                                   dtimenow.ToString("yyyy-MM-dd"),    //تاريخ اليوم
                                                                                                                   2,                                    // اذا كان غياب يساوي اثنان
                                                                                                                   null,                               // يتم حفظ ملاحظة عند الاجازة
                                                                                                                   dtimenow.ToString("yyyy-MM-dd HH:mm"), // تاريه وتوقيت العملية
                                                                                                                   n.txt_Empoly_number.Caption);           // رقم المستخدم
                                        DB_Add_delete_update_.Database.update("TB_absences_vacations");

                                        MessageBox.Show("تم حفظ الاجازة");
                                        txt_code_Emp.Clear();
                                        txt_name_Emp.Clear();
                                        txt_nots_Emp.Clear();
                                   



                                }
                                else
                                    {
                                        return;
                                    }
                            }
                            else
                            {
                                if (Convert.ToInt32(dr_abs_vaca[0][4]) == 1)
                                {
                                    MessageBox.Show(" ! تم عمل للموظف اليوم غياب  في وقت سابقاً ");
                                    return;
                                }
                                else if (Convert.ToInt32(dr_abs_vaca[0][4]) == 2)
                                {
                                    MessageBox.Show(" ! تم عمل للموظف اليوم إجازة في وقت سابقاً ");
                                    return;
                                }

                            }

                        }
                        else
                        {
                            MessageBox.Show("  الموظف تم تحضيرة سابقاً لايمكن عمل إجازة للموظف ");
                            return;
                        }


                    }

                        }
                else
                {
                    MessageBox.Show(" يرجا التحقق من إدخال معلومات الموظف ");
                    return;
                }
            }
            
        }

        private void Txt_code_Emp_DoubleClick(object sender, EventArgs e)
        {
            Employlee.Emp_forms.Frm_view_abs_Emp fr = new Frm_view_abs_Emp();
            fr.numForm = 1;
            fr.ShowDialog();
        }

        private void Pane1_Frm_absen_vacat_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
