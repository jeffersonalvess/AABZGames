<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="OrderHistory.aspx.cs" Inherits="AABZGames.OrderHistory" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="page-header"><h1>Order History</h1></div>
    <asp:Label runat="server" ID="lblResults2" BackColor="Red"></asp:Label>
	<asp:Table ID="tblData" class="table table-hover" runat="server">
			<asp:TableHeaderRow>
				<asp:TableHeaderCell>Id </asp:TableHeaderCell>
				<asp:TableHeaderCell>Shipping Address Id</asp:TableHeaderCell>
				<asp:TableHeaderCell>Billing Address Id</asp:TableHeaderCell>
                <asp:TableHeaderCell>Product Order</asp:TableHeaderCell>
			</asp:TableHeaderRow>
    </asp:Table>
</asp:Content>
