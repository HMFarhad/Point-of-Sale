<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Sale_employee.aspx.cs" Inherits="POS.Sale_employee" %>
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
                #container{
                    padding:20px
                }
        .auto-style1 {
            width: 90px;
            height: 34px;
        }
        .auto-style2 {
            height: 34px;
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
    <div id="container">
         <br />
         <br />
         <br />
         <table>
             <tr>
                 <td >
                     <asp:Label ID="Label2" runat="server" Text="Item Name"></asp:Label>
                 </td>
                 <td >
                     <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
                 </td>
                 <td >
                     <asp:Label ID="Label3" runat="server" Text="Quantity"></asp:Label>
                 </td>
                 <td >
                     <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
                 </td>
                 <td >
                     <asp:Button class="btnClick" ID="btnDone" runat="server" Text="Done" OnClick="btnDone_Click" />
                 </td>
             </tr>
         </table>
         <br />
         <asp:GridView ID="GridView1" runat="server" Width="532px" AutoGenerateColumns="False" ShowFooter="True" OnDataBound="GridView1_DataBound" OnRowDataBound="GridView1_RowDataBound">
             <Columns>
                 <asp:BoundField DataField="p_name" HeaderText="Name" />
                 <asp:BoundField DataField="p_price" HeaderText="Price" />
                 <asp:BoundField HeaderText="Quantity" DataField="p_quantity" />
                 <asp:BoundField HeaderText="Sub Total" DataField="subTotal" />
             </Columns>
         </asp:GridView>
         <br />
         <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="TOTAL" />
         &nbsp;&nbsp;&nbsp;
         <asp:Button ID="Button2" runat="server" OnClick="Button2_Click" Text="CLEAR" />
         <br />
         <table>
             <tr>
                 <td class="auto-style2" >
                     <asp:Label ID="Label10" runat="server" Text="Total Price:"></asp:Label>
                 </td>
                 <td class="auto-style2" >
                     <asp:Label ID="Label17" runat="server" Text="Label"></asp:Label>
                 </td>
                 <td class="auto-style2" >&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:Label ID="Label12" runat="server" Text="Payment:"></asp:Label>
                 </td>
                 <td class="auto-style2" >
                     <asp:TextBox ID="TextBox3" runat="server"></asp:TextBox>
                 </td>
                 <td class="auto-style2" >&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:Label ID="Label14" runat="server" Text="Balance:"></asp:Label>
                 </td>
                 <td class="auto-style2" >
                     <asp:Label ID="Label15" runat="server" Text="Label"></asp:Label>
                 </td>
                 <td class="auto-style1" >&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:Button class="btnClick" ID="btnPay" runat="server" Text="Pay" OnClick="btnPay_Click"/>
                 </td>
             </tr>
         </table>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
         <asp:Label ID="Label16" runat="server"></asp:Label>
    </div>
    </form>
</body>
</html>
