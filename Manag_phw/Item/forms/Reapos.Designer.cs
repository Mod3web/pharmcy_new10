namespace Manag_ph.Item.forms
{
    partial class Reapos
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
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.txt_num_reapos = new System.Windows.Forms.TextBox();
            this.txt_reapos = new System.Windows.Forms.TextBox();
            this.txt_sech_reapos = new System.Windows.Forms.TextBox();
            this.dgv_reapos_dgv = new System.Windows.Forms.DataGridView();
            this.lan = new DevExpress.XtraEditors.LabelControl();
            this.btn_new_reapos_btn = new System.Windows.Forms.Button();
            this.btn_delete_reapos_btn = new System.Windows.Forms.Button();
            this.btn_update_reapos_btn = new System.Windows.Forms.Button();
            this.bt_Add_reapos_btn = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_reapos_dgv)).BeginInit();
            this.SuspendLayout();
            // 
            // labelControl2
            // 
            this.labelControl2.Appearance.Font = new System.Drawing.Font("AGA Arabesque Desktop", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl2.Appearance.Options.UseFont = true;
            this.labelControl2.Location = new System.Drawing.Point(27, 23);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(40, 19);
            this.labelControl2.TabIndex = 70;
            this.labelControl2.Text = "البحث :";
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.Font = new System.Drawing.Font("AGA Arabesque Desktop", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl1.Appearance.Options.UseFont = true;
            this.labelControl1.Location = new System.Drawing.Point(31, 67);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(36, 19);
            this.labelControl1.TabIndex = 69;
            this.labelControl1.Text = "الرقم :";
            // 
            // txt_num_reapos
            // 
            this.txt_num_reapos.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_num_reapos.Location = new System.Drawing.Point(84, 60);
            this.txt_num_reapos.Name = "txt_num_reapos";
            this.txt_num_reapos.ReadOnly = true;
            this.txt_num_reapos.Size = new System.Drawing.Size(224, 26);
            this.txt_num_reapos.TabIndex = 68;
            this.txt_num_reapos.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txt_reapos
            // 
            this.txt_reapos.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_reapos.Location = new System.Drawing.Point(84, 90);
            this.txt_reapos.Name = "txt_reapos";
            this.txt_reapos.Size = new System.Drawing.Size(223, 26);
            this.txt_reapos.TabIndex = 67;
            this.txt_reapos.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txt_reapos.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Txt_reapos_KeyDown);
            // 
            // txt_sech_reapos
            // 
            this.txt_sech_reapos.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_sech_reapos.Location = new System.Drawing.Point(83, 23);
            this.txt_sech_reapos.Name = "txt_sech_reapos";
            this.txt_sech_reapos.Size = new System.Drawing.Size(224, 26);
            this.txt_sech_reapos.TabIndex = 66;
            this.txt_sech_reapos.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txt_sech_reapos.TextChanged += new System.EventHandler(this.Txt_sech_reapos_TextChanged);
            // 
            // dgv_reapos_dgv
            // 
            this.dgv_reapos_dgv.AllowUserToAddRows = false;
            this.dgv_reapos_dgv.AllowUserToDeleteRows = false;
            this.dgv_reapos_dgv.AllowUserToResizeColumns = false;
            this.dgv_reapos_dgv.AllowUserToResizeRows = false;
            this.dgv_reapos_dgv.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgv_reapos_dgv.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(200)))), ((int)(((byte)(230)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(200)))), ((int)(((byte)(90)))));
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgv_reapos_dgv.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgv_reapos_dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_reapos_dgv.EnableHeadersVisualStyles = false;
            this.dgv_reapos_dgv.Location = new System.Drawing.Point(4, 128);
            this.dgv_reapos_dgv.Name = "dgv_reapos_dgv";
            this.dgv_reapos_dgv.ReadOnly = true;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(200)))), ((int)(((byte)(90)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Black;
            this.dgv_reapos_dgv.RowsDefaultCellStyle = dataGridViewCellStyle2;
            this.dgv_reapos_dgv.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv_reapos_dgv.Size = new System.Drawing.Size(324, 150);
            this.dgv_reapos_dgv.TabIndex = 64;
            this.dgv_reapos_dgv.SelectionChanged += new System.EventHandler(this.Dgv_reapos_SelectionChanged);
            // 
            // lan
            // 
            this.lan.Appearance.Font = new System.Drawing.Font("AGA Arabesque Desktop", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lan.Appearance.Options.UseFont = true;
            this.lan.Location = new System.Drawing.Point(29, 97);
            this.lan.Name = "lan";
            this.lan.Size = new System.Drawing.Size(42, 19);
            this.lan.TabIndex = 60;
            this.lan.Text = "السبب :";
            // 
            // btn_new_reapos_btn
            // 
            this.btn_new_reapos_btn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(120)))), ((int)(((byte)(210)))));
            this.btn_new_reapos_btn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_new_reapos_btn.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.btn_new_reapos_btn.FlatAppearance.BorderSize = 2;
            this.btn_new_reapos_btn.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold);
            this.btn_new_reapos_btn.ForeColor = System.Drawing.Color.White;
            this.btn_new_reapos_btn.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_new_reapos_btn.Location = new System.Drawing.Point(178, 280);
            this.btn_new_reapos_btn.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.btn_new_reapos_btn.Name = "btn_new_reapos_btn";
            this.btn_new_reapos_btn.Size = new System.Drawing.Size(106, 31);
            this.btn_new_reapos_btn.TabIndex = 65;
            this.btn_new_reapos_btn.Text = "جديد";
            this.btn_new_reapos_btn.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btn_new_reapos_btn.UseVisualStyleBackColor = false;
            this.btn_new_reapos_btn.Click += new System.EventHandler(this.Btn_new_reapos_Click);
            // 
            // btn_delete_reapos_btn
            // 
            this.btn_delete_reapos_btn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(120)))), ((int)(((byte)(210)))));
            this.btn_delete_reapos_btn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_delete_reapos_btn.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.btn_delete_reapos_btn.FlatAppearance.BorderSize = 2;
            this.btn_delete_reapos_btn.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold);
            this.btn_delete_reapos_btn.ForeColor = System.Drawing.Color.White;
            this.btn_delete_reapos_btn.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_delete_reapos_btn.Location = new System.Drawing.Point(178, 319);
            this.btn_delete_reapos_btn.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.btn_delete_reapos_btn.Name = "btn_delete_reapos_btn";
            this.btn_delete_reapos_btn.Size = new System.Drawing.Size(106, 31);
            this.btn_delete_reapos_btn.TabIndex = 63;
            this.btn_delete_reapos_btn.Text = "حذف";
            this.btn_delete_reapos_btn.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btn_delete_reapos_btn.UseVisualStyleBackColor = false;
            this.btn_delete_reapos_btn.Click += new System.EventHandler(this.Btn_delete_reapos_Click);
            // 
            // btn_update_reapos_btn
            // 
            this.btn_update_reapos_btn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(120)))), ((int)(((byte)(210)))));
            this.btn_update_reapos_btn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_update_reapos_btn.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.btn_update_reapos_btn.FlatAppearance.BorderSize = 2;
            this.btn_update_reapos_btn.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold);
            this.btn_update_reapos_btn.ForeColor = System.Drawing.Color.White;
            this.btn_update_reapos_btn.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_update_reapos_btn.Location = new System.Drawing.Point(34, 319);
            this.btn_update_reapos_btn.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.btn_update_reapos_btn.Name = "btn_update_reapos_btn";
            this.btn_update_reapos_btn.Size = new System.Drawing.Size(106, 31);
            this.btn_update_reapos_btn.TabIndex = 62;
            this.btn_update_reapos_btn.Text = "تعديل";
            this.btn_update_reapos_btn.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btn_update_reapos_btn.UseVisualStyleBackColor = false;
            this.btn_update_reapos_btn.Click += new System.EventHandler(this.Btn_update_reapos_Click);
            // 
            // bt_Add_reapos_btn
            // 
            this.bt_Add_reapos_btn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(120)))), ((int)(((byte)(210)))));
            this.bt_Add_reapos_btn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.bt_Add_reapos_btn.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.bt_Add_reapos_btn.FlatAppearance.BorderSize = 2;
            this.bt_Add_reapos_btn.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold);
            this.bt_Add_reapos_btn.ForeColor = System.Drawing.Color.White;
            this.bt_Add_reapos_btn.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.bt_Add_reapos_btn.Location = new System.Drawing.Point(34, 280);
            this.bt_Add_reapos_btn.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.bt_Add_reapos_btn.Name = "bt_Add_reapos_btn";
            this.bt_Add_reapos_btn.Size = new System.Drawing.Size(106, 31);
            this.bt_Add_reapos_btn.TabIndex = 61;
            this.bt_Add_reapos_btn.Text = "اضافة";
            this.bt_Add_reapos_btn.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.bt_Add_reapos_btn.UseVisualStyleBackColor = false;
            this.bt_Add_reapos_btn.Click += new System.EventHandler(this.Bt_Add_reapos_Click);
            // 
            // Reapos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(331, 352);
            this.Controls.Add(this.labelControl2);
            this.Controls.Add(this.labelControl1);
            this.Controls.Add(this.txt_num_reapos);
            this.Controls.Add(this.txt_reapos);
            this.Controls.Add(this.txt_sech_reapos);
            this.Controls.Add(this.btn_new_reapos_btn);
            this.Controls.Add(this.dgv_reapos_dgv);
            this.Controls.Add(this.btn_delete_reapos_btn);
            this.Controls.Add(this.btn_update_reapos_btn);
            this.Controls.Add(this.bt_Add_reapos_btn);
            this.Controls.Add(this.lan);
            this.Name = "Reapos";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RightToLeftLayout = true;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "اسباب التسويات";
            this.Load += new System.EventHandler(this.Reapos_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_reapos_dgv)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private System.Windows.Forms.TextBox txt_num_reapos;
        private System.Windows.Forms.TextBox txt_reapos;
        private System.Windows.Forms.TextBox txt_sech_reapos;
        private System.Windows.Forms.Button btn_new_reapos_btn;
        private System.Windows.Forms.DataGridView dgv_reapos_dgv;
        private System.Windows.Forms.Button btn_delete_reapos_btn;
        private System.Windows.Forms.Button btn_update_reapos_btn;
        private System.Windows.Forms.Button bt_Add_reapos_btn;
        private DevExpress.XtraEditors.LabelControl lan;
    }
}