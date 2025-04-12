using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Module7;

namespace Module7
{
    class Order<TDelivery, TCustomer, TNumber> where TDelivery : DeliveryType
        where TCustomer : Customer

    {
        public TDelivery DeliveryType;

        public TCustomer Customer;

        public TNumber Number;

        public string Description;

        public Product[] Products;

        public Order(TDelivery deliveryType, TCustomer customer, TNumber number, string description)
        {
            DeliveryType = deliveryType;
            Customer = customer;
            Number = number;
            Description = description;
        }

        public void SendOrder()
        {
            if (Validator.IsValid(Customer, DeliveryType))
            {
                Console.WriteLine($"Заказ {Number} успешно отправлен {Customer.toString()} на адрес: {DeliveryType.Address}." +
                    $"Нужен курьер: {DeliveryType.UseCourier}");
            }
            else { Console.WriteLine("Заказ не прошел валидацию"); }
        }
        public void DisplayAddress()
        {
            Console.WriteLine(DeliveryType.Address);
        }

    }
}
