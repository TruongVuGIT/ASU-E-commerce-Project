<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="edit_books.aspx.cs" Inherits="ASU_E_Commerce.edit_books" %>

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
                <img src="Content/sparky.png" width="150" height="150" style="float: left" />
                <div>
                    <div style="font-family: 'Arial'">
                        <h1>&nbsp ASU E-COMMERCE</h1>
                        <h2>&nbsp Edit Books</h2>
                    </div>
                    <br />
                </div>
            </div>
        </div>
        <div>
            <div>
                <table>
                    <tr>
                        <td>Product ID
                        </td>
                        <td>
                            <asp:Label ID="Label2" runat="server" Text="Label" ></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td>ISBN
                        </td>
                        <td>
                            <asp:TextBox ID="TextBox2" runat="server" CssClass="signupTextBox"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="auto-style1">Title
                        </td>
                        <td class="auto-style1">
                            <asp:TextBox ID="TextBox3" runat="server" CssClass="signupTextBox"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>Subject
                        </td>
                        <td>
                            <asp:TextBox ID="TextBox4" runat="server" CssClass="signupTextBox"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>Quantity
                        </td>
                        <td>
                            <asp:TextBox ID="TextBox8" runat="server" CssClass="signupTextBox"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>Price
                        </td>
                        <td>
                            <asp:TextBox ID="TextBox6" runat="server" CssClass="signupTextBox"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>Bidding Price
                        </td>
                        <td>
                            <asp:TextBox ID="TextBox7" runat="server" CssClass="signupTextBox"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>Seller's Name
                        </td>
                        <td>
                            <asp:Label ID="Label3" runat="server" Text="Label"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td>Seller's Email&nbsp;&nbsp;
                        </td>
                        <td>
                            <asp:Label ID="Label4" runat="server" Text="Label"></asp:Label>
                        </td>
                    </tr>
                </table>
            </div>

            <asp:Label ID="Label5" runat="server" Visible="False"></asp:Label>
            <br />
            <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Submit Changes" CssClass="button" />
            &nbsp;&nbsp;&nbsp;   
            <asp:Button ID="Button2" runat="server" OnClick="Button2_Click" Text="Back" CssClass="button" />
        </div>
    </form>
</body>
</html>
