using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data;

using System.Windows.Data;

namespace Manag_ph.Employlee.Page_Employees
{
    class Show_Employees
    {

       
         public void show_info_Emp()
        {// داله عرض جدول الموظفين 
            var n = Application.OpenForms["Main"] as Main;
            n.dgv_view_EMPS_dgv.Rows.Clear();
            DataView dview_Emp = new DataView();
            dview_Emp = new DataView(DB_Add_delete_update_.Database.ds.Tables["TB_Employees"]);


            int nncoun_row_Emp = dview_Emp.Table.Rows.Count;
            int num_job;
            int num_Emp;

            if (nncoun_row_Emp != 0)
            {
                for (int c = 0; c < nncoun_row_Emp; c++)
                {
                    DataRow dd = dview_Emp.Table.Rows[c];
                    num_job = Convert.ToInt32(dd[3]);
                    num_Emp = Convert.ToInt32(dd[0]);
                    DataRow[] nn = new DataRow[1];
                    nn = DB_Add_delete_update_.Database.ds.Tables["tb_Jobs"].Select("id_Job=" + num_job);

                    string name_job = null;
                    if (nn != null)
                    {
                        name_job = Convert.ToString(nn[0][1]);
                    }
                    DataRow[] comm_ratio = new DataRow[1];
                    comm_ratio = DB_Add_delete_update_.Database.ds.Tables["TB_commission_ratio"].Select("id_EMP=" + num_Emp);
                    double name_ratio1 = 0.0;
                    double name_ratio2 = 0.0;
                    if (comm_ratio.Count() != 0)
                    {

                        name_ratio1 = (double)comm_ratio[0][1];
                        name_ratio2 = (double)comm_ratio[0][2];
                    }
                    object[] data = { dd[0], dd[1], dd[2], Convert.ToString(nn[0][1]), dd[4], dd[5], dd[6], dd[9], name_ratio1, name_ratio2, dd[13], dd[14], dd[15] };// dd[13], dd[14],
                    n.dgv_view_EMPS_dgv.Rows.Add(data);
                }
            }
        }
        public void clerevirablesEmp()
        { //داله تنظيف ادوات الموظف
            var n = Application.OpenForms["Main"] as Main;

            //داله لتنظيف المتغيرات تبع واجهه اضافة الموظف  مع الخانات تبع الواجهه 
            //اخذ اكبر رقم موظف ونزيد واحد 


            n.txt_iD_Emp.Text = new classs_table.Items_Tools().AoutoNumber("TB_Employees", "id_EMP").ToString() ;


            n.txt_Emp_name_ar.Text = null;// اسم الموظف بالعربي
            n.txt_Emp_name_En.Text = null; //اسم الموظف بالانجليزي

            n.txt_phon_Emp.Text = null;// رقم الهاتف الشخصي

            //phon_num = Convert.ToInt32(phon_num_s);// رقم الهاتف الشخصي
            n.txt_Telephon_Emp.Text = null;//رقم الهاتف الثابت

            //telipho_num = Convert.ToInt32(telipho_num_s);//رقم الهاتف الثابت
            n.txt_Addres_Emp.Text = null; //                  عنوان الموظف
            n.txt_grincard_Emp.Text = null;// رقم البطاقه الشخصية


            n.Hostory_Date_Date.Value = DateTime.Now;// تاريخ اصدار البطاقه الشخصية
            n.Date_Pirth_Date.Value = DateTime.Now;//تاريخ ميلاد الموظف
            n.Graduation_Date_Date.Value = DateTime.Now;// تاريخ التخرج الموظف
            n.Date_hiring_Date.Value = DateTime.Now;//ناريخ تعين الموظف

            n.chbox_stop.Checked = false;    //  موظف موقف او لا 
            n.chbox_on_Emp_use_prgram_slahiat.Checked = false;//اذا كان مستخدم برنامج
            n.txt_tayp_Emp.Text = null;     // نوع الموظف او الجنس



            n.chbox_on_Emp_use_prgram_slahiat.Checked = false; //هذا اختيار لو كان مستخدم برنامج
            n.Gbox_pageEmp_sys_login.Enabled = false; // حاويه تسجيل حساب المستخدم
            n.txt_Username_Emp.Enabled = false; // تفعيل  خانة نص اسم المسنخدم
            n.txt_password_Emp.Enabled = false;// تفعيل  خانة نص كلمة المرور
            n.txt_password2_Emp.Enabled = false;// تفعيل  خانة نص تاكيد كلمه المرور

            n.txt_Username_Emp.Text = null;//اسم المستخدم او الجيميل

            n.txt_password_Emp.Text = null;//كلمة السر
            n.txt_password2_Emp.Text = null;// اعادة كلمة السر 

            DateTime newd = new DateTime();
            n.chbox_SAT.Checked = false;
            n.checkBox21.Checked = false;



            //تعديل3
            //n.timeEdit__sat_attendance.Time = Convert.ToDateTime(newd.Date.ToString("t"));//وقت الحضور للسبت
            //n.timeEdit_Sat__Leave.Time = Convert.ToDateTime(newd.Date.ToString("t"));//وقت الانصراف للسبت

            n.timeEdit__sat_attendance.Time = new DateTime();//وقت الحضور للسبت
            n.timeEdit_Sat__Leave.Time = new DateTime();//وقت الانصراف للسبت


            //تعديل3
            n.chbox_SAN.Checked = false;

            //n.timeEdit_SAN_attendance.Time = Convert.ToDateTime(newd.Date.ToString("t"));//وقت الحضور للاحد
            //n.timeEdit_San_Leave.Time = Convert.ToDateTime(newd.Date.ToString("t"));//وقت الانصراف للاحد

            n.timeEdit_SAN_attendance.Time = new DateTime();//وقت الحضور للاحد
            n.timeEdit_San_Leave.Time = new DateTime();//وقت الانصراف للاحد




            n.chbox_MON.Checked = false;

            //n.timeEdit_MON_attendance.Time = Convert.ToDateTime(newd.Date.ToString("t"));//وقت الحضور الاثنين
            //n.timeEdit_MON_Leave.Time = Convert.ToDateTime(newd.Date.ToString("t"));//وقت الانصراف الاثنين


            n.timeEdit_MON_attendance.Time = new DateTime();//وقت الحضور الاثنين
            n.timeEdit_MON_Leave.Time = new DateTime();//وقت الانصراف الاثنين

            n.chbox_TUE.Checked = false;

            //n.timeEdit_TUE_attendance.Time = Convert.ToDateTime(newd.Date.ToString("t"));//وقت الحضور الثلاثاء
            //n.timeEdit_TUE_Leave.Time = Convert.ToDateTime(newd.Date.ToString("t"));//وقت الانصراف الثلاثاء

            n.timeEdit_TUE_attendance.Time = new DateTime();//وقت الحضور الثلاثاء
            n.timeEdit_TUE_Leave.Time = new DateTime();//وقت الانصراف الثلاثاء


            n.chbox_WED.Checked = false;

            //n.timeEdit_WED_attendance.Time = Convert.ToDateTime(newd.Date.ToString("t"));//وقت الحضور الاربعاء
            //n.timeEdit_WED_Leave.Time = Convert.ToDateTime(newd.Date.ToString("t"));//وقت الانصراف الاربعاء

            n.timeEdit_WED_attendance.Time = new DateTime();//وقت الحضور الاربعاء
            n.timeEdit_WED_Leave.Time = new DateTime();//وقت الانصراف الاربعاء

            
            n.chbox_THUR.Checked = false;

            //n.timeEdit_THUR_attendance.Time = Convert.ToDateTime(newd.Date.ToString("t"));//وقت الحضور الخميس
            //n.timeEdit_THUR_Leave.Time = Convert.ToDateTime(newd.Date.ToString("t"));//وقت الانصراف الخميس

            n.timeEdit_THUR_attendance.Time =new DateTime();//وقت الحضور الخميس
            n.timeEdit_THUR_Leave.Time = new DateTime();//وقت الانصراف الخميس

            //تعديل3
            n.chbox_FRI.Checked = false;

            //n.timeEdit_FRI_attendance.Time = Convert.ToDateTime(newd.Date.ToString("t"));//وقت الحضور الجمعة
            //n.timeEdit_FRI_Leave.Time = Convert.ToDateTime(newd.Date.ToString("t"));//وقت الانصراف الجمعة


            //n.timeEdit_FRI_attendance.Time =new DateTime();//وقت الحضور الجمعة
            //n.timeEdit_FRI_Leave.Time = new DateTime();//وقت الانصراف الجمعة


            n.chbox_hourly_salary.Checked = false;

            n.txt_hour_value.Text = null;//قيمة الساعة
            n.txt_Extra_hour_value.Text = null;//قيمة الساعة الشهرية
            n.txt_value_hour_absence.Text = null;//قيمة الساعةالاضافية

            n.chbox_monthe_salary.Checked = false;

            n.txt_salary_value.Text = null; //قيمة الراتب
            n.txt_Extra_day_value.Text = null;//قيمة اليوم الاضافي
            n.txt_day_value_absence.Text = null;//قيمة اليوم الغياب
            //DB_Add_delete_update_.Database.ds.Tables["TB_sys_salary"].Rows.Add(num_Emp, salary_value, Extra_day_value, day_value_absence);
            //DB_Add_delete_update_.Database.update("TB_sys_salary");//

            //n.txt_retail_commission.Text = null;//نسبة عمولة بيع التجزئ
            //n.txt_Wholesale_currency_rate.Text = null; //نسبة عمولة بيع جملة
        }

