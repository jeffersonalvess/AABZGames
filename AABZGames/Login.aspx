<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="AABZGames.Login" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div id="mainBody">
		<header>
			<hgroup>
				<h1>Login</h1>
			</hgroup>
		</header>
		<section>
			<asp:Panel ID="panelLogin" Visible="false" runat="server">
				Email: <asp:TextBox ID="txtUserName" runat="server"></asp:TextBox><br/>
				Password: <asp:TextBox ID="txtPwd" runat="server" TextMode="Password"></asp:TextBox><br/>
				<asp:Button runat="server" ID="btnLogin" OnClick="btn_login" Text="Login"></asp:Button> <br>
				<asp:Label runat="server" ID="lblResults" ></asp:Label>
			</asp:Panel>
		</section>
		<footer>
		</footer>
	</div>
</asp:Content>
