<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="mycart.aspx.cs" Inherits="ASU_E_Commerce.mycart" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link rel="icon" href="https://www.asu.edu/sites/all/themes/asu_home/favicon.ico" />
    <link rel="stylesheet" type="text/css" href="StyleSheet1.css" />
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:GridView ID="GridView1" runat="server" OnRowCommand="GridView1_RowCommand">
        </asp:GridView>  <!-- Added OnRowCommand -->
        <asp:Button ID="Button1" CssClass="button" runat="server" Text="Checkout" OnClick="Button1_Click" />
        <asp:Button ID="Button2" CssClass="button" runat="server" Text="Back" OnClick="Button2_Click" />
    </div>
    </form>
</body>
</html>
