<%@ Page Title="Products" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Products.aspx.cs" Inherits="AABZGames.Products" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
   
     <div class="row" style="margin-top: 20px;">

        <div class="col-md-2 list-group">
            
            <ef:EntityDataSource ID="PlatformListDataSource" runat="server" 
                EntitySetName="Platforms" ContextTypeName="AABZGames.Model.AABZContext"
                OrderBy="it.Name"
                Where="it.isVisible == true" />

            <ef:EntityDataSource ID="CategoryListDataSource" runat="server" 
                EntitySetName="Categories" ContextTypeName="AABZGames.Model.AABZContext"
                OrderBy="it.Name"
                Where="it.isVisible == true" />

            <asp:HyperLink CssClass="list-group-item active" runat="server">Platform</asp:HyperLink>
            <asp:ListView ID="PlatformsListView" runat="server" DataSourceID="PlatformListDataSource">
                <ItemTemplate>
                    <asp:HyperLink runat="server" CssClass="list-group-item" NavigateUrl='<%# GetCorrectURL(Eval("Name").ToString(), "Platform") %>' Text='<%# Eval("Name") %>' />
                </ItemTemplate>
            </asp:ListView>

            <asp:HyperLink runat="server" CssClass="list-group-item active">Category</asp:HyperLink>
            <asp:ListView ID="CategoriesListView" runat="server" DataSourceID="CategoryListDataSource">
                <ItemTemplate>
                    <asp:HyperLink runat="server" CssClass="list-group-item" NavigateUrl='<%# GetCorrectURL(Eval("Name").ToString(), "Category") %>' Text='<%# Eval("Name") %>' />
                </ItemTemplate>
            </asp:ListView>

        </div>

        <div class="col-md-8">

        </div>

    </div>
</asp:Content>
