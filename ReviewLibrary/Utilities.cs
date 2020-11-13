using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;
using System.Data.SqlClient;
using System.Web.UI;

namespace ReviewLibrary
{
    public class Utilities
    {
        DBConnect objDB = new DBConnect();

        //Get the list of Reviews of a restaurant
        public DataSet GetReviewsByRestID(int id)
        {
            SqlCommand objCommand = new SqlCommand();
            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.CommandText = "GetReviewsByRestID";

            //set value for input parameter
            SqlParameter inputParam = new SqlParameter("@theID", id);
            inputParam.Direction = ParameterDirection.Input;
            inputParam.SqlDbType = SqlDbType.Int;
            inputParam.Size = 4;
            objCommand.Parameters.Add(inputParam);

            DataSet resultDS = objDB.GetDataSetUsingCmdObj(objCommand);
            return resultDS;
        }

        //Get the list of Reservation of a restaurant
        public DataSet GetReservationsByRestID(int id)
        {
            SqlCommand objCommand = new SqlCommand();
            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.CommandText = "GetReservationsByRestID";

            //set value for input parameter
            SqlParameter inputParam = new SqlParameter("@theID", id);
            inputParam.Direction = ParameterDirection.Input;
            inputParam.SqlDbType = SqlDbType.Int;
            inputParam.Size = 4;
            objCommand.Parameters.Add(inputParam);

            DataSet resultDS = objDB.GetDataSetUsingCmdObj(objCommand);
            return resultDS;
        }

        // Count reservation of restaurant
        public int CountReservationByRestID(int id)
        {
            int result = 0;
            DataSet dataSet = GetReservationsByRestID(id);
            if (dataSet.Tables.Count > 0)
            {
                result = dataSet.Tables[0].Rows.Count;
            }
            return result;
        }

        //Get the list of all Restaurants
        public DataSet GetRestaurants()
        {
            SqlCommand objCommand = new SqlCommand();
            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.CommandText = "GetRestaurants";            

            DataSet resultDS = objDB.GetDataSetUsingCmdObj(objCommand);
            return resultDS;
        }

        //Get the list of Reviews of a user
        public DataSet GetReviewsByUserID(int id)
        {
            SqlCommand objCommand = new SqlCommand();
            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.CommandText = "GetReviewsByUserID";

            //set value for input parameter
            SqlParameter inputParam = new SqlParameter("@theID", id);
            inputParam.Direction = ParameterDirection.Input;
            inputParam.SqlDbType = SqlDbType.Int;
            inputParam.Size = 4;
            objCommand.Parameters.Add(inputParam);

            DataSet resultDS = objDB.GetDataSetUsingCmdObj(objCommand);
            return resultDS;
        }

        //Get a review by id
        public Review GetReviewByID(int id)
        {
            Review rev = new Review();
            SqlCommand objCommand = new SqlCommand();
            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.CommandText = "GetReviewByID";

            //set value for input parameter
            SqlParameter inputParam = new SqlParameter("@theID", id);
            inputParam.Direction = ParameterDirection.Input;
            inputParam.SqlDbType = SqlDbType.Int;
            inputParam.Size = 4;
            objCommand.Parameters.Add(inputParam);

            DataSet resultDS = objDB.GetDataSetUsingCmdObj(objCommand);
            if (resultDS.Tables.Count > 0)
            {
                foreach (DataRow row in resultDS.Tables[0].Rows)
                {
                    rev.ReviewID = int.Parse(row["ReviewID"].ToString());
                    rev.UserID = int.Parse(row["UserID"].ToString());
                    rev.RestaurantID = int.Parse(row["RestaurantID"].ToString());
                    rev.RestaurantName = row["Name"].ToString();
                    rev.FoodRating = int.Parse(row["FoodRating"].ToString());
                    rev.ServiceRating = int.Parse(row["ServiceRating"].ToString());
                    rev.AtmosphereRating = int.Parse(row["AtmosphereRating"].ToString());
                    rev.PriceRating = int.Parse(row["PriceRating"].ToString());
                    rev.Comments = row["Comments"].ToString();                    
                }
            }

            return rev;
        }

