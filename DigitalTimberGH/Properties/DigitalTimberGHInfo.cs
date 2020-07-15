using System;
using System.Drawing;
using Grasshopper.Kernel;

namespace DigitalTimberGH
{
    public class DigitalTimberGHInfo : GH_AssemblyInfo
    {
        public override string Name
        {
            get
            {
                return "DigitalTimberGH";
            }
        }
        public override Bitmap Icon
        {
            get
            {
                //Return a 24x24 pixel bitmap to represent this GHA library.
                return null;
            }
        }
        public override string Description
        {
            get
            {
                //Return a short string describing the purpose of this GHA library.
                return "Grasshopper interface to the Digital Timber research library.";
            }
        }
        public override Guid Id
        {
            get
            {
                return new Guid("df942066-7000-48c4-8fa9-b85bf1a2facb");
            }
        }

        public override string AuthorName
        {
            get
            {
                //Return a string identifying you or your company.
                return "Ryan Hughes";
            }
        }
        public override string AuthorContact
        {
            get
            {
                //Return a string representing your preferred contact details.
                return "rhu@axisarch.tech";
            }
        }
    }
}
