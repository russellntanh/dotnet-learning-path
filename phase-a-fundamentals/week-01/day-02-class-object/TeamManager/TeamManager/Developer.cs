using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeamManager
{
    public class Developer
    {
        public string Name;
        public int Age;
        public string Position;
        public double YearOfExperience;
        public bool IsFullTime;

        public string GetFullTimeStatus()
        {
            return IsFullTime ? "Yes" : "No";
        }
    }
}
