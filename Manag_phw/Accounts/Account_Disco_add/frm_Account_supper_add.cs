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
    public partial class frm_Account_supper_add : Form
    {
        public frm_Account_supper_add()
        {
            InitializeComponent();
        }

        private void Frm_Account_supper_add_Load(object sender, EventArgs e)
        {
            new classs_table.My_tool_2().fill_com_alhrca(com_sbb_alhrcka);
        }

        private void Txt_num_supper_discou_acco_add_KeyDown(object sender, KeyEventArgs e)
        {
            // دالة لتعبئة اسم المورد ورصيدة
            new classs_table.Items_Tools().Fill_supper_set_id_get_name(txt_num_supper_discou_acco_add, txt_name_supper_discou_acco_add, txt_Deitor_supper_discou_acco_add, e);

        }

        private void Txt_sals_discount_EditValueChanged(object sender, EventArgs e)
        {
            // حساب رصيد المورد بعد الخصم
            if (txt_sals_discount.Text.Trim() != string.Empty)
            {

                if (txt_name_supper_discou_acco_add.Text.Trim() != string.Empty)
                {
                    DataRow dr_Accou_Clne = DB_Add_delete_update_.Database.ds.Tables["Calc_supply"].Rows.Find(txt_num_supper_discou_acco_add.Text.Trim());
                    
                        txt_sals_begin_calc.Text = Convert.ToDouble(Convert.ToDouble(txt_Deitor_supper_discou_acco_add.Text) + Convert.ToDouble(txt_sals_discount.Text)).ToString("N2");
                    
                }
                else
                {
                    MessageBox.Show("يرجاء ادخال المورد اولن", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                "مورد",// النوع
                null,
                txt_num_supper_discou_acco_add.Text.Trim(),// رقم العميل
                txt_Deitor_supper_discou_acco_add.Text,//الرصيد قبل
                txt_sals_discount.Text.Trim(),// قيمة الخصم
                txt_sals_begin_calc.Text.Trim(),// الرصيد بعد
               Convert.ToInt32(com_sbb_alhrcka.SelectedValue),// سبب الحركة
                textEdit6.Text.Trim(),// الملاحضة
               vr.txt_Empoly_number.Caption);
            DB_Add_delete_update_.Database.update("Report_Account_Add");
        }
        private void Button2_Click(object sender, EventArgs e)
        {
            var vr = Application.OpenForms["Main"] as Main;
            DataRow dt_Emp_use = DB_Add_delete_update_.Database.ds.Tables["TB_LOGIN_EMP"].Rows.Find(new object[] { Convert.ToInt32(vr.txt_user_id_Emp.Caption), vr.txt_user_Emp.Caption });//Convert.ToInt32(vr.txt_user_id_Emp.Caption)
            DataRow dt_Emp_name_use = DB_Add_delete_update_.Database.ds.Tables["TB_Employees"].Rows.Find(dt_Emp_use[4]);
            int num_max = new classs_table.Items_Tools().AoutoNumber("Accounts_suppliers", "id_Accoun_sup");
            // تعديل رصيد المورد بعد الحركة
            if (Convert.ToDouble(txt_sals_begin_calc.Text) >= 0)
            {
                object[] ob_calc = DB_Add_delete_update_.Database.ds.Tables["Calc_supply"].Rows.Find(txt_num_supper_discou_acco_add.Text).ItemArray;
                object[] name_sup = DB_Add_delete_update_.Database.ds.Tables["Clien"].Rows.Find(txt_num_supper_discou_acco_add.Text).ItemArray;
                if (Convert.ToDouble(ob_calc[2]) >= 0 && Convert.ToDouble(ob_calc[1]) == 0)
                {                                                                                           
                    double Sum = Math.Abs(Convert.ToDouble(txt_Deitor_supper_discou_acco_add.Text) + Convert.ToDouble(txt_sals_discount.Text));

                    ob_calc[2] = Sum.ToString("N2");
                    ob_calc[1] = 0;
                    ob_calc[3] = Sum.ToString("N2");
                }
                else if (Convert.ToDouble(ob_calc[1]) >= 0 && Convert.ToDouble(ob_calc[2]) == 0)
                {
                    double Sum = Math.Abs(Convert.ToDouble(txt_sals_discount.Text) - Convert.ToDouble(txt_Deitor_supper_discou_acco_add.Text));

                    ob_calc[1] = Sum.ToString("N2");
                    ob_calc[2] = 0;
                    ob_calc[3] = Sum.ToString("N2");
                }
                else if (Convert.ToDouble(ob_calc[1]) == 0 && Convert.ToDouble(ob_calc[2]) == 0)
                {
                    double Sum = Math.Abs(Convert.ToDouble(txt_Deitor_supper_discou_acco_add.Text) + Convert.ToDouble(txt_sals_discount.Text));

                    ob_calc[2] = Sum.ToString("N2");
                    ob_calc[1] = 0;
                    ob_calc[3] = Sum.ToString("N2");
                }

                new classs_table.Items_Tools().update_Rows_Table_Database("Calc_supply", ob_calc[0].ToString(), ob_calc);
                Save_Data_Report();
                DB_Add_delete_update_.Database.ds.Tables["Accounts_suppliers"].Rows.Add(
                                       num_max,
                                       name_sup[0],
                                       name_sup[1],
                                       dt_Emp_name_use[0],//data_user[0][0],
                                       dt_Emp_name_use[1], // dt_Emp_name_use[1].ToString(),
                                       ob_calc[1],
                                       ob_calc[2],
                                       "اظافة الى حساب",
                                       DateTime.Now,
                                       Convert.ToDouble(txt_sals_discount.Text)
                                 );
                           
                DB_Add_delete_update_.Database.update("Accounts_suppliers");
                MessageBox.Show("تم الاضافة بنجاح", "save", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Close();
            }
            else
            {
                MessageBox.Show("الرصيد بعد الحركة باسالب", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        private void Txt_sals_discount_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsNumber(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }
    }
}
