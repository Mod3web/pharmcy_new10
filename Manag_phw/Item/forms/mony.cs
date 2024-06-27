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
    public partial class mony : Form
    {
        public mony()
        {
            InitializeComponent();
        }

        private void Mony_Load(object sender, EventArgs e)
        {
            dgv_currensic_dgv.DataSource = DB_Add_delete_update_.Database.ds.Tables["currencies"];
            dgv_currensic_dgv.Columns[0].HeaderText = "رقم العمة";
            dgv_currensic_dgv.Columns[1].HeaderText = "اسم العمة";
            dgv_currensic_dgv.Columns[2].HeaderText = "اسم الوحدة الكبرا ";
            dgv_currensic_dgv.Columns[3].HeaderText = "اسم الوحدة الصغرا ";

        }

        void Clear()
        {
            txt_num.Focus();
            txt_name.Clear();
            txt_name_curr.Clear();
            txt_name_curr2.Clear();
        }


        void checkEmpty()
        {
            if (txt_name.Text.Trim() == String.Empty || txt_name_curr.Text.Trim() == String.Empty || txt_name_curr2.Text.Trim() == String.Empty)
            {
                MessageBox.Show("يرجاء التحقق من المدخلات", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }


        private void Btn_new_Click(object sender, EventArgs e)
        {
            txt_num.Text = new classs_table.Items_Tools().AoutoNumber("currencies", "current_num").ToString();
            Clear();
        }

        private void Bt_Add_Click(object sender, EventArgs e)
        {
            checkEmpty();
            DB_Add_delete_update_.Database.ds.Tables["currencies"].Rows.Add(Convert.ToInt32(txt_num.Text), txt_name.Text, txt_name_curr.Text, txt_name_curr2.Text);
            DB_Add_delete_update_.Database.update("currencies");
            MessageBox.Show("تم الاضافة بنجاح", "اضافة", MessageBoxButtons.OK, MessageBoxIcon.Information);
            txt_num.Text = new classs_table.Items_Tools().AoutoNumber("currencies", "current_num").ToString();

            Clear();
        }

        private void Dgv_currensic_SelectionChanged(object sender, EventArgs e)
        {
            if (dgv_currensic_dgv.CurrentRow != null)
            {
                txt_num.Text = dgv_currensic_dgv.CurrentRow.Cells[0].Value.ToString();
                txt_name.Text = dgv_currensic_dgv.CurrentRow.Cells[1].Value.ToString();
                txt_name_curr.Text = dgv_currensic_dgv.CurrentRow.Cells[2].Value.ToString();
                txt_name_curr2.Text = dgv_currensic_dgv.CurrentRow.Cells[3].Value.ToString();
            }
        }

        private void Btn_update_Click(object sender, EventArgs e)
        {
            DataRow dr_curr = DB_Add_delete_update_.Database.ds.Tables["currencies"].Rows.Find(txt_num.Text);
            if (dr_curr != null)
            {
                object[] ob_currns = dr_curr.ItemArray;
                checkEmpty();

                ob_currns[1] = txt_name.Text.Trim();
                ob_currns[2] = txt_name_curr.Text.Trim();
                ob_currns[3] = txt_name_curr2.Text.Trim();
                new classs_table.Items_Tools().update_Rows_Table_Database("currencies", ob_currns[0].ToString(), ob_currns);
                MessageBox.Show("تم التحديث بنجاح", "تحديث", MessageBoxButtons.OK, MessageBoxIcon.Information);

                btn_new_btn.PerformClick();

            }
        }
    }
}
