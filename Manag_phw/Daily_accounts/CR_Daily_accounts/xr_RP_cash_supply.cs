using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;

namespace Manag_ph.Daily_accounts.CR_Daily_accounts
{
    public partial class xr_RP_cash_supply : DevExpress.XtraReports.UI.XtraReport
    {
        private TopMarginBand topMarginBand1;
        private DetailBand detailBand1;
        private ReportHeaderBand ReportHeader;
        private PageHeaderBand PageHeader;
        private ReportFooterBand ReportFooter;
        private PageFooterBand PageFooter;
        private XRTable Table2_RP_cash_supply;
        private XRTableRow xrTableRow2;
        private XRTableCell xrTableCell4;
        private XRTableCell xrTableCell5;
        private XRTableCell xrTableCell6;
        private XRTableCell xrTableCell15;
        private XRTableCell xrTableCell22;
        private XRTableCell xrTableCell23;
        private XRTableCell xrTableCell24;
        private XRTableCell xrTableCell25;
        private XRTableCell xrTableCell26;
        public XRLabel dtp_Tow_RP_cash_supply;
        public XRLabel txt_Storg_RP_cash_supply;
        private XRLabel lbl_Storg_RP_cash_supply;
        private XRLabel lbl_dtp_Tow_RP_cash_supply;
        public XRLabel dtp_One_RP_cash_supply;
        private XRLabel lbl_dtp_One_RP_cash_supply;
        private XRTable xrTable4_RP_Cash_supply;
        private XRTableRow xrTableRow4;
        private XRTableCell xrTableCell21;
        private XRTableCell xrTableCell20;
        private XRTableCell xrTableCell19;
        private XRTableCell xrTableCell18;
        private XRTableCell xrTableCell17;
        private XRTableCell xrTableCell16;
        private XRTableCell xrTableCell12;
        private XRTableCell xrTableCell13;
        private XRTableCell Table_RP_cash_supply;
        public XRLabel xrtxtRP_amount_supply_written;
        private XRLabel lbl_xrtxtRP_amount_supply_written;
        public XRLabel xrtxtRP_total_supply;
        private XRLabel lblxrtxtRP_total_supply;
        public XRLabel xrtxtRP_num_pross_RP_Cash_supply;
        private XRLabel lbl_xrtxtRP_num_pross_RP_Cash_supply;
        private XRShape xrShape3_RP_cash_supply;
        private XRShape xrShape_RP_Cash_supply;
        private XRPageInfo xrPageInfo_RP_cash_supply;
        private XRCrossBandLine xrCrossBandLine1;
        private XRCrossBandLine xrCrossBandLine2;
        private XRLine xrLine2;
        private XRLabel xrLabel_Main_name_RP_Cash_exchange;
        private DataSet1 dataSet11;
        private BottomMarginBand bottomMarginBand1;

