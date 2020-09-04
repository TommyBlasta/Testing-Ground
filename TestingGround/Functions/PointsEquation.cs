using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestingGround.Functions
{
    class PointsEquation
    {
        public int FindMaxValueOfEquation(int[][] points, int k)
        {
            int? maxValue = null;
            //points[0][0] 1 bod, hodota x
            //points[0][1] 1 bod, hodnota y
            //points[1][0] 2bod, hodnota x ...
            for (int i = 0; i <= points.GetLength(0) - 2; i++)
            {
                if (Math.Abs(points[i][0] - points[i + 1][0]) <= k)
                {
                    int equation = (points[i][1] + points[i + 1][1]) + Math.Abs(points[i][0] - points[i + 1][0]);
                    if (equation > maxValue || maxValue == null)
                    {
                        maxValue = equation;
                    }
                }
            }
            return maxValue.GetValueOrDefault();
        }
    }
}
