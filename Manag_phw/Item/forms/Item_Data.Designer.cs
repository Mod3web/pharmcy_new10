namespace Manag_ph.forms
{
    partial class Item_Data
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dgv_Item_Add_dgv = new System.Windows.Forms.DataGridView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.button2_btn = new System.Windows.Forms.Button();
            this.button1_btn = new System.Windows.Forms.Button();
            this.txt_pons = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txt_qut = new System.Windows.Forms.TextBox();
            this.dtp_E = new System.Windows.Forms.DateTimePicker();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel5 = new System.Windows.Forms.Panel();
            this.ch_Sp_All = new System.Windows.Forms.RadioButton();
            this.ch_NoStop = new System.Windows.Forms.RadioButton();
            this.ch_Stop = new System.Windows.Forms.RadioButton();
            this.panel4 = new System.Windows.Forms.Panel();
            this.ch_All = new System.Windows.Forms.RadioButton();
            this.ch_NoDow = new System.Windows.Forms.RadioButton();
            this.ch_Dow = new System.Windows.Forms.RadioButton();
            this.label1 = new System.Windows.Forms.Label();
            this.txt_Serch_Item = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Item_Add_dgv)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel5.SuspendLayout();
            this.panel4.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgv_Item_Add_dgv
            // 
            this.dgv_Item_Add_dgv.AllowUserToAddRows = false;
            this.dgv_Item_Add_dgv.AllowUserToDeleteRows = false;
            this.dgv_Item_Add_dgv.AllowUserToResizeColumns = false;
            this.dgv_Item_Add_dgv.AllowUserToResizeRows = false;
            this.dgv_Item_Add_dgv.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgv_Item_Add_dgv.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(200)))), ((int)(((byte)(230)))));
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(200)))), ((int)(((byte)(90)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgv_Item_Add_dgv.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgv_Item_Add_dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_Item_Add_dgv.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgv_Item_Add_dgv.EnableHeadersVisualStyles = false;
            this.dgv_Item_Add_dgv.Location = new System.Drawing.Point(0, 75);
            this.dgv_Item_Add_dgv.MultiSelect = false;
            this.dgv_Item_Add_dgv.Name = "dgv_Item_Add_dgv";
            this.dgv_Item_Add_dgv.ReadOnly = true;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(200)))), ((int)(((byte)(90)))));
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.Black;
            this.dgv_Item_Add_dgv.RowsDefaultCellStyle = dataGridViewCellStyle4;
            this.dgv_Item_Add_dgv.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv_Item_Add_dgv.Size = new System.Drawing.Size(670, 288);
            this.dgv_Item_Add_dgv.TabIndex = 0;
            this.dgv_Item_Add_dgv.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.Dgv_Item_Add_CellDoubleClick);
            this.dgv_Item_Add_dgv.RowDividerDoubleClick += new System.Windows.Forms.DataGridViewRowDividerDoubleClickEventHandler(this.Dgv_Item_Add_RowDividerDoubleClick);
            this.dgv_Item_Add_dgv.RowHeaderMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.Dgv_Item_Add_RowHeaderMouseDoubleClick);
            this.dgv_Item_Add_dgv.SelectionChanged += new System.EventHandler(this.Dgv_Item_Add_SelectionChanged);
            this.dgv_Item_Add_dgv.DoubleClick += new System.EventHandler(this.Dgv_Item_Add_DoubleClick);
            this.dgv_Item_Add_dgv.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.Dgv_Item_Add_RowHeaderMouseDoubleClick);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.button2_btn);
            this.panel1.Controls.Add(this.button1_btn);
            this.panel1.Controls.Add(this.txt_pons);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.txt_qut);
            this.panel1.Controls.Add(this.dtp_E);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 363);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(670, 78);
            this.panel1.TabIndex = 1;
            // 
            // button2_btn
            // 
            this.button2_btn.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2_btn.Location = new System.Drawing.Point(216, 40);
            this.button2_btn.Name = "button2_btn";
            this.button2_btn.Size = new System.Drawing.Size(83, 31);
            this.button2_btn.TabIndex = 11;
            this.button2_btn.Text = "إلغاء";
            this.button2_btn.UseVisualStyleBackColor = true;
            this.button2_btn.Click += new System.EventHandler(this.Button2_Click);
            // 
            // button1_btn
            // 
            this.button1_btn.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1_btn.Location = new System.Drawing.Point(350, 40);
            this.button1_btn.Name = "button1_btn";
            this.button1_btn.Size = new System.Drawing.Size(83, 31);
            this.button1_btn.TabIndex = 10;
            this.button1_btn.Text = "موافق";
            this.button1_btn.UseVisualStyleBackColor = true;
            this.button1_btn.Click += new System.EventHandler(this.Button1_Click);
            // 
            // txt_pons
            // 
            this.txt_pons.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_pons.ForeColor = System.Drawing.Color.Red;
            this.txt_pons.Location = new System.Drawing.Point(91, 3);
            this.txt_pons.MaxLength = 5;
            this.txt_pons.Name = "txt_pons";
            this.txt_pons.Size = new System.Drawing.Size(95, 26);
            this.txt_pons.TabIndex = 9;
            this.txt_pons.Text = "0";
            this.txt_pons.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Arial", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(192, 8);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(57, 22);
            this.label4.TabIndex = 8;
            this.label4.Text = "البونص";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(383, 7);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(104, 22);
            this.label2.TabIndex = 7;
            this.label2.Text = "تاريخ الصلاحية";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Arial", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Red;
            this.label3.Location = new System.Drawing.Point(594, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(46, 22);
            this.label3.TabIndex = 6;
            this.label3.Text = "الكمية";
            this.label3.Visible = false;
            // 
            // txt_qut
            // 
            this.txt_qut.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_qut.ForeColor = System.Drawing.Color.Red;
            this.txt_qut.Location = new System.Drawing.Point(493, 5);
            this.txt_qut.MaxLength = 5;
            this.txt_qut.Name = "txt_qut";
            this.txt_qut.Size = new System.Drawing.Size(95, 26);
            this.txt_qut.TabIndex = 5;
            this.txt_qut.Text = "1";
            this.txt_qut.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txt_qut.Visible = false;
            // 
            // dtp_E
            // 
            this.dtp_E.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtp_E.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtp_E.Location = new System.Drawing.Point(255, 5);
            this.dtp_E.Name = "dtp_E";
            this.dtp_E.Size = new System.Drawing.Size(122, 27);
            this.dtp_E.TabIndex = 4;
            this.dtp_E.ValueChanged += new System.EventHandler(this.DateTimePicker2_ValueChanged);
            this.dtp_E.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.DateTimePicker2_KeyPress);
            this.dtp_E.MouseDown += new System.Windows.Forms.MouseEventHandler(this.DateTimePicker2_MouseDown);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.panel5);
            this.panel2.Controls.Add(this.panel4);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.txt_Serch_Item);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(670, 75);
            this.panel2.TabIndex = 2;
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.Color.DarkGray;
            this.panel5.Controls.Add(this.ch_Sp_All);
            this.panel5.Controls.Add(this.ch_NoStop);
            this.panel5.Controls.Add(this.ch_Stop);
            this.panel5.Location = new System.Drawing.Point(3, 2);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(237, 37);
            this.panel5.TabIndex = 10;
            // 
            // ch_Sp_All
            // 
            this.ch_Sp_All.AutoSize = true;
            this.ch_Sp_All.Checked = true;
            this.ch_Sp_All.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ch_Sp_All.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.ch_Sp_All.Location = new System.Drawing.Point(3, 5);
            this.ch_Sp_All.Name = "ch_Sp_All";
            this.ch_Sp_All.Size = new System.Drawing.Size(46, 22);
            this.ch_Sp_All.TabIndex = 11;
            this.ch_Sp_All.TabStop = true;
            this.ch_Sp_All.Text = "الكل";
            this.ch_Sp_All.UseVisualStyleBackColor = true;
            this.ch_Sp_All.CheckedChanged += new System.EventHandler(this.Ch_Sp_All_CheckedChanged);
            // 
            // ch_NoStop
            // 
            this.ch_NoStop.AutoSize = true;
            this.ch_NoStop.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ch_NoStop.ForeColor = System.Drawing.Color.Blue;
            this.ch_NoStop.Location = new System.Drawing.Point(72, 5);
            this.ch_NoStop.Name = "ch_NoStop";
            this.ch_NoStop.Size = new System.Drawing.Size(77, 22);
            this.ch_NoStop.TabIndex = 10;
            this.ch_NoStop.Text = "غير موقف";
            this.ch_NoStop.UseVisualStyleBackColor = true;
            this.ch_NoStop.CheckedChanged += new System.EventHandler(this.Ch_NoStop_CheckedChanged);
            // 
            // ch_Stop
            // 
            this.ch_Stop.AutoSize = true;
            this.ch_Stop.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ch_Stop.ForeColor = System.Drawing.Color.Blue;
            this.ch_Stop.Location = new System.Drawing.Point(154, 5);
            this.ch_Stop.Name = "ch_Stop";
            this.ch_Stop.Size = new System.Drawing.Size(55, 22);
            this.ch_Stop.TabIndex = 9;
            this.ch_Stop.Text = "موقف";
            this.ch_Stop.UseVisualStyleBackColor = true;
            this.ch_Stop.CheckedChanged += new System.EventHandler(this.Ch_Stop_CheckedChanged);
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.panel4.Controls.Add(this.ch_All);
            this.panel4.Controls.Add(this.ch_NoDow);
            this.panel4.Controls.Add(this.ch_Dow);
            this.panel4.Location = new System.Drawing.Point(3, 40);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(237, 32);
            this.panel4.TabIndex = 12;
            // 
            // ch_All
            // 
            this.ch_All.AutoSize = true;
            this.ch_All.Checked = true;
            this.ch_All.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ch_All.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.ch_All.Location = new System.Drawing.Point(4, 5);
            this.ch_All.Name = "ch_All";
            this.ch_All.Size = new System.Drawing.Size(46, 22);
            this.ch_All.TabIndex = 8;
            this.ch_All.TabStop = true;
            this.ch_All.Text = "الكل";
            this.ch_All.UseVisualStyleBackColor = true;
            this.ch_All.CheckedChanged += new System.EventHandler(this.Ch_All_CheckedChanged);
            // 
            // ch_NoDow
            // 
            this.ch_NoDow.AutoSize = true;
            this.ch_NoDow.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ch_NoDow.ForeColor = System.Drawing.Color.Black;
            this.ch_NoDow.Location = new System.Drawing.Point(72, 4);
            this.ch_NoDow.Name = "ch_NoDow";
            this.ch_NoDow.Size = new System.Drawing.Size(71, 22);
            this.ch_NoDow.TabIndex = 7;
            this.ch_NoDow.Text = "غير دواء";
            this.ch_NoDow.UseVisualStyleBackColor = true;
            this.ch_NoDow.CheckedChanged += new System.EventHandler(this.Ch_NoDow_CheckedChanged);
            // 
            // ch_Dow
            // 
            this.ch_Dow.AutoSize = true;
            this.ch_Dow.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ch_Dow.ForeColor = System.Drawing.Color.Black;
            this.ch_Dow.Location = new System.Drawing.Point(154, 4);
            this.ch_Dow.Name = "ch_Dow";
            this.ch_Dow.Size = new System.Drawing.Size(49, 22);
            this.ch_Dow.TabIndex = 6;
            this.ch_Dow.Text = "دواء";
            this.ch_Dow.UseVisualStyleBackColor = true;
            this.ch_Dow.CheckedChanged += new System.EventHandler(this.Ch_Dow_CheckedChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(557, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(83, 22);
            this.label1.TabIndex = 3;
            this.label1.Text = "اكتب للبحث ";
            // 
            // txt_Serch_Item
            // 
            this.txt_Serch_Item.BackColor = System.Drawing.Color.White;
            this.txt_Serch_Item.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_Serch_Item.Location = new System.Drawing.Point(255, 25);
            this.txt_Serch_Item.Name = "txt_Serch_Item";
            this.txt_Serch_Item.Size = new System.Drawing.Size(296, 26);
            this.txt_Serch_Item.TabIndex = 2;
            this.txt_Serch_Item.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txt_Serch_Item.TextChanged += new System.EventHandler(this.Txt_Serch_Item_TextChanged);
            // 
            // Item_Data
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(670, 441);
            this.Controls.Add(this.dgv_Item_Add_dgv);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.Name = "Item_Data";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RightToLeftLayout = true;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "الصنف ";
            this.Load += new System.EventHandler(this.Item_Data_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Item_Add_dgv)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.Label label1;
        public System.Windows.Forms.TextBox txt_Serch_Item;
        public System.Windows.Forms.Panel panel4;
        public System.Windows.Forms.RadioButton ch_All;
        public System.Windows.Forms.RadioButton ch_NoDow;
        public System.Windows.Forms.RadioButton ch_Dow;
        public System.Windows.Forms.Panel panel5;
        public System.Windows.Forms.RadioButton ch_Sp_All;
        public System.Windows.Forms.RadioButton ch_NoStop;
        public System.Windows.Forms.RadioButton ch_Stop;
        public System.Windows.Forms.DataGridView dgv_Item_Add_dgv;
        public System.Windows.Forms.Panel panel1;
        public System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button button2_btn;
        private System.Windows.Forms.Button button1_btn;
        private System.Windows.Forms.TextBox txt_pons;
        public System.Windows.Forms.Label label4;
        public System.Windows.Forms.Label label2;
        public System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txt_qut;
        private System.Windows.Forms.DateTimePicker dtp_E;
    }
}