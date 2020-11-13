using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReviewLibrary
{
    public class Restaurant
    {
        //properties
        private int restaurantID;
        private int userID;
        private int categoryID;
        private string name;
        private string address;
        private string imageURL;
        private string description;
        private string openingTime;
        private string priceRange;
        private string website;
        private string phone;

        public Restaurant()
        {

        }

        // Encapsulate fields
        public int RestaurantID { get => restaurantID; set => restaurantID = value; }
        public int UserID { get => userID; set => userID = value; }
        public int CategoryID { get => categoryID; set => categoryID = value; }
        public string Name { get => name; set => name = value; }
        public string Address { get => address; set => address = value; }
        public string ImageURL { get => imageURL; set => imageURL = value; }
        public string Description { get => description; set => description = value; }
        public string OpeningTime { get => openingTime; set => openingTime = value; }
        public string PriceRange { get => priceRange; set => priceRange = value; }
        public string Website { get => website; set => website = value; }
        public string Phone { get => phone; set => phone = value; }        
    }
}