        //Get a reservation by id
        public Reservation GetReservationByID(int id)
        {
            Reservation res = new Reservation();
            SqlCommand objCommand = new SqlCommand();
            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.CommandText = "GetReservationByID";

            //set value for input parameter
            SqlParameter inputParam = new SqlParameter("@theID", id);
            inputParam.Direction = ParameterDirection.Input;
            inputParam.SqlDbType = SqlDbType.Int;
            inputParam.Size = 4;
            objCommand.Parameters.Add(inputParam);

            DataSet resultDS = objDB.GetDataSetUsingCmdObj(objCommand);
            if (resultDS.Tables.Count > 0)
            {
                foreach (DataRow row in resultDS.Tables[0].Rows)
                {
                    res.ReservationID = int.Parse(row["ReservationID"].ToString());
                    res.RestaurantID = int.Parse(row["RestaurantID"].ToString());                    
                    res.ReservationName = row["ReservationName"].ToString();
                    res.ReservationTime = DateTime.Parse(row["ReservationTime"].ToString());
                    res.Phone = row["Phone"].ToString();
                }
            }

            return res;
        }

        //Get the list of categories
        public DataSet GetCategories()
        {
            SqlCommand objCommand = new SqlCommand();
            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.CommandText = "GetCategories";

            DataSet resultDS = objDB.GetDataSetUsingCmdObj(objCommand);
            return resultDS;
        }

        //Get the result of search restaurant()
        public DataSet GetSearchRestaurant(string search, int cateID)
        {
            SqlCommand objCommand = new SqlCommand();
            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.CommandText = "SearchRestaurant";

            //set value for input parameter
            SqlParameter inputParam = new SqlParameter("@theID", cateID);
            inputParam.Direction = ParameterDirection.Input;
            inputParam.SqlDbType = SqlDbType.Int;
            inputParam.Size = 4;
            objCommand.Parameters.Add(inputParam);

            inputParam = new SqlParameter("@theSearch", search);
            inputParam.Direction = ParameterDirection.Input;
            inputParam.SqlDbType = SqlDbType.VarChar;
            inputParam.Size = 70;
            objCommand.Parameters.Add(inputParam);

            DataSet resultDS = objDB.GetDataSetUsingCmdObj(objCommand);
            return resultDS;
        }

        //Get a restaurant by ID
        public Restaurant GetRestaurantByID(int id)
        {
            Restaurant rest = new Restaurant();
            SqlCommand objCommand = new SqlCommand();            
            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.CommandText = "GetRestaurantByID";

            //set value for input parameter
            SqlParameter inputParam = new SqlParameter("@theID", id);
            inputParam.Direction = ParameterDirection.Input;
            inputParam.SqlDbType = SqlDbType.Int;
            inputParam.Size = 4;
            objCommand.Parameters.Add(inputParam);

            DataSet resultDS = objDB.GetDataSetUsingCmdObj(objCommand);
            if (resultDS.Tables.Count > 0)
            {
                foreach (DataRow row in resultDS.Tables[0].Rows)
                {
                    rest.RestaurantID = int.Parse(row["RestaurantID"].ToString());
                    if (row["UserID"].ToString() != "") rest.UserID = int.Parse(row["UserID"].ToString());
                    else rest.UserID = -1;
                    rest.CategoryID = int.Parse(row["CategoryID"].ToString());
                    rest.Name = row["Name"].ToString();
                    rest.Address = row["Address"].ToString();
                    rest.ImageURL = row["ImageURL"].ToString();
                    rest.Description = row["Description"].ToString();
                    rest.OpeningTime = row["OpeningTime"].ToString();
                    rest.PriceRange = row["PriceRange"].ToString();
                    rest.Website = row["Website"].ToString();
                    rest.Phone = row["Phone"].ToString();
                }
            }

            return rest;
        }       

        // Get user by username
        public User GetUserByUsername(string username)
        {
            User user = new User();

            SqlCommand objCommand = new SqlCommand();
            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.CommandText = "GetUserByUsername";

            //set value for input parameter
            SqlParameter inputParam = new SqlParameter("@theUsername", username);
            inputParam.Direction = ParameterDirection.Input;
            inputParam.SqlDbType = SqlDbType.VarChar;
            inputParam.Size = 20;
            objCommand.Parameters.Add(inputParam);

            DataSet resultDS = objDB.GetDataSetUsingCmdObj(objCommand);

            if (resultDS.Tables.Count > 0)
            {
                foreach (DataRow row in resultDS.Tables[0].Rows)
                {
                    user.UserID = int.Parse(row["UserID"].ToString());
                    user.Username = row["Username"].ToString();
                    user.Firstname = row["FirstName"].ToString();
                    user.Lastname = row["LastName"].ToString();
                    user.UserType = row["UserType"].ToString();                    
                }
            }

            return user;
        }

