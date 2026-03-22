
namespace TeamManager
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var team = CreateTeam();

            //===== TEAM MEMBER LIST =====
            DisplayDeveloperInfo(team);

            var skillMaps = BuildSkillDictionary(team);
            DisplaySkillMatrix(skillMaps);
            FindDeveloperBySkill(skillMaps, "VB6");
            DisplaySkillOfEachDeveloper(team);
            Console.WriteLine();
        }
        static List<Developer> CreateTeam()
        {
            return new List<Developer>()
            {
                new Developer("Khuong.Duong", 43, TeamRole.Leader, Project.SPI)
                {
                    YearOfExperience = 20,
                    Level = TechLevel.Senior,
                    IsFullTime = true,
                    Skills = new List<string>() { "VB6", "WPF", "ASP.NET", "C#" }
                },
                new Developer("Jimmii.Nguyen", 37, TeamRole.Member, Project.SPI)
                {
                    YearOfExperience = 12.0,
                    Level = TechLevel.Senior,
                    IsFullTime = true,
                    Skills = new List<string>() { "VB6", "C#", "ASP.NET", "C++" }
                },
                new Developer("Jason.Duong", 27, TeamRole.Member, Project.SPI)
                {
                    YearOfExperience = 3.0,
                    Level = TechLevel.Junior,
                    IsFullTime = true,
                    Skills = new List<string>() { "VB6", "C#", "WPF", "Python" }
                },
                new Developer("Alex.Thai", 42, TeamRole.Member, Project.SPI)
                {
                    YearOfExperience = 17.0,
                    Level = TechLevel.Senior,
                    IsFullTime = true,
                    Skills = new List<string>() { "VB6", "C#", "WPF", "Java" }
                },
                new Developer("Michael.Kim", 44, TeamRole.Manager, Project.SPI)
                {
                    YearOfExperience = 20,
                    Level = TechLevel.Senior,
                    IsFullTime = true,
                    Skills = new List<string>() { "Project Management", "Agile", "Scrum", "Leadership", "VB6", "WPF" }
                },
                new Developer("Minh.Nguyen", 38, TeamRole.Member, Project.AOI)
                {
                    YearOfExperience = 10.0,
                    Level = TechLevel.Senior,
                    IsFullTime = true,
                    Skills = new List<string>() { "C++", "MFC", "Socket Programming", "Python", "OpenCV" }
                },
                new Developer("Mark.Ngo", 28, TeamRole.Member, Project.AOI)
                {
                    YearOfExperience = 7,
                    Level = TechLevel.Senior,
                    IsFullTime = true,
                    Skills = new List<string>() { "C++", "MFC", "OpenCV", "Python", "Socket Programming" }
                },
                new Developer("Cyber.Nguyen", 34, TeamRole.Member, Project.AOI)
                {
                    YearOfExperience = 8,
                    Level = TechLevel.Senior,
                    IsFullTime = true,
                    Skills = new List<string>() { "C++", "MFC", "OpenCV", "Python" }
                },
                new Developer("Benjamin.Nguyen", 36, TeamRole.Member, Project.AOI)
                {
                    YearOfExperience = 9,
                    Level = TechLevel.Senior,
                    IsFullTime = true,
                    Skills = new List<string>() { "C++", "MFC", "OpenCV", "Python" }
                },
                new Developer("Christine.Nguyen", 38, TeamRole.Member, Project.AOI)
                {
                    YearOfExperience = 10.0,
                    Level = TechLevel.Senior,
                    IsFullTime = true,
                    Skills = new List<string>() { "Automation Test", "Ranorex", "C#", "Python" }
                },
                new Developer("Linh.Mai", 40, TeamRole.Member, Project.ReviewStation)
                {
                    YearOfExperience = 17.0,
                    Level = TechLevel.Senior,
                    IsFullTime = true,
                    Skills = new List<string>() { "C#", "WPF", "SQL", "Python" }
                },
                new Developer("Sy.Pham", 36, TeamRole.Member, Project.ReviewStation)
                {
                    YearOfExperience = 13.0,
                    Level = TechLevel.Senior,
                    IsFullTime = true,
                    Skills = new List<string>() { "C#", "WPF", "SQL", "Python" }
                },
                new Developer("Tom.Pham", 45, TeamRole.Member, Project.ReviewStation)
                {
                    YearOfExperience = 20.0,
                    Level = TechLevel.Senior,
                    IsFullTime = true,
                    Skills = new List<string>() { "C#", "WPF", "SQL", "Python" }
                },
                new Developer("Long.Pham", 26, TeamRole.Member, Project.ReviewStation)
                {
                    YearOfExperience = 3.0,
                    Level = TechLevel.Junior,
                    IsFullTime = true,
                    Skills = new List<string>() { "C#", "WPF", "SQL", "Python", "OpenCV" }
                },
                new Developer("Duc.Hoang", 26, TeamRole.Member, Project.RtoS)
                {
                    YearOfExperience = 3.0,
                    Level = TechLevel.Junior,
                    IsFullTime = true,
                    Skills = new List<string>() { "C#", "WPF", "SQL", "Python", "OpenCV" }
                },
                new Developer("George.Do", 43, TeamRole.Member, Project.RtoS)
                {
                    YearOfExperience = 18.0,
                    Level = TechLevel.Senior,
                    IsFullTime = true,
                    Skills = new List<string>() { "C#", ".NET", "ASP.NET", "Python" }
                },
                new Developer("Harry.Nguyen", 44, TeamRole.Member, Project.RtoS)
                {
                    YearOfExperience = 19.0,
                    Level = TechLevel.Senior,
                    IsFullTime = true,
                    Skills = new List<string>() { "C#", "WPF", "SQL", "Python", "ASP.NET", "Microservice" }
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

        // Build a dictionary where key is skill and value is list of developers with that skill
        static Dictionary<string, List<Developer>> BuildSkillDictionary(List<Developer> team)
        {
            var skillMap = new Dictionary<string, List<Developer>>();
            
            foreach (var dev in team)
            {
                foreach (var skill in dev.Skills)
                {
                    if (!skillMap.ContainsKey(skill))
                    {
                        skillMap[skill] = new List<Developer>();
                    }
                    skillMap[skill].Add(dev);
                }
            }
            return skillMap;
        }

        static void DisplaySkillMatrix(Dictionary<string, List<Developer>> skillMap)
        {
            Console.WriteLine("===== SKILL MATRIX =====");
            foreach (var skill in skillMap.OrderByDescending(s => s.Value.Count))
            {
                Console.WriteLine($"{skill.Key} ({skill.Value.Count} developers): ");
                foreach (var dev in skill.Value)
                {
                    var names = skill.Value.Select(dev => dev.Name);
                    Console.WriteLine($"     {string.Join(", ", names)}");
                }
            }
        }

        static void FindDeveloperBySkill(Dictionary<string, List<Developer>> skillMap, string skill)
        {
            Console.WriteLine("===== FIND DEVELOPER BY SKILL =====");
            Developer developer = null;

            if (skillMap.TryGetValue(skill, out var developers))
            {
                Console.WriteLine($"Found: {developers.Count} developers has skill {skill}:");
                foreach (var dev in developers)
                {
                    Console.WriteLine($"     - {dev.Name} ({dev.InvolvedProject}, {dev.Level})");
                }
            }
            else
                Console.WriteLine($"Cannot find any \"{skill}\" developer.");
        }

        static void DisplaySkillOfEachDeveloper(List<Developer> team)
        {
            Console.WriteLine("===== SKILL OF EACH DEVELOPER =====");
            foreach (var dev in team.OrderByDescending(dev => dev.Skills.Count))
            {
                Console.WriteLine($"{dev.Name} : {dev.Skills.Count} skills ({string.Join(", ", dev.Skills)})");
            }
        }
    }
}
