﻿using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;

namespace Manag_ph.Sales.Report
{
    public partial class File_RP_footer_sales_Item_Date : DevExpress.XtraReports.UI.XtraReport
    {
        public File_RP_footer_sales_Item_Date()
        {
            InitializeComponent();
        }

        private void Detail_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {

        }
    }
}