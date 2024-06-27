
namespace Manag_ph.Item.forms
{
    partial class Frm_add_operating_Expenses
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
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.txt_name_operating_Expenses = new System.Windows.Forms.TextBox();
            this.btn_new_operating_Expenses_btn = new System.Windows.Forms.Button();
            this.dgv_operating_Expenses_dgv = new System.Windows.Forms.DataGridView();
            this.btn_update_perating_Expenses_btn = new System.Windows.Forms.Button();
            this.btn_add_operating_Expenses_btn = new System.Windows.Forms.Button();
            this.lab = new DevExpress.XtraEditors.LabelControl();
            this.chBox_stop_operating_Expenses = new System.Windows.Forms.CheckBox();
            this.txt_num_operating_Expenses = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_operating_Expenses_dgv)).BeginInit();
            this.SuspendLayout();
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl1.Appearance.Options.UseFont = true;
            this.labelControl1.Location = new System.Drawing.Point(353, 32);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(36, 19);
            this.labelControl1.TabIndex = 36;
            this.labelControl1.Text = "الرقم :";
            // 
            // txt_name_operating_Expenses
            // 
            this.txt_name_operating_Expenses.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_name_operating_Expenses.Location = new System.Drawing.Point(90, 60);
            this.txt_name_operating_Expenses.Name = "txt_name_operating_Expenses";
            this.txt_name_operating_Expenses.Size = new System.Drawing.Size(179, 26);
            this.txt_name_operating_Expenses.TabIndex = 34;
            this.txt_name_operating_Expenses.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // btn_new_operating_Expenses_btn
            // 
            this.btn_new_operating_Expenses_btn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(120)))), ((int)(((byte)(210)))));
            this.btn_new_operating_Expenses_btn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_new_operating_Expenses_btn.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.btn_new_operating_Expenses_btn.FlatAppearance.BorderSize = 2;
            this.btn_new_operating_Expenses_btn.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold);
            this.btn_new_operating_Expenses_btn.ForeColor = System.Drawing.Color.White;
            this.btn_new_operating_Expenses_btn.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_new_operating_Expenses_btn.Location = new System.Drawing.Point(241, 274);
            this.btn_new_operating_Expenses_btn.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.btn_new_operating_Expenses_btn.Name = "btn_new_operating_Expenses_btn";
            this.btn_new_operating_Expenses_btn.Size = new System.Drawing.Size(106, 31);
            this.btn_new_operating_Expenses_btn.TabIndex = 32;
            this.btn_new_operating_Expenses_btn.Text = "جديد";
            this.btn_new_operating_Expenses_btn.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btn_new_operating_Expenses_btn.UseVisualStyleBackColor = false;
            this.btn_new_operating_Expenses_btn.Click += new System.EventHandler(this.btn_new_operating_Expenses_Click);
            // 
            // dgv_operating_Expenses_dgv
            // 
            this.dgv_operating_Expenses_dgv.AllowUserToAddRows = false;
            this.dgv_operating_Expenses_dgv.AllowUserToDeleteRows = false;
            this.dgv_operating_Expenses_dgv.AllowUserToResizeColumns = false;
            this.dgv_operating_Expenses_dgv.AllowUserToResizeRows = false;
            this.dgv_operating_Expenses_dgv.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgv_operating_Expenses_dgv.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(200)))), ((int)(((byte)(230)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(200)))), ((int)(((byte)(90)))));
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgv_operating_Expenses_dgv.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgv_operating_Expenses_dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_operating_Expenses_dgv.EnableHeadersVisualStyles = false;
            this.dgv_operating_Expenses_dgv.Location = new System.Drawing.Point(3, 106);
            this.dgv_operating_Expenses_dgv.Name = "dgv_operating_Expenses_dgv";
            this.dgv_operating_Expenses_dgv.ReadOnly = true;
            this.dgv_operating_Expenses_dgv.RowHeadersWidth = 51;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(200)))), ((int)(((byte)(90)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Black;
            this.dgv_operating_Expenses_dgv.RowsDefaultCellStyle = dataGridViewCellStyle2;
            this.dgv_operating_Expenses_dgv.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv_operating_Expenses_dgv.Size = new System.Drawing.Size(396, 167);
            this.dgv_operating_Expenses_dgv.TabIndex = 31;
            this.dgv_operating_Expenses_dgv.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.Dgv_operating_Expenses_CellContentClick);
            this.dgv_operating_Expenses_dgv.SelectionChanged += new System.EventHandler(this.dgv_operating_Expenses_SelectionChanged);
            // 
            // btn_update_perating_Expenses_btn
            // 
            this.btn_update_perating_Expenses_btn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(120)))), ((int)(((byte)(210)))));
            this.btn_update_perating_Expenses_btn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_update_perating_Expenses_btn.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.btn_update_perating_Expenses_btn.FlatAppearance.BorderSize = 2;
            this.btn_update_perating_Expenses_btn.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold);
            this.btn_update_perating_Expenses_btn.ForeColor = System.Drawing.Color.White;
            this.btn_update_perating_Expenses_btn.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_update_perating_Expenses_btn.Location = new System.Drawing.Point(149, 311);
            this.btn_update_perating_Expenses_btn.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.btn_update_perating_Expenses_btn.Name = "btn_update_perating_Expenses_btn";
            this.btn_update_perating_Expenses_btn.Size = new System.Drawing.Size(106, 31);
            this.btn_update_perating_Expenses_btn.TabIndex = 29;
            this.btn_update_perating_Expenses_btn.Text = "تعديل";
            this.btn_update_perating_Expenses_btn.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btn_update_perating_Expenses_btn.UseVisualStyleBackColor = false;
            this.btn_update_perating_Expenses_btn.Click += new System.EventHandler(this.btn_update_perating_Expenses_Click);
            // 
            // btn_add_operating_Expenses_btn
            // 
            this.btn_add_operating_Expenses_btn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(120)))), ((int)(((byte)(210)))));
            this.btn_add_operating_Expenses_btn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_add_operating_Expenses_btn.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.btn_add_operating_Expenses_btn.FlatAppearance.BorderSize = 2;
            this.btn_add_operating_Expenses_btn.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold);
            this.btn_add_operating_Expenses_btn.ForeColor = System.Drawing.Color.White;
            this.btn_add_operating_Expenses_btn.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_add_operating_Expenses_btn.Location = new System.Drawing.Point(51, 274);
            this.btn_add_operating_Expenses_btn.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.btn_add_operating_Expenses_btn.Name = "btn_add_operating_Expenses_btn";
            this.btn_add_operating_Expenses_btn.Size = new System.Drawing.Size(106, 31);
            this.btn_add_operating_Expenses_btn.TabIndex = 28;
            this.btn_add_operating_Expenses_btn.Text = "اضافة";
            this.btn_add_operating_Expenses_btn.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btn_add_operating_Expenses_btn.UseVisualStyleBackColor = false;
            this.btn_add_operating_Expenses_btn.Click += new System.EventHandler(this.btn_add_operating_Expenses_Click);
            // 
            // lab
            // 
            this.lab.Appearance.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lab.Appearance.Options.UseFont = true;
            this.lab.Location = new System.Drawing.Point(275, 65);
            this.lab.Name = "lab";
            this.lab.Size = new System.Drawing.Size(116, 19);
            this.lab.TabIndex = 27;
            this.lab.Text = "اسم مصروف التشغيل ";
            this.lab.Click += new System.EventHandler(this.lan_Click);
            // 
            // chBox_stop_operating_Expenses
            // 
            this.chBox_stop_operating_Expenses.AutoSize = true;
            this.chBox_stop_operating_Expenses.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold);
            this.chBox_stop_operating_Expenses.Location = new System.Drawing.Point(12, 31);
            this.chBox_stop_operating_Expenses.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.chBox_stop_operating_Expenses.Name = "chBox_stop_operating_Expenses";
            this.chBox_stop_operating_Expenses.Size = new System.Drawing.Size(60, 20);
            this.chBox_stop_operating_Expenses.TabIndex = 38;
            this.chBox_stop_operating_Expenses.Text = "توقيف ";
            this.chBox_stop_operating_Expenses.UseVisualStyleBackColor = true;
            // 
            // txt_num_operating_Expenses
            // 
            this.txt_num_operating_Expenses.Location = new System.Drawing.Point(90, 27);
            this.txt_num_operating_Expenses.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txt_num_operating_Expenses.Multiline = true;
            this.txt_num_operating_Expenses.Name = "txt_num_operating_Expenses";
            this.txt_num_operating_Expenses.ReadOnly = true;
            this.txt_num_operating_Expenses.Size = new System.Drawing.Size(245, 26);
            this.txt_num_operating_Expenses.TabIndex = 39;
            this.txt_num_operating_Expenses.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // Frm_add_operating_Expenses
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(399, 342);
            this.Controls.Add(this.txt_num_operating_Expenses);
            this.Controls.Add(this.chBox_stop_operating_Expenses);
            this.Controls.Add(this.labelControl1);
            this.Controls.Add(this.txt_name_operating_Expenses);
            this.Controls.Add(this.btn_new_operating_Expenses_btn);
            this.Controls.Add(this.dgv_operating_Expenses_dgv);
            this.Controls.Add(this.btn_update_perating_Expenses_btn);
            this.Controls.Add(this.btn_add_operating_Expenses_btn);
            this.Controls.Add(this.lab);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Frm_add_operating_Expenses";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Frm_add_operating_Expenses";
            this.Load += new System.EventHandler(this.Frm_add_operating_Expenses_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_operating_Expenses_dgv)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private System.Windows.Forms.TextBox txt_name_operating_Expenses;
        private System.Windows.Forms.Button btn_new_operating_Expenses_btn;
        private System.Windows.Forms.DataGridView dgv_operating_Expenses_dgv;
        private System.Windows.Forms.Button btn_update_perating_Expenses_btn;
        private System.Windows.Forms.Button btn_add_operating_Expenses_btn;
        private DevExpress.XtraEditors.LabelControl lab;
        private System.Windows.Forms.CheckBox chBox_stop_operating_Expenses;
        private System.Windows.Forms.TextBox txt_num_operating_Expenses;
    }
}