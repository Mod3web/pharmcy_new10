namespace Manag_ph.Item.forms
{
    partial class frm_Supper_prodect
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
            this.dgv_supper_dgv = new System.Windows.Forms.DataGridView();
            this.button1_btn = new System.Windows.Forms.Button();
            this.txt_supper_serch = new System.Windows.Forms.TextBox();
            this.labelControl74 = new DevExpress.XtraEditors.LabelControl();
            this.button3_btn = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_supper_dgv)).BeginInit();
            this.SuspendLayout();
            // 
            // dgv_supper_dgv
            // 
            this.dgv_supper_dgv.AllowUserToAddRows = false;
            this.dgv_supper_dgv.AllowUserToDeleteRows = false;
            this.dgv_supper_dgv.AllowUserToResizeColumns = false;
            this.dgv_supper_dgv.AllowUserToResizeRows = false;
            this.dgv_supper_dgv.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(200)))), ((int)(((byte)(230)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(200)))), ((int)(((byte)(90)))));
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgv_supper_dgv.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgv_supper_dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_supper_dgv.EnableHeadersVisualStyles = false;
            this.dgv_supper_dgv.Location = new System.Drawing.Point(4, 76);
            this.dgv_supper_dgv.Name = "dgv_supper_dgv";
            this.dgv_supper_dgv.ReadOnly = true;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(200)))), ((int)(((byte)(90)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Black;
            this.dgv_supper_dgv.RowsDefaultCellStyle = dataGridViewCellStyle2;
            this.dgv_supper_dgv.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv_supper_dgv.Size = new System.Drawing.Size(406, 333);
            this.dgv_supper_dgv.TabIndex = 0;
            this.dgv_supper_dgv.CellMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.Dgv_supper_CellMouseDoubleClick);
            this.dgv_supper_dgv.RowHeaderMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.Dgv_supper_RowHeaderMouseDoubleClick);
            // 
            // button1_btn
            // 
            this.button1_btn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(120)))), ((int)(((byte)(210)))));
            this.button1_btn.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold);
            this.button1_btn.ForeColor = System.Drawing.Color.White;
            this.button1_btn.Location = new System.Drawing.Point(83, 409);
            this.button1_btn.Name = "button1_btn";
            this.button1_btn.Size = new System.Drawing.Size(106, 31);
            this.button1_btn.TabIndex = 1;
            this.button1_btn.Text = "موافق";
            this.button1_btn.UseVisualStyleBackColor = false;
            this.button1_btn.Click += new System.EventHandler(this.Button1_Click);
            // 
            // txt_supper_serch
            // 
            this.txt_supper_serch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txt_supper_serch.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_supper_serch.Location = new System.Drawing.Point(143, 26);
            this.txt_supper_serch.Name = "txt_supper_serch";
            this.txt_supper_serch.Size = new System.Drawing.Size(240, 25);
            this.txt_supper_serch.TabIndex = 23;
            this.txt_supper_serch.TextChanged += new System.EventHandler(this.Txt_supper_serch_TextChanged);
            // 
            // labelControl74
            // 
            this.labelControl74.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.labelControl74.Appearance.Font = new System.Drawing.Font("AGA Arabesque", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl74.Appearance.ForeColor = System.Drawing.Color.Red;
            this.labelControl74.Appearance.Options.UseFont = true;
            this.labelControl74.Appearance.Options.UseForeColor = true;
            this.labelControl74.Location = new System.Drawing.Point(28, 28);
            this.labelControl74.Name = "labelControl74";
            this.labelControl74.Size = new System.Drawing.Size(107, 22);
            this.labelControl74.TabIndex = 24;
            this.labelControl74.Text = "ادخل الاسم للبحث";
            // 
            // button3_btn
            // 
            this.button3_btn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(120)))), ((int)(((byte)(210)))));
            this.button3_btn.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold);
            this.button3_btn.ForeColor = System.Drawing.Color.White;
            this.button3_btn.Location = new System.Drawing.Point(216, 410);
            this.button3_btn.Name = "button3_btn";
            this.button3_btn.Size = new System.Drawing.Size(106, 31);
            this.button3_btn.TabIndex = 25;
            this.button3_btn.Text = "اغلاق";
            this.button3_btn.UseVisualStyleBackColor = false;
            this.button3_btn.Click += new System.EventHandler(this.Button3_Click);
            // 
            // frm_Supper_prodect
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(413, 450);
            this.Controls.Add(this.button3_btn);
            this.Controls.Add(this.labelControl74);
            this.Controls.Add(this.txt_supper_serch);
            this.Controls.Add(this.button1_btn);
            this.Controls.Add(this.dgv_supper_dgv);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frm_Supper_prodect";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RightToLeftLayout = true;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "الموردين";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Frm_Supper_prodect_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Frm_Supper_prodect_FormClosed);
            this.Load += new System.EventHandler(this.Frm_Supper_prodect_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_supper_dgv)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgv_supper_dgv;
        private System.Windows.Forms.Button button1_btn;
        public System.Windows.Forms.TextBox txt_supper_serch;
        public DevExpress.XtraEditors.LabelControl labelControl74;
        private System.Windows.Forms.Button button3_btn;
    }
}