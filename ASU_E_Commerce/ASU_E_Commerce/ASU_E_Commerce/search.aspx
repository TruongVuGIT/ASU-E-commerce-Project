<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="search.aspx.cs" Inherits="ASU_E_Commerce.search" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
   <link rel="icon" href="https://www.asu.edu/sites/all/themes/asu_home/favicon.ico"/>
    <link rel="stylesheet" type="text/css" href="StyleSheet1.css" />
    <title></title>
    <style type="text/css">
        .auto-style1 {
            height: 31px;
        }
    </style>
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
                <asp:ListBox ID="ListBox1" runat="server" Width="1054px" Font-Size="18"></asp:ListBox>
                <br />
                <br />
                <asp:Button ID="Button2" CssClass="button" runat="server" Text="View Details" OnClick="Button2_Click" />
                &nbsp;&nbsp;&nbsp;&nbsp
                <br />
                <div>
                    <table id="details" style="font-size:28px";>
                        <tr>
                            <td>
                                Product ID
                            </td>
                            <td>
                                <asp:Label ID="Label4" runat="server" Text=""></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                ISBN
                            </td>
                            <td>
                                <asp:Label ID="Label5" runat="server" Text=""></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td class="auto-style1">
                                Title
                            </td>
                            <td class="auto-style1">
                                <asp:Label ID="Label6" runat="server" Text=""></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                Subject
                            </td>
                            <td>
                                <asp:Label ID="Label7" runat="server" Text=""></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                Quantity
                            </td>
                            <td>
                                <asp:Label ID="Label8" runat="server" Text=""></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                Price
                            </td>
                            <td>
                                <asp:Label ID="Label9" runat="server" Text=""></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                Bidding Price
                            </td>
                            <td>
                                <asp:Label ID="Label10" runat="server" Text=""></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                Seller's Name
                            </td>
                            <td>
                                <asp:Label ID="Label11" runat="server" Text=""></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                Seller's Email&nbsp;&nbsp;
                            </td>
                            <td>
                                <asp:Label ID="Label12" runat="server" Text=""></asp:Label>
                            </td>
                        </tr>
                    </table>
                </div>
                <br />
                Quantity:
                <asp:DropDownList ID="DropDownList6" runat="server" Font-Size="18">
                    <asp:ListItem Selected="True">0</asp:ListItem>
                    <asp:ListItem>1</asp:ListItem>
                    <asp:ListItem>2</asp:ListItem>
                    <asp:ListItem>3</asp:ListItem>
                    <asp:ListItem>4</asp:ListItem>
                    <asp:ListItem>5</asp:ListItem>
                    <asp:ListItem>6</asp:ListItem>
                    <asp:ListItem>7</asp:ListItem>
                    <asp:ListItem>8</asp:ListItem>
                    <asp:ListItem>9</asp:ListItem>
                    <asp:ListItem>10</asp:ListItem>
                </asp:DropDownList>
                &nbsp;&nbsp;&nbsp;&nbsp
                <asp:Button ID="Button3" CssClass="button" runat="server" Text="Add to Cart" OnClick="Button3_Click" />
            </div>
        </div>
    </form>
</body>
</html>
