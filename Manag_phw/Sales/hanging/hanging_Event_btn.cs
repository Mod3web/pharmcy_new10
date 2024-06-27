using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Manag_ph.Sales
{
    class hanging_Event_btn
    {

        string name_Cline;
        double pric_sals_paind;
        double pric_sals_rest;
      public  hanging_Event_btn(string name_Cline, double pric_sals_paind, double pric_sals_rest)
        {
            this.name_Cline = name_Cline;
            this.pric_sals_paind = pric_sals_paind;
            this.pric_sals_rest = pric_sals_rest;
        }


        public void save_Footer_hanging()
        {// حفظ بيانات الفاتورة المعلقة
            var vr = Application.OpenForms["Main"] as Main;
            if (vr.dgv_sals_dgv.CurrentRow != null)
            {
                if (vr.rb_hanging_sals.Checked)
                {
                    int num_DateFoot = new classs_table.Items_Tools().AoutoNumber("Date_Footer_Sals", "num_foot_sals");
                    DB_Add_delete_update_.Database.ds.Tables["Date_Footer_Sals"].Rows.Add(
                        num_DateFoot,
                        num_DateFoot.ToString()
                        , DateTime.Now,
                        vr.txt_begin_Dicount_All_sals.Text,
                        vr.txt_Dicount_Rate_All_sals.Text,
                        vr.txt_Dicount_value_All_sals.Text,
                        vr.txt_end_Dico_All_sals.Text,
                        3,
                        vr.txt_Empoly_number.Caption,
                        vr.dgv_sals_dgv.RowCount,
                        vr.txt_id_storg_sels.Text,
                        vr.txt_id_casher.Text,
                        name_Cline,
                        pric_sals_paind,
                        pric_sals_rest,
                        vr.txt_note_footer_sals.Text,
                        false);
                    DB_Add_delete_update_.Database.update("Date_Footer_Sals");

                    // حفظ اصناف الفاتورة المعلقة
                    for (int i = 0; i < vr.dgv_sals_dgv.RowCount; i++)
                    {
                        DataGridViewComboBoxCell DGV_Prodect = vr.dgv_sals_dgv.Rows[i].Cells[4] as DataGridViewComboBoxCell;
                        int num_Item_Foot = new classs_table.Items_Tools().AoutoNumber("Item_footer_Sals", "num_Item_sals");
                        DB_Add_delete_update_.Database.ds.Tables["Item_footer_Sals"].Rows.Add(
                            num_Item_Foot,
                            vr.dgv_sals_dgv.Rows[i].Cells[1].Value,
                            num_DateFoot,
                            vr.dgv_sals_dgv.Rows[i].Cells[15].Value,
                            vr.dgv_sals_dgv.Rows[i].Cells[5].Value,
                            DGV_Prodect.Value,
                              vr.dgv_sals_dgv.Rows[i].Cells[9].Value,
                              vr.dgv_sals_dgv.Rows[i].Cells[10].Value,
                              vr.dgv_sals_dgv.Rows[i].Cells[11].Value,
                              vr.dgv_sals_dgv.Rows[i].Cells[12].Value,
                              vr.dgv_sals_dgv.Rows[i].Cells[13].Value,
                              false
                              );
                    }

                    DB_Add_delete_update_.Database.update("Item_footer_Sals");

                    MessageBox.Show("تم تعليق الفاتورة بنجاح","Ssccoful",MessageBoxButtons.OK,MessageBoxIcon.Information);

                    vr.dgv_sals_dgv.Rows.Clear();
                    vr.txt_note_footer_sals.Text = "";
                    vr.txt_begin_Dicount_All_sals.Text = "0.00";
                     vr.txt_Dicount_Rate_All_sals.Text = "0";
                    vr.txt_Dicount_value_All_sals.Text = "0.00";
                    vr.txt_end_Dico_All_sals.Text = "0.00";
                    

                }
            }
        }


    }
}
