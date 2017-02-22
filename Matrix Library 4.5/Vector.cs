using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
//using System.Runtime.InteropServices;

namespace Matrix_Library_4_5
{
    //[ComVisible(true)]
    public class Vector
    {
        private double[] vect;

        /// <summary>
        /// Creates a vector of three elements. All elements are set to 0
        /// </summary>
        public Vector()
        {
            vect = new double[3];
            vect[0] = 0;
            vect[1] = 0;
            vect[2] = 0;
        }

        /// <summary>
        /// Creates a vector of the specified length. All elements are set to 0
        /// </summary>
        /// <param name="j">The number of elements to be in this vector.</param>
        public Vector(int j)
        {
            vect = new double[j];
            for (int i = 0; i < j; i++)
            {
                vect[i] = 0;
            }
        }

        /// <summary>
        /// Creates a vector initilized with passed in values.
        /// </summary>
        /// <param name="a">the value for the first element</param>
        /// <param name="b">the value for the second element</param>
        /// <param name="c">the value for the third element</param>
        public Vector(double a, double b, double c)
        {
            vect = new double[3];
            vect[0] = a;
            vect[1] = b;
            vect[2] = c;
        }

        /// <summary>
        /// Creates a vector initilized with passed in values.
        /// </summary>
        /// <param name="a">the value for the first element</param>
        /// <param name="b">the value for the second element</param>
        /// <param name="c">the value for the third element</param>
        /// <param name="d">the value for teh fourth element</param>
        public Vector(double a, double b, double c, double d)
        {
            vect = new double[4];
            vect[0] = a;
            vect[1] = b;
            vect[2] = c;
            vect[3] = d;
        }

        /// <summary>
        /// Creates a vecotr initilized with the values passed in
        /// </summary>
        /// <param name="a">all of the values this vector is to be initialized with</param>
        public Vector(params double[] a)
        {
            vect = new double[a.Length];
            int i = 0;
            foreach (double entry in a)
            {
                vect[i++] = entry;
            }
        }

        /// <summary>
        /// Creates a vector by copying another vector
        /// </summary>
        /// <param name="a">the vector being copied </param>
        public Vector(Vector a)
        {
            vect = new double[a.size()];
            for (int i = 0; i < a.size(); i++)
            {
                vect[i] = a.get(i);
            }
        }

        /// <summary>
        /// Creates a vector by copying the matrix if the matrix is just one column, 
        /// or if the matrix has 4 columns, then this vector is initialized with the first three elements of the fourth column
        /// </summary>
        /// <param name="a">the matrix that will have its values used to initalize this vector</param>
        public Vector(Matrix a)
        {
            int[] aSize = a.size();
            if (aSize[1] == 1 && aSize[0] == 3)
            {
                vect = new double[3];
                vect[0] = a.get(0, 0);
                vect[1] = a.get(1, 0);
                vect[2] = a.get(2, 0);
            }
            else if (aSize[1] == 4)
            {
                vect = new double[3];
                vect[0] = a.get(0, 3);
                vect[1] = a.get(1, 3);
                vect[2] = a.get(2, 3);
            }
            else
            {
                vect = new double[aSize[0]];
                for (int i = 0; i < aSize[0]; i++)
                {
                    vect[i] = a.get(i, 0);
                }
            }
        }

        /// <summary>
        /// Creates a new vector with all of the elements initilized with 1's
        /// </summary>
        /// <param name="a">the number of elements in the vector to be created</param>
        /// <returns>a new vector where every element is a '1'</returns>
        public static Vector ones(int a)
        {
            Vector ret = new Vector(a);
            for (int i = 0; i < a; i++)
            {
                ret.set(i, 1);
            }
            return ret;
        }

        /// <summary>
        /// Creates a new vector which is copy of this matrix, but without some of the top elements
        /// </summary>
        /// <param name="startingPos">the position that will be the top element of the new vector. This is zero-based.</param>
        /// <returns>a new vector that is a copy of part of this vector</returns>
        public Vector subset(int startingPos)
        {
            Vector ret = new Vector(this.vect.Length - startingPos);
            for (int i = startingPos; i < this.vect.Length; i++)
            {
                ret.vect[i - startingPos] = this.vect[i];
            }
            return ret;
        }

        /// <summary>
        /// returns an element of this vector
        /// </summary>
        /// <param name="a">The number of the element you want. This is zero-based.</param>
        /// <returns>the element at the position specified by the argument</returns>
        public double get(int a)
        {
            return vect[a];
        }

        /// <summary>
        /// Returns the number of elements in this vector
        /// </summary>
        /// <returns>the number of elements in this vector</returns>
        public int size()
        {
            return this.vect.Length;
        }

        /// <summary>
        /// Returns the column of a matrix
        /// </summary>
        /// <param name="a">the matrix having a column retrieved out of it</param>
        /// <param name="col">the number of the column being retrieved. This is zero-based. </param>
        /// <returns>a new vector which is a copy of the specified column</returns>
        public static Vector getCol(Matrix a, int col)
        {
            int[] size = a.size();
            Vector ret = new Vector(size[0]);
            for (int i = 0; i < size[0]; i++)
            {
                ret.vect[i] = a.get(i, col);
            }
            return ret;
        }

