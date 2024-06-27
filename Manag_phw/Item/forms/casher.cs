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
    public partial class casher : Form
    {
        public casher()
        {
            InitializeComponent();
        }

        // دالة لت
        void fill_Data()
        {
            DataTable dt = DB_Add_delete_update_.Database.ds.Tables["casher"];

            dgv_casher_dgv.Rows.Clear();
            if (dt.Rows.Count != 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    DataRow dr_storg = DB_Add_delete_update_.Database.ds.Tables["Storg"].Rows.Find(dt.Rows[i][3]);
                    DataRow dr_fund_acu = DB_Add_delete_update_.Database.ds.Tables["account_fund"].Rows.Find(dt.Rows[i][4]);
                    dgv_casher_dgv.Rows.Add(dt.Rows[i][0], dt.Rows[i][1], dr_storg[1], dr_fund_acu[1], dt.Rows[i][2]);
                }
            }
        }
        private void Casher_Load(object sender, EventArgs e)
        {
            fill_Data();
            int num = new classs_table.Items_Tools().AoutoNumber("casher", "casher_num");
            txt_num_casher.Text = num.ToString();
         
        }

        private void TextEdit4_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (txt_nun_storg_casher.Text.Trim() != string.Empty)
                {
                    DataRow dr_storg = DB_Add_delete_update_.Database.ds.Tables["Storg"].Rows.Find(txt_nun_storg_casher.Text.Trim());
                    if (dr_storg != null)
                    {
                        txt_name_storg_casher.Text = dr_storg[1].ToString();
                    }
                    else
                    {
                        MessageBox.Show("يرجاء التحقق من رقم المخزن", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        txt_name_storg_casher.Text = "";
                        return;
                    }
                }
            }
        }

        private void Txt_num_fund_casher_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (txt_num_fund_casher.Text.Trim() != string.Empty)
                {
                    DataRow dr_storg = DB_Add_delete_update_.Database.ds.Tables["account_fund"].Rows.Find(txt_num_fund_casher.Text.Trim());
                    if (dr_storg != null)
                    {
                        txt_name_fund_casher.Text = dr_storg[1].ToString();
                    }
                    else
                    {
                        MessageBox.Show("يرجاء التحقق من رقم الصندوق", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        txt_name_fund_casher.Text = "";
                        return;
                    }
                }
            }
        }


        void new_casher()
        {
            btn_update_btn.Enabled = false;
            btn_Add_btn.Enabled = true;
            txt_num_casher.Text = new classs_table.Items_Tools().AoutoNumber("casher", "casher_num").ToString();
            txt_name_casher.Text = "";
            txt_name_casher.Focus();
            txt_nun_storg_casher.Text = "";
            txt_name_storg_casher.Text = "";
            txt_name_fund_casher.Text = "";
            txt_num_fund_casher.Text = "";
            ch_stop_casher.Checked = false;
        }
        private void Button5_Click(object sender, EventArgs e)
        {
            new_casher();
        }

        void check_Data()
        {
            if (txt_name_casher.Text.Trim() == string.Empty)
            {
                MessageBox.Show("يرجاء ادخال اسم الكاشير", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (txt_name_storg_casher.Text.Trim() == string.Empty)
            {
                MessageBox.Show("يرجاء ادخال المخزن ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (txt_name_fund_casher.Text.Trim() == string.Empty)
            {
                MessageBox.Show("يرجاء ادخال الصندوق ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        private void Btn_Add_Click(object sender, EventArgs e)
        {

            check_Data();
            int num_cacher_Accuount = new classs_table.Items_Tools().AoutoNumber("casher_account", "casher_Account_num");

            DB_Add_delete_update_.Database.ds.Tables["casher_account"].Rows.Add(num_cacher_Accuount, 0, 0);
            DB_Add_delete_update_.Database.update("casher_account");

            if (txt_name_casher.Text.Trim() == String.Empty )
            {
                MessageBox.Show("يرجاء ادخال اسم الكاشير");
                return;
            }else if (txt_nun_storg_casher.Text.Trim() == string.Empty)
            {
                MessageBox.Show("يرجاء ادخال  رقم المخزن");
                return;
            }else if (txt_num_fund_casher.Text.Trim() == string.Empty)
            {
                MessageBox.Show("يرجاء ادخال  رقم الصندوق");
                return;
            }

            DB_Add_delete_update_.Database.ds.Tables["casher"].Rows.Add(
              Convert.ToInt32( txt_num_casher.Text),
                txt_name_casher.Text.Trim(),
                ch_stop_casher.Checked,
                txt_nun_storg_casher.Text.Trim(),
                txt_num_fund_casher.Text.Trim(),
                num_cacher_Accuount);
            DB_Add_delete_update_.Database.update("casher");



            // اضاف بيانات حسابات الكاشير بس تكون المبلغ فاضي

            fill_Data();
            new_casher();
            MessageBox.Show("تم اضاف البيانات بنجاح","Save",MessageBoxButtons.OK,MessageBoxIcon.Information);

        }

        private void DataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            if (dgv_casher_dgv.CurrentRow != null)
            {
                btn_update_btn.Enabled = true;
                btn_Add_btn.Enabled = false;
                txt_num_casher.Text = dgv_casher_dgv.CurrentRow.Cells[0].Value.ToString();
                txt_name_casher.Text = dgv_casher_dgv.CurrentRow.Cells[1].Value.ToString();


                DataRow dr_casher = DB_Add_delete_update_.Database.ds.Tables["casher"].Rows.Find(dgv_casher_dgv.CurrentRow.Cells[0].Value);
                if (dr_casher != null)
                {


                    DataRow dr_storg = DB_Add_delete_update_.Database.ds.Tables["Storg"].Rows.Find(dr_casher[3]);
                    if (dr_storg != null)
                    {
                        txt_nun_storg_casher.Text = dr_storg[0].ToString();
                        txt_name_storg_casher.Text = dr_storg[1].ToString();
                    }
                    DataRow dr_fund = DB_Add_delete_update_.Database.ds.Tables["account_fund"].Rows.Find(dr_casher[4]);
                    if (dr_fund != null)
                    {
                        txt_num_fund_casher.Text = dr_fund[0].ToString();
                        txt_name_fund_casher.Text = dr_fund[1].ToString();
                    }

                    ch_stop_casher.Checked = Convert.ToBoolean(dr_casher[2]);
                }
            }
        }

        private void Btn_update_Click(object sender, EventArgs e)
        {
            check_Data();


          DataRow dr_casher_update =  DB_Add_delete_update_.Database.ds.Tables["casher"].Rows.Find(txt_num_casher.Text);
            if (dr_casher_update != null)
            {
                dr_casher_update[1] = txt_name_casher.Text.Trim();
                dr_casher_update[2] = ch_stop_casher.Checked;
                dr_casher_update[3] = txt_nun_storg_casher.Text;
                dr_casher_update[4] = txt_num_fund_casher.Text;
            new classs_table.Items_Tools().update_Rows_Table_Database("casher", dr_casher_update[0].ToString(), dr_casher_update.ItemArray);
                fill_Data();
                MessageBox.Show("تم تحديث البيانات ","update",MessageBoxButtons.OK,MessageBoxIcon.Information);
            }


        }
    }
}
