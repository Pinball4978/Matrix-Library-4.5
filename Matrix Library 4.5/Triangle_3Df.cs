using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Matrix_Library_4_5
{
    public class Triangle_3Df
    {
        public Point_3Df A { get; set; }
        public Point_3Df B { get; set; }
        public Point_3Df C { get; set; }

        public Triangle_3Df(Point_3Df a, Point_3Df b, Point_3Df c)
        {
            A = a;
            B = b;
            C = c;
        }
    }
}
