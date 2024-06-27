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
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }
        bool clo = false;
        private void Form4_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (clo == false)
            {

                Application.Exit();
            }
            else
            {
                Close();
            }
        }

        private void Btn_Add_Click(object sender, EventArgs e)
        {
            if (txt_username.Text.Trim() != string.Empty || txt_password.Text.Trim() != string.Empty)
            {

                DataRow[] dr_log = DB_Add_delete_update_.Database.ds.Tables["TB_LOGIN_EMP"].Select("UserName = '" + txt_username.Text.Trim() + "' and passowrd_one = '" + txt_password.Text.Trim() + "'");
                if (dr_log.Count() != 0)
                {
                    DataRow dr_Emp = DB_Add_delete_update_.Database.ds.Tables["TB_Employees"].Rows.Find(dr_log[0][4]);
                    if (Convert.ToBoolean(dr_Emp[14]))
                    {
                        clo = true;
                        var n = Application.OpenForms["Main"] as Main;
                        n.txt_user_Emp.Caption = dr_log[0][1].ToString();
                        n.txt_user_id_Emp.Caption = dr_log[0][0].ToString();
                        n.txt_Empoly_number.Caption = dr_log[0][4].ToString();
                        n.WindowState = FormWindowState.Maximized;
                        String Query = "id_login = " + dr_log[0][0].ToString() + " And " + "UserName = '" + dr_log[0][1].ToString() + "' And isLoock =" + false;
                        DataRow[] dr_Cheack_user = DB_Add_delete_update_.Database.ds.Tables["Unlook_Box"].Select(Query);
                        if (dr_Cheack_user.Count() == 0)
                        {
                            int num_unlock_box = new classs_table.Items_Tools().AoutoNumber("Unlook_Box", "unloock_num");
                            DB_Add_delete_update_.Database.ds.Tables["Unlook_Box"].Rows.Add(
                                num_unlock_box,
                                DateTime.Now,
                                dr_log[0][0].ToString(),
                                dr_log[0][1].ToString(),
                                0,
                                0,
                                0,
                                0,
                                0,
                                0,
                                0,
                                0,
                                "",
                                false,
                                null);
                            DB_Add_delete_update_.Database.update("Unlook_Box");
                            DB_Add_delete_update_.Database.ds.Tables["unlock_ditils"].Rows.Add(
                                new classs_table.Items_Tools().AoutoNumber("unlock_ditils", "History_num"),
                                num_unlock_box,
                                0.00,
                                0.00,
                                0.00,
                                0.00,
                                0.00,
                                0.00);
                            DB_Add_delete_update_.Database.update("unlock_ditils");
                        }
                        Close();
                    }
                    else
                    {
                        MessageBox.Show("تم ايقاف التعامل معاء  الموظف");
                        Application.Exit();
                    }
                }
                else
                {
                    MessageBox.Show("يرجاء التاكد من المدخلات ");
                    return;
                }
            }

            else
            {
                MessageBox.Show("يرجاء ملاء الحقول");
                return;
            }
        }

        private void Form4_Load(object sender, EventArgs e)
        {

        }

        private void Txt_username_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txt_password.Focus();
                txt_password.SelectAll();
                txt_password.Select();
            }
        }

        private void Txt_password_KeyDown(object sender, KeyEventArgs e)
        {

            if (e.KeyCode == Keys.Enter)
            {
                btn_Add_btn.PerformClick();
            }

        }
    }
}

