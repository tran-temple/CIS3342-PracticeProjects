using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using ReviewLibrary;
using System.Drawing;
using System.Data;

namespace Project3
{
    public partial class ViewReviews : System.Web.UI.Page
    {
        Utilities utilities = new Utilities();
        int userID;

        // The column index
        private const int REVIEWID_INDEX = 7;
        private const int RESTID_INDEX = 8;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["userid"] != null) userID = int.Parse(Session["userid"].ToString());
            else Response.Redirect("Login.aspx");

            if (!IsPostBack)
            {
                ShowReviewList(userID);
            }
        }

        //Show the reviews list of a user
        private void ShowReviewList(int id)
        {
            DataSet ds = utilities.GetReviewsByUserID(id);
            if (ds.Tables[0].Rows.Count == 0)
            {
                lblGeneral_Error.Text = "There is not any reviews!";
                btnDelete.Visible = false;
                btnModify.Visible = false;
            }
            gvReviews.DataSource = ds;
            gvReviews.DataBind();
        }

        protected void gvReviews_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Attributes["onclick"] = Page.ClientScript.GetPostBackClientHyperlink(gvReviews, "Select$" + e.Row.RowIndex);
                e.Row.ToolTip = "Click to select this row.";
            }
        }

        protected void gvReviews_SelectedIndexChanged(object sender, EventArgs e)
        {
            foreach (GridViewRow row in gvReviews.Rows)
            {
                if (row.RowIndex == gvReviews.SelectedIndex)
                {
                    row.BackColor = ColorTranslator.FromHtml("#A1DCF2");
                    row.ToolTip = string.Empty;
                }
                else
                {
                    row.BackColor = ColorTranslator.FromHtml("#FFFFFF");
                    row.ToolTip = "Click to select this row.";
                }
            }
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            if (gvReviews.SelectedRow != null)
            {
                int ret = utilities.DeleteReviewByID(int.Parse(gvReviews.SelectedRow.Cells[REVIEWID_INDEX].Text));
                ShowReviewList(userID);
            }
            else
            {
                lblGeneral_Error.Text = "You have to select one row to do that!";
            }
        }

        protected void btnModify_Click(object sender, EventArgs e)
        {
            if (gvReviews.SelectedRow != null)
            {
                int revID = int.Parse(gvReviews.SelectedRow.Cells[REVIEWID_INDEX].Text);
                int restID = int.Parse(gvReviews.SelectedRow.Cells[RESTID_INDEX].Text);
                Response.Redirect("ReviewPage.aspx?RestID=" + restID + "&RevID=" + revID + "&action=modify");
            }
            else
            {
                lblGeneral_Error.Text = "You have to select one row to do that!";
            }            
        }
    }
}