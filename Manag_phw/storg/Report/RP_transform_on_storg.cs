using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CrystalDecisions.CrystalReports.Engine;
using Manag_ph.DB_Add_delete_update_;

namespace Manag_ph.storg.Report
{
    class RP_transform_on_storg
    {

        public void fill_Com_ofline(TextBox txt_num, TextBox txt_name)
        {
           DataRow dr_storg = DB_Add_delete_update_.Database.ds.Tables["Storg"].Rows.Find(txt_num.Text);
            if (dr_storg != null)
            {
                txt_name.Text = dr_storg[1].ToString();
            }
            else
            {
                MessageBox.Show("يرجاء التاكد من رقم المخزن","Error",MessageBoxButtons.OK,MessageBoxIcon.Information);
                txt_name.Text = "";
                txt_num.Focus();
                txt_num.SelectAll();

            }
        }



        public DataTable Fill_Column(string name,string[] Column, Type[] type)
        {
            DataTable dt = new DataTable(name);
            for (int i = 0; i < Column.Length; i++)
            {
                dt.Columns.Add(Column[i].ToString(), type[i]);
            }
            return dt;
        }

        public void view_Report()
        {
            var vr = Application.OpenForms["Main"] as Main;
            RPP_transform_on_storg RPP = new RPP_transform_on_storg();

            if (vr.dgv_RP_transform_dgv.CurrentRow != null)
            {
                DataTable dt = new storg.Report.RP_transform_on_storg().Fill_Column("dt_RP_trans_storg", new string[] { "Item_no", "name_Item", "name_unit", "qty", "Date_Expret", "sell_pric", "sell_prod" }, new Type[] { typeof(int), typeof(string), typeof(string), typeof(int), typeof(DateTime), typeof(double), typeof(double) });


                DataTable dt_DataTrans_RP = new DataTable("Data_Items_Transform_of_storg");
                dt_DataTrans_RP.Columns.Add("Date_trans");
                dt_DataTrans_RP.Columns.Add("Storg_trans");
                dt_DataTrans_RP.Columns.Add("Storg_yue_trans");
                dt_DataTrans_RP.Columns.Add("Emp_name");
                dt_DataTrans_RP.Columns.Add("sum_sell_prod", typeof(Double));
                dt_DataTrans_RP.Columns.Add("sum_sell_pric", typeof(Double));

                int num_sum_Trans_RP = Convert.ToInt32(vr.dgv_RP_transform_dgv.CurrentRow.Cells[7].Value);
                DataRow obj_sum_trans_RP = DB_Add_delete_update_.Database.ds.Tables["RP_sum_storg_Item"].Rows.Find(num_sum_Trans_RP);

                dt_DataTrans_RP.Rows.Add(Convert.ToDateTime(vr.dgv_RP_transform_dgv.CurrentRow.Cells[1].Value).ToString("d"), vr.dgv_RP_transform_dgv.CurrentRow.Cells[2].Value.ToString(), vr.dgv_RP_transform_dgv.CurrentRow.Cells[3].Value.ToString(), vr.dgv_RP_transform_dgv.CurrentRow.Cells[4].Value.ToString(), Convert.ToDouble(obj_sum_trans_RP[3]), Convert.ToDouble(obj_sum_trans_RP[2]));
                DataRow[] dr_Item_trans_RP = DB_Add_delete_update_.Database.ds.Tables["RP_Item_transform"].Select("num_RP_sum = " + num_sum_Trans_RP);
                if (dr_Item_trans_RP.Count() != 0)
                {
                    for (int i = 0; i < dr_Item_trans_RP.Count(); i++)
                    {
                        object[] ob_Item = DB_Add_delete_update_.Database.ds.Tables["Item"].Rows.Find(dr_Item_trans_RP[i][1]).ItemArray;
                        dt.Rows.Add(dr_Item_trans_RP[i][1], ob_Item[1], dr_Item_trans_RP[i][2], dr_Item_trans_RP[i][3], Convert.ToDateTime(dr_Item_trans_RP[i][4]).ToString("d"), Convert.ToDouble(dr_Item_trans_RP[i][5]).ToString("N0"), Convert.ToDouble(dr_Item_trans_RP[i][6]).ToString("N0"));
                    }

                    //ReportDocument rd = new ReportDocument();
                    //rd.Load("../../storg/Report/CrystalReport10.rpt");
                    //DataSet ds = new DataSet();
                    //ds.Tables.Add(dt);
                    //ds.Tables.Add(dt_DataTrans_RP);
                    //rd.SetDataSource(ds);
                    //vr.crystalReportViewer1.Refresh();
                    //vr.crystalReportViewer1.ReportSource = rd;
                    //vr.crystalReportViewer1.Refresh();
                    RPP.lbl_2.Text=dt_DataTrans_RP.Rows[0][0].ToString();
                    RPP.xrLabel6.Text=dt_DataTrans_RP.Rows[0][1].ToString();
                    RPP.lbl_4.Text=dt_DataTrans_RP.Rows[0][2].ToString();
                    RPP.lbl_6.Text=dt_DataTrans_RP.Rows[0][3].ToString();
                    new classs_table.Items_Tools().show_Dev_ReportView(dt, RPP);

                }

            }
        }


