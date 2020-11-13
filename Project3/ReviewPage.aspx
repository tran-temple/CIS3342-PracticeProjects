<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="ReviewPage.aspx.cs" Inherits="Project3.ReviewPage"%>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="BodyPlaceHolder" runat="server">
    <div class="col-lg-8 offset-lg-2 mt-3 border">
        <!-- Add / Modify a Review -->
        <div class="m-3 form-group">            
            <asp:Panel ID="pnlReview" runat="server">
                <div class="row form-group justify-content-center">
                    <asp:Label ID="lblReviewHeading" runat="server" Text="... Review" CssClass="h3 font-weight-bold"></asp:Label>
                    <asp:HiddenField ID="hidReviewID" runat="server" />
                </div>
                <div class="row form-group">
                    <asp:Label ID="lblGeneralError" runat="server" CssClass="text-danger"></asp:Label>
                </div>
                <div class="row form-group">
                    <div class="col"><span>Restaurant name: </span></div>
                    <div class="col-md-8">                        
                        <asp:Label ID="lblRestaurantName" runat="server"></asp:Label>
                        <asp:HiddenField ID="hidRestID" runat="server" />
                    </div>
                </div>
                <div class="row form-group">
                    <div class="col"><span>Food Quality: </span></div>
                    <div class="col-md-8">                        
                        <asp:RadioButtonList ID="rblFoodRating" runat="server" RepeatDirection="Horizontal" RepeatColumns="5">
                            <asp:ListItem Value="1">*&nbsp;</asp:ListItem>
                            <asp:ListItem Value="2">**&nbsp;</asp:ListItem>
                            <asp:ListItem Value="3">***&nbsp;</asp:ListItem>
                            <asp:ListItem Value="4">****&nbsp;</asp:ListItem>
                            <asp:ListItem Value="5">*****&nbsp;</asp:ListItem>
                        </asp:RadioButtonList>
                        &nbsp;&nbsp;<asp:Label ID="lblFoodRating_Error" runat="server" CssClass="text-danger"></asp:Label>
                    </div>
                </div>
                <div class="row form-group">
                    <div class="col"><span>Service: </span></div>
                    <div class="col-md-8">
                        <asp:RadioButtonList ID="rblServiceRating" runat="server" RepeatDirection="Horizontal" RepeatColumns="5">
                            <asp:ListItem Value="1">*&nbsp;</asp:ListItem>
                            <asp:ListItem Value="2">**&nbsp;</asp:ListItem>
                            <asp:ListItem Value="3">***&nbsp;</asp:ListItem>
                            <asp:ListItem Value="4">****&nbsp;</asp:ListItem>
                            <asp:ListItem Value="5">*****&nbsp;</asp:ListItem>
                        </asp:RadioButtonList>
                        &nbsp;&nbsp;<asp:Label ID="lblServiceRating_Error" runat="server" CssClass="text-danger"></asp:Label>
                    </div>
                </div>
                <div class="row form-group">
                    <div class="col"><span>Atmosphere: </span></div>
                    <div class="col-md-8">
                        <asp:RadioButtonList ID="rblAtmosphereRating" runat="server" RepeatDirection="Horizontal" RepeatColumns="5">
                            <asp:ListItem Value="1">*&nbsp;</asp:ListItem>
                            <asp:ListItem Value="2">**&nbsp;</asp:ListItem>
                            <asp:ListItem Value="3">***&nbsp;</asp:ListItem>
                            <asp:ListItem Value="4">****&nbsp;</asp:ListItem>
                            <asp:ListItem Value="5">*****&nbsp;</asp:ListItem>
                        </asp:RadioButtonList>
                        &nbsp;&nbsp;<asp:Label ID="lblAtmosphereRating_Error" runat="server" CssClass="text-danger"></asp:Label>
                    </div>
                </div>
                <div class="row form-group">
                    <div class="col"><span>Price Level: </span></div>
                    <div class="col-md-8">
                        <asp:RadioButtonList ID="rblPriceRating" runat="server" RepeatDirection="Horizontal" RepeatColumns="5">
                            <asp:ListItem Value="1">*&nbsp;</asp:ListItem>
                            <asp:ListItem Value="2">**&nbsp;</asp:ListItem>
                            <asp:ListItem Value="3">***&nbsp;</asp:ListItem>
                            <asp:ListItem Value="4">****&nbsp;</asp:ListItem>
                            <asp:ListItem Value="5">*****&nbsp;</asp:ListItem>
                        </asp:RadioButtonList>
                        &nbsp;&nbsp;<asp:Label ID="lblPriceRating_Error" runat="server" CssClass="text-danger"></asp:Label>
                    </div>
                </div>
                <div class="row form-group">
                    <div class="col"><span>Comments: </span></div>
                    <div class="col-md-8">
                        <asp:TextBox ID="txtComments" runat="server" TextMode="MultiLine"></asp:TextBox>
                        &nbsp;&nbsp;<asp:Label ID="lblComments_Error" runat="server" CssClass="text-danger"></asp:Label>
                    </div>
                </div>
                <div class="row form-group justify-content-center">
                    <asp:Button ID="btnCancel" runat="server" Text="Cancel" CssClass="btn-secondary" OnClick="btnCancel_Click"/>&nbsp;&nbsp;
                    <asp:Button ID="btnSubmit" runat="server" Text="Submit" CssClass="btn-primary" OnClick="btnSubmit_Click"/>
                </div>
            </asp:Panel>
        </div>        
    </div>
</asp:Content>
