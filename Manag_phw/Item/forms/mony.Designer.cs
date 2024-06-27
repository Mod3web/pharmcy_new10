namespace Manag_ph.Item.forms
{
    partial class mony
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
            this.txt_name = new System.Windows.Forms.TextBox();
            this.txt_sech = new System.Windows.Forms.TextBox();
            this.btn_new_btn = new System.Windows.Forms.Button();
            this.dgv_currensic_dgv = new System.Windows.Forms.DataGridView();
            this.btn_update_btn = new System.Windows.Forms.Button();
            this.bt_Add_btn = new System.Windows.Forms.Button();
            this.lan = new DevExpress.XtraEditors.LabelControl();
            this.txt_name_curr = new System.Windows.Forms.TextBox();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.txt_name_curr2 = new System.Windows.Forms.TextBox();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_currensic_dgv)).BeginInit();
            this.SuspendLayout();
            // 
            // labelControl2
            // 
            this.labelControl2.Appearance.Font = new System.Drawing.Font("AGA Arabesque Desktop", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl2.Appearance.Options.UseFont = true;
            this.labelControl2.Location = new System.Drawing.Point(108, 8);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(40, 19);
            this.labelControl2.TabIndex = 81;
            this.labelControl2.Text = "البحث :";
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.Font = new System.Drawing.Font("AGA Arabesque Desktop", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl1.Appearance.Options.UseFont = true;
            this.labelControl1.Location = new System.Drawing.Point(12, 51);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(36, 19);
            this.labelControl1.TabIndex = 80;
            this.labelControl1.Text = "الرقم :";
            // 
            // txt_num
            // 
            this.txt_num.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_num.Location = new System.Drawing.Point(75, 44);
            this.txt_num.Name = "txt_num";
            this.txt_num.ReadOnly = true;
            this.txt_num.Size = new System.Drawing.Size(183, 26);
            this.txt_num.TabIndex = 79;
            this.txt_num.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txt_name
            // 
            this.txt_name.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_name.Location = new System.Drawing.Point(339, 47);
            this.txt_name.Name = "txt_name";
            this.txt_name.Size = new System.Drawing.Size(179, 26);
            this.txt_name.TabIndex = 78;
            this.txt_name.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txt_sech
            // 
            this.txt_sech.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_sech.Location = new System.Drawing.Point(154, 3);
            this.txt_sech.Name = "txt_sech";
            this.txt_sech.Size = new System.Drawing.Size(257, 26);
            this.txt_sech.TabIndex = 77;
            this.txt_sech.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
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
            this.btn_new_btn.Location = new System.Drawing.Point(88, 261);
            this.btn_new_btn.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.btn_new_btn.Name = "btn_new_btn";
            this.btn_new_btn.Size = new System.Drawing.Size(106, 31);
            this.btn_new_btn.TabIndex = 76;
            this.btn_new_btn.Text = "جديد";
            this.btn_new_btn.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btn_new_btn.UseVisualStyleBackColor = false;
            this.btn_new_btn.Click += new System.EventHandler(this.Btn_new_Click);
            // 
            // dgv_currensic_dgv
            // 
            this.dgv_currensic_dgv.AllowUserToAddRows = false;
            this.dgv_currensic_dgv.AllowUserToDeleteRows = false;
            this.dgv_currensic_dgv.AllowUserToResizeColumns = false;
            this.dgv_currensic_dgv.AllowUserToResizeRows = false;
            this.dgv_currensic_dgv.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgv_currensic_dgv.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(200)))), ((int)(((byte)(230)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(200)))), ((int)(((byte)(90)))));
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgv_currensic_dgv.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgv_currensic_dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_currensic_dgv.EnableHeadersVisualStyles = false;
            this.dgv_currensic_dgv.Location = new System.Drawing.Point(3, 110);
            this.dgv_currensic_dgv.Name = "dgv_currensic_dgv";
            this.dgv_currensic_dgv.ReadOnly = true;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(200)))), ((int)(((byte)(90)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Black;
            this.dgv_currensic_dgv.RowsDefaultCellStyle = dataGridViewCellStyle2;
            this.dgv_currensic_dgv.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv_currensic_dgv.Size = new System.Drawing.Size(523, 150);
            this.dgv_currensic_dgv.TabIndex = 75;
            this.dgv_currensic_dgv.SelectionChanged += new System.EventHandler(this.Dgv_currensic_SelectionChanged);
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
            this.btn_update_btn.Location = new System.Drawing.Point(329, 261);
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
            this.bt_Add_btn.Location = new System.Drawing.Point(208, 261);
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
            this.lan.Location = new System.Drawing.Point(277, 51);
            this.lan.Name = "lan";
            this.lan.Size = new System.Drawing.Size(56, 19);
            this.lan.TabIndex = 71;
            this.lan.Text = "اسم العملة";
            // 
            // txt_name_curr
            // 
            this.txt_name_curr.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_name_curr.Location = new System.Drawing.Point(75, 78);
            this.txt_name_curr.Name = "txt_name_curr";
            this.txt_name_curr.Size = new System.Drawing.Size(183, 26);
            this.txt_name_curr.TabIndex = 83;
            this.txt_name_curr.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // labelControl3
            // 
            this.labelControl3.Appearance.Font = new System.Drawing.Font("AGA Arabesque Desktop", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl3.Appearance.Options.UseFont = true;
            this.labelControl3.Location = new System.Drawing.Point(3, 83);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(61, 19);
            this.labelControl3.TabIndex = 82;
            this.labelControl3.Text = "الاسم الاكبر";
            // 
            // txt_name_curr2
            // 
            this.txt_name_curr2.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_name_curr2.Location = new System.Drawing.Point(339, 79);
            this.txt_name_curr2.Name = "txt_name_curr2";
            this.txt_name_curr2.Size = new System.Drawing.Size(179, 26);
            this.txt_name_curr2.TabIndex = 85;
            this.txt_name_curr2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // labelControl4
            // 
            this.labelControl4.Appearance.Font = new System.Drawing.Font("AGA Arabesque Desktop", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl4.Appearance.Options.UseFont = true;
            this.labelControl4.Location = new System.Drawing.Point(264, 83);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(69, 19);
            this.labelControl4.TabIndex = 84;
            this.labelControl4.Text = "الاسم الاصغر";
            // 
            // mony
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(530, 296);
            this.Controls.Add(this.txt_name_curr2);
            this.Controls.Add(this.labelControl4);
            this.Controls.Add(this.txt_name_curr);
            this.Controls.Add(this.labelControl3);
            this.Controls.Add(this.labelControl2);
            this.Controls.Add(this.labelControl1);
            this.Controls.Add(this.txt_num);
            this.Controls.Add(this.txt_name);
            this.Controls.Add(this.txt_sech);
            this.Controls.Add(this.btn_new_btn);
            this.Controls.Add(this.dgv_currensic_dgv);
            this.Controls.Add(this.btn_update_btn);
            this.Controls.Add(this.bt_Add_btn);
            this.Controls.Add(this.lan);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "mony";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RightToLeftLayout = true;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "العملة";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.Mony_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_currensic_dgv)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private System.Windows.Forms.TextBox txt_num;
        private System.Windows.Forms.TextBox txt_name;
        private System.Windows.Forms.TextBox txt_sech;
        private System.Windows.Forms.Button btn_new_btn;
        private System.Windows.Forms.DataGridView dgv_currensic_dgv;
        private System.Windows.Forms.Button btn_update_btn;
        private System.Windows.Forms.Button bt_Add_btn;
        private DevExpress.XtraEditors.LabelControl lan;
        private System.Windows.Forms.TextBox txt_name_curr;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private System.Windows.Forms.TextBox txt_name_curr2;
        private DevExpress.XtraEditors.LabelControl labelControl4;
    }
}