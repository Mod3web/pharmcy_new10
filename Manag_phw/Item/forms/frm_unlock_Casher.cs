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
    public partial class frm_unlock_Casher : Form
    {
        public frm_unlock_Casher()
        {
            InitializeComponent();
        }


        void Fill_fund()
        {
            DataTable dt = new DataTable("d");
            dt.Columns.Add("fund_num");
            dt.Columns.Add("fund_name_ar");


            for (int i = 0; i < DB_Add_delete_update_.Database.ds.Tables["account_fund"].Rows.Count; i++)
            {
                if (!Convert.ToBoolean(DB_Add_delete_update_.Database.ds.Tables["account_fund"].Rows[i][3]))
                {
                    dt.Rows.Add(DB_Add_delete_update_.Database.ds.Tables["account_fund"].Rows[i][0], DB_Add_delete_update_.Database.ds.Tables["account_fund"].Rows[i][1]);
                }

            }
            com_transform_fund.DataSource = dt;
            com_transform_fund.DisplayMember = "fund_name_ar";
            com_transform_fund.ValueMember = "fund_num";
        }
        private void Frm_unlock_Casher_Load(object sender, EventArgs e)
        {

            var vr = Application.OpenForms["Main"] as Main;
            String Query = "id_login = " + vr.txt_user_id_Emp.Caption + " And " + "UserName = '" + vr.txt_user_Emp.Caption + "' And isLoock =" + false;
            DataRow[] dr_Cheack_user = DB_Add_delete_update_.Database.ds.Tables["Unlook_Box"].Select(Query);
            object[] ob_Emp = DB_Add_delete_update_.Database.ds.Tables["TB_LOGIN_EMP"].Rows.Find(new object[] { vr.txt_user_id_Emp.Caption, vr.txt_user_Emp.Caption }).ItemArray;
            object[] ob_Casher = DB_Add_delete_update_.Database.ds.Tables["casher"].Rows.Find(ob_Emp[5]).ItemArray;
            lbl_Name_Casher.Text = ob_Casher[1].ToString();

            if (dr_Cheack_user.Count() != 0)
            {
                txt_user_begin.Text = vr.txt_user_Emp.Caption;
                dtp_begin_Date.Value = Convert.ToDateTime(dr_Cheack_user[0][1]);

                if (!String.IsNullOrEmpty(dr_Cheack_user[0][4].ToString()))
                {
                    price_begin.Text = Convert.ToDouble(dr_Cheack_user[0][4]).ToString("N2");
                }
                else
                {
                    price_begin.Text = "0.00";
                }


                DataRow[] dr_test = DB_Add_delete_update_.Database.ds.Tables["TB_LOGIN_EMP"].Select();
                DataTable dt = new DataTable("jol");
                dt.Columns.Add("id_login");
                dt.Columns.Add("UserName");
                if (dr_test != null)
                {

                    for (int i = 0; i < dr_test.Count(); i++)
                    {
                        if (!String.IsNullOrEmpty(dr_test[i][5].ToString()))
                        {
                            dt.Rows.Add(dr_test[i][0], dr_test[i][1]);

                        }

                    }
                    com_Name_user_new.DataSource = dt;
                    com_Name_user_new.DisplayMember = "UserName";
                    com_Name_user_new.ValueMember = "id_login";
                }
                Fill_fund();
            }
            else
            {
                MessageBox.Show("يرجاء اعادة تسجيل الدخول ");
            }


        }


        String Calc_Recoiedr_Value()
        {
            var vr = Application.OpenForms["Main"] as Main;
            String Query = "id_login = " + vr.txt_user_id_Emp.Caption + " And " + "UserName = '" + vr.txt_user_Emp.Caption + "' And isLoock =" + false;
            DataRow[] dr_Cheack_user = DB_Add_delete_update_.Database.ds.Tables["Unlook_Box"].Select(Query);

            DataRow[] dr_ditils = DB_Add_delete_update_.Database.ds.Tables["unlock_ditils"].Select("num_unlock_box = " + dr_Cheack_user[0][0]);
            object[] ob_unlock = DB_Add_delete_update_.Database.ds.Tables["unlock_ditils"].Rows.Find(dr_Cheack_user[0][0]).ItemArray;
            string totile_All_digtal = "";
            if (dr_ditils.Count() != 0)
            {
                string sum_supply = Convert.ToDouble(Convert.ToDouble(dr_Cheack_user[0][4])+ Convert.ToDouble(ob_unlock[4]) + Convert.ToDouble(dr_ditils[0][5]) + Convert.ToDouble(dr_ditils[0][4]) + Convert.ToDouble(dr_ditils[0][3])).ToString("N2");
                string txt_cashe = Convert.ToDouble(Convert.ToDouble(dr_ditils[0][2]) + Convert.ToDouble(dr_ditils[0][6]) + Convert.ToDouble(dr_ditils[0][7])).ToString("N2");
                totile_All_digtal = Convert.ToDouble(Convert.ToDouble(sum_supply) - Convert.ToDouble(txt_cashe)).ToString("N2");
            }
            return totile_All_digtal;
        }

        void update_Value_Casher_And_Fund()
        {
            var vr = Application.OpenForms["Main"] as Main;
            object[] ob_Log = DB_Add_delete_update_.Database.ds.Tables["TB_LOGIN_EMP"].Rows.Find(new object[] { vr.txt_user_id_Emp.Caption, vr.txt_user_Emp.Caption }).ItemArray;
            object[] ob_Cahser = DB_Add_delete_update_.Database.ds.Tables["casher"].Rows.Find(ob_Log[5]).ItemArray;
            object[] ob_Casher_Acco = DB_Add_delete_update_.Database.ds.Tables["casher_account"].Rows.Find(ob_Cahser[5]).ItemArray;


            ob_Casher_Acco[1] = Convert.ToDouble(Convert.ToDouble(ob_Casher_Acco[1])- Convert.ToDouble(txt_Report_Sales_Cline_num.Text));
            if (Convert.ToDouble(ob_Casher_Acco[1])<0)
            {
                MessageBox.Show("القيمة الفعلية المدخلة اقل من الموجود في الدرج");
                return;
            }
            else
            {
                new classs_table.Items_Tools().update_Rows_Table_Database("casher_account", ob_Casher_Acco[0].ToString(), ob_Casher_Acco);

                object[] od_Account_found = DB_Add_delete_update_.Database.ds.Tables["account_fund"].Rows.Find(com_transform_fund.SelectedValue).ItemArray;
                if (Convert.ToBoolean(od_Account_found[3]))
                {
                    MessageBox.Show("الصندوق تم ايقاف التعامل معة");
                    return;
                }
                else
                {
                    object[] od_Fund_Sales = DB_Add_delete_update_.Database.ds.Tables["fund_sals"].Rows.Find(od_Account_found[4]).ItemArray;
                    od_Fund_Sales[1] = Convert.ToDouble(Convert.ToDouble(od_Fund_Sales[1]) + Convert.ToDouble(txt_TransForm_Amound.Text));
                    new classs_table.Items_Tools().update_Rows_Table_Database("fund_sals", od_Fund_Sales[0].ToString(), od_Fund_Sales);
                }
             


            }


        }
        void updateDataOlduser()
        {
            var vr = Application.OpenForms["Main"] as Main;
            String Query = "id_login = " + vr.txt_user_id_Emp.Caption + " And " + "UserName = '" + vr.txt_user_Emp.Caption + "' And isLoock =" + false;
            DataRow[] dr_Cheack_user = DB_Add_delete_update_.Database.ds.Tables["Unlook_Box"].Select(Query);
            object[] ob_Emp = DB_Add_delete_update_.Database.ds.Tables["TB_LOGIN_EMP"].Rows.Find(new object[] { vr.txt_user_id_Emp.Caption, vr.txt_user_Emp.Caption }).ItemArray;
            object[] ob_Casher = DB_Add_delete_update_.Database.ds.Tables["casher"].Rows.Find(ob_Emp[5]).ItemArray;
            object[] ob_unlock_box = DB_Add_delete_update_.Database.ds.Tables["Unlook_Box"].Rows.Find(dr_Cheack_user[0][0]).ItemArray;
            ob_unlock_box[5] = ob_Casher[0];// تعديل رقم الكاشير
            ob_unlock_box[6] = txt_Report_Sales_Cline_num.Text;// المبلغ الموجود في الكاشير
            ob_unlock_box[7] = txt_TransForm_Amound.Text;// المبلغ المحول
            ob_unlock_box[8] = com_transform_fund.SelectedValue;// رقم الصندوق
            ob_unlock_box[9] = txt_reast_Box.Text;// الباقي في الكاشير

            ob_unlock_box[10] = com_Name_user_new.SelectedValue;// رقم المستخدم المستلم
            ob_unlock_box[11] = Calc_Recoiedr_Value();// المطلوب من المستخدم
            ob_unlock_box[12] = txt_item_nots.Text;// الملاحظة
            ob_unlock_box[13] = true;// تم الاغلاق
            ob_unlock_box[14] = DateTime.Now;// تم الاغلاق
            new classs_table.Items_Tools().update_Rows_Table_Database("Unlook_Box", ob_unlock_box[0].ToString(), ob_unlock_box);
        }
        private void Button86_Click(object sender, EventArgs e)
        {
            var vr = Application.OpenForms["Main"] as Main;

            String Query = "id_login = " + vr.txt_user_id_Emp.Caption + " And " + "UserName = '" + vr.txt_user_Emp.Caption + "' And isLoock =" + false;
            DataRow[] dr_Cheack_user = DB_Add_delete_update_.Database.ds.Tables["Unlook_Box"].Select(Query);
            if (dr_Cheack_user.Count() != 0)
            {
                if (txt_Report_Sales_Cline_num.Text.Trim() == string.Empty)
                {
                    MessageBox.Show("يرجاء التحقق من النقدية");
                    return;
                }
                if (txt_TransForm_Amound.Text.Trim() == string.Empty)
                {
                    MessageBox.Show("يرجاء التحقق من المبلغ المحول");
                    return;
                }
                if (txt_TransForm_Amound.Text.Trim() == string.Empty)
                {
                    MessageBox.Show("يرجاء التحقق من المبلغ المحول");
                    return;
                }
                if (Convert.ToDouble(txt_TransForm_Amound.Text)> Convert.ToDouble(txt_Report_Sales_Cline_num.Text))
                {
                    MessageBox.Show("المبلغ المحول اكبر من المبلغ الفعلي");
                    return;
                }


                String Query_new_user = "id_login = " + com_Name_user_new.SelectedValue + " And " + "UserName = '" + com_Name_user_new.Text + "' And isLoock =" + false;
                DataRow[] dr_Cheack_user_new_user = DB_Add_delete_update_.Database.ds.Tables["Unlook_Box"].Select(Query_new_user);
                object[] Cheack_Passeword = DB_Add_delete_update_.Database.ds.Tables["TB_LOGIN_EMP"].Rows.Find(new object[] { com_Name_user_new.SelectedValue, com_Name_user_new.Text }).ItemArray;
                if (dr_Cheack_user_new_user.Count() == 0)
                {
                    if (Cheack_Passeword[2].ToString() == txt_password_user_new.Text.Trim())
                    {
                        updateDataOlduser();// دالة تعديل بيانات المستخدم القديم


                        int num_unlock_box = new classs_table.Items_Tools().AoutoNumber("Unlook_Box", "unloock_num");
                        DB_Add_delete_update_.Database.ds.Tables["Unlook_Box"].Rows.Add(
                            num_unlock_box,
                            DateTime.Now,
                            com_Name_user_new.SelectedValue,
                            com_Name_user_new.Text,
                            txt_reast_Box.Text,
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
                        update_Value_Casher_And_Fund();
                        MessageBox.Show("تم الاغلاق بنجاح ");
                        MessageBox.Show("يرجاء اعادة تشغيل النظام");
                        Application.Restart();
                        Close();
                    }
                    else
                    {
                        MessageBox.Show("يرجاء التحقق من كلمة سر المستخدم المستلم");
                        return;
                    }
                }
                else
                {

                    if (Cheack_Passeword[2].ToString() == txt_password_user_new.Text.Trim())
                    {
                        updateDataOlduser();
                        object[] ob_update_new_user = DB_Add_delete_update_.Database.ds.Tables["Unlook_Box"].Rows.Find(dr_Cheack_user_new_user[0][0]).ItemArray;
                        ob_update_new_user[4] = Convert.ToDouble(ob_update_new_user[4]) + Convert.ToDouble(txt_reast_Box.Text);
                        new classs_table.Items_Tools().update_Rows_Table_Database("Unlook_Box", ob_update_new_user[0].ToString(), ob_update_new_user);
                        update_Value_Casher_And_Fund();
                        MessageBox.Show("تم الاغلاق بنجاح ");
                        MessageBox.Show("يرجاء اعادة تشغيل النظام");
                        Application.Restart();
                        Close();
                    }
                    else
                    {
                        MessageBox.Show("يرجاء التحقق من كلمة سر المستخدم المستلم");
                        return;
                    }

                }
            }

        }
        private void Button2_Click(object sender, EventArgs e)
        {
            var vr = Application.OpenForms["Main"] as Main;
            String Query = "id_login = " + vr.txt_user_id_Emp.Caption + " And " + "UserName = '" + vr.txt_user_Emp.Caption + "' And isLoock =" + false;
            DataRow[] dr_Cheack_user = DB_Add_delete_update_.Database.ds.Tables["Unlook_Box"].Select(Query);
            frm_unlock_detils vr2 = new frm_unlock_detils();

            vr2.txt_num_unlock_chasher.Text = dr_Cheack_user[0][0].ToString();
            vr2.ShowDialog();


        }

        private void Txt_TransForm_Amound_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void Txt_TransForm_Amound_KeyDown(object sender, KeyEventArgs e)
        {
        }
        private void Txt_Report_Sales_Cline_num_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private void Txt_Report_Sales_Cline_num_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void Txt_TransForm_Amound_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyData != Keys.Back)
            {
                if (txt_TransForm_Amound.Text.Trim() != String.Empty)
                {

                    if (txt_Report_Sales_Cline_num.Text.Trim() != string.Empty)
                    {

                        if (Convert.ToDouble(txt_TransForm_Amound.Text.Trim()) > Convert.ToDouble(txt_Report_Sales_Cline_num.Text.Trim()))
                        {
                            txt_TransForm_Amound.Text = Convert.ToDouble(txt_Report_Sales_Cline_num.Text.Trim()).ToString();
                            txt_reast_Box.Text = "0";
                            e.Handled = true;
                        }
                        else
                        {
                            txt_reast_Box.Text = Convert.ToDouble(Convert.ToDouble(txt_Report_Sales_Cline_num.Text.Trim()) - Convert.ToDouble(txt_TransForm_Amound.Text.Trim())).ToString();
                        }
                    }
                }
            }
            else
            {
                txt_reast_Box.Text = Convert.ToDouble(Convert.ToDouble(txt_Report_Sales_Cline_num.Text.Trim()) - Convert.ToDouble(txt_TransForm_Amound.Text.Trim())).ToString();
            }
        }

        private void Txt_Report_Sales_Cline_num_KeyUp(object sender, KeyEventArgs e)
        {
            txt_reast_Box.Text = Convert.ToDouble(Convert.ToDouble(txt_Report_Sales_Cline_num.Text.Trim()) - Convert.ToDouble(txt_TransForm_Amound.Text.Trim())).ToString();
        }
    }
}
