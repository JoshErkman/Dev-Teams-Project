using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevTeamsProject
{
    public class Developer
    {
        public string Name { get; set; }
        public string IDNumber { get; set; }
        public bool HasPluralsightAccess { get; set; }
        public Developer() { }

        public Developer(string name, string idNumber, bool hasAccess)
        {
            Name = name;
            IDNumber = idNumber;
            HasPluralsightAccess = hasAccess;

        }
    }

}
