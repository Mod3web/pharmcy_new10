using Manag_ph.classs_table;
using Manag_ph.Item.forms;
using System;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Threading;
using System.Windows.Forms;
using USB_Barcode_Scanner;

namespace Manag_ph
{
    public partial class Main : Form
    {




        public Main()
        {
            InitializeComponent();








            BarcodeScanner barcodeScanner1 = new BarcodeScanner(dgv_sals_dgv);
            barcodeScanner1.BarcodeScanned += BarcodeScanner_BarcodeScanned;

            BarcodeScanner barcodeScanner2 = new BarcodeScanner(dgv_open_storg_dgv);
            barcodeScanner2.BarcodeScanned += BarcodeScanner_BarcodeScanned;

            BarcodeScanner barcodeScanner3 = new BarcodeScanner(dgv_prodect_dgv);
            barcodeScanner3.BarcodeScanned += BarcodeScanner_BarcodeScanned;

            BarcodeScanner barcodeScanner4 = new BarcodeScanner(dgv_hanging_Data_footer_dgv);
            barcodeScanner4.BarcodeScanned += BarcodeScanner_BarcodeScanned;

            BarcodeScanner barcodeScanner5 = new BarcodeScanner(dgv_hanging_Item_sals_dgv);
            barcodeScanner5.BarcodeScanned += BarcodeScanner_BarcodeScanned;
        }
        public int Datagridview_Type_barcode = 0;
        private void BarcodeScanner_BarcodeScanned(object sender, BarcodeScannerEventArgs e)
        {
            // المخزون الافتتاحي
            if (Datagridview_Type_barcode == 1)
            {
                new BarcodeScanner(dgv_open_storg_dgv);
                dgv_open_storg_dgv.Focus();
                dgv_open_storg_dgv.Select();
                dgv_open_storg_dgv.Rows.Add();

                dgv_open_storg_dgv.Rows[dgv_open_storg_dgv.Rows.Count - 1].Cells[0].Selected = true;
                dgv_open_storg_dgv.Rows[dgv_open_storg_dgv.Rows.Count - 1].Cells[0].Value = e.Barcode;
                Items_Tools.DGV_Test(dgv_open_storg_dgv, null);
                Open_blans.view_And_serch();
                if (dgv_open_storg_dgv.CurrentRow != null)
                {
                    dgv_open_storg_dgv.Rows[dgv_open_storg_dgv.Rows.Count - 1].Cells[1].Selected = true;
                }


            }
            else if (Datagridview_Type_barcode == 0) // فاتورة مبيعات
            {
                new BarcodeScanner(dgv_sals_dgv);
                dgv_sals_dgv.Focus();
                dgv_sals_dgv.Select();
                dgv_sals_dgv.SelectAll();
                dgv_sals_dgv.Select();
                dgv_sals_dgv.Rows.Add();

                dgv_sals_dgv.Rows[dgv_sals_dgv.Rows.Count - 1].Cells[0].Selected = true;
                dgv_sals_dgv.Rows[dgv_sals_dgv.Rows.Count - 1].Cells[1].Selected = true;
                dgv_sals_dgv.Rows[dgv_sals_dgv.Rows.Count - 1].Cells[1].Value = e.Barcode;
                try
                {
                    new Sales.Sales_open_Add().Dgv_sals_CellEndEdit_();
                }
                catch (Exception ms)
                {
                    if (ms.Message == "Error barco")
                    {
                        MessageBox.Show("يرجاء التحقق من رقم الصنف");
                    }
                }
                if (dgv_sals_dgv.CurrentRow != null)
                {
                    dgv_sals_dgv.Rows[dgv_sals_dgv.Rows.Count - 1].Cells[0].Selected = true;
                }
            }
            else if (Datagridview_Type_barcode == 2)
            {

                new BarcodeScanner(dgv_prodect_dgv);
                dgv_prodect_dgv.Focus();
                dgv_prodect_dgv.Select();
                dgv_prodect_dgv.SelectAll();
                dgv_prodect_dgv.Select();
                dgv_prodect_dgv.Rows.Add();
                dgv_prodect_dgv.Rows[dgv_prodect_dgv.Rows.Count - 1].Cells[1].Selected = true;
                dgv_prodect_dgv.Rows[dgv_prodect_dgv.Rows.Count - 1].Cells[1].Value = e.Barcode;
                Footter_prodects._DataGridView5_CellEndEdit();
                if (dgv_prodect_dgv.CurrentRow != null)
                {
                    dgv_prodect_dgv.Rows[dgv_prodect_dgv.Rows.Count - 1].Cells[1].Selected = true;
                }

            }
            else if (Datagridview_Type_barcode == 3)
            {
                new BarcodeScanner(dgv_hanging_Item_sals_dgv);
                dgv_hanging_Item_sals_dgv.Focus();
                dgv_hanging_Item_sals_dgv.Select();
                dgv_hanging_Item_sals_dgv.SelectAll();
                dgv_hanging_Item_sals_dgv.Select();
                dgv_hanging_Item_sals_dgv.Rows.Add();
                dgv_hanging_Item_sals_dgv.Rows[dgv_hanging_Item_sals_dgv.Rows.Count - 1].Cells[1].Selected = true;
                dgv_hanging_Item_sals_dgv.Rows[dgv_hanging_Item_sals_dgv.Rows.Count - 1].Cells[1].Value = e.Barcode;
                try
                {
                    new Sales.hanging_Add_Delete_update_serch().Dgv_hanging_Item_sals_CellEndEdit();
                }
                catch (Exception ms)
                {
                    if (ms.Message == "Error barco")
                    {
                        MessageBox.Show("يرجاء التحقق من رقم الصنف");
                    }
                }
                if (dgv_hanging_Item_sals_dgv.CurrentRow != null)
                {
                    dgv_hanging_Item_sals_dgv.Rows[dgv_hanging_Item_sals_dgv.Rows.Count - 1].Cells[0].Selected = true;
                }
            }


        }


        private void dtp_key_down(object sender, KeyEventArgs e)
        {

        }
        //متغيرات تبع العديل
        public int num_cont = 0;
        public int num_cli;




        // متغير مستخدم لحساب الخصم
        string Aoumn_befor;
        string Aoumn_befor_update;
        //انشئنا كاءن من الكلاس الخصا بئضافة الصنف
        Item.Item Items = new Item.Item();

        //متغير من اجل اختيار اي واجهه شغاله واجهه التوربد النقدي او الصرف النقدي
        public int show_form_doc = 0;
        public int show_form_supper = 0;
        public int show_form_Clint = 0;


        void foucs_key(KeyEventArgs e, Control control_name)
        {
            if (e.KeyCode == Keys.Enter)
            {
                control_name.Focus();

            }
        }
        classs_table.Items_Tools m2 = new Items_Tools();
        DB_Add_delete_update_.Database m1 = new DB_Add_delete_update_.Database();
        Item.Serch serchs = new Item.Serch();
        Item.update updates = new Item.update();
        Item.Delete Deletes = new Item.Delete();

        storg.Storg storgs = new storg.Storg();
        storg.open_blans_storg Open_blans = new storg.open_blans_storg();

        storg.update_Open_storg update_Open_blans = new storg.update_Open_storg();

        storg.transformtion Transformtion = new storg.transformtion();

        storg.settle_Item settles = new storg.settle_Item();


        Supplier.supplier.supplier supp = new Supplier.supplier.supplier();
        Client.Contracts.Class_contracts contrt = new Client.Contracts.Class_contracts();

        prodects.Footer_prodect Footter_prodects = new prodects.Footer_prodect();
        prodects.Foot_return Footter_Return = new prodects.Foot_return();
        Employlee.job.Add_job job = new Employlee.job.Add_job();
        Employlee.job.Show_Jobs show_job = new Employlee.job.Show_Jobs();
        Employlee.job.Update_jobs update_job = new Employlee.job.Update_jobs();
        Recovry.Recovre_Data_of_Power DataRecovry = new Recovry.Recovre_Data_of_Power();





        void ClearData()
        {
            Items.ClearData();
            Aoumn_befor = "";
        }
        public void Fill_All_Data()
        {
            ClearData();
            m2.Fill_Combox(com_copny, "manufctur_company");
            m2.Fill_Combox(com_nature, "nature_of_Item");
            m2.Fill_Combox(com_collection, "collection_of_Item");
            m2.Fill_Combox(com_of_supply, "type_of_supply");
            m2.Fill_Combox(com_places_items, "places_of_items");
            m2.Fill_Combox(com_sciehtific_collection, "sciehtific_collection");
            m2.Fill_Combox(com_effective_material, "effective_material");
            m2.Fill_Combox(com_reason, "reason_for_user");
            m2.Fill_Combox(com_unit_smol, "therpeutic_unite");
            m2.Fill_Combox(combox_version_personal_card, "TB_version_personal_card");
            m2.Fill_Combox(combx_jobs, "tb_Jobs");
            // دالة لجب بيانات الفيو الا الجدول لعرضها والبحث بها
            DB_Add_delete_update_.Database.view_Item();

            num_unit_avrg.Enabled = false;
            num_unit_smol.Enabled = false;

            com_unit_avrg.DataSource = DB_Add_delete_update_.Database.unit;
            com_unit_avrg.ValueMember = DB_Add_delete_update_.Database.unit.Columns[1].ColumnName;
            com_unit_avrg.ValueMember = DB_Add_delete_update_.Database.unit.Columns[0].ColumnName;

            com_unit_Comtl.DataSource = DB_Add_delete_update_.Database.unit2;
            com_unit_Comtl.ValueMember = DB_Add_delete_update_.Database.unit2.Columns[1].ColumnName;
            com_unit_Comtl.ValueMember = DB_Add_delete_update_.Database.unit2.Columns[0].ColumnName;

            com_unit_sals.DataSource = DB_Add_delete_update_.Database.unit_sales;
            com_unit_sals.ValueMember = DB_Add_delete_update_.Database.unit2.Columns[1].ColumnName;
            com_unit_sals.ValueMember = DB_Add_delete_update_.Database.unit2.Columns[0].ColumnName;

            //جلب البيانات من الدادتا فيو الى الجدول 
            dgvm_dgv.DataSource = DB_Add_delete_update_.Database.dv;

            new storg.settle_Item().Fill_com_storg_settle();// تعبئة الكمباء الخاص باالمخازن في شاشة التسويات
            new storg.settle_Item().Fill_com_Type_unit_settle(); //تعبئة الكبو بنوع الوحدات
            new storg.settle_Item().Fill_resaol_settle(); //تعبئة الكبو  سبب التسويات
            

            Footter_prodects.fill_com_typr_prodect();


            dgvm_dgv.Columns[3].Visible = false;
            dgvm_dgv.Columns[4].Visible = false;
            dgvm_dgv.Columns[5].Visible = false;
            dgvm_dgv.Columns[6].Visible = false;


            Items.Path = "unKnown.png";

        }
        private void Form1_Load(object sender, EventArgs e)
        {

            new classs_table.Formats().Coordinate();
            this.Visible = false;

            // DB_Add_delete_update_.Database.FillAll(new string[] { "Report_Account_Add","Report_Account_Discount", "Reasons_disco_Add", "unlock_ditils", "Unlook_Box", "Emplyee_account", "cash_Exchange", "operating_Expenses", "cash_supply", "Return_Item_sals", "Return_footer_sals", "cline_footer", "Item_footer_Sals", "Date_Footer_Sals", "fund_sals", "casher_account", "casher", "current_fund_Accunt", "account_fund", "currencies", "RP_pay_supper", "RP_Total_return", "RP_Data_Item_prodect", "RP_sum_storg_Item", "RP_Item_transform", "view_alternatives", "TB_Employees", "TB_version_personal_card", "TB_LOGIN_EMP", "TB_week_days", "TB_time_Attendance_departure", "TB_sys_salary", "TB_sys_hauur", "TB_commission_ratio", "tb_Jobs", "Totel_Footer_prodeuct", "Data_Footer", "info_update_settle_report", "Reason_settle", "barcode", "dealings", "tb_alternatives", "tb_it_main", "Link_supplier", "collection_of_Item", "manufctur_company", "effective_material", "nature_of_Item", "places_of_items", "reason_for_user", "sciehtific_collection", "therpeutic_unite", "type_of_supply", "Item", "pric", "unite_items", "Storg", "Item_storg", "sum_storg_Item", "Data_Items_Transform_of_storg", "Data_Item_trans", "Clien", "Supplier", "Calc_supply", "Stock_client", "Accounts_suppliers", "Accounts_Clin", "Type_Clin_Accounts" });
            DB_Add_delete_update_.Database.FillAll(new string[] { "TB_Employee_salary_disbursement", "TB_Sales_representative_commission_calculation", "TB_incentives_allowances", "TB_Employee_discount", "TB_Absence_discount","TB_absences_vacations", "TB_Attendance_departure", "TB_COUNT_DAY_EMP", "TB_Emplyee_days_weekly", "Item_footer_Sals_And_Return", "Report_Account_Add", "Report_Account_Discount", "Reasons_disco_Add", "unlock_ditils", "Unlook_Box", "Emplyee_account", "cash_Exchange", "operating_Expenses", "cash_supply", "Return_Item_sals", "Return_footer_sals", "cline_footer", "Item_footer_Sals", "Date_Footer_Sals", "fund_sals", "casher_account", "casher", "current_fund_Accunt", "account_fund", "currencies", "RP_pay_supper", "RP_Total_return", "RP_Data_Item_prodect", "RP_sum_storg_Item", "RP_Item_transform", "view_alternatives", "TB_Employees", "TB_version_personal_card", "TB_LOGIN_EMP", "TB_week_days", "TB_time_Attendance_departure", "TB_sys_salary", "TB_sys_hauur", "TB_commission_ratio", "tb_Jobs", "Totel_Footer_prodeuct", "Data_Footer", "info_update_settle_report", "Reason_settle", "barcode", "dealings", "tb_alternatives", "tb_it_main", "Link_supplier", "collection_of_Item", "manufctur_company", "effective_material", "nature_of_Item", "places_of_items", "reason_for_user", "sciehtific_collection", "therpeutic_unite", "type_of_supply", "Item", "pric", "unite_items", "Storg", "Item_storg", "sum_storg_Item", "Data_Items_Transform_of_storg", "Data_Item_trans", "Clien", "Supplier", "Calc_supply", "Stock_client", "Accounts_suppliers", "Accounts_Clin", "Type_Clin_Accounts" });

            DB_Add_delete_update_.Database.view_Item4();
            dgv_prodect_dgv.ColumnHeadersDefaultCellStyle.Font = new Font("Arial", 11, FontStyle.Bold);
            //m2.Style_DataGridView(dgvm_dgv);//دالة تنسيق الجدول
            //m2.Style_DataGridView(dgv_open_storg_dgv);
            //m2.Style_DataGridView(dgv_tranformtion_dgv);
            //m2.Style_DataGridView(dgv_settle_dgv);
            //m2.Style_DataGridView(dgv_prodect_dgv);
            //m2.Style_DataGridView(dgv_return_prodect_dgv);
            //m2.Style_DataGridView(dgv_view_EMPS_dgv);
            //m2.Style_DataGridView(dgv_RP_Item_Storg_dgv);
            //m2.Style_DataGridView(dgv_RP_Expert_Item_dgv);
            //m2.Style_DataGridView(dgv_update_qty_RP_dgv);
            //m2.Style_DataGridView(dgv_update_Expit_dgv);
            //m2.Style_DataGridView(dgv_update_sals_dgv);
            //m2.Style_DataGridView(dgv_footer_prodect_All_RP_dgv);
            //m2.Style_DataGridView(dgv_footer_RP_number_dgv);
            //m2.Style_DataGridView(dgv_total_footer_return_dgv);
            //m2.Style_DataGridView(dgv_bond_RP_dgv);
            //m2.Style_DataGridView(dgv_fund_currensic);
            //m2.Style_DataGridView(dgv_fund_Account_dgv);
            //m2.Style_DataGridView(dgv_sals_dgv);
            //m2.Style_DataGridView(dgv_hanging_Data_footer_dgv);
            //m2.Style_DataGridView(dgv_data_footer_sals_return_dgv);
            //m2.Style_DataGridView(dgv_RP_Sales_Item_All_dgv);
            //m2.Style_DataGridView(dgv_Data_Return_Date_dgv);
            //m2.Style_DataGridView(dataGridView2_dgv);
            //m2.Style_DataGridView(dataGridView4_dgv);
            //m2.Style_DataGridView(dgv_Report_unlock_dgv);
            //m2.Style_DataGridView(dgv_RP_Account_Diocunt_dgv);

            //m2.Style_DataGridView(dgv_bln_clin_new_dgv);
            //m2.Style_DataGridView_2(dgv_hanging_Item_sals_dgv);
            //m2.Style_DataGridView_2(dgv_Item_footer_sals_return_dgv);

            //m2.Style_DataGridView_Jon_1_2(dgv_data_footer_RP_sals_All_dgv);
            //m2.Style_DataGridView_2(dgv_Item_footer_RP_sals_All_dgv);
            ////m2.Style_DataGridView_Mine(dgv_Item_footer_RP_sals_All_dgv);


            new Employlee.Page_Employees.Show_Employees().show_DataTable();

            Fill_All_Data();
            DataTable dss = new DataTable("smd");
            Items_Tools.Dataunit.Tables.Add(dss);
            new Item.forms.Login().ShowDialog();
            this.Visible = true;
        }

