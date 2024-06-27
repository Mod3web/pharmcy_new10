namespace Manag_ph.Supplier.Report_Supp
{
    partial class Show_supp_data
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.pan_hed_show_sup = new System.Windows.Forms.Panel();
            this.btn_add_dt_Rp_sup_btn = new System.Windows.Forms.Button();
            this.label_sech_Rp_dt_sup = new DevExpress.XtraEditors.LabelControl();
            this.txt_sech_Rp_dt_sup = new System.Windows.Forms.TextBox();
            this.dgv_sech_dt_Rp_sup_dgv = new System.Windows.Forms.DataGridView();
            this.pan_hed_show_sup.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_sech_dt_Rp_sup_dgv)).BeginInit();
            this.SuspendLayout();
            // 
            // pan_hed_show_sup
            // 
            this.pan_hed_show_sup.Controls.Add(this.btn_add_dt_Rp_sup_btn);
            this.pan_hed_show_sup.Controls.Add(this.label_sech_Rp_dt_sup);
            this.pan_hed_show_sup.Controls.Add(this.txt_sech_Rp_dt_sup);
            this.pan_hed_show_sup.Dock = System.Windows.Forms.DockStyle.Top;
            this.pan_hed_show_sup.Location = new System.Drawing.Point(0, 0);
            this.pan_hed_show_sup.Name = "pan_hed_show_sup";
            this.pan_hed_show_sup.Size = new System.Drawing.Size(532, 70);
            this.pan_hed_show_sup.TabIndex = 2;
            // 
            // btn_add_dt_Rp_sup_btn
            // 
            this.btn_add_dt_Rp_sup_btn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(120)))), ((int)(((byte)(210)))));
            this.btn_add_dt_Rp_sup_btn.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold);
            this.btn_add_dt_Rp_sup_btn.ForeColor = System.Drawing.Color.White;
            this.btn_add_dt_Rp_sup_btn.Location = new System.Drawing.Point(12, 25);
            this.btn_add_dt_Rp_sup_btn.Name = "btn_add_dt_Rp_sup_btn";
            this.btn_add_dt_Rp_sup_btn.Size = new System.Drawing.Size(131, 28);
            this.btn_add_dt_Rp_sup_btn.TabIndex = 64;
            this.btn_add_dt_Rp_sup_btn.Text = "اظافة مورد";
            this.btn_add_dt_Rp_sup_btn.UseVisualStyleBackColor = false;
            this.btn_add_dt_Rp_sup_btn.Click += new System.EventHandler(this.Btn_add_dt_Rp_sup_btn_Click_2);
            // 
            // label_sech_Rp_dt_sup
            // 
            this.label_sech_Rp_dt_sup.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label_sech_Rp_dt_sup.Appearance.Font = new System.Drawing.Font("AGA Arabesque", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_sech_Rp_dt_sup.Appearance.ForeColor = System.Drawing.Color.Red;
            this.label_sech_Rp_dt_sup.Appearance.Options.UseFont = true;
            this.label_sech_Rp_dt_sup.Appearance.Options.UseForeColor = true;
            this.label_sech_Rp_dt_sup.Location = new System.Drawing.Point(483, 31);
            this.label_sech_Rp_dt_sup.Name = "label_sech_Rp_dt_sup";
            this.label_sech_Rp_dt_sup.Size = new System.Drawing.Size(27, 22);
            this.label_sech_Rp_dt_sup.TabIndex = 63;
            this.label_sech_Rp_dt_sup.Text = "بحث";
            // 
            // txt_sech_Rp_dt_sup
            // 
            this.txt_sech_Rp_dt_sup.Location = new System.Drawing.Point(178, 31);
            this.txt_sech_Rp_dt_sup.Name = "txt_sech_Rp_dt_sup";
            this.txt_sech_Rp_dt_sup.Size = new System.Drawing.Size(294, 20);
            this.txt_sech_Rp_dt_sup.TabIndex = 0;
            this.txt_sech_Rp_dt_sup.TextChanged += new System.EventHandler(this.Txt_sech_Rp_dt_sup_TextChanged);
            // 
            // dgv_sech_dt_Rp_sup_dgv
            // 
            this.dgv_sech_dt_Rp_sup_dgv.AllowUserToAddRows = false;
            this.dgv_sech_dt_Rp_sup_dgv.AllowUserToDeleteRows = false;
            this.dgv_sech_dt_Rp_sup_dgv.AllowUserToOrderColumns = true;
            this.dgv_sech_dt_Rp_sup_dgv.AllowUserToResizeColumns = false;
            this.dgv_sech_dt_Rp_sup_dgv.AllowUserToResizeRows = false;
            this.dgv_sech_dt_Rp_sup_dgv.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(200)))), ((int)(((byte)(230)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(200)))), ((int)(((byte)(90)))));
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgv_sech_dt_Rp_sup_dgv.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgv_sech_dt_Rp_sup_dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_sech_dt_Rp_sup_dgv.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgv_sech_dt_Rp_sup_dgv.Location = new System.Drawing.Point(0, 70);
            this.dgv_sech_dt_Rp_sup_dgv.Name = "dgv_sech_dt_Rp_sup_dgv";
            this.dgv_sech_dt_Rp_sup_dgv.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(200)))), ((int)(((byte)(90)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Black;
            this.dgv_sech_dt_Rp_sup_dgv.RowsDefaultCellStyle = dataGridViewCellStyle2;
            this.dgv_sech_dt_Rp_sup_dgv.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv_sech_dt_Rp_sup_dgv.Size = new System.Drawing.Size(532, 426);
            this.dgv_sech_dt_Rp_sup_dgv.TabIndex = 71;
            this.dgv_sech_dt_Rp_sup_dgv.DoubleClick += new System.EventHandler(this.Dgv_sech_dt_Rp_sup_dgv_DoubleClick_1);
            // 
            // Show_supp_data
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(532, 496);
            this.Controls.Add(this.dgv_sech_dt_Rp_sup_dgv);
            this.Controls.Add(this.pan_hed_show_sup);
            this.Name = "Show_supp_data";
            this.Text = "Show_supp_data";
            this.pan_hed_show_sup.ResumeLayout(false);
            this.pan_hed_show_sup.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_sech_dt_Rp_sup_dgv)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pan_hed_show_sup;
        private System.Windows.Forms.Button btn_add_dt_Rp_sup_btn;
        private DevExpress.XtraEditors.LabelControl label_sech_Rp_dt_sup;
        private System.Windows.Forms.TextBox txt_sech_Rp_dt_sup;
        public System.Windows.Forms.DataGridView dgv_sech_dt_Rp_sup_dgv;
    }
}