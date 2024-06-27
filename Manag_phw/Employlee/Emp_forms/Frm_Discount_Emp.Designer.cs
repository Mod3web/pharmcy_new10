namespace Manag_ph.Employlee.Emp_forms
{
    partial class Frm_Discount_Emp
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
            this.panel_discount_Emp = new System.Windows.Forms.Panel();
            this.dateTime_month = new System.Windows.Forms.DateTimePicker();
            this.btn_close_discount_btn = new System.Windows.Forms.Button();
            this.btn_save_discount_btn = new System.Windows.Forms.Button();
            this.btn_add_Emp_doscount_btn = new System.Windows.Forms.Button();
            this.txt_name_Emp = new System.Windows.Forms.TextBox();
            this.txt_code_Emp = new System.Windows.Forms.TextBox();
            this.txt_nots_discount = new System.Windows.Forms.TextBox();
            this.txt_value_absen = new System.Windows.Forms.TextBox();
            this.txt_value_day_absen = new System.Windows.Forms.TextBox();
            this.txt_count_absincs = new System.Windows.Forms.TextBox();
            this.txt_value_discount = new System.Windows.Forms.TextBox();
            this.lbl_value_absen = new System.Windows.Forms.Label();
            this.lbl_value_day_absen = new System.Windows.Forms.Label();
            this.lbl_count_absincs = new System.Windows.Forms.Label();
            this.lbl_code_Emp = new System.Windows.Forms.Label();
            this.lbl_nots_discount = new System.Windows.Forms.Label();
            this.lbl_month = new System.Windows.Forms.Label();
            this.lbl_value_discount = new System.Windows.Forms.Label();
            this.lbl_name_main_discount = new System.Windows.Forms.Label();
            this.panel_discount_Emp.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel_discount_Emp
            // 
            this.panel_discount_Emp.Controls.Add(this.dateTime_month);
            this.panel_discount_Emp.Controls.Add(this.btn_close_discount_btn);
            this.panel_discount_Emp.Controls.Add(this.btn_save_discount_btn);
            this.panel_discount_Emp.Controls.Add(this.btn_add_Emp_doscount_btn);
            this.panel_discount_Emp.Controls.Add(this.txt_name_Emp);
            this.panel_discount_Emp.Controls.Add(this.txt_code_Emp);
            this.panel_discount_Emp.Controls.Add(this.txt_nots_discount);
            this.panel_discount_Emp.Controls.Add(this.txt_value_absen);
            this.panel_discount_Emp.Controls.Add(this.txt_value_day_absen);
            this.panel_discount_Emp.Controls.Add(this.txt_count_absincs);
            this.panel_discount_Emp.Controls.Add(this.txt_value_discount);
            this.panel_discount_Emp.Controls.Add(this.lbl_value_absen);
            this.panel_discount_Emp.Controls.Add(this.lbl_value_day_absen);
            this.panel_discount_Emp.Controls.Add(this.lbl_count_absincs);
            this.panel_discount_Emp.Controls.Add(this.lbl_code_Emp);
            this.panel_discount_Emp.Controls.Add(this.lbl_nots_discount);
            this.panel_discount_Emp.Controls.Add(this.lbl_month);
            this.panel_discount_Emp.Controls.Add(this.lbl_value_discount);
            this.panel_discount_Emp.Controls.Add(this.lbl_name_main_discount);
            this.panel_discount_Emp.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel_discount_Emp.Location = new System.Drawing.Point(0, 0);
            this.panel_discount_Emp.Name = "panel_discount_Emp";
            this.panel_discount_Emp.Size = new System.Drawing.Size(377, 276);
            this.panel_discount_Emp.TabIndex = 0;
            // 
            // dateTime_month
            // 
            this.dateTime_month.CustomFormat = "yyyy-MM";
            this.dateTime_month.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateTime_month.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTime_month.Location = new System.Drawing.Point(40, 54);
            this.dateTime_month.Name = "dateTime_month";
            this.dateTime_month.ShowUpDown = true;
            this.dateTime_month.Size = new System.Drawing.Size(105, 21);
            this.dateTime_month.TabIndex = 41;
            this.dateTime_month.ValueChanged += new System.EventHandler(this.DateTime_month_ValueChanged);
            // 
            // btn_close_discount_btn
            // 
            this.btn_close_discount_btn.BackColor = System.Drawing.Color.Red;
            this.btn_close_discount_btn.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold);
            this.btn_close_discount_btn.ForeColor = System.Drawing.Color.White;
            this.btn_close_discount_btn.Location = new System.Drawing.Point(85, 233);
            this.btn_close_discount_btn.Name = "btn_close_discount_btn";
            this.btn_close_discount_btn.Size = new System.Drawing.Size(59, 32);
            this.btn_close_discount_btn.TabIndex = 40;
            this.btn_close_discount_btn.Text = "إغلاق";
            this.btn_close_discount_btn.UseVisualStyleBackColor = false;
            this.btn_close_discount_btn.Click += new System.EventHandler(this.Btn_close_discount_btn_Click);
            // 
            // btn_save_discount_btn
            // 
            this.btn_save_discount_btn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(120)))), ((int)(((byte)(210)))));
            this.btn_save_discount_btn.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold);
            this.btn_save_discount_btn.ForeColor = System.Drawing.Color.White;
            this.btn_save_discount_btn.Location = new System.Drawing.Point(228, 233);
            this.btn_save_discount_btn.Name = "btn_save_discount_btn";
            this.btn_save_discount_btn.Size = new System.Drawing.Size(59, 32);
            this.btn_save_discount_btn.TabIndex = 39;
            this.btn_save_discount_btn.Text = "حفظ";
            this.btn_save_discount_btn.UseVisualStyleBackColor = false;
            this.btn_save_discount_btn.Click += new System.EventHandler(this.Btn_save_discount_btn_Click);
            // 
            // btn_add_Emp_doscount_btn
            // 
            this.btn_add_Emp_doscount_btn.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Bold);
            this.btn_add_Emp_doscount_btn.Location = new System.Drawing.Point(11, 129);
            this.btn_add_Emp_doscount_btn.Name = "btn_add_Emp_doscount_btn";
            this.btn_add_Emp_doscount_btn.Size = new System.Drawing.Size(31, 22);
            this.btn_add_Emp_doscount_btn.TabIndex = 38;
            this.btn_add_Emp_doscount_btn.Text = "...";
            this.btn_add_Emp_doscount_btn.UseVisualStyleBackColor = true;
            this.btn_add_Emp_doscount_btn.Click += new System.EventHandler(this.Btn_add_Emp_doscount_btn_Click);
            // 
            // txt_name_Emp
            // 
            this.txt_name_Emp.BackColor = System.Drawing.Color.PapayaWhip;
            this.txt_name_Emp.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_name_Emp.Location = new System.Drawing.Point(43, 129);
            this.txt_name_Emp.Name = "txt_name_Emp";
            this.txt_name_Emp.ReadOnly = true;
            this.txt_name_Emp.Size = new System.Drawing.Size(181, 21);
            this.txt_name_Emp.TabIndex = 14;
            this.txt_name_Emp.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txt_code_Emp
            // 
            this.txt_code_Emp.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_code_Emp.Location = new System.Drawing.Point(226, 129);
            this.txt_code_Emp.Name = "txt_code_Emp";
            this.txt_code_Emp.ReadOnly = true;
            this.txt_code_Emp.Size = new System.Drawing.Size(46, 21);
            this.txt_code_Emp.TabIndex = 13;
            this.txt_code_Emp.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txt_code_Emp.DoubleClick += new System.EventHandler(this.Txt_code_Emp_DoubleClick);
            this.txt_code_Emp.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Txt_code_Emp_KeyPress);
            // 
            // txt_nots_discount
            // 
            this.txt_nots_discount.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_nots_discount.Location = new System.Drawing.Point(43, 90);
            this.txt_nots_discount.Name = "txt_nots_discount";
            this.txt_nots_discount.Size = new System.Drawing.Size(243, 21);
            this.txt_nots_discount.TabIndex = 12;
            this.txt_nots_discount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txt_value_absen
            // 
            this.txt_value_absen.BackColor = System.Drawing.Color.PapayaWhip;
            this.txt_value_absen.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_value_absen.Location = new System.Drawing.Point(111, 197);
            this.txt_value_absen.Name = "txt_value_absen";
            this.txt_value_absen.ReadOnly = true;
            this.txt_value_absen.Size = new System.Drawing.Size(85, 21);
            this.txt_value_absen.TabIndex = 11;
            this.txt_value_absen.Text = "0";
            this.txt_value_absen.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txt_value_day_absen
            // 
            this.txt_value_day_absen.BackColor = System.Drawing.Color.PapayaWhip;
            this.txt_value_day_absen.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_value_day_absen.Location = new System.Drawing.Point(43, 165);
            this.txt_value_day_absen.Name = "txt_value_day_absen";
            this.txt_value_day_absen.ReadOnly = true;
            this.txt_value_day_absen.Size = new System.Drawing.Size(69, 21);
            this.txt_value_day_absen.TabIndex = 10;
            this.txt_value_day_absen.Text = "0";
            this.txt_value_day_absen.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txt_count_absincs
            // 
            this.txt_count_absincs.BackColor = System.Drawing.Color.PapayaWhip;
            this.txt_count_absincs.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_count_absincs.Location = new System.Drawing.Point(215, 165);
            this.txt_count_absincs.Name = "txt_count_absincs";
            this.txt_count_absincs.ReadOnly = true;
            this.txt_count_absincs.Size = new System.Drawing.Size(57, 21);
            this.txt_count_absincs.TabIndex = 9;
            this.txt_count_absincs.Text = "0";
            this.txt_count_absincs.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txt_value_discount
            // 
            this.txt_value_discount.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_value_discount.Location = new System.Drawing.Point(228, 54);
            this.txt_value_discount.Name = "txt_value_discount";
            this.txt_value_discount.Size = new System.Drawing.Size(66, 21);
            this.txt_value_discount.TabIndex = 8;
            this.txt_value_discount.Text = "0";
            this.txt_value_discount.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txt_value_discount.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Txt_value_discount_KeyDown);
            this.txt_value_discount.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Txt_value_discount_KeyPress);
            // 
            // lbl_value_absen
            // 
            this.lbl_value_absen.AutoSize = true;
            this.lbl_value_absen.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_value_absen.ForeColor = System.Drawing.Color.Black;
            this.lbl_value_absen.Location = new System.Drawing.Point(199, 200);
            this.lbl_value_absen.Name = "lbl_value_absen";
            this.lbl_value_absen.Size = new System.Drawing.Size(67, 16);
            this.lbl_value_absen.TabIndex = 7;
            this.lbl_value_absen.Text = ": قيمة الغياب";
            // 
            // lbl_value_day_absen
            // 
            this.lbl_value_day_absen.AutoSize = true;
            this.lbl_value_day_absen.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_value_day_absen.ForeColor = System.Drawing.Color.Black;
            this.lbl_value_day_absen.Location = new System.Drawing.Point(112, 168);
            this.lbl_value_day_absen.Name = "lbl_value_day_absen";
            this.lbl_value_day_absen.Size = new System.Drawing.Size(92, 16);
            this.lbl_value_day_absen.TabIndex = 6;
            this.lbl_value_day_absen.Text = ": قيمة اليوم الغياب";
            // 
            // lbl_count_absincs
            // 
            this.lbl_count_absincs.AutoSize = true;
            this.lbl_count_absincs.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_count_absincs.ForeColor = System.Drawing.Color.Black;
            this.lbl_count_absincs.Location = new System.Drawing.Point(272, 168);
            this.lbl_count_absincs.Name = "lbl_count_absincs";
            this.lbl_count_absincs.Size = new System.Drawing.Size(72, 16);
            this.lbl_count_absincs.TabIndex = 5;
            this.lbl_count_absincs.Text = ": موقت الغياب";
            // 
            // lbl_code_Emp
            // 
            this.lbl_code_Emp.AutoSize = true;
            this.lbl_code_Emp.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_code_Emp.ForeColor = System.Drawing.Color.Black;
            this.lbl_code_Emp.Location = new System.Drawing.Point(272, 131);
            this.lbl_code_Emp.Name = "lbl_code_Emp";
            this.lbl_code_Emp.Size = new System.Drawing.Size(97, 16);
            this.lbl_code_Emp.TabIndex = 4;
            this.lbl_code_Emp.Text = ": ادخل كود الموظف";
            // 
            // lbl_nots_discount
            // 
            this.lbl_nots_discount.AutoSize = true;
            this.lbl_nots_discount.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_nots_discount.ForeColor = System.Drawing.Color.Black;
            this.lbl_nots_discount.Location = new System.Drawing.Point(285, 92);
            this.lbl_nots_discount.Name = "lbl_nots_discount";
            this.lbl_nots_discount.Size = new System.Drawing.Size(83, 16);
            this.lbl_nots_discount.TabIndex = 3;
            this.lbl_nots_discount.Text = ": ملاحظة الخصم";
            // 
            // lbl_month
            // 
            this.lbl_month.AutoSize = true;
            this.lbl_month.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_month.ForeColor = System.Drawing.Color.Black;
            this.lbl_month.Location = new System.Drawing.Point(146, 57);
            this.lbl_month.Name = "lbl_month";
            this.lbl_month.Size = new System.Drawing.Size(43, 16);
            this.lbl_month.TabIndex = 2;
            this.lbl_month.Text = ": الشهر";
            // 
            // lbl_value_discount
            // 
            this.lbl_value_discount.AutoSize = true;
            this.lbl_value_discount.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_value_discount.ForeColor = System.Drawing.Color.Black;
            this.lbl_value_discount.Location = new System.Drawing.Point(296, 55);
            this.lbl_value_discount.Name = "lbl_value_discount";
            this.lbl_value_discount.Size = new System.Drawing.Size(69, 16);
            this.lbl_value_discount.TabIndex = 1;
            this.lbl_value_discount.Text = ": قيمة الخصم";
            // 
            // lbl_name_main_discount
            // 
            this.lbl_name_main_discount.AutoSize = true;
            this.lbl_name_main_discount.Font = new System.Drawing.Font("Arial", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_name_main_discount.ForeColor = System.Drawing.Color.DodgerBlue;
            this.lbl_name_main_discount.Location = new System.Drawing.Point(117, 9);
            this.lbl_name_main_discount.Name = "lbl_name_main_discount";
            this.lbl_name_main_discount.Size = new System.Drawing.Size(151, 26);
            this.lbl_name_main_discount.TabIndex = 0;
            this.lbl_name_main_discount.Text = "تسجيل خصم الغياب";
            // 
            // Frm_Discount_Emp
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(377, 276);
            this.Controls.Add(this.panel_discount_Emp);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Frm_Discount_Emp";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "تسجيل خصم الغياب";
            this.panel_discount_Emp.ResumeLayout(false);
            this.panel_discount_Emp.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel_discount_Emp;
        private System.Windows.Forms.Label lbl_value_absen;
        private System.Windows.Forms.Label lbl_value_day_absen;
        private System.Windows.Forms.Label lbl_count_absincs;
        private System.Windows.Forms.Label lbl_code_Emp;
        private System.Windows.Forms.Label lbl_nots_discount;
        private System.Windows.Forms.Label lbl_month;
        private System.Windows.Forms.Label lbl_value_discount;
        private System.Windows.Forms.Label lbl_name_main_discount;
        public System.Windows.Forms.TextBox txt_name_Emp;
        public System.Windows.Forms.TextBox txt_code_Emp;
        public System.Windows.Forms.TextBox txt_nots_discount;
        public System.Windows.Forms.TextBox txt_value_absen;
        public System.Windows.Forms.TextBox txt_value_day_absen;
        public System.Windows.Forms.TextBox txt_count_absincs;
        public System.Windows.Forms.TextBox txt_value_discount;
        public System.Windows.Forms.Button btn_close_discount_btn;
        public System.Windows.Forms.Button btn_save_discount_btn;
        private System.Windows.Forms.Button btn_add_Emp_doscount_btn;
        public System.Windows.Forms.DateTimePicker dateTime_month;
    }
}