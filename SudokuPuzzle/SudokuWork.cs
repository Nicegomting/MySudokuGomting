using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace MySudokuGomting
{
    /// <summary>
    /// Sudoku work block for solving the puzzle
    /// </summary>
    public class SudokuWorkBlock
    {
        public ushort Candidate = 0;
        public ushort Solution = 0;
        public Point Location = Point.Empty;
        public bool IsJunction
        {
            get
            {
                string candy = Convert.ToString(Candidate, toBase:2).PadLeft(SudokuMaster.ColumnCount+1, '0');
                return candy.Last() == '1';
            }
        }
    }
    /// <summary>
    /// Sudoku work block stack manager
    /// </summary>
    public class SudokuWork
    {
        public static Stack<SudokuWorkBlock> _sudokuStack = new Stack<SudokuWorkBlock>();
        public static int Length => _sudokuStack.Count;
        public static bool IsEmpty => _sudokuStack.Count == 0;
        public static bool HasJunction => _sudokuStack.Any(_o => _o.IsJunction);

        public static void Push(int x, int y, ushort candy, ushort solution)
        {
            Point pt = new Point(x, y);
            SudokuWorkBlock newBlock = new SudokuWorkBlock()
            {
                Candidate = candy,
                Location = pt,
                Solution = solution,
            };
            _sudokuStack.Push(newBlock);
        }
        public static SudokuWorkBlock Pop()
        {
            if (IsEmpty)
                return null;
            else
                return _sudokuStack.Pop();
        }
        public static SudokuWorkBlock Peek()
        {
            if (IsEmpty)
                return null;
            else
                return _sudokuStack.Peek();
        }
        public static void Clear()
        {
            _sudokuStack.Clear();
        }
    }
}
