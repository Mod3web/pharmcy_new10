namespace Manag_ph.Client.Contracts
{
    partial class Discount_cont_frm
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.labelControl79 = new DevExpress.XtraEditors.LabelControl();
            this.button8_btn = new System.Windows.Forms.Button();
            this.txt_Dise_bill_cont = new System.Windows.Forms.TextBox();
            this.txt_Discount_cont = new System.Windows.Forms.TextBox();
            this.labelControl76 = new DevExpress.XtraEditors.LabelControl();
            this.panel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(385, 134);
            this.panel1.TabIndex = 0;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.labelControl79);
            this.groupBox1.Controls.Add(this.button8_btn);
            this.groupBox1.Controls.Add(this.txt_Dise_bill_cont);
            this.groupBox1.Controls.Add(this.txt_Discount_cont);
            this.groupBox1.Controls.Add(this.labelControl76);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.groupBox1.Size = new System.Drawing.Size(385, 134);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "groupBox1";
            this.groupBox1.Enter += new System.EventHandler(this.GroupBox1_Enter);
            // 
            // labelControl79
            // 
            this.labelControl79.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.labelControl79.Appearance.Font = new System.Drawing.Font("AGA Arabesque", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl79.Appearance.Options.UseFont = true;
            this.labelControl79.Location = new System.Drawing.Point(268, 53);
            this.labelControl79.Name = "labelControl79";
            this.labelControl79.Size = new System.Drawing.Size(111, 22);
            this.labelControl79.TabIndex = 87;
            this.labelControl79.Text = "نسبة دفع العميل :";
            // 
            // button8_btn
            // 
            this.button8_btn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(120)))), ((int)(((byte)(210)))));
            this.button8_btn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button8_btn.FlatAppearance.BorderSize = 0;
            this.button8_btn.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold);
            this.button8_btn.ForeColor = System.Drawing.Color.White;
            this.button8_btn.Location = new System.Drawing.Point(125, 92);
            this.button8_btn.Name = "button8_btn";
            this.button8_btn.Size = new System.Drawing.Size(137, 36);
            this.button8_btn.TabIndex = 86;
            this.button8_btn.Text = "موافق";
            this.button8_btn.UseVisualStyleBackColor = false;
            this.button8_btn.Click += new System.EventHandler(this.Button8_Click);
            // 
            // txt_Dise_bill_cont
            // 
            this.txt_Dise_bill_cont.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txt_Dise_bill_cont.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_Dise_bill_cont.Location = new System.Drawing.Point(41, 50);
            this.txt_Dise_bill_cont.Name = "txt_Dise_bill_cont";
            this.txt_Dise_bill_cont.Size = new System.Drawing.Size(221, 25);
            this.txt_Dise_bill_cont.TabIndex = 74;
            // 
            // txt_Discount_cont
            // 
            this.txt_Discount_cont.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txt_Discount_cont.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_Discount_cont.Location = new System.Drawing.Point(41, 19);
            this.txt_Discount_cont.Name = "txt_Discount_cont";
            this.txt_Discount_cont.Size = new System.Drawing.Size(221, 25);
            this.txt_Discount_cont.TabIndex = 72;
            this.txt_Discount_cont.TextChanged += new System.EventHandler(this.Txt_num_cont_TextChanged);
            // 
            // labelControl76
            // 
            this.labelControl76.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.labelControl76.Appearance.Font = new System.Drawing.Font("AGA Arabesque", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl76.Appearance.Options.UseFont = true;
            this.labelControl76.Location = new System.Drawing.Point(268, 22);
            this.labelControl76.Name = "labelControl76";
            this.labelControl76.Size = new System.Drawing.Size(87, 22);
            this.labelControl76.TabIndex = 71;
            this.labelControl76.Text = "نسبة الخصم :";
            // 
            // Discount_cont_frm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(385, 134);
            this.ControlBox = false;
            this.Controls.Add(this.panel1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Discount_cont_frm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Discount_cont_frm";
            this.Load += new System.EventHandler(this.Discount_cont_frm_Load);
            this.panel1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.GroupBox groupBox1;
        public System.Windows.Forms.TextBox txt_Dise_bill_cont;
        public System.Windows.Forms.TextBox txt_Discount_cont;
        private DevExpress.XtraEditors.LabelControl labelControl76;
        public System.Windows.Forms.Button button8_btn;
        public DevExpress.XtraEditors.LabelControl labelControl79;
    }
}