<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Test_Edit_Delete_Books.aspx.cs" Inherits="ASU_E_Commerce.Test_Edit_Delete_Books" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:Label ID="Label1" runat="server" Text="Edit Books"></asp:Label>
        <br />
        <asp:Label ID="Label2" runat="server" Text="Product ID"></asp:Label>
        <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
        <br />
        <asp:Label ID="Label3" runat="server" Text="ISBN"></asp:Label>
        <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
        <br />
        <asp:Label ID="Label4" runat="server" Text="Title"></asp:Label>
        <asp:TextBox ID="TextBox3" runat="server"></asp:TextBox>
        <br />
        <asp:Label ID="Label5" runat="server" Text="Subject"></asp:Label>
        <asp:TextBox ID="TextBox4" runat="server"></asp:TextBox>
        <br />
        <asp:Label ID="Label6" runat="server" Text="Quantity"></asp:Label>
        <asp:TextBox ID="TextBox5" runat="server"></asp:TextBox>
        <br />
        <asp:Label ID="Label7" runat="server" Text="Price"></asp:Label>
        <asp:TextBox ID="TextBox6" runat="server"></asp:TextBox>
        <br />
        <asp:Label ID="Label8" runat="server" Text="Bidding"></asp:Label>
        <asp:TextBox ID="TextBox7" runat="server"></asp:TextBox>
        <br />
        <asp:Button ID="Button1" runat="server" Text="Populate" OnClick="Button1_Click" />
        <asp:Button ID="Button2" runat="server" Text="Edit" OnClick="Button2_Click" />

        <br />
        <br />

        <asp:Label ID="Label9" runat="server" Text="Product ID"></asp:Label>
        <asp:TextBox ID="TextBox8" runat="server"></asp:TextBox>
        <br />
        <asp:Button ID="Button3" runat="server" Text="Delete" OnClick="Button3_Click" />
    </div>
    </form>
</body>
</html>
