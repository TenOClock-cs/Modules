using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Xml.Schema;

namespace Task1
{
    class Program
    {
        static void Main(string[] args)
        {
            var classes = new []
            {
                new Classroom { Students = {"Evgeniy", "Sergey", "Andrew"}, },
                new Classroom { Students = {"Anna", "Viktor", "Vladimir"}, },
                new Classroom { Students = {"Bulat", "Alex", "Galina"}, }
            };
            var allStudents = GetAllStudents(classes);
         
            Console.WriteLine(string.Join(" ", allStudents));
        }
 
        static string [] GetAllStudents( Classroom [] classes )
        {
            return classes.Select(x => x.Students).SelectMany(s => s).ToArray();
        }
      
        public class Classroom
        {
            public List<string> Students = new List<string>();
        }
    }
}