using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Matrix_Library_4_5
{
    public class Plane_3D
    {
        Vector normalVect;
        Vector origin;

        public Plane_3D(Vector normalOfPlane, Vector originOfPlane)
        {
            if (normalOfPlane.size() == 3 && originOfPlane.size() == 3)
            {
                normalVect = normalOfPlane;
                origin = originOfPlane;
            }
            else if (normalOfPlane.size() >= 3 && originOfPlane.size() >= 3)
            {
                normalVect = new Vector(3);
                normalVect.set(0, normalOfPlane.get(0));
                normalVect.set(1, normalOfPlane.get(1));
                normalVect.set(2, normalOfPlane.get(2));
                origin = new Vector(3);
                origin.set(0, originOfPlane.get(0));
                origin.set(1, originOfPlane.get(1));
                origin.set(2, originOfPlane.get(2));
            }
        }

        public Plane_3D(double normalX, double normalY, double normalZ, double originX, double originY, double originZ)
        {
            normalVect = new Vector(normalX, normalY, normalZ);
            origin = new Vector(originX, originY, originZ);
        }

        public Plane_3D(Point_3D point1, Point_3D point2, Point_3D point3)
        {
            Vector v1_2 = new Vector(point2.X - point1.X, point2.Y - point1.Y, point2.Z - point1.Z);
            Vector v2_3 = new Vector(point3.X - point2.X, point3.Y - point2.Y, point3.Z - point2.Z);
            normalVect = v1_2.crossProduct(v2_3);
            origin = new Vector(point1.X, point1.Y, point1.Z);
        }

        public Vector getNormalVector()
        {
            return normalVect;
        }

        public Vector getOrigin()
        {
            return origin;
        }

        public double findDistanceToPoint(Point_3D point)
        {
            Vector pointVect = new Vector(point.X, point.Y, point.Z);
            return normalVect.unit().dotProduct((pointVect.subtract(origin)));
        }

        public Matrix findMirroredPoint(Matrix pointToMirror)
        {
            Vector planeNormal = getUnitNormalVector();
            Vector originalPoint = new Vector(pointToMirror);
            Vector translatedPoint = originalPoint.subtract(origin);
            double distanceToPlane = planeNormal.insideProduct(translatedPoint);
            Vector mirroredPoint = translatedPoint.subtract(planeNormal.mult(2 * distanceToPlane));
            return new Matrix(mirroredPoint.add(origin));
        }

        public bool isParallelTo(Plane_3D otherPlane)
        {
            return normalVect.unit().Equals(otherPlane.getUnitNormalVector());
        }

        public Vector getUnitNormalVector()
        {
            return normalVect.unit();
        }
    }
}
