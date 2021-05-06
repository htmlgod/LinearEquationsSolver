using System;
using System.Windows.Forms;

namespace LinearEquationsSolver
{
    public partial class Answer : Form
    {
        public Answer(string[] ans)
        {
            InitializeComponent();
            richTextBox1.Text += "Answer: \n";
            for (int i = 0; i < ans.Length; i++)
            {
                richTextBox1.Text += ans[i] + "\n";
            }
        }
    }
}
