<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CourseUI.aspx.cs" Inherits="New_Course_OutLine.UIDesign.CourseUI" %>

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
                <div class="col-md-12 font-weight-bold titlepadding"><img src="../img/ologo.png" alt="LINDOS"/></div>
			<%--<div class="col-md-12 font-weight-bold titlepadding"><h1>Department Of CSE & IT </h1></div>
            <div class="col-md-12 text-center font-weight-bold coursepadding"><h1>Course Outline</h1></div>--%>
            </div>
            <div class="row">
				<div class="CourseCode" >
                    <div>
                        <asp:Label ID="lblMgs" runat="server" Text=""></asp:Label>
                    </div>
					<div class="col-md-8"><br /><br />
                        <asp:Label ID="lblCCode" runat="server" Text="">Course Code :</asp:Label>
                        <asp:TextBox ID="txtCCode" runat="server" AutoPostBack="True"></asp:TextBox>
                        <br /><br />
                    </div>
                    <div class="col-md-8">
                        <asp:Label ID="lblCTitle" runat="server" Text="">Course Title :</asp:Label>
                        <asp:TextBox ID="txtCTitle" runat="server"></asp:TextBox>
                        <br /><br />
                    </div>
                    <div class="col-md-8"> 
                        <asp:Label ID="lblCredit" runat="server" Text="">Credit Hour:</asp:Label>
                        <asp:TextBox ID="txtCHour" runat="server"></asp:TextBox>
                        <br /><br />
                    </div>
                     <div class="col-md-8"> 
                         <asp:Label ID="lblFacName" runat="server" Text="Faculty Name:" Visible="False"></asp:Label>
                         <asp:DropDownList ID="ddFac" runat="server" AutoPostBack="True" Height="19px" Width="96px" Visible="False" ></asp:DropDownList>
                        <br /><br />
                     </div> 
                    <div class="col-md-8">
                        <div>
                            <asp:Button ID="btnSave" runat="server" Text="Save" OnClick="btnSave_Click" />
                            <asp:Button ID="btnEdit" runat="server" Text="Go To Manage Page" OnClick="btnEdit_Click" />

                        </div>
                        <br /><br />
                    </div>
	            </div>
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
