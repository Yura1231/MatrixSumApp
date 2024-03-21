using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MatrixSumApp
{
    public partial class Form1 : Form
    {
        private DataGridView dataGridView1;
        private Button btnCreate;
        private Button btnCalculate;
        private TextBox txtRows;
        private TextBox txtColumns;
        private TextBox txtResult;

        public Form1()
        {
            InitializeComponent();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.btnCreate = new System.Windows.Forms.Button();
            this.btnCalculate = new System.Windows.Forms.Button();
            this.txtRows = new System.Windows.Forms.TextBox();
            this.txtColumns = new System.Windows.Forms.TextBox();
            this.txtResult = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            
            
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(12, 12);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(240, 150);
            this.dataGridView1.TabIndex = 0;
           
            this.btnCreate.Location = new System.Drawing.Point(12, 168);
            this.btnCreate.Name = "btnCreate";
            this.btnCreate.Size = new System.Drawing.Size(75, 23);
            this.btnCreate.TabIndex = 1;
            this.btnCreate.Text = "Create Matrix";
            this.btnCreate.UseVisualStyleBackColor = true;
            this.btnCreate.Click += new System.EventHandler(this.btnCreate_Click);
           
            this.btnCalculate.Location = new System.Drawing.Point(93, 168);
            this.btnCalculate.Name = "btnCalculate";
            this.btnCalculate.Size = new System.Drawing.Size(75, 23);
            this.btnCalculate.TabIndex = 2;
            this.btnCalculate.Text = "Calculate";
            this.btnCalculate.UseVisualStyleBackColor = true;
            this.btnCalculate.Click += new System.EventHandler(this.btnCalculate_Click);
           
            this.txtRows.Location = new System.Drawing.Point(12, 198);
            this.txtRows.Name = "txtRows";
            this.txtRows.Size = new System.Drawing.Size(100, 20);
            this.txtRows.TabIndex = 3;
            this.txtRows.Text = "3";
            
            this.txtColumns.Location = new System.Drawing.Point(118, 198);
            this.txtColumns.Name = "txtColumns";
            this.txtColumns.Size = new System.Drawing.Size(100, 20);
            this.txtColumns.TabIndex = 4;
            this.txtColumns.Text = "3";
            
            this.txtResult.Location = new System.Drawing.Point(12, 224);
            this.txtResult.Multiline = true;
            this.txtResult.Name = "txtResult";
            this.txtResult.ReadOnly = true;
            this.txtResult.Size = new System.Drawing.Size(240, 150);
            this.txtResult.TabIndex = 5;
             
            this.ClientSize = new System.Drawing.Size(264, 386);
            this.Controls.Add(this.txtResult);
            this.Controls.Add(this.txtColumns);
            this.Controls.Add(this.txtRows);
            this.Controls.Add(this.btnCalculate);
            this.Controls.Add(this.btnCreate);
            this.Controls.Add(this.dataGridView1);
            this.Name = "Form1";
            this.Text = "Matrix Sum Calculator";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            
        }


        private void btnCalculate_Click(object sender, EventArgs e)
        {
            
            int rows = int.Parse(txtRows.Text);
            int cols = int.Parse(txtColumns.Text);

            
            int[,] matrix = new int[rows, cols];
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    if (dataGridView1.Rows[i].Cells[j].Value != null) 
                    {
                        matrix[i, j] = int.Parse(dataGridView1.Rows[i].Cells[j].Value.ToString());
                    }
                }
            }

            
            int sum = 0;
            for (int i = 0; i < rows; i++)
            {
                bool hasNegative = false;
                for (int j = 0; j < cols; j++)
                {
                    if (matrix[i, j] < 0)
                    {
                        hasNegative = true;
                        break;
                    }
                    else
                    {
                        sum += matrix[i, j];
                    }
                }
                if (!hasNegative)
                {
                    
                    txtResult.AppendText($"Сума елементів у рядку {i + 1}: {sum}\n");
                }
                sum = 0; 
            }
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            
            int rows, cols;
            if (!int.TryParse(txtRows.Text, out rows) || !int.TryParse(txtColumns.Text, out cols))
            {
                MessageBox.Show("Розмір матриці має бути цілим числом.");
                return;
            }

            if (rows <= 0 || rows > 10 || cols <= 0 || cols > 10)
            {
                MessageBox.Show("Невірний розмір");
                return;
            }

            
            dataGridView1.Rows.Clear();
            dataGridView1.Columns.Clear();
            dataGridView1.ColumnCount = cols;

            for (int i = 0; i < rows; i++)
            {
                dataGridView1.Rows.Add();
            }
        }
    }
}
