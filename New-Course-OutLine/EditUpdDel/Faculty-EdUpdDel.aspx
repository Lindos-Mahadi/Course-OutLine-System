<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Faculty-EdUpdDel.aspx.cs" Inherits="New_Course_OutLine.EditUpdDel.Faculty_EdUpdDel" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="../Content/bootstrap-grid.min.css" rel="stylesheet" />
    <link href="../Content/bootstrap.min.css" rel="stylesheet" />
    <link href="../Content/style.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <div class="row">
            <div class="col-md-8">
                <asp:Label ID="lblMsg" runat="server" Text=""></asp:Label><br />
            </div>
         </div>
        <div class="row">
            <div class="col-md-8">
                <asp:Label ID="lblFSear" runat="server" Text="">Faculty Serch By Short Name :</asp:Label><br />
                <asp:TextBox ID="txtFSear" runat="server"></asp:TextBox>
                <asp:Button ID="btnSear" runat="server" Text="Search Faculty" OnClick="btnSear_Click" />
                <asp:Button ID="btnShow" runat="server" Text="Show Faculty List" OnClick="btnShow_Click" />
            </div>
        </div>
        <div class="row">
            <div class="col-md-8">
                <br /><br /><br />
                <asp:GridView ID="facultyGridView" runat="server" AutoGenerateColumns="False" OnRowCancelingEdit="facultyGridView_RowCancelingEdit" OnRowEditing="facultyGridView_RowEditing" Height="140px" Width="953px" OnRowUpdating="facultyGridView_RowUpdating" OnRowDeleting="facultyGridView_RowDeleting" >
                        <%--Theme Properties--%>
                    <FooterStyle BackColor="#F7DFB5" ForeColor="#8C4510" />
                    <HeaderStyle BackColor="#A55129" Font-Bold="True" ForeColor="White" />
                    <PagerStyle ForeColor="#8C4510" HorizontalAlign="Center" />
                    <RowStyle ForeColor="#8C4510" BackColor="#FFF7E7" />
                    <SelectedRowStyle BackColor="#738A9C" Font-Bold="True" ForeColor="White" />
                    <SortedAscendingCellStyle BackColor="#FFF1D4" />
                    <SortedAscendingHeaderStyle BackColor="#B95C30" />
                    <SortedDescendingCellStyle BackColor="#F1E5CE" />
                    <SortedDescendingHeaderStyle BackColor="#93451F" />

                        <Columns>
                            <asp:TemplateField HeaderText="ID">
                            <ItemTemplate>
                                <asp:Label ID="lbl" runat="server"  Text='<%#Eval ("FId") %>'  />
                            </ItemTemplate>
                            <EditItemTemplate>
                                <asp:Label ID="lbFId" runat="server"  Text='<%#Eval ("FId") %>'  />
                            </EditItemTemplate>
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="First Name">
                            <ItemTemplate>
                                <asp:Label ID="lblFirstName" runat="server"  Text='<%#Eval ("FirstName") %>'  />
                            </ItemTemplate>
                            <EditItemTemplate>
                                <asp:TextBox ID="txtFirstName" Text='<%#Eval ("FirstName") %>' runat="server" />
                            </EditItemTemplate>
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="Last Name">
                            <ItemTemplate>
                                <asp:Label ID="lblLastName" runat="server"  Text='<%#Eval ("LastName") %>'  />
                            </ItemTemplate>
                            <EditItemTemplate>
                                <asp:TextBox ID="txtLastName" Text='<%#Eval ("LastName") %>' runat="server" />
                            </EditItemTemplate>
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="Short Name">
                            <ItemTemplate>
                                <asp:Label ID="lblShortName" runat="server"  Text='<%#Eval ("ShortName") %>'  />
                            </ItemTemplate>
                            <EditItemTemplate>
                                <asp:TextBox ID="txtShortName" Text='<%#Eval ("ShortName") %>' runat="server" />
                            </EditItemTemplate>
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="Contact Number">
                            <ItemTemplate>
                                <asp:Label ID="lblContactNo" runat="server"  Text='<%#Eval ("ContactNo") %>'  />
                            </ItemTemplate>
                            <EditItemTemplate>
                                <asp:TextBox ID="txtContactNo" Text='<%#Eval ("ContactNo") %>' runat="server" />
                            </EditItemTemplate>
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="Email Account">
                            <ItemTemplate>
                                <asp:Label ID="lblEmail" runat="server"  Text='<%#Eval ("Email") %>'  />
                            </ItemTemplate>
                            <EditItemTemplate>
                                <asp:TextBox ID="txtEmail" Text='<%#Eval ("Email") %>' runat="server" />
                            </EditItemTemplate>
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="Department Name">
                    <ItemTemplate>
                        <asp:Label ID="lblDepName" runat="server"  Text='<%#Eval ("Dep_ID") %>'  />
                    </ItemTemplate>
                    <EditItemTemplate>
                        <asp:TextBox ID="txtDepName" Text='<%#Eval ("Dep_ID") %>' runat="server" />
                    </EditItemTemplate>
                    </asp:TemplateField>

                            <asp:CommandField ShowDeleteButton="True" >
                            <ControlStyle BackColor="White" BorderColor="#006666" Font-Bold="True" ForeColor="#990000" Font-Italic="True" Height="20px" Width="20px" />
                            </asp:CommandField>
                            <asp:CommandField ShowEditButton="True" UpdateImageUrl="~/Images/edit.png" >
                            <ControlStyle BackColor="White" BorderColor="#FFCC00" Font-Bold="True" Font-Italic="True" ForeColor="#003300" />
                            </asp:CommandField>
                    </Columns>
                </asp:GridView>
                <br /> <br />
                <div class="col-md-8">
                        <asp:Button ID="btnGo" runat="server" Text="Go To Main Page" OnClick="btnGo_Click" />
                  <br /><br /><br /><br />
                </div>
            </div>
            <div class="row">
                <div class="navbar-collapse collapse">
                    <ul id="menu">
                        <asp:Literal ID="Literal1" runat="server"></asp:Literal>
                    </ul> 
                </div>
            </div>
        </div>
    </div>
    </form>
    <script src="../Scripts/jquery-1.10.2.min.js"></script>
    <script src="../Scripts/bootstrap.min.js"></script>
</body>
</html>
