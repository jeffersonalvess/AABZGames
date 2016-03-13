<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Checkout.aspx.cs" Inherits="AABZGames.Checkout" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h2><%: Title %></h2>
    <div>
        <asp:Panel ID="pnlNotLoggedIn" runat="server" Visible="false">
            You must be logged in to check out.
        </asp:Panel>
        <asp:Panel ID="pnlCheckout" runat="server" Visible="true">
            <h2>Payment</h2>
            Payment Amount: <asp:Label ID="lblPayment" runat="server"></asp:Label>
            <table>
                <tr>
                    <td>
                        Name on Card: 
                    </td>
                    <td>
                        <asp:TextBox ID="txtCcName" runat="server"></asp:TextBox>
                    </td>
                    <td>
                        <asp:RequiredFieldValidator ID="reqCcName" runat="server" ControlToValidate="txtCcName" ErrorMessage="Please enter a name." ForeColor="Red" EnableClientScript="true"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td>
                        Card Number: 
                    </td>
                    <td>
                        <asp:TextBox ID="txtCcNumber" runat="server"></asp:TextBox>
                    </td>
                    <td>
                        <asp:RequiredFieldValidator ID="reqCcNumber" runat="server" ControlToValidate="txtCcNumber" ErrorMessage="Please enter a credit or debit card number. " ForeColor="Red" Display="Dynamic" EnableClientScript="true"></asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator ID="regCcNumber" runat="server" ControlToValidate="txtCcNumber" ValidationExpression="[0-9]{16}" ErrorMessage="Credit card number is in the wrong format." ForeColor="Red" Display="Dynamic" EnableClientScript="true"></asp:RegularExpressionValidator>
                    </td>
                </tr>
                <tr>
                    <td>
                        Expiration: 
                    </td>
                    <td>
                        Month: <asp:DropDownList ID="drpCcMonth" runat="server"></asp:DropDownList> 
                        Year: <asp:DropDownList ID="drpCcYear" runat="server"></asp:DropDownList>
                    </td>
                    <td>
                    </td>
                </tr>
                <tr>
                    <td>
                        CVV Code: 
                    </td>
                    <td>
                        <asp:TextBox ID="txtCcCvv" runat="server" MaxLength="3"></asp:TextBox>
                    </td>
                    <td>
                        <asp:RequiredFieldValidator ID="reqCcCvv" runat="server" ControlToValidate="txtCcCvv" ErrorMessage="Please enter a CVV code. " ForeColor="Red" Display="Dynamic" EnableClientScript="true"></asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator ID="regCcCvv" runat="server" ControlToValidate="txtCcCvv" ValidationExpression="[0-9]{3}" ErrorMessage="CVV Code is in the wrong format." ForeColor="Red" Display="Dynamic" EnableClientScript="true"></asp:RegularExpressionValidator>
                    </td>
                </tr>
            </table>
            Billing Address:<br />
            <asp:Label ID="lblBillingAddress" runat="server" Text="Same as shipping address" Visible="true"></asp:Label><br />
            <asp:Panel ID="pnlBillingAddress" runat="server" Visible="false">
                <table>
                    <tr>
                        <td>
                            Address Line 1: 
                        </td>
                        <td>
                            <asp:TextBox ID="txtAddress1" runat="server" AutoCompleteType="HomeStreetAddress"></asp:TextBox>
                        </td>
                        <td>
                            <asp:RequiredFieldValidator ID="reqAddress1" runat="server" ControlToValidate="txtAddress1" ErrorMessage="Please enter an address." ForeColor="Red" EnableClientScript="true"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            Address Line 2: 
                        </td>
                        <td>
                            <asp:TextBox ID="txtAddress2" runat="server"></asp:TextBox>
                        </td>
                        <td>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            City: 
                        </td>
                        <td>
                            <asp:TextBox ID="txtCity" runat="server" AutoCompleteType="HomeCity"></asp:TextBox>
                        </td>
                        <td>
                            <asp:RequiredFieldValidator ID="reqCity" runat="server" ControlToValidate="txtCity" ErrorMessage="Please enter a city." ForeColor="Red" EnableClientScript="true"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            State: 
                        </td>
                        <td>
                            <asp:TextBox ID="txtState" runat="server" MaxLength="2"></asp:TextBox>
                        </td>
                        <td>
                            <asp:RequiredFieldValidator ID="reqState" runat="server" ControlToValidate="txtState" ErrorMessage="Please enter a state." ForeColor="Red" EnableClientScript="true"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            Zip Code: 
                        </td>
                        <td>
                            <asp:TextBox ID="txtZipCode" runat="server" AutoCompleteType="HomeZipCode"></asp:TextBox>
                        </td>
                        <td>
                            <asp:RequiredFieldValidator ID="reqZipCode" runat="server" ControlToValidate="txtZipCode" ErrorMessage="Please enter a zip code. " ForeColor="Red" Display="Dynamic" EnableClientScript="true"></asp:RequiredFieldValidator>
                            <asp:RegularExpressionValidator ID="regZipCode" runat="server" ControlToValidate="txtZipCode" ValidationExpression="([0-9]{5})(-([0-9]{4}))?" ErrorMessage="Zip code is improperly formatted." ForeColor="Red" Display="Dynamic" EnableClientScript="true"></asp:RegularExpressionValidator>
                        </td>
                    </tr>
                </table>
            </asp:Panel>
            <h2>Shipping</h2>
            Your order will be shipped to the following address:<br />
            <asp:Table ID="tblAddress" runat="server">
            </asp:Table>
            <asp:Button ID="btnSubmit" runat="server" Text="Submit" OnClick="btnSubmit_Click" />
        </asp:Panel>
    </div>
</asp:Content>
