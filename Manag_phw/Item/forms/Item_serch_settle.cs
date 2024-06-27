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
    public partial class Item_serch_settle : Form
    {
        public Item_serch_settle()
        {
            InitializeComponent();
        }

        private void Item_serch_settle_Load(object sender, EventArgs e)
        {

            dgv_Item_serch_settl_dgv.DataSource = DB_Add_delete_update_.Database.ds.Tables["Item"];
            dgv_Item_serch_settl_dgv.Columns[0].HeaderText = " رقم الصنف";
            dgv_Item_serch_settl_dgv.Columns[1].HeaderText = "الاسم عربي";
            dgv_Item_serch_settl_dgv.Columns[2].HeaderText = "الاسم انجليزي";
            dgv_Item_serch_settl_dgv.Columns[3].HeaderText = "الاسم التجاري";

            for (int i = 4; i < dgv_Item_serch_settl_dgv.Columns.Count; i++)
            {
                dgv_Item_serch_settl_dgv.Columns[i].Visible = false;
            }
        }

        private void Txt_serch_TextChanged(object sender, EventArgs e)
        {
            DataView dv = new DataView(DB_Add_delete_update_.Database.ds.Tables["Item"]);
            //string str = txt_serch.Text;
            string str = classs_table.Items_Tools.get_str_barcode(txt_serch);
            dv.RowFilter = "name_en + Item_no + name_ar + name_tr like '%" + str + "%'";
            dgv_Item_serch_settl_dgv.DataSource = dv;
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            var dr = Application.OpenForms["Main"] as Main;
            dr.txt_num_Item_settle.Text = dgv_Item_serch_settl_dgv.CurrentRow.Cells[0].Value.ToString();

          new storg.settle_Item().serch_Item_get_name();
            Close();
        }
    }
}
