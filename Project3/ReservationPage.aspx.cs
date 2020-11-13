using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using ReviewLibrary;

namespace Project3
{
    public partial class ReservationPage : System.Web.UI.Page
    {
        Utilities utilities = new Utilities();
        string action;
        int restID;

        protected void Page_Load(object sender, EventArgs e)
        {
            action = Request.QueryString["action"];
            restID = int.Parse(Request.QueryString["RestID"]);

            if (!IsPostBack)
            {
                hidRestID.Value = restID.ToString();

                if (action == "add")
                {
                    lblReservationHeading.Text = "Add Reservation";
                }
                else
                {
                    int reserveID = int.Parse(Request.QueryString["ReserveID"]);
                    hidReserveID.Value = reserveID.ToString();
                    LoadReserve(reserveID);
                    lblReservationHeading.Text = "Modify Reservation";
                }               
            }
        }

        //Load info to modify
        private void LoadReserve(int id)
        {
            Reservation obj = utilities.GetReservationByID(id);
            txtReserveName.Text = obj.ReservationName;
            txtReserveTime.Text = obj.ReservationTime.ToString("yyyy-MM-ddTHH:mm");
            txtPhone.Text = obj.Phone;
        }

        //Create a reservation for insert or update
        private Reservation CreateReservationObject(int id)
        {
            Reservation res = new Reservation();
            res.ReservationID = id;
            res.RestaurantID = int.Parse(hidRestID.Value);
            res.ReservationName = txtReserveName.Text;
            res.ReservationTime = DateTime.Parse(txtReserveTime.Text);
            res.Phone = txtPhone.Text;
            return res;
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            try
            {
                Reservation obj;
                int ret;
                ClearErrorMessage();
                if (InvalidReservation())
                {
                    return;
                }
                if (action == "add")
                {
                    obj = CreateReservationObject(0);
                    ret = utilities.InsertReservation(obj);
                    if (ret == 1)
                    {
                        Response.Redirect("ViewRestaurant.aspx?RestID=" + hidRestID.Value);
                    }
                }
                else
                {
                    obj = CreateReservationObject(int.Parse(hidReserveID.Value));
                    ret = utilities.UpdateReservation(obj);
                    if (ret == 1)
                    {
                        Response.Redirect("ViewReservations.aspx?RestID=" + hidRestID.Value);
                    }
                }

                if (ret < 1)
                {
                    lblGeneral_Error.Text = "Cannot add reservation!";
                }
            }
            catch (Exception ex)
            {
                lblGeneral_Error.Text = ex.Message;
            }
            
        }

        private void ClearErrorMessage()
        {
            lblGeneral_Error.Text = "";
            lblReserveName_Error.Text = "";
            lblTime_Error.Text = "";
            lblPhone_Error.Text = "";
        }

        private bool InvalidReservation()
        {
            bool hasError = false;
            if (string.IsNullOrWhiteSpace(txtReserveName.Text))
            {
                hasError = true;
                lblReserveName_Error.Text = "Input name!";
            }
            if (string.IsNullOrWhiteSpace(txtReserveTime.Text))
            {
                hasError = true;
                lblTime_Error.Text = "Input time!";
            }
            if (string.IsNullOrWhiteSpace(txtPhone.Text))
            {
                hasError = true;
                lblPhone_Error.Text = "Input phone!";
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
                Response.Redirect("ViewReservations.aspx?RestID=" + hidRestID.Value);
            }
        }
    }
}