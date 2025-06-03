namespace Module12
{
    public class MainClass
    {
        private static User CheckLogin(string login, List<User> users, ref int faults)
        {
            foreach (var user in users)
            {
                if (login.Equals(user.Login))
                {
                    return user;
                }
            }
            Console.WriteLine("Illegal login");
            faults++;
            if (faults == 3)
            {
                Console.WriteLine("Max attempts reached");
                Environment.Exit(1);
            }

            return null;
        }

        static void ShowAds()
        {
            Console.WriteLine("Посетите наш новый сайт с бесплатными играми free.games.for.a.fool.com");
            // Остановка на 1 с
            Thread.Sleep(1000);

            Console.WriteLine("Купите подписку на МыКомбо и слушайте музыку везде и всегда.");
            // Остановка на 2 с
            Thread.Sleep(2000);

            Console.WriteLine("Оформите премиум-подписку на наш сервис, чтобы не видеть рекламу.");
            // Остановка на 3 с
            Thread.Sleep(3000);
        }

        public static void Main(string[] args)
        {
            List<User> users = new List<User>();
            users.Add(new User("first", "mr. First", false));
            users.Add(new User("second", "mr. Second", false));
            users.Add(new User("third", "mr. Third", true));
            User currentUser = null;
            int loginFault = 0;
            while (currentUser == null)
            {
                Console.WriteLine("Enter your login:");
                String s = Console.ReadLine();
                currentUser = CheckLogin(s, users, ref loginFault);
            }

            if (!currentUser.IsPremium)
            {
                ShowAds();
            }
            else
            {
                Console.WriteLine("You are premium");
            }
        }
}

}