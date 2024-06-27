namespace Manag_ph.Item.forms
{
    partial class frm_casher_And_fund
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
            this.dataGridView1_dgv = new System.Windows.Forms.DataGridView();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.button1_btn = new System.Windows.Forms.Button();
            this.button2_btn = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1_dgv)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1_dgv
            // 
            this.dataGridView1_dgv.AllowUserToAddRows = false;
            this.dataGridView1_dgv.AllowUserToDeleteRows = false;
            this.dataGridView1_dgv.AllowUserToResizeColumns = false;
            this.dataGridView1_dgv.AllowUserToResizeRows = false;
            this.dataGridView1_dgv.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1_dgv.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(200)))), ((int)(((byte)(230)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(200)))), ((int)(((byte)(90)))));
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1_dgv.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView1_dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1_dgv.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column4,
            this.Column1,
            this.Column3,
            this.Column2});
            this.dataGridView1_dgv.Dock = System.Windows.Forms.DockStyle.Top;
            this.dataGridView1_dgv.EnableHeadersVisualStyles = false;
            this.dataGridView1_dgv.Location = new System.Drawing.Point(0, 0);
            this.dataGridView1_dgv.Name = "dataGridView1_dgv";
            this.dataGridView1_dgv.ReadOnly = true;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(200)))), ((int)(((byte)(90)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Black;
            this.dataGridView1_dgv.RowsDefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridView1_dgv.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1_dgv.Size = new System.Drawing.Size(316, 170);
            this.dataGridView1_dgv.TabIndex = 0;
            this.dataGridView1_dgv.CellMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.DataGridView1_CellMouseDoubleClick);
            this.dataGridView1_dgv.SelectionChanged += new System.EventHandler(this.DataGridView1_SelectionChanged);
            // 
            // Column4
            // 
            this.Column4.HeaderText = "الكود";
            this.Column4.Name = "Column4";
            this.Column4.ReadOnly = true;
            this.Column4.Visible = false;
            // 
            // Column1
            // 
            this.Column1.HeaderText = "الاسم";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            // 
            // Column3
            // 
            this.Column3.HeaderText = "الرصيد";
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            // 
            // Column2
            // 
            this.Column2.HeaderText = "النوع";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            // 
            // button1_btn
            // 
            this.button1_btn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(120)))), ((int)(((byte)(210)))));
            this.button1_btn.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold);
            this.button1_btn.ForeColor = System.Drawing.Color.White;
            this.button1_btn.Location = new System.Drawing.Point(73, 176);
            this.button1_btn.Name = "button1_btn";
            this.button1_btn.Size = new System.Drawing.Size(75, 30);
            this.button1_btn.TabIndex = 1;
            this.button1_btn.Text = "اضافة";
            this.button1_btn.UseVisualStyleBackColor = false;
            this.button1_btn.Click += new System.EventHandler(this.Button1_Click);
            // 
            // button2_btn
            // 
            this.button2_btn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(120)))), ((int)(((byte)(210)))));
            this.button2_btn.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold);
            this.button2_btn.ForeColor = System.Drawing.Color.White;
            this.button2_btn.Location = new System.Drawing.Point(176, 176);
            this.button2_btn.Name = "button2_btn";
            this.button2_btn.Size = new System.Drawing.Size(75, 30);
            this.button2_btn.TabIndex = 2;
            this.button2_btn.Text = "اغلاق";
            this.button2_btn.UseVisualStyleBackColor = false;
            this.button2_btn.Click += new System.EventHandler(this.Button2_Click);
            // 
            // frm_casher_And_fund
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(316, 211);
            this.Controls.Add(this.button2_btn);
            this.Controls.Add(this.button1_btn);
            this.Controls.Add(this.dataGridView1_dgv);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frm_casher_And_fund";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RightToLeftLayout = true;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "حسابات الصيدلية";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.Frm_casher_And_fund_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1_dgv)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1_dgv;
        private System.Windows.Forms.Button button1_btn;
        private System.Windows.Forms.Button button2_btn;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
    }
}