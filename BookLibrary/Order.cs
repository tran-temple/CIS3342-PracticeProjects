using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookLibrary
{
    public class Order
    {
        private const double HARDCOVER_TYPE_RATE = 0.15; // hardcover price = base price + 15% rate
        private const double PAPERBACK_TYPE_RATE = 0; // paperback price = base price + 0% rate
        private const double EBOOK_TYPE_RATE = 0.3; // e-book price = base price - 30% rate

        private const string HARDCOVER_TYPE = "hardcover";
        private const string PAPERBACK_TYPE = "paperback";
        private const string EBOOK_TYPE = "ebook";

        private const string RENT_OPTION = "Rent"; // rent will less 50% than buy

        public Order()
        {

        }

        public double CalculatePrice(double basePrice, string type, string option)
        {
            double num = 0.0;
            switch (type)
            {
                case HARDCOVER_TYPE:
                    num = basePrice + (basePrice * HARDCOVER_TYPE_RATE);
                    break;
                case PAPERBACK_TYPE:
                    num = basePrice + (basePrice * PAPERBACK_TYPE_RATE);
                    break;
                case EBOOK_TYPE:
                    num = basePrice - (basePrice * EBOOK_TYPE_RATE);
                    break;
            }
            if (option == RENT_OPTION) num = num / 2;
            
            return num;
        }
    }
}
