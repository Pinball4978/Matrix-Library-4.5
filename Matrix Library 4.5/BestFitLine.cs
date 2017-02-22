using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace Matrix_Library_4_5
{
    public class BestFitLine
    {
        //line formula: a + bx = y

        private double a;
        private double b;
        private double rSquared;
        public double RegressionCoefficient
        {
            get { return b; }
        }
        public double RegressionConstant
        {
            get { return a; }
        }
        public double CorrelationCoefficient
        {
            get { return rSquared; }
        }

        public BestFitLine(List<Point_2D> points)
        {
            double xSum = 0, ySum = 0, xAvg, yAvg, sumOfXSquares = 0, sumOfXYSquares = 0, sumOfYSquares = 0;
            foreach (Point_2D point in points)
            {
                xSum += point.X;
                ySum += point.Y;
            }
            xAvg = xSum / points.Count;
            yAvg = ySum / points.Count;
            foreach (Point_2D point in points)
            {
                sumOfXSquares += Math.Pow((point.X - xAvg), 2);
                sumOfXYSquares += (point.X - xAvg) * (point.Y - yAvg);
                sumOfYSquares += Math.Pow((point.Y - yAvg), 2);
            }
            this.b = sumOfXYSquares / sumOfXSquares;
            this.a = yAvg - this.b * xAvg;
            this.rSquared = Math.Pow(sumOfXYSquares, 2)/(sumOfXSquares * sumOfYSquares);
        }

        public double findValueOfX(double y)
        {
            return ((y - this.a)/this.b);
        }

        public double findValueOfY(double x)
        {
            return (this.a + this.b * x);
        }

        public static void CreateFileOfOptimumXs(string inputFile, string outputFile, double targetY)
        {
            List<BestFitLine> results = new List<BestFitLine>();
            using (TextReader input = new StreamReader(inputFile))
            {
                using (TextWriter output = new StreamWriter(outputFile))
                {
                    string line;
                    while ((line = input.ReadLine()) != null)
                    {
                        string[] temp = line.Split(',');
                        List<Point_2D> points = new List<Point_2D>();
                        for (int i = 1; i < temp.Length; i += 2)
                        {
                            try
                            {
                                points.Add(new Point_2D(double.Parse(temp[i]), double.Parse(temp[i + 1])));
                            }
                            catch (FormatException)
                            {

                            }
                        }
                        BestFitLine bestLine = new BestFitLine(points);
                        results.Add(bestLine);
                        output.WriteLine(temp[0] + "," + bestLine.findValueOfX(targetY));
                    }
                }
            }
            double avgError = 0;
            int numberOfValidLines = results.Count;
            foreach (BestFitLine line in results)
            {
                if (double.IsNaN(line.CorrelationCoefficient) || double.IsInfinity(line.CorrelationCoefficient))
                {
                    numberOfValidLines--;
                }
                else
                {
                    avgError += line.CorrelationCoefficient;
                }
            }
            avgError /= numberOfValidLines;
        }
    }
}
