using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Manag_ph.Sales.Footer_sals
{
    public partial class frm_Save_footer_sals : Form
    {
        public frm_Save_footer_sals()
        {
            InitializeComponent();
        }


        private void Frm_Save_footer_sals_Load(object sender, EventArgs e)
        {
            var vr = Application.OpenForms["Main"] as Main;
            txt_sals_begin_cash.Text = vr.txt_end_Dico_All_sals.Text;
            txt_sals_pand_cash.Text = vr.txt_end_Dico_All_sals.Text;
            txt_sals_pand_cash.Select();
            txt_sals_pand_cash.SelectAll();
        }
        private void Button1_Click(object sender, EventArgs e)
        {
            var dr = Application.OpenForms["Main"] as Main;

            if (dr.rb_cash_sals.Checked)
            {
                if (Convert.ToDouble(txt_after_pand_cash.Text) < 0)
                {
                    MessageBox.Show("يرجاء التحقق من من الرصيد المدفوع", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                else
                {

                    new Sales.Save_Footer_Sals().Save_Footer_Item();
                    Close();
                }
            }
        }

        private void Txt_sals_pand_cash_KeyUp(object sender, KeyEventArgs e)
        {
            txt_after_pand_cash.Text = txt_sals_pand_cash.Text.Trim() == String.Empty ? ((-1) * Convert.ToDouble(txt_sals_begin_cash.Text)).ToString("N2") : Convert.ToDouble(Convert.ToDouble(txt_sals_pand_cash.Text) - Convert.ToDouble(txt_sals_begin_cash.Text) ).ToString("N2");
        }

        private void Button2_btn_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void Txt_sals_pand_cash_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsDigit(e.KeyChar) || e.KeyChar == 8))
            {
                e.Handled = true;
            }
        }

        private void Txt_sals_pand_cash_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                button1_btn.PerformClick();
            }
        }
    }
}
