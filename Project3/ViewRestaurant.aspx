<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="ViewRestaurant.aspx.cs" Inherits="Project3.ViewRestaurant" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="BodyPlaceHolder" runat="server">
    <div class="col-lg-8 offset-lg-2 mt-3 border">
        <div class="row form-group justify-content-center">
            <asp:Label ID="lblGeneral_Error" runat="server" CssClass="text-danger"></asp:Label>
        </div>
        <!-- View Restaurant -->
        <asp:Panel ID="pnlViewProfile" runat="server">
            <div class="row justify-content-center mt-2">
                <div class="col">
                    <div class="row mt-2 ml-1 mb-2"><asp:Image ID="imgRestaurant" Width="160px" Height="160px" runat="server" CssClass="border shadow"/></div>
                    <div class="row ml-1"><asp:Button ID="btnAddReview" runat="server" Text="Add Review" CssClass="btn-primary mt-2" Visible="false" OnClick="btnAddReview_Click" /></div>
                    <div class="row ml-1"><asp:Button ID="btnReserve" runat="server" Text="Reserve" CssClass="btn-primary mt-2" OnClick="btnReserve_Click" /></div>
                    <div class="row ml-1"><asp:Button ID="btnModifyRest" runat="server" Text="Modify Profile" CssClass="btn-primary mt-2" Visible="false" OnClick="btnModifyRest_Click" /></div>                    
                    <div class="row ml-1"><asp:Button ID="btnReservation" runat="server" Text="Reservation" CssClass="btn-primary mt-2" Visible="false" OnClick="btnReservation_Click" /></div>  
                    <div class="row ml-1"><asp:Button ID="btnAssignRepresentative" runat="server" Text="Become Representative" CssClass="btn-primary mt-2" Visible="false" OnClick="btnAssignRepresentative_Click" /></div>
                </div>
                <div class="col-md-8">
                    <div class="row mt-2 ml-1">
                        <asp:Label ID="lblRole" runat="server" CssClass="bg-light text-primary font-weight-bold"></asp:Label>
                    </div>
                    <div class="row mt-2 ml-1">
                        <span>Name: </span>&nbsp;
                        <asp:Label ID="lblName" runat="server" CssClass="font-weight-bold"></asp:Label>
                    </div>
                    <div class="row mt-2 ml-1">
                        <span>Description: </span>&nbsp;
                        <asp:Label ID="lblDescription" runat="server" CssClass="font-weight-bold"></asp:Label>
                    </div>
                    <div class="row mt-2 ml-1">
                        <span>Address: </span>&nbsp;
                        <asp:Label ID="lblAddress" runat="server" CssClass="font-weight-bold"></asp:Label>
                    </div>
                    <div class="row mt-2 ml-1">
                        <span>Food Quality Rate: </span>&nbsp;
                        <asp:Label ID="lblFoodRate" runat="server" CssClass="font-weight-bold"></asp:Label><br />
                    </div>
                    <div class="row mt-2 ml-1">
                        <span>Service Rate: </span>&nbsp;
                        <asp:Label ID="lblServiceRate" runat="server" CssClass="font-weight-bold"></asp:Label>
                    </div>
                    <div class="row mt-2 ml-1">
                        <span>Restaurant’s atmosphere Rate: </span>&nbsp;
                        <asp:Label ID="lblAtmosphereRate" runat="server" CssClass="font-weight-bold"></asp:Label>
                    </div>
                    <div class="row mt-2 ml-1">
                        <span>Price Level Rate: </span>&nbsp;
                        <asp:Label ID="lblPriceRate" runat="server" CssClass="font-weight-bold"></asp:Label>
                    </div>
                    <div class="row mt-2 ml-1">
                        <span>Opening Time: </span>&nbsp;
                        <asp:Label ID="lblOpeningTime" runat="server" CssClass="font-weight-bold"></asp:Label>
                    </div>
                    <div class="row mt-2 ml-1">
                        <span>Price Range: </span>&nbsp;
                        <asp:Label ID="lblPriceRange" runat="server" CssClass="font-weight-bold"></asp:Label>
                    </div>
                    <div class="row mt-2 ml-1">
                        <span>Website: </span>&nbsp;
                        <asp:Label ID="lblWebsite" runat="server" CssClass="font-weight-bold"></asp:Label>
                    </div>
                    <div class="row mt-2 ml-1">
                        <span>Phone: </span>&nbsp;
                        <asp:Label ID="lblPhone" runat="server" CssClass="font-weight-bold"></asp:Label>
                    </div>
                    <div class="row mt-2 ml-1">
                        <span>Number of reservation: </span>&nbsp;
                        <asp:Label ID="lblNumOfReservation" runat="server" CssClass="font-weight-bold"></asp:Label>
                    </div>
                </div>
            </div>

            <!-- Showing the list of reviews -->
            <div class="row justify-content-center mt-3">
                <div class="col">
                    <asp:Repeater ID="rptReviews" runat="server">                        
                        <ItemTemplate>
                            <hr />
                            <div class="row mt-3 ml-2">
                                <span class="font-weight-bolder">Review <%# Container.ItemIndex + 1 %>:</span>
                            </div>
                            <div class="row ml-4">
                                <span>Food Rate:</span>&nbsp;
                                <asp:Label ID="lblFoodRate" runat="server" CssClass="font-weight-bold"
                                    Text='<%# DataBinder.Eval(Container.DataItem, "FoodRating") %>'></asp:Label>
                                &nbsp;&nbsp;&nbsp;<span>Service Rate:</span>&nbsp;
                                <asp:Label ID="lblServiceRate" runat="server" CssClass="font-weight-bold"
                                    Text='<%# DataBinder.Eval(Container.DataItem, "ServiceRating") %>'></asp:Label>
                                &nbsp;&nbsp;&nbsp;<span>Atmosphere Rate:</span>&nbsp;
                                <asp:Label ID="lblAtmosphereRate" runat="server" CssClass="font-weight-bold"
                                    Text='<%# DataBinder.Eval(Container.DataItem, "AtmosphereRating") %>'></asp:Label>
                                &nbsp;&nbsp;&nbsp;<span>Price Level Rate:</span>&nbsp;
                                <asp:Label ID="lblPriceRate" runat="server" CssClass="font-weight-bold"
                                    Text='<%# DataBinder.Eval(Container.DataItem, "PriceRating") %>'></asp:Label>
                            </div>
                            <div class="row ml-4">
                                <span>Comments:</span>&nbsp;
                                <asp:Label ID="lblComments" runat="server" CssClass="font-italic"
                                    Text='<%# DataBinder.Eval(Container.DataItem, "Comments") %>'></asp:Label>
                            </div>                            
                        </ItemTemplate>
                    </asp:Repeater>
                </div>
            </div>
        </asp:Panel>
    </div>
</asp:Content>
