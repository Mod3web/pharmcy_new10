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
    public partial class frm_unlock_detils : Form
    {
        public frm_unlock_detils()
        {
            InitializeComponent();
        }

        private void Frm_unlock_detils_Load(object sender, EventArgs e)
        {
         DataRow[] dr_ditils =  DB_Add_delete_update_.Database.ds.Tables["unlock_ditils"].Select("num_unlock_box = " + txt_num_unlock_chasher.Text);
         object[] ob_unlock_box =  DB_Add_delete_update_.Database.ds.Tables["Unlook_Box"].Rows.Find(txt_num_unlock_chasher.Text).ItemArray;
            if (dr_ditils.Count() != 0)
            {
                txt_first_price.Text = Convert.ToDouble(ob_unlock_box[4]).ToString("N2");
                txt_value_footer_sales.Text = Convert.ToDouble(dr_ditils[0][5]).ToString("N2");
                txt_supply_value.Text = Convert.ToDouble(dr_ditils[0][4]).ToString("N2");
                txt_return_Prodect.Text = Convert.ToDouble(dr_ditils[0][3]).ToString("N2");

                txt_footer_prodect.Text = Convert.ToDouble(dr_ditils[0][2]).ToString("N2");
                txt_return_sales.Text = Convert.ToDouble(dr_ditils[0][6]).ToString("N2");
                txt_cash_exchange.Text = Convert.ToDouble(dr_ditils[0][7]).ToString("N2");

                sum_supply.Text = Convert.ToDouble(Convert.ToDouble(ob_unlock_box[4]) + Convert.ToDouble(dr_ditils[0][5]) + Convert.ToDouble(dr_ditils[0][4]) + Convert.ToDouble(dr_ditils[0][3])).ToString("N2");
                txt_cashe.Text = Convert.ToDouble(Convert.ToDouble(dr_ditils[0][2]) + Convert.ToDouble(dr_ditils[0][6]) + Convert.ToDouble(dr_ditils[0][7])).ToString("N2");
                totile_All_digtal.Text = Convert.ToDouble(Convert.ToDouble(sum_supply.Text) - Convert.ToDouble(txt_cashe.Text)).ToString("N2");
                if (Convert.ToDouble(totile_All_digtal.Text) <0)
                {
                    totile_All_String.Text = MOJ.General.ConvertToLetters(Math.Abs(Convert.ToDecimal(totile_All_digtal.Text)), "ريال", "ريال") + "(سالب)";
                }
                else
                {
                    totile_All_String.Text = MOJ.General.ConvertToLetters(Convert.ToDecimal(totile_All_digtal.Text), "ريال", "ريال");
                }

            }
        }
    }
}
