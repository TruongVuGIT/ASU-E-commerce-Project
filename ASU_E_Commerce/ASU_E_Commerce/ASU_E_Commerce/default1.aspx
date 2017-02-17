<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="default1.aspx.cs" Inherits="ASU_E_Commerce.default1" %>

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
                    <h2>&nbsp Home </h2>
                    </div>
                    <br />
                </div>
            </div>
        </div>
        <div>
            <br />
            <asp:Button ID="Button1" CssClass="button" runat="server" Text="Sell Products" OnClick="Button1_Click" />
            <div style="float: right">
                <asp:Button ID="Button2" CssClass="button" runat="server" Text="My Account" OnClick="Button2_Click" />
                <asp:Button ID="Button3" CssClass="button" runat="server" Text="Shopping Cart" OnClick="Button3_Click" />
            </div>
            <br style="clear: both" />
            <br />
            <br />
            <div>
                <iframe class="search_frame" height="500" src="search.aspx" id="iframe1"></iframe>
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
