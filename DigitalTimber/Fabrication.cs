using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigitalTimber
{
    /// <summary>
    /// Compute fabrication metrics.
    /// </summary>
    public class Fabrication
    {
        public double fTime { get; set; }
        public double fComplexity { get; set; }
        public double fCosts { get; set; }

        public Fabrication()
        {
            // Initial fabrication time, complexity and cost calculations.
        }
    }
}
