using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeamManager
{
    public class Developer
    {
        // Properties
        public string Name { get; private set; } // cannot empty or null
        public int Age { get; set; } // must be between 18 and 65
        public string Position { get; set; } // cannot empty or null
        public double YearOfExperience { get; set; }
        public bool IsFullTime { get; set; }

        // Computed property
        public string DisplaySummary => $"{Name} - {Position} ({YearOfExperience} Years)";

        // Constructor
        public Developer(string name, int age, string position) 
        { 
            if(string.IsNullOrEmpty(name))
                throw new ArgumentNullException("Name cannot be empty.");
            Name = name;

            if (age < 18 || age > 65)
                throw new ArgumentOutOfRangeException("Age must be between 18 and 65.");
            Age = age;

            if (string.IsNullOrEmpty(position))
                throw new ArgumentNullException("Position cannot be empty.");
            Position = position;
        }

        public string GetFullTimeStatus()
        {
            return IsFullTime ? "Yes" : "No";
        }
    }
}
