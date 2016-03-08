<%@ Page Title="Register" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="AABZGames.Register" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
              <div class="page-header">
                  <h1>Create your account</h1>

              </div>
            <div class="form-group  row">
                <label class="col-sm-2 form-control-label" for="txtFname">First name:</label>
                <asp:TextBox ID="txtFname" CssClass="form-control fix-width" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="reqFname" ControlToValidate="txtFname" EnableClientScript="true" ErrorMessage="*" runat="server" SetFocusOnError="true"></asp:RequiredFieldValidator>
            </div>
            <div class="form-group row">
                <label class="col-sm-2 form-control-lable" for="txtLastName">Last name:</label>
                <asp:TextBox ID="txtLastName" CssClass="form-control fix-width" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="reqLname" ControlToValidate="txtLastName" EnableClientScript="true" ErrorMessage="*" runat="server" SetFocusOnError="true"></asp:RequiredFieldValidator>
            </div>
            <div class="form-group row">
                <label class="col-sm-2 form-control-label" for="txtEmail">Email:</label>
                <asp:TextBox ID="txtEmail" CssClass="form-control fix-width"  runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="reqEmail" ControlToValidate="txtEmail" EnableClientScript="true" ErrorMessage="*" runat="server" SetFocusOnError="true"></asp:RequiredFieldValidator>
            </div>
            <div class="form-group row">
                <label class="col-sm-2 form-control-label" for="txtPass">Password:</label>
                <asp:TextBox ID="txtPass" CssClass="form-control fix-width"  runat="server" TextMode="Password"></asp:TextBox> 
                <asp:RequiredFieldValidator ID="reqPass" ControlToValidate="txtPass" EnableClientScript="true" ErrorMessage="*" runat="server" SetFocusOnError="true"></asp:RequiredFieldValidator>
            </div>
            <div class="form-group row">
               <label class="col-sm-2 form-control-label" for="txtConf">Confirm password:</label>
                <asp:TextBox ID="txtConf" CssClass="form-control fix-width" runat="server" TextMode="Password"></asp:TextBox> 
               <asp:RequiredFieldValidator TextMode="Password" ID="reqConf" ControlToValidate="txtConf" EnableClientScript="true" ErrorMessage="*" runat="server" SetFocusOnError="true"></asp:RequiredFieldValidator><asp:CompareValidator ID="comparePass" ControlToCompare="txtPass" ControlToValidate="txtConf" EnableClientScript="true" ErrorMessage="Passwords don't match" runat="server"></asp:CompareValidator>
            </div>
            <div class="form-group row">
                <label class="col-sm-2 form-control-label" for="txtPhone">Phone:</label>
                <asp:TextBox ID="txtPhone" CssClass="form-control fix-width" runat="server" MaxLength="10" Columns="10"></asp:TextBox> 
                <asp:RequiredFieldValidator ID="reqPhone" MaxLength="10" Columns="10" ControlToValidate="txtPhone" EnableClientScript="true" ErrorMessage="*" runat="server" SetFocusOnError="true"></asp:RequiredFieldValidator>
            </div>
            <div class="form-group row">
                <label class="col-sm-2 form-control-label" for="txtAdd">Address:</label>
                <asp:TextBox ID="txtAdd" CssClass="form-control fix-width" runat="server" MaxLength="30" Columns="30"></asp:TextBox> 
                <asp:RequiredFieldValidator ID="reqAdd" ControlToValidate="txtAdd" EnableClientScript="true" ErrorMessage="*" runat="server" SetFocusOnError="true"></asp:RequiredFieldValidator>
            </div>
            <div class="form-group row">
                <label class="col-sm-2 form-control-label" for="txtAdd2">Address 2:</label>
                <asp:TextBox ID="txtAdd2" CssClass="form-control fix-width"  MaxLength="30" Columns="30" runat="server"/>
                <br />
            </div>
            <div class="form-group row">
                <label class="col-sm-2 form-control-label" for="txtCity">City:</label>
                <asp:TextBox ID="txtCity" CssClass="form-control fix-width" runat="server" MaxLength="20" Columns="10"></asp:TextBox> 
                <asp:RequiredFieldValidator ID="reqCity" ControlToValidate="txtCity" EnableClientScript="true" ErrorMessage="*" runat="server" SetFocusOnError="true"></asp:RequiredFieldValidator>
            </div>
            <div class="form-group row">
                <label class="col-sm-2 form-control-label" for="txtState">State:</label>
                <asp:TextBox ID="txtState" CssClass="form-control fix-width" runat="server" MaxLength="2" Columns="2"></asp:TextBox> 
                <asp:RequiredFieldValidator ID="reqState" MaxLength="2" Columns="2" ControlToValidate="txtState" EnableClientScript="true" ErrorMessage="*" runat="server" SetFocusOnError="true"></asp:RequiredFieldValidator>
            </div>
            <div class="form-group row">
                <label class="col-sm-2 form-control-label" for="txtZip">Zip:</label>
                <asp:TextBox ID="txtZip" CssClass="form-control fix-width" runat="server" MaxLength="5" Columns="5"></asp:TextBox> 
                <asp:RequiredFieldValidator ID="reqZip" MaxLength="5" Columns="5" ControlToValidate="txtZip" EnableClientScript="true" ErrorMessage="*" runat="server" SetFocusOnError="true"></asp:RequiredFieldValidator>
            </div>
            <div class="form-group row">
                <asp:CheckBox ID="chkBill" runat="server" AutoPostBack="true" OnCheckedChanged="onCheckChangedMethod"/>
                <asp:Label for="chkBill" runat="server" Text="Use this as Billing Address"></asp:Label> 
            </div>
            <asp:Panel runat="server" ID="panelBilling" Visible="true">
                 <h4>Billing Information</h4>
                <div class="form-group row">
                    <label class="col-sm-2 form-control-label" for="txtBill1">Address:</label>
                    <asp:TextBox ID="txtBill1" CssClass="form-control fix-width" runat="server" MaxLength="30" Columns="20"></asp:TextBox> 
                </div>
                <div class="form-group row">
                    <label class="col-sm-2 form-control-label" for="txtBill2">Address 2:</label>
                    <asp:TextBox ID="txtBill2" CssClass="form-control fix-width" runat="server" MaxLength="30" Columns="20"></asp:TextBox> 
                    <br />
                </div>
                 <div class="form-group row">
                    <label class="col-sm-2 form-control-label" for="billcity">City:</label>
                    <asp:TextBox ID="billcity" CssClass="form-control fix-width" runat="server" MaxLength="20" Columns="10"></asp:TextBox> 
                  </div>
                <div class="form-group row">
                    <label class="col-sm-2 form-control-label" for="billstate">State:</label>
                    <asp:TextBox ID="billstate" CssClass="form-control fix-width"  runat="server" MaxLength="2" Columns="2"></asp:TextBox> 
            
                </div>
                <div class="form-group row">
                    <label class="col-sm-2 form-control-label" for="billzip">Zip:</label>
                    <asp:TextBox ID="billzip" CssClass="form-control fix-width" runat="server" MaxLength="5" Columns="5"></asp:TextBox>
                </div>
            </asp:Panel>
            <asp:Button ID="btnSubmit" class="btn btn-info" runat="server" CausesValidation="true" Text="Submit" OnClick="BtnSubmit"/> <br/>
            <asp:Label ID="error" runat="server"></asp:Label>
</asp:Content>
