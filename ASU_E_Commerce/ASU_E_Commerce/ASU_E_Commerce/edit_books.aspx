<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="edit_books.aspx.cs" Inherits="ASU_E_Commerce.edit_books" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">

        .auto-style1 {
            height: 31px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <h1>
        <asp:Label ID="Label1" runat="server" Text="Edit Book Information"></asp:Label>
        </h1>
        <div>
                    <table id="details" style="font-size:28px";>
                        <tr>
                            <td>
                                Product ID
                            </td>
                            <td>
                                <asp:Label ID="Label2" runat="server" Text="Label"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                ISBN
                            </td>
                            <td>
                                <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td class="auto-style1">
                                Title
                            </td>
                            <td class="auto-style1">
                                <asp:TextBox ID="TextBox3" runat="server"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                Subject
                            </td>
                            <td>
                                <asp:TextBox ID="TextBox4" runat="server"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                Quantity
                            </td>
                            <td>
                                <asp:TextBox ID="TextBox8" runat="server"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                Price
                            </td>
                            <td>
                                <asp:TextBox ID="TextBox6" runat="server"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                Bidding Price
                            </td>
                            <td>
                                <asp:TextBox ID="TextBox7" runat="server"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                Seller's Name
                            </td>
                            <td>
                                <asp:Label ID="Label3" runat="server" Text="Label"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                Seller's Email&nbsp;&nbsp;
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
        <asp:Button ID="Button2" runat="server" OnClick="Button2_Click" Text="Back" />
    </div>
    </form>
</body>
</html>