        private void BarButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            forms.therpeutic_unite frm = new forms.therpeutic_unite();
            frm.ShowDialog();
        }
        private void BarButtonItem3_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

        }
        private void BarButtonItem6_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            forms.sciehtific_collection frm = new forms.sciehtific_collection();
            frm.ShowDialog();
        }
        private void BarButtonItem4_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            forms.Compny_Frm frm = new forms.Compny_Frm();
            frm.ShowDialog();
        }
        private void BarButtonItem9_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

            new Items_Tools().showAndHideForm(View_And_serch);
            lbl_count.Text = DB_Add_delete_update_.Database.dv.Count.ToString();
        }

        private void BarButtonItem10_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

        }

        private void Frm_Coll_Item_Paint(object sender, PaintEventArgs e)
        {

        }

        private void BarButtonItem12_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            forms.Type_supply_ m1 = new forms.Type_supply_();
            m1.ShowDialog();
        }

        private void BarButtonItem8_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            forms.places_of_items m1 = new forms.places_of_items();
            m1.ShowDialog();

        }

        private void BarButtonItem13_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            forms.collection_of_Item m1 = new forms.collection_of_Item();
            m1.ShowDialog();
        }

        private void BarButtonItem17_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            forms.nature_of_Item m1 = new forms.nature_of_Item();
            m1.ShowDialog();
        }

        private void GroupControl2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void GroupControl1_Paint(object sender, PaintEventArgs e)
        {

        }
        //اضافة الصنف كامل مهم
        private void Btn_Add_Click(object sender, EventArgs e)
        {
            Items.AddDataItem();
            txt_barcode_enter.Focus();
        }

        private void BarButtonItem15_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            forms.effective_material frm = new forms.effective_material();
            frm.ShowDialog();

        }

        private void BarButtonItem16_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            forms.reason_for_user frm = new forms.reason_for_user();
            frm.ShowDialog();
        }

        private void Com_nature_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void Ch_item_drog_CheckedChanged(object sender, EventArgs e)
        {
            if (!ch_item_drog.Checked)
            {
                grop_inf_ph_gbx.Enabled = false;
                com_sciehtific_collection.SelectedIndex = 0;
                com_effective_material.SelectedIndex = 0;
                com_reason.SelectedIndex = 0;
            }
            else
            {
                grop_inf_ph_gbx.Enabled = true;
            }
        }

        private void Pic_itms_Click(object sender, EventArgs e)
        {
            //حدث اضافة الصورة الا الاصناف
            Items.Add_picr();

        }

        private void Txt_Name_ar_KeyDown(object sender, KeyEventArgs e)
        {
            foucs_key(e, txt_item_tr);
        }

        private void Txt_item_tr_KeyDown(object sender, KeyEventArgs e)
        {
            foucs_key(e, txt_item_name_en);
        }

        private void Txt_item_name_en_KeyDown(object sender, KeyEventArgs e)
        {
            foucs_key(e, txt_item_nots);
        }

        private void Sell_pric_KeyDown(object sender, KeyEventArgs e)
        {
            foucs_key(e, disc_parc);
        }

        private void Sell_pric_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsDigit(e.KeyChar) || e.KeyChar == 8))
            {
                e.Handled = true;
            }
        }

        private void Max_DIsc_KeyDown(object sender, KeyEventArgs e)
        {
            foucs_key(e, disc_parc);

        }

        private void Max_DIsc_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsDigit(e.KeyChar) || e.KeyChar == 8))
            {
                e.Handled = true;
            }
        }
        //دالة لحساب نسبة الخصم
        private void Col_Discount()
        {
            if (disc_parc.Text.Trim() != string.Empty && sell_pric.Text.Trim() != string.Empty)
            {
                lbl_disc.ForeColor = Color.Black;

                double sell = Convert.ToDouble(sell_pric.Text.Trim());
                double pric_ns = Convert.ToDouble(disc_parc.Text.Trim()) / 100;
                double reslt = sell * pric_ns;

                double reslt2 = sell - reslt;
                product_price.Text = reslt2.ToString();
                Aoumn_befor = reslt2.ToString();
            }
        }
        private void Disc_parc_KeyDown(object sender, KeyEventArgs e)
        {
            foucs_key(e, tax_pric);
            Col_Discount();
        }

        private void Disc_parc_KeyPress(object sender, KeyPressEventArgs e)
        {


            if (!(char.IsDigit(e.KeyChar) || e.KeyChar == 8))
            {
                e.Handled = true;
            }
            if (char.IsDigit(e.KeyChar))
            {
                //int max = Convert.ToInt32(Max_DIsc.Text.Trim());
                string str = disc_parc.Text.Trim() + e.KeyChar.ToString();
                string str2 = e.KeyChar.ToString() + disc_parc.Text.Trim();
                //string str = disc_parc.text.trim();
                int pric = Convert.ToInt32(str);
                int pric2 = Convert.ToInt32(str2);
                if (!(pric <= 100))
                {
                    e.Handled = true;
                }
            }

        }

        private void Tax_pric_KeyDown(object sender, KeyEventArgs e)
        {
            foucs_key(e, product_price);

        }

        private void Tax_pric_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsDigit(e.KeyChar) || e.KeyChar == 8))
            {
                e.Handled = true;
            }

        }

        private void Disc_parc_KeyUp(object sender, KeyEventArgs e)
        {
            if (disc_parc.Text.Trim() != string.Empty)
            {
                Col_Discount();
            }
            m2.Check_Text_Empty(disc_parc, lbl_disc);
        }

        private void Max_DIsc_KeyUp(object sender, KeyEventArgs e)
        {
            if (Max_DIsc.Text.Trim() != string.Empty)
            {
                disc_parc.Text = "0";
                Col_Discount();
            }
            m2.Check_Text_Empty(Max_DIsc, lbl_max);
        }
        // حدث اضافة حساب السعر
        private void Sell_pric_KeyUp(object sender, KeyEventArgs e)
        {
            product_price.Text = sell_pric.Text;
            m2.Check_Text_Empty(sell_pric, lbl_sall);
            pric_unit_avrg.Text = sell_pric.Text;
            pric_unit_smol.Text = sell_pric.Text;
        }

        private void Txt_Name_ar_KeyUp(object sender, KeyEventArgs e)
        {
            m2.Check_Text_Empty(txt_Name_ar, lbl_ar);
        }
        //دالة لحساب الضريبة
        private void Auom()
        {
            if (tax_pric.Text.Trim() != string.Empty)
            {
                double tax = Convert.ToDouble(tax_pric.Text.Trim()) / 100;
                double prodect = Convert.ToDouble(Aoumn_befor);

                double reslt = prodect * tax;

                double reslt2 = prodect - reslt;
                product_price.Text = reslt2.ToString();

                lbl_tex.ForeColor = Color.Black;

            }
        }
        private void Auom_update()
        {
            if (tax_pric_update.Text.Trim() != string.Empty)
            {
                double tax = Convert.ToDouble(tax_pric_update.Text.Trim()) / 100;
                double prodect = Convert.ToDouble(Aoumn_befor_update);

                double reslt = prodect * tax;

                double reslt2 = prodect - reslt;
                product_price_update.Text = reslt2.ToString();

                //lbl_tex.ForeColor = Color.Black;

            }
        }
        private void Tax_pric_KeyUp(object sender, KeyEventArgs e)
        {
            Auom();
            m2.Check_Text_Empty(tax_pric, lbl_tex);
        }

        private void Sell_pric_MouseDown(object sender, MouseEventArgs e)
        {
            ContextMenu m3 = new ContextMenu();
            if (e.Button == MouseButtons.Right)
            {
                sell_pric.ContextMenu = m3;
            }
        }

        private void Max_DIsc_MouseDown(object sender, MouseEventArgs e)
        {
            ContextMenu m3 = new ContextMenu();
            if (e.Button == MouseButtons.Right)
            {
                Max_DIsc.ContextMenu = m3;
            }
        }

        private void Disc_parc_MouseDown(object sender, MouseEventArgs e)
        {
            ContextMenu m3 = new ContextMenu();
            if (e.Button == MouseButtons.Right)
            {
                disc_parc.ContextMenu = m3;
            }
        }

        private void Tax_pric_MouseDown(object sender, MouseEventArgs e)
        {
            ContextMenu m3 = new ContextMenu();
            if (e.Button == MouseButtons.Right)
            {
                tax_pric.ContextMenu = m3;
            }
        }

        private void Product_price_MouseDown(object sender, MouseEventArgs e)
        {

            ContextMenu m3 = new ContextMenu();
            if (e.Button == MouseButtons.Right)
            {
                product_price.ContextMenu = m3;
            }
        }

        private void Product_price_KeyPress(object sender, KeyPressEventArgs e)
        {


            if (!(char.IsDigit(e.KeyChar) || e.KeyChar == 8))
            {
                e.Handled = true;
            }

        }

        private void Num_unit_avrg_KeyDown(object sender, KeyEventArgs e)
        {
            foucs_key(e, pric_unit_avrg);
        }

        private void Num_unit_smol_KeyDown(object sender, KeyEventArgs e)
        {
            foucs_key(e, pric_unit_smol);
        }

        private void Num_unit_avrg_KeyUp(object sender, KeyEventArgs e)
        {
            m2.Check_Text_Empty(num_unit_avrg, lbl_avrg);

            double num = m2.Calc_un(num_unit_avrg, sell_pric);
            int num2 = Convert.ToInt32(num);
            if (num == num2)
            {
                pric_unit_avrg.Text = num.ToString();
            }
            else
            {
                pric_unit_avrg.Text = num.ToString("N");
            }


            double nums = m2.Calc_un(num_unit_smol, pric_unit_avrg);
            int nums2 = Convert.ToInt32(nums);
            if (nums == nums2)
            {
                pric_unit_smol.Text = nums.ToString();
            }
            else
            {
                pric_unit_smol.Text = nums.ToString("N");
            }


        }

        private void Num_unit_smol_KeyUp(object sender, KeyEventArgs e)
        {



            m2.Check_Text_Empty(num_unit_smol, lbl_smoll);

            double num = m2.Calc_un(num_unit_smol, pric_unit_avrg);
            int num2 = Convert.ToInt32(num);
            if (num == num2)
            {
                pric_unit_smol.Text = num.ToString();
            }
            else
            {
                pric_unit_smol.Text = num.ToString("N");
            }



            //MessageBox.Show((Convert.ToDouble(pric_unit_avrg.Text)/ Convert.ToDouble(num_unit_smol.Text)) +"");

        }

        private void BarButtonItem14_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //   Main_Form.SelectedPage = frm_Coll_Item;
            new Items_Tools().showAndHideForm(Add_Item);
            txt_barcode_enter.Focus();
        }


        private void BarButtonItem14_ItemClick_1(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

        }

        private void TextBox1_TextChanged(object sender, EventArgs e)
        {
            // الكود الخاص بلبحث
            serchs.serch_view_Item();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            serchs.get_Unit();


        }

        private void Txt_Serch_Item_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void Txt_Serch_Item_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (char.IsSymbol(e.KeyChar) || e.KeyChar == '[' || e.KeyChar == ']')
                {
                    e.Handled = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Ch_Dow_CheckedChanged(object sender, EventArgs e)
        {
            serchs.Down_Dro();
        }

        private void Ch_Stop_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void Ch_Dow_CheckedChanged_1(object sender, EventArgs e)
        {
            // جاهز دوا
            serchs.serch_drg();

        }

        private void Ch_NoDow_CheckedChanged(object sender, EventArgs e)
        {

        }


        private void Ch_All_CheckedChanged_1(object sender, EventArgs e)
        {

        }

        private void Ch_NoDow_CheckedChanged_1(object sender, EventArgs e)
        {
            //البحث في الصنف
            serchs.serch_Items();


        }


        private void Ch_NoDow_CheckedChanged_2(object sender, EventArgs e)
        {

        }

        private void RadioButton1_CheckedChanged(object sender, EventArgs e)
        {

        }
        private void Ch_Stop_CheckedChanged_1(object sender, EventArgs e)
        {

        }
        private void Ch_NoStop_CheckedChanged(object sender, EventArgs e)
        {

        }
        private void Ch_NoDow_CheckedChanged_3(object sender, EventArgs e)
        {
            serchs.All_Drt();

        }

        private void Ch_All_CheckedChanged(object sender, EventArgs e)
        {
            serchs.AllDrk_stop();

        }

        private void Ch_Stop_CheckedChanged_2(object sender, EventArgs e)
        {

            serchs.All_dar_2();

        }

        private void Ch_NoStop_CheckedChanged_1(object sender, EventArgs e)
        {
            serchs.NoStoop();
        }

        private void Ch_Sp_All_CheckedChanged(object sender, EventArgs e)
        {
            serchs.ch_sp_All();
        }

        private void Bt_new_Item_Click(object sender, EventArgs e)
        {
            bt_Add_Item.PerformClick();
        }

        private void Btn_update_Item_Click(object sender, EventArgs e)
        {


            new Items_Tools().showAndHideForm(update_Item);
            updates.updates();

        }

        private void Txt_item_nots_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void Txt_item_nots_KeyDown(object sender, KeyEventArgs e)
        {
            foucs_key(e, sell_pric);
        }

        private void Product_price_KeyDown(object sender, KeyEventArgs e)
        {
            foucs_key(e, num_unit_avrg);
        }

        private void Pric_unit_avrg_KeyDown(object sender, KeyEventArgs e)
        {
            foucs_key(e, num_unit_smol);
        }

        private void Pric_unit_smol_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btn_Add_btn.PerformClick();
            }
        }

        private void Delete_Click(object sender, EventArgs e)
        {
            Deletes.Delete_Item();

        }

        private void Button2_Click(object sender, EventArgs e)
        {
            // حدث تحديث كل البيانات
            updates.update_All();

            new Items_Tools().showAndHideForm(View_And_serch);
        }

        private void Btn_Add_storg_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Datagridview_Type_barcode = 1;
            new Items_Tools().showAndHideForm(open_balanc_storg);
            txt_sum_num.Text = Open_blans.AoutoNumber("sum_storg_Item", "sum_num").ToString();
        }

        private void Com_unit_Comtl_SelectedIndexChanged(object sender, EventArgs e)
        {
            // حدث اختيار الوحدة الكبرا
            updates.Cobr_All();
        }

        private void Com_unit_avrg_SelectedIndexChanged(object sender, EventArgs e)
        {
            // حدث اختيار الوحدة الوسطا
            updates.Avrg_All();
        }

        private void Com_unit_smol_SelectedIndexChanged(object sender, EventArgs e)
        {
            // حدث اختيار الوحدة الصغرا
            updates.smoll_All();
        }

        private void Btn_storg_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {



            dgv_storg_dgv.DataSource = DB_Add_delete_update_.Database.ds.Tables["Storg"];
            new Items_Tools().showAndHideForm(Add_Storg);
            dgv_storg_dgv.Columns[0].HeaderText = " رقم المخزن";
            dgv_storg_dgv.Columns[1].HeaderText = "اسم لمخزن(AR)";
            dgv_storg_dgv.Columns[2].HeaderText = "اسم لمخزن(EN)";
            dgv_storg_dgv.Columns[3].HeaderText = "عنوان المخزن";
            dgv_storg_dgv.Columns[4].HeaderText = "امين المخزم";
            dgv_storg_dgv.Columns[5].HeaderText = " الهاتف";



        }

        private void Dgv_storg_SelectionChanged(object sender, EventArgs e)
        {
            if (dgv_storg_dgv.CurrentRow != null)
            {
                txt_num_storg.Text = dgv_storg_dgv.CurrentRow.Cells[0].Value.ToString();
                txt_Storg_name_ar.Text = dgv_storg_dgv.CurrentRow.Cells[1].Value.ToString();
                txt_Storg_name_en.Text = dgv_storg_dgv.CurrentRow.Cells[2].Value.ToString();
                txt_Addrs_storg.Text = dgv_storg_dgv.CurrentRow.Cells[3].Value.ToString();
                txt_Am_storg.Text = dgv_storg_dgv.CurrentRow.Cells[4].Value.ToString();
                txt_Pho_storg.Text = dgv_storg_dgv.CurrentRow.Cells[5].Value.ToString();

                btn_Adds_storg_btn.Enabled = false;
                btn_Delete_storg_btn.Enabled = true;
                btn_update_storg_btn.Enabled = true;


            }
        }

        private void Btn_new_Click(object sender, EventArgs e)
        {
            // حذ بيانات ادخال المخازن

            storgs.ClearData_storg();
        }

        private void Button1_Click_1(object sender, EventArgs e)
        {
            if (txt_Storg_name_ar.Text.Trim() != string.Empty)
            {
                MessageBox.Show("Test");
                DB_Add_delete_update_.Database.ds.Tables["Storg"].Rows.Add(Convert.ToInt32(txt_num_storg.Text), txt_Storg_name_ar.Text, txt_Storg_name_en.Text, txt_Addrs_storg.Text, txt_Am_storg.Text, txt_Pho_storg.Text);
                DB_Add_delete_update_.Database.update("Storg");
                // حذ بيانات ادخال المخازن
                storgs.ClearData_storg();
            }
        }

        private void Btn_Delete_storg_Click(object sender, EventArgs e)
        {
            // حذف محزن
            storgs.Delete_Storg();
        }

        private void Btn_update_storg_Click(object sender, EventArgs e)
        {
            // تحديث البيانان
            storgs.update_Storg();

        }

        private void Button1_Click_2(object sender, EventArgs e)
        {
            dgv_open_storg_dgv.Rows.Add();
        }

        private void Dgv_open_storg_KeyPress(object sender, KeyPressEventArgs e)
        {

        }
        private void Dgv_open_storg_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            ////دالة لتحكم بالوحدات والاسعار الخاصة بلوحدات

            Open_blans.EditingControlShowing(sender, e);

        }

        private void TextBox1_KeyDown(object sender, KeyEventArgs e)
        {


        }

        private void Dgv_open_storg_CellClick(object sender, DataGridViewCellEventArgs e)
        {


        }

        private void Dgv_open_storg_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {




        }

        private void Dgv_open_storg_KeyDown(object sender, KeyEventArgs e)
        {


        }

        private void Dgv_open_storg_KeyUp(object sender, KeyEventArgs e)
        {



        }

        private void Dgv_open_storg_CellClick_1(object sender, DataGridViewCellEventArgs e)
        {

        }
        private void Button3_Click(object sender, EventArgs e)
        {
            //حذف سطر من الجدول
            if (dgv_open_storg_dgv.CurrentRow != null)
            {
                //MessageBox.Show(dgv_open_storg_dgv.CurrentCell.RowIndex + "");
                dgv_open_storg_dgv.Rows.RemoveAt(dgv_open_storg_dgv.CurrentCell.RowIndex);
            }
            //Totle_price();
            Open_blans.Totle_price();
        }
        public bool Open_Storg = false;
        private void Dgv_open_storg_DoubleClick(object sender, EventArgs e)
        {
            Open_Storg = true;
            //لعرض جدول الاصناف
            new forms.Item_Data().ShowDialog();

        }
        private void Dgv_open_storg_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
        }
        private void Dgv_open_storg_Scroll(object sender, ScrollEventArgs e)
        {
            
        }
        private void Dgv_open_storg_CellClick_2(object sender, DataGridViewCellEventArgs e)
        {
        }
        private void Dgv_open_storg_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            
        }
        private void Label16_Click(object sender, EventArgs e)
        {

        }
        string tex22 = "";
        double temp_open = 0;
        private void Dgv_open_storg_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {


            if (dgv_open_storg_dgv.CurrentCell.ColumnIndex == 0)
            {

                new classs_table.Items_Tools().SetKeyboardLayout("eng");
            }


            if (dgv_open_storg_dgv.CurrentCell.ColumnIndex == 7)
            {
                Open_blans.prodects = Convert.ToDouble(dgv_open_storg_dgv.CurrentRow.Cells[9].Value);

                //prodect = Convert.ToDouble(dgv_open_storg.CurrentRow.Cells[9].Value);

            }
            else if (dgv_open_storg_dgv.CurrentCell.ColumnIndex == 8)
            {
                Open_blans.prodects = Convert.ToDouble(dgv_open_storg_dgv.CurrentRow.Cells[9].Value);
            }
            else if (dgv_open_storg_dgv.CurrentCell.ColumnIndex == 6)
            {
                temp_open = Convert.ToDouble(dgv_open_storg_dgv.CurrentRow.Cells[6].Value);
            }
            else if (dgv_open_storg_dgv.CurrentCell.ColumnIndex == 9)
            {
                temp_open = Convert.ToDouble(dgv_open_storg_dgv.CurrentRow.Cells[9].Value);
            }
            
        }

        private void Dgv_open_storg_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            try
            {

                if (dgv_open_storg_dgv.CurrentRow != null)
                {
                    if (dgv_open_storg_dgv.CurrentCell.ColumnIndex == 6)
                    {
                        object test = dgv_open_storg_dgv.CurrentRow.Cells[6].Value;

                        if (test == null || Convert.ToDouble(test) == 0)
                        {

                            dgv_open_storg_dgv.CurrentRow.Cells[6].Value = temp_open.ToString("N0");
                        }
                        else if (Convert.ToDouble(test) < Convert.ToDouble(dgv_open_storg_dgv.CurrentRow.Cells[9].Value))
                        {
                            MessageBox.Show("سعر البيع اصغر من سعر الشرا !!");
                            dgv_open_storg_dgv.CurrentRow.Cells[6].Value = temp_open.ToString("N0");

                        }
                    }
                    else if (dgv_open_storg_dgv.CurrentCell.ColumnIndex == 9)
                    {
                        object test = dgv_open_storg_dgv.CurrentRow.Cells[9].Value;

                        if (test == null || Convert.ToDouble(test) == 0)
                        {

                            dgv_open_storg_dgv.CurrentRow.Cells[9].Value = temp_open.ToString("N0");
                        }
                        else if (Convert.ToDouble(test) > Convert.ToDouble(dgv_open_storg_dgv.CurrentRow.Cells[6].Value))
                        {
                            MessageBox.Show("سعر الشرا اكبر من سعر البيع !!");
                            dgv_open_storg_dgv.CurrentRow.Cells[9].Value = temp_open.ToString("N0");

                        }
                    }
                    {

                    }
                }
                //الدالة الاساسية لعرض لبحث وعرض البيانات  في الجدول
                Items_Tools.DGV_Test(dgv_open_storg_dgv, null);

                Open_blans.view_And_serch();
            }
            catch
            {
                if (dgv_open_storg_dgv.CurrentRow != null)
                {
                    MessageBox.Show("لايوجد صنف بهاذا الرقم", "لايوجد");
                    dgv_open_storg_dgv.Rows.Remove(dgv_open_storg_dgv.CurrentRow);
                    new storg.open_blans_storg().Totle_price();
                }

            }

        }

        private void Button4_Click(object sender, EventArgs e)
        {
            //  لحفظ البيانات الافتتاحية
            Open_blans.Save_Data_Storg();

        }
        public bool bool_num_stor = false;
        private void TextBox6_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            bool_num_stor = true;
            forms.Data_storg m1 = new forms.Data_storg();
            m1.ShowDialog();
        }

        private void Txt_num_stor_KeyPress(object sender, KeyPressEventArgs e)
        {
            //للبحث عن الرقم لتعديل في المخزون الافتتاحي
            update_Open_blans.serch_number(sender, e);
        }

        private void Txt_num_stor_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private void GroupBox3_Enter(object sender, EventArgs e)
        {

        }

        private void Button5_Click(object sender, EventArgs e)
        {



        }

        private void TextBox6_TextChanged(object sender, EventArgs e)
        {


        }
        public static DataSet Dataunit2 = new DataSet();
        private void Txt_num_sum_KeyPress(object sender, KeyPressEventArgs e)
        {
            // دالة للبحث والتعديل عن المخزون الافتتاحي
            update_Open_blans.update_open_storg_serch(sender, e);
        }

        private void BarButtonItem21_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            new Items_Tools().showAndHideForm(update_Item_storg);
        }
        private void Dgv_open_storg_update_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            //دالة لتحويل الوحدات او تعديل الوحدات عبر الكبو بكس
            update_Open_blans.Dgv_open_storg_update_EditingControlShowing_(sender, e);
        }
        private void Dgv_open_storg_update_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            //تحديث البيانت بعد كل عملية تعديل في الخلية
            update_Open_blans.Dgv_open_storg_update_CellEndEdit_();
        }

        private void Txt_num_stor_update_KeyPress(object sender, KeyPressEventArgs e)
        {
            //للبحث عن الاصناف من اجل التعديل
            update_Open_blans.Txt_num_stor_update_KeyPress_(sender, e);
        }
        //==================================================================================================================================================================

        //==================================================================================================================================================================

        // حدث تحديث البيانت الافتتاحية
        private void Button7_Click(object sender, EventArgs e)
        {
            update_Open_blans.event_update_open_buttn();
        }

        private void Dgv_open_storg_update_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // اضهار التاريخ والوقت في الجدول

        }

        private void BarButtonItem9_ItemClick_1(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            new Items_Tools().showAndHideForm(TransFormation);
            txt_num_Transformtion.Text = Open_blans.AoutoNumber("Data_Items_Transform_of_storg", "Trans_num").ToString();

        }

        private void DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {


        }

        private void NavigationPage1_Paint(object sender, PaintEventArgs e)
        {

        }

        // دالة لحذف بيانات من قاعدة البيانات
        private void Delete_Row_Table_Database(string TableName, int PK1, int PK2)
        {
            object[] ss = { PK1, PK2 };
            DataRow Data_update_storg = DB_Add_delete_update_.Database.ds.Tables[TableName].Rows.Find(ss);
            int Row_sum_Index_update = DB_Add_delete_update_.Database.ds.Tables[TableName].Rows.IndexOf(Data_update_storg);
            DB_Add_delete_update_.Database.ds.Tables[TableName].Rows[Row_sum_Index_update].Delete();
            DB_Add_delete_update_.Database.update(TableName);
        }


        private void Button10_Click(object sender, EventArgs e)
        {
            //جاهز
            object[] arrdelete = new object[2];

            arrdelete[0] = dataGridView4_dgv.CurrentRow.Cells[0].Value;
            arrdelete[1] = dataGridView4_dgv.CurrentRow.Cells[1].Value;

            DataRow[] dr2 = DB_Add_delete_update_.Database.ds.Tables["tb_alternatives"].Select("Item_no2=" + arrdelete[1] + " And " + "Item_no=" + arrdelete[0]);


            DialogResult dr = MessageBox.Show("هل تريد بالفعل حذف  البديل المحدد ", "حذف", MessageBoxButtons.YesNo, MessageBoxIcon.Information, MessageBoxDefaultButton.Button2);

            if (dr == DialogResult.Yes)
            {
                if (dr2.Count() != 0)
                {
                    //     DataRow dr_suup1 = DB_Add_delete_update_.Database.ds.Tables["tb_alternatives"].Rows.Find(dr2);//

                    //DB_Add_delete_update_.Database.ds.Tables["tb_alternatives"].Rows.Remove(DB_Add_delete_update_.Database.ds.Tables["tb_alternatives"].Rows.Find(arrdelete));    

                    Delete_Row_Table_Database("tb_alternatives", Convert.ToInt32(arrdelete[0]), Convert.ToInt32(arrdelete[1]));
                    Delete_Row_Table_Database("tb_alternatives", Convert.ToInt32(arrdelete[1]), Convert.ToInt32(arrdelete[0]));


                    dataGridView4_dgv.Rows.Clear();
                    int id = Convert.ToInt16(dataGridView2_dgv.CurrentRow.Cells[0].Value);
                    DataRow[] dr1;
                    dr1 = DB_Add_delete_update_.Database.ds.Tables["tb_it_main"].Select("Item_no=" + id);


                    if (dr1.Count() != 0)
                    {


                        dr2 = DB_Add_delete_update_.Database.ds.Tables["tb_alternatives"].Select("Item_no=" + id);
                        for (int i = 0; i < dr2.Count(); i++)
                        {
                            dataGridView4_dgv.Rows.Add(dr2[i][0], dr2[i][1], dr2[i][2], dr2[i][3], dr2[i][4], dr2[i][5], dr2[i][6]);

                        }


                    }
                }
                else
                {
                    MessageBox.Show(" لم يتم الحذف يرجا ان يتم الحفظ قبل الحذف  ", " لم يتم الحذف ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    button10_btn.Enabled = false;

                }
            }
            else
            {

                MessageBox.Show("تم الغاء الحذف  ", "حذف", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }
        //**********************************************************************************************************
        //داله البحث عن الصنف
        private void Btn_sersh_Click(object sender, EventArgs e)
        {
            dataGridView4_dgv.Rows.Clear();

            string str = txt_sersh_view2.Text;
            //dv.RowFilter = "[رقم الصنف]+[اسم العربي]+[اسم انجليزي]+[اسم التجاري] like'%" + str + "%'";

            DB_Add_delete_update_.Database.dv4.RowFilter = "[رقم الصنف]+[اسم العربي]+[اسم انجليزي]+[اسم التجاري] like'%" + str + "%'";


            dataGridView2_dgv.DataSource = DB_Add_delete_update_.Database.dv4;

            if (dataGridView2_dgv.Rows.Count != 0)
            {

                btn_add_badal_btn.Enabled = true;
            }

            //DataView dv = new DataView(DB_Add_delete_update_.Database.view_All("All_collection_of_Item"));
            //DB_Add_delete_update_.Database.dv3.RowFilter = "[رقم الصنف]+[اسم العربي]+[اسم انجليزي]+[اسم التجاري]+[اسم الشركة]+[سعر] like'%" + txt_sersh_view2.Text + "%'";



            Main ma = new Main();
            ma.dataGridView4_dgv.Rows.Clear();

            var n = Application.OpenForms["Main"] as Main;

            object[] arr = new object[6];
            //*******************************************
            DataRow[] dr1;

            DataRow[] dr2;

            if (dataGridView2_dgv.Rows.Count != 0)
            {
                int id = Convert.ToInt16(dataGridView2_dgv.CurrentRow.Cells[0].Value);

                dr1 = DB_Add_delete_update_.Database.ds.Tables["tb_it_main"].Select("Item_no=" + id);


                if (dr1.Count() != 0)
                {


                    dr2 = DB_Add_delete_update_.Database.ds.Tables["tb_alternatives"].Select("Item_no=" + id);
                    for (int i = 0; i < dr2.Count(); i++)
                    {
                        dataGridView4_dgv.Rows.Add(dr2[i][0], dr2[i][1], dr2[i][2], dr2[i][3], dr2[i][4], dr2[i][5], dr2[i][6]);

                    }
                    MessageBox.Show(" عدد البدائل للصنف" + dr2.Count().ToString(), "", MessageBoxButtons.OK, MessageBoxIcon.Information);



                }

            }
            else
            {
                MessageBox.Show(" لايوجد  الصنف المطلوب ", "", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }

        }
        //************************************************************************


        //*********************************************************************
        //داله حفظ الصنف الرئيسي مع البدائل 

        private void Btn_save_Click(object sender, EventArgs e)
        {
            //جاهز
            int x2 = dataGridView2_dgv.Rows.Count;
            if (x2 == 0)
            {
                MessageBox.Show("يرجاء اضافه الصنف الاساسي", "خطاء", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {

                object[] arr = new object[6];
                for (int i = 0; i < arr.Length; i++)
                {

                    arr[i] = dataGridView2_dgv.CurrentRow.Cells[i].Value;

                }



                int intmItem_no = Convert.ToInt32(arr[0]);

                string name_ar = arr[1].ToString();
                string name_en = arr[2].ToString();
                string name_tr = arr[3].ToString();
                string comp_name = arr[4].ToString();
                int sell_pric = Convert.ToInt32(arr[5]);



                forms.Form2 fs = new forms.Form2();

                DataRow[] dr1;


                int id = Convert.ToInt32(dataGridView2_dgv.CurrentRow.Cells[0].Value);

                //dr = DB_Add_delete_update_.Database.ds.Tables["tb_it_main"].Rows.Find(x).IsNull(0);
                dr1 = DB_Add_delete_update_.Database.ds.Tables["tb_it_main"].Select("Item_no=" + id);

                //MessageBox.Show(dr1.Count().ToString());

                if (dr1.Count() == 0)

                {


                    DB_Add_delete_update_.Database.ds.Tables["tb_it_main"].Rows.Add(intmItem_no, name_ar, name_en, name_tr, comp_name, sell_pric);

                    DB_Add_delete_update_.Database.update("tb_it_main");

                }


                ///**********************************************


                int dd = dataGridView4_dgv.Rows.Count;
                string[] mes = new string[dd];

                if (dd != 0)
                {




                    for (int y = 0; y < dd; y++)
                    {

                        int id2 = Convert.ToInt32(dataGridView4_dgv.Rows[y].Cells[1].Value);
                        int id3 = Convert.ToInt32(dataGridView4_dgv.Rows[y].Cells[0].Value);
                        int ntmItem_no2;
                        int Item_no2;
                        string name_ar2;
                        string name_en2;
                        string name_tr2;
                        string comp_name2;
                        int sell_pric2;

                        DataRow[] dr2 = DB_Add_delete_update_.Database.ds.Tables["tb_alternatives"].Select("Item_no2=" + id2 + " And " + "Item_no=" + id3);


                        if (dr2.Count() == 0)

                        {


                            object[] arr2 = new object[7];

                            int x = 1;

                            for (int i = 1; i < 7; i++)
                            {
                                arr2[0] = dataGridView2_dgv.CurrentRow.Cells[0].Value;
                                arr2[x] = dataGridView4_dgv.Rows[y].Cells[i].Value;
                                x++;
                            }

                            ntmItem_no2 = Convert.ToInt32(arr2[0]);
                            Item_no2 = Convert.ToInt32(arr2[1]);
                            name_ar2 = Convert.ToString(arr2[2]);
                            name_en2 = arr2[3].ToString();
                            name_tr2 = arr2[4].ToString();
                            comp_name2 = arr2[5].ToString();
                            sell_pric2 = Convert.ToInt32(arr2[6]);



                            DB_Add_delete_update_.Database.ds.Tables["tb_alternatives"].Rows.Add(ntmItem_no2, Item_no2, name_ar2, name_en2, name_tr2, comp_name2, sell_pric2);
                            DB_Add_delete_update_.Database.update("tb_alternatives");

                            DataRow[] dr11 = DB_Add_delete_update_.Database.ds.Tables["tb_it_main"].Select("Item_no=" + Item_no2);



                            if (dr11.Count() == 0)

                            {


                                DB_Add_delete_update_.Database.ds.Tables["tb_it_main"].Rows.Add(Item_no2, name_ar2, name_en2, name_tr2, comp_name2, sell_pric2);
                                DB_Add_delete_update_.Database.update("tb_it_main");

                            }


                            DataRow[] dr3 = DB_Add_delete_update_.Database.ds.Tables["tb_alternatives"].Select("Item_no=" + Item_no2 + " And " + "Item_no2=" + ntmItem_no2);


                            if (dr3.Count() == 0)

                            {
                                DB_Add_delete_update_.Database.ds.Tables["tb_alternatives"].Rows.Add(Item_no2, ntmItem_no2, name_ar, name_en, name_tr, comp_name, sell_pric);
                                DB_Add_delete_update_.Database.update("tb_alternatives");

                            }





                        }



                    }
                    MessageBox.Show("تم الاضافة البائل  ", "اضافة", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    btn_save_btn.Enabled = false;
                    button10_btn.Enabled = true;
                    dataGridView4_dgv.Refresh();
                }
                else
                {

                    MessageBox.Show("يرجاء اضافه بديل", "خطاء", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
            }


        }

        //*************************************
        // داله تنظيف الجداول جديد

        private void Button8_Click(object sender, EventArgs e)
        {
            //جاهز
            dataGridView4_dgv.Rows.Clear();
            dataGridView2_dgv.DataSource = null;
            txt_sersh_view2.Clear();
        }
        //************************************************************************
        private void Txt_sersh_view2_TextChanged(object sender, EventArgs e)
        {
            //جاهز
            dataGridView4_dgv.Rows.Clear();

            //string str = txt_sersh_view2.Text;
            string str = classs_table.Items_Tools.get_str_barcode(txt_sersh_view2).ToString();
            //dv4.RowFilter = "[رقم الصنف]+[اسم العربي]+[اسم انجليزي]+[اسم التجاري] like'%" + str + "%'";
            DB_Add_delete_update_.Database.dv4.RowFilter = "[رقم الصنف]+[اسم العربي]+[اسم انجليزي]+[اسم التجاري] like'%" + str + "%'";

            //DB_Add_delete_update_.Database.dv4.RowFilter = "[رقم الصنف] like'%" + str + "%'";
            //DB_Add_delete_update_.Database.ds.Tables[""] = "[رقم الصنف] like'%" + str + "%'";


            dataGridView2_dgv.DataSource = DB_Add_delete_update_.Database.dv4;



            if (dataGridView2_dgv.Rows.Count != 0)
            {

                btn_add_badal_btn.Enabled = true;
            }

            //DataView dv = new DataView(DB_Add_delete_update_.Database.view_All("All_collection_of_Item"));
            //DB_Add_delete_update_.Database.dv3.RowFilter = "[رقم الصنف]+[اسم العربي]+[اسم انجليزي]+[اسم التجاري]+[اسم الشركة]+[سعر] like'%" + txt_sersh_view2.Text + "%'";



            Main ma = new Main();
            ma.dataGridView4_dgv.Rows.Clear();

            var n = Application.OpenForms["Main"] as Main;

            object[] arr = new object[6];
            //*******************************************
            DataRow[] dr1;

            DataRow[] dr2;

            if (dataGridView2_dgv.Rows.Count != 0)
            {
                int id = Convert.ToInt16(dataGridView2_dgv.CurrentRow.Cells[0].Value);

                dr1 = DB_Add_delete_update_.Database.ds.Tables["tb_it_main"].Select("Item_no=" + id);


                if (dr1.Count() != 0)
                {


                    dr2 = DB_Add_delete_update_.Database.ds.Tables["tb_alternatives"].Select("Item_no=" + id);
                    for (int i = 0; i < dr2.Count(); i++)
                    {
                        dataGridView4_dgv.Rows.Add(dr2[i][0], dr2[i][1], dr2[i][2], dr2[i][3], dr2[i][4], dr2[i][5], dr2[i][6]);

                    }
                    MessageBox.Show(" عدد البدائل للصنف" + dr2.Count().ToString(), "", MessageBoxButtons.OK, MessageBoxIcon.Information);



                }

            }
            else
            {
                MessageBox.Show(" لايوجد  الصنف المطلوب ", "", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
        }


        //**************************************
        // داله فتح واحجهه اضافه بديل
        private void Btn_badal_Click(object sender, EventArgs e)
        {
            //جاهز
            forms.Form2 m = new forms.Form2();
            //dataGridView4.Rows.Clear();

            m.Text = "اختيار البديل";
            m.Show();
        }
        private void Btn_bdals_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            new Items_Tools().showAndHideForm(bdails_page);
        }

        private void Timer1_Tick(object sender, EventArgs e)
        {
            lbl_DateTime_Trans.Text = DateTime.Now.ToString();
        }

        private void Txt_num_storg_send_KeyPress(object sender, KeyPressEventArgs e)
        {
            Transformtion.Txt_num_storg_send_KeyPress_(sender, e);
        }

        private void Txt_num_storg_Trans_KeyPress(object sender, KeyPressEventArgs e)
        {
            Transformtion.Txt_num_storg_Trans_KeyPress_(sender, e);

        }
        public bool send = false;
        private void Txt_num_storg_send_DoubleClick(object sender, EventArgs e)
        {
            send = true;
            forms.Data_storg m1 = new forms.Data_storg();
            m1.ShowDialog();

        }
        public bool Transform = false;
        private void Txt_num_storg_Trans_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            Transform = true;
            forms.Data_storg m1 = new forms.Data_storg();
            m1.ShowDialog();
        }

        private void Button5_Click_1(object sender, EventArgs e)
        {
            dgv_tranformtion_dgv.Rows.Add();
        }

        private void Dgv_tranformtion_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {

            Transformtion.Dgv_tranformtion_CellEndEdit_(sender, e);
        }

        private void Dgv_tranformtion_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            Transformtion.Dgv_tranformtion_EditingControlShowing_(sender, e);

        }

        private void Txt_name_storg_Trans_TextChanged(object sender, EventArgs e)
        {

        }

        private void Btn_trans_Click(object sender, EventArgs e)
        {
            Transformtion.Btn_trans_Items_(sender, e);
        }

        private void Button6_Click(object sender, EventArgs e)
        {
            if (dgv_tranformtion_dgv.CurrentRow != null)
            {
                dgv_tranformtion_dgv.Rows.RemoveAt(dgv_tranformtion_dgv.CurrentCell.RowIndex);
                Transformtion.Auto_calc_sum();
            }
        }

        private void DataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void BarButtonItem22_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            new Items_Tools().showAndHideForm(navig_supplire);
            supp.Btn_Add_supplier_ItemClick2(sender, e);

        }

        private void Bt_add_suppl_Click(object sender, EventArgs e)
        {
            supp.Bt_add_suppl_Click1(sender, e);
            supp.ClearData("Supplier", "num_supp");
        }

        private void Btn_New_suppl_Click(object sender, EventArgs e)
        {
            supp.Btn_New_suppl_Click2();

        }

        private void Btn_updete_suppl_Click(object sender, EventArgs e)
        {
            //تعديل بيانات  
            supp.Btn_updete_suppl_Click2(sender, e);
        }

        private void Btn_delet_suppl_Click(object sender, EventArgs e)
        { // حذف بيانات من الجداول 
            supp.Btn_delet_suppl_Click2(sender, e);
        }

        private void Dgv_supplier_SelectionChanged(object sender, EventArgs e)
        {
            supp.Dgv_supplier_SelectionChanged2(sender, e);
        }

        private void Txt_serch_supp_TextChanged(object sender, EventArgs e)
        {
            supp.TextBox2_TextChanged2(sender, e);
        }

        private void Txt_Pon_supp_KeyPress(object sender, KeyPressEventArgs e)
        {
            supp.Txt_Pon_supp_KeyPress2(sender, e);
        }
        /// <summary>
        /// ///////////////////
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// 

        Client.Class_Client.Client clin = new Client.Class_Client.Client();
        private void BarButtonItem23_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            new Items_Tools().showAndHideForm(add_client);
            clin.BarButtonItem9_ItemClick(sender, e);
        }

        private void Button11_Click(object sender, EventArgs e)
        {
            clin.Button8_Click_Clinte(sender, e);
        }

        private void Button14_Click(object sender, EventArgs e)
        {
            clin.Btn_New_Clinte_Click(sender, e);
        }

        private void Button13_Click(object sender, EventArgs e)
        {
            clin.Btn_update_Clinte_Click(sender, e);
        }

        private void Button12_Click(object sender, EventArgs e)
        {
            clin.Btn_delete_Clinte_Click(sender, e);
        }

        private void Dgv_clin_SelectionChanged(object sender, EventArgs e)
        {
            clin.Dgv_Clinte_SelectionChanged(sender, e);
        }

        private void Ch_link_clin_CheckedChanged(object sender, EventArgs e)
        {
            clin.Ch_link_Clinte_CheckedChanged(sender, e);
        }

        private void Com_link_SelectedIndexChanged(object sender, EventArgs e)
        {
            //clin.ComboBox2_SelectedIndexChanged2(sender, e);

        }

        private void Txt_Pon_supp_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            supp.Txt_Pon_supp_KeyPress2(sender, e);
        }

        private void GroupControl15_Paint(object sender, PaintEventArgs e)
        {

        }

        private void BarButtonItem24_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            new Items_Tools().showAndHideForm(settle_Items);
            dgv_settle_dgv.Columns[3].DefaultCellStyle.ForeColor = Color.Red;
            dgv_settle_dgv.Columns[4].DefaultCellStyle.ForeColor = Color.Blue;
            dgv_settle_dgv.Columns[6].DefaultCellStyle.ForeColor = Color.Red;
            dgv_settle_dgv.Columns[7].DefaultCellStyle.ForeColor = Color.Blue;
            dgv_settle_dgv.Columns[8].DefaultCellStyle.ForeColor = Color.Red;
            dgv_settle_dgv.Columns[9].DefaultCellStyle.ForeColor = Color.Blue;
        }

        private void CheckBox1_CheckedChanged(object sender, EventArgs e)
        {
            settles.CheckBox1_CheckedChanged_();// اخفا التاريخ واضهارة
        }

        private void Txt_num_Item_settle_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsDigit(e.KeyChar) || e.KeyChar == 8))
            {
                e.Handled = true;
            }
        }

        private void Txt_num_Item_settle_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                settles.serch_Item_get_name(); // جلب اسم الصنف من الرقم
            }
        }

        private void Timer2_Tick(object sender, EventArgs e)
        {
            lbl_Date_Time_settle.Text = DateTime.Now.ToString();
        }

        private void Button13_Click_1(object sender, EventArgs e)
        {
            settles.Fill_Table_settle();
        }

        private void Button22_Click(object sender, EventArgs e)
        {
            contrt.Add_Contract();
        }

        private void Button21_Click(object sender, EventArgs e)
        {
            contrt.Button13_Click();
        }

        private void Button20_Click(object sender, EventArgs e)
        {
            contrt.Btn_delete_cont_Click();
        }

        private void TextBox9_DoubleClick(object sender, EventArgs e)
        {
            contrt.TextBox3_DoubleClick();
        }

        private void TextBox5_TextChanged(object sender, EventArgs e)
        {
            contrt.Txt_Dise_rate_cont_TextChanged();
        }

        private void RadioButton2_CheckedChanged(object sender, EventArgs e)
        {
            contrt.Rid_clin_CheckedChanged();
        }

        private void DataGridView3_SelectionChanged(object sender, EventArgs e)
        {
            contrt.Dgv_cont_show_SelectionChanged();

        }

        private void Button19_Click(object sender, EventArgs e)
        {
            contrt.Button9_Click();
        }

        private void Button18_Click(object sender, EventArgs e)
        {
            contrt.Button10_Click_1();
        }

        private void Button17_Click(object sender, EventArgs e)
        {
            contrt.Button11_Click();
        }

        private void Btn_content_class_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            new classs_table.Items_Tools().showAndHideForm(nav_Bln_Clin_Show);
            //class_Blan_clin.Show_blnFrm_clin();
            //contrt.Open_Contract();
            class_Blan_clin.pup_Data();

        }

        private void Dgv_settle_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            settles.Dgv_settle_EditingControlShowing_(sender, e);

        }
        int temp = 0;
        private void Dgv_settle_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            //حفظ الكمية السابقة قبل التعديل
            if (dgv_settle_dgv.CurrentRow != null)
            {
                if (dgv_settle_dgv.CurrentCell.ColumnIndex == 7 || dgv_settle_dgv.CurrentCell.ColumnIndex == 9)
                {
                    temp = Convert.ToInt32(dgv_settle_dgv.CurrentCell.Value);
                }
            }
        }

        private void Dgv_settle_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (dgv_settle_dgv.CurrentRow != null)
            {

                if (dgv_settle_dgv.CurrentCell.ColumnIndex == 9)
                {
                    if (Convert.ToDouble(dgv_settle_dgv.CurrentCell.Value) < Convert.ToDouble(dgv_settle_dgv.CurrentRow.Cells[10].Value))
                    {
                        MessageBox.Show("!! سعر البيع اقل من سعر الشرا", "تغير", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1);
                        dgv_settle_dgv.CurrentCell.Value = temp;
                        temp = 0;
                    }
                    else if (Convert.ToDouble(dgv_settle_dgv.CurrentCell.Value) == Convert.ToDouble(dgv_settle_dgv.CurrentRow.Cells[10].Value))
                    {
                        MessageBox.Show("!! سعر البيع يساوي  سعر الشرا", "تغير", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1);
                        dgv_settle_dgv.CurrentCell.Value = temp;
                        temp = 0;
                    }
                }


                if (dgv_settle_dgv.CurrentCell.ColumnIndex == 7 || dgv_settle_dgv.CurrentCell.ColumnIndex == 9)
                {
                    if (Convert.ToString(dgv_settle_dgv.CurrentCell.Value) == "" || Convert.ToString(dgv_settle_dgv.CurrentCell.Value.ToString().Trim()) == string.Empty)
                    {
                        dgv_settle_dgv.CurrentCell.Value = temp;
                        temp = 0;
                    }
                }


            }
        }

        private void Button23_Click(object sender, EventArgs e)
        {
            dgv_settle_dgv.Rows.Add();
        }

        private void Button24_Click(object sender, EventArgs e)
        {
            settles.Button24_Click_(sender, e);
        }

        private void Dgv_supplier_SelectionChanged_1(object sender, EventArgs e)
        {
            supp.Dgv_supplier_SelectionChanged2(sender, e);

        }

        private void BarButtonItem25_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            new Item.forms.Reapos().ShowDialog();
        }

        private void Button12_Click_1(object sender, EventArgs e)
        {
            new Item.forms.Item_serch_settle().Show();
        }
        DataTable dtTest;
        private void BarButtonItem26_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Datagridview_Type_barcode = 2;
            new Items_Tools().showAndHideForm(purchases_bill);

            txt_num_prodect.Text = new Items_Tools().AoutoNumber("Data_Footer", "Foot_code").ToString();
            new prodects.Footer_prodect().fill_Cacher_and_fund();


            // استعادة البيانات
            //DataRecovry.chek_recovry_Data_TextBox("PeodctText", purchases_bill);
            //DataRecovry.check_Data_Recovry("Prodct", dgv_prodect_dgv);
            //dtTest = DataRecovry.Fill_info_TextBox("PeodctText", purchases_bill);
        }
        private void Txt_num_Footer_TextChanged(object sender, EventArgs e)
        {
            DataRecovry.Fill_Data_Textbox(dtTest, purchases_bill);
        }
        private void TabPane2_Click(object sender, EventArgs e)
        {

        }

        private void Txt_num__KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                int num_storg = txt_num_storg_prodect.Text.Trim() == string.Empty ? 0 : Convert.ToInt32(txt_num_storg_prodect.Text.Trim());
                DataRow dr_Storg_prodect = DB_Add_delete_update_.Database.ds.Tables["Storg"].Rows.Find(num_storg);
                if (dr_Storg_prodect != null)
                {
                    txt_name_storg_prodect.Text = dr_Storg_prodect[1].ToString();
                }
                else
                {
                    MessageBox.Show("الرقم المدخل غير صحيح", "😓");
                    txt_name_storg_prodect.Text = "";
                }
            }

        }

        private void Txt_num__KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsDigit(e.KeyChar) || e.KeyChar == 8))
            {
                e.Handled = true;
            }
        }

        public bool Form_prodect = false;
        private void Txt_num_storg_prodect_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            Form_prodect = true;
            new forms.Data_storg().ShowDialog();
        }

        private void Txt_num__KeyDown_1(object sender, KeyEventArgs e)
        {
            Footter_prodects._Txt_num__KeyDown_1(sender, e);
        }

        private void Txt_num_Supplier_prodect_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsDigit(e.KeyChar) || e.KeyChar == 8))
            {
                e.Handled = true;
            }
        }
        public bool show_supper = false;
        private void Txt_num_Supplier_prodect_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            show_supper = true;
            new Item.forms.frm_Supper_prodect().ShowDialog();
        }

        private void Txt_num_Supplier_prodect_TextChanged(object sender, EventArgs e)
        {

        }

        private void Txt_name_Supplier_prodect_TextChanged(object sender, EventArgs e)
        {

        }
        double Temp_cell_begin = 0;
        private void Dgv_prodect_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            try
            {

                if (dgv_prodect_dgv.CurrentRow != null)
                {
                    if (dgv_prodect_dgv.CurrentCell.ColumnIndex == 1)
                    {
                        new classs_table.Items_Tools().SetKeyboardLayout("eng");
                    }


                    if (dgv_prodect_dgv.CurrentCell.ColumnIndex == 8 && dgv_prodect_dgv.CurrentRow.Cells[14].Value.ToString() != "null")
                    {
                        Temp_cell_begin = Convert.ToDouble(dgv_prodect_dgv.CurrentRow.Cells[8].Value);
                    }
                    else if (dgv_prodect_dgv.CurrentCell.ColumnIndex == 11 && dgv_prodect_dgv.CurrentRow.Cells[14].Value.ToString() != "null")
                    {
                        Temp_cell_begin = Convert.ToDouble(dgv_prodect_dgv.CurrentRow.Cells[11].Value);
                    }
                    else if (dgv_prodect_dgv.CurrentCell.ColumnIndex == 4 && dgv_prodect_dgv.CurrentRow.Cells[14].Value.ToString() != "null")
                    {
                        Temp_cell_begin = Convert.ToDouble(dgv_prodect_dgv.CurrentRow.Cells[4].Value);
                    }
                }

            }
            catch
            {
                return;
            }


        }

        private void DataGridView5_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            //DataRecovry.FillRow("Prodct", dgv_prodect_dgv);
            try
            {


                if (dgv_prodect_dgv.CurrentCell.ColumnIndex == 8 && dgv_prodect_dgv.CurrentRow.Cells[14].Value.ToString() != "null")
                {
                    object test = dgv_prodect_dgv.CurrentRow.Cells[8].Value;

                    if (test == null || Convert.ToDouble(test) == 0)
                    {

                        dgv_prodect_dgv.CurrentRow.Cells[8].Value = Temp_cell_begin.ToString("N0");
                    }
                    else if (Convert.ToDouble(test) < Convert.ToDouble(dgv_prodect_dgv.CurrentRow.Cells[11].Value))
                    {
                        MessageBox.Show("سعر البيع اصغر من سعر الشرا !!");
                        dgv_prodect_dgv.CurrentRow.Cells[8].Value = Temp_cell_begin.ToString("N0");

                    }
                }
                else if (dgv_prodect_dgv.CurrentCell.ColumnIndex == 11 && dgv_prodect_dgv.CurrentRow.Cells[14].Value.ToString() != "null")
                {
                    object test = dgv_prodect_dgv.CurrentRow.Cells[11].Value;

                    if (test == null || Convert.ToDouble(test) == 0)
                    {
                        dgv_prodect_dgv.CurrentRow.Cells[11].Value = Temp_cell_begin.ToString("N0");
                    }
                    else if (Convert.ToDouble(test) > Convert.ToDouble(dgv_prodect_dgv.CurrentRow.Cells[8].Value))
                    {
                        MessageBox.Show("سعر الشرا اكبر من سعر البيع !!");
                        //dgv_prodect_dgv.CurrentRow.Cells[14].Value = dgv_prodect_dgv.CurrentRow.Cells[11].Value;
                        dgv_prodect_dgv.CurrentRow.Cells[11].Value = Temp_cell_begin.ToString("N0");
                    }
                    else
                    {
                        dgv_prodect_dgv.CurrentRow.Cells[14].Value = dgv_prodect_dgv.CurrentRow.Cells[11].Value;
                    }

                }
                else if (dgv_prodect_dgv.CurrentCell.ColumnIndex == 4 && dgv_prodect_dgv.CurrentRow.Cells[14].Value.ToString() != "null")
                {
                    object test = dgv_prodect_dgv.CurrentRow.Cells[4].Value;
                    if (test == null || Convert.ToDouble(test) == 0)
                    {
                        dgv_prodect_dgv.CurrentRow.Cells[4].Value = Temp_cell_begin;
                    }
                }
                else if (dgv_prodect_dgv.CurrentCell.ColumnIndex == 6 && dgv_prodect_dgv.CurrentRow.Cells[14].Value.ToString() != "null")
                {
                    object test = dgv_prodect_dgv.CurrentRow.Cells[6].Value;
                    if (test == null || Convert.ToDouble(test) == 0)
                    {
                        dgv_prodect_dgv.CurrentRow.Cells[6].Value = "0";
                    }
                }

                Footter_prodects._DataGridView5_CellEndEdit();
            }
            catch (Exception ex)
            {
                if (ex.Message == "search Item")
                {
                    MessageBox.Show("يرجاء التحقق من رقم الصنف");

                }
            }
        }

        private void Button13_Click_2(object sender, EventArgs e)
        {
            dgv_prodect_dgv.Rows.Add();
            dgv_prodect_dgv.Rows[dgv_prodect_dgv.Rows.Count - 1].Cells[14].Value = "null";
        }

        private void Button23_Click_1(object sender, EventArgs e)
        {



        }

        private void Button23_Click_2(object sender, EventArgs e)
        {

        }

        private void Dgv_prodect_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            Footter_prodects.Dgv_prodect_EditingControlShowing(sender, e);
        }

        private void Txt_Dicount_Rate_All_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                Footter_prodects.Totil_All_Fotter();
            }
        }

        private void Txt_Dicount_Rate_All_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsDigit(e.KeyChar) || e.KeyChar == 8))
            {
                e.Handled = true;
            }
        }

        private void Txt_Dicount_value_All_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                Footter_prodects.Totil_All_Fotter();
            }

        }

        private void Txt_Dicount_value_All_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsDigit(e.KeyChar) || e.KeyChar == 8))
            {
                e.Handled = true;
            }
        }

        private void Button23_Click_3(object sender, EventArgs e)
        {
            new prodects.Footer_prodect().remove();

        }

        private void Dgv_prodect_MouseDown(object sender, MouseEventArgs e)
        {

        }
        public bool prodect_open_Items = false;
        private void Dgv_prodect_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            prodect_open_Items = true;
            new forms.Item_Data().ShowDialog();
        }
        public bool checkData = true;
        private void Button27_Click(object sender, EventArgs e)
        {
            Footter_prodects.Save_data_And_Footer_All();
        }

        private void TextBox11_KeyDown(object sender, KeyEventArgs e)
        {

        }
        public bool show_supper_return = false;
        private void Txt_num_supper_return_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            show_supper_return = true;
            new Item.forms.frm_Supper_prodect().ShowDialog();
        }

        private void BarButtonItem27_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            new Items_Tools().showAndHideForm(nav_return_prodect);
        }

        private void Txt_num_supper_return_KeyDown(object sender, KeyEventArgs e)
        {
            Footter_Return.Txt_num_supper_return_KeyDown_(sender, e);
        }

        private void Txt_serch_num_footer_KeyDown(object sender, KeyEventArgs e)
        {
            Footter_Return.Txt_serch_num_footer_KeyDown_(sender, e);
        }
        private void Dgv_return_prodect_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            Footter_Return.Dgv_return_prodect_CellBeginEdit_(sender, e);
        }


        private void Dgv_return_prodect_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            Footter_Return.Dgv_return_prodect_CellEndEdit_(sender, e);

        }

        private void Dgv_return_prodect_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {

            Footter_Return.Edting_Control_shawing(sender, e);
        }

        private void Button29_Click(object sender, EventArgs e)
        {
            Footter_Return.Sacve_Prodect_return();
        }

        private void Dgv_prodect_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Txt_limet_dealing_TabStopChanged(object sender, EventArgs e)
        {

        }

        private void Txt_amount_paid_TextChanged(object sender, EventArgs e)
        {
            Footter_prodects.Txt_amount_paid_TextChanged_();
        }

        private void RibbonControl1_Click(object sender, EventArgs e)
        {

        }

        private void BarButtonItem28_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //اضافة موضف
            new Items_Tools().showAndHideForm(Emplyes_page);

            new Employlee.Page_Employees.Add_Employees().page_Add_Emp();
            //new Employlee.Page_Employees.Show_Employees().show_info_Emp();
        }

        private void BarButtonItem29_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Item.forms.frm_pay_bill frm = new Item.forms.frm_pay_bill();
            frm.ShowDialog();
        }

        private void BarButtonItem30_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            DGV_JOBS_dgv.DataSource = DB_Add_delete_update_.Database.ds.Tables["tb_Jobs"];
            new Items_Tools().showAndHideForm(jobs);
        }

        private void BarButtonItem31_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            new Items_Tools().showAndHideForm(page_show_All_Empl);

            new Employlee.Page_Employees.Show_Employees().show_DataTable();


        }

        private void Btn_save_job_Click(object sender, EventArgs e)
        {
            job.save_job();
        }

        private void Btn_dite_job_Click(object sender, EventArgs e)
        {
            update_job.Update_to_page_job();
        }

        private void Btn_save_updata_job_Click(object sender, EventArgs e)
        {
            update_job.save_updata_job();
        }

        private void Btn_add_job_Click(object sender, EventArgs e)
        {
            int max_numjob = new Items_Tools().AoutoNumber("tb_Jobs", "id_Job");
            txt_num_Job.Text = max_numjob.ToString();
            txt_name_job_AR.Clear();
            txt_name_job_EN.Clear();
            txt_name_job_AR.Focus();
            btn_save_job_btn.Enabled = true;
        }


        private void Chbox_SAT_CheckedChanged(object sender, EventArgs e)
        {
            if (chbox_SAT.Checked == true)
            {

                timeEdit__sat_attendance.Enabled = true;//وقت الحضور للسبت
                timeEdit_Sat__Leave.Enabled = true;//وقت الانصراف للسبت
                //MessageBox.Show(""+timeEdit__sat_attendance.Text);
            }
            else
            {
                timeEdit__sat_attendance.Enabled = false;//وقت الحضور للسبت
                timeEdit_Sat__Leave.Enabled = false;//وقت الانصراف للسبت

            }
        }

        private void Chbox_SAN_CheckedChanged(object sender, EventArgs e)
        {
            if (chbox_SAN.Checked == true)
            {
                timeEdit_SAN_attendance.Enabled = true;//وقت الحضور للاحد
                timeEdit_San_Leave.Enabled = true;//وقت الانصراف للاحد
            }
            else
            {
                timeEdit_SAN_attendance.Enabled = false;//وقت الحضور للاحد
                timeEdit_San_Leave.Enabled = false;//وقت الانصراف للاحد


            }
        }

        private void Chbox_MON_CheckedChanged(object sender, EventArgs e)
        {
            if (chbox_MON.Checked == true)
            {
                timeEdit_MON_attendance.Enabled = true;//وقت الحضور الاثنين
                timeEdit_MON_Leave.Enabled = true;//وقت الانصراف الاثنين
            }
            else
            {
                timeEdit_MON_attendance.Enabled = false;//وقت الحضور الاثنين
                timeEdit_MON_Leave.Enabled = false;//وقت الانصراف الاثنين

            }
        }

        private void Chbox_TUE_CheckedChanged(object sender, EventArgs e)
        {

            if (chbox_TUE.Checked == true)
            {
                timeEdit_TUE_attendance.Enabled = true;//وقت الحضور الثلاثاء
                timeEdit_TUE_Leave.Enabled = true;//وقت الانصراف الثلاثاء

            }
            else
            {
                timeEdit_TUE_attendance.Enabled = false;//وقت الحضور الثلاثاء
                timeEdit_TUE_Leave.Enabled = false;//وقت الانصراف الثلاثاء


            }
        }

        private void Chbox_WED_CheckedChanged(object sender, EventArgs e)
        {

            if (chbox_WED.Checked == true)
            {
                timeEdit_WED_attendance.Enabled = true;//وقت الحضور الاربعاء
                timeEdit_WED_Leave.Enabled = true;//وقت الانصراف الاربعاء
            }
            else
            {
                timeEdit_WED_attendance.Enabled = false;//وقت الحضور الاربعاء
                timeEdit_WED_Leave.Enabled = false;//وقت الانصراف الاربعاء

            }
        }

        private void Chbox_THUR_CheckedChanged(object sender, EventArgs e)
        {
            if (chbox_THUR.Checked == true)
            {
                timeEdit_THUR_attendance.Enabled = true;//وقت الحضور الخميس
                timeEdit_THUR_Leave.Enabled = true;//وقت الانصراف الخميس
            }
            else
            {
                timeEdit_THUR_attendance.Enabled = false;//وقت الحضور الخميس
                timeEdit_THUR_Leave.Enabled = false;//وقت الانصراف الخميس

            }
        }

        private void Chbox_FRI_CheckedChanged(object sender, EventArgs e)
        {
            if (chbox_FRI.Checked == true)
            {
                timeEdit_FRI_attendance.Enabled = true;//وقت الحضور الجمعة
                timeEdit_FRI_Leave.Enabled = true;//وقت الانصراف الجمعة
            }
            else
            {
                timeEdit_FRI_attendance.Enabled = false;//وقت الحضور الجمعة
                timeEdit_FRI_Leave.Enabled = false;//وقت الانصراف الجمعة

            }
        }

        private void CheckBox5_CheckedChanged(object sender, EventArgs e)
        {
            //تعديل3
            ////شرط اذا كان تفعل شرط الراتب بالساعةيظهر الخانات
            //if (chbox_hourly_salary.Checked == true)
            //{
            //    chbox_monthe_salary.Checked = false;
            //    txt_hour_value.Enabled = true;
            //    txt_Extra_hour_value.Enabled = true;
            //    txt_value_hour_absence.Enabled = true;
            //}
            ////شرط اذا كان لم يتفعل شرط الراتب بالساعةيخفي الخانات
            /////تعديل3
            if (chbox_hourly_salary.Checked == false)
            {
                chbox_monthe_salary.Checked = true;
                txt_hour_value.Enabled = false;
                txt_Extra_hour_value.Enabled = false;
                txt_value_hour_absence.Enabled = false;
            }
        }

        private void CheckBox6_CheckedChanged(object sender, EventArgs e)
        {
            //تعديل3
            //شرط اذا كان تفعل شرط الراتب بالشهر يظهر الخانات


        }

        private void Chbox_monthe_salary_CheckedChanged(object sender, EventArgs e)
        {
            //تعديل3
            if (chbox_monthe_salary.Checked == true)
            {
                chbox_hourly_salary.Checked = false;
                txt_salary_value.Enabled = true;
                txt_Extra_day_value.Enabled = true;
                txt_day_value_absence.Enabled = true;

                txt_hour_value.Enabled = false;
                txt_Extra_hour_value.Enabled = false;
                txt_value_hour_absence.Enabled = false;
            }
            //    //شرط اذا كان لم يتفعل شرط الراتب بالشهر يخفي الخانات
            //تعديل3
            if (chbox_monthe_salary.Checked == false)
            {
                //chbox_hourly_salary.Checked = true;
                txt_salary_value.Enabled = false;
                txt_Extra_day_value.Enabled = false;
                txt_day_value_absence.Enabled = false;
               
            }
        }

        public string time__TUE__Leave;//وقت الانصراف الثلاثاء

        public string time_WED_attendance;//وقت الحضور الاربعاء
        public string time__WED__Leave;//وقت الانصراف الاربعاء

        public string time_THUR_attendance;//وقت الحضور الخميس
        public string time__THUR__Leave;//وقت الانصراف الخميس

        public string time_FRI_attendance;//وقت الحضور الجمعة
        public string time__FRI__Leave;//وقت الانصراف الجمعة

        public string hour_value;//قيمة الساعة
        public string Monthly_hourly_value;//قيمة الساعة الشهرية
        public string Extra_hour_value; //قيمة الساعةالاضافية
        public string salary_value; //قيمة الراتب
        public string Extra_day_value;//قيمة اليوم الاضافي
        public string day_value_absence;//قيمة اليوم الغياب

        public double retail_commission;//نسبة عمولة بيع التجزئة
        public double Wholesale_currency_rate;//نسبة عمولة بيع جملة


        private void Chbox_on_Emp_use_prgram_slahiat_CheckedChanged(object sender, EventArgs e)
        {
            if (chbox_on_Emp_use_prgram_slahiat.Checked == true)
            {

                Gbox_pageEmp_sys_login.Enabled = true;
                txt_Username_Emp.Enabled = true;
                txt_password_Emp.Enabled = true;
                txt_password2_Emp.Enabled = true;
            }
            //شرط اذا كان  لم يتفعل شرط موظف يستخدم برنامج  يخفي الخانات

            else if (chbox_on_Emp_use_prgram_slahiat.Checked == false)
            {

                Gbox_pageEmp_sys_login.Enabled = false;
                txt_Username_Emp.Enabled = false;
                txt_password_Emp.Enabled = false;
                txt_password2_Emp.Enabled = false;
            }
        }




        private void Btn_save_Emp_Click(object sender, EventArgs e)
        {
            new Employlee.Page_Employees.Add_Employees().Save_Emps();
        }

        private void L_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Dgv_view_EMPS_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Btn_page_Add_Emp_Click(object sender, EventArgs e)
        {

        }

        private void Btn_page_update_Emp_Click(object sender, EventArgs e)
        {
            new Employlee.Page_Employees.Update_Employees().show_update_Employ();

        }

        private void Combox_version_personal_card_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void Btn_save_adite_Emp_Click(object sender, EventArgs e)
        {
            new Employlee.Page_Employees.Update_Employees().save_update();
        }

        private void Btn_Exit_form_Add_Emp_Click(object sender, EventArgs e)
        {
            new Items_Tools().showAndHideForm(page_show_All_Empl);
            new Employlee.Page_Employees.Show_Employees().clerevirablesEmp();

        }

        private void GroupControl20_Paint(object sender, PaintEventArgs e)
        {

        }

        private void TextBox16_KeyDown(object sender, KeyEventArgs e)
        {
        }

        private void BarButtonItem32_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            new Items_Tools().showAndHideForm(pawers_Emp);
        }

        private void Panel37_Paint(object sender, PaintEventArgs e)
        {

        }

        private void TextBox10_TextChanged(object sender, EventArgs e)
        {

        }

        private void BarButtonItem33_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            new Items_Tools().showAndHideForm(Report_Transform_on_storg);

        }

        private void Txt_num_storg_one_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                new storg.Report.RP_transform_on_storg().fill_Com_ofline(txt_num_storg_one, txt_name_storg_one);
            }
        }

        private void Txt_num_storg_tow_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void Txt_num_storg_tow_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                new storg.Report.RP_transform_on_storg().fill_Com_ofline(txt_num_storg_tow, txt_name_storg_tow);
            }
        }

        private void CheckBox21_CheckedChanged(object sender, EventArgs e)
        {
            if (ch_Date_RP.Checked)
            {

                pnp_Date_RP.Enabled = true;
            }
            else
            {
                pnp_Date_RP.Enabled = false;
            }
        }

        private void Button30_Click(object sender, EventArgs e)
        {
            new storg.Report.RP_transform_on_storg().Serch_Data_Trans();

        }

        private void Button31_Click(object sender, EventArgs e)
        {
            new storg.Report.RP_transform_on_storg().view_Report();
        }

        private void BarButtonItem34_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            new classs_table.Items_Tools().showAndHideForm(Report_Item_Storg);
            new storg.Report.RP_storg_Item().Fill_Com_Filter_RP();
        }

        private void Txt_num_Item_RP_Storg_All_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (txt_num_Item_RP_Storg_All.Text.Trim() != string.Empty)
                {


                    DataRow dr_Item = DB_Add_delete_update_.Database.ds.Tables["Item"].Rows.Find(txt_num_Item_RP_Storg_All.Text);
                    if (dr_Item != null)
                    {
                        txt_name_Item_RP_Storg_All.Text = dr_Item[1].ToString();

                    }
                    else
                    {
                        MessageBox.Show("يرجاء التحقق من رقم الصنف", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        txt_num_Item_RP_Storg_All.Focus();
                        txt_num_Item_RP_Storg_All.SelectAll();
                        txt_name_Item_RP_Storg_All.Text = "";
                    }
                }
                else
                {
                    MessageBox.Show("يرجاء ملا رقم الصنف", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txt_num_Item_RP_Storg_All.Focus();
                    txt_num_Item_RP_Storg_All.SelectAll();
                    txt_name_Item_RP_Storg_All.Text = "";
                }
            }
        }

        private void Button35_Click(object sender, EventArgs e)
        {
            try
            {
                new storg.Report.RP_storg_Item().Serch_RP_Item_Storg();
            }
            catch(Exception ex)
            {
                if (ex.Message == "No Data")
                {
                    MessageBox.Show("لايوجد اصناف مدخلة من الوحدة المختارة");
                }
            }
            
        }

        private void Button34_Click(object sender, EventArgs e)
        {

            new storg.Report.RP_storg_Item().show_Report_Item_Storg();
        }

        private void BarButtonItem35_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            new classs_table.Items_Tools().showAndHideForm(Report_Item_Expirt);
            new storg.Report.RP_Item_Expirt_Item().Fill_All_Data_RP_Expoirt();
        }

        private void Button37_Click(object sender, EventArgs e)
        {
            new storg.Report.RP_Item_Expirt_Item().show_Report_Item_Storg();
        }

        private void Button38_Click(object sender, EventArgs e)
        {
            new storg.Report.RP_Item_Expirt_Item().Serch_RP_Item_Storg_Expirt();
        }

        private void BarButtonItem36_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            new classs_table.Items_Tools().showAndHideForm(Report_update_qty);
            new storg.Report.RP_update_qty().Fill_All_Data_RP_update_qty();
        }


        private void Button41_Click(object sender, EventArgs e)
        {

            new storg.Report.RP_update_qty().Serch_update_qty();
        }

        private void Button40_Click(object sender, EventArgs e)
        {
            new storg.Report.RP_update_qty().show_crv_update_qty();
        }

        private void BarButtonItem37_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            new classs_table.Items_Tools().showAndHideForm(Report_update_Date_Expirt);
            new storg.Report.RP_update_Expit().Fill_All_Data_RP_update_Expit();
        }

        private void Button43_Click(object sender, EventArgs e)
        {
            new storg.Report.RP_update_Expit().show_crv_update_Expirt();

        }

        private void Button44_Click(object sender, EventArgs e)
        {
            new storg.Report.RP_update_Expit().Serch_update_Expirt();

        }

        private void BarButtonItem38_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            new storg.Report.RP_update_sals().Fill_All_Data_RP_update_sals();
            new classs_table.Items_Tools().showAndHideForm(Report_update_salse);
        }

        private void Button47_Click(object sender, EventArgs e)
        {
            new storg.Report.RP_update_sals().Serch_update_sals();
        }

        private void Button46_Click(object sender, EventArgs e)
        {
            new storg.Report.RP_update_sals().show_crv_update_sals();

        }

        private void BarButtonItem39_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            new prodects.Report.RP_footer_prodects().Fill_All_Data_RP_update_qty();
            new classs_table.Items_Tools().showAndHideForm(Report_Footer_prodect_All);
        }

        private void Ch_suppr_footer_All_RP_CheckedChanged(object sender, EventArgs e)
        {

            txt_suppr_num_footer_All_RP.Enabled = ch_suppr_footer_All_RP.Checked;
            txt_suppr_name_footer_All_RP.Enabled = ch_suppr_footer_All_RP.Checked;



        }

        private void Ch_show_dtp_footer_All_RP_CheckedChanged(object sender, EventArgs e)
        {
            dtp_footer_All_RP_one.Enabled = ch_show_dtp_footer_All_RP.Checked;
            dtp_footer_All_RP_tow.Enabled = ch_show_dtp_footer_All_RP.Checked;
        }

        private void Button50_Click(object sender, EventArgs e)
        {
            new prodects.Report.RP_footer_prodects().serch_Data_Footer();

        }

        private void Txt_suppr_num_footer_All_RP_KeyDown(object sender, KeyEventArgs e)
        {
            new prodects.Report.RP_footer_prodects().Txt_suppr_num_footer_All_RP_KeyDown_(sender, e);
        }

        private void Button49_Click(object sender, EventArgs e)
        {
            // اخراج بيانات فاتورة المشتريات
            new prodects.Report.RP_footer_prodects().Show_Report();

        }

        private void BarButtonItem40_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            new classs_table.Items_Tools().showAndHideForm(Report_Footer_prodect_num);
        }

        private void Txt_footter_supper_num_RP_num_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (txt_footter_supper_num_RP_num.Text.Trim() != string.Empty)
                {
                    DataRow dr_supper = DB_Add_delete_update_.Database.ds.Tables["Supplier"].Rows.Find(txt_footter_supper_num_RP_num.Text.Trim());
                    if (dr_supper != null)
                    {
                        txt_footter_supper_name_RP_num.Text = dr_supper[1].ToString();

                    }
                }
            }
        }

        private void Txt_footter_number_RP_num_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (txt_footter_number_RP_num.Text.Trim() != string.Empty)
                {
                    if (txt_footter_supper_name_RP_num.Text.Trim() != string.Empty)
                    {
                        new prodects.Report.RP_footer_prodect_number().serch_footer_prodect_number(1);
                    }
                    else
                    {
                        MessageBox.Show("يرجاء تعبئة المورد ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }
            }
        }

        private void Txt_footter_id_RP_num_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (txt_footter_id_RP_num.Text.Trim() != string.Empty)
                {
                    new prodects.Report.RP_footer_prodect_number().serch_footer_prodect_number(0);
                }
                else
                {
                    MessageBox.Show("يرجاء تعبئة متسلسل الفاتورة ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }

        }

        private void Button52_Click(object sender, EventArgs e)
        {

            new prodects.Report.RP_footer_prodect_number().Show_Report();


        }

        private void BarButtonItem7_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

        }

        private void BarButtonItem41_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            new classs_table.Items_Tools().showAndHideForm(Report_total_return_supper);
        }

        private void Txt_num_supper_RP_total_return_KeyDown(object sender, KeyEventArgs e)
        {

            new classs_table.Items_Tools().Fill_supper_set_id_get_name(txt_num_supper_RP_total_return, txt_name_supper_RP_total_return, e);
        }

        private void Button56_Click(object sender, EventArgs e)
        {
            new prodects.Report.RP_footer_total_return().save_Data_Return();
            new prodects.Report.RP_footer_total_return().show_CRV_total_return();

        }

        private void Button55_Click(object sender, EventArgs e)
        {
            CRV_total_footer_return.PrintReport();
        }

        private void Button57_Click(object sender, EventArgs e)
        {
            CRV_total_footer_return.AllowedExportFormats = 1;
            CRV_total_footer_return.ExportReport();
        }

        private void TextBox11_KeyDown_1(object sender, KeyEventArgs e)
        {
            new classs_table.Items_Tools().Fill_supper_set_id_get_name(txt_num_supper_bond_one, txt_name_supper_bond_one, e);
        }

        private void CheckBox22_CheckedChanged(object sender, EventArgs e)
        {
            if (ch_bond_supper.Checked)
            {
                gb_Data_RP_All_bond.Enabled = false;
                gb_bond_sup_bond_num.Enabled = true;

            }
            else
            {
                gb_Data_RP_All_bond.Enabled = true;
                gb_bond_sup_bond_num.Enabled = false;
            }
        }

        private void Txt_num_supper_bond_tow_KeyDown(object sender, KeyEventArgs e)
        {
            new classs_table.Items_Tools().Fill_supper_set_id_get_name(txt_num_supper_bond_tow, txt_name_supper_bond_tow, e);

        }

        private void CheckBox27_CheckedChanged(object sender, EventArgs e)
        {
            txt_num_supper_bond_tow.Enabled = ch_En_supper_bond_Report.Checked;
            txt_name_supper_bond_tow.Enabled = ch_En_supper_bond_Report.Checked;
        }

        private void Ch_En_Emp_bond_Report_CheckedChanged(object sender, EventArgs e)
        {
            txt_name_Emp_bond.Enabled = ch_En_Emp_bond_Report.Checked;
            txt_num_Emp_bond.Enabled = ch_En_Emp_bond_Report.Checked;
        }

        private void Ch_Date_bond_serch_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void Button61_Click(object sender, EventArgs e)
        {
            new prodects.Report.RP_bond_supper().serch_bond_supper();
        }

        private void Txt_num_Emp_bond_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (txt_num_Emp_bond.Text.Trim() != null)
                {
                    DataRow dr_Emp = DB_Add_delete_update_.Database.ds.Tables["TB_Employees"].Rows.Find(txt_num_Emp_bond.Text.Trim());
                    if (dr_Emp != null)
                    {
                        txt_name_Emp_bond.Text = dr_Emp[1].ToString();
                    }
                    else
                    {
                        MessageBox.Show("يرجاء التحقق من رقم الموضف", "ERRor", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        txt_name_Emp_bond.Text = "";

                    }
                }
            }
        }

        private void BarButtonItem42_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            new classs_table.Items_Tools().showAndHideForm(Report_dons_supper);
        }

        private void Dgv_bond_RP_SelectionChanged(object sender, EventArgs e)
        {
            new prodects.Report.RP_bond_supper().Select_ching_dgv();

        }

        private void Button63_Click(object sender, EventArgs e)
        {
            new prodects.Report.RP_bond_supper().show_Report();
        }

        private void BarButtonItem45_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            new Item.forms.mony().ShowDialog();
        }

        private void BarButtonItem43_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            // حدث اضهار شاشة الصندوق
            new classs_table.Items_Tools().showAndHideForm(fund_Account);
            txt_num_fund.Text = new classs_table.Items_Tools().AoutoNumber("account_fund", "fund_num").ToString();
            // تعبئة الجدول بلبيانات ان وجدت
            dgv_fund_Account_dgv.DataSource = DB_Add_delete_update_.Database.ds.Tables["account_fund"];
            // اضاف اسماء للاعمدة
            dgv_fund_Account_dgv.Columns[0].HeaderText = "الكود";
            dgv_fund_Account_dgv.Columns[1].HeaderText = "الاسم (AR)";
            dgv_fund_Account_dgv.Columns[2].HeaderText = "الاسم (EN)";
            dgv_fund_Account_dgv.Columns[3].HeaderText = "موقف";

        }

        private void Button66_Click(object sender, EventArgs e)
        {
            new Item.forms.choos_currensic().ShowDialog();
        }

        private void Button67_Click(object sender, EventArgs e)
        {
            if (dgv_fund_currensic_dgv.CurrentRow != null)
            {
                dgv_fund_currensic_dgv.Rows.RemoveAt(dgv_fund_currensic_dgv.CurrentRow.Index);
            }
        }

        private void Button65_Click(object sender, EventArgs e)
        {
            new Accounts.fund_Acunt().Add_fund();
        }

        private void Button60_Click(object sender, EventArgs e)
        {
            new Accounts.fund_Acunt().new_Data();

        }

        private void Dgv_fund_Account_SelectionChanged(object sender, EventArgs e)
        {
            new Accounts.fund_Acunt().Dgv_fund_Account_SelectionChanged_();
        }

        private void Button64_Click(object sender, EventArgs e)
        {
            new Accounts.fund_Acunt().update_Account_fund();
        }

        private void BarButtonItem44_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            new casher().ShowDialog();
        }

        private void Com_type_prodect_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Convert.ToInt32(com_type_prodect.SelectedValue) == 2)
            {
                pnl_type_sdad.Visible = true;
            }
            else
            {
                pnl_type_sdad.Visible = false;

            }
        }

        private void BarButtonItem46_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            new Accounts.Account_Disco_add.frm_Account_supper_disco().ShowDialog();

        }

        private void BarButtonItem47_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Datagridview_Type_barcode = 0;
            using_contracr.Text = "استخداد \n\r التعاقد";
            new Sales.Sales_open_Add().open_Sales();
        }

        private void TextEdit4_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void CheckBox21_CheckedChanged_1(object sender, EventArgs e)
        {
            com_casher_emply.Enabled = checkBox21.Checked;
        }

        private void TextEdit4_DoubleClick(object sender, EventArgs e)
        {
            var vr = Application.OpenForms["Main"] as Main;


        }

        private void TextEdit4_KeyDown(object sender, KeyEventArgs e)
        {
            new Sales.Sales_open_Add().Add_Cline(sender, e);
        }

        private void Button69_Click(object sender, EventArgs e)
        {
            dgv_sals_dgv.Rows.Add();
        }

        private void Dgv_sals_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            new Sales.Sales_open_Add().Dgv_sals_EditingControlShowing_(sender, e);
        }

        private void Dgv_sals_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                new Sales.Sales_open_Add().Dgv_sals_CellEndEdit_();
        }
            catch(Exception ms)
            {
                if (ms.Message == "Error barco")
                {
                    MessageBox.Show("يرجاء التحقق من رقم الصنف");
                }
            }

        }

        private void Button70_Click(object sender, EventArgs e)
        {
            new Sales.Sales_open_Add().Remove_Rows();
        }

        private void Txt_Dicount_Rate_All_sals_KeyUp(object sender, KeyEventArgs e)
        {
            new Sales.Sales_open_Add().Txt_Dicount_Rate_All_sals_KeyUp_(sender, e);
        }

        private void Txt_Dicount_value_All_sals_KeyUp(object sender, KeyEventArgs e)
        {
            new Sales.Sales_open_Add().Txt_Dicount_Value_All_sals_Keyup_(sender, e);

        }

        private void Dgv_sals_DoubleClick(object sender, EventArgs e)
        {
            new Sales.Item_serch_storg().ShowDialog();
        }

        private void Button72_Click(object sender, EventArgs e)
        {
            if (dgv_sals_dgv.CurrentRow != null)
            {
                if (dgv_sals_dgv.CurrentRow.Cells[3].Value != null)
                {

                    new Sales.info_Item_sals().ShowDialog();
                }
            }
        }

        private void BarButtonItem48_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Datagridview_Type_barcode = 3;
            // نقل بيانات المخزن من فورم المبيعات الا فورم الفواتير المعلقة

            new Sales.hanging_Add_Delete_update_serch().open_hanging();
            button75_btn.PerformClick();
        }
        private void Rb_yup_sals_CheckedChanged(object sender, EventArgs e)
        {

            txt_deictor_cline_sals.Enabled = rb_yup_sals.Checked;
            txt_num_cline_sals.Enabled = rb_yup_sals.Checked;
        }

        private void Btn_footer_hanging_Click(object sender, EventArgs e)
        {
            // تعليق فاتورة
            if (dgv_sals_dgv.CurrentRow != null)
            {
                for (int i = 0; i < dgv_sals_dgv.RowCount; i++)
                {
                    if (dgv_sals_dgv.Rows[i].Cells[4].Value == null)
                    {
                        MessageBox.Show("يرجاء حذف الصف الفارغ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }

                new Sales.frm_paid_rest().ShowDialog();

            }
            else
            {
                MessageBox.Show("يرجاء ادخال اصناف الفاتورة");
                return;
            }

        }

        private void Txt_num_storg_hanging_MouseDown(object sender, MouseEventArgs e)
        {

        }

        private void Txt_num_storg_hanging_KeyDown(object sender, KeyEventArgs e)
        {
            new Sales.hanging_Add_Delete_update_serch().serch_storg(sender, e);
        }

        private void Button75_Click(object sender, EventArgs e)
        {
            new Sales.hanging_Add_Delete_update_serch().serch_hanging();
        }

        private void Dgv_hanging_Data_footer_SelectionChanged(object sender, EventArgs e)
        {
            new Sales.hanging_Add_Delete_update_serch().Dgv_hanging_Data_footer_SelectionChanged_();
        }

        private void Dgv_hanging_Item_sals_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            new Sales.hanging_Add_Delete_update_serch().Dgv_hanging_Item_sals_EditingControlShowing_(sender, e);
        }

        private void Dgv_hanging_Item_sals_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
           
            try
            {
                new Sales.hanging_Add_Delete_update_serch().Dgv_hanging_Item_sals_CellEndEdit();
            }
            catch (Exception ms)
            {
                if (ms.Message == "Error barco")
                {
                    MessageBox.Show("يرجاء التحقق من رقم الصنف");
                }
            }
        }

        private void Button76_Click(object sender, EventArgs e)
        {
            dgv_hanging_Item_sals_dgv.Rows.Add();
        }

        private void Button74_Click(object sender, EventArgs e)
        {
            new Sales.hanging_Add_Delete_update_serch().remove_row_hanging();
        }

        private void Dgv_hanging_Item_sals_DoubleClick(object sender, EventArgs e)
        {
            new Sales.hanging.Item_serch_storg_hanging().ShowDialog();
        }

        private void Rb_hanging_sals_CheckedChanged(object sender, EventArgs e)
        {
            btn_footer_hanging_btn.Enabled = rb_hanging_sals.Checked;
        }

        private void Button65_Click_1(object sender, EventArgs e)
        {

            if (!new Sales.Sales_open_Add().check_Blance())
            {
                if (rb_cash_sals.Checked)
                {
                    new Sales.Footer_sals.frm_Save_footer_sals().ShowDialog();
                }
                else if (rb_yup_sals.Checked)
                {

                    new Sales.Footer_sals.frm_save_sals_Cline().ShowDialog();
                }
                else
                {
                    MessageBox.Show("يرجاء تعديل نوع البيع", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            else
            {
                MessageBox.Show("الكمية المباعة اكبر من الرصيد المخزن ");
            }
        }

        private void Button78_Click(object sender, EventArgs e)
        {
            new Sales.hanging.frm_save_hanging().ShowDialog();
        }

        private void Btn_Show_DiscoFrm_Click(object sender, EventArgs e)
        {
            new Client.Contracts.Discount_cont_frm().ShowDialog();
        }

        private void Button67_Click_1(object sender, EventArgs e)
        {
            new Client.Contracts.Add_cont().ShowDialog();
        }

        private void DataGridView3_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void BarButtonItem50_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            new Sales.Sals_return.search_Data_sals_return().open_frm_sals_return();
        }

        private void Rb_yup_sals_return_CheckedChanged(object sender, EventArgs e)
        {
            gb_Cline_sals_return.Enabled = rb_yup_sals_return.Checked;
            dgv_data_footer_sals_return_dgv.Columns[9].Visible = rb_yup_sals_return.Checked;
            dgv_data_footer_sals_return_dgv.Columns[10].Visible = rb_yup_sals_return.Checked;
        }

        private void Txt_num_or_phone_cline_sals_retrn_KeyDown(object sender, KeyEventArgs e)
        {
            new Sales.Sals_return.search_Data_sals_return().Add_Cline_sals_return(sender, e);
        }

        private void Button83_Click(object sender, EventArgs e)
        {
            new Sales.Sals_return.search_Data_sals_return().serch_Data_Sals_return();

        }

        private void Dgv_data_footer_sals_return_SelectionChanged(object sender, EventArgs e)
        {
            new Sales.Sals_return.search_Data_sals_return().dgv_data_sals_return_();
        }

        private void Dgv_Item_footer_sals_return_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            new Sales.Sals_return.search_Data_sals_return().dgv_Item_footer_sals_return_EditingControlShowing_(sender, e);
        }

        private void Dgv_Item_footer_sals_return_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            new Sales.Sals_return.search_Data_sals_return().dgv_Item_footer_sals_return_CellEndEdit_(sender, e);
        }

        private void Button79_Click(object sender, EventArgs e)
        {
            if (Convert.ToDouble(txt_after_sals_return.Text) > 0)
            {
                if (rb_cash_sals_return.Checked)
                {
                    new Sales.Sals_return.frm_save_data_return().ShowDialog();
                }
                else
                {
                    //rb_yup_sals_return

                    //if (txt_account_Cline_sals_return.Text != string.Empty)
                    //{
                    new Sales.Sals_return.frm_save_Acount_Cline_return().ShowDialog();
                    //  }
                }

            }



        }

        private void Rb_cash_sals_return_CheckedChanged(object sender, EventArgs e)
        {
            new Sales.Sals_return.Save_and_update_unit().Clear_Data_sals_return();
        }

        private void BarButtonItem51_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            new classs_table.Items_Tools().showAndHideForm(Report_sals_return);
        }

        private void Button80_Click(object sender, EventArgs e)
        {
            new Sales.Report.RP_sals_Sas_hang_retu_All().RP_Serch_And_View_Data_sals();
        }

        private void Txt_num_storg_RP_sals_All_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (txt_num_storg_RP_sals_All.Text.Trim() != string.Empty)
                {
                    DataRow dr_storg = DB_Add_delete_update_.Database.ds.Tables["Storg"].Rows.Find(txt_num_storg_RP_sals_All.Text);
                    if (dr_storg != null)
                    {
                        txt_name_storg_RP_sals_All.Text = dr_storg[1].ToString();
                    }
                    else
                    {
                        MessageBox.Show("يرجاء التحقق من رقم المخزن");
                        txt_name_storg_RP_sals_All.Text = "";

                    }
                }
                else
                {
                    txt_name_storg_RP_sals_All.Text = "";

                }
            }

        }

        private void Txt_num_CLine_RP_sals_All_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (txt_num_CLine_RP_sals_All.Text.Trim() != string.Empty)
                {
                    DataRow dr_storg = DB_Add_delete_update_.Database.ds.Tables["Clien"].Rows.Find(txt_num_CLine_RP_sals_All.Text);
                    if (dr_storg != null)
                    {
                        txt_name_CLine_RP_sals_All.Text = dr_storg[1].ToString();
                    }
                    else
                    {
                        MessageBox.Show("يرجاء التحقق من رقم المخزن");
                        txt_name_CLine_RP_sals_All.Text = "";

                    }
                }
                else
                {
                    txt_name_CLine_RP_sals_All.Text = "";

                }
            }

        }
        private void Dgv_data_footer_RP_sals_All_SelectionChanged(object sender, EventArgs e)
        {

            new Sales.Report.RP_sals_Sas_hang_retu_All().Dgv_data_footer_RP_sals_All_SelectionChanged_();
        }

        private void Button81_Click(object sender, EventArgs e)
        {
            new Sales.Report.RP_sals_Sas_hang_retu_All().Fill_RP();
        }

        private void Button82_Click(object sender, EventArgs e)
        {
            new Sales.Report.RP_sals_Sas_hang_retu_All().Print_Footer_RP_All();
        }

        private void Button85_Click(object sender, EventArgs e)
        {

        }

        private void BarButtonItem52_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            new classs_table.Items_Tools().showAndHideForm(Report_sales_Item_All);

            new Sales.Report.RP_sals_Item_date().Get_Storg_RP_Sales_Item_All();
        }

        private void Button84_Click(object sender, EventArgs e)
        {
            new Sales.Report.RP_sals_Item_date().Search_Item_Sales_All();
        }
        private void TextEdit7_KeyDown(object sender, KeyEventArgs e)
        {
            var vr = Application.OpenForms["Main"] as Main;
            new classs_table.Event_Tool().Get_Name_to_ID_Item_DownUp(e, vr.txt_Item_RP_Sales_Item, vr.txt_Name_Item_RP_Sales_Item, "يرجاء التحقق من المدخلات");
        }

        private void Txt_id_Compny_RP_Sales_Item_KeyDown(object sender, KeyEventArgs e)
        {
            var vr = Application.OpenForms["Main"] as Main;
            new classs_table.Event_Tool().Get_Name_to_ID_Compny_DownUp(e, vr.txt_id_Compny_RP_Sales_Item, vr.txt_Name_Compny_RP_Sales_Item, "يرجاء التحقق من المدخلات");
        }

        private void Button85_Click_1(object sender, EventArgs e)
        {
            new Sales.Report.RP_sals_Item_date().View_Report_Sales_Itam_All();
        }

        private void BarButtonItem53_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            new classs_table.Items_Tools().showAndHideForm(Report_Sales_Footer_Return);
            new Sales.Report.RP_Sales_Footer_Return_Date().Get_Storg_RP_Sales_Item_All();
        }

        private void Button86_Click(object sender, EventArgs e)
        {
            new Sales.Report.RP_Sales_Footer_Return_Date().Search_Data_Sales_Data_And_Item_Return();
        }

        private void Dgv_Data_Return_Date_SelectionChanged(object sender, EventArgs e)
        {
            new Sales.Report.RP_Sales_Footer_Return_Date().DataGradview_SelectChang();
        }

        private void Button87_Click(object sender, EventArgs e)
        {
            new Sales.Report.RP_Sales_Footer_Return_Date().ViewReport_Item_Return();
        }

        private void Txt_Report_Sales_Cline_num_KeyDown(object sender, KeyEventArgs e)
        {
            var vr = Application.OpenForms["Main"] as Main;
            new classs_table.Event_Tool().Get_Name_to_ID_Cline_DownUp(e, vr.txt_Report_Sales_Cline_num, vr.txt_Report_Sales_Cline_name, "يرجاء التحقق من رقم العميل");

        }

        private void BarButtonItem54_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            new classs_table.Items_Tools().showAndHideForm(Report_Sales_Footer_Employ);
            new Sales.Report.RP_Sales_Ditiles_Emp().Get_Storg_RP_Sales_Emp_All();
            new Sales.Report.RP_Sales_Ditiles_Emp().Get_All_Employ();
        }

        private void Button88_Click(object sender, EventArgs e)
        {
            new Sales.Report.RP_Sales_Ditiles_Emp().Search_Ditiles_Sales_Emp();
        }
        private void Button89_Click(object sender, EventArgs e)
        {
            new Sales.Report.RP_Sales_Ditiles_Emp().View_Report_Sales_Emp();
        }

        private void BarButtonItem59_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            new Frm_add_operating_Expenses().ShowDialog();
        }


        private void BarButtonItem57_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

            show_form_doc = 1;
            new Manag_ph.Daily_accounts.Cash_exchange.cash_exchange().ShowDialog();
        }

        private void BarButtonItem58_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            show_form_doc = 2;
            new Manag_ph.Daily_accounts.cash_Supply.cash_supply().ShowDialog();
        }


        private void Btn_unlock_Casher_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            new Item.forms.frm_unlock_Casher().ShowDialog();
        }

        private void Panel32_Paint(object sender, PaintEventArgs e)
        {

        }


        Client.Class_Client.Class_Blan_clin class_Blan_clin = new Client.Class_Client.Class_Blan_clin();

        private void Btn_save_bln_clin_Click(object sender, EventArgs e)
        {
            class_Blan_clin.seva_bln_clin();
        }
        private void Btn_add_bln_clin_Click(object sender, EventArgs e)
        {
            new classs_table.Items_Tools().showAndHideForm(nav_Bln_Clin_Show);
            class_Blan_clin.btn_baln_add_clin();
        }
        private void Dgv_bln_clin_new_SelectionChanged(object sender, EventArgs e)
        {
            class_Blan_clin.Dgv_bln_clin();

        }

        private void BarButtonItem56_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            new classs_table.Items_Tools().showAndHideForm(Report_unlock_casher);
            new Sales.Report.RP_unlock_Casher().get_Emp_use_Program();
        }

        private void Button90_Click(object sender, EventArgs e)
        {
            new Sales.Report.RP_unlock_Casher().Search_unlock_Casher_Emp();
        }

        private void Button91_Click(object sender, EventArgs e)
        {
            new Sales.Report.RP_unlock_Casher().Report_unlock_Cahser();

        }

        private void BarButtonItem55_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            new Item.forms.Frm_reason_dicon_Add().ShowDialog();
        }

        private void Btn_Report_Reasons_disco_Add_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            new classs_table.Items_Tools().showAndHideForm(Report_Reasons_disco_Add);
            new Accounts.Report.RP_Discount_All().Fill_All_Data();

        }

        private void Button93_Click(object sender, EventArgs e)
        {
            new Accounts.Report.RP_Discount_All().SearchData();
        }

        private void Com_type_Dico_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void Btn_Show_Rp_cash_supply_Click(object sender, EventArgs e)
        {
            new Daily_accounts.CR_Daily_accounts.RP_cash__supply().View_Report_cash_supply();
        }

        private void Btn_show_RT_cash_exchange_Click(object sender, EventArgs e)
        {
            new Daily_accounts.CR_Daily_accounts.RP_cash_exchange().View_Report_cash_Exchange();

        }

        private void Btn_RT_sersh_cash_exchange_Click(object sender, EventArgs e)
        {
            new Daily_accounts.CR_Daily_accounts.RP_cash_exchange().serch_RT_cash_exchange();
        }

        private void Btn_serch_RP_cash_supply_Click(object sender, EventArgs e)
        {

            new Daily_accounts.CR_Daily_accounts.RP_cash__supply().serch_RT_cash_exchange();
        }

        private void Brn_RT_cash_exchange_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            new classs_table.Items_Tools().showAndHideForm(Report_cash_exchange);
            new Daily_accounts.CR_Daily_accounts.RP_cash_exchange().Get_account_fund_All();
            new Daily_accounts.CR_Daily_accounts.RP_cash_exchange().Get_beneficiary_RP_cash_exchange();
        }

        private void Btn_RP_cash_supply_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            new classs_table.Items_Tools().showAndHideForm(Report_cash_supply);
            new Daily_accounts.CR_Daily_accounts.RP_cash__supply().Get_beneficiary_RP_cash_supply();
            new Daily_accounts.CR_Daily_accounts.RP_cash__supply().Get_account_fund_All();
        }

        private void Bar_Btn_Show_bal_sup_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

        }
        Supplier.supplier.Balanse Balan_sup = new Supplier.supplier.Balanse();

        private void Bar_Btn_Show_bal_sup_ItemClick_1(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            new classs_table.Items_Tools().showAndHideForm(nav_Balance_supp);
            Balan_sup.Get_IndexDatagrid2();
        }

        private void Txt_Debt_blan_clin_TextChanged(object sender, EventArgs e)
        {

        }

        private void Btn_save_bln_clin_btn_Click(object sender, EventArgs e)
        {

            class_Blan_clin.seva_bln_clin();
        }

        private void Btn_Save_Blance_btn_Click(object sender, EventArgs e)
        {
            Balan_sup.Save_Balanse_sup();
        }

        private void Dgv_bln_clin_new_dgv_SelectionChanged(object sender, EventArgs e)
        {
            class_Blan_clin.Dgv_bln_clin();
        }

        private void Dgv_Balanse_Add_sup_dgv_SelectionChanged(object sender, EventArgs e)
        {
            Balan_sup.Dgv_Balanse_Add_sup_SelectionChanged();
        }

        private void Dgv_sals_dgv_SelectionChanged(object sender, EventArgs e)
        {


        }
        private void Dgv_sals_dgv_KeyDown(object sender, KeyEventArgs e)
        {
            if (dgv_sals_dgv.CurrentRow != null)
            {
                if (e.KeyCode == Keys.F1)
                {
                    dgv_sals_dgv.CurrentRow.Cells[1].Selected = true;
                }
                else if (e.KeyCode == Keys.F2)
                {
                    dgv_sals_dgv.CurrentRow.Cells[4].Selected = true;

                }
                else if (e.KeyCode == Keys.F3)
                {
                    dgv_sals_dgv.CurrentRow.Cells[5].Selected = true;

                }
                else if (e.KeyCode == Keys.F4)
                {
                    dgv_sals_dgv.CurrentRow.Cells[10].Selected = true;

                }
                else if (e.KeyCode == Keys.F5)
                {
                    dgv_sals_dgv.CurrentRow.Cells[11].Selected = true;

                }
                else if (e.Control && e.KeyCode == Keys.S)
                {
                    button65_btn.PerformClick();
                }
                if (e.KeyCode == Keys.Enter)
                {
                    dgv_sals_dgv.CurrentRow.Cells[0].Selected = true;
                }

            }

        }

        private void Dgv_sals_dgv_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void Dgv_open_storg_dgv_MouseDown(object sender, MouseEventArgs e)
        {

        }

        private void Dgv_open_storg_dgv_KeyDown(object sender, KeyEventArgs e)
        {
            if (dgv_open_storg_dgv.CurrentRow != null)
            {
                if (e.KeyCode == Keys.Enter)
                {
                    if ((dgv_open_storg_dgv.CurrentRow.Cells.Count - 1) != dgv_open_storg_dgv.CurrentCell.ColumnIndex)
                    {

                        dgv_open_storg_dgv.CurrentRow.Cells[dgv_open_storg_dgv.CurrentCell.ColumnIndex + 1].Selected = true;
                      
                        dgv_open_storg_dgv.Focus();

                    }
                    else
                    {

                        dgv_open_storg_dgv.Rows.Add();

                        dgv_open_storg_dgv.Rows[dgv_open_storg_dgv.RowCount - 1].Cells[0].Selected = true;
                    }
                }

                if (e.KeyCode == Keys.F1)
                {
                    dgv_open_storg_dgv.CurrentRow.Cells[0].Selected = true;
                }
                else if (e.KeyCode == Keys.F2)
                {
                    dgv_open_storg_dgv.CurrentRow.Cells[2].Selected = true;
                }
                else if (e.KeyCode == Keys.F3)
                {
                    dgv_open_storg_dgv.CurrentRow.Cells[3].Selected = true;
                }
                else if (e.KeyCode == Keys.F4)
                {
                    dgv_open_storg_dgv.CurrentRow.Cells[4].Selected = true;
                }
                else if (e.KeyCode == Keys.F5)
                {
                    dgv_open_storg_dgv.CurrentRow.Cells[5].Selected = true;
                  
                }
                else if (e.KeyCode == Keys.F6)
                {
                    dgv_open_storg_dgv.CurrentRow.Cells[6].Selected = true;
                }
                else if (e.KeyCode == Keys.F7)
                {

                    dgv_open_storg_dgv.CurrentRow.Cells[7].Selected = true;

                }
                else if (e.KeyCode == Keys.F8)
                {
                    dgv_open_storg_dgv.CurrentRow.Cells[9].Selected = true;
                }

            }
        }

        private void Dgv_prodect_dgv_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {

        
        }

        private void Dgv_prodect_dgv_KeyDown(object sender, KeyEventArgs e)
        {
            if (dgv_prodect_dgv.CurrentRow != null)
            {
                if (e.KeyCode == Keys.Enter)
                {
                    if (((dgv_prodect_dgv.CurrentRow.Cells.Count - 1) != dgv_prodect_dgv.CurrentCell.ColumnIndex) && dgv_prodect_dgv.CurrentRow.Cells[dgv_prodect_dgv.CurrentCell.ColumnIndex + 1].OwningColumn.Visible == true)
                    {

                        dgv_prodect_dgv.CurrentRow.Cells[dgv_prodect_dgv.CurrentCell.ColumnIndex + 1].Selected = true;
                      
                        dgv_prodect_dgv.Focus();

                    }
                    else
                    {

                        dgv_prodect_dgv.Rows.Add();

                        dgv_prodect_dgv.Rows[dgv_prodect_dgv.RowCount - 1].Cells[1].Selected = true;
                    }
                }

                if (e.KeyCode == Keys.F1)
                {
                    dgv_prodect_dgv.CurrentRow.Cells[1].Selected = true;
                }
                else if (e.KeyCode == Keys.F2)
                {
                    dgv_prodect_dgv.CurrentRow.Cells[3].Selected = true;
                }
                else if (e.KeyCode == Keys.F3)
                {
                    dgv_prodect_dgv.CurrentRow.Cells[4].Selected = true;
                }
                else if (e.KeyCode == Keys.F4)
                {
                    dgv_prodect_dgv.CurrentRow.Cells[5].Selected = true;
                }
                else if (e.KeyCode == Keys.F5)
                {
                    dgv_prodect_dgv.CurrentRow.Cells[6].Selected = true;
                 
                }
                else if (e.KeyCode == Keys.F6)
                {
                    dgv_prodect_dgv.CurrentRow.Cells[8].Selected = true;
                }
                else if (e.KeyCode == Keys.F7)
                {
                    dgv_prodect_dgv.CurrentRow.Cells[9].Selected = true;
                }
                else if (e.KeyCode == Keys.F8)
                {
                    dgv_prodect_dgv.CurrentRow.Cells[11].Selected = true;
                }
            }
        }

        private void Dgv_prodect_dgv_CellClick_1(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void DataGridView4_dgv_DoubleClick(object sender, EventArgs e)
        {
            forms.Form2 m = new forms.Form2();
            //dataGridView4.Rows.Clear();

            m.Text = "اختيار البديل";
            m.Show();
        }

        private void Btn_save_bln_clin_btn_Click_1(object sender, EventArgs e)
        {
            class_Blan_clin.seva_bln_clin();
        }

        private void Dgv_bln_clin_new_dgv_SelectionChanged_1(object sender, EventArgs e)
        {
            class_Blan_clin.Dgv_bln_clin();
        }

        private void Btn_Save_Blance_btn_Click_1(object sender, EventArgs e)
        {
            Balan_sup.Save_Balanse_sup();
        }

        private void Dgv_Balanse_Add_sup_dgv_SelectionChanged_1(object sender, EventArgs e)
        {
            Balan_sup.Dgv_bln_clin();
        }

        private void Com_beneficiary_RT_cash_exchange_SelectedValueChanged(object sender, EventArgs e)
        {

        }

        private void Com_beneficiary_RT_cash_exchange_SelectedIndexChanged(object sender, EventArgs e)
        {
            //تعديل

            new Daily_accounts.CR_Daily_accounts.RP_cash_exchange().serch_text_and_combox();
        }

        private void Cbx_RP_name_Benf_Type_cash_supply_SelectedIndexChanged(object sender, EventArgs e)
        {

            //تعديل

            new Daily_accounts.CR_Daily_accounts.RP_cash__supply().serch_text_and_combox_cash_supply();
        }

        private void Txt_num_footer_sals_return_KeyDown(object sender, KeyEventArgs e)
        {
            new Sales.Sals_return.search_Data_sals_return().Add_Cline_sals_return_in_txt_id_sls(sender, e);
        }

        private void BarButtonItem58_ItemClick_1(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            new classs_table.Items_Tools().showAndHideForm(RP_Search_Report_Account_Add);
            new Accounts.Report.RP_Add_Account_All().Fill_All_Data();
        }

        private void Button5_Click_2(object sender, EventArgs e)
        {
            new Accounts.Report.RP_Add_Account_All().SearchData();
        }

        private void Button7_Click_1(object sender, EventArgs e)
        {
            new Items_Tools().showAndHideForm(Nav_Main);
        }

        private void Button8_Click_1(object sender, EventArgs e)
        {
            new Items_Tools().showAndHideForm(Nav_Main);
        }

        private void Button9_Click(object sender, EventArgs e)
        {
            new Items_Tools().showAndHideForm(Nav_Main);
        }

        private void Button11_Click_1(object sender, EventArgs e)
        {
            new Items_Tools().showAndHideForm(Nav_Main);
        }

        private void Button12_Click_2(object sender, EventArgs e)
        {
            new Items_Tools().showAndHideForm(Nav_Main);
        }

        private void Button14_Click_1(object sender, EventArgs e)
        {
            new Items_Tools().showAndHideForm(Nav_Main);
        }

        private void Button15_Click(object sender, EventArgs e)
        {
            new Items_Tools().showAndHideForm(Nav_Main);
        }

        private void Button16_Click(object sender, EventArgs e)
        {
            new Items_Tools().showAndHideForm(Nav_Main);
        }

        private void Button25_btn_Click(object sender, EventArgs e)
        {
            new Items_Tools().showAndHideForm(Nav_Main);
        }

        private void Button26_btn_Click(object sender, EventArgs e)
        {
            new Items_Tools().showAndHideForm(Nav_Main);
        }

        private void Button28_btn_Click(object sender, EventArgs e)
        {
            new Items_Tools().showAndHideForm(Nav_Main);
        }

        private void Btn_Close_page_shew_EMP_btn_Click(object sender, EventArgs e)
        {
            new Items_Tools().showAndHideForm(Nav_Main);
        }

        private void Button17_Click_1(object sender, EventArgs e)
        {
            new Items_Tools().showAndHideForm(Nav_Main);
        }

        private void Btn_cloes_btn_Click(object sender, EventArgs e)
        {
            new Items_Tools().showAndHideForm(Nav_Main);
        }

        private void BarButtonItem14_ItemClick(object sender, DevExpress.XtraEditors.TileItemEventArgs e)
        {
            new Items_Tools().showAndHideForm(Add_Item);
            txt_barcode_enter.Focus();
        }

        private void BarButtonItem9_ItemClick(object sender, DevExpress.XtraEditors.TileItemEventArgs e)
        {
            new Items_Tools().showAndHideForm(View_And_serch);
            lbl_count.Text = DB_Add_delete_update_.Database.dv.Count.ToString();
        }

        private void Btn_storg_ItemClick(object sender, DevExpress.XtraEditors.TileItemEventArgs e)
        {
            dgv_storg_dgv.DataSource = DB_Add_delete_update_.Database.ds.Tables["Storg"];
            new Items_Tools().showAndHideForm(Add_Storg);
            dgv_storg_dgv.Columns[0].HeaderText = " رقم المخزن";
            dgv_storg_dgv.Columns[1].HeaderText = "اسم لمخزن(AR)";
            dgv_storg_dgv.Columns[2].HeaderText = "اسم لمخزن(EN)";
            dgv_storg_dgv.Columns[3].HeaderText = "عنوان المخزن";
            dgv_storg_dgv.Columns[4].HeaderText = "امين المخزم";
            dgv_storg_dgv.Columns[5].HeaderText = " الهاتف";

        }

        private void Btn_Add_storg_ItemClick(object sender, DevExpress.XtraEditors.TileItemEventArgs e)
        {

        }

        private void BarButtonItem24_ItemClick(object sender, DevExpress.XtraEditors.TileItemEventArgs e)
        {

        }

        private void BarButtonItem26_ItemClick(object sender, DevExpress.XtraEditors.TileItemEventArgs e)
        {

        }

        private void BarButtonItem27_ItemClick(object sender, DevExpress.XtraEditors.TileItemEventArgs e)
        {
            new Items_Tools().showAndHideForm(nav_return_prodect);
        }

        private void BarButtonItem39_ItemClick(object sender, DevExpress.XtraEditors.TileItemEventArgs e)
        {
            new prodects.Report.RP_footer_prodects().Fill_All_Data_RP_update_qty();
            new classs_table.Items_Tools().showAndHideForm(Report_Footer_prodect_All);
        }

        private void BarButtonItem41_ItemClick(object sender, DevExpress.XtraEditors.TileItemEventArgs e)
        {
            new classs_table.Items_Tools().showAndHideForm(Report_total_return_supper);
        }

        private void BarButtonItem40_ItemClick(object sender, DevExpress.XtraEditors.TileItemEventArgs e)
        {
            new classs_table.Items_Tools().showAndHideForm(Report_Footer_prodect_num);
        }

        private void BarButtonItem47_ItemClick(object sender, DevExpress.XtraEditors.TileItemEventArgs e)
        {
            Datagridview_Type_barcode = 0;
            using_contracr.Text = "استخداد \n\r التعاقد";
            new Sales.Sales_open_Add().open_Sales();
        }

        private void BarButtonItem50_ItemClick(object sender, DevExpress.XtraEditors.TileItemEventArgs e)
        {
            new Sales.Sals_return.search_Data_sals_return().open_frm_sals_return();
        }

        private void BarButtonItem48_ItemClick(object sender, DevExpress.XtraEditors.TileItemEventArgs e)
        {
            Datagridview_Type_barcode = 3;
            // نقل بيانات المخزن من فورم المبيعات الا فورم الفواتير المعلقة

            new Sales.hanging_Add_Delete_update_serch().open_hanging();
            button75_btn.PerformClick();
        }

        private void BarButtonItem54_ItemClick(object sender, DevExpress.XtraEditors.TileItemEventArgs e)
        {
            new classs_table.Items_Tools().showAndHideForm(Report_Sales_Footer_Employ);
            new Sales.Report.RP_Sales_Ditiles_Emp().Get_Storg_RP_Sales_Emp_All();
            new Sales.Report.RP_Sales_Ditiles_Emp().Get_All_Employ();
        }

        private void BarButtonItem56_ItemClick(object sender, DevExpress.XtraEditors.TileItemEventArgs e)
        {
            new classs_table.Items_Tools().showAndHideForm(Report_unlock_casher);
            new Sales.Report.RP_unlock_Casher().get_Emp_use_Program();
        }

        private void TileItem3_ItemClick(object sender, DevExpress.XtraEditors.TileItemEventArgs e)
        {
            Datagridview_Type_barcode = 2;
            new Items_Tools().showAndHideForm(purchases_bill);

            txt_num_prodect.Text = new Items_Tools().AoutoNumber("Data_Footer", "Foot_code").ToString();
            new prodects.Footer_prodect().fill_Cacher_and_fund();

        }

        private void Panel20_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Com_unit_Comtl_update_SelectedIndexChanged(object sender, EventArgs e)
        {
            new Item.update().Cobr_All_update();
        }

        private void Com_unit_avrg_update_SelectedIndexChanged(object sender, EventArgs e)
        {
            new Item.update().Avrg_All_update();
        }

        private void Com_unit_smol_update_SelectedIndexChanged(object sender, EventArgs e)
        {
            new Item.update().smoll_All_update();
        }

        private void Sell_pric_update_KeyDown(object sender, KeyEventArgs e)
        {
            foucs_key(e, disc_parc_update);
        }

        private void Sell_pric_update_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsDigit(e.KeyChar) || e.KeyChar == 8))
            {
                e.Handled = true;
            }
        }

        private void Sell_pric_update_KeyUp(object sender, KeyEventArgs e)
        {
            product_price_update.Text = sell_pric_update.Text;
            //m2.Check_Text_Empty(sell_pric_update, lbl_sall);
            pric_unit_avrg_update.Text = sell_pric_update.Text;
            pric_unit_smol_update.Text = sell_pric_update.Text;
        }
        private void Col_Discount_update()
        {
            if (disc_parc_update.Text.Trim() != string.Empty && sell_pric_update.Text.Trim() != string.Empty)
            {


                double sell = Convert.ToDouble(sell_pric_update.Text.Trim());
                double pric_ns = Convert.ToDouble(disc_parc_update.Text.Trim()) / 100;
                double reslt = sell * pric_ns;

                double reslt2 = sell - reslt;
                product_price_update.Text = reslt2.ToString();
                Aoumn_befor_update = reslt2.ToString();
            }
        }
        private void Disc_parc_update_KeyDown(object sender, KeyEventArgs e)
        {
            foucs_key(e, tax_pric_update);
            Col_Discount_update();
        }

        private void Disc_parc_update_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsDigit(e.KeyChar) || e.KeyChar == 8))
            {
                e.Handled = true;
            }
            if (char.IsDigit(e.KeyChar))
            {
                //int max = Convert.ToInt32(Max_DIsc.Text.Trim());
                string str = disc_parc_update.Text.Trim() + e.KeyChar.ToString();
                string str2 = e.KeyChar.ToString() + disc_parc_update.Text.Trim();
                //string str = disc_parc.text.trim();
                int pric = Convert.ToInt32(str);
                int pric2 = Convert.ToInt32(str2);
                if (!(pric <= 100))
                {
                    e.Handled = true;
                }
            }
        }

        private void Disc_parc_update_KeyUp(object sender, KeyEventArgs e)
        {
            if (disc_parc.Text.Trim() != string.Empty)
            {
                Col_Discount_update();
            }
        }

        private void Tax_pric_update_KeyDown(object sender, KeyEventArgs e)
        {
            foucs_key(e, product_price_update);
        }

        private void Tax_pric_update_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsDigit(e.KeyChar) || e.KeyChar == 8))
            {
                e.Handled = true;
            }
        }

        private void Tax_pric_update_KeyUp(object sender, KeyEventArgs e)
        {
            Auom_update();
            //m2.Check_Text_Empty(tax_pric_update, lbl_tex);
        }

        private void Num_unit_avrg_update_KeyDown(object sender, KeyEventArgs e)
        {
            foucs_key(e, pric_unit_avrg_update);
        }

        private void Num_unit_avrg_update_KeyPress(object sender, KeyPressEventArgs e)
        {

            if (!(char.IsDigit(e.KeyChar) || e.KeyChar == 8))
            {
                e.Handled = true;
            }
        }

        private void Num_unit_avrg_update_KeyUp(object sender, KeyEventArgs e)
        {
            //m2.Check_Text_Empty(num_unit_avrg, lbl_avrg);

            double num = m2.Calc_un(num_unit_avrg_update, sell_pric_update);
            int num2 = Convert.ToInt32(num);
            if (num == num2)
            {
                pric_unit_avrg_update.Text = num.ToString();
            }
            else
            {
                pric_unit_avrg_update.Text = num.ToString("N");
            }


            double nums = m2.Calc_un(num_unit_smol_update, pric_unit_avrg_update);
            int nums2 = Convert.ToInt32(nums);
            if (nums == nums2)
            {
                pric_unit_smol_update.Text = nums.ToString();
            }
            else
            {
                pric_unit_smol_update.Text = nums.ToString("N");
            }

        }

        private void Txt_item_name_en_KeyUp(object sender, KeyEventArgs e)
        {
            m2.Check_Text_Empty(txt_item_name_en, labelControl3);
        }

        private void Dgv_open_storg_dgv_SelectionChanged(object sender, EventArgs e)
        {
          
        }

        private void Dgv_prodect_dgv_SelectionChanged(object sender, EventArgs e)
        {
       

        }

        private void Txt_barcode_enter_TextChanged(object sender, EventArgs e)
        {
            new classs_table.Items_Tools().SetKeyboardLayout("eng");
        }

        private void Button6_Click_1(object sender, EventArgs e)
        {

        }

        private void Dgv_open_storg_dgv_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            new classs_table.Items_Tools().Set_And_Vildet_Date(dgv_open_storg_dgv,5,e);
        }

        private void Dgv_settle_dgv_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            new classs_table.Items_Tools().Set_And_Vildet_Date(dgv_settle_dgv, 4, e);
        }

        private void Dgv_prodect_dgv_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            new classs_table.Items_Tools().Set_And_Vildet_Date(dgv_prodect_dgv, 5, e);
        }

        private void TabPage3_Click(object sender, EventArgs e)
        {

        }

        private void TabPage1_Click(object sender, EventArgs e)
        {

        }

        private void Dgv_open_storg_dgv_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Txt_num_supper_return_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsDigit(e.KeyChar) || e.KeyChar == 8))
            {
                e.Handled = true;
            }
        }

        private void Txt_serch_num_foote_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsDigit(e.KeyChar) || e.KeyChar == 8))
            {
                e.Handled = true;
            }
        }

        private void Txt_num_storg_one_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsDigit(e.KeyChar) || e.KeyChar == 8))
            {
                e.Handled = true;
            }
        }

        private void Txt_num_Item_RP_Storg_All_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsDigit(e.KeyChar) || e.KeyChar == 8))
            {
                e.Handled = true;
            }
        }

        private void Txt_suppr_num_footer_All_RP_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsDigit(e.KeyChar) || e.KeyChar == 8))
            {
                e.Handled = true;
            }
        }

        private void Txt_footter_id_RP_num_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsDigit(e.KeyChar) || e.KeyChar == 8))
            {
                e.Handled = true;
            }
        }

        private void Txt_footter_number_RP_num_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsDigit(e.KeyChar) || e.KeyChar == 8))
            {
                e.Handled = true;
            }
        }

        private void Txt_footter_supper_num_RP_num_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsDigit(e.KeyChar) || e.KeyChar == 8))
            {
                e.Handled = true;
            }
        }

        private void BarButt57_create_backup_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Item.forms.Frm_Backup fb = new Frm_Backup();
            fb.show_button = 1;
            fb.lbl_form_backup_and_retore_backup.Text = "إنشاء نُسخ إحتياطية";
            fb.ShowDialog();

        }

        private void BarButt59_Rerstor_backup_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Item.forms.Frm_Backup fb = new Frm_Backup();
            fb.show_button = 2;
            fb.lbl_form_backup_and_retore_backup.Text = "إستعادة نُسخ إحتياطية";
            fb.ShowDialog();
        }

        private void Txt_Report_id_sup_DoubleClick(object sender, EventArgs e)
        {
            new Supplier.Report_Supp.Show_supp_data().ShowDialog();
        }

        private void Btn_Rep_serch_sup_btn_Click(object sender, EventArgs e)
        {
            new Supplier.Report_Supp.Report_sup().serch_Rp_supper();
        }

        private void Txt_id_Rp_clin_DoubleClick(object sender, EventArgs e)
        {
           
            new Client.Report_Clin.show_Data_clin().ShowDialog();
        }

        private void Btn_serch_Rp_clin_Click(object sender, EventArgs e)
        {
            new Client.Report_Clin.Report_clin().serch_Rp_clin();
        }

        private void BarBtn_Show_Rep_Sup_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            new classs_table.Items_Tools().showAndHideForm(Report_Supp);
            new Supplier.Report_Supp.Report_sup().show_Data();
        }

        private void BarBtn_Show_Rep_Clin_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            new classs_table.Items_Tools().showAndHideForm(Report_Clint);
            new Client.Report_Clin.Report_clin().show_Data();
        }

        private void Txt_Report_id_sup_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                new Supplier.Report_Supp.Report_sup().get_Data_Supp();
            }
        }

        private void Txt_id_Rp_clin_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                new Client.Report_Clin.Report_clin().get_Data_Clin();
            }
        }

        private void TextEdit2_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void TextEdit2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                new classs_table.Items_Tools().get_data_Item_or_barcode(txt_num_Item_shert, txt_name_Item_shert);
            }
        }

        private void BarButtonItem59_ItemClick_1(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            new classs_table.Items_Tools().showAndHideForm(nav_report_short);
        }

        private void BarBtn_Preparing_Emps_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

            Item.forms.Frm_Preparing_employees frm = new Frm_Preparing_employees();
            frm.ShowDialog();
        }

        private void Txt_num_Storg_sals_return_EditValueChanged(object sender, EventArgs e)
        {

        }
    }


}