        public xr_RP_cash_supply()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            DevExpress.XtraReports.UI.XRSummary xrSummary1 = new DevExpress.XtraReports.UI.XRSummary();
            DevExpress.XtraPrinting.Shape.ShapeRectangle shapeRectangle1 = new DevExpress.XtraPrinting.Shape.ShapeRectangle();
            DevExpress.XtraPrinting.Shape.ShapeRectangle shapeRectangle2 = new DevExpress.XtraPrinting.Shape.ShapeRectangle();
            this.topMarginBand1 = new DevExpress.XtraReports.UI.TopMarginBand();
            this.detailBand1 = new DevExpress.XtraReports.UI.DetailBand();
            this.Table2_RP_cash_supply = new DevExpress.XtraReports.UI.XRTable();
            this.xrTableRow2 = new DevExpress.XtraReports.UI.XRTableRow();
            this.xrTableCell4 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell5 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell6 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell15 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell22 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell23 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell24 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell25 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell26 = new DevExpress.XtraReports.UI.XRTableCell();
            this.bottomMarginBand1 = new DevExpress.XtraReports.UI.BottomMarginBand();
            this.ReportHeader = new DevExpress.XtraReports.UI.ReportHeaderBand();
            this.xrLabel_Main_name_RP_Cash_exchange = new DevExpress.XtraReports.UI.XRLabel();
            this.dtp_Tow_RP_cash_supply = new DevExpress.XtraReports.UI.XRLabel();
            this.txt_Storg_RP_cash_supply = new DevExpress.XtraReports.UI.XRLabel();
            this.lbl_Storg_RP_cash_supply = new DevExpress.XtraReports.UI.XRLabel();
            this.lbl_dtp_Tow_RP_cash_supply = new DevExpress.XtraReports.UI.XRLabel();
            this.dtp_One_RP_cash_supply = new DevExpress.XtraReports.UI.XRLabel();
            this.lbl_dtp_One_RP_cash_supply = new DevExpress.XtraReports.UI.XRLabel();
            this.PageHeader = new DevExpress.XtraReports.UI.PageHeaderBand();
            this.xrTable4_RP_Cash_supply = new DevExpress.XtraReports.UI.XRTable();
            this.xrTableRow4 = new DevExpress.XtraReports.UI.XRTableRow();
            this.xrTableCell21 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell20 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell19 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell18 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell17 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell16 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell12 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell13 = new DevExpress.XtraReports.UI.XRTableCell();
            this.Table_RP_cash_supply = new DevExpress.XtraReports.UI.XRTableCell();
            this.ReportFooter = new DevExpress.XtraReports.UI.ReportFooterBand();
            this.xrLine2 = new DevExpress.XtraReports.UI.XRLine();
            this.xrtxtRP_amount_supply_written = new DevExpress.XtraReports.UI.XRLabel();
            this.lbl_xrtxtRP_amount_supply_written = new DevExpress.XtraReports.UI.XRLabel();
            this.xrtxtRP_total_supply = new DevExpress.XtraReports.UI.XRLabel();
            this.lblxrtxtRP_total_supply = new DevExpress.XtraReports.UI.XRLabel();
            this.xrtxtRP_num_pross_RP_Cash_supply = new DevExpress.XtraReports.UI.XRLabel();
            this.lbl_xrtxtRP_num_pross_RP_Cash_supply = new DevExpress.XtraReports.UI.XRLabel();
            this.xrShape3_RP_cash_supply = new DevExpress.XtraReports.UI.XRShape();
            this.xrShape_RP_Cash_supply = new DevExpress.XtraReports.UI.XRShape();
            this.PageFooter = new DevExpress.XtraReports.UI.PageFooterBand();
            this.xrPageInfo_RP_cash_supply = new DevExpress.XtraReports.UI.XRPageInfo();
            this.xrCrossBandLine1 = new DevExpress.XtraReports.UI.XRCrossBandLine();
            this.xrCrossBandLine2 = new DevExpress.XtraReports.UI.XRCrossBandLine();
            this.dataSet11 = new Manag_ph.DataSet1();
            ((System.ComponentModel.ISupportInitialize)(this.Table2_RP_cash_supply)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xrTable4_RP_Cash_supply)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSet11)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            // 
            // topMarginBand1
            // 
            this.topMarginBand1.HeightF = 0F;
            this.topMarginBand1.Name = "topMarginBand1";
            // 
            // detailBand1
            // 
            this.detailBand1.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.Table2_RP_cash_supply});
            this.detailBand1.HeightF = 28.125F;
            this.detailBand1.Name = "detailBand1";
            // 
            // Table2_RP_cash_supply
            // 
            this.Table2_RP_cash_supply.AnchorVertical = DevExpress.XtraReports.UI.VerticalAnchorStyles.Top;
            this.Table2_RP_cash_supply.LocationFloat = new DevExpress.Utils.PointFloat(0F, 0F);
            this.Table2_RP_cash_supply.Name = "Table2_RP_cash_supply";
            this.Table2_RP_cash_supply.Rows.AddRange(new DevExpress.XtraReports.UI.XRTableRow[] {
            this.xrTableRow2});
            this.Table2_RP_cash_supply.SizeF = new System.Drawing.SizeF(809F, 26.2917F);
            // 
            // xrTableRow2
            // 
            this.xrTableRow2.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.xrTableCell4,
            this.xrTableCell5,
            this.xrTableCell6,
            this.xrTableCell15,
            this.xrTableCell22,
            this.xrTableCell23,
            this.xrTableCell24,
            this.xrTableCell25,
            this.xrTableCell26});
            this.xrTableRow2.Name = "xrTableRow2";
            this.xrTableRow2.Weight = 1D;
            // 
            // xrTableCell4
            // 
            this.xrTableCell4.BackColor = System.Drawing.Color.White;
            this.xrTableCell4.Borders = ((DevExpress.XtraPrinting.BorderSide)((((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top) 
            | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrTableCell4.BorderWidth = 1F;
            this.xrTableCell4.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[Name_Emp]")});
            this.xrTableCell4.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold);
            this.xrTableCell4.ForeColor = System.Drawing.Color.Black;
            this.xrTableCell4.Multiline = true;
            this.xrTableCell4.Name = "xrTableCell4";
            this.xrTableCell4.StylePriority.UseBackColor = false;
            this.xrTableCell4.StylePriority.UseBorders = false;
            this.xrTableCell4.StylePriority.UseBorderWidth = false;
            this.xrTableCell4.StylePriority.UseFont = false;
            this.xrTableCell4.StylePriority.UseForeColor = false;
            this.xrTableCell4.StylePriority.UseTextAlignment = false;
            this.xrTableCell4.Text = "اسم الموظف";
            this.xrTableCell4.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.xrTableCell4.Weight = 1D;
            // 
            // xrTableCell5
            // 
            this.xrTableCell5.BackColor = System.Drawing.Color.White;
            this.xrTableCell5.Borders = ((DevExpress.XtraPrinting.BorderSide)((((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top) 
            | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrTableCell5.BorderWidth = 1F;
            this.xrTableCell5.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[Document_Note]")});
            this.xrTableCell5.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold);
            this.xrTableCell5.ForeColor = System.Drawing.Color.Black;
            this.xrTableCell5.Multiline = true;
            this.xrTableCell5.Name = "xrTableCell5";
            this.xrTableCell5.StylePriority.UseBackColor = false;
            this.xrTableCell5.StylePriority.UseBorders = false;
            this.xrTableCell5.StylePriority.UseBorderWidth = false;
            this.xrTableCell5.StylePriority.UseFont = false;
            this.xrTableCell5.StylePriority.UseForeColor = false;
            this.xrTableCell5.StylePriority.UseTextAlignment = false;
            this.xrTableCell5.Text = "ملاحظة";
            this.xrTableCell5.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.xrTableCell5.Weight = 0.826174119494312D;
            // 
            // xrTableCell6
            // 
            this.xrTableCell6.BackColor = System.Drawing.Color.White;
            this.xrTableCell6.Borders = ((DevExpress.XtraPrinting.BorderSide)((((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top) 
            | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrTableCell6.BorderWidth = 1F;
            this.xrTableCell6.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[name_Payment_side]")});
            this.xrTableCell6.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold);
            this.xrTableCell6.ForeColor = System.Drawing.Color.Black;
            this.xrTableCell6.Multiline = true;
            this.xrTableCell6.Name = "xrTableCell6";
            this.xrTableCell6.StylePriority.UseBackColor = false;
            this.xrTableCell6.StylePriority.UseBorders = false;
            this.xrTableCell6.StylePriority.UseBorderWidth = false;
            this.xrTableCell6.StylePriority.UseFont = false;
            this.xrTableCell6.StylePriority.UseForeColor = false;
            this.xrTableCell6.StylePriority.UseTextAlignment = false;
            this.xrTableCell6.Text = "الصندوق";
            this.xrTableCell6.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.xrTableCell6.Weight = 0.90612477985094453D;
            // 
            // xrTableCell15
            // 
            this.xrTableCell15.BackColor = System.Drawing.Color.White;
            this.xrTableCell15.Borders = ((DevExpress.XtraPrinting.BorderSide)((((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top) 
            | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrTableCell15.BorderWidth = 1F;
            this.xrTableCell15.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[Remain_balan]")});
            this.xrTableCell15.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold);
            this.xrTableCell15.ForeColor = System.Drawing.Color.Black;
            this.xrTableCell15.Multiline = true;
            this.xrTableCell15.Name = "xrTableCell15";
            this.xrTableCell15.StylePriority.UseBackColor = false;
            this.xrTableCell15.StylePriority.UseBorders = false;
            this.xrTableCell15.StylePriority.UseBorderWidth = false;
            this.xrTableCell15.StylePriority.UseFont = false;
            this.xrTableCell15.StylePriority.UseForeColor = false;
            this.xrTableCell15.StylePriority.UseTextAlignment = false;
            this.xrTableCell15.Text = "الرصيد المتبقي";
            this.xrTableCell15.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.xrTableCell15.Weight = 0.96533195580481312D;
            // 
            // xrTableCell22
            // 
            this.xrTableCell22.BackColor = System.Drawing.Color.White;
            this.xrTableCell22.Borders = ((DevExpress.XtraPrinting.BorderSide)((((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top) 
            | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrTableCell22.BorderWidth = 1F;
            this.xrTableCell22.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[Curr_balance]")});
            this.xrTableCell22.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold);
            this.xrTableCell22.ForeColor = System.Drawing.Color.Black;
            this.xrTableCell22.Multiline = true;
            this.xrTableCell22.Name = "xrTableCell22";
            this.xrTableCell22.StylePriority.UseBackColor = false;
            this.xrTableCell22.StylePriority.UseBorders = false;
            this.xrTableCell22.StylePriority.UseBorderWidth = false;
            this.xrTableCell22.StylePriority.UseFont = false;
            this.xrTableCell22.StylePriority.UseForeColor = false;
            this.xrTableCell22.StylePriority.UseTextAlignment = false;
            this.xrTableCell22.Text = "الرصيد الحالي";
            this.xrTableCell22.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.xrTableCell22.Weight = 1.0010711330418536D;
            // 
            // xrTableCell23
            // 
            this.xrTableCell23.BackColor = System.Drawing.Color.White;
            this.xrTableCell23.Borders = ((DevExpress.XtraPrinting.BorderSide)((((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top) 
            | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrTableCell23.BorderWidth = 1F;
            this.xrTableCell23.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[Value_Expe]")});
            this.xrTableCell23.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold);
            this.xrTableCell23.ForeColor = System.Drawing.Color.Black;
            this.xrTableCell23.Multiline = true;
            this.xrTableCell23.Name = "xrTableCell23";
            this.xrTableCell23.StylePriority.UseBackColor = false;
            this.xrTableCell23.StylePriority.UseBorders = false;
            this.xrTableCell23.StylePriority.UseBorderWidth = false;
            this.xrTableCell23.StylePriority.UseFont = false;
            this.xrTableCell23.StylePriority.UseForeColor = false;
            this.xrTableCell23.StylePriority.UseTextAlignment = false;
            this.xrTableCell23.Text = "قيمة الصرف";
            this.xrTableCell23.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.xrTableCell23.Weight = 0.900416200918379D;
            // 
            // xrTableCell24
            // 
            this.xrTableCell24.BackColor = System.Drawing.Color.White;
            this.xrTableCell24.Borders = ((DevExpress.XtraPrinting.BorderSide)((((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top) 
            | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrTableCell24.BorderWidth = 1F;
            this.xrTableCell24.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[name_beneficiry]")});
            this.xrTableCell24.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold);
            this.xrTableCell24.ForeColor = System.Drawing.Color.Black;
            this.xrTableCell24.Multiline = true;
            this.xrTableCell24.Name = "xrTableCell24";
            this.xrTableCell24.StylePriority.UseBackColor = false;
            this.xrTableCell24.StylePriority.UseBorders = false;
            this.xrTableCell24.StylePriority.UseBorderWidth = false;
            this.xrTableCell24.StylePriority.UseFont = false;
            this.xrTableCell24.StylePriority.UseForeColor = false;
            this.xrTableCell24.StylePriority.UseTextAlignment = false;
            this.xrTableCell24.Text = "اسم المستفيد";
            this.xrTableCell24.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.xrTableCell24.TextFormatString = "{0:dd/MM/yyyy}";
            this.xrTableCell24.Weight = 1.1547062405844408D;
            // 
            // xrTableCell25
            // 
            this.xrTableCell25.BackColor = System.Drawing.Color.White;
            this.xrTableCell25.Borders = ((DevExpress.XtraPrinting.BorderSide)((((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top) 
            | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrTableCell25.BorderWidth = 1F;
            this.xrTableCell25.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[name_Benf_Type]")});
            this.xrTableCell25.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold);
            this.xrTableCell25.ForeColor = System.Drawing.Color.Black;
            this.xrTableCell25.Multiline = true;
            this.xrTableCell25.Name = "xrTableCell25";
            this.xrTableCell25.StylePriority.UseBackColor = false;
            this.xrTableCell25.StylePriority.UseBorders = false;
            this.xrTableCell25.StylePriority.UseBorderWidth = false;
            this.xrTableCell25.StylePriority.UseFont = false;
            this.xrTableCell25.StylePriority.UseForeColor = false;
            this.xrTableCell25.StylePriority.UseTextAlignment = false;
            this.xrTableCell25.Text = "نوع المستفيد";
            this.xrTableCell25.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.xrTableCell25.Weight = 1.1052538443849467D;
            // 
            // xrTableCell26
            // 
            this.xrTableCell26.BackColor = System.Drawing.Color.White;
            this.xrTableCell26.Borders = ((DevExpress.XtraPrinting.BorderSide)((((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top) 
            | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrTableCell26.BorderWidth = 1F;
            this.xrTableCell26.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[date_cash_supply]")});
            this.xrTableCell26.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold);
            this.xrTableCell26.ForeColor = System.Drawing.Color.Black;
            this.xrTableCell26.Multiline = true;
            this.xrTableCell26.Name = "xrTableCell26";
            this.xrTableCell26.StylePriority.UseBackColor = false;
            this.xrTableCell26.StylePriority.UseBorders = false;
            this.xrTableCell26.StylePriority.UseBorderWidth = false;
            this.xrTableCell26.StylePriority.UseFont = false;
            this.xrTableCell26.StylePriority.UseForeColor = false;
            this.xrTableCell26.StylePriority.UseTextAlignment = false;
            this.xrTableCell26.Text = "تاريخ الصرف ";
            this.xrTableCell26.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.xrTableCell26.Weight = 1.1409217259203106D;
            // 
            // bottomMarginBand1
            // 
            this.bottomMarginBand1.HeightF = 0F;
            this.bottomMarginBand1.Name = "bottomMarginBand1";
            // 
            // ReportHeader
            // 
            this.ReportHeader.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrLabel_Main_name_RP_Cash_exchange,
            this.dtp_Tow_RP_cash_supply,
            this.txt_Storg_RP_cash_supply,
            this.lbl_Storg_RP_cash_supply,
            this.lbl_dtp_Tow_RP_cash_supply,
            this.dtp_One_RP_cash_supply,
            this.lbl_dtp_One_RP_cash_supply});
            this.ReportHeader.HeightF = 208.3333F;
            this.ReportHeader.Name = "ReportHeader";
            // 
            // xrLabel_Main_name_RP_Cash_exchange
            // 
            this.xrLabel_Main_name_RP_Cash_exchange.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel_Main_name_RP_Cash_exchange.LocationFloat = new DevExpress.Utils.PointFloat(308.514F, 56.87501F);
            this.xrLabel_Main_name_RP_Cash_exchange.Multiline = true;
            this.xrLabel_Main_name_RP_Cash_exchange.Name = "xrLabel_Main_name_RP_Cash_exchange";
            this.xrLabel_Main_name_RP_Cash_exchange.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel_Main_name_RP_Cash_exchange.SizeF = new System.Drawing.SizeF(216.4305F, 32.375F);
            this.xrLabel_Main_name_RP_Cash_exchange.StylePriority.UseFont = false;
            this.xrLabel_Main_name_RP_Cash_exchange.StylePriority.UseTextAlignment = false;
            this.xrLabel_Main_name_RP_Cash_exchange.Text = "تقارير التوريد النقدي";
            this.xrLabel_Main_name_RP_Cash_exchange.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            // 
            // dtp_Tow_RP_cash_supply
            // 
            this.dtp_Tow_RP_cash_supply.Borders = ((DevExpress.XtraPrinting.BorderSide)(((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.dtp_Tow_RP_cash_supply.BorderWidth = 2F;
            this.dtp_Tow_RP_cash_supply.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Bold);
            this.dtp_Tow_RP_cash_supply.ForeColor = System.Drawing.Color.Red;
            this.dtp_Tow_RP_cash_supply.LocationFloat = new DevExpress.Utils.PointFloat(258.5456F, 118.6111F);
            this.dtp_Tow_RP_cash_supply.Multiline = true;
            this.dtp_Tow_RP_cash_supply.Name = "dtp_Tow_RP_cash_supply";
            this.dtp_Tow_RP_cash_supply.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.dtp_Tow_RP_cash_supply.SizeF = new System.Drawing.SizeF(189.62F, 29.72F);
            this.dtp_Tow_RP_cash_supply.StylePriority.UseBorders = false;
            this.dtp_Tow_RP_cash_supply.StylePriority.UseBorderWidth = false;
            this.dtp_Tow_RP_cash_supply.StylePriority.UseFont = false;
            this.dtp_Tow_RP_cash_supply.StylePriority.UseForeColor = false;
            this.dtp_Tow_RP_cash_supply.StylePriority.UseTextAlignment = false;
            this.dtp_Tow_RP_cash_supply.Text = "Label1";
            this.dtp_Tow_RP_cash_supply.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.dtp_Tow_RP_cash_supply.TextFormatString = "{0:M/d/yyyy}";
            // 
            // txt_Storg_RP_cash_supply
            // 
            this.txt_Storg_RP_cash_supply.Borders = ((DevExpress.XtraPrinting.BorderSide)(((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.txt_Storg_RP_cash_supply.BorderWidth = 2F;
            this.txt_Storg_RP_cash_supply.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Bold);
            this.txt_Storg_RP_cash_supply.ForeColor = System.Drawing.Color.Red;
            this.txt_Storg_RP_cash_supply.LocationFloat = new DevExpress.Utils.PointFloat(23.68021F, 118.6111F);
            this.txt_Storg_RP_cash_supply.Multiline = true;
            this.txt_Storg_RP_cash_supply.Name = "txt_Storg_RP_cash_supply";
            this.txt_Storg_RP_cash_supply.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.txt_Storg_RP_cash_supply.SizeF = new System.Drawing.SizeF(156.2773F, 29.72221F);
            this.txt_Storg_RP_cash_supply.StylePriority.UseBorders = false;
            this.txt_Storg_RP_cash_supply.StylePriority.UseBorderWidth = false;
            this.txt_Storg_RP_cash_supply.StylePriority.UseFont = false;
            this.txt_Storg_RP_cash_supply.StylePriority.UseForeColor = false;
            this.txt_Storg_RP_cash_supply.StylePriority.UseTextAlignment = false;
            this.txt_Storg_RP_cash_supply.Text = "Label1";
            this.txt_Storg_RP_cash_supply.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // lbl_Storg_RP_cash_supply
            // 
            this.lbl_Storg_RP_cash_supply.Borders = ((DevExpress.XtraPrinting.BorderSide)(((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.lbl_Storg_RP_cash_supply.BorderWidth = 2F;
            this.lbl_Storg_RP_cash_supply.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Bold);
            this.lbl_Storg_RP_cash_supply.LocationFloat = new DevExpress.Utils.PointFloat(179.9575F, 118.6111F);
            this.lbl_Storg_RP_cash_supply.Multiline = true;
            this.lbl_Storg_RP_cash_supply.Name = "lbl_Storg_RP_cash_supply";
            this.lbl_Storg_RP_cash_supply.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.lbl_Storg_RP_cash_supply.SizeF = new System.Drawing.SizeF(78.58807F, 29.72221F);
            this.lbl_Storg_RP_cash_supply.StylePriority.UseBorders = false;
            this.lbl_Storg_RP_cash_supply.StylePriority.UseBorderWidth = false;
            this.lbl_Storg_RP_cash_supply.StylePriority.UseFont = false;
            this.lbl_Storg_RP_cash_supply.StylePriority.UseTextAlignment = false;
            this.lbl_Storg_RP_cash_supply.Text = "الصناديق";
            this.lbl_Storg_RP_cash_supply.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // lbl_dtp_Tow_RP_cash_supply
            // 
            this.lbl_dtp_Tow_RP_cash_supply.Borders = ((DevExpress.XtraPrinting.BorderSide)(((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.lbl_dtp_Tow_RP_cash_supply.BorderWidth = 2F;
            this.lbl_dtp_Tow_RP_cash_supply.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Bold);
            this.lbl_dtp_Tow_RP_cash_supply.LocationFloat = new DevExpress.Utils.PointFloat(448.1657F, 118.6111F);
            this.lbl_dtp_Tow_RP_cash_supply.Multiline = true;
            this.lbl_dtp_Tow_RP_cash_supply.Name = "lbl_dtp_Tow_RP_cash_supply";
            this.lbl_dtp_Tow_RP_cash_supply.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.lbl_dtp_Tow_RP_cash_supply.SizeF = new System.Drawing.SizeF(68.66211F, 29.72221F);
            this.lbl_dtp_Tow_RP_cash_supply.StylePriority.UseBorders = false;
            this.lbl_dtp_Tow_RP_cash_supply.StylePriority.UseBorderWidth = false;
            this.lbl_dtp_Tow_RP_cash_supply.StylePriority.UseFont = false;
            this.lbl_dtp_Tow_RP_cash_supply.StylePriority.UseTextAlignment = false;
            this.lbl_dtp_Tow_RP_cash_supply.Text = "الى تاريخ";
            this.lbl_dtp_Tow_RP_cash_supply.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // dtp_One_RP_cash_supply
            // 
            this.dtp_One_RP_cash_supply.Borders = ((DevExpress.XtraPrinting.BorderSide)(((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.dtp_One_RP_cash_supply.BorderWidth = 2F;
            this.dtp_One_RP_cash_supply.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Bold);
            this.dtp_One_RP_cash_supply.ForeColor = System.Drawing.Color.Red;
            this.dtp_One_RP_cash_supply.LocationFloat = new DevExpress.Utils.PointFloat(516.8279F, 118.6111F);
            this.dtp_One_RP_cash_supply.Multiline = true;
            this.dtp_One_RP_cash_supply.Name = "dtp_One_RP_cash_supply";
            this.dtp_One_RP_cash_supply.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.dtp_One_RP_cash_supply.SizeF = new System.Drawing.SizeF(189.616F, 29.72221F);
            this.dtp_One_RP_cash_supply.StylePriority.UseBorders = false;
            this.dtp_One_RP_cash_supply.StylePriority.UseBorderWidth = false;
            this.dtp_One_RP_cash_supply.StylePriority.UseFont = false;
            this.dtp_One_RP_cash_supply.StylePriority.UseForeColor = false;
            this.dtp_One_RP_cash_supply.StylePriority.UseTextAlignment = false;
            this.dtp_One_RP_cash_supply.Text = "Label1";
            this.dtp_One_RP_cash_supply.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.dtp_One_RP_cash_supply.TextFormatString = "{0:M/d/yyyy}";
            // 
            // lbl_dtp_One_RP_cash_supply
            // 
            this.lbl_dtp_One_RP_cash_supply.Borders = ((DevExpress.XtraPrinting.BorderSide)((((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top) 
            | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.lbl_dtp_One_RP_cash_supply.BorderWidth = 2F;
            this.lbl_dtp_One_RP_cash_supply.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Bold);
            this.lbl_dtp_One_RP_cash_supply.LocationFloat = new DevExpress.Utils.PointFloat(706.4437F, 118.6111F);
            this.lbl_dtp_One_RP_cash_supply.Multiline = true;
            this.lbl_dtp_One_RP_cash_supply.Name = "lbl_dtp_One_RP_cash_supply";
            this.lbl_dtp_One_RP_cash_supply.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.lbl_dtp_One_RP_cash_supply.SizeF = new System.Drawing.SizeF(85.81934F, 29.72221F);
            this.lbl_dtp_One_RP_cash_supply.StylePriority.UseBorders = false;
            this.lbl_dtp_One_RP_cash_supply.StylePriority.UseBorderWidth = false;
            this.lbl_dtp_One_RP_cash_supply.StylePriority.UseFont = false;
            this.lbl_dtp_One_RP_cash_supply.StylePriority.UseTextAlignment = false;
            this.lbl_dtp_One_RP_cash_supply.Text = "من تاريخ";
            this.lbl_dtp_One_RP_cash_supply.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // PageHeader
            // 
            this.PageHeader.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrTable4_RP_Cash_supply});
            this.PageHeader.HeightF = 33.33333F;
            this.PageHeader.Name = "PageHeader";
            // 
            // xrTable4_RP_Cash_supply
            // 
            this.xrTable4_RP_Cash_supply.AnchorVertical = DevExpress.XtraReports.UI.VerticalAnchorStyles.Top;
            this.xrTable4_RP_Cash_supply.LocationFloat = new DevExpress.Utils.PointFloat(0F, 0F);
            this.xrTable4_RP_Cash_supply.Name = "xrTable4_RP_Cash_supply";
            this.xrTable4_RP_Cash_supply.Rows.AddRange(new DevExpress.XtraReports.UI.XRTableRow[] {
            this.xrTableRow4});
            this.xrTable4_RP_Cash_supply.SizeF = new System.Drawing.SizeF(809F, 32.2917F);
            // 
            // xrTableRow4
            // 
            this.xrTableRow4.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.xrTableCell21,
            this.xrTableCell20,
            this.xrTableCell19,
            this.xrTableCell18,
            this.xrTableCell17,
            this.xrTableCell16,
            this.xrTableCell12,
            this.xrTableCell13,
            this.Table_RP_cash_supply});
            this.xrTableRow4.Name = "xrTableRow4";
            this.xrTableRow4.Weight = 1D;
            // 
            // xrTableCell21
            // 
            this.xrTableCell21.BackColor = System.Drawing.Color.Gray;
            this.xrTableCell21.Borders = ((DevExpress.XtraPrinting.BorderSide)((((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top) 
            | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrTableCell21.BorderWidth = 2F;
            this.xrTableCell21.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Bold);
            this.xrTableCell21.ForeColor = System.Drawing.Color.White;
            this.xrTableCell21.Multiline = true;
            this.xrTableCell21.Name = "xrTableCell21";
            this.xrTableCell21.StylePriority.UseBackColor = false;
            this.xrTableCell21.StylePriority.UseBorders = false;
            this.xrTableCell21.StylePriority.UseBorderWidth = false;
            this.xrTableCell21.StylePriority.UseFont = false;
            this.xrTableCell21.StylePriority.UseForeColor = false;
            this.xrTableCell21.StylePriority.UseTextAlignment = false;
            this.xrTableCell21.Text = "اسم الموظف";
            this.xrTableCell21.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.xrTableCell21.Weight = 1D;
            // 
            // xrTableCell20
            // 
            this.xrTableCell20.BackColor = System.Drawing.Color.Gray;
            this.xrTableCell20.Borders = ((DevExpress.XtraPrinting.BorderSide)((((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top) 
            | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrTableCell20.BorderWidth = 2F;
            this.xrTableCell20.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Bold);
            this.xrTableCell20.ForeColor = System.Drawing.Color.White;
            this.xrTableCell20.Multiline = true;
            this.xrTableCell20.Name = "xrTableCell20";
            this.xrTableCell20.StylePriority.UseBackColor = false;
            this.xrTableCell20.StylePriority.UseBorders = false;
            this.xrTableCell20.StylePriority.UseBorderWidth = false;
            this.xrTableCell20.StylePriority.UseFont = false;
            this.xrTableCell20.StylePriority.UseForeColor = false;
            this.xrTableCell20.StylePriority.UseTextAlignment = false;
            this.xrTableCell20.Text = "ملاحظة";
            this.xrTableCell20.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.xrTableCell20.Weight = 0.826174119494312D;
            // 
            // xrTableCell19
            // 
            this.xrTableCell19.BackColor = System.Drawing.Color.Gray;
            this.xrTableCell19.Borders = ((DevExpress.XtraPrinting.BorderSide)((((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top) 
            | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrTableCell19.BorderWidth = 2F;
            this.xrTableCell19.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Bold);
            this.xrTableCell19.ForeColor = System.Drawing.Color.White;
            this.xrTableCell19.Multiline = true;
            this.xrTableCell19.Name = "xrTableCell19";
            this.xrTableCell19.StylePriority.UseBackColor = false;
            this.xrTableCell19.StylePriority.UseBorders = false;
            this.xrTableCell19.StylePriority.UseBorderWidth = false;
            this.xrTableCell19.StylePriority.UseFont = false;
            this.xrTableCell19.StylePriority.UseForeColor = false;
            this.xrTableCell19.StylePriority.UseTextAlignment = false;
            this.xrTableCell19.Text = "الصندوق";
            this.xrTableCell19.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.xrTableCell19.Weight = 0.90612477985094453D;
            // 
            // xrTableCell18
            // 
            this.xrTableCell18.BackColor = System.Drawing.Color.Gray;
            this.xrTableCell18.Borders = ((DevExpress.XtraPrinting.BorderSide)((((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top) 
            | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrTableCell18.BorderWidth = 2F;
            this.xrTableCell18.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Bold);
            this.xrTableCell18.ForeColor = System.Drawing.Color.White;
            this.xrTableCell18.Multiline = true;
            this.xrTableCell18.Name = "xrTableCell18";
            this.xrTableCell18.StylePriority.UseBackColor = false;
            this.xrTableCell18.StylePriority.UseBorders = false;
            this.xrTableCell18.StylePriority.UseBorderWidth = false;
            this.xrTableCell18.StylePriority.UseFont = false;
            this.xrTableCell18.StylePriority.UseForeColor = false;
            this.xrTableCell18.StylePriority.UseTextAlignment = false;
            this.xrTableCell18.Text = "الرصيد المتبقي";
            this.xrTableCell18.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.xrTableCell18.Weight = 0.965331955804813D;
            // 
            // xrTableCell17
            // 
            this.xrTableCell17.BackColor = System.Drawing.Color.Gray;
            this.xrTableCell17.Borders = ((DevExpress.XtraPrinting.BorderSide)((((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top) 
            | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrTableCell17.BorderWidth = 2F;
            this.xrTableCell17.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Bold);
            this.xrTableCell17.ForeColor = System.Drawing.Color.White;
            this.xrTableCell17.Multiline = true;
            this.xrTableCell17.Name = "xrTableCell17";
            this.xrTableCell17.StylePriority.UseBackColor = false;
            this.xrTableCell17.StylePriority.UseBorders = false;
            this.xrTableCell17.StylePriority.UseBorderWidth = false;
            this.xrTableCell17.StylePriority.UseFont = false;
            this.xrTableCell17.StylePriority.UseForeColor = false;
            this.xrTableCell17.StylePriority.UseTextAlignment = false;
            this.xrTableCell17.Text = "الرصيد الحالي";
            this.xrTableCell17.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.xrTableCell17.Weight = 1.0010711330418534D;
            // 
            // xrTableCell16
            // 
            this.xrTableCell16.BackColor = System.Drawing.Color.Gray;
            this.xrTableCell16.Borders = ((DevExpress.XtraPrinting.BorderSide)((((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top) 
            | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrTableCell16.BorderWidth = 2F;
            this.xrTableCell16.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Bold);
            this.xrTableCell16.ForeColor = System.Drawing.Color.White;
            this.xrTableCell16.Multiline = true;
            this.xrTableCell16.Name = "xrTableCell16";
            this.xrTableCell16.StylePriority.UseBackColor = false;
            this.xrTableCell16.StylePriority.UseBorders = false;
            this.xrTableCell16.StylePriority.UseBorderWidth = false;
            this.xrTableCell16.StylePriority.UseFont = false;
            this.xrTableCell16.StylePriority.UseForeColor = false;
            this.xrTableCell16.StylePriority.UseTextAlignment = false;
            this.xrTableCell16.Text = "المبلغ المورد";
            this.xrTableCell16.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.xrTableCell16.Weight = 0.900416200918379D;
            // 
            // xrTableCell12
            // 
            this.xrTableCell12.BackColor = System.Drawing.Color.Gray;
            this.xrTableCell12.Borders = ((DevExpress.XtraPrinting.BorderSide)((((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top) 
            | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrTableCell12.BorderWidth = 2F;
            this.xrTableCell12.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Bold);
            this.xrTableCell12.ForeColor = System.Drawing.Color.White;
            this.xrTableCell12.Multiline = true;
            this.xrTableCell12.Name = "xrTableCell12";
            this.xrTableCell12.StylePriority.UseBackColor = false;
            this.xrTableCell12.StylePriority.UseBorders = false;
            this.xrTableCell12.StylePriority.UseBorderWidth = false;
            this.xrTableCell12.StylePriority.UseFont = false;
            this.xrTableCell12.StylePriority.UseForeColor = false;
            this.xrTableCell12.StylePriority.UseTextAlignment = false;
            this.xrTableCell12.Text = "اسم المستفيد";
            this.xrTableCell12.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.xrTableCell12.Weight = 1.1547062405844408D;
            // 
            // xrTableCell13
            // 
            this.xrTableCell13.BackColor = System.Drawing.Color.Gray;
            this.xrTableCell13.Borders = ((DevExpress.XtraPrinting.BorderSide)((((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top) 
            | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrTableCell13.BorderWidth = 2F;
            this.xrTableCell13.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Bold);
            this.xrTableCell13.ForeColor = System.Drawing.Color.White;
            this.xrTableCell13.Multiline = true;
            this.xrTableCell13.Name = "xrTableCell13";
            this.xrTableCell13.StylePriority.UseBackColor = false;
            this.xrTableCell13.StylePriority.UseBorders = false;
            this.xrTableCell13.StylePriority.UseBorderWidth = false;
            this.xrTableCell13.StylePriority.UseFont = false;
            this.xrTableCell13.StylePriority.UseForeColor = false;
            this.xrTableCell13.StylePriority.UseTextAlignment = false;
            this.xrTableCell13.Text = "نوع المستفيد";
            this.xrTableCell13.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.xrTableCell13.Weight = 1.1052545233916293D;
            // 
            // Table_RP_cash_supply
            // 
            this.Table_RP_cash_supply.BackColor = System.Drawing.Color.Gray;
            this.Table_RP_cash_supply.Borders = ((DevExpress.XtraPrinting.BorderSide)((((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top) 
            | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.Table_RP_cash_supply.BorderWidth = 2F;
            this.Table_RP_cash_supply.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Bold);
            this.Table_RP_cash_supply.ForeColor = System.Drawing.Color.White;
            this.Table_RP_cash_supply.Multiline = true;
            this.Table_RP_cash_supply.Name = "Table_RP_cash_supply";
            this.Table_RP_cash_supply.StylePriority.UseBackColor = false;
            this.Table_RP_cash_supply.StylePriority.UseBorders = false;
            this.Table_RP_cash_supply.StylePriority.UseBorderWidth = false;
            this.Table_RP_cash_supply.StylePriority.UseFont = false;
            this.Table_RP_cash_supply.StylePriority.UseForeColor = false;
            this.Table_RP_cash_supply.StylePriority.UseTextAlignment = false;
            this.Table_RP_cash_supply.Text = "تاريخ التوريد ";
            this.Table_RP_cash_supply.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.Table_RP_cash_supply.Weight = 1.140921046913628D;
            // 
            // ReportFooter
            // 
            this.ReportFooter.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrLine2,
            this.xrtxtRP_amount_supply_written,
            this.lbl_xrtxtRP_amount_supply_written,
            this.xrtxtRP_total_supply,
            this.lblxrtxtRP_total_supply,
            this.xrtxtRP_num_pross_RP_Cash_supply,
            this.lbl_xrtxtRP_num_pross_RP_Cash_supply,
            this.xrShape3_RP_cash_supply,
            this.xrShape_RP_Cash_supply});
            this.ReportFooter.HeightF = 235.4167F;
            this.ReportFooter.Name = "ReportFooter";
            // 
            // xrLine2
            // 
            this.xrLine2.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.xrLine2.BorderWidth = 0F;
            this.xrLine2.LineWidth = 2F;
            this.xrLine2.LocationFloat = new DevExpress.Utils.PointFloat(0F, 21.45834F);
            this.xrLine2.Name = "xrLine2";
            this.xrLine2.SizeF = new System.Drawing.SizeF(809F, 15.99998F);
            this.xrLine2.StylePriority.UseBorders = false;
            this.xrLine2.StylePriority.UseBorderWidth = false;
            // 
            // xrtxtRP_amount_supply_written
            // 
            this.xrtxtRP_amount_supply_written.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "")});
            this.xrtxtRP_amount_supply_written.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold);
            this.xrtxtRP_amount_supply_written.ForeColor = System.Drawing.Color.Red;
            this.xrtxtRP_amount_supply_written.LocationFloat = new DevExpress.Utils.PointFloat(206.4307F, 170.5416F);
            this.xrtxtRP_amount_supply_written.Multiline = true;
            this.xrtxtRP_amount_supply_written.Name = "xrtxtRP_amount_supply_written";
            this.xrtxtRP_amount_supply_written.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrtxtRP_amount_supply_written.SizeF = new System.Drawing.SizeF(239.9869F, 23F);
            this.xrtxtRP_amount_supply_written.StylePriority.UseFont = false;
            this.xrtxtRP_amount_supply_written.StylePriority.UseForeColor = false;
            this.xrtxtRP_amount_supply_written.StylePriority.UseTextAlignment = false;
            this.xrtxtRP_amount_supply_written.Text = "المبلغ المصروف كتابة";
            this.xrtxtRP_amount_supply_written.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // lbl_xrtxtRP_amount_supply_written
            // 
            this.lbl_xrtxtRP_amount_supply_written.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold);
            this.lbl_xrtxtRP_amount_supply_written.LocationFloat = new DevExpress.Utils.PointFloat(523.4117F, 170.5416F);
            this.lbl_xrtxtRP_amount_supply_written.Multiline = true;
            this.lbl_xrtxtRP_amount_supply_written.Name = "lbl_xrtxtRP_amount_supply_written";
            this.lbl_xrtxtRP_amount_supply_written.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.lbl_xrtxtRP_amount_supply_written.SizeF = new System.Drawing.SizeF(134.9924F, 23F);
            this.lbl_xrtxtRP_amount_supply_written.StylePriority.UseFont = false;
            this.lbl_xrtxtRP_amount_supply_written.StylePriority.UseTextAlignment = false;
            this.lbl_xrtxtRP_amount_supply_written.Text = " :المبلغ المصروف كتابة ";
            this.lbl_xrtxtRP_amount_supply_written.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // xrtxtRP_total_supply
            // 
            this.xrtxtRP_total_supply.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold);
            this.xrtxtRP_total_supply.ForeColor = System.Drawing.Color.Red;
            this.xrtxtRP_total_supply.LocationFloat = new DevExpress.Utils.PointFloat(206.4307F, 86.33337F);
            this.xrtxtRP_total_supply.Multiline = true;
            this.xrtxtRP_total_supply.Name = "xrtxtRP_total_supply";
            this.xrtxtRP_total_supply.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrtxtRP_total_supply.SizeF = new System.Drawing.SizeF(102.0833F, 23F);
            this.xrtxtRP_total_supply.StylePriority.UseFont = false;
            this.xrtxtRP_total_supply.StylePriority.UseForeColor = false;
            this.xrtxtRP_total_supply.StylePriority.UseTextAlignment = false;
            this.xrtxtRP_total_supply.Text = ":اجمالي الصرف";
            this.xrtxtRP_total_supply.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // lblxrtxtRP_total_supply
            // 
            this.lblxrtxtRP_total_supply.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold);
            this.lblxrtxtRP_total_supply.LocationFloat = new DevExpress.Utils.PointFloat(308.514F, 86.33337F);
            this.lblxrtxtRP_total_supply.Multiline = true;
            this.lblxrtxtRP_total_supply.Name = "lblxrtxtRP_total_supply";
            this.lblxrtxtRP_total_supply.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.lblxrtxtRP_total_supply.SizeF = new System.Drawing.SizeF(102.0833F, 23F);
            this.lblxrtxtRP_total_supply.StylePriority.UseFont = false;
            this.lblxrtxtRP_total_supply.StylePriority.UseTextAlignment = false;
            this.lblxrtxtRP_total_supply.Text = ":اجمالي الصرف";
            this.lblxrtxtRP_total_supply.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // xrtxtRP_num_pross_RP_Cash_supply
            // 
            this.xrtxtRP_num_pross_RP_Cash_supply.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "sumCount([Curr_balance])")});
            this.xrtxtRP_num_pross_RP_Cash_supply.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold);
            this.xrtxtRP_num_pross_RP_Cash_supply.ForeColor = System.Drawing.Color.Red;
            this.xrtxtRP_num_pross_RP_Cash_supply.LocationFloat = new DevExpress.Utils.PointFloat(523.4117F, 86.33337F);
            this.xrtxtRP_num_pross_RP_Cash_supply.Multiline = true;
            this.xrtxtRP_num_pross_RP_Cash_supply.Name = "xrtxtRP_num_pross_RP_Cash_supply";
            this.xrtxtRP_num_pross_RP_Cash_supply.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrtxtRP_num_pross_RP_Cash_supply.SizeF = new System.Drawing.SizeF(100F, 23F);
            this.xrtxtRP_num_pross_RP_Cash_supply.StylePriority.UseFont = false;
            this.xrtxtRP_num_pross_RP_Cash_supply.StylePriority.UseForeColor = false;
            this.xrtxtRP_num_pross_RP_Cash_supply.StylePriority.UseTextAlignment = false;
            xrSummary1.Running = DevExpress.XtraReports.UI.SummaryRunning.Report;
            this.xrtxtRP_num_pross_RP_Cash_supply.Summary = xrSummary1;
            this.xrtxtRP_num_pross_RP_Cash_supply.Text = "عدد العمليات ";
            this.xrtxtRP_num_pross_RP_Cash_supply.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // lbl_xrtxtRP_num_pross_RP_Cash_supply
            // 
            this.lbl_xrtxtRP_num_pross_RP_Cash_supply.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold);
            this.lbl_xrtxtRP_num_pross_RP_Cash_supply.LocationFloat = new DevExpress.Utils.PointFloat(623.4117F, 86.33337F);
            this.lbl_xrtxtRP_num_pross_RP_Cash_supply.Multiline = true;
            this.lbl_xrtxtRP_num_pross_RP_Cash_supply.Name = "lbl_xrtxtRP_num_pross_RP_Cash_supply";
            this.lbl_xrtxtRP_num_pross_RP_Cash_supply.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.lbl_xrtxtRP_num_pross_RP_Cash_supply.SizeF = new System.Drawing.SizeF(99.99988F, 23F);
            this.lbl_xrtxtRP_num_pross_RP_Cash_supply.StylePriority.UseFont = false;
            this.lbl_xrtxtRP_num_pross_RP_Cash_supply.StylePriority.UseTextAlignment = false;
            this.lbl_xrtxtRP_num_pross_RP_Cash_supply.Text = ":عدد العمليات";
            this.lbl_xrtxtRP_num_pross_RP_Cash_supply.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // xrShape3_RP_cash_supply
            // 
            this.xrShape3_RP_cash_supply.FillColor = System.Drawing.Color.Wheat;
            this.xrShape3_RP_cash_supply.LineWidth = 2;
            this.xrShape3_RP_cash_supply.LocationFloat = new DevExpress.Utils.PointFloat(152.389F, 159.7482F);
            this.xrShape3_RP_cash_supply.Name = "xrShape3_RP_cash_supply";
            shapeRectangle1.Fillet = 50;
            this.xrShape3_RP_cash_supply.Shape = shapeRectangle1;
            this.xrShape3_RP_cash_supply.SizeF = new System.Drawing.SizeF(528.7493F, 46.25002F);
            // 
            // xrShape_RP_Cash_supply
            // 
            this.xrShape_RP_Cash_supply.FillColor = System.Drawing.Color.Wheat;
            this.xrShape_RP_Cash_supply.LineWidth = 2;
            this.xrShape_RP_Cash_supply.LocationFloat = new DevExpress.Utils.PointFloat(89.88889F, 68.62504F);
            this.xrShape_RP_Cash_supply.Name = "xrShape_RP_Cash_supply";
            shapeRectangle2.Fillet = 50;
            this.xrShape_RP_Cash_supply.Shape = shapeRectangle2;
            this.xrShape_RP_Cash_supply.SizeF = new System.Drawing.SizeF(657.8706F, 56.25001F);
            // 
            // PageFooter
            // 
            this.PageFooter.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrPageInfo_RP_cash_supply});
            this.PageFooter.HeightF = 61.45833F;
            this.PageFooter.Name = "PageFooter";
            // 
            // xrPageInfo_RP_cash_supply
            // 
            this.xrPageInfo_RP_cash_supply.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold);
            this.xrPageInfo_RP_cash_supply.LocationFloat = new DevExpress.Utils.PointFloat(349.8466F, 24.29167F);
            this.xrPageInfo_RP_cash_supply.Name = "xrPageInfo_RP_cash_supply";
            this.xrPageInfo_RP_cash_supply.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrPageInfo_RP_cash_supply.SizeF = new System.Drawing.SizeF(100F, 23F);
            this.xrPageInfo_RP_cash_supply.StylePriority.UseFont = false;
            this.xrPageInfo_RP_cash_supply.StylePriority.UseTextAlignment = false;
            this.xrPageInfo_RP_cash_supply.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            // 
            // xrCrossBandLine1
            // 
            this.xrCrossBandLine1.AnchorVertical = ((DevExpress.XtraReports.UI.VerticalAnchorStyles)((DevExpress.XtraReports.UI.VerticalAnchorStyles.Top | DevExpress.XtraReports.UI.VerticalAnchorStyles.Bottom)));
            this.xrCrossBandLine1.EndBand = this.ReportFooter;
            this.xrCrossBandLine1.EndPointFloat = new DevExpress.Utils.PointFloat(490.1718F, 124.875F);
            this.xrCrossBandLine1.Name = "xrCrossBandLine1";
            this.xrCrossBandLine1.StartBand = this.ReportFooter;
            this.xrCrossBandLine1.StartPointFloat = new DevExpress.Utils.PointFloat(490.1718F, 68.62504F);
            this.xrCrossBandLine1.WidthF = 3.125F;
            // 
            // xrCrossBandLine2
            // 
            this.xrCrossBandLine2.AnchorVertical = ((DevExpress.XtraReports.UI.VerticalAnchorStyles)((DevExpress.XtraReports.UI.VerticalAnchorStyles.Top | DevExpress.XtraReports.UI.VerticalAnchorStyles.Bottom)));
            this.xrCrossBandLine2.EndBand = this.ReportFooter;
            this.xrCrossBandLine2.EndPointFloat = new DevExpress.Utils.PointFloat(503.2985F, 205.9982F);
            this.xrCrossBandLine2.Name = "xrCrossBandLine2";
            this.xrCrossBandLine2.StartBand = this.ReportFooter;
            this.xrCrossBandLine2.StartPointFloat = new DevExpress.Utils.PointFloat(503.2985F, 159.7482F);
            this.xrCrossBandLine2.WidthF = 3.125F;
            // 
            // dataSet11
            // 
            this.dataSet11.DataSetName = "DataSet1";
            this.dataSet11.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // xr_RP_cash_supply
            // 
            this.Bands.AddRange(new DevExpress.XtraReports.UI.Band[] {
            this.topMarginBand1,
            this.detailBand1,
            this.bottomMarginBand1,
            this.ReportHeader,
            this.PageHeader,
            this.ReportFooter,
            this.PageFooter});
            this.ComponentStorage.AddRange(new System.ComponentModel.IComponent[] {
            this.dataSet11});
            this.CrossBandControls.AddRange(new DevExpress.XtraReports.UI.XRCrossBandControl[] {
            this.xrCrossBandLine2,
            this.xrCrossBandLine1});
            this.DataMember = "dt_RP_cash_supply";
            this.DataSource = this.dataSet11;
            this.Margins = new System.Drawing.Printing.Margins(7, 9, 0, 0);
            this.PageHeight = 1169;
            this.PageWidth = 827;
            this.PaperKind = System.Drawing.Printing.PaperKind.A4;
            this.Version = "21.2";
            ((System.ComponentModel.ISupportInitialize)(this.Table2_RP_cash_supply)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xrTable4_RP_Cash_supply)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSet11)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

        }
    }
}
