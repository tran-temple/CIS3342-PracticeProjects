<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="RestaurantPage.aspx.cs" Inherits="Project3.RestaurantPage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="BodyPlaceHolder" runat="server">
    <div class="col-lg-8 offset-lg-2 mt-3 border">        
        <!-- Add / Modify a Restaurant -->                
        <div class="m-3 form-group">            
            <asp:Panel ID="pnlRestaurant" runat="server">
                <div class="row form-group justify-content-center">
                    <asp:Label ID="lblRestaurantHeading" runat="server" Text="... Restaurant" CssClass="h3 font-weight-bold"></asp:Label>
                    <asp:HiddenField ID="hidRestId" runat="server" />
                </div>
                <div class="row form-group">
                    <asp:Label ID="lblGeneral_Error" runat="server" CssClass="text-danger"></asp:Label>
                </div>
                <div class="row form-group">
                    <div class="col"><span>Restaurant name: </span></div>
                    <div class="col-md-8">
                        <asp:TextBox ID="txtRestaurantName" runat="server"></asp:TextBox>
                        &nbsp;&nbsp;<asp:Label ID="lblRestaurantName_Error" runat="server" CssClass="text-danger"></asp:Label>
                    </div>
                </div>
                <div class="row form-group">
                    <div class="col"><span>Address: </span></div>
                    <div class="col-md-8">
                        <asp:TextBox ID="txtAddress" runat="server"></asp:TextBox>
                        &nbsp;&nbsp;<asp:Label ID="lblAddress_Error" runat="server" CssClass="text-danger"></asp:Label>
                    </div>
                </div>
                <div class="row form-group">
                    <div class="col"><span>Categories: </span></div>
                    <div class="col-md-8">
                        <asp:DropDownList ID="ddlCategory" runat="server">
                            <asp:ListItem Value="-1" Selected="True">Select a category...</asp:ListItem>
                        </asp:DropDownList>
                        &nbsp;&nbsp;<asp:Label ID="lblCategory_Error" runat="server" CssClass="text-danger"></asp:Label>
                    </div>
                </div>
                <div class="row form-group">
                    <div class="col"><span>Description: </span></div>
                    <div class="col-md-8">
                        <asp:TextBox ID="txtDescription" runat="server"></asp:TextBox>
                        &nbsp;&nbsp;<asp:Label ID="lblDescription_Error" runat="server" CssClass="text-danger"></asp:Label>
                    </div>
                </div>                
                <div class="row form-group">
                    <div class="col"><span>Image: </span></div>
                    <div class="col-md-8">
                        <asp:DropDownList ID="ddlImageURL" runat="server">
                            <asp:ListItem Value="default_1.jpg" Selected="True">default_1.jpg</asp:ListItem>
                            <asp:ListItem Value="default_2.jpg">default_2.jpg</asp:ListItem>
                            <asp:ListItem Value="default_3.jpg">default_3.jpg</asp:ListItem>
                            <asp:ListItem Value="default_4.jpg">default_4.jpg</asp:ListItem>
                            <asp:ListItem Value="default_5.jpg">default_5.jpg</asp:ListItem>
                        </asp:DropDownList>
                    </div>
                </div>
                <div class="row form-group">
                    <div class="col"><span>Website: </span></div>
                    <div class="col-md-8">
                        <asp:TextBox ID="txtWebsite" runat="server"></asp:TextBox>
                    </div>
                </div>
                <div class="row form-group">
                    <div class="col"><span>Phone number: </span></div>
                    <div class="col-md-8">
                        <asp:TextBox ID="txtPhone" runat="server" TextMode="Phone"></asp:TextBox>
                    </div>
                </div>
                <div class="row form-group">
                    <div class="col"><span>Opening Time: </span></div>
                    <div class="col-md-8">
                        <asp:TextBox ID="txtOpeningTime" runat="server"></asp:TextBox>
                    </div>
                </div>
                <div class="row form-group">
                    <div class="col"><span>Price Range: </span></div>
                    <div class="col-md-8">
                        <asp:TextBox ID="txtPriceRange" runat="server"></asp:TextBox>
                    </div>
                </div>
                <div class="row form-group justify-content-center">                    
                    <asp:Button ID="btnCancel" runat="server" Text="Cancel" CssClass="btn-secondary" OnClick="btnCancel_Click"/>
                    &nbsp;&nbsp;<asp:Button ID="btnSubmit" runat="server" Text="Submit" CssClass="btn-primary" OnClick="btnSubmit_Click"/>
                </div>
            </asp:Panel>
        </div>
    </div>
</asp:Content>
