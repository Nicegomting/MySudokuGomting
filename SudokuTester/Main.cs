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

namespace SudokuTester
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
        }

        private void Main_Load(object sender, EventArgs e)
        {
        }

        private void mOpenSudoku_Click(object sender, EventArgs e)
        {
            var filePath = string.Empty;
            string sudoku_string = String.Empty;

            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "Sudoku Text File (*.txt)|*.txt|All files (*.*)|*.*";
                openFileDialog.Multiselect = false;
                openFileDialog.RestoreDirectory = true;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    filePath = openFileDialog.FileName;

                    try
                    {
                        sudoku_string = File.ReadAllText(filePath, Encoding.Default);
                    }
                    catch
                    {
                    }
                }
            }

            if (!ucSudoku.EnterSudoku(sudoku_string))
                MessageBox.Show(Properties.Resources.MSG_INVALID_PUZZLE, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void mInputPuzzle_Click(object sender, EventArgs e)
        {
            ucSudoku.ShowSudokuInputForm(this);
        }

        private void mShowSolution_Click(object sender, EventArgs e)
        {
            ucSudoku.ShowSolution();
        }

        private void mInfo_Click(object sender, EventArgs e)
        {

        }

        private void mClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // Main
            // 
            this.ClientSize = new System.Drawing.Size(282, 260);
            this.Name = "Main";
            this.ResumeLayout(false);

        }
    }
}
