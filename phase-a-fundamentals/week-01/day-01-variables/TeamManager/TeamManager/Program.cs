namespace TeamManager
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Define team member information
            string name1 = "Khuong.Duong";
            int age1 = 44;
            string position1 = "Team Leader";
            int yearOfExperience1 = 20;
            bool isFullTime1 = true;

            string name2 = "Jimmii.Nguyen";
            int age2 = 37;
            string position2 = "Member";
            int yearOfExperience2 = 15;
            bool isFullTime2 = true;

            string name3 = "Jason.Duong";
            int age3 = 26;
            string position3 = "Member";
            int yearOfExperience3 = 3;
            bool isFullTime3 = true;

            string name4 = "Alex.Thai";
            int age4 = 42;
            string position4 = "Team Leader";
            int yearOfExperience4 = 18;
            bool isFullTime4 = true;

            string name5 = "Michael.Kim";
            int age5 = 43;
            string position5 = "Team Manager";
            int yearOfExperience5 = 20;
            bool isFullTime5 = true;

            // Display team member information
            Console.WriteLine("===== TEAM MEMBER LIST =====");
            Console.WriteLine("\n");

            Console.WriteLine($"1. {name1}");
            Console.WriteLine($"Position: {position1}");
            string isFullTimeText1 = isFullTime1 ? "Yes" : "No";
            Console.WriteLine($"Age: {age1} | Experience: {yearOfExperience1} | Fulltime: {isFullTimeText1}\n");

            Console.WriteLine($"2. {name2}");
            Console.WriteLine($"Position: {position2}");
            string isFullTimeText2 = isFullTime2 ? "Yes" : "No";
            Console.WriteLine($"Age: {age2} | Experience: {yearOfExperience2} | Fulltime: {isFullTimeText2}\n");

            Console.WriteLine($"3. {name3}");
            Console.WriteLine($"Position: {position3}");
            string isFullTimeText3 = isFullTime3 ? "Yes" : "No";
            Console.WriteLine($"Age: {age3} | Experience: {yearOfExperience3} | Fulltime: {isFullTimeText3}\n");

            Console.WriteLine($"4. {name4}");
            Console.WriteLine($"Position: {position4}");
            string isFullTimeText4 = isFullTime4 ? "Yes" : "No";
            Console.WriteLine($"Age: {age4} | Experience: {yearOfExperience4} | Fulltime: {isFullTimeText4} \n");

            Console.WriteLine($"5. {name5}");
            Console.WriteLine($"Position: {position5}");
            string isFullTimeText5 = isFullTime5 ? "Yes" : "No";
            Console.WriteLine($"Age: {age5} | Experience: {yearOfExperience5} | Fulltime: {isFullTimeText5} \n");

            Console.WriteLine($"Total team members: 5");
        }
    }
}
