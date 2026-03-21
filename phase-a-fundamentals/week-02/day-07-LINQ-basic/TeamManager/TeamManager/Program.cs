
namespace TeamManager
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var team = CreateTeam();

            //===== TEAM MEMBER LIST =====
            DisplayDeveloperInfo(team);

            //===== SEARCH BY NAME =====
            Console.WriteLine("===== SEARCH BY NAME =====");
            Console.Write("Enter name to search: ");
            string searchName = Console.ReadLine();

            var foundDeveloper = FindDeveloperByName(team, searchName);
            DisplaySearchedDeveloperInfo(foundDeveloper, searchName);
            Console.WriteLine();

            //===== FILTER BY POSITION =====
            Console.WriteLine("===== FILTER BY POSITION =====");
            FilterByPosition(team, Position.Member);
            Console.WriteLine();

            //===== SORTED BY NAME =====
            Console.WriteLine("===== SORTED BY NAME =====");
            SortByName(team);
            Console.WriteLine();

            //===== TEAM STATISTICS =====
            Console.WriteLine("===== TEAM STATISTICS =====");
            DisplayTeamStatistics(team);
        }



        static List<Developer> CreateTeam()
        {
            return new List<Developer>()
            {
                new Developer("Khuong.Duong", 43, Position.TeamLeader)
                {
                    YearOfExperience = 20,
                    Level = DeveloperLevel.Senior,
                    IsFullTime = true
                },
                new Developer("Jimmii.Nguyen", 37, Position.Member)
                {
                    YearOfExperience = 3.0,
                    Level = DeveloperLevel.Senior,
                    IsFullTime = true
                },
                new Developer("Jason.Duong", 27, Position.Member)
                {
                    YearOfExperience = 3.0,
                    Level = DeveloperLevel.Junior,
                    IsFullTime = true
                },
                new Developer("Alex.Thai", 42, Position.Member)
                {
                    YearOfExperience = 3.0,
                    Level = DeveloperLevel.Senior,
                    IsFullTime = true
                },
                new Developer("Michael.Kim", 44, Position.Manager)
                {
                    YearOfExperience = 20,
                    Level = DeveloperLevel.Lead,
                    IsFullTime = true
                }
            };
        }

        static void DisplayDeveloperInfo(List<Developer> team)
        {
            for (int i = 0; i < team.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {team[i].Name}");
                Console.WriteLine($"   Position: {team[i].TeamRole}");
                Console.WriteLine($"   Age: {team[i].Age} | Year of Experience: {team[i].YearOfExperience} | Level: {team[i].Level} | Full Time: {team[i].GetFullTimeStatus()}");
                Console.WriteLine();
            }
            Console.WriteLine($"Total Members: {team.Count}");
            Console.WriteLine();
        }

        static Developer? FindDeveloperByName(List<Developer> team, string keyword)
        {
            return team.FirstOrDefault(dev => dev.Name.Contains(keyword, StringComparison.OrdinalIgnoreCase));
        }

        static void DisplaySearchedDeveloperInfo(Developer? dev, string keyword)
        {
            if (dev != null)
            {
                Console.WriteLine($"Found developer: {dev.Name}");
                Console.WriteLine($"Position: {dev.TeamRole}");
                Console.WriteLine($"Age: {dev.Age} | Year of Experience: {dev.YearOfExperience} | Full Time: {dev.GetFullTimeStatus()}");
            }
            else
            {
                Console.WriteLine($"No developer found with the name: {keyword}");
            }
        }

        static void FilterByPosition(List<Developer> team, Position position)
        {
            // nhanh hon khi dung ToList() de luu ket qua vao mot list moi, tranh viec tinh toan lai moi lan truy cap
            var filteredDevelopers = team.Where(dev => dev.TeamRole == position).ToList(); 

            Console.WriteLine($"There are {filteredDevelopers.Count} {position}: "); // nhanh hon vi tren da la List
            int i = 1;
            foreach (var dev in filteredDevelopers)
            {
                Console.WriteLine($"{i++}. {dev.Name} - {dev.GetFullTimeStatus()}");
            }
        }

        static void SortByName(List<Developer> team)
        {
            var developerNames = team.OrderBy(dev => dev.Name);

            foreach (var dev in developerNames)
            {
                Console.WriteLine(dev.Name);
            }
        }
        static void DisplayTeamStatistics(List<Developer> team)
        {
            var leaderCount = team.Count(dev => dev.TeamRole == Position.TeamLeader);
            var memberCount = team.Count(dev => dev.TeamRole == Position.Member);
            var managerCount = team.Count(dev => dev.TeamRole == Position.Manager);

            var averagedExp = team.Average(dev => dev.YearOfExperience);
            var mostExperienced = team.OrderByDescending(dev => dev.YearOfExperience).FirstOrDefault();
            
            Console.WriteLine($"Team Leaders: {leaderCount}");
            Console.WriteLine($"Members: {memberCount}");
            Console.WriteLine($"Managers: {managerCount}");
            Console.WriteLine($"Average Experience: {averagedExp:F1} years");
            if (mostExperienced != null)
            {
                Console.WriteLine($"Most Experienced: {mostExperienced.Name} ({mostExperienced.YearOfExperience} years)");
            }
        }
    }
}
