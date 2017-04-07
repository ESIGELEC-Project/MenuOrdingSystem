<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Registration.aspx.cs" Inherits="MenuOrdering.Registration" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Register</title>
    <link href="Styles.css" rel="stylesheet" />
</head>
<body>
    <h1>Register</h1>
    <form id="RegistrationForm" runat="server">
        <asp:Label ID="RegistrationInstructions" runat="server" Text="Label">All Fields Are Required.</asp:Label>
        <br /><br />
        <asp:Label ID="UsernameLabel" runat="server" Text="Label">Username: </asp:Label>
        <asp:TextBox ID="Username" runat="server"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Username Required" ForeColor="Red" ControlToValidate="Username">*</asp:RequiredFieldValidator>
        <br />
        <asp:Label ID="PasswordLabel" runat="server" Text="Label">Password: </asp:Label>
        <asp:TextBox ID="Password" runat="server" TextMode="Password"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Password Required" ForeColor="Red" ControlToValidate="Password">*</asp:RequiredFieldValidator>
        <br />
        <asp:Label ID="PasswordConfirmLabel" runat="server" Text="Label">Password Confirm: </asp:Label>
        <asp:TextBox ID="PasswordConfirm" runat="server" TextMode="Password"></asp:TextBox>
        <asp:CompareValidator ID="CompareValidator1" runat="server" ErrorMessage="Password Must Match" ForeColor="Red" ControlToCompare="Password" ControlToValidate="PasswordConfirm">*</asp:CompareValidator>
        <br />
        <asp:Label ID="FirstNameLabel" runat="server" Text="Label">First Name: </asp:Label>
        <asp:TextBox ID="First" runat="server"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="First Name Required" ForeColor="Red" ControlToValidate="First">*</asp:RequiredFieldValidator>
        <br />
        <asp:Label ID="LastNameLabel" runat="server" Text="Label">Last Name: </asp:Label>
        <asp:TextBox ID="Last" runat="server"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="Last Name Required" ForeColor="Red" ControlToValidate="Last">*</asp:RequiredFieldValidator>
        <br />
        <asp:Label ID="PhoneLabel" runat="server" Text="Label">Phone Number: </asp:Label>
        <asp:TextBox ID="Phone" runat="server" TextMode="Phone"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ErrorMessage="Phone Number Required" ForeColor="Red" ControlToValidate="Phone">*</asp:RequiredFieldValidator>
        <br />
        <asp:ValidationSummary ID="ValidationSummary1" runat="server" ForeColor="Red" />
        <br />
        <asp:Button ID="CancelButton" runat="server" Text="Cancel" OnClick="CancelButton_Click" />
        <asp:Button ID="RegisterButton" runat="server" Text="Register" OnClick="RegisterButton_Click" />
    </form>
</body>
</html>
