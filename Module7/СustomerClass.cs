using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module7
{
    internal abstract class Customer
    {
        internal CustomerData CustomerData;
        protected CustomerType customerType;
        public abstract CustomerType CustomerType { get; }
        protected Customer(CustomerData data) => CustomerData = data;

        public string toString()
        {
            return $"{CustomerData.Name}({CustomerData.Email})";
        }
    }

    internal class PhysicalCustomer : Customer
    {
        public override CustomerType CustomerType { get { return this.customerType; } }
        internal PhysicalCustomer(CustomerData data) : base(data) => customerType = CustomerType.Fiz;
    }

    internal class JurCustomer : Customer
    {
        public override CustomerType CustomerType { get { return this.customerType; } }
        internal JurCustomer(CustomerData data) : base(data) => customerType = CustomerType.Jur;
    }

    class CustomerData
    {
        string name;
        string telephone;
        string email;
        

        public string Name { get { return this.name; } }
        public string Email { get { return this.email; } }

        

        internal CustomerData(string name, string telephone, string email)
        {
            this.name = name;
            this.telephone = telephone;
            if (Validator.IsValid(email)) {
                this.email = email; }
        }
    }
    enum CustomerType
    {
        Jur,
        Fiz

    }
}

