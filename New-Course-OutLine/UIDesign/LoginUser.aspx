<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="LoginUser.aspx.cs" Inherits="New_Course_OutLine.UIDesign.LoginUser" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    

    <div class="container">
        <div class="row"> 
            <table style="margin-top: 28px; margin-left:209px; border-color:black" border="1" class="auto-style2">

                
                <tr>
                 <td class="auto-style1">    
                     <asp:Label ID="lblMsgS" runat="server" Font-Size="XX-Large" Text=""></asp:Label>
                 </td>
              </tr>
               <tr>    
                    <td class="auto-style1"><br />
                        <asp:Label ID="lab1" runat="server" Text="User Name" style="margin-left: 40px" Font-Size="X-Large" Width="161px" Height="30px" />
                        <asp:TextBox ID="txtU" runat="server" BorderColor="#333300" Font-Size="XX-Large" Height="30px" Width="350px" BorderStyle="Solid"  />
                        <br /><br />
                    </td>
               </tr>
               <tr>
               <td class="auto-style1"><br />
                    <asp:Label ID="lab2" runat="server" Text="Password" style="margin-left: 40px" Font-Size="X-Large" Width="153px" Height="30px" />
                    <asp:TextBox ID="txtP" runat="server" TextMode="Password"  Font-Size="XX-Large" Height="30px" Width="350px" BorderColor="Black" BorderStyle="Solid" />
                    <br />
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ControlToValidate="txtP" runat="server" ErrorMessage="This value is required." BackColor="#003300" ForeColor="White"></asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator1" ControlToValidate="txtP" ValidationExpression="[a-zA-Z]+\w*\d+\w*" runat="server" ErrorMessage="Plz at least one number and letter." BackColor="#66FF99" ForeColor="#FF0066"></asp:RegularExpressionValidator>
                       <br />
                   </td>
               </tr>
                <tr>
                   <td class="auto-style1"><br />
                    <asp:Label ID="lblConPass" runat="server" Text="Conferm Password" style="margin-left: 40px" Font-Size="X-Large" Width="153px" Height="30px" />
                    <asp:TextBox ID="txtConPass" runat="server" TextMode="Password"  Font-Size="XX-Large" Height="30px" Width="350px" BorderColor="Black" BorderStyle="Solid" />
                    <br />
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" ControlToValidate="txtP" runat="server" ErrorMessage="This value is required." BackColor="#003300" ForeColor="White"></asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator2" ControlToValidate="txtP" ValidationExpression="[a-zA-Z]+\w*\d+\w*" runat="server" ErrorMessage="Plz at least one number and letter." BackColor="#66FF99" ForeColor="#FF0066"></asp:RegularExpressionValidator>
                       <br />
                   </td>
               </tr>
                <tr>
                    <td class="auto-style3"><br />
                         &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                         <asp:Button ID="btLoginSub" Text="Login" runat="server" BackColor="white" Font-Size="XX-Large" ForeColor="Green" BorderStyle="Solid" BorderWidth="2px" OnClick="btLoginSub_Click" />
                   <br />
                  </td>
                   
                </tr>
               <tr>
                    <td class="auto-style3"><br />
                         &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                         <asp:Button ID="btnResetPass" Text="Reset Password" runat="server" BackColor="white" Font-Size="XX-Large" ForeColor="Green" BorderStyle="Solid" BorderWidth="2px"  />
                   <br />
                  </td>
                   
                </tr>
             </table>
         </div>>
    </div>
</asp:Content>
