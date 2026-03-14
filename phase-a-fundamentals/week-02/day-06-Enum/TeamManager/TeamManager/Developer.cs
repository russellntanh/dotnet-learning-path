namespace TeamManager
{
    public class Developer
    {
        // Properties
        public string Name { get; private set; } // cannot empty or null
        public int Age { get; set; } // must be between 18 and 65
        public Position TeamRole { get; set; } // cannot empty or null
        public double YearOfExperience { get; set; }
        public DeveloperLevel Level { get; set; }
        public bool IsFullTime { get; set; }
        

        // Computed property
        public string DisplaySummary => $"{Name} - {TeamRole.ToString()} ({YearOfExperience} Years)";

        // Constructor
        public Developer(string name, int age, Position position) 
        { 
            if(string.IsNullOrEmpty(name))
                throw new ArgumentNullException("Name cannot be empty.");
            Name = name;

            if (age < 18 || age > 65)
                throw new ArgumentOutOfRangeException("Age must be between 18 and 65.");
            Age = age;
            TeamRole = position;
        }

        public string GetFullTimeStatus()
        {
            return IsFullTime ? "Yes" : "No";
        }
    }
}
