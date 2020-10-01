using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace CSharpGenericsLab.Starter
{
    public class Part : IEquatable<Part>
    {
        public string PartName { get; set; }

        public int PartId { get; set; }

        public override string ToString()
        {
            return "ID: " + PartId + "   Name: " + PartName;
        }

        public override bool Equals(object obj)
        {
            if (obj == null)
            {
                return false;
            }

            Part objAsPart = obj as Part;

            if (objAsPart == null)
            {
                return false;
            }
            else
            {
                return Equals(objAsPart);
            }
        }
        public override int GetHashCode()
        {
            return PartId;
        }

        public bool Equals(Part part)
        {
            if (part == null)
            {
                return false;
            }

            return (this.PartId.Equals(part.PartId));
        }

    }
}
