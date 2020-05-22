using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace WindowsFormNet
{
    public partial class BookRecordForm : Form
    {
        public const string Description = "description";
        public const string Binding = "binding";
        public const string InStock = "in stock";
        public const string DescriptionButtonText = "Action";
        public BookRecordForm()
        {
            InitializeComponent();
        }


        private void load_file_btn_Click(object sender, EventArgs e)
        {
            try
            {
                var ppt = new OpenFileDialog { Filter = @"Comma Delimited Separated (.csv) | *.csv" };
                if (ppt.ShowDialog() != DialogResult.OK) return;
                var dataTable = ReadCsvFile(ppt.FileName);
                dataGridView.DataSource = dataTable;
                dataGridView.DataError += new DataGridViewDataErrorEventHandler(dgvCombo_DataError);
                dataGridView.CellClick += new DataGridViewCellEventHandler(dataGridView1_CellClick);
                dataGridView.ShowCellToolTips = true;
                dataGridView.AllowUserToOrderColumns = false;
                dataGridView.AllowUserToAddRows = false;
                dataGridView.CellMouseEnter += DataGridView1_CellMouseEnter;

                var col = new DataGridViewButtonColumn
                {
                    UseColumnTextForButtonValue = true,
                    Text = "View Description",
                    Name = DescriptionButtonText,
                    
                };
                dataGridView.Columns.Add(col);
                dataGridView.Columns[Description].Visible = false; 
                ReplaceBindingColumnWithCombobox();

                CheckIfInStock();

                DisableSorting();
            }
            catch (Exception exception)
            {
                MessageBox.Show("Error:" + exception.ToString());
                throw;
            }
        }

        
        private void MainForm_Load(object sender, EventArgs e)
        {
            FormDesigner();
        }

        private void delete_btn_nostock_books_Click(object sender, EventArgs e)
        {
            var dialogResult = MessageBox.Show(@"Are you sure you want to perform this operation?", @"Prompt",
                MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (dialogResult != DialogResult.OK) return;
            if (!dataGridView.Columns.Contains(InStock))
            {
                MessageBox.Show(@"No record to delete", $@"Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;

            }

            var indexColumn = dataGridView.Columns.IndexOf(dataGridView.Columns[InStock]);

            var totalRecordsDeleted = 0;
            for (var i = 0; i < dataGridView.RowCount; i++)
            {
                var data = dataGridView.Rows[i].Cells[indexColumn];
                if (data?.Value == null) continue;
                var dvgValue = data.Value.ToString();
                if (!dvgValue.Equals("no")) continue;
                dataGridView.Rows.Remove(dataGridView.Rows[i]);
                totalRecordsDeleted++;

            }

            MessageBox.Show($@"{totalRecordsDeleted} books are not in stock and has been deleted successfully",
                $@"Delete Notification", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }



        #region EventHandlers

        void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex < 0 || e.RowIndex < 0) return;
            if (dataGridView.Columns[e.ColumnIndex].Name != DescriptionButtonText) return;
            var descriptionColumn = dataGridView.Columns.IndexOf(dataGridView.Columns[Description]);

            var description = dataGridView.Rows[e.RowIndex].Cells[descriptionColumn].Value.ToString();
            // button clicked - do some logic
            MessageBox.Show(description, @"Description", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        void dgvCombo_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            // (No need to write anything in here)
        }
        private void DataGridView1_CellMouseEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex < 0 || e.RowIndex < 0) return;
            if (dataGridView.Columns[e.ColumnIndex].Name != DescriptionButtonText) return;
            var descriptionColumn = dataGridView.Columns.IndexOf(dataGridView.Columns[Description]);
            var descriptionBtnCell = dataGridView.Rows[e.RowIndex].Cells[e.ColumnIndex];
            var data = dataGridView.Rows[e.RowIndex].Cells[descriptionColumn];
            if (data?.Value == null) return;
            var description = data.Value.ToString();
            descriptionBtnCell.ToolTipText = description;
        }
        #endregion


        #region HelperFunctions
        private static DataTable ReadCsvFile(string csvFilePath)
        {
            var lines = File.ReadAllLines(csvFilePath);
            var fields = lines[0].Split(new char[] { ';' });
            var cols = fields.GetLength(0);
            var dt = new DataTable();
            for (var i = 0; i < cols; i++)
            {
                if (fields[i].Contains("Description,,,,,,,,,"))
                    fields[i] = Description;
                dt.Columns.Add(fields[i].ToUpper(), typeof(string));
            }

            for (var i = 1; i < lines.GetLength(0); i++)
            {
                fields = lines[i].Split(new char[] { ';' });
                var row = dt.NewRow();
                for (var f = 0; f < cols; f++)
                    if (!string.IsNullOrEmpty(fields[f])) row[f] = fields[f];
                dt.Rows.Add(row);
            }

            return dt;
        }

        private void FormDesigner()
        {
            dataGridView.BorderStyle = BorderStyle.None;
            dataGridView.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dataGridView.RowsDefaultCellStyle.Padding = new Padding(20, 5, 0, 0);
            dataGridView.DefaultCellStyle.SelectionForeColor = Color.WhiteSmoke;

            dataGridView.EnableHeadersVisualStyles = false;
            dataGridView.AllowUserToOrderColumns = false;
            dataGridView.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dataGridView.ColumnHeadersDefaultCellStyle.BackColor = Color.DodgerBlue;
            dataGridView.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dataGridView.ColumnHeadersDefaultCellStyle.Font = new Font("Cambria", 8.5F, FontStyle.Bold);
            dataGridView.ColumnHeadersDefaultCellStyle.Padding = new Padding(0, 10, 0, 10);
        }

       
        private void CheckIfInStock()
        {
            if (!dataGridView.Columns.Contains(InStock)) return;
            var indexColumn = dataGridView.Columns.IndexOf(dataGridView.Columns[InStock]);

            for (var i = 0; i < dataGridView.RowCount; i++)
            {
                var combo = new DataGridViewCheckBoxCell();

                var data = dataGridView.Rows[i].Cells[indexColumn];
                if (data?.Value == null) continue;
                var dvgValue = data.Value.ToString();
                if (dvgValue.Equals("no"))
                {
                    combo.Value = 1;
                    dataGridView.Rows[i].DefaultCellStyle.BackColor = Color.GhostWhite;
                    dataGridView.Rows[i].DefaultCellStyle.ForeColor = Color.DarkRed;

                }
                else if (dvgValue.Equals("yes"))
                {
                    combo.Value = 0;

                }

                dataGridView.Rows[i].Cells[indexColumn] = combo;

            }

        }

        private void ReplaceBindingColumnWithCombobox()
        {
            if (!dataGridView.Columns.Contains(Binding)) return;
            var indexColumn = dataGridView.Columns.IndexOf(dataGridView.Columns[Binding]);

            for (var i = 0; i < dataGridView.RowCount; i++)
            {
                var combo = new DataGridViewComboBoxCell();

                var comboSource = new Dictionary<int, string>();
                var data = dataGridView.Rows[i].Cells[indexColumn];
                if (data?.Value == null) continue;
                var dvgValue = data.Value.ToString();
                comboSource.Add(i, dvgValue);
                combo.DataSource = new BindingSource(comboSource, null);
                combo.DisplayMember = "Value";
                combo.ValueMember = "Key";

                dataGridView.Rows[i].Cells[indexColumn] = combo;

            }
        }

        private void DisableSorting()
        {
            foreach (DataGridViewColumn column in dataGridView.Columns)
            {
                column.SortMode = DataGridViewColumnSortMode.NotSortable;
            }
        }



        #endregion

         
    }
}
