<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="UserType.aspx.cs" Inherits="CourseOutLine.UIView.AdminFaculty" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <meta charset="UTF-8">
	<link rel="stylesheet" type="text/css" href="../Content/bootstrap.min.css" media="all" />
	<link rel="stylesheet" type="text/css" href="../Content/bootstrap-grid.min.css" media="all" />
	<link rel="stylesheet" type="text/css" href="../Content/bootstrap-reboot.min.css" media="all" />
	<link rel="stylesheet" type="text/css" href="../Content/style.css" media="all" />

<div class="container-fluid">
		<div class="row">
            
			<div class="col-md-12 font-weight-bold titlepadding"><img src="../img/ologo.png" alt="LINDOS"/></div>
			<%--<div class="col-md-12 font-weight-bold titlepadding"><h1>Department Of CSE & IT </h1></div>--%>
            <div class="col-md-12 text-center font-weight-bold coursepadding"><h1>Course Outline</h1></div>
		</div>
        <div>
            <div>
				<asp:Label ID="lblMgs" runat="server" Text=""></asp:Label>
			</div>
            <h1>User Type</h1>
    </div>
        <div class="row" ">
			<div class="col-md-8">
				<div class="UserType" >
                    <div class="col-md-8">
                        <label for="UserTyp">User Type :</label>
						<asp:TextBox ID="txtUtyp" runat="server"></asp:TextBox>
                    </div>
                    <div class="col-md-8">
                        <br />
                        <asp:Button ID="btnUTypeSave" runat="server" Text="Save" OnClick="btnUTypeSave_Click" />
                        <asp:Button ID="btnSer" runat="server" Text="Search" OnClick="btnSer_Click" />
                        <asp:Button ID="btnEdit" runat="server" Text="Update" OnClick="btnEdit_Click" />
                        <br />
                    </div>
	            </div>
        </div>
        <br />
        <hr />
</div>
    <script type="text/javascript"src="../Scriptsjquery-1.11.1.min.js"></script>
	<script type="text/javascript" src="../Scripts/bootstrap.min.js"></script>
	<script type="text/javascript" src="../Scripts/bootstrap.bundle.min.js"></script>
    </div>

</asp:Content>
