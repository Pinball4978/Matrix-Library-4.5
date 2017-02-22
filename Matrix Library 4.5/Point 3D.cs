using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Matrix_Library_4_5
{
    public class Point_3D
    {
        public double X { get; set; }
        public double Y { get; set; }
        public double Z { get; set; }

        public Point_3D(double x, double y, double z)
        {
            this.X = x;
            this.Y = y;
            this.Z = z;
        }

        public Point_3D(Point_3D toClone)
        {
            this.X = toClone.X;
            this.Y = toClone.Y;
            this.Z = toClone.Z;
        }

        public double findDistanceBetweenPoints(Point_3D point)
        {
            double yDiffSquared = Math.Pow((point.Y - this.Y), 2);
            double xDiffSquared = Math.Pow((point.X - this.X), 2);
            double zDiffSquared = Math.Pow((point.Z - this.Z), 2);
            return Math.Sqrt(yDiffSquared + xDiffSquared + zDiffSquared);
        }
    }
}
