using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Matrix_Library_4_5
{
    public class MathFunctions
    {
        public static double CalculateStdDev(IEnumerable<double> values)
        {
            double ret = 0;
            if (values.Count() > 0)
            {
                //Compute the Average      
                double avg = values.Average();
                //Perform the Sum of (value-avg)_2_2      
                double sum = values.Sum(d => Math.Pow(d - avg, 2));
                //Put it all together      
                ret = Math.Sqrt((sum) / (values.Count() - 1));
            }
            return ret;
        }

        public static float CalculateStdDev(IEnumerable<float> values)
        {
            float ret = 0;
            if (values.Count() > 0)
            {
                //Compute the Average      
                float avg = values.Average();
                //Perform the Sum of (value-avg)_2_2      
                float sum = values.Sum(d => (float)Math.Pow(d - avg, 2));
                //Put it all together      
                ret = (float)Math.Sqrt((sum) / (values.Count() - 1));
            }
            return ret;
        }
    }
}
