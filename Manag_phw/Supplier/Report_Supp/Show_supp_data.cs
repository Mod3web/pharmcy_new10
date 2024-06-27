using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Manag_ph.Supplier.Report_Supp
{
    public partial class Show_supp_data : Form
    {
        public Show_supp_data()
        {
            InitializeComponent();
        }

        private void Show_supp_data_Load(object sender, EventArgs e)
        {
            dgv_sech_dt_Rp_sup_dgv.DataSource = DB_Add_delete_update_.Database.ds.Tables["Supplier"];

            dgv_sech_dt_Rp_sup_dgv.Columns[0].HeaderText = "كود المورد";
            dgv_sech_dt_Rp_sup_dgv.Columns[1].HeaderText = "اسم المورد";
            dgv_sech_dt_Rp_sup_dgv.Columns[2].HeaderText = "عنوان المورد";
            dgv_sech_dt_Rp_sup_dgv.Columns[3].HeaderText = "اسم المندوب";
            dgv_sech_dt_Rp_sup_dgv.Columns[4].HeaderText = "المورد موقف";
            dgv_sech_dt_Rp_sup_dgv.Columns[5].HeaderText = "هاتف المندوب";
            dgv_sech_dt_Rp_sup_dgv.Columns[6].HeaderText = "هاتف المندوب";
            dgv_sech_dt_Rp_sup_dgv.Columns[7].HeaderText = "هاتف المندوب";
            dgv_sech_dt_Rp_sup_dgv.Columns[8].HeaderText = "هاتف المندوب";
            dgv_sech_dt_Rp_sup_dgv.Columns[9].HeaderText = "هاتف المندوب";
            dgv_sech_dt_Rp_sup_dgv.Columns[10].HeaderText = "هاتف المندوب";
            dgv_sech_dt_Rp_sup_dgv.Columns[11].HeaderText = "هاتف المندوب";
            dgv_sech_dt_Rp_sup_dgv.Columns[12].HeaderText = "هاتف المندوب";

        }
        /*
          ,[name_supp]
      ,[address_supp]
      ,[name_dldt]
      ,[posi_or_not]
      ,[phon_dlgt]
      ,[num_calc]
      ,[phon_sup1]
      ,[phon_sup2]
      ,[name_Ditbt]
      ,[Phon_Ditdt]
      ,[name_Conus]
      ,[Phon_Conus]
             */

        private void Txt_sech_Rp_dt_sup_TextChanged(object sender, EventArgs e)
        {
            dgv_sech_dt_Rp_sup_dgv.ClearSelection();
            DataView dv = new DataView(DB_Add_delete_update_.Database.ds.Tables["Supplier"]);
            string str = txt_sech_Rp_dt_sup.Text;
            dv.RowFilter = "num_supp + name_supp + posi_or_not + phon_sup1 + phon_sup2 + name_Conus + name_Ditbt  like '%" + str + "%'";
            dgv_sech_dt_Rp_sup_dgv.DataSource = dv;
            dgv_sech_dt_Rp_sup_dgv.ClearSelection();

        }

        public void add_Data_Rp_Supp()
        {
            Main min = new Main();
            var a = Application.OpenForms["Main"] as Main;
            object[] arr = new object[2];

            if (dgv_sech_dt_Rp_sup_dgv.CurrentRow != null)
            {
                if (Convert.ToBoolean(dgv_sech_dt_Rp_sup_dgv.CurrentRow.Cells[4].Value) != true)
                {
                    a.txt_Report_name_sup.Text = dgv_sech_dt_Rp_sup_dgv.CurrentRow.Cells[1].Value.ToString();
                    a.txt_Report_id_sup.Text = dgv_sech_dt_Rp_sup_dgv.CurrentRow.Cells[0].Value.ToString();
                    this.Close();
                }
                else
                {
                    MessageBox.Show("هذا المورد موقف ");
                    a.txt_Report_name_sup.Text = "";
                    a.txt_Report_id_sup.Text = "";
                }


            }
        }
        private void Btn_add_dt_Rp_sup_btn_Click(object sender, EventArgs e)
        {
            add_Data_Rp_Supp();

        }

        private void Dgv_sech_dt_Rp_sup_dgv_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            add_Data_Rp_Supp();
        }

        private void Btn_add_dt_Rp_sup_btn_Click_1(object sender, EventArgs e)
        {
            add_Data_Rp_Supp();
        }

        private void Dgv_sech_dt_Rp_sup_dgv_DoubleClick(object sender, EventArgs e)
        {
            add_Data_Rp_Supp();
        }

        private void Btn_add_dt_Rp_sup_btn_Click_2(object sender, EventArgs e)
        {
            add_Data_Rp_Supp();
        }

        private void Dgv_sech_dt_Rp_sup_dgv_DoubleClick_1(object sender, EventArgs e)
        {
            add_Data_Rp_Supp();
        }
    }
}
