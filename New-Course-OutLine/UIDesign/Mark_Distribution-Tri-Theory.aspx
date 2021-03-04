<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Mark_Distribution-Tri-Theory.aspx.cs" Inherits="New_Course_OutLine.UIDesign.Mark_Distribution_Tri_Theory" %>

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
               <div class="nav navbar-nav navbar-right">
	            <ul id="menu" class="nav navbar-nav navbar-right">
		            <li>
			            <asp:Literal ID="Literal1" runat="server" ></asp:Literal>
		            </li>
	            </ul> 
             </div>
            </div>
        <div class="row">
            <div class="col-md-8">
                <div class="markDistribution-tri">
                    <asp:GridView ID="marksGridView" runat="server" AutoGenerateColumns="False" ShowFooter="True" >
                        <Columns>
                            <asp:BoundField DataField="sno" HeaderText="Serila No" Visible="true" />
                                <asp:TemplateField HeaderText="Marks Name">
                                    <ItemTemplate>
                                        <asp:TextBox ID="lblMarDisName" runat="server" Text='<%#Bind("lblMarDisName") %>' />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Marks">
                                    <ItemTemplate>
                                        <asp:TextBox ID="lblMarks" runat="server" Text='<%#Bind("lblMarks") %>' />
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView><br /> <br />
                        <asp:Button ID="btnaddNew" runat="server" Text="Add New Row" />
                        <asp:Button ID="btnSaves" runat="server" Text="Save"  />
                    <asp:Button ID="btnGoManage" runat="server" Text="Go to Manage Page" />
                </div>
            </div>
        </div>
        <div class="row">
            <div class="col-md-8">
                <div class="show-mark"><br /> <br />
                    <asp:GridView ID="MarksGridView2" runat="server" AutoGenerateColumns="False">
                        <Columns>
                            <asp:TemplateField HeaderText="Marks Name">
                                <ItemTemplate>
                                    <asp:TextBox ID="lblMarDisName" runat="server" Text='<%#Bind("Mar_Dis_Name") %>' />
                                </ItemTemplate>
                            </asp:TemplateField>
                             <asp:TemplateField HeaderText="Marks">
                                <ItemTemplate>
                                    <asp:TextBox ID="lblMarks" runat="server" Text='<%#Bind("Marks") %>' />
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                </div>
            </div>
        </div>
        <div class="row"></div>
        
    </div>
    </div>
    </form>
    <script src="../Scripts/jquery-1.10.2.min.js"></script>
    <script src="../Scripts/bootstrap.min.js"></script>
</body>
</html>
