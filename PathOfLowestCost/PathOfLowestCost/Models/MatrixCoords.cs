using System;
using System.Collections.Generic;
using System.Text;

namespace PathOfLowestCost.Models
{
    public struct MatrixCoords
    {
        public int Row, Column;

        public MatrixCoords(int r, int c)
        {
            Row = r;
            Column = c;
        }
    }
}
