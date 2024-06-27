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
    public partial class frm_save_data_return : Form
    {
        public frm_save_data_return()
        {
            InitializeComponent();
        }

        private void Frm_save_data_return_Load(object sender, EventArgs e)
        {
            var vr = Application.OpenForms["Main"] as Main;
            txt_sals_begin_cash.Text = vr.txt_after_sals_return.Text;
            txt_sals_pand_cash.Text = vr.txt_after_sals_return.Text;
            txt_sals_pand_cash.SelectAll();
        }

        private void Txt_sals_pand_cash_KeyUp(object sender, KeyEventArgs e)
        {

            double sum = txt_sals_pand_cash.Text.Trim() == String.Empty ? ((-1) * Convert.ToDouble(txt_sals_begin_cash.Text)) : Convert.ToDouble(Convert.ToDouble(txt_sals_pand_cash.Text) - Convert.ToDouble(txt_sals_begin_cash.Text));

            //double sum  = Convert.ToDouble(Convert.ToDouble(txt_sals_begin_cash.Text) - Convert.ToDouble(txt_sals_pand_cash.Text));
               txt_after_pand_cash.Text = sum.ToString("N2");


        }

        private void Button2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            if (txt_sals_pand_cash.Text.Trim() != String.Empty)
            {
                if (Convert.ToDouble(txt_sals_pand_cash.Text.Trim())< Convert.ToDouble(txt_sals_begin_cash.Text.Trim()))
                {
                    MessageBox.Show("يرجاء التحقق من المبلغ المدفوع");
                }
                else
                {
                    new Save_and_update_unit().update_unit();
                    Close();
                }
 
            }

        }

        private void Label3_Click(object sender, EventArgs e)
        {

        }

        private void Txt_after_pand_cash_TextChanged(object sender, EventArgs e)
        {

        }

        private void Label2_Click(object sender, EventArgs e)
        {

        }

        private void Txt_sals_pand_cash_TextChanged(object sender, EventArgs e)
        {

        }

        private void Label1_Click(object sender, EventArgs e)
        {

        }

        private void Txt_sals_begin_cash_TextChanged(object sender, EventArgs e)
        {

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
