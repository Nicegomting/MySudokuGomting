using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MySudokuGomting
{
    /// <summary>
    /// Sudoku Gomting Canvas Control
    /// </summary>
    public partial class CanvasControl : UserControl
    {
        private int _row_count = 0;
        private int _column_count = 0;
        private const int _margine = 20;
        private int _gridSizeH = 0;
        private int _gridSizeV = 0;
        private int _hiRow = -1;
        private int _hiColumn = -1;
        private bool _isShownSolution = false;
        private Point _highCell = Point.Empty;
        private Point _highClient = Point.Empty;
        private Rectangle _outbound;
        private Rectangle _inbound;
        private SudokuMaster _master;

        private Point HighLightCell
        {
            get => _highCell;
            set
            {
                if (value == Point.Empty)
                {
                    _highClient = Point.Empty;
                    _hiRow = -1;
                    _hiColumn = -1;
                }
                _highCell = value;
            }
        }

        public bool IsShownSolution
        {
            get => _isShownSolution;
            set
            {
                _isShownSolution = value;
                RefreshBoard();
            }
        }

        public CanvasControl()
        {
            InitializeComponent();
            ResizeRedraw = true;
            _master = new SudokuMaster();
            _row_count = SudokuMaster.RowCount;
            _column_count = SudokuMaster.ColumnCount;
        }

        private void CanvasControl_Load(object sender, EventArgs e)
        {
        }

        private void CanvasControl_Resize(object sender, EventArgs e)
        {
            HighLightCell = Point.Empty;
        }

        private void CanvasControl_MouseDown(object sender, MouseEventArgs e)
        {
            _highClient.X = e.X;
            _highClient.Y = e.Y;
            Invalidate(_outbound);
        }

        protected override void OnPaintBackground(PaintEventArgs pevent)
        {
            base.OnPaintBackground(pevent);
            var g = pevent.Graphics;
            DrawBoard(g);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            DrawBoardNumbers(e.Graphics);
            if(IsShownSolution)
                DrawSolutionNumbers(e.Graphics);
            #if DEBUG
                // This will be shown candidates of the cells
                /*DrawCandidates(e.Graphics);*/
            #endif
            DrawHighLightCell(e.Graphics);
        }
        /// <summary>
        /// Draw a base board of the sudoku puzzle
        /// </summary>
        /// <param name="g">Graphics Instance</param>
        private void DrawBoard(Graphics g)
        {            
            var rect = ClientRectangle;
            int grid_size_H = (int)(rect.Width / _column_count);
            int grid_size_V = (int)(rect.Height / _row_count);
            _outbound = new Rectangle(_margine,_margine,(grid_size_H*_column_count)-_margine*2,(grid_size_V*_row_count)-_margine*2);
            _inbound  = new Rectangle(_margine*2,_margine*2,(grid_size_H*_column_count)-_margine*4,(grid_size_V*_row_count)-_margine*4);
            _gridSizeH = (int)(_inbound.Width / _column_count);
            _gridSizeV = (int)(_inbound.Height / _row_count);
            // Draw Board Boundary
            g.FillRectangle(Brushes.Orange, _outbound);
            g.FillRectangle(Brushes.White, _inbound);
            using (Pen thick_pen=new Pen(Color.Orange, 3))
            { 
                // Draw Horizontal Lines
                for (int i=1; i<_row_count; i++)
                {
                    Pen board_pen = null;
                    if (i % 3 != 0)
                        board_pen = Pens.Orange;
                    else
                        board_pen = thick_pen;
                    g.DrawLine(board_pen,_inbound.Left,_inbound.Top+(i*_gridSizeV),_inbound.Right,_inbound.Top+(i*_gridSizeV));
                }
                // Draw Vertical Lines
                for (int i=1; i <_column_count; i++)
                {
                    Pen board_pen = null;
                    if (i % 3 != 0)
                        board_pen = Pens.Orange;
                    else
                        board_pen = thick_pen;
                    g.DrawLine(board_pen,_inbound.Left+(i*_gridSizeH),_inbound.Top,_inbound.Left+(i*_gridSizeH),_inbound.Bottom);
                }
            }
            using(Font index_font=new Font(Font.FontFamily, 11.0f, FontStyle.Bold))
            { 
                // Write Row Indexes
                for (int i=1; i <=_row_count; i++)
                    g.DrawString(i.ToString(),index_font,Brushes.White,_inbound.Left-(_margine*0.80f),_inbound.Top+((i-1)*(_gridSizeV))+(_gridSizeV*0.40f));
                // Write Column Indexes
                for (int i=1; i <=_column_count; i++)
                    g.DrawString(((char)(64+i)).ToString(),index_font,Brushes.White,_inbound.Left+((i-1)*_gridSizeH)+(_gridSizeH*0.44f),_inbound.Top-(_margine*0.94f));
            }
        }
        /// <summary>
        /// Draw all board number of the puzzle
        /// </summary>
        /// <param name="g">Graphics Instance</param>
        private void DrawBoardNumbers(Graphics g)
        {
            for (int i = 0; i < _row_count; i++)
                for (int j = 0; j < _column_count; j++)
                {
                    if (_master[i, j] != 0)
                        PrintNumber(g, i, j, _master[i, j]);
                }
        }
        /// <summary>
        /// Draw all candidates of the puzzle
        /// </summary>
        /// <param name="g">Graphics Instance</param>
        private void DrawCandidates(Graphics g)
        {
            if (!_master.IsSudokuLoaded)
                return;

            for (int i = 0; i < _row_count; i++)
                for (int j = 0; j < _column_count; j++)
                    PrintCandidates(g, i, j, _master.Candidates(i, j));
        }
        /// <summary>
        /// Draw all solution number of the puzzle
        /// </summary>
        /// <param name="g">Graphics Instance</param>
        private void DrawSolutionNumbers(Graphics g)
        {
            if (!_master.IsSudokuLoaded)
                return;

            for (int i = 0; i < _row_count; i++)
                for (int j = 0; j < _column_count; j++)
                {
                    if (_master.Solution(i, j) != 0)
                        PrintSolutionNumber(g, i, j, _master.Solution(i, j));
                }
        }
        /// <summary>
        /// Draw a rectangle of the highlighted cell
        /// </summary>
        /// <param name="g">Graphics Instance</param>
        private void DrawHighLightCell(Graphics g)
        {
            if (g is null)
                return;
            if (_highClient == Point.Empty)
                return;
            if (!_inbound.Contains(_highClient))
            {
                HighLightCell = Point.Empty;
                return;
            }
            int x = _highClient.X;
            int y = _highClient.Y;
            _hiRow = ((y-_inbound.Top)/_gridSizeV);
            _hiColumn = ((x-_inbound.Left)/_gridSizeH);
            int rx = _inbound.Left+(_gridSizeH*_hiColumn);
            int ry = _inbound.Top+(_gridSizeV*_hiRow);
            using(Pen high_pen = new Pen(Color.Black, 4))
            {
                Rectangle high_rect = new Rectangle(rx, ry, _gridSizeH, _gridSizeV);
                g.DrawRectangle(high_pen, high_rect);
            }
        }
        /// <summary>
        /// Print Board number
        /// </summary>
        /// <param name="g">Graphics Instance</param>
        /// <param name="row">Target row index</param>
        /// <param name="column">Target column index</param>
        /// <param name="number">Target number</param>
        private void PrintNumber(Graphics g, int row, int column, int number)
        {
            if (g is null)
                return;

            float H_ratio = _gridSizeH * 0.11f;
            float V_ratio = _gridSizeV * 0.11f;
            using(Font number_font = new Font(Font.FontFamily,11.0f+(H_ratio+V_ratio),FontStyle.Bold))
            { 
                g.DrawString(number.ToString(),number_font,Brushes.Black,_inbound.Left+(_gridSizeH*column)+(_gridSizeH*0.33f),_inbound.Top+(_gridSizeV*row)+(_gridSizeV*0.11f));
            }
        }
        /// <summary>
        /// Print candidate of the cell
        /// </summary>
        /// <param name="g">Graphics Instance</param>
        /// <param name="row">Target row index</param>
        /// <param name="column">Target column index</param>
        /// <param name="candy">Candidate string</param>
        private void PrintCandidates(Graphics g, int row, int column, string candy)
        {
            if (g is null)
                return;

            float H_ratio = _gridSizeH * 0.01f;
            float V_ratio = _gridSizeV * 0.01f;
            using(Font candy_font = new Font(Font.FontFamily, 6.0f+(H_ratio+V_ratio), FontStyle.Regular))
            { 
                g.DrawString(candy, candy_font, Brushes.Red,_inbound.Left+(_gridSizeH*column)+(_gridSizeH*0.05f),_inbound.Top+(_gridSizeV*row)+(_gridSizeV*0.05f));
            }
        }
        /// <summary>
        /// Print Solution Number
        /// </summary>
        /// <param name="g">Graphics Instance</param>
        /// <param name="row">Target row index</param>
        /// <param name="column">Target column index</param>
        /// <param name="number">Target number</param>
        private void PrintSolutionNumber(Graphics g, int row, int column, int number)
        {
            if (g is null)
                return;

            float H_ratio = _gridSizeH * 0.11f;
            float V_ratio = _gridSizeV * 0.11f;
            using(Font solution_font=new Font(Font.FontFamily,11.0f+(H_ratio+V_ratio),FontStyle.Bold))
            {
                g.DrawString(number.ToString(),solution_font, Brushes.Red,_inbound.Left+(_gridSizeH*column)+(_gridSizeH*0.33f),_inbound.Top+(_gridSizeV*row)+(_gridSizeV*0.11f));            
            }
        }
        /// <summary>
        /// Show the sudoku puzzle entering form
        /// </summary>
        /// <param name="owner">Owner handle of the form</param>
        public void ShowSudokuInputForm(IWin32Window owner)
        {
            SudokuInput frmInput = new SudokuInput(_master);
            if(frmInput.ShowDialog(owner) == DialogResult.OK)
                RefreshBoard();
        }
        /// <summary>
        /// Enter the new sudoku puzzle
        /// </summary>
        /// <param name="sudoku_string">Sudoku puzzle string</param>
        /// <returns>Whether the valid puzzle</returns>
        public bool EnterSudoku(string sudoku_string)
        {
            bool result = _master.EnterSudoku(sudoku_string);

            if (result)
                RefreshBoard();

            return result;
        }
        /// <summary>
        /// Show or Hide the solution
        /// </summary>
        public void ShowSolution()
        {
            IsShownSolution = !IsShownSolution;
        }
        /// <summary>
        /// Re-draw the inner board
        /// </summary>
        public void RefreshBoard()
        {
            Invalidate(_inbound);
        }
    }
}