<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Department-EdUpdDel.aspx.cs" Inherits="New_Course_OutLine.EditUpdDel.Department_EdUpdDel" EnableEventValidation="false" %>

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
                <asp:Label ID="lblDepSer" runat="server" Text="">Search By Department Name :</asp:Label><br />
                <asp:TextBox ID="txtSer" runat="server"></asp:TextBox>
                <asp:Button ID="btnSear" runat="server" Text="Serach Department List" OnClick="btnSear_Click" />
            </div>
            
        </div>

    <div class="row">
        <div class="col-md-8">
            <br /><br /><br />
            <asp:GridView ID="departmentGridView" runat="server" AutoGenerateColumns="False" Width="566px" BackColor="White" BorderColor="#DEDFDE" BorderStyle="None" BorderWidth="1px" CellPadding="4" ForeColor="Black" GridLines="Vertical" OnRowCancelingEdit="departmentGridView_RowCancelingEdit" OnRowDeleting="departmentGridView_RowDeleting" OnRowEditing="departmentGridView_RowEditing" OnRowUpdating="departmentGridView_RowUpdating" >
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
                        <asp:Label ID="lbl" runat="server"  Text='<%#Eval ("Dep_ID") %>'  />
                    </ItemTemplate>
                    <EditItemTemplate>
                        <asp:Label ID="lbDep_ID" runat="server"  Text='<%#Eval ("Dep_ID") %>'  />
                    </EditItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Department Name">
                    <ItemTemplate>
                        <asp:Label ID="lblDepName" runat="server"  Text='<%#Eval ("DepName") %>'  />
                    </ItemTemplate>
                    <EditItemTemplate>
                        <asp:TextBox ID="txtDepName" Text='<%#Eval ("DepName") %>' runat="server" />
                    </EditItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Department Floor">
                    <ItemTemplate>
                        <asp:Label ID="lblDepFlr" runat="server"  Text='<%#Eval ("Dep_Floor") %>'  />
                    </ItemTemplate>
                    <EditItemTemplate>
                        <asp:TextBox ID="txtDepFlr" Text='<%#Eval ("Dep_Floor") %>' runat="server" />
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
        <br />
            <asp:Label ID="lblSuccessMessage" runat="server" ForeColor="White" />
            <asp:Label ID="lblErrorMessage" runat="server" ForeColor="White" />
            <asp:Button ID="btnDepBack" runat="server" OnClick="btnDepBack_Click" Text="Back To Main Page" Width="182px" />
            <asp:Button ID="btnPDF" runat="server" Text="PDF Print" OnClick="btnPDF_Click" />
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
    </form>
    <script src="../Scripts/jquery-1.10.2.min.js"></script>
    <script src="../Scripts/bootstrap.min.js"></script>
</body>
</html>
