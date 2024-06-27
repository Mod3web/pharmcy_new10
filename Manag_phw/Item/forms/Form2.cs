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
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }
        DataView dv3 = new DataView();
        private void get_data_item_bdail()
        {
            Main p = new Main();


            var n = Application.OpenForms["Main"] as Main;
            object[] arr = new object[7];

            string name_str = "";
            if (dataGridView_dgv.CurrentRow != null)
            {

                int idv1 = Convert.ToInt32(n.dataGridView2_dgv.CurrentRow.Cells[0].Value);
                int idv = Convert.ToInt32(dataGridView_dgv.CurrentRow.Cells[0].Value);
                DataRow[] fo = DB_Add_delete_update_.Database.ds.Tables["tb_alternatives"].Select("Item_no2=" + idv1 + " And " + "Item_no=" + idv);
                //هذا شرط لو كان الصنف موجود سابقا من ضمن البدائل مايضيفه مره ثانية
                if (fo.Count() != 0)
                {

                    MessageBox.Show(" ! يرجا اختيار صنف اخر هذا الصنف موجود مسبقا من ضمن البدائل ", "خطاء", MessageBoxButtons.OK, MessageBoxIcon.Error);


                }

                else
                {

                    if (n.dataGridView2_dgv.Rows.Count != 0)
                    {
                        int idid = Convert.ToInt32(dataGridView_dgv.CurrentRow.Cells[0].Value);
                        DataRow[] dr2 = DB_Add_delete_update_.Database.ds.Tables["Item"].Select("Item_no=" + idid);

                        if (dr2.Count() != 0)
                        {
                            name_str = (dr2[0][3]).ToString();



                            //DataRow[] dr3 = DB_Add_delete_update_.Database.ds.Tables["manufctur_company"].Select("comp_num=" + id22);
                            //if (dr3.Count() != 0)
                            //{
                            //    name_comm = dr3[0][1].ToString();
                            //}
                        }

                        //arr[0] = n.dataGridView2_dgv.CurrentRow.Cells[0].Value;

                        ////for (int i = 0; i < 6 ; i++)
                        //{ 
                        //        

                        //}

                        object rw1 = n.dataGridView2_dgv.CurrentRow.Cells[0].Value;
                        object rw2 = dataGridView_dgv.CurrentRow.Cells[0].Value;

                        object rw3 = dataGridView_dgv.CurrentRow.Cells[1].Value;
                        object rw4 = dataGridView_dgv.CurrentRow.Cells[2].Value;
                        object rw5 = name_str;
                        object rw6 = dataGridView_dgv.CurrentRow.Cells[7].Value;
                        object rw7 = dataGridView_dgv.CurrentRow.Cells[10].Value;

                        n.dataGridView4_dgv.Rows.Add(rw1, rw2, rw3, rw4, rw5, rw6, rw7);
                        // var n = Application.OpenForms["Main"] as Main;
                        n.btn_save_btn.Enabled = true;
                        //n.dataGridView4_dgv.Rows.Add(arr);

                    }
                    else
                    {
                        MessageBox.Show("تم الغاء اضافه بديل ", "خطاء", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    }
                }


            }


            txt_sersh_view.Clear();
            Close();
        }
        private void Btn_add_bdal_Click(object sender, EventArgs e)
        {
            //جاهز

            get_data_item_bdail();
            //Main p = new Main();


            //var n = Application.OpenForms["Main"] as Main;
            //object[] arr = new object[7];




            //if (dataGridView_dgv.CurrentRow != null)
            //{


            //    if (n.dataGridView2_dgv.Rows.Count != 0)
            //    {
            //        arr[0] = n.dataGridView2_dgv.CurrentRow.Cells[0].Value;
            //        for (int i = 0; i < 6; i++)

            //        {

            //            arr[i + 1] = dataGridView_dgv.CurrentRow.Cells[i].Value;
            //        }

            //        n.dataGridView4_dgv.Rows.Add(arr);

            //    }
            //    else
            //    {
            //        MessageBox.Show("تم الغاء اضافه بديل ", "خطاء", MessageBoxButtons.OK, MessageBoxIcon.Error);

            //    }
            //}


            //txt_sersh_view.Clear();
            //Close();



        }

        private void Txt_sersh_view_TextChanged(object sender, EventArgs e)
        {
            //جاهز
            //DB_Add_delete_update_.Database.dv3.RowFilter = "[رقم الصنف]+[اسم العربي]+[اسم انجليزي]+[اسم التجاري]+[اسم الشركة]+[سعر] like'%" + txt_sersh_view.Text + "%'";
            string str = classs_table.Items_Tools.get_str_barcode(txt_sersh_view);
            //dv3.RowFilter = "[رقم الصنف]+[اسم العربي]+[اسم انجليزي]+[اسم الشركة] like'%" + str + "%'";
            dv3.RowFilter = "[رقم الصنف]+[اسم العربي]+[اسم انجليزي]+[اسم الشركة] like'%" + str + "%'";


        }

        private void Btn_Eixt_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            //**************************************************************
            //DB_Add_delete_update_.Database.view_Item3("proc_view_alternatives");

            //dataGridView_dgv.DataSource = DB_Add_delete_update_.Database.dv3;
            //******************************************************

            //**************************************************************
            //DB_Add_delete_update_.Database.view_Item3("proc_view_alternatives");
            // dv3 = new DataView(DB_Add_delete_update_.Database.dt_View_Item3);

            // dataGridView_dgv.DataSource = dv3;
            //******************************************************
            //int num = Convert.ToInt32(dgv_Compny_dgv.CurrentRow.Cells[0].Value);
            //new classs_table.Items_Tools().Delete_Rows_Table_Database("manufctur_company", num.ToString());

            var n = Application.OpenForms["Main"] as Main;

            dv3 = new DataView(DB_Add_delete_update_.Database.dt_View_Item22);

            DataView dv4 = dv3;


            int x2 = 0;
            int countv = n.dataGridView4_dgv.Rows.Count;

            if (n.dataGridView2_dgv.Rows.Count != 0)
            {


                for (int i = 0; i < countv + 1; i++)
                {
                    if (i == 0)
                    {
                        int num = Convert.ToInt32(n.dataGridView2_dgv.CurrentRow.Cells[0].Value);
                        if (num != 0)
                        {
                            x2 = num;
                        }


                    }
                    else
                    {

                        int idx = Convert.ToInt32(n.dataGridView4_dgv.Rows[i - 1].Cells[1].Value);
                        if (idx != 0)
                        {
                            x2 = idx;
                        }

                    }

                    if (x2 != 0)
                    {
                        for (int j = 0; j < dv3.Count; j++)
                        {

                            if (Convert.ToInt32(dv3[j][0]) == x2)
                            {
                                dv4[j].Delete();
                            }

                        }

                    }

                }


            }
            //dataGridView_dgv.DataSource = dv3;
            dataGridView_dgv.DataSource = dv4;
            //
            //
            //
            dataGridView_dgv.Columns[3].Visible = false;///////
            dataGridView_dgv.Columns[4].Visible = false;//
            dataGridView_dgv.Columns[5].Visible = false;//
            dataGridView_dgv.Columns[6].Visible = false;

            dataGridView_dgv.Columns[8].Visible = false;
            dataGridView_dgv.Columns[9].Visible = false;

            dataGridView_dgv.Columns[11].Visible = false;
            dataGridView_dgv.Columns[12].Visible = false;


        }
    }
}
