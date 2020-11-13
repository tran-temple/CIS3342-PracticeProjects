using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using ReviewLibrary;
using System.Data;

namespace Project3
{
    public partial class ViewRestaurant : System.Web.UI.Page
    {
        Utilities utilities = new Utilities();
        int restID;
        protected void Page_Load(object sender, EventArgs e)
        {
            //Get restaurant ID from URL
            restID = int.Parse(Request.QueryString["RestID"]);

            if (!IsPostBack)
            {
                ShowRestaurantProfile(restID);
                ShowReviews(restID);                
            }
        }

        //Show the Restaurant Profile
        private void ShowRestaurantProfile(int id)
        {
            Restaurant obj = utilities.GetRestaurantByID(id);
            LoadRating(id);
            SetOperations(obj);

            imgRestaurant.ImageUrl = "images/" + obj.ImageURL;
            lblDescription.Text = obj.Description;
            lblName.Text = obj.Name;
            lblAddress.Text = obj.Address;
            lblOpeningTime.Text = obj.OpeningTime;
            lblPriceRange.Text = obj.PriceRange;
            lblWebsite.Text = obj.Website;
            lblPhone.Text = obj.Phone;

            // load number of reservations
            int numOfReservation = utilities.CountReservationByRestID(id);
            lblNumOfReservation.Text = numOfReservation.ToString();
        }

        // calculate rating and show
        private void LoadRating(int id)
        {
            float foodRating = 0;
            float serviceRating = 0;
            float atmosphereRating = 0;
            float priceRating = 0;
            int totalRating = 0;
            DataSet dataSource = utilities.GetReviewsByRestID(id);

            if (dataSource.Tables.Count > 0)
            {
                foreach (DataRow row in dataSource.Tables[0].Rows) {
                    foodRating += float.Parse(row["FoodRating"].ToString());
                    serviceRating += float.Parse(row["ServiceRating"].ToString());
                    atmosphereRating += float.Parse(row["AtmosphereRating"].ToString());
                    priceRating += float.Parse(row["PriceRating"].ToString());
                    totalRating++;
                }
            }
            if (totalRating > 0)
            {
                foodRating = foodRating / totalRating;
                serviceRating = serviceRating / totalRating;
                atmosphereRating = atmosphereRating / totalRating;
                priceRating = priceRating / totalRating;
            }
            lblFoodRate.Text = foodRating.ToString("0.0");
            lblServiceRate.Text = serviceRating.ToString("0.0"); 
            lblAtmosphereRate.Text = atmosphereRating.ToString("0.0");
            lblPriceRate.Text = priceRating.ToString("0.0");
        }

        //Show the reviews list of a restaurant
        private void ShowReviews(int id)
        {
            rptReviews.DataSource = utilities.GetReviewsByRestID(id);
            rptReviews.DataBind();
        }

        //Set Operations depending on user type
        private void SetOperations(Restaurant restaurant)
        {
            if (Constant.REVIEWER.Equals(Session["usertype"].ToString()))
            {
                btnAddReview.Visible = true;
            }

            // show Assign Representative button
            if (Constant.REPRESENTATIVE.Equals(Session["usertype"].ToString()) && restaurant.UserID == -1)
            {
                btnAssignRepresentative.Visible = true;
            }

            // show the user is the representative
            if (Constant.REPRESENTATIVE.Equals(Session["usertype"].ToString()) && restaurant.UserID.ToString().Equals(Session["userid"].ToString()))
            {
                lblRole.Text = "You are the " + Constant.REPRESENTATIVE + " for this restaurant.";
                btnModifyRest.Visible = true;
                btnReservation.Visible = true;
            }
        }

        protected void btnAddReview_Click(object sender, EventArgs e)
        {
            Response.Redirect("ReviewPage.aspx?RestID=" + restID + "&action=add");
        }

        protected void btnModifyRest_Click(object sender, EventArgs e)
        {
            Response.Redirect("RestaurantPage.aspx?RestID=" + restID + "&action=modify");
        }

        protected void btnReserve_Click(object sender, EventArgs e)
        {
            Response.Redirect("ReservationPage.aspx?RestID=" + restID + "&action=add");
        }

        protected void btnReservation_Click(object sender, EventArgs e)
        {
            Response.Redirect("ViewReservations.aspx?RestID=" + restID);
        }

        protected void btnAssignRepresentative_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(Session["userid"].ToString()))
            {
                int userID = int.Parse(Session["userid"].ToString());
                int ret = utilities.AssignRestaurantRepresentative(restID, userID);
                lblRole.Text = "";
                lblGeneral_Error.Text = "";
                if (ret > 0)
                {
                    // update successful
                    btnAssignRepresentative.Visible = false;
                    btnModifyRest.Visible = true;
                    btnReservation.Visible = true;
                    lblRole.Text = "You are the " + Constant.REPRESENTATIVE + " for this restaurant.";
                }
                else
                {
                    // have error when updating the data
                    lblGeneral_Error.Text = "Cannot assign " + Constant.REPRESENTATIVE + ". Please try again later!";
                }
            }
        }
    }
}