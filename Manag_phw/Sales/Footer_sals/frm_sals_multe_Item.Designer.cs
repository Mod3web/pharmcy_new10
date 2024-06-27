namespace Manag_ph.Sales
{
    partial class frm_sals_multe_Item
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
            this.dgv_multy_Item_dgv = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.txt_pric_sals = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.button2_btn = new System.Windows.Forms.Button();
            this.button1_btn = new System.Windows.Forms.Button();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txt_qty = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txt_qty_sals = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.com_unit = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_multy_Item_dgv)).BeginInit();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgv_multy_Item_dgv
            // 
            this.dgv_multy_Item_dgv.AllowUserToAddRows = false;
            this.dgv_multy_Item_dgv.AllowUserToDeleteRows = false;
            this.dgv_multy_Item_dgv.AllowUserToResizeColumns = false;
            this.dgv_multy_Item_dgv.AllowUserToResizeRows = false;
            this.dgv_multy_Item_dgv.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(200)))), ((int)(((byte)(230)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(200)))), ((int)(((byte)(90)))));
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgv_multy_Item_dgv.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgv_multy_Item_dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_multy_Item_dgv.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column3,
            this.Column5,
            this.Column4,
            this.Column7,
            this.Column8,
            this.Column6});
            this.dgv_multy_Item_dgv.Dock = System.Windows.Forms.DockStyle.Top;
            this.dgv_multy_Item_dgv.EnableHeadersVisualStyles = false;
            this.dgv_multy_Item_dgv.Location = new System.Drawing.Point(0, 40);
            this.dgv_multy_Item_dgv.MultiSelect = false;
            this.dgv_multy_Item_dgv.Name = "dgv_multy_Item_dgv";
            this.dgv_multy_Item_dgv.ReadOnly = true;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(200)))), ((int)(((byte)(90)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Black;
            this.dgv_multy_Item_dgv.RowsDefaultCellStyle = dataGridViewCellStyle2;
            this.dgv_multy_Item_dgv.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv_multy_Item_dgv.Size = new System.Drawing.Size(564, 252);
            this.dgv_multy_Item_dgv.TabIndex = 0;
            this.dgv_multy_Item_dgv.SelectionChanged += new System.EventHandler(this.Dgv_multy_Item_SelectionChanged);
            // 
            // Column1
            // 
            this.Column1.HeaderText = "الكود";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            this.Column1.Width = 80;
            // 
            // Column2
            // 
            this.Column2.HeaderText = "الاسم انجليزي";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            this.Column2.Width = 160;
            // 
            // Column3
            // 
            this.Column3.HeaderText = "تاريخ الصلاحية";
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            // 
            // Column5
            // 
            this.Column5.HeaderText = "سعر البيع";
            this.Column5.Name = "Column5";
            this.Column5.ReadOnly = true;
            // 
            // Column4
            // 
            this.Column4.HeaderText = "المادة الفعالة";
            this.Column4.Name = "Column4";
            this.Column4.ReadOnly = true;
            // 
            // Column7
            // 
            this.Column7.HeaderText = "طبيعة الصنف";
            this.Column7.Name = "Column7";
            this.Column7.ReadOnly = true;
            // 
            // Column8
            // 
            this.Column8.HeaderText = "سبب الاستخدام";
            this.Column8.Name = "Column8";
            this.Column8.ReadOnly = true;
            // 
            // Column6
            // 
            this.Column6.HeaderText = "رقم الصنف المخزن";
            this.Column6.Name = "Column6";
            this.Column6.ReadOnly = true;
            this.Column6.Width = 200;
            // 
            // panel1
            // 
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(564, 40);
            this.panel1.TabIndex = 1;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.txt_pric_sals);
            this.panel2.Controls.Add(this.label6);
            this.panel2.Controls.Add(this.button2_btn);
            this.panel2.Controls.Add(this.button1_btn);
            this.panel2.Controls.Add(this.textBox3);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.txt_qty);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.txt_qty_sals);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.com_unit);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 292);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(564, 72);
            this.panel2.TabIndex = 2;
            // 
            // txt_pric_sals
            // 
            this.txt_pric_sals.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold);
            this.txt_pric_sals.Location = new System.Drawing.Point(398, 31);
            this.txt_pric_sals.Name = "txt_pric_sals";
            this.txt_pric_sals.ReadOnly = true;
            this.txt_pric_sals.Size = new System.Drawing.Size(97, 23);
            this.txt_pric_sals.TabIndex = 11;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold);
            this.label6.Location = new System.Drawing.Point(501, 33);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(60, 19);
            this.label6.TabIndex = 10;
            this.label6.Text = "سعر البيع";
            // 
            // button2_btn
            // 
            this.button2_btn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(120)))), ((int)(((byte)(210)))));
            this.button2_btn.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold);
            this.button2_btn.ForeColor = System.Drawing.Color.White;
            this.button2_btn.Location = new System.Drawing.Point(193, 32);
            this.button2_btn.Name = "button2_btn";
            this.button2_btn.Size = new System.Drawing.Size(75, 32);
            this.button2_btn.TabIndex = 9;
            this.button2_btn.Text = "الغاء";
            this.button2_btn.UseVisualStyleBackColor = false;
            this.button2_btn.Click += new System.EventHandler(this.Button2_Click);
            // 
            // button1_btn
            // 
            this.button1_btn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(120)))), ((int)(((byte)(210)))));
            this.button1_btn.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold);
            this.button1_btn.ForeColor = System.Drawing.Color.White;
            this.button1_btn.Location = new System.Drawing.Point(302, 33);
            this.button1_btn.Name = "button1_btn";
            this.button1_btn.Size = new System.Drawing.Size(75, 32);
            this.button1_btn.TabIndex = 8;
            this.button1_btn.Text = "اضافة";
            this.button1_btn.UseVisualStyleBackColor = false;
            this.button1_btn.Click += new System.EventHandler(this.Button1_Click);
            // 
            // textBox3
            // 
            this.textBox3.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold);
            this.textBox3.Location = new System.Drawing.Point(9, 5);
            this.textBox3.Name = "textBox3";
            this.textBox3.ReadOnly = true;
            this.textBox3.Size = new System.Drawing.Size(67, 23);
            this.textBox3.TabIndex = 7;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold);
            this.label4.Location = new System.Drawing.Point(82, 8);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(76, 19);
            this.label4.TabIndex = 6;
            this.label4.Text = "عدد الاصناف";
            // 
            // txt_qty
            // 
            this.txt_qty.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold);
            this.txt_qty.Location = new System.Drawing.Point(164, 6);
            this.txt_qty.Name = "txt_qty";
            this.txt_qty.ReadOnly = true;
            this.txt_qty.Size = new System.Drawing.Size(67, 23);
            this.txt_qty.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold);
            this.label3.Location = new System.Drawing.Point(237, 8);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(45, 19);
            this.label3.TabIndex = 4;
            this.label3.Text = "الرصيد";
            // 
            // txt_qty_sals
            // 
            this.txt_qty_sals.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold);
            this.txt_qty_sals.Location = new System.Drawing.Point(288, 6);
            this.txt_qty_sals.Name = "txt_qty_sals";
            this.txt_qty_sals.Size = new System.Drawing.Size(67, 23);
            this.txt_qty_sals.TabIndex = 3;
            this.txt_qty_sals.Text = "1";
            this.txt_qty_sals.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txt_qty_sals.TextChanged += new System.EventHandler(this.TextBox1_TextChanged);
            this.txt_qty_sals.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Txt_qty_sals_KeyUp);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold);
            this.label2.Location = new System.Drawing.Point(355, 7);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 19);
            this.label2.TabIndex = 2;
            this.label2.Text = "الكمية";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(502, 6);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(42, 19);
            this.label1.TabIndex = 1;
            this.label1.Text = "الوحدة";
            // 
            // com_unit
            // 
            this.com_unit.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.com_unit.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold);
            this.com_unit.FormattingEnabled = true;
            this.com_unit.Location = new System.Drawing.Point(398, 3);
            this.com_unit.Name = "com_unit";
            this.com_unit.Size = new System.Drawing.Size(98, 24);
            this.com_unit.TabIndex = 0;
            this.com_unit.SelectedIndexChanged += new System.EventHandler(this.Com_unit_SelectedIndexChanged);
            // 
            // frm_sals_multe_Item
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(564, 364);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.dgv_multy_Item_dgv);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frm_sals_multe_Item";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RightToLeftLayout = true;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "صنف متكرر";
            this.Load += new System.EventHandler(this.Frm_sals_multe_Item_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_multy_Item_dgv)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgv_multy_Item_dgv;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button button2_btn;
        private System.Windows.Forms.Button button1_btn;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txt_qty;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txt_qty_sals;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox com_unit;
        private System.Windows.Forms.TextBox txt_pric_sals;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column7;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column8;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column6;
    }
}