namespace Manag_ph.Item.forms
{
    partial class fro_contra_and_clin
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
            this.txt_searsh_clin_and_cont = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btn_add_clin_to_cont_btn = new System.Windows.Forms.Button();
            this.btn_Add_cont_btn = new System.Windows.Forms.Button();
            this.labelControl72 = new DevExpress.XtraEditors.LabelControl();
            this.dgv_clin_and_contar_dgv = new System.Windows.Forms.DataGridView();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_clin_and_contar_dgv)).BeginInit();
            this.SuspendLayout();
            // 
            // txt_searsh_clin_and_cont
            // 
            this.txt_searsh_clin_and_cont.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txt_searsh_clin_and_cont.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_searsh_clin_and_cont.Location = new System.Drawing.Point(62, 20);
            this.txt_searsh_clin_and_cont.Name = "txt_searsh_clin_and_cont";
            this.txt_searsh_clin_and_cont.Size = new System.Drawing.Size(393, 25);
            this.txt_searsh_clin_and_cont.TabIndex = 59;
            this.txt_searsh_clin_and_cont.TextChanged += new System.EventHandler(this.Txt_searsh_clin_and_cont_TextChanged);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btn_add_clin_to_cont_btn);
            this.panel1.Controls.Add(this.btn_Add_cont_btn);
            this.panel1.Controls.Add(this.txt_searsh_clin_and_cont);
            this.panel1.Controls.Add(this.labelControl72);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(518, 89);
            this.panel1.TabIndex = 2;
            // 
            // btn_add_clin_to_cont_btn
            // 
            this.btn_add_clin_to_cont_btn.Location = new System.Drawing.Point(91, 55);
            this.btn_add_clin_to_cont_btn.Name = "btn_add_clin_to_cont_btn";
            this.btn_add_clin_to_cont_btn.Size = new System.Drawing.Size(156, 28);
            this.btn_add_clin_to_cont_btn.TabIndex = 61;
            this.btn_add_clin_to_cont_btn.Text = "اضافة عميل لعقد";
            this.btn_add_clin_to_cont_btn.UseVisualStyleBackColor = true;
            // 
            // btn_Add_cont_btn
            // 
            this.btn_Add_cont_btn.Location = new System.Drawing.Point(279, 51);
            this.btn_Add_cont_btn.Name = "btn_Add_cont_btn";
            this.btn_Add_cont_btn.Size = new System.Drawing.Size(151, 32);
            this.btn_Add_cont_btn.TabIndex = 60;
            this.btn_Add_cont_btn.Text = "اضافة عقد عميل";
            this.btn_Add_cont_btn.UseVisualStyleBackColor = true;
            // 
            // labelControl72
            // 
            this.labelControl72.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.labelControl72.Appearance.Font = new System.Drawing.Font("AGA Arabesque", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl72.Appearance.ForeColor = System.Drawing.Color.Red;
            this.labelControl72.Appearance.Options.UseFont = true;
            this.labelControl72.Appearance.Options.UseForeColor = true;
            this.labelControl72.Location = new System.Drawing.Point(472, 22);
            this.labelControl72.Name = "labelControl72";
            this.labelControl72.Size = new System.Drawing.Size(34, 22);
            this.labelControl72.TabIndex = 58;
            this.labelControl72.Text = "بحث:";
            // 
            // dgv_clin_and_contar_dgv
            // 
            this.dgv_clin_and_contar_dgv.AllowUserToAddRows = false;
            this.dgv_clin_and_contar_dgv.AllowUserToDeleteRows = false;
            this.dgv_clin_and_contar_dgv.AllowUserToOrderColumns = true;
            this.dgv_clin_and_contar_dgv.AllowUserToResizeColumns = false;
            this.dgv_clin_and_contar_dgv.AllowUserToResizeRows = false;
            this.dgv_clin_and_contar_dgv.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(200)))), ((int)(((byte)(230)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(200)))), ((int)(((byte)(90)))));
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgv_clin_and_contar_dgv.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgv_clin_and_contar_dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_clin_and_contar_dgv.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgv_clin_and_contar_dgv.EnableHeadersVisualStyles = false;
            this.dgv_clin_and_contar_dgv.Location = new System.Drawing.Point(0, 0);
            this.dgv_clin_and_contar_dgv.Name = "dgv_clin_and_contar_dgv";
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(200)))), ((int)(((byte)(90)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Black;
            this.dgv_clin_and_contar_dgv.RowsDefaultCellStyle = dataGridViewCellStyle2;
            this.dgv_clin_and_contar_dgv.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv_clin_and_contar_dgv.Size = new System.Drawing.Size(518, 532);
            this.dgv_clin_and_contar_dgv.TabIndex = 3;
            // 
            // fro_contra_and_clin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(518, 532);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.dgv_clin_and_contar_dgv);
            this.Name = "fro_contra_and_clin";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "fro_contra_and_clin";
            this.Load += new System.EventHandler(this.Fro_contra_and_clin_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_clin_and_contar_dgv)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox txt_searsh_clin_and_cont;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btn_add_clin_to_cont_btn;
        private System.Windows.Forms.Button btn_Add_cont_btn;
        private DevExpress.XtraEditors.LabelControl labelControl72;
        public System.Windows.Forms.DataGridView dgv_clin_and_contar_dgv;
    }
}