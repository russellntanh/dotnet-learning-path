namespace TeamManager
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int totalMembers = 0;

            // Create some Developer instances
            var team = new List<Developer>()
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

            // Display developer information
            for (int i = 0; i < team.Count; i++)
            {
                Console.WriteLine($"{i+1}. {team[i].Name}");
                Console.WriteLine($"   Position: {team[i].Position}");
                Console.WriteLine($"   Age: {team[i].Age} | Year of Experience: {team[i].YearOfExperience} | Full Time: {team[i].GetFullTimeStatus()}");
                Console.WriteLine();
            }

            // Total members
            Console.WriteLine($"Total Members: {team.Count}");
            Console.WriteLine();

            // Find information of a specific developer
            Console.Write("Enter name to search: ");
            string searchName = Console.ReadLine();

            bool found = false;
            foreach (var developer in team)
            {
                if (developer.Name.Contains(searchName, StringComparison.OrdinalIgnoreCase))
                {
                    found = true;
                    Console.WriteLine($"Found: {developer.DisplaySummary}");
                    break;
                }
            }
         
            if (found == false)
                Console.WriteLine($"Not found the search name: {searchName}");
        }
    }
}
