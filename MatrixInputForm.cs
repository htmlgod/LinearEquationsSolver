using System;
using System.Data;
using System.Windows.Forms;

namespace LinearEquationsSolver
{
    public partial class MatrixInputForm : Form
    {
        private readonly int rows;
        private readonly int cols;

        static DataTable dataTable;

        public MatrixInputForm(int rows, int cols)
        {
            InitializeComponent();
            this.rows = rows;
            this.cols = cols;
        }

        public void MatrixSetup()
        {
            dataTable = new DataTable();

            for (int i = 1; i <= cols - 1; i++)
            {
                dataTable.Columns.Add("x" + i.ToString(), typeof(decimal));
            }
            dataTable.Columns.Add("B", typeof(decimal));
 

            for (int i = 0; i < rows; i++)
                dataTable.Rows.Add(dataTable.NewRow());

            for (int i = 0; i < rows; i++)
                for (int j = 0; j < cols; j++)
                    dataTable.Rows[i][j] = 0;

            dataGridView1.DataSource = dataTable;

            dataGridView1.AutoResizeColumns();
            dataGridView1.AutoResizeRows();
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.RowsDefaultCellStyle.WrapMode = DataGridViewTriState.True;
            dataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCellsExceptHeaders;
        }
        private void ButtonSaveMatrix_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < rows; i++)
                for (int j = 0; j < cols; j++)
                    Solver.matrix[i,j] = Convert.ToDecimal(dataTable.Rows[i][j].ToString());

            Close();
        }
    }
}
