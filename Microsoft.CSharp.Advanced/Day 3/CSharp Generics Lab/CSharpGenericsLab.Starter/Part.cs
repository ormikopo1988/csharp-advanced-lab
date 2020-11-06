using System;
using System.Diagnostics.CodeAnalysis;


namespace CSharpGenericsLab.Starter
{
    public class Part : IEquatable<Part>
    {
        public int PartId { get; set; }
        public string PartName { get; set; }

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

        public bool Equals(Part other)
        {
            if (other == null) return false;
            // Write code here to return false if null vaue is provided


            // Write code here to compare the two objects (this -> the current object & other -> the object provided as input argument) based on their PartId properties
            // and using the .Equals method
            return (this.PartId.Equals(other.PartId));
        }

        public override string ToString()
        {
            return "Part Id: " + PartId + "   Name: " + PartName;
        }
    }
}