        /// <summary>
        /// Returns the row of a matix
        /// </summary>
        /// <param name="a">the matrix having a row retrieved out of it</param>
        /// <param name="row">the number of the row being retrieved. This is zero-based.</param>
        /// <returns>a new vector which is a copy of the specified row</returns>
        public static Vector getRow(Matrix a, int row)
        {
            int[] size = a.size();
            Vector ret = new Vector(size[1]);
            for (int i = 0; i < size[1]; i++)
            {
                ret.vect[i] = a.get(row, i);
            }
            return ret;
        }

        /// <summary>
        /// sets the value for a single element in this vector
        /// </summary>
        /// <param name="a">the zero-based number for the element being set</param>
        /// <param name="num">the new number for the element being set</param>
        public void set(int a, double num)
        {
            vect[a] = num;
        }

        public bool Equals(Vector otherVector)
        {
            if (this.size() != otherVector.size())
            {
                return false;
            }
            else
            {
                bool ret = true;
                for (int i = 0; i < this.size(); i++)
                { 
                    ret &= Matrix.isCloseToEqual(this.get(i), otherVector.get(i));
                }
                return ret;
            }
        }

        public double findAngleBetweenVectors(Vector otherVector)
        {
            return Math.Acos((this.dotProduct(otherVector))/ (this.magnitude() * otherVector.magnitude()));
        }

        public Matrix findTransformationMatixToMakeThisVectorMatchAnother(Vector otherVector)
        {
            if (this.size() == 3 && otherVector.size() == 3)
            {
                Vector vectorBeingRotatedAbout = this.crossProduct(otherVector);
                double angleOfRotation = this.findAngleBetweenVectors(otherVector);
                if (angleOfRotation != 0 && (vectorBeingRotatedAbout.get(0) != 0 || vectorBeingRotatedAbout.get(1) != 0 || vectorBeingRotatedAbout.get(2) != 0))
                {
                    return vectorBeingRotatedAbout.findMatrixToRotateAboutThisVector(angleOfRotation, false);
                }
                else
                {
                    return new Matrix();
                }
            }
            else
            {
                return null;
            }
        }

        public Matrix findMatrixToRotateAboutThisVector(double angle, bool angleIsInDegrees)
        {
            Vector unitAxis = this.unit();
            double d = Math.Sqrt(Math.Pow(unitAxis.get(1), 2) + Math.Pow(unitAxis.get(2), 2));
            Matrix xRot = new Matrix();
            xRot.set(1, 1, unitAxis.get(2) / d);
            xRot.set(1, 2, -1.0*unitAxis.get(1) / d);
            xRot.set(2, 1, unitAxis.get(1) / d);
            xRot.set(2, 2, unitAxis.get(2) / d);
            Matrix xRotInverse = new Matrix();
            xRotInverse.set(1, 1, unitAxis.get(2) / d);
            xRotInverse.set(1, 2, unitAxis.get(1) / d);
            xRotInverse.set(2, 1, -1.0 * unitAxis.get(1) / d);
            xRotInverse.set(2, 2, unitAxis.get(2) / d);
            Matrix yRot = new Matrix();
            yRot.set(0, 0, d);
            yRot.set(0, 2, -1.0 * unitAxis.get(0));
            yRot.set(2, 0, unitAxis.get(0));
            yRot.set(2, 2, d);
            Matrix yRotInverse = new Matrix();
            yRotInverse.set(0, 0, d);
            yRotInverse.set(0, 2, unitAxis.get(0));
            yRotInverse.set(2, 0, -1.0 * unitAxis.get(0));
            yRotInverse.set(2, 2, d);
            Matrix zRot = new Matrix(angle, 'z', angleIsInDegrees);
            return (xRotInverse.multiply(yRotInverse.multiply(zRot.multiply(yRot.multiply(xRot)))));
        }

        /// <summary>
        /// Measures how close two vectors are to being parallel
        /// </summary>
        /// <param name="b">the other vector this one is being compared to</param>
        /// <returns>a value somewhere on the range from -1 to 1, a 1 is returned for two vectors that are completely parallel,
        /// -1 for two vectors that are completely parallel but pointed in opposite directions. A zero is returned when the vectors are perpindicular</returns>
        public double findCosineSimilarity(Vector b)
        {
            return (this.dotProduct(b)) / (this.magnitude() * b.magnitude());
        }

        /// <summary>
        /// Finds the square root of the the squares of the first three elements in this vector
        /// </summary>
        /// <returns>the square root of the the squares of the first three elements in this vector</returns>
        public double magnitude()
        {
            return Math.Sqrt(Math.Pow(vect[0], 2) + Math.Pow(vect[1], 2) + Math.Pow(vect[2], 2));
        }

