using DevExpress.XtraBars.Navigation;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Manag_ph.Recovry
{
    class Recovre_Data_of_Power
    {

        DataTable FillColumn(string NameFileXML, DataGridView dgv)
        {
            DataTable dt = new DataTable(NameFileXML);

            foreach (DataGridViewColumn column in dgv.Columns)
            {
                dt.Columns.Add(column.HeaderText);
            }
            return dt;
        }

        public void FillRow(string NameFileXML, DataGridView dgv)
        {
            DataTable dt = FillColumn(NameFileXML, dgv);
            foreach (DataGridViewRow Row in dgv.Rows)
            {
                dt.Rows.Add();
                foreach (DataGridViewCell cell in Row.Cells)
                {
                    dt.Rows[dt.Rows.Count - 1][cell.ColumnIndex] = cell.Value;
                }
            }

            dt.WriteXmlSchema(NameFileXML + ".xml");
            dt.WriteXml(NameFileXML + ".xml");
        }

        public void check_Data_Recovry(string NameFileXML, DataGridView dgv)
        {
            if (File.Exists(NameFileXML + ".xml"))
            {
                DialogResult dr = MessageBox.Show("هل تريد استعادة البيانات", "s", MessageBoxButtons.YesNo);
                if (dr == DialogResult.Yes)
                {
                    DataTable dt = new DataTable(NameFileXML);
                    dt.ReadXmlSchema(NameFileXML + ".xml");
                    dt.ReadXml(NameFileXML + ".xml");
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        object[] obj = dt.Rows[i].ItemArray;
                        dgv.Rows.Add();
                        for (int j = 0; j < obj.Count(); j++)
                        {

                            if (j == 0)
                            {
                                if (obj.Count()  == 16)
                                {

                                    dgv.Rows[dgv.Rows.Count - 1].Cells[j].Value = 0;
                                }


                            }

                            if (j == 1)
                            {
                                dgv.Rows[dgv.Rows.Count - 1].Cells[j].Value = obj[j].ToString();
                                dgv.Rows[dgv.Rows.Count - 1].Cells[j].Selected = true;

                                new prodects.Footer_prodect()._DataGridView5_CellEndEdit();
                            }
                            dgv.Rows[dgv.Rows.Count - 1].Cells[j].Value = obj[j].ToString();




                            //if (j == 3)
                            //{
                            //    DataGridViewComboBoxCell DGV_Prodect = dgv.CurrentRow.Cells[3] as DataGridViewComboBoxCell;
                            //    DGV_Prodect.Value = DGV_Prodect.Items[0];

                            //    dgv.Rows[dgv.Rows.Count - 1].Cells[j].Value = false;
                            //}
                        }
                    }
                    File.Delete(NameFileXML + ".xml");
                }
            }
        }

        public void DeleteFile_bergin_Save(string NameFileXML)
        {
            File.Delete("NameFileXML" + ".xml");
        }



        public DataTable Fill_info_TextBox(string NameFileXML, NavigationPage frm)
        {
            DataTable dt = new DataTable(NameFileXML);

            for (int i = 0; i < frm.Controls.Count; i++)
            {
                if (frm.Controls[i] is TabPane)
                {
                    for (int j = 0; j < frm.Controls[i].Controls.Count; j++)
                    {
                        if (frm.Controls[i].Controls[j] is TabNavigationPage)
                        {
                            for (int x = 0; x < frm.Controls[i].Controls[j].Controls.Count; x++)
                            {
                                if (frm.Controls[i].Controls[j].Controls[x] is GroupBox)
                                {
                                    for (int z = 0; z < frm.Controls[i].Controls[j].Controls[x].Controls.Count; z++)
                                    {
                                        if (frm.Controls[i].Controls[j].Controls[x].Controls[z] is TextBox)
                                        {

                                            dt.Columns.Add(frm.Controls[i].Controls[j].Controls[x].Controls[z].Name);
                                        }
                                    }


                                }
                            }
                        }
                    }

                    dt.Columns.Add(frm.Controls[i].Name);
                }
            }

            return dt;
        }

        public void Fill_Data_Textbox(DataTable DataTablColumn, NavigationPage frm)
        {

            DataTable dt = DataTablColumn;
            if (dt != null)
            {


                if (dt.Rows.Count == 0)
                {
                    dt.Rows.Add();
                }
                for (int i = 0; i < dt.Columns.Count; i++)
                {

                    for (int j = 0; j < frm.Controls.Count; j++)
                    {
                        if (frm.Controls[j] is TabPane)
                        {
                            //MessageBox.Show("TabPane");


                            for (int x = 0; x < frm.Controls[j].Controls.Count; x++)
                            {
                                if (frm.Controls[j].Controls[x] is TabNavigationPage)
                                {
                                    //MessageBox.Show("TabNavigationPage");

                                    for (int y = 0; y < frm.Controls[j].Controls[x].Controls.Count; y++)
                                    {

                                        if (frm.Controls[j].Controls[x].Controls[y] is GroupBox)
                                        {
                                            //MessageBox.Show("Group");

                                            for (int z = 0; z < frm.Controls[j].Controls[x].Controls[y].Controls.Count; z++)
                                            {
                                                if (frm.Controls[j].Controls[x].Controls[y].Controls[z] is TextBox)
                                                {
                                                    if ((frm.Controls[j].Controls[x].Controls[y].Controls[z].Name == dt.Columns[i].ColumnName) && ((TextBox)frm.Controls[j].Controls[x].Controls[y].Controls[z]).Text != string.Empty)
                                                    {
                                                        //MessageBox.Show("OK");

                                                        dt.Rows[0][dt.Columns.IndexOf(frm.Controls[j].Controls[x].Controls[y].Controls[z].Name)] = ((TextBox)frm.Controls[j].Controls[x].Controls[y].Controls[z]).Text;
                                                    }
                                                }

                                            }

                                        }

                                        if (frm.Controls[j].Controls[x].Controls[y] is TextBox)
                                        {
                                            if ((frm.Controls[j].Controls[x].Controls[y].Name == dt.Columns[i].ColumnName) && ((TextBox)frm.Controls[j].Controls[x].Controls[y]).Text != string.Empty)
                                            {

                                                dt.Rows[0][dt.Columns.IndexOf(frm.Controls[j].Controls[x].Controls[y].Name)] = ((TextBox)frm.Controls[j]).Text;
                                            }
                                        }


                                    }

                                }
                                if (frm.Controls[j].Controls[x] is TextBox)
                                {
                                    if ((frm.Controls[j].Controls[x].Name == dt.Columns[i].ColumnName) && ((TextBox)frm.Controls[j].Controls[x]).Text != string.Empty)
                                    {

                                        dt.Rows[0][dt.Columns.IndexOf(frm.Controls[j].Controls[x].Name)] = ((TextBox)frm.Controls[j].Controls[x]).Text;
                                    }
                                }

                            }



                        }
                        if (frm.Controls[j] is TextBox)
                        {

                            if ((frm.Controls[j].Name == dt.Columns[i].ColumnName) && ((TextBox)frm.Controls[j]).Text != string.Empty)
                            {

                                dt.Rows[0][dt.Columns.IndexOf(frm.Controls[j].Name)] = ((TextBox)frm.Controls[j]).Text;
                            }
                        }
                    }

                }


                dt.WriteXmlSchema(dt.TableName + ".xml");
                dt.WriteXml(dt.TableName + ".xml");

            }
        }

        public void chek_recovry_Data_TextBox(string NameFileXML, NavigationPage frm)
        {
            if (File.Exists(NameFileXML + ".xml"))
            {
                DialogResult dr = MessageBox.Show("هل تريد استعادة البيانات", "s", MessageBoxButtons.YesNo);
                if (dr == DialogResult.Yes)
                {
                    DataTable dt = new DataTable(NameFileXML);
                    dt.ReadXmlSchema(NameFileXML + ".xml");
                    dt.ReadXml(NameFileXML + ".xml");


                    for (int i = 0; i < dt.Columns.Count; i++)
                    {

                        for (int j = 0; j < frm.Controls.Count; j++)
                        {
                            if (frm.Controls[j] is TabPane)
                            {

                                for (int x = 0; x < frm.Controls[j].Controls.Count; x++)
                                {
                                    if (frm.Controls[j].Controls[x] is TabNavigationPage)
                                    {

                                        for (int y = 0; y < frm.Controls[j].Controls[x].Controls.Count; y++)
                                        {

                                            if (frm.Controls[j].Controls[x].Controls[y] is GroupBox)
                                            {

                                                for (int z = 0; z < frm.Controls[j].Controls[x].Controls[y].Controls.Count; z++)
                                                {

                                                    if (frm.Controls[j].Controls[x].Controls[y].Controls[z] is TextBox)
                                                    {
                                                        if ((frm.Controls[j].Controls[x].Controls[y].Controls[z].Name == dt.Columns[i].ColumnName))
                                                        {
                                                            ((TextBox)frm.Controls[j].Controls[x].Controls[y].Controls[z]).Text = dt.Rows[0][dt.Columns.IndexOf(frm.Controls[j].Controls[x].Controls[y].Controls[z].Name)].ToString();
                                                        }
                                                    }

                                                }

                                            }


                                            if (frm.Controls[j].Controls[x].Controls[y] is TextBox)
                                            {
                                                if ((frm.Controls[j].Controls[x].Controls[y].Name == dt.Columns[i].ColumnName))
                                                {
                                                    ((TextBox)frm.Controls[j].Controls[x].Controls[y]).Text = dt.Rows[0][dt.Columns.IndexOf(frm.Controls[j].Controls[x].Controls[y].Name)].ToString();
                                                }
                                            }


                                        }

                                    }
                                    if (frm.Controls[j].Controls[x] is TextBox)
                                    {
                                        if ((frm.Controls[j].Controls[x].Name == dt.Columns[i].ColumnName))
                                        {
                                            ((TextBox)frm.Controls[j].Controls[x]).Text = dt.Rows[0][dt.Columns.IndexOf(frm.Controls[j].Controls[x].Name)].ToString();
                                        }
                                    }

                                }


                            }
                            if (frm.Controls[j] is TextBox)
                            {
                                if ((frm.Controls[j].Name == dt.Columns[i].ColumnName))
                                {
                                    ((TextBox)frm.Controls[j]).Text = dt.Rows[0][dt.Columns.IndexOf(frm.Controls[j].Name)].ToString();
                                }
                            }
                        }

                    }




                    for (int i = 0; i < dt.Columns.Count; i++)
                    {

                        for (int j = 0; j < frm.Controls.Count; j++)
                        {
                            if (frm.Controls[j] is TextBox)
                            {
                                if ((frm.Controls[j].Name == dt.Columns[i].ColumnName))
                                {
                                    ((TextBox)frm.Controls[j]).Text = dt.Rows[0][dt.Columns.IndexOf(frm.Controls[j].Name)].ToString();
                                }
                            }
                        }

                    }

                    File.Delete(NameFileXML + ".xml");
                }
            }
        }








    }

}
