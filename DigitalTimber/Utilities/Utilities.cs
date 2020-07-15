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

namespace DigitalTimber.Utilities
{
    public static class Util
    {
        /// <summary>
        /// Returns the minimum angle in degrees between two vectors.
        /// </summary>
        /// <param name="v0"></param>
        /// <param name="v1"></param>
        /// <returns></returns>
        public static double Angle(Vec3d v0, Vec3d v1)
        {
            double rad = Vec3d.Angle(v0, v1);
            return rad * (180 / Math.PI);
        }

        /// <summary>
        /// Return a standard form of the face normal.
        /// </summary>
        /// <param name="face"></param>
        /// <returns></returns>
        public static Vector3d Normal(HeMesh3d.Face face)
        {
            Vector3d norm = new Vector3d();
            Vec3d v = X.GetNormal(face);

            norm.X = v.X; norm.Y = v.Y; norm.Z = v.Z;
            return norm;
        }

        /// <summary>
        /// Return the face area of a HE Mesh Face in m2.
        /// </summary>
        /// <param name="face"></param>
        /// <returns></returns>
        public static double FaceArea(HeMesh3d.Face face)
        {
            return Math.Round((X.GetArea(face) / 10000000), 3);
        }

        /// <summary>
        /// Returns the planar deviation of the face (unspecified units).
        /// </summary>
        /// <param name="face"></param>
        /// <returns></returns>
        public static double Deviation(HeMesh3d.Face face)
        {
            return X.GetPlanarity(face);
        }
    }
}
