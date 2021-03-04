<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="UserLogin.aspx.cs" Inherits="CourseOutline.Login.UserLogin" %>
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
        <h1>User Information.</h1>
            <div>
                <asp:Label ID="lblMgs" runat="server" Text=""></asp:Label>
            </div>
            </div>
                <div class="row" id="FacInfo">
			        <div class="col-md-8">
				        <div class="Semester" >
					         <div class="col-md-8">
                                     <div><label for="UName" Id="UName">User Name :</label>&nbsp;&nbsp;
                                         <asp:DropDownList ID="DDUName" runat="server" AutoPostBack="True" OnSelectedIndexChanged="DDUName_SelectedIndexChanged"  ></asp:DropDownList>
                                        <asp:TextBox ID="txtUFullName" runat="server" AutoPostBack="True" Width="500px" BackColor="#CCFFFF" Enabled="False" ></asp:TextBox>
                                     </div>
                                     <div>
                                         <asp:TextBox ID="txtFId" runat="server" AutoPostBack="True" Width="500px" Visible="False"></asp:TextBox>
                                         <asp:TextBox ID="txtDepId" runat="server" AutoPostBack="True" Width="500px" Visible="False"></asp:TextBox>
                                     </div>


                            </div>
                            <div class="col-md-8" style="left: -92px; top: -2px">
                                <label for="lblDName" Id="lblDName">Department :</label>
                                <asp:TextBox ID="txtDName" runat="server" AutoPostBack="True" Enabled="False" Visible="true" ReadOnly="True" Width="500px" BackColor="#CCFFFF"></asp:TextBox>
                            </div>
                            <div class="col-md-8"> 
                                <label for="lblUType" Id="lblUType">User_Type :</label>           
                                   &nbsp;<asp:DropDownList ID="DDUtype" runat="server" AutoPostBack="True" OnSelectedIndexChanged="DDUtype_SelectedIndexChanged" ></asp:DropDownList>
                                   <asp:TextBox ID="txtUtype" runat="server" Width="505px" BackColor="#CCFFFF" Enabled="False"></asp:TextBox>  
                            </div>
                            <div class="col-md-8">
                                <label for="lblPassWord" Id="lblPassWord">Password :</label>
                                <asp:TextBox ID="txtPass"  AutoPostBack="True" runat="server" Width="500px"></asp:TextBox>
                            </div> 
                            <div class="col-md-8">
                                <br />
                                <br />
                                <asp:Button ID="btnFSave" runat="server" Text="Save" Font-Size="X-Large" Font-Bold="true" Width="105px" ForeColor="White" BackColor="Green" Height="42px" OnClick="btnFSave_Click"/>
                                <asp:Button ID="btnEdit" runat="server" Text="Update" Font-Size="X-Large" Font-Bold="true" Width="105px" ForeColor="White" BackColor="Blue" Height="42px" OnClick="btnEdit_Click"  />
                            </div>
	                    </div>
                </div>
                <br />
                <hr />
            </div>

             <div class="row">
                <div class="col-lg-12">
                    <asp:GridView ID="GridUser" runat="server" AutoGenerateColumns="False"  Height="140px"  Width="953px" OnRowCancelingEdit="GridUser_RowCancelingEdit" OnRowDeleting="GridUser_RowDeleting" OnRowEditing="GridUser_RowEditing" OnRowUpdating="GridUser_RowUpdating" >
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
                            <asp:TemplateField HeaderText="User ID">
                            <ItemTemplate>
                                <asp:Label ID="lblUser" runat="server"  Text='<%#Eval ("ID") %>'  />
                            </ItemTemplate>
                            <EditItemTemplate>
                                <asp:Label ID="lbUserID" runat="server"  Text='<%#Eval ("ID") %>'  />
                            </EditItemTemplate>
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="User Name">
                            <ItemTemplate>
                                <asp:Label ID="lblUserName" runat="server"  Text='<%#Eval ("UserName") %>'  />
                            </ItemTemplate>
                            <EditItemTemplate>
                                <asp:TextBox ID="txtUserName" runat="server" Text='<%#Eval ("UserName") %>'  />
                            </EditItemTemplate>
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="Department">
                            <ItemTemplate>
                                <asp:Label ID="lblDepartment" runat="server"  Text='<%#Eval ("Department") %>'  />
                            </ItemTemplate>
                            <EditItemTemplate>
                                <asp:TextBox ID="txtDepartment" runat="server" Text='<%#Eval ("Department") %>'  />
                            </EditItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="User Type">
                            <ItemTemplate>
                                <asp:Label ID="lblUserType" runat="server"  Text='<%#Eval ("User_Type") %>'  />
                            </ItemTemplate>
                            <EditItemTemplate>
                                <asp:TextBox ID="txtUserType" runat="server" Text='<%#Eval ("User_Type") %>'  />
                            </EditItemTemplate>
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="Password">
                            <ItemTemplate>
                                <asp:Label ID="lblPassword" runat="server"  Text='<%#Eval ("Password") %>'  />
                            </ItemTemplate>
                            <EditItemTemplate>
                                <asp:TextBox ID="txtPassword" runat="server" Text='<%#Eval ("Password") %>'  />
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
                <asp:Label ID="lblSuccessMessage" Text="" runat="server" ForeColor="Green" />
                <asp:Label ID="lblErrorMessage" Text="" runat="server" ForeColor="Red" />
                </div>
            </div>
            <script type="text/javascript"src="../Scriptsjquery-1.11.1.min.js"></script>
	        <script type="text/javascript" src="../Scripts/bootstrap.min.js"></script>
	        <script type="text/javascript" src="../Scripts/bootstrap.bundle.min.js"></script>
</div>


</asp:Content>
