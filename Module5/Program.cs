using System;

class Module5
{
    const string ErrorMessage = "Введено неверное или пустое значение. Введите заново:";
    static string[] getArrayFromConsole(int ValCount, string Header)
    {
        string[] result = new string[ValCount];
        for (int i = 0; i < ValCount; i++)
        {
            result[i] = GetStringFromConsole(Header);
        }
        return result;
    }

    static int GetIntFromConsole(string Header)
    {
        Console.WriteLine(Header);
        return int.TryParse(Console.ReadLine(), out int a) ? a : GetIntFromConsole(ErrorMessage);

    }

    static string GetStringFromConsole(string Header)
    {
        Console.WriteLine(Header);
        string result = Console.ReadLine();
        return !String.IsNullOrEmpty(result) ? result : GetStringFromConsole(ErrorMessage);

    }

    static bool GetBoolFromConsole(string Header)
    {
        Console.WriteLine(Header);
        string result = Console.ReadLine();
        return !String.IsNullOrEmpty(result) && (result.Equals("да") || result.Equals("Да") || result.Equals("y") || result.Equals("yes"));
    }

    static (string, string, int, bool, int, string[], int, string[]) NewUser()
    {
        (string Name, string LastName, int Age, bool HasPet, int PetCount, string[] PetNames, int FavColorsCount, string[] FavColorNames) User =
            ("", "", 0, false, 0, Array.Empty<string>(), 0, Array.Empty<string>());
        User.Name = GetStringFromConsole("Введите имя:");
        User.LastName = GetStringFromConsole("Введите фамилию:");
        User.Age = GetIntFromConsole("Введите возраст:");
        User.HasPet = GetBoolFromConsole("Наличие питомца? (Да|y / Нет):");
        if (User.HasPet)
        {
            User.PetCount = GetIntFromConsole("Введите количество питомцев:");
            User.PetNames = User.PetCount > 0 ? getArrayFromConsole(User.PetCount, "Введите имя питомца:") : Array.Empty<string>();
        }
        User.FavColorsCount = GetIntFromConsole("Введите количество любимых цветов:");
        User.FavColorNames = User.FavColorsCount > 0 ? getArrayFromConsole(User.FavColorsCount, "Введите наименование цвета:") : Array.Empty<string>();

        CheckUser(ref User);

        return User;
    }

    static void CheckUser(ref (string Name, string LastName, int Age, bool HasPet, int PetCount, string[] PetNames, int FavColorsCount, string[] FavColorNames) User)
    {
        if (User.Age == 0)
        {
            Console.WriteLine("Возраст пользователя не может быть равен 0.");
            User.Age = GetIntFromConsole("Введите возраст пользователя:");
            CheckUser(ref User);
        }
        if (User.HasPet && User.PetCount == 0)
        {
            Console.WriteLine("Указано наличие питомцев, но их количество равно 0");
            User.HasPet = GetBoolFromConsole("Наличие питомца? (Да|y / Нет):");
            if (User.HasPet)
            {
                User.PetCount = GetIntFromConsole("Введите количество питомцев:");
            }
            CheckUser(ref User);
        }

        if (User.HasPet && User.PetCount != User.PetNames.Length)
        {
            Console.WriteLine("Количество имен питомцев не совпадает с количеством питомцев.");
            User.PetNames = getArrayFromConsole(User.PetCount, "Введите имя питомца:");
            CheckUser(ref User);

        }
        if (User.FavColorsCount != User.FavColorNames.Length)
        {
            Console.WriteLine("Количество названий цветов не совпадает с количеством любимых цветов.");
            User.FavColorNames = getArrayFromConsole(User.FavColorsCount, "Введите название цвета:");
            CheckUser(ref User);
        }

    }

    static void PrintUser((string Name, string LastName, int Age, bool HasPet, int PetCount, string[] PetNames, int FavColorsCount, string[] FavColorNames) User)
    {
        Console.WriteLine("Имя: " + User.Name);
        Console.WriteLine("Фамилия: " + User.LastName);
        Console.WriteLine("Возраст:" + User.Age);
        Console.WriteLine("Наличие питомцев: " + User.HasPet);
        if (User.HasPet)
        {
            Console.WriteLine("Количество питомцев: " + User.PetCount);
            Console.WriteLine("Имена питомцев: " + string.Join(",", User.PetNames));
        }
        Console.WriteLine("Количество любимых цветов: " + User.FavColorsCount);
        if (User.FavColorsCount > 0)
        {
            Console.WriteLine("Любимые цвета: ", string.Join(",", User.FavColorNames));
        }
    }

    public static void Main(string[] args)
    {
        var usr = NewUser();
        PrintUser(usr);
    }
}