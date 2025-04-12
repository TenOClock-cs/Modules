using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using Module7;

namespace Module7
{
    internal static class Validator
    {
        public static bool IsValid(string emailAddress) {
            try
            {
                MailAddress m = new MailAddress(emailAddress);

                return true;
            }
            catch (FormatException)
            {
                return false;
            }
        }

        public static bool IsValid(Customer customer, DeliveryType deliveryType) {

            return customer.CustomerType == CustomerType.Fiz || (customer.CustomerType == CustomerType.Jur && deliveryType.GetType().Name != "HomeDelivery");
            
        }
    }
}
