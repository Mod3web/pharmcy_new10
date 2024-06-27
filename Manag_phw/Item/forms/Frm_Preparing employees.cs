using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Manag_ph.Item.forms
{
    public partial class Frm_Preparing_employees : Form
    {
        public Frm_Preparing_employees()
        {
            InitializeComponent();
        }

        private void Dgv_Preparing_Emps_dgv_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F12)
            {
                dgv_Preparing_Emps_dgv.Rows.Add();
            }
        }

        private void Dgv_Preparing_Emps_dgv_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            //if (dgv_Preparing_Emps_dgv.CurrentCell.ColumnIndex == 0 )
            //{

            //    if (e.Control is TextBox && e.Control != null)
            //    {
            //        e.Control.KeyPress += delegate (object Mysend, KeyPressEventArgs Mye)
            //        {
            //            if (!(char.IsDigit(Mye.KeyChar)) && Mye.KeyChar != (Char)Keys.Back)
            //            {
            //                Mye.Handled = true;
            //            }


            //        };
            //    }
            //}
        }

        private void Dgv_Preparing_Emps_dgv_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            //if (dgv_Preparing_Emps_dgv.CurrentCell.ColumnIndex == 0)
            //{

            //        DataRow[] dr = DB_Add_delete_update_.Database.ds.Tables["TB_Employees"].Select("id_EMP = " + Convert.ToInt32(dgv_Preparing_Emps_dgv.CurrentRow.Cells[0].Value));

            //        if (dr.Count() != 0)
            //        {


            //        }
            //        else
            //        {
            //            MessageBox.Show("لايوجد موظف بهذا الرقم");
            //        }


            //}
        }

        private void Dgv_Preparing_Emps_dgv_KeyDown_1(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F12)
            {
                int Countrows = dgv_Preparing_Emps_dgv.Rows.Count;
                if (Countrows !=0)
                {
                    for (int i = 0; i < Countrows; i++)
                    {
                            int x=0;
                        for (int j = 0; j < dgv_Preparing_Emps_dgv.ColumnCount; j++)
                        {
                        if (dgv_Preparing_Emps_dgv.Rows[i].Cells[j].Value == null  )
                          {
                                x += 1;
                          }
                        }
                            if (x==3)
                            {
                            dgv_Preparing_Emps_dgv.Rows.RemoveAt(dgv_Preparing_Emps_dgv.Rows[i].Index);
                            }
                    }

                } 
                dgv_Preparing_Emps_dgv.Rows.Add();
            }

        }

        private void Dgv_Preparing_Emps_dgv_EditingControlShowing_1(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            if (dgv_Preparing_Emps_dgv.CurrentCell.ColumnIndex == 0)
            {

                if (e.Control is TextBox && e.Control != null)
                {
                    e.Control.KeyPress += delegate (object Mysend, KeyPressEventArgs Mye)
                    {
                        if (!(char.IsDigit(Mye.KeyChar)) && Mye.KeyChar != (Char)Keys.Back)
                        {
                            Mye.Handled = true;
                        }


                    };
                }
            }
        }

        private void Dgv_Preparing_Emps_dgv_CellEndEdit_1(object sender, DataGridViewCellEventArgs e)
        {
            if (dgv_Preparing_Emps_dgv.CurrentCell.ColumnIndex == 0)
            {
              
                

                DataRow[] dr = DB_Add_delete_update_.Database.ds.Tables["TB_Employees"].Select("id_EMP = " + Convert.ToInt32(dgv_Preparing_Emps_dgv.CurrentRow.Cells[0].Value));

                if (dr.Count() != 0)
                {
                    //string x = DateTime.Now.ToShortDateString();
                    //DateTime ti = Convert.ToDateTime(x);
                    //MessageBox.Show("== " + x);
                   // MessageBox.Show(" == "+DateTime.Now.ToString("d"));

                    //  DataRow[] drr = DB_Add_delete_update_.Database.ds.Tables["Table_Main_Emp_ALL"].Select("datenow ='" + DateTime.Now.ToString("")+"'"); 

                    DataTable drs1 = DB_Add_delete_update_.Database.ds.Tables["Table_Main_Emp_ALL"];
                    DataRow [] dr5 = DB_Add_delete_update_.Database.ds.Tables["Table_Main_Emp_ALL"].Select("num_Emp ='" + dgv_Preparing_Emps_dgv.CurrentRow.Cells[0].Value+"'"+ " And datenow ='" + DateTime.Now.ToString("d") + "'"); ;
                    //MessageBox.Show("=============  "+dr5[0][1]+"==="+dr5[0][2]);
                   // DataView cc = new DataView(drs1);
                   // cc.RowFilter = "[datenow] like '%" + DateTime.Now.ToString("d") + "%'";

                   //drs1= new classs_table.Items_Tools().Fill_DataTable_Columns("Table_Main_Emp_ALL" , new string[] {
                   //          "id",
                   //          "num_Emp" ,
                   //         "datenow"  ,
                   //          "type_story" ,
                   //         "Date_star",
                   //         "Date_end",
                   //         "Count_Hours"
                   //                       }   );

                    //if (dr5.Count() !=0)
                    //{
                    //    //for (int i = 0; i < dr5.Count(); i++)
                    //    //{
                            
                    //    //}
                        

                    //}
                    // DataView c2 = new DataView(drs1);
                    //if (c2.Count !=0)
                    //{

                    //    if (true)
                    //    {

                    //    } 

                    //}
                    //DataRow[] dr33 =null;
                    //if (drs1.Rows.Count != 0)
                    //{
                    //     //dr33 = drs1.Select("num_Emp =" + dgv_Preparing_Emps_dgv.CurrentRow.Cells[0].Value);

                    //}
                    
                    if (dr5.Count()!=0)
                    {

                        MessageBox.Show("الموظف تم تحضيرة سابقا");
                        dgv_Preparing_Emps_dgv.Rows.RemoveAt(dgv_Preparing_Emps_dgv.CurrentRow.Index);
                        dgv_Preparing_Emps_dgv.Rows.Add();
                        
                    }
                    else {

                    dgv_Preparing_Emps_dgv.CurrentRow.Cells[1].Value = dr[0][1].ToString();
                    dgv_Preparing_Emps_dgv.CurrentRow.Cells[2].Value = DateTime.Now.ToString();

                    }

                }
                else
                {
                    if (dgv_Preparing_Emps_dgv.CurrentRow != null)
                    {
                        dgv_Preparing_Emps_dgv.Rows.RemoveAt(dgv_Preparing_Emps_dgv.CurrentRow.Index);
                    }
                    MessageBox.Show("لايوجد موظف بهذا الرقم");
                }

                


            }
        }

        private void TabPane1_KeyDown(object sender, KeyEventArgs e)
        {
            //    Dgv_Preparing_Emps_dgv_KeyDown_1(sender,e);
            //    Dgv_Preparing_Emps_dgv_KeyDown(sender, e);
            //if (e.KeyCode == Keys.F12)
            //{
            //    dgv_Preparing_Emps_dgv.Rows.Add();
            //}
        }

        private void TabNavigationPage2_MouseUp(object sender, MouseEventArgs e)
        {
            
        }

        private void TabNavigationPage2_MouseDown(object sender, MouseEventArgs e)
        {
            
            //if (e.KeyCode == Keys.F12)
            //{
            //    dgv_Preparing_Emps_dgv.Rows.Add();
            //}
        }

        private void TabNavigationPage2_MouseClick(object sender, MouseEventArgs e)
        {

            //dgv_Preparing_Emps_dgv.Rows.Add();
            //Dgv_Preparing_Emps_dgv_MouseClick( sender,  e);
        }

        private void Dgv_Preparing_Emps_dgv_MouseClick(object sender, MouseEventArgs e)
        {

        }

        private void Btn_save_Preparing_Emps_btn_Click(object sender, EventArgs e)
        {
            //if (dgv_Preparing_Emps_dgv.Rows.Count != 0 )
            //{
            //    int id_Emp = 0;
            //    string name_Emp = "";
            //    DateTime date_stare;
            //    for (int i = 0; i < dgv_Preparing_Emps_dgv.Rows.Count; i++)
            //    {
            //        if (dgv_Preparing_Emps_dgv.Rows[i].Cells[0].Value != null)
            //        { 
            //        id_Emp = Convert.ToInt32(dgv_Preparing_Emps_dgv.Rows[i].Cells[0].Value);
            //        name_Emp = dgv_Preparing_Emps_dgv.Rows[i].Cells[1].Value.ToString();
            //        date_stare = Convert.ToDateTime(dgv_Preparing_Emps_dgv.Rows[i].Cells[2].Value);
            //        int id_now = new classs_table.Items_Tools().AoutoNumber("Table_Main_Emp_ALL", "id");
            //        DB_Add_delete_update_.Database.ds.Tables["Table_Main_Emp_ALL"].Rows.Add(id_now, id_Emp, date_stare.ToString("d"), 1, date_stare); //عندما يكون نوع العملية تحضير يكون رقم واحد
            //        DB_Add_delete_update_.Database.update("Table_Main_Emp_ALL");
            //    }
            //    }
            //        dgv_Preparing_Emps_dgv.Rows.Clear();
            //        dgv_Preparing_Emps_dgv.Focus();

            //}
        }

        private void Btn_save_Preparing_Emps_btn_Click_1(object sender, EventArgs e)
        {
            var n = Application.OpenForms["Main"] as Main;

            if (dgv_Preparing_Emps_dgv.Rows.Count != 0)
            {
               

                for (int i = 0; i < dgv_Preparing_Emps_dgv.Rows.Count; i++)
                {
                    int id_Emp = 0;
                    string name_Emp = "";
                    string date_stare;

                    string time_one_static = "";
                    string time_tow_static = "";

                    int Operation_type = 0;

                    if (dgv_Preparing_Emps_dgv.Rows[i].Cells[0].Value != null)
                    {
                        DataRow[] dr_obs = DB_Add_delete_update_.Database.ds.Tables["TB_Attendance_departure"].Select("id_Emp ='" + dgv_Preparing_Emps_dgv.Rows[i].Cells[0].Value + "'" + " And day_now ='" + DateTime.Now.ToString("yyyy-MM-dd") + "'");

                        if (dr_obs.Count() == 0)
                        {
                            DataRow[] dr_weekly = DB_Add_delete_update_.Database.ds.Tables["TB_Emplyee_days_weekly"].Select("id_Emp =" + dgv_Preparing_Emps_dgv.Rows[i].Cells[0].Value);

                            if (dr_weekly.Count() != 0)
                            {
                                if (DateTime.Now.DayOfWeek.ToString() == "Saturday")
                                {
                                    if (Convert.ToInt32(dr_weekly[0][2]) == 1)
                                    {
                                        Operation_type = 1;
                                        time_one_static = dr_weekly[0][3].ToString();
                                        time_tow_static = dr_weekly[0][4].ToString();
                                    }
                                    else
                                    {
                                        Operation_type = 0;

                                    }

                                }
                                else if (DateTime.Now.DayOfWeek.ToString() == "Sunday")
                                {
                                    if (Convert.ToInt32(dr_weekly[0][5]) == 1)
                                    {
                                        Operation_type = 1;
                                        time_one_static = dr_weekly[0][6].ToString();
                                        time_tow_static = dr_weekly[0][7].ToString();

                                    }
                                    else
                                    {
                                        Operation_type = 0;

                                    }

                                }

                                else if (DateTime.Now.DayOfWeek.ToString() == "Monday")
                                {
                                    if (Convert.ToInt32(dr_weekly[0][8]) == 1)
                                    {
                                        Operation_type = 1;
                                        time_one_static = dr_weekly[0][9].ToString();
                                        time_tow_static = dr_weekly[0][10].ToString();

                                    }
                                    else
                                    {
                                        Operation_type = 0;

                                    }

                                }

                                else if (DateTime.Now.DayOfWeek.ToString() == "Tuesday")
                                {
                                    if (Convert.ToInt32(dr_weekly[0][11]) == 1)
                                    {
                                        Operation_type = 1;
                                        time_one_static = dr_weekly[0][12].ToString();
                                        time_tow_static = dr_weekly[0][13].ToString();

                                    }
                                    else
                                    {
                                        Operation_type = 0;

                                    }

                                }

                                else if (DateTime.Now.DayOfWeek.ToString() == "Wednesday")
                                {
                                    if (Convert.ToInt32(dr_weekly[0][14]) == 1)
                                    {
                                        Operation_type = 1;
                                        time_one_static = dr_weekly[0][15].ToString();
                                        time_tow_static = dr_weekly[0][16].ToString();

                                    }
                                    else
                                    {
                                        Operation_type = 0;

                                    }

                                }
                                else if (DateTime.Now.DayOfWeek.ToString() == "Thursday")
                                {
                                    if (Convert.ToInt32(dr_weekly[0][17]) == 1)
                                    {
                                        Operation_type = 1;
                                        time_one_static = dr_weekly[0][18].ToString();
                                        time_tow_static = dr_weekly[0][19].ToString();

                                    }
                                    else
                                    {
                                        Operation_type = 0;

                                    }

                                }
                                else if (DateTime.Now.DayOfWeek.ToString() == "Friday")
                                {
                                    if (Convert.ToInt32(dr_weekly[0][20]) == 1)
                                    {
                                        Operation_type = 1;
                                        time_one_static = dr_weekly[0][21].ToString();
                                        time_tow_static = dr_weekly[0][22].ToString();

                                    }
                                    else
                                    {
                                        Operation_type = 0;

                                    }

                                }
                            }
                            if (Operation_type == 1)
                            {
                                id_Emp = Convert.ToInt32(dgv_Preparing_Emps_dgv.Rows[i].Cells[0].Value);
                                DateTime time_one = Convert.ToDateTime(time_one_static);//موعد الحضور الثابت
                                DateTime time_tow = Convert.ToDateTime(time_tow_static);//موعد الانصراف الثابت
                                DateTime abs_datetime_now = Convert.ToDateTime(dgv_Preparing_Emps_dgv.Rows[i].Cells[2].Value);//توقيت التحضير الحالي
                                date_stare = abs_datetime_now.ToString("yyy-MM-dd");
                                int id_now = new classs_table.Items_Tools().AoutoNumber("TB_Attendance_departure", "code");
                                DB_Add_delete_update_.Database.ds.Tables["TB_Attendance_departure"].Rows.Add(id_now,                                      //كودالعملية
                                                                                                             id_Emp,                                       //كود الموظف
                                                                                                             DateTime.Now.ToString("yyyy-MM"),            // تاريخ الشهر 
                                                                                                             Operation_type,                               //نوع العملية
                                                                                                             date_stare,                                   //تاريخ اليوم
                                                                                                             1,                             // اذا تم ادخال وقت التحضير يكون القيمه واحد او يكون صفر 
                                                                                                             time_one_static,                              //موعد الحضور الثابت
                                                                                                             abs_datetime_now.ToString("HH:mm"),               //توقيت التحضير الحالي
                                                                                          Convert.ToInt32(abs_datetime_now.Subtract(time_one).TotalMinutes),  //الفرق بالدقائق بين توقيت الحضور الثابت والحالي
                                                                                                             0,                                //اذا كان لم يتم تسجيل توقيت الانصراف تكون القيمه صفر زاذا تم تحضيره يكون واحد 
                                                                                                             time_tow.ToString("HH:mm"),                                           //موعد الانصراف الثابت
                                                                                                             null,                                                                   //موعد الانصراف الحالي
                                                                                                             0,                                                //الفرق بين وقت الانصراف الحالي والثابت
                                                                                                             0,                                                 //ساعات العمل يتم جمع ساعات الشغل 
                                                                                                             0,                                                  //مجموع التاخيرات في الحضور والانصراف
                                                                                                             DateTime.Now.ToString("yyyy-MM-dd HH:mm"),          //تاريخ تسجيل العملية
                                                                                                             n.txt_Empoly_number.Caption);
                                DB_Add_delete_update_.Database.update("TB_Attendance_departure");



                            }
                            else
                            {
                                MessageBox.Show(" ! الموظف اليوم في إجازة إعتيادية لا يمكن تحضيرة ");
                                dgv_Preparing_Emps_dgv.Rows.RemoveAt(dgv_Preparing_Emps_dgv.CurrentRow.Index);
                                int Countrows2 = dgv_Preparing_Emps_dgv.Rows.Count;
                                dgv_Preparing_Emps_dgv.Rows.Add();
                                dgv_Preparing_Emps_dgv.Rows[Countrows2].Cells[0].Selected = true;

                                return;
                            }
                        }
                      
                        
                    }
                }
                dgv_Preparing_Emps_dgv.Rows.Clear();
                dgv_Preparing_Emps_dgv.Focus();
                //DataRow[] dr_weekly2 = DB_Add_delete_update_.Database.ds.Tables["TB_Attendance_departure"].Select("day_now="+DateTime.Now.ToString("yyyy-MM-dd"));
                //for (int i = 0; i < dr_weekly2.Count(); i++)
                //{
                //    DataRow dr_Emp2 = DB_Add_delete_update_.Database.ds.Tables["TB_Employees"].Rows.Find(Convert.ToInt32(dr_weekly2[i][1]));
                //    if (dr_Emp2 != null)
                //    {

                //    dgv_Preparing_Emps_dgv.Rows[i].Cells[0].Value = dr_weekly2[i][1];
                //    dgv_Preparing_Emps_dgv.Rows[i].Cells[1].Value = dr_Emp2[2];
                //    dgv_Preparing_Emps_dgv.Rows[i].Cells[2].Value = Convert.ToDateTime( dr_weekly2[i][5]).ToString("yyyy-MM-dd HH:mm");
                //    }

                //}
                DataRow[] dr_weekly2 = DB_Add_delete_update_.Database.ds.Tables["TB_Attendance_departure"].Select();
                if (dr_weekly2.Count() != 0)
                {

                    for (int i = 0; i < dr_weekly2.Count(); i++)

                    {
                        if (dr_weekly2[i][3].ToString() == DateTime.Now.ToString("yyyy-MM-dd"))
                        {

                            DataRow dr_Emp2 = DB_Add_delete_update_.Database.ds.Tables["TB_Employees"].Rows.Find(Convert.ToInt32(dr_weekly2[i][1]));
                            if (dr_Emp2 != null)
                            {
                                dgv_Preparing_Emps_dgv.Rows.Add(dr_weekly2[i][1], dr_Emp2[2], Convert.ToDateTime(dr_weekly2[i][6]).ToString("yyyy-MM-dd HH:mm"));
                                //dgv_Preparing_Emps_dgv.Rows[i].Cells[0].Value = ;
                                //dgv_Preparing_Emps_dgv.Rows[i].Cells[1].Value = ;
                                //dgv_Preparing_Emps_dgv.Rows[i].Cells[2].Value = Convert.ToDateTime(dr_weekly2[i][5]).ToString("yyyy-MM-dd HH:mm");
                            }
                        }

                    }

                }


            }
        }

        private void Dgv_Preparing_Emps_dgv_KeyDown_2(object sender, KeyEventArgs e)
        {

            if (e.KeyCode == Keys.F12)
            {
                int Countrows = dgv_Preparing_Emps_dgv.Rows.Count;
                if (Countrows != 0)
                {
                    for (int i = 0; i < Countrows; i++)
                    {
                        int x = 0;
                        for (int j = 0; j < dgv_Preparing_Emps_dgv.ColumnCount; j++)
                        {
                            if (dgv_Preparing_Emps_dgv.Rows[i].Cells[j].Value == null)
                            {
                                x += 1;
                            }
                        }
                        if (x == 3)
                        {
                            dgv_Preparing_Emps_dgv.Rows.RemoveAt(dgv_Preparing_Emps_dgv.Rows[i].Index);
                        }
                    }

                }
                int Countrows2 = dgv_Preparing_Emps_dgv.Rows.Count;
                dgv_Preparing_Emps_dgv.Rows.Add();
                dgv_Preparing_Emps_dgv.Rows[Countrows2].Cells[0].Selected = true;
                if (dgv_Preparing_Emps_dgv.CurrentRow.Cells[0].Value == null)
                {
                    dgv_Preparing_Emps_dgv.CurrentRow.Cells[0].ReadOnly = false;
                }
                else
                {

                    dgv_Preparing_Emps_dgv.CurrentRow.Cells[0].ReadOnly = true;

                }

            }
        }

        private void Dgv_Preparing_Emps_dgv_EditingControlShowing_2(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            if (dgv_Preparing_Emps_dgv.CurrentCell.ColumnIndex == 0)
            {

                if (e.Control is TextBox && e.Control != null)
                {
                    e.Control.KeyPress += delegate (object Mysend, KeyPressEventArgs Mye)
                    {
                        if (!(char.IsDigit(Mye.KeyChar)) && Mye.KeyChar != (Char)Keys.Back)
                        {
                            Mye.Handled = true;
                        }


                    };
                }
            }
        }

        private void Dgv_Preparing_Emps_dgv_CellEndEdit_2(object sender, DataGridViewCellEventArgs e)
        {
            if (dgv_Preparing_Emps_dgv.CurrentCell.ColumnIndex == 0)
            {

                if (dgv_Preparing_Emps_dgv.CurrentCell.Value != null)
                {

                 

                    DataRow[] dr = DB_Add_delete_update_.Database.ds.Tables["TB_Employees"].Select("id_EMP = " + Convert.ToInt32(dgv_Preparing_Emps_dgv.CurrentRow.Cells[0].Value));


                if (dr.Count() != 0)
                {
                    //string x = DateTime.Now.ToShortDateString();
                    //DateTime ti = Convert.ToDateTime(x);
                    //MessageBox.Show("== " + x);
                    // MessageBox.Show(" == "+DateTime.Now.ToString("d"));

                    //  DataRow[] drr = DB_Add_delete_update_.Database.ds.Tables["Table_Main_Emp_ALL"].Select("datenow ='" + DateTime.Now.ToString("")+"'"); 
                    for (int i = 0; i < dr.Count(); i++)
                    {
                        if (Convert.ToBoolean(dr[i][13]) != true) //شرط اذا كان الموظف غير موقف
                        {

                                DataRow[] dr_abs_vaca = DB_Add_delete_update_.Database.ds.Tables["TB_absences_vacations"].Select("id_Emp ='" + dgv_Preparing_Emps_dgv.CurrentRow.Cells[0].Value + "'" + " And date_day ='" + DateTime.Now.ToString("yyyy-MM-dd") + "'");
                                if (dr_abs_vaca.Count() == 0)
                                {
                                                //DataTable drs1 = DB_Add_delete_update_.Database.ds.Tables["Table_Main_Emp_ALL"];
                                                DataRow[] dr5 = DB_Add_delete_update_.Database.ds.Tables["TB_Attendance_departure"].Select("id_Emp ='" + dgv_Preparing_Emps_dgv.CurrentRow.Cells[0].Value + "'" + " And day_now ='" + DateTime.Now.ToString("yyyy-MM-dd") + "'");
                                        //MessageBox.Show("=============  "+dr5[0][1]+"==="+dr5[0][2]);
                                        // DataView cc = new DataView(drs1);
                                        // cc.RowFilter = "[datenow] like '%" + DateTime.Now.ToString("d") + "%'";

                                        //drs1= new classs_table.Items_Tools().Fill_DataTable_Columns("Table_Main_Emp_ALL" , new string[] {
                                        //          "id",
                                        //          "num_Emp" ,
                                        //         "datenow"  ,
                                        //          "type_story" ,
                                        //         "Date_star",
                                        //         "Date_end",
                                        //         "Count_Hours"
                                        //                       }   );

                                        //if (dr5.Count() !=0)
                                        //{
                                        //    //for (int i = 0; i < dr5.Count(); i++)
                                        //    //{

                                        //    //}


                                        //}
                                        // DataView c2 = new DataView(drs1);
                                        //if (c2.Count !=0)
                                        //{

                                        //    if (true)
                                        //    {

                                        //    } 

                                        //}
                                        //DataRow[] dr33 =null;
                                        //if (drs1.Rows.Count != 0)
                                        //{
                                        //     //dr33 = drs1.Select("num_Emp =" + dgv_Preparing_Emps_dgv.CurrentRow.Cells[0].Value);

                                        //}

                                        if (dr5.Count() != 0)
                                        {

                                            MessageBox.Show("الموظف تم تحضيرة سابقا");
                                            dgv_Preparing_Emps_dgv.Rows.RemoveAt(dgv_Preparing_Emps_dgv.CurrentRow.Index);
                                            int Countrows2 = dgv_Preparing_Emps_dgv.Rows.Count;
                                            dgv_Preparing_Emps_dgv.Rows.Add();
                                            dgv_Preparing_Emps_dgv.Rows[Countrows2].Cells[0].Selected = true;

                                    }
                                        else
                                        {

                                            dgv_Preparing_Emps_dgv.CurrentRow.Cells[1].Value = dr[0][1].ToString();
                                            dgv_Preparing_Emps_dgv.CurrentRow.Cells[2].Value = DateTime.Now.ToString("yyyy-MM-dd HH:mm");

                                        }

                                }
                                else
                                {
                                    if (Convert.ToInt32(dr_abs_vaca[0][3]) == 1)
                                    {
                                        MessageBox.Show(" ! لا يمكن التحضير تم عمل للموظف اليوم غياب  في وقت سابقاً ");
                                        dgv_Preparing_Emps_dgv.Rows.RemoveAt(dgv_Preparing_Emps_dgv.CurrentRow.Index);
                                        int Countrows2 = dgv_Preparing_Emps_dgv.Rows.Count;
                                        dgv_Preparing_Emps_dgv.Rows.Add();
                                        dgv_Preparing_Emps_dgv.Rows[Countrows2].Cells[0].Selected = true;
                                    }
                                    else if (Convert.ToInt32(dr_abs_vaca[0][3]) == 2)
                                    {
                                        MessageBox.Show(" !  لا يمكن التحضير تم عمل للموظف اليوم إجازة في وقت سابقاً ");
                                        dgv_Preparing_Emps_dgv.Rows.RemoveAt(dgv_Preparing_Emps_dgv.CurrentRow.Index);
                                        int Countrows2 = dgv_Preparing_Emps_dgv.Rows.Count;
                                        dgv_Preparing_Emps_dgv.Rows.Add();
                                        dgv_Preparing_Emps_dgv.Rows[Countrows2].Cells[0].Selected = true;
                                    }

                                }
                            }
                        else
                        {
                            MessageBox.Show("الموظف موقف يرجأ اختيار موظف اخر");
                            if (dgv_Preparing_Emps_dgv.CurrentRow != null)
                            {
                                dgv_Preparing_Emps_dgv.Rows.RemoveAt(dgv_Preparing_Emps_dgv.CurrentRow.Index);
                            }

                        }

                    }

                }
                else
                {
                    if (dgv_Preparing_Emps_dgv.CurrentRow != null)
                    {
                        dgv_Preparing_Emps_dgv.Rows.RemoveAt(dgv_Preparing_Emps_dgv.CurrentRow.Index);
                    }
                    MessageBox.Show("لايوجد موظف بهذا الرقم");
                }

            }


            }
        }

        private void TabNavigationPage1_MouseClick(object sender, MouseEventArgs e)
        {
            //dgv_Check_out_screen_dgv.Focus();
        }

        private void Dgv_Check_out_screen_dgv_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F12)
            {
                int Countrows = dgv_Check_out_screen_dgv.Rows.Count;
                if (Countrows != 0)
                {
                    for (int i = 0; i < Countrows; i++)
                    {
                        int x = 0;
                        for (int j = 0; j < dgv_Check_out_screen_dgv.ColumnCount; j++)
                        {
                            if (dgv_Check_out_screen_dgv.Rows[i].Cells[j].Value == null)
                            {
                                x += 1;
                            }
                        }
                        if (x == 3)
                        {
                            dgv_Check_out_screen_dgv.Rows.RemoveAt(dgv_Check_out_screen_dgv.Rows[i].Index);
                        }
                    }

                }

                int Countrows2 = dgv_Check_out_screen_dgv.Rows.Count;
                dgv_Check_out_screen_dgv.Rows.Add();
                dgv_Check_out_screen_dgv.Rows[Countrows2].Cells[0].Selected = true;
                if (dgv_Check_out_screen_dgv.CurrentRow.Cells[0].Value == null)
                {
                    dgv_Check_out_screen_dgv.CurrentRow.Cells[0].ReadOnly = false;
                }
                else {

                    dgv_Check_out_screen_dgv.CurrentRow.Cells[0].ReadOnly = true;

                }


            }
        }

        private void Btn_save_Check_out_screen_Click(object sender, EventArgs e)
        {
            dgv_Check_out_screen_dgv.Focus();

            if (dgv_Check_out_screen_dgv.Rows.Count != 0)
            {

                for (int i = 0; i < dgv_Check_out_screen_dgv.Rows.Count; i++)
                {
                    if (dgv_Check_out_screen_dgv.Rows[i].Cells[0].Value != null)
                    {

                        //DataRow[] dr_obs = DB_Add_delete_update_.Database.ds.Tables["TB_Attendance_departure"].Select("id_Emp ='" + dgv_Check_out_screen_dgv.Rows[i].Cells[0].Value + "'" + " And day_now ='" + DateTime.Now.ToString("yyyy-MM-dd") + "'" + " And date_time_departure ='" + Convert.ToDateTime( dgv_Check_out_screen_dgv.Rows[i].Cells[3].Value).ToString("HH:mm") + "'");
                        DataRow[] dr_obs = DB_Add_delete_update_.Database.ds.Tables["TB_Attendance_departure"].Select("id_Emp ='" + dgv_Check_out_screen_dgv.Rows[i].Cells[0].Value + "'" + " And day_now ='" + DateTime.Now.ToString("yyyy-MM-dd") + "'" );

                        if (dr_obs.Count() != 0)
                        {
                            if (Convert.ToInt32(dr_obs[0][5]) == 1 && Convert.ToInt32(dr_obs[0][9]) == 0)
                            {
                                //DataRow[] dr_obs2 = DB_Add_delete_update_.Database.ds.Tables["TB_Attendance_departure"].Select("id_Emp ='" + dgv_Check_out_screen_dgv.Rows[i].Cells[0].Value + "'" + " And day_now ='" + DateTime.Now.ToString("yyyy-MM-dd") + "'");
                                DataRow Data_update_storg = DB_Add_delete_update_.Database.ds.Tables["TB_Attendance_departure"].Rows.Find(dr_obs[0][0]);
                                if (Data_update_storg != null)
                                {


                                    DateTime time_tow = Convert.ToDateTime(Data_update_storg[9]);//موعد الانصراف الثابت
                                    DateTime abs_datetime_now = Convert.ToDateTime(dgv_Check_out_screen_dgv.Rows[i].Cells[3].Value);//توقيت التحضير الحالي

                                    int Row_sum_Index_ubdate = DB_Add_delete_update_.Database.ds.Tables["TB_Attendance_departure"].Rows.IndexOf(Data_update_storg);

                                    int count_HH = 0;
                                    int count_mm = 0;


                                    if (Convert.ToInt32(Data_update_storg[8]) >= 0 && Convert.ToInt32(abs_datetime_now.Subtract(time_tow).TotalMinutes) >= 0)
                                    {
                                        count_mm = Convert.ToInt32(Data_update_storg[8]) + Convert.ToInt32(abs_datetime_now.Subtract(time_tow).TotalMinutes);

                                    }
                                    else if (Convert.ToInt32(Data_update_storg[8]) >= 0 && Convert.ToInt32(abs_datetime_now.Subtract(time_tow).TotalMinutes) < 0)
                                    {
                                        count_mm = Convert.ToInt32(Data_update_storg[8]);

                                    }
                                    else if (Convert.ToInt32(Data_update_storg[8]) < 0 && Convert.ToInt32(abs_datetime_now.Subtract(time_tow).TotalMinutes) >= 0)
                                    {
                                        count_mm = Convert.ToInt32(abs_datetime_now.Subtract(time_tow).TotalMinutes);

                                    }
                                    else if (Convert.ToInt32(Data_update_storg[8]) < 0 && Convert.ToInt32(abs_datetime_now.Subtract(time_tow).TotalMinutes) < 0)
                                    {
                                        count_mm = 0;

                                    }

                                    if (count_mm < 60)
                                    {
                                        count_HH = 0;

                                    }
                                    else if (count_mm >= 60)
                                    {
                                        count_HH = count_mm / 60;
                                    }

                                    DB_Add_delete_update_.Database.ds.Tables["TB_Attendance_departure"].Rows[Row_sum_Index_ubdate][9] = 1; // // تم اضافة وقت الانصراف يكون القيمة واحد 
                                    DB_Add_delete_update_.Database.ds.Tables["TB_Attendance_departure"].Rows[Row_sum_Index_ubdate][11] = Convert.ToDateTime(dgv_Check_out_screen_dgv.Rows[i].Cells[3].Value).ToString("HH:mm");
                                    DB_Add_delete_update_.Database.ds.Tables["TB_Attendance_departure"].Rows[Row_sum_Index_ubdate][12] = Convert.ToInt32(abs_datetime_now.Subtract(time_tow).TotalMinutes);

                                    DB_Add_delete_update_.Database.ds.Tables["TB_Attendance_departure"].Rows[Row_sum_Index_ubdate][13] = count_HH;
                                    DB_Add_delete_update_.Database.ds.Tables["TB_Attendance_departure"].Rows[Row_sum_Index_ubdate][14] = count_mm;


                                    DB_Add_delete_update_.Database.update("TB_Attendance_departure");

                                }
                            }

                        }
                        else {
                            MessageBox.Show("الموظف لم يتم تحضيرة");
                        }

                    }

                }

                }
            }

        private void TabNavigationPage1_Click(object sender, EventArgs e)
        {
          //  dgv_Check_out_screen_dgv.Focus();
        }

        private void TabPane1_SelectedPageChanging(object sender, DevExpress.XtraBars.Navigation.SelectedPageChangingEventArgs e)
        {
            //if (e.Page.PageText == "الانصراف")
            //{
            //    dgv_Check_out_screen_dgv.Focus();
            //}
            //else if (e.Page.PageText == "الحضور")
            //{

            //    dgv_Preparing_Emps_dgv.Focus();
            //}
        }

        private void TabPane1_SelectedPageChanged(object sender, DevExpress.XtraBars.Navigation.SelectedPageChangedEventArgs e)
        {
            if (e.Page.PageText == "الانصراف")
            {
                dgv_Check_out_screen_dgv.Focus();
            }
            else if(e.Page.PageText == "الحضور" )
            {

                dgv_Preparing_Emps_dgv.Focus();
            }



        }

        private void TabPane1_SelectedPageIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void TabPane1_ControlShown(object sender, DevExpress.XtraBars.Navigation.DeferredControlLoadEventArgs e)
        {
            if (e.Page.PageText == "الانصراف")
            {
                dgv_Check_out_screen_dgv.Focus();
            }
            else if (e.Page.PageText == "الحضور")
            {

                dgv_Preparing_Emps_dgv.Focus();
            }
        }

        private void Dgv_Check_out_screen_dgv_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (dgv_Check_out_screen_dgv.CurrentCell.ColumnIndex == 0)
            {

                if (dgv_Check_out_screen_dgv.CurrentCell.Value != null)
                {
                    DataRow[] drEmp = DB_Add_delete_update_.Database.ds.Tables["TB_Employees"].Select("id_EMP = " + Convert.ToInt32(dgv_Check_out_screen_dgv.CurrentRow.Cells[0].Value));


                    if (drEmp.Count() != 0)
                    {

                        if (Convert.ToBoolean(drEmp[0][13]) != true) //شرط اذا كان الموظف غير موقف
                        {

                            DataRow[] dr = DB_Add_delete_update_.Database.ds.Tables["TB_Attendance_departure"].Select("id_Emp = '" + Convert.ToInt32(dgv_Check_out_screen_dgv.CurrentRow.Cells[0].Value) + "'" + " And day_now ='" + DateTime.Now.ToString("yyyy-MM-dd") + "'");

                            if (dr.Count() != 0)
                            {
                                DataRow drEmplyee = DB_Add_delete_update_.Database.ds.Tables["TB_Employees"].Rows.Find(dgv_Check_out_screen_dgv.CurrentRow.Cells[0].Value);


                                if (Convert.ToInt32(dr[0][4]) == 1 && Convert.ToInt32(dr[0][8]) == 0)
                                {
                                    if (drEmplyee != null)
                                    {

                                        dgv_Check_out_screen_dgv.CurrentRow.Cells[1].Value = drEmplyee[2].ToString();
                                        dgv_Check_out_screen_dgv.CurrentRow.Cells[2].Value = Convert.ToDateTime(dr[0][6]).ToString("yyyy-MM-dd HH:mm");
                                        dgv_Check_out_screen_dgv.CurrentRow.Cells[3].Value = DateTime.Now.ToString("yyyy-MM-dd HH:mm");

                                    }



                                }



                            }
                            else
                            {
                                MessageBox.Show(" الموظف لم يتم تحضيرة ");
                                dgv_Check_out_screen_dgv.Rows.RemoveAt(dgv_Check_out_screen_dgv.CurrentRow.Index);

                                return;

                            }

                        }
                        else
                        {
                            MessageBox.Show("الموظف موقف يرجأ اختيار موظف اخر");
                            if (dgv_Check_out_screen_dgv.CurrentRow != null)
                            {
                                dgv_Check_out_screen_dgv.Rows.RemoveAt(dgv_Check_out_screen_dgv.CurrentRow.Index);
                            }

                        }






                    }
                    else
                    {
                        if (dgv_Check_out_screen_dgv.CurrentRow != null)
                        {
                            dgv_Check_out_screen_dgv.Rows.RemoveAt(dgv_Check_out_screen_dgv.CurrentRow.Index);
                        }
                        MessageBox.Show("لايوجد موظف بهذا الرقم");
                    }


                }

              






            }



        }

        private void Dgv_Check_out_screen_dgv_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            if (dgv_Check_out_screen_dgv.CurrentCell.ColumnIndex == 0)
            {

                if (e.Control is TextBox && e.Control != null)
                {
                    e.Control.KeyPress += delegate (object Mysend, KeyPressEventArgs Mye)
                    {
                        if (!(char.IsDigit(Mye.KeyChar)) && Mye.KeyChar != (Char)Keys.Back)
                        {
                            Mye.Handled = true;
                        }


                    };
                }
            }
        }

        private void Frm_Preparing_employees_Load(object sender, EventArgs e)
        {

           
            //MessageBox.Show(""+tabPane1.SelectedPage.PageText);

            //تعبئه شاشه الانصراف بالموظفين الذي تم اعطائهم توقيت   الحضور لليوم الحالي

            DataRow[] dr_weekly2 = DB_Add_delete_update_.Database.ds.Tables["TB_Attendance_departure"].Select("day_now ='" + DateTime.Now.ToString("yyyy-MM-dd") + "'");
            if (dr_weekly2.Count() !=0)
            {
               
                for (int i = 0; i < dr_weekly2.Count(); i++)
               
                if (dr_weekly2[0][3].ToString() == DateTime.Now.ToString("yyyy-MM-dd"))
             {
                {

                    DataRow dr_Emp2 = DB_Add_delete_update_.Database.ds.Tables["TB_Employees"].Rows.Find(Convert.ToInt32(dr_weekly2[i][1]));
                    if (dr_Emp2 != null)
                    {
                            dgv_Preparing_Emps_dgv.Rows.Add(dr_weekly2[i][1] , dr_Emp2[2] , Convert.ToDateTime(dr_weekly2[i][6]).ToString("yyyy-MM-dd HH:mm"));
                    //dgv_Preparing_Emps_dgv.Rows[i].Cells[0].Value = ;
                    //dgv_Preparing_Emps_dgv.Rows[i].Cells[1].Value = ;
                    //dgv_Preparing_Emps_dgv.Rows[i].Cells[2].Value = Convert.ToDateTime(dr_weekly2[i][5]).ToString("yyyy-MM-dd HH:mm");
                    }

                }
             }

            }

            // تعبئه شاشه الانصراف بالموظفين الذي تم اعطائهم توقيت   الانصراف لليوم الحالي
            DataRow[] dr_weekly3 = DB_Add_delete_update_.Database.ds.Tables["TB_Attendance_departure"].Select("day_now ='" + DateTime.Now.ToString("yyyy-MM-dd") + "'");

            if (dr_weekly3.Count() != 0)
            {
                for (int i = 0; i < dr_weekly3.Count(); i++)
                {
                    if (Convert.ToInt32(dr_weekly3[i][4]) == 1 && Convert.ToInt32( dr_weekly3[i][8]) == 1 )
                    {
                        //MessageBox.Show(" = "+ dr_weekly3[i][4] +" && = " + dr_weekly3[i][8]);
                        DataRow dr_Emp3 = DB_Add_delete_update_.Database.ds.Tables["TB_Employees"].Rows.Find(Convert.ToInt32(dr_weekly3[i][1]));
                        if (dr_Emp3 != null)
                        {
                            dgv_Check_out_screen_dgv.Rows.Add(dr_weekly3[i][1], dr_Emp3[2], Convert.ToDateTime(dr_weekly3[i][6]).ToString("yyyy-MM-dd HH:mm"), Convert.ToDateTime(dr_weekly3[i][10]).ToString("yyyy-MM-dd HH:mm"));
                            //dgv_Preparing_Emps_dgv.Rows[i].Cells[0].Value = ;
                            //dgv_Preparing_Emps_dgv.Rows[i].Cells[1].Value = ;
                            //dgv_Preparing_Emps_dgv.Rows[i].Cells[2].Value = Convert.ToDateTime(dr_weekly2[i][5]).ToString("yyyy-MM-dd HH:mm");
                        }


                    }

                }
            }



            pan_dgv_Preparing_emp.Focus();

        }

        private void Button1_Click(object sender, EventArgs e)
        {
            //int days = DateTime.DaysInMonth(Convert.ToInt32(DateTime.Now.Year), Convert.ToInt32(DateTime.Now.Month));
            int month = DateTime.Now.Month;
            int days = DateTime.DaysInMonth(Convert.ToInt32(DateTime.Now.Year), month);
            DateTime dttt = DateTime.Now.Date;
            DataRow[] dt_scount = DB_Add_delete_update_.Database.ds.Tables["TB_COUNT_DAY_EMP"].Select("id_EMP ='" + dgv_Preparing_Emps_dgv.CurrentRow.Cells[0].Value + "'" + " And date_month ='" + dttt.ToString("yyyy-MM-dd") + "'");
            if (dt_scount.Count() == 0)
            {
                int[] x = new int[days];
                int id_Empp = Convert.ToInt32(dgv_Preparing_Emps_dgv.CurrentRow.Cells[0].Value);
                DataRow[] drstatic = DB_Add_delete_update_.Database.ds.Tables["TB_Emplyee_days_weekly"].Select("id_Emp =" + id_Empp);
                object[] daysstatic = { drstatic[0][2], drstatic[0][5], drstatic[0][8], drstatic[0][11], drstatic[0][14], drstatic[0][17], drstatic[0][20] };

                for (int j = 1; j <= days; j++)
                {

                    if (new DateTime(DateTime.Now.Year, month, j).DayOfWeek.ToString() == "Saturday")
                    {
                        if (Convert.ToInt32(daysstatic[0]) == 1)
                        {
                            x[j - 1] = 1;
                        }
                        else
                        {
                            x[j - 1] = 0;
                        }

                    }
                    else if (new DateTime(DateTime.Now.Year, month, j).DayOfWeek.ToString() == "Sunday")
                    {

                        if (Convert.ToInt32(daysstatic[1]) == 1)
                        {
                            x[j - 1] = 1;
                        }
                        else
                        {
                            x[j - 1] = 0;
                        }
                    }
                    else if (new DateTime(DateTime.Now.Year, month, j).DayOfWeek.ToString() == "Monday")
                    {

                        if (Convert.ToInt32(daysstatic[2]) == 1)
                        {
                            x[j - 1] = 1;
                        }
                        else
                        {
                            x[j - 1] = 0;
                        }
                    }
                    else if (new DateTime(DateTime.Now.Year, month, j).DayOfWeek.ToString() == "Tuesday")
                    {

                        if (Convert.ToInt32(daysstatic[3]) == 1)
                        {
                            x[j - 1] = 1;
                        }
                        else
                        {
                            x[j - 1] = 0;
                        }
                    }

                    else if (new DateTime(DateTime.Now.Year, month, j).DayOfWeek.ToString() == "Wednesday")
                    {

                        if (Convert.ToInt32(daysstatic[4]) == 1)
                        {
                            x[j - 1] = 1;
                        }
                        else
                        {
                            x[j - 1] = 0;
                        }
                    }

                    else if (new DateTime(DateTime.Now.Year, month, j).DayOfWeek.ToString() == "Thursday")
                    {

                        if (Convert.ToInt32(daysstatic[5]) == 1)
                        {
                            x[j - 1] = 1;
                        }
                        else
                        {
                            x[j - 1] = 0;
                        }
                    }

                    else if (new DateTime(DateTime.Now.Year, month, j).DayOfWeek.ToString() == "Friday")
                    {

                        if (Convert.ToInt32(daysstatic[6]) == 1)
                        {
                            x[j - 1] = 1;
                        }
                        else
                        {
                            x[j - 1] = 0;
                        }
                    }



                }

                int id_now = new classs_table.Items_Tools().AoutoNumber("TB_COUNT_DAY_EMP", "code");

                countdaysmonth(id_now, id_Empp, dttt.ToString("yyyy-MM-dd"), days, x);

            }
           
            

                //}


                //else if (i == 1 && Convert.ToInt32(daysstatic[i]) == 1)//اذا كان اليوم الثابت الاحد
                //{
                //    for (int j = 1; i <= days; i++)
                //    {
                //        if (new DateTime(DateTime.Now.Year, DateTime.Now.Month, j).DayOfWeek.ToString() == "Sunday")
                //        {
                //            x[j - 1] = 1;
                //        }
                //        else
                //        {
                //            x[j - 1] = 0;
                //        }

                //    }

                //}

                //else if (i == 2 && Convert.ToInt32(daysstatic[i]) == 1)//اذا كان اليوم الثابت الاثنين
                //{
                //    for (int j = 1; i <= days; i++)
                //    {
                //        if (new DateTime(DateTime.Now.Year, DateTime.Now.Month, j).DayOfWeek.ToString() == "Monday")
                //        {
                //            x[j - 1] = 1;
                //        }
                //        else
                //        {
                //            x[j - 1] = 0;
                //        }

                //    }

                //}

                //else if (i == 3 && Convert.ToInt32(daysstatic[i]) == 1)//اذا كان اليوم الثابت الاثلاثاء
                //{
                //    for (int j = 1; i <= days; i++)
                //    {
                //        if (new DateTime(DateTime.Now.Year, DateTime.Now.Month, j).DayOfWeek.ToString() == "Tuesday")
                //        {
                //            x[j - 1] = 1;
                //        }
                //        else
                //        {
                //            x[j - 1] = 0;
                //        }

                //    }

                //}

                //else if (i == 4 && Convert.ToInt32(daysstatic[i]) == 1)//اذا كان اليوم الثابت الاربعاء
                //{
                //    for (int j = 1; i <= days; i++)
                //    {
                //        if (new DateTime(DateTime.Now.Year, DateTime.Now.Month, j).DayOfWeek.ToString() == "Wednesday")
                //        {
                //            x[j - 1] = 1;
                //        }
                //        else
                //        {
                //            x[j - 1] = 0;
                //        }

                //    }

                //}

                //else if (i == 5 && Convert.ToInt32(daysstatic[i]) == 1)//اذا كان اليوم الثابت الاخميس
                //{
                //    for (int j = 1; i <= days; i++)
                //    {
                //        if (new DateTime(DateTime.Now.Year, DateTime.Now.Month, j).DayOfWeek.ToString() == "Thursday")
                //        {
                //            x[j - 1] = 1;
                //        }
                //        else
                //        {
                //            x[j - 1] = 0;
                //        }

                //    }

                //}

                //else if (i == 6 && Convert.ToInt32(daysstatic[i]) == 1)//اذا كان اليوم الثابت الجمعة
                //{
                //    for (int j = 1; i <= days; i++)
                //    {
                //        if (new DateTime(DateTime.Now.Year, DateTime.Now.Month, j).DayOfWeek.ToString() == "Friday")
                //        {
                //            x[j - 1] = 1;
                //        }
                //        else
                //        {
                //            x[j - 1] = 0;
                //        }

                //    }

                //}

           // }

           
           // DataRow[] dr5 = DB_Add_delete_update_.Database.ds.Tables["TB_Employee_discount"].Select() ;

          

            //DB_Add_delete_update_.Database.ds.Tables["TB_COUNT_DAY_EMP"].Rows.Add(id_now, id_Empp , dttt.ToString("yyyy-MM-dd"), days , x[0], x[1], x[2], x[3], x[4], x[5], x[6], x[7], x[8], x[9], x[10] ,x[11], x[12], x[13], x[14], x[15], x[16], x[17], x[18], x[19], x[20], x[21], x[22], x[23], x[24], x[25], x[26], x[27], x[28], x[29]); //عندما يكون نوع العملية تحضير يكون رقم واحد

            //DB_Add_delete_update_.Database.update("TB_COUNT_DAY_EMP");

        }
        public void countdaysmonth(int Aoutonum,int id_Emp, string datetimee,int count_days , int []x) {

            if (count_days == 28)
            {
                DB_Add_delete_update_.Database.ds.Tables["TB_COUNT_DAY_EMP"].Rows.Add(Aoutonum,
                                                                                     id_Emp,
                                                                                     datetimee,
                                                                                     count_days ,
                                                                                     x[0],
                                                                                     x[1], x[2], x[3], x[4], x[5], x[6], x[7], x[8], x[9], x[10], x[11], x[12], x[13], x[14], x[15], x[16], x[17], x[18], x[19], x[20], x[21], x[22], x[23], x[24], x[25], x[26], x[27]); //عندما يكون نوع العملية تحضير يكون رقم واحد


            }
            else if (count_days == 29)
            {
                DB_Add_delete_update_.Database.ds.Tables["TB_COUNT_DAY_EMP"].Rows.Add(Aoutonum, id_Emp, datetimee, count_days, x[0], x[1], x[2], x[3], x[4], x[5], x[6], x[7], x[8], x[9], x[10], x[11], x[12], x[13], x[14], x[15], x[16], x[17], x[18], x[19], x[20], x[21], x[22], x[23], x[24], x[25], x[26], x[27], x[28]); //عندما يكون نوع العملية تحضير يكون رقم واحد


            }
            else if (count_days == 30)
            {
                DB_Add_delete_update_.Database.ds.Tables["TB_COUNT_DAY_EMP"].Rows.Add(Aoutonum, id_Emp, datetimee, count_days, x[0], x[1], x[2], x[3], x[4], x[5], x[6], x[7], x[8], x[9], x[10], x[11], x[12], x[13], x[14], x[15], x[16], x[17], x[18], x[19], x[20], x[21], x[22], x[23], x[24], x[25], x[26], x[27], x[28], x[29]); //عندما يكون نوع العملية تحضير يكون رقم واحد


            }
            else if (count_days == 31)
            {
                DB_Add_delete_update_.Database.ds.Tables["TB_COUNT_DAY_EMP"].Rows.Add(Aoutonum, id_Emp, datetimee, count_days, x[0], x[1], x[2], x[3], x[4], x[5], x[6], x[7], x[8], x[9], x[10], x[11], x[12], x[13], x[14], x[15], x[16], x[17], x[18], x[19], x[20], x[21], x[22], x[23], x[24], x[25], x[26], x[27], x[28], x[29],x[30]); //عندما يكون نوع العملية تحضير يكون رقم واحد


            }
            DB_Add_delete_update_.Database.update("TB_COUNT_DAY_EMP");

        }

        private void TabPane1_Click(object sender, EventArgs e)
        {
            //if (tabPane1.Pages.IndexOf(tabPane1) == 1)
            //{
            //    dgv_Preparing_Emps_dgv.Focus();
            //    MessageBox.Show("page2");
            //}
            
        }

        private void Dgv_Check_out_screen_dgv_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            
        }

        private void Dgv_Check_out_screen_dgv_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Dgv_Check_out_screen_dgv_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            if (dgv_Check_out_screen_dgv.CurrentCell.ColumnIndex == 0)
            {
                if (dgv_Check_out_screen_dgv.CurrentRow.Cells[0].Value == null)
                {
                    dgv_Check_out_screen_dgv.CurrentRow.Cells[0].ReadOnly = false;

                }
                else {
                    dgv_Check_out_screen_dgv.CurrentRow.Cells[0].ReadOnly = true;

                }
            }
        }

        private void Dgv_Preparing_Emps_dgv_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            if (dgv_Preparing_Emps_dgv.CurrentCell.ColumnIndex == 0)
            {
                if (dgv_Preparing_Emps_dgv.CurrentRow.Cells[0].Value == null)
                {
                    dgv_Preparing_Emps_dgv.CurrentRow.Cells[0].ReadOnly = false;

                }
                else
                {
                    dgv_Preparing_Emps_dgv.CurrentRow.Cells[0].ReadOnly = true;

                }
            }
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            new Employlee.Emp_forms.Frm_absences_vacations().ShowDialog();
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            new Employlee.Emp_forms.Frm_Discount_Emp().ShowDialog();
        }

        private void Button4_Click(object sender, EventArgs e)
        {
            //Employlee.Emp_forms.Frm_Employee_discount_problem fr = new Employlee.Emp_forms.Frm_Employee_discount_problem();
            
           new Employlee.Emp_forms.Frm_Employee_discount_problemm().ShowDialog();
        }

        private void Button5_Click(object sender, EventArgs e)
        {
            new Employlee.Emp_forms.Frm_incentives_allowances().ShowDialog();

        }

        private void Button6_Click(object sender, EventArgs e)
        {
            new Employlee.Emp_forms.Frm_sales_representative_commission_calculation().ShowDialog();

        }

        private void Button7_Click(object sender, EventArgs e)
        {
            new Employlee.Emp_forms.frm_Emp_salary_disbursement().ShowDialog();
        }
    }
}