        //Update Restaurant
        public int UpdateRestaurant(Restaurant rest)
        {
            SqlCommand objCommand = new SqlCommand();
            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.CommandText = "UpdateRestaurant";
            ConvertRestaurantToParams(objCommand, rest);
            return objDB.DoUpdateUsingCmdObj(objCommand);            
        }
        
        //Insert Restaurant
        public int InsertRestaurant(Restaurant rest)
        {
            int id = 0;
            SqlCommand objCommand = new SqlCommand();
            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.CommandText = "InsertRestaurant";
            ConvertRestaurantToParams(objCommand, rest);
            SqlParameter outParam = new SqlParameter("@theID", rest.RestaurantID);
            outParam.Direction = ParameterDirection.Output;
            outParam.SqlDbType = SqlDbType.Int;
            outParam.Size = 4;
            objCommand.Parameters.Add(outParam);

            objDB.DoUpdateUsingCmdObj(objCommand);
            if (outParam.Value != DBNull.Value)
            {
                id = Convert.ToInt32(outParam.Value);
            }
            return id;
        }

        //Insert Review
        public int InsertReview(Review review)
        {
            SqlCommand objCommand = new SqlCommand();
            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.CommandText = "InsertReview";
            ConvertReviewToParams(objCommand, review);
            return objDB.DoUpdateUsingCmdObj(objCommand);
        }

        // Assign Representative for user
        public int AssignRestaurantRepresentative(int restaurantId, int userId)
        {
            SqlCommand objCommand = new SqlCommand();
            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.CommandText = "[AssignRestaurantRepresentative]";

            SqlParameter inputParam = new SqlParameter("@theID", restaurantId);
            inputParam.Direction = ParameterDirection.Input;
            inputParam.SqlDbType = SqlDbType.Int;
            inputParam.Size = 4;
            objCommand.Parameters.Add(inputParam);

            inputParam = new SqlParameter("@theUserID", userId);
            inputParam.SqlDbType = SqlDbType.Int;
            inputParam.Size = 4;
            objCommand.Parameters.Add(inputParam);
            return objDB.DoUpdateUsingCmdObj(objCommand);
        }

        //Update Review
        public int UpdateReview(Review review)
        {
            SqlCommand objCommand = new SqlCommand();
            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.CommandText = "UpdateReview";
            ConvertReviewToParams(objCommand, review);
            return objDB.DoUpdateUsingCmdObj(objCommand);
        }

        //Insert Reservation
        public int InsertReservation(Reservation reservation)
        {
            SqlCommand objCommand = new SqlCommand();
            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.CommandText = "InsertReservation";
            ConvertReservationToParams(objCommand, reservation);
            return objDB.DoUpdateUsingCmdObj(objCommand);
        }

        //Update Reseravation
        public int UpdateReservation(Reservation reservation)
        {
            SqlCommand objCommand = new SqlCommand();
            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.CommandText = "UpdateReservation";
            ConvertReservationToParams(objCommand, reservation);
            return objDB.DoUpdateUsingCmdObj(objCommand);
        }

