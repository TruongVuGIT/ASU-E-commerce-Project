﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="mycart.aspx.cs" Inherits="ASU_E_Commerce.mycart" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link rel="icon" href="https://www.asu.edu/sites/all/themes/asu_home/favicon.ico" />
    <link rel="stylesheet" type="text/css" href="StyleSheet1.css" />
    <title></title>
</head>
<body class="main_body">
    <form id="form1" runat="server">
        <div class="top_border">
            <div>
                <div>
                    <div style="font-family: 'Arial'">
                        <h1>
                            <img src="Content/sparky.png" width="150" height="150" style="float: left" />&nbsp ASU E-COMMERCE 
                            <img src="Content/Innovation.png" width="175" height="175" style="float: right" /></h1>
                        <h2>&nbsp Shopping Cart</h2>
                        <br />
                    </div>
                </div>
            </div>
        </div>
        <br />
        <br />
        <table>
            <tr>
                <td>
                    <asp:ListBox ID="ListBox1" runat="server" Width="1054px" Font-Size="18" Height="111px"></asp:ListBox>
                </td>
                <td>
                    <asp:Label ID="Label1" runat="server" Text="Quantity:"></asp:Label>
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
                    <asp:Button ID="Button4" runat="server" CssClass="button" OnClick="Button4_Click" Text="Remove" />
                    <asp:Button ID="Button1" CssClass="button" runat="server" Text="Checkout" OnClick="Button1_Click" />
                </td>
            </tr>
            <tr>
                <td align="right">
                    <asp:Label ID="Label2" runat="server" Text="Total:"></asp:Label>
                    <asp:Label ID="Label3" runat="server" Text=""></asp:Label>
                </td>
                <td></td>
            </tr>
        </table>
        <br />
        <asp:Button ID="Button5" runat="server" CssClass="button" OnClick="Button5_Click" Text="View Details" />
        <br />

        <div>
            <table id="details" style="font-size: 28px">
                <tr>
                    <td>Product ID
                    </td>
                    <td>
                        <asp:Label ID="Label4" runat="server" Text=""></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>ISBN
                    </td>
                    <td>
                        <asp:Label ID="Label5" runat="server" Text=""></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style1">Title
                    </td>
                    <td class="auto-style1">
                        <asp:Label ID="Label6" runat="server" Text=""></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>Subject
                    </td>
                    <td>
                        <asp:Label ID="Label7" runat="server" Text=""></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>Quantity
                    </td>
                    <td>
                        <asp:Label ID="Label8" runat="server" Text=""></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>Price
                    </td>
                    <td>
                        <asp:Label ID="Label9" runat="server" Text=""></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>Bidding Price
                    </td>
                    <td>
                        <asp:Label ID="Label10" runat="server" Text=""></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>Seller's Name
                    </td>
                    <td>
                        <asp:Label ID="Label11" runat="server" Text=""></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>Seller's Email&nbsp;&nbsp;
                    </td>
                    <td>
                        <asp:Label ID="Label12" runat="server" Text=""></asp:Label>
                    </td>
                </tr>
            </table>
        </div>
        <p>
            <asp:Button ID="Button2" CssClass="button" runat="server" Text="Back" OnClick="Button2_Click" />
        </p>
    </form>
</body>
</html>
