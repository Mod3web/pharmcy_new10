using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Windows.Forms;
using System.Drawing;

namespace Manag_ph.classs_table
{
    class MyTool_1
    {

        public static void CreateFolder(string pathName)
        {//دالة تنشاء مجلد واحد
            if (!Directory.Exists(pathName))
            {
                Directory.CreateDirectory(pathName);
            }


        }
        public static void CreateFolders(string[] pathNames)
        {//دالة تستقب مسارات المجلدات  وتنشءها

            foreach (string str in pathNames)
            {

                CreateFolder(str);


            }

        

        }
        public static void CreateEmptyFile(string pathNAme)
        {//دالة تستقبل مسار المف وتنشئة فاضي
           if(!File.Exists(pathNAme))
           {

               File.Create(pathNAme).Close();
           
           
           }
        }
      
        public static void CreateEmpteFiles(string[] pathNames)
        { //دالة تستقبل مصفوفة مسارات وتنش بها عدة ملفات
            foreach(string str in pathNames)
            {
                CreateEmptyFile(str);
            
            
            }
        }
        public static void CreateDataFile(string pathNAme, string[] Item)
        {//دالة تستقبل مغير مسار الملف ومصفوفة بها السطور ونقم بئنشا ملفات 
            CreateEmptyFile(pathNAme);
            StreamWriter aw = new StreamWriter(pathNAme,true);
            foreach(string lins in Item){
            aw.WriteLine(lins);

            }
            aw.Close();



        }
        public static void CreateDataFiles(string[] PathNames, string[][] Lines )
        {//داله تستقبل عدة مسارات وعدة سطور ونقوم بئدخال البانات الا الملفات
            for (int i = 0; i < PathNames.Length;i++ )
            {


                CreateDataFile(PathNames[i],Lines[i]);
            
            
            }

        }
        public static int GetNmberOnly(string numberAndLetter)
        {//دالة تستقبل  نص به ارقام وحروف وتفلتر الارقام من الحروف وترجع الارقام
            string num = "";
            foreach(char ch in numberAndLetter.ToCharArray())
            {

                if (ch == '0' || ch == '1' || ch == '2' || ch == '3' || ch == '4' || ch == '5' || ch == '6' || ch == '7' || ch == '8' || ch == '9')
                {
                    num += ch;
                }
            
            }
            return Convert.ToInt32(num);
        }
        public static string InputBox(string Totel,string Text , bool isPassword = false)  
        {
            string str="";
            Form frm = new Form();
            Label lbl = new Label();
            TextBox txt = new TextBox();
            Button btOK = new Button();
            Button btClose = new Button();
         

            frm.Text = Totel;
            frm.FormBorderStyle = FormBorderStyle.FixedToolWindow;
            frm.StartPosition = FormStartPosition.CenterScreen;
            frm.MaximizeBox = false;
            frm.MinimizeBox = false;
            frm.ControlBox = false;
            
            frm.Font = new Font("Arial",14,FontStyle.Bold);
            frm.Size = new System.Drawing.Size(400,190);


            lbl.AutoSize = true;
            lbl.Location = new Point(10, 10);


            txt.Location = new Point(10, 50);
            if (isPassword) txt.PasswordChar = '•';
            txt.BorderStyle = BorderStyle.FixedSingle;
            txt.Width = frm.Width - 30;
            txt.KeyDown += delegate(object ob , KeyEventArgs MyE) {
            
                if(MyE.KeyData==Keys.Enter){
                    str = txt.Text;
                    frm.Close();
                }
            };


            btOK.Location = new Point(10,frm.Height-80);
            btOK.Width = 100;
            btOK.BackColor = Color.Navy;
            btOK.AutoSize = true;
            btOK.Cursor = Cursors.Hand;
            btOK.ForeColor = Color.White;
            btOK.FlatStyle = FlatStyle.Popup;
            btOK.Text = "OK";
            btOK.Click += delegate {

                str = txt.Text;
                frm.Close();
            
            };



            btClose.Location = new Point(160, frm.Height - 80);
            btClose.Width = 100;
            btClose.BackColor = Color.Navy;
            btClose.AutoSize = true;
            btClose.Cursor = Cursors.Hand;
            btClose.ForeColor = Color.White;
            btClose.FlatStyle = FlatStyle.Popup;
            btClose.Text = "Cancel";
            btClose.Click += delegate {
                frm.Close();

            };
       


            frm.Controls.Add(btClose);
            frm.Controls.Add(btOK);
            frm.Controls.Add(txt);
            frm.Controls.Add(lbl);
            lbl.Text = Text;
            frm.ShowDialog();


            return str;


        }



    }
}
