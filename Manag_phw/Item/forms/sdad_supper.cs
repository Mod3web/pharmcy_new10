using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Manag_ph.Item.forms
{
    public partial class frm_pay_bill : Form
    {
        public frm_pay_bill()
        {
            InitializeComponent();
        }

        public bool show_frm_suppr = false;
        DataRow[] dr_footer;
        DataRow dr_supperr_prodect;
        string path = null;

        private void Frm_pay_bill_Load(object sender, EventArgs e)
        {

        }

        private void TextBox15_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            show_frm_suppr = true;
            new frm_Supper_prodect().ShowDialog();
        }

        private void Txt_num_supper_KeyDown(object sender, KeyEventArgs e)
        {
            // جلب بيانات المورد وعرضها
            if (e.KeyCode == Keys.Enter)
            {
                int num_supper = txt_num_supper.Text.Trim() == string.Empty ? 0 : Convert.ToInt32(txt_num_supper.Text.Trim());
                dr_supperr_prodect = DB_Add_delete_update_.Database.ds.Tables["Supplier"].Rows.Find(num_supper);
                if (dr_supperr_prodect != null)
                {
                    if (Convert.ToInt32(dr_supperr_prodect[4]) == 0)
                    {
                        DataRow dr_Calc_supply = DB_Add_delete_update_.Database.ds.Tables["Calc_supply"].Rows.Find(dr_supperr_prodect[6]);

                        txt_num_supper.Text = dr_supperr_prodect[0].ToString();
                        txt_name_supper.Text = dr_supperr_prodect[1].ToString();
                        txt_name_couns.Text = dr_supperr_prodect[11].ToString();
                        txt_Crdt_supp.Text = Convert.ToDouble(dr_Calc_supply[1]).ToString("N0");
                        txt_Dbt_supp.Text = Convert.ToDouble(dr_Calc_supply[2]).ToString("N0");


                    }
                    else
                    {
                        MessageBox.Show("المورد تم ايقاف التعامل معة ", "توقيف", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        txt_num_supper.Text = "0";
                        txt_name_supper.Clear();
                        txt_name_couns.Clear();


                    }
                }
                else
                {
                    MessageBox.Show("الرقم المدخل غير صحيح", "لايوجد");
                    txt_num_supper.Text = "";
                }
            }
        }

        private void Txt_num_footer_KeyDown(object sender, KeyEventArgs e)
        {
        }

        private void Txt_pric_pal_TextChanged(object sender, EventArgs e)
        {
            if (txt_pric_pal.Text.Trim() != string.Empty)
            {

            }
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            var vr = Application.OpenForms["Main"] as Main;

            if (txt_name_supper.Text == string.Empty)
            {
                MessageBox.Show("يرجاء ادخال بيانات المورد ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                return;

            }
            else if (txt_num_sand.Text == string.Empty)
            {
                MessageBox.Show("يرجاء ادخال رقم السند", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);


                return;

            }
            else if (txt_pric_pal.Text == string.Empty)
            {
                MessageBox.Show("يرجاء ادخال مبلغ السند", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);


                return;
            }




            if (Convert.ToDouble(txt_pric_pal.Text) > Convert.ToDouble(txt_Crdt_supp.Text))
            {
                MessageBox.Show("مبلغ السداد اكبر من رصيد المورد ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            else
            {

                int num = new classs_table.Items_Tools().AoutoNumber("RP_pay_supper", "pay_num");

                // تعديل حساب المورد بلمباغ المسدد
                object[] dr_supperCalc = DB_Add_delete_update_.Database.ds.Tables["Calc_supply"].Rows.Find(dr_supperr_prodect[6]).ItemArray;
                dr_supperCalc[1] = Convert.ToDouble(Convert.ToDouble(dr_supperCalc[1]) - Convert.ToDouble(txt_pric_pal.Text)).ToString("N0");
                new classs_table.Items_Tools().update_Rows_Table_Database("Calc_supply", dr_supperCalc[0].ToString(), dr_supperCalc);


                // حفظ بيانات التسديد من اجل التقارير
                DB_Add_delete_update_.Database.ds.Tables["RP_pay_supper"].Rows.Add(
                    num,
                    txt_num_supper.Text,
                    txt_num_sand.Text.Trim(),
                    Convert.ToDouble(txt_pric_pal.Text),
                    dtp_input_boan.Value,
                    DateTime.Now,
                    vr.txt_Empoly_number.Caption,
                    Convert.ToDouble(dr_supperCalc[1]),
                    Convert.ToDouble(txt_Dbt_supp.Text),
                 path == null ? File.ReadAllBytes("unKnown.png") : File.ReadAllBytes(path));
                MessageBox.Show("تم الحفظ بنجاج", "حفظ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                DB_Add_delete_update_.Database.update("RP_pay_supper");
                Close();

            }





        }

        private void Button1_Click(object sender, EventArgs e)
        {
           

            Close();

        }

        private void Pic_bond_Click(object sender, EventArgs e)
        {
            OpenFileDialog op = new OpenFileDialog();
            op.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyPictures);
            op.Filter = "Image |*.png;*.jpg;*.gif;*.bmp";
            if (op.ShowDialog() == DialogResult.OK)
            {
                path = op.FileName;
                pic_bond.Image = Image.FromFile(op.FileName);
            }
            else
            {
                path = null;
            }
        }
    }
}
