using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Manag_ph.Client.Report_Clin
{
    public partial class show_Data_clin : Form
    {
        public show_Data_clin()
        {
            InitializeComponent();
        }
        public void search_Clin()
        {
            var vr = Application.OpenForms["Main"] as Main;
            dgv_sech_dt_Rp_clin_dgv.ClearSelection();
            DataView dv = new DataView(DB_Add_delete_update_.Database.ds.Tables["Clien"]);
            string str = txt_sech_Rp_dt_clin.Text;

            dv.RowFilter = "num_clin+name_clin+address_clin+stop_clin+Link_clin+phon1_clin+phon2_clin+max_cloud like '%" + str + "%'";
            // dv.RowFilter = "كود العميل+اسم العميل+هاتف العميل+هاتف العميل   like '%" + str + "%'";
            dgv_sech_dt_Rp_clin_dgv.DataSource = dv;
            dgv_sech_dt_Rp_clin_dgv.ClearSelection();

        }
        private void Show_Data_clin_Load(object sender, EventArgs e)
        {
            dgv_sech_dt_Rp_clin_dgv.DataSource = DB_Add_delete_update_.Database.ds.Tables["Clien"];

            dgv_sech_dt_Rp_clin_dgv.Columns[0].HeaderText = "كود العميل";
            dgv_sech_dt_Rp_clin_dgv.Columns[1].HeaderText = "اسم العميل";
            dgv_sech_dt_Rp_clin_dgv.Columns[2].HeaderText = "عنوان العميل";
            dgv_sech_dt_Rp_clin_dgv.Columns[3].HeaderText = "العميل موقف";
            dgv_sech_dt_Rp_clin_dgv.Columns[4].HeaderText = "مرنبط باحد";
            dgv_sech_dt_Rp_clin_dgv.Columns[5].HeaderText = "هاتف العميل";
            dgv_sech_dt_Rp_clin_dgv.Columns[6].HeaderText = "هاتف العميل";
            dgv_sech_dt_Rp_clin_dgv.Columns[7].HeaderText = "هاتف المندوب";
            dgv_sech_dt_Rp_clin_dgv.Columns[8].HeaderText = "هاتف المندوب";
            dgv_sech_dt_Rp_clin_dgv.Columns[9].HeaderText = "هاتف المندوب";
            dgv_sech_dt_Rp_clin_dgv.Columns[10].HeaderText = "هاتف المندوب";
            dgv_sech_dt_Rp_clin_dgv.Columns[11].HeaderText = "هاتف المندوب";

        }

        public void add_Data_Rp_Supp()
        {
            Main min = new Main();
            var a = Application.OpenForms["Main"] as Main;
            object[] arr = new object[2];

            if (dgv_sech_dt_Rp_clin_dgv.CurrentRow != null)
            {
                if (Convert.ToBoolean(dgv_sech_dt_Rp_clin_dgv.CurrentRow.Cells[3].Value) != true)
                {
                    a.txt_name_Rp_clin.Text = dgv_sech_dt_Rp_clin_dgv.CurrentRow.Cells[1].Value.ToString();
                    a.txt_id_Rp_clin.Text = dgv_sech_dt_Rp_clin_dgv.CurrentRow.Cells[0].Value.ToString();
                    this.Close();
                }
                else
                {
                    MessageBox.Show("هذا العميل موقف ");
                    a.txt_name_Rp_clin.Text = "";
                    a.txt_id_Rp_clin.Text = "";
                }


            }
        }

        private void Txt_sech_Rp_dt_clin_TextChanged(object sender, EventArgs e)
        {
            search_Clin();
        }

        private void Btn_add_dt_Rp_clin_btn_Click(object sender, EventArgs e)
        {
            add_Data_Rp_Supp();
        }

        private void Dgv_sech_dt_Rp_clin_dgv_DoubleClick(object sender, EventArgs e)
        {
            add_Data_Rp_Supp();
        }
    }
}
