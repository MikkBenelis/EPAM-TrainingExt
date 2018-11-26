using System;
using System.Collections.Generic;

namespace No3.Solution
{
    public class Calculator
    {
        public double CalculateAverage(List<double> values, Func<List<double>, double> averagingFunc)
        {
            if (values == null || averagingFunc == null)
            {
                throw new ArgumentNullException(nameof(values));
            }

            return averagingFunc(values);
        }

        public double CalculateAverage(List<double> values, IAveragingMethod averagingFunc)
        {
            if (values == null || averagingFunc == null)
            {
                throw new ArgumentNullException(nameof(values));
            }

            return averagingFunc.CalculateAverage(values);
        }
    }
}
