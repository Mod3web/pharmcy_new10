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
    public partial class Frm_reason_dicon_Add : Form
    {
        public Frm_reason_dicon_Add()
        {
            InitializeComponent();
        }

        void Fill_Data()
        {
        dgv_Compny_dgv.DataSource =  DB_Add_delete_update_.Database.ds.Tables["Reasons_disco_Add"];

            dgv_Compny_dgv.Columns[0].HeaderText = "الكود";
            dgv_Compny_dgv.Columns[1].HeaderText = "السبب";


        }
        public void ClareData()
        {
            btn_delete_btn.Enabled = false;
            btn_update_btn.Enabled = false;
            bt_Add_btn.Enabled = true;

            foreach (Control co in Controls)
            {
                if (co is TextBox)
                {

                    ((TextBox)co).Clear();
                    txt_com.Focus();
                    txt_com.SelectAll();

                }
            }
            int Auto = 1;
            Auto = new classs_table.Items_Tools().AoutoNumber("Reasons_disco_Add", "num_Reasons");

            txt_num.Text = Auto.ToString();
            //int Auto = 1;
            //if (DB_Add_delete_update_.Database.ds.Tables["Reasons_disco_Add"].Rows.Count > 0)
            //{
            //    Auto = Convert.ToInt32(DB_Add_delete_update_.Database.ds.Tables["Reasons_disco_Add"].Compute("max(num_Reasons)", "")) + 1;
            //    txt_num.Text = Auto.ToString();
            //}
            //else
            //{
            //    txt_num.Text = Auto.ToString();
            //}
        }
        private void Frm_reason_dicon_Add_Load(object sender, EventArgs e)
        {
            bt_Add_btn.Enabled = false;
            Fill_Data();
        }
         ErrorProvider er = new ErrorProvider();
        private void Bt_Add_Click(object sender, EventArgs e)
        {
            er.Clear();
            if (txt_com.Text.Trim() != string.Empty)
            {
                //DB_Add_delete_update_.Database.ds.Tables["Reasons_disco_Add"].Rows.Add(Convert.ToInt32(txt_num.Text), txt_com.Text);


                DB_Add_delete_update_.Database.ds.Tables["Reasons_disco_Add"].Rows.Add(Convert.ToInt32(txt_num.Text), txt_com.Text);

                btn_new_btn.PerformClick();
                dgv_Compny_dgv.DataSource = DB_Add_delete_update_.Database.ds.Tables["Reasons_disco_Add"];
                DB_Add_delete_update_.Database.update("Reasons_disco_Add");
            }
            else
            {
                er.SetError(txt_com, "يرجا ملا الحقل");
            }
        }

        private void Btn_new_Click(object sender, EventArgs e)
        {
            ClareData();
        }

        private void Btn_update_Click(object sender, EventArgs e)
        {
            if (txt_com.Text.Trim() != string.Empty)
            {

              object[] od_update =  DB_Add_delete_update_.Database.ds.Tables["Reasons_disco_Add"].Rows.Find(dgv_Compny_dgv.CurrentRow.Cells[0].Value).ItemArray;
                od_update[1] = txt_com.Text;
                new classs_table.Items_Tools().update_Rows_Table_Database("Reasons_disco_Add", od_update[0].ToString(), od_update);
            }
            else
            {
                er.SetError(txt_com, "يرجا ملا الحقل");
            }
        }

        private void Btn_delete_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult dr = MessageBox.Show("هل تريد الحذف ", "حذف", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                if (dr == DialogResult.OK)
                {
                   
                    new classs_table.Items_Tools().Delete_Rows_Table_Database("Reasons_disco_Add", txt_num.Text);
                    ClareData();
                    int i = Convert.ToInt32(dgv_Compny_dgv.CurrentRow.Cells[0].Value);

                    dgv_Compny_dgv.DataSource = DB_Add_delete_update_.Database.ds.Tables["Reasons_disco_Add"];
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

        private void Txt_sech_TextChanged(object sender, EventArgs e)
        {
            DataView dv = new DataView(DB_Add_delete_update_.Database.ds.Tables["Reasons_disco_Add"]);
            string str = txt_sech.Text;
            dv.RowFilter = "[name_Reasons] + [num_Reasons] like '%" + str + "%'";
            dgv_Compny_dgv.DataSource = dv;
            dgv_Compny_dgv.Columns[0].HeaderText = "الكود";
            dgv_Compny_dgv.Columns[1].HeaderText = "السبب";
        }

        private void Dgv_Compny_SelectionChanged(object sender, EventArgs e)
        {
            if (dgv_Compny_dgv.CurrentRow != null)
            {
                txt_num.Text = dgv_Compny_dgv.CurrentRow.Cells[0].Value.ToString();
                txt_com.Text = dgv_Compny_dgv.CurrentRow.Cells[1].Value.ToString();
                bt_Add_btn.Enabled = false;
                btn_update_btn.Enabled = true;
                btn_delete_btn.Enabled = true;
            }
        }
    }
}
