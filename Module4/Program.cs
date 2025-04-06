using System;
public class Module45
{
    public static void Main(string[] args)
    {
        (string Name, string LastName, string Login, int LoginLength, bool HasPet, string[] favcolors, double Age) User;
        (string, string, string, int, bool, string[], double)[] users = new (string, string, string, int, bool, string[], double)[3];

        for (int i = 0; i < users.Length; i++)
        {
            Console.WriteLine("Введите имя");
            User.Name = Console.ReadLine();
            Console.WriteLine("Введите фамилию");
            User.LastName = Console.ReadLine();
            Console.WriteLine("Введите логин");
            User.Login = Console.ReadLine();
            User.LoginLength = User.Login.Length;
            Console.WriteLine("Есть ли у вас животные. Да / Нет");
            switch (Console.ReadLine())
            {
                case "да":
                    User.HasPet = true; break;
                default:
                    User.HasPet = false; break;
            }
            User.Age = 0;
            while (User.Age == 0)
            {
                Console.WriteLine("Введите возраст");
                User.Age = double.Parse(Console.ReadLine());
            }
            Console.WriteLine("Введите через запятую 3 цвета");
            User.favcolors = Console.ReadLine().Split(",");
            users[i] = User;
        }
        foreach ((string, string, string, int, bool, string[], double) us in users)
        {
            Console.WriteLine(us.ToString());
        }
    }
}