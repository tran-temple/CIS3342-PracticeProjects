using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReviewLibrary
{
    public class Review
    {
        //properties
        private int reviewID;
        private int userID;
        private int restaurantID;
        private string restaurantName;
        private int foodRating;
        private int serviceRating;
        private int atmosphereRating;
        private int priceRating;
        private string comments;
        private DateTime reviewDate;

        public Review()
        {

        }

        // Encapsulate fields
        public int ReviewID { get => reviewID; set => reviewID = value; }
        public int UserID { get => userID; set => userID = value; }
        public int RestaurantID { get => restaurantID; set => restaurantID = value; }
        public string RestaurantName { get => restaurantName; set => restaurantName = value; }
        public int FoodRating { get => foodRating; set => foodRating = value; }
        public int ServiceRating { get => serviceRating; set => serviceRating = value; }
        public int AtmosphereRating { get => atmosphereRating; set => atmosphereRating = value; }
        public int PriceRating { get => priceRating; set => priceRating = value; }
        public string Comments { get => comments; set => comments = value; }
        public DateTime ReviewDate { get => reviewDate; set => reviewDate = value; }
    }
}
