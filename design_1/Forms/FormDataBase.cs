using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ExcelDataReader;
using Excel = Microsoft.Office.Interop.Excel;
using SD = System.Data;

namespace design_1.Forms
{
    public partial class FormDataBase : Form
    {
        private string path = "D:\\лаби\\c#\\design_1\\design_1\\Kursova_1.xlsx";
        private string path1 = "D:\\лаби\\c#\\design_1\\design_1\\Kursova_1.1.xlsx";
        private string path2 = "D:\\лаби\\c#\\design_1\\design_1\\Kursova_1.2.xlsx";
        private DataTableCollection tablecoll = null;
        DataSet data = null;
        private bool newrowadd = false;
        public FormDataBase()
        {
            InitializeComponent();
            OpenExcel();
        }
        private void OpenExcel()
        {
            using(FileStream stream = File.Open(path, FileMode.Open, FileAccess.Read))
            {
                IExcelDataReader reader = ExcelReaderFactory.CreateReader(stream);
                DataSet db = reader.AsDataSet(new ExcelDataSetConfiguration()
                {
                    ConfigureDataTable = (x) => new ExcelDataTableConfiguration()
                    {
                        UseHeaderRow = true
                    }
                });

                tablecoll = db.Tables;
                data = db;
                comboBox1.Items.Clear();
                foreach (DataTable item in tablecoll)
                {
                    comboBox1.Items.Add(item.TableName);
                }
                comboBox1.SelectedIndex = 0;
            }
            
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void vScrollBar1_Scroll(object sender, ScrollEventArgs e)
        {
            try
            {
                dataGridView1.FirstDisplayedScrollingRowIndex = dataGridView1.Rows[e.NewValue].Index;
            }
            catch (Exception)
            {

                throw;
            }
            
        }

        private void iconButton2_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            (dataGridView1.DataSource as DataTable).DefaultView.RowFilter = $"Назва LIKE '%{textBox1.Text}%'";
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataTable table = tablecoll[Convert.ToString(comboBox1.SelectedItem)];
            dataGridView1.DataSource = table;
        }

        private void iconButton1_Click(object sender, EventArgs e)
        {
            
        }

        private void iconButton4_Click(object sender, EventArgs e)
        {

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (comboBox2.SelectedIndex)
            {
                case 0: 
                    (dataGridView1.DataSource as DataTable).DefaultView.RowFilter = $"Ціна <=100";
                    break;
                case 1:
                    (dataGridView1.DataSource as DataTable).DefaultView.RowFilter = $"Ціна >=100 AND Ціна <=500";
                    break;
                case 2:
                    (dataGridView1.DataSource as DataTable).DefaultView.RowFilter = $"Ціна >=500 AND Ціна <=1000";
                    break;
                case 3:
                    (dataGridView1.DataSource as DataTable).DefaultView.RowFilter = $"Ціна >=1000 AND Ціна <=5000";
                    break;
                case 4:
                    (dataGridView1.DataSource as DataTable).DefaultView.RowFilter = $"Ціна >=5000";
                    break;
                case 5:
                    (dataGridView1.DataSource as DataTable).DefaultView.RowFilter = "";
                    break;
            }
        }