        /// <summary>
        /// Adds the square of every element together and then returning the square root of that
        /// </summary>
        /// <returns>the square root of the squares of all of the elements</returns>
        public double magnitudeAll()
        {
            double ret = 0;
            for (int i = 0; i < this.size(); i++)
            {
                ret += Math.Pow(this.get(i), 2);
            }
            return Math.Sqrt(ret);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="num"></param>
        /// <returns></returns>
        public Vector mult(double num)
        {
            Vector ret = new Vector(this.size());
            for (int i = 0; i < this.size(); i++)
            {
                ret.set(i, this.get(i) * num);
            }
            return ret;
        }

        public Vector subtract(Vector b)
        {
            if (this.size() == b.size())
            {
                Vector ret = new Vector(this.size());
                for (int i = 0; i < this.size(); i++)
                {
                    ret.set(i, this.get(i) - b.get(i));
                }
                return ret;
            }
            return null;
        }

        public Vector add(Vector b)
        {
            if (this.size() == b.size())
            {
                Vector ret = new Vector(this.size());
                for (int i = 0; i < this.size(); i++)
                {
                    ret.set(i, this.get(i) + b.get(i));
                }
                return ret;
            }
            return null;
        }

        public Vector add(double b)
        {
            Vector ret = new Vector(this.size());
            for (int i = 0; i < this.size(); i++)
            {
                ret.set(i, this.get(i) + b);
            }
            return ret;
        }

        public Vector unit()
        {
            double size = this.magnitudeAll();
            Vector ret = new Vector();
            for (int i = 0; i < vect.Length; i++)
            {
                ret.vect[i] = this.vect[i] / size;
            }
            return ret;
        }

        public double dotProduct(Vector b)
        {
            return (this.vect[0] * b.vect[0] + this.vect[1] * b.vect[1] + this.vect[2] * b.vect[2]);
        }

        public Vector crossProduct(Vector b)
        {
            double i = this.vect[1] * b.vect[2] - this.vect[2] * b.vect[1];
            double j = -(this.vect[0] * b.vect[2] - this.vect[2] * b.vect[0]);
            double k = this.vect[0] * b.vect[1] - this.vect[1] * b.vect[0];
            return new Vector(i, j, k);
        }

        public Vector findProjectionOntoPlane(Vector plane)
        {
            double temp = plane.dotProduct(this) / Math.Pow(plane.magnitudeAll(), 2);
            return this.subtract(plane.mult(temp));
        }

        public string print()
        {
            string ret = "";
            for (int i = 0; i < vect.Length; i++)
            {
                Console.WriteLine(vect[i]);
                ret += vect[i];
            }
            return ret;
        }

        public Matrix transpose()
        {
            Matrix ret = new Matrix(this.vect.Length, 1);
            for (int i = 0; i < this.vect.Length; i++)
            {
                ret.set(0, i, this.vect[i]);
            }
            return ret;
        }

        public Matrix outsideProduct(Vector b)
        {
            if (this.size() == b.size())
            {
                Matrix ret = new Matrix(this.size(), this.size());
                for (int i = 0; i < this.size(); i++)
                {
                    for (int j = 0; j < this.size(); j++)
                    {
                        ret.set(i, j, this.get(i) * b.get(j));
                    }
                }
                return ret;
            }
            return null;
        }

        public double insideProduct(Vector b)
        {
            if (this.size() == b.size())
            {
                double ret = 0;
                for (int i = 0; i < this.size(); i++)
                {
                    ret += this.get(i) * b.get(i);
                }
                return ret;
            }
            return 0;
        }

        public Vector toLength4Vector()
        {
            Vector ret = new Vector(4);
            ret.set(0, this.get(0));
            ret.set(1, this.get(1));
            ret.set(2, this.get(2));
            ret.set(3, 1.0);
            return ret;
        }

        public Matrix to4By4Matrix()
        {
            Matrix ret = new Matrix();
            ret.set(0, 3, this.get(0));
            ret.set(1, 3, this.get(1));
            ret.set(2, 3, this.get(2));
            return ret;
        }

        public Matrix to4By1Matrix()
        {
            Matrix ret = new Matrix(4, 1);
            ret.set(0, 0, this.get(0));
            ret.set(1, 0, this.get(1));
            ret.set(2, 0, this.get(2));
            ret.set(3, 0, 1);
            return ret;
        }

        public Matrix toColMatrix()
        {
            Matrix ret = new Matrix(this.size(), 1);
            for (int i = 0; i < this.size(); i++)
            {
                ret.set(i, 0, this.get(i));
            }
            return ret;
        }

        public static Vector makeItPlane(Vector a, Vector b)
        {
            return a.crossProduct(b);
        }

        /// <summary>
        /// finds the value returned when a value is plugged into the equation for a line
        /// </summary>
        /// <param name="x">the value to be substituted in</param>
        /// <param name="line">the line the value is being substituted into</param>
        /// <returns>the value of returned when x is plugged into the equation for the line</returns>
        public static double findValueOfX(double x, Vector line)
        {
            Vector xs = new Vector(line.size());
            xs.set(0, 1);
            for (int i = 1; i < line.size(); i++)
            {
                xs.set(i, Math.Pow(x, i));
            }
            return xs.insideProduct(line);
        }
    }
}