        //تعديلل
        //static public string num_Emp;// كود الموظف
        //static public string name_AR_Emp;// اسم الموظف بالعربي
        //static public string name_EN_Emp;//اسم الموظف بالانجليزي
        //static public int num_job;
        ////int phon_num;
        //static public string phon_num;       // رقم الهاتف الشخصي
        //                                     //int telipho_num_s;
        //static public string telipho_num;  //رقم الهاتف الثابت
        //static public string aaddress;   //                  عنوان الموظف
        //static public string num_card; // رقم البطاقه الشخصية
        //static public int version_personal_card;//رقم جهه اصدار البطاقة

        //static public DateTime Hostory_Date;// تاريخ اصدار البطاقه الشخصية
        //static public DateTime Pirth_Date;//تاريخ ميلاد الموظف
        //static public DateTime Graduation_Date;// تاريخ التخرج الموظف
        //static public DateTime hiring_Date;//ناريخ تعين الموظف

        //static public bool ch_stop_Emp; //  موظف موقف او لا 
        //static public bool user_program;//اذا كان مستخدم برنامج
        //static public string tayp_Emp;// نوع الموظف او الجنس
        //static public int num_table1 = 0, num_table2 = 0, num_table3 = 0, num_table4 = 0, num_table5 = 0, num_table6 = 0, num_table7 = 0, num_table8 = 0, num_table9 = 0, num_table10 = 0, num_table11 = 0, num_table12 = 0;

