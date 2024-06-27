using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Manag_ph.Item.forms
{
    public partial class Frm_Backup : Form
    {
        public Frm_Backup()
        {
            InitializeComponent();
        }

        public int show_button = 0;

        private void Btn_Browser_choose_backup_Click(object sender, EventArgs e)
        {
            //Manag_ph.Item.forms.Frm_Backup frmb = new Frm_Backup();
            //frmb.show_button = 2;
            if (show_button == 1)
            {
                FolderBrowserDialog fb = new FolderBrowserDialog();
                if (fb.ShowDialog() == DialogResult.OK)
                {
                    txt_backup_browser_txt.Text = fb.SelectedPath;
                    btn_create_Backup_btn.Enabled = true;
                }

            }
            else if (show_button == 2)
            {

                OpenFileDialog dlg = new OpenFileDialog();
                dlg.Filter = "SQL SERVER database backup files|*.bak";
                dlg.Title = "DATABASE RESTORE";
                if (dlg.ShowDialog() == DialogResult.OK)
                {

                    txt_backup_browser_txt.Text = dlg.FileName;
                    btn_Restore_Backup_btn.Enabled = true;
                }
            }
        }

        private void Btn_Restore_Backup_btn_Click(object sender, EventArgs e)
        {
            DB_Add_delete_update_.Database dd = new DB_Add_delete_update_.Database();
            if (txt_backup_browser_txt.Text != string.Empty)
            {
                bool typee = dd.Restor_BackUp(txt_backup_browser_txt);

                progressPanel1_Backup.Visible = true;
                dd.Restor_BackUp(txt_backup_browser_txt);
                if (typee)
                {
                    progressPanel1_Backup.Visible = false;
                    MessageBox.Show("تم إستعادة النسخة إحتياطية ");

                    txt_backup_browser_txt.Text = string.Empty;
                    //new Main().Fill_All_Data();
                }
                else
                {
                    progressPanel1_Backup.Visible = false;

                    MessageBox.Show("لم يتم إستعادة النسخة إحتياطية ");

                }


            }
            else
            {
                progressPanel1_Backup.Visible = false;


                btn_Restore_Backup_btn.Enabled = false;

                MessageBox.Show("يرجاء ادخال موقع النسخه الاحتياطية حتى يتم استعادتها");

            }
        }

        private void Btn_create_Backup_btn_Click(object sender, EventArgs e)
        {
            //DB_Add_delete_update_.Database ddd = new DB_Add_delete_update_.Database();

            DB_Add_delete_update_.Database dd = new DB_Add_delete_update_.Database();
            if (txt_backup_browser_txt.Text != string.Empty)
            {
                bool typee = dd.Create_BackUp(txt_backup_browser_txt);

                progressPanel1_Backup.Visible = true;
                dd.Create_BackUp(txt_backup_browser_txt);
                if (typee)

                {

                    progressPanel1_Backup.Visible = false;
                    MessageBox.Show("تم إنشاء نسخة إحتياطية ");
                    txt_backup_browser_txt.Text = string.Empty;

                }
                else
                {
                    progressPanel1_Backup.Visible = false;

                    MessageBox.Show("لم يتم إنشاء نسخة إحتياطية ");

                }


            }
            else
            {
                progressPanel1_Backup.Visible = false;


                btn_create_Backup_btn.Enabled = false;

                MessageBox.Show("يرجاء ادخال موقع حفظ النسخه الاحتياطية");

            }
            //if (txt_backup_browser_txt.Text != string.Empty)
            //{

            //    dd.BackUp(txt_backup_browser_txt);

            //}
            // else
            //{

            //    progressPanel1_Backup.Visible = false;


            //    btn_create_Backup_btn.Enabled = false;

            //    MessageBox.Show("يرجاء ادخال موقع حفظ النسخه الاحتياطية");
            //}

            ////////////////////////////////////////////////////
            //try
            //{
            //    SaveFileDialog sf = new SaveFileDialog();

            //    //FolderBrowserDialog sf = new FolderBrowserDialog();
            //    //string dbbackup = "Manag_Pharmacy" + DateTime.Now.ToString("yyyyMMddHHmm");
            //    sf.Filter = "Backup Files (*.Bak) |*.bak";

            //    DB_Add_delete_update_.Database dd = new DB_Add_delete_update_.Database();
            //    if (sf.ShowDialog() == DialogResult.OK)
            //    {
            //        //  pn_progress.Visible = true;
            //        progressPanel1_Backup.Visible = true;

            //        var result = await Task.Run(() => dd.BackUp(sf));
            //        if (result == true)
            //        {
            //            MessageBox.Show("تم النسخ الاحتياطي بنجاح");
            //            //    //pn_progress.Visible = false;
            //            progressPanel1_Backup.Visible = false;

            //        }
            //        else
            //        {
            //            MessageBox.Show("لم يتم النسخ الاحتياطي بنجاح يوجد خطاء , الرجاء تحديد مسار اخر , لا تحديد القرص (C) ");
            //            //    //pn_progress.Visible = false;
            //            progressPanel1_Backup.Visible = false;

            //        }
            //    }
            //}
            //catch
            //{

            //    MessageBox.Show("لم يتم النسخ الاحتياطي بنجاح يوجد خطاء , الرجاء تحديد مسار اخر , لا تحديد القرص (C) ");
            //    //        pn_progress.Visible = false;
            //    progressPanel1_Backup.Visible = false;

            //}
            ///////////////////////////////////////////////
        }

        private void Frm_Backup_Load(object sender, EventArgs e)
        {
            if (show_button == 1)
            {
                btn_create_Backup_btn.Visible = true;
                btn_Restore_Backup_btn.Visible = false;
            }
            else if (show_button == 2)
            {
                btn_Restore_Backup_btn.Visible = true;
                btn_create_Backup_btn.Visible = false;
            }
        }
    }
}
