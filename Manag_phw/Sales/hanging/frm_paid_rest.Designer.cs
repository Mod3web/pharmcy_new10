namespace Manag_ph.Sales
{
    partial class frm_paid_rest
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
            this.label1 = new System.Windows.Forms.Label();
            this.txt_name_Cline_foot_sals_haing = new System.Windows.Forms.TextBox();
            this.txt_pain_pric_sals_end = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txt_pain_pric_sals = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txt_rest_pric_sals = new System.Windows.Forms.TextBox();
            this.button1_btn = new System.Windows.Forms.Button();
            this.button2_btn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(3, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 19);
            this.label1.TabIndex = 0;
            this.label1.Text = "اسم العميل";
            // 
            // txt_name_Cline_foot_sals_haing
            // 
            this.txt_name_Cline_foot_sals_haing.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold);
            this.txt_name_Cline_foot_sals_haing.Location = new System.Drawing.Point(74, 12);
            this.txt_name_Cline_foot_sals_haing.Name = "txt_name_Cline_foot_sals_haing";
            this.txt_name_Cline_foot_sals_haing.Size = new System.Drawing.Size(229, 26);
            this.txt_name_Cline_foot_sals_haing.TabIndex = 1;
            // 
            // txt_pain_pric_sals_end
            // 
            this.txt_pain_pric_sals_end.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold);
            this.txt_pain_pric_sals_end.Location = new System.Drawing.Point(74, 51);
            this.txt_pain_pric_sals_end.Name = "txt_pain_pric_sals_end";
            this.txt_pain_pric_sals_end.ReadOnly = true;
            this.txt_pain_pric_sals_end.Size = new System.Drawing.Size(228, 26);
            this.txt_pain_pric_sals_end.TabIndex = 2;
            this.txt_pain_pric_sals_end.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial", 14F, System.Drawing.FontStyle.Bold);
            this.label2.Location = new System.Drawing.Point(7, 55);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(61, 22);
            this.label2.TabIndex = 3;
            this.label2.Text = "المطلوب";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Arial", 14F, System.Drawing.FontStyle.Bold);
            this.label3.Location = new System.Drawing.Point(10, 84);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(58, 22);
            this.label3.TabIndex = 5;
            this.label3.Text = "المدفوع";
            // 
            // txt_pain_pric_sals
            // 
            this.txt_pain_pric_sals.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold);
            this.txt_pain_pric_sals.Location = new System.Drawing.Point(74, 80);
            this.txt_pain_pric_sals.Name = "txt_pain_pric_sals";
            this.txt_pain_pric_sals.Size = new System.Drawing.Size(228, 26);
            this.txt_pain_pric_sals.TabIndex = 4;
            this.txt_pain_pric_sals.Text = "0.00";
            this.txt_pain_pric_sals.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txt_pain_pric_sals.TextChanged += new System.EventHandler(this.Txt_pain_pric_sals_TextChanged);
            this.txt_pain_pric_sals.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Txt_pain_pric_sals_KeyPress);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Arial", 14F, System.Drawing.FontStyle.Bold);
            this.label4.Location = new System.Drawing.Point(21, 113);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(44, 22);
            this.label4.TabIndex = 7;
            this.label4.Text = "الباقي";
            // 
            // txt_rest_pric_sals
            // 
            this.txt_rest_pric_sals.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold);
            this.txt_rest_pric_sals.Location = new System.Drawing.Point(74, 109);
            this.txt_rest_pric_sals.Name = "txt_rest_pric_sals";
            this.txt_rest_pric_sals.ReadOnly = true;
            this.txt_rest_pric_sals.Size = new System.Drawing.Size(228, 26);
            this.txt_rest_pric_sals.TabIndex = 6;
            this.txt_rest_pric_sals.Text = "0.00";
            this.txt_rest_pric_sals.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // button1_btn
            // 
            this.button1_btn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(120)))), ((int)(((byte)(210)))));
            this.button1_btn.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold);
            this.button1_btn.ForeColor = System.Drawing.Color.White;
            this.button1_btn.Location = new System.Drawing.Point(95, 140);
            this.button1_btn.Name = "button1_btn";
            this.button1_btn.Size = new System.Drawing.Size(75, 37);
            this.button1_btn.TabIndex = 8;
            this.button1_btn.Text = "حفظ";
            this.button1_btn.UseVisualStyleBackColor = false;
            this.button1_btn.Click += new System.EventHandler(this.Button1_Click);
            // 
            // button2_btn
            // 
            this.button2_btn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(120)))), ((int)(((byte)(210)))));
            this.button2_btn.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold);
            this.button2_btn.ForeColor = System.Drawing.Color.White;
            this.button2_btn.Location = new System.Drawing.Point(195, 140);
            this.button2_btn.Name = "button2_btn";
            this.button2_btn.Size = new System.Drawing.Size(75, 37);
            this.button2_btn.TabIndex = 9;
            this.button2_btn.Text = "الغاء";
            this.button2_btn.UseVisualStyleBackColor = false;
            this.button2_btn.Click += new System.EventHandler(this.Button2_Click);
            // 
            // frm_paid_rest
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(314, 189);
            this.Controls.Add(this.button2_btn);
            this.Controls.Add(this.button1_btn);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txt_rest_pric_sals);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txt_pain_pric_sals);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txt_pain_pric_sals_end);
            this.Controls.Add(this.txt_name_Cline_foot_sals_haing);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frm_paid_rest";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RightToLeftLayout = true;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "تعليق فاتورة";
            this.Load += new System.EventHandler(this.Frm_paid_rest_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        public System.Windows.Forms.TextBox txt_name_Cline_foot_sals_haing;
        public System.Windows.Forms.TextBox txt_pain_pric_sals_end;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        public System.Windows.Forms.TextBox txt_pain_pric_sals;
        private System.Windows.Forms.Label label4;
        public System.Windows.Forms.TextBox txt_rest_pric_sals;
        private System.Windows.Forms.Button button1_btn;
        private System.Windows.Forms.Button button2_btn;
    }
}