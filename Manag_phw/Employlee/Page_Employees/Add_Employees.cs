using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;


namespace Manag_ph.Employlee.Page_Employees
{
    class Add_Employees
    {
        public void page_Add_Emp()
        {
            var n = Application.OpenForms["Main"] as Main;
            new Show_Employees().clerevirablesEmp();
            full_casher();
            //int tem_num = 0;
            //تغيير اسم عنوان او اسم الواجهه
            n.lab_title.Text = "اضافة موظف";
            int num_Emp = new classs_table.Items_Tools().AoutoNumber("TB_Employees", "id_EMP");
            n.txt_iD_Emp.Text = Convert.ToString(num_Emp);
            n.btn_save_Emp_btn.Visible = true;
            n.btn_save_adite_Emp_btn.Visible = false;
            n.btn_Exit_form_Add_Emp_btn.Visible = false;

        }

        void full_casher()
        {
            var vr = Application.OpenForms["Main"] as Main;
            new classs_table.Items_Tools().Fill_Combox(vr.com_casher_emply, "casher");
        }
        public void Save_Emps()
        {
            string num_Emp;// كود الموظف
            string name_AR_Emp;// اسم الموظف بالعربي
            string name_EN_Emp;//اسم الموظف بالانجليزي
            int num_job;
            //int phon_num;
            string phon_num;       // رقم الهاتف الشخصي
                                   //int telipho_num_s;
            string telipho_num;  //رقم الهاتف الثابت
            string aaddress;   //                  عنوان الموظف
            string num_card; // رقم البطاقه الشخصية
            int version_personal_card;//رقم جهه اصدار البطاقة

            DateTime Hostory_Date;// تاريخ اصدار البطاقه الشخصية
            DateTime Pirth_Date;//تاريخ ميلاد الموظف
            DateTime Graduation_Date;// تاريخ التخرج الموظف
            DateTime hiring_Date;//ناريخ تعين الموظف

            bool ch_stop_Emp; //  موظف موقف او لا 
            bool user_program;//اذا كان مستخدم برنامج
            int tayp_Emp;// نوع الموظف او الجنس
            int Type_sys_Salary = -1; // نوع نظام الراتب
            //تعديل3
            double discount_value_retail = 0; // عمولة البيع بالتجزئة



            int id_login = new classs_table.Items_Tools().AoutoNumber("TB_LOGIN_EMP", "id_login");
            string Username_Emp = "user";//اسم المستخدم او الجيميل
            string password_Emp = "passwd"; //كلمة السر
            string password2_Emp = "passwd";// اعادة كلمة السر
            bool ch_use_pg = false;

            //تعديل3
            //الراتب بنظام الساعة
            int id_hour = new classs_table.Items_Tools().AoutoNumber("TB_sys_hauur", "id_hour");
            double hour_value = 0;
            double Extra_hour_value = 0;
            double value_hour_absence = 0;

            //تعديل3
            //نظام الراتب باشهر
            int id_Manth = new classs_table.Items_Tools().AoutoNumber("TB_sys_salary", "id_minth");
            double salary_value = 0;
            double Extra_day_value = 0;
            double day_value_absence = 0;

            //تعديل3
            int saturday = 0;
            string time_sat_attendance="00:00";//وقت الحضور للسبت
            string time__Sat__Leave= "00:00";//وقت الانصراف للسبت

            int sun = 0;
            string time_sun_attendance = "00:00";//وقت الحضور للاحد
            string time__sun__Leave = "00:00";//وقت الانصراف للاحد

            int mon = 0;
            string time_MON_attendance = "00:00";//وقت الحضور الاثنين
            string time__MON__Leave = "00:00";//وقت الانصراف الاثنين

            int tue = 0;
            string time_TUE_attendance = "00:00";//وقت الحضور الثلاثاء
            string time__TUE__Leave = "00:00";//وقت الانصراف الاثلاثاء

            int wed = 0;
            string time_WED_attendance = "00:00";//وقت الحضور الاربعاء
            string time__WED__Leave = "00:00";//وقت الانصراف الاربعاء

            int thus = 0;
            string time_THUS_attendance = "00:00";//وقت الحضور الخميس
            string time__THUS__Leave = "00:00";//وقت الانصراف الخميس
            //تعديل3
            int fri = 0;
            string time_FRI_attendance = "00:00";//وقت الحضور الجمعة
            string time__FRI__Leave = "00:00";//وقت الانصراف الجمعة

            var n = Application.OpenForms["Main"] as Main;


            num_Emp = n.txt_iD_Emp.Text;   // كود الموظف
            name_AR_Emp = n.txt_Emp_name_ar.Text;// اسم الموظف بالعربي
            name_EN_Emp = n.txt_Emp_name_En.Text; //اسم الموظف بالانجليزي
            num_job = Convert.ToInt32(n.combx_jobs.SelectedValue);//ناخذ القيمة المختاره من الوظائف
            phon_num = n.txt_phon_Emp.Text;// رقم الهاتف الشخصي
            telipho_num = n.txt_Telephon_Emp.Text.Trim() == String.Empty ? "0" : n.txt_Telephon_Emp.Text.Trim();//رقم الهاتف الثابت
            aaddress = n.txt_Addres_Emp.Text.Trim() == string.Empty ? "null" : n.txt_Addres_Emp.Text.Trim(); // عنوان الموظف
            num_card = n.txt_grincard_Emp.Text;// رقم البطاقه الشخصية
            version_personal_card = Convert.ToInt32(n.combox_version_personal_card.SelectedValue);//رقم جهه اصدار البطاقة
            Hostory_Date = Convert.ToDateTime(n.Hostory_Date_Date.Value);// تاريخ اصدار البطاقه الشخصية
            Pirth_Date = Convert.ToDateTime(n.Date_Pirth_Date.Value);//تاريخ ميلاد الموظف
            Graduation_Date = Convert.ToDateTime(n.Graduation_Date_Date.Value);// تاريخ التخرج الموظف
            hiring_Date = Convert.ToDateTime(n.Date_hiring_Date.Value);//ناريخ تعين الموظف

            ch_stop_Emp = n.chbox_stop.Checked;    //  موظف موقف او لا 
            user_program = n.chbox_on_Emp_use_prgram_slahiat.Checked;//اذا كان مستخدم برنامج
            tayp_Emp = n.rb_male.Checked ? 1 : 0;     // نوع الموظف او الجنس
            //تعديل3
            discount_value_retail = n.txt_retail_commission.Text.Trim() == String.Empty.Trim() ? Convert.ToDouble("0") :  Convert.ToDouble(n.txt_retail_commission.Text);


            if (n.txt_Emp_name_ar.Text.Trim() == string.Empty)
            {
                MessageBox.Show("يرجاء تعبئة خانة الاسم العربي");
                n.txt_Emp_name_ar.Focus();
                return;
            }

            if (n.txt_Emp_name_En.Text.Trim() == string.Empty)
            {
                MessageBox.Show("يرجاء تعبئة خانة الاسم بالنجليزي");
                n.txt_Emp_name_En.Focus();
                return;
            }
            if (n.txt_phon_Emp.Text.Trim() == string.Empty)
            {
                MessageBox.Show("يرجاء تعبئة خانة رقم الهاتف ");
                n.txt_phon_Emp.Focus();
                return;
            }

            if (n.chbox_on_Emp_use_prgram_slahiat.Checked == true)
            {
                if (n.txt_Username_Emp.Text.Trim() == string.Empty)
                {
                    MessageBox.Show("يرجاء تعبئة خانة اسم المستخدم او الجيمايل ");
                    return;
                }
                if ((n.txt_password_Emp.Text.Trim() == string.Empty && n.txt_password2_Emp.Text.Trim() == string.Empty) || (n.txt_password_Emp.Text.Trim() != n.txt_password2_Emp.Text.Trim()))
                {

                    MessageBox.Show(" يرجاء تطابق كلمات المرور !", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    n.txt_password2_Emp.Focus();
                    return;

                }
                Username_Emp = n.txt_Username_Emp.Text.Trim();
                password_Emp = n.txt_password_Emp.Text.Trim();
                password2_Emp = n.txt_password2_Emp.Text.Trim();
                ch_use_pg = true;

            }
            if (n.txt_grincard_Emp.Text.Trim() == string.Empty)
            {
                num_card = "0";// رقم البطاقه الشخصية
                //تعديلل
                //MessageBox.Show("يرجاء تعبئة خانة رقم البطاقة  ");
                //n.txt_grincard_Emp.Focus();
                //return;
            }

            //تعديلل
            //if (n.txt_retail_commission.Text == null)
            //{

            //    //MessageBox.Show("يرجاء تعبئة خانة نسبة العمولة بالتجزئة ");
            //    //n.txt_retail_commission.Focus();
            //    //return;
            //}

            //تعديلل
            //if (n.txt_Wholesale_currency_rate.Text == null)
            //{
            //    MessageBox.Show("يرجاء تعبئة خانة نسبة العمولة بالجملة ");
            //    n.txt_Wholesale_currency_rate.Focus();
            //    return;
            //}

            //تعديل3
            if (n.chbox_SAT.Checked)
            {
                saturday = 1;
                time_sat_attendance = n.timeEdit__sat_attendance.Time.ToString("HH:mm");
                time__Sat__Leave = n.timeEdit_Sat__Leave.Time.ToString("HH:mm");

            }
            if (n.chbox_SAN.Checked)
            {
                sun = 1;
                time_sun_attendance = n.timeEdit_SAN_attendance.Time.ToString("HH:mm");
                time__sun__Leave = n.timeEdit_San_Leave.Time.ToString("HH:mm");

            }
            if (n.chbox_MON.Checked)
            {
                mon = 1;
                time_MON_attendance = n.timeEdit_MON_attendance.Time.ToString("HH:mm");
                time__MON__Leave = n.timeEdit_MON_Leave.Time.ToString("HH:mm");

            }
            if (n.chbox_TUE.Checked)
            {
                tue = 1;
                time_TUE_attendance = n.timeEdit_TUE_attendance.Time.ToString("HH:mm");
                time__TUE__Leave = n.timeEdit_TUE_Leave.Time.ToString("HH:mm");

            }
            if (n.chbox_WED.Checked)
            {
                wed = 1;
                time_WED_attendance = n.timeEdit_WED_attendance.Time.ToString("HH:mm");
                time__WED__Leave = n.timeEdit_WED_Leave.Time.ToString("HH:mm");

            }
            if (n.chbox_THUR.Checked)
            {
                thus = 1;
                time_THUS_attendance = n.timeEdit_THUR_attendance.Time.ToString("HH:mm");
                time__THUS__Leave = n.timeEdit_THUR_Leave.Time.ToString("HH:mm");

            }
            //تعديل3
            if (n.chbox_FRI.Checked)
            {
                fri = 1;
                time_FRI_attendance = n.timeEdit_FRI_attendance.Time.ToString("HH:mm");
                time__FRI__Leave = n.timeEdit_FRI_Leave.Time.ToString("HH:mm");

            }

            //تعديل3
            //تعديلل
            if (n.chbox_hourly_salary.Checked)
            {
                Type_sys_Salary = 1;
                if (n.txt_hour_value.Text.Trim() != string.Empty && n.txt_Extra_hour_value.Text.Trim() != string.Empty && n.txt_value_hour_absence.Text.Trim() != string.Empty)
                {
                    hour_value = Convert.ToDouble(n.txt_hour_value.Text.Trim());
                    Extra_hour_value = Convert.ToDouble(n.txt_Extra_hour_value.Text.Trim());
                    value_hour_absence = Convert.ToDouble(n.txt_value_hour_absence.Text.Trim()); ;
                }

                //تعديلل
                //else
                //{
                //    MessageBox.Show("يرجاء تعبة كل بيانات نظام الراتب بساعة", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //    return;
                //}

            }
            //تعديل3
            else if (n.chbox_monthe_salary.Checked)
            {
                Type_sys_Salary = 0;
                if (n.txt_salary_value.Text.Trim() != string.Empty && n.txt_Extra_day_value.Text.Trim() != string.Empty && n.txt_day_value_absence.Text.Trim() != string.Empty)
                {
                    salary_value = Convert.ToDouble(n.txt_salary_value.Text.Trim());
                    Extra_day_value = Convert.ToDouble(n.txt_Extra_day_value.Text.Trim());
                    day_value_absence = Convert.ToDouble(n.txt_day_value_absence.Text.Trim());
                }

                //تعديلل
                //else
                //{
                //    MessageBox.Show("يرجاء تعبة كل بيانات نظام الراتب بشهر", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //    return;
                //}
            }
            //تعديل3
            else if ((!n.chbox_hourly_salary.Checked && !n.chbox_monthe_salary.Checked))
            {
                //تعديلل
                Type_sys_Salary = 2;
                //salary_value = Convert.ToDouble(n.txt_salary_value.Text.Trim());
                //Extra_day_value = Convert.ToDouble(n.txt_Extra_day_value.Text.Trim());
                //day_value_absence = Convert.ToDouble(n.txt_day_value_absence.Text.Trim());
                //MessageBox.Show("يرجاء اختيار نظام الراتب ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //return;
            }

            //تعديل3
            DB_Add_delete_update_.Database.ds.Tables["TB_Employees"].Rows.Add(num_Emp, name_AR_Emp, name_EN_Emp, num_job, phon_num, telipho_num, aaddress, num_card, version_personal_card, Hostory_Date, Pirth_Date, Graduation_Date, hiring_Date, ch_stop_Emp, user_program, tayp_Emp, Type_sys_Salary , discount_value_retail);
            DB_Add_delete_update_.Database.update("TB_Employees");//
            DataRow dta = DB_Add_delete_update_.Database.ds.Tables["TB_Employees"].Rows.Find(Convert.ToInt32(num_Emp));
            if (dta != null)
            { 

            if (ch_use_pg)
            {

                DB_Add_delete_update_.Database.ds.Tables["TB_LOGIN_EMP"].Rows.Add(id_login, Username_Emp, password_Emp, password2_Emp, num_Emp, n.checkBox21.Checked == true ? n.com_casher_emply.SelectedValue : null);
                DB_Add_delete_update_.Database.update("TB_LOGIN_EMP");//
            }
                //تعديل3
             if (n.chbox_SAT.Checked || n.chbox_SAN.Checked || n.chbox_MON.Checked || n.chbox_TUE.Checked || n.chbox_WED.Checked || n.chbox_THUR.Checked || n.chbox_FRI.Checked)//  حفظ الايام و اوفات الحضور والانصراف الى جدول الايام الخاص بالموظف
             {
                    int autonum = new classs_table.Items_Tools().AoutoNumber("TB_Emplyee_days_weekly", "code");
                    //DataRow[] dr_Emp_d_weekly = DB_Add_delete_update_.Database.ds.Tables["TB_Emplyee_days_weekly"].Select();
                    //if (dr_Emp_d_weekly.Count() != 0)
                    //{

                    //     autonum = new classs_table.Items_Tools().AoutoNumber("TB_Emplyee_days_weekly", "code");

                    //}
                    //تعديل3
                    DB_Add_delete_update_.Database.ds.Tables["TB_Emplyee_days_weekly"].Rows.Add(autonum,
                                                                                                num_Emp,

                                                                                                saturday,
                                                                                                time_sat_attendance,
                                                                                                time__Sat__Leave,

                                                                                                sun,
                                                                                                time_sun_attendance,
                                                                                                time__sun__Leave, 
                                                                                                
                                                                                                mon,
                                                                                                time_MON_attendance,
                                                                                                time__MON__Leave, 

                                                                                                tue,
                                                                                                time_TUE_attendance,
                                                                                                time__TUE__Leave, 

                                                                                                wed,
                                                                                                time_WED_attendance,
                                                                                                time__WED__Leave, 

                                                                                                thus,
                                                                                                time_THUS_attendance,
                                                                                                time__THUS__Leave, 

                                                                                                fri,
                                                                                                time_FRI_attendance,
                                                                                                time__FRI__Leave);
                    DB_Add_delete_update_.Database.update("TB_Emplyee_days_weekly");//
                    MessageBox.Show("تم حفط التوقيتات");
                }
            //تعديل3
            if (Type_sys_Salary == 1)//شرط اذا كان القيمة واحد اذا الحفظ الى جدول الساعات 
            {
                DB_Add_delete_update_.Database.ds.Tables["TB_sys_hauur"].Rows.Add(id_hour, hour_value,  Extra_hour_value, value_hour_absence ,num_Emp);
                DB_Add_delete_update_.Database.update("TB_sys_hauur");//

            }
            //تعديل3

            else if (Type_sys_Salary == 0)//شرط اذا كان القيمة صفر اذا الحفظ الى جدول الرواتب 
                {
                DB_Add_delete_update_.Database.ds.Tables["TB_sys_salary"].Rows.Add(id_Manth, salary_value, Extra_day_value, day_value_absence, num_Emp);
                DB_Add_delete_update_.Database.update("TB_sys_salary");//
            }
                //تعديل3
                ////تعديلل
                else
                {
                    MessageBox.Show("الموظف لم يتم ادخال له راتب");
                                            //    DB_Add_delete_update_.Database.ds.Tables["TB_sys_salary"].Rows.Add(id_Manth, salary_value, Extra_day_value, day_value_absence, num_Emp);
                                            //    DB_Add_delete_update_.Database.update("TB_sys_salary");//

                }

            double cred = 0;//دائن
            double Debt = 0;//مدين
            DB_Add_delete_update_.Database.ds.Tables["Emplyee_account"].Rows.Add(num_Emp, cred, Debt);
            DB_Add_delete_update_.Database.update("Emplyee_account");

            MessageBox.Show(" تم حفظ الموظف بنجاح ", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
            new Show_Employees().clerevirablesEmp();
        }
            else {
                MessageBox.Show(" لم يتم  حفظ الموظف ! ", "", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
}


    }
}
