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
    public partial class Frm_view_abs_Emp : Form
    {
        public Frm_view_abs_Emp()
        {
            InitializeComponent();
        }

        private void Btn_close_Click(object sender, EventArgs e)
        {
            this.Close();
        }
         public int numForm = 0;
        DataTable dtable = new DataTable();
        
        private void Frm_view_abs_Emp_Load(object sender, EventArgs e)
        {
            //MessageBox.Show("Test" + numForm);
            dtable.Columns.Add("Code_Emp", typeof(int));
            dtable.Columns.Add("Name_Emp_A", typeof(string));
            dtable.Columns.Add("Name_Emp_E", typeof(string));

            //dgv_view_Emps_dgv.Focus();
            DataRow[] dr_Emp = DB_Add_delete_update_.Database.ds.Tables["TB_Employees"].Select();
            if (dr_Emp.Count() !=0 )
            {
                for (int i = 0; i < dr_Emp.Count(); i++)
                {
                    if (Convert.ToBoolean(dr_Emp[i][13]) != true)
                    {
                        if (numForm==1)//اذا كان شاشة تسجيل  غياب و الاجازات 
                        {

                            DataRow[] dr_weekly = DB_Add_delete_update_.Database.ds.Tables["TB_Emplyee_days_weekly"].Select("id_Emp =" + dr_Emp[i][0]);
                            int type_abc = 0;
                            if (dr_weekly.Count() != 0)
                            {
                                object[] daysstatic = { dr_weekly[0][2], dr_weekly[0][5], dr_weekly[0][8], dr_weekly[0][11], dr_weekly[0][14], dr_weekly[0][17], dr_weekly[0][20] };
                                int month = Convert.ToInt32(DateTime.Now.Month);
                                int day = Convert.ToInt32(DateTime.Now.Day);


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

                            if (type_abc == 1) // اذا كان اليوم الحالي للموظف دوام 
                            {
                                dtable.Rows.Add(Convert.ToInt32( dr_Emp[i][0] ), dr_Emp[i][1].ToString() , dr_Emp[i][2].ToString());
                            

                            }
                        }
                        else if (numForm==2) //اذا كان شاشة تسجيل خصم غياب
                        {

                            dtable.Rows.Add(Convert.ToInt32( dr_Emp[i][0] ), dr_Emp[i][1].ToString() , dr_Emp[i][2].ToString());
                        }
                        else if (numForm == 3) //اذا كان شاشة تسجيل خصم عقوبة او خصم من حساب الموظف 
                        {

                            dtable.Rows.Add(Convert.ToInt32(dr_Emp[i][0]), dr_Emp[i][1].ToString(), dr_Emp[i][2].ToString());
                        }
                        else if (numForm == 4) //اذا كانت شاشة تسجيل حوافز وبدالات  الموظف 
                        {

                            dtable.Rows.Add(Convert.ToInt32(dr_Emp[i][0]), dr_Emp[i][1].ToString(), dr_Emp[i][2].ToString());
                        }


                    } 

                }
                for (int i = 0; i < dtable.Rows.Count; i++)
                {
                    dgv_view_Emps_dgv.Rows.Add(dtable.Rows[i][0], dtable.Rows[i][1], dtable.Rows[i][2]);

                }
                

            }

        }

        private void Btn_serch_emps_Click(object sender, EventArgs e)
        {
            DataView dview_Emps = new DataView(dtable);
            //dv.RowFilter = "الاسم+الرقم like '%" + str + "%'";
            string str = txt_serch_emps.Text;
            dview_Emps.RowFilter= "[Code_Emp]+[Name_Emp_A]+[Name_Emp_E] like '%" + str + "%'";
            dgv_view_Emps_dgv.Rows.Clear();
            for (int i = 0; i < dview_Emps.Count; i++)
            {
                dgv_view_Emps_dgv.Rows.Add(dview_Emps[i][0], dview_Emps[i][1], dview_Emps[i][2]);

            }
            //dgv_view_Emps_dgv.DataSource = dview_Emps;
            //DataView f;
            //f.RowFilter

        }

        private void Dgv_view_Emps_dgv_DoubleClick(object sender, EventArgs e)
        {
            if (numForm==1)//اذا كان شاشة تسجيل  الغياب والاجازات
            {

            var v = Application.OpenForms["Frm_absences_vacations"] as Frm_absences_vacations;
            var n = Application.OpenForms["Main"] as Main;

                if (dgv_view_Emps_dgv.CurrentRow !=null)
                {
                    if (Convert.ToInt32(dgv_view_Emps_dgv.CurrentRow.Cells[0].Value) != Convert.ToInt32(n.txt_Empoly_number.Caption))
                    {
                        v.txt_code_Emp.Text = dgv_view_Emps_dgv.CurrentRow.Cells[0].Value.ToString();
                        v.txt_name_Emp.Text = dgv_view_Emps_dgv.CurrentRow.Cells[1].Value.ToString();
                        //MessageBox.Show(dgv_view_Emps_dgv.CurrentRow.Cells[0].Value.ToString() +"  = "+ dgv_view_Emps_dgv.CurrentRow.Cells[1].Value.ToString());
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show(" ! لا يمكن عمل غياب او اجازة لمستخدم يعمل حاليا ");

                    }

                

                }
            }
            else if (numForm==2)//اذا كان شاشة تسجيل خصم غياب
            {
                var v = Application.OpenForms["Frm_Discount_Emp"] as Frm_Discount_Emp;

                    if (dgv_view_Emps_dgv.CurrentRow != null)
                    {

                    int code = Convert.ToInt32(dgv_view_Emps_dgv.CurrentRow.Cells[0].Value);
                    string name_Emp = dgv_view_Emps_dgv.CurrentRow.Cells[1].Value.ToString();
                    DateTime dattime =  new  DateTime( v.dateTime_month.Value.Year , v.dateTime_month.Value.Month , 1 ) ;
                    int count_abs = 0;
                    double value_day_absin = 0;
                    double value_absin_End = 0;
                    double value_day_absin_And_count_abs = 0;
                    double value_discount = 0;
                    


                    DataRow[] dr_abs = DB_Add_delete_update_.Database.ds.Tables["TB_absences_vacations"].Select("id_Emp ='" + code + "'" + " And date_month ='" + dattime.ToString("yyyy-MM") + "'" + " And type_process ='" + 1 + "'");

                    if (dr_abs.Count() != 0)
                    {
                        count_abs = dr_abs.Count();
                    }
                    else
                    {
                        MessageBox.Show("لايوجد غياب لهذا الموظف");
                        count_abs = 0;
                        
                    }
                    DataRow[] dr_salary = DB_Add_delete_update_.Database.ds.Tables["TB_sys_salary"].Select("id_EMP ='" + code + "'");
                    if (dr_salary.Count() != 0)
                    {

                        value_day_absin = Convert.ToDouble(dr_salary[0][3]);
                    }
                    else
                    {
                       // MessageBox.Show("  قيمة يوم الغياب لهذا الموظف صفر");

                        value_day_absin = 0;
                    }



                    if (count_abs != 0)
                    { 
                        if (value_day_absin !=0 )
                        {
                            value_day_absin_And_count_abs = count_abs * value_day_absin ;

                            if (v.txt_value_discount.Text != string.Empty.Trim())
                            {
                                value_discount = Convert.ToDouble(v.txt_value_discount.Text);
                            }
                            if ( value_discount  > value_day_absin_And_count_abs)
                            {
                               // this.Close();
                               // MessageBox.Show(" ! قيمة الخصم اكبر من قيمة الغياب يرجاء تعديل قيمةالخصم ");

                                //v.txt_value_discount.Focus();
                                

                            }
                            else
                            {
                                value_absin_End = value_day_absin_And_count_abs - value_discount ;
                            }
                        }
                    }
                    
                    v.txt_code_Emp.Text = code.ToString();
                    v.txt_name_Emp.Text = name_Emp;
                    v.txt_count_absincs.Text = count_abs.ToString();
                    v.txt_value_day_absen.Text = value_day_absin.ToString();
                    v.txt_value_absen.Text = value_absin_End.ToString();
                    this.Close();
                    v.txt_value_discount.Focus();



                }
            }
            else if (numForm == 3)  //اذا كان شاشة تسجيل خصم عقوبات او خصم من حساب الموظف
            {
                var v = Application.OpenForms["Frm_Employee_discount_problemm"] as Frm_Employee_discount_problemm;

                if (dgv_view_Emps_dgv.CurrentRow != null)
                {

                    v.txt_code_Emp_problem.Text = dgv_view_Emps_dgv.CurrentRow.Cells[0].Value.ToString();
                    v.txt_name_Emp__frmproblem.Text = dgv_view_Emps_dgv.CurrentRow.Cells[1].Value.ToString();
                    //MessageBox.Show(dgv_view_Emps_dgv.CurrentRow.Cells[0].Value.ToString() +"  = "+ dgv_view_Emps_dgv.CurrentRow.Cells[1].Value.ToString());
                    this.Close();


                }
            }
            else if (numForm == 4)  //اذا كانت شاشة تسجيل حوافز وبدالات  الموظف 
            {
                var v = Application.OpenForms["Frm_incentives_allowances"] as Frm_incentives_allowances;

                if (dgv_view_Emps_dgv.CurrentRow != null)
                {

                    v.txt_code_Emp_incertives_allowances.Text = dgv_view_Emps_dgv.CurrentRow.Cells[0].Value.ToString();
                    v.txt_name_Emp_incertives_allowances.Text = dgv_view_Emps_dgv.CurrentRow.Cells[1].Value.ToString();
                    //MessageBox.Show(dgv_view_Emps_dgv.CurrentRow.Cells[0].Value.ToString() +"  = "+ dgv_view_Emps_dgv.CurrentRow.Cells[1].Value.ToString());
                    this.Close();


                }
            }
        }

        private void Btn_ok_Click(object sender, EventArgs e)
        {
            if (numForm == 1)//اذا كان شاشة تسجيل  الغياب والاجازات
            {
                var v = Application.OpenForms["Frm_absences_vacations"] as Frm_absences_vacations;
                //Frm_absences_vacations fr = new Frm_absences_vacations();
                if (dgv_view_Emps_dgv.CurrentRow != null)
                {

                    v.txt_code_Emp.Text = dgv_view_Emps_dgv.CurrentRow.Cells[0].Value.ToString();
                    v.txt_name_Emp.Text = dgv_view_Emps_dgv.CurrentRow.Cells[1].Value.ToString();
                    //MessageBox.Show(dgv_view_Emps_dgv.CurrentRow.Cells[0].Value.ToString() +"  = "+ dgv_view_Emps_dgv.CurrentRow.Cells[1].Value.ToString());
                    this.Close();


                }
            }

            else if (numForm == 2)//اذا كان شاشة تسجيل خصم غياب
            {
                var v = Application.OpenForms["Frm_Discount_Emp"] as Frm_Discount_Emp;

                if (dgv_view_Emps_dgv.CurrentRow != null)
                {

                    int code = Convert.ToInt32(dgv_view_Emps_dgv.CurrentRow.Cells[0].Value);
                    string name_Emp = dgv_view_Emps_dgv.CurrentRow.Cells[1].Value.ToString();
                    DateTime dattime = new DateTime(v.dateTime_month.Value.Year, v.dateTime_month.Value.Month, 1);
                    int count_abs = 0;
                    double value_day_absin = 0;
                    double value_absin_End = 0;
                    double value_day_absin_And_count_abs = 0;
                    double value_discount = 0;



                    DataRow[] dr_abs = DB_Add_delete_update_.Database.ds.Tables["TB_absences_vacations"].Select("id_Emp ='" + code + "'" + " And date_month ='" + dattime.ToString("yyyy-MM") + "'" + " And type_process ='" + 1 + "'");

                    if (dr_abs.Count() != 0)
                    {
                        count_abs = dr_abs.Count();
                    }
                    else
                    {
                        MessageBox.Show("لايوجد غياب لهذا الموظف");
                        count_abs = 0;

                    }
                    DataRow[] dr_salary = DB_Add_delete_update_.Database.ds.Tables["TB_sys_salary"].Select("id_EMP ='" + code + "'");
                    if (dr_salary.Count() != 0)
                    {

                        value_day_absin = Convert.ToDouble(dr_salary[0][3]);
                    }
                    else
                    {
                      //  MessageBox.Show("  قيمة يوم الغياب لهذا الموظف صفر");

                        value_day_absin = 0;
                    }



                    if (count_abs != 0)
                    {
                        if (value_day_absin != 0)
                        {
                            value_day_absin_And_count_abs = count_abs * value_day_absin;

                            if (v.txt_value_discount.Text != string.Empty.Trim())
                            {
                                value_discount = Convert.ToDouble(v.txt_value_discount.Text);
                            }
                            if (value_discount > value_day_absin_And_count_abs)
                            {
                                
                                MessageBox.Show(" ! قيمة الخصم اكبر من قيمة الغياب يرجاء تعديل قيمةالخصم ");
                                v.txt_value_discount.Focus();


                            }
                            else
                            {
                                value_absin_End = value_day_absin_And_count_abs - value_discount;
                            }
                        }
                    }

                    v.txt_code_Emp.Text = code.ToString();
                    v.txt_name_Emp.Text = name_Emp;
                    v.txt_count_absincs.Text = count_abs.ToString();
                    v.txt_value_day_absen.Text = value_day_absin.ToString();
                    v.txt_value_absen.Text = value_absin_End.ToString();
                    this.Close();
                    v.txt_value_discount.Select();


                }
            }

            else if (numForm == 3)  //اذا كان شاشة تسجيل خصم عقوبة او خصم من حساب الموظف
            {
                var v = Application.OpenForms["Frm_Employee_discount_problemm"] as Frm_Employee_discount_problemm;

                if (dgv_view_Emps_dgv.CurrentRow != null)
                {

                    v.txt_code_Emp_problem.Text = dgv_view_Emps_dgv.CurrentRow.Cells[0].Value.ToString();
                    v.txt_name_Emp__frmproblem.Text = dgv_view_Emps_dgv.CurrentRow.Cells[1].Value.ToString();
                    //MessageBox.Show(dgv_view_Emps_dgv.CurrentRow.Cells[0].Value.ToString() +"  = "+ dgv_view_Emps_dgv.CurrentRow.Cells[1].Value.ToString());
                    this.Close();


                }
            }

            else if (numForm == 4)  //اذا كانت شاشة تسجيل حوافز وبدالات  الموظف 
            {
                var v = Application.OpenForms["Frm_incentives_allowances"] as Frm_incentives_allowances;

                if (dgv_view_Emps_dgv.CurrentRow != null)
                {

                    v.txt_code_Emp_incertives_allowances.Text = dgv_view_Emps_dgv.CurrentRow.Cells[0].Value.ToString();
                    v.txt_name_Emp_incertives_allowances.Text = dgv_view_Emps_dgv.CurrentRow.Cells[1].Value.ToString();
                    //MessageBox.Show(dgv_view_Emps_dgv.CurrentRow.Cells[0].Value.ToString() +"  = "+ dgv_view_Emps_dgv.CurrentRow.Cells[1].Value.ToString());
                    this.Close();


                }
            }
        }


        private void Txt_serch_emps_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode ==Keys.Enter)
            {

                DataView dview_Emps = new DataView(dtable);
                //dv.RowFilter = "الاسم+الرقم like '%" + str + "%'";
                string str = txt_serch_emps.Text;
                dview_Emps.RowFilter = "[Code_Emp]+[Name_Emp_A]+[Name_Emp_E] like '%" + str + "%'";
                dgv_view_Emps_dgv.Rows.Clear();
                for (int i = 0; i < dview_Emps.Count; i++)
                {
                    dgv_view_Emps_dgv.Rows.Add(dview_Emps[i][0], dview_Emps[i][1], dview_Emps[i][2]);

                }
            }
        }
    }
}
