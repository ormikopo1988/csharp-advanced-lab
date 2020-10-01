using System;
using System.Collections.Generic;
using System.Text;

namespace CSharpGenericsLab.Starter
{
   public  class Part 
    {
        public string PartName { get; set; }

        public int PartId { get; set; }

        public override string ToString()
        {
            return "ID: " + PartId + "   Name: " + PartName;
        }
    }

}
