using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using System.Windows.Forms;
using Manag_ph.Item.forms;

namespace Manag_ph.DB_Add_delete_update_
{

    class Database
    {



       // string dd = SystemInformation.ComputerName;
        static SqlConnection cn = new SqlConnection(Properties.Settings.Default.dd);
        // static SqlConnection cn = new SqlConnection(@"Data source=SALAH\SQLEXPRESS;Database=Manag_Pharmacy;integrated security=true");
        //static SqlConnection cn = new SqlConnection(@"Data source=MIDO653\SQLEXPRESS;Database=Manag_Pharmacy;integrated security=true");
       // static SqlConnection cn = new SqlConnection(@"Data source=.\SQLEXPRESS;Database=Manag_Pharmacy;integrated security=true");


        public static void open()
        {
            try
            {
                //MessageBox.Show(SystemInformation.ComputerName + "/SQLEXPRESS");

                if (cn.State != ConnectionState.Open)
                {
                    cn.Open();
                }
            }
            catch (Exception e)
            {
                Frm_stap_database_frm f = new Frm_stap_database_frm();

                f.ShowDialog();
                //var frm = Application.OpenForms["Frm_stap_database_frm"] as Frm_stap_database_frm;
                // //frm.Show();
                // //namelab = frm.textBox1.Text ;

            }
            if (cn.State != ConnectionState.Open)
            {
                cn.Open();
            }
        }

        public static void close()
        {


            if (cn.State == ConnectionState.Open)
            {
                cn.Close();
            }
        }

        ///////////////////////////////////////////////////////////////


      public static DataTable unit = new DataTable();
      public static DataTable unit2 = new DataTable();
      public static DataTable unit_sales = new DataTable();


        ///////////////////////////////دالة خاصة بعرض البيانات من الفيو////////////////////////
        public static DataTable dt_View_Item = new DataTable();
        public static DataTable dt_View_Item22 = new DataTable();

        public static DataView dv = new DataView(dt_View_Item);
        public static void view_Item()
        {
            SqlCommand cmd = new SqlCommand("All_View", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            open();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            SqlDataAdapter daa = new SqlDataAdapter(cmd);
            da.Fill(dt_View_Item);
            daa.Fill(dt_View_Item22);
            cmd.ExecuteNonQuery();
            close();
        }
        /// //////////////////////////////////////////////////////////////////////////



        //*******************************************************************

        public static DataTable dt_View_Item2 = new DataTable();
        public static DataView dv2 = new DataView(dt_View_Item2);



        public static void view_Item2(string viw_name_table)
        {


            SqlCommand cmd = new SqlCommand(viw_name_table, cn);
            cmd.CommandType = CommandType.StoredProcedure;
            open();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt_View_Item2);
            cmd.ExecuteNonQuery();
            close();
        }


        public static DataTable dt_View_Item3 = new DataTable();
        public static DataView dv3 = new DataView(dt_View_Item3);
        public static void view_Item3(string viw_name_table)
        {


            SqlCommand cmd = new SqlCommand(viw_name_table, cn);
            cmd.CommandType = CommandType.StoredProcedure;
            open();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt_View_Item3);
            cmd.ExecuteNonQuery();
            close();
        }


        public static DataTable dt_View_Item4 = new DataTable();
        public static DataView dv4 = new DataView(dt_View_Item4);
        public static void view_Item4()
        {


            SqlCommand cmd = new SqlCommand("proc_view_alternatives", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            open();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt_View_Item4);
            cmd.ExecuteNonQuery();
            close();
        }
        //***********************************************************************


        public  DataTable view_All(string storg_procug)
        {
            SqlCommand cmd = new SqlCommand(storg_procug, cn);
            cmd.CommandType = CommandType.StoredProcedure;
            open();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dta = new DataTable();
            da.Fill(dta);
            cmd.ExecuteNonQuery();
            close();
            return dta;
        }

