<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AddItem.aspx.cs" Inherits="POS.AddItem" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style1 {
            width: 142px;
        }
    </style>
</head>
<body style="height: 152px">

    <form id="form1" runat="server">
        
       <table>
            <tr>
                <td>Name:</td>
                <td><asp:TextBox ID="TextBox2" runat="server"></asp:TextBox></td>
                <td class="auto-style1"><asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="TextBox2" ErrorMessage="Item Name Required!!!" ForeColor="#CC3300"></asp:RequiredFieldValidator></td>
            </tr>
            <tr>
                <td>Price:</td>
                <td><asp:TextBox ID="TextBox3" runat="server" TextMode="Number"></asp:TextBox>
                <td><asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="TextBox3" ErrorMessage="Item Price Required!!!" ForeColor="#CC3300"></asp:RequiredFieldValidator></td>
            </tr>
            <tr>
                <td>Quantity:</td>
                <td><asp:TextBox ID="TextBox4" runat="server" TextMode="Number"></asp:TextBox>
                <td><asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="TextBox4" ErrorMessage="Item Quantity Required!!!" ForeColor="#CC3300"></asp:RequiredFieldValidator></td>
            </tr>
            <tr>
               <td><asp:Button ID="Button1" runat="server" OnClick="Button1_Click1" Text="Add Item" /></td> 

            </tr>
        </table>  
    </form>

   </body>
</html>
