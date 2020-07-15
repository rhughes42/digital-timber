using System;
using System.Collections.Generic;

using Grasshopper.Kernel;
using Rhino.Geometry;
using SpatialSlur.SlurMesh;

using DigitalTimber.Data;

namespace DigitalTimberGH.Data
{
    public class CreateElement : GH_Component
    {
        /// <summary>
        /// Initializes a new instance of the CreateElement class.
        /// </summary>
        public CreateElement()
          : base("Create Element", "Element",
              "Create DTIF elements from a halfedge mesh.",
              "Digital Timber", "Data")
        {
        }

        /// <summary>
        /// Registers all the input parameters for this component.
        /// </summary>
        protected override void RegisterInputParams(GH_Component.GH_InputParamManager pManager)
        {
            pManager.AddGenericParameter("Mesh", "Mesh", "Element halfedge mesh geometry.", GH_ParamAccess.list);
            pManager.AddGenericParameter("Attributes", "Attributes", "Element attributes as a dictionary.", GH_ParamAccess.list);
            pManager[1].Optional = true;
        }

        /// <summary>
        /// Registers all the output parameters for this component.
        /// </summary>
        protected override void RegisterOutputParams(GH_Component.GH_OutputParamManager pManager)
        {
            pManager.AddGenericParameter("Element", "Element", "DTIF formatted element.", GH_ParamAccess.list);
        }

        /// <summary>
        /// This is the method that actually does the work.
        /// </summary>
        /// <param name="DA">The DA object is used to retrieve from inputs and store in outputs.</param>
        protected override void SolveInstance(IGH_DataAccess DA)
        {
            List<HeMesh3d> hem = new List<HeMesh3d>();
            List<Attributes> att = new List<Attributes>();
            List<Element> els = new List<Element>();

            if (!DA.GetDataList(0, hem)) return;
            if (!DA.GetDataList(1, att)) att.Add(new Attributes());

            // Check if every object has attributes, and add default if needed.
            if (att.Count < hem.Count)
            {
                this.AddRuntimeMessage(GH_RuntimeMessageLevel.Warning, "List of attributes was modified to fit the list of geometries.");
                for (int i = att.Count; i < hem.Count; i++)
                    att.Add(new Attributes());
            }

            for(int i = 0; i < hem.Count; i++)
            {
                try
                {
                    els.Add(new Element()
                }
                catch (Exception e)
                {
                    Console.WriteLine("{0} Exception caught.", e);
                }
            }

            DA.SetDataList(0, els);
        }

        /// <summary>
        /// Provides an Icon for the component.
        /// </summary>
        protected override System.Drawing.Bitmap Icon
        {
            get
            {
                //You can add image files to your project resources and access them like this:
                // return Resources.IconForThisComponent;
                return null;
            }
        }

        /// <summary>
        /// Gets the unique ID for this component. Do not change this ID after release.
        /// </summary>
        public override Guid ComponentGuid
        {
            get { return new Guid("56eef3d0-5162-49ef-9328-8555507891cb"); }
        }
    }
}