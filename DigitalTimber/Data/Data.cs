using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Rhino.Geometry;

using SpatialSlur.SlurCore;
using SpatialSlur.SlurData;
using SpatialSlur.SlurMesh;

using X = SpatialSlur.SlurMesh.HeFaceExtension;

namespace DigitalTimber.Data
{
    public class Types
    {
        /// <summary>
        /// Enumerable component types for clarity.
        /// </summary>
        public enum Function
        {
            Unknown = -1,
            Floor = 0,
            Wall = 1,
            Roof = 2
        }

        /// <summary>
        /// Enumerable material types for clarity.
        /// </summary>
        public enum Material
        {
            Unknown = -1,
            Concrete = 0,
            Steel = 1,
            MassTimber = 2,
            MiC = 3,
            CLT = 4
        }

        /// <summary>
        /// Enumerable structural classification for clarity.
        /// </summary>
        public enum Structure
        {
            Unknown = -1,
            Critical = 0,
            Loadbearing = 1,
            Infill = 2
        }
    }
}
