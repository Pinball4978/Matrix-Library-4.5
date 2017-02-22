using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Matrix_Library_4_5
{
    public class Plane_3DDec
    {
        VectorDec normalVect;
        VectorDec origin;

        public Plane_3DDec(VectorDec normalOfPlane, VectorDec originOfPlane)
        {
            if (normalOfPlane.size() == 3 && originOfPlane.size() == 3)
            {
                normalVect = normalOfPlane;
                origin = originOfPlane;
            }
            else if (normalOfPlane.size() >= 3 && originOfPlane.size() >= 3)
            {
                normalVect = new VectorDec(3);
                normalVect.set(0, normalOfPlane.get(0));
                normalVect.set(1, normalOfPlane.get(1));
                normalVect.set(2, normalOfPlane.get(2));
                origin = new VectorDec(3);
                origin.set(0, originOfPlane.get(0));
                origin.set(1, originOfPlane.get(1));
                origin.set(2, originOfPlane.get(2));
            }
        }

        public Plane_3DDec(decimal normalX, decimal normalY, decimal normalZ, decimal originX, decimal originY, decimal originZ)
        {
            normalVect = new VectorDec(normalX, normalY, normalZ);
            origin = new VectorDec(originX, originY, originZ);
        }

        public Plane_3DDec(Point_3DDec point1, Point_3DDec point2, Point_3DDec point3)
        {
            VectorDec v1_2 = new VectorDec(point2.X - point1.X, point2.Y - point1.Y, point2.Z - point1.Z);
            VectorDec v2_3 = new VectorDec(point3.X - point2.X, point3.Y - point2.Y, point3.Z - point2.Z);
            normalVect = v1_2.crossProduct(v2_3);
            origin = new VectorDec(point1.X, point1.Y, point1.Z);
        }

        public VectorDec getNormalVector()
        {
            return normalVect;
        }

        public VectorDec getOrigin()
        {
            return origin;
        }

        public decimal findDistanceToPoint(Point_3DDec point)
        {
            VectorDec pointVect = new VectorDec(point.X, point.Y, point.Z);
            return normalVect.unit().dotProduct((pointVect.subtract(origin)));
        }

        public MatrixDec findMirroredPoint(MatrixDec pointToMirror)
        {
            VectorDec planeNormal = getUnitNormalVector();
            VectorDec originalPoint = new VectorDec(pointToMirror);
            VectorDec translatedPoint = originalPoint.subtract(origin);
            decimal distanceToPlane = planeNormal.insideProduct(translatedPoint);
            VectorDec mirroredPoint = translatedPoint.subtract(planeNormal.mult(2 * distanceToPlane));
            return new MatrixDec(mirroredPoint.add(origin));
        }

        public bool isParallelTo(Plane_3DDec otherPlane)
        {
            return normalVect.unit().Equals(otherPlane.getUnitNormalVector());
        }

        public VectorDec getUnitNormalVector()
        {
            return normalVect.unit();
        }
    }
}
