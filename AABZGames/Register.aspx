<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="AABZGames.Register" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
      <h1>Create your account</h1>
            <p>
                <label class="field" for="fname">First:</label>
                <asp:TextBox ID="txtFname" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="reqFname" ControlToValidate="txtFname" EnableClientScript="true" ErrorMessage="*" runat="server" SetFocusOnError="true"></asp:RequiredFieldValidator>
            </p>
            <p>
                <label class="field" for="lname">Last:</label>
                <asp:TextBox ID="txtLastName" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="reqLname" ControlToValidate="txtLastName" EnableClientScript="true" ErrorMessage="*" runat="server" SetFocusOnError="true"></asp:RequiredFieldValidator>
            </p>
            <p>
                <label class="field" for="txtEmail">Email:</label>
                <asp:TextBox ID="txtEmail"  runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="reqEmail" ControlToValidate="txtEmail" EnableClientScript="true" ErrorMessage="*" runat="server" SetFocusOnError="true"></asp:RequiredFieldValidator>
            </p>
            <p>
                <label class="field" for="txtPass">Password:</label>
                <asp:TextBox ID="txtPass" runat="server" TextMode="Password"></asp:TextBox> 
                <asp:RequiredFieldValidator ID="reqPass" ControlToValidate="txtPass" EnableClientScript="true" ErrorMessage="*" runat="server" SetFocusOnError="true"></asp:RequiredFieldValidator>
            </p>
            <p>
               <label class="field" for="conf">Confirm:</label>
                <asp:TextBox ID="txtConf" runat="server" TextMode="Password"></asp:TextBox> 
               <asp:RequiredFieldValidator TextMode="Password" ID="reqConf" ControlToValidate="txtConf" EnableClientScript="true" ErrorMessage="*" runat="server" SetFocusOnError="true"></asp:RequiredFieldValidator><asp:CompareValidator ID="comparePass" ControlToCompare="txtPass" ControlToValidate="txtConf" EnableClientScript="true" ErrorMessage="Passwords don't match" runat="server"></asp:CompareValidator>
            </p>
            <p>
                <label class="field" for="txtPhone">Phone:</label>
                <asp:TextBox ID="txtPhone" runat="server" MaxLength="10" Columns="10"></asp:TextBox> 
                <asp:RequiredFieldValidator ID="reqPhone" MaxLength="10" Columns="10" ControlToValidate="txtPhone" EnableClientScript="true" ErrorMessage="*" runat="server" SetFocusOnError="true"></asp:RequiredFieldValidator>
            </p>
            <p>
                <label class="field" for="add1">Address 1:</label>
                <asp:TextBox ID="txtAdd" runat="server" MaxLength="30" Columns="20"></asp:TextBox> 
                <asp:RequiredFieldValidator ID="reqAdd" ControlToValidate="txtAdd" EnableClientScript="true" ErrorMessage="*" runat="server" SetFocusOnError="true"></asp:RequiredFieldValidator>
            </p>
            <p>
                <label class="field" for="txtAdd2">Address 2:</label>
                <asp:Textbox ID="txtAdd2" MaxLength="30" Columns="20" runat="server"/>
                <br />
            </p>
            <p>
                <label class="field" for="city">City:</label>
                <asp:TextBox ID="txtCity" runat="server" MaxLength="20" Columns="10"></asp:TextBox> 
                <asp:RequiredFieldValidator ID="reqCity" ControlToValidate="txtCity" EnableClientScript="true" ErrorMessage="*" runat="server" SetFocusOnError="true"></asp:RequiredFieldValidator>
            </p>
            <p>
                <label class="field" for="state">State:</label>
                <asp:TextBox ID="txtState" runat="server" MaxLength="2" Columns="2"></asp:TextBox> 
                <asp:RequiredFieldValidator ID="reqState" MaxLength="2" Columns="2" ControlToValidate="txtState" EnableClientScript="true" ErrorMessage="*" runat="server" SetFocusOnError="true"></asp:RequiredFieldValidator>
            </p>
            <p>
                <label class="field" for="zip">Zip:</label>
                <asp:TextBox ID="txtZip" runat="server" MaxLength="5" Columns="5"></asp:TextBox> 
                <asp:RequiredFieldValidator ID="reqZip" MaxLength="5" Columns="5" ControlToValidate="txtZip" EnableClientScript="true" ErrorMessage="*" runat="server" SetFocusOnError="true"></asp:RequiredFieldValidator>
            </p>
            <p>
                <asp:CheckBox ID="chkBill" runat="server" AutoPostBack="true" OnCheckedChanged="onCheckChangedMethod"/>
                <asp:Label for="chkBill" runat="server" Text="Use this as Billing Address"></asp:Label> 
            </p>
            <asp:Panel runat="server" ID="panelBilling" Visible="true">
                <p>
                    <label class="field" for="txtBill1">Billing Address 1:</label>
                    <asp:TextBox ID="txtBill1" runat="server" MaxLength="30" Columns="20"></asp:TextBox> 
                </p>
                <p>
                    <label class="field" for="txtBill2">Billing Address 2:</label>
                    <asp:TextBox ID="txtBill2" runat="server" MaxLength="30" Columns="20"></asp:TextBox> 
                    <br />
                </p>
                    <p>
                <label class="field" for="city">City:</label>
                <asp:TextBox ID="TextBox1" runat="server" MaxLength="20" Columns="10"></asp:TextBox> 
             
                </p>
                <p>
                    <label class="field" for="billstate">State:</label>
                    <asp:TextBox ID="billstate" runat="server" MaxLength="2" Columns="2"></asp:TextBox> 
            
                </p>
                <p>
                    <label class="field" for="billzip">Zip:</label>
                    <asp:TextBox ID="billzip" runat="server" MaxLength="5" Columns="5"></asp:TextBox> 
            
                </p>
            </asp:Panel>
            <asp:Button ID="btnSubmit" runat="server" CausesValidation="true" Text="Submit" OnClick="BtnSubmit"/> <br/>
            <asp:Label ID="error" runat="server"></asp:Label>
</asp:Content>
