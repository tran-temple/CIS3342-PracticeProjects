<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="ViewReservations.aspx.cs" Inherits="Project3.ViewReservations" EnableEventValidation="false"%>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="BodyPlaceHolder" runat="server">
    <div class="col-lg-8 offset-lg-2 mt-3 border">
        <div class="row form-group justify-content-center">
            <asp:Label ID="lblGeneral_Error" runat="server" CssClass="text-danger"></asp:Label>
        </div>        
        <asp:Panel ID="pnlReservationList" runat="server">
            <!-- The output GridView: contains (data) reservations list -->
            <div class="row justify-content-start mt-3">
                <div class="col">
                    <asp:Button ID="btnDelete" runat="server" Text="Delete" CssClass="btn-primary mr-2" OnClick="btnDelete_Click"/>
                    <asp:Button ID="btnModify" runat="server" Text="Modify" CssClass="btn-primary" onclick="btnModify_Click"/>
                </div>
            </div>
            <div class="row justify-content-start mt-3">
                <div class="col mb-3">
                    <asp:GridView ID="gvReservations" runat="server" AutoGenerateColumns="false" OnRowDataBound="gvReservations_RowDataBound" OnSelectedIndexChanged="gvReservations_SelectedIndexChanged">
                        <Columns>
                            <asp:TemplateField HeaderText="ID" ItemStyle-HorizontalAlign="Center">
                                <ItemTemplate>
                                    <%# Container.DataItemIndex + 1 %>
                                </ItemTemplate>
                                <ItemStyle Width="7%" />
                            </asp:TemplateField>
                            <asp:BoundField DataField="ReservationName" HeaderText="Reservation Name" ItemStyle-HorizontalAlign="Center"/>
                            <asp:BoundField DataField="ReservationTime" HeaderText="Reservation Time" ItemStyle-HorizontalAlign="Center"/>
                            <asp:BoundField DataField="Phone" HeaderText="Phone Number" ItemStyle-HorizontalAlign="Center"/>

                            <asp:BoundField DataField="ReservationID" HeaderText="ReservationID" HeaderStyle-CssClass="hiddenCol" ItemStyle-CssClass="hiddenCol" />
                            <asp:BoundField DataField="RestaurantID" HeaderText="RestaurantID" HeaderStyle-CssClass="hiddenCol" ItemStyle-CssClass="hiddenCol" />
                        </Columns>
                        <HeaderStyle BackColor="#99CCFF" HorizontalAlign="Center" Wrap="False" />
                    </asp:GridView>
                </div>
            </div>
        </asp:Panel>
    </div>
</asp:Content>
