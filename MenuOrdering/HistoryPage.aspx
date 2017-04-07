<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="HistoryPage.aspx.cs" Inherits="MenuOrdering.History_page" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Order History</title>
    <link href="Styles.css" rel="stylesheet" />
</head>
<body>
    <h1>Order History</h1>
    <form id="form1" runat="server">
    <div>
        <asp:Table ID="Table1" runat="server" GridLines="Both" HorizontalAlign="Center" BorderStyle="Dashed" CellPadding="5" CellSpacing="20">
            <asp:TableHeaderRow>
                <asp:TableHeaderCell>Menu name</asp:TableHeaderCell>
                <asp:TableHeaderCell>Price</asp:TableHeaderCell>
                <asp:TableHeaderCell>Ordered phone number</asp:TableHeaderCell>
                <asp:TableHeaderCell>Deliver address</asp:TableHeaderCell>
                <asp:TableHeaderCell>Comments</asp:TableHeaderCell>
                <asp:TableHeaderCell>Ordered date</asp:TableHeaderCell>
            </asp:TableHeaderRow>

        </asp:Table>
    </div>
    </form>
</body>
</html>
