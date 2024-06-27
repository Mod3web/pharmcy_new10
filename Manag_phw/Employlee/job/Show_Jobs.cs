using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Manag_ph.Employlee.job
{
    class Show_Jobs
    {

         public void show_jobs_TB()
        {
            var n = Application.OpenForms["Main"] as Main;

            //n.View_And_serch.Hide();
            //n.update_Item.Hide();
            //n.Add_Item.Hide();
            //n.Add_Storg.Hide();
            //n.open_balanc_storg.Hide();
            //n.TransFormation.Hide();
            //n.bdails_page.Hide();

            //n.update_Item_storg.Hide();
            //n.Emplyes_page.Hide();
            //n.Emplyes_page.Hide();
            //n.JobsPage.Show();

            n.DGV_JOBS_dgv.DataSource = DB_Add_delete_update_.Database.ds.Tables["tb_Jobs"];
            n.DGV_JOBS_dgv.Refresh();
        }
    }
}
