<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="BookOrder.aspx.cs" Inherits="Project2.BookOrder" %>

<!DOCTYPE html>
<!--
Name:  Hong Tran
Project 2: Bookstore
-->
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <!-- Required meta tags -->
    <meta charset="utf-8"/>
    <meta name="viewport" content="width=device-width, initial-scale=1, shrink-to-fit=no"/>

    <!-- Bootstrap CSS -->
    <link rel="stylesheet" href="https://stackpath.bootstrapcdn.com/bootstrap/4.4.1/css/bootstrap.min.css" integrity="sha384-Vkoo8x4CGsO3+Hhxv8T/Q5PaXtkKtu6ug5TOeNV6gBiFeWPGFN9MuhOf23Q9Ifjh" crossorigin="anonymous"/>

    <title>Order Books</title>

    <!-- Styles -->
    <style>        
        .hiddenCol {
            display: none;
        }
    </style>
</head>
<body class="bg-white">
    <nav style="background-color:#F7F7F7; padding:20px;">
        <img src="images/books.png" style="width:100px;" />
        <span style="font-size:40px; padding:30px;"> Welcome to the Bookstore </span>        
    </nav>    
    <div class="container-fluid">
        <form id="frmBookOrder" runat="server">
            <!--Customer Info-->
            <div>                
                <div class="row" style="padding:10px 0 5px 0;">
                    <div class="col">
                        <h5><b>Ordering Books</b></h5>
                    </div>
                </div>
                <!--textbox-->
                <div class="row" style="padding-top:5px;">
                    <div class="col">
                        <span>Student ID:</span>
                    </div>
                    <div class="col-11">
                        <asp:TextBox ID="txtStudentID" runat="server"></asp:TextBox>
                        &nbsp;&nbsp;<asp:Label ID="lblStudentID_Error" runat="server" CssClass="text-danger"></asp:Label>
                    </div>
                </div>
                <div class="row" style="padding-top:5px;">
                    <div class="col">
                        <span>Phone:</span>
                    </div>
                    <div class="col-11">
                        <asp:TextBox ID="txtPhone" runat="server" TextMode="Phone"></asp:TextBox>
                        &nbsp;&nbsp;<asp:Label ID="lblPhone_Error" runat="server" CssClass="text-danger"></asp:Label>
                    </div>
                </div>
                <div class="row" style="padding-top:5px;">
                    <div class="col">
                        <span>Name:</span>
                    </div>
                    <div class="col-11">
                        <asp:TextBox ID="txtName" runat="server"></asp:TextBox>
                        &nbsp;&nbsp;<asp:Label ID="lblName_Error" runat="server" CssClass="text-danger"></asp:Label>
                    </div>
                </div>
                <div class="row" style="padding-top:5px;">
                    <div class="col">
                        <span>Address:</span>
                    </div>
                    <div class="col-11">
                        <asp:TextBox ID="txtAddress" runat="server"></asp:TextBox>
                        &nbsp;&nbsp;<asp:Label ID="lblAddress_Error" runat="server" CssClass="text-danger"></asp:Label>
                    </div>
                </div>
                <div class="row" style="padding-top:5px;">
                    <div class="col">
                        <span>Campus:</span>
                    </div>
                    <div class="col-11">
                        <asp:DropDownList ID="ddlCampus" runat="server">
                            <asp:ListItem Value="-1">Select a campus...</asp:ListItem>
                            <asp:ListItem Value="main"> Main </asp:ListItem>
                            <asp:ListItem Value="tucc"> TUCC </asp:ListItem>
                            <asp:ListItem Value="ambler"> Ambler </asp:ListItem>
                            <asp:ListItem Value="tokyo"> Tokyo </asp:ListItem>
                            <asp:ListItem Value="rome"> Rome </asp:ListItem>
                        </asp:DropDownList>
                        &nbsp;&nbsp;<asp:Label ID="lblCampus_Error" runat="server" CssClass="text-danger"></asp:Label>
                    </div>
                </div>     
            </div>

            <br />
            <!-- Show errors -->
            <asp:Label ID="lblErrors" runat="server" CssClass="alert-danger font-weight-bold"></asp:Label>
            <!-- Show results -->
            <asp:Label ID="lblDisplay" runat="server" CssClass="alert-info font-weight-bold"></asp:Label>
            <br />

            <!-- The input GridView: contains (data) books to order -->
            <div>
                <asp:GridView ID="gvBooks" runat="server" AutoGenerateColumns="false">
                    <Columns>
                        <asp:TemplateField HeaderText="Select Book" ItemStyle-HorizontalAlign="Center">
                            <ItemTemplate>
                                <asp:CheckBox ID="chkSelect" runat="server"/>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField DataField="Title" HeaderText="Title" />
                        <asp:BoundField DataField="Authors" HeaderText="Authors" />
                        <asp:BoundField DataField="ISBN" HeaderText="ISBN" />
                        <asp:TemplateField HeaderText="Book Type">
                            <ItemTemplate>
                                <asp:DropDownList ID="ddlBookType" runat="server">
                                    <asp:ListItem Value="-1">Select a book type...</asp:ListItem>
                                    <asp:ListItem Value="hardcover"> Hard cover </asp:ListItem>
                                    <asp:ListItem Value="paperback"> Paper back </asp:ListItem>
                                    <asp:ListItem Value="ebook"> E-book </asp:ListItem>
                                </asp:DropDownList>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Buy or Rent" ControlStyle-Width="45px" ItemStyle-HorizontalAlign="Center">
                            <ItemTemplate>
                                <asp:RadioButton ID="rdoBuy" GroupName="PurchaseType" runat="server" Text="Buy" />
                                <asp:RadioButton ID="rdoRent" GroupName="PurchaseType" runat="server" Text="Rent" />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Quantity">
                            <ItemTemplate>
                                <asp:TextBox ID="txtQuantity" runat="server" Height="20px" Width="64px" TextMode="Number"></asp:TextBox>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField DataField="BasePrice" HeaderText="BasePrice" HeaderStyle-CssClass="hiddenCol" ItemStyle-CssClass="hiddenCol"/>                       
                        <asp:BoundField DataField="Id" HeaderText="Id" HeaderStyle-CssClass="hiddenCol" ItemStyle-CssClass="hiddenCol"/>
                    </Columns>
                    <HeaderStyle BackColor="#99CCFF" HorizontalAlign="Center" Wrap="False" />
                </asp:GridView>
            </div>
            
            <!-- The output GridView: contains (info) ordered books  -->
            <div>
                <asp:GridView ID="gvBooks_Output" runat="server" AutoGenerateColumns="false" ShowFooter="true" Visible="False">
                    <Columns>
                        <asp:BoundField DataField="Title" HeaderText="Title" />
                        <asp:BoundField DataField="Isbn" HeaderText="ISBN" />
                        <asp:BoundField DataField="BookType" HeaderText="Type" />
                        <asp:BoundField DataField="Option" HeaderText="Buy/Rent" ItemStyle-HorizontalAlign="Center" />
                        <asp:BoundField DataField="Price" DataFormatString="{0:c}" HeaderText="Price" />
                        <asp:BoundField DataField="Quantity" HeaderText="Quantity" />
                        <asp:BoundField DataField="TotalCost" DataFormatString="{0:c}" HeaderText="Total Cost" />
                    </Columns>
                    <HeaderStyle BackColor="#99CCFF" HorizontalAlign="Center" Wrap="False" />
                    <FooterStyle Font-Bold="true" />
                </asp:GridView>
            </div>

            <!-- Show a management report -->
            <div>
                <asp:GridView ID="gvReport" runat="server" AutoGenerateColumns="false" Visible="False">
                    <Columns>
                        <asp:BoundField DataField="Title" HeaderText="Title" />
                        <asp:BoundField DataField="Isbn" HeaderText="ISBN" />
                        <asp:BoundField DataField="Authors" HeaderText="Authors" />
                        <asp:BoundField DataField="TotalSales" DataFormatString="{0:c}" HeaderText="Total Sales" />
                        <asp:BoundField DataField="TotalQuantityRented" HeaderText="Total Rented" ItemStyle-HorizontalAlign="Center" />
                        <asp:BoundField DataField="TotalQuantitySold" HeaderText="Total Sold" ItemStyle-HorizontalAlign="Center" />
                    </Columns>
                    <HeaderStyle BackColor="#99CCFF" HorizontalAlign="Center" Wrap="False" />
                </asp:GridView>
            </div>

            <br />
            <!-- The submit button -->
            <asp:Button ID="btnOrder" runat="server" Text="Order Books" CssClass="btn-primary" OnClick="btnOrder_Click" />
            
            <asp:Button ID="btnGenerateReport" runat="server" Text="Generate Reports" CssClass="btn-primary" OnClick="btnGenerateReport_Click" Visible="false"/>
            
            <asp:Button ID="btnGoBackOrder" runat="server" Text="Go Back To Order" CssClass="btn-primary" OnClick="btnGoBackOrder_Click" Visible="false"/>

            <br />
            <br />
        </form>
    </div>
    <!-- Optional JavaScript -->
    
    <!-- jQuery first, then Popper.js, then Bootstrap JS -->
    <script src="https://code.jquery.com/jquery-3.4.1.slim.min.js" integrity="sha384-J6qa4849blE2+poT4WnyKhv5vZF5SrPo0iEjwBvKU7imGFAV0wwj1yYfoRSJoZ+n" crossorigin="anonymous"></script>
    <script src="https://cdn.jsdelivr.net/npm/popper.js@1.16.0/dist/umd/popper.min.js" integrity="sha384-Q6E9RHvbIyZFJoft+2mJbHaEWldlvI9IOYy5n3zV9zzTtmI3UksdQRVvoxMfooAo" crossorigin="anonymous"></script>
    <script src="https://stackpath.bootstrapcdn.com/bootstrap/4.4.1/js/bootstrap.min.js" integrity="sha384-wfSDF2E50Y2D1uUdj0O3uMBJnjuUD4Ih7YwaYd1iqfktj0Uod8GCExl3Og8ifwB6" crossorigin="anonymous"></script>    
</body>
</html>
