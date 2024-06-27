namespace Manag_ph.forms
{
    partial class effective_material
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
            this.txt_num = new System.Windows.Forms.TextBox();
            this.txt_com = new System.Windows.Forms.TextBox();
            this.txt_sech = new System.Windows.Forms.TextBox();
            this.btn_new_btn = new System.Windows.Forms.Button();
            this.dgv_Compny_dgv = new System.Windows.Forms.DataGridView();
            this.btn_delete_btn = new System.Windows.Forms.Button();
            this.btn_update_btn = new System.Windows.Forms.Button();
            this.bt_Add_btn = new System.Windows.Forms.Button();
            this.lan = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Compny_dgv)).BeginInit();
            this.SuspendLayout();
            // 
            // labelControl2
            // 
            this.labelControl2.Appearance.Font = new System.Drawing.Font("AGA Arabesque Desktop", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl2.Appearance.Options.UseFont = true;
            this.labelControl2.Location = new System.Drawing.Point(11, 17);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(40, 19);
            this.labelControl2.TabIndex = 81;
            this.labelControl2.Text = "البحث :";
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.Font = new System.Drawing.Font("AGA Arabesque Desktop", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl1.Appearance.Options.UseFont = true;
            this.labelControl1.Location = new System.Drawing.Point(15, 61);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(36, 19);
            this.labelControl1.TabIndex = 80;
            this.labelControl1.Text = "الرقم :";
            // 
            // txt_num
            // 
            this.txt_num.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_num.Location = new System.Drawing.Point(85, 54);
            this.txt_num.Name = "txt_num";
            this.txt_num.ReadOnly = true;
            this.txt_num.Size = new System.Drawing.Size(235, 26);
            this.txt_num.TabIndex = 79;
            this.txt_num.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txt_com
            // 
            this.txt_com.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_com.Location = new System.Drawing.Point(85, 84);
            this.txt_com.Name = "txt_com";
            this.txt_com.Size = new System.Drawing.Size(234, 26);
            this.txt_com.TabIndex = 78;
            this.txt_com.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txt_sech
            // 
            this.txt_sech.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_sech.Location = new System.Drawing.Point(84, 17);
            this.txt_sech.Name = "txt_sech";
            this.txt_sech.Size = new System.Drawing.Size(235, 26);
            this.txt_sech.TabIndex = 77;
            this.txt_sech.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txt_sech.TextChanged += new System.EventHandler(this.Txt_sech_TextChanged);
            // 
            // btn_new_btn
            // 
            this.btn_new_btn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(120)))), ((int)(((byte)(210)))));
            this.btn_new_btn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_new_btn.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.btn_new_btn.FlatAppearance.BorderSize = 2;
            this.btn_new_btn.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold);
            this.btn_new_btn.ForeColor = System.Drawing.Color.White;
            this.btn_new_btn.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_new_btn.Location = new System.Drawing.Point(184, 275);
            this.btn_new_btn.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.btn_new_btn.Name = "btn_new_btn";
            this.btn_new_btn.Size = new System.Drawing.Size(106, 31);
            this.btn_new_btn.TabIndex = 76;
            this.btn_new_btn.Text = "جديد";
            this.btn_new_btn.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btn_new_btn.UseVisualStyleBackColor = false;
            this.btn_new_btn.Click += new System.EventHandler(this.Btn_new_Click);
            // 
            // dgv_Compny_dgv
            // 
            this.dgv_Compny_dgv.AllowUserToAddRows = false;
            this.dgv_Compny_dgv.AllowUserToDeleteRows = false;
            this.dgv_Compny_dgv.AllowUserToResizeColumns = false;
            this.dgv_Compny_dgv.AllowUserToResizeRows = false;
            this.dgv_Compny_dgv.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgv_Compny_dgv.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(200)))), ((int)(((byte)(230)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(200)))), ((int)(((byte)(90)))));
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgv_Compny_dgv.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgv_Compny_dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_Compny_dgv.EnableHeadersVisualStyles = false;
            this.dgv_Compny_dgv.Location = new System.Drawing.Point(4, 124);
            this.dgv_Compny_dgv.Name = "dgv_Compny_dgv";
            this.dgv_Compny_dgv.ReadOnly = true;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(200)))), ((int)(((byte)(90)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Black;
            this.dgv_Compny_dgv.RowsDefaultCellStyle = dataGridViewCellStyle2;
            this.dgv_Compny_dgv.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv_Compny_dgv.Size = new System.Drawing.Size(324, 150);
            this.dgv_Compny_dgv.TabIndex = 75;
            this.dgv_Compny_dgv.SelectionChanged += new System.EventHandler(this.Dgv_Compny_SelectionChanged);
            // 
            // btn_delete_btn
            // 
            this.btn_delete_btn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(120)))), ((int)(((byte)(210)))));
            this.btn_delete_btn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_delete_btn.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.btn_delete_btn.FlatAppearance.BorderSize = 2;
            this.btn_delete_btn.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold);
            this.btn_delete_btn.ForeColor = System.Drawing.Color.White;
            this.btn_delete_btn.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_delete_btn.Location = new System.Drawing.Point(184, 314);
            this.btn_delete_btn.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.btn_delete_btn.Name = "btn_delete_btn";
            this.btn_delete_btn.Size = new System.Drawing.Size(106, 31);
            this.btn_delete_btn.TabIndex = 74;
            this.btn_delete_btn.Text = "حذف";
            this.btn_delete_btn.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btn_delete_btn.UseVisualStyleBackColor = false;
            this.btn_delete_btn.Click += new System.EventHandler(this.Btn_delete_Click);
            // 
            // btn_update_btn
            // 
            this.btn_update_btn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(120)))), ((int)(((byte)(210)))));
            this.btn_update_btn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_update_btn.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.btn_update_btn.FlatAppearance.BorderSize = 2;
            this.btn_update_btn.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold);
            this.btn_update_btn.ForeColor = System.Drawing.Color.White;
            this.btn_update_btn.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_update_btn.Location = new System.Drawing.Point(39, 314);
            this.btn_update_btn.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.btn_update_btn.Name = "btn_update_btn";
            this.btn_update_btn.Size = new System.Drawing.Size(106, 31);
            this.btn_update_btn.TabIndex = 73;
            this.btn_update_btn.Text = "تعديل";
            this.btn_update_btn.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btn_update_btn.UseVisualStyleBackColor = false;
            this.btn_update_btn.Click += new System.EventHandler(this.Btn_update_Click);
            // 
            // bt_Add_btn
            // 
            this.bt_Add_btn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(120)))), ((int)(((byte)(210)))));
            this.bt_Add_btn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.bt_Add_btn.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.bt_Add_btn.FlatAppearance.BorderSize = 2;
            this.bt_Add_btn.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold);
            this.bt_Add_btn.ForeColor = System.Drawing.Color.White;
            this.bt_Add_btn.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.bt_Add_btn.Location = new System.Drawing.Point(39, 275);
            this.bt_Add_btn.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.bt_Add_btn.Name = "bt_Add_btn";
            this.bt_Add_btn.Size = new System.Drawing.Size(106, 31);
            this.bt_Add_btn.TabIndex = 72;
            this.bt_Add_btn.Text = "اضافة";
            this.bt_Add_btn.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.bt_Add_btn.UseVisualStyleBackColor = false;
            this.bt_Add_btn.Click += new System.EventHandler(this.Bt_Add_Click);
            // 
            // lan
            // 
            this.lan.Appearance.Font = new System.Drawing.Font("AGA Arabesque Desktop", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lan.Appearance.Options.UseFont = true;
            this.lan.Location = new System.Drawing.Point(19, 91);
            this.lan.Name = "lan";
            this.lan.Size = new System.Drawing.Size(39, 19);
            this.lan.TabIndex = 71;
            this.lan.Text = "المادة :";
            // 
            // effective_material
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(331, 347);
            this.Controls.Add(this.labelControl2);
            this.Controls.Add(this.labelControl1);
            this.Controls.Add(this.txt_num);
            this.Controls.Add(this.txt_com);
            this.Controls.Add(this.txt_sech);
            this.Controls.Add(this.btn_new_btn);
            this.Controls.Add(this.dgv_Compny_dgv);
            this.Controls.Add(this.btn_delete_btn);
            this.Controls.Add(this.btn_update_btn);
            this.Controls.Add(this.bt_Add_btn);
            this.Controls.Add(this.lan);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "effective_material";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RightToLeftLayout = true;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "المادة الفعالة";
            this.Load += new System.EventHandler(this.Effective_material_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Compny_dgv)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private System.Windows.Forms.TextBox txt_num;
        private System.Windows.Forms.TextBox txt_com;
        private System.Windows.Forms.TextBox txt_sech;
        private System.Windows.Forms.Button btn_new_btn;
        private System.Windows.Forms.DataGridView dgv_Compny_dgv;
        private System.Windows.Forms.Button btn_delete_btn;
        private System.Windows.Forms.Button btn_update_btn;
        private System.Windows.Forms.Button bt_Add_btn;
        private DevExpress.XtraEditors.LabelControl lan;
    }
}