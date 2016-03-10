<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Cart.aspx.cs" Inherits="AABZGames.Cart" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h2><%: Title %></h2>
    <asp:Panel ID="pnlNotLoggedIn" runat="server" Visible="false">
        Please log in to view the contents of your cart.
    </asp:Panel>
    <asp:Panel ID="pnlCart" runat="server" Visible="true">
        <!--Items will be added to the cart programmatically-->
        <div id="page-header"><h1>Cart</h1></div>
        <div class="container">
            <asp:Table ID="tblCart" class="table table-hover" runat="server">
            </asp:Table>
            <asp:Button ID="btnCheckout" class="btn btn-info" runat="server" Text="Proceed to Checkout"  OnClick="btnCheckout_Click" />
        </div>

    </asp:Panel>
</asp:Content>
