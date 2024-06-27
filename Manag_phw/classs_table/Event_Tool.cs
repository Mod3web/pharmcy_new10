using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data;
using DevExpress.XtraEditors;

namespace Manag_ph.classs_table
{
    class Event_Tool
    {

        // دالة تستخدم في حدث تكست تستقبل رقم الصنف وتبحث عن الاسم

        public void Get_Name_to_ID_Item_DownUp(KeyEventArgs e, TextEdit Id, TextEdit Name, String MessageError)
        {
            //var vr = Application.OpenForms["Main"] as Main;
            if (e.KeyCode==Keys.Enter)
            {
                if (Id.Text.Trim()!= string.Empty)
                {
                    DataRow dr = DB_Add_delete_update_.Database.ds.Tables["Item"].Rows.Find(Id.Text.Trim());
                    if (dr != null)
                    {
                        Name.Text = dr[2].ToString();
                    }
                    else
                    {
                        Id.Text = "";
                        Name.Text = "";
                    }

                }
                else
                {
                  Id.Text = "";
                     Name.Text = "";
                    MessageBox.Show(MessageError,"خطاء",MessageBoxButtons.OK,MessageBoxIcon.Error);
                }
            }
        }

        public void Get_Name_to_ID_Compny_DownUp(KeyEventArgs e, TextEdit Id, TextEdit Name, String MessageError)
        {
            //var vr = Application.OpenForms["Main"] as Main;
            if (e.KeyCode == Keys.Enter)
            {
                if (Id.Text.Trim() != string.Empty)
                {
                    DataRow dr = DB_Add_delete_update_.Database.ds.Tables["manufctur_company"].Rows.Find(Id.Text.Trim());
                    if (dr != null)
                    {
                        Name.Text = dr[1].ToString();
                    }
                    else
                    {
                        Id.Text = "";
                        Name.Text = "";
                    }

                }
                else
                {
                    Id.Text = "";
                    Name.Text = "";
                    MessageBox.Show(MessageError, "خطاء", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        public void Get_Name_to_ID_Cline_DownUp(KeyEventArgs e, TextEdit Id, TextEdit Name, String MessageError){
            //var vr = Application.OpenForms["Main"] as Main;
            if (e.KeyCode == Keys.Enter)
            {
                if (Id.Text.Trim() != string.Empty)
                {
                    DataRow dr = DB_Add_delete_update_.Database.ds.Tables["Clien"].Rows.Find(Id.Text.Trim());
                    if (dr != null)
                    {
                        Name.Text = dr[1].ToString();
                    }
                    else
                    {
                        Id.Text = "";
                        Name.Text = "";
                    }

                }
                else
                {
                    Id.Text = "";
                    Name.Text = "";
                    MessageBox.Show(MessageError, "خطاء", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }



    }
}
