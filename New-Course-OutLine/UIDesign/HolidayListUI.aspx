<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="HolidayListUI.aspx.cs" Inherits="New_Course_OutLine.UIDesign.HolidayListUI" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <div class="row">
            <div class="col-md-8">
                <asp:Label ID="lblMsg" runat="server" Text=""></asp:Label><br />
            </div>
         </div>
        <div class="row">
            <div class="col-md-8">
                <div class="Mark_Distribution" >
					<asp:GridView ID="holidayGridView" runat="server" AutoGenerateColumns="False" ShowFooter="True" CellPadding="4" ForeColor="#333333" GridLines="None" >
                        <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                        <Columns>
                        <asp:BoundField DataField="sno" HeaderText="Serila No" Visible="true" />
                            <asp:TemplateField HeaderText="Holiday Name">
                                <ItemTemplate>
                                    <asp:TextBox ID="lblHName" runat="server" Text='<%#Bind("lblHName") %>' />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Holiday Date">
                                <ItemTemplate>
                                    <asp:TextBox ID="lblHDate" runat="server" Text='<%#Bind("lblHDate") %>' />
                                </ItemTemplate>
                            </asp:TemplateField>
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
                <asp:Button ID="btnaddNewHN" runat="server" Text="Add New Row" OnClick="btnaddNewHN_Click"/>
                <asp:Button ID="btnSavesHN" runat="server" Text="Save" OnClick="btnSavesHN_Click" />
            </div><br /><br />
            <div class="col-md-8">
                 <asp:Button ID="btnGo" runat="server" Text="Go To Manage Page" OnClick="btnGo_Click" />
            </div>
            <div class="col-md-8">
                <br /><br />
                 <asp:Button ID="btnHome" runat="server" Text="Go To Home Page" OnClick="btnHome_Click"/>
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
</body>
</html>