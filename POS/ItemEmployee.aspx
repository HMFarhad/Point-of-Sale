<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ItemEmployee.aspx.cs" Inherits="POS.ItemEmployee" %>

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
       
        </style>
</head>
<body>
    <form id="form1" runat="server">
    <div align="center">
        <asp:Label ID="Label1" runat="server" Font-Bold="True" Font-Size="XX-Large" ForeColor="#CC3300" Text="POINT OF SALES"></asp:Label>
        <ul class="topnav" id="Topnav">
            <li><a href="Sale_employee.aspx">SALE</a></li>
            <li><a href="ItemEmployee.aspx">ITEMS</a></li>
            <li><a href="Logout.aspx">LOG OUT</a></li>
        </ul>
    </div>
        <br />
        <br />
        <br />
        <br />
        <br />
    <div>
        <br />
        <br />
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" OnRowDataBound="GridView1_RowDataBound">
            <Columns>
                <asp:BoundField DataField="productId" HeaderText="Product ID" />
                <asp:BoundField DataField="productName" HeaderText="Name" />
                <asp:BoundField DataField="productPrice" HeaderText="Price" />
                <asp:BoundField DataField="productQuantity" HeaderText="Quantity" />
                <asp:BoundField HeaderText="Status" />
            </Columns>
        </asp:GridView>
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    </div>
        <br />
    </form>
</body>
</html>
