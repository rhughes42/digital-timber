using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigitalTimber
{
    /// <summary>
    /// Compute assembly metrics.
    /// </summary>
    public class Assembly
    {
        public double aTime { get; set; }
        public double aComplexity { get; set; }
        public double aCosts { get; set; }

        public Assembly()
        {
            // Initial fabrication time, complexity and cost calculations.
        }
    }
}
