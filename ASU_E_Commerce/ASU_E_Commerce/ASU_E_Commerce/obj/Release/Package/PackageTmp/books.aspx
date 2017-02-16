<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="books.aspx.cs" Inherits="ASU_E_Commerce.books" %>

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
                        <h2>&nbsp Books </h2>
                    </div>
                    <br />
                </div>
            </div>
        </div>
        <div>
            <br />
            <table>
                <tr>
                    <td>
                        <table>
                            <tr>
                                <td>ISBN:
                                </td>
                                <td>
                                    <asp:TextBox ID="TextBox1" CssClass="signupTextBox" runat="server"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td>Title:
                                </td>
                                <td>
                                    <asp:TextBox ID="TextBox2" CssClass="signupTextBox" runat="server"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td>Subject:
                                </td>
                                <td>
                                    <asp:TextBox ID="TextBox3" CssClass="signupTextBox" runat="server"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td>Quantity
                                </td>
                                <td>
                                    <asp:TextBox ID="TextBox4" CssClass="signupTextBox" runat="server"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td>Price/Item:
                                </td>
                                <td>
                                    <asp:TextBox ID="TextBox5" CssClass="signupTextBox" runat="server"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td>Bidding Price:
                                </td>
                                <td>
                                    <asp:TextBox ID="TextBox6" CssClass="signupTextBox" runat="server"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td>Image1:
                                </td>
                                <td>
                                    <asp:FileUpload CssClass="fileupload" ID="FileUpload1" runat="server" />
                                </td>
                            </tr>
                            <tr>
                                <td>Image2:
                                </td>
                                <td>
                                    <asp:FileUpload CssClass="fileupload" ID="FileUpload2" runat="server" />
                                </td>
                            </tr>
                        </table>
                    </td>
                    <td>&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp
                    </td>
                    <td>
                        <table>
                            <tr>
                                <td>Description:
                                </td>
                                <td>
                                    <asp:TextBox ID="TextBox7" CssClass="commentTextBox" runat="server" TextMode="MultiLine"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td></td>
                                <td>
                                    <br />
                                    <asp:Button ID="Button1" CssClass="button" runat="server" Text="Back" OnClick="Button1_Click" />
                                    <asp:Button ID="Button2" CssClass="button" runat="server" Text="Sell" OnClick="Button2_Click" />
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
            </table>
        </div>
        <br />
        <br />
        <div class="top_border">
            <br />
            <a href="http://www.asu.edu/" style="color: white;">Register for Web Services</a>
            &nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp                
            &nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp                
            Contact:                
            <br />
            <br />
        </div>
    </form>
</body>
</html>
