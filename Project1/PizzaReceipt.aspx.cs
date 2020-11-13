using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Project1
{
    public partial class PizzaReceipt : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //Get customer info and tip for order
                string customerName = Request["customerName"];
                string customerPhone = Request["customerPhone"];
                string customerAddress = Request["customerAddress"];
                string deliveryType = Request["deliveryType"];
                string tip = Request["tip"];

                /**** Get pizza info ****/
                string size = Request["pizzaSize"];
                string toasted = Request["toasted"];
                string sauce = Request["sauce"];
                //Get data from the group of checkbox by using Request.Form[]
                string toppings = Request.Form["toppings"];
                string additions = Request.Form["additions"];
                //Get family meal - side
                string side = Request["side"];
                /**** **** **** ****/                

                //Calculation and output the result
                Calculation cal = new Calculation(deliveryType, size, toasted, sauce, toppings, additions, side, tip);

                //Output the order receipt -- The 1st method
                /*Response.Write("<h2> Welcome to the Pizza shop </h2>");
                Response.Write("<h3> This is your order receipt </h3>");
                Response.Write("<p> Your name is " + customerName + "</p>");
                Response.Write("<p> Your phone number is " + customerPhone + "</p>");
                Response.Write("<p> Your address is " + customerAddress + "</p>");
                Response.Write("<p> The delivery type is " + deliveryType + "</p>");

                Response.Write("<p> The size of the pizza is " + size + "</p>");
                Response.Write("<p> The pizza is toasted? " + toasted + "</p>");
                Response.Write("<p> The sauce of the pizza is " + sauce + "</p>");
                Response.Write("<p> The toppings of the pizza is " + toppings + "</p>");
                Response.Write("<p> The additions of the pizza is " + additions + "</p>");
                Response.Write("<p> The side of the Family meal is " + side + "</p>");
                Response.Write("<p> The sub total of the order is " + cal.getSubOrderTotal() + "</p>");
                Response.Write("<p> The tip amount is " + cal.getTipAmount(tip) + "</p>");
                Response.Write("<p> The tax amount is " + cal.getTaxAmount() + "</p>");
                Response.Write("<p> The grand total of the order is " + cal.getGrandTotal() + "</p>");*/

                //Output the order receipt -- The 2nd method
                userName.Text = customerName;
                userPhone.Text = customerPhone;
                userAddress.Text = customerAddress;
                userDelivery.Text = deliveryType;

                pizzaSize.Text = size;
                pizzaToast.Text = toasted;
                pizzaSauce.Text = sauce;
                pizzaTops.Text = toppings;
                pizzaAdds.Text = additions;
                pizzaSide.Text = side;
                pizzaSubTotal.Text = cal.getSubOrderTotal().ToString();
                pizzaTip.Text = cal.getTipAmount(tip).ToString();
                pizzaTax.Text = cal.getTaxAmount().ToString();
                pizzaGrandTotal.Text = cal.getGrandTotal().ToString();
            }
        }
    }
}