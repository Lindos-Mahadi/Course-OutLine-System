<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Course-EdUpdDel.aspx.cs" Inherits="New_Course_OutLine.EditUpdDel.Course_EdUpdDel" %>

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
    <%--<div class="row">
        <div class="navbar-collapse collapse">
            <ul id="menu">
                <asp:Literal ID="Literal1" runat="server"></asp:Literal>
            </ul> 
        </div>
     </div>--%>
        <div class="container">
            <div class="row"><br /><br />
                <div class="col-md-10">
                    <asp:Label ID="lblMsg" runat="server" Text=""></asp:Label>
                </div>
            </div>
            <div class="row"><br /><br />
                <div class="col-md-10">
                    <asp:Label ID="lblCourse" runat="server" Text="">Search By Title :</asp:Label>
                    <asp:TextBox ID="txtCourse" runat="server"></asp:TextBox>
                    <asp:Button ID="btnSearch" runat="server" Text="Search" OnClick="btnSearch_Click" />
                </div>
            </div>
            <div class="row"><br /><br />
                <div class="col-md-4">
                    <asp:Button ID="btnShow" runat="server" Text="Show Course List" OnClick="btnShow_Click" />
                    <asp:Button ID="btnGo" runat="server" Text="Go To View Page" OnClick="btnGo_Click" />
                </div>
            </div>
            <div class="row">
                <div class="col-md-10"><br /><br /><br />
                    <asp:GridView ID="courseGridView" runat="server" AutoGenerateColumns="False" OnRowCancelingEdit="courseGridView_RowCancelingEdit" OnRowDeleting="courseGridView_RowDeleting" OnRowEditing="courseGridView_RowEditing" OnRowUpdating="courseGridView_RowUpdating" >
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
                                <asp:TemplateField HeaderText="Course ID">
                                <ItemTemplate>
                                    <asp:Label ID="lbl" runat="server"  Text='<%#Eval ("Co_ID") %>'  />
                                </ItemTemplate>
                                <EditItemTemplate>
                                    <asp:Label ID="lblCo_ID" runat="server"  Text='<%#Eval ("Co_ID") %>'  />
                                </EditItemTemplate>
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="Course Code">
                                <ItemTemplate>
                                    <asp:Label ID="lblFirstName" runat="server"  Text='<%#Eval ("Course_Code") %>'  />
                                </ItemTemplate>
                                <EditItemTemplate>
                                    <asp:TextBox ID="txtCourse_Code" Text='<%#Eval ("Course_Code") %>' runat="server" />
                                </EditItemTemplate>
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="Course Title">
                                <ItemTemplate>
                                    <asp:Label ID="lblTitle" runat="server"  Text='<%#Eval ("Title") %>'  />
                                </ItemTemplate>
                                <EditItemTemplate>
                                    <asp:TextBox ID="txtTitle" Text='<%#Eval ("LastName") %>' runat="server" />
                                </EditItemTemplate>
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="Credit Hour">
                                <ItemTemplate>
                                    <asp:Label ID="lblCredit_Hour" runat="server"  Text='<%#Eval ("Credit_Hour") %>'  />
                                </ItemTemplate>
                                <EditItemTemplate>
                                    <asp:TextBox ID="txtCredit_Hour" Text='<%#Eval ("Credit_Hour") %>' runat="server" />
                                </EditItemTemplate>
                                </asp:TemplateField>

                               <%-- <asp:TemplateField HeaderText="Department Name">
                                    <ItemTemplate>
                                        <asp:Label ID="lblDepName" runat="server"  Text='<%#Eval ("Dep_ID") %>'  />
                                    </ItemTemplate>
                                    <EditItemTemplate>
                                        <asp:TextBox ID="txtDepName" Text='<%#Eval ("Dep_ID") %>' runat="server" />
                                    </EditItemTemplate>
                                    </asp:TemplateField>--%>

                                <asp:CommandField ShowDeleteButton="True" >
                                <ControlStyle BackColor="White" BorderColor="#006666" Font-Bold="True" ForeColor="#990000" Font-Italic="True" Height="20px" Width="20px" />
                                </asp:CommandField>
                                <asp:CommandField ShowEditButton="True" UpdateImageUrl="~/Images/edit.png" >
                                <ControlStyle BackColor="White" BorderColor="#FFCC00" Font-Bold="True" Font-Italic="True" ForeColor="#003300" />
                                </asp:CommandField>
                        </Columns>
                    </asp:GridView>
                        <br /> <br />
                </div>
            </div>
        </div>
    </div>
    </form>
    <script src="../Scripts/jquery-1.10.2.min.js"></script>
    <script src="../Scripts/bootstrap.min.js"></script>
</body>
</html>
