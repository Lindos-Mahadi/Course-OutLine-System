<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Holiday-EdUpdDel.aspx.cs" Inherits="New_Course_OutLine.EditUpdDel.Holiday_EdUpdDel" %>

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
                <div>
                <asp:Label ID="lblMsg" runat="server" Text=""></asp:Label>
            </div>
            </div>
        </div>
            <div class="row">
                <div class="col-md-8">
                    <asp:Label ID="lblHDaySear" runat="server" Text="Holiday Search by Date or Name :" BackColor="White" ForeColor="Black"></asp:Label>
                    <asp:TextBox ID="txtHDaySear" runat="server"></asp:TextBox>
                    <asp:Button ID="btnSearch" runat="server" Text="Search" OnClick="btnSearch_Click" /><br /><br />
                    <asp:Button ID="btnShow" runat="server" Text="Show Holiday List" OnClick="btnShow_Click" /><br />
                </div>
            </div>
            <div class="row">
                <div class="col-md-8">
                    <div class="HoliDayList" >
					    <asp:GridView ID="holiDayGridView" runat="server" AutoGenerateColumns="False" ShowFooter="True" CellPadding="4" ForeColor="#333333" GridLines="None" OnRowCancelingEdit="holiDayGridView_RowCancelingEdit" OnRowDeleting="holiDayGridView_RowDeleting" OnRowEditing="holiDayGridView_RowEditing" OnRowUpdating="holiDayGridView_RowUpdating" >
                            <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                            <Columns>
                                <asp:TemplateField HeaderText="Holiday Name">
                                    <ItemTemplate>
                                        <asp:Label ID="lblId" runat="server"  Text='<%#Eval ("Id") %>'  />
                                    </ItemTemplate>
                                     <EditItemTemplate>
                                         <asp:TextBox ID="txtId" runat="server"  Text='<%#Eval ("Id") %>'  />
                                     </EditItemTemplate>
                                </asp:TemplateField>
                                       <asp:TemplateField HeaderText="Full Date">
                                        <ItemTemplate>
                                            <asp:TextBox ID="lblDateFull" runat="server" Text='<%#Bind("FullDate") %>' />
                                        </ItemTemplate>
                                         <EditItemTemplate>
                                         <asp:TextBox ID="txtDateFull" runat="server"  Text='<%#Eval ("FullDate") %>'  />
                                     </EditItemTemplate>
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="Holiday Name">
                                        <ItemTemplate>
                                            <asp:TextBox ID="lblHolidayName" runat="server" Text='<%#Bind("HolidayName") %>' />
                                        </ItemTemplate>
                                         <EditItemTemplate>
                                         <asp:TextBox ID="txtHolidayName" runat="server"  Text='<%#Eval ("HolidayName") %>'  />
                                     </EditItemTemplate>
                                </asp:TemplateField>



                                <asp:CommandField ShowEditButton="True" />
                                <asp:CommandField ShowDeleteButton="True" />
                            </Columns>
                            <EditRowStyle BackColor="#999999" />
                            <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                            <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                            <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                            <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                            <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                            <SortedAscendingCellStyle BackColor="#E9E7E2" />
                            <SortedAscendingHeaderStyle BackColor="#506C8C" />
                            <SortedDescendingCellStyle BackColor="#FFFDF8" />
                            <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
                      </asp:GridView>
                  </div>
            </div>

            </div>
             <div class="row">
                <div class="col-md-8">
                    <asp:Button ID="btnGo" runat="server" Text="Back To Main Page" OnClick="btnGo_Click" />
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
