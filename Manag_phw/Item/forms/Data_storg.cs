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
    public partial class Data_storg : Form
    {
        public Data_storg()
        {
            InitializeComponent();
        }

        private void Data_storg_Load(object sender, EventArgs e)
        {
            dataGridView1_dgv.DataSource = DB_Add_delete_update_.Database.ds.Tables["Storg"];
            dataGridView1_dgv.Columns[2].Visible = false;
            dataGridView1_dgv.Columns[3].Visible = false;
            dataGridView1_dgv.Columns[4].Visible = false;
            dataGridView1_dgv.Columns[5].Visible = false;
        }

        private void DataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            var fr = Application.OpenForms["Main"] as Main;



            if (fr.bool_num_stor) {
                fr.txt_num_stor.Text = dataGridView1_dgv.CurrentRow.Cells[0].Value.ToString();
                fr.txt_name_storg.Text = dataGridView1_dgv.CurrentRow.Cells[1].Value.ToString();
                fr.bool_num_stor = false;
            }
            else if (fr.send)
            {
                fr.txt_num_storg_send.Text = dataGridView1_dgv.CurrentRow.Cells[0].Value.ToString();
                fr.txt_name_storg_send.Text = dataGridView1_dgv.CurrentRow.Cells[1].Value.ToString();
                fr.send = false;
            }
            else if (fr.Transform)
            {
                fr.txt_num_storg_Trans.Text = dataGridView1_dgv.CurrentRow.Cells[0].Value.ToString();
                fr.txt_name_storg_Trans.Text = dataGridView1_dgv.CurrentRow.Cells[1].Value.ToString();
                fr.Transform = false;
            }
            else if (fr.Form_prodect)
            {
                fr.txt_name_storg_prodect.Text = dataGridView1_dgv.CurrentRow.Cells[1].Value.ToString();
                fr.txt_num_storg_prodect.Text = dataGridView1_dgv.CurrentRow.Cells[0].Value.ToString();
                fr.Form_prodect = false;
            }
            Close();
        }
    }
}
