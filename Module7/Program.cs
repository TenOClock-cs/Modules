using Module7;

namespace Module7
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            Product product1 = new Product(1, "Moloko", Measure.Lither);
            Product product2 = new Product(2, "Sugar", Measure.Kilogramm);
            Product product3 = new Product(3, "Korobka", Measure.Unit);
            Product[] products = { product1, product2, product3 };
            ShopDelivery deliverShop = new ShopDelivery("Адрес амгазина");
            HomeDelivery homeDelivery = new("Дом5, кв 100");
            JurCustomer jurcustomer = new(new CustomerData("ООО Матрешка", "+7989", "serious@corp.ru"));
            PhysicalCustomer fizCustomer = new(new CustomerData("Иванов Петрович Гадя", "12345", "sdfsdscd"));
            Order<ShopDelivery, JurCustomer, string> orderTrueJur = 
                new Order<ShopDelivery, JurCustomer, string>(deliverShop, jurcustomer, "1234-YY", "descr");
            Order<HomeDelivery, JurCustomer, string> orderFalseJur = new(homeDelivery, jurcustomer, "1234-YY", "descr");
            Order<HomeDelivery, PhysicalCustomer, int> orderTrueFiz = new(homeDelivery, fizCustomer, 125, "descr");
            orderTrueJur.SendOrder();
            orderFalseJur.SendOrder();
            orderTrueFiz.SendOrder();

        }
    }
}