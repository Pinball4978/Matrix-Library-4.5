using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Matrix_Library_4_5
{
    public class CorrelationCoeficientFinder
    {
        public static double[] findCorrelationCoeficients(double[] actualValues, params double[][] predictiveVariables)
        {
            Matrix X = new Matrix(actualValues.Length, predictiveVariables.Length + 1);
            for (int i = 0; i < actualValues.Length; i++)
            {
                X.set(i, 0, 1);
            }
            for (int i = 0; i < predictiveVariables.Length; i++)
            {
                double[] variableValues = predictiveVariables[i];
                for (int j = 0; j < actualValues.Length; j++)
                {
                    X.set(j, i + 1, variableValues[j]);
                }
            }
            //X == Matrix of the variables that are supposed to predict some value
            Matrix y = new Vector(actualValues.ToArray()).toColMatrix();        //y == actual values 
            Matrix XtX = X.transpose().multiply(X);
            Matrix XtXInverse = XtX.inverse();
            Matrix XtY = X.transpose().multiply(y);

            Matrix b = XtXInverse.multiply(XtY);                                //b = ((XT * X)^-1) * (XT * y)  b == the coeficients of the variables that are being used to predict some values
            Matrix yHat = X.multiply(b);                                        //yHat = X * b                  yHat == values arrived at using the predictive values and their coefficients to predict the values
            double[] ret = new double[predictiveVariables.Length + 1];
            for (int i = 0; i < predictiveVariables.Length + 1; i++)
            {
                ret[i] = b.get(i, 0);
            }
            return ret;
        }

        public static double[] findCorrelationCoeficients(List<double> actualValues, params List<double>[] predictiveVariables)
        {
            Matrix X = new Matrix(actualValues.Count, predictiveVariables.Length + 1);
            for (int i = 0; i < actualValues.Count; i++)
            {
                X.set(i, 0, 1);
            }
            for (int i = 0; i < predictiveVariables.Length; i++)
            {
                List<double> variableValues = predictiveVariables[i];
                for (int j = 0; j < actualValues.Count; j++)
                {
                    X.set(j, i + 1, variableValues[j]);
                }
            }
            //X == Matrix of the variables that are supposed to predict some value
            Matrix y = new Vector(actualValues.ToArray()).toColMatrix();        //y == actual values 
            Matrix XtX = X.transpose().multiply(X);
            Matrix XtXInverse = XtX.inverse();
            Matrix XtY = X.transpose().multiply(y);

            Matrix b = XtXInverse.multiply(XtY);                                //b = ((XT * X)^-1) * (XT * y)  b == the coeficients of the variables that are being used to predict some values
            Matrix yHat = X.multiply(b);                                        //yHat = X * b                  yHat == values arrived at using the predictive values and their coefficients to predict the values
            double[] ret = new double[predictiveVariables.Length + 1];
            for (int i = 0; i < predictiveVariables.Length + 1; i++)
            {
                ret[i] = b.get(i, 0);
            }
            return ret;
        }
    }
}
