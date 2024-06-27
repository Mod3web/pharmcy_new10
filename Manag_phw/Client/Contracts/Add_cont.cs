using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Manag_ph.Client.Contracts
{
    public partial class Add_cont : Form
    {
        public Add_cont()
        {
            InitializeComponent();
        }
        public void ClearData(string name_Table)
        {



            int cod = Convert.ToInt32(DB_Add_delete_update_.Database.ds.Tables["Contracts_now"].Compute("max(num_cont)", "")) + 1;
            txt_num_cont.Text = Convert.ToString(cod);


            //int number = Convert.ToInt32(DB_Add_delete_update_.Database.ds.Tables["Contracts_now"].Compute("max(num_cont)", ""));
            //txt_number_cont.Text = Convert.ToString(number);


            int numb = Convert.ToInt32(DB_Add_delete_update_.Database.ds.Tables["Contracts"].Compute("count(num_clin)", "num_clin =" + cod));
            txt_number_cont.Text = Convert.ToString(numb);

            txt_name_cont.Clear();
            txt_credtor.Text = "0";
            txt_Debtor.Text = "0";
            txt_Totel.Text = "0";
            txt_max_cont.Text = "0";

        }
        private void Add_cont_Load(object sender, EventArgs e)
        {
            ClearData("Contracts_now");
        }

        ErrorProvider ero = new ErrorProvider();

        private void Button22_Click(object sender, EventArgs e)
        {

            string name;
            string max_cont;
            string Dis_cont;
            bool stop_cont;
            string crid_cont;
            string dic_cont;
            string total;

            int numb = Convert.ToInt32(DB_Add_delete_update_.Database.ds.Tables["Contracts_now"].Compute("max(num_cont)", ""));
            string number = Convert.ToString(numb);


            int cod = Convert.ToInt32(DB_Add_delete_update_.Database.ds.Tables["Contracts_now"].Compute("max(num_cont)", "")) + 1;


            name = txt_name_cont.Text;
            max_cont = txt_max_cont.Text;
            Dis_cont = txt_Disco_up_cont.Text;
            crid_cont = txt_credtor.Text;
            dic_cont = txt_Debtor.Text;
            total = txt_Totel.Text;
            stop_cont = ch_stop_cont.Checked == true ? true : false;

            if (txt_name_cont.Text.Trim() != string.Empty)
            {

                //اضافة البيانات الى الجداول
                DB_Add_delete_update_.Database.ds.Tables["Contracts_now"].Rows.Add(cod, name, stop_cont, max_cont, Dis_cont, number, crid_cont, dic_cont, total);

            }
            else
            {
                ero.SetError(txt_name_cont, "يرجاء ملى الحقل");


            }

            DB_Add_delete_update_.Database.update("Contracts_now");

            ClearData("Contracts_now");
        }
    }
}
