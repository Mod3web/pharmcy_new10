using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraBars.Navigation;

namespace Manag_ph.Employlee.Page_Employees
{
    class Update_Employees
    {
   
        public void show_update_Employ()
        {
                var vr = Application.OpenForms["Main"] as Main;
            if (vr.dgv_view_EMPS_dgv.CurrentRow != null)
            {


                object[] obje = DB_Add_delete_update_.Database.ds.Tables["TB_Employees"].Rows.Find(vr.dgv_view_EMPS_dgv.CurrentRow.Cells[0].Value).ItemArray;

                int id_emp = Convert.ToInt32(obje[0]);

                vr.txt_iD_Emp.Text = id_emp.ToString();
                vr.txt_Emp_name_ar.Text = obje[1].ToString();
                vr.txt_Emp_name_En.Text = obje[2].ToString();
                vr.combx_jobs.SelectedValue = Convert.ToInt32(obje[3]);
               vr. txt_phon_Emp.Text = obje[4].ToString();
               vr. txt_Telephon_Emp.Text = obje[5].ToString();
               vr. txt_Addres_Emp.Text = obje[6].ToString();
               vr. txt_grincard_Emp.Text = obje[7].ToString();
               vr. combox_version_personal_card.SelectedValue = Convert.ToInt32(obje[8]);
               vr. Hostory_Date_Date.Text = Convert.ToDateTime(obje[9]).ToString("d");
               vr. Date_Pirth_Date.Text = Convert.ToDateTime(obje[10]).ToString("d");
               vr. Graduation_Date_Date.Text = Convert.ToDateTime(obje[11]).ToString("d");
               vr. Date_hiring_Date.Text = Convert.ToDateTime(obje[12]).ToString("d");
                vr.chbox_stop.Checked = Convert.ToBoolean(obje[13]) == true ? true : false;

                //تعديل3
                vr.txt_retail_commission.Text = obje[17].ToString();// عمولة البيع بالتجزئة

                if (Convert.ToBoolean(obje[14]))
                {
                   vr. chbox_on_Emp_use_prgram_slahiat.Checked = true;
                   vr. txt_Username_Emp.Enabled = true;
                   vr. txt_password_Emp.Enabled = true;
                   vr. txt_password2_Emp.Enabled = true;
                   DataRow[] dr_login = DB_Add_delete_update_.Database.ds.Tables["TB_LOGIN_EMP"].Select("id_EMP = " + id_emp);
                   vr. txt_Username_Emp.Text = dr_login[0][1].ToString();
                   vr. txt_password_Emp.Text = dr_login[0][2].ToString();
                    vr.txt_password2_Emp.Text = dr_login[0][3].ToString();
                }
                else
                {
                   vr. chbox_on_Emp_use_prgram_slahiat.Checked = false;
                   vr. txt_Username_Emp.Enabled = false;
                   vr. txt_password_Emp.Enabled = false;
                    vr.txt_password2_Emp.Enabled = false;

                }
                if (Convert.ToBoolean(obje[15]))
                {
                    vr.rb_male.Checked = true;
                    vr.rb_female.Checked = false;
                }
                
                else
                {
                   vr. rb_male.Checked = false;
                    vr.rb_female.Checked = true;
                }



                //تعديل3
               

                DataRow [] drdays = DB_Add_delete_update_.Database.ds.Tables["TB_Emplyee_days_weekly"].Select("id_Emp ="+vr.dgv_view_EMPS_dgv.CurrentRow.Cells[0].Value);
                if (drdays.Count() !=0)
                {
                    //DataRow drdays2 = DB_Add_delete_update_.Database.ds.Tables["TB_Emplyee_days_weekly"].Rows.Find(Convert.ToInt32( drdays[0][0]));

                    //التحقق من يوم السبت
                    if (Convert.ToInt32(drdays[0][2]) == 1)
                    {
                        vr.chbox_SAT.Checked = true;
                        vr.timeEdit__sat_attendance.Time =Convert.ToDateTime(drdays[0][3]);
                        vr.timeEdit_Sat__Leave.Time = Convert.ToDateTime( drdays[0][4]);

                    }
                    else if (Convert.ToInt32(drdays[0][2]) == 0)
                    {
                        vr.chbox_SAT.Checked = false;

                    }
                    //التحقق من يوم الاحد
                    if (Convert.ToInt32(drdays[0][5]) == 1)
                    {
                        vr.chbox_SAN.Checked = true;
                        vr.timeEdit_SAN_attendance.Time = Convert.ToDateTime(drdays[0][6]);
                        vr.timeEdit_San_Leave.Time = Convert.ToDateTime(drdays[0][7]);

                    }
                    else if (Convert.ToInt32(drdays[0][5]) == 0)
                    {
                        vr.chbox_SAN.Checked = false;

                    }
                    //التحقق من يوم الاثنين
                    if (Convert.ToInt32(drdays[0][8]) == 1)
                    {
                        vr.chbox_MON.Checked = true;
                        vr.timeEdit_MON_attendance.Time = Convert.ToDateTime(drdays[0][9]);
                        vr.timeEdit_MON_Leave.Time = Convert.ToDateTime(drdays[0][10]);

                    }
                    else if (Convert.ToInt32(drdays[0][8]) == 0)
                    {
                        vr.chbox_MON.Checked = false;

                    }
                    //التحقق من يوم الثلاثاء
                    if (Convert.ToInt32(drdays[0][11]) == 1)
                    {
                        vr.chbox_TUE.Checked = true;
                        vr.timeEdit_TUE_attendance.Time = Convert.ToDateTime(drdays[0][12]);
                        vr.timeEdit_TUE_Leave.Time = Convert.ToDateTime(drdays[0][13]);

                    }
                    else if (Convert.ToInt32(drdays[0][11]) == 0)
                    {
                        vr.chbox_TUE.Checked = false;

                    }
                    //التحقق من يوم الاربعاء
                    if (Convert.ToInt32(drdays[0][14]) == 1)
                    {
                        vr.chbox_WED.Checked = true;
                        vr.timeEdit_WED_attendance.Time = Convert.ToDateTime(drdays[0][15]);
                        vr.timeEdit_WED_Leave.Time = Convert.ToDateTime(drdays[0][16]);

                    }
                    else if (Convert.ToInt32(drdays[0][14]) == 0)
                    {
                        vr.chbox_WED.Checked = false;

                    }

                    //التحقق من يوم الخميس
                    if (Convert.ToInt32(drdays[0][17]) == 1)
                    {
                        vr.chbox_THUR.Checked = true;
                        vr.timeEdit_THUR_attendance.Time = Convert.ToDateTime(drdays[0][18]);
                        vr.timeEdit_THUR_Leave.Time = Convert.ToDateTime(drdays[0][19]);

                    }
                    else if (Convert.ToInt32(drdays[0][17]) == 0)
                    {
                        vr.chbox_THUR.Checked = false;

                    }


                    if (Convert.ToInt32(drdays[0][20]) == 1)//التحقق من يوم الجمعه
                    {
                        vr.chbox_FRI.Checked = true;
                        vr.timeEdit_FRI_attendance.Time = Convert.ToDateTime(drdays[0][21]);
                        vr.timeEdit_FRI_Leave.Time = Convert.ToDateTime(drdays[0][22]);

                    }
                    else if (Convert.ToInt32(drdays[0][20]) == 0)
                    {
                        vr.chbox_FRI.Checked = false;

                    } //تعديل3
                }


                //تعديل3
                if (Convert.ToInt32(obje[16]) == 1) //شرط اذا كان يساوي واحد اذا لدية راتي بالساعة
                {
                    vr.chbox_hourly_salary.Checked = true;
                    vr.txt_hour_value.Enabled = true;
                    vr.txt_Extra_hour_value.Enabled = true;
                    vr.txt_value_hour_absence.Enabled = true;
                    DataRow[] dr_sys_hore = DB_Add_delete_update_.Database.ds.Tables["TB_sys_hauur"].Select("id_EMP =" + id_emp);
                    vr.txt_hour_value.Text = dr_sys_hore[0][1].ToString();
                    vr.txt_Extra_hour_value.Text = dr_sys_hore[0][2].ToString();
                    vr.txt_value_hour_absence.Text = dr_sys_hore[0][3].ToString();
                }
                //تعديل3
                else if (Convert.ToInt32(obje[16]) == 0)//شرط اذا كان يساوي صفر اذا لدية راتب شهري
                {
                    vr.chbox_monthe_salary.Checked = true;
                    vr.txt_salary_value.Enabled = true;
                    vr.txt_Extra_day_value.Enabled = true;
                    vr.txt_day_value_absence.Enabled = true;
                    DataRow[] dr_sys_hore = DB_Add_delete_update_.Database.ds.Tables["TB_sys_salary"].Select("id_EMP =" + id_emp);
                    vr.txt_salary_value.Text = dr_sys_hore[0][1].ToString();
                    vr.txt_Extra_day_value.Text = dr_sys_hore[0][2].ToString();
                    vr.txt_day_value_absence.Text = dr_sys_hore[0][3].ToString();

                }
                //تعديل3
                else
                {
                    vr.chbox_monthe_salary.Checked = false;
                    vr.txt_salary_value.Enabled = false;
                    vr.txt_Extra_day_value.Enabled = false;
                    vr.txt_day_value_absence.Enabled = false;
                    vr.chbox_hourly_salary.Checked = false;
                    vr.txt_hour_value.Enabled = false;
                    vr.txt_Extra_hour_value.Enabled = false;
                    vr.txt_value_hour_absence.Enabled = false;

                }
                vr.btn_save_Emp_btn.Visible = false;
                vr.btn_save_adite_Emp_btn.Visible = true;
                vr.lab_title.Text = "تعديل موظف";
                vr.btn_Exit_form_Add_Emp_btn.Visible = true;
                new classs_table.Items_Tools().showAndHideForm(vr.Emplyes_page);
            }
        }

