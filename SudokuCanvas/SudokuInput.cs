using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace MySudokuGomting
{
    /// <summary>
    /// Sudoku Puzzle Input Form
    /// </summary>
    public partial class SudokuInput : Form
    {
        private SudokuMaster _master = null;

        public SudokuInput(SudokuMaster master)
        {
            InitializeComponent();
            _master = master;
            this.Text = Properties.Resources.UI_TITLE_INPUT;
            lbDesc.Text = Properties.Resources.UI_SUDOKU_INPUT;
            lbEx.Text = Properties.Resources.UI_SUDOKU_SAMPLE;
            sbOK.Text = Properties.Resources.UI_SUDOKU_ENTER;
            grPreview.Text = Properties.Resources.UI_PREVIEW_INPUT;
        }

        private void SudokuInput_Load(object sender, EventArgs e)
        {
            CenterToParent();
            tePuzzle.MaxLength = SudokuMaster.RowCount*SudokuMaster.ColumnCount;

            for (int i = 0; i < SudokuMaster.ColumnCount; i++)
            {
                dgPreview.Columns.Add(String.Format("Column{0}", i), "");
                dgPreview.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                dgPreview.Columns[i].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }

            for (int i=0; i <SudokuMaster.RowCount; i++)
                dgPreview.Rows.Add("", "", "","", "", "","", "", "");
        }

        private void dgPreview_Resize(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dgPreview.Rows)
                row.Height = dgPreview.Height / dgPreview.Rows.Count;
        }

        private void sbOK_Click(object sender, EventArgs e)
        {
            if(_master?.EnterSudoku(tePuzzle.Text) ?? false)
            {
                this.DialogResult = DialogResult.OK;
                Close();
            }
            else
                MessageBox.Show(Properties.Resources.MSG_INVALID_PUZZLE, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void UpdatePreview()
        {
            string sudoku_string = tePuzzle.Text;

            if (String.IsNullOrEmpty(sudoku_string) || String.IsNullOrWhiteSpace(sudoku_string))
                return;

            var sudoku = sudoku_string.AsEnumerable();
            for (int i=0; i<sudoku.Count(); i++)
            {
                int row = i / SudokuMaster.ColumnCount;
                int col = i % SudokuMaster.ColumnCount;
                char ch = sudoku.ElementAt(i);

                if (ch != '0')
                    dgPreview.Rows[row].Cells[col].Value = sudoku.ElementAt(i);
            }
        }

        private void tePuzzle_TextChanged(object sender, EventArgs e)
        {
            UpdatePreview();
        }
    }
}
