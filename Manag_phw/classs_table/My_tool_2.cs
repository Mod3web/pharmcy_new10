using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Manag_ph.classs_table
{
    class My_tool_2
    {


        // دالة لاضافة سبب الحركة
       public void fill_com_alhrca(ComboBox com_sbb_alhrcka)
        {
            com_sbb_alhrcka.DataSource = DB_Add_delete_update_.Database.ds.Tables["Reasons_disco_Add"];
            com_sbb_alhrcka.DisplayMember = "name_Reasons";
            com_sbb_alhrcka.ValueMember = "num_Reasons";
        }
    }
}
