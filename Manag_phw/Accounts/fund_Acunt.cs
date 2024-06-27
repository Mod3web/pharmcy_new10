using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Manag_ph.Accounts
{
    class fund_Acunt
    {



        public void Add_fund()
        {
            var vr = Application.OpenForms["Main"] as Main;
            int num = new classs_table.Items_Tools().AoutoNumber("account_fund", "fund_num");
            int num_fund_sas = new classs_table.Items_Tools().AoutoNumber("fund_sals", "fund_sals_num");

            if (vr.txt_name_ar_fund.Text.Trim() == string.Empty)
            {
                MessageBox.Show(" يرجاء ادخال اسم الصندوق عربي","Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
                return;
            }
            if (vr.dgv_fund_currensic_dgv.RowCount == 0)
            {
                MessageBox.Show(" يرجاء استخدام عملة واحدة علا الاقل","Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
                return;
            }
            // اضاف بيانات حسابات الصندوق
            DB_Add_delete_update_.Database.ds.Tables["fund_sals"].Rows.Add(num_fund_sas, 0, 0);
            DB_Add_delete_update_.Database.update("fund_sals");
            //اضافة بيانات الصندوق 

            DB_Add_delete_update_.Database.ds.Tables["account_fund"].Rows.Add(vr.txt_num_fund.Text, vr.txt_name_ar_fund.Text.Trim(), vr.txt_name_en_fund.Text.Trim(),vr.ch_fund_stop.Checked, num_fund_sas);
            DB_Add_delete_update_.Database.update("account_fund");

         

            // اضافة بيانات العملات والصندوق الا جدول اخر
            for (int i = 0; i < vr.dgv_fund_currensic_dgv.RowCount; i++)
            {
                int check = vr.dgv_fund_currensic_dgv.Rows[i].Cells[2].Value != null ? 1 : 0; 
            DB_Add_delete_update_.Database.ds.Tables["current_fund_Accunt"].Rows.Add(
                vr.dgv_fund_currensic_dgv.Rows[i].Cells[0].Value,
                vr.txt_num_fund.Text,
                check
                );
            DB_Add_delete_update_.Database.update("current_fund_Accunt");
            }

            new_Data();
        }

        public void new_Data()
        {
            var vr = Application.OpenForms["Main"] as Main;
            vr.btn_add_fund_acunt_btn.Enabled = true;
            vr.btn_remove_Rows_Current_btn.Enabled = true;
            vr.btn_update_fund_btn.Enabled = false;
            int num = new classs_table.Items_Tools().AoutoNumber("account_fund", "fund_num");
            vr.txt_num_fund.Text = num.ToString();
            vr.txt_name_ar_fund.Text = "";
            vr.txt_name_en_fund.Text = "";
            vr.ch_fund_stop.Checked = false;
            vr.dgv_fund_currensic_dgv.Rows.Clear();
        }


        public void update_Account_fund()
        {
            var vr = Application.OpenForms["Main"] as Main;
            // تحديث بيانات الصندوق
            if (vr.dgv_fund_Account_dgv.CurrentRow != null)
            {
                object[] ob_update_fund = DB_Add_delete_update_.Database.ds.Tables["account_fund"].Rows.Find(vr.txt_num_fund.Text).ItemArray;

                if (vr.txt_name_ar_fund.Text.Trim() == string.Empty)
                {
                    MessageBox.Show("يرجاء التحقق من اسم الصندوق", "Error");
                    return;
                }
                ob_update_fund[1] = vr.txt_name_ar_fund.Text.Trim();
                ob_update_fund[2] = vr.txt_name_en_fund.Text.Trim();
                ob_update_fund[3] = vr.ch_fund_stop.Checked;

                new classs_table.Items_Tools().update_Rows_Table_Database("account_fund", ob_update_fund[0].ToString(), ob_update_fund);


                if (vr.dgv_fund_currensic_dgv.Rows.Count != 0)
                {

                    // نلف علا كل العملات في الصندوق
                    for (int i = 0; i < vr.dgv_fund_currensic_dgv.Rows.Count; i++)
                    {
                        // نتحقق من كل العملات التي يدعمها الصندوق 
                        DataRow update_fun_acu = DB_Add_delete_update_.Database.ds.Tables["current_fund_Accunt"].Rows.Find(new object[] { vr.dgv_fund_currensic_dgv.Rows[i].Cells[0].Value, Convert.ToInt32(vr.txt_num_fund.Text) });
                        // لو كان الصف ليس فاضي نعدلة واذا كان فاضي اذن ضاف عملة جديدة نضيفها
                        if (update_fun_acu != null)
                        {

                            update_fun_acu[2] = Convert.ToBoolean(vr.dgv_fund_currensic_dgv.Rows[i].Cells[2].Value);
                            //MessageBox.Show(update_fun_acu.ItemArray+"");
                            new classs_table.Items_Tools().update_Rows_Table_Database_miulty_key("current_fund_Accunt", new object[] { update_fun_acu[0], update_fun_acu[1] }, update_fun_acu.ItemArray);
                        }
                        else
                        {
                            int check = vr.dgv_fund_currensic_dgv.Rows[i].Cells[2].Value != null ? 1 : 0;

                            DB_Add_delete_update_.Database.ds.Tables["current_fund_Accunt"].Rows.Add(vr.dgv_fund_currensic_dgv.Rows[i].Cells[0].Value, Convert.ToInt32(vr.txt_num_fund.Text), check);
                            DB_Add_delete_update_.Database.update("current_fund_Accunt");
                        }
                    }
                }
                MessageBox.Show("تم التعديل بنجاح ", "update", MessageBoxButtons.OK, MessageBoxIcon.Information);
                new Accounts.fund_Acunt().new_Data();

            }
        }
        public void Dgv_fund_Account_SelectionChanged_()
        {

            // الحدث الخاص عند تحديد صف معين لكي تطلع البيانات لتحديث
            var vr = Application.OpenForms["Main"] as Main;
            vr.btn_add_fund_acunt_btn.Enabled = false;
            vr.btn_remove_Rows_Current_btn.Enabled = false;
            vr.btn_update_fund_btn.Enabled = true;


            vr.dgv_fund_currensic_dgv.Rows.Clear();
            if (vr.dgv_fund_Account_dgv.CurrentRow != null)
            {
                vr.txt_num_fund.Text = vr.dgv_fund_Account_dgv.CurrentRow.Cells[0].Value.ToString();
                vr.txt_name_ar_fund.Text = vr.dgv_fund_Account_dgv.CurrentRow.Cells[1].Value.ToString();
                vr.txt_name_en_fund.Text = vr.dgv_fund_Account_dgv.CurrentRow.Cells[2].Value.ToString();
                vr.ch_fund_stop.Checked = Convert.ToBoolean(vr.dgv_fund_Account_dgv.CurrentRow.Cells[3].Value);
                DataRow[] dr_fund_current = DB_Add_delete_update_.Database.ds.Tables["current_fund_Accunt"].Select("fund_num =" + vr.dgv_fund_Account_dgv.CurrentRow.Cells[0].Value);
                if (dr_fund_current.Count() != 0)
                {
                    for (int i = 0; i < dr_fund_current.Count(); i++)
                    {

                        DataRow dr_currenins = DB_Add_delete_update_.Database.ds.Tables["currencies"].Rows.Find(dr_fund_current[i][0]);
                        vr.dgv_fund_currensic_dgv.Rows.Add(dr_currenins[0], dr_currenins[1], Convert.ToBoolean(dr_fund_current[i][2]));
                    }
                }
            }
        }
    }
}
