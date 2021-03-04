<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="FaultyUI.aspx.cs" Inherits="New_Course_OutLine.UIDesign.FaultyUI" %>

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
            </div>
            <div class="row">
                <div><h1>Faculty Information.</h1> </div>
                <div><asp:Label ID="lblMgs" runat="server" Text=""></asp:Label> </div>
            </div>
            <div class="row">
                <div class="Semester" >
					<div class="col-md-8">
                        <asp:Label ID="lblFastNam" runat="server" Text="">First Name :</asp:Label>
                        <asp:TextBox ID="txtFN" runat="server"></asp:TextBox>
                        <br /><br />
                    </div>
                    <div class="col-md-8">
                        <asp:Label ID="lblLastNam" runat="server" Text="">Last Name :</asp:Label>
                        <asp:TextBox ID="txtLN" runat="server"></asp:TextBox>
                        <br /><br />
                    </div>
                    <div class="col-md-8">
                       <asp:Label ID="lblSName" runat="server" Text="">Short Name :</asp:Label>
                        <asp:TextBox ID="txtSN" runat="server"></asp:TextBox>
                         <br /><br />
                    </div>

                    <div class="col-md-8">
                        <asp:Label ID="lblConNo" runat="server" Text="">Contact No :</asp:Label>
                        <asp:TextBox ID="txtCN" runat="server"></asp:TextBox>
                         <br /><br />
                    </div> 
                    <div class="col-md-8">
                        <asp:Label ID="lblEmailNo" runat="server" Text="">Email :</asp:Label>
                        <asp:TextBox ID="txtEM" runat="server"></asp:TextBox>
                         <br /><br />                        
                    </div>
                    <div class="col-md-8">
                        <asp:Label ID="lblDepId" runat="server" Text="">Department Name :</asp:Label>
                        <asp:DropDownList ID="ddDepID" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddDepID_SelectedIndexChanged" ></asp:DropDownList>
                        <asp:TextBox ID="txtdID" runat="server" AutoPostBack="True" Visible="False" ReadOnly="True"></asp:TextBox>
                          <br /><br />
                    </div>
                    <div class="col-md-8">
                          <br /><br />
                    </div>
                    <div class="col-md-8">
                        <asp:Button ID="btnFSave" runat="server" Text="Save" OnClick="btnFSave_Click" />
                        <asp:Button ID="btnEdit" runat="server" Text="Go To Manage Page" OnClick="btnEdit_Click" />
                        <br /><br /><br /><br />
                    </div>
	            </div>
            </div>
            <div class="row"></div>
                <div class="row">
                    <%--<div class="navbar-collapse collapse">
                        <ul id="menu">
                            <asp:Literal ID="Literal1" runat="server"></asp:Literal>
                        </ul> 
                    </div>--%>
                </div>
         </div>
    </div>
    </form>
    <script src="../Scripts/jquery-1.10.2.min.js"></script>
    <script src="../Scripts/bootstrap.min.js"></script>
</body>
</html>
