using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Matrix_Library_4_5
{
    public class Point_2D
    {
        public double X { get; set; }
        public double Y { get; set; }

        public Point_2D(double x, double y)
        {
            this.X = x;
            this.Y = y;
        }

        public double distanceBetweenPoints(Point_2D point)
        {
            double yDiffSquared = Math.Pow((point.Y - this.Y), 2);
            double xDiffSquared = Math.Pow((point.X - this.X), 2);
            return Math.Sqrt(yDiffSquared + xDiffSquared);
        }
    }
}
