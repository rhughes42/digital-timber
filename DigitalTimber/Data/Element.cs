using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using SpatialSlur.SlurCore;
using SpatialSlur.SlurData;
using SpatialSlur.SlurMesh;

using U = DigitalTimber.Utilities.Util;
using T = DigitalTimber.Data.Types;

namespace DigitalTimber
{
    /// <summary>
    /// Digital timber interchange format (DTIF) element class.
    /// </summary>
    public class Element
    {
        public T.Function cFunction { get; set; }
        public HeMesh3d.Face cFace { get; set; }
        public Attributes cAttribs { get; set; }
        public Assembly cAssembly { get; set; }
        public Fabrication cFabrication { get; set; }
        public Guid cGuid { get; set; }
        public double cCost { get; set; }        

        public Element(HeMesh3d.Face face, Attributes attributes)
        {
            this.cFace = face;
            this.cAttribs = attributes;
            this.cGuid = Guid.NewGuid();
            this.cCost = this.ComputeCost();
        }

        /// <summary>
        /// Niaively return the type of the element
        /// based on orientation.
        /// </summary>
        /// <param name="face"></param>
        /// <param name="tolerance"></param>
        /// <returns></returns>
        public T.Function ComputeFunction(HeMesh3d.Face face, double tolerance)
        {
            T.Function func = T.Function.Unknown;

            Vec3d up = new Vec3d(0, 0, 1);
            double ang = U.Angle(U.Normal(face), up);
            double abs = Math.Abs(ang);

            // Use dot product in next version.
            if (abs > (0 - tolerance) && abs < (0 + tolerance)) // Up test
                func = T.Function.Roof;
            else if (abs > (0 + tolerance) && abs < (180 - tolerance)) // Hor test
                func = T.Function.Wall;
            else if (abs > (180 - tolerance) && abs < (180 + tolerance)) // Down test
                func = T.Function.Floor;
            else
                func = T.Function.Unknown;

            return func;
        }

        /// <summary>
        /// Simplified cost calculation function based on face, type and material.
        /// </summary>
        /// <returns></returns>
        public double ComputeCost()
        {
            double cost = 0.00;
            double cltCost = 600;

            // Handle each material case based on available information.
            if ((T.Material)this.cAttribs.attribs["material"] == T.Material.CLT)
            {
                cost = (double)this.cAttribs.attribs["area"] * cltCost;
            }

            return cost;
        }

        /// <summary>
        /// Niaive function to compute estimated assembly time.
        /// </summary>
        /// <returns></returns>
        public Assembly ComputeAssembly()
        {
            Assembly asm = new Assembly();

            // Function to compute assembly time goes here.
            // Use AIM models from Ayoub / CITA?

            return asm;
        }

        public Fabrication ComputeFabrication()
        {
            Fabrication fab = null;
            return fab;
        }

        /// <summary>
        /// If assembly information is available,
        /// update our element costs.
        /// </summary>
        /// <returns></returns>
        public double UpdateCosts()
        {
            double cost = 0.00;
            double baseCost = 150;
            if (this.cAssembly != null)
            {
                // Placeholder assembly cost function.
                double asmCosts = (cAssembly.aComplexity * cAssembly.aTime * baseCost);
                this.cCost = cCost + asmCosts;
            }
            return cost; // Unlinked placeholder.
        }

        /// <summary>
        /// If we don't have geometry, try compute it
        /// from a reference path.
        /// </summary>
        /// <param name="JSON"></param>
        /// <returns></returns>
        public HeMesh3d GeoFromJSON(string JSON)
        {
            HeMesh3d hem = HeMesh3d.Factory.CreateFromJson(JSON);
            return hem;
        }

        public override string ToString()
        {
            return String.Format("{0} : [{1} Attributes]", cFunction, cAttribs.size);
        }
    }
}
