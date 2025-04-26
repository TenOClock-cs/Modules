using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module9
{
    internal class ThrowExceptionExample
    {
        public static List<Exception> exceptions = new List<Exception>(){ new ArgumentException("Неверный аргумент"),
        new ArgumentOutOfRangeException("Аргумент за пределами"), new FileNotFoundException("Файл не найден"),
        new TimeoutException("Таймаут операции"), new IllegalKeyException("Нажата неверная клавиша")};


        public static void throwExceptions(List<Exception> ex)
        {

            foreach (Exception e in ex)
            {
                try
                {
                    throw e;
                }
                catch (Exception e2)
                {
                    Console.WriteLine(e2.GetType() + " Сообщение: " + e.Message);
                }
            }
        }
    }
}
