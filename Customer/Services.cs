using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Custoemr
{
    internal class Services
    {
        public string ServiceType { get; set; }
        public string Size { get; set; }
        public double FeesPerUnit { get; set; }
        public double? Discount { get; set; }
        public int? MinQuantity { get; set; }

        public Services(string serviceType, string size, double feesPerUnit, double discount, int minQuantity)
        {
            ServiceType = serviceType;
            Size = size;
            FeesPerUnit = feesPerUnit;
            Discount = discount;
            MinQuantity = minQuantity;
        }

        public double CalculatePrice(int quantity, bool isUrgent)
        {
            double price = FeesPerUnit * quantity;

            // Apply discount if quantity meets minimum requirement
            if (quantity >= MinQuantity)
            {
                price -= price * Discount.Value;
            }

            // Apply urgent fee
            if (isUrgent)
            {
                price += price*0.3; 
            }

            return price;
        }


    }
}
