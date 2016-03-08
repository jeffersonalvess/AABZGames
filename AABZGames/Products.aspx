<%@ Page Title="Products" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Products.aspx.cs" Inherits="AABZGames.Products" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
   
     <div class="row" style="margin-top: 30px;">

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

        <div class="col-md-10">

            <ef:EntityDataSource ID="ProductsListDataSource" runat="server" 
                EntitySetName="Products" ContextTypeName="AABZGames.Model.AABZContext"
                OrderBy="it.price"
                OnQueryCreated="ProductsListDataSource_QueryCreated"/>

            <div class="row">
                <asp:ListView ID="ProductsListView" runat="server" DataSourceID="ProductsListDataSource">
                <ItemTemplate>
                    <div class="col-md-3">
                        <div class="btn btn-products productItems">
                            <asp:HyperLink runat="server" NavigateUrl='<%# "~/ProductDetails.aspx?productID=" + Eval("Id") %>'>
                                <img alt="<%# Eval("name") %>" src="<%# "./Images/" + Eval("Id") + ".jpg" %>" height="150" />
                                <p><%# Eval("name") %></p>
                                
                                <div>
                                    <span class="productPrice"><%# (Convert.ToDouble(Eval("price"))).ToString("C") %></span>
                                    <asp:LinkButton ID="btnAddCart" CommandName="ProductID" CommandArgument='<%# Eval("Id") %>' runat="server" CssClass="btn btn-default btn-lg" OnClick="btnAddCart_Click">
                                        <span class="glyphicon glyphicon-shopping-cart" aria-hidden="true" style="color: #428BCA;"/>
                                    </asp:LinkButton>
                                </div>
                                
                            </asp:HyperLink>
                        </div>
                    </div>
                </ItemTemplate>
            </asp:ListView>
            </div>
        </div>

    </div>
</asp:Content>
