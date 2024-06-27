using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Manag_ph.forms
{
    public partial class Item_Data : Form
    {
        public Item_Data()
        {
            InitializeComponent();
        }

        DataView dv = new DataView();
        private void Item_Data_Load(object sender, EventArgs e)
        {
            txt_Serch_Item.Text = "";
            dv = DB_Add_delete_update_.Database.dv;
            dgv_Item_Add_dgv.DataSource = dv;
            dgv_Item_Add_dgv.Columns[3].Visible = false;
            dgv_Item_Add_dgv.Columns[4].Visible = false;
            dgv_Item_Add_dgv.Columns[5].Visible = false;
            dgv_Item_Add_dgv.Columns[6].Visible = false;
        }

        private void Dgv_Item_Add_RowHeaderMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {

        }

        private void Dgv_Item_Add_RowHeaderMouseDoubleClick(object sender, MouseEventArgs e)
        {


        }

        private void Dgv_Item_Add_SelectionChanged(object sender, EventArgs e)
        {

        }

        private void Dgv_Item_Add_RowDividerDoubleClick(object sender, DataGridViewRowDividerDoubleClickEventArgs e)
        {

        }

        private void Dgv_Item_Add_DoubleClick(object sender, EventArgs e)
        {
            button1_btn.PerformClick();
        }

        private void Dgv_Item_Add_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Ch_Dow_CheckedChanged(object sender, EventArgs e)
        {
            // جاهز
            if (ch_Dow.Checked)
            {
                if (ch_Stop.Checked)
                {
                    dv.RowFilter = "[الاسم العربي] + [الاسم الانجليزي] + [الشركة المصنعة] + [طبيعة الصنف] + [مكان الصنف] + [المجموعة العلمية]+[المادة الفعالة] +[كود الصنف] like '%" + txt_Serch_Item.Text + "%'  And   [صنف دواء]=" + 1 + "  And   [ايقاف الصنف]=" + 1;

                }
                else if (ch_NoStop.Checked)
                {
                    dv.RowFilter = "[الاسم العربي] + [الاسم الانجليزي] + [الشركة المصنعة] + [طبيعة الصنف] + [مكان الصنف] + [المجموعة العلمية]+[المادة الفعالة] +[كود الصنف] like '%" + txt_Serch_Item.Text + "%'  And   [صنف دواء]=" + 1 + "  And   [ايقاف الصنف]=" + 0;

                }
                else
                {
                    dv.RowFilter = "[الاسم العربي] + [الاسم الانجليزي] + [الشركة المصنعة] + [طبيعة الصنف] + [مكان الصنف] + [المجموعة العلمية]+[المادة الفعالة] +[كود الصنف] like '%" + txt_Serch_Item.Text + "%'  And   [صنف دواء]=" + 1;

                }

            }
        }

        private void Ch_NoDow_CheckedChanged(object sender, EventArgs e)
        {
            if (ch_NoDow.Checked)
            {
                if (ch_Stop.Checked)
                {
                    dv.RowFilter = "[الاسم العربي] + [الاسم الانجليزي] + [الشركة المصنعة] + [طبيعة الصنف] + [مكان الصنف] + [المجموعة العلمية]+[المادة الفعالة] +[كود الصنف] like '%" + txt_Serch_Item.Text + "%'  And   [صنف دواء]=" + 0 + "  And   [ايقاف الصنف]=" + 1;

                }
                else if (ch_NoStop.Checked)
                {
                    dv.RowFilter = "[الاسم العربي] + [الاسم الانجليزي] + [الشركة المصنعة] + [طبيعة الصنف] + [مكان الصنف] + [المجموعة العلمية]+[المادة الفعالة] +[كود الصنف] like '%" + txt_Serch_Item.Text + "%'  And   [صنف دواء]=" + 0 + "  And   [ايقاف الصنف]=" + 0;

                }
                else
                {
                    dv.RowFilter = "[الاسم العربي] + [الاسم الانجليزي] + [الشركة المصنعة] + [طبيعة الصنف] + [مكان الصنف] + [المجموعة العلمية]+[المادة الفعالة] +[كود الصنف] like '%" + txt_Serch_Item.Text + "%'  And   [صنف دواء]=" + 0;

                }

            }
        }

        private void Ch_All_CheckedChanged(object sender, EventArgs e)
        {
            if (ch_All.Checked)
            {
                if (ch_Stop.Checked)
                {
                    dv.RowFilter = "[الاسم العربي] + [الاسم الانجليزي] + [الشركة المصنعة] + [طبيعة الصنف] + [مكان الصنف] + [المجموعة العلمية]+[المادة الفعالة] +[كود الصنف] like '%" + txt_Serch_Item.Text + "%' " + " And [ايقاف الصنف]=" + 1;

                }
                else if (ch_NoStop.Checked)
                {
                    dv.RowFilter = "[الاسم العربي] + [الاسم الانجليزي] + [الشركة المصنعة] + [طبيعة الصنف] + [مكان الصنف] + [المجموعة العلمية]+[المادة الفعالة] +[كود الصنف] like '%" + txt_Serch_Item.Text + "%' And [ايقاف الصنف]=" + 0;

                }
                else
                {
                    dv.RowFilter = "[الاسم العربي] + [الاسم الانجليزي] + [الشركة المصنعة] + [طبيعة الصنف] + [مكان الصنف] + [المجموعة العلمية]+[المادة الفعالة] +[كود الصنف] like '%" + txt_Serch_Item.Text + "%'";

                }

            }
        }

        private void Ch_Stop_CheckedChanged(object sender, EventArgs e)
        {
            //جاهز
            if (ch_Stop.Checked)
            {
                if (ch_Dow.Checked)
                {
                    dv.RowFilter = "[الاسم العربي] + [الاسم الانجليزي] + [الشركة المصنعة] + [طبيعة الصنف] + [مكان الصنف] + [المجموعة العلمية]+[المادة الفعالة] +[كود الصنف] like '%" + txt_Serch_Item.Text + "%'  And   [صنف دواء]=" + 1 + "  And   [ايقاف الصنف]=" + 1;

                }
                else if (ch_NoDow.Checked)
                {
                    dv.RowFilter = "[الاسم العربي] + [الاسم الانجليزي] + [الشركة المصنعة] + [طبيعة الصنف] + [مكان الصنف] + [المجموعة العلمية]+[المادة الفعالة] +[كود الصنف] like '%" + txt_Serch_Item.Text + "%'  And   [صنف دواء]=" + 0 + "  And   [ايقاف الصنف]=" + 1;

                }
                else
                {
                    dv.RowFilter = "[الاسم العربي] + [الاسم الانجليزي] + [الشركة المصنعة] + [طبيعة الصنف] + [مكان الصنف] + [المجموعة العلمية]+[المادة الفعالة] +[كود الصنف] like '%" + txt_Serch_Item.Text + "%'" + "  And   [ايقاف الصنف]=" + 1;

                }

            }

        }

        private void Ch_NoStop_CheckedChanged(object sender, EventArgs e)
        {
            if (ch_NoStop.Checked)
            {
                if (ch_Dow.Checked)
                {
                    dv.RowFilter = "[الاسم العربي] + [الاسم الانجليزي] + [الشركة المصنعة] + [طبيعة الصنف] + [مكان الصنف] + [المجموعة العلمية]+[المادة الفعالة] +[كود الصنف] like '%" + txt_Serch_Item.Text + "%'  And   [صنف دواء]=" + 1 + "  And   [ايقاف الصنف]=" + 0;

                }
                else if (ch_NoDow.Checked)
                {
                    dv.RowFilter = "[الاسم العربي] + [الاسم الانجليزي] + [الشركة المصنعة] + [طبيعة الصنف] + [مكان الصنف] + [المجموعة العلمية]+[المادة الفعالة] +[كود الصنف] like '%" + txt_Serch_Item.Text + "%'  And   [صنف دواء]=" + 0 + "  And   [ايقاف الصنف]=" + 0;

                }
                else
                {
                    dv.RowFilter = "[الاسم العربي] + [الاسم الانجليزي] + [الشركة المصنعة] + [طبيعة الصنف] + [مكان الصنف] + [المجموعة العلمية]+[المادة الفعالة] +[كود الصنف] like '%" + txt_Serch_Item.Text + "%'" + "  And   [ايقاف الصنف]=" + 0;

                }
            }
        }

        private void Ch_Sp_All_CheckedChanged(object sender, EventArgs e)
        {
            //جاهز
            if (ch_Sp_All.Checked)
            {
                if (ch_Dow.Checked)
                {
                    dv.RowFilter = "[الاسم العربي] + [الاسم الانجليزي] + [الشركة المصنعة] + [طبيعة الصنف] + [مكان الصنف] + [المجموعة العلمية]+[المادة الفعالة] +[كود الصنف] like '%" + txt_Serch_Item.Text + "%'  And   [صنف دواء]=" + 1;

                }
                else if (ch_NoDow.Checked)
                {
                    dv.RowFilter = "[الاسم العربي] + [الاسم الانجليزي] + [الشركة المصنعة] + [طبيعة الصنف] + [مكان الصنف] + [المجموعة العلمية]+[المادة الفعالة] +[كود الصنف] like '%" + txt_Serch_Item.Text + "%'  And   [صنف دواء]=" + 0;

                }
                else
                {
                    dv.RowFilter = "[الاسم العربي] + [الاسم الانجليزي] + [الشركة المصنعة] + [طبيعة الصنف] + [مكان الصنف] + [المجموعة العلمية]+[المادة الفعالة] +[كود الصنف] like '%" + txt_Serch_Item.Text + "%'";

                }
            }
        }

        private void Txt_Serch_Item_TextChanged(object sender, EventArgs e)
        {
            //string str = txt_Serch_Item.Text;
            string str = classs_table.Items_Tools.get_str_barcode(txt_Serch_Item);
            // الكل الكل
            string All = "[الاسم العربي] + [الاسم الانجليزي] + [الشركة المصنعة] + [طبيعة الصنف] + [مكان الصنف] + [المجموعة العلمية]+[المادة الفعالة] +[كود الصنف] like '%" + str + "%'";
            //الكل وموقف
            string All_stop = "[الاسم العربي] + [الاسم الانجليزي] + [الشركة المصنعة] + [طبيعة الصنف] + [مكان الصنف] + [المجموعة العلمية]+[المادة الفعالة] +[كود الصنف] like '%" + str + "%' And [ايقاف الصنف] = " + 1;
            //الكل ومش موقف
            string All_Nostop = "[الاسم العربي] + [الاسم الانجليزي] + [الشركة المصنعة] + [طبيعة الصنف] + [مكان الصنف] + [المجموعة العلمية]+[المادة الفعالة] +[كود الصنف] like '%" + str + "%' And [ايقاف الصنف] = " + 0;
            //الكل ودواء
            string All_Dow = "[الاسم العربي] + [الاسم الانجليزي] + [الشركة المصنعة] + [طبيعة الصنف] + [مكان الصنف] + [المجموعة العلمية]+[المادة الفعالة] +[كود الصنف] like '%" + str + "%' And [صنف دواء] = " + 1;
            //الكل ومش دواء
            string All_NoDow = "[الاسم العربي] + [الاسم الانجليزي] + [الشركة المصنعة] + [طبيعة الصنف] + [مكان الصنف] + [المجموعة العلمية]+[المادة الفعالة] +[كود الصنف] like '%" + str + "%' And [صنف دواء] = " + 0;

            //دوا وموقف
            string stop_Dow = "[الاسم العربي] + [الاسم الانجليزي] + [الشركة المصنعة] + [طبيعة الصنف] + [مكان الصنف] + [المجموعة العلمية]+[المادة الفعالة] +[كود الصنف] like '%" + str + "%' And [ايقاف الصنف] = " + 1 + " And[صنف دواء] = " + 1;
            //دواء ومش موقف
            string Dow_Nostop = "[الاسم العربي] + [الاسم الانجليزي] + [الشركة المصنعة] + [طبيعة الصنف] + [مكان الصنف] + [المجموعة العلمية]+[المادة الفعالة] +[كود الصنف] like '%" + str + "%' And [ايقاف الصنف] = " + 0 + " And[صنف دواء] = " + 1;
            //مش دواء وموقف
            string NoDow_stop = "[الاسم العربي] + [الاسم الانجليزي] + [الشركة المصنعة] + [طبيعة الصنف] + [مكان الصنف] + [المجموعة العلمية]+[المادة الفعالة] +[كود الصنف] like '%" + str + "%' And [ايقاف الصنف] = " + 1 + " And[صنف دواء] = " + 0;
            //مش دواء ومش موقف
            string Nodow_Nostop = "[الاسم العربي] + [الاسم الانجليزي] + [الشركة المصنعة] + [طبيعة الصنف] + [مكان الصنف] + [المجموعة العلمية]+[المادة الفعالة] +[كود الصنف] like '%" + str + "%' And [ايقاف الصنف] = " + 0 + " And[صنف دواء] = " + 0;



            if (ch_All.Checked && ch_Sp_All.Checked)
            {
                dv.RowFilter = All;

            }
            else if (ch_All.Checked && ch_Stop.Checked)
            {
                dv.RowFilter = All_stop;

            }
            else if (ch_All.Checked && ch_NoStop.Checked)
            {
                dv.RowFilter = All_Nostop;

            }
            else if (ch_Sp_All.Checked && ch_Dow.Checked)
            {
                dv.RowFilter = All_Dow;

            }
            else if (ch_Sp_All.Checked && ch_NoDow.Checked)
            {
                dv.RowFilter = All_NoDow;

            }
            else if (ch_Dow.Checked && ch_Stop.Checked)
            {
                dv.RowFilter = stop_Dow;


            }
            else if (ch_Dow.Checked && ch_NoStop.Checked)
            {
                dv.RowFilter = Dow_Nostop;


            }
            else if (ch_NoDow.Checked && ch_Stop.Checked)
            {
                dv.RowFilter = NoDow_stop;


            }
            else if (ch_NoDow.Checked && ch_NoStop.Checked)
            {
                dv.RowFilter = Nodow_Nostop;


            }

        }
        bool b = false;
        private void Button1_Click(object sender, EventArgs e)
        {
            var fr = Application.OpenForms["Main"] as Main;
            if (fr.Open_Storg)
            {
                if (dgv_Item_Add_dgv.CurrentRow != null)
                {
                    storg.open_blans_storg m1 = new storg.open_blans_storg();


                    fr.dgv_open_storg_dgv.Rows.Add();
                    int count = fr.dgv_open_storg_dgv.Rows.Count;
                    string Item_no = dgv_Item_Add_dgv.CurrentRow.Cells[0].Value + "";
                    if (Item_no.Trim() != string.Empty)
                    {

                        fr.dgv_open_storg_dgv.Rows[count - 1].Cells[0].Value = Item_no;
                        int num = Convert.ToInt32(Item_no);
                        DataRow[] drItem = DB_Add_delete_update_.Database.ds.Tables["Item"].Select("Item_no =" + num);
                        if (drItem.Count() != 0)
                        {
                            if (Convert.ToBoolean(drItem[0][8]) == false)
                            {
                                fr.dgv_open_storg_dgv.Rows[count - 1].Cells[1].Value = drItem[0][1].ToString();
                                //fr.dgv_open_storg.CurrentRow.Cells[3].Value = "1";
                                //fr.dgv_open_storg.CurrentRow.Cells[4].Value = "0";
                                DataGridViewComboBoxColumn dgv_com = (DataGridViewComboBoxColumn)fr.dgv_open_storg_dgv.Columns[2];
                                DataGridViewComboBoxCell comboBoxCell = (fr.dgv_open_storg_dgv.Rows[count - 1].Cells[2] as DataGridViewComboBoxCell);
                                //جلب بيانات الوحداد والتسعيرات والكميات
                                DataRow[] dr_unit = DB_Add_delete_update_.Database.ds.Tables["unite_items"].Select("item_no =" + num);
                                DataRow[] dr_pricc = DB_Add_delete_update_.Database.ds.Tables["pric"].Select("item_no =" + num);
                                List<string> list = new List<string>();
                                for (int i = 1; i <= 3; i++)
                                {
                                    DataRow Item_unit3 = DB_Add_delete_update_.Database.ds.Tables["therpeutic_unite"].Rows.Find(dr_unit[0][i]);
                                    list.Add(Item_unit3[1].ToString());
                                }
                                DataTable dt = new DataTable();
                                dt.TableName = num + "";
                                dt.Columns.Add("unit_unit");
                                dt.Columns.Add("unit_pric");
                                dt.Columns.Add("unit_num");
                                //جدول بيانات  الوحدات والتسعيرات والكميات
                                dt.Rows.Add(list[0], dr_pricc[0][1], dr_pricc[0][5]);
                                dt.Rows.Add(list[1], dr_unit[0][6], dr_unit[0][4]);
                                dt.Rows.Add(list[2], dr_unit[0][7], dr_unit[0][5]);
                                //تعبئة الكمبو بكس بلجدول
                                comboBoxCell.Items.Clear();
                                comboBoxCell.Items.AddRange(dt.Rows[0][0], dt.Rows[1][0], dt.Rows[2][0]);
                                comboBoxCell.Value = comboBoxCell.Items[0];
                                fr.dgv_open_storg_dgv.Rows[count - 1].Cells[6].Value = dt.Rows[0][1];
                                fr.dgv_open_storg_dgv.Rows[count - 1].Cells[9].Value = dt.Rows[0][1];
                                //fr.dgv_open_storg_dgv.Rows[count - 1].Cells[9].Value = dt.Rows[0][2];
                                fr.dgv_open_storg_dgv.Rows[count - 1].Cells[3].Value = txt_qut.Text;
                                fr.dgv_open_storg_dgv.Rows[count - 1].Cells[4].Value = txt_pons.Text;
                                fr.dgv_open_storg_dgv.Rows[count - 1].Cells[7].Value = "0";
                                fr.dgv_open_storg_dgv.Rows[count - 1].Cells[8].Value = "0";
                                fr.dgv_open_storg_dgv.Rows[count - 1].Cells[5].Value = b == true ? dtp_E.Text : "";
                                if (!classs_table.Items_Tools.Dataunit.Tables.Contains(num.ToString()))
                                {
                                    classs_table.Items_Tools.Dataunit.Tables.Add(dt);
                                }
                            }
                            else
                            {
                                MessageBox.Show("تم ايقاف التعامل معاء الصنف", "لايوجد");
                               fr.dgv_open_storg_dgv.Rows.RemoveAt(fr.dgv_open_storg_dgv.RowCount -1);
                                new storg.open_blans_storg().Totle_price();
                            }

                        }
                        else
                        {
                            MessageBox.Show("لايوجد صنف بهاذا الرقم", "لايوجد");
                        }
                    }
                    else
                    {
                        MessageBox.Show("يرجا التاكد من المدخلات ");

                    }
                    m1.Totle_price();
                    m1.Won();
                    Close();
                    fr.Open_Storg = false;
                }
                else
                {
                    MessageBox.Show("الصنف ليس موجود");

                    return;
                }
            }
            else if (fr.prodect_open_Items)
            {
                if (dgv_Item_Add_dgv.CurrentRow != null)
                {
                    if (fr.dgv_prodect_dgv.CurrentRow != null)
                    {
                        if (fr.dgv_prodect_dgv.Rows[fr.dgv_prodect_dgv.Rows.Count - 1].Cells[14].Value.ToString() == "null")
                        {
                            fr.dgv_prodect_dgv.Rows[fr.dgv_prodect_dgv.Rows.Count - 1].Cells[1].Value = dgv_Item_Add_dgv.CurrentRow.Cells[0].Value;
                            fr.dgv_prodect_dgv.Rows[fr.dgv_prodect_dgv.Rows.Count - 1].Cells[1].Selected = true;
                            fr.dgv_prodect_dgv.Rows[fr.dgv_prodect_dgv.Rows.Count - 1].Cells[4].Value = txt_qut.Text;
                            fr.dgv_prodect_dgv.Rows[fr.dgv_prodect_dgv.Rows.Count - 1].Cells[5].Value = dtp_E.Text;
                            fr.dgv_prodect_dgv.Rows[fr.dgv_prodect_dgv.Rows.Count - 1].Cells[6].Value = txt_pons.Text;
                            new prodects.Footer_prodect()._DataGridView5_CellEndEdit();

                        }
                        else
                        {
                            fr.dgv_prodect_dgv.Rows.Add();
                            fr.dgv_prodect_dgv.Rows[fr.dgv_prodect_dgv.Rows.Count - 1].Cells[14].Value = "null";
                            fr.dgv_prodect_dgv.Rows[fr.dgv_prodect_dgv.Rows.Count - 1].Cells[1].Value = dgv_Item_Add_dgv.CurrentRow.Cells[0].Value;
                            fr.dgv_prodect_dgv.Rows[fr.dgv_prodect_dgv.Rows.Count - 1].Cells[1].Selected = true;
                            fr.dgv_prodect_dgv.Rows[fr.dgv_prodect_dgv.Rows.Count - 1].Cells[4].Value = txt_qut.Text;
                            fr.dgv_prodect_dgv.Rows[fr.dgv_prodect_dgv.Rows.Count - 1].Cells[5].Value = dtp_E.Text;
                            fr.dgv_prodect_dgv.Rows[fr.dgv_prodect_dgv.Rows.Count - 1].Cells[6].Value = txt_pons.Text;

                            new prodects.Footer_prodect()._DataGridView5_CellEndEdit();

                        }
                    }
                    else
                    {
                        fr.dgv_prodect_dgv.Rows.Add();
                        fr.dgv_prodect_dgv.Rows[fr.dgv_prodect_dgv.Rows.Count - 1].Cells[14].Value = "null";
                        fr.dgv_prodect_dgv.Rows[fr.dgv_prodect_dgv.Rows.Count - 1].Cells[1].Value = dgv_Item_Add_dgv.CurrentRow.Cells[0].Value;
                        fr.dgv_prodect_dgv.Rows[fr.dgv_prodect_dgv.Rows.Count - 1].Cells[1].Selected = true;
                        fr.dgv_prodect_dgv.Rows[fr.dgv_prodect_dgv.Rows.Count - 1].Cells[4].Value = txt_qut.Text;
                        fr.dgv_prodect_dgv.Rows[fr.dgv_prodect_dgv.Rows.Count - 1].Cells[5].Value = dtp_E.Text;
                        fr.dgv_prodect_dgv.Rows[fr.dgv_prodect_dgv.Rows.Count - 1].Cells[6].Value = txt_pons.Text;
                        new prodects.Footer_prodect()._DataGridView5_CellEndEdit();


                    }
                    fr.prodect_open_Items = false;
                    Close();
                }
            }
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void DateTimePicker2_ValueChanged(object sender, EventArgs e)
        {

        }

        private void DateTimePicker2_KeyPress(object sender, KeyPressEventArgs e)
        {
            b = true;
        }

        private void DateTimePicker2_MouseDown(object sender, MouseEventArgs e)
        {
            b = true;
        }
    }
}
