using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using ReviewLibrary;

namespace Project3
{
    public partial class ReviewPage : System.Web.UI.Page
    {
        Utilities utilities = new Utilities();
        string action;
        int userID;
        int restID;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["userid"] != null)
            {
                userID = int.Parse(Session["userid"].ToString());
                action = Request.QueryString["action"];
                restID = int.Parse(Request.QueryString["RestID"]);
            }
            else
            {
                Response.Redirect("Login.aspx");
            }

            if (!IsPostBack)
            {
                Restaurant obj = utilities.GetRestaurantByID(restID);
                hidRestID.Value = restID.ToString();
                lblRestaurantName.Text = obj.Name;

                if (action == "add")
                {
                    lblReviewHeading.Text = "Add Review";
                }
                else
                {
                    int revID = int.Parse(Request.QueryString["RevID"]);
                    hidReviewID.Value = revID.ToString();
                    LoadReview(revID);
                    lblReviewHeading.Text = "Modify Review";
                }
            }
        }

        //Load info to modify
        private void LoadReview(int id)
        {
            Review obj = utilities.GetReviewByID(id);
            rblFoodRating.SelectedValue = obj.FoodRating.ToString();
            rblServiceRating.SelectedValue = obj.ServiceRating.ToString();
            rblAtmosphereRating.SelectedValue = obj.AtmosphereRating.ToString();
            rblPriceRating.SelectedValue = obj.PriceRating.ToString();
            txtComments.Text = obj.Comments;
        }

        //Create a review for insert or update
        private Review CreateReviewObject(int id)
        {
            Review rev = new Review();
            rev.ReviewID = id;
            rev.RestaurantID = int.Parse(hidRestID.Value);
            rev.UserID = userID;
            rev.FoodRating = int.Parse(rblFoodRating.SelectedValue);
            rev.ServiceRating = int.Parse(rblServiceRating.SelectedValue);
            rev.AtmosphereRating = int.Parse(rblAtmosphereRating.SelectedValue);
            rev.PriceRating = int.Parse(rblPriceRating.SelectedValue);
            rev.Comments = txtComments.Text;
            return rev;
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            try
            {
                Review obj;
                int ret;
                if (InvalidReview())
                {
                    return;
                }
                if (action == "add")
                {
                    obj = CreateReviewObject(0);
                    ret = utilities.InsertReview(obj);
                }
                else
                {
                    obj = CreateReviewObject(int.Parse(hidReviewID.Value));
                    ret = utilities.UpdateReview(obj);
                }

                if (ret == 1)
                {
                    Response.Redirect("ViewReviews.aspx");

                }
                else
                {
                    lblGeneralError.Text = "Error happen. Please try later!";
                }
            }
            catch (Exception ex)
            {
                lblGeneralError.Text = ex.Message;
            }
        }

        private void ClearErrorMessages()
        {
            lblFoodRating_Error.Text = "";
            lblServiceRating_Error.Text = "";
            lblAtmosphereRating_Error.Text = "";
            lblPriceRating_Error.Text = "";
            lblComments_Error.Text = "";
        }

        private bool InvalidReview()
        {
            ClearErrorMessages();
            bool hasError = false;
            if (String.IsNullOrWhiteSpace(rblFoodRating.SelectedValue))
            {
                hasError = true;
                lblFoodRating_Error.Text = "Select rating value!";
            }
            if (String.IsNullOrWhiteSpace(rblServiceRating.SelectedValue))
            {
                hasError = true;
                lblServiceRating_Error.Text = "Select rating value!";
            }
            if (String.IsNullOrWhiteSpace(rblAtmosphereRating.SelectedValue))
            {
                hasError = true;
                lblAtmosphereRating_Error.Text = "Select rating value!";
            }
            if (String.IsNullOrWhiteSpace(rblPriceRating.SelectedValue))
            {
                hasError = true;
                lblPriceRating_Error.Text = "Select rating value!";
            }
            if (String.IsNullOrWhiteSpace(txtComments.Text))
            {
                hasError = true;
                lblComments_Error.Text = "Input comments!";
            }
            return hasError;
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            if (action == "add")
            {
                Response.Redirect("ViewRestaurant.aspx?RestID=" + hidRestID.Value);
            }
            else
            {
                Response.Redirect("ViewReviews.aspx");
            }
        }
    }
}