using System;
using System.Linq;
using System.Collections.Generic;

namespace No3.Solution
{
    public class AveragingMethodWithInterface : IAveragingMethod
    {
        public double CalculateAverage(List<double> values)
        {
            if (values == null)
            {
                throw new ArgumentNullException(nameof(values));
            }

            return values.Sum() / values.Count;
        }
    }
}
