namespace WindowsFormNet
{
    partial class BookRecordForm
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.dataGridView = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.delete_btn_nostock_books = new System.Windows.Forms.Button();
            this.load_file_btn = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // openFileDialog
            // 
            this.openFileDialog.FileName = "openFileDialog";
            // 
            // dataGridView
            // 
            this.dataGridView.AllowUserToOrderColumns = true;
            this.dataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
            this.dataGridView.BackgroundColor = System.Drawing.Color.WhiteSmoke;
            this.dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridView.DefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridView.Location = new System.Drawing.Point(18, 130);
            this.dataGridView.Name = "dataGridView";
            this.dataGridView.RowHeadersWidth = 51;
            this.dataGridView.RowTemplate.Height = 25;
            this.dataGridView.Size = new System.Drawing.Size(1046, 525);
            this.dataGridView.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.SystemColors.Highlight;
            this.label1.Dock = System.Windows.Forms.DockStyle.Top;
            this.label1.Font = new System.Drawing.Font("Cambria", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(1085, 51);
            this.label1.TabIndex = 3;
            this.label1.Text = "Book Records\r\n";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // delete_btn_nostock_books
            // 
            this.delete_btn_nostock_books.BackColor = System.Drawing.Color.Red;
            this.delete_btn_nostock_books.FlatAppearance.BorderColor = System.Drawing.Color.Red;
            this.delete_btn_nostock_books.FlatAppearance.BorderSize = 0;
            this.delete_btn_nostock_books.Font = new System.Drawing.Font("Cambria", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.delete_btn_nostock_books.ForeColor = System.Drawing.Color.White;
            this.delete_btn_nostock_books.Location = new System.Drawing.Point(923, 15);
            this.delete_btn_nostock_books.Name = "delete_btn_nostock_books";
            this.delete_btn_nostock_books.Size = new System.Drawing.Size(108, 43);
            this.delete_btn_nostock_books.TabIndex = 4;
            this.delete_btn_nostock_books.Text = "Delete ";
            this.delete_btn_nostock_books.UseVisualStyleBackColor = false;
            this.delete_btn_nostock_books.Click += new System.EventHandler(this.delete_btn_nostock_books_Click);
            // 
            // load_file_btn
            // 
            this.load_file_btn.BackColor = System.Drawing.Color.DodgerBlue;
            this.load_file_btn.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.load_file_btn.FlatAppearance.BorderSize = 0;
            this.load_file_btn.Font = new System.Drawing.Font("Cambria", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.load_file_btn.ForeColor = System.Drawing.Color.White;
            this.load_file_btn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.load_file_btn.Location = new System.Drawing.Point(807, 14);
            this.load_file_btn.Name = "load_file_btn";
            this.load_file_btn.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.load_file_btn.Size = new System.Drawing.Size(110, 44);
            this.load_file_btn.TabIndex = 6;
            this.load_file_btn.Text = "Load File";
            this.load_file_btn.UseVisualStyleBackColor = false;
            this.load_file_btn.Click += new System.EventHandler(this.load_file_btn_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.Transparent;
            this.groupBox1.Controls.Add(this.load_file_btn);
            this.groupBox1.Controls.Add(this.delete_btn_nostock_books);
            this.groupBox1.Location = new System.Drawing.Point(18, 54);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1046, 68);
            this.groupBox1.TabIndex = 7;
            this.groupBox1.TabStop = false;
            // 
            // BookRecordForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1085, 713);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dataGridView);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "BookRecordForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Book Record";
            this.Load += new System.EventHandler(this.MainForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.DataGridView dataGridView;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button delete_btn_nostock_books;
        private System.Windows.Forms.Button load_file_btn;
        private System.Windows.Forms.GroupBox groupBox1;
    }
}

