<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="HomePage.aspx.cs" Inherits="Project3.HomePage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="BodyPlaceHolder" runat="server">
    <div class="col-lg-8 offset-lg-2 mt-3">
        <!-- Search area -->
        <div class="row justify-content-center mt-3">
            <div class="col-md-6">
                <asp:TextBox ID="txtSearch" runat="server" CssClass="w-100"></asp:TextBox>
            </div>
            <div class="col">
                <asp:DropDownList ID="ddlCategory" runat="server" >
                    <asp:ListItem Value="-1" Selected="True">Select a category...</asp:ListItem>
                </asp:DropDownList>
                &nbsp;&nbsp;
                <asp:Button ID="btnSearch" runat="server" Text="Search" CssClass="btn-primary" OnClick="btnSearch_Click"/>
            </div>            
        </div>

        <!-- Showing the list of restaurants -->
        <div class="row justify-content-center mt-3">
            <div class="col">
                <asp:HiddenField ID="hidSearchClicked" runat="server" />
                <asp:GridView ID="gvRestaurants" runat="server" AutoGenerateColumns="false"
                    OnSelectedIndexChanged="gvRestaurants_SelectedIndexChanged" OnPageIndexChanging="gvRestaurants_PageIndexChanging" AllowPaging="true" PageSize="4">
                    <Columns> 
                        <asp:CommandField ButtonType="Link" ShowSelectButton="true" SelectText="View">                            
                        </asp:CommandField>
                        <asp:TemplateField HeaderText="Image">
                            <ItemTemplate>
                                <asp:Image ID="imgRestaurant" runat="server" ImageUrl='<%# "images/" + Eval("ImageURL") %>' CssClass="w-100"/>
                            </ItemTemplate>
                            <ItemStyle Width="25%" />
                        </asp:TemplateField>
                        <asp:BoundField DataField="Name" HeaderText="Restaurant Name" ItemStyle-Width="30%"/>
                        <asp:BoundField DataField="Description" HeaderText="Description" />

                        <asp:BoundField DataField="RestaurantID" HeaderText="RestaurantID" HeaderStyle-CssClass="hiddenCol" ItemStyle-CssClass="hiddenCol" />
                        <asp:BoundField DataField="UserID" HeaderText="UserID" HeaderStyle-CssClass="hiddenCol" ItemStyle-CssClass="hiddenCol" />
                    </Columns>
                    <HeaderStyle BackColor="#99CCFF" HorizontalAlign="Center" Wrap="False" />
                </asp:GridView>
            </div>
        </div>

    </div>
</asp:Content>
