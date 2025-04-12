using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Module7
{
    internal abstract class DeliveryType
    {
        private string address;
        protected bool useCourier;
        public string Address { get => this.address; }

        public bool UseCourier { get => this.useCourier; }
        protected DeliveryType(string address)
        {
            this.address = address;
        }
    }

    internal class HomeDelivery : DeliveryType
    {


        public HomeDelivery(string address) : base(address)
        {

            this.useCourier = true;
        }
    }

    internal class PickPointDelivery : DeliveryType
    {
        public PickPointDelivery(string address) : base(address)
        {
            this.useCourier = true;
        }
    }

    internal class ShopDelivery : DeliveryType
    {
        public ShopDelivery(string address) : base(address)
        {
            {

                this.useCourier = false;
            }
        }


    }
}
