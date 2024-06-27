using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Manag_ph.prodects.Report
{
    class RP_footer_prodects
    {


        void Fill_com_Storg_Item_update_qty()
        {
            var vr = Application.OpenForms["Main"] as Main;
            DataTable dt = new DataTable("Storg");
            dt.Columns.Add("Storg_id", typeof(int));
            dt.Columns.Add("Storg_Name");
            dt.Rows.Add(0, "الكل");

            for (int i = 0; i < DB_Add_delete_update_.Database.ds.Tables["Storg"].Rows.Count; i++)
            {

                object[] dr = DB_Add_delete_update_.Database.ds.Tables["Storg"].Rows[i].ItemArray;
                dt.Rows.Add(Convert.ToInt32(dr[0]), dr[1].ToString());
            }
            vr.com_storg_footer_All_RP.DataSource = dt;
            vr.com_storg_footer_All_RP.DisplayMember = "Storg_Name";
            vr.com_storg_footer_All_RP.ValueMember = "Storg_id";
        }

        void Fill_com_Type_sdad()
        {
            var vr = Application.OpenForms["Main"] as Main;
            DataTable dt = new DataTable("sdaad");
            dt.Columns.Add("sds_num", typeof(int));
            dt.Columns.Add("sds_name");
            dt.Rows.Add(0, "الكل");
            dt.Rows.Add(1, "اجل");
            dt.Rows.Add(2, "نقد");


            vr.com_type_sdad_footer_All_RP.DataSource = dt;
            vr.com_type_sdad_footer_All_RP.DisplayMember = "sds_name";
            vr.com_type_sdad_footer_All_RP.ValueMember = "sds_num";
        }

        void Fill_Emplyee()
        {
            var vr = Application.OpenForms["Main"] as Main;

            vr.com_Emply_footer_All_RP.DataSource = DB_Add_delete_update_.Database.ds.Tables["TB_Employees"];
            vr.com_Emply_footer_All_RP.DisplayMember = "name_AR_EMP";
            vr.com_Emply_footer_All_RP.ValueMember = "id_EMP";
        }

        public void Fill_All_Data_RP_update_qty()
        {
            Fill_Emplyee();
            Fill_com_Storg_Item_update_qty();
            Fill_com_Type_sdad();
        }



        public void serch_Data_Footer()
        {
            var vr = Application.OpenForms["Main"] as Main;
            vr.dgv_footer_prodect_All_RP_dgv.Rows.Clear();
            int Storg_num = Convert.ToInt32(vr.com_storg_footer_All_RP.SelectedValue);
            int Emply_num = Convert.ToInt32(vr.com_Emply_footer_All_RP.SelectedValue);
            int sdad = Convert.ToInt32(vr.com_type_sdad_footer_All_RP.SelectedValue);
            int supper_num = 0;
            string MySelect = "Emp_id =" + Emply_num;
            if (vr.ch_suppr_footer_All_RP.Checked)
            {
                if (vr.txt_suppr_name_footer_All_RP.Text.Trim() != string.Empty)
                {
                    supper_num = Convert.ToInt32(vr.txt_suppr_num_footer_All_RP.Text.Trim());
                }
                else
                {
                    MessageBox.Show("يرجاء التحقق من رقم المورد", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                // فلتير اذا كان يبحث في المخزن او كل المخازن او تاريخ الصلاحية او بدون تاريخ الصلاحية
                MySelect += " and Foot_supper =" + supper_num;

            }

            if (Storg_num != 0)
            {
                MySelect += " and Foot_Storg =" + Storg_num;
            }


            if (sdad != 0)
            {
                MySelect += " and Type_paymant ='" + vr.com_type_sdad_footer_All_RP.Text + "'";
            }

            if (vr.ch_show_dtp_footer_All_RP.Checked)
            {
                MySelect += " and (Date_Create_Footer >='" + vr.dtp_footer_All_RP_one.Value + "' and Date_Create_Footer <='" + vr.dtp_footer_All_RP_tow.Value + "')";
                //MessageBox.Show(vr.dtp_footer_All_RP_one.Value+"");
            }



            DataRow[] dr_df = DB_Add_delete_update_.Database.ds.Tables["Data_Footer"].Select(MySelect);

            if (dr_df.Count() != 0)
            {
                // اضافة البيانات الا جدول الفواتير من اجل التقارير
                for (int i = 0; i < dr_df.Count(); i++)
                {
                    object[] storg_data = DB_Add_delete_update_.Database.ds.Tables["Storg"].Rows.Find(dr_df[i][2]).ItemArray;
                    object[] suppr_data = DB_Add_delete_update_.Database.ds.Tables["Supplier"].Rows.Find(dr_df[i][4]).ItemArray;
                    object[] sum_data = DB_Add_delete_update_.Database.ds.Tables["sum_storg_Item"].Rows.Find(dr_df[i][7]).ItemArray;
                    object[] Totle_data = DB_Add_delete_update_.Database.ds.Tables["Totel_Footer_prodeuct"].Rows.Find(dr_df[i][9]).ItemArray;


                    vr.dgv_footer_prodect_All_RP_dgv.Rows.Add(dr_df[i][0]
                        , dr_df[i][1],
                        storg_data[1],
                        suppr_data[1],
                        dr_df[i][5],
                        dr_df[i][11],
                        dr_df[i][3],
                        sum_data[1],
                        Convert.ToDouble(Totle_data[1]).ToString("N2"),
                        Totle_data[2],
                       Convert.ToDouble(Totle_data[3]).ToString("N2"),
                        Convert.ToDouble(Totle_data[5]).ToString("N2"));
                }
            }
            else
            {
                //MessageBox.Show("Not Fill");
            }



            vr.lbl_RP_Count_Footer.Text = vr.dgv_footer_prodect_All_RP_dgv.RowCount.ToString();





        }


        public void Txt_suppr_num_footer_All_RP_KeyDown_(object sender, KeyEventArgs e)
        {
            var vr = Application.OpenForms["Main"] as Main;

            if (e.KeyCode == Keys.Enter)
            {
                if (vr.txt_suppr_num_footer_All_RP.Text.Trim() != string.Empty)
                {
                    DataRow dr_supper = DB_Add_delete_update_.Database.ds.Tables["Supplier"].Rows.Find(vr.txt_suppr_num_footer_All_RP.Text.Trim());
                    if (dr_supper != null)
                    {
                        vr.txt_suppr_name_footer_All_RP.Text = dr_supper[1].ToString();
                    }
                    else
                    {
                        MessageBox.Show("يرجاء التاكد من رقم المورد", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        vr.txt_suppr_name_footer_All_RP.Text = "";
                        vr.txt_suppr_num_footer_All_RP.Text = "";
                        return;
                    }
                }

            }



        }

        public void Add_Data_Report()
        {





        }


        public void Show_Report()
        {
            var vr = Application.OpenForms["Main"] as Main;
            // اخراج بيانات فاتورة المشتريات
            RPP_footer_prodects RPP = new RPP_footer_prodects();
            if (vr.dgv_footer_prodect_All_RP_dgv.CurrentRow != null)
            {
                DataRow sum_Data = DB_Add_delete_update_.Database.ds.Tables["Data_Footer"].Rows.Find(vr.dgv_footer_prodect_All_RP_dgv.CurrentRow.Cells[0].Value);
                if (sum_Data != null)
                {

                    DataRow[] dr_Item_storg = DB_Add_delete_update_.Database.ds.Tables["Item_storg"].Select("sum_num = " + Convert.ToInt32(sum_Data[7]));

                    DataTable dt = new classs_table.Items_Tools().Fill_DataTable_Columns("dt_RP_footer_Item", new string[] { "Item_no"
                    ,"Item_name_en"
                    ,"unit_name"
                    ,"Date_Expit"
                    ,"qty"
                    ,"poins"
                    ,"qty_return"
                    ,"poins_return"
                    ,"sals_pric"
                    ,"sals_prodect"
                    ,"prift" });

                    DataTable dt_Date = new classs_table.Items_Tools().Fill_DataTable_Columns("dt_RP_footer_Data", new string[]{
                    "storg_name"
                    ,"footer_id"
                    ,"footer_num"
                    ,"type_sdad"
                    ,"total_begin"
                    ,"dicount_rate"
                    ,"dicount_value"
                    ,"total_return"
                    ,"total_alter"
                    ,"Date_footer"
                    ,"Empyl_name"
                    ,"supper_name"});

                    object[] ob_Total = DB_Add_delete_update_.Database.ds.Tables["Totel_Footer_prodeuct"].Rows.Find(sum_Data[9]).ItemArray;

                    dt_Date.Rows.Add(
                        vr.dgv_footer_prodect_All_RP_dgv.CurrentRow.Cells[2].Value,//المخزن
                        vr.dgv_footer_prodect_All_RP_dgv.CurrentRow.Cells[0].Value,//الكود
                        vr.dgv_footer_prodect_All_RP_dgv.CurrentRow.Cells[1].Value,//رثم الفاتورة
                        vr.dgv_footer_prodect_All_RP_dgv.CurrentRow.Cells[6].Value,//طريقة السداد
                        Convert.ToDouble(ob_Total[1]).ToString("N2"),//المجموع قبل
                        Convert.ToDouble(ob_Total[2]).ToString("N2"),//خصم نسبة
                        Convert.ToDouble(ob_Total[3]).ToString("N2"),//خصم قيمه
                        Convert.ToDouble(ob_Total[6]).ToString("N2"),//قيمة المرتجع
                        Convert.ToDouble(Convert.ToDouble(ob_Total[5]) - Convert.ToDouble(ob_Total[6])).ToString("N2"),//المجموع يعد ناقص القيمة المرتجع
                         vr.dgv_footer_prodect_All_RP_dgv.CurrentRow.Cells[4].Value,//تاريخ الفاتورة
                         vr.com_Emply_footer_All_RP.Text,//الموظف
                          vr.dgv_footer_prodect_All_RP_dgv.CurrentRow.Cells[3].Value);//المورد




                    
                    for (int i = 0; i < dr_Item_storg.Count(); i++)
                    {

                        object[] ob_Item = DB_Add_delete_update_.Database.ds.Tables["Item"].Rows.Find(dr_Item_storg[i][9]).ItemArray;
                        // جلب البيامات من جدول البيانات التي لاتتغير 
                        DataRow[] dr_DataItem_RP = DB_Add_delete_update_.Database.ds.Tables["RP_Data_Item_prodect"].Select("num_Item_storg =" + dr_Item_storg[i][0]);
                        
                        //جلب اسم الوحدة
                        object[] ob_unit = DB_Add_delete_update_.Database.ds.Tables["therpeutic_unite"].Rows.Find(dr_DataItem_RP[0][3]).ItemArray;
                        dt.Rows.Add(
                            dr_Item_storg[i][9]
                            , ob_Item[1]
                            , ob_unit[1]
                            , Convert.ToDateTime(dr_Item_storg[i][2]).ToString("d")
                            , dr_DataItem_RP[0][1]
                            , dr_DataItem_RP[0][2]
                            , dr_DataItem_RP[0][5]
                            , dr_DataItem_RP[0][6]
                            , Convert.ToDouble(dr_Item_storg[i][8]).ToString("N2")
                            , Convert.ToDouble(dr_DataItem_RP[0][4]).ToString("N2")
                            , Convert.ToDouble(Convert.ToDouble(dr_Item_storg[i][8]) - Convert.ToDouble(dr_DataItem_RP[0][4])).ToString("N2")); ;

                    }
                    //new classs_table.Items_Tools().show_CrystalReportView_Tow_DataTavle(dt, dt_Date, vr.CRV_footer_All_RP, "../../prodects/Report/CR_footer_prodects.rpt");

                    //RPP.lbl_2.Text= dt_Date.Rows[0][0].ToString();
                    RPP.lbl_2.Text = vr.dgv_footer_prodect_All_RP_dgv.CurrentRow.Cells[2].Value.ToString();//المخزن;
                    //RPP.xrLabel6.Text= dt_Date.Rows[0][2].ToString();
                    RPP.xrLabel6.Text = vr.dgv_footer_prodect_All_RP_dgv.CurrentRow.Cells[1].Value.ToString();//رثم الفاتورة
                    //RPP.lbl_4.Text= dt_Date.Rows[0][9].ToString();
                    RPP.lbl_4.Text = Convert.ToDateTime(vr.dgv_footer_prodect_All_RP_dgv.CurrentRow.Cells[4].Value).ToString("d");//تاريخ الفاتورة

                    //RPP.lbl_6.Text= dt_Date.Rows[0][11].ToString();
                    RPP.lbl_6.Text = vr.dgv_footer_prodect_All_RP_dgv.CurrentRow.Cells[3].Value.ToString();//

                    //RPP.xrLabel8.Text= dt_Date.Rows[0][10].ToString();
                    RPP.xrLabel8.Text = vr.com_Emply_footer_All_RP.Text;//الموظف

                    //RPP.xrLabel3.Text= dt_Date.Rows[0][7].ToString();
                    RPP.xrLabel3.Text = Convert.ToDouble(ob_Total[1]).ToString("N2");//المجموع قبل;//قيمة الفاتورة
                        
                    //RPP.xrLabel11.Text= dt_Date.Rows[0][5].ToString();
                    RPP.xrLabel11.Text = Convert.ToDouble(ob_Total[2]).ToString("N2");//خصم نسبة
                    //RPP.xrLabel13.Text= dt_Date.Rows[0][6].ToString();
                    RPP.xrLabel13.Text = Convert.ToDouble(ob_Total[3]).ToString("N2");//خصم قيمه
                    //RPP.xrLabel9.Text= dt_Date.Rows[0][7].ToString();//
                    RPP.xrLabel9.Text = Convert.ToDouble(ob_Total[6]).ToString("N2");//قيمة المرتجع
                    //RPP.xrLabel15.Text= dt_Date.Rows[0][8].ToString();
                    RPP.xrLabel15.Text = Convert.ToDouble(Convert.ToDouble(ob_Total[5]) - Convert.ToDouble(ob_Total[6])).ToString("N2");//المجموع يعد ناقص القيمة المرتجع
                                                                                                                                        //RPP.xrLabel1.Text= dt_Date.Rows[0][3].ToString();
                    RPP.xrLabel1.Text = vr.dgv_footer_prodect_All_RP_dgv.CurrentRow.Cells[6].Value.ToString();//طريقة السداد
                    new classs_table.Items_Tools().show_Dev_ReportView(dt, RPP);



                }
            }
        }

    }
}
