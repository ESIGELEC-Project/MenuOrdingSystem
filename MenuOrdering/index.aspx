<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="MenuOrdering.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Welcome</title>
    <link href="Styles.css" rel="stylesheet" />
</head>
<body class="newStyle1">
    <h1>Online Ordering System - Welcome!</h1>

    <!-- No Logged in User -->
    <% if(Session["Username"] == null) { %>
        <form id="LoginForm" runat="server">
            <asp:Label ID="LoginInstructions" runat="server" Text="Label">Register or Login to use this website.</asp:Label>
            <br /><br />
            <asp:Label ID="UsernameLabel" runat="server" Text="Label">Username: </asp:Label>
            <asp:TextBox ID="Username" runat="server"></asp:TextBox>
            <br /><br />
            <asp:Label ID="PasswordLabel" runat="server" Text="Label">Password: </asp:Label>
            <asp:TextBox ID="Password" runat="server" TextMode="Password"></asp:TextBox>
            <br />
            <asp:Label ID="LoginError" runat="server" Text="" ForeColor="Red"></asp:Label>
            <br />
            <br />
            <asp:Button ID="LoginButton" runat="server" Text="Login" OnClick="LoginButton_Click" />
            <asp:Button ID="RegisterButton" runat="server" Text="Register" OnClick="RegisterButton_Click" />
        </form>
    <% } %>

    <!-- Logged in User -->
    <% if(Session["Username"] != null) { %>
        <form id="ButtonBox" runat="server">
            <asp:Button ID="MakeOrderButton" runat="server" Text="Make Order" OnClick="MakeOrderButton_Click" />
            <br /><br />
            <asp:Button ID="OrderHistoryButton" runat="server" Text="Order History" OnClick="OrderHistoryButton_Click" />
            <br /><br />
            <asp:Button ID="LogoutButton" runat="server" Text="Logout" OnClick="LogoutButton_Click" />
        </form>
    <% } %>
</body>
</html>
