namespace Module9
{
    public delegate void OnKeyPressed(char k);
    public class ConsoleReader
    {

        public event OnKeyPressed UserKeyPressed;
        public void StartWaiting()
        {

            Console.WriteLine("Нажмите 1 для сортировки ASC или 2 для сортировки DESC. q для выхода.");
            char k = Console.ReadKey(true).KeyChar;
            if (k.Equals('q') || k.Equals('й'))
            {
                Environment.Exit(0);
            }
            else if (!(k.Equals('1') || k.Equals('2')))
            {
                throw new IllegalKeyException("Нажата неверная клавиша!");
            }
            OnUserKeyPressed(k);
            StartWaiting();

        }
        public void OnUserKeyPressed(char k)
        {
            UserKeyPressed?.Invoke(k);
        }
    }
    public class Program
    {
        
        static List<string> names = new List<string>() { "Паша", "Сева", "Вася", "Анатолий", "Евген" };
        public static void Main(string[] args)
        {
            Console.WriteLine("Задание 1:");
            ThrowExceptionExample.throwExceptions(ThrowExceptionExample.exceptions);
            
            Console.WriteLine("Задание 2:");
            ConsoleReader reader = new ConsoleReader();
            reader.UserKeyPressed += cr_OnUserKeyPressed;
            HandleReader(reader);
        }

        public static void HandleReader(ConsoleReader reader)
        {
            try
            {
                reader.StartWaiting();
            }
            catch (IllegalKeyException e)
            {
                Console.WriteLine(e.Message);
                HandleReader(reader);
            }
        }

        public static void cr_OnUserKeyPressed(char k)
        {
            Console.WriteLine("Вы ввели:" + k);
            names = k.Equals('1') ? names.OrderBy(i => i).ToList()
                : names.OrderByDescending(i => i).ToList();
            foreach (string name in names)
            {
                Console.Write($"{name} ");

            }
            Console.WriteLine();
        }

    }
}