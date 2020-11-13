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
    public partial class ViewReservations : System.Web.UI.Page
    {
        Utilities utilities = new Utilities();
        int restID;

        // The column index
        private const int RESERVEID_INDEX = 4;
        private const int RESTID_INDEX = 5;

        protected void Page_Load(object sender, EventArgs e)
        {
            restID = int.Parse(Request.QueryString["RestID"]);

            if (!IsPostBack)
            {
                ShowReservationList(restID);
            }
        }

        //Show the reservaion list of a restaurant
        private void ShowReservationList(int id)
        {
            DataSet ds = utilities.GetReservationsByRestID(id);
            if (ds.Tables[0].Rows.Count == 0)
            {
                lblGeneral_Error.Text = "There is not any reservation!";
                btnDelete.Visible = false;
                btnModify.Visible = false;
            }
            gvReservations.DataSource = ds;
            gvReservations.DataBind();                       
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            if (gvReservations.SelectedRow != null)
            {
                int ret = utilities.DeleteReservationByID(int.Parse(gvReservations.SelectedRow.Cells[RESERVEID_INDEX].Text));
                ShowReservationList(restID);
            }
            else
            {
                lblGeneral_Error.Text = "You have to select one row to do that!";
            }
        }

        protected void btnModify_Click(object sender, EventArgs e)
        {
            if (gvReservations.SelectedRow != null)
            {
                int reserveID = int.Parse(gvReservations.SelectedRow.Cells[RESERVEID_INDEX].Text);
                int restID = int.Parse(gvReservations.SelectedRow.Cells[RESTID_INDEX].Text);
                Response.Redirect("ReservationPage.aspx?RestID=" + restID + "&ReserveID=" + reserveID + "&action=modify");
            }
            else
            {
                lblGeneral_Error.Text = "You have to select one row to do that!";
            }
        }

        protected void gvReservations_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Attributes["onclick"] = Page.ClientScript.GetPostBackClientHyperlink(gvReservations, "Select$" + e.Row.RowIndex);
                e.Row.ToolTip = "Click to select this row.";
            }
        }

        protected void gvReservations_SelectedIndexChanged(object sender, EventArgs e)
        {
            foreach (GridViewRow row in gvReservations.Rows)
            {
                if (row.RowIndex == gvReservations.SelectedIndex)
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
    }
}