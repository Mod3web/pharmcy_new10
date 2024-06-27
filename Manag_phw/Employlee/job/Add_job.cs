using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Manag_ph.Employlee.job
{
    class Add_job
    {
         public void save_job()
        {//داله لاضافه وظيفه
            var n = Application.OpenForms["Main"] as Main;


            int num_job = Convert.ToInt32(n.txt_num_Job.Text);
            string name_AB_job = n.txt_name_job_AR.Text;
            string name_EN_job = n.txt_name_job_EN.Text;

            if (n.txt_name_job_AR == null)
            {
                MessageBox.Show("يرجاء ادخال اسم الوظيفة بالعربي ! ", "رساله خطاء", MessageBoxButtons.OK);
                n.txt_name_job_AR.Focus();
            }
            if (n.txt_name_job_EN == null)
            {
                MessageBox.Show("يرجاء ادخال اسم الوظيفة بالانجليزي ! ", "رساله خطاء", MessageBoxButtons.OK);
                n.txt_name_job_EN.Focus();

            }



            DB_Add_delete_update_.Database.ds.Tables["tb_Jobs"].Rows.Add(num_job, name_AB_job, name_EN_job);
            DB_Add_delete_update_.Database.update("tb_Jobs");

            n.txt_num_Job.Clear();
            n.txt_num_Job.Text = Convert.ToString(Convert.ToInt32(DB_Add_delete_update_.Database.ds.Tables["tb_Jobs"].Compute("max(id_Job)", "")) + 1);

            n.txt_name_job_AR.Clear();
            n.txt_name_job_EN.Clear();
            n.btn_save_job_btn.Enabled = false;
        }
    }
}
