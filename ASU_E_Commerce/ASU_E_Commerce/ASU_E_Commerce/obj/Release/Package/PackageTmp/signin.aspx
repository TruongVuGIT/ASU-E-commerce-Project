<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="signin.aspx.cs" Inherits="ASU_E_Commerce.signin" %>

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
                    <div style="font-family:'Arial'">
                    <h1>&nbsp ASU E-COMMERCE</h1>
                    <h2>&nbsp Sign In</h2>
                    </div>
                    <br />
                </div>
            </div>
        </div>
        <div class="signin">
            <table>
                <tr>
                    <td>Login ID:
                    </td>
                    <td>
                        <asp:TextBox ID="TextBox1" CssClass="signupTextBox" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>Password:
                    </td>
                    <td>
                        <asp:TextBox ID="TextBox2" CssClass="signupTextBox" runat="server" TextMode="Password"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Button ID="Button1" CssClass="button" runat="server" Text="Home" OnClick="Button1_Click" />
                    </td>
                    <td>
                        <asp:Button ID="Button2" CssClass="button" runat="server" Text="Sign In" OnClick="Button2_Click" />
                        <asp:Button ID="Button3" CssClass="button" runat="server" Text="Sign Up" OnClick="Button3_Click" />
                        <asp:Button ID="Button4" CssClass="button" runat="server" Text="Forgot Password" OnClick="Button4_Click" />
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
