namespace Manag_ph.forms
{
    partial class Form2
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
            this.dataGridView_dgv = new System.Windows.Forms.DataGridView();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txt_sersh_view = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btn_add_bdal_btn = new System.Windows.Forms.Button();
            this.btn_Eixt_btn = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_dgv)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridView_dgv
            // 
            this.dataGridView_dgv.AllowUserToAddRows = false;
            this.dataGridView_dgv.AllowUserToDeleteRows = false;
            this.dataGridView_dgv.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView_dgv.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(200)))), ((int)(((byte)(230)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(200)))), ((int)(((byte)(90)))));
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView_dgv.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView_dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_dgv.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView_dgv.EnableHeadersVisualStyles = false;
            this.dataGridView_dgv.Location = new System.Drawing.Point(0, 50);
            this.dataGridView_dgv.Margin = new System.Windows.Forms.Padding(2);
            this.dataGridView_dgv.Name = "dataGridView_dgv";
            this.dataGridView_dgv.ReadOnly = true;
            this.dataGridView_dgv.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.dataGridView_dgv.RowHeadersWidth = 30;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(200)))), ((int)(((byte)(90)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Black;
            this.dataGridView_dgv.RowsDefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridView_dgv.RowTemplate.Height = 24;
            this.dataGridView_dgv.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView_dgv.Size = new System.Drawing.Size(684, 239);
            this.dataGridView_dgv.TabIndex = 5;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txt_sersh_view);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox1.Size = new System.Drawing.Size(684, 50);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            // 
            // txt_sersh_view
            // 
            this.txt_sersh_view.Location = new System.Drawing.Point(130, 14);
            this.txt_sersh_view.Margin = new System.Windows.Forms.Padding(2);
            this.txt_sersh_view.Multiline = true;
            this.txt_sersh_view.Name = "txt_sersh_view";
            this.txt_sersh_view.Size = new System.Drawing.Size(318, 24);
            this.txt_sersh_view.TabIndex = 2;
            this.txt_sersh_view.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txt_sersh_view.TextChanged += new System.EventHandler(this.Txt_sersh_view_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(457, 12);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(99, 26);
            this.label1.TabIndex = 1;
            this.label1.Text = "اكتب للبحث ";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btn_add_bdal_btn);
            this.groupBox2.Controls.Add(this.btn_Eixt_btn);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupBox2.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(0, 289);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox2.Size = new System.Drawing.Size(684, 62);
            this.groupBox2.TabIndex = 7;
            this.groupBox2.TabStop = false;
            // 
            // btn_add_bdal_btn
            // 
            this.btn_add_bdal_btn.Location = new System.Drawing.Point(439, 20);
            this.btn_add_bdal_btn.Margin = new System.Windows.Forms.Padding(2);
            this.btn_add_bdal_btn.Name = "btn_add_bdal_btn";
            this.btn_add_bdal_btn.Size = new System.Drawing.Size(106, 31);
            this.btn_add_bdal_btn.TabIndex = 1;
            this.btn_add_bdal_btn.Text = "اضافة";
            this.btn_add_bdal_btn.UseVisualStyleBackColor = true;
            this.btn_add_bdal_btn.Click += new System.EventHandler(this.Btn_add_bdal_Click);
            // 
            // btn_Eixt_btn
            // 
            this.btn_Eixt_btn.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Eixt_btn.Location = new System.Drawing.Point(169, 21);
            this.btn_Eixt_btn.Margin = new System.Windows.Forms.Padding(2);
            this.btn_Eixt_btn.Name = "btn_Eixt_btn";
            this.btn_Eixt_btn.Size = new System.Drawing.Size(106, 31);
            this.btn_Eixt_btn.TabIndex = 0;
            this.btn_Eixt_btn.Text = "الغاء";
            this.btn_Eixt_btn.UseVisualStyleBackColor = true;
            this.btn_Eixt_btn.Click += new System.EventHandler(this.Btn_Eixt_Click);
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(684, 351);
            this.Controls.Add(this.dataGridView_dgv);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(700, 390);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(700, 390);
            this.Name = "Form2";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "شاشة الاصناف";
            this.Load += new System.EventHandler(this.Form2_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_dgv)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.DataGridView dataGridView_dgv;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txt_sersh_view;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox2;
        public System.Windows.Forms.Button btn_add_bdal_btn;
        public System.Windows.Forms.Button btn_Eixt_btn;
    }
}