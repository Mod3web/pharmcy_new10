using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Manag_ph.Employlee.job
{
    class Update_jobs
    {
         public void Update_to_page_job()
        {
            var n = Application.OpenForms["Main"] as Main;

            n.txt_num_Job.Clear();
            n.txt_name_job_AR.Clear();
            n.txt_name_job_EN.Clear();

            n.btn_save_updata_job_btn.Enabled = true;
            int x = Convert.ToInt32(n.DGV_JOBS_dgv.CurrentRow.Cells[0].Value);
            DataRow[] drow = DB_Add_delete_update_.Database.ds.Tables["tb_Jobs"].Select("id_Job = " + x);

            n.txt_num_Job.Text = drow[0][0].ToString();
            n.txt_name_job_AR.Text = drow[0][1].ToString();
            n.txt_name_job_EN.Text = drow[0][2].ToString();
        }

         public void save_updata_job()
        {
            var n = Application.OpenForms["Main"] as Main;

            int id = Convert.ToInt32(n.txt_num_Job.Text);

            DataRow daRow = DB_Add_delete_update_.Database.ds.Tables["tb_Jobs"].Rows.Find(id);
            int dr_ofindex = DB_Add_delete_update_.Database.ds.Tables["tb_Jobs"].Rows.IndexOf(daRow);


            //DB_Add_delete_update_.Database.ds.Tables["tb_Jobs"].Rows[dr_ofindex][0] = txt_num_Job.Text;
            DB_Add_delete_update_.Database.ds.Tables["tb_Jobs"].Rows[dr_ofindex][1] = n.txt_name_job_AR.Text;
            DB_Add_delete_update_.Database.ds.Tables["tb_Jobs"].Rows[dr_ofindex][2] = n.txt_name_job_EN.Text;
            DB_Add_delete_update_.Database.update("tb_Jobs");


            n.txt_num_Job.Clear();
            n.txt_num_Job.Text = Convert.ToString(Convert.ToInt32(DB_Add_delete_update_.Database.ds.Tables["tb_Jobs"].Compute("max(id_Job)", "")) + 1);

            n.txt_name_job_AR.Clear();
            n.txt_name_job_EN.Clear();
            n.btn_save_updata_job_btn.Enabled = false;
        }

    }
}
