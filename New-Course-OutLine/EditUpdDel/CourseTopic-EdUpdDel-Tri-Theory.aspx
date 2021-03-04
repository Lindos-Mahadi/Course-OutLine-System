<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CourseTopic-EdUpdDel-Tri-Theory.aspx.cs" Inherits="New_Course_OutLine.EditUpdDel.CourseTopic_EdUpdDel_Tri_Theory" %>

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
        <div class="container">
        <div class="row">
            <div class="navbar-collapse collapse">
                <ul id="menu">
                    <asp:Literal ID="Literal1" runat="server"></asp:Literal>
                </ul> 
            </div>
        </div>
        <div class="row">
            <div class="col-md-8">
                <asp:Label ID="lblCoTopic" runat="server" Text="">Search By Course Title:</asp:Label><br />
                <asp:TextBox ID="txtSear" runat="server"></asp:TextBox>
                <asp:Button ID="btnSear" runat="server" Text="Search" OnClick="btnSear_Click" /><br /><br />
                <asp:Button ID="btnShow" runat="server" Text="Show Topic List" OnClick="btnShow_Click" />
            &nbsp;<asp:Button ID="btnGoto" runat="server" Text="Go To View Page" OnClick="btnGoto_Click" />
            </div>
        </div><div class="row">
            <div class="col-md-8">
                <div>
                    <br />
                    <asp:Label ID="lblMsg" runat="server" Text=""></asp:Label>
                </div>
                <br /><br /><br />
            <asp:GridView ID="topicGridView" runat="server" AutoGenerateColumns="False" Width="566px" BackColor="White" BorderColor="#DEDFDE" BorderStyle="None" BorderWidth="1px" CellPadding="4" ForeColor="Black" GridLines="Vertical" OnRowCancelingEdit="topicGridView_RowCancelingEdit" OnRowEditing="topicGridView_RowEditing" OnRowUpdating="topicGridView_RowUpdating" OnRowDeleting="topicGridView_RowDeleting" >
             <%--Theme Properties--%>
                    <FooterStyle BackColor="#CCCC99" />
                    <HeaderStyle BackColor="#6B696B" Font-Bold="True" ForeColor="White" />
                    <PagerStyle BackColor="#F7F7DE" ForeColor="Black" HorizontalAlign="Right" />
                    <RowStyle BackColor="#F7F7DE" />
                    <SelectedRowStyle BackColor="#CE5D5A" Font-Bold="True" ForeColor="White" />
                    <SortedAscendingCellStyle BackColor="#FBFBF2" />
                    <SortedAscendingHeaderStyle BackColor="#848384" />
                    <SortedDescendingCellStyle BackColor="#EAEAD3" />
                    <SortedDescendingHeaderStyle BackColor="#575357" />
                        <AlternatingRowStyle BackColor="White" />
                        <Columns>
                            <asp:TemplateField HeaderText="ID">
                            <ItemTemplate>
                                <asp:Label ID="lbl" runat="server"  Text='<%#Eval ("CoT_ID") %>'  />
                            </ItemTemplate>
                            <EditItemTemplate>
                                <asp:Label ID="lbCoT_ID" runat="server"  Text='<%#Eval ("CoT_ID") %>'  />
                            </EditItemTemplate>
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="Course TItle">
                            <ItemTemplate>
                                <asp:Label ID="lblTitle" runat="server"  Text='<%#Eval ("Title") %>'  />
                            </ItemTemplate>
                            <EditItemTemplate>
                                <asp:TextBox ID="txtTitle" Text='<%#Eval ("Title") %>' runat="server" />
                            </EditItemTemplate>
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="Topics">
                            <ItemTemplate>
                                <asp:Label ID="lblTopic" runat="server"  Text='<%#Eval ("Topic") %>'  />
                            </ItemTemplate>
                            <EditItemTemplate>
                                <asp:TextBox ID="txtTopic" Text='<%#Eval ("Topic") %>' runat="server" />
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
                <br /><br /><br />
            </div>
        </div>
        <div class="row">
            <div class="col-md-8">
            </div>
        </div>
      </div>
    </div>
    </form>
    <script src="../Scripts/jquery-1.10.2.min.js"></script>
    <script src="../Scripts/bootstrap.min.js"></script>
</body>
</html>
