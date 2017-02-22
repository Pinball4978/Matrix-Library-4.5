using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Matrix_Library_4_5
{
    public class Plane_3Df
    {
        Vectorf normalVect;
        Vectorf origin;

        public Plane_3Df(Vectorf normalOfPlane, Vectorf originOfPlane)
        {
            if (normalOfPlane.size() == 3 && originOfPlane.size() == 3)
            {
                normalVect = normalOfPlane;
                origin = originOfPlane;
            }
            else if (normalOfPlane.size() >= 3 && originOfPlane.size() >= 3)
            {
                normalVect = new Vectorf(3);
                normalVect.set(0, normalOfPlane.get(0));
                normalVect.set(1, normalOfPlane.get(1));
                normalVect.set(2, normalOfPlane.get(2));
                origin = new Vectorf(3);
                origin.set(0, originOfPlane.get(0));
                origin.set(1, originOfPlane.get(1));
                origin.set(2, originOfPlane.get(2));
            }
        }

        public Plane_3Df(float normalX, float normalY, float normalZ, float originX, float originY, float originZ)
        {
            normalVect = new Vectorf(normalX, normalY, normalZ);
            origin = new Vectorf(originX, originY, originZ);
        }

        public Plane_3Df(Point_3Df point1, Point_3Df point2, Point_3Df point3)
        {
            Vectorf v1_2 = new Vectorf(point2.X - point1.X, point2.Y - point1.Y, point2.Z - point1.Z);
            Vectorf v2_3 = new Vectorf(point3.X - point2.X, point3.Y - point2.Y, point3.Z - point2.Z);
            normalVect = v1_2.crossProduct(v2_3);
            origin = new Vectorf(point1.X, point1.Y, point1.Z);
        }

        public Plane_3Df(Triangle_3Df triangle)
        {
            Vectorf v1_2 = new Vectorf(triangle.B.X - triangle.A.X, triangle.B.Y - triangle.A.Y, triangle.B.Z - triangle.A.Z);
            Vectorf v2_3 = new Vectorf(triangle.C.X - triangle.B.X, triangle.C.Y - triangle.B.Y, triangle.C.Z - triangle.B.Z);
            normalVect = v1_2.crossProduct(v2_3);
            origin = new Vectorf(triangle.A.X, triangle.A.Y, triangle.A.Z);
        }

        public Vectorf getNormalVector()
        {
            return normalVect;
        }

        public Vectorf getOrigin()
        {
            return origin;
        }

        public double findDistanceToPoint(Point_3Df point)
        {
            Vectorf pointVect = new Vectorf(point.X, point.Y, point.Z);
            return normalVect.unit().dotProduct((pointVect.subtract(origin)));
        }

        public bool isParallelTo(Plane_3Df otherPlane)
        {
            return normalVect.unit().Equals(otherPlane.getUnitNormalVector());
        }

        public Vectorf getUnitNormalVector()
        {
            return normalVect.unit();
        }
    }
}
