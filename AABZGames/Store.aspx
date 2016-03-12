<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Store.aspx.cs" Inherits="AABZGames.WebForm1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <asp:Label runat="server" ID="lblGreeting"></asp:Label><br />
    <asp:LinkButton runat="server" ID="lnkbttnLogout" Text="Logout" Visible="false" OnClick="Logout"></asp:LinkButton>

</asp:Content>
