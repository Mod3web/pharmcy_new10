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
    public partial class frm_save_sals_Cline : Form
    {
        public frm_save_sals_Cline()
        {
            InitializeComponent();
        }

        private void Frm_save_sals_Cline_Load(object sender, EventArgs e)
        {
            //txt_after_pand_cash
            var vr = Application.OpenForms["Main"] as Main;
            txt_sals_begin_cash.Text = vr.txt_end_Dico_All_sals.Text;
            txt_sals_pand_cash.Text = "0";
            txt_after_pand_cash.Text = Convert.ToDouble(Convert.ToDouble("0") - Convert.ToDouble(txt_sals_begin_cash.Text)).ToString("N2");
            txt_sals_pand_cash.Select();
            txt_sals_pand_cash.SelectAll();

        }

        private void Txt_sals_pand_cash_KeyUp(object sender, KeyEventArgs e)
        {

            txt_after_pand_cash.Text = txt_sals_pand_cash.Text.Trim() == String.Empty ?((-1)*Convert.ToDouble(txt_sals_begin_cash.Text)).ToString("N2") : Convert.ToDouble(Convert.ToDouble(txt_sals_pand_cash.Text) - Convert.ToDouble(txt_sals_begin_cash.Text)).ToString("N2");


        }

        private void Button1_Click(object sender, EventArgs e)
        {
            var dr = Application.OpenForms["Main"] as Main;

            if (dr.txt_name_cline_sals.Text.Trim() != string.Empty)
            {
                object[] ob_cline = DB_Add_delete_update_.Database.ds.Tables["Clien"].Rows.Find(dr.txt_num_cline_sals.Text.Trim()).ItemArray;
                object[] ob_cline_Account = DB_Add_delete_update_.Database.ds.Tables["Stock_client"].Rows.Find(ob_cline[10]).ItemArray;
                double sum =  Math.Abs(Convert.ToDouble(txt_after_pand_cash.Text)) + Convert.ToDouble(ob_cline_Account[1]);                    ///Convert.ToDouble(ob_cline[7])
                // التحقق من المبغ المتبقي اكبر اصغر من حد التعامل
                if (Convert.ToDouble(ob_cline[9]) == 0)
                {
                   
                }
                //txt_after_pand_cash
                else if (Math.Abs(Convert.ToDouble(txt_after_pand_cash.Text)) > Convert.ToDouble(ob_cline[9]))
                {
                    MessageBox.Show("المبغ المتبقي اكبر من حد الفاتورة معاء العميل");
                    return;
                }
                else if ((Math.Abs(Convert.ToDouble(txt_after_pand_cash.Text)) + Convert.ToDouble(ob_cline_Account[1])) > Convert.ToDouble(ob_cline[7]))
                {
                    MessageBox.Show("المبغ المتبقي اكبر من حد التعامل مع العميل");
                    return;
                }

                new Sales.Save_Footer_Sals().Save_Footer_Item();
                Close();

            }
            else
            {
                MessageBox.Show("يرجاء ادخال العميل ");
            }
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void Txt_sals_pand_cash_TextChanged(object sender, EventArgs e)
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
