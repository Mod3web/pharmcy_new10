using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Manag_ph.Item.forms;

namespace Manag_ph.Accounts.Account_Disco_add
{
    public partial class frm_Add_account_pharna : Form
    {
        public frm_Add_account_pharna()
        {
            InitializeComponent();
        }

        
        private void Button1_Click(object sender, EventArgs e)
        {
            //var vr = Application.OpenForms["frm_casher_And_fund"] as frm_casher_And_fund;
            frm_casher_And_fund vr = new frm_casher_And_fund();
            vr.show_Add = true;
           vr.ShowDialog();
        }

        private void Frm_Add_account_pharna_Load(object sender, EventArgs e)
        {
            new classs_table.My_tool_2().fill_com_alhrca(com_sbb_alhrcka);

        }

        private void Txt_sals_discount_EditValueChanged(object sender, EventArgs e)
        {
            if (txt_sals_discount.Text.Trim() != string.Empty)
            {
                if (txt_name_supper_discou_acco_add.Text.Trim() != string.Empty)
                {
                    txt_sals_begin_calc.Text = Convert.ToDouble(Convert.ToDouble(txt_Deitor_supper_discou_acco_add.Text) + Convert.ToDouble(txt_sals_discount.Text)).ToString("N2");
                }
                else
                {
                    txt_sals_begin_calc.Text = "";

                    MessageBox.Show("يرجاء ادخال المصدر ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
        }

        void Save_Data_Report()
        {
            var vr = Application.OpenForms["Main"] as Main;
            int num = new classs_table.Items_Tools().AoutoNumber("Report_Account_Add", "num_Re_Acc_Add");


            DB_Add_delete_update_.Database.ds.Tables["Report_Account_Add"].Rows.Add(
                num,// الكود
                DateTime.Now,// تاريح الخصم
                "المؤسسة",// النوع
                type.Text,// النوع صندوق او كاشير من اين تم الخصم
                txt_num_supper_discou_acco_add.Text.Trim(),// رقم 
                txt_Deitor_supper_discou_acco_add.Text,//الرصيد قبل
                txt_sals_discount.Text.Trim(),// قيمة الخصم
                txt_sals_begin_calc.Text.Trim(),// الرصيد بعد
               Convert.ToInt32(com_sbb_alhrcka.SelectedValue),// سبب الحركة
                textEdit6.Text.Trim(),// الملاحظة
vr.txt_Empoly_number.Caption);
            DB_Add_delete_update_.Database.update("Report_Account_Add");
        }
        private void Button2_Click(object sender, EventArgs e)
        {
            DataRow[] dr_casher = DB_Add_delete_update_.Database.ds.Tables["casher"].Select("casher_num = " + txt_num_supper_discou_acco_add.Text + " and casher_name = '" + txt_name_supper_discou_acco_add.Text + "'");
            DataRow[] dr_fund = DB_Add_delete_update_.Database.ds.Tables["account_fund"].Select("fund_num = " + txt_num_supper_discou_acco_add.Text + " and fund_name_ar = '" + txt_name_supper_discou_acco_add.Text + "'");
            // لو كان يرد السداد نقد ومن الكاشير
            if (dr_casher.Count() != 0)
            {
                object[] ob_account_casher = DB_Add_delete_update_.Database.ds.Tables["casher_account"].Rows.Find(dr_casher[0][5]).ItemArray;

                double sum_sals_casher_Account = Convert.ToDouble(ob_account_casher[1]);

                if (txt_sals_discount.Text != string.Empty)
                {
                ob_account_casher[1] = Convert.ToDouble(Convert.ToDouble(txt_Deitor_supper_discou_acco_add.Text) + Convert.ToDouble(txt_sals_discount.Text)).ToString("N2");
                new classs_table.Items_Tools().update_Rows_Table_Database("casher_account", ob_account_casher[0].ToString(), ob_account_casher);
                    Save_Data_Report();
                    MessageBox.Show("تم الاضافة بنجاح", "Save", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Close();
                }
                else
                {
                    MessageBox.Show("يرجا التحقق من المدخلات");
                    return;
                }


            }
            // لو كان يرد السداد نقد ومن الصندوق
            else if (dr_fund.Count() != 0)
            {
                object[] ob_account_fund = DB_Add_delete_update_.Database.ds.Tables["fund_sals"].Rows.Find(dr_fund[0][4]).ItemArray;

                double sum_sals_fund_sals = Convert.ToDouble(ob_account_fund[1]);
                //MessageBox.Show(sum_sals_fund_sals + "");
                if (txt_sals_discount.Text != string.Empty)
                {
                    ob_account_fund[1] = Convert.ToDouble(Convert.ToDouble(txt_Deitor_supper_discou_acco_add.Text) + Convert.ToDouble(txt_sals_discount.Text)).ToString("N2");
                    new classs_table.Items_Tools().update_Rows_Table_Database("fund_sals", ob_account_fund[0].ToString(), ob_account_fund);
                    Save_Data_Report();
                    MessageBox.Show("تم الاضافة بنجاح", "Save", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Close();
                }
                else
                {
                    MessageBox.Show("يرجا التحقق من المدخلات");
                    return;
                }


                // ننقص قيمة الفاتورة من رصيد الصندوق
        

            }
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
