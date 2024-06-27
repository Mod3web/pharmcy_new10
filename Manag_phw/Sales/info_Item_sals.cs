using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Manag_ph.Sales
{
    public partial class info_Item_sals : Form
    {
        public info_Item_sals()
        {
            InitializeComponent();
        }

        private void TabPane1_Click(object sender, EventArgs e)
        {


        }

        private void Info_Item_sals_Load(object sender, EventArgs e)
        {
            var vr = Application.OpenForms["Main"] as Main;
            int num_Item = Convert.ToInt32(vr.dgv_sals_dgv.CurrentRow.Cells[1].Value);
            object[] ob_Item = DB_Add_delete_update_.Database.ds.Tables["Item"].Rows.Find(num_Item).ItemArray;
            txt_num.Text = ob_Item[0].ToString();
            txt_name_ar.Text = ob_Item[2].ToString();
            txt_name_en.Text = ob_Item[1].ToString();
            txt_name_tg.Text = ob_Item[3].ToString();
        }
    }
}
