<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="New_Course_OutLine._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

	<%--<link rel="stylesheet" type="text/css" href="../Content/bootstrap.min.css" media="all" />
	<link rel="stylesheet" type="text/css" href="../Content/bootstrap-grid.min.css" media="all" />
	<link rel="stylesheet" type="text/css" href="../Content/bootstrap-reboot.min.css" media="all" />
	<link rel="stylesheet" type="text/css" href="../Content/style.css" media="all" />
    <link rel="stylesheet" type="text/css"  href="../Content/style.css" rel="stylesheet" />--%>
    
    <section id="full_banner">
        <img src="../images/slider.jpg" />
        <ul id="slid_item">
            <li class="bnrimg" style="background-image: url('images/slider.jpg'); width:1200px;height:600px; background-size: 100% 100%;">
                <div class="bnrlay">
                    
                </div>
            </li>
            
            <li class="bnrimg" style="background-image: url('images/slider1.jpg');width:1200px;height:600px; background-size: 100% 100%; ">
                <div class="bnrlay"></div>
            </li>
            <li class="bnrimg" style="background-image: url('images/slider2.jpg'); width:1200px;height:600px; background-size: 100% 100%; ">
                <div class="bnrlay"></div>
            </li>
        </ul>
    </section>

</asp:Content>
