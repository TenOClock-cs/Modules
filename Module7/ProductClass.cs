using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Module7
{
    internal class Product
    {

        private int id;
        private string name;
        private Measure measure;

        public int Id
        {
            get { return this.id; }
        }
        public string Name { get { return this.name; } }

        public Measure Measure { get { return this.measure; } }

        public Product(int id, string name, Measure measure)
        {
            this.id = id;
            this.name = name;
            this.measure = measure;
        }
    }

    enum Measure
    {
        Lither,
        Kilogramm,
        Unit
    }
}
