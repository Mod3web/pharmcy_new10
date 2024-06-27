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
    public partial class Frm_add_operating_Expenses : Form
    {
        public Frm_add_operating_Expenses()
        {
            InitializeComponent();
        }

        private void lan_Click(object sender, EventArgs e)
        {

        }

        private void Frm_add_operating_Expenses_Load(object sender, EventArgs e)
        {

            dgv_operating_Expenses_dgv.DataSource = DB_Add_delete_update_.Database.ds.Tables["operating_Expenses"];
            dgv_operating_Expenses_dgv.Columns[0].HeaderText ="كود";
            dgv_operating_Expenses_dgv.Columns[1].HeaderText ="مصاريف التشغيل";
            dgv_operating_Expenses_dgv.Columns[2].HeaderText = "موقف";
        }

        public void ClareData2()
        {
           
            btn_update_perating_Expenses_btn.Enabled = false;
            btn_add_operating_Expenses_btn.Enabled = true;
            chBox_stop_operating_Expenses.Checked = false;
            foreach (Control co in Controls)
            {
                if (co is TextBox)
                {

                    ((TextBox)co).Clear();
                    txt_name_operating_Expenses.Focus();
                    txt_name_operating_Expenses.SelectAll();

                }
            }

            int Auto = 1;
            Auto = new classs_table.Items_Tools().AoutoNumber("operating_Expenses", "num_operating_Expenses");

            txt_num_operating_Expenses.Text = Auto.ToString();
            //int Auto = 1;
            //if (DB_Add_delete_update_.Database.ds.Tables["operating_Expenses"].Rows.Count > 0)
            //{
            //    Auto = new classs_table.Items_Tools().AoutoNumber("operating_Expenses", "num_operating_Expenses");

            //    txt_num_operating_Expenses.Text = Auto.ToString();
            //}
            //else
            //{
            //    txt_num_operating_Expenses.Text= Auto.ToString();
            //}

        }
        private void btn_new_operating_Expenses_Click(object sender, EventArgs e)
        {
            ClareData2();
        }
        ErrorProvider er = new ErrorProvider();

        private void btn_add_operating_Expenses_Click(object sender, EventArgs e)
        {
            
            if (txt_name_operating_Expenses.Text.Trim() != string.Empty)
            {
                DB_Add_delete_update_.Database.ds.Tables["operating_Expenses"].Rows.Add(Convert.ToInt32(txt_num_operating_Expenses.Text), txt_name_operating_Expenses.Text,chBox_stop_operating_Expenses.Checked);
                //btn_new_operating_Expenses.PerformClick();
                DB_Add_delete_update_.Database.update("operating_Expenses");
                dgv_operating_Expenses_dgv.DataSource = DB_Add_delete_update_.Database.ds.Tables["operating_Expenses"];
                ClareData2();
                btn_add_operating_Expenses_btn.Enabled = false;
                btn_update_perating_Expenses_btn.Enabled = true;
                btn_new_operating_Expenses_btn.Enabled = true;
            }
            else
            {
                er.SetError(txt_name_operating_Expenses, "يرجا ملا الحقل");
            }
        }

        private void btn_update_perating_Expenses_Click(object sender, EventArgs e)
        {

            if (txt_name_operating_Expenses.Text.Trim() != string.Empty)
            {
                DB_Add_delete_update_.Database.ds.Tables["operating_Expenses"].Rows[dgv_operating_Expenses_dgv.CurrentRow.Index][1] = txt_name_operating_Expenses.Text;
                DB_Add_delete_update_.Database.ds.Tables["operating_Expenses"].Rows[dgv_operating_Expenses_dgv.CurrentRow.Index][2] =chBox_stop_operating_Expenses.Checked;
                DB_Add_delete_update_.Database.update("operating_Expenses");

            }
            else
            {
                er.SetError(txt_name_operating_Expenses, "يرجا ملا الحقل");
            }
        }

        private void dgv_operating_Expenses_SelectionChanged(object sender, EventArgs e)
        {
            if (dgv_operating_Expenses_dgv.CurrentRow != null)
            {
                txt_num_operating_Expenses.Text = dgv_operating_Expenses_dgv.CurrentRow.Cells[0].Value.ToString();
                txt_name_operating_Expenses.Text = dgv_operating_Expenses_dgv.CurrentRow.Cells[1].Value.ToString();
                chBox_stop_operating_Expenses.Checked =Convert.ToBoolean( dgv_operating_Expenses_dgv.CurrentRow.Cells[2].Value);
                
                btn_add_operating_Expenses_btn.Enabled = false;
                btn_update_perating_Expenses_btn.Enabled = true;
            }
        }

        private void Dgv_operating_Expenses_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