    public void save_update()
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
            int id_hour = new classs_table.Items_Tools().AoutoNumber("TB_sys_hauur", "id_hour"); ;
            double hour_value = 0;
            double Extra_hour_value = 0;
            double value_hour_absence = 0;

            //تعديل3
            //نظام الراتب باشهر
            int id_Manth = new classs_table.Items_Tools().AoutoNumber("TB_sys_salary", "id_month"); ;
            double salary_value = 0;
            double Extra_day_value = 0;
            double day_value_absence = 0;


            //string time_sat_attendance;//وقت الحضور للسبت
            //string time__Sat__Leave;//وقت الانصراف للسبت

            //string time_sna_attendance;//وقت الحضور للاحد
            //string time__san__Leave;//وقت الانصراف للاحد

            //string time_MON_attendance;//وقت الحضور الاثنين
            //string time__MON__Leave;//وقت الانصراف الاثنين
            //string time_TUE_attendance;//وقت الحضور الثلاثاء

            //تعديل3
            int saturday = 0;
            string time_sat_attendance = "00:00";//وقت الحضور للسبت
            string time__Sat__Leave = "00:00";//وقت الانصراف للسبت

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
            discount_value_retail = Convert.ToDouble( n.txt_retail_commission.Text);// عمولة البيع بالتجزئة


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
                    MessageBox.Show("يرجاء تعبئة خانة اسم المستخدم او الجمايل ");
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
            //    MessageBox.Show("يرجاء تعبئة خانة نسبة العمولة بالتجزئة ");
            //    n.txt_retail_commission.Focus();
            //    return;
            //}

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

            }//تعديل3
            if (n.chbox_FRI.Checked)
            {
                fri = 1;
                time_FRI_attendance = n.timeEdit_FRI_attendance.Time.ToString("HH:mm");
                time__FRI__Leave = n.timeEdit_FRI_Leave.Time.ToString("HH:mm");

            }

