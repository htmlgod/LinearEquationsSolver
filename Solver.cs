using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Windows.Forms;

namespace LinearEquationsSolver
{
    public partial class Solver : Form
    {
        static public decimal[,] matrix;
        static public int rows, columns;
        public int precision;
        MatrixInputForm input_form = null;
        Answer answer_form = null;
        public Solver()
        {
            InitializeComponent();
        }

        private void LoadMatrix(string name)
        {
            string line;

            System.IO.StreamReader file = new System.IO.StreamReader(name);
            if ((line = file.ReadLine()) != null)
            {
                rows = Convert.ToInt32(line);
            }
            if ((line = file.ReadLine()) != null)
            {
                columns = Convert.ToInt32(line);
            }
            matrix = new decimal[rows, columns];
            int rownumber = 0;
            while ((line = file.ReadLine()) != null)
            {
                string[] values = line.Split(' ', StringSplitOptions.RemoveEmptyEntries);

                for (int i = 0; i < columns; i++)
                {
                    matrix[rownumber, i] = Convert.ToDecimal(values[i]);
                }

                rownumber++;
            }

            file.Close();
        }
        private void SaveMatrix(string name)
        {
            FileStream fw = new FileStream(name + ".txt", FileMode.Create);

            string output = "";

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    output += matrix[i, j].ToString() + "  ";
                }
                output += "\r\n";
            }
            byte[] outBytes = Encoding.Default.GetBytes(output);
            fw.Write(outBytes, 0, outBytes.Length);

