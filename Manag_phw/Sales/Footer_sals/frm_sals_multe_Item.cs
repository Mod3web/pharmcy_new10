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
    public partial class frm_sals_multe_Item : Form
    {
        public frm_sals_multe_Item()
        {
            InitializeComponent();
        }
            DataTable dt;

        private void Frm_sals_multe_Item_Load(object sender, EventArgs e)
        {
            var vr = Application.OpenForms["Main"] as Main;
            DataTable dt = new classs_table.Items_Tools().GetItems_Storg_All(Convert.ToInt32(vr.txt_id_storg_sels.Text));

            DataRow[] dr_Item_Storg = dt.Select("Item_no = " + vr.dgv_sals_dgv.CurrentRow.Cells[1].Value);

            if (dr_Item_Storg.Count() != 0)
            {

                List<int> num_Item_storg_begin = new List<int>(); // تحفظ رقم الصنف الذي يوجد فية كميات
                Dictionary<int, DateTime> Trteb = new Dictionary<int, DateTime>(); // تحفظ تاريخ الصنف معا رقمة 
                for (int i = 0; i < dr_Item_Storg.Count(); i++)
                {
                    if (Convert.ToInt32(dr_Item_Storg[i][14]) > 0) // فلترت الاصناف التي الكمية صفر
                    {
                        if (Convert.ToDateTime(dr_Item_Storg[i][2]) > DateTime.Now) // فلترت التواريخ المنتهية
                        {
                            Trteb.Add(Convert.ToInt32(dr_Item_Storg[i][0]), Convert.ToDateTime(dr_Item_Storg[i][2]));// حفظ الرقم معا تاريخ الصلاحية
                            num_Item_storg_begin.Add((int)dr_Item_Storg[i][0]);// حفظ الرقم المفلتر
                        }
                    }

                }
                if (Trteb.Count != 0)
                {
                    // الترتيب
                    DateTime temp;
                    for (int i = 0; i < Trteb.Count; i++)
                    {
                        for (int j = i + 1; j < Trteb.Count; j++)
                        {
                            if (Convert.ToDateTime(Trteb[(int)num_Item_storg_begin[i]]) > Convert.ToDateTime(Trteb[(int)num_Item_storg_begin[j]]))
                            {
                                temp = Trteb[(int)num_Item_storg_begin[i]];
                                Trteb[(int)num_Item_storg_begin[i]] = Trteb[(int)num_Item_storg_begin[j]];
                                Trteb[(int)num_Item_storg_begin[j]] = temp;
                            }
                        }
                    }
                    List<int> ls = Trteb.Keys.ToList();
                    for (int i = 0; i < Trteb.Count; i++)
                    {
                        if (Trteb.Count > 1)
                        {
                            object[] ob_Item_storg = DB_Add_delete_update_.Database.ds.Tables["Item_storg"].Rows.Find(ls[i]).ItemArray;
                            object[] ob_Item = DB_Add_delete_update_.Database.ds.Tables["Item"].Rows.Find(ob_Item_storg[9]).ItemArray;
                            object[] ob_effct = DB_Add_delete_update_.Database.ds.Tables["effective_material"].Rows.Find(ob_Item[15]).ItemArray;// المادة الفعالة
                            object[] ob_natural = DB_Add_delete_update_.Database.ds.Tables["nature_of_Item"].Rows.Find(ob_Item[16]).ItemArray;// طبيعة الصنف
                            object[] ob_reason = DB_Add_delete_update_.Database.ds.Tables["reason_for_user"].Rows.Find(ob_Item[16]).ItemArray;// سبب الاستخداام
                            dgv_multy_Item_dgv.Rows.Add(ob_Item_storg[9], ob_Item[1], Convert.ToDateTime(ob_Item_storg[2]), Convert.ToDouble(ob_Item_storg[8]).ToString("N2"), ob_effct[1], ob_natural[1], ob_reason[1], ob_Item_storg[0]);
                        }

                    }

                }
            }

            dgv_multy_Item_dgv.Sort(dgv_multy_Item_dgv.Columns[2], ListSortDirection.Ascending);// ترتيب علا حسب تاريخ الصلاحية
            for (int i = 0; i < dgv_multy_Item_dgv.Rows.Count; i++)
            {
                dgv_multy_Item_dgv.Rows[i].Cells[2].Value = Convert.ToDateTime(dgv_multy_Item_dgv.Rows[i].Cells[2].Value).ToString("d");
            }
            dgv_multy_Item_dgv.Rows[0].Cells[0].Selected = true;
        }

        bool Com_Selectv = false;
        private void Dgv_multy_Item_SelectionChanged(object sender, EventArgs e)
        {
            if (dgv_multy_Item_dgv.CurrentRow != null)
            {
                DataRow dr_Item_storg = DB_Add_delete_update_.Database.ds.Tables["Item_storg"].Rows.Find(dgv_multy_Item_dgv.CurrentRow.Cells[7].Value);
                DataRow[] dr_unit_pro = DB_Add_delete_update_.Database.ds.Tables["unite_items"].Select("Item_no = " + dgv_multy_Item_dgv.CurrentRow.Cells[0].Value);// جلب بيانات الوحداد

                DataRow dr_unit_pro_kptol = DB_Add_delete_update_.Database.ds.Tables["therpeutic_unite"].Rows.Find(Convert.ToInt32(dr_unit_pro[0][1]));
                DataRow dr_unit_pro_avrg = DB_Add_delete_update_.Database.ds.Tables["therpeutic_unite"].Rows.Find(Convert.ToInt32(dr_unit_pro[0][2]));
                DataRow dr_unit_pro_smool = DB_Add_delete_update_.Database.ds.Tables["therpeutic_unite"].Rows.Find(Convert.ToInt32(dr_unit_pro[0][3]));
                txt_pric_sals.Text = Convert.ToDouble(dgv_multy_Item_dgv.CurrentRow.Cells[3].Value).ToString("N2");
                // عرض الوحدة التي تم ادخال الصنف الا المخزن بها والوحدات التي اصغر منها
                dt = new DataTable();
                dt.Columns.Add("num", typeof(int));
                dt.Columns.Add("name", typeof(string));

                if (Convert.ToInt32(dr_Item_storg[12]) == 1)
                {
                    dt.Rows.Add(1, dr_unit_pro_kptol[1].ToString());
                    dt.Rows.Add(2, dr_unit_pro_avrg[1].ToString());
                    dt.Rows.Add(3, dr_unit_pro_smool[1].ToString());

                }
                else if (Convert.ToInt32(dr_Item_storg[12]) == 2)
                {
                    dt.Rows.Add(2, dr_unit_pro_avrg[1].ToString());
                    dt.Rows.Add(3, dr_unit_pro_smool[1].ToString());
                }
                else if (Convert.ToInt32(dr_Item_storg[12]) == 3)
                {
                    dt.Rows.Add(3, dr_unit_pro_smool[1].ToString());

                }
                txt_qty.Text = dr_Item_storg[1].ToString();
                com_unit.DataSource = dt;
                com_unit.DisplayMember = "name";
                com_unit.ValueMember = "num";
                Com_Selectv = true;

            }


        }
        private void Button2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            var vr = Application.OpenForms["Main"] as Main;
            new Sales.Sales_open_Add().fill_Com_(vr.dgv_sals_dgv, (int)dgv_multy_Item_dgv.CurrentRow.Cells[0].Value, (int)dgv_multy_Item_dgv.CurrentRow.Cells[7].Value,(int)com_unit.SelectedValue);
            vr.dgv_sals_dgv.CurrentRow.Cells[5].Value = txt_qty_sals.Text;// الكمية
            vr.dgv_sals_dgv.CurrentRow.Cells[6].Value = txt_pric_sals.Text;// سعر البيع
            vr.dgv_sals_dgv.CurrentRow.Cells[7].Value = txt_qty.Text;// الرصيد
            vr.dgv_sals_dgv.CurrentRow.Cells[9].Value = txt_pric_sals.Text;// القيمة قبل الخصم
            vr.dgv_sals_dgv.CurrentRow.Cells[12].Value = txt_pric_sals.Text; // القيمة بعد الخصم
            vr.dgv_sals_dgv.CurrentRow.Cells[13].Value = Convert.ToDouble(txt_pric_sals.Text) * Convert.ToInt32(txt_qty_sals.Text); // القيمة بعد الخصم
            new Sales.Sales_open_Add().Totil_All_Fotter_sals();

            Close();
        }

        private void Com_unit_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Com_Selectv)
            {
                DataRow dr_Item_storg = DB_Add_delete_update_.Database.ds.Tables["Item_storg"].Rows.Find(dgv_multy_Item_dgv.CurrentRow.Cells[7].Value);
                DataRow[] dr_unit = DB_Add_delete_update_.Database.ds.Tables["unite_items"].Select("item_no =" + dr_Item_storg[9]);
                double sals_pric = Convert.ToDouble(dr_Item_storg[8]);
                double temp = Convert.ToDouble(dr_Item_storg[8]);
                // تحديد الوحدة التي تم ادخالها ثم تحديد ثم تحديد الكمية
                if (Convert.ToInt32(dr_Item_storg[12]) == 1)
                {
                    if (Convert.ToInt32(com_unit.SelectedValue) == 1)
                    {
                        txt_qty.Text = dr_Item_storg[1].ToString();

                    }// لو كان الادخال وحدة كبرا والبيع وحدة وسطاء
                    else if (Convert.ToInt32(com_unit.SelectedValue) == 2)
                    {
                        txt_qty.Text = dr_Item_storg[13].ToString();
                        sals_pric = Convert.ToDouble(temp / Convert.ToInt32(dr_unit[0][2]));

                    }// لو كان الادخال وحدة كبرا والبيع وحدة صغرا
                    else if (Convert.ToInt32(com_unit.SelectedValue) == 3)
                    {
                        txt_qty.Text = dr_Item_storg[14].ToString();
                      double  sals_pric_avrg = Convert.ToDouble(temp / Convert.ToInt32(dr_unit[0][2]));
                      sals_pric = Convert.ToDouble(sals_pric_avrg / Convert.ToInt32(dr_unit[0][3]));

                    }
                }// لو كان الادخال وحدة وسطاء 
                else if (Convert.ToInt32(dr_Item_storg[12]) == 2)
                {
                    // لو كان الادخال وحدة وسطاء والبيع وحدة وسطاء
                    if (Convert.ToInt32(com_unit.SelectedValue) == 2)
                    {
                        txt_qty.Text = dr_Item_storg[1].ToString();
                        sals_pric = Convert.ToDouble(dr_Item_storg[8]);
                    }// لو كان الادخال وحدة وسطاء والبيع وحدة صغرا
                    else if (Convert.ToInt32(com_unit.SelectedValue) == 3)
                    {
                        txt_qty.Text = dr_Item_storg[14].ToString();
                        sals_pric = Convert.ToDouble(temp / Convert.ToInt32(dr_unit[0][3]));

                    }
                }// لو كان الادخال وحدة صغرا والبيع وحدة صغرا
                else if (Convert.ToInt32(dr_Item_storg[12]) == 3)
                {
                    if (Convert.ToInt32(com_unit.SelectedValue) == 3)
                    {
                        txt_qty.Text = dr_Item_storg[1].ToString();
                        sals_pric = Convert.ToDouble(dr_Item_storg[8]);

                    }
                }
                txt_pric_sals.Text = sals_pric.ToString("N2");// سعر البيع الجديد

            }

        }

        private void TextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void Txt_qty_sals_KeyUp(object sender, KeyEventArgs e)
        {
            if (txt_qty_sals.Text.Trim() != string.Empty)
            {
                if (Convert.ToInt32(txt_qty_sals.Text) > Convert.ToInt32(txt_qty.Text))
                {
                    MessageBox.Show("الكمية المدخلة اكبر من الرصيد","Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
                    txt_qty_sals.Text = "1";
                    txt_qty_sals.SelectAll();
                }
            }
            else
            {
                txt_qty_sals.Text = "1";
            }
        }
    }
}
