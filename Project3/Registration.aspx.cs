using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ReviewLibrary;

namespace Project3
{
    public partial class Registration : System.Web.UI.Page
    {
        Utilities utilities = new Utilities();

        protected void Page_Load(object sender, EventArgs e)
        {
          
        }

        protected void btnRegister_Click(object sender, EventArgs e)
        {
            try
            {
                User user = CreateUserObject();
                if (!ValidateUserObject(user))
                {
                    int ret = utilities.InsertUser(user);
                    if (ret == 1)
                    {
                        Response.Redirect("Login.aspx");
                    }
                    else
                    {
                        lblGeneral_Error.Text = "Cannot create user!";
                    }
                }
            }
            catch (Exception ex)
            {
                lblGeneral_Error.Text = ex.Message;
            }                        
        }

        private void ClearErrorMessage()
        {
            lblFirstName_Error.Text = "";
            lblLastNameID_Error.Text = "";
            lblUserName_Error.Text = "";
            lblUserType_Error.Text = "";
            lblGeneral_Error.Text = "";
        }

        //Valid the input user info
        private bool ValidateUserObject(User user)
        {
            ClearErrorMessage();
            bool hasError = false;

            if (String.IsNullOrWhiteSpace(user.Username))
            {
                lblUserName_Error.Text = "Input username!";
                hasError = true;
            }
            else
            {
                User userDb = utilities.GetUserByUsername(user.Username);
                if (!string.IsNullOrWhiteSpace(userDb.Username))
                {
                    lblUserName_Error.Text = "Username existed!";
                    hasError = true;
                }
            }
            if (String.IsNullOrWhiteSpace(user.Firstname))
            {
                lblFirstName_Error.Text = "Input First Name!";
                hasError = true;
            }
            if (String.IsNullOrWhiteSpace(user.Lastname))
            {
                lblLastNameID_Error.Text = "Input Last Name!";
                hasError = true;
            }
            if (String.IsNullOrWhiteSpace(user.UserType))
            {
                lblUserType_Error.Text = "Select User Type!";
                hasError = true;
            }
            return hasError;
        }

        private User CreateUserObject()
        {
            User user = new User();
            user.Username = txtUsername.Text;
            user.Lastname = txtLastName.Text;
            user.Firstname = txtFirstName.Text;
            string type = "" ;
            if (rdoRepresentative.Checked)
            {
                type = Constant.REPRESENTATIVE;
            }
            else if (rdoReviewer.Checked)
            {
                type = Constant.REVIEWER;
            }
            user.UserType = type;
            return user;
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("Login.aspx");
        }
    }
}