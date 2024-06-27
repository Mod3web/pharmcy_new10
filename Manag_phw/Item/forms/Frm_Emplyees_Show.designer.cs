
namespace Manag_ph.Item.forms
{
    partial class Frm_Emplyees_Show
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
            this.btn_close_Emplyee_btn = new System.Windows.Forms.Button();
            this.lbl_Emplyee = new DevExpress.XtraEditors.LabelControl();
            this.txt_Emplyee_serch = new System.Windows.Forms.TextBox();
            this.btn_OK_Emplyee_btn = new System.Windows.Forms.Button();
            this.dgv_Emplyee_dgv = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Emplyee_dgv)).BeginInit();
            this.SuspendLayout();
            // 
            // btn_close_Emplyee_btn
            // 
            this.btn_close_Emplyee_btn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(120)))), ((int)(((byte)(210)))));
            this.btn_close_Emplyee_btn.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold);
            this.btn_close_Emplyee_btn.ForeColor = System.Drawing.Color.White;
            this.btn_close_Emplyee_btn.Location = new System.Drawing.Point(91, 386);
            this.btn_close_Emplyee_btn.Name = "btn_close_Emplyee_btn";
            this.btn_close_Emplyee_btn.Size = new System.Drawing.Size(106, 31);
            this.btn_close_Emplyee_btn.TabIndex = 30;
            this.btn_close_Emplyee_btn.Text = "اغلاق";
            this.btn_close_Emplyee_btn.UseVisualStyleBackColor = false;
            this.btn_close_Emplyee_btn.Click += new System.EventHandler(this.btn_close_Emplyee_Click);
            // 
            // lbl_Emplyee
            // 
            this.lbl_Emplyee.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lbl_Emplyee.Appearance.Font = new System.Drawing.Font("AGA Arabesque", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_Emplyee.Appearance.ForeColor = System.Drawing.Color.Red;
            this.lbl_Emplyee.Appearance.Options.UseFont = true;
            this.lbl_Emplyee.Appearance.Options.UseForeColor = true;
            this.lbl_Emplyee.Location = new System.Drawing.Point(278, 13);
            this.lbl_Emplyee.Margin = new System.Windows.Forms.Padding(5);
            this.lbl_Emplyee.Name = "lbl_Emplyee";
            this.lbl_Emplyee.Size = new System.Drawing.Size(107, 22);
            this.lbl_Emplyee.TabIndex = 29;
            this.lbl_Emplyee.Text = "ادخل الاسم للبحث";
            // 
            // txt_Emplyee_serch
            // 
            this.txt_Emplyee_serch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txt_Emplyee_serch.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_Emplyee_serch.Location = new System.Drawing.Point(21, 13);
            this.txt_Emplyee_serch.Name = "txt_Emplyee_serch";
            this.txt_Emplyee_serch.Size = new System.Drawing.Size(240, 25);
            this.txt_Emplyee_serch.TabIndex = 28;
            this.txt_Emplyee_serch.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txt_Emplyee_serch.TextChanged += new System.EventHandler(this.txt_supper_serch_TextChanged);
            // 
            // btn_OK_Emplyee_btn
            // 
            this.btn_OK_Emplyee_btn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(120)))), ((int)(((byte)(210)))));
            this.btn_OK_Emplyee_btn.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold);
            this.btn_OK_Emplyee_btn.ForeColor = System.Drawing.Color.White;
            this.btn_OK_Emplyee_btn.Location = new System.Drawing.Point(236, 386);
            this.btn_OK_Emplyee_btn.Name = "btn_OK_Emplyee_btn";
            this.btn_OK_Emplyee_btn.Size = new System.Drawing.Size(106, 31);
            this.btn_OK_Emplyee_btn.TabIndex = 27;
            this.btn_OK_Emplyee_btn.Text = "موافق";
            this.btn_OK_Emplyee_btn.UseVisualStyleBackColor = false;
            this.btn_OK_Emplyee_btn.Click += new System.EventHandler(this.btn_OK_Emplyee_Click);
            // 
            // dgv_Emplyee_dgv
            // 
            this.dgv_Emplyee_dgv.AllowUserToAddRows = false;
            this.dgv_Emplyee_dgv.AllowUserToDeleteRows = false;
            this.dgv_Emplyee_dgv.AllowUserToResizeColumns = false;
            this.dgv_Emplyee_dgv.AllowUserToResizeRows = false;
            this.dgv_Emplyee_dgv.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(200)))), ((int)(((byte)(230)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(200)))), ((int)(((byte)(90)))));
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgv_Emplyee_dgv.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgv_Emplyee_dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_Emplyee_dgv.EnableHeadersVisualStyles = false;
            this.dgv_Emplyee_dgv.Location = new System.Drawing.Point(3, 51);
            this.dgv_Emplyee_dgv.Name = "dgv_Emplyee_dgv";
            this.dgv_Emplyee_dgv.ReadOnly = true;
            this.dgv_Emplyee_dgv.RowHeadersWidth = 51;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(200)))), ((int)(((byte)(90)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Black;
            this.dgv_Emplyee_dgv.RowsDefaultCellStyle = dataGridViewCellStyle2;
            this.dgv_Emplyee_dgv.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv_Emplyee_dgv.Size = new System.Drawing.Size(406, 333);
            this.dgv_Emplyee_dgv.TabIndex = 26;
            this.dgv_Emplyee_dgv.CellMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgv_Emplyee_CellMouseDoubleClick);
            // 
            // Frm_Emplyees_Show
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(413, 420);
            this.Controls.Add(this.btn_close_Emplyee_btn);
            this.Controls.Add(this.lbl_Emplyee);
            this.Controls.Add(this.txt_Emplyee_serch);
            this.Controls.Add(this.btn_OK_Emplyee_btn);
            this.Controls.Add(this.dgv_Emplyee_dgv);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Frm_Emplyees_Show";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Frm_Emplyees_Show";
            this.Load += new System.EventHandler(this.Frm_Emplyees_Show_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Emplyee_dgv)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_close_Emplyee_btn;
        public DevExpress.XtraEditors.LabelControl lbl_Emplyee;
        public System.Windows.Forms.TextBox txt_Emplyee_serch;
        private System.Windows.Forms.Button btn_OK_Emplyee_btn;
        public System.Windows.Forms.DataGridView dgv_Emplyee_dgv;
    }
}