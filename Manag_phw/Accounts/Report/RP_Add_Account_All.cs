using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Manag_ph.Accounts.Report
{
    class RP_Add_Account_All
    {

        void Fill_EMP()
        {
            var vr = Application.OpenForms["Main"] as Main;
            DataTable dt = new DataTable();

            dt.Columns.Add("num_EMP");
            dt.Columns.Add("name_EMP");
            dt.Rows.Add("0", "الكل");
            DataRow[] dt_EMp = DB_Add_delete_update_.Database.ds.Tables["TB_Employees"].Select("use_program =" + true);
            for (int i = 0; i < dt_EMp.Count(); i++)
            {
                dt.Rows.Add(dt_EMp[i][0], dt_EMp[i][1]);
            }
            vr.cm_EMP_Account_Add.DataSource = dt;
            vr.cm_EMP_Account_Add.DisplayMember = "name_EMP";
            vr.cm_EMP_Account_Add.ValueMember = "num_EMP";

        }

        void Fill_Reasp()
        {
            var vr = Application.OpenForms["Main"] as Main;
            DataTable dt = new DataTable();

            dt.Columns.Add("num_Reas", typeof(int));
            dt.Columns.Add("name_Reas");
            dt.Rows.Add(0, "الكل");
            dt.Rows.Add(1, "المورد");
            dt.Rows.Add(2, "المؤسسة");
            dt.Rows.Add(3, "عميل");

            vr.cm_Res_Account_Add.DataSource = dt;
            vr.cm_Res_Account_Add.DisplayMember = "name_Reas";
            vr.cm_Res_Account_Add.ValueMember = "num_Reas";
        }





        public void Fill_All_Data()
        {
            Fill_EMP();
            Fill_Reasp();

        }



        public void SearchData()
        {

            var vr = Application.OpenForms["Main"] as Main;
            vr.dgv_Report_Account_Add.Rows.Clear();
            String query = "(Date_Disco>'" + vr.dtp_One_Search_Acc_Add.Value + "' And Date_Disco<'" + vr.dtp_Tow_Search_Acc_Add.Value + "')";

            if (Convert.ToInt32(vr.cm_EMP_Account_Add.SelectedValue) != 0)
            {
                //DataRow[] dr_EMp = DB_Add_delete_update_.Database.ds.Tables["TB_LOGIN_EMP"].Select("id_EMP=" + Convert.ToInt32(vr.cm_EMP_Account_Add.SelectedValue));
                DataRow dr_EMp = DB_Add_delete_update_.Database.ds.Tables["TB_Employees"].Rows.Find( vr.cm_EMP_Account_Add.SelectedValue);
                if (dr_EMp != null)
                {
                    query += " And Emp_num = '" + dr_EMp[0] + "'";
                }
            }

            if (Convert.ToInt32(vr.cm_Res_Account_Add.SelectedValue) != 0)
            {

                if (Convert.ToInt32(vr.cm_Res_Account_Add.SelectedValue) == 1)
                {
                    query += " And type ='" + "مورد" + "'";
                    vr.dgv_Report_Account_Add.Columns[3].HeaderText = "كود المورد";
                    vr.dgv_Report_Account_Add.Columns[4].HeaderText = "اسم المورد";
                }
                else if (Convert.ToInt32(vr.cm_Res_Account_Add.SelectedValue) == 2)
                {
                    query += " And type ='" + "المؤسسة" + "'";
                }
                else if (Convert.ToInt32(vr.cm_Res_Account_Add.SelectedValue) == 3)
                {
                    query += " And type ='" + "عميل" + "'";
                    vr.dgv_Report_Account_Add.Columns[3].HeaderText = "كود العميل";
                    vr.dgv_Report_Account_Add.Columns[4].HeaderText = "اسم العميل";
                }
            }
            else
            {
                vr.dgv_Report_Account_Add.Columns[3].HeaderText = "الكود ";
                vr.dgv_Report_Account_Add.Columns[4].HeaderText = "الاسم";
            }



            DataRow[] dr_Data = DB_Add_delete_update_.Database.ds.Tables["Report_Account_Add"].Select(query);

            if (dr_Data.Count() != 0)
            {

                for (int i = 0; i < dr_Data.Count(); i++)
                {
                    object[] ob_fund = null;
                    if (Convert.ToInt32(vr.cm_Res_Account_Add.SelectedValue) == 2 || dr_Data[i][2].ToString() == "المؤسسة")
                    {
                        if (Convert.ToInt32(dr_Data[i][3]) == 1)
                        {
                            ob_fund = DB_Add_delete_update_.Database.ds.Tables["account_fund"].Rows.Find(dr_Data[i][4]).ItemArray;
                        }
                        else if (Convert.ToInt32(dr_Data[i][3]) == 2)
                        {
                            ob_fund = DB_Add_delete_update_.Database.ds.Tables["casher"].Rows.Find(dr_Data[i][4]).ItemArray;
                        }
                    }
                    else if (Convert.ToInt32(vr.cm_Res_Account_Add.SelectedValue) == 1 || dr_Data[i][2].ToString() == "مورد")
                    {
                        ob_fund = DB_Add_delete_update_.Database.ds.Tables["Supplier"].Rows.Find(dr_Data[i][4]).ItemArray;
                    }
                    else if (Convert.ToInt32(vr.cm_Res_Account_Add.SelectedValue) == 3 || dr_Data[i][2].ToString() == "عميل")
                    {
                        ob_fund = DB_Add_delete_update_.Database.ds.Tables["Clien"].Rows.Find(dr_Data[i][4]).ItemArray;
                    }

                    object[] ob_reas = DB_Add_delete_update_.Database.ds.Tables["Reasons_disco_Add"].Rows.Find(dr_Data[i][8]).ItemArray;
                    object[] dr_EMp_Data = DB_Add_delete_update_.Database.ds.Tables["TB_Employees"].Rows.Find(dr_Data[i][10]).ItemArray;
                    vr.dgv_Report_Account_Add.Rows.Add(
                        dr_Data[i][0],//رقم السجل
                        dr_Data[i][2],//مخصوم من
                        dr_Data[i][1],// تاريخ الخصم
                        ob_fund[0],// الكود
                        ob_fund[1],//الاسم
                        dr_Data[i][5],// الرصيد قبل
                        dr_Data[i][6],// قيمة الخسم
                        dr_Data[i][7],// الرصيد بعد
                        ob_reas[1],
                        dr_Data[i][9],
                        dr_EMp_Data[1]);
                }

            }
        }

    }
}
