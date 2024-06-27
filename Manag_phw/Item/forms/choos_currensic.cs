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
    public partial class choos_currensic : Form
    {
        public choos_currensic()
        {
            InitializeComponent();
        }

        private void Choos_currensic_Load(object sender, EventArgs e)
        {
            dgv_curren_dgv.DataSource = DB_Add_delete_update_.Database.ds.Tables["currencies"];
            dgv_curren_dgv.Columns[0].HeaderText = "رقم العملة";
            dgv_curren_dgv.Columns[1].HeaderText = " اسم العملة";
            dgv_curren_dgv.Columns[2].HeaderText = "اسم الوحدة الاكبر";
            dgv_curren_dgv.Columns[3].HeaderText = "اسم الوحدة الاصغر";
        }


         void Add_Data()
        {
            if (dgv_curren_dgv.CurrentRow != null)
            {
                var vr = Application.OpenForms["Main"] as Main;

                // التحقق لو كان يرد اضاف اكثر من عملة من نفس العملة
                if (vr.dgv_fund_currensic_dgv.Rows.Count != 0)
                {
                    for (int i = 0; i < vr.dgv_fund_currensic_dgv.Rows.Count; i++)
                    {
                        if (dgv_curren_dgv.CurrentRow.Cells[0].Value.ToString() == vr.dgv_fund_currensic_dgv.Rows[i].Cells[0].Value.ToString())
                        {
                            MessageBox.Show("لايمكن اضافة العملة اكثر من مرة","Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
                            Close();
                            return;
                        }
                    }
                }
                vr.dgv_fund_currensic_dgv.Rows.Add(dgv_curren_dgv.CurrentRow.Cells[0].Value, dgv_curren_dgv.CurrentRow.Cells[1].Value);
                Close();
            }
        }
        private void Button1_Click(object sender, EventArgs e)
        {
            Add_Data();
        }

        private void Dgv_curren_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            Add_Data();
        }

        private void Dgv_curren_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                Add_Data();
            }
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
