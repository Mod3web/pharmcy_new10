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
    public partial class Item_transfromtion : Form
    {
        public Item_transfromtion()
        {
            InitializeComponent();
        }

        private void Item_transfromtion_Load(object sender, EventArgs e)
        {

            var fr = Application.OpenForms["Main"] as Main;



            if (fr.dgv_tranformtion_dgv.CurrentRow.Cells[0].Value != null)
            {
                if (fr.txt_num_storg_send.Text != string.Empty && fr.txt_name_storg_send.Text != string.Empty)
                {
                    DataRow[] data_sum = DB_Add_delete_update_.Database.ds.Tables["sum_storg_Item"].Select("Storg_no = " + Convert.ToInt32(fr.txt_num_storg_send.Text));

                    if (data_sum != null)
                    {
                        DataRow[] data_Item_storg = null;
                        DataTable dttest = new DataTable();
                        string[] Coloumns = { "رقم الصنف المخزني", "الكمية", "تاريخ الانتها", "البونص", "الخصم", "الضريبة", "الربح", "سعر الشراء", "سعر البيع", "رقم الصنف", "رقم الوحدة", "رقم المجاميع", "نوع الوحدة", "عدد الوحدات الوسطاء", "عدد الوحدات الصغرا" };
                        foreach (string item in Coloumns)
                        {
                            dttest.Columns.Add(item);
                        }

                        for (int i = 0; i < data_sum.Count(); i++)
                        {

                            data_Item_storg = DB_Add_delete_update_.Database.ds.Tables["Item_storg"].Select("sum_num = " + Convert.ToInt32(data_sum[i][0]) + " And Item_no = " + Convert.ToInt32(fr.dgv_tranformtion_dgv.CurrentRow.Cells[0].Value));
                            foreach (DataRow item in data_Item_storg)
                            {
                                object[] ob = item.ItemArray;
                                dttest.Rows.Add(ob);

                            }

                        }


                        


                        DataRow Item_name = DB_Add_delete_update_.Database.ds.Tables["Item"].Rows.Find(Convert.ToInt32(fr.dgv_tranformtion_dgv.CurrentRow.Cells[0].Value));

                        DataRow[] unit_quit = DB_Add_delete_update_.Database.ds.Tables["unite_items"].Select("item_no = " + fr.dgv_tranformtion_dgv.CurrentRow.Cells[0].Value);
                        DataRow unit11 = DB_Add_delete_update_.Database.ds.Tables["therpeutic_unite"].Rows.Find(Convert.ToInt32(unit_quit[0][1]));
                        DataRow unit112 = DB_Add_delete_update_.Database.ds.Tables["therpeutic_unite"].Rows.Find(Convert.ToInt32(unit_quit[0][2]));
                        if (dttest.Rows.Count != 0)
                        {



                            int red = 255;
                            int Gren = 255;
                            int blu = 255;
                            int ty = 5;

                            int red2 = 255;
                            int green = 255;
                            int color_unit_count = 0;
                            for (int i = 0; i < dttest.Rows.Count; i++)
                            {


                                if (i != 0)
                                {
                                    if (dttest.Rows[i][2].ToString() != dttest.Rows[i - 1][2].ToString())
                                    { 
                                        red = 100;
                                        Gren = ty;
                                        blu = 80;
                                        ty += 5;
                                    }
                                }
                                else
                                {
                                    red = 150;
                                    Gren = ty;
                                    blu = 80;
                                    ty += 5;
                                }


                                double pric_qubtl = 0;
                                double pric_avrg = 0;
                                double pric_smool = 0;

                                double pro_qubtl = 0;
                                double pro_avrg = 0;
                                double pro_smool = 0;
                                if (Convert.ToInt32(dttest.Rows[i][12])==1)
                                {
                                    pric_qubtl = Convert.ToDouble(dttest.Rows[i][8]);
                                    pric_avrg = (pric_qubtl / Convert.ToDouble(unit_quit[0][4]));
                                    pric_smool = pric_avrg / Convert.ToDouble(unit_quit[0][5]);


                                    pro_qubtl = Convert.ToDouble(dttest.Rows[i][7]);
                                    pro_avrg = (pro_qubtl / Convert.ToDouble(unit_quit[0][4]));
                                    pro_smool = pro_avrg  / Convert.ToDouble(unit_quit[0][5]);
                                }
                                else if (Convert.ToInt32(dttest.Rows[i][12]) == 2)
                                {
                                    pric_avrg = Convert.ToDouble(dttest.Rows[i][8]);
                                    pric_qubtl = pric_avrg * Convert.ToDouble(unit_quit[0][4]);
                                    pric_smool = pric_avrg / Convert.ToDouble(unit_quit[0][5]);



                                    pro_avrg = Convert.ToDouble(dttest.Rows[i][7]);
                                    pro_qubtl = pro_avrg * Convert.ToDouble(unit_quit[0][4]);
                                    pro_smool = pro_avrg / Convert.ToDouble(unit_quit[0][5]);
                                }
                                else if (Convert.ToInt32(dttest.Rows[i][12]) == 3)
                                {
                                    pric_smool = Convert.ToDouble(dttest.Rows[i][8]);
                                    pric_avrg = pric_smool * Convert.ToDouble(unit_quit[0][5]);
                                    pric_qubtl = pric_avrg * Convert.ToDouble(unit_quit[0][4]);


                                    pro_smool = Convert.ToDouble(dttest.Rows[i][7]);
                                    pro_avrg = pro_smool * Convert.ToDouble(unit_quit[0][5]);
                                    pro_qubtl = pro_avrg * Convert.ToDouble(unit_quit[0][4]);

                                }





                                if (Convert.ToInt32(dttest.Rows[i][14]) % Convert.ToInt32(unit_quit[0][5]) == 0)
                                {

                                    int quit_smool = Convert.ToInt32(dttest.Rows[i][14]) / Convert.ToInt32(unit_quit[0][5]);
                                    DataRow unit1 = DB_Add_delete_update_.Database.ds.Tables["therpeutic_unite"].Rows.Find(Convert.ToInt32(unit_quit[0][3]));
                                    if (quit_smool % Convert.ToInt32(unit_quit[0][4]) == 0)
                                    {
                                        int quit_avrg = quit_smool / Convert.ToInt32(unit_quit[0][4]);
                                        dgv_Item_storg_trans_dgv.Rows.Add(Item_name[2], unit11[1].ToString(), quit_avrg, Convert.ToDateTime(dttest.Rows[i][2]).Date.ToString("d"), dttest.Rows[i][0].ToString(),quit_avrg,pric_qubtl,pro_qubtl,1, unit_quit[0][1],(pric_qubtl - pro_qubtl), dttest.Rows[i][11]);//الوحدة الكبرا

                                        dgv_Item_storg_trans_dgv.Rows[dgv_Item_storg_trans_dgv.Rows.Count - 1].Cells[3].Style.BackColor = Color.FromArgb(red, Gren, blu);
                                        dgv_Item_storg_trans_dgv.Rows[dgv_Item_storg_trans_dgv.Rows.Count - 1].Cells[1].Style.BackColor = Color.FromArgb(red2, color_unit_count, green);


                                        dgv_Item_storg_trans_dgv.Rows.Add(Item_name[2], unit112[1].ToString(), 0, Convert.ToDateTime(dttest.Rows[i][2]).Date.ToString("d"), dttest.Rows[i][0].ToString(), quit_smool,pric_avrg,pro_avrg,2, unit_quit[0][2],(pric_avrg - pro_avrg), dttest.Rows[i][11]);//الوحدة المتوسطة
                                       dgv_Item_storg_trans_dgv.Rows[dgv_Item_storg_trans_dgv.Rows.Count - 1].Cells[3].Style.BackColor = Color.FromArgb(red, Gren, blu);
                                        dgv_Item_storg_trans_dgv.Rows[dgv_Item_storg_trans_dgv.Rows.Count - 1].Cells[1].Style.BackColor = Color.FromArgb(red2, color_unit_count, green);
                                    }
                                    else
                                    {
                                        int quit_avrg = quit_smool % Convert.ToInt32(unit_quit[0][4]);
                                        int quit_avrg2 = quit_smool / Convert.ToInt32(unit_quit[0][4]);
                                        dgv_Item_storg_trans_dgv.Rows.Add(Item_name[2], unit11[1].ToString(), quit_avrg2, Convert.ToDateTime(dttest.Rows[i][2]).Date.ToString("d"), dttest.Rows[i][0].ToString(), quit_avrg2, pric_qubtl, pro_qubtl,1, unit_quit[0][1],(pric_qubtl- pro_qubtl), dttest.Rows[i][11]);//الوحدة الكبرا
                                        dgv_Item_storg_trans_dgv.Rows[dgv_Item_storg_trans_dgv.Rows.Count - 1].Cells[3].Style.BackColor = Color.FromArgb(red, Gren, blu);
                                        dgv_Item_storg_trans_dgv.Rows[dgv_Item_storg_trans_dgv.Rows.Count - 1].Cells[1].Style.BackColor = Color.FromArgb(red2, color_unit_count, green);

                                        dgv_Item_storg_trans_dgv.Rows.Add(Item_name[2], unit112[1].ToString(), quit_avrg, Convert.ToDateTime(dttest.Rows[i][2]).Date.ToString("d"), dttest.Rows[i][0].ToString(),quit_smool, pric_avrg, pro_avrg,2, unit_quit[0][2],(pric_avrg - pro_avrg), dttest.Rows[i][11]);//الوحدة المتوسطة
                                         dgv_Item_storg_trans_dgv.Rows[dgv_Item_storg_trans_dgv.Rows.Count - 1].Cells[3].Style.BackColor = Color.FromArgb(red, Gren, blu);
                                        dgv_Item_storg_trans_dgv.Rows[dgv_Item_storg_trans_dgv.Rows.Count - 1].Cells[1].Style.BackColor = Color.FromArgb(red2, color_unit_count, green);

                                    }
                                    dgv_Item_storg_trans_dgv.Rows.Add(Item_name[2], unit1[1].ToString(), 0, Convert.ToDateTime(dttest.Rows[i][2]).Date.ToString("d"), dttest.Rows[i][0].ToString(), dttest.Rows[i][14],pric_smool,pro_smool,3, unit_quit[0][3],(pric_smool- pro_smool), dttest.Rows[i][11]);//الوحددة الصغرا
                                    dgv_Item_storg_trans_dgv.Rows[dgv_Item_storg_trans_dgv.Rows.Count - 1].Cells[3].Style.BackColor = Color.FromArgb(red, Gren, blu);
                                    dgv_Item_storg_trans_dgv.Rows[dgv_Item_storg_trans_dgv.Rows.Count - 1].Cells[1].Style.BackColor = Color.FromArgb(red2, color_unit_count, green);

                                }
                                else
                                {
                                    int quit_smool = Convert.ToInt32(dttest.Rows[i][14]) / Convert.ToInt32(unit_quit[0][5]);
                                    int quit_smool2 = Convert.ToInt32(dttest.Rows[i][14]) % Convert.ToInt32(unit_quit[0][5]);
                                    DataRow uni33 = DB_Add_delete_update_.Database.ds.Tables["therpeutic_unite"].Rows.Find(Convert.ToInt32(unit_quit[0][3]));
                                    if (quit_smool % Convert.ToInt32(unit_quit[0][4]) == 0)
                                    {
                                        int quit_avrg = quit_smool / Convert.ToInt32(unit_quit[0][4]);
                                        dgv_Item_storg_trans_dgv.Rows.Add(Item_name[2], unit11[1].ToString(), quit_avrg, Convert.ToDateTime(dttest.Rows[i][2]).Date.ToString("d"),dttest.Rows[i][0].ToString(), quit_avrg, pric_qubtl, pro_qubtl,1, unit_quit[0][1],(pric_qubtl - pro_qubtl), dttest.Rows[i][11]);//الوحدة الكبرا

                                        dgv_Item_storg_trans_dgv.Rows[dgv_Item_storg_trans_dgv.Rows.Count - 1].Cells[3].Style.BackColor = Color.FromArgb(red, Gren, blu);
                                        dgv_Item_storg_trans_dgv.Rows[dgv_Item_storg_trans_dgv.Rows.Count - 1].Cells[1].Style.BackColor = Color.FromArgb(red2, color_unit_count, green);

                                    }
                                    else
                                    {
                                        int quit_avrg = quit_smool % Convert.ToInt32(unit_quit[0][4]);
                                        int quit_avrg2 = quit_smool / Convert.ToInt32(unit_quit[0][4]);
                                        dgv_Item_storg_trans_dgv.Rows.Add(Item_name[2], unit11[1].ToString(), quit_avrg2, Convert.ToDateTime(dttest.Rows[i][2]).Date.ToString("d"),dttest.Rows[i][0].ToString(), quit_avrg2, pric_qubtl, pro_qubtl,1, unit_quit[0][1],( pric_qubtl- pro_qubtl), dttest.Rows[i][11]);//الوحدة الكبرا

                                         dgv_Item_storg_trans_dgv.Rows[dgv_Item_storg_trans_dgv.Rows.Count - 1].Cells[3].Style.BackColor = Color.FromArgb(red, Gren, blu);
                                        dgv_Item_storg_trans_dgv.Rows[dgv_Item_storg_trans_dgv.Rows.Count - 1].Cells[1].Style.BackColor = Color.FromArgb(red2, color_unit_count, green);

                                        dgv_Item_storg_trans_dgv.Rows.Add(Item_name[2], unit112[1].ToString(), quit_avrg, Convert.ToDateTime(dttest.Rows[i][2]).Date.ToString("d"), dttest.Rows[i][0].ToString(),quit_smool, pric_avrg, pro_avrg,2, unit_quit[0][2],(pric_avrg - pro_avrg), dttest.Rows[i][11]);//الوحدة المتوسطة

                                         dgv_Item_storg_trans_dgv.Rows[dgv_Item_storg_trans_dgv.Rows.Count - 1].Cells[3].Style.BackColor = Color.FromArgb(red, Gren, blu);
                                        dgv_Item_storg_trans_dgv.Rows[dgv_Item_storg_trans_dgv.Rows.Count - 1].Cells[1].Style.BackColor = Color.FromArgb(red2, color_unit_count, green);
                                    }
                                    dgv_Item_storg_trans_dgv.Rows.Add(Item_name[2],uni33[1].ToString(), quit_smool2, Convert.ToDateTime(dttest.Rows[i][2]).Date.ToString("d"), dttest.Rows[i][0].ToString(), dttest.Rows[i][14], pric_smool, pro_smool,3, unit_quit[0][3],(pric_smool- pro_smool), dttest.Rows[i][11]);//الوحددة الصغرا

                                    dgv_Item_storg_trans_dgv.Rows[dgv_Item_storg_trans_dgv.Rows.Count - 1].Cells[3].Style.BackColor = Color.FromArgb(red, Gren, blu);
                                    dgv_Item_storg_trans_dgv.Rows[dgv_Item_storg_trans_dgv.Rows.Count - 1].Cells[1].Style.BackColor = Color.FromArgb(red2, color_unit_count, green);

                                }

                                color_unit_count += 5;
                                red2 -= 5;
                            }

                        }
                    }
                }
            }
        }

        private void Dgv_Item_storg_trans_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            var fr = Application.OpenForms["Main"] as Main;
            bool check = true;
            for (int i = 0; i < fr.dgv_tranformtion_dgv.Rows.Count; i++)
            {
                int Item_no_storg_chek = Convert.ToInt32(dgv_Item_storg_trans_dgv.CurrentRow.Cells[4].Value);

                if (Convert.ToInt32(fr.dgv_tranformtion_dgv.Rows[i].Cells[11].Value) == Item_no_storg_chek)
                {
                    check = false;
                    break;
                }
            }
            
            if (check)
            {
                if (dgv_Item_storg_trans_dgv.CurrentRow != null)
                {
                    int num = Convert.ToInt32(fr.dgv_tranformtion_dgv.CurrentRow.Cells[0].Value);
                    object name = dgv_Item_storg_trans_dgv.CurrentRow.Cells[0].Value;
                    string unite = dgv_Item_storg_trans_dgv.CurrentRow.Cells[1].Value.ToString();
                    int Item_no_storg = Convert.ToInt32(dgv_Item_storg_trans_dgv.CurrentRow.Cells[4].Value);
                    int All_quity = Convert.ToInt32(dgv_Item_storg_trans_dgv.CurrentRow.Cells[5].Value);
                    int quity_end = 0;
                    DateTime dt = Convert.ToDateTime(dgv_Item_storg_trans_dgv.CurrentRow.Cells[3].Value);
                    double pric = Convert.ToDouble(dgv_Item_storg_trans_dgv.CurrentRow.Cells[6].Value);
                    double prodect = Convert.ToDouble(dgv_Item_storg_trans_dgv.CurrentRow.Cells[7].Value);
                    double privs = Convert.ToDouble(dgv_Item_storg_trans_dgv.CurrentRow.Cells[10].Value);
                    int Type_unit = Convert.ToInt32(dgv_Item_storg_trans_dgv.CurrentRow.Cells[8].Value);
                    int num_unit = Convert.ToInt32(dgv_Item_storg_trans_dgv.CurrentRow.Cells[9].Value);
                    int sum_num = Convert.ToInt32(dgv_Item_storg_trans_dgv.CurrentRow.Cells[11].Value);




                    // fr.dgv_tranformtion.Rows.Add(num, name, unite, All_quity, quity_end, dt.Date.ToString("d"));
                    fr.dgv_tranformtion_dgv.CurrentRow.Cells[0].Value = num;
                    fr.dgv_tranformtion_dgv.CurrentRow.Cells[1].Value = name;
                    fr.dgv_tranformtion_dgv.CurrentRow.Cells[2].Value = unite;
                    fr.dgv_tranformtion_dgv.CurrentRow.Cells[3].Value = All_quity;
                    fr.dgv_tranformtion_dgv.CurrentRow.Cells[4].Value = quity_end;
                    fr.dgv_tranformtion_dgv.CurrentRow.Cells[5].Value = dt.Date.ToString("d");
                    fr.dgv_tranformtion_dgv.CurrentRow.Cells[6].Value = pric.ToString("N0");
                    fr.dgv_tranformtion_dgv.CurrentRow.Cells[7].Value = prodect.ToString("N0");
                    fr.dgv_tranformtion_dgv.CurrentRow.Cells[8].Value = privs.ToString("N0");
                    fr.dgv_tranformtion_dgv.CurrentRow.Cells[9].Value = Type_unit;
                    fr.dgv_tranformtion_dgv.CurrentRow.Cells[10].Value = num_unit;
                    fr.dgv_tranformtion_dgv.CurrentRow.Cells[11].Value = Item_no_storg;
                    fr.dgv_tranformtion_dgv.CurrentRow.Cells[12].Value = sum_num;
                    Close();




                }
            }else
            {
                MessageBox.Show("لا يمكن تحويب  نفس الصنف اكثر من مرة","تحذير",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
                    
        }  
    }
}
