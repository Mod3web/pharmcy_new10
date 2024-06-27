namespace Manag_ph.Item.forms
{
    partial class Item_serch_settle
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
            this.dgv_Item_serch_settl_dgv = new System.Windows.Forms.DataGridView();
            this.button1_btn = new System.Windows.Forms.Button();
            this.button2_btn = new System.Windows.Forms.Button();
            this.txt_serch = new System.Windows.Forms.TextBox();
            this.labelControl86 = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Item_serch_settl_dgv)).BeginInit();
            this.SuspendLayout();
            // 
            // dgv_Item_serch_settl_dgv
            // 
            this.dgv_Item_serch_settl_dgv.AllowDrop = true;
            this.dgv_Item_serch_settl_dgv.AllowUserToAddRows = false;
            this.dgv_Item_serch_settl_dgv.AllowUserToDeleteRows = false;
            this.dgv_Item_serch_settl_dgv.AllowUserToOrderColumns = true;
            this.dgv_Item_serch_settl_dgv.AllowUserToResizeColumns = false;
            this.dgv_Item_serch_settl_dgv.AllowUserToResizeRows = false;
            this.dgv_Item_serch_settl_dgv.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgv_Item_serch_settl_dgv.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(200)))), ((int)(((byte)(230)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(200)))), ((int)(((byte)(90)))));
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgv_Item_serch_settl_dgv.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgv_Item_serch_settl_dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_Item_serch_settl_dgv.EnableHeadersVisualStyles = false;
            this.dgv_Item_serch_settl_dgv.Location = new System.Drawing.Point(3, 53);
            this.dgv_Item_serch_settl_dgv.Name = "dgv_Item_serch_settl_dgv";
            this.dgv_Item_serch_settl_dgv.ReadOnly = true;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(200)))), ((int)(((byte)(90)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Black;
            this.dgv_Item_serch_settl_dgv.RowsDefaultCellStyle = dataGridViewCellStyle2;
            this.dgv_Item_serch_settl_dgv.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv_Item_serch_settl_dgv.Size = new System.Drawing.Size(612, 221);
            this.dgv_Item_serch_settl_dgv.TabIndex = 0;
            // 
            // button1_btn
            // 
            this.button1_btn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(120)))), ((int)(((byte)(210)))));
            this.button1_btn.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold);
            this.button1_btn.ForeColor = System.Drawing.Color.White;
            this.button1_btn.Location = new System.Drawing.Point(182, 275);
            this.button1_btn.Name = "button1_btn";
            this.button1_btn.Size = new System.Drawing.Size(106, 36);
            this.button1_btn.TabIndex = 1;
            this.button1_btn.Text = "موافق";
            this.button1_btn.UseVisualStyleBackColor = false;
            this.button1_btn.Click += new System.EventHandler(this.Button1_Click);
            // 
            // button2_btn
            // 
            this.button2_btn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(120)))), ((int)(((byte)(210)))));
            this.button2_btn.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold);
            this.button2_btn.ForeColor = System.Drawing.Color.White;
            this.button2_btn.Location = new System.Drawing.Point(331, 275);
            this.button2_btn.Name = "button2_btn";
            this.button2_btn.Size = new System.Drawing.Size(106, 36);
            this.button2_btn.TabIndex = 2;
            this.button2_btn.Text = "اغلاق";
            this.button2_btn.UseVisualStyleBackColor = false;
            this.button2_btn.Click += new System.EventHandler(this.Button2_Click);
            // 
            // txt_serch
            // 
            this.txt_serch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txt_serch.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_serch.ForeColor = System.Drawing.Color.Red;
            this.txt_serch.HideSelection = false;
            this.txt_serch.Location = new System.Drawing.Point(170, 12);
            this.txt_serch.Name = "txt_serch";
            this.txt_serch.Size = new System.Drawing.Size(308, 26);
            this.txt_serch.TabIndex = 61;
            this.txt_serch.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txt_serch.TextChanged += new System.EventHandler(this.Txt_serch_TextChanged);
            // 
            // labelControl86
            // 
            this.labelControl86.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.labelControl86.Appearance.Font = new System.Drawing.Font("AGA Arabesque", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl86.Appearance.ForeColor = System.Drawing.Color.Red;
            this.labelControl86.Appearance.Options.UseFont = true;
            this.labelControl86.Appearance.Options.UseForeColor = true;
            this.labelControl86.Location = new System.Drawing.Point(42, 13);
            this.labelControl86.Name = "labelControl86";
            this.labelControl86.Size = new System.Drawing.Size(122, 22);
            this.labelControl86.TabIndex = 60;
            this.labelControl86.Text = "ادخل اسم الصنف  :";
            // 
            // Item_serch_settle
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(618, 314);
            this.Controls.Add(this.txt_serch);
            this.Controls.Add(this.labelControl86);
            this.Controls.Add(this.button2_btn);
            this.Controls.Add(this.button1_btn);
            this.Controls.Add(this.dgv_Item_serch_settl_dgv);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(634, 353);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(634, 353);
            this.Name = "Item_serch_settle";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RightToLeftLayout = true;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Item_serch_settle";
            this.Load += new System.EventHandler(this.Item_serch_settle_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Item_serch_settl_dgv)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgv_Item_serch_settl_dgv;
        private System.Windows.Forms.Button button1_btn;
        private System.Windows.Forms.Button button2_btn;
        public System.Windows.Forms.TextBox txt_serch;
        public DevExpress.XtraEditors.LabelControl labelControl86;
    }
}