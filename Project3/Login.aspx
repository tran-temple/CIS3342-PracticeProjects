﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Project3.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <!-- Required meta tags -->
    <meta charset="utf-8"/>
    <meta name="viewport" content="width=device-width, initial-scale=1, shrink-to-fit=no"/>

    <!-- Bootstrap CSS -->
    <link rel="stylesheet" href="https://stackpath.bootstrapcdn.com/bootstrap/4.4.1/css/bootstrap.min.css" />
    <link rel="stylesheet" href="https://fonts.googleapis.com/css2?family=Montserrat:wght@500;700&display=swap" />    
    
    <link rel="stylesheet" href="styles/Styles.css" />

    <title>Login</title>
</head>
<body>
    <form id="form1" runat="server">
        <div class="col-lg-4 offset-lg-4 mt-2">
            <div class="row form-group justify-content-center mt-2">
                <img src="images/orginal_logo.jpg" width="300" height="150" class="d-inline-block img-fluid" alt="Logo" />                
            </div>            
        </div>        
        <div class="col-lg-4 offset-lg-4 mt-2 border">            
            <div class="row form-group justify-content-center mt-2">
                <h2 class="font-weight-bold">Login</h2>                
            </div>
            <div class="row form-group justify-content-center">
                <asp:Label ID="lblGeneral_Error" runat="server" CssClass="text-danger mt-2"></asp:Label>                
            </div>
            <div class="row form-group">       
                <div class="col">
                    <span>Username: </span>
                </div>
                <div class="col-md-8">
                    <asp:TextBox ID="txtUsername" runat="server"></asp:TextBox>
                </div>
            </div>            
            <div class="row form-group">
                <div class="col">
                </div>
                <div class="col-md-8">
                    <asp:Button ID="btnLogin" runat="server" Text="Login" CssClass="btn-primary" OnClick="btnLogin_Click"/>                
                </div>                
            </div>
            <div class="row form-group">
                <span class="ml-3">Click this link for visitors: </span>&nbsp;&nbsp;
                <asp:LinkButton ID="btnVisit" runat="server" Text="Just Visit" OnClick="btnVisit_Click"/>
            </div>
            <div class="row form-group">
                <span class="ml-3">Click this link for registration: </span>&nbsp;&nbsp;
                <asp:LinkButton ID="btnRegister" runat="server" Text="Register" OnClick="btnRegister_Click" />
            </div>
        </div>
    </form>
</body>
</html>
