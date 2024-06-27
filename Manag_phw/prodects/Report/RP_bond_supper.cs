using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Manag_ph.prodects.Report
{
    class RP_bond_supper
    {
        public void serch_bond_supper()
        {
            DataRow[] dr_Data_bond;


            string query = "";
            var vr = Application.OpenForms["Main"] as Main;
            vr.pic_bond_image.Image = null;
            vr.dgv_bond_RP_dgv.Rows.Clear();
            if (vr.ch_bond_supper.Checked)
            {
                if (vr.txt_name_supper_bond_one.Text != string.Empty)
                {
                    if (vr.txt_bond_number.Text.Trim() != string.Empty)
                    {
                        query += "supper_num = " + vr.txt_num_supper_bond_one.Text + " and num_bond = " + vr.txt_bond_number.Text.Trim();
                    }
                }
                else
                {
                    MessageBox.Show("يرجاء ادخال المورد", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    vr.txt_num_supper_bond_one.Focus();
                    vr.txt_num_supper_bond_one.SelectAll();
                    vr.txt_name_supper_bond_one.Clear();
                    return;


                }
            }
            else
            {
                query = "(Date_input >= '" + vr.dtp_bond_RP_one.Value + "' and Date_input <= '" + vr.dtp_bond_RP_tow.Value + "')";

                if (vr.ch_En_Emp_bond_Report.Checked)
                {
                    if (vr.txt_num_Emp_bond.Text.Trim() != string.Empty && vr.txt_name_Emp_bond.Text.Trim() != string.Empty)
                    {

                        query += " and Emp_num = " + vr.txt_num_Emp_bond.Text;
                    }
                    else
                    {
                        MessageBox.Show("يرجاء التحقق من رقم  الموظف", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }

                if (vr.ch_En_supper_bond_Report.Checked)
                {
                    if (vr.txt_name_supper_bond_tow.Text.Trim() != string.Empty && vr.txt_num_supper_bond_tow.Text.Trim() != string.Empty)
                    {
                        query += " and supper_num = " + vr.txt_num_supper_bond_tow.Text;
                    }
                    else
                    {
                        MessageBox.Show("يرجاء التحقق من رقم المورد", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }
            }
            dr_Data_bond = DB_Add_delete_update_.Database.ds.Tables["RP_pay_supper"].Select(query);
            for (int i = 0; i < dr_Data_bond.Count(); i++)
            {
                DataRow dr_Emp = DB_Add_delete_update_.Database.ds.Tables["TB_Employees"].Rows.Find(dr_Data_bond[i][6]);
                DataRow dr_supper = DB_Add_delete_update_.Database.ds.Tables["Supplier"].Rows.Find(dr_Data_bond[i][1]);
                vr.dgv_bond_RP_dgv.Rows.Add(
                    dr_Data_bond[i][0]
                    , dr_Emp[1],
                    dr_supper[1],
                    Convert.ToDateTime(dr_Data_bond[i][5]).ToString("d"),
                    dr_Data_bond[i][2],
                    Convert.ToDateTime(dr_Data_bond[i][4]).ToString("d"),
                    Convert.ToDouble(dr_Data_bond[i][3]).ToString("N2"),
                    Convert.ToDouble(dr_Data_bond[i][7]).ToString("N2"),
                    Convert.ToDouble(dr_Data_bond[i][8]).ToString("N2"),
                    dr_Data_bond[i][9]); ;
            }

        }

        public void Select_ching_dgv()
        {
            var vr = Application.OpenForms["Main"] as Main;

            if (vr.dgv_bond_RP_dgv.CurrentRow != null)
            {
                string name_Image = vr.dgv_bond_RP_dgv.CurrentRow.Cells[0].Value + ".png";


                if (!File.Exists(name_Image))
                {
                    File.WriteAllBytes(name_Image, (byte[])vr.dgv_bond_RP_dgv.CurrentRow.Cells[9].Value);
                }

                FileStream fs = File.Open(name_Image, FileMode.Open);
                Bitmap bt = new Bitmap(fs);
                fs.Close();
                vr.pic_bond_image.Image = bt;


            }
        }

        public void show_Report()
        {
            var vr = Application.OpenForms["Main"] as Main;
            RPP_bond_supper RPP = new RPP_bond_supper();
            DataTable dt = new classs_table.Items_Tools().Fill_DataTable_Columns("dt_RP_bond_supper_All", new string[]
               {
"pay_num"
,"name_emp"
,"name_supper"
,"date_create"
,"number_bond"
,"date_bond"
,"sals_bond"
,"cirtor"
,"date_cre_one"
,"date_cre_tow"
,"image_bond"
,"sals_string" });

            dt.Columns[10].DataType = typeof(byte[]);

            if (!vr.ch_bond_supper.Checked)
            {
                for (int i = 0; i < vr.dgv_bond_RP_dgv.RowCount; i++)
                {
                    dt.Rows.Add
                        (
                        vr.dgv_bond_RP_dgv.Rows[i].Cells[0].Value,
                        vr.dgv_bond_RP_dgv.Rows[i].Cells[1].Value,
                        vr.dgv_bond_RP_dgv.Rows[i].Cells[2].Value,
                        vr.dgv_bond_RP_dgv.Rows[i].Cells[3].Value,
                        vr.dgv_bond_RP_dgv.Rows[i].Cells[4].Value,
                        vr.dgv_bond_RP_dgv.Rows[i].Cells[5].Value,
                        vr.dgv_bond_RP_dgv.Rows[i].Cells[6].Value,
                        vr.dgv_bond_RP_dgv.Rows[i].Cells[7].Value,
                        vr.dtp_bond_RP_one.Value.ToString("d"),
                        vr.dtp_bond_RP_tow.Value.ToString("d"),
                        vr.dgv_bond_RP_dgv.Rows[i].Cells[9].Value,
                        MOJ.General.ConvertToLetters(Convert.ToDecimal(Convert.ToDouble(vr.dgv_bond_RP_dgv.Rows[i].Cells[6].Value)), "ريال", "ريال")

                        );
                }
            }


            new classs_table.Items_Tools().show_CrystalReportView(dt, vr.CRV_bond_supper, "../../prodects/Report/CR_bond_supper.rpt");
            new classs_table.Items_Tools().show_Dev_ReportView(dt, RPP);




        }
    }
}
