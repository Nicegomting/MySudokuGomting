using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace MySudokuGomting
{
    public class SudokuMaster
    {
        private ushort[,] _board;
        private ushort[,] _solution;
        private ushort[,] _candidates;

        public static int RowCount    { get { return 9; } }
        public static int ColumnCount { get { return 9; } }
        public bool IsSudokuLoaded => (this.ToString()?.Count(_o => _o == '0')) != _board.Length;
        public int this[int row, int column] => this._board[row, column];
        public int Board(int row, int column) => this[row, column];
        public string Candidates(int row, int column) => Convert.ToString(this._candidates[row, column], toBase:2).PadLeft(ColumnCount+1, '0');
        public int Solution(int row, int column)
        {
            if (this._board[row, column] == 0)
                return this._solution[row, column];
            else
                return 0;
        }
        
        public SudokuMaster()
        {
            _board = new ushort[RowCount, ColumnCount];
            _solution = new ushort[RowCount, ColumnCount];
            _candidates = new ushort[RowCount, ColumnCount];
        }
        /// <summary>
        /// Check the sudoku puzzle is a valid form
        /// </summary>
        /// <param name="sudoku_string">Sudoku puzzle string</param>
        /// <returns>Whether the puzzle is valid</returns>
        public bool IsValidSudokuForm(string sudoku_string)
        {
            if (String.IsNullOrEmpty(sudoku_string) || sudoku_string.Length != RowCount*ColumnCount)
                return false;

            Regex regex = new Regex(@"^\d*$");
            if (!regex.IsMatch(sudoku_string))
                return false;

            return IsValidSudokuStrHorz(sudoku_string) &&
                   IsValidSudokuStrVert(sudoku_string) &&
                   IsValidSudokuStr3x3(sudoku_string);
        }
        /// <summary>
        /// Check whether the duplicate number exists horizontally
        /// </summary>
        /// <param name="sudoku_string">Sudoku puzzle string</param>
        /// <returns>Whether duplicate number exists</returns>
        private bool IsValidSudokuStrHorz(string sudoku_string)
        {
            for (int row=0;row<RowCount;row++)
            {
                string line = sudoku_string.Substring(row*RowCount,ColumnCount);
                string validLine = line.Replace("0", String.Empty);
                bool isDuplicated =  validLine.GroupBy(_o => _o).Any(_g => _g.Count() > 1);
                if (isDuplicated)
                    return false;
            }
            return true;
        }
        /// <summary>
        /// Check whether the duplicate number exists vertically
        /// </summary>
        /// <param name="sudoku_string">Sudoku puzzle string</param>
        /// <returns>Whether duplicate number exists</returns>
        private bool IsValidSudokuStrVert(string sudoku_string)
        {
            for (int column=0;column<ColumnCount;column++)
            {
                string line = String.Empty;
                for(int row=column;row<sudoku_string.Length;row+=ColumnCount)
                    line = String.Concat(line, sudoku_string.ElementAt(row));
                string validLine = line.Replace("0", String.Empty);
                bool isDuplicated = validLine.GroupBy(_o => _o)
                                             .Any(_g => _g.Count() > 1);
                if (isDuplicated)
                    return false;
            }
            return true;
        }
        /// <summary>
        /// Check whether the duplicate number exists in each 3x3 grid
        /// </summary>
        /// <param name="sudoku_string">Sudoku puzzle string</param>
        /// <returns>Whether duplicate number exists</returns>
        private bool IsValidSudokuStr3x3(string sudoku_string)
        {
            for(int row=0;row<sudoku_string.Length;row+=ColumnCount*3)
            {
                for (int col=0;col<ColumnCount;col+=3)
                {
                    string line = String.Empty;
                    for (int i=row+col;i<row+(ColumnCount*3);i+=ColumnCount)
                    {
                        line = String.Concat(line, sudoku_string.ElementAt(i+0));
                        line = String.Concat(line, sudoku_string.ElementAt(i+1));
                        line = String.Concat(line, sudoku_string.ElementAt(i+2));
                    }
                    string validLine = line.Replace("0", String.Empty);
                    bool isDuplicated = validLine.GroupBy(_o => _o).Any(_g => _g.Count() > 1);
                    if (isDuplicated)
                        return false;
                }
            }
            return true;
        }
        /// <summary>
        /// Enter a new sudoku puzzle
        /// </summary>
        /// <param name="sudoku_string">Sudoku puzzle string</param>
        /// <returns>Whether the puzzle is valid</returns>
        public bool EnterSudoku(string sudoku_string)
        {
            if (!IsValidSudokuForm(sudoku_string))
                return false;

            SudokuWork.Clear();
            for (int i=0;i<RowCount;i++)
                for (int j=0;j<ColumnCount;j++)
                {
                    int index = ((j+1)+(i*ColumnCount))-1;
                    _board[i, j] = Convert.ToUInt16(sudoku_string[index].ToString());
                    _solution[i, j] = _board[i, j];
                    _candidates[i, j] = 0x3FE;
                }

            return FindSolution();
        }
        /// <summary>
        /// Clear current sudoku
        /// </summary>
        public void ClearSudoku()
        {
            SudokuWork.Clear();
            for (int i=0;i<RowCount;i++)
                for (int j=0;j<ColumnCount;j++)
                {
                    int index = ((j+1)+(i*ColumnCount))-1;
                    _board[i, j] = 0;
                    _solution[i, j] = 0;
                    _candidates[i, j] = 0x3FE;
                }
        }
        /// <summary>
        /// Create a puzzle string of the current sudoku
        /// </summary>
        /// <returns>Sudoku puzzle string</returns>
        public override string ToString()
        {
            string sudoku_string = String.Empty;
            for (int i = 0; i<_board.GetLength(0); i++)
                for (int j = 0; j<_board.GetLength(1); j++)
                    sudoku_string = String.Concat(sudoku_string, _board[i, j].ToString());
            return sudoku_string;
        }
        /// <summary>
        /// Create a solution string of the current sudoku
        /// </summary>
        /// <returns>Sudoku puzzle string</returns>
        public string ToSolutionString()
        {
            string solution_string = String.Empty;
            for (int i=0; i <_solution.GetLength(0); i++)
                for (int j=0; j <_solution.GetLength(1); j++)
                    solution_string = String.Concat(solution_string, _solution[i, j].ToString());
            return solution_string;
        }
        /// <summary>
        /// Find a solution of the current sudoku puzzle
        /// </summary>
        /// <returns>Whether a solution has been found</returns>
        public bool FindSolution()
        {
            bool result = true;            
            while (result)
            {
                bool isMarked = false;

                if (IsCleared())
                    break;
                // Find all of the candidates for cells
                FindAllCandy();
                // Find single candidate cells and fill in the number
                isMarked = MarkSoloCandy() || MarkUniqueCandy();
                if (!isMarked)
                {
                    if (IsWrongPuzzle() || !TakeMostSafeCandy())
                    {
                        if (!RestoreRecentJunction())
                            return false;
                    }
                }
            }
            return true;
        }
        /// <summary>
        /// Find all candidates of the entire cells
        /// </summary>
        /// <returns>Reserved return value</returns>
        private bool FindAllCandy()
        {
            Find3x3Candy(0);
            FindHorzCandy(0);
            FindVertCandy(0);
            return true;
        }
        /// <summary>
        /// Find all candidates of the 3x3 grid cells
        /// </summary>
        /// <param name="subset">3x3 Grid number(from the left corner to the right bottom)</param>
        /// <returns>Reserved return value</returns>
        private bool Find3x3Candy(int subset)
        {
            if (subset >= 3*3)
                return true;
            
            int sRow = subset-(subset%3);
            int sColumn = (subset%3)*3;
            int eColumn = (subset%3)*3+(3-1);
            int eRow = subset+((3-1)-subset%3);
            List<ushort> occupied_numbers = new List<ushort>();

            for (int row=sRow; row<=eRow; row++)
            {
                for(int column=sColumn; column<=eColumn; column++)
                {
                    if (_solution[row, column] != 0)
                        occupied_numbers.Add(_solution[row, column]);
                }
            } 
            for (int row=sRow; row<=eRow; row++)
            {
                for(int column=sColumn; column<=eColumn; column++)
                {
                    ushort candy=Convert.ToUInt16((_candidates[row, column]&1)==1? 0x3FF : 0x3FE);
                    if (_solution[row, column] == 0)
                    {
                        occupied_numbers.ForEach(_o =>
                            candy=candy.ZRO(_o)
                        );
                        _candidates[row, column]=candy;
                    }
                }
            }
            return Find3x3Candy(subset+1);
        }
        /// <summary>
        /// Find all candidates of the cells by row
        /// </summary>
        /// <param name="row">Target row index</param>
        /// <returns>Reserved return value</returns>
        private bool FindHorzCandy(int row)
        {
            if (row >= RowCount)
                return true;

            List<ushort> occupied_numbers = new List<ushort>();
            for (int y=0; y<ColumnCount; y++)
            {
                ushort board = _solution[row, y];
                if (board != 0)
                    occupied_numbers.Add(board);
            }
            for (int y=0; y<ColumnCount; y++)
            {
                if (_solution[row, y] == 0)
                {
                    occupied_numbers.ForEach(_o =>
                        _candidates[row, y] = _candidates[row, y].ZRO(_o)
                    );
                }
            }
            return FindHorzCandy(row+1);
        }
        /// <summary>
        /// Find all candidates of the cells by column
        /// </summary>
        /// <param name="column">Target column index</param>
        /// <returns>Reserved return value</returns>
        private bool FindVertCandy(int column)
        {
            if (column >= ColumnCount)
                return true;

            List<ushort> occupied_numbers = new List<ushort>();
            for (int x=0; x<RowCount; x++)
            {
                ushort board = _solution[x, column];
                if (board != 0)
                    occupied_numbers.Add(board);
            }
            for (int x=0; x<RowCount; x++)
            {
                if (_solution[x, column] == 0)
                {
                    occupied_numbers.ForEach(_o =>
                        _candidates[x, column] = _candidates[x, column].ZRO(_o)
                    );
                }
            }
            return FindVertCandy(column+1);
        }
        /// <summary>
        /// Check whether the current puzzle solution is invalid
        /// </summary>
        /// <returns>Whether the puzzle solution is invalid</returns>
        private bool IsWrongPuzzle()
        {
            if (!IsValidSudokuForm(ToSolutionString()))
                return true;
            // Check whether the candidates are not available on empty cells
            for (int x = 0; x<RowCount; x++)
                for (int y = 0; y<ColumnCount; y++)
                {
                    ushort candy = _candidates[x, y];
                    ushort solution = _solution[x, y];
                    if (solution == 0 && candy == 0)
                        return true;
                }
            return false;
        }
        /// <summary>
        /// Check whether a solution has been found
        /// </summary>
        /// <returns>Whether a solution has been found</returns>
        private bool IsCleared()
        {
            if (IsWrongPuzzle())
                return false;

            foreach (ushort number in _solution)
            {
                if (number == 0)
                    return false;
            }
            return true;
        }
        /// <summary>
        /// Mark the cells that have only one available candidate
        /// </summary>
        /// <returns>Whether a marked cell exists</returns>
        /// <remarks>It targets the cells that have only one candidate</remarks>
        private bool MarkSoloCandy()
        {
            bool result = false;
            for(int x=0; x<RowCount; x++)
                for(int y=0; y<ColumnCount; y++)
                {
                    if (_solution[x, y] != 0)
                        continue;
                    // Count available candidates except for the junction marker
                    ushort candy =_candidates[x, y];
                    ushort solution = _solution[x, y];
                    string allCandy = Candidates(x, y);
                    string validCandy = allCandy.Substring(0, allCandy.Length-1);
                    if(validCandy.Count(_o => _o == '1')==1)
                    {
                        SudokuWork.Push(x, y, candy, solution);
                        int zeroing_number = ColumnCount-validCandy.IndexOf('1');
                        _candidates[x, y] = candy.ZRO(zeroing_number);
                        _solution[x, y] = Convert.ToUInt16(zeroing_number);
                        result = true;
                    }
                }
            return result;
        }
        /// <summary>
        /// Mark the cells that have a unique candidate in the region (Row,Column,3x3 Grid)
        /// </summary>
        /// <returns>Whether a marked cell exists</returns>
        /// <remarks>It targets the cells that have multiple candidates but only one candidate available in the region</remarks>
        private bool MarkUniqueCandy()
        {
            bool result = false;
            // Find and mark a unique candidate by cell
            for (int x=0;x<RowCount;x++)
            {
                if(MarkHorzUniqueCandy(x))
                {
                    FindAllCandy();
                    result = true;
                }
                for (int y=0;y<ColumnCount;y++)
                {
                    if (Mark3x3UniqueCandy(x, y))
                    {
                        FindAllCandy();
                        result = true;
                    }
                    if(MarkVertUniqueCandy(y))
                    {
                        FindAllCandy();
                        result = true;
                    }
                }
            }
            return result;
        }
        /// <summary>
        /// Mark a unique candidate in the 3x3 grid cells
        /// </summary>
        /// <param name="x">Target row index</param>
        /// <param name="y">Target column index</param>
        /// <returns>Whether a marked cell exists</returns>
        private bool Mark3x3UniqueCandy(int x, int y)
        {
            if (x>=RowCount || y>=ColumnCount)
                return false;

            if (_solution[x, y] != 0)
                return false;

            int subset = Convert.ToInt32((x-(x%3))+Convert.ToInt32(y/3));
            int sRow = subset-(subset%3);
            int sColumn = (subset%3)*3;
            int eColumn = (subset%3)*3+(3-1);
            int eRow = subset+((3-1)-subset%3);
            var candidates = new List<Tuple<int, int, ushort>>();

            for (int row=sRow; row<=eRow; row++)
            {
                for(int column=sColumn; column<=eColumn; column++)
                {
                    ushort candy=_candidates[row, column];
                    var candy3x3 = new Tuple<int, int, ushort>(row, column, candy);
                    if (_solution[row, column] == 0)
                        candidates.Add(candy3x3); 
                }
            }
            int stackLen = SudokuWork.Length;
            ushort currentCandy = _candidates[x, y];
            ushort currentSolution = _solution[x, y];
            for (int reserve=0; reserve<ColumnCount; reserve++)
            {
                int zeroing_number = ColumnCount-reserve;
                if (Convert.ToUInt16(currentCandy&(1<<zeroing_number)) == 0)
                    continue;

                var uniques = from _o in candidates
                              where Convert.ToUInt16(_o.Item3&(1<<zeroing_number))!=0
                              select new
                              {
                                  x = _o.Item1,
                                  y = _o.Item2,
                                  candidate = _o.Item3
                              };
                if (uniques.Count() == 1)
                {
                    var unique = uniques.First();
                    int uniqueX = unique.x;
                    int uniqueY = unique.y;
                    if (uniqueX == x && uniqueY == y)
                    {
                        SudokuWork.Push(uniqueX, uniqueY, currentCandy, currentSolution);
                        _candidates[uniqueX, uniqueY] = currentCandy.ZRO(zeroing_number);
                        _solution[uniqueX, uniqueY] = Convert.ToUInt16(zeroing_number);
                        break;
                    }
                }
            }
            return stackLen<SudokuWork.Length;
        }
        /// <summary>
        /// Mark a unique candidate by the row
        /// </summary>
        /// <param name="x">Target row index</param>
        /// <returns>Whether a marked cell exists</returns>
        private bool MarkHorzUniqueCandy(int x)
        {
            if (x >= RowCount)
                return false;

            int stackLen = SudokuWork.Length;
            var candidates = new List<Tuple<int, int, ushort>>();
            for(int y=0; y<ColumnCount; y++)
            {
                ushort candy=_candidates[x, y];
                var candyHorz = new Tuple<int, int, ushort>(x, y, candy);
                if (_solution[x, y] == 0)
                    candidates.Add(candyHorz);
            }
            
            for (int y=0; y<ColumnCount; y++)
            {
                if (_solution[x, y] != 0)
                    continue;

                ushort currentCandy = _candidates[x, y];
                ushort currentSolution = _solution[x, y];
                for (int reserve=0; reserve<ColumnCount; reserve++)
                {
                    int zeroing_number = ColumnCount-reserve;
                    if (Convert.ToUInt16(currentCandy&(1<<zeroing_number)) == 0)
                        continue;

                    var uniques = from _o in candidates
                                  where Convert.ToUInt16(_o.Item3&(1<<zeroing_number)) != 0
                                  select new
                                  {
                                      x = _o.Item1,
                                      y = _o.Item2,
                                      candidate = _o.Item3
                                  };
                    if (uniques.Count() == 1)
                    {
                        var unique = uniques.First();
                        int uniqueX = unique.x;
                        int uniqueY = unique.y;
                        if (uniqueY == y)
                        {
                            SudokuWork.Push(uniqueX, uniqueY, currentCandy, currentSolution);
                            _candidates[uniqueX, uniqueY] = currentCandy.ZRO(zeroing_number);
                            _solution[uniqueX, uniqueY] = Convert.ToUInt16(zeroing_number);
                            break;
                        }
                    }
                }
            }
            return stackLen<SudokuWork.Length;
        }
        /// <summary>
        /// Mark a unique candidate by the column
        /// </summary>
        /// <param name="y">Target column index</param>
        /// <returns>Whether a marked cell exists</returns>
        private bool MarkVertUniqueCandy(int y)
        {
            if (y >= ColumnCount)
                return false;

            int stackLen = SudokuWork.Length;
            var candidates = new List<Tuple<int, int, ushort>>();
            for(int x=0; x<RowCount; x++)
            {
                ushort candy=_candidates[x, y];
                var candyVert = new Tuple<int, int, ushort>(x, y, candy);
                if (_solution[x, y] == 0)
                    candidates.Add(candyVert);
            }
            
            for (int x=0; x<RowCount; x++)
            {
                if (_solution[x, y] != 0)
                    continue;

                ushort currentCandy = _candidates[x, y];
                ushort currentSolution = _solution[x, y];
                for (int reserve=0; reserve<ColumnCount; reserve++)
                {
                    int zeroing_number = ColumnCount - reserve;
                    if (Convert.ToUInt16(currentCandy&(1<<zeroing_number)) == 0)
                        continue;

                    var uniques = from _o in candidates
                                  where Convert.ToUInt16(_o.Item3&(1<<zeroing_number)) != 0
                                  select new
                                  {
                                      x = _o.Item1,
                                      y = _o.Item2,
                                      candidate = _o.Item3
                                  };
                    if (uniques.Count() == 1)
                    {
                        var unique = uniques.First();
                        int uniqueX = unique.x;
                        int uniqueY = unique.y;
                        if (uniqueX == x)
                        {
                            SudokuWork.Push(uniqueX, uniqueY, currentCandy, currentSolution);                            
                            _candidates[uniqueX, uniqueY] = currentCandy.ZRO(zeroing_number);
                            _solution[uniqueX, uniqueY] = Convert.ToUInt16(zeroing_number);
                            break;
                        }
                    }
                }
            }
            return stackLen<SudokuWork.Length;
        }
        /// <summary>
        /// Mark the candidate of the cell with the highest probability
        /// </summary>
        /// <returns>Whether a marked cell exists</returns>
        private bool TakeMostSafeCandy()
        {
            ushort safety_candy = 0x3FE;
            System.Drawing.Point pt = System.Drawing.Point.Empty;

            for (int x=0; x<RowCount; x++)
                for(int y=0; y<ColumnCount; y++)
                {
                    ushort occupant = _solution[x, y];
                    ushort candy = _candidates[x,y];
                    int junction = (candy&1);
                    if (candy!=0 && safety_candy>candy && occupant==0/*&& junction==0*/)
                    {
                        safety_candy = candy;
                        pt.X = x;
                        pt.Y = y;
                    }
                }

            if (pt == System.Drawing.Point.Empty)
                return false;

            ushort solution = _solution[pt.X, pt.Y];
            string safetyCandy = Convert.ToString(safety_candy, toBase:2).PadLeft(ColumnCount+1, '0');
            string validCandy = safetyCandy.Substring(0, safetyCandy.Length-1);
            for(int index=0; index<validCandy.Length; index++)
            {
                char ch = validCandy[index];
                ushort newSolution = Convert.ToUInt16(ColumnCount-index);
                if (ch == '1')
                {
                    if(solution==0 || solution>newSolution)
                    {
                        safety_candy |= 1;
                        SudokuWork.Push(pt.X, pt.Y, safety_candy, solution);
                        int zeroing_number = ColumnCount-index;
                        _candidates[pt.X, pt.Y] = safety_candy.ZRO(zeroing_number);
                        _solution[pt.X, pt.Y] = Convert.ToUInt16(zeroing_number);
                        break;
                    }
                }
            }
            return true;
        }
        /// <summary>
        /// Restore the work block stack to the lastest junction block
        /// </summary>
        /// <returns>Whether the restore completed</returns>
        private bool RestoreRecentJunction()
        {
            while(true)
            {
                if (!SudokuWork.HasJunction)
                    return false;

                SudokuWorkBlock block = SudokuWork.Peek();
                int x = block.Location.X;
                int y = block.Location.Y;
                ushort nowCandy = _candidates[x, y];
                ushort solution = _solution[x, y];
                ushort oriCandy = block.Candidate;
                ushort oriSolution = block.Solution;

                if (block.IsJunction)
                {
                    // Try to mark the next candidate
                    if (!MarkNextCandy())
                    {
                        _candidates[x, y] = oriCandy.ZRO(0);
                        _solution[x, y] = oriSolution;
                        SudokuWork.Pop();
                    }
                    else
                        break;
                }
                else
                {
                    _candidates[x, y] = oriCandy;
                    _solution[x, y] = oriSolution;
                    SudokuWork.Pop();
                }
            }
            return true;
        }
        /// <summary>
        /// Try to mark the next candidate of the latest junction cell using the junction block
        /// </summary>
        /// <returns>Whether a succeeded in marking a cell</returns>
        private bool MarkNextCandy()
        {
            var block = SudokuWork.Peek();
            if (!block?.IsJunction ?? false)
                return false;

            int x = block.Location.X;
            int y = block.Location.Y;
            ushort nowCandy = _candidates[x, y];
            ushort solution = _solution[x, y];
            string currentCandy = Convert.ToString(nowCandy, toBase:2).PadLeft(ColumnCount+1,'0');
            string validCandy = currentCandy.Substring(0, currentCandy.Length-1);
            
            for (int index=0; index<validCandy.Length; index++)
            {
                var ch = validCandy[index];
                ushort newSolution = Convert.ToUInt16(ColumnCount-index);
                if (ch == '1' && solution>newSolution)
                {
                    _candidates[x, y] = _candidates[x, y].ZRO(newSolution);
                    _solution[x, y] = newSolution;
                    return true;
                }
            }
            return false;
        }
    }
}
