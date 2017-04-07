<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MenuPage.aspx.cs" Inherits="MenuOrdering.MenuPage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Menu Page</title>
    <%--<link rel="stylesheet" type="text/css" href="MenuPage.css" />--%>
    <link href="Styles.css" rel="stylesheet" />
</head>
<body>
    <h1>Current Menu</h1>
    <form id="form1" runat="server">

        <div class="order">
        <asp:Label ID="Label1" runat="server" Text="Main_course:"></asp:Label>
        <asp:CheckBoxList ID="main_course" runat="server" OnSelectedIndexChanged="main_course_SelectedIndexChanged" AutoPostBack="True">
        </asp:CheckBoxList>
        
                        
        <asp:Label ID="Label2" runat="server" Text="Drink:"></asp:Label>
        <asp:CheckBoxList ID="drink" runat="server" OnSelectedIndexChanged="drink_SelectedIndexChanged" AutoPostBack="True">
        </asp:CheckBoxList>

        <asp:Label ID="Label3" runat="server" Text="Dessert:"></asp:Label>
        <asp:CheckBoxList ID="dessert" runat="server" OnSelectedIndexChanged="dessert_SelectedIndexChanged" AutoPostBack="True">
        </asp:CheckBoxList>


            

        <div class="user_info">
            <asp:Label ID="name_label" runat="server" Text="Name:"></asp:Label>
            <div>
                <asp:TextBox ID="name" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Name required" 
                    ForeColor="Red" ControlToValidate="name">*</asp:RequiredFieldValidator>
            </div>
        
            <asp:Label ID="phone_label" runat="server" Text="Phone:"></asp:Label>
            <div>
                <asp:TextBox ID="phone" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Phone required" 
                    ForeColor="Red" ControlToValidate="phone">*</asp:RequiredFieldValidator>
            </div>
            <asp:Label ID="address_label" runat="server" Text="Address:"></asp:Label>
            <div>
                <asp:TextBox ID="address" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="Address required" 
                    ForeColor="Red" ControlToValidate="address">*</asp:RequiredFieldValidator>
            </div>
        </div>

        <asp:Label ID="comment_label" runat="server" Text="Comment:"></asp:Label>
        <div>
            <asp:TextBox ID="comment" runat="server"></asp:TextBox>
        </div>
        <asp:Label ID="error_message" runat="server" foreColor="Red"></asp:Label><br />
        <asp:ValidationSummary ID="ValidationSummary1" runat="server" ForeColor="Red" />

        <asp:Button ID="submit" runat="server" Text="submit" OnClick="submit_Click" />
        <asp:Button ID="cancel" runat="server" Text="cancel" OnClick="cancel_Click" />
        </div>

    </form>
</body>
</html>
