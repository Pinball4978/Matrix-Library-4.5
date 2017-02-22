using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Matrix_Library_4_5
{
    public class Point_3Df
    {
        public float X { get; set; }
        public float Y { get; set; }
        public float Z { get; set; }

        public Point_3Df(float x, float y, float z)
        {
            this.X = x;
            this.Y = y;
            this.Z = z;
        }

        public Point_3Df(Point_3Df toClone)
        {
            this.X = toClone.X;
            this.Y = toClone.Y;
            this.Z = toClone.Z;
        }

        public double findDistanceBetweenPoints(Point_3Df point)
        {
            double yDiffSquared = Math.Pow((point.Y - this.Y), 2);
            double xDiffSquared = Math.Pow((point.X - this.X), 2);
            double zDiffSquared = Math.Pow((point.Z - this.Z), 2);
            return Math.Sqrt(yDiffSquared + xDiffSquared + zDiffSquared);
        }

        public override string ToString()
        {
            return X.ToString("0.0") + ", " + Y.ToString("0.0") + Z.ToString("0.0");
        }
    }
}