        public void Execute(string storg_procug, SqlParameter[] param)
        {
            SqlCommand cmd = new SqlCommand(storg_procug, cn);

            open();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddRange(param);
            cmd.ExecuteNonQuery();
            close();
        }



        //دالة لجلب الرقم تلقائي
        public  int  AutoNumber(string TableName,string Id_Name)
        {
            open();
            SqlDataReader rd;
            
            int Aout = 0;
            SqlCommand cmd = new SqlCommand("select * from " + TableName, cn);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            if (dt.Rows.Count!=0) {
                cmd.CommandText = "select max(" + Id_Name + ") from " + TableName;
              rd =  cmd.ExecuteReader();
               
                    while (rd.Read())
                    {
                        Aout = Convert.ToInt32(rd[0]);
                    
                }
                rd.Close();
            }

            close();
            return Aout =Aout+1;
        }

        //دالة تعطيلها اسم الجدول اسم ترجع الادي
        public object setName_getid(string TableName,string column_name,string text_name,string column_id)
        {
            cn.Open();
            SqlDataReader red;
            string query = "select " + column_id + " from " + TableName + " where " + column_name + " = '" + text_name + "'";
            SqlCommand cmd = new SqlCommand(query, cn);
            object re = cmd.ExecuteScalar();
            cn.Close();
            return re;
        }

        public void Fill_Combox(ComboBox combox, string StorgProsegr)
        {
            DataTable dt = view_All(StorgProsegr);


            combox.DataSource = dt;
            combox.DisplayMember = dt.Columns[1].ColumnName;
            combox.ValueMember = dt.Columns[0].ColumnName;

        }



       public static DataSet ds = new DataSet();
        private static SqlDataAdapter sda;
     
        //Methode Fill Dataset
    
    public static void FillAll(string[] TableName)
        { 
            DataTable dt;
            SqlCommand cmd;
            foreach (string table in TableName)
            {
                open();
                dt = new DataTable();
                cmd = new SqlCommand("select * from "+table, cn);
               
                sda = new SqlDataAdapter(cmd);
               sda.FillSchema(dt, SchemaType.Mapped);
                sda.Fill(dt);
                if (table == "therpeutic_unite")
                {
                    sda.FillSchema(unit, SchemaType.Mapped);
                    sda.Fill(unit);

                    sda.FillSchema(unit2, SchemaType.Mapped);
                    sda.Fill(unit2);

                    sda.FillSchema(unit_sales, SchemaType.Mapped);
                    sda.Fill(unit_sales);
                }
                cmd.ExecuteNonQuery();
                ds.Tables.Add(dt);

            }
            close();
          
        }

       //Methode Update Data To Database
    public static void update(string TableName) {
            sda.SelectCommand.CommandText = "Select * from " + TableName;
            SqlCommandBuilder scmdb = new SqlCommandBuilder(sda);
            sda.Update(ds.Tables[TableName]);
        }

