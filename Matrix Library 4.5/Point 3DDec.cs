using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Matrix_Library_4_5
{
    public class Point_3DDec
    {
        public decimal X { get; set; }
        public decimal Y { get; set; }
        public decimal Z { get; set; }

        public Point_3DDec(decimal x, decimal y, decimal z)
        {
            this.X = x;
            this.Y = y;
            this.Z = z;
        }

        public Point_3DDec(Point_3DDec toClone)
        {
            this.X = toClone.X;
            this.Y = toClone.Y;
            this.Z = toClone.Z;
        }

        public decimal findDistanceBetweenPoints(Point_3DDec point)
        {
            double yDiffSquared = Math.Pow((double)(point.Y - this.Y), 2);
            double xDiffSquared = Math.Pow((double)(point.X - this.X), 2);
            double zDiffSquared = Math.Pow((double)(point.Z - this.Z), 2);
            return (decimal)Math.Sqrt(yDiffSquared + xDiffSquared + zDiffSquared);
        }
    }
}
