<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="search.aspx.cs" Inherits="ASU_E_Commerce.search" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
   <link rel="icon" href="https://www.asu.edu/sites/all/themes/asu_home/favicon.ico"/>
    <link rel="stylesheet" type="text/css" href="StyleSheet1.css" />
    <title></title>
</head>
<body class="main_body">
    <form id="form1" runat="server">
        <div style="float: right">
            <asp:DropDownList AutoPostBack="true" CssClass="searchButton" ID="DropDownList1" runat="server" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged">
                <asp:ListItem Selected="True">Books</asp:ListItem>
                <asp:ListItem>Shirts</asp:ListItem>
                <asp:ListItem>Product ID</asp:ListItem>
                <asp:ListItem>People</asp:ListItem>
            </asp:DropDownList>
            <asp:DropDownList CssClass="searchButton" ID="DropDownList2" runat="server">
                <asp:ListItem Selected="True">ISBN</asp:ListItem>
                <asp:ListItem>Title</asp:ListItem>
                <asp:ListItem>Subject</asp:ListItem>
            </asp:DropDownList>
            <asp:TextBox CssClass="searchTextBox" ID="TextBox1" runat="server"></asp:TextBox>
            <asp:Button CssClass="searchButton" ID="Button1" runat="server" Text="Search" OnClick="Button1_Click" />
            <br />
            <div style="float: right">
                <asp:Label ID="Label1" runat="server" Text="Size" Visible="False"></asp:Label>
                <asp:DropDownList AutoPostBack="true" CssClass="searchButton" ID="DropDownList3" runat="server" Visible="False">
                    <asp:ListItem>xs</asp:ListItem>
                    <asp:ListItem>s</asp:ListItem>
                    <asp:ListItem Selected="True">m</asp:ListItem>
                    <asp:ListItem>l</asp:ListItem>
                    <asp:ListItem>xl</asp:ListItem>
                </asp:DropDownList>
                <asp:Label ID="Label2" runat="server" Text="Gender" Visible="False"></asp:Label>
                <asp:DropDownList AutoPostBack="true" CssClass="searchButton" ID="DropDownList4" runat="server" Visible="False">
                    <asp:ListItem>female</asp:ListItem>
                    <asp:ListItem>male</asp:ListItem>
                    <asp:ListItem Selected="True">unisex</asp:ListItem>
                </asp:DropDownList>
                <asp:Label ID="Label3" runat="server" Text="Age Group" Visible="False"></asp:Label>
                <asp:DropDownList AutoPostBack="true" CssClass="searchButton" ID="DropDownList5" runat="server" Visible="False">
                    <asp:ListItem>baby</asp:ListItem>
                    <asp:ListItem>kids</asp:ListItem>
                    <asp:ListItem Selected="True">teen</asp:ListItem>
                    <asp:ListItem>adult</asp:ListItem>
                </asp:DropDownList>
            </div>
        </div>
        <br style="clear: both" />
        <br />
        <div>
            <div>
                <asp:GridView ID="GridView1" runat="server" OnRowCommand="GridView1_RowCommand"></asp:GridView><!--Added OnRowCommand="GridView1_RowCommand" -->
            </div>
        </div>
    </form>
</body>
</html>
