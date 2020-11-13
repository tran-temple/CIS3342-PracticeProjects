using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Data;
using ReviewLibrary;

namespace Project3
{
    public partial class HomePage : System.Web.UI.Page
    {
        Utilities utilities = new Utilities();

        //INDEX of USED columns
        private const int RESTID_COLUMN = 4;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ShowRestaurantsList();
                ShowCategoriesList();
                hidSearchClicked.Value = "false";
            }

        }

        //Show the list of all restaurants
        private void ShowRestaurantsList()
        {
            gvRestaurants.DataSource = utilities.GetRestaurants();
            gvRestaurants.DataBind();
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

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            DataSet ds = utilities.GetSearchRestaurant(txtSearch.Text, int.Parse(ddlCategory.SelectedValue));
            gvRestaurants.DataSource = ds;
            gvRestaurants.DataBind();
            hidSearchClicked.Value = "true";
        }        

        protected void gvRestaurants_SelectedIndexChanged(object sender, EventArgs e)
        {
            Response.Redirect("ViewRestaurant.aspx?RestID=" + gvRestaurants.SelectedRow.Cells[RESTID_COLUMN].Text);
        }

        protected void gvRestaurants_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvRestaurants.PageIndex = e.NewPageIndex;
            if ("true".Equals(hidSearchClicked.Value))
            {
                DataSet ds = utilities.GetSearchRestaurant(txtSearch.Text, int.Parse(ddlCategory.SelectedValue));
                gvRestaurants.DataSource = ds;
                gvRestaurants.DataBind();
            }
            else
            {
                gvRestaurants.DataSource = utilities.GetRestaurants();
                gvRestaurants.DataBind();
            }
        }
    }
}