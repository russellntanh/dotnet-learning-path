namespace TeamManager
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Create some Developer instances
            var team = CreateTeam();

            // Display developer information
            DisplayDeveloperInfo(team);

            // Find information of a specific developer
            Console.Write("Enter name to search: ");
            string searchName = Console.ReadLine();

            var foundDeveloper = FindDeveloperByName(team, searchName);
            DisplaySearchedDeveloperInfo(foundDeveloper, searchName);

        }

        static List<Developer> CreateTeam()
        {
            return new List<Developer>()
            {
                new Developer("Khuong.Duong", 43, "Team Leader")
                {
                    YearOfExperience = 20,
                    IsFullTime = true
                },
                new Developer("Jimmii.Nguyen", 37, "Member")
                {
                    YearOfExperience = 3.0,
                    IsFullTime = true
                },
                new Developer("Jason.Duong", 27, "Member")
                {
                    YearOfExperience = 3.0,
                    IsFullTime = true
                },
                new Developer("Alex.Thai", 42, "Member")
                {
                    YearOfExperience = 3.0,
                    IsFullTime = true
                },
                new Developer("Michael.Kim", 44, "Manager")
                {
                    YearOfExperience = 20,
                    IsFullTime = true
                }
            };
        }

        static void DisplayDeveloperInfo(List<Developer> team)
        {
            for (int i = 0; i < team.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {team[i].Name}");
                Console.WriteLine($"   Position: {team[i].Position}");
                Console.WriteLine($"   Age: {team[i].Age} | Year of Experience: {team[i].YearOfExperience} | Full Time: {team[i].GetFullTimeStatus()}");
                Console.WriteLine();
            }
            Console.WriteLine($"Total Members: {team.Count}");
            Console.WriteLine();
        }

        static Developer? FindDeveloperByName(List<Developer> team, string keyword)
        {
            foreach (var developer in team)
            {
                if (developer.Name.Contains(keyword, StringComparison.OrdinalIgnoreCase))
                   return developer;
            }

            return null;
        }

        static void DisplaySearchedDeveloperInfo(Developer? dev, string keyword)
        {
            if (dev != null)
            {
                Console.WriteLine($"Found developer: {keyword}");
                Console.WriteLine($"Position: {dev.Position}");
                Console.WriteLine($"Age: {dev.Age} | Year of Experience: {dev.YearOfExperience} | Full Time: {dev.GetFullTimeStatus()}");
            }
            else
            {
                Console.WriteLine($"No developer found with the name: {keyword}");
            }
        }
    }
}
