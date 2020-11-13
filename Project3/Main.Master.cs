using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ReviewLibrary;

namespace Project3
{
    public partial class Main : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["usertype"] != null)
            {
                if (Session["usertype"].ToString() != Constant.GUEST)
                {
                    lblUsername.Visible = true;
                    btnSignOut.Visible = true;
                    lblUsername.Text = "Sign in as " + Session["username"];
                }
                else
                {
                    btnSignUp.Visible = true;
                }
                SetMenu();
            }
            else
            {
                Response.Redirect("Login.aspx");
            }            
        }

        protected void btnSignOut_Click(object sender, EventArgs e)
        {
            Session.Clear();
            Response.Redirect("Login.aspx");
        }

        protected void btnReviews_Click(object sender, EventArgs e)
        {
            Response.Redirect("ViewReviews.aspx");
        }

        protected void btnAddRestaurant_Click(object sender, EventArgs e)
        {            
            Response.Redirect("RestaurantPage.aspx?action=add");            
        }

        protected void btnHome_Click(object sender, EventArgs e)
        {
            Response.Redirect("HomePage.aspx");
        }

        private void SetMenu()
        {            
            switch (Session["usertype"])
            {
                case Constant.REVIEWER:
                    btnAddRestaurant.Visible = true;
                    btnReviews.Visible = true;
                    break;
                case Constant.REPRESENTATIVE:
                    btnAddRestaurant.Visible = true;                    
                    break;
            }
        }

        protected void btnSignUp_Click(object sender, EventArgs e)
        {
            Session.Clear();
            Response.Redirect("Login.aspx");
        }
    }
}