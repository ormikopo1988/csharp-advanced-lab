﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace CSharpGenericsLab.Starter
{
    public class Part : IEquatable<Part>
    {
        public int PartId { get; set; }
        public string PartName { get; set; }

        public override string ToString()
        {
            return $"ID: {PartId} Name: {PartName}";
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

        public bool Equals(Part other)
        {
            if (other == null)
            {
                return false;
            }
            return PartId.Equals(other.PartId);
        }
    }
}