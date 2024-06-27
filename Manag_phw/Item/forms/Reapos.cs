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
    public partial class Reapos : Form
    {
        public Reapos()
        {
            InitializeComponent();
        }

        private void Reapos_Load(object sender, EventArgs e)
        {
            bt_Add_reapos_btn.Enabled = false;
            //dgv_Compny.DataSource = db.view_All("All_collection_of_Item");
            dgv_reapos_dgv.DataSource = DB_Add_delete_update_.Database.ds.Tables["Reason_settle"];
            dgv_reapos_dgv.Columns[0].HeaderText = "رقم التسوية";
            dgv_reapos_dgv.Columns[1].HeaderText = "اسم التسوية";
        }

        private void Dgv_reapos_SelectionChanged(object sender, EventArgs e)
        {
            if (dgv_reapos_dgv.CurrentRow != null)
            {
                txt_num_reapos.Text = dgv_reapos_dgv.CurrentRow.Cells[0].Value.ToString();
                txt_reapos.Text = dgv_reapos_dgv.CurrentRow.Cells[1].Value.ToString();
                bt_Add_reapos_btn.Enabled = false;
                btn_update_reapos_btn.Enabled = true;
                btn_delete_reapos_btn.Enabled = true;
            }
        }
        public void ClareData()
        {
            btn_delete_reapos_btn.Enabled = false;
            btn_update_reapos_btn.Enabled = false;
            bt_Add_reapos_btn.Enabled = true;

            foreach (Control co in Controls)
            {
                if (co is TextBox)
                {

                    ((TextBox)co).Clear();
                }
            }
            int Auto = 1;
            Auto = new classs_table.Items_Tools().AoutoNumber("Reason_settle", "num_reason_settl");

            txt_num_reapos.Text = Auto.ToString();
            //  txt_num.Text = db.AutoNumber("collection_of_Item;", "colle_num").ToString();
            //int Auto = 1;
            //if (DB_Add_delete_update_.Database.ds.Tables[0].Rows.Count > 0)
            //{
            //    Auto = new classs_table.Items_Tools().AoutoNumber("Reason_settle", "num_reason_settl");
            //    txt_num_reapos.Text = Auto.ToString();
            //}
            //else
            //{
            //    txt_num_reapos.Text = Auto.ToString();
            //}


            txt_reapos.Focus();
        }
        ErrorProvider er = new ErrorProvider();
        private void Bt_Add_reapos_Click(object sender, EventArgs e)
        {
            er.Clear();
            if (txt_reapos.Text.Trim() != string.Empty)
            {
                DB_Add_delete_update_.Database.ds.Tables["Reason_settle"].Rows.Add(Convert.ToInt32(txt_num_reapos.Text), txt_reapos.Text);
                btn_new_reapos_btn.PerformClick();
                dgv_reapos_dgv.DataSource = DB_Add_delete_update_.Database.ds.Tables["Reason_settle"];
                DB_Add_delete_update_.Database.update("Reason_settle");
            }
            else
            {
                er.SetError(txt_reapos, "يرجا ملا الحقل");
            }
        }

        private void Txt_reapos_KeyDown(object sender, KeyEventArgs e)
        {
            if (char.IsLetterOrDigit((char)e.KeyValue))
            {
                er.Clear();


            }
        }

        private void Btn_delete_reapos_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult dr = MessageBox.Show("هل تريد الحذف ", "حذف", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                if (dr == DialogResult.OK)
                {
                    int num = Convert.ToInt32(dgv_reapos_dgv.CurrentRow.Cells[0].Value);
                    new classs_table.Items_Tools().Delete_Rows_Table_Database("Reason_settle", num.ToString());
                    ClareData();
                }
            }
            catch (Exception ex)
            {
                string str = ex.Message;
                if (str.Contains("The DELETE statement conflicted with the REFERENCE constraint"))
                {
                    MessageBox.Show("الصف الذي تريد حذفة مربوط بجدول اخر" + "\n" + "يرجا  حذف الصف من جدول الاصناف", "تنبية", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void Btn_update_reapos_Click(object sender, EventArgs e)
        {
            if (txt_reapos.Text.Trim() != string.Empty)
            {
                int num = Convert.ToInt32(dgv_reapos_dgv.CurrentRow.Cells[0].Value);
               

                if (txt_reapos.Text.Trim() != string.Empty)
                {
                    string name = txt_reapos.Text;
                    new classs_table.Items_Tools().update_Rows_Table_Database("Reason_settle", num.ToString(), new object[] { num, name });

                }

            }
            else
            {
                er.SetError(txt_reapos, "يرجا ملا الحقل");
            }
        }

        private void Txt_sech_reapos_TextChanged(object sender, EventArgs e)
        {
            if (DB_Add_delete_update_.Database.ds.Tables["Reason_settle"].Rows.Count!=0)
            {
                 DataView dv = new DataView(DB_Add_delete_update_.Database.ds.Tables["Reason_settle"]);
            string str = txt_sech_reapos.Text;
            dv.RowFilter = "num_reason_settl + name_resson_settl like '%" + str + "%'";
            dgv_reapos_dgv.DataSource = dv;
            }
           

        }

        private void Btn_new_reapos_Click(object sender, EventArgs e)
        {
            ClareData();
        }
    }
}
