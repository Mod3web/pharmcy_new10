namespace Manag_ph.Item.forms
{
    partial class Frm_Backup
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
            this.btn_Browser_choose_backup = new System.Windows.Forms.Button();
            this.txt_backup_browser_txt = new System.Windows.Forms.TextBox();
            this.lbl_form_backup_and_retore_backup = new System.Windows.Forms.Label();
            this.btn_Restore_Backup_btn = new System.Windows.Forms.Button();
            this.btn_create_Backup_btn = new System.Windows.Forms.Button();
            this.progressPanel1_Backup = new DevExpress.XtraWaitForm.ProgressPanel();
            this.SuspendLayout();
            // 
            // btn_Browser_choose_backup
            // 
            this.btn_Browser_choose_backup.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(120)))), ((int)(((byte)(210)))));
            this.btn_Browser_choose_backup.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold);
            this.btn_Browser_choose_backup.ForeColor = System.Drawing.Color.White;
            this.btn_Browser_choose_backup.Location = new System.Drawing.Point(363, 73);
            this.btn_Browser_choose_backup.Name = "btn_Browser_choose_backup";
            this.btn_Browser_choose_backup.Size = new System.Drawing.Size(39, 26);
            this.btn_Browser_choose_backup.TabIndex = 51;
            this.btn_Browser_choose_backup.Text = "...";
            this.btn_Browser_choose_backup.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btn_Browser_choose_backup.UseVisualStyleBackColor = false;
            this.btn_Browser_choose_backup.Click += new System.EventHandler(this.Btn_Browser_choose_backup_Click);
            // 
            // txt_backup_browser_txt
            // 
            this.txt_backup_browser_txt.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold);
            this.txt_backup_browser_txt.Location = new System.Drawing.Point(46, 74);
            this.txt_backup_browser_txt.Name = "txt_backup_browser_txt";
            this.txt_backup_browser_txt.ReadOnly = true;
            this.txt_backup_browser_txt.Size = new System.Drawing.Size(311, 26);
            this.txt_backup_browser_txt.TabIndex = 50;
            // 
            // lbl_form_backup_and_retore_backup
            // 
            this.lbl_form_backup_and_retore_backup.AutoSize = true;
            this.lbl_form_backup_and_retore_backup.Font = new System.Drawing.Font("Arial Narrow", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_form_backup_and_retore_backup.ForeColor = System.Drawing.Color.Firebrick;
            this.lbl_form_backup_and_retore_backup.Location = new System.Drawing.Point(150, 31);
            this.lbl_form_backup_and_retore_backup.Name = "lbl_form_backup_and_retore_backup";
            this.lbl_form_backup_and_retore_backup.Size = new System.Drawing.Size(152, 22);
            this.lbl_form_backup_and_retore_backup.TabIndex = 49;
            this.lbl_form_backup_and_retore_backup.Text = " انشاء نسخة احتياطية";
            // 
            // btn_Restore_Backup_btn
            // 
            this.btn_Restore_Backup_btn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(120)))), ((int)(((byte)(210)))));
            this.btn_Restore_Backup_btn.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold);
            this.btn_Restore_Backup_btn.ForeColor = System.Drawing.Color.White;
            this.btn_Restore_Backup_btn.Location = new System.Drawing.Point(145, 126);
            this.btn_Restore_Backup_btn.Name = "btn_Restore_Backup_btn";
            this.btn_Restore_Backup_btn.Size = new System.Drawing.Size(137, 42);
            this.btn_Restore_Backup_btn.TabIndex = 48;
            this.btn_Restore_Backup_btn.Text = "إستعادة نسخة احتياطية";
            this.btn_Restore_Backup_btn.UseVisualStyleBackColor = false;
            this.btn_Restore_Backup_btn.Visible = false;
            this.btn_Restore_Backup_btn.Click += new System.EventHandler(this.Btn_Restore_Backup_btn_Click);
            // 
            // btn_create_Backup_btn
            // 
            this.btn_create_Backup_btn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(120)))), ((int)(((byte)(210)))));
            this.btn_create_Backup_btn.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold);
            this.btn_create_Backup_btn.ForeColor = System.Drawing.Color.White;
            this.btn_create_Backup_btn.Location = new System.Drawing.Point(151, 126);
            this.btn_create_Backup_btn.Name = "btn_create_Backup_btn";
            this.btn_create_Backup_btn.Size = new System.Drawing.Size(136, 42);
            this.btn_create_Backup_btn.TabIndex = 47;
            this.btn_create_Backup_btn.Text = "انشاء نسخة احتياطية";
            this.btn_create_Backup_btn.UseVisualStyleBackColor = false;
            this.btn_create_Backup_btn.Visible = false;
            this.btn_create_Backup_btn.Click += new System.EventHandler(this.Btn_create_Backup_btn_Click);
            // 
            // progressPanel1_Backup
            // 
            this.progressPanel1_Backup.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.progressPanel1_Backup.Appearance.Options.UseBackColor = true;
            this.progressPanel1_Backup.FrameCount = 5;
            this.progressPanel1_Backup.Location = new System.Drawing.Point(101, 66);
            this.progressPanel1_Backup.Name = "progressPanel1_Backup";
            this.progressPanel1_Backup.Size = new System.Drawing.Size(246, 66);
            this.progressPanel1_Backup.TabIndex = 52;
            this.progressPanel1_Backup.Text = "progressPanel1";
            this.progressPanel1_Backup.Visible = false;
            // 
            // Frm_Backup
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(448, 198);
            this.Controls.Add(this.progressPanel1_Backup);
            this.Controls.Add(this.btn_Browser_choose_backup);
            this.Controls.Add(this.txt_backup_browser_txt);
            this.Controls.Add(this.lbl_form_backup_and_retore_backup);
            this.Controls.Add(this.btn_Restore_Backup_btn);
            this.Controls.Add(this.btn_create_Backup_btn);
            this.MaximumSize = new System.Drawing.Size(464, 237);
            this.MinimumSize = new System.Drawing.Size(464, 237);
            this.Name = "Frm_Backup";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.Frm_Backup_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.Button btn_Browser_choose_backup;
        public System.Windows.Forms.TextBox txt_backup_browser_txt;
        public System.Windows.Forms.Label lbl_form_backup_and_retore_backup;
        private System.Windows.Forms.Button btn_Restore_Backup_btn;
        public System.Windows.Forms.Button btn_create_Backup_btn;
        public DevExpress.XtraWaitForm.ProgressPanel progressPanel1_Backup;
    }
}