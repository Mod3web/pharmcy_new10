﻿namespace Manag_ph.Sales.Footer_sals
{
    partial class frm_Save_footer_sals
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
            this.txt_sals_begin_cash = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txt_sals_pand_cash = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txt_after_pand_cash = new System.Windows.Forms.TextBox();
            this.button1_btn = new System.Windows.Forms.Button();
            this.button2_btn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txt_sals_begin_cash
            // 
            this.txt_sals_begin_cash.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.txt_sals_begin_cash.Font = new System.Drawing.Font("Arial", 20F, System.Drawing.FontStyle.Bold);
            this.txt_sals_begin_cash.Location = new System.Drawing.Point(14, 33);
            this.txt_sals_begin_cash.Name = "txt_sals_begin_cash";
            this.txt_sals_begin_cash.ReadOnly = true;
            this.txt_sals_begin_cash.Size = new System.Drawing.Size(278, 38);
            this.txt_sals_begin_cash.TabIndex = 0;
            this.txt_sals_begin_cash.Text = "0.00";
            this.txt_sals_begin_cash.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 16F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(120, 4);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(72, 26);
            this.label1.TabIndex = 1;
            this.label1.Text = "المطلوب";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial", 16F, System.Drawing.FontStyle.Bold);
            this.label2.Location = new System.Drawing.Point(124, 92);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(68, 26);
            this.label2.TabIndex = 3;
            this.label2.Text = "المدفوع";
            // 
            // txt_sals_pand_cash
            // 
            this.txt_sals_pand_cash.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.txt_sals_pand_cash.Font = new System.Drawing.Font("Arial", 20F, System.Drawing.FontStyle.Bold);
            this.txt_sals_pand_cash.Location = new System.Drawing.Point(14, 121);
            this.txt_sals_pand_cash.Name = "txt_sals_pand_cash";
            this.txt_sals_pand_cash.Size = new System.Drawing.Size(278, 38);
            this.txt_sals_pand_cash.TabIndex = 2;
            this.txt_sals_pand_cash.Text = "0.00";
            this.txt_sals_pand_cash.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txt_sals_pand_cash.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Txt_sals_pand_cash_KeyDown);
            this.txt_sals_pand_cash.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Txt_sals_pand_cash_KeyPress);
            this.txt_sals_pand_cash.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Txt_sals_pand_cash_KeyUp);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Arial", 16F, System.Drawing.FontStyle.Bold);
            this.label3.Location = new System.Drawing.Point(129, 176);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 26);
            this.label3.TabIndex = 5;
            this.label3.Text = "الباقي";
            // 
            // txt_after_pand_cash
            // 
            this.txt_after_pand_cash.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.txt_after_pand_cash.Font = new System.Drawing.Font("Arial", 20F, System.Drawing.FontStyle.Bold);
            this.txt_after_pand_cash.Location = new System.Drawing.Point(14, 205);
            this.txt_after_pand_cash.Name = "txt_after_pand_cash";
            this.txt_after_pand_cash.ReadOnly = true;
            this.txt_after_pand_cash.Size = new System.Drawing.Size(278, 38);
            this.txt_after_pand_cash.TabIndex = 4;
            this.txt_after_pand_cash.Text = "0.00";
            this.txt_after_pand_cash.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // button1_btn
            // 
            this.button1_btn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(120)))), ((int)(((byte)(210)))));
            this.button1_btn.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.button1_btn.FlatAppearance.BorderSize = 2;
            this.button1_btn.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold);
            this.button1_btn.ForeColor = System.Drawing.Color.White;
            this.button1_btn.Location = new System.Drawing.Point(12, 297);
            this.button1_btn.Name = "button1_btn";
            this.button1_btn.Size = new System.Drawing.Size(136, 50);
            this.button1_btn.TabIndex = 6;
            this.button1_btn.Text = "حفظ";
            this.button1_btn.UseVisualStyleBackColor = false;
            this.button1_btn.Click += new System.EventHandler(this.Button1_Click);
            // 
            // button2_btn
            // 
            this.button2_btn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(120)))), ((int)(((byte)(210)))));
            this.button2_btn.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.button2_btn.FlatAppearance.BorderSize = 2;
            this.button2_btn.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold);
            this.button2_btn.ForeColor = System.Drawing.Color.White;
            this.button2_btn.Location = new System.Drawing.Point(154, 297);
            this.button2_btn.Name = "button2_btn";
            this.button2_btn.Size = new System.Drawing.Size(136, 50);
            this.button2_btn.TabIndex = 7;
            this.button2_btn.Text = "الغاء";
            this.button2_btn.UseVisualStyleBackColor = false;
            this.button2_btn.Click += new System.EventHandler(this.Button2_btn_Click);
            // 
            // frm_Save_footer_sals
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(297, 359);
            this.Controls.Add(this.button2_btn);
            this.Controls.Add(this.button1_btn);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txt_after_pand_cash);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txt_sals_pand_cash);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txt_sals_begin_cash);
            this.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frm_Save_footer_sals";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RightToLeftLayout = true;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "المدفوع";
            this.Load += new System.EventHandler(this.Frm_Save_footer_sals_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button button1_btn;
        private System.Windows.Forms.Button button2_btn;
        public System.Windows.Forms.TextBox txt_sals_pand_cash;
        public System.Windows.Forms.TextBox txt_after_pand_cash;
        public System.Windows.Forms.TextBox txt_sals_begin_cash;
    }
}