        private void dataGridView1_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            try
            {

                vScrollBar1.Maximum = dataGridView1.RowCount;
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void dataGridView1_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            try
            {

                vScrollBar1.Maximum = dataGridView1.RowCount;
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void textBox1_Leave(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                textBox1.Text = "Введіть назву";
                textBox1.ForeColor = Color.LightSteelBlue;
            }
        }

        private void textBox1_Enter(object sender, EventArgs e)
        {
            if (textBox1.Text == "Введіть назву")
            {
                textBox1.Text = "";
                textBox1.ForeColor = Color.Black;
            }
           
        }

        private void iconButton5_Click(object sender, EventArgs e)
        {
            try
            {
                int row = dataGridView1.SelectedCells[0].RowIndex;
                dataGridView1.Rows.RemoveAt(row);
                //data.Tables[Convert.ToString(comboBox1.SelectedItem)].Rows[row].Delete();
                ReadExcel();
            }
            catch (Exception)
            {

                MessageBox.Show("fff");
            }
        }

        private void iconButton1_Click_1(object sender, EventArgs e)
        {
            try
            {
                if(newrowadd == true)
                {
                    ReadExcel();
                    newrowadd = false;
                }
               // int row = dataGridView1.SelectedCells[0].RowIndex;
                /*int lastrow = dataGridView1.Rows.Count - 2;

                DataRow r1 = data.Tables[Convert.ToString(comboBox1.SelectedItem)].NewRow();

                r1[0] = dataGridView1.Rows[lastrow].Cells[0].Value;
                r1[1] = dataGridView1.Rows[lastrow].Cells[1].Value;
                r1[2] = dataGridView1.Rows[lastrow].Cells[2].Value;
                r1[3] = dataGridView1.Rows[lastrow].Cells[3].Value;
                r1[4] = dataGridView1.Rows[lastrow].Cells[4].Value;
                r1[5] = dataGridView1.Rows[lastrow].Cells[5].Value;
                r1[6] = dataGridView1.Rows[lastrow].Cells[6].Value;

                data.Tables[Convert.ToString(comboBox1.SelectedItem)].Rows.Add(r1);
                data.Tables[Convert.ToString(comboBox1.SelectedItem)].Rows.RemoveAt(data.Tables[Convert.ToString(comboBox1.SelectedItem)].Rows.Count - 1);
                dataGridView1.Rows.RemoveAt(dataGridView1.Rows.Count - 1);*/

                
            }
            catch (Exception)
            {
                throw;
            }
        }

        private void dataGridView1_UserAddedRow(object sender, DataGridViewRowEventArgs e)
        {
            try
            {
                if (newrowadd == false)
                {
                    newrowadd = true;
                    int lastrow = dataGridView1.Rows.Count - 2;
                    DataGridViewRow r = dataGridView1.Rows[lastrow];

                }
            }
            catch (Exception)
            {

                throw;
            }
            
        }

        private void iconButton6_Click(object sender, EventArgs e)
        {
            try
            {
                /*int lastrow = dataGridView1.SelectedCells[0].RowIndex;

                data.Tables[Convert.ToString(comboBox1.SelectedItem)].Rows[lastrow][0] = dataGridView1.Rows[lastrow].Cells[0].Value;
                data.Tables[Convert.ToString(comboBox1.SelectedItem)].Rows[lastrow][1] = dataGridView1.Rows[lastrow].Cells[1].Value;
                data.Tables[Convert.ToString(comboBox1.SelectedItem)].Rows[lastrow][2] = dataGridView1.Rows[lastrow].Cells[2].Value;
                data.Tables[Convert.ToString(comboBox1.SelectedItem)].Rows[lastrow][3] = dataGridView1.Rows[lastrow].Cells[3].Value;
                data.Tables[Convert.ToString(comboBox1.SelectedItem)].Rows[lastrow][4] = dataGridView1.Rows[lastrow].Cells[4].Value;
                data.Tables[Convert.ToString(comboBox1.SelectedItem)].Rows[lastrow][5] = dataGridView1.Rows[lastrow].Cells[5].Value;
                data.Tables[Convert.ToString(comboBox1.SelectedItem)].Rows[lastrow][6] = dataGridView1.Rows[lastrow].Cells[6].Value;*/
                if (newrowadd == true)
                {
                    ReadExcel();
                    newrowadd = false;
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
        private void ReadExcel()
        {
            int n = comboBox1.SelectedIndex + 1;
            Excel.Application ea = new Excel.Application();

            Excel.Workbook ee = ea.Workbooks.Open(path1, false);
            Excel.Worksheet ww = ee.Worksheets[n];
            for (int i = 0; i < dataGridView1.RowCount - 2; i++)
            {
                for (int j = 0; j < dataGridView1.Columns.Count - 1; j++)
                {
                    ww.Cells[i + 2, j + 1] = dataGridView1[j, i].Value.ToString();
                }
            }
            ea.Visible = true;
            ee.SaveAs(path1);
            ee.Close();

        }
        private void dataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
               /* if (newrowadd == false)
                {
                    newrowadd = true;
                    int ri = dataGridView1.SelectedCells[0].RowIndex;
                    DataGridViewRow edit = dataGridView1.Rows[ri];
                }*/
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void iconButton7_Click(object sender, EventArgs e)
        {
           ReadExcel();
        }
    }
}
