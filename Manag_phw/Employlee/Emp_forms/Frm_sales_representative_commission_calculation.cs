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
    public partial class Frm_sales_representative_commission_calculation : Form
    {
        public Frm_sales_representative_commission_calculation()
        {
            InitializeComponent();
        }

        private void Btn_deportaion_Emp_Click(object sender, EventArgs e)
        {
            //dgv_view_Emps_sales_representative_comm_calc.Rows.Add(false ,comboBox_sales_representative_comm_calc.SelectedValue,comboBox_sales_representative_comm_calc.Text, "", "", "", "", "", "");

            var n = Application.OpenForms["Main"] as Main ;
            if (dgv_view_Emps_sales_representative_comm_calc.Rows.Count !=0 )
            {
                DateTime date_new = DateTime.Now;
                for (int i = 0; i < dgv_view_Emps_sales_representative_comm_calc.Rows.Count; i++)
                {
                    DateTime date_time = DateTime.Now;
                    DateTime date_start_month = new DateTime(date_time.Year, date_time.Month, 1);

                    string type_sell = "";
                    int code_Emp = 0;
                    int count_invoices = 0;
                    int count_items = 0;
                    double value_sell = 0;
                    double value_commission = 0;
                    double value_commission_end = 0;
                    
                    if (dgv_view_Emps_sales_representative_comm_calc.Rows[i] != null)
                    {
                        code_Emp= Convert.ToInt32( dgv_view_Emps_sales_representative_comm_calc.Rows[i].Cells[1].Value);
                        type_sell = dgv_view_Emps_sales_representative_comm_calc.Rows[i].Cells[3].Value.ToString();
                        count_invoices = Convert.ToInt32( dgv_view_Emps_sales_representative_comm_calc.Rows[i].Cells[4].Value);
                        count_items = Convert.ToInt32( dgv_view_Emps_sales_representative_comm_calc.Rows[i].Cells[5].Value);
                        value_sell = Convert.ToDouble( dgv_view_Emps_sales_representative_comm_calc.Rows[i].Cells[6].Value);
                        value_commission = Convert.ToDouble( dgv_view_Emps_sales_representative_comm_calc.Rows[i].Cells[7].Value);
                        value_commission_end = Convert.ToDouble( dgv_view_Emps_sales_representative_comm_calc.Rows[i].Cells[8].Value);


                        if (Convert.ToBoolean( dgv_view_Emps_sales_representative_comm_calc.Rows[i].Cells[0].Value) != false)
                        {
                            int new_commission = new classs_table.Items_Tools().AoutoNumber("TB_Sales_representative_commission_calculation", "code");

                            DB_Add_delete_update_.Database.ds.Tables["TB_Sales_representative_commission_calculation"].Rows.Add(new_commission,     // رقم العملية
                                                                                                                                date_time.ToString("yyyy-MM"),  //تاريخ في السنه والشهر فقط
                                                                                                                                code_Emp ,                       // كود الموظف
                                                                                                                                date_start_month.ToString("yyyy-MM-dd") , // التاريخ اليوم بداية الشهر 
                                                                                                                                date_time.ToString("yyyy-MM-dd"),        //التاريخ  اليوم الحالي
                                                                                                                                type_sell,                               // نوع البيع تجزئة  
                                                                                                                                count_invoices,                           // عدد الفواتير
                                                                                                                                count_items,                              // عدد الاصناف
                                                                                                                                value_sell,                                // قيمة  المبيعات
                                                                                                                                value_commission,                           //قيمة عمولة التجزئة
                                                                                                                                value_commission_end,                       // قيمة العمولة  النهائي
                                                                                                                                date_new.ToString("yyyy-MM-dd HH:mm"),        // التاريخ الحالي في الساعة    
                                                                                                                                n.txt_Empoly_number.Caption                    // رقم المستخدم
                                                                                                                                );
                            DB_Add_delete_update_.Database.update("TB_Sales_representative_commission_calculation");
                            
                            dgv_view_Emps_sales_representative_comm_calc.Rows.RemoveAt(dgv_view_Emps_sales_representative_comm_calc.Rows[i].Index);
                        } 
                    }

                }
                            MessageBox.Show("تم ترحيل حوافز البيع بنجاح");

            }
        }


        
        private void Frm_sales_representative_commission_calculation_Load(object sender, EventArgs e)
        {
            lode_combobox_Emp();


        }
            DataTable dtable = new DataTable("TB_Employees");

        public void lode_combobox_Emp() {

            dtable.Columns.Add("Code_Emp", typeof(int));
            dtable.Columns.Add("Name_Emp_A", typeof(string));
            dtable.Rows.Add( 0 , "الكل" );
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

                
                comboBox_sales_representative_comm_calc.DataSource =  dtable;
               
                comboBox_sales_representative_comm_calc.DisplayMember = "Name_Emp_A";
                comboBox_sales_representative_comm_calc.ValueMember = "Code_Emp";

            }
        }

        private void Btn_serch_sales_representative_comm_calc_Click(object sender, EventArgs e)
        {

            dgv_view_Emps_sales_representative_comm_calc.Rows.Clear();
            //MessageBox.Show("  "+ dateone +" to "+ datetow);
            //MessageBox.Show("  "+DateTime.Now);
            //string query = "(Date_Foot_sals >='" + vr.dtp_Sales_Employ_One.Value + "' And Date_Foot_sals <='" + vr.dtp_Sales_Employ_Tow.Value + "')";

            //MessageBox.Show(" SelectedText =  " + comboBox_sales_representative_comm_calc.Text);
            //MessageBox.Show("SelectedValue =  " + comboBox_sales_representative_comm_calc.SelectedValue);
            //MessageBox.Show("SelectedIndex =  " + comboBox_sales_representative_comm_calc.SelectedIndex.ToString());
            //MessageBox.Show("ValueMember=  " + comboBox_sales_representative_comm_calc.ValueMember.ToString());
            //MessageBox.Show("  "+ comboBox_sales_representative_comm_calc.);
            int count = 0;
            int[] y;
            if (Convert.ToInt32(comboBox_sales_representative_comm_calc.SelectedValue) != 0)
            {
                count = 1;
                y = new int[count];
                y[0] = Convert.ToInt32( comboBox_sales_representative_comm_calc.SelectedValue);
            }
            else
            {
                count = dtable.Rows.Count -1 ;
                y = new int[count];
                for (int i = 0; i < dtable.Rows.Count  ; i++)
                {
                    if (Convert.ToInt32( dtable.Rows[i][0] )!=0 )
                    {

                        y[i-1] = Convert.ToInt32(dtable.Rows[i][0]);
                    }

                }
            }
            add_row_dgv(y);


        }
        public void add_row_dgv(int[] y )
        {

            int year = dateTime_month_sales_representative_comm_calc.Value.Year;
            int month = dateTime_month_sales_representative_comm_calc.Value.Month;
            DateTime dateone = new DateTime(year, month, 1 , 00 , 00 , 01 );
            int x = DateTime.DaysInMonth(year, month);
            DateTime datetow = new DateTime(year, month, x , 23 , 59 , 59 );

            DateTime date_mon_olde = new DateTime();

            for (int i = 0; i < y.Length; i++)
            {
              
                DataRow[] dr_commission = DB_Add_delete_update_.Database.ds.Tables["TB_Sales_representative_commission_calculation"].Select("id_Emp ='" + Convert.ToInt32(y[i]) + "'" + " And   month ='" + dateone.ToString("yyyy-MM") + "'");
                if (dr_commission.Count() == 0)
                {
                    int month_olde1 = 0;
                    int year_olde = 0;
                    DateTime month_olde2 = dateone;
                    if (month != 1 )// اذا كان الشهر ليش شهر واحد اذا نقص الشهر الحالي واحد
                    {
                     month_olde1 = month - 1;

                     month_olde2 = new DateTime( year , month_olde1 , 1  ); //  لتحقق من وجود مبيعات لم يحسبها من الشهر السابق

                    }
                    else if (month == 1 )//شرط اذا كان الشهر الحالي شهر واحد اذا الشهر السابق السنه السابقة شهر 12
                    {
                        month_olde1 = 12;
                        year_olde = year - 1;
                        month_olde2 = new DateTime( year_olde , month_olde1 , 1); //  لتحقق من وجود مبيعات لم يحسبها من الشهر السابق



                    }
                    DataRow[] dr_commission_olde = DB_Add_delete_update_.Database.ds.Tables["TB_Sales_representative_commission_calculation"].Select("id_Emp ='" + Convert.ToInt32(y[i]) + "'" + " And   month ='" + month_olde2.ToString("yyyy-MM") + "'");
                    if (dr_commission_olde.Count() != 0)
                    {

                        //date_mon_olde = Convert.ToDateTime(dr_commission_olde[0][4]);
                        string dateee = dr_commission_olde[0][4].ToString();
                        string dateee2 = Convert.ToDateTime(dateee + " 00:00").ToString("yyyy-MM-dd HH:mm");

                        dateone = Convert.ToDateTime(dateee2);
                    }
                    else
                    {
                        dateone = new DateTime(year, month, 1, 00, 00, 01);

                    }
                    DataRow[] dr_footer_sals = DB_Add_delete_update_.Database.ds.Tables["Date_Footer_Sals"].Select("num_emp ='" + Convert.ToInt32(y[i]) + "'" + " And   Date_Foot_sals >='" + dateone + "' And Date_Foot_sals <='" + datetow + "'");
                    DataRow dr_Emp = DB_Add_delete_update_.Database.ds.Tables["TB_Employees"].Rows.Find(Convert.ToInt32(y[i]));


                    if (dr_footer_sals.Count() != 0)
                    {
                        int count_items = 0;
                        double values_after = 0;
                        double discount_value_retail = 0;
                        string Name_Emp = dr_Emp[1].ToString();

                        if (dr_Emp != null)
                        {
                            discount_value_retail = Convert.ToDouble(dr_Emp[17]);
                        }
                        for (int j = 0; j < dr_footer_sals.Count(); j++)
                        {
                            count_items += Convert.ToInt32(dr_footer_sals[j][9]);
                            values_after += Convert.ToDouble(dr_footer_sals[j][6]);
                        }

                        dgv_view_Emps_sales_representative_comm_calc.Rows.Add(false, dr_footer_sals[0][8], Name_Emp, "تجزئة", dr_footer_sals.Count(), count_items, values_after, discount_value_retail, values_after * discount_value_retail);

                    }
                    else
                    {
                        if (y.Length == 1)
                        {

                            MessageBox.Show("( لا يوجد مبيعات للموظف " + dr_Emp[1].ToString() + ")" + " في شهر  " + new DateTime(year,month,1).ToString(" MM-yyyy "));

                        }
                    }


                }
                else
                {
                  

                }
             
            }

        }

        private void Dgv_view_Emps_sales_representative_comm_calc_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (dgv_view_Emps_sales_representative_comm_calc.CurrentCell.ColumnIndex == 7 )
            {

                double value_sell = 0;
                double value_commission = 0;
                double value_end = 0;

                if (dgv_view_Emps_sales_representative_comm_calc.CurrentRow != null)
                {
                    if (Convert.ToDouble(dgv_view_Emps_sales_representative_comm_calc.CurrentRow.Cells[6].Value) != 0)
                    {
                        value_sell = Convert.ToDouble(dgv_view_Emps_sales_representative_comm_calc.CurrentRow.Cells[6].Value);

                    }

                }
                if ( Convert.ToDouble(dgv_view_Emps_sales_representative_comm_calc.CurrentRow.Cells[7].Value) != 0 )
                {
                     
                        value_commission = Convert.ToDouble(dgv_view_Emps_sales_representative_comm_calc.CurrentRow.Cells[7].Value);
                }

                value_end = value_sell * value_commission;

                if (dgv_view_Emps_sales_representative_comm_calc.CurrentRow.Cells[8].Value != null)
                {
                    dgv_view_Emps_sales_representative_comm_calc.CurrentRow.Cells[8].Value = DBNull.Value;

                }

                  dgv_view_Emps_sales_representative_comm_calc.CurrentRow.Cells[8].Value = value_end;
                MessageBox.Show(" ="+ dgv_view_Emps_sales_representative_comm_calc.CurrentRow.Cells[8].Value);
            }
        }
    }
}
