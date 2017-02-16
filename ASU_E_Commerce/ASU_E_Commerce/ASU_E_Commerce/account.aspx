<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="account.aspx.cs" Inherits="ASU_E_Commerce.account" %>

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
                        <h2>&nbsp My Account</h2>
                    </div>
                    <br />
                </div>
            </div>
        </div>
        <div>
            <br />
            <div>
                <table>
                    <tr>
                        <td>
                            <table>
                                <tr>
                                    <td>First Name:
                                    </td>
                                    <td>
                                        <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td>Last Name:
                                    </td>
                                    <td>
                                        <asp:Label ID="Label2" runat="server" Text="Label"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td>Prefered Name:
                                    </td>
                                    <td>
                                        <asp:TextBox ID="TextBox1" CssClass="signupTextBox" runat="server"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td>ASU Email:
                                    </td>
                                    <td>
                                        <asp:Label ID="Label3" runat="server" Text="Label"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td>Login ID:
                                    </td>
                                    <td>
                                        <asp:TextBox ID="TextBox2" CssClass="signupTextBox" runat="server"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td>Password:
                                    </td>
                                    <td>
                                        <asp:TextBox ID="TextBox3" CssClass="signupTextBox" runat="server" TextMode="Password"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td>Re-enter Password:
                                    </td>
                                    <td>
                                        <asp:TextBox ID="TextBox4" CssClass="signupTextBox" runat="server" TextMode="Password"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td>Street Address 1:
                                    </td>
                                    <td>
                                        <asp:TextBox ID="TextBox5" CssClass="signupTextBox" runat="server"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td>Street Address 2:
                                    </td>
                                    <td>
                                        <asp:TextBox ID="TextBox6" CssClass="signupTextBox" runat="server"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td>City:
                                    </td>
                                    <td>
                                        <asp:TextBox ID="TextBox7" CssClass="signupTextBox" runat="server"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td>State:
                                    </td>
                                    <td>
                                        <asp:TextBox ID="TextBox8" CssClass="signupTextBox" runat="server"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td>ZipCode:
                                    </td>
                                    <td>
                                        <asp:TextBox ID="TextBox9" CssClass="signupTextBox" runat="server"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <br />
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Button ID="Button1" CssClass="button" runat="server" Text="Back" OnClick="Button1_Click" />
                                    </td>
                                    <td>
                                        <asp:Button ID="Button2" CssClass="button" runat="server" Text="Edit" OnClick="Button2_Click" />
                                    </td>
                                </tr>
                            </table>
                        </td>
                        <td>&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp
                        </td>
                        <td style="width: 60%">
                            <div>
                                <asp:GridView ID="GridView1" runat="server"></asp:GridView>
                            </div>
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
        </div>
    </form>
</body>
</html>
