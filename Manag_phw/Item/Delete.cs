using Manag_ph.classs_table;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Manag_ph.Item
{
    class Delete
    {
        public void Delete_Item()
        {
            var vr = Application.OpenForms["Main"] as Main;
            //if (vr.dgvm_dgv.CurrentRow != null)
            //{
            //    DialogResult dr = MessageBox.Show("هل تريد بالفعل حذف الصنف المحدد", "حذف", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2);
            //    if (dr == DialogResult.Yes)
            //    {
            //        int id = (int)vr.dgvm_dgv.CurrentRow.Cells[0].Value;
            //       DataRow[] dr_bar = DB_Add_delete_update_.Database.ds.Tables["barcode"].Select("Item_no =" + id);
            //        if (dr_bar.Count() != 0)
            //        {
            //            object[] ob_bar = dr_bar[0].ItemArray;
            //            new classs_table.Items_Tools().Delete_Rows_Table_Database("barcode", ob_bar[0].ToString()) ;
            //        }


            //        DataRow[] dealings = DB_Add_delete_update_.Database.ds.Tables["dealings"].Select("Item_num =" + id);
            //        object[] ob_deal = dealings[0].ItemArray;
            //        new classs_table.Items_Tools().Delete_Rows_Table_Database("dealings", ob_deal[0].ToString());


            //        new classs_table.Items_Tools().Delete_Rows_Table_Database("Item", id.ToString());



            //        //DB_Add_delete_update_.Database.ds.Tables["Item"].Rows.Remove(DB_Add_delete_update_.Database.ds.Tables["Item"].Rows.Find(id));
            //        //DataRow[] m = DB_Add_delete_update_.Database.dt_View_Item.Select("[كود الصنف] = " + id);
            //        //DB_Add_delete_update_.Database.dt_View_Item.Rows.Remove(m[0]);
            //        //DB_Add_delete_update_.Database.update("Item");
            //        //MessageBox.Show("تم الحذف بنجاح", "حذف", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //        ////حذف الاسعار
            //        //new Items_Tools().insertItem(1, "Delete_pric", "@Id_Item ", id, SqlDbType.Int);
            //        ////حذف الوحدات من الكدول الفرعي للوحدات
            //        //new Items_Tools().insertItem(1, "Delete_multi_unit", "@Id_Item", id, SqlDbType.Int);
            //        ////حذف الصنف 
            //        //new Items_Tools().insertItem(1, "Delete_Item", "@Item_no", id, SqlDbType.Int);

            //    }
            //}
        }

    }
}