            //تعديل3
            if (n.chbox_hourly_salary.Checked)
            {
                Type_sys_Salary = 1;//شرط اذا تم اختيار راتب بالساعة يتم اضافة الرقم واحد 
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
                Type_sys_Salary = 0;//شرط اذا تم اختيار راتب بالشهر يتم اضافة الرقم صفر 
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
            else if ((!n.chbox_hourly_salary.Checked && !n.chbox_monthe_salary.Checked))//شرط اذا لم  يتم اختيار راتب بالشهر  ولا بالساعة يتم اضافة الرقم 2 
            {
                

                //تعديلل
                Type_sys_Salary = 2; //شرط اذا كان ليس لديه راتب بالساعة ولا بالشهر يضيف الرقم 2
                //salary_value = Convert.ToDouble(n.txt_salary_value.Text.Trim());
                //Extra_day_value = Convert.ToDouble(n.txt_Extra_day_value.Text.Trim());
                //day_value_absence = Convert.ToDouble(n.txt_day_value_absence.Text.Trim());
                //MessageBox.Show("يرجاء اختيار نظام الراتب ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //return;
            }


            object[] ob_Emp = DB_Add_delete_update_.Database.ds.Tables["TB_Employees"].Rows.Find(num_Emp).ItemArray;
            DataRow[] dr_Login = DB_Add_delete_update_.Database.ds.Tables["TB_LOGIN_EMP"].Select("id_EMP = " + num_Emp);

            if (Convert.ToBoolean(ob_Emp[14]) != user_program)
            {
                if (Convert.ToBoolean(ob_Emp[14]) == true)
                {
                    // مسح بيانات تسجيل الدخول في 
                    new classs_table.Items_Tools().Delete_Rows_Table_Database_Miulty_Key("TB_LOGIN_EMP", new object[] { dr_Login[0][0], dr_Login[0][1] });
                }
                else if (Convert.ToBoolean(ob_Emp[14]) == false)
                {
                    // اضافة بيانات تسجيل الدخول في حالة لم يكن يستخدم النظام
                    DB_Add_delete_update_.Database.ds.Tables["TB_LOGIN_EMP"].Rows.Add(id_login, Username_Emp, password_Emp, password2_Emp, num_Emp);
                    DB_Add_delete_update_.Database.update("TB_LOGIN_EMP");
                }

            }else if(Convert.ToBoolean(ob_Emp[14]) == true && user_program == true)
            {
                //تحديث بيانات  تسجيل الدخول
              object[] ob_Login_up =  DB_Add_delete_update_.Database.ds.Tables["TB_LOGIN_EMP"].Rows.Find(new object[]  { dr_Login[0][0], dr_Login[0][1]}).ItemArray;
                ob_Login_up[1] = Username_Emp;
                ob_Login_up[2] = password_Emp;
                ob_Login_up[3] = password2_Emp;
                new classs_table.Items_Tools().update_Rows_Table_Database_miulty_key("TB_LOGIN_EMP", new object[] { dr_Login[0][0], dr_Login[0][1]}, ob_Login_up);
            }
            //تعديل3
            DataRow[] dr_days_static = DB_Add_delete_update_.Database.ds.Tables["TB_Emplyee_days_weekly"].Select("id_Emp = " + num_Emp);
            if (dr_days_static.Count() != 0)
            {
                object[] ob_Emp_day_static = DB_Add_delete_update_.Database.ds.Tables["TB_Emplyee_days_weekly"].Rows.Find(dr_days_static[0][0]).ItemArray;
                ob_Emp_day_static[1] = Convert.ToInt32(num_Emp);
                ob_Emp_day_static[2] = saturday;
                ob_Emp_day_static[3] = time_sat_attendance;
                ob_Emp_day_static[4] = time__Sat__Leave;
                ob_Emp_day_static[5] = sun;
                ob_Emp_day_static[6] = time_sun_attendance;
                ob_Emp_day_static[7] = time__sun__Leave;
                ob_Emp_day_static[8] = mon;
                ob_Emp_day_static[9] = time_MON_attendance;
                ob_Emp_day_static[10] = time__MON__Leave;
                ob_Emp_day_static[11] = tue;
                ob_Emp_day_static[12] = time_TUE_attendance;
                ob_Emp_day_static[13] = time__TUE__Leave;

                ob_Emp_day_static[14] = wed;
                ob_Emp_day_static[15] = time_WED_attendance;
                ob_Emp_day_static[16] = time__WED__Leave;
                ob_Emp_day_static[17] = thus;
                ob_Emp_day_static[18] = time_THUS_attendance;
                ob_Emp_day_static[19] = time__THUS__Leave;
                ob_Emp_day_static[20] = fri;
                ob_Emp_day_static[21] = time_FRI_attendance;
                ob_Emp_day_static[22] = time__FRI__Leave;
                new classs_table.Items_Tools().update_Rows_Table_Database("TB_Emplyee_days_weekly", dr_days_static[0][0].ToString(), ob_Emp_day_static);

                MessageBox.Show("تم تعديل الاوقات");
            }
            else {
                //تعديل3
                int aout_tb_days =  new classs_table.Items_Tools().AoutoNumber("TB_Emplyee_days_weekly", "code");

                DB_Add_delete_update_.Database.ds.Tables["TB_Emplyee_days_weekly"].Rows.Add(aout_tb_days,
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
                                                                                                time__FRI__Leave
                                                                                                                    );
                DB_Add_delete_update_.Database.update("TB_Emplyee_days_weekly");//

            }

            DataRow[] dr_sys_Minth = DB_Add_delete_update_.Database.ds.Tables["TB_sys_salary"].Select("id_EMP = " + num_Emp);
            DataRow[] dr_sys_houre = DB_Add_delete_update_.Database.ds.Tables["TB_sys_hauur"].Select("id_EMP = " + num_Emp);

            //تعديل3
            if (Convert.ToInt32(ob_Emp[16] ) != Type_sys_Salary)
            {

                if (Type_sys_Salary == 1)
                {
                    DB_Add_delete_update_.Database.ds.Tables["TB_sys_hauur"].Rows.Add(id_hour, hour_value, Extra_hour_value, value_hour_absence, num_Emp);
                    DB_Add_delete_update_.Database.update("TB_sys_hauur");//
                    if (dr_sys_Minth.Count() != 0)
                    {
                        new classs_table.Items_Tools().Delete_Rows_Table_Database("TB_sys_salary", dr_sys_Minth[0][0].ToString());
                    }
                }
                else if (Type_sys_Salary == 0)
                {
                    DB_Add_delete_update_.Database.ds.Tables["TB_sys_salary"].Rows.Add(id_Manth, salary_value, Extra_day_value, day_value_absence, num_Emp);
                    DB_Add_delete_update_.Database.update("TB_sys_salary");//
                    if (dr_sys_houre .Count()!=0)
                    {

                    new classs_table.Items_Tools().Delete_Rows_Table_Database("TB_sys_hauur", dr_sys_houre[0][0].ToString());
                    }

                }
                else
               if (Type_sys_Salary == 2)
                {
                    if (Convert.ToInt32(ob_Emp[16]) == 1)
                    {
                        if (dr_sys_houre .Count()!=0)
                        {
                          new classs_table.Items_Tools().Delete_Rows_Table_Database("TB_sys_hauur", dr_sys_houre[0][0].ToString());
                        }
                    }
                    else if (Convert.ToInt32(ob_Emp[16]) == 0)
                    {
                        if (dr_sys_Minth.Count() != 0)
                        {
                            new classs_table.Items_Tools().Delete_Rows_Table_Database("TB_sys_salary", dr_sys_Minth[0][0].ToString());
                        }
                    }
                }


                }
            //تعديل3
            else
            {
                if (Type_sys_Salary == 1)
                {
                    if (dr_sys_houre.Count() != 0)
                    {
                        object[] ob_her = DB_Add_delete_update_.Database.ds.Tables["TB_sys_hauur"].Rows.Find(dr_sys_houre[0][0]).ItemArray;
                        ob_her[1] = Convert.ToDouble(n.txt_hour_value.Text.Trim());
                        ob_her[2] = Convert.ToDouble(n.txt_Extra_hour_value.Text.Trim());
                        ob_her[3] = Convert.ToDouble(n.txt_value_hour_absence.Text.Trim());
                        new classs_table.Items_Tools().update_Rows_Table_Database("TB_sys_hauur", ob_her[0].ToString(), ob_her);
                    }
                }
                else if (Type_sys_Salary == 0)
                {
                    if (dr_sys_Minth.Count() != 0)
                    {
                        object[] ob_Login_up = DB_Add_delete_update_.Database.ds.Tables["TB_sys_salary"].Rows.Find(dr_sys_Minth[0][0]).ItemArray;
                        ob_Login_up[1] = Convert.ToDouble(n.txt_salary_value.Text.Trim());
                        ob_Login_up[2] = Convert.ToDouble(n.txt_Extra_day_value.Text.Trim());
                        ob_Login_up[3] = Convert.ToDouble(n.txt_day_value_absence.Text.Trim());
                        new classs_table.Items_Tools().update_Rows_Table_Database("TB_sys_salary", ob_Login_up[0].ToString(), ob_Login_up);
                    }
                } else if (Type_sys_Salary == 2)
                {
                    Type_sys_Salary = 2;

                }

            }




            ob_Emp[1] = name_AR_Emp;
            ob_Emp[2] = name_EN_Emp;
            ob_Emp[3] = num_job;
            ob_Emp[4] = phon_num;
            ob_Emp[5] = telipho_num;
            ob_Emp[6] = aaddress;
            ob_Emp[7] = num_card;
            ob_Emp[8] = version_personal_card;
            ob_Emp[9] = Hostory_Date;
            ob_Emp[10] = Pirth_Date;
            ob_Emp[11] = Graduation_Date;
            ob_Emp[12] = hiring_Date;
            ob_Emp[13] = ch_stop_Emp;
            ob_Emp[14] = user_program;
            ob_Emp[15] = tayp_Emp;
            ob_Emp[16] = Type_sys_Salary;
            //تعديل3
            ob_Emp[17] = discount_value_retail;
            new classs_table.Items_Tools().update_Rows_Table_Database("TB_Employees", ob_Emp[0].ToString(), ob_Emp);


            MessageBox.Show("تم التعديل بنجاح ","update",MessageBoxButtons.OK,MessageBoxIcon.Information);

            new Employlee.Page_Employees.Show_Employees().clerevirablesEmp();

            new classs_table.Items_Tools().showAndHideForm(n.page_show_All_Empl);




        }
    }
}
