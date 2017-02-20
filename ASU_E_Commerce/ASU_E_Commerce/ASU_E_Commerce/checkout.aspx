﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="checkout.aspx.cs" Inherits="ASU_E_Commerce.checkout" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">



.button {
    font-size: 24px;
    background: rgb(53,53,53);
    color: white;
    border: solid 2px;
    border-radius: 8px;
    /*border-color:rgb(51,51,51);*/
    padding-left: 10px;
    padding-right: 10px;
    height: 41px;
}

    .top_border {
    padding-left: 25px;
    padding-right: 25px;
    padding-top: 1px;
    padding-bottom: 1px;
    /*background:linear-gradient(rgb(26,26,26),rgb(128,128,128));*/
    /*background:linear-gradient(rgb(163,0,70),rgb(255,196,35));*/
    background:linear-gradient(to left, rgb(255,196,35), rgb(163,0,70));
    
    /*background-color: rgb(77,77,77);*/
    font-size: 24px;
    color: white;
}

    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
        <div class="top_border">
            <div>
                <div>
                    <div style="font-family:'Arial'">
                    <h1>
                <img src="Content/sparky.png" width="150" height="150" style="float: left" />&nbsp ASU E-COMMERCE  <img src="Content/Innovation.png" width="175" height="175" style="float: right" /></h1>
                    <h2>&nbsp Checkout</h2>
                    <br />
                    </div>
                </div>
            </div>
        </div>

        <div>
        </div>
            <asp:Label ID="FirstNameLabel" runat="server" Text="First Name"></asp:Label>
            <asp:Label ID="LastNameLabel" runat="server" Text="Last Name"></asp:Label>
            <br />
            <asp:Label ID="AddressLabel" runat="server" Text="Address"></asp:Label>
            <br />
            <asp:Label ID="CityLabel" runat="server" Text="City"></asp:Label>
            <asp:Label ID="StateLabel" runat="server" Text="State"></asp:Label>
            <asp:Label ID="ZipLabel" runat="server" Text="Zip"></asp:Label>
        </div>
        <asp:Label ID="TotalLabel" runat="server" Text="Total: $"></asp:Label>
        <asp:TextBox ID="TextBox1" runat="server" ReadOnly="True">0.00</asp:TextBox>
        <br />
        <br />
        <asp:ImageButton
    ID="PayPalBtn"
    runat="server"
    ImageUrl="https://www.paypalobjects.com/en_GB/i/btn/btn_buynow_LG.gif"
    onclick="PayPalBtn_Click" />

        <br />
        <br /> 
        <asp:Button ID="BackButton" CssClass="button" runat="server" Text="Back" OnClick="BackButton_Click" />


        
    </form>
    </body>
</html>
