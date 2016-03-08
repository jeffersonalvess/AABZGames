<%@ Page Title="Login" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="AABZGames.Login" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div id="mainBody">
		<header>
			<div class="page-header">
				<h1>Login</h1>
			</div>
		</header>
		<section>
			<asp:Panel ID="panelLogin" Visible="false" runat="server">
                <div class="form-group row">
                    <label class="col-sm-1 form-control-label" for="txtUserName">Email:</label>
                    <div class="col-sm-3"><asp:TextBox ID="txtUserName" class="form-control" runat="server"></asp:TextBox></div>
                </div>
				<div class="form-group row">
				     <label class="col-sm-1 form-control-label" for="txtPwd">Password:</label>
                     <div class="col-sm-3"><asp:TextBox ID="txtPwd" class="form-control" runat="server" TextMode="Password"></asp:TextBox></div>
                </div>
                <div class="form-group row">
				    <asp:Button runat="server" ID="btnLogin" class="btn btn-info" OnClick="btn_login" Text="Login"></asp:Button>
				    <asp:Label runat="server" ID="lblResults" ></asp:Label>
                </div>

			</asp:Panel>
		</section>
		<footer>
		</footer>
	</div>
</asp:Content>
