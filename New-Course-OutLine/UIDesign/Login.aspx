<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="New_Course_OutLine.UIDesign.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style1 {
            height: 39px;
        }
        .auto-style2 {
            height: 54px;
        }
        .auto-style3 {
            height: 84px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
  <div>
                 <table style="margin-top: 28px; margin-left:209px; border-color:black" border="1" class="auto-style2">
             <tr> 
                 <td class="auto-style1">    
                     <asp:Label ID="lblMsgS" runat="server" Font-Size="XX-Large" Text=""></asp:Label>
                 </td>
             </tr>
                                  <tr>
                 <td>
                     <asp:Label ID="lbldd" style="margin-left: 40px" runat="server" Text="User Type :" Font-Bold="True" Font-Size="X-Large"></asp:Label>
                     <asp:DropDownList ID="ddUType" runat="server" Width="50%" OnSelectedIndexChanged="ddUType_SelectedIndexChanged">
                         <asp:ListItem>---Select Your Type---</asp:ListItem>
                         <asp:ListItem Value="1">Super</asp:ListItem>
                         <asp:ListItem Value="2">Admin</asp:ListItem>
                         <asp:ListItem Value="3">User</asp:ListItem>
                     </asp:DropDownList>
                     </td>

                 
             </tr>
              <tr>
                   <td>
                          <asp:TextBox ID="txtType" runat="server" BorderColor="#333300" Font-Size="XX-Large" Height="30px" Width="350px" BorderStyle="Solid" Visible="False"  />
                   </td>
              </tr>
             <tr>    
                        <td class="auto-style1">
                            <br />
                         <asp:Label ID="lab1" runat="server" Text="User Email" style="margin-left: 40px" Font-Size="X-Large" Width="161px" Height="30px" />
                         <asp:TextBox ID="txtU" runat="server" BorderColor="#333300" Font-Size="XX-Large" Height="30px" Width="350px" BorderStyle="Solid"  />
                        <br />
                            
                        <br />
                    </td>
               </tr>
               <tr>
                   <td class="auto-style1">
                       <br />
                       <asp:Label ID="lab2" runat="server" Text="Password" style="margin-left: 40px" Font-Size="X-Large" Width="153px" Height="30px" />
                       &nbsp;
                       <asp:TextBox ID="txtP" runat="server" TextMode="Password"  Font-Size="XX-Large" Height="30px" Width="350px" BorderColor="Black" BorderStyle="Solid" />
                           <br />
                                  &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                               <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ControlToValidate="txtP" runat="server" ErrorMessage="This value is required." BackColor="#003300" ForeColor="White"></asp:RequiredFieldValidator>
                               <asp:RegularExpressionValidator ID="RegularExpressionValidator1" ControlToValidate="txtP" ValidationExpression="[a-zA-Z]+\w*\d+\w*" runat="server" ErrorMessage="Plz at least one number and letter." BackColor="#66FF99" ForeColor="#FF0066"></asp:RegularExpressionValidator>
 
                       <br />
                   </td>
               </tr>
          <%--      <tr>
                   <td class="auto-style1"><br />
                    <asp:Label ID="lblConPass" runat="server" Text="Conferm Password" style="margin-left: 40px" Font-Size="X-Large" Width="153px" Height="30px" />
                    <asp:TextBox ID="txtConPass" runat="server" TextMode="Password"  Font-Size="XX-Large" Height="30px" Width="350px" BorderColor="Black" BorderStyle="Solid" />
                    <br />
                  <br />
                   </td>
               </tr>--%>
                <tr>
                    <td class="auto-style3">
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<br />
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                         <asp:Button ID="btLoginSub" Text="Login" runat="server" BackColor="white" Font-Size="XX-Large" ForeColor="Green" BorderStyle="Solid" BorderWidth="2px" OnClick="btLoginSub_Click" />
                        <br />
                    </td>

                </tr>
<%--                     <tr>
                       <td class="auto-style3">
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<br />
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                         <asp:Button ID="btnConfermPass" Text="Confer to Reset Password" runat="server" BackColor="white" Font-Size="XX-Large" ForeColor="Green" BorderStyle="Solid" BorderWidth="2px" OnClick="btnConfermPass_Click" />
                        <br />
                    </td>
                     </tr>
                     <tr>
                    <td class="auto-style3"><br />
                         &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                         <asp:Button ID="btnResetPass" Text="Reset Password" runat="server" BackColor="white" Font-Size="XX-Large" ForeColor="Green" BorderStyle="Solid" BorderWidth="2px" OnClick="btnResetPass_Click"  />
                   <br />
                  </td>
                   
                </tr>--%>
             </table>

    </div>
    </form>
</body>
</html>
