
namespace Manag_ph.Item.forms
{
    partial class Frm_Client_Show
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
            this.btn_close_customer_btn = new System.Windows.Forms.Button();
            this.lab_customer = new DevExpress.XtraEditors.LabelControl();
            this.txt_customer_serch = new System.Windows.Forms.TextBox();
            this.btn_OK_customer_btn = new System.Windows.Forms.Button();
            this.dgv_Customer_dgv = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Customer_dgv)).BeginInit();
            this.SuspendLayout();
            // 
            // btn_close_customer_btn
            // 
            this.btn_close_customer_btn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(120)))), ((int)(((byte)(210)))));
            this.btn_close_customer_btn.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold);
            this.btn_close_customer_btn.ForeColor = System.Drawing.Color.White;
            this.btn_close_customer_btn.Location = new System.Drawing.Point(92, 376);
            this.btn_close_customer_btn.Name = "btn_close_customer_btn";
            this.btn_close_customer_btn.Size = new System.Drawing.Size(106, 31);
            this.btn_close_customer_btn.TabIndex = 30;
            this.btn_close_customer_btn.Text = "اغلاق";
            this.btn_close_customer_btn.UseVisualStyleBackColor = false;
            this.btn_close_customer_btn.Click += new System.EventHandler(this.btn_close_customer_Click);
            // 
            // lab_customer
            // 
            this.lab_customer.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lab_customer.Appearance.Font = new System.Drawing.Font("Arial", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lab_customer.Appearance.ForeColor = System.Drawing.Color.Red;
            this.lab_customer.Appearance.Options.UseFont = true;
            this.lab_customer.Appearance.Options.UseForeColor = true;
            this.lab_customer.Location = new System.Drawing.Point(274, 11);
            this.lab_customer.Margin = new System.Windows.Forms.Padding(5);
            this.lab_customer.Name = "lab_customer";
            this.lab_customer.Size = new System.Drawing.Size(107, 22);
            this.lab_customer.TabIndex = 29;
            this.lab_customer.Text = "ادخل الاسم للبحث";
            // 
            // txt_customer_serch
            // 
            this.txt_customer_serch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txt_customer_serch.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_customer_serch.Location = new System.Drawing.Point(23, 11);
            this.txt_customer_serch.Name = "txt_customer_serch";
            this.txt_customer_serch.Size = new System.Drawing.Size(240, 25);
            this.txt_customer_serch.TabIndex = 28;
            this.txt_customer_serch.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txt_customer_serch.TextChanged += new System.EventHandler(this.txt_customer_serch_TextChanged);
            // 
            // btn_OK_customer_btn
            // 
            this.btn_OK_customer_btn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(120)))), ((int)(((byte)(210)))));
            this.btn_OK_customer_btn.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold);
            this.btn_OK_customer_btn.ForeColor = System.Drawing.Color.White;
            this.btn_OK_customer_btn.Location = new System.Drawing.Point(226, 376);
            this.btn_OK_customer_btn.Name = "btn_OK_customer_btn";
            this.btn_OK_customer_btn.Size = new System.Drawing.Size(106, 31);
            this.btn_OK_customer_btn.TabIndex = 27;
            this.btn_OK_customer_btn.Text = "موافق";
            this.btn_OK_customer_btn.UseVisualStyleBackColor = false;
            this.btn_OK_customer_btn.Click += new System.EventHandler(this.btn_OK_customer_Click);
            // 
            // dgv_Customer_dgv
            // 
            this.dgv_Customer_dgv.AllowUserToAddRows = false;
            this.dgv_Customer_dgv.AllowUserToDeleteRows = false;
            this.dgv_Customer_dgv.AllowUserToResizeColumns = false;
            this.dgv_Customer_dgv.AllowUserToResizeRows = false;
            this.dgv_Customer_dgv.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(200)))), ((int)(((byte)(230)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(200)))), ((int)(((byte)(90)))));
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgv_Customer_dgv.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgv_Customer_dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_Customer_dgv.EnableHeadersVisualStyles = false;
            this.dgv_Customer_dgv.Location = new System.Drawing.Point(4, 40);
            this.dgv_Customer_dgv.Name = "dgv_Customer_dgv";
            this.dgv_Customer_dgv.ReadOnly = true;
            this.dgv_Customer_dgv.RowHeadersWidth = 51;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(200)))), ((int)(((byte)(90)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Black;
            this.dgv_Customer_dgv.RowsDefaultCellStyle = dataGridViewCellStyle2;
            this.dgv_Customer_dgv.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv_Customer_dgv.Size = new System.Drawing.Size(406, 333);
            this.dgv_Customer_dgv.TabIndex = 26;
            this.dgv_Customer_dgv.CellMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgv_Customer_CellMouseDoubleClick);
            // 
            // Frm_Client_Show
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(413, 409);
            this.Controls.Add(this.btn_close_customer_btn);
            this.Controls.Add(this.lab_customer);
            this.Controls.Add(this.txt_customer_serch);
            this.Controls.Add(this.btn_OK_customer_btn);
            this.Controls.Add(this.dgv_Customer_dgv);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Frm_Client_Show";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Frm_Client_Show";
            this.Load += new System.EventHandler(this.Frm_Customer_Show_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Customer_dgv)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_close_customer_btn;
        public DevExpress.XtraEditors.LabelControl lab_customer;
        public System.Windows.Forms.TextBox txt_customer_serch;
        private System.Windows.Forms.Button btn_OK_customer_btn;
        public System.Windows.Forms.DataGridView dgv_Customer_dgv;
    }
}