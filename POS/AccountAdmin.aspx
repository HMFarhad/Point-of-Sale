<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AccountAdmin.aspx.cs" Inherits="POS.AccountAdmin" %>

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
            <li><a href="Sale.aspx">SALE</a></li>
            <li><a href="Items.aspx">ITEMS</a></li>
            <li><a href="AccountAdmin.aspx">ACCOUNT</a></li>
            <li><a href="Logout.aspx">LOG OUT</a></li>
        </ul>
    </div>
        <div>
            <br />
            <br />
            <br />
            <br />
            <table>
            <tr>
                <td>Name:</td>
                <td><asp:TextBox ID="TextBox2" runat="server"></asp:TextBox></td>
                <td class="auto-style1"><asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="TextBox2" ErrorMessage="Name Required!!!" ForeColor="#CC3300"></asp:RequiredFieldValidator></td>
            </tr>
            <tr>
                <td>Password:</td>
                <td class="auto-style1"><asp:TextBox ID="TextBox3" runat="server" TextMode="Password"></asp:TextBox></td>
                <td class="auto-style1"><asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="TextBox3" ErrorMessage="Password Required!!!" ForeColor="#CC3300"></asp:RequiredFieldValidator></td>
            </tr>
            <tr>
                <td>Confirm Password:</td>
                <td class="auto-style1"><asp:TextBox ID="TextBox4" runat="server" TextMode="Password"></asp:TextBox></td>
                <td class="auto-style1"><asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="TextBox4" ErrorMessage="Confirm Password Required!!!" ForeColor="#CC3300"></asp:RequiredFieldValidator></td>
            </tr>
                <tr>
                <td>Type:</td>
                <td class="auto-style1">
                    <asp:DropDownList ID="DropDownList1" runat="server">
                        <asp:ListItem>Employee</asp:ListItem>
                        <asp:ListItem>Admin</asp:ListItem>
                    </asp:DropDownList></td>
            </tr>
            <tr>
               <td><asp:Button ID="Button1" runat="server" OnClick="Button1_Click1" Text="Add Member" /></td> 

            </tr>
        </table>  
        </div>
    </form>
</body>
</html>
