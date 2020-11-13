using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using ReviewLibrary;

namespace Project3
{
    public partial class Login : System.Web.UI.Page
    {
        User objUser;
        Utilities utilities = new Utilities();

        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        private void GetUserLogin(string username)
        {
            objUser = utilities.GetUserByUsername(username);
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                GetUserLogin(txtUsername.Text);
                lblGeneral_Error.Text = "";
                if (string.IsNullOrWhiteSpace(objUser.Username))
                {
                    lblGeneral_Error.Text = "Login failed! Please input a valid username!";
                    return;
                }
                Session["userid"] = objUser.UserID;
                Session["username"] = objUser.Username;
                Session["usertype"] = objUser.UserType;

                Response.Redirect("HomePage.aspx");
            }
            catch (Exception ex)
            {
                lblGeneral_Error.Text = ex.Message;
            }
            
        }

        protected void btnVisit_Click(object sender, EventArgs e)
        {
            Session["username"] = "guest";
            Session["usertype"] = "Visitor";

            Response.Redirect("HomePage.aspx");
        }

        protected void btnRegister_Click(object sender, EventArgs e)
        {
            Response.Redirect("Registration.aspx");
        }
    }
}