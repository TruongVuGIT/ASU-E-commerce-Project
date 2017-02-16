<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="checkout.aspx.cs" Inherits="ASU_E_Commerce.checkout" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
        </div>
        <asp:Label ID="TotalLabel" runat="server" Text="Total: $"></asp:Label>
        <asp:TextBox ID="TextBox1" runat="server" ReadOnly="True">0.00</asp:TextBox>
    </form>
    <form name="_xclick" action="https://www.paypal.com/cgi-bin/webscr" method="post" onclick="myFunction()">
  <input type="hidden" name="cmd" value="_xclick"/>
  <input type="hidden" name="business" value="cseecommerce@gmail.com"/>
  <input type="hidden" name="currency_code" value="USD"/>
  <input type="hidden" name="item_name" value="ASU Geology 101"/>
  <input type="hidden" name="amount" value="0"/>

&nbsp;<script>
            function myFunction()
            {
                var textbox = document.getElementById('TextBox1');
                var textboxvalue = textbox.value;
                document._xclick.amount.value = textboxvalue
            }
    </script>
        <input type="image" src="http://www.paypalobjects.com/en_US/i/btn/btn_buynow_LG.gif"          name="submit" alt="Make payments with PayPal - it's fast, free and secure!"/>

</form>
</body>
</html>
