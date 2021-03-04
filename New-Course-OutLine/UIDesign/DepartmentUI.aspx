<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DepartmentUI.aspx.cs" Inherits="New_Course_OutLine.UIDesign.DepartmentUI" %>

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
        <div>
            <h1>Department Information</h1>
			<div>
				<asp:Label ID="lblMgs" runat="server" Text=""></asp:Label>
			</div>
        </div>
				<div class="Department" >
					<div class="col-md-8">
                        <asp:Label ID="lblDep" runat="server" Text="">Department Name :</asp:Label>
						<asp:TextBox ID="txtDep" runat="server" ></asp:TextBox>
                        <br /><br />
                    </div>
                    <div class="col-md-8">
                        <asp:Label ID="lblDfl" runat="server" Text="">Department Flore :</asp:Label>
						<asp:TextBox ID="txtDFL" runat="server"></asp:TextBox>
                    </div>
                    <div class="col-md-8">
                        <br />
                        <asp:Button ID="btnDepSave" runat="server" Text="Save" OnClick="btnDepSave_Click"/>
                        <asp:Button ID="btnSer" runat="server" Text="Go To Magae Page" OnClick="btnSer_Click"/>
                        <%--<asp:Button ID="btnEdit" runat="server" Text="Update" OnClick="btnEdit_Click" />--%>
                    </div>
                </div>
            </div>
        
    </div>
    </form>
    <script src="../Scripts/jquery-1.10.2.min.js"></script>
    <script src="../Scripts/bootstrap.min.js"></script>
</body>
</html>