        //Convert Restaurant to params of DB
        private void ConvertRestaurantToParams(SqlCommand objCommand, Restaurant rest)
        {
            //set value for input parameter
            SqlParameter inputParam;
            if (rest.RestaurantID != 0)
            {
                inputParam = new SqlParameter("@theID", rest.RestaurantID);
                inputParam.Direction = ParameterDirection.Input;
                inputParam.SqlDbType = SqlDbType.Int;
                inputParam.Size = 4;
                objCommand.Parameters.Add(inputParam);
            }

            if (rest.UserID != 0)
            {
                // insert user id
                inputParam = new SqlParameter("@theUserID", rest.UserID);
            }
            else
            {
                // insert null value
                inputParam = new SqlParameter("@theUserID", DBNull.Value);
            }
            
            inputParam.Direction = ParameterDirection.Input;
            inputParam.SqlDbType = SqlDbType.Int;
            inputParam.Size = 4;
            objCommand.Parameters.Add(inputParam);

            inputParam = new SqlParameter("@theCateID", rest.CategoryID);
            inputParam.Direction = ParameterDirection.Input;
            inputParam.SqlDbType = SqlDbType.Int;
            inputParam.Size = 4;
            objCommand.Parameters.Add(inputParam);

            inputParam = new SqlParameter("@theName", rest.Name);
            inputParam.Direction = ParameterDirection.Input;
            inputParam.SqlDbType = SqlDbType.VarChar;
            inputParam.Size = 60;
            objCommand.Parameters.Add(inputParam);

            inputParam = new SqlParameter("@theAddress", rest.Address);
            inputParam.Direction = ParameterDirection.Input;
            inputParam.SqlDbType = SqlDbType.VarChar;
            inputParam.Size = 120;
            objCommand.Parameters.Add(inputParam);

            inputParam = new SqlParameter("@theImageURL", rest.ImageURL);
            inputParam.Direction = ParameterDirection.Input;
            inputParam.SqlDbType = SqlDbType.VarChar;
            inputParam.Size = 200;
            objCommand.Parameters.Add(inputParam);

            inputParam = new SqlParameter("@theDescription", rest.Description);
            inputParam.Direction = ParameterDirection.Input;
            inputParam.SqlDbType = SqlDbType.VarChar;
            inputParam.Size = 500;
            objCommand.Parameters.Add(inputParam);

            inputParam = new SqlParameter("@theOpeningTime", rest.OpeningTime);
            inputParam.Direction = ParameterDirection.Input;
            inputParam.SqlDbType = SqlDbType.VarChar;
            inputParam.Size = 120;
            objCommand.Parameters.Add(inputParam);

            inputParam = new SqlParameter("@thePriceRange", rest.PriceRange);
            inputParam.Direction = ParameterDirection.Input;
            inputParam.SqlDbType = SqlDbType.VarChar;
            inputParam.Size = 60;
            objCommand.Parameters.Add(inputParam);

            inputParam = new SqlParameter("@theWebsite", rest.Website);
            inputParam.Direction = ParameterDirection.Input;
            inputParam.SqlDbType = SqlDbType.VarChar;
            inputParam.Size = 200;
            objCommand.Parameters.Add(inputParam);

            inputParam = new SqlParameter("@thePhone", rest.Phone);
            inputParam.Direction = ParameterDirection.Input;
            inputParam.SqlDbType = SqlDbType.VarChar;
            inputParam.Size = 20;
            objCommand.Parameters.Add(inputParam);            
        }
        
        //Convert Review to params of DB
        private void ConvertReviewToParams(SqlCommand objCommand, Review review)
        {
            //set value for input parameter
            SqlParameter inputParam;
            if (review.ReviewID != 0)
            {
                inputParam = new SqlParameter("@theID", review.ReviewID);
                inputParam.Direction = ParameterDirection.Input;
                inputParam.SqlDbType = SqlDbType.Int;
                inputParam.Size = 4;
                objCommand.Parameters.Add(inputParam);
            }

            inputParam = new SqlParameter("@theUserID", review.UserID);
            inputParam.Direction = ParameterDirection.Input;
            inputParam.SqlDbType = SqlDbType.Int;
            inputParam.Size = 4;
            objCommand.Parameters.Add(inputParam);

            inputParam = new SqlParameter("@theRestID", review.RestaurantID);
            inputParam.Direction = ParameterDirection.Input;
            inputParam.SqlDbType = SqlDbType.Int;
            inputParam.Size = 4;
            objCommand.Parameters.Add(inputParam);

            inputParam = new SqlParameter("@theFoodRating", review.FoodRating);
            inputParam.Direction = ParameterDirection.Input;
            inputParam.SqlDbType = SqlDbType.Int;
            inputParam.Size = 4;
            objCommand.Parameters.Add(inputParam);

            inputParam = new SqlParameter("@theServiceRating", review.ServiceRating);
            inputParam.Direction = ParameterDirection.Input;
            inputParam.SqlDbType = SqlDbType.Int;
            inputParam.Size = 4;
            objCommand.Parameters.Add(inputParam);

            inputParam = new SqlParameter("@theAtmosphereRating", review.AtmosphereRating);
            inputParam.Direction = ParameterDirection.Input;
            inputParam.SqlDbType = SqlDbType.Int;
            inputParam.Size = 4;
            objCommand.Parameters.Add(inputParam);

            inputParam = new SqlParameter("@thePriceRating", review.PriceRating);
            inputParam.Direction = ParameterDirection.Input;
            inputParam.SqlDbType = SqlDbType.Int;
            inputParam.Size = 4;
            objCommand.Parameters.Add(inputParam);

            inputParam = new SqlParameter("@theComments", review.Comments);
            inputParam.Direction = ParameterDirection.Input;
            inputParam.SqlDbType = SqlDbType.VarChar;
            inputParam.Size = 300;
            objCommand.Parameters.Add(inputParam);
        }

