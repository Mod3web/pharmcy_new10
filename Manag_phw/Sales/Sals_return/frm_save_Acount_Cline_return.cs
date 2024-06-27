using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Manag_ph.Sales.Sals_return
{
    public partial class frm_save_Acount_Cline_return : Form
    {
        public frm_save_Acount_Cline_return()
        {
            InitializeComponent();
        }

        private void Frm_save_Acount_Cline_return_Load(object sender, EventArgs e)
        {
            var vr = Application.OpenForms["Main"] as Main;
            txt_sals_begin_cash.Text = vr.txt_after_sals_return.Text;
            txt_sals_pand_cash.Text = "0.00";
            txt_after_pand_cash.Text = Convert.ToDouble(Convert.ToDouble(txt_sals_pand_cash.Text) - Convert.ToDouble(vr.txt_after_sals_return.Text)).ToString("N2");
            txt_sals_pand_cash.Select();
            txt_sals_pand_cash.SelectAll();

        }

        private void Txt_sals_pand_cash_KeyUp(object sender, KeyEventArgs e)
        {
            double sum = txt_sals_pand_cash.Text.Trim() == String.Empty ? ((-1) * Convert.ToDouble(txt_sals_begin_cash.Text)) : Convert.ToDouble(Convert.ToDouble(txt_sals_pand_cash.Text) - Convert.ToDouble(txt_sals_begin_cash.Text));

            txt_after_pand_cash.Text = sum.ToString("N2");

        }

        private void Rb_yuo_CheckedChanged(object sender, EventArgs e)
        {

                txt_sals_pand_cash.Text = "0.00";
                txt_after_pand_cash.Text = Convert.ToDouble(Convert.ToDouble(txt_sals_pand_cash.Text) - Convert.ToDouble(txt_sals_begin_cash.Text)).ToString("N2");
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            new Sals_return.Save_and_update_unit().Account_Cline();
            Close();
        }

        private void Button2_Click(object sender, EventArgs e)
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
    }
}
