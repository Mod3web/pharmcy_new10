using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Manag_ph.storg.Report
{
    class RP_short_falls
    {

        
        public void search_short()
        {
            
            DataTable dt_search = new DataTable();

            dt_search.Columns.Add("الكود");
            dt_search.Columns.Add("اسم الصنف (AR)");
            dt_search.Columns.Add("اسم الصنف (EN)");
            dt_search.Columns.Add("الوحدة");
            dt_search.Columns.Add("الرصيد");
            dt_search.Columns.Add("سعر الشراء");
            dt_search.Columns.Add("سعر البيع");


            var vr = Application.OpenForms["Main"] as Main;
            DataRow[] dr_Item_storg = DB_Add_delete_update_.Database.ds.Tables["Item_storg"].Select();
            for (int i = 0; i < dr_Item_storg.Count(); i++)
            {
                DataRow[] dr_dealings = DB_Add_delete_update_.Database.ds.Tables["dealings"].Select("Item_num ="+ dr_Item_storg[i][9]);
                if (Convert.ToInt32(dr_Item_storg[i][1]) <= Convert.ToInt32(dr_dealings[0][2]) )
                {
                  DataRow dr_Item =  DB_Add_delete_update_.Database.ds.Tables["Item"].Rows.Find(dr_Item_storg[i][9]);
                    DataRow dr_unit = DB_Add_delete_update_.Database.ds.Tables["therpeutic_unite"].Rows.Find(dr_Item_storg[i][10]);
                    dt_search.Rows.Add(dr_Item[0], dr_Item[1], dr_Item[2], dr_unit[1]);
                }
            }
          


        }
    }
}
