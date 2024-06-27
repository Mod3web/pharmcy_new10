using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Manag_ph.Sales.hanging
{
    public partial class frm_save_hanging : Form
    {
        public frm_save_hanging()
        {
            InitializeComponent();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            new Sales.hanging.Save_Footer_hanging().Save_and_update_Footer_hanging_Item();
            Close();
        }

        private void Frm_save_hanging_Load(object sender, EventArgs e)
        {
            var vr = Application.OpenForms["Main"] as Main;
            txt_sals_begin_cash.Text = vr.txt_value_after_hanging.Text;
            txt_sals_pand_cash.Text = vr.txt_value_after_hanging.Text;
        }

        private void Button2_btn_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