        //Convert Reservation to params of DB
        private void ConvertReservationToParams(SqlCommand objCommand, Reservation reservation)
        {
            //set value for input parameter
            SqlParameter inputParam;
            if (reservation.ReservationID != 0)
            {
                inputParam = new SqlParameter("@theID", reservation.ReservationID);
                inputParam.Direction = ParameterDirection.Input;
                inputParam.SqlDbType = SqlDbType.Int;
                inputParam.Size = 4;
                objCommand.Parameters.Add(inputParam);
            }

            inputParam = new SqlParameter("@theRestID", reservation.RestaurantID);
            inputParam.Direction = ParameterDirection.Input;
            inputParam.SqlDbType = SqlDbType.Int;
            inputParam.Size = 4;
            objCommand.Parameters.Add(inputParam);

            inputParam = new SqlParameter("@theReservationName", reservation.ReservationName);
            inputParam.Direction = ParameterDirection.Input;
            inputParam.SqlDbType = SqlDbType.VarChar;
            inputParam.Size = 60;
            objCommand.Parameters.Add(inputParam);

            inputParam = new SqlParameter("@theReservationTime", reservation.ReservationTime);
            inputParam.Direction = ParameterDirection.Input;
            inputParam.SqlDbType = SqlDbType.DateTime;
            objCommand.Parameters.Add(inputParam);

            inputParam = new SqlParameter("@thePhone", reservation.Phone);
            inputParam.Direction = ParameterDirection.Input;
            inputParam.SqlDbType = SqlDbType.VarChar;
            inputParam.Size = 20;
            objCommand.Parameters.Add(inputParam);
        }

        //Delete Review
        public int DeleteReviewByID(int id)
        {
            SqlCommand objCommand = new SqlCommand();
            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.CommandText = "DeleteReviewByID";

            //set value for input parameter
            SqlParameter inputParam = new SqlParameter("@theID", id);
            inputParam.Direction = ParameterDirection.Input;
            inputParam.SqlDbType = SqlDbType.Int;
            inputParam.Size = 4;
            objCommand.Parameters.Add(inputParam);

            return objDB.DoUpdateUsingCmdObj(objCommand);
        }

        //Delete Reservation
        public int DeleteReservationByID(int id)
        {
            SqlCommand objCommand = new SqlCommand();
            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.CommandText = "DeleteReservationByID";

            //set value for input parameter
            SqlParameter inputParam = new SqlParameter("@theID", id);
            inputParam.Direction = ParameterDirection.Input;
            inputParam.SqlDbType = SqlDbType.Int;
            inputParam.Size = 4;
            objCommand.Parameters.Add(inputParam);

            return objDB.DoUpdateUsingCmdObj(objCommand);
        }

        //Insert user
        public int InsertUser(User user)
        {
            SqlCommand objCommand = new SqlCommand();
            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.CommandText = "InsertUser";

            //set value for input parameter
            SqlParameter inputParam = new SqlParameter("@theUsername", user.Username);
            inputParam.Direction = ParameterDirection.Input;
            inputParam.SqlDbType = SqlDbType.VarChar;
            inputParam.Size = 20;
            objCommand.Parameters.Add(inputParam);

            inputParam = new SqlParameter("@theFirstname", user.Firstname);
            inputParam.Direction = ParameterDirection.Input;
            inputParam.SqlDbType = SqlDbType.VarChar;
            inputParam.Size = 30;
            objCommand.Parameters.Add(inputParam);

            inputParam = new SqlParameter("@theLastname", user.Lastname);
            inputParam.Direction = ParameterDirection.Input;
            inputParam.SqlDbType = SqlDbType.VarChar;
            inputParam.Size = 30;
            objCommand.Parameters.Add(inputParam);

            inputParam = new SqlParameter("@theUsertype", user.UserType);
            inputParam.Direction = ParameterDirection.Input;
            inputParam.SqlDbType = SqlDbType.VarChar;
            inputParam.Size = 30;
            objCommand.Parameters.Add(inputParam);

            return objDB.DoUpdateUsingCmdObj(objCommand);
        }

    }
}
