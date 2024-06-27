using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Manag_ph.Sales.Report
{
    class RP_unlock_Casher
    {
        public void get_Emp_use_Program()
        {
            var vr = Application.OpenForms["Main"] as Main;
            DataTable dt = new DataTable();
            dt.Columns.Add("id_Emp");
            dt.Columns.Add("Name");
            dt.Rows.Add(0, "الكل");

            DataRow[] dr_emp = DB_Add_delete_update_.Database.ds.Tables["TB_Employees"].Select("use_program");
            if (dr_emp.Count() != 0)
            {
                for (int i = 0; i < dr_emp.Count(); i++)
                {
                    dt.Rows.Add(dr_emp[i][0], dr_emp[i][1]);
                }
                vr.com_unlock_Emp.DataSource = dt;
                vr.com_unlock_Emp.DisplayMember = "Name";
                vr.com_unlock_Emp.ValueMember = "id_Emp";

            }



        }

        public void Search_unlock_Casher_Emp()
        {
            var vr = Application.OpenForms["Main"] as Main;
            vr.dgv_Report_unlock_dgv.Rows.Clear();
            String Query = "isLoock=" + true + " And (Date_lock_Casher > '" + vr.dtp_RP_unlock_one.Value + "' And Date_lock_Casher < '" + vr.dtp_RP_unlock_tow.Value + "')";
            if (Convert.ToInt32(vr.com_unlock_Emp.SelectedValue) != 0)
            {
                DataRow[] dr_Log_in = DB_Add_delete_update_.Database.ds.Tables["TB_LOGIN_EMP"].Select("id_EMP =" + vr.com_unlock_Emp.SelectedValue);
                if (dr_Log_in.Count() != 0)
                {
                    Query += " And id_login =" + dr_Log_in[0][0] + " And UserName='" + dr_Log_in[0][1]+"'";
                }

            }

            DataRow[] dr_unlock = DB_Add_delete_update_.Database.ds.Tables["Unlook_Box"].Select(Query);
            if (dr_unlock.Count() != 0)
            {
                for (int i = 0; i < dr_unlock.Count(); i++)
                {
                    object[] od_Cashe = DB_Add_delete_update_.Database.ds.Tables["casher"].Rows.Find(dr_unlock[i][5]).ItemArray;
                    object[] od_LogIn_get_Emp = DB_Add_delete_update_.Database.ds.Tables["TB_LOGIN_EMP"].Rows.Find(new object[] { dr_unlock[i][2], dr_unlock[i][3] }).ItemArray;
                    object[] od_Emp = DB_Add_delete_update_.Database.ds.Tables["TB_Employees"].Rows.Find(od_LogIn_get_Emp[4]).ItemArray;
                    object[] fund = DB_Add_delete_update_.Database.ds.Tables["account_fund"].Rows.Find(dr_unlock[i][8]).ItemArray;

                    DataRow[] od_new_user = DB_Add_delete_update_.Database.ds.Tables["TB_LOGIN_EMP"].Select("id_login=" + dr_unlock[i][10]);
                    object[] od_new_Emp = DB_Add_delete_update_.Database.ds.Tables["TB_Employees"].Rows.Find(od_new_user[0][4]).ItemArray;
                    vr.dgv_Report_unlock_dgv.Rows.Add(
                        dr_unlock[i][0],// رقم الاقفال
                        od_Cashe[1],// اسم الكاشي
                         dr_unlock[i][1],// تاريخ بداية الفترة
                         dr_unlock[i][14],// تاريخ الاقفال
                         dr_unlock[i][3],// المستخدم
                         od_Emp[1],//  الموظف
                         Convert.ToDouble(dr_unlock[i][4]).ToString("N2"),// القيمة الافتتاحية
                         Convert.ToDouble(dr_unlock[i][6]).ToString("N2"),// قيمة التسليم
                         Convert.ToDouble(dr_unlock[i][7]).ToString("N2"),//المبلغ المحول الا الصندوق
                         Convert.ToDouble(dr_unlock[i][9]).ToString("N2"),//الباقي في الصندوق
                        fund[1],// اسم الصندوق المحول لة
                        Convert.ToDouble(dr_unlock[i][11]).ToString("N2"),// الرصيد الفعلي
                        Convert.ToDouble(Convert.ToDouble(dr_unlock[i][6]) -Convert.ToDouble(dr_unlock[i][11])).ToString("N2"),// زيادة او عجز
                        dr_unlock[i][12],// ملاحظة
                        od_new_Emp[1]//  الموظف المستلم
                                     );
                }

            }


        }


        public void Report_unlock_Cahser()
        {
            var vr = Application.OpenForms["Main"] as Main;

            DataTable dt = new classs_table.Items_Tools().Fill_DataTable_Columns("dt_RP_unlock_Casher", new string[] {
                "num_unlock",
                "name_Cahser",
                "Date_unlock",
                "Name_Emp",
                "Value_open",
                "Value_Casher",
                "value_send_Box",
                "name_Box",
                "Recoierd_Value",
                "Increase or decrease",
                "num_user_Recipient",
                "reast_casher",
            });

            if (vr.dgv_Report_unlock_dgv.Rows.Count != 0)
            {
                File_RP_unlock_Casher RP = new File_RP_unlock_Casher();
                for (int i = 0; i < vr.dgv_Report_unlock_dgv.Rows.Count; i++)
                {
                    dt.Rows.Add(
                        vr.dgv_Report_unlock_dgv.Rows[i].Cells[0].Value,//الكود
                        vr.dgv_Report_unlock_dgv.Rows[i].Cells[1].Value,// اسم الكاشير
                        vr.dgv_Report_unlock_dgv.Rows[i].Cells[3].Value,// تاريخ الاقفال
                        vr.dgv_Report_unlock_dgv.Rows[i].Cells[5].Value,//اسم  الموظف
                      Convert.ToDouble(  vr.dgv_Report_unlock_dgv.Rows[i].Cells[6].Value),//القيمة الافتتاحية
                        Convert.ToDouble(vr.dgv_Report_unlock_dgv.Rows[i].Cells[7].Value),//قيمة التسليم
                        Convert.ToDouble(vr.dgv_Report_unlock_dgv.Rows[i].Cells[8].Value),//القيمة المحولة

                        vr.dgv_Report_unlock_dgv.Rows[i].Cells[10].Value,//اسم الصندوق
                         Convert.ToDouble(vr.dgv_Report_unlock_dgv.Rows[i].Cells[11].Value),//القيمة المطلوبة
                         Convert.ToDouble(vr.dgv_Report_unlock_dgv.Rows[i].Cells[12].Value),//الزيادة الو النقصان
                        vr.dgv_Report_unlock_dgv.Rows[i].Cells[14].Value,//المستلم
                        Convert.ToDouble(vr.dgv_Report_unlock_dgv.Rows[i].Cells[9].Value)//الباقي في الدرج
                        );
                }
                new classs_table.Items_Tools().show_Dev_ReportView(dt, RP);
            }
          
        }
    }
}
