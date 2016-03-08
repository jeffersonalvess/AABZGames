<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Cart.aspx.cs" Inherits="AABZGames.Cart" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h2><%: Title %></h2>
    <asp:Panel ID="pnlNotLoggedIn" runat="server" Visible="false">
        Please log in to view the contents of your cart.
    </asp:Panel>
    <asp:Panel ID="pnlCart" runat="server" Visible="true">
        <!--Items will be added to the cart programmatically-->
        <asp:Table ID="tblCart" runat="server">
        </asp:Table>
        <asp:Button ID="btnCheckout" runat="server" Text="Proceed to Checkout"  OnClick="btnCheckout_Click" />
    </asp:Panel>
</asp:Content>
