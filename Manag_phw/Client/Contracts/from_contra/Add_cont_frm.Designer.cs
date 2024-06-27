namespace Manag_ph.Client.Contracts.from_contra
{
    partial class Add_cont_frm
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.txt_searsh_cont = new System.Windows.Forms.TextBox();
            this.labelControl72 = new DevExpress.XtraEditors.LabelControl();
            this.btn_Add_cont_btn = new System.Windows.Forms.Button();
            this.dgv_contar = new System.Windows.Forms.DataGridView();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_contar)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.txt_searsh_cont);
            this.panel1.Controls.Add(this.labelControl72);
            this.panel1.Controls.Add(this.btn_Add_cont_btn);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.panel1.Size = new System.Drawing.Size(689, 68);
            this.panel1.TabIndex = 67;
            // 
            // txt_searsh_cont
            // 
            this.txt_searsh_cont.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txt_searsh_cont.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_searsh_cont.Location = new System.Drawing.Point(174, 22);
            this.txt_searsh_cont.Name = "txt_searsh_cont";
            this.txt_searsh_cont.Size = new System.Drawing.Size(441, 25);
            this.txt_searsh_cont.TabIndex = 63;
            this.txt_searsh_cont.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txt_searsh_cont.TextChanged += new System.EventHandler(this.Txt_searsh_cont_TextChanged);
            // 
            // labelControl72
            // 
            this.labelControl72.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.labelControl72.Appearance.Font = new System.Drawing.Font("AGA Arabesque", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl72.Appearance.ForeColor = System.Drawing.Color.Red;
            this.labelControl72.Appearance.Options.UseFont = true;
            this.labelControl72.Appearance.Options.UseForeColor = true;
            this.labelControl72.Location = new System.Drawing.Point(633, 25);
            this.labelControl72.Name = "labelControl72";
            this.labelControl72.Size = new System.Drawing.Size(34, 22);
            this.labelControl72.TabIndex = 62;
            this.labelControl72.Text = "بحث:";
            // 
            // btn_Add_cont_btn
            // 
            this.btn_Add_cont_btn.Location = new System.Drawing.Point(12, 21);
            this.btn_Add_cont_btn.Name = "btn_Add_cont_btn";
            this.btn_Add_cont_btn.Size = new System.Drawing.Size(146, 32);
            this.btn_Add_cont_btn.TabIndex = 64;
            this.btn_Add_cont_btn.Text = "اضافة عقد عميل";
            this.btn_Add_cont_btn.UseVisualStyleBackColor = true;
            this.btn_Add_cont_btn.Click += new System.EventHandler(this.Btn_Add_cont_Click);
            // 
            // dgv_contar
            // 
            this.dgv_contar.AllowUserToAddRows = false;
            this.dgv_contar.AllowUserToDeleteRows = false;
            this.dgv_contar.AllowUserToOrderColumns = true;
            this.dgv_contar.AllowUserToResizeColumns = false;
            this.dgv_contar.AllowUserToResizeRows = false;
            this.dgv_contar.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(200)))), ((int)(((byte)(230)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(200)))), ((int)(((byte)(90)))));
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgv_contar.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgv_contar.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_contar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgv_contar.Location = new System.Drawing.Point(0, 68);
            this.dgv_contar.Name = "dgv_contar";
            this.dgv_contar.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(200)))), ((int)(((byte)(90)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Black;
            this.dgv_contar.RowsDefaultCellStyle = dataGridViewCellStyle2;
            this.dgv_contar.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv_contar.Size = new System.Drawing.Size(689, 319);
            this.dgv_contar.TabIndex = 68;
            // 
            // Add_cont_frm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(689, 387);
            this.Controls.Add(this.dgv_contar);
            this.Controls.Add(this.panel1);
            this.Name = "Add_cont_frm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Add_cont_frm";
            this.Load += new System.EventHandler(this.Add_cont_frm_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_contar)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox txt_searsh_cont;
        private DevExpress.XtraEditors.LabelControl labelControl72;
        private System.Windows.Forms.Button btn_Add_cont_btn;
        public System.Windows.Forms.DataGridView dgv_contar;
    }
}