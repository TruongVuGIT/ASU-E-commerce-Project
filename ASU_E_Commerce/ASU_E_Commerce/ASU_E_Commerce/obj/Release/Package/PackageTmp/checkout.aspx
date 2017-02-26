<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="checkout.aspx.cs" Inherits="ASU_E_Commerce.checkout" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link rel="icon" href="https://www.asu.edu/sites/all/themes/asu_home/favicon.ico" />
    <link rel="stylesheet" type="text/css" href="StyleSheet1.css" />
    <title></title>
    <style type="text/css">
        .auto-style1 {
            width: 2px;
        }
        .auto-style2 {
            height: 31px;
        }
    </style>
</head>
<body class="main_body">
    <form id="form1" runat="server">
        <div>
            <div class="top_border">
                <div>
                    <div style="font-family: 'Arial'">
                        <h1>
                            <img src="Content/sparky.png" width="150" height="150" style="float: left" />&nbsp ASU E-COMMERCE 
                                <img src="Content/Innovation.png" width="175" height="175" style="float: right" /></h1>
                        <h2>&nbsp Checkout</h2>
                        <br />
                    </div>
                </div>
            </div>
            <br />
            <br />
            <table>
                <tr>
                    <td>
                        <table>
                            <tr>
                                <td>First Name:
                                </td>
                                <td>
                                    <asp:Label ID="FirstNameLabel" runat="server" Text="First Name"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td class="auto-style2">Last Name:
                                </td>
                                <td class="auto-style2">
                                    <asp:Label ID="LastNameLabel" runat="server" Text="Last Name"></asp:Label>

                                </td>
                            </tr>
                            <tr>
                                <td>Address:            
                                </td>
                                <td>
                                    <asp:Label ID="AddressLabel" runat="server" Text="Address"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td>City:           
                                </td>
                                <td>
                                    <asp:Label ID="CityLabel" runat="server" Text="City"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td>State:           
                                </td>
                                <td>
                                    <asp:Label ID="StateLabel" runat="server" Text="State"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td>Zip Code:
            
                                </td>
                                <td>
                                    <asp:Label ID="ZipLabel" runat="server" Text="Zip"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="TotalLabel" runat="server" Text="Total:"></asp:Label>
                                </td>
                                <td>$<asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
                                </td>
                            </tr>
                        </table>
                    </td>
                    <td>
                        &nbsp&nbsp&nbsp&nbsp&nbsp
                    </td>
                    <td class="auto-style1">
                        <table>
                            <asp:TextBox ID="TextBox1" runat="server" TextMode="MultiLine" Font-Size="18pt" Height="204px" ReadOnly="True" Width="799px"></asp:TextBox>
                        </table>
                    </td>
                </tr>
            </table>
        </div>
        <br />
        <br />
        <asp:ImageButton
            ID="PayPalBtn"
            runat="server"
            ImageUrl="https://www.paypalobjects.com/en_GB/i/btn/btn_buynow_LG.gif"
            OnClick="PayPalBtn_Click" />
        <br />
        <br />
        <asp:Button ID="BackButton" CssClass="button" runat="server" Text="Back" OnClick="BackButton_Click" />
    </form>
</body>
</html>
