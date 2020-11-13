using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Project1
{
    public class Calculation
    {
        // Calculated Prices for building a pizza
        double deliveryPrice;
        double pizzaBasePrice;
        double saucePrice;
        double toastedPrice;
        double totalTopsPrice;
        double totalAdditionsPrice;
        double familyMealPrice;
        double tipAmount;
        double taxAmount;
        double subOrderTotal; // total no including tax
        double grandTotal; // total including tax + tip

        //Default Price for delivery
        const double DELIVERY_PRICE = 2.0;

        //Default Price for pizza sizes
        const double SMALL_PRICE = 5.0;
        const double MEDIUM_PRICE = 10.0;
        const double LARGE_PRICE = 15.0;
        const double EXTRA_LARGE_PRICE = 20.0;

        //Default Price for sauce
        const double SAUCE_PRICE = 1.0;

        //Default Price for toasted
        const double TOASTED_PRICE = 1.0;

        //Default Price for toppings - meat
        const double MEAT_TOPPINGS_PRICE = 1.0;
        //Default Price for toppings - veggies
        const double VEGGIES_TOPPINGS_PRICE = 0.5;

        //Default Price for additions
        const double ADDITIONS_PRICE = 1.0;

        //Default Price for Family Meal 1 (salad, wings, nuggets)
        const double FAMILY_MEAL_1_PRICE = 8.0;
        //Default Price for Family Meal 2 (fries, breadsticks)
        const double FAMILY_MEAL_2_PRICE = 5.0;

        //Defalut sale tax
        const double SALE_TAX = 0.08;

        public Calculation()
        {

        }

        public Calculation(string type, string pizzaSize, string toasted, string sauce,
            string toppings, string additions, string side, string tip)
        {
            subOrderTotal = 0.0;
            grandTotal = 0.0;
            
            deliveryPrice = getDeliveryPrice(type);
            pizzaBasePrice = getPizzaBasePrice(pizzaSize);
            toastedPrice = getToastedPrice(toasted);
            saucePrice = getSaucePrice(sauce);            
            totalTopsPrice = getTotalTopsPrice(toppings);
            totalAdditionsPrice = getTotalAdditionsPrice(additions);
            familyMealPrice = getFamilyMealPrice(side);
            tipAmount = getTipAmount(tip);
            
            subOrderTotal = SubTotal();
            taxAmount = SalesTax();
            grandTotal = Total();
        }

        // Get price for delivery
        public double getDeliveryPrice(string type)
        {
            if (type == "delivery")
            {
                return DELIVERY_PRICE;
            }
            return 0.0;
        }

        // Get price depending on pizza size
        public double getPizzaBasePrice(string size)
        {
            if (size != "")
            {
                if (size == "small") return SMALL_PRICE;
                if (size == "medium") return MEDIUM_PRICE;
                if (size == "large") return LARGE_PRICE;
                if (size == "extralarge") return EXTRA_LARGE_PRICE;                
            }
            return 0.0;
        }

        // Get price for pizza toasted
        public double getToastedPrice(string toasted)
        {
            if (toasted == "yes")
            {
                return TOASTED_PRICE;
            }
            return 0.0;
        }

        // Get price for pizza sauce
        public double getSaucePrice(string sauce)
        {
            if (sauce != "none")
            {
                return SAUCE_PRICE;
            }
            return 0.0;
        }

        // Get price depending on Toppings types
        public double getTopsTypePrice(string toppings)
        {
            double num = 0.0;
            if (toppings == "") return num;
            
            if (toppings == "pepperoni" || toppings == "sausage"
                || toppings == "bacon" || toppings == "ham")
            {
                num = MEAT_TOPPINGS_PRICE;
            }
            else
            {
                num = VEGGIES_TOPPINGS_PRICE;
            }
            return num;
        }
        
        // Calculate total price of chosen toppings
        public double getTotalTopsPrice(string toppings)
        {
            double num = 0.0;
            if (toppings != null)
            {
                string[] topsArray = toppings.Split(',');
                foreach (string tops in topsArray)
                {
                    num += getTopsTypePrice(tops);
                }
            }            
            return num;
        }        

        // Calculate total price of chosen additions
        public double getTotalAdditionsPrice(string additions)
        {
            double num = 0.0;
            if (additions != null)
            {
                string[] addsArray = additions.Split(',');
                foreach (string addition in addsArray)
                {
                    num += ADDITIONS_PRICE;
                }
            }            
            return num;
        }

        // Get price depending on family meal side
        public double getFamilyMealPrice(string side)
        {
            double num = 0.0;
            if (side == "none") return num;

            if (side == "salad" || side == "wings"|| side == "nuggets")
            {
                num = FAMILY_MEAL_1_PRICE;
            }
            else
            {
                num = FAMILY_MEAL_2_PRICE;
            }
            return num;
        }

        // Convert tip to the double type
        public double getTipAmount(string tip)
        {
            double num = 0.0;
            if (tip != "") double.TryParse(tip, out num);
            return num;
        }
        
        //Calculate tax
        public double SalesTax()
        {
            double num = 0.0;
            num = subOrderTotal * SALE_TAX;
            return num;
        }

        //Total no including tax
        public double SubTotal()
        {
            double num = 0.0;
            num = deliveryPrice + pizzaBasePrice + toastedPrice + saucePrice 
                + totalTopsPrice + totalAdditionsPrice + familyMealPrice;
            return num;
        }

        //Total of order
        public double Total()
        {
            return SubTotal() + SalesTax() + tipAmount;
        }

        public double getTaxAmount()
        {
            return taxAmount;
        }
        public double getSubOrderTotal()
        {
            return subOrderTotal;
        }
        public double getGrandTotal()
        {
            return grandTotal;
        }
    }
}