using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Manag_ph.Item.forms
{
    public partial class Frm_stap_database_frm : Form
    {
        private Panel panel1_Frm_stap_database_frm;
        public Button btn_stup_database_btn;
        public TextBox textBox1_Frm_stap_database_frm;

        public Frm_stap_database_frm()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            this.panel1_Frm_stap_database_frm = new System.Windows.Forms.Panel();
            this.btn_stup_database_btn = new System.Windows.Forms.Button();
            this.textBox1_Frm_stap_database_frm = new System.Windows.Forms.TextBox();
            this.panel1_Frm_stap_database_frm.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1_Frm_stap_database_frm
            // 
            this.panel1_Frm_stap_database_frm.Controls.Add(this.btn_stup_database_btn);
            this.panel1_Frm_stap_database_frm.Controls.Add(this.textBox1_Frm_stap_database_frm);
            this.panel1_Frm_stap_database_frm.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1_Frm_stap_database_frm.Location = new System.Drawing.Point(0, 0);
            this.panel1_Frm_stap_database_frm.Name = "panel1_Frm_stap_database_frm";
            this.panel1_Frm_stap_database_frm.Size = new System.Drawing.Size(379, 231);
            this.panel1_Frm_stap_database_frm.TabIndex = 0;
            // 
            // btn_stup_database_btn
            // 
            this.btn_stup_database_btn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(120)))), ((int)(((byte)(210)))));
            this.btn_stup_database_btn.ForeColor = System.Drawing.Color.White;
            this.btn_stup_database_btn.Location = new System.Drawing.Point(134, 128);
            this.btn_stup_database_btn.Name = "btn_stup_database_btn";
            this.btn_stup_database_btn.Size = new System.Drawing.Size(102, 38);
            this.btn_stup_database_btn.TabIndex = 5;
            this.btn_stup_database_btn.Text = "button1";
            this.btn_stup_database_btn.UseVisualStyleBackColor = false;
            this.btn_stup_database_btn.Click += new System.EventHandler(this.Btn_stup_database_btn_Click);
            // 
            // textBox1_Frm_stap_database_frm
            // 
            this.textBox1_Frm_stap_database_frm.Location = new System.Drawing.Point(67, 60);
            this.textBox1_Frm_stap_database_frm.Multiline = true;
            this.textBox1_Frm_stap_database_frm.Name = "textBox1_Frm_stap_database_frm";
            this.textBox1_Frm_stap_database_frm.Size = new System.Drawing.Size(238, 27);
            this.textBox1_Frm_stap_database_frm.TabIndex = 4;
            // 
            // Frm_stap_database_frm
            // 
            this.ClientSize = new System.Drawing.Size(379, 231);
            this.Controls.Add(this.panel1_Frm_stap_database_frm);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(395, 270);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(395, 270);
            this.Name = "Frm_stap_database_frm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.panel1_Frm_stap_database_frm.ResumeLayout(false);
            this.panel1_Frm_stap_database_frm.PerformLayout();
            this.ResumeLayout(false);

        }

        private void Btn_stup_database_btn_Click(object sender, EventArgs e)
        {
            if (textBox1_Frm_stap_database_frm.Text.Trim() == string.Empty)
            {

                MessageBox.Show("this text is null ");
            }

            else
            {

                string namelab = textBox1_Frm_stap_database_frm.Text;
                string x = "Data source=" + namelab + ";Database=Manag_Pharmacy;integrated security=true";
                Properties.Settings.Default.dd = x;
                Properties.Settings.Default.Save();
                Application.Restart();

            }
        }
    }
}
