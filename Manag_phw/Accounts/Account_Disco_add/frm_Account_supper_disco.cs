using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Manag_ph.Accounts.Account_Disco_add
{
    public partial class frm_Account_supper_disco : Form
    {
        public frm_Account_supper_disco()
        {
            InitializeComponent();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            new Discount_supper().ShowDialog();
        }

        private void Button4_Click(object sender, EventArgs e)
        {
            new frm_Account_supper_add().ShowDialog();
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            new frm_Discount_account_pharna().ShowDialog();
        }

        private void Button6_Click(object sender, EventArgs e)
        {
            new Accounts.Account_Disco_add.frm_Add_account_pharna().ShowDialog();
        }

        private void Button7_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            new frm_Account_cline_disc().ShowDialog();
        }

        private void Button5_Click(object sender, EventArgs e)
        {
            new frm_Account_Cline_Add().ShowDialog();
        }
    }
}
