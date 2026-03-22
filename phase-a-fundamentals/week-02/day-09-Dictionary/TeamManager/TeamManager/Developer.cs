namespace TeamManager
{
    public class Developer
    {
        // Properties
        public string Name { get; private set; } // cannot empty or null
        public int Age { get; set; } // must be between 18 and 65
        public TeamRole Role { get; set; } // Member, Leader, Manager
        public double YearOfExperience { get; set; }
        public TechLevel Level { get; set; } // Junior, Mid, Senior
        public bool IsFullTime { get; set; }
        public Project InvolvedProject { get; set; }
        public List<string> Skills { get; set; } = new List<string>();


        // Computed property
        public string DisplaySummary => $"{Name} - {Role} ({YearOfExperience} Years)";

        // Constructor
        public Developer(string name, int age, TeamRole role, Project project) 
        { 
            if(string.IsNullOrEmpty(name))
                throw new ArgumentNullException("Name cannot be empty.");
            Name = name;

            if (age < 18 || age > 65)
                throw new ArgumentOutOfRangeException("Age must be between 18 and 65.");
            
            Age = age;
            Role = role;
            InvolvedProject = project;
        }

        public string GetFullTimeStatus()
        {
            return IsFullTime ? "Yes" : "No";
        }
    }
}
