using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Manag_ph.Client.Contracts
{
    public partial class Discount_cont_frm : Form
    {
        public Discount_cont_frm()
        {
            InitializeComponent();
        }

        private void LabelControl1_Click(object sender, EventArgs e)
        {

        }

        private void GroupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void Txt_num_cont_TextChanged(object sender, EventArgs e)
        {
            var vr = Application.OpenForms["Main"] as Main;

            int num = Convert.ToInt32(txt_Discount_cont.Text);

            vr.txt_Dise_rate_cont.Text = txt_Discount_cont.Text;
            txt_Dise_bill_cont.Text = (100 - num).ToString();

            if (vr.txt_Dise_rate_cont.Text != string.Empty)
            {


                if (vr.rid_company.Checked)
                {
                    vr.txt_Dise_bill_clin.Text = (100 - num).ToString();

                }


                if (vr.rid_clin.Checked)
                {
                    vr.txt_Dise_bill_clin.Text = num.ToString();
                }
            }
        }

        private void Discount_cont_frm_Load(object sender, EventArgs e)
        {
            txt_Discount_cont.Text = "0";
            txt_Dise_bill_cont.Text = "0";
        }

        private void Button8_Click(object sender, EventArgs e)
        {
            var vr = Application.OpenForms["Main"] as Main;


            vr.txt_Dise_rate_cont.Text = txt_Discount_cont.Text;
            vr.txt_Dise_bill_clin.Text = txt_Dise_bill_cont.Text;
          
            //vr.btn_Show_Discount_frm.Enabled = false;
            this.Close();

        }
    }
}
