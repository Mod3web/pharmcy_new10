using Manag_ph.classs_table;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Manag_ph.storg
{
    class Storg
    {

        // حذ بيانات ادخال المخازن
        public void ClearData_storg()
        {

            var vr = Application.OpenForms["Main"] as Main;
            vr.dgv_storg_dgv.ClearSelection();
            int Autonum_storg = 1;
            if (DB_Add_delete_update_.Database.ds.Tables["Storg"].Rows.Count != 0)
            {
                Autonum_storg = Convert.ToInt32(DB_Add_delete_update_.Database.ds.Tables["Storg"].Compute("max(Storg_no)", "")) + 1;

            }
            else
            {
            Autonum_storg = 1;
            }

            vr.txt_num_storg.Text = Autonum_storg.ToString();
            vr.txt_Storg_name_ar.Clear();
            vr.txt_Storg_name_en.Clear();
            vr.txt_Addrs_storg.Clear();
            vr.txt_Am_storg.Clear();
            vr.txt_Pho_storg.Clear();

            vr.btn_Adds_storg_btn.Enabled = true;
            vr.btn_Delete_storg_btn.Enabled = false;
            vr.btn_update_storg_btn.Enabled = false;

            vr.txt_Storg_name_ar.Focus();
            vr.txt_Storg_name_ar.SelectAll();
        }

        // حذف محزن
        public void Delete_Storg()
        {
            var vr = Application.OpenForms["Main"] as Main;
            int id_storg = (int)vr.dgv_storg_dgv.CurrentRow.Cells[0].Value;
            DataRow[] dr_storg = DB_Add_delete_update_.Database.ds.Tables["Storg"].Select("Storg_no = " + id_storg);
            MessageBox.Show(id_storg + "");
            DB_Add_delete_update_.Database.ds.Tables["Storg"].Rows.Remove(dr_storg[0]);
            new Items_Tools().insertItem(1, "Delete_Storg", "@Storg_num", id_storg, SqlDbType.Int);
        }

        public void update_Storg()
        {
            var vr = Application.OpenForms["Main"] as Main;
            if (true)
            {


                int a = (int)vr.dgv_storg_dgv.CurrentRow.Cells[0].Value;
                DataRow dr_Item = DB_Add_delete_update_.Database.ds.Tables["Storg"].Rows.Find(a);
                int dr_Ite = DB_Add_delete_update_.Database.ds.Tables["Storg"].Rows.IndexOf(dr_Item);


                DB_Add_delete_update_.Database.ds.Tables["Storg"].Rows[dr_Ite][1] = vr.txt_Storg_name_ar.Text;
                DB_Add_delete_update_.Database.ds.Tables["Storg"].Rows[dr_Ite][2] = vr.txt_Storg_name_en.Text;
                DB_Add_delete_update_.Database.ds.Tables["Storg"].Rows[dr_Ite][3] = vr.txt_Addrs_storg.Text;
                DB_Add_delete_update_.Database.ds.Tables["Storg"].Rows[dr_Ite][4] = vr.txt_Am_storg.Text;
                DB_Add_delete_update_.Database.ds.Tables["Storg"].Rows[dr_Ite][5] = vr.txt_Pho_storg.Text;

                DB_Add_delete_update_.Database.update("Storg");

            }
        }


        }
}
