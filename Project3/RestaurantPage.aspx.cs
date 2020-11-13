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
    public partial class RestaurantPage : System.Web.UI.Page
    {
        Utilities utilities = new Utilities();
        string action;
        int userID;
        int representativeID = 0; // restaurant without representative
                
        protected void Page_Load(object sender, EventArgs e)
        {
            if(Session["userid"] != null)
            {
                userID = int.Parse(Session["userid"].ToString());
                action = Request.QueryString["action"];
            }
            else
            {
                Response.Redirect("Login.aspx");
            }

            if (!IsPostBack)
            {
                if (action == "add")
                {
                    lblRestaurantHeading.Text = "Add Restaurant";
                    ShowCategoriesList();
                }
                else
                {
                    hidRestId.Value = Request.QueryString["RestID"];
                    LoadRestaurantInfo(int.Parse(hidRestId.Value));
                    lblRestaurantHeading.Text = "Modify Restaurant";
                }
            }            
        }      

        //Load Restaurant Info to modify
        private void LoadRestaurantInfo(int id)
        {
            Restaurant obj = utilities.GetRestaurantByID(id);
            txtRestaurantName.Text = obj.Name;
            txtAddress.Text = obj.Address;
            txtDescription.Text = obj.Description;
            ddlImageURL.SelectedValue = obj.ImageURL;
            txtOpeningTime.Text = obj.OpeningTime;
            txtPriceRange.Text = obj.PriceRange;
            txtWebsite.Text = obj.Website;
            txtPhone.Text = obj.Phone;

            ShowCategoriesList();
            ddlCategory.ClearSelection();
            ddlCategory.Items.FindByValue(obj.CategoryID.ToString()).Selected = true;
        }

        //Create a restaurant for insert or update
        private Restaurant CreateRestaurantObject(int id)
        {
            Restaurant rest = new Restaurant();
            if (!string.IsNullOrWhiteSpace(hidRestId.Value))
            {
                rest.RestaurantID = int.Parse(hidRestId.Value);
            }
            rest.UserID = representativeID;
            rest.CategoryID = int.Parse(ddlCategory.SelectedValue);
            rest.Name = txtRestaurantName.Text;
            rest.Address = txtAddress.Text;
            rest.ImageURL = ddlImageURL.SelectedValue;
            rest.Description = txtDescription.Text;
            rest.OpeningTime = txtOpeningTime.Text;
            rest.PriceRange = txtPriceRange.Text;
            rest.Website = txtWebsite.Text;
            rest.Phone = txtPhone.Text;

            return rest;
        }

        //Show the list of categories
        private void ShowCategoriesList()
        {
            DataSet ds = utilities.GetCategories();
            if (ds.Tables.Count > 0)
            {
                foreach (DataRow row in ds.Tables[0].Rows)
                {
                    ddlCategory.Items.Add(new ListItem() { Text = row["CategoryName"].ToString(), Value = row["CategoryID"].ToString() });
                }
            }
        }

        private bool ValidateRestaurantObject(Restaurant rest)
        {
            bool hasError = false;
            ClearErrorMessage();
            if (string.IsNullOrWhiteSpace(rest.Name))
            {
                hasError = true;
                lblRestaurantName_Error.Text = "Input name!";
            }
            if (string.IsNullOrWhiteSpace(rest.Address))
            {
                hasError = true;
                lblAddress_Error.Text = "Input address!";
            }
            if (rest.CategoryID == -1)
            {
                hasError = true;
                lblCategory_Error.Text = "Select one category!";
            }
            if (string.IsNullOrWhiteSpace(rest.Description))
            {
                hasError = true;
                lblDescription_Error.Text = "Input description!";
            }            
            return hasError;
        }


        private void ClearErrorMessage()
        {
            lblRestaurantName_Error.Text = "";
            lblAddress_Error.Text = "";
            lblCategory_Error.Text = "";
            lblDescription_Error.Text = "";
            lblGeneral_Error.Text = "";
        }              

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            try
            {
                Restaurant obj;
                int ret = 0;

                // check user role put to Representative
                // set the user is the representative for the restaurant
                if (Constant.REPRESENTATIVE.Equals(Session["usertype"].ToString()))
                {
                    representativeID = userID;
                }
                if (action == "add")
                {
                    obj = CreateRestaurantObject(0);
                    if (!ValidateRestaurantObject(obj))
                    {
                        ret = utilities.InsertRestaurant(obj);
                        // update restId
                        hidRestId.Value = ret.ToString();
                    }
                }
                else
                {
                    obj = CreateRestaurantObject(int.Parse(hidRestId.Value));
                    if (!ValidateRestaurantObject(obj))
                    {
                        ret = utilities.UpdateRestaurant(obj);
                    }
                }

                if (ret >= 1)
                {
                    Response.Redirect("ViewRestaurant.aspx?RestID=" + hidRestId.Value);
                }
                else if (ret == -1)
                {
                    lblGeneral_Error.Text = "Cannot insert restaurant!";
                }
            }
            catch (Exception ex)
            {
                lblGeneral_Error.Text = ex.Message;
            }
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            if (action == "add")
            {
                Response.Redirect("HomePage.aspx");
            }
            else
            {
                Response.Redirect("ViewRestaurant.aspx?RestID=" + hidRestId.Value);
            }
        }
    }
}