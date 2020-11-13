using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Collections;
using System.Globalization;
using System.Drawing;

using Utilities;
using BookLibrary;

namespace Project2
{
    public partial class BookOrder : System.Web.UI.Page
    {
        DBConnect objDB = new DBConnect();
        ArrayList arrSelectedBooks = new ArrayList();   // used to store selected books
        ArrayList arrSelectedRows = new ArrayList(); // store index of selected rows

        // Columns use for output results
        private const int FIRST_COLUMN = 0;
        private const int QUANTITY_COLUMN = 5;
        private const int TOTALCOST_COLUMN = 6;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                try
                {
                    ShowBooks();                    
                }
                catch (Exception ex)
                {
                    lblErrors.Text = ex.Message;
                    return;
                }
            }
        }      

        public void GenerateBookList()
        { 
            Book objBook;
            Order order = new Order();

            // Iterate through the rows (records) of the Gridview and store the Book object
            // for each row that is checked
            for (int i = 0; i < arrSelectedRows.Count; i++)
            {
                DropDownList dList;
                RadioButton rButton_1; // buy option
                RadioButton rButton_2; // rent option
                TextBox tBox;

                int row = (int)arrSelectedRows[i];
                // Get the reference for the chkSelect control in the current row
                dList = (DropDownList)gvBooks.Rows[row].FindControl("ddlBookType");
                rButton_1 = (RadioButton)gvBooks.Rows[row].FindControl("rdoBuy");
                rButton_2 = (RadioButton)gvBooks.Rows[row].FindControl("rdoRent");
                tBox = (TextBox)gvBooks.Rows[row].FindControl("txtQuantity");

                // Only add selected books to the arraylist to ouput results                
                int id;
                string title = "";
                string isbn = "";
                string type = "";
                string option = "";
                double basePrice = 0.0;
                double price = 0.0;
                int quantity = 0;
                double totalCost = 0.0;
                int totalRent = 0;
                int totalBuy = 0;

                // Get info of ordered Books and add into the arraylist
                id = int.Parse(gvBooks.Rows[row].Cells[8].Text);
                title = gvBooks.Rows[row].Cells[1].Text;
                isbn = gvBooks.Rows[row].Cells[3].Text;
                type = dList.SelectedItem.Text;
                quantity = int.Parse(tBox.Text);
                if (rButton_1.Checked)
                {
                    option = rButton_1.Text;
                    totalBuy = quantity;
                }
                else
                {
                    option = rButton_2.Text;
                    totalRent = quantity;
                } 
                basePrice = double.Parse(gvBooks.Rows[row].Cells[7].Text);
                price = order.CalculatePrice(basePrice, dList.SelectedItem.Value, option);                    
                totalCost = price * quantity;

                objBook = new Book();
                objBook.Title = title;
                objBook.Isbn = isbn;
                objBook.BookType = type;
                objBook.Option = option;
                objBook.Price = price;
                objBook.Quantity = quantity;
                objBook.TotalCost = totalCost;

                arrSelectedBooks.Add(objBook);

                // Update ordered books into Database
                UpdateOrderedBook(id, totalCost, totalRent, totalBuy);
                
            } // end for
        }

        public void ShowBooks()
        {
            string strSQL = "SELECT * FROM Books ORDER BY Title";
            gvBooks.DataSource = objDB.GetDataSet(strSQL);
            gvBooks.DataBind();
        }

        public void ShowBooksReport()
        {
            string strSQL = "SELECT * FROM Books";
            strSQL += " ORDER BY TotalSales DESC, TotalQuantityRented DESC, TotalQuantitySold DESC";
            gvReport.DataSource = objDB.GetDataSet(strSQL);
        }

        public void UpdateOrderedBook(int id, double totalSales, int totalQuantityRent, int totalQuantityBuy)
        {
            string strSQL = "UPDATE Books SET";
            strSQL += " TotalSales = TotalSales + " + totalSales + ",";
            strSQL += " TotalQuantityRented = TotalQuantityRented + " + totalQuantityRent + ",";
            strSQL += " TotalQuantitySold = TotalQuantitySold + " + totalQuantityBuy;
            strSQL += " WHERE Id = " + id;
            objDB.DoUpdate(strSQL);
        }

        public void ShowOrderedBooks()
        {
            gvBooks_Output.DataSource = arrSelectedBooks;
            gvBooks_Output.DataBind();

            // Computer the totals by summing the values in the quantity and price columns
            // for each row in the GridView            
            int totalQuantity = 0;
            double total = 0;
            for (int i = 0; i < arrSelectedBooks.Count; i++)
            {
                totalQuantity += int.Parse(gvBooks_Output.Rows[i].Cells[QUANTITY_COLUMN].Text);
                total += double.Parse(gvBooks_Output.Rows[i].Cells[TOTALCOST_COLUMN].Text, NumberStyles.Currency);
            }

            //Put the values into the corresponding footer column
            gvBooks_Output.Columns[FIRST_COLUMN].FooterText = "Totals:";
            gvBooks_Output.Columns[QUANTITY_COLUMN].FooterText = totalQuantity.ToString();
            gvBooks_Output.Columns[TOTALCOST_COLUMN].FooterText = total.ToString("C2");     //C2 formats as currency           

            // Re-Bind the GridView with the changes made to the footer
            gvBooks_Output.DataBind();            
        }

        // Input Validation for the Gridview of the selected books list
        public bool VerifySelectedBookList()
        {   
            int count = 0; // number of selected rows
            lblErrors.Text = "";
            // Controls need to be verified
            CheckBox cBox;
            DropDownList dList;
            RadioButton rButton_1; // buy option
            RadioButton rButton_2; // rent option
            TextBox tBox;

            // Iterate through the rows (records) of the Gridview and check input validation
            // for each row that is checked
            for (int row = 0; row < gvBooks.Rows.Count; row++)
            {               
                cBox = (CheckBox)gvBooks.Rows[row].FindControl("chkSelect");
                dList = (DropDownList)gvBooks.Rows[row].FindControl("ddlBookType");
                rButton_1 = (RadioButton)gvBooks.Rows[row].FindControl("rdoBuy");
                rButton_2 = (RadioButton)gvBooks.Rows[row].FindControl("rdoRent");
                tBox = (TextBox)gvBooks.Rows[row].FindControl("txtQuantity");

                // Clear red notification of controls
                dList.Style.Add("color", "black");
                rButton_1.Style.Add("color", "black");
                rButton_2.Style.Add("color", "black");
                tBox.Style.Add("border-color", "black");

                // Only add selected books to the arraylist
                if (cBox.Checked)
                {
                    count++;
                    arrSelectedRows.Add(row);                   
                }
            } // end for

            if (count == 0)
            {
                lblErrors.Text = "You have to select at least one Book to order!";
                return false;
            }
            else
            {
                bool b = true;
                for (int i = 0; i < arrSelectedRows.Count; i++)
                {
                    int index = (int) arrSelectedRows[i];
                    // Get the reference for the chkSelect control in the current row
                    dList = (DropDownList)gvBooks.Rows[index].FindControl("ddlBookType");
                    rButton_1 = (RadioButton)gvBooks.Rows[index].FindControl("rdoBuy");
                    rButton_2 = (RadioButton)gvBooks.Rows[index].FindControl("rdoRent");
                    tBox = (TextBox)gvBooks.Rows[index].FindControl("txtQuantity");

                    if (dList.SelectedValue == "-1")
                    {
                        dList.Style.Add("color", "red");
                        b = false;
                    }
                    if (!rButton_1.Checked && !rButton_2.Checked)
                    {
                        rButton_1.Style.Add("color", "red");
                        rButton_2.Style.Add("color", "red");
                        b = false;
                    }
                    if (tBox.Text == "")
                    {
                        tBox.Style.Add("border-color", "red");
                        b = false;
                    }                    
                } // end for
                if (b == false)
                {
                    lblErrors.Text = "Please complete input value for selected books!";
                    arrSelectedRows.Clear();
                    return false;
                }
            }
            return true;
        }
        
        public void ClearStudentInfo_Error()
        {
            // Clear Errors Info
            lblStudentID_Error.Text = "";
            lblPhone_Error.Text = "";
            lblName_Error.Text = "";
            lblAddress_Error.Text = "";
            lblCampus_Error.Text = "";
        }

        public bool VerifyStudentInfo()
        {
            bool b = true;
            ClearStudentInfo_Error();
            // Input validation
            if (txtStudentID.Text == "")
            {
                lblStudentID_Error.Text = "* Required";
                b = false;
            }                
            if (txtPhone.Text == "")
            {
                lblPhone_Error.Text = "* Required";
                b = false;
            }                
            if (txtName.Text == "")
            {
                lblName_Error.Text = "* Required";
                b = false;
            }                
            if (txtAddress.Text == "")
            {
                lblAddress_Error.Text = "* Required";
                b = false;
            }                
            if (ddlCampus.SelectedValue == "-1")
            {
                lblCampus_Error.Text = "* The Required Campus Choice";
                b = false;
            }
            return b;
        }

        protected void btnOrder_Click(object sender, EventArgs e)
        {
            try
            {
                // Generate the selected books list
                if (VerifyStudentInfo() && VerifySelectedBookList())
                {
                    GenerateBookList();
                    // Display the selected books
                    ShowOrderedBooks();

                    gvBooks.Visible = false;
                    gvBooks_Output.Visible = true;
                    btnOrder.Visible = false;
                    btnGenerateReport.Visible = true;

                    arrSelectedRows.Clear();
                    lblDisplay.Text = "Hello " + txtName.Text + "! You ordered the following books successfully: ";
                }
            }
            catch (Exception ex)
            {
                lblErrors.Text = ex.Message;
                arrSelectedBooks.Clear();
                arrSelectedRows.Clear();
                return;
            }
        }

        protected void btnGenerateReport_Click(object sender, EventArgs e)
        {
            try
            {
                ShowBooksReport();
                gvReport.DataBind();
                gvReport.Visible = true;

                gvBooks_Output.Visible = false;
                btnGenerateReport.Visible = false;
                btnGoBackOrder.Visible = true;

                arrSelectedBooks.Clear();
                lblDisplay.Text = "Here is the report of all books in Database!";
            }
            catch (Exception ex)
            {
                lblErrors.Text = ex.Message;
                return;
            }
        }

        protected void btnGoBackOrder_Click(object sender, EventArgs e)
        {
            gvBooks.Visible = true;
            gvReport.Visible = false;
            btnOrder.Visible = true;
            btnGoBackOrder.Visible = false;
            lblDisplay.Text = "";
            ShowBooks();
        }
    } // end class
} // end namespace