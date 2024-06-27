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
    public partial class fro_contra_and_clin : Form
    {
        public fro_contra_and_clin()
        {
            InitializeComponent();
        }
        classs_table.Items_Tools to = new classs_table.Items_Tools();

        private void Fro_contra_and_clin_Load(object sender, EventArgs e)
        {
            dgv_clin_and_contar_dgv.DataSource = DB_Add_delete_update_.Database.ds.Tables["Clien"];    //ارجاع البيانات من جدول الموردين الى الجدول في الواجهه

            dgv_clin_and_contar_dgv.Columns[4].Visible = false;
            dgv_clin_and_contar_dgv.Columns[5].Visible = false;
            dgv_clin_and_contar_dgv.Columns[6].Visible = false;
            dgv_clin_and_contar_dgv.Columns[7].Visible = false;
            dgv_clin_and_contar_dgv.Columns[9].Visible = false;
            dgv_clin_and_contar_dgv.Columns[11].Visible = false;

            dgv_clin_and_contar_dgv.Columns[10].Visible = false;


            //cod, name_clin, address_clin, stop_clin, link_clin, Phon_clin1, Phon_clin2, max_cloud, Diosc_rate, max_bill, stoc_cod, dat_start_clin
            dgv_clin_and_contar_dgv.Columns[0].HeaderText = "كود العميل";
            dgv_clin_and_contar_dgv.Columns[1].HeaderText = "اسم العميل";
            dgv_clin_and_contar_dgv.Columns[2].HeaderText = "عنوان العميل";
            dgv_clin_and_contar_dgv.Columns[3].HeaderText = "ايقاف العميل";
            dgv_clin_and_contar_dgv.Columns[8].HeaderText = "نسبة الخصم";

            // Style_DataGridView(dgv_);//دالة تنسيق الجدول

            //
           // to.Style_DataGridView(dgv_clin_and_contar_dgv);
        }

        private void Txt_searsh_clin_and_cont_TextChanged(object sender, EventArgs e)
        {
            dgv_clin_and_contar_dgv.ClearSelection();
            DataView dv = new DataView(DB_Add_delete_update_.Database.ds.Tables["Clien"]);
            string str = txt_searsh_clin_and_cont.Text;
            dv.RowFilter = "num_clin + name_clin + address_clin  +  phon1_clin + phon2_clin + max_cloud   like '%" + str + "%'";//+ " And  Link_clin = " + 1
        }

        public string txt_clin_cheing(string txt)
        {
            int id = Convert.ToInt32(dgv_clin_and_contar_dgv.CurrentRow.Cells[0].Value);
            object[] dr;
            dr = DB_Add_delete_update_.Database.ds.Tables["Clien"].Rows.Find(id).ItemArray;

            //(cod , name_clin , address_clin , stop_clin , link_clin , Phon_clin1 , Phon_clin2, max_cloud, Diosc_rate, max_bill, stoc_cod
            if (dgv_clin_and_contar_dgv.CurrentRow != null)
            {

                txt = dr[1].ToString();
                // txt.Text = txt_name;
            }

            return txt;
        }
        public string txt_name;

        private void Dgv_clin_and_contar_SelectionChanged(object sender, EventArgs e)
        {

        }




        int num_cl;
        public int get_and_set
        {
            get { return num_cl; }
            set { num_cl = value; }
        }
        private void Button1_Click(object sender, EventArgs e)
        {
            Main min = new Main();
            var a = Application.OpenForms["Main"] as Main;
            object[] arr = new object[2];

            if (dgv_clin_and_contar_dgv.CurrentRow != null)
            {
                if (Convert.ToBoolean(dgv_clin_and_contar_dgv.CurrentRow.Cells[3].Value) != true)
                {
                    a.txt_geiv_clin.Text = dgv_clin_and_contar_dgv.CurrentRow.Cells[1].Value.ToString();

                    a.num_cli = Convert.ToInt32(dgv_clin_and_contar_dgv.CurrentRow.Cells[0].Value);

                }
                else
                {
                    MessageBox.Show("هذاء العميل موقف ");
                    a.txt_geiv_clin.Text = "";
                    a.num_cli = 0;
                }



            }


            //if (dgv_cont_show.CurrentRow != null)
            //{
            //    if (Convert.ToBoolean(dgv_cont_show.CurrentRow.Cells[5].Value) != true)
            //    {
            //        // name_cont = dgv_cont_show.CurrentRow.Cells[1].Value.ToString();
            //        num_cont = Convert.ToInt32(dgv_cont_show.CurrentRow.Cells[0].Value);
            //    }
            //}
        }

    }
}
