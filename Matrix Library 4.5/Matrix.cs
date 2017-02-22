using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
//using System.Runtime.InteropServices;

namespace Matrix_Library_4_5
{

    //[ComVisible(true)]
    public class Matrix
    {
        private double[][] mat;
        public const double SMALLEST_NONZERO_NUMBER = 0.00000000001;
        #region Constructors

        /// <summary>
        /// Creates the 4x4 identity matrix
        /// </summary>
        public Matrix()
        {
            mat = new double[4][];
            for (int i = 0; i < 4; i++)
            {
                mat[i] = new double[4];
            }
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    if (i == j)
                    {
                        mat[i][j] = 1;
                    }
                    else
                    {
                        mat[i][j] = 0;
                    }
                }
            }
        }

        /// <summary>
        /// Creates a matrix with the specified number of rows and columns
        /// </summary>
        /// <param name="rows">the nubmer of rows this matrix is to have</param>
        /// <param name="cols">the number of columns this matrix is to have</param>
        public Matrix(int rows, int cols)
        {
            mat = new double[rows][];
            for (int i = 0; i < rows; i++)
            {
                mat[i] = new double[cols];
            }
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    if (i == j)
                    {
                        mat[i][j] = 1;
                    }
                    else
                    {
                        mat[i][j] = 0;
                    }
                }
            }
        }

        /// <summary>
        /// Creates a 4x4 matrix with each element of that matrix being specified by an argument
        /// </summary>
        /// <param name="a">row 1 column 1</param>
        /// <param name="b">row 1 column 2</param>
        /// <param name="c">row 1 column 3</param>
        /// <param name="d">row 1 column 4</param>
        /// <param name="e">row 2 column 1</param>
        /// <param name="f">row 2 column 2</param>
        /// <param name="g">row 2 column 3</param>
        /// <param name="h">row 2 column 4</param>
        /// <param name="i">row 3 column 1</param>
        /// <param name="j">row 3 column 2</param>
        /// <param name="k">row 3 column 3</param>
        /// <param name="l">row 3 column 4</param>
        /// <param name="m">row 4 column 1</param>
        /// <param name="n">row 4 column 2</param>
        /// <param name="o">row 4 column 3</param>
        /// <param name="p">row 4 column 4</param>
        public Matrix(double a, double b, double c, double d, double e, double f, double g, double h, double i, double j, double k, double l, double m, double n, double o, double p)
        {
            mat = new double[4][];
            for (int moo = 0; moo < 4; moo++)
            {
                mat[moo] = new double[4];
            }
            mat[0][0] = a;
            mat[0][1] = b;
            mat[0][2] = c;
            mat[0][3] = d;
            mat[1][0] = e;
            mat[1][1] = f;
            mat[1][2] = g;
            mat[1][3] = h;
            mat[2][0] = i;
            mat[2][1] = j;
            mat[2][2] = k;
            mat[2][3] = l;
            mat[3][0] = m;
            mat[3][1] = n;
            mat[3][2] = o;
            mat[3][3] = p;
        }

        /// <summary>
        /// Creates a 4x4 matrix with each element of that matrix being specified by an element from the argument array
        /// </summary>
        /// <param name="values">an array 16 elements that lists the values of the matrix in order left to right, top to bottom</param>
        public Matrix(double[] values)
        {
            if (values.Length == 16)
            {
                mat = new double[4][];
                for (int moo = 0; moo < 4; moo++)
                {
                    mat[moo] = new double[4];
                }
                mat[0][0] = values[0];
                mat[0][1] = values[1];
                mat[0][2] = values[2];
                mat[0][3] = values[3];
                mat[1][0] = values[4];
                mat[1][1] = values[5];
                mat[1][2] = values[6];
                mat[1][3] = values[7];
                mat[2][0] = values[8];
                mat[2][1] = values[9];
                mat[2][2] = values[10];
                mat[2][3] = values[11];
                mat[3][0] = values[12];
                mat[3][1] = values[13];
                mat[3][2] = values[14];
                mat[3][3] = values[15];
            }
        }

        /// <summary>
        /// Creates a 2x2 matrix with each element of that matrix being specified by an argument
        /// </summary>
        /// <param name="a">row 1 column 1</param>
        /// <param name="b">row 1 column 2</param>
        /// <param name="c">row 2 column 1</param>
        /// <param name="d">row 2 column 2</param>
        public Matrix(double a, double b, double c, double d)
        {
            mat = new double[2][];
            for (int moo = 0; moo < 2; moo++)
            {
                mat[moo] = new double[2];
            }
            mat[0][0] = a;
            mat[0][1] = b;
            mat[1][0] = c;
            mat[1][1] = d;
        }

        /// <summary>
        /// Creates a 4x4 transformation matrix
        /// </summary>
        /// <param name="xPosition">the x translation component of the matrix</param>
        /// <param name="yPosition">the y translation component of the matrix</param>
        /// <param name="zPosition">the z translation component of the matrix</param>
        /// <param name="xAngle">the angle of rotation about the x axis</param>
        /// <param name="yAngle">the angle of rotation about the y axis</param>
        /// <param name="zAngle">the angle of rotation about the z axis</param>
        /// <param name="angleOrder">the order in which the rotations will be applied. 
        /// Ex. "ZYX"- applies the z rotation, then the y rotation, followed by the x rotation
        /// Ex. "XYZ"- applies the x rotation, then the y rotation, followed by the z rotation</param>
        /// <param name="anglesAreInDegrees">boolean specifing whether or not the angle arguments are in degrees or radians
        /// True = all angles are in degrees
        /// False = all angles are in radians</param>
        public Matrix(double xPosition, double yPosition, double zPosition, double xAngle, double yAngle, double zAngle, string angleOrder, bool anglesAreInDegrees)
        {
            mat = new double[4][];
            for (int moo = 0; moo < 4; moo++)
            {
                mat[moo] = new double[4];
            }
            Matrix[] rotationMatrices = new Matrix[3];      //array to hold the three rotation matrices in the order that they are multiplied
            switch (angleOrder.ElementAt(0))
            {                       //store first rotation matrix based on the first letter of the angleOrder string
                case 'x':
                case 'X':
                    rotationMatrices[0] = new Matrix(xAngle, 'x', anglesAreInDegrees);
                    break;
                case 'y':
                case 'Y':
                    rotationMatrices[0] = new Matrix(yAngle, 'y', anglesAreInDegrees);
                    break;
                case 'z':
                case 'Z':
                    rotationMatrices[0] = new Matrix(zAngle, 'z', anglesAreInDegrees);
                    break;
            }
            switch (angleOrder.ElementAt(1))
            {                       //store second rotation matrix based on the second letter of the angleOrder string
                case 'x':
                case 'X':
                    rotationMatrices[1] = new Matrix(xAngle, 'x', anglesAreInDegrees);
                    break;
                case 'y':
                case 'Y':
                    rotationMatrices[1] = new Matrix(yAngle, 'y', anglesAreInDegrees);
                    break;
                case 'z':
                case 'Z':
                    rotationMatrices[1] = new Matrix(zAngle, 'z', anglesAreInDegrees);
                    break;
            }
            switch (angleOrder.ElementAt(2))
            {                       //store third rotation matrix based on the third letter of the angleOrder string
                case 'x':
                case 'X':
                    rotationMatrices[2] = new Matrix(xAngle, 'x', anglesAreInDegrees);
                    break;
                case 'y':
                case 'Y':
                    rotationMatrices[2] = new Matrix(yAngle, 'y', anglesAreInDegrees);
                    break;
                case 'z':
                case 'Z':
                    rotationMatrices[2] = new Matrix(zAngle, 'z', anglesAreInDegrees);
                    break;
            }
            Matrix temp = rotationMatrices[0].multiply(rotationMatrices[1].multiply(rotationMatrices[2]));      //build the final rotation matrix by multiplying the three individual rotation matrices in correct order
            mat[0][0] = temp.get(0, 0);         //fill in values for the transformation matrix
            mat[0][1] = temp.get(0, 1);
            mat[0][2] = temp.get(0, 2);
            mat[0][3] = xPosition;
            mat[1][0] = temp.get(1, 0);
            mat[1][1] = temp.get(1, 1);
            mat[1][2] = temp.get(1, 2);
            mat[1][3] = yPosition;
            mat[2][0] = temp.get(2, 0);
            mat[2][1] = temp.get(2, 1);
            mat[2][2] = temp.get(2, 2);
            mat[2][3] = zPosition;
            mat[3][0] = 0;
            mat[3][1] = 0;
            mat[3][2] = 0;
            mat[3][3] = 1;
        }

        /// <summary>
        /// Builds a 4x4 translation matrix (transformation matrix with no rotation)
        /// </summary>
        /// <param name="v">Vector containing the x,y,z translation values. I.E. v(0) = x , v(1) = y, v(2) = z</param>
        public Matrix(Vector v)
        {
            mat = new double[4][];
            for (int i = 0; i < 4; i++)
            {
                mat[i] = new double[4];
            }
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    if (i == j)
                    {
                        mat[i][j] = 1;
                    }
                    else
                    {
                        mat[i][j] = 0;
                    }
                }
            }
            mat[0][3] = v.get(0);
            mat[1][3] = v.get(1);
            mat[2][3] = v.get(2);
        }

        /// <summary>
        /// produces matrix from stream
        /// </summary>
        /// <param name="fileStream">an already opened stream to read the matrix from NOTE: calling function must close stream</param>
        /// <param name="numberOfRows">the number of rows the matrix will have</param>
        /// <param name="numberOfColumns">the number of columns the matrix will have</param>
        public Matrix(ref TextReader reader, int numberOfRows, int numberOfColumns)
        {
            mat = new double[numberOfRows][];
            for (int i = 0; i < numberOfRows; i++)
            {
                mat[i] = new double[numberOfColumns];
            }
            
            for (int i = 0; i < numberOfRows; i++)
            {
                string temp = reader.ReadLine().Trim();
                string[] stringValues = temp.Split( new char[1] {' '}, StringSplitOptions.RemoveEmptyEntries);
                for (int j = 0; j < numberOfColumns; j++)
                {
                    mat[i][j] = double.Parse(stringValues[j]);
                }
            }
        }

        /// <summary>
        /// Creates a 4x4 rotation matrix (last row and column is the same as identity matrix)
        /// </summary>
        /// <param name="angle">the angle, in radians, of the rotation</param>
        /// <param name="orientation">the axis about which this rotation will be made. I.E. 'x', 'y', 'z'</param>
        public Matrix(double angle, char orientation)
        {
            char letter;
            switch (orientation)
            {                       //make sure the passed in character is a capitol letter
                case 'x':
                    {
                        letter = 'X';
                        break;
                    }
                case 'y':
                    {
                        letter = 'Y';
                        break;
                    }
                case 'z':
                    {
                        letter = 'Z';
                        break;
                    }
                default:
                    {
                        letter = orientation;
                        break;
                    }
            }
            switch (letter)
            {
                case 'X':
                    {
                        mat = new double[4][];
                        for (int moo = 0; moo < 4; moo++)
                        {
                            mat[moo] = new double[4];
                        }
                        mat[0][0] = 1;
                        mat[0][1] = 0;
                        mat[0][2] = 0;
                        mat[0][3] = 0;//end first row
                        mat[1][0] = 0;
                        mat[1][1] = (double)Math.Cos(angle);
                        mat[1][2] = (double)-Math.Sin(angle);
                        mat[1][3] = 0;//end second row
                        mat[2][0] = 0;
                        mat[2][1] = (double)Math.Sin(angle);
                        mat[2][2] = (double)Math.Cos(angle);
                        mat[2][3] = 0;//end third row
                        mat[3][0] = 0;
                        mat[3][1] = 0;
                        mat[3][2] = 0;
                        mat[3][3] = 1;
                        break;
                    }
                case 'Y':
                    {
                        mat = new double[4][];
                        for (int moo = 0; moo < 4; moo++)
                        {
                            mat[moo] = new double[4];
                        }
                        mat[0][0] = (double)Math.Cos(angle);
                        mat[0][1] = 0;
                        mat[0][2] = (double)Math.Sin(angle);
                        mat[0][3] = 0;//end first row
                        mat[1][0] = 0;
                        mat[1][1] = 1;
                        mat[1][2] = 0;
                        mat[1][3] = 0;//end second row
                        mat[2][0] = (double)-Math.Sin(angle);
                        mat[2][1] = 0;
                        mat[2][2] = (double)Math.Cos(angle);
                        mat[2][3] = 0;//end third row
                        mat[3][0] = 0;
                        mat[3][1] = 0;
                        mat[3][2] = 0;
                        mat[3][3] = 1;
                        break;
                    }
                case 'Z':
                    {
                        mat = new double[4][];
                        for (int moo = 0; moo < 4; moo++)
                        {
                            mat[moo] = new double[4];
                        }
                        mat[0][0] = (double)Math.Cos(angle);
                        mat[0][1] = (double)-Math.Sin(angle);
                        mat[0][2] = 0;
                        mat[0][3] = 0;//end first row
                        mat[1][0] = (double)Math.Sin(angle);
                        mat[1][1] = (double)Math.Cos(angle);
                        mat[1][2] = 0;
                        mat[1][3] = 0;//end second row
                        mat[2][0] = 0;
                        mat[2][1] = 0;
                        mat[2][2] = 1;
                        mat[2][3] = 0;//end third row
                        mat[3][0] = 0;
                        mat[3][1] = 0;
                        mat[3][2] = 0;
                        mat[3][3] = 1;
                        break;
                    }
            }
        }

        /// <summary>
        /// Creates a 4x4 rotation matrix (last row and column is the same as identity matrix)
        /// </summary>
        /// <param name="angle">the angle, in radians or degrees, of the rotation</param>
        /// <param name="orientation">the axis about which this rotation will be made. I.E. 'x', 'y', 'z'</param>
        /// <param name="angleIsInDegrees">bool stating whether the angle is in radians or degrees
        /// True = angle is in degrees
        /// False = angle is in radians</param>
        public Matrix(double angle, char orientation, bool angleIsInDegrees)
        {
            char letter;
            double tempAngle = angle;
            if (angleIsInDegrees)       
            {                       //angle is in degrees, need to convert to radians
                tempAngle = angle * (Math.PI / 180.0);
            }
            switch (orientation)
            {                       //make sure the passed in character is a capitol letter
                case 'x':
                    {
                        letter = 'X';
                        break;
                    }
                case 'y':
                    {
                        letter = 'Y';
                        break;
                    }
                case 'z':
                    {
                        letter = 'Z';
                        break;
                    }
                default:
                    {
                        letter = orientation;
                        break;
                    }
            }
            switch (letter)
            {
                case 'X':
                    {
                        mat = new double[4][];
                        for (int moo = 0; moo < 4; moo++)
                        {
                            mat[moo] = new double[4];
                        }
                        mat[0][0] = 1;
                        mat[0][1] = 0;
                        mat[0][2] = 0;
                        mat[0][3] = 0;//end first row
                        mat[1][0] = 0;
                        mat[1][1] = (double)Math.Cos(tempAngle);
                        mat[1][2] = (double)-Math.Sin(tempAngle);
                        mat[1][3] = 0;//end second row
                        mat[2][0] = 0;
                        mat[2][1] = (double)Math.Sin(tempAngle);
                        mat[2][2] = (double)Math.Cos(tempAngle);
                        mat[2][3] = 0;//end third row
                        mat[3][0] = 0;
                        mat[3][1] = 0;
                        mat[3][2] = 0;
                        mat[3][3] = 1;
                        break;
                    }
                case 'Y':
                    {
                        mat = new double[4][];
                        for (int moo = 0; moo < 4; moo++)
                        {
                            mat[moo] = new double[4];
                        }
                        mat[0][0] = (double)Math.Cos(tempAngle);
                        mat[0][1] = 0;
                        mat[0][2] = (double)Math.Sin(tempAngle);
                        mat[0][3] = 0;//end first row
                        mat[1][0] = 0;
                        mat[1][1] = 1;
                        mat[1][2] = 0;
                        mat[1][3] = 0;//end second row
                        mat[2][0] = (double)-Math.Sin(tempAngle);
                        mat[2][1] = 0;
                        mat[2][2] = (double)Math.Cos(tempAngle);
                        mat[2][3] = 0;//end third row
                        mat[3][0] = 0;
                        mat[3][1] = 0;
                        mat[3][2] = 0;
                        mat[3][3] = 1;
                        break;
                    }
                case 'Z':
                    {
                        mat = new double[4][];
                        for (int moo = 0; moo < 4; moo++)
                        {
                            mat[moo] = new double[4];
                        }
                        mat[0][0] = (double)Math.Cos(tempAngle);
                        mat[0][1] = (double)-Math.Sin(tempAngle);
                        mat[0][2] = 0;
                        mat[0][3] = 0;//end first row
                        mat[1][0] = (double)Math.Sin(tempAngle);
                        mat[1][1] = (double)Math.Cos(tempAngle);
                        mat[1][2] = 0;
                        mat[1][3] = 0;//end second row
                        mat[2][0] = 0;
                        mat[2][1] = 0;
                        mat[2][2] = 1;
                        mat[2][3] = 0;//end third row
                        mat[3][0] = 0;
                        mat[3][1] = 0;
                        mat[3][2] = 0;
                        mat[3][3] = 1;
                        break;
                    }
            }
        }

        /// <summary>
        /// Create a 4x4 rotation matrix, from rotating about an arbitrary 3d space vector
        /// </summary>
        /// <param name="angle">the amount of rotation, in radians, about the vector</param>
        /// <param name="b">the vector the being rotated about</param>
        public Matrix(double angle, Vector b)
        {
            mat = new double[4][];
            Vector unitB = b.unit();            //formulas are a lot simpler with a unit vector
            for (int moo = 0; moo < 4; moo++)
            {
                mat[moo] = new double[4];
            }
            mat[0][0] = Math.Pow(unitB.get(0), 2) + Math.Cos(angle) * (1 - Math.Pow(unitB.get(0), 2));
            mat[0][1] = unitB.get(0) * unitB.get(1) * (1 - Math.Cos(angle)) - unitB.get(2) * Math.Sin(angle);
            mat[0][2] = unitB.get(0) * unitB.get(2) * (1 - Math.Cos(angle)) + unitB.get(1) * Math.Sin(angle);
            mat[0][3] = 0;//end first row
            mat[1][0] = unitB.get(0) * unitB.get(1) * (1 - Math.Cos(angle)) + unitB.get(2) * Math.Sin(angle);
            mat[1][1] = Math.Pow(unitB.get(1), 2) + Math.Cos(angle) * (1 - Math.Pow(unitB.get(1), 2));
            mat[1][2] = unitB.get(1) * unitB.get(2) * (1 - Math.Cos(angle)) - unitB.get(0) * Math.Sin(angle);
            mat[1][3] = 0;//end second row
            mat[2][0] = unitB.get(0) * unitB.get(2) * (1 - Math.Cos(angle)) - unitB.get(1) * Math.Sin(angle); ;
            mat[2][1] = unitB.get(1) * unitB.get(2) * (1 - Math.Cos(angle)) + unitB.get(0) * Math.Sin(angle); ;
            mat[2][2] = Math.Pow(unitB.get(2), 2) + Math.Cos(angle) * (1 - Math.Pow(unitB.get(2), 2));
            mat[2][3] = 0;//end third row
            mat[3][0] = 0;
            mat[3][1] = 0;
            mat[3][2] = 0;
            mat[3][3] = 1;
        }

        /// <summary>
        /// Creates a copy of another matrix
        /// </summary>
        /// <param name="a">the matrix being copied</param>
        public Matrix(Matrix a)
        {
            mat = new double[a.mat.Length][];
            for (int i = 0; i < a.mat.Length; i++)
            {
                mat[i] = new double[a.mat[0].Length];
            }
            for (int i = 0; i < a.mat.Length; i++)
            {
                for (int j = 0; j < a.mat[0].Length; j++)
                {
                    this.mat[i][j] = a.mat[i][j];
                }
            }
        }

        /// <summary>
        /// Creates a matrix from a series of column vectors. 
        /// </summary>
        /// <param name="vs">Each vector is a column of the matrix. The first vector is the first column.
        /// The second vector is the second column, so on and so forth.</param>
        public Matrix(params Vector[] vs)
        {
            mat = new double[vs[0].size()][];
            for (int i = 0; i < vs[0].size(); i++)
            {
                mat[i] = new double[vs.Length];
            }
            int k = 0;
            foreach (Vector v in vs)
            {
                for (int j = 0; j < vs[0].size(); j++)
                {
                    mat[j][k] = v.get(j);
                }
                k++;
            }
        }

        #endregion

        /// <summary>
        /// Checks if this matrix is equal (within a margin) to another matrix
        /// </summary>
        /// <param name="otherMatrix">the matrix this matrix is being compared to</param>
        /// <param name="allowableDelta">the percentage margin that these matrices can be different</param>
        /// <returns>True if these matrices are equal
        /// False if these matrices are different</returns>
        public bool Equals(Matrix otherMatrix, double allowableDelta)
        {
            if (this.mat.Length == otherMatrix.mat.Length && this.mat[0].Length == otherMatrix.mat[0].Length)
            {
                for (int i = 0; i < this.mat.Length; i++)
                {
                    for (int j = 0; j < this.mat[0].Length; j++)
                    {
                        double ratio = this.get(i, j) / otherMatrix.get(i, j);
                        if (isZero(this.get(i, j)) && isZero(otherMatrix.get(i, j)))
                        { 
                        
                        }
                        else if (ratio >= 1.0 - Math.Abs(allowableDelta) && ratio <= 1.0 + Math.Abs(allowableDelta))
                        {

                        }
                        else
                        {
                            return false;
                        }
                    }
                }
                return true;
            }
            else
            {
                return false;
            }
        }

        public Matrix getRotations()
        {
            if (this.mat.Length == 4 && this.mat[0].Length == 4)
            {
                Matrix ret = new Matrix(3, 3);
                ret.set(0, 0, this.get(0, 0));
                ret.set(0, 1, this.get(0, 1));
                ret.set(0, 2, this.get(0, 2));
                ret.set(1, 0, this.get(1, 0));
                ret.set(1, 1, this.get(1, 1));
                ret.set(1, 2, this.get(1, 2));
                ret.set(2, 0, this.get(2, 0));
                ret.set(2, 1, this.get(2, 1));
                ret.set(2, 2, this.get(2, 2));
                return ret;
            }
            else
            {
                return null;
            }
        }

        private static bool isZero(double number)
        {
            return (number < SMALLEST_NONZERO_NUMBER && number > -1 * SMALLEST_NONZERO_NUMBER);
        }

        public static bool isCloseToEqual(double number, double numberBeingComparedTo)
        {
            return (number < (numberBeingComparedTo + SMALLEST_NONZERO_NUMBER) && number > (numberBeingComparedTo - SMALLEST_NONZERO_NUMBER));
        }

        /// <summary>
        /// Creates a matrix from a series of column vectors.
        /// </summary>
        /// <param name="vs">Each vector is a column of the matrix. The first vector is the first column.
        /// The second vector is the second column, so on and so forth.</param>
        /// <returns>A matrix where each column is one of the vectors from the argument</returns>
        public static Matrix createMatrixFromColumnVectors(Vector[] vs)
        {
            Matrix ret = new Matrix(vs[0].size(), vs.Length);
            int k = 0;
            foreach (Vector v in vs)
            {
                for (int j = 0; j < vs[0].size(); j++)
                {
                    ret.mat[j][k] = v.get(j);
                }
                k++;
            }
            return ret;
        }

        /// <summary>
        /// Creates a new matrix which is a subset of this matrix.
        /// </summary>
        /// <param name="startingRow">the number of the first row of the new matrix</param>
        /// <param name="startingCol">the number of the first column of the new matrix</param>
        /// <returns>A matrix that is a portion of this matrix</returns>
        public Matrix subsetMatrix(int startingRow, int startingCol)
        {
            Matrix ret = new Matrix(this.mat.Length - startingRow, this.mat[0].Length - startingCol);
            for (int i = startingRow; i < this.mat.Length; i++)
            {
                for (int j = startingCol; j < this.mat[0].Length; j++)
                {
                    ret.mat[i - startingRow][j - startingCol] = this.mat[i][j];
                }
            }
            return ret;
        }

        /// <summary>
        /// returns the number of rows and columns for this matrix
        /// </summary>
        /// <returns>an array where [0] is the number of rows and [1] is the number of columns for this matrix</returns>
        public int[] size()
        {
            int[] ret = new int[2];
            ret[0] = mat.Length;
            ret[1] = mat[0].Length;
            return ret;
        }

        /// <summary>
        /// Returns a single element of this matrix.
        /// </summary>
        /// <param name="row">the zero-based row you want an element from. (for the first row use 0)</param>
        /// <param name="col">the zero-based column you want an element from. (for the first column use 0)</param>
        /// <returns>the element at the row and column specified</returns>
        public double get(int row, int col)
        {
            return this.mat[row][col];
        }

        /// <summary>
        /// Sets the value for a single element in this matrix
        /// </summary>
        /// <param name="row">the zero-based row you want to change. (for the first row use 0)</param>
        /// <param name="col">the zero-based column you want to change. (for the first column use 0)</param>
        /// <param name="entry">the new value for the matrix element</param>
        public void set(int row, int col, double entry)
        {
            this.mat[row][col] = entry;
        }

        /// <summary>
        /// Set all of the elements of a 4x4 matrix
        /// </summary>
        /// <param name="a">row 1 column 1</param>
        /// <param name="b">row 1 column 2</param>
        /// <param name="c">row 1 column 3</param>
        /// <param name="d">row 1 column 4</param>
        /// <param name="e">row 2 column 1</param>
        /// <param name="f">row 2 column 2</param>
        /// <param name="g">row 2 column 3</param>
        /// <param name="h">row 2 column 4</param>
        /// <param name="i">row 3 column 1</param>
        /// <param name="j">row 3 column 2</param>
        /// <param name="k">row 3 column 3</param>
        /// <param name="l">row 3 column 4</param>
        /// <param name="m">row 4 column 1</param>
        /// <param name="n">row 4 column 2</param>
        /// <param name="o">row 4 column 3</param>
        /// <param name="p">row 4 column 4</param>
        public void setAll(double a, double b, double c, double d, double e, double f, double g, double h, double i, double j, double k, double l, double m, double n, double o, double p)
        {
            if (mat.Length == 4 && mat[0].Length == 4)
            {
                mat[0][0] = a;
                mat[0][1] = b;
                mat[0][2] = c;
                mat[0][3] = d;
                mat[1][0] = e;
                mat[1][1] = f;
                mat[1][2] = g;
                mat[1][3] = h;
                mat[2][0] = i;
                mat[2][1] = j;
                mat[2][2] = k;
                mat[2][3] = l;
                mat[3][0] = m;
                mat[3][1] = n;
                mat[3][2] = o;
                mat[3][3] = p;
            }
        }

        /// <summary>
        /// Creates a new matrix by subtracting all of the values, element by element, of a matrix from this matrix
        /// </summary>
        /// <param name="a">the subtractee matrix</param>
        /// <returns>a new matrix that is the difference between this matrix and the argument</returns>
        public Matrix subtract(Matrix a)
        {
            Matrix ret;
            if (this.mat.Length == a.mat.Length && this.mat[0].Length == a.mat[0].Length)
            {
                ret = new Matrix(this.mat.Length, this.mat[0].Length);
                for (int i = 0; i < this.mat.Length; i++)
                {
                    for (int j = 0; j < this.mat[0].Length; j++)
                    {
                        ret.mat[i][j] = this.mat[i][j] - a.mat[i][j];
                    }
                }
                return ret;
            }
            return null;
        }

        /// <summary>
        /// Creates a new matrix by adding all of the values, element by element, of a matrix to this matrix
        /// </summary>
        /// <param name="a">the other matrix</param>
        /// <returns>a new matrix where each element is the result of adding the the matrices together element by element</returns>
        public Matrix add(Matrix a)
        {
            Matrix ret;
            if (this.mat.Length == a.mat.Length && this.mat[0].Length == a.mat[0].Length)
            {
                ret = new Matrix(this.mat.Length, this.mat[0].Length);
                for (int i = 0; i < this.mat.Length; i++)
                {
                    for (int j = 0; j < this.mat[0].Length; j++)
                    {
                        ret.mat[i][j] = this.mat[i][j] + a.mat[i][j];
                    }
                }
                return ret;
            }
            return null;
        }

        /// <summary>
        /// Multiplies this matrix by another matrix. (This*A)
        /// </summary>
        /// <param name="a">the matrix this matrix is being multiplied by</param>
        /// <returns>the matrix that is created when this matrix is multiplied by the argument matrix</returns>
        public Matrix multiply(Matrix a)
        {
            if (this.mat[0].Length != a.mat.Length)
            {
                return null;
            }
            Matrix ret = new Matrix(this.mat.Length, a.mat[0].Length);
            double temp = 0;
            for (int i = 0; i < this.mat.Length; i++)
            {
                for (int j = 0; j < a.mat[0].Length; j++)
                {
                    ret.mat[i][j] = 0;
                    for (int k = 0; k < this.mat[0].Length; k++)
                    {
                        temp = (this.mat[i][k] * a.mat[k][j]);
                        ret.mat[i][j] += temp;
                    }
                }
            }
            return ret;
        }

        /// <summary>
        /// Dot multplies this matrix by a vector
        /// </summary>
        /// <param name="a">the vector this matrix is being multiplied by</param>
        /// <returns>a vector that is the dot product of this matrix and the argument</returns>
        public Vector multiply(Vector a)
        {
            if (this.mat[0].Length != a.size())
            {
                return null;
            }
            Vector ret = new Vector(this.mat.Length);
            for (int i = 0; i < this.mat.Length; i++)
            {
                double temp = 0;
                for (int j = 0; j < this.mat[0].Length; j++)
                {
                    temp += this.mat[i][j] * a.get(j);
                }
                ret.set(i, temp);
            }
            return ret;
        }

        /// <summary>
        /// Dot multplies this matrix by a vector
        /// </summary>
        /// <param name="a">the vector this matrix is being multiplied by</param>
        /// <returns>a vector that is the dot product of this matrix and the argument</returns>
        public Vectorf multiply(Vectorf a)
        {
            if (this.mat[0].Length != a.size())
            {
                return null;
            }
            Vectorf ret = new Vectorf(this.mat.Length);
            for (int i = 0; i < this.mat.Length; i++)
            {
                float temp = 0;
                for (int j = 0; j < this.mat[0].Length; j++)
                {
                    temp += (float)(this.mat[i][j] * a.get(j));
                }
                ret.set(i, temp);
            }
            return ret;
        }

        /// <summary>
        /// Scalar multiplies this matrix by a number
        /// </summary>
        /// <param name="a">the number that each element in the matrix will be multiplied by</param>
        /// <returns>a new matrix where the entire matrix has its elements scaled by the argument</returns>
        public Matrix multiply(double a)
        {
            Matrix ret = new Matrix(this.mat.Length, this.mat[0].Length);
            for (int i = 0; i < this.mat.Length; i++)
            {
                for (int j = 0; j < this.mat[0].Length; j++)
                {
                    ret.mat[i][j] = this.mat[i][j] * a;
                }
            }
            return ret;
        }

        /// <summary>
        /// Creates the transpose matrix of this matrix
        /// </summary>
        /// <returns>a new matrix that is the transpose of this matrix</returns>
        public Matrix transpose()
        {
            Matrix ret = new Matrix(this.mat[0].Length, this.mat.Length);
            for (int i = 0; i < this.mat[0].Length; i++)
            {
                for (int j = 0; j < this.mat.Length; j++)
                {
                    ret.mat[i][j] = this.mat[j][i];
                }
            }
            return ret;
        }

        /// <summary>
        /// Finds the determinant for this matrix
        /// </summary>
        /// <returns>the determinant for this matrix</returns>
        public double determinant()
        {
            int[] thisSize = this.size();
            if (thisSize[0] == 2 && thisSize[1] == 2)
            {
                return this.mat[0][0] * this.mat[1][1] - this.mat[0][1] * this.mat[1][0];
            }
            else
            {
                double temp = 0;
                for (int i = 0; i < thisSize[1]; i++)
                {
                    if (i % 2 == 0)
                    {
                        temp += this.mat[0][i] * this.minor(0, i).determinant();
                    }
                    else
                    {
                        temp -= this.mat[0][i] * this.minor(0, i).determinant();
                    }
                }
                return temp;
            }
        }

        /// <summary>
        /// Creates the minor matrix for a specified element in the matrix
        /// </summary>
        /// <param name="row">the row of the element that we are make a minor matrix</param>
        /// <param name="column">the column of the element that we are make a minor matrix</param>
        /// <returns>a matrix which is this matrix without any of elements of the row and column passed in as arguments</returns>
        public Matrix minor(int row, int column)
        {
            int rowPosition = 0;
            int colPosition = 0;
            Matrix ret = new Matrix(mat.Length - 1, mat[0].Length - 1);
            for (int i = 0; i < mat.Length; i++)
            {
                if (i != row)
                {
                    for (int j = 0; j < mat[0].Length; j++)
                    {
                        if (j != column)
                        {
                            ret.mat[rowPosition][colPosition] = this.mat[i][j];
                            colPosition++;
                        }
                    }
                    colPosition = 0;
                    rowPosition++;
                }
            }
            return ret;
        }

        /// <summary>
        /// Finds the cofactor (the determinant of a minor) for a specified element in this matrix
        /// </summary>
        /// <param name="row">the row of the element that we are make a minor matrix</param>
        /// <param name="col">the column of the element that we are make a minor matrix</param>
        /// <returns>The cofactor for a specified element in the matrix</returns>
        public double cofactor(int row, int col)
        {
            Matrix minor = this.minor(row, col);
            double ret = minor.determinant();
            if ((row + col) % 2 == 0)
            {
                return ret;
            }
            else
            {
                return (ret * -1.0);
            }
        }

        /// <summary>
        /// Prints all of the elements onto console
        /// </summary>
        /// <returns>A string that contains everthing that was printed to the console</returns>
        public string print()
        {
            string ret = "";
            for (int i = 0; i < this.mat.Length; i++)
            {
                for (int j = 0; j < this.mat[0].Length; j++)
                {
                    double roundedNumber = mat[i][j];
                    if (isZero(roundedNumber))
                    {
                        roundedNumber = 0;
                    }
                    Console.Write("{0:G15}    ", roundedNumber);
                    ret += String.Format("{0:F17}\t", roundedNumber);
                    if (j == this.mat[0].Length - 1)
                    {
                        ret += "\r\n";
                        Console.WriteLine(" ");
                    }
                }
            }
            return ret;
        }

        /// <summary>
        /// Assumes the transformation matrix was multiplied in the Z-Y-X order and will parse it out as such
        /// </summary>
        /// <returns>An array that stores the rotations that were parsed from the transformation matrix [0] holds the X rotation, [1] holds the Y rotation, [2] holds the Z rotation, all angles are in degrees</returns>
        public double[] parseZYXRotations()
        {
            double[] ret = new double[3];
            if ((this.mat.Length == 3 && this.mat[0].Length == 3) || (this.mat.Length == 4 && this.mat[0].Length == 4))
            {
                double xAngleInRadians = Math.Atan(this.mat[2][1] / this.mat[2][2]);        //find x angle
                if (this.mat[2][1] >= 0 && this.mat[2][2] < 0)
                {                                       //math fuction only returns values from -PI/2 to PI/2 
                    xAngleInRadians += Math.PI;         //larger angles must be accounted for manually
                }
                else if (this.mat[2][1] < 0 && this.mat[2][2] < 0)
                {
                    xAngleInRadians -= Math.PI;
                }
                ret[0] = xAngleInRadians * (180.0 / Math.PI);           //store in degrees not radians
                double zAngleInRadians = Math.Atan(this.mat[1][0] / this.mat[0][0]);        //find z angle
                if (this.mat[1][0] >= 0 && this.mat[0][0] < 0)
                {                                       //math function only returns values from -PI/2 to PI/2 
                    zAngleInRadians += Math.PI;         //larger angles must be accounted for manually
                }
                else if (this.mat[1][0] < 0 && this.mat[0][0] < 0)
                {
                    zAngleInRadians -= Math.PI;
                }
                ret[2] = (zAngleInRadians) * (180.0 / Math.PI);         //store in degrees not radians
                double yAngleInRadians, cosOfY;
                if (isZero(Math.Sin(xAngleInRadians)))
                {                                       //find y angle, must watch out for a divide by zero
                    cosOfY = this.mat[2][2] / Math.Cos(xAngleInRadians);
                }
                else
                {
                    cosOfY = this.mat[2][1] / Math.Sin(xAngleInRadians);
                }
                yAngleInRadians = Math.Atan(-1.0 * this.mat[2][0] / cosOfY);
                if (this.mat[2][0] <= 0 && cosOfY < 0)
                {                                       //math function only returns values from -PI/2 to PI/2 
                    yAngleInRadians += Math.PI;         //larger angles must be accounted for manually
                }
                else if (this.mat[2][0] > 0 && cosOfY < 0)
                {
                    yAngleInRadians -= Math.PI;
                }
                ret[1] = yAngleInRadians * (180.0 / Math.PI);           //store in degrees not radians
            }
            return ret;
        }

        /// <summary>
        /// Finds the point of this coordinate system that is in the same 3d space as a point in another coorinate system.
        /// </summary>
        /// <param name="otherCooridinateSystem">The other coordinate system</param>
        /// <param name="pointToFindInOtherCoordSystem">the point in the other coorinate system that we want to find the coorinates to in this coordinate system</param>
        /// <returns>the point in this coordinate system that is in the same location as the point in the other coordinate system, if anything is wrong returns 4x4 identity matrix</returns>
        public Matrix findPointOfCorrespondingCoordinateSystem(Matrix otherCooridinateSystem, Matrix pointToFindInOtherCoordSystem)
        {
            if (this.size()[0] == 4 && this.size()[1] == 4 && otherCooridinateSystem.size()[0] == 4 && otherCooridinateSystem.size()[1] == 4 && pointToFindInOtherCoordSystem.size()[0] == 4 && pointToFindInOtherCoordSystem.size()[1] == 4)
            {
                return this.inverse().multiply(otherCooridinateSystem.multiply(pointToFindInOtherCoordSystem));
            }
            else
            {
                return new Matrix();
            }
        }

        /// <summary>
        /// Attempts to create a coordinate system that would place the original points into their adjusted positions
        /// </summary>
        /// <param name="points">An array of paired points. The first point in a pair is the original point, the second point of the pair the adjusted point.</param>
        /// <returns>A coordinate system that places the original points into their adjusted positions</returns>
        public Matrix findAdjustedCoordinateSystemForAdjustedPoints(Tuple<Matrix, Matrix>[] points)
        {
            Matrix[] adjustedFrames = new Matrix[points.Length];
            Vector[] pointShifts = new Vector[points.Length];           //holds what difference between an original point and its touched point
            //double temp = 0;
            for (int i = 0; i < points.Length; i++)
            {
                adjustedFrames[i] = this.multiply(points[i].Item2).multiply(points[i].Item1.inverse());
                pointShifts[i] = findVectorBetweenTwoFrames(points[i].Item1, points[i].Item2);
                //temp = findDistanceBetweenTwoPoints(points[i].Item1, points[i].Item2);
            }
            List<int>[] closeToLists = new List<int>[points.Length];            //an array that holds for each vector (the vector of difference between a point and its touched-up point) the numbers of the other vectors that are similar
            for (int i = 0; i < pointShifts.Length; i++)
            {
                closeToLists[i] = new List<int>();      //build a seperate list of similar vectors for each vector
                for (int j = 0; j < pointShifts.Length; j++)
                {
                    if (i != j)             //don't compare a vector to itself
                    {
                        if (pointShifts[i].findCosineSimilarity(pointShifts[j]) > 0.5)
                        {
                            closeToLists[i].Add(j);         //the ith vector and the jth vector are similar, so add the jth vector to the i's list of close vectors
                        }
                    }
                }
            }
            int largestNumberOfSimilarVectors = 0, indexOfListWithMostSimilarVectors = -1;
            for (int i = 0; i < closeToLists.Length; i++)                   //find the list with the most similar vectors
            {
                if (closeToLists[i].Count > largestNumberOfSimilarVectors)
                {
                    largestNumberOfSimilarVectors = closeToLists[i].Count;
                    indexOfListWithMostSimilarVectors = i;
                }
            }
            Matrix[] adjustedFramesOfSimilarVectors = new Matrix[closeToLists[indexOfListWithMostSimilarVectors].Count + 1];
            adjustedFramesOfSimilarVectors[0] = adjustedFrames[indexOfListWithMostSimilarVectors];      //build the array of potential new user frames using only the frames that had similar vectors
            for (int i = 0; i < adjustedFramesOfSimilarVectors.Length - 1; i++)
            {
                adjustedFramesOfSimilarVectors[i + 1] = adjustedFrames[closeToLists[indexOfListWithMostSimilarVectors].ElementAt(i)];
            }
            return averageOfTransforms(adjustedFramesOfSimilarVectors);
        }

        /// <summary>
        /// Finds the vector holding the x,y,z translation to move from the starting frame to the end frame
        /// </summary>
        /// <param name="startingFrame">the frame you are moveing from</param>
        /// <param name="finishingFrame">the frame we are going to</param>
        /// <returns>a 3x1 vector that has the x, y, and z values to go from the starting frame to the finishing frame</returns>
        private static Vector findVectorBetweenTwoFrames(Matrix startingFrame, Matrix finishingFrame)
        {
            Matrix diff = startingFrame.inverse().multiply(finishingFrame);
            return diff.turnPointMatrixInto3x1Vector();
        }

        private static double findDistanceBetweenTwoPoints(Matrix start, Matrix end)
        {
            Matrix diff = start.inverse().multiply(end);
            double ret = Math.Pow(diff.get(0, 3), 2) + Math.Pow(diff.get(1, 3), 2) + Math.Pow(diff.get(2, 3), 2);
            return Math.Sqrt(ret);
        }

        /// <summary>
        /// Takes a 4x4 matrix that represents a point, and strips out the translations of the matrix and puts them into a 3x1 vector
        /// </summary>
        /// <returns>A 3x1 vector that has the translations of the matrix this was called on</returns>
        public Vector turnPointMatrixInto3x1Vector()
        {
            int[] size = this.size();
            if (size[0] == 4 && size[1] == 4)
            {
                Vector ret = new Vector(3);
                ret.set(0, this.mat[0][3]);
                ret.set(1, this.mat[1][3]);
                ret.set(2, this.mat[2][3]);
                return ret;
            }
            return null;
        }

        /// <summary>
        /// Assumes the transformation matrix was multiplied in the X-Y-Z order and will parse it out as such
        /// </summary>
        /// <returns>An array that stores the rotations that were parsed from the transformation matrix [0] holds the X rotation, [1] holds the Y rotation, [2] holds the Z rotation, all angles are in degrees</returns>
        public double[] parseXYZRotations()
        {
            double[] ret = new double[3];
            if ((this.mat.Length == 3 && this.mat[0].Length == 3) || (this.mat.Length == 4 && this.mat[0].Length == 4))
            {
                double xAngleInRadians = Math.Atan(-1 * this.mat[1][2] / this.mat[2][2]);       //find x angle
                if (-1.0 * this.mat[1][2] >= 0 && this.mat[2][2] < 0)
                {                                                   //math fuction only returns values from -PI/2 to PI/2 
                    xAngleInRadians += Math.PI;                     //larger angles must be accounted for manually
                }
                else if (-1.0 * this.mat[1][2] < 0 && this.mat[2][2] < 0)
                {
                    xAngleInRadians -= Math.PI;
                }
                ret[0] = xAngleInRadians * (180.0 / Math.PI);       //store answer in degrees not radians
                double zAngleInRadians = Math.Atan(-1 * this.mat[0][1] / this.mat[0][0]);       //find z angle
                if (-1.0 * this.mat[0][1] >= 0 && this.mat[0][0] < 0)
                {                                                   //math fuction only returns values from -PI/2 to PI/2 
                    zAngleInRadians += Math.PI;                     //larger angles must be accounted for manually
                }
                else if (-1.0 * this.mat[0][1] < 0 && this.mat[0][0] < 0)
                {
                    zAngleInRadians -= Math.PI;
                }
                ret[2] = (zAngleInRadians) * (180.0 / Math.PI);     //store answer in degrees not radians
                double yAngleInRadians, cosOfY;
                if (isZero(Math.Sin(xAngleInRadians)))
                {                                   //find y angle, must watch out for divide by zero
                    cosOfY = this.mat[2][2] / Math.Cos(xAngleInRadians);
                    yAngleInRadians = Math.Atan(this.mat[0][2] / cosOfY);
                }
                else
                {
                    cosOfY = this.mat[1][2] / (-1.0 * Math.Sin(xAngleInRadians));
                    yAngleInRadians = Math.Atan(this.mat[0][2] / cosOfY);
                }
                if (this.mat[0][2] >= 0 && cosOfY < 0)
                {                                                   //math fuction only returns values from -PI/2 to PI/2 
                    yAngleInRadians += Math.PI;                     //larger angles must be accounted for manually
                }
                else if (this.mat[0][2] < 0 && cosOfY < 0)
                {
                    yAngleInRadians -= Math.PI;
                }
                ret[1] = yAngleInRadians * (180.0 / Math.PI);       //store answer in degrees not radians
            }
            return ret;
        }


        public static Matrix[] coordSolve(Vector a1, Vector a2, Vector b1, Vector b2, Vector c1, Vector c2, Vector d1, Vector d2)
        {
            Matrix[] ret = new Matrix[2];
            Matrix Q = new Matrix(3, 3);
            Matrix P = new Matrix(3, 3);
            P.set(0, 0, b1.get(0) - a1.get(0));
            P.set(0, 1, b1.get(1) - a1.get(1));
            P.set(0, 2, b1.get(2) - a1.get(2));
            P.set(1, 0, c1.get(0) - a1.get(0));
            P.set(1, 1, c1.get(1) - a1.get(1));
            P.set(1, 2, c1.get(2) - a1.get(2));
            P.set(2, 0, d1.get(0) - a1.get(0));
            P.set(2, 1, d1.get(1) - a1.get(1));
            P.set(2, 2, d1.get(2) - a1.get(2));
            Q.set(0, 0, b2.get(0) - a2.get(0));
            Q.set(0, 1, b2.get(1) - a2.get(1));
            Q.set(0, 2, b2.get(2) - a2.get(2));
            Q.set(1, 0, c2.get(0) - a2.get(0));
            Q.set(1, 1, c2.get(1) - a2.get(1));
            Q.set(1, 2, c2.get(2) - a2.get(2));
            Q.set(2, 0, d2.get(0) - a2.get(0));
            Q.set(2, 1, d2.get(1) - a2.get(1));
            Q.set(2, 2, d2.get(2) - a2.get(2));
            Matrix M = P.inverse().multiply(Q);
            ret[0] = M;
            Matrix FaroPoint1 = new Matrix(1, 3);
            FaroPoint1.set(0, 0, a1.get(0));
            FaroPoint1.set(0, 1, a1.get(1));
            FaroPoint1.set(0, 2, a1.get(2));
            Matrix RobotPoint1 = new Matrix(1, 3);
            RobotPoint1.set(0, 0, a2.get(0));
            RobotPoint1.set(0, 1, a2.get(1));
            RobotPoint1.set(0, 2, a2.get(2));
            Matrix offset = RobotPoint1.subtract(FaroPoint1.multiply(M));
            ret[1] = offset;
            return ret;
        }
        
        ///<summary>
        ///Based on the Orientation of the vector the return array will hold angles for rotations about axis in different order ----------------------------
        ///if principle axis of vector is x the return array will contain angles for the Z rotation then the Y rotation --------------------------------
        ///if principle axis of vector is y the return array will contain angles for the Z rotation then the X rotation --------------------------------
        ///if principle axis of vector is z the return array will contain angles for the X rotation then the Y rotation---------------------------------
        ///</summary>
        public double[] findAnglesToZeroVector(char orientation)
        {
            if (this.mat.Length != 4 && this.mat[0].Length != 1)
            {
                return null;
            }
            char letter;
            double[] ret = new double[2];
            Matrix tempMatrix = new Matrix(this);
            switch (orientation)
            {
                case 'x':
                    {
                        letter = 'X';
                        break;
                    }
                case 'y':
                    {
                        letter = 'Y';
                        break;
                    }
                case 'z':
                    {
                        letter = 'Z';
                        break;
                    }
                default:
                    {
                        letter = orientation;
                        break;
                    }
            }
            switch (letter)
            {
                case 'X':
                    {
                        double numer = (double)(tempMatrix.get(1, 0));
                        double denom = (double)(tempMatrix.get(0, 0));
                        ret[0] = (double)Math.Atan(numer / denom);
                        Matrix rotZ = new Matrix(Math.Atan(numer / denom), 'z');
                        tempMatrix = rotZ.multiply(tempMatrix);
                        numer = (double)(tempMatrix.get(2, 0));
                        denom = (double)(tempMatrix.get(0, 0));
                        ret[1] = (double)Math.Atan(numer / denom);
                        break;
                    }
                case 'Y':
                    {
                        double numer = (double)(tempMatrix.get(0, 0));
                        double denom = (double)(tempMatrix.get(1, 0));
                        ret[0] = (double)Math.Atan(numer / denom);
                        Matrix rotZ = new Matrix(Math.Atan(numer / denom), 'z');
                        tempMatrix = rotZ.multiply(tempMatrix);
                        numer = (double)(tempMatrix.get(2, 0));
                        denom = (double)(tempMatrix.get(1, 0));
                        ret[1] = (double)-Math.Atan(numer / denom);
                        break;
                    }
                case 'Z':
                    {
                        double numer = (double)(tempMatrix.get(0, 0));
                        double denom = (double)(tempMatrix.get(2, 0));
                        ret[0] = (double)-Math.Atan(numer / denom);
                        Matrix rotX = new Matrix(Math.Atan(numer / denom), 'y');
                        tempMatrix = rotX.multiply(tempMatrix);
                        numer = (double)(tempMatrix.get(1, 0));
                        denom = (double)(tempMatrix.get(2, 0));
                        ret[1] = (double)-Math.Atan(numer / denom);
                        break;
                    }
            }
            return ret;
        }

        ///<summary>
        ///Returns an array for the similair transformation matrices in this order. The array contents are in this order Scaling, then Rotation
        ///</summary>
        public Matrix[] similarTransforms(Matrix a)
        {
            Matrix[] ret = new Matrix[2];
            if (this.mat.Length == 4 && a.mat.Length == 4 || this.mat[0].Length == 1 && this.mat[0].Length == 1)
            {
                double thisSize = Math.Sqrt(Math.Pow(this.get(0, 0), 2) + Math.Pow(this.get(1, 0), 2) + Math.Pow(this.get(2, 0), 2));
                double aSize = Math.Sqrt(Math.Pow(a.get(0, 0), 2) + Math.Pow(a.get(1, 0), 2) + Math.Pow(a.get(2, 0), 2));
                ret[0] = new Matrix(aSize / thisSize, 0, 0, 0
                                    , 0, aSize / thisSize, 0, 0
                                    , 0, 0, aSize / thisSize, 0
                                    , 0, 0, 0, 1);
                Matrix temp = ret[0].multiply(this);
                Vector though = new Vector(temp);
                Vector that = new Vector(a);
                Vector axis = though.crossProduct(that);
                axis = axis.unit();
                double dot = (though.dotProduct(that));
                double angle = Math.Acos(dot / (though.magnitude() * that.magnitude()));
                ret[1] = new Matrix(-angle, axis.unit());
                return ret;
            }
            else if (this.mat.Length == 4 && a.mat.Length == 4 || this.mat[0].Length == 4 && this.mat[0].Length == 4)
            {
                double thisSize = Math.Sqrt(Math.Pow(this.get(0, 0), 2) + Math.Pow(this.get(1, 0), 2) + Math.Pow(this.get(2, 0), 2));
                double aSize = Math.Sqrt(Math.Pow(a.get(0, 0), 2) + Math.Pow(a.get(1, 0), 2) + Math.Pow(a.get(2, 0), 2));
                ret[0] = new Matrix(aSize / thisSize, 0, 0, 0
                                    , 0, aSize / thisSize, 0, 0
                                    , 0, 0, aSize / thisSize, 0
                                    , 0, 0, 0, 1);
                Matrix temp = ret[0].multiply(this);
                Vector though = new Vector(this);
                Vector that = new Vector(a);
                Vector axis = though.crossProduct(that);
                double angle = Math.Acos(though.dotProduct(that) / (though.magnitude() * that.magnitude()));
                ret[1] = new Matrix(-angle, axis.unit());
                return ret;
            }
            else
            {
                return ret;
            }
        }

        /// <summary>
        /// Creates the transpose of this matrix.
        /// Works for 2x2, 3x3, and nxn matrices. Note: Anything larger than 3 is done by Kramer's Rule. For large n this will run extremely poorly.
        /// </summary>
        /// <returns>The inverse of this matrix. I.E. the matrix that when multiplied with this matrix produces the identity matrix</returns>
        public Matrix inverse()
        {
            double det = this.determinant();
            if (det != 0)
            {
                if (this.mat.Length == 3 && this.mat[0].Length == 3)
                {
                    Matrix tran = this.transpose();
                    Matrix adj = new Matrix(3, 3);
                    adj.set(0, 0, tran.get(1, 1) * tran.get(2, 2) - tran.get(1, 2) * tran.get(2, 1));
                    adj.set(0, 1, -(tran.get(1, 0) * tran.get(2, 2) - tran.get(1, 2) * tran.get(2, 0)));
                    adj.set(0, 2, tran.get(1, 0) * tran.get(2, 1) - tran.get(1, 1) * tran.get(2, 0));
                    adj.set(1, 0, -(tran.get(0, 1) * tran.get(2, 2) - tran.get(0, 2) * tran.get(2, 1)));
                    adj.set(1, 1, tran.get(0, 0) * tran.get(2, 2) - tran.get(0, 2) * tran.get(2, 0));
                    adj.set(1, 2, -(tran.get(0, 0) * tran.get(2, 1) - tran.get(0, 1) * tran.get(2, 0)));
                    adj.set(2, 0, tran.get(0, 1) * tran.get(1, 2) - tran.get(0, 2) * tran.get(1, 1));
                    adj.set(2, 1, -(tran.get(0, 0) * tran.get(1, 2) - tran.get(0, 2) * tran.get(1, 0)));
                    adj.set(2, 2, tran.get(0, 0) * tran.get(1, 1) - tran.get(0, 1) * tran.get(1, 0));
                    return adj.multiply(1.0 / det);
                }
                else if (this.mat.Length == 2 && this.mat[0].Length == 2)
                {
                    Matrix ret = new Matrix(2, 2);
                    ret.set(0, 0, this.get(1, 1));
                    ret.set(0, 1, -1 * this.get(0, 1));
                    ret.set(1, 0, -1 * this.get(1, 0));
                    ret.set(1, 1, this.get(0, 0));
                    return ret.multiply(1.0 / det);
                }
                else if (this.mat.Length > 0 && this.mat.Length == this.mat[0].Length)
                {
                    Matrix cofactorMatrix = new Matrix();
                    for (int i = 0; i < 4; i++)
                    {
                        for (int j = 0; j < 4; j++)
                        {
                            cofactorMatrix.set(i, j, this.cofactor(j, i));
                        }
                    }
                    return cofactorMatrix.multiply(1.0 / det);
                    //Matrix P = new Matrix(2, 2);
                    //P.set(0, 0, this.get(0, 0));
                    //P.set(0, 1, this.get(0, 1));
                    //P.set(1, 0, this.get(1, 0));
                    //P.set(1, 1, this.get(1, 1));
                    //Matrix Q = new Matrix(2, 2);
                    //Q.set(0, 0, this.get(0, 2));
                    //Q.set(0, 1, this.get(0, 3));
                    //Q.set(1, 0, this.get(1, 2));
                    //Q.set(1, 1, this.get(1, 3));
                    //Matrix R = new Matrix(2, 2);
                    //R.set(0, 0, this.get(2, 0));
                    //R.set(0, 1, this.get(2, 1));
                    //R.set(1, 0, this.get(3, 0));
                    //R.set(1, 1, this.get(3, 1));
                    //Matrix S = new Matrix(2, 2);
                    //S.set(0, 0, this.get(2, 2));
                    //S.set(0, 1, this.get(2, 3));
                    //S.set(1, 0, this.get(3, 2));
                    //S.set(1, 1, this.get(3, 3));
                    //Matrix wierdS = S.subtract(R.multiply(P.inverse().multiply(Q))).inverse();
                    //Matrix wierdR = wierdS.multiply(-1).multiply(R.multiply(P.inverse()));
                    //Matrix wierdQ = P.inverse().multiply(Q).multiply(-1).multiply(wierdS);
                    //Matrix wierdP = P.inverse().subtract(P.inverse().multiply(Q).multiply(wierdR));
                    //Matrix ret = new Matrix(4, 4);
                    //ret.set(0, 0, wierdP.get(0, 0));
                    //ret.set(0, 1, wierdP.get(0, 1));
                    //ret.set(1, 0, wierdP.get(1, 0));
                    //ret.set(1, 1, wierdP.get(1, 1));
                    //ret.set(0, 2, wierdQ.get(0, 0));
                    //ret.set(0, 3, wierdQ.get(0, 1));
                    //ret.set(1, 2, wierdQ.get(1, 0));
                    //ret.set(1, 3, wierdQ.get(1, 1));
                    //ret.set(2, 0, wierdR.get(0, 0));
                    //ret.set(2, 1, wierdR.get(0, 1));
                    //ret.set(3, 0, wierdR.get(1, 0));
                    //ret.set(3, 1, wierdR.get(1, 1));
                    //ret.set(2, 2, wierdS.get(0, 0));
                    //ret.set(2, 3, wierdS.get(0, 1));
                    //ret.set(3, 2, wierdS.get(1, 0));
                    //ret.set(3, 3, wierdS.get(1, 1));
                    //return ret;
                }
                else
                {
                    return null;
                }
            }
            else
                return null;
        }

        /// <summary>
        /// Finds the inverse of this 4x4 transformation matrix
        /// </summary>
        /// <returns>The inverse of this 4x4 transformation matrix</returns>
        public Matrix inverseTransformationMatrix()
        {
            Matrix ret = new Matrix();
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    ret.mat[i][j] = this.mat[j][i];
                }
            }
            ret.mat[0][3] = this.mat[0][3] * -1;
            ret.mat[1][3] = this.mat[1][3] * -1;
            ret.mat[2][3] = this.mat[2][3] * -1;
            return ret;
        }

        /// <summary>
        /// Don't use
        /// </summary>
        /// <returns></returns>
        public Matrix inverseScale()
        {
            Matrix ret = new Matrix();
            for (int i = 0; i < 4; i++)
            {
                ret.mat[i][i] = 1.0 / this.mat[i][i];
            }
            return ret;
        }

        /// <summary>
        /// Creates a transformation matrix which has its rotations built as an average of a group of another rotation or transformation matrices
        /// </summary>
        /// <param name="mats">A series of either rotation matrices or transformation matrices or a combination of both</param>
        /// <returns>a 4x4 transformation matrix with no translation and a rotation component that is the average of all the arguments</returns>
        public static Matrix averageRotations(params Matrix[] mats)
        {
            Matrix ret = new Matrix();
            double a = 0;
            double b = 0;
            double c = 0;
            double d = 0;
            double e = 0;
            double f = 0;
            double g = 0;
            double h = 0;
            double i = 0;
            for (int j = 0; j < mats.Length; j++)
            {
                a += mats[j].get(0, 0);
                b += mats[j].get(0, 1);
                c += mats[j].get(0, 2);
                d += mats[j].get(1, 0);
                e += mats[j].get(1, 1);
                f += mats[j].get(1, 2);
                g += mats[j].get(2, 0);
                h += mats[j].get(2, 1);
                i += mats[j].get(2, 2);
            }
            ret.set(0, 0, a / mats.Length);
            ret.set(0, 1, b / mats.Length);
            ret.set(0, 2, c / mats.Length);
            ret.set(1, 0, d / mats.Length);
            ret.set(1, 1, e / mats.Length);
            ret.set(1, 2, f / mats.Length);
            ret.set(2, 0, g / mats.Length);
            ret.set(2, 1, h / mats.Length);
            ret.set(2, 2, i / mats.Length);
            return ret;
        }

        /// <summary>
        /// Averages all of the individual elements of the passed in matrices and
        /// returns a matrix that is all of the average values of the passed matrices
        /// </summary>
        /// <param name="mats">the transformation matrices we want the average of</param>
        /// <returns>the average of the argument matrices</returns>
        public static Matrix averageOfTransforms(params Matrix[] mats)
        {
            for (int i = 0; i < mats.Length; i++)
            {
                int[] size = mats[i].size();
                if (size[0] != 4 || size[1] != 4)
                {
                    return new Matrix();
                }
            }
            Matrix ret = new Matrix();
            double a = 0;
            double b = 0;
            double c = 0;
            double d = 0;
            double e = 0;
            double f = 0;
            double g = 0;
            double h = 0;
            double k = 0;
            double l = 0;
            double m = 0;
            double n = 0;
            double o = 0;
            double p = 0;
            double q = 0;
            double r = 0;
            for (int j = 0; j < mats.Length; j++)
            {
                a += mats[j].get(0, 0);
                b += mats[j].get(0, 1);
                c += mats[j].get(0, 2);
                d += mats[j].get(0, 3);
                e += mats[j].get(1, 0);
                f += mats[j].get(1, 1);
                g += mats[j].get(1, 2);
                h += mats[j].get(1, 3);
                k += mats[j].get(2, 0);
                l += mats[j].get(2, 1);
                m += mats[j].get(2, 2);
                n += mats[j].get(2, 3);
                o += mats[j].get(3, 0);
                p += mats[j].get(3, 1);
                q += mats[j].get(3, 2);
                r += mats[j].get(3, 3);
            }
            ret.set(0, 0, a / mats.Length);
            ret.set(0, 1, b / mats.Length);
            ret.set(0, 2, c / mats.Length);
            ret.set(0, 3, d / mats.Length);
            ret.set(1, 0, e / mats.Length);
            ret.set(1, 1, f / mats.Length);
            ret.set(1, 2, g / mats.Length);
            ret.set(1, 3, h / mats.Length);
            ret.set(2, 0, k / mats.Length);
            ret.set(2, 1, l / mats.Length);
            ret.set(2, 2, m / mats.Length);
            ret.set(2, 3, n / mats.Length);
            ret.set(3, 0, o / mats.Length);
            ret.set(3, 1, p / mats.Length);
            ret.set(3, 2, q / mats.Length);
            ret.set(3, 3, r / mats.Length);
            return ret;
        }

        /// <summary>
        /// Reduces this matrix into upper-triangular form, by useing the HouseHolder algorithm
        /// </summary>
        /// <param name="b">the vector b from the matrix equation Ax = b. NOTE: this will be modified by this method.</param>
        /// <returns>the matrix A in upper triangular form</returns>
        public Matrix householderReduce(ref Vector b)
        {
            if (this.mat[0].Length > this.mat.Length)
            {
                throw new MatrixException("More Columns than Rows");
            }
            Matrix[] store = new Matrix[this.mat[0].Length + 1];
            Vector[] c = new Vector[this.mat[0].Length + 1];
            c[0] = b;
            store[0] = this;
            int l;
            for (l = 0; l < this.mat[0].Length; l++)
            {
                Vector x = Vector.getCol(store[l], 0);
                x.set(0, x.get(0) + Math.Sign(x.get(0)) * x.magnitudeAll());
                Vector w = x.mult(1.0 / x.magnitudeAll());
                Matrix H = new Matrix(w.size(), w.size());
                Matrix wwPer = w.outsideProduct(w);
                H = H.subtract(wwPer.multiply(2.0));
                store[l] = H.multiply(store[l]);
                c[l] = H.multiply(c[l]);
                if (l < this.mat[0].Length - 1)
                {
                    store[l + 1] = store[l].subsetMatrix(1, 1);
                    c[l + 1] = c[l].subset(1);
                }
            }
            Matrix ret = new Matrix(this.mat.Length, this.mat[0].Length);
            for (int i = 1; i <= this.mat[0].Length; i++)
            {
                for (int j = i - 1, k = 0; j < this.mat[0].Length; j++, k++)
                {
                    ret.set(i - 1, j, store[i - 1].get(0, k));
                }
                b.set(i - 1, c[i - 1].get(0));
            }
            for (int i = 0; i < this.mat.Length; i++)
            {
                for (int j = 0; j < this.mat[0].Length; j++)
                {
                    this.mat[i][j] = ret.get(i, j);
                }
            }
            return ret;
        }

        /// <summary>
        /// Subtracts a mulitple of one row from another
        /// </summary>
        /// <param name="subtracterRow">the number of the row that will be haveing a multiple of itself be subtracted from another row</param>
        /// <param name="subtracteeRow">the number of the row that will be subtracted from</param>
        /// <param name="multiple">the number that the subtractor row will be multiplied by before subtracting it from the subtractee row</param>
        public void subtractRow(int subtracterRow, int subtracteeRow, double multiple)
        {
            for (int i = 0; i < this.mat[subtracterRow].Length; i++)
            {
                this.mat[subtracteeRow][i] -= (this.mat[subtracterRow][i] * multiple);
            }
        }

        /// <summary>
        /// Finds the transformation Matrix that transforms a set of points from one coordinate system to another coordinate system
        /// </summary>
        /// <param name="O">The matrix of points in the original coordinate system</param>
        /// <param name="M">The matrix of points in the new coordate system</param>
        /// <returns></returns>
        public static Matrix computeTransformationMatrix(Matrix O, Matrix M)
        {
            Matrix oTimesOTranspose = O.multiply(O.transpose());
            Matrix temp = oTimesOTranspose.inverse();
            Matrix T = M.multiply(O.transpose()).multiply(temp);
            double tx = T.get(0, 3);
            double ty = T.get(1, 3);
            double tz = T.get(2, 3);
            double rz = Math.Atan(-T.get(1, 0) / T.get(0, 0));
            double ry = Math.Atan(T.get(2, 0) / (T.get(0, 0) / Math.Cos(rz)));
            double rx = Math.Atan(-T.get(2, 1) / T.get(2, 2));
            Matrix rotateZ = new Matrix(-rz, 'z');
            Matrix rotateY = new Matrix(-ry, 'y');
            Matrix rotateX = new Matrix(-rx, 'x');
            Matrix FaroRotate = rotateZ.multiply(rotateY.multiply(rotateX));
            Matrix currentToOriginal = new Matrix(FaroRotate.get(0, 0), FaroRotate.get(0, 1), FaroRotate.get(0, 2), tx, FaroRotate.get(1, 0), FaroRotate.get(1, 1), FaroRotate.get(1, 2), ty, FaroRotate.get(2, 0), FaroRotate.get(2, 1), FaroRotate.get(2, 2), tz, 0, 0, 0, 1);
            return currentToOriginal;
        }

        /// <summary>
        /// Takes a 4x4 matrix that represents a point, and strips out the translations of the matrix and puts them into a 4x1 vector
        /// </summary>
        /// <returns>A 3x1 vector that has the translations of the matrix this was called on</returns>
        public Vector turnPointMatrixInto4x1Vector()
        {
            int[] size = this.size();
            if (size[0] == 4 && size[1] == 4)
            {
                Vector ret = new Vector(4);
                ret.set(0, this.mat[0][3]);
                ret.set(1, this.mat[1][3]);
                ret.set(2, this.mat[2][3]);
                ret.set(3, 1);
                return ret;
            }
            return null;
        }

        ///<summary>
        ///Solves Matrix systems of the form Ax = b Only works on square matrices
        ///</summary>
        public static Vector solve(Matrix A, Matrix b)
        {
            if (A.mat.Length == b.mat.Length && b.mat[0].Length == 1)
            {
                Vector ret;
                for (int i = 0; i < A.mat.Length; i++)
                {
                    for (int j = i + 1; j < A.mat.Length; j++)
                    {
                        double mult = A.mat[j][i] / A.mat[i][i];
                        A.subtractRow(i, j, mult);
                        b.subtractRow(i, j, mult);
                    }
                }
                return ret = backSubstitution(A, new Vector(b));
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// Solves Matrix systems of the form Ax = b
        /// </summary>
        /// <param name="A">the matrix A from the matrix equation Ax = b</param>
        /// <param name="b">the vector b from the matrix equation Ax = b</param>
        /// <returns>the vector x from the matrix equation Ax = b</returns>
        public static Vector solve(Matrix A, Vector b)
        {
            Matrix AtransposeTimesA = A.transpose().multiply(A);
            AtransposeTimesA.print();
            Vector AtransposeTimesb = A.transpose().multiply(b);
            AtransposeTimesb.print();
            if (AtransposeTimesb != null)
            {
                AtransposeTimesA.householderReduce(ref AtransposeTimesb);
                return backSubstitution(AtransposeTimesA, AtransposeTimesb);
            }
            return null;
        }

        /// <summary>
        /// Computes the values for x in the matrix equation Ax = b, after A is in uppper-triangular form
        /// </summary>
        /// <param name="A">An upper-triangular Matrix</param>
        /// <param name="b">the b in the matrix equation Ax = b</param>
        /// <returns>the x in the matrix equation Ax = b</returns>
        public static Vector backSubstitution(Matrix A, Vector b)
        {
            Matrix tempA;
            Vector tempB;
            if (A.mat.Length != A.mat[0].Length)
            {
                tempA = new Matrix(A.mat[0].Length, A.mat[0].Length);
                for (int i = 0; i < A.mat[0].Length; i++)
                {
                    for (int j = 0; j < A.mat[0].Length; j++)
                    {
                        tempA.mat[i][j] = A.mat[i][j];
                    }
                }
                tempB = new Vector(A.mat[0].Length);
                for (int i = 0; i < A.mat[0].Length; i++)
                {
                    tempB.set(i, b.get(i));
                }
            }
            else
            {
                tempA = A;
                tempB = b;
            }
            Vector ret = new Vector(tempA.mat.Length);
            for (int i = tempA.mat.Length - 1; i >= 0; i--)
            {
                ret.set(i, tempB.get(i));
                for (int j = i + 1; j < tempA.mat.Length; j++)
                {
                    ret.set(i, ret.get(i) - tempA.mat[i][j] * ret.get(j));
                }
                ret.set(i, ret.get(i) / tempA.mat[i][i]);
            }
            return ret;
        }

        /// <summary>
        /// Creates a best fit line for a set of points (x,y)
        /// </summary>
        /// <param name="xs">An array containing the range of values for the line to fit</param>
        /// <param name="ys">An array with the domain values for the line to be created</param>
        /// <param name="degree">The degree of the line to be created ie. degree=1 makes a line of the form y = ax + b</param>
        /// <param name="error">A variable holding the amount of error that the fit line has for this set of data</param>
        /// <returns>A vector containing the coefficients of the best fit line</returns>
        public static Vector fitLineToPoints(double[] xs, double[] ys, int degree, out double error)
        {
            Vector[] columnsOfA = new Vector[degree+1];
            Vector b = new Vector(ys);
            columnsOfA[0] = Vector.ones(xs.Length);
            double[] temp = new double[xs.Length];
            for (int i = 1; i < (degree+1); i++)
            {
                for (int j = 0; j < xs.Length; j++)
                {
                    temp[j] = Math.Pow(xs[j], i);
                }
                columnsOfA[i] = new Vector(temp);
            }
            Matrix A = new Matrix(columnsOfA);
            Matrix AtA = A.transpose().multiply(A);
            Vector Atb = A.transpose().multiply(b);
            Matrix rrefAtA = AtA.householderReduce(ref Atb);
            Vector ret = backSubstitution(rrefAtA, Atb);
            Vector Ax = A.multiply(ret);
            Vector AxMINUSb = Ax.subtract(b);
            //Console.WriteLine("--------------A-----------------\n");
            //A.print();
            //Console.WriteLine("--------------A*x------------------\n");
            //Ax.print();
            //Console.WriteLine("--------------b-----------------\n");
            //b.print();
            //Console.WriteLine("--------------A*x-b------------------\n");
            //AxMINUSb.print();
            error = AxMINUSb.magnitudeAll();
            return ret;
        }
    }
}
