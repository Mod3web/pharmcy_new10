using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Data;
using System.Data;

namespace Manag_ph.Employlee.Page_Employees
{
    class Delete_Emp
    {
        static public void Delete_Emps()
        {
            var n = Application.OpenForms["Main"] as Main;

            if (n.dgv_view_EMPS_dgv.CurrentRow != null)
            {
                DialogResult dr_Emp = MessageBox.Show("هل تريد بالفعل حذف الموظف المحدد", "حذف", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2);
                if (dr_Emp == DialogResult.Yes)
                {

                    int num_Emp_d = Convert.ToInt32(n.dgv_view_EMPS_dgv.CurrentRow.Cells[0].Value);
                    DataRow fin_ratio = null;
                    fin_ratio = DB_Add_delete_update_.Database.ds.Tables["TB_commission_ratio"].Rows.Find(num_Emp_d);
                    int idx_fin_ratio = DB_Add_delete_update_.Database.ds.Tables["TB_commission_ratio"].Rows.IndexOf(fin_ratio);
                    if (fin_ratio != null)
                    {

                        DB_Add_delete_update_.Database.ds.Tables["TB_commission_ratio"].Rows[idx_fin_ratio].Delete();
                        DB_Add_delete_update_.Database.update("TB_commission_ratio");
                        MessageBox.Show(" تم الحذف من جدول النسب ");

                    }
                    else
                    {
                        MessageBox.Show("لم يتم الحذف من جدول النسب ");

                    }
                    DataRow login = null;

                    DataRow[] select_login = DB_Add_delete_update_.Database.ds.Tables["TB_LOGIN_EMP"].Select("id_EMP=" + num_Emp_d);
                    string user_name_for_tb = "";
                    if (select_login.Count() != 0)
                    {
                        user_name_for_tb = Convert.ToString(select_login[0][1]);
                    }
                    object[] fin_tb_login = { num_Emp_d, user_name_for_tb }; //كان مفتاحين
                    login = DB_Add_delete_update_.Database.ds.Tables["TB_LOGIN_EMP"].Rows.Find(user_name_for_tb);
                    int idx_fin_login = DB_Add_delete_update_.Database.ds.Tables["TB_LOGIN_EMP"].Rows.IndexOf(login);

                    if (login != null)
                    {
                        if (select_login != null)
                        {


                            //DB_Add_delete_update_.Database.ds.Tables["TB_LOGIN_EMP"].Rows.Remove(login);
                            DB_Add_delete_update_.Database.ds.Tables["TB_LOGIN_EMP"].Rows[idx_fin_login].Delete();

                            DB_Add_delete_update_.Database.update("TB_LOGIN_EMP");
                            MessageBox.Show(" تم الحذف من جدول التسجيل ");
                        }

                    }
                    else
                    {
                        MessageBox.Show("لم يتم الحذف من جدول التسجيل ");
                    }

                    DataRow[] time_Emp;
                    time_Emp = DB_Add_delete_update_.Database.ds.Tables["TB_time_Attendance_departure"].Select("id_EMP=" + num_Emp_d);


                    for (int i = 0; i < time_Emp.Count(); i++)
                    {
                        int num_day = Convert.ToInt32(time_Emp[i][1]);
                        object[] num_time = { num_Emp_d, num_day };
                        DataRow inf_time = null;
                        inf_time = DB_Add_delete_update_.Database.ds.Tables["TB_time_Attendance_departure"].Rows.Find(num_time);
                        int idx_fin_inf_time = DB_Add_delete_update_.Database.ds.Tables["TB_time_Attendance_departure"].Rows.IndexOf(inf_time);

                        if (inf_time != null)
                        {
                            DB_Add_delete_update_.Database.ds.Tables["TB_time_Attendance_departure"].Rows[idx_fin_inf_time].Delete();

                            //DB_Add_delete_update_.Database.ds.Tables["TB_time_Attendance_departure"].Rows.Remove(inf_time);
                            DB_Add_delete_update_.Database.update("TB_time_Attendance_departure");
                            MessageBox.Show(" تم الحذف من جدول الوقت ");


                        }
                        else
                        {

                            MessageBox.Show("لم يتم الحذف من جدول الوقت =" + num_day);
                        }
                    }
                    DataRow idx_find_salary = null;
                    idx_find_salary = DB_Add_delete_update_.Database.ds.Tables["TB_sys_salary"].Rows.Find(num_Emp_d);
                    int idx_fin_salary = DB_Add_delete_update_.Database.ds.Tables["TB_sys_salary"].Rows.IndexOf(idx_find_salary);

                    if (idx_find_salary != null)
                    {
                        DB_Add_delete_update_.Database.ds.Tables["TB_sys_salary"].Rows[idx_fin_salary].Delete();

                        //DB_Add_delete_update_.Database.ds.Tables["TB_sys_salary"].Rows.Remove(idx_find_salary);
                        DB_Add_delete_update_.Database.update("TB_sys_salary");
                        MessageBox.Show(" تم الحذف من جدول الراتب");

                    }
                    else
                    {
                        MessageBox.Show("لم يتم الحذف من جدول الراتب");
                    }

                    DataRow idx_find_hauur = null;
                    idx_find_hauur = DB_Add_delete_update_.Database.ds.Tables["TB_sys_hauur"].Rows.Find(num_Emp_d);
                    int idx_fin_hauur = DB_Add_delete_update_.Database.ds.Tables["TB_sys_hauur"].Rows.IndexOf(idx_find_hauur);

                    if (idx_find_hauur != null)
                    {
                        DB_Add_delete_update_.Database.ds.Tables["TB_sys_hauur"].Rows[idx_fin_hauur].Delete();

                        //DB_Add_delete_update_.Database.ds.Tables["TB_sys_hauur"].Rows.Remove(idx_find_hauur);
                        DB_Add_delete_update_.Database.update("TB_sys_hauur");
                        MessageBox.Show("تم الحذف من جدول الساعه");

                    }
                    else
                    {
                        MessageBox.Show("لم يتم الحذف من جدول الساعه");
                    }
                    DataRow inf_Emp = DB_Add_delete_update_.Database.ds.Tables["TB_Employees"].Rows.Find(num_Emp_d);
                    int idx_fin_inf_Emp = DB_Add_delete_update_.Database.ds.Tables["TB_Employees"].Rows.IndexOf(inf_Emp);

                    if (inf_Emp != null)
                    {
                        DB_Add_delete_update_.Database.ds.Tables["TB_Employees"].Rows[idx_fin_inf_Emp].Delete();

                        //DB_Add_delete_update_.Database.ds.Tables["TB_Employees"].Rows.Remove(inf_Emp);
                        DB_Add_delete_update_.Database.update("TB_Employees");
                        MessageBox.Show("تم حذف الموظف بنجاح ");

                    }
                    else
                    {
                        MessageBox.Show("لم يتم الحذف من جدول الموظف");
                    }
                }

               new Show_Employees().show_info_Emp();//داله لعرض شاشةالموظفين

                //show_info_Emp_in_DGV_Emp();


            }
        }

    }
}
