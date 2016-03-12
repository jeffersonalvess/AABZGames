<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Cart.aspx.cs" Inherits="AABZGames.Cart" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h2><%: Title %></h2>
    <asp:Panel ID="pnlNotLoggedIn" runat="server" Visible="false">
        Please log in to view the contents of your cart.
    </asp:Panel>
    <asp:Panel ID="pnlCart" runat="server" Visible="true">
        
        <asp:Repeater ID="rptCart" runat="server">
            <HeaderTemplate>
                <table>
                    <thead>
                        <td>Product</td>
                        <td>Quantity</td>
                        <td>Price</td>
                        <td></td>
                    </thead>
            </HeaderTemplate>
            <ItemTemplate>
                <tr>
                    <td>
                        <%#Eval("Product.name") %>
                    </td>
                    <td>
                        <%#Eval("quantity") %>
                    </td>
                    <td>
                        <%#moneyString(multiply((int)Eval("quantity"), (double)Eval("Product.price"))) %>
                    </td>
                    <td>
                        <asp:Button ID="btnDelete" runat="server" CommandArgument='<%#Eval("Id") %>' OnCommand="btnDelete_Command" Text="Remove" />
                    </td>
                </tr>
            </ItemTemplate>
            <FooterTemplate>
                </table>
            </FooterTemplate>
        </asp:Repeater>
        <asp:Button ID="btnCheckout" class="btn btn-info" runat="server" Text="Proceed to Checkout"  OnClick="btnCheckout_Click" />
    </asp:Panel>
</asp:Content>
