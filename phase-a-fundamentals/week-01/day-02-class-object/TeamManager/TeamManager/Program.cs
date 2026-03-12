namespace TeamManager
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int totalMembers = 5;

            var dev1 = new Developer()
            { 
                Name = "Khuong.Duong",
                Age = 43,
                Position = "Team Leader",
                YearOfExperience = 20,
                IsFullTime = true
            };

            var dev2 = new Developer()
            {
                Name = "Jimmii.Nguyen",
                Age = 37,
                Position = "Member",
                YearOfExperience = 3.0,
                IsFullTime = true
            };

            var dev3 = new Developer()
            {
                Name = "Jason.Duong",
                Age = 27,
                Position = "Member",
                YearOfExperience = 3.0,
                IsFullTime = true
            };

            var dev4 = new Developer()
            {
                Name = "Alex.Thai",
                Age = 42,
                Position = "Member",
                YearOfExperience = 3.0,
                IsFullTime = true
            };

            var dev5 = new Developer()
            {
                Name = "Michael.Kim",
                Age = 44,
                Position = "Manager",
                YearOfExperience = 20,
                IsFullTime = true
            };

            Console.WriteLine($"1. {dev1.Name}");
            Console.WriteLine($"   Position: {dev1.Position}");
            Console.WriteLine($"   Age: {dev1.Age} | Experience: {dev1.YearOfExperience} | Full Time: {dev1.GetFullTimeStatus()}");
            Console.WriteLine();

            Console.WriteLine($"2. {dev2.Name}");
            Console.WriteLine($"   Position: {dev2.Position}");
            Console.WriteLine($"   Age: {dev2.Age} | Experience: {dev2.YearOfExperience} | Full Time: {dev2.GetFullTimeStatus()}");
            Console.WriteLine();            

            Console.WriteLine($"3. {dev3.Name}");
            Console.WriteLine($"   Position: {dev3.Position}");
            Console.WriteLine($"   Age: {dev3.Age} | Experience: {dev3.YearOfExperience} | Full Time: {dev3.GetFullTimeStatus()}");
            Console.WriteLine();

            Console.WriteLine($"4. {dev4.Name}");
            Console.WriteLine($"   Position: {dev4.Position}");
            Console.WriteLine($"   Age: {dev4.Age} | Experience: {dev4.YearOfExperience} | Full Time: {dev4.GetFullTimeStatus()}");
            Console.WriteLine();

            Console.WriteLine($"5. {dev5.Name}");
            Console.WriteLine($"   Position: {dev5.Position}");
            Console.WriteLine($"   Age: {dev5.Age} | Experience: {dev5.YearOfExperience} | Full Time: {dev5.GetFullTimeStatus()}");
            Console.WriteLine();

            Console.WriteLine($"Total Members: {totalMembers}");
            Console.WriteLine();
        }
    }
}
