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
    public partial class frm_paid_rest : Form
    {
        public frm_paid_rest()
        {
            InitializeComponent();
        }

        private void Frm_paid_rest_Load(object sender, EventArgs e)
        {
            var vr = Application.OpenForms["Main"] as Main;
            txt_pain_pric_sals_end.Text = vr.txt_end_Dico_All_sals.Text;
        }

        private void Txt_pain_pric_sals_TextChanged(object sender, EventArgs e)
        {
            if (txt_pain_pric_sals.Text != string.Empty)
            {
                txt_rest_pric_sals.Text = Convert.ToDouble(Convert.ToDouble(txt_pain_pric_sals_end.Text) - Convert.ToDouble(txt_pain_pric_sals.Text)).ToString("N2"); 
            }
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            if (txt_name_Cline_foot_sals_haing.Text.Trim() != string.Empty)
            {
                // حفظ بيانات الفاتورة المعلقة
                if (Convert.ToDouble(txt_rest_pric_sals.Text) >= 0)
                {
                    hanging_Event_btn save_foot_hang = new hanging_Event_btn(txt_name_Cline_foot_sals_haing.Text.ToString(), Convert.ToDouble(txt_pain_pric_sals.Text), Convert.ToDouble(txt_rest_pric_sals.Text));
                    save_foot_hang.save_Footer_hanging();
                    Close();
                }
            }
            else
            {
                MessageBox.Show("يرجاء ادخال اسم العميل","Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
                return;
            }
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void Txt_pain_pric_sals_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsDigit(e.KeyChar) || e.KeyChar == 8))
            {
                e.Handled = true;
            }
        }
    }
}
