<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="AABZGames._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <a href="Products.aspx">
        <div class="jumbotron">
            <center><img src="Images/HomeBanner.png" alt="Home Banner" height="300" /></center>
        </div>
    </a>

    <div class="row">
        <div class="col-md-4 ">
            <div class="btn btn-default homeItems">
                <asp:HyperLink runat="server" NavigateUrl="~/Products.aspx?category=Games&platform=ps4">
                    <img src="Images/PS4Games.png" height="150" />
                    <h4>PS4 Games</h4>
                </asp:HyperLink>
            </div>

        </div>
        <div class="col-md-4">
            <div class="btn btn-default homeItems">
                <asp:HyperLink  runat="server" NavigateUrl="~/Products.aspx?category=Consoles&category=Accessories">
                    <img src="Images/Consoles.png" height="150" />
                    <h4>Consoles & Accessories</h4>
                </asp:HyperLink>
            </div>
        </div>
        <div class="col-md-4">
            <div class="btn btn-default homeItems">
                <asp:HyperLink runat="server" NavigateUrl="~/Products.aspx?category=Games&platform=xone">
                    <img src="Images/XBOXGames.png" height="150" />
                    <h4>XBOX ONE Games</h4>
                </asp:HyperLink>
            </div>
        </div>
    </div>

</asp:Content>