        SqlCommand Cmd;
        public bool Create_BackUp(TextBox textBox)
        {
            Item.forms.Frm_Backup frm = new Item.forms.Frm_Backup();
            string dataname = cn.Database.ToString();
            //if (frm.txt_backup_browser_txt.Text != string.Empty)
            //{
            //frm.progressPanel1_Backup.Visible = true;
            //if (textBox.Text != string.Empty)
            //{
            try
            {
                new Frm_Backup().progressPanel1_Backup.Visible = true;
                string cmdd = @"BACKUP DATABASE [" + dataname + "] TO DISK ='" + textBox.Text + "\\" + "database" + "-" + DateTime.Now.ToString("yyyy-MM-dd--HH-mm") + ".bak'";
                cn.Open();
                SqlCommand command = new SqlCommand(cmdd, cn);
                command.ExecuteNonQuery();
                cn.Close();
                //new Item.forms.Frm_Backup().progressPanel1_Backup.Visible = false;
                return true;
                //if (frm.progressPanel1_Backup.FrameInterval==2000)
                //{
                //frm.progressPanel1_Backup.Visible = false;

                //}


            }
            catch
            {
                //MessageBox.Show("لم يتم إنشاء نسخة إحتياطية ");
                return false;

            }




            //}
            //else
            //{

            //   frm. progressPanel1_Backup.Visible = false;


            //    frm.btn_create_Backup_btn.Enabled = false;

            //    MessageBox.Show("يرجاء ادخال موقع حفظ النسخه الاحتياطية");
            //    return false;
            //}

            //frm.progressPanel1_Backup.Visible = false;
            //MessageBox.Show("Database Backup done Successfuly");
            //frm.btn_create_Backup_btn.Enabled = false;


            // }
            //// else
            //{


            //     MessageBox.Show("يرجاء ادخال موقع حفظ النسخه الاحتياطية");
            //}


            ////////////////////////////////////////////////////
            //try
            //{
            //SaveFileDialog sf = new SaveFileDialog();
            ////sf.Filter = "Backup Files (*.Bak) |*.bak";
            //if (sf.ShowDialog() == DialogResult.OK)
            //{
            //  pn_progress.Visible = true;
            //var result = await Task.Run(() => BackUp(sf));
            //if (result == true)
            //{
            //    MessageBox.Show("تم النسخ الاحتياطي بنجاح");
            //    //pn_progress.Visible = false;
            //}
            //else
            //{
            //    MessageBox.Show("لم يتم النسخ الاحتياطي بنجاح يوجد خطاء , الرجاء تحديد مسار اخر , لا تحديد القرص (C) ");
            //    //pn_progress.Visible = false;
            //}
            //}
            //}
            //catch 
            //{

            //    MessageBox.Show("لم يتم النسخ الاحتياطي بنجاح يوجد خطاء , الرجاء تحديد مسار اخر , لا تحديد القرص (C) ");
            //        pn_progress.Visible = false;
            //}
            ///////////////////////////////////////////////
            //SaveFileDialog sf = new SaveFileDialog();

            //SFolder.Filter = "Backup Files (*.Bak) |*.bak";

            //    try
            //    {
            //         //dd = new Database();

            //        string dbbackup = "Manag_Pharmacy" + DateTime.Now.ToString("yyyyMMddHHmm");
            //        var fullpath = SFolder.FileName ;
            //        MessageBox.Show("Test = "+fullpath );
            //        //string sqlcommand = @"Backup Database Manag_Pharmacy To Disk='" + fullpath + "'whth noformat ,noinit, name=n'Manag_Pharmacy',skip, norewind, nounload ,stats =10";
            //        //int  path = 
            //        Cmd = new SqlCommand("Backup Database Manag_Pharmacy To Disk='" + fullpath + "'", cn);
            //        cn.Open();

            //        Cmd.ExecuteNonQuery();
            //        cn.Close();

            //        return true;
            //    }
            //    catch 
            //    {

            //        return false;
            //    }

            //}

        }
        public bool Restor_BackUp(TextBox textBox)
        {
            string dataname = cn.Database.ToString();
            try
            {
                cn.Open();
                string str1 = string.Format("ALTER DATABASE [" + dataname + "] SET SINGLE_USER WITH ROLLBACK IMMEDIATE");
                SqlCommand cmd1 = new SqlCommand(str1, cn);
                cmd1.ExecuteNonQuery();

                string str2 = "USE MASTER RESTORE DATABASE [" + dataname + "] FROM DISK='" + textBox.Text + "' WITH REPLACE";
                SqlCommand cmd2 = new SqlCommand(str2, cn);
                cmd2.ExecuteNonQuery();

                string str3 = string.Format("ALTER DATABASE [" + dataname + "] SET MULTI_USER");
                SqlCommand cmd3 = new SqlCommand(str3, cn);
                cmd3.ExecuteNonQuery();
                //MessageBox.Show("Test _retors data ");
                cn.Close();
                return true;
            }
            catch
            {

                return false;
            }

        }
    }
}
