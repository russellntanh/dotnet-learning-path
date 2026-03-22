namespace TeamManager
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var team = CreateTeam();

            //===== TEAM MEMBER LIST =====
            DisplayDeveloperInfo(team);
            DisplayTeamSummary(team);
            DisplayGroupByProject(team);
            DisplayGroupByLevel(team);
            DisplayGroupByRole(team);
            DisplayTopExperienced(team, 3);
        }
        static List<Developer> CreateTeam()
        {
            return new List<Developer>()
            {
                new Developer("Khuong.Duong", 43, TeamRole.Leader, Project.SPI)
                {
                    YearOfExperience = 20,
                    Level = TechLevel.Senior,
                    IsFullTime = true
                },
                new Developer("Jimmii.Nguyen", 37, TeamRole.Member, Project.SPI)
                {
                    YearOfExperience = 12.0,
                    Level = TechLevel.Senior,
                    IsFullTime = true
                },
                new Developer("Jason.Duong", 27, TeamRole.Member, Project.SPI)
                {
                    YearOfExperience = 3.0,
                    Level = TechLevel.Junior,
                    IsFullTime = true
                },
                new Developer("Alex.Thai", 42, TeamRole.Member, Project.SPI)
                {
                    YearOfExperience = 17.0,
                    Level = TechLevel.Senior,
                    IsFullTime = true
                },
                new Developer("Michael.Kim", 44, TeamRole.Manager, Project.SPI)
                {
                    YearOfExperience = 20,
                    Level = TechLevel.Senior,
                    IsFullTime = true
                },
                new Developer("Minh.Nguyen", 38, TeamRole.Member, Project.AOI)
                {
                    YearOfExperience = 10.0,
                    Level = TechLevel.Senior,
                    IsFullTime = true
                },
                new Developer("Mark.Ngo", 28, TeamRole.Member, Project.AOI)
                {
                    YearOfExperience = 7,
                    Level = TechLevel.Senior,
                    IsFullTime = true
                },
                new Developer("Cyber.Nguyen", 34, TeamRole.Member, Project.AOI)
                {
                    YearOfExperience = 8,
                    Level = TechLevel.Senior,
                    IsFullTime = true
                },
                new Developer("Benjamin.Nguyen", 36, TeamRole.Member, Project.AOI)
                {
                    YearOfExperience = 9,
                    Level = TechLevel.Senior,
                    IsFullTime = true
                },
                new Developer("Christine.Nguyen", 38, TeamRole.Member, Project.AOI)
                {
                    YearOfExperience = 10.0,
                    Level = TechLevel.Senior,
                    IsFullTime = true
                },
                new Developer("Linh.Mai", 40, TeamRole.Member, Project.ReviewStation)
                {
                    YearOfExperience = 17.0,
                    Level = TechLevel.Senior,
                    IsFullTime = true
                },
                new Developer("Sy.Pham", 36, TeamRole.Member, Project.ReviewStation)
                {
                    YearOfExperience = 13.0,
                    Level = TechLevel.Senior,
                    IsFullTime = true
                },
                new Developer("Tom.Pham", 45, TeamRole.Member, Project.ReviewStation)
                {
                    YearOfExperience = 20.0,
                    Level = TechLevel.Senior,
                    IsFullTime = true
                },
                new Developer("Long.Pham", 26, TeamRole.Member, Project.ReviewStation)
                {
                    YearOfExperience = 3.0,
                    Level = TechLevel.Junior,
                    IsFullTime = true
                },
                new Developer("Duc.Hoang", 26, TeamRole.Member, Project.RtoS)
                {
                    YearOfExperience = 3.0,
                    Level = TechLevel.Junior,
                    IsFullTime = true
                },
                new Developer("George.Do", 43, TeamRole.Member, Project.RtoS)
                {
                    YearOfExperience = 18.0,
                    Level = TechLevel.Senior,
                    IsFullTime = true
                },
                new Developer("Harry.Nguyen", 44, TeamRole.Member, Project.RtoS)
                {
                    YearOfExperience = 19.0,
                    Level = TechLevel.Senior,
                    IsFullTime = true
                },
            };
        }
        static void DisplayDeveloperInfo(List<Developer> team)
        {
            for (int i = 0; i < team.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {team[i].Name}");
                Console.WriteLine($"   Position: {team[i].Role}");
                Console.WriteLine($"   Age: {team[i].Age} | Year of Experience: {team[i].YearOfExperience} | Level: {team[i].Level} | Full Time: {team[i].GetFullTimeStatus()}");
                Console.WriteLine();
            }
            Console.WriteLine($"Total Members: {team.Count}");
            Console.WriteLine();
        }

        static void DisplayTeamSummary(List<Developer> team)
        {
            Console.WriteLine("===== TEAM SUMMARY =====");
            Console.WriteLine($"Total: {team.Count}");
                   
            // Roles
            var roles = team.Select(dev => dev.Role).Distinct();
            Console.WriteLine($"Role: {roles.Count()} unique: {string.Join(", ", roles)}"); 

            // Technical levels
            var techLevels = team.Select(dev => dev.Level).Distinct();
            Console.WriteLine($"Technical Level: {techLevels.Count()} unique: {string.Join(", ", techLevels)}");
            

            // Projects
            var projects = team.Select(dev => dev.InvolvedProject).Distinct();
            Console.WriteLine($"\nProject: {projects.Count()} unique: {string.Join(", ", projects)}");
            

            // Experience
            var totalExp = team.Sum(dev => dev.YearOfExperience);
            var avgExp = team.Average(dev => dev.YearOfExperience);
            var minExp = team.Min(dev => dev.YearOfExperience);
            var maxExp = team.Max(dev => dev.YearOfExperience);
            Console.WriteLine($"Experience - Total: {totalExp} | Avg: {avgExp:F1} | Min: {minExp} | Max: {maxExp}");

            // Fulltime
            var fullTimeCount = team.Count(dev=>dev.IsFullTime);
            Console.WriteLine($"Fulltime: {fullTimeCount}/{team.Count}");
        }

        static void DisplayGroupByProject(List<Developer> team)
        {
            Console.WriteLine("===== GROUP BY PROJECT =====");
            var groups = team.GroupBy(dev => dev.InvolvedProject);

            foreach (var group in groups)
            {
                Console.WriteLine($"{group.Key} ({group.Count()})");
                foreach (var dev in group)
                {
                    Console.WriteLine($"     {dev.Name} ({dev.Level}, {dev.YearOfExperience})");
                }
            }
        }

        static void DisplayGroupByLevel(List<Developer> team)
        {
            Console.WriteLine("===== GROUP BY LEVEL =====");
            var groups = team.GroupBy(dev => dev.Level);

            foreach (var group in groups)
            {
                Console.WriteLine($"{group.Key} ({group.Count()}), Avg Experience: {group.Average(g => g.YearOfExperience):F1} years");
                foreach (var dev in group.OrderByDescending(d=>d.YearOfExperience))
                {
                    Console.WriteLine($"     {dev.Name} ({dev.YearOfExperience})");
                }
            }
        }

        static void DisplayGroupByRole(List<Developer> team)
        {
            Console.WriteLine("===== GROUP BY ROLE =====");
            var groups = team.GroupBy(dev => dev.Role);
            foreach (var group in groups)
            {
                Console.WriteLine($"{group.Key} ({group.Count()})");
                foreach (var dev in group)
                {
                    Console.WriteLine($"     {dev.Name} ({dev.Level}, {dev.YearOfExperience} years)");
                }
            }
        }

        static void DisplayTopExperienced(List<Developer> team, int topExp)
        {
            Console.WriteLine($"===== TOP EXPERIENCED =====");
            var topExperienced = team.OrderByDescending(dev => dev.YearOfExperience)
                                        .Take(topExp);
            foreach (var dev in topExperienced)
            {
                Console.WriteLine($"     {dev.Name} - {dev.YearOfExperience} years");
            }
        }

    }
}