        public void Serch_Data_Trans()
        {
            var vr = Application.OpenForms["Main"] as Main;
           vr.dgv_RP_transform_dgv.Rows.Clear();

            DataRow[] dr_Data_Trans;
            if (vr.ch_Date_RP.Checked)
            {

                dr_Data_Trans = DB_Add_delete_update_.Database.ds.Tables["Data_Items_Transform_of_storg"].Select("(Date_trans >= '" + vr.dtp_Stort_tr_RP_one.Value + "' and Date_trans <= '" + vr.dtp_Stort_tr_RP_tow.Value + "') and (Storg_trans = " + vr.txt_num_storg_one.Text + " and Storg_yue_trans = " + vr.txt_num_storg_tow.Text + " )");
                if (dr_Data_Trans.Count() != 0)
                {
                    for (int i = 0; i < dr_Data_Trans.Count(); i++)
                    {
                        object[] obj_storg_one = DB_Add_delete_update_.Database.ds.Tables["Storg"].Rows.Find(dr_Data_Trans[i][3]).ItemArray;
                        object[] obj_storg_tow = DB_Add_delete_update_.Database.ds.Tables["Storg"].Rows.Find(dr_Data_Trans[i][4]).ItemArray;
                        object[] obj_Emp = DB_Add_delete_update_.Database.ds.Tables["TB_Employees"].Rows.Find(dr_Data_Trans[i][6]).ItemArray;
                        DataRow[] obj_sum_trans_RP = DB_Add_delete_update_.Database.ds.Tables["RP_sum_storg_Item"].Select("Trans_num = " + dr_Data_Trans[i][0]);

                        vr.dgv_RP_transform_dgv.Rows.Add(dr_Data_Trans[i][0], dr_Data_Trans[i][1], obj_storg_one[1], obj_storg_tow[1], obj_Emp[1], obj_sum_trans_RP[0][1], dr_Data_Trans[i][2], obj_sum_trans_RP[0][0]);
                    }
                }
                else
                {
                    MessageBox.Show("Noll");
                }
            }
            else
            {
                if (vr.txt_num_storg_one.Text.Trim() != string.Empty || vr.txt_num_storg_tow.Text.Trim() != string.Empty)
                {
                    dr_Data_Trans = DB_Add_delete_update_.Database.ds.Tables["Data_Items_Transform_of_storg"].Select("Storg_trans = " + vr.txt_num_storg_one.Text + " and Storg_yue_trans = " + vr.txt_num_storg_tow.Text);
                    if (dr_Data_Trans.Count() != 0)
                    {
                        for (int i = 0; i < dr_Data_Trans.Count(); i++)
                        {
                            object[] obj_storg_one = DB_Add_delete_update_.Database.ds.Tables["Storg"].Rows.Find(dr_Data_Trans[i][3]).ItemArray;
                            object[] obj_storg_tow = DB_Add_delete_update_.Database.ds.Tables["Storg"].Rows.Find(dr_Data_Trans[i][4]).ItemArray;
                            object[] obj_Emp = DB_Add_delete_update_.Database.ds.Tables["TB_Employees"].Rows.Find(dr_Data_Trans[i][6]).ItemArray;
                            DataRow[] obj_sum_trans_RP = DB_Add_delete_update_.Database.ds.Tables["RP_sum_storg_Item"].Select("Trans_num = " + dr_Data_Trans[i][0]);

                            vr.dgv_RP_transform_dgv.Rows.Add(dr_Data_Trans[i][0], dr_Data_Trans[i][1], obj_storg_one[1], obj_storg_tow[1], obj_Emp[1], obj_sum_trans_RP[0][1], dr_Data_Trans[i][2], obj_sum_trans_RP[0][0]);
                        }
                    }
                    else
                    {
                        MessageBox.Show("لايوجد بيانات");
                    }
                }
            }
        }
    }
}
