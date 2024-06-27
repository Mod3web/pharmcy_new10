using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Manag_ph.Client.Contracts.from_contra
{
    public partial class Add_cont_frm : Form
    {
        public Add_cont_frm()
        {
            InitializeComponent();
        }
        classs_table.Items_Tools to = new classs_table.Items_Tools();

        private void Add_cont_frm_Load(object sender, EventArgs e)
        {
            dgv_contar.DataSource = DB_Add_delete_update_.Database.ds.Tables["Contracts_now"];

            dgv_contar.Columns[0].HeaderText = "كود العقد";
            dgv_contar.Columns[1].HeaderText = "اسم العقد";
            dgv_contar.Columns[2].HeaderText = "ايقاف العقد";
            dgv_contar.Columns[3].HeaderText = "الحد الاقصى";
            dgv_contar.Columns[4].HeaderText = "حد السحب";
            dgv_contar.Columns[5].HeaderText = "عدد التأمينات";
            dgv_contar.Columns[6].HeaderText = "دائن";
            dgv_contar.Columns[7].HeaderText = "مدين";
            dgv_contar.Columns[8].HeaderText = "اجمالي";

           // to.Style_DataGridView(dgv_contar);
        }

        private void Txt_searsh_cont_TextChanged(object sender, EventArgs e)
        {
            dgv_contar.ClearSelection();
            DataView dv = new DataView(DB_Add_delete_update_.Database.ds.Tables["Contracts_now"]);
            string str = txt_searsh_cont.Text;
            dv.RowFilter = "num_cont + name_cont + stop_cont + max_clou_cont + Disco_rate_cont + number_cont + Creditor + Debtor + Total   like '%" + str + "%'";//+ " And  Link_clin = " + 1
        }


        public string txt_cont_cheing(string txt)
        {
            int id = Convert.ToInt32(dgv_contar.CurrentRow.Cells[0].Value);
            object[] dr;
            dr = DB_Add_delete_update_.Database.ds.Tables["Contracts_now"].Rows.Find(id).ItemArray;

            if (dgv_contar.CurrentRow != null)
            {

                txt = dr[1].ToString();
            }

            return txt;
        }

        public string txt_name;


        int num_cl;
        public int get_and_set
        {
            get { return num_cl; }
            set { num_cl = value; }
        }

        private void Btn_Add_cont_Click(object sender, EventArgs e)
        {
            Main min = new Main();
            var a = Application.OpenForms["Main"] as Main;
            object[] arr = new object[2];

            if (dgv_contar.CurrentRow != null)
            {
                if (Convert.ToBoolean(dgv_contar.CurrentRow.Cells[2].Value) != true)
                {
                    a.txt_geiv_clin.Text = dgv_contar.CurrentRow.Cells[1].Value.ToString();

                    a.num_cli = Convert.ToInt32(dgv_contar.CurrentRow.Cells[0].Value);

                }
                else
                {
                    MessageBox.Show("هذالعقد موقف ");
                    a.txt_geiv_clin.Text = "";
                    a.num_cli = 0;
                }



            }
        }

        private void Button1_Click(object sender, EventArgs e)
        {

        }
    }
}
