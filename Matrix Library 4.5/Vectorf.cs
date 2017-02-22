using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
//using System.Runtime.InteropServices;

namespace Matrix_Library_4_5
{
    //[ComVisible(true)]
    public class Vectorf
    {
        private float[] vect;

        /// <summary>
        /// Creates a vector of three elements. All elements are set to 0
        /// </summary>
        public Vectorf()
        {
            vect = new float[3];
            vect[0] = 0;
            vect[1] = 0;
            vect[2] = 0;
        }

        /// <summary>
        /// Creates a vector of the specified length. All elements are set to 0
        /// </summary>
        /// <param name="j">The number of elements to be in this vector.</param>
        public Vectorf(int j)
        {
            vect = new float[j];
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
        public Vectorf(float a, float b, float c)
        {
            vect = new float[3];
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
        public Vectorf(float a, float b, float c, float d)
        {
            vect = new float[4];
            vect[0] = a;
            vect[1] = b;
            vect[2] = c;
            vect[3] = d;
        }

        /// <summary>
        /// Creates a vecotr initilized with the values passed in
        /// </summary>
        /// <param name="a">all of the values this vector is to be initialized with</param>
        public Vectorf(params float[] a)
        {
            vect = new float[a.Length];
            int i = 0;
            foreach (float entry in a)
            {
                vect[i++] = entry;
            }
        }

        /// <summary>
        /// Creates a vector by copying another vector
        /// </summary>
        /// <param name="a">the vector being copied </param>
        public Vectorf(Vectorf a)
        {
            vect = new float[a.size()];
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
        public Vectorf(Matrix a)
        {
            int[] aSize = a.size();
            if (aSize[1] == 1 && aSize[0] == 3)
            {
                vect = new float[3];
                vect[0] = (float)a.get(0, 0);
                vect[1] = (float)a.get(1, 0);
                vect[2] = (float)a.get(2, 0);
            }
            else if (aSize[1] == 4)
            {
                vect = new float[3];
                vect[0] = (float)a.get(0, 3);
                vect[1] = (float)a.get(1, 3);
                vect[2] = (float)a.get(2, 3);
            }
            else
            {
                vect = new float[aSize[0]];
                for (int i = 0; i < aSize[0]; i++)
                {
                    vect[i] = (float)a.get(i, 0);
                }
            }
        }

        /// <summary>
        /// Creates a new vector with all of the elements initilized with 1's
        /// </summary>
        /// <param name="a">the number of elements in the vector to be created</param>
        /// <returns>a new vector where every element is a '1'</returns>
        public static Vectorf ones(int a)
        {
            Vectorf ret = new Vectorf(a);
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
        public Vectorf subset(int startingPos)
        {
            Vectorf ret = new Vectorf(this.vect.Length - startingPos);
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
        public float get(int a)
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
        /// Returns how many bytes this vector takes up
        /// </summary>
        /// <returns>the number of bytes this vector is</returns>
        public int sizeInBytes()
        {
            return this.vect.Length * 4;
        }

        /// <summary>
        /// Returns the column of a matrix
        /// </summary>
        /// <param name="a">the matrix having a column retrieved out of it</param>
        /// <param name="col">the number of the column being retrieved. This is zero-based. </param>
        /// <returns>a new vector which is a copy of the specified column</returns>
        public static Vectorf getCol(Matrix a, int col)
        {
            int[] size = a.size();
            Vectorf ret = new Vectorf(size[0]);
            for (int i = 0; i < size[0]; i++)
            {
                ret.vect[i] = (float)a.get(i, col);
            }
            return ret;
        }

        /// <summary>
        /// Returns the row of a matix
        /// </summary>
        /// <param name="a">the matrix having a row retrieved out of it</param>
        /// <param name="row">the number of the row being retrieved. This is zero-based.</param>
        /// <returns>a new vector which is a copy of the specified row</returns>
        public static Vectorf getRow(Matrix a, int row)
        {
            int[] size = a.size();
            Vectorf ret = new Vectorf(size[1]);
            for (int i = 0; i < size[1]; i++)
            {
                ret.vect[i] = (float)a.get(row, i);
            }
            return ret;
        }

        /// <summary>
        /// sets the value for a single element in this vector
        /// </summary>
        /// <param name="a">the zero-based number for the element being set</param>
        /// <param name="num">the new number for the element being set</param>
        public void set(int a, float num)
        {
            vect[a] = num;
        }

        public bool Equals(Vectorf otherVector)
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

        public int CompareTo(Vectorf otherVector)
        {
            for (int i=0;i<this.size();i++)
            {
                if (Matrix.isCloseToEqual(this.get(i), otherVector.get(i)))
                {
                    continue;
                }
                else if (this.get(i) < otherVector.get(i))
                {
                    return -1;
                }
                else
                {
                    return 1;
                }
            }
            return 0;
        }

        public float findAngleBetweenVectors(Vectorf otherVector)
        {
            return (float)Math.Acos((this.dotProduct(otherVector))/ (this.magnitude() * otherVector.magnitude()));
        }

        public Matrix findTransformationMatixToMakeThisVectorMatchAnother(Vectorf otherVector)
        {
            if (this.size() == 3 && otherVector.size() == 3)
            {
                Vectorf vectorBeingRotatedAbout = this.crossProduct(otherVector);
                float angleOfRotation = this.findAngleBetweenVectors(otherVector);
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

        public Matrix findMatrixToRotateAboutThisVector(float angle, bool angleIsInDegrees)
        {
            Vectorf unitAxis = this.unit();
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
        public float findCosineSimilarity(Vectorf b)
        {
            return (this.dotProduct(b)) / (this.magnitude() * b.magnitude());
        }

        /// <summary>
        /// Finds the square root of the the squares of the first three elements in this vector
        /// </summary>
        /// <returns>the square root of the the squares of the first three elements in this vector</returns>
        public float magnitude()
        {
            return (float)Math.Sqrt(Math.Pow((double)vect[0], 2) + (double)Math.Pow(vect[1], 2) + (double)Math.Pow(vect[2], 2));
        }

        /// <summary>
        /// Adds the square of every element together and then returning the square root of that
        /// </summary>
        /// <returns>the square root of the squares of all of the elements</returns>
        public float magnitudeAll()
        {
            double ret = 0;
            for (int i = 0; i < this.size(); i++)
            {
                ret += Math.Pow((double)this.get(i), 2);
            }
            return (float)Math.Sqrt(ret);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="num"></param>
        /// <returns></returns>
        public Vectorf mult(float num)
        {
            Vectorf ret = new Vectorf(this.size());
            for (int i = 0; i < this.size(); i++)
            {
                ret.set(i, this.get(i) * num);
            }
            return ret;
        }

        public static Vectorf operator -(Vectorf a, Vectorf b)
        {
            return a.subtract(b);
        }

        public Vectorf subtract(Vectorf b)
        {
            if (this.size() == b.size())
            {
                Vectorf ret = new Vectorf(this.size());
                for (int i = 0; i < this.size(); i++)
                {
                    ret.set(i, this.get(i) - b.get(i));
                }
                return ret;
            }
            return null;
        }

        public static Vectorf operator +(Vectorf a, Vectorf b)
        {
            return a.add(b);
        }

        public Vectorf add(Vectorf b)
        {
            if (this.size() == b.size())
            {
                Vectorf ret = new Vectorf(this.size());
                for (int i = 0; i < this.size(); i++)
                {
                    ret.set(i, this.get(i) + b.get(i));
                }
                return ret;
            }
            return null;
        }

        public Vectorf add(float b)
        {
            Vectorf ret = new Vectorf(this.size());
            for (int i = 0; i < this.size(); i++)
            {
                ret.set(i, this.get(i) + b);
            }
            return ret;
        }

        public Vectorf unit()
        {
            float size = this.magnitudeAll();
            Vectorf ret = new Vectorf();
            for (int i = 0; i < vect.Length; i++)
            {
                ret.vect[i] = this.vect[i] / size;
            }
            return ret;
        }

        public float dotProduct(Vectorf b)
        {
            return (this.vect[0] * b.vect[0] + this.vect[1] * b.vect[1] + this.vect[2] * b.vect[2]);
        }

        public Vectorf crossProduct(Vectorf b)
        {
            float i = this.vect[1] * b.vect[2] - this.vect[2] * b.vect[1];
            float j = -(this.vect[0] * b.vect[2] - this.vect[2] * b.vect[0]);
            float k = this.vect[0] * b.vect[1] - this.vect[1] * b.vect[0];
            return new Vectorf(i, j, k);
        }

        public Vectorf findProjectionOntoPlane(Vectorf plane)
        {
            float temp = plane.dotProduct(this) / (float)Math.Pow(plane.magnitudeAll(), 2);
            return this.subtract(plane.mult(temp));
        }

        public string print()
        {
            string ret = "";
            for (int i = 0; i < vect.Length; i++)
            {
                Console.WriteLine(vect[i]);
                ret += vect[i];
                if (i + 1 < vect.Length)
                {
                    ret += ",";
                }
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

        public Matrix outsideProduct(Vectorf b)
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

        public float insideProduct(Vectorf b)
        {
            if (this.size() == b.size())
            {
                float ret = 0;
                for (int i = 0; i < this.size(); i++)
                {
                    ret += this.get(i) * b.get(i);
                }
                return ret;
            }
            return 0;
        }

        public Vectorf toLength4Vector()
        {
            Vectorf ret = new Vectorf(4);
            ret.set(0, this.get(0));
            ret.set(1, this.get(1));
            ret.set(2, this.get(2));
            ret.set(3, 1.0f);
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

        public static Vectorf makeItPlane(Vectorf a, Vectorf b)
        {
            return a.crossProduct(b);
        }

        /// <summary>
        /// finds the value returned when a value is plugged into the equation for a line
        /// </summary>
        /// <param name="x">the value to be substituted in</param>
        /// <param name="line">the line the value is being substituted into</param>
        /// <returns>the value of returned when x is plugged into the equation for the line</returns>
        public static float findValueOfX(float x, Vectorf line)
        {
            Vectorf xs = new Vectorf(line.size());
            xs.set(0, 1);
            for (int i = 1; i < line.size(); i++)
            {
                xs.set(i, (float)Math.Pow(x, i));
            }
            return xs.insideProduct(line);
        }
    }
}
