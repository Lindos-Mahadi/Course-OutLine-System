﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="PermissionLogin.aspx.cs" Inherits="CourseOutline.Login.PermissionLogin" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

   
    <meta charset="UTF-8">
	<link rel="stylesheet" type="text/css" href="../Content/bootstrap.min.css" media="all" />
	<link rel="stylesheet" type="text/css" href="../Content/bootstrap-grid.min.css" media="all" />
	<link rel="stylesheet" type="text/css" href="../Content/bootstrap-reboot.min.css" media="all" />
	<link rel="stylesheet" type="text/css" href="../Content/style.css" media="all" />

<div class="container-fluid">
		<div class="row">
            
			<div class="col-md-12 font-weight-bold titlepadding"><img src="../img/ologo.png" alt="LINDOS"/></div>
            <div class="col-md-12 text-center font-weight-bold coursepadding"><h1>Course Outline</h1></div>
		</div>
        <div>
        <h1>Permission Information.</h1>
            <div>
                <asp:Label ID="lblMgs" runat="server" Font-Size="X-Large" Text=""></asp:Label>
            </div>
    </div>
        <div class="row" Id="FacInfo">
			<div class="col-md-8">
				<div class="Semester" >
                    <div class="col-md-8"> 
                         <asp:Label ID="lblPermissionId" runat="server" Text="Permission Id :"></asp:Label>
                         <asp:TextBox ID="txtPermissionId" runat="server" Width="505px" AutoPostBack="True" ></asp:TextBox>  
                    </div>
                    <div class="col-md-8"> 
                        <asp:Label ID="lblRoleId" runat="server" Text="Role Id:"></asp:Label>
                        <asp:TextBox ID="txtRoleId"  AutoPostBack="True" runat="server" Width="500px"></asp:TextBox>
                    </div> 
                    <div class="col-md-8">
                        <br />
                        <br />
                        <asp:Button ID="btnFSave" runat="server" Text="Save" Font-Size="X-Large" Font-Bold="true" Width="105px" ForeColor="White" BackColor="Green" Height="42px" OnClick="btnFSave_Click" />
                        <asp:Button ID="btnEdit" runat="server" Text="Update" Font-Size="X-Large" Font-Bold="true" Width="105px" ForeColor="White" BackColor="Blue" Height="42px" OnClick="btnEdit_Click"  />
                    </div>
	            </div>
        </div>
        <br />
        <hr />
    </div>


     <div class="row">
        <div class="col-lg-12">
            <asp:GridView ID="GridUser" runat="server" AutoGenerateColumns="False"  Height="140px"  Width="953px">
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
                    <asp:TemplateField HeaderText="Id">
                    <ItemTemplate>
                        <asp:Label ID="lbld" runat="server"  Text='<%#Eval ("Id") %>'  />
                    </ItemTemplate>
                    <EditItemTemplate>
                        <asp:Label ID="lblId" runat="server"  Text='<%#Eval ("Id") %>'  />
                    </EditItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Role Id">
                    <ItemTemplate>
                        <asp:Label ID="lblRoleId" runat="server"  Text='<%#Eval ("RoleId") %>'  />
                    </ItemTemplate>
                    <EditItemTemplate>
                        <asp:TextBox ID="txtRoleId" runat="server" Text='<%#Eval ("RoleId") %>'  />
                    </EditItemTemplate>
                    </asp:TemplateField>                                        
                    <asp:TemplateField HeaderText="Menu Id">
                    <ItemTemplate>
                        <asp:Label ID="lblMenuId" runat="server"  Text='<%#Eval ("MenuId") %>'  />
                    </ItemTemplate>
                    <EditItemTemplate>
                        <asp:TextBox ID="txtMenuId" runat="server" Text='<%#Eval ("MenuId") %>'  />
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
        <asp:Label ID="lblSuccessMessage" Text="" runat="server" Font-Size="X-Large" ForeColor="Green" />
        <asp:Label ID="lblErrorMessage" Text="" runat="server" Font-Size="X-Large" ForeColor="Red" />
        </div>
    </div>
    <script type="text/javascript"src="../Scriptsjquery-1.11.1.min.js"></script>
	<script type="text/javascript" src="../Scripts/bootstrap.min.js"></script>
	<script type="text/javascript" src="../Scripts/bootstrap.bundle.min.js"></script>
</div>




</asp:Content>
