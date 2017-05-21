<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Reports.aspx.cs" Inherits="POS.Reports" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style>
            ul.topnav {
              list-style-type: none;
              margin: 0;
              padding: 0;
            }

            ul.topnav li {float:left;}

            ul.topnav li a {
              display: block;
              width: 100px;
            }
       
            ul.sidemenu {
                list-style-type: none;
                margin: 15px;
                padding: 15px;
            }

            ul.sidemenu li a {
                display: block;
                width: 100px;
                height:50px
            }
        </style>
</head>
<body>
    <form id="form1" runat="server">
    <div align="center">
        <asp:Label ID="Label1" runat="server" Font-Bold="True" Font-Size="XX-Large" ForeColor="#CC3300" Text="POINT OF SALES"></asp:Label>
        <ul class="topnav" id="Topnav">
            <li><a href="Sale.aspx">SALE</a></li>
            <li><a href="Items.aspx">ITEMS</a></li>
            <li><a href="Reports.aspx">REPORTS</a></li>
            <li><a href="AccountAdmin.aspx">ACCOUNT</a></li>
            <li><a href="Logout.aspx">LOG OUT</a></li>
        </ul>
        <p>
            &nbsp;</p>
    </div>
    <div>
        <ul class="sidemenu">
          <li><a href="#home">Sales Report</a></li>
          <li><a href="#news">Best Sale</a></li>
          <li><a href="#contact">Limited Items</a></li>
          <li><a href="#about">Unused Items</a></li>
        </ul>
    </div>
    </form>
</body>
</html>
