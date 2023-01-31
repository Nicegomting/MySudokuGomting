using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySudokuGomting
{
    internal static class ShiftExtender
    {
        public static ushort ZRO(this ushort value, int x)
        {
            return Convert.ToUInt16(value ^ (1 << x) & value);
        }
    }
}