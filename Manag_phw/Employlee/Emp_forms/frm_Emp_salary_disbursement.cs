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
    public partial class frm_Emp_salary_disbursement : Form
    {
        public frm_Emp_salary_disbursement()
        {
            InitializeComponent();
        }
        DataTable dtable = new DataTable("TB_Employees"); 
        private void Frm_Emp_salary_disbursement_Load(object sender, EventArgs e)
        {
            lode_combobox_Emp();
        }
        public void lode_combobox_Emp()
        {

            dtable.Columns.Add("Code_Emp", typeof(int));
            dtable.Columns.Add("Name_Emp_A", typeof(string));
            dtable.Rows.Add(0, "الكل");
            DataRow[] dr_Emp = DB_Add_delete_update_.Database.ds.Tables["TB_Employees"].Select();
            if (dr_Emp.Count() != 0)
            {

                for (int i = 0; i < dr_Emp.Count(); i++)
                {

                    if (Convert.ToBoolean(dr_Emp[i][13]) != true)
                    {
                        dtable.Rows.Add(Convert.ToInt32(dr_Emp[i][0]), dr_Emp[i][1].ToString());

                    }
                }


                comboBox_Emp_salary_disbursement.DataSource = dtable;

                comboBox_Emp_salary_disbursement.DisplayMember = "Name_Emp_A";
                comboBox_Emp_salary_disbursement.ValueMember = "Code_Emp";

            }
        }

        private void Btn_serch_Emp_salary_disbursement_Click(object sender, EventArgs e)
        {
            dgv_view_Emps_Emp_salary_disbursement.Rows.Clear();
            
            int count = 0;
            int[] y;
            if (Convert.ToInt32(comboBox_Emp_salary_disbursement.SelectedValue) != 0)
            {
                count = 1;
                y = new int[count];
                y[0] = Convert.ToInt32(comboBox_Emp_salary_disbursement.SelectedValue);
            }
            else
            {
                count = dtable.Rows.Count - 1;
                y = new int[count];
                for (int i = 0; i < dtable.Rows.Count; i++)
                {
                    if (Convert.ToInt32(dtable.Rows[i][0]) != 0)
                    {

                        y[i - 1] = Convert.ToInt32(dtable.Rows[i][0]);
                    }

                }
            }
            add_row_dgv(y);
        }

        public void add_row_dgv(int[] y)
        {
            int year = dateTime_month_Emp_salary_disbursement.Value.Year;
            int month = dateTime_month_Emp_salary_disbursement.Value.Month;
            DateTime dateone = new DateTime(year, month, 1, 00, 00, 01);
            int x = DateTime.DaysInMonth(year, month);
            DateTime datetow = new DateTime(year, month, x, 23, 59, 59);

          

            for (int i = 0; i < y.Length; i++)
            {
                int code_Emps = 0;
                string name_Emps = "";
                double salary_static = 0;                         //متغير الراتب الاساسي
                double value_commission = 0;                       // متغير  قيمة العمولة
                double value_incentives_allowances = 0;             //// متغير  قيمة الحوافز والبدالات
                double value_Employee_discount = 0;                 // متغير  قيمة الخصم على الموظف
                double value_Day_absences_TB_salary = 0;            // متغير  قيمة اليوم الفياب للموظف
                double value_all_absences_in_month_and_discount = 0;   // متغير قيمة الغياب الكلي ناقص الخصم تبع الموظف
                double value_net_salary_Emps = 0;                       // مغير قيمة الراتب الصافي 


                //جدول  معلومات الموظف
                DataRow dr_Emps = DB_Add_delete_update_.Database.ds.Tables["TB_Employees"].Rows.Find(Convert.ToInt32(y[i]));
                if (dr_Emps !=null)
                {
                    code_Emps = Convert.ToInt32( dr_Emps[0]);
                    name_Emps = dr_Emps[1].ToString();

                }
                //جدول ترحيل رواتب موظف
                //int auto_num_TB_Employee_salary_disbursement = new classs_table.Items_Tools().AoutoNumber("TB_Employee_salary_disbursement", "code");
                //if (auto_num_TB_Employee_salary_disbursement == 1)
                //{

                //}
                //else
                //{

                //}
                DataRow[] dr_salary_disbursement= DB_Add_delete_update_.Database.ds.Tables["TB_Employee_salary_disbursement"].Select("id_Emp ='" + Convert.ToInt32(y[i]) + "'" + " And   month ='" + dateone.ToString("yyyy-MM") + "'");
                if ( dr_salary_disbursement.Count() == 0 )
                {
                    //جدول  معلومات رواتب الموظفين
                    DataRow[] dr_sys_salary= DB_Add_delete_update_.Database.ds.Tables["TB_sys_salary"].Select("id_EMP ="+ Convert.ToInt32(y[i]) );
                    if (dr_sys_salary.Count() != 0)
                    {
                        salary_static = Convert.ToDouble(dr_sys_salary[0][1]);
                        value_Day_absences_TB_salary = Convert.ToDouble(dr_sys_salary[0][3]);

                    }
                    //جدول عمولات مناديب البيع
                    DataRow[] dr_value_commission= DB_Add_delete_update_.Database.ds.Tables["TB_Sales_representative_commission_calculation"].Select("id_Emp ='" + Convert.ToInt32(y[i]) + "'" + " And   month ='" + dateone.ToString("yyyy-MM") + "'");
                    if (dr_value_commission.Count() != 0)
                    {
                        value_commission = Convert.ToDouble(dr_value_commission[0][10]);

                    }
                    //جدول الحوافز والبدالات
                    DataRow[] dr_incentives_allowances = DB_Add_delete_update_.Database.ds.Tables["TB_incentives_allowances"].Select("id_Emp ='" + Convert.ToInt32(y[i]) + "'" + " And   month ='" + dateone.ToString("yyyy-MM") + "'");
                    if (dr_incentives_allowances.Count() != 0)
                    {
                        for (int j = 0; j < dr_incentives_allowances.Count(); j++)
                        {
                            value_incentives_allowances += Convert.ToDouble(dr_incentives_allowances[j][3]);
                        }

                    }
                    //جدول خصوم على الموظف مثل عقوبات 
                    DataRow[] dr_Employee_discount = DB_Add_delete_update_.Database.ds.Tables["TB_Employee_discount"].Select("id_Emp ='" + Convert.ToInt32(y[i]) + "'" + " And   month ='" + dateone.ToString("yyyy-MM") + "'");
                    if (dr_Employee_discount.Count() != 0)
                    {
                        for (int j = 0; j < dr_Employee_discount.Count(); j++)
                        {
                            value_Employee_discount += Convert.ToDouble(dr_Employee_discount[j][3]);
                        }

                    }
                    //جدول الغياب والاجازات
                DataRow[] dr_absences_vacations = DB_Add_delete_update_.Database.ds.Tables["TB_absences_vacations"].Select("id_Emp ='" + Convert.ToInt32(y[i]) + "'" + " And   date_month ='" + dateone.ToString("yyyy-MM") + "'" + " And   type_process ='" + 1 + "'");
                    if (dr_absences_vacations.Count() != 0)
                    {
                        double sum_absences_discount_in_month = 0;
                        //جدول  خصوم الغياب 
                        DataRow[] dr_absences_discount_in_month = DB_Add_delete_update_.Database.ds.Tables["TB_Absence_discount"].Select("id_Emp ='" + Convert.ToInt32(y[i]) + "'" + " And   month ='" + dateone.ToString("yyyy-MM") + "'");

                        if (dr_absences_discount_in_month.Count() !=0)
                        {
                            for (int j = 0; j < dr_absences_discount_in_month.Count(); j++)
                            {
                                //جمع الخصومات  الغياب المضافة للموظف الشهر نفسة
                                sum_absences_discount_in_month += Convert.ToDouble(dr_absences_discount_in_month[j][3]);

                            }

                        }
                        // يتم ضرب عدد ايام الغياب في الشهر الحالي  في فيمة يوم الغياب
                        double value_all_day_absences_no_discount = dr_absences_vacations.Count() * value_Day_absences_TB_salary;

                        //يتم هنا نقص من قيمة ايام الغياب كلها الخصومات  المضافة  للموظف
                        value_all_absences_in_month_and_discount = value_all_day_absences_no_discount - sum_absences_discount_in_month; 
                    }
                     //( الراتب + عمولة البيع + الحوافز ) ناقص ( الخصومات العقوبات + كل الغياب نافص الخص المضاف للموظف) == الصافي للراتب
                    value_net_salary_Emps = (salary_static + value_commission + value_incentives_allowances) - ( value_Employee_discount +  value_all_absences_in_month_and_discount );
                    dgv_view_Emps_Emp_salary_disbursement.Rows.Add(false, code_Emps, name_Emps , salary_static , value_commission , value_incentives_allowances , value_Employee_discount , value_all_absences_in_month_and_discount , value_net_salary_Emps );

                }

            }

        }

    }
}
