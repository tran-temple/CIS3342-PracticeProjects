<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="ReservationPage.aspx.cs" Inherits="Project3.ReservationPage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">    
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="BodyPlaceHolder" runat="server">
    <div class="col-lg-8 offset-lg-2 mt-3 border">       
        <!-- Add / Modify a Reservation -->
        <div class="m-3 form-group">          
            <asp:Panel ID="pnlReservation" runat="server">
                <div class="row form-group justify-content-center">
                    <asp:Label ID="lblReservationHeading" runat="server" Text="... Reservation" CssClass="h3 font-weight-bold"></asp:Label>
                    <asp:HiddenField ID="hidReserveID" runat="server" />
                    <asp:HiddenField ID="hidRestID" runat="server" />
                </div>  
                <div class="row form-group">
                    <asp:Label ID="lblGeneral_Error" runat="server" CssClass="text-danger"></asp:Label>
                </div>
                <div class="row form-group">
                    <div class="col"><span>Reservation name: </span></div>
                    <div class="col-md-8">
                        <asp:TextBox ID="txtReserveName" runat="server"></asp:TextBox>
                        &nbsp;&nbsp;<asp:Label ID="lblReserveName_Error" runat="server" CssClass="text-danger"></asp:Label>
                    </div>
                </div>
                <div class="row form-group">
                    <div class="col"><span>Reservation time: </span></div>
                    <div class="col-md-8">
                        <asp:TextBox ID="txtReserveTime" runat="server" TextMode="DateTimeLocal"></asp:TextBox>
                        &nbsp;&nbsp;<asp:Label ID="lblTime_Error" runat="server" CssClass="text-danger"></asp:Label>
                    </div>
                </div>
                <div class="row form-group">
                    <div class="col"><span>Phone number: </span></div>
                    <div class="col-md-8">
                        <asp:TextBox ID="txtPhone" runat="server" TextMode="Phone"></asp:TextBox>
                        &nbsp;&nbsp;<asp:Label ID="lblPhone_Error" runat="server" CssClass="text-danger"></asp:Label>
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
