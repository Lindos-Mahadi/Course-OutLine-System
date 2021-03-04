<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Course_Topics-Dual-UI.aspx.cs" Inherits="New_Course_OutLine.UIDesign.Course_Topics_Dual_UI" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="../Content/bootstrap-grid.min.css" rel="stylesheet" />
    <link href="../Content/bootstrap.min.css" rel="stylesheet" />
    <%--<link href="../Content/style.css" rel="stylesheet" />--%>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <div class="container">
            <div class="row">
                <div class="col-md-8">
                    <asp:Label ID="lblCourseTopic" runat="server" Text="">Course Title :</asp:Label>
                    <asp:DropDownList ID="ddCtitle" runat="server" AutoPostBack="True"></asp:DropDownList>
                    <asp:TextBox ID="txtCTId" runat="server" AutoPostBack="True"></asp:TextBox>
                    <asp:TextBox ID="txtCoId" runat="server" AutoPostBack="True"></asp:TextBox> 
                </div>
            </div>
            <div class="row">
                <div class="col-md-8">
                    <asp:Label ID="lblMSG" runat="server" Text=""></asp:Label>
                </div>
            </div>
            <div class="row">
                <div class="col-md-8">
                    <asp:GridView ID="topicsGridView" runat="server" AutoGenerateColumns="False" ShowFooter="True" CellPadding="4" ForeColor="#000066" GridLines="None" >
                        <AlternatingRowStyle BackColor="White" />
                        <Columns>
                        <asp:BoundField DataField="sno" HeaderText="Serila No" Visible="true" />
                            <asp:TemplateField HeaderText="Date">
                                <ItemTemplate>
                                    <asp:TextBox ID="lblDate" runat="server" Text='<%#Bind("lblMarDisName") %>' />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Topics">
                                <ItemTemplate>
                                    <asp:TextBox ID="lblTopics" runat="server" Text='<%#Bind("lblMarks") %>' />
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                        <EditRowStyle BackColor="#7C6F57" />
                        <FooterStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
                        <HeaderStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
                        <PagerStyle BackColor="#666666" ForeColor="White" HorizontalAlign="Center" />
                        <RowStyle BackColor="#E3EAEB" />
                        <SelectedRowStyle BackColor="#C5BBAF" Font-Bold="True" ForeColor="#333333" />
                        <SortedAscendingCellStyle BackColor="#F8FAFA" />
                        <SortedAscendingHeaderStyle BackColor="#246B61" />
                        <SortedDescendingCellStyle BackColor="#D4DFE1" />
                        <SortedDescendingHeaderStyle BackColor="#15524A" />
                    </asp:GridView> <br /> <br /> <br />
                </div>
            </div>
            <div class="row">
                <asp:Button ID="addNewDual" runat="server" Text="Add New Row"  />
                <asp:Button ID="btnSaveDual" runat="server" Text="Save" />
            </div>
            <div class="row"></div>
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
