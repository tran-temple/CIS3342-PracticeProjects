<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PizzaReceipt.aspx.cs" Inherits="Project1.PizzaReceipt" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <!-- Required meta tags -->
    <meta charset="utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0"/>

    <title>Order Receipt</title>    
    <!-- Bootstrap CSS -->
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.4.1/css/bootstrap.min.css" />
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.5.1/jquery.min.js"></script>
    <script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.4.1/js/bootstrap.min.js"></script>

    <link href="styles/MyStyles.css" rel="stylesheet" type="text/css" />
    <style>        
        div.main_content {            
            margin: auto;
            margin-top: 3%;
            margin-bottom: 3%;
            border: 1px solid black;
            text-shadow: 0.3px 0.3px lightgoldenrodyellow;
            padding: 30px;
            width: 600px;
            height: 700px;          
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="main_content"> 
            <h2 class="text-center"> *** Welcome to the Pizza shop *** </h2>
            <h3 class="text-center"> This is your order receipt </h3> <br />
            <!--Customer Info-->
            <p class="text-primary"> Your name is <asp:Label ID="userName" runat="server" Text="Label"></asp:Label></p>
            <p class="text-primary"> Your phone number is <asp:Label ID="userPhone" runat="server" Text="Label"></asp:Label></p>
            <p class="text-primary"> Your address is <asp:Label ID="userAddress" runat="server" Text="Label"></asp:Label></p>
            <p class="text-primary"> The delivery type is <asp:Label ID="userDelivery" runat="server" Text="Label"></asp:Label></p>
            <!--Pizza Info-->
            <p class="text-primary"> The size of the pizza is <asp:Label ID="pizzaSize" runat="server" Text="Label"></asp:Label></p>
            <p class="text-primary"> The pizza is toasted? <asp:Label ID="pizzaToast" runat="server" Text="Label"></asp:Label></p>
            <p class="text-primary"> The sauce of the pizza is <asp:Label ID="pizzaSauce" runat="server" Text="Label"></asp:Label></p>
            <p class="text-primary"> The toppings of the pizza is <asp:Label ID="pizzaTops" runat="server" Text="Label"></asp:Label></p>
            <p class="text-primary"> The additions of the pizza is <asp:Label ID="pizzaAdds" runat="server" Text="Label"></asp:Label></p>
            <p class="text-primary"> The side of the Family meal is <asp:Label ID="pizzaSide" runat="server" Text="Label"></asp:Label></p>
            <p class="text-primary"> The sub total of the order is <asp:Label ID="pizzaSubTotal" runat="server" Text="Label"></asp:Label></p>
            <p class="text-primary"> The tip amount is <asp:Label ID="pizzaTip" runat="server" Text="Label"></asp:Label></p>
            <p class="text-primary"> The tax amount is <asp:Label ID="pizzaTax" runat="server" Text="Label"></asp:Label></p>
            <p class="text-primary"> The grand total of the order is <asp:Label ID="pizzaGrandTotal" runat="server" Text="Label"></asp:Label></p>
        </div>
    </form>
</body>
</html>