        //static public int num_day1, num_day2, num_day3, num_day4, num_day5, num_day6, num_day7;

        //static public string Username_Emp;//اسم المستخدم او الجيميل
        //static public string password_Emp; //كلمة السر
        //static public string password2_Emp;// اعادة كلمة السر


        //static public string time_sat_attendance;//وقت الحضور للسبت
        //static public string time__Sat__Leave;//وقت الانصراف للسبت

        //static public string time_sna_attendance;//وقت الحضور للاحد
        //static public string time__san__Leave;//وقت الانصراف للاحد

        //static public string time_MON_attendance;//وقت الحضور الاثنين
        //static public string time__MON__Leave;//وقت الانصراف الاثنين

        //static public string time_TUE_attendance;//وقت الحضور الثلاثاء
        //static public string time__TUE__Leave;//وقت الانصراف الثلاثاء

        //static public string time_WED_attendance;//وقت الحضور الاربعاء
        //static public string time__WED__Leave;//وقت الانصراف الاربعاء

        //static public string time_THUR_attendance;//وقت الحضور الخميس
        //static public string time__THUR__Leave;//وقت الانصراف الخميس

        //static public string time_FRI_attendance;//وقت الحضور الجمعة
        //static public string time__FRI__Leave;//وقت الانصراف الجمعة

        //static public string hour_value;//قيمة الساعة
        //static public string Monthly_hourly_value;//قيمة الساعة الشهرية
        //static public string Extra_hour_value; //قيمة الساعةالاضافية
        //static public string salary_value; //قيمة الراتب
        //static public string Extra_day_value;//قيمة اليوم الاضافي
        //static public string day_value_absence;//قيمة اليوم الغياب

        //static public double retail_commission;//نسبة عمولة بيع التجزئة
        //static public double Wholesale_currency_rate;//نسبة عمولة بيع جملة

        public void show_DataTable()
        {
            var vr = Application.OpenForms["Main"] as Main;
            vr.dgv_view_EMPS_dgv.Rows.Clear();
            DataTable dt = DB_Add_delete_update_.Database.ds.Tables["TB_Employees"];
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                object[] ob = dt.Rows[i].ItemArray;
                DataRow dr_job = DB_Add_delete_update_.Database.ds.Tables["tb_Jobs"].Rows.Find(ob[3]);
                string Type_salary = Convert.ToInt32( ob[16] )== 1 ? "بالساعة":"باشهر";
                string Type_Emp = Convert.ToInt32(ob[15]) == 1 ? "ذكر" : "انثاء"; 
                string user_system = Convert.ToInt32(ob[14]) == 1 ? "مستخدم" : "ليس مستخدم";
                string emp_stop = Convert.ToInt32(ob[13]) == 1 ? "موقف" : "ليس موقف";
                vr.dgv_view_EMPS_dgv.Rows.Add(ob[0], ob[1], dr_job[1], ob[4],ob[5],ob[6],ob[12], emp_stop, user_system, Type_Emp, Type_salary);
            }
            //vr.dgv_view_EMPS
        }

    }
}
