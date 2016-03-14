<%@ Page Title="Register" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="AABZGames.Register" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
              <div class="page-header">
                  <h1>Create your account</h1>

              </div>
            <div class="form-group  row">
                <label class="col-sm-2 form-control-label" for="txtFname">First name: <asp:RequiredFieldValidator ID="reqFname" ControlToValidate="txtFname" EnableClientScript="true" ErrorMessage="*" runat="server" SetFocusOnError="true"></asp:RequiredFieldValidator></label>
                <asp:TextBox ID="txtFname" CssClass="form-control fix-width" runat="server"></asp:TextBox>
            </div>
            <div class="form-group row">
                <label class="col-sm-2 form-control-lable" for="txtLastName">Last name: <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ControlToValidate="txtLastName" EnableClientScript="true" ErrorMessage="*" runat="server" SetFocusOnError="true"></asp:RequiredFieldValidator></label>
                <asp:TextBox ID="txtLastName" CssClass="form-control fix-width" runat="server"></asp:TextBox>
            </div>
            <div class="form-group row">
                <label class="col-sm-2 form-control-label" for="txtEmail">Email: <asp:RequiredFieldValidator ID="reqEmail" ControlToValidate="txtEmail" EnableClientScript="true" ErrorMessage="*" runat="server" SetFocusOnError="true"></asp:RequiredFieldValidator></label>
                <asp:TextBox ID="txtEmail" CssClass="form-control fix-width"  runat="server"></asp:TextBox>
                
            </div>
            <div class="form-group row">
                <label class="col-sm-2 form-control-label" for="txtPass">Password: <asp:RequiredFieldValidator ID="reqPass" ControlToValidate="txtPass" EnableClientScript="true" ErrorMessage="*" runat="server" SetFocusOnError="true"></asp:RequiredFieldValidator></label>
                <asp:TextBox ID="txtPass" CssClass="form-control fix-width"  runat="server" TextMode="Password"></asp:TextBox> 
                
            </div>
            <div class="form-group row">
               <label class="col-sm-2 form-control-label" for="txtConf">Confirm password: <asp:RequiredFieldValidator TextMode="Password" ID="reqConf" ControlToValidate="txtConf" EnableClientScript="true" ErrorMessage="*" runat="server" SetFocusOnError="true"></asp:RequiredFieldValidator></label>
                <asp:TextBox ID="txtConf" CssClass="form-control fix-width" runat="server" TextMode="Password"></asp:TextBox> 
               <asp:CompareValidator ID="comparePass" ControlToCompare="txtPass" ControlToValidate="txtConf" EnableClientScript="true" ErrorMessage="Passwords don't match" runat="server"></asp:CompareValidator>
            </div>
            <div class="form-group row">
                <label class="col-sm-2 form-control-label" for="txtPhone">Phone: <asp:RequiredFieldValidator ID="reqPhone" MaxLength="10" Columns="10" ControlToValidate="txtPhone" EnableClientScript="true" ErrorMessage="*" runat="server" SetFocusOnError="true"></asp:RequiredFieldValidator></label>
                <asp:TextBox ID="txtPhone" CssClass="form-control fix-width" runat="server" MaxLength="10" Columns="10"></asp:TextBox> 
                
            </div>
            <div class="form-group row">
                <label class="col-sm-2 form-control-label" for="txtAdd">Address: <asp:RequiredFieldValidator ID="reqAdd" ControlToValidate="txtAdd" EnableClientScript="true" ErrorMessage="*" runat="server" SetFocusOnError="true"></asp:RequiredFieldValidator></label>
                <asp:TextBox ID="txtAdd" CssClass="form-control fix-width" runat="server" MaxLength="30" Columns="30"></asp:TextBox> 
                
            </div>
            <div class="form-group row">
                <label class="col-sm-2 form-control-label" for="txtAdd2">Address 2:</label>
                <asp:TextBox ID="txtAdd2" CssClass="form-control fix-width"  MaxLength="30" Columns="30" runat="server"/>
                <br />
            </div>
            <div class="form-group row">
                <label class="col-sm-2 form-control-label" for="txtCity">City: <asp:RequiredFieldValidator ID="reqCity" ControlToValidate="txtCity" EnableClientScript="true" ErrorMessage="*" runat="server" SetFocusOnError="true"></asp:RequiredFieldValidator></label>
                <asp:TextBox ID="txtCity" CssClass="form-control fix-width" runat="server" MaxLength="20" Columns="10"></asp:TextBox> 
                
            </div>
            <div class="form-group row">
                <label class="col-sm-2 form-control-label" for="txtState">State: <asp:RequiredFieldValidator ID="reqState" MaxLength="2" Columns="2" ControlToValidate="txtState" EnableClientScript="true" ErrorMessage="*" runat="server" SetFocusOnError="true"></asp:RequiredFieldValidator></label>
                <asp:TextBox ID="txtState" CssClass="form-control fix-width" runat="server" MaxLength="2" Columns="2"></asp:TextBox> 
                
            </div>
            <div class="form-group row">
                <label class="col-sm-2 form-control-label" for="txtZip">Zip: <asp:RequiredFieldValidator ID="reqZip" MaxLength="5" Columns="5" ControlToValidate="txtZip" EnableClientScript="true" ErrorMessage="*" runat="server" SetFocusOnError="true"></asp:RequiredFieldValidator></label>
                <asp:TextBox ID="txtZip" CssClass="form-control fix-width" runat="server" MaxLength="5" Columns="5"></asp:TextBox> 
                
            </div>
            <div class="form-group row">
                <asp:CheckBox ID="chkBill" runat="server" AutoPostBack="true" OnCheckedChanged="onCheckChangedMethod"/>
                <asp:Label for="chkBill" runat="server" Text="Use this as Billing Address"></asp:Label> 
            </div>
            <div id="registerPanel">
            <asp:Panel runat="server" ID="panelBilling" Visible="true">
                 <h4>Billing Information</h4>
                <div class="form-group row">
                    <label class="col-sm-2 form-control-label" for="txtBill1">Address: <asp:RequiredFieldValidator ID="reqBill1" ControlToValidate="txtBill1" EnableClientScript="true" ErrorMessage="*" runat="server" SetFocusOnError="true"></asp:RequiredFieldValidator></label>
                    <asp:TextBox ID="txtBill1" CssClass="form-control fix-width" runat="server" MaxLength="30" Columns="20"></asp:TextBox> 
                    
                </div>
                <div class="form-group row">
                    <label class="col-sm-2 form-control-label" for="txtBill2">Address 2:</label>
                    <asp:TextBox ID="txtBill2" CssClass="form-control fix-width" runat="server" MaxLength="30" Columns="20"></asp:TextBox>
                </div>
                 <div class="form-group row">
                    <label class="col-sm-2 form-control-label" for="billcity">City: <asp:RequiredFieldValidator ID="reqbillcity" ControlToValidate="billcity" EnableClientScript="true" ErrorMessage="*" runat="server" SetFocusOnError="true"></asp:RequiredFieldValidator>     </label>
                    <asp:TextBox ID="billcity" CssClass="form-control fix-width" runat="server" MaxLength="20" Columns="10"></asp:TextBox>
                    
                  </div>
                <div class="form-group row">
                    <label class="col-sm-2 form-control-label" for="billstate">State: <asp:RequiredFieldValidator ID="reqbillstate" ControlToValidate="billstate" EnableClientScript="true" ErrorMessage="*" runat="server" SetFocusOnError="true"></asp:RequiredFieldValidator></label>
                    <asp:TextBox ID="billstate" CssClass="form-control fix-width"  runat="server" MaxLength="2" Columns="2"></asp:TextBox> 
                   
                </div>
                <div class="form-group row">
                    <label class="col-sm-2 form-control-label" for="billzip">Zip: <asp:RequiredFieldValidator ID="reqbillzip" ControlToValidate="billzip" EnableClientScript="true" ErrorMessage="*" runat="server" SetFocusOnError="true"></asp:RequiredFieldValidator></label>
                    <asp:TextBox ID="billzip" CssClass="form-control fix-width" runat="server" MaxLength="5" Columns="5"></asp:TextBox>
                    
                </div>
            </asp:Panel>
            </div>
            
            <asp:Button ID="btnSubmit" class="btn btn-info" runat="server" CausesValidation="true" Text="Submit" OnClick="BtnSubmit"/> <br/>
            <asp:Label ID="error" runat="server"></asp:Label>
</asp:Content>
