using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Manag_ph.Recovry_Data
{
    class Recovre_Data_of_Power
    {

        DataTable FillColumn(string NameFileXML,DataGridView dgv)
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

        public void check_Data_Recovry(string NameFileXML,DataGridView dgv)
        {
            if (File.Exists(NameFileXML+".xml"))
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
                            if (dgv.Rows[dgv.Rows.Count - 1].Cells[j].ValueType == typeof(DataGridViewCheckBoxColumn))
                            {
                                dgv.Rows[dgv.Rows.Count - 1].Cells[j].Value = false;
                            } else if (dgv.Rows[dgv.Rows.Count - 1].Cells[j].ValueType == typeof(object))
                            {
                                dgv.Rows[dgv.Rows.Count - 1].Cells[j].Value = obj[j].ToString();
                                new prodects.Footer_prodect()._DataGridView5_CellEndEdit();

                            }
                            else if (dgv.Rows[dgv.Rows.Count - 1].Cells[j].GetType() == typeof(DataGridViewComboBoxColumn))
                            {
                                MessageBox.Show("Combobox");
                            }
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

    }
}