            if (fw != null) fw.Close();
        }
        private class GaussSolver
        {
            readonly decimal[,] _double;

            public GaussSolver()
            {
                _double = new decimal[rows, columns];

                CopyMatrixIntoDouble();
            }
            private void CopyMatrixIntoDouble()
			{
                for (int i = 0; i < rows; i++)
                    for (int j = 0; j < columns; j++)
                        _double[i, j] = matrix[i, j];
            }
            private bool IsZeroColumn(int col)
			{
                for (int r = 0; r < rows; r++)
                    if (matrix[r,col] != 0)
					{
                        return false;
					}
                return true;
			}
            private bool IsZeroRow(int row)
            {
                for (int k = 0; k < columns; k++)
                {
                    if (matrix[row, k] != 0)
                    {
                        return false;
                    }
                }
                return true;
            }
            private int CountBasisVariables()
            {
                int num_of_basis_vars = columns - 1;

                for (int i = 0; i < rows; i++)
                {
                    if (IsZeroRow(i))
                    {
                        num_of_basis_vars--;
                    }
                }

                return num_of_basis_vars;
            }
            private int FindLargestInCol(int row, int col)
			{
                int max_row = row;
                for (int r = row; r < rows; r ++)
				{
                    if (matrix[r, col] > matrix[max_row, col])
					{
                        max_row = r;
					}
				}

                return max_row;
			}
            private int FindNextNonZeroInRow(int row, int col)
            {
                for (int c = col; c < columns - 1; c++)
				{
                    if (matrix[row, c] != 0)
					{
                        return c;
					}
				}

                return -1;
            }
            private void SwapRows(int r1, int r2)
            {
                decimal[] buf = new decimal[columns];

                for (int i = 0; i < columns; i++)
                {
                    buf[i] = matrix[r1, i];
                    matrix[r1, i] = matrix[r2, i];
                }

                for (int i = 0; i < columns; i++)
                {
                    matrix[r2, i] = buf[i];
                }
            }
            private bool SolutionExists()
            {
                decimal checksum;
                for (int i = 0; i < rows; i++)
                {
                    checksum = 0;
                    for (int j = 0; j < columns - 1; j++)
                    {
                        checksum += matrix[i, j];
                    }
                    if (0 == checksum && matrix[i, columns - 1] != 0)
                    {
                        return false;
                    }
                }
                return true;
            }

            private int FindBasisVar(int row)
			{
                for (int col = 0; col < columns; col++)
				{
                    if (matrix[row, col] == 1)
					{
                        return col;
					}
				}
                return -1;
			}

            private void MakeSolution(ref string[] sol, int precision)
            {
                Dictionary<string, int> vars = new Dictionary<string, int>();
                List<int> basis_vars_indices = new List<int>();
               // Dictionary<string, string> free_vars = new Dictionary<string, string>();

                for (int var = 0; var < sol.Length; var++)
                {
                    string str = "x" + (var + 1).ToString();
                    sol[var] = str + " = ";
                    vars.Add(str, var);
                }

                

                // detect basic variables
                for (int row = rows - 1; row > -1; row--)
				{
                    var variable = FindBasisVar(row);
                    if (variable != -1)
					{
                        sol[variable] += matrix[row, columns - 1].ToString();
                        for (int col = variable + 1; col < columns - 1; col++)
                        {
                            var element = matrix[row, col];
                            if (element != 0)
                            {
                                element = -element;
                                sol[variable] += (element > 0 ? " + " : " - ") + Math.Abs(element).ToString() + " * x" + (col + 1).ToString();
                            }
                        }
                        string removing_basis_var = "x" + (variable + 1).ToString();
                        vars.Remove(removing_basis_var);
                        basis_vars_indices.Add(variable);
                    }
				}

                int lambda_index = 0;

                // check for free variables
                if (vars.Count != 0)
				{
                    foreach (var free_var in vars)
					{
                        string lambda_string = "L" + (++lambda_index).ToString();
                        sol[free_var.Value] += lambda_string;
                        foreach(int basis_var_index in basis_vars_indices)
						{
                            sol[basis_var_index] = sol[basis_var_index].Replace(free_var.Key, lambda_string);
                        }
                    }
				}   
            }

            public string[] Solve(int precision)
            {
                string[] answer = new string[1];
                int shift = 0;
                // 1.matrix to upper triangular matrix
                for (int r = -1, k = -1; r++ < rows - 1 && k++ < columns - 1;)
                {
                    if (matrix[r, k] != 0) // aii != 0
                    {
                        for (int i = r + 1; i < rows; i++)
                        {
                            //double K = Math.Round(_double[i, k] / _double[r, k], precision, MidpointRounding.ToZero);
                            decimal K = _double[i, k] / _double[r, k];
                            for (int j = shift; j < columns; j++)
                                //_double[i, j] = Math.Round(_double[i, j] - _double[k, j] * K, precision, MidpointRounding.ToZero);
                                _double[i, j] = _double[i, j] - _double[r, j] * K;
                        }
                    }
                    else
					{
                        if (IsZeroColumn(k))
						{
                            shift++;
                            r--;
                            continue;
						}
                        else
						{
                            int new_row = FindLargestInCol(r, k);
                            if (new_row != r)
                            {
                                SwapRows(r, new_row);
                                CopyMatrixIntoDouble();
                                r--;
                                k--;
                                continue;
                            }
                        }
					}
                    for (int i = 0; i < rows; i++)
                        for (int j = 0; j < columns; j++)
                        {
                            _double[i, j] = Math.Round(_double[i, j], precision, MidpointRounding.ToEven);
                            matrix[i, j] = _double[i, j];
                        }
                }

                if (!SolutionExists())
                {
                    answer[0] = "Solution does not exist";
                    return answer;
                }

                // 2.dividing all rows by their main non-zero element
                for (int r = 0; r < rows; r++)
                {
                    decimal main_elem = 1;
                    for (int k = 0; k < columns; k++)
                    {
                        if (_double[r, k] != 0)
                        {
                            main_elem = _double[r, k];
                            break;
                        }
                    }
                    for (int k = 0; k < columns; k++)
                    {
                        _double[r, k] = _double[r, k] / main_elem;
                    }
                }
                for (int i = 0; i < rows; i++)
                    for (int j = 0; j < columns; j++)
                    {
                        //_double[i, j] = Math.Round(_double[i, j], precision, MidpointRounding.ToEven);
                        matrix[i, j] = _double[i, j];
                    }



                // 3. Reverse traverse

                for (int r = rows - 1; r > -1; r--)
                {
                    for (int k = columns - 2; k > -1; k--)
                    {
                        if (_double[r, k] != 0 /*&& r == k*/)
                        {
                            for (int row = r - 1; row > -1; row--)
                            {
                                decimal K = _double[row, k] / _double[r, k];
                                for (int col = columns - 1; col > -1; col--)
                                    _double[row, col] = _double[row, col] - _double[r, col] * K;
                            }
                        }
                    }
                }

                for (int i = 0; i < rows; i++)
                    for (int j = 0; j < columns; j++)
                        matrix[i, j] = Math.Round(_double[i, j], precision, MidpointRounding.ToEven);
                answer = new string[columns - 1];
                MakeSolution(ref answer, precision);
                return answer;
            }
        }

        //===== windows forms elements
        //=== manual input mode
        // manual input mode radiobutton
        private void RadioButtonInputManual_CheckedChanged(object sender, EventArgs e)
        {
            groupBoxManual.Enabled = !groupBoxManual.Enabled;
        }
        // disabling "set size" button if sizes were changed
        private void TextBoxColumns_TextChanged(object sender, EventArgs e)
        {
            buttonEditMatrix.Enabled = false;
        }
        private void TextBoxRows_TextChanged(object sender, EventArgs e)
        {
            buttonEditMatrix.Enabled = false;
        }
        // set size button (also MatrixInputForm Setup)
        private void ButtonSetSize_Click(object sender, EventArgs e)
        {
            if (textBoxColumns.Text == "" || textBoxRows.Text == "")
            {
                MessageBox.Show("Empty parameter");
                return;
            }
            rows = Convert.ToInt32(textBoxRows.Text);
            columns = Convert.ToInt32(textBoxColumns.Text) + 1; // plus 1 cuz we have B column

            matrix = new decimal[rows, columns];
            buttonEditMatrix.Enabled = true;

            input_form = new MatrixInputForm(rows, columns);
            input_form.MatrixSetup();
        }
        // edit matrix button
        private void ButtonEditMatrix_Click(object sender, EventArgs e)
        {
            input_form.ShowDialog();
        }

        //=== file input mode
        // file input mode radiobutton
        private void RadioButtonInputFromFile_CheckedChanged(object sender, EventArgs e)
        {
            groupBoxFileInput.Enabled = !groupBoxFileInput.Enabled;
        }
        // opening file
        private void ButtonLoadFile_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();
            label1.Text = openFileDialog1.SafeFileName;
        }
        private void OpenFileDialog1_FileOk(object sender, CancelEventArgs e)
        {
            LoadMatrix(openFileDialog1.FileName);
        }


        //=== solve button
        private void ButtonSolve_Click(object sender, EventArgs e)
        {
            precision = Convert.ToInt32(textBoxPrecision.Text);

            GaussSolver gs = new GaussSolver();
            string[] solution = gs.Solve(precision);

            answer_form = new Answer(solution);

            answer_form.ShowDialog();

            SaveMatrix("result.txt");
        }
    }
}
