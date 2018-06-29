using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PathOfLowestCost.Models;

namespace PathOfLowestCost.Services
{
    public class CostService : ICostService
    {
        public async Task<ResultItem> GetLowest(string mData)
        {
            var matrix = GetMatrix(mData);
            if (matrix == null || matrix.Length == 0)
                return null;

            return await Task.Run((() => Lowest(matrix)));
        }

        private static ResultItem Lowest(int[,] matrix)
        {
            ResultItem result = null;
            for (var i = 0; i < matrix.Length; i++)
            {
                var list = new List<int> { matrix[i, 0] };
                var row = FromPoint(matrix, new MatrixCoords(matrix[i, 0], 1), list, 1);
                if (result == null || row.TotalCost < result.TotalCost)
                    result = row;
            }

            return result;
        }

        private static ResultItem FromPoint(int[,] matrix, MatrixCoords coords, ICollection<int> prevPath, int prevLocation)
        {
            var location = prevLocation + matrix[coords.Row - 1, coords.Column - 1];
            prevPath.Add(coords.Row);
            if (location > 50)
                return new ResultItem(false, prevLocation, string.Join(",", prevPath));

            if (coords.Column == matrix.Length)
                return new ResultItem(true, location, string.Join(",", prevPath));

            var upPath = FromPoint(matrix, GoUp(matrix, coords.Row, coords.Column), prevPath, location);
            var rightPath = FromPoint(matrix, GoRight(coords.Row, coords.Column), prevPath, location);
            var downPath = FromPoint(matrix, GoDown(matrix, coords.Row, coords.Column), prevPath, location);

            if (upPath.TotalCost > rightPath.TotalCost && upPath.TotalCost > downPath.TotalCost)
                return upPath;

            return rightPath.TotalCost > downPath.TotalCost ? rightPath : downPath;
        }

        private static MatrixCoords GoUp(int[,] matrix, int row, int column)
        {
            return row == 1
                ? new MatrixCoords(matrix.Length, column + 1)
                : new MatrixCoords(row - 1, column + 1);
        }

        private static MatrixCoords GoDown(int[,] matrix, int row, int column)
        {
            return row == matrix.Length 
                ? new MatrixCoords(1, column + 1) 
                : new MatrixCoords(row + 1, column + 1);
        }

        private static MatrixCoords GoRight(int row, int column)
        {
            return new MatrixCoords(row, column + 1);
        }

        private static int[,] GetMatrix(string data)
        {
            var lines = data.Split(new[] {Environment.NewLine}, StringSplitOptions.None);
            if (!lines.Any()) return null;
            var colCount = lines[0].Split(',').Length;
            var matrix = new int[lines.Length, colCount];
            for (var i = 0; i < lines.Length; i++)
            {
                var rows = lines[i].Split(',');
                for (var j = 0; j < rows.Length; j++)
                {
                    matrix[i, j] = Convert.ToInt32(rows[j]);
                }
            }

            return matrix;
        }
    }
}
