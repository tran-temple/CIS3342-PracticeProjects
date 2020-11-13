using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReviewLibrary
{
    public class Reservation
    {
        //properties
        private int reservationID;
        private int restaurantID;
        private string reservationName;
        private DateTime reservationTime;
        private string phone;

        public Reservation()
        {

        }

        // Encapsulate fields
        public int ReservationID { get => reservationID; set => reservationID = value; }
        public int RestaurantID { get => restaurantID; set => restaurantID = value; }
        public string ReservationName { get => reservationName; set => reservationName = value; }
        public DateTime ReservationTime { get => reservationTime; set => reservationTime = value; }
        public string Phone { get => phone; set => phone = value; }
        
    }
}
