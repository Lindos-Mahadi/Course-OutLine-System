<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Course_Topics-Tri-UI.aspx.cs" Inherits="New_Course_OutLine.UIDesign.Course_Topics_Tri_UI" %>

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
			    <div class="col-md-12 font-weight-bold titlepadding"><img src="../img/ologo.png" alt="LINDOS"/></div>
			    <%--<div class="col-md-12 font-weight-bold titlepadding"><h1>Department Of CSE & IT </h1></div>--%>
                <div class="col-md-12 text-center font-weight-bold coursepadding"><h1>Course Outline</h1></div>
		    </div>
            <div class="row">
                <div class="col-md-8">
                    <asp:Label ID="lblCourseTopic" runat="server" Text="">Course Title :</asp:Label>
                    <asp:DropDownList ID="ddCtitle" runat="server" AutoPostBack="True" Height="16px" OnSelectedIndexChanged="ddCtitle_SelectedIndexChanged"></asp:DropDownList>
                    <asp:TextBox ID="txtCTitle" runat="server" AutoPostBack="True" Visible="False"></asp:TextBox>
                    <asp:TextBox ID="txtCId" runat="server" AutoPostBack="True" Visible="False"></asp:TextBox> 
                </div>
            </div>
            <div class="row">
                <div class="col-md-8">
                    <asp:Label ID="lblMsg" runat="server" Text=""></asp:Label>
                </div>
            </div>
            <div class="row">
                <div class="col-md-8">
                    <asp:GridView ID="topicsGridView" runat="server" AutoGenerateColumns="False" ShowFooter="True" CellPadding="4" ForeColor="#000066" GridLines="None" >
                        <AlternatingRowStyle BackColor="White" />
                        <Columns>
                        <asp:BoundField DataField="sno" HeaderText="Serila No" Visible="true" />
                            <asp:TemplateField HeaderText="Course Topic">
                                <ItemTemplate>
                                    <asp:TextBox ID="lblTopic" runat="server" Text='<%#Bind("lblTopic") %>' />
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
                <asp:Button ID="addNewTri" runat="server" Text="Add New Row" OnClick="addNewTri_Click"  />
                <asp:Button ID="btnSaveTri" runat="server" Text="Save" OnClick="btnSaveTri_Click" />
                <asp:Button ID="btngo" runat="server" Text="Go To Manage Page" OnClick="btngo_Click" />
            </div>
<%--            <div class="row">
                <div class="navbar-collapse collapse">
                    <ul id="menu">
                        <asp:Literal ID="Literal1" runat="server"></asp:Literal>
                    </ul> 
                </div>
            </div>--%>
        </div>
              
    </div>
    </form>
    <script src="../Scripts/jquery-1.10.2.min.js"></script>
    <script src="../Scripts/bootstrap.min.js"></script>
</body>
</html>
