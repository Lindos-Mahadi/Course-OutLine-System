<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" EnableEventValidation="false" CodeBehind="CourseOutLine.aspx.cs" Inherits="CourseOutLine.UIView.CourseOutLine" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <div class="container">

        <div class="row"><br /><%--<br /><br />--%> <%--col-sm-offset-2 col-sm-10--%>
            <div class="col-md-12 font-weight-bold titlepadding"><img src="../img/ologo.png" alt="LINDOS"/></div><br /><br />
            <div class="col-md-12 text-center font-weight-bold coursepadding"><h1>Course Outline</h1></div>
        </div>

        <div class="row">
            <div class="col-md-4">
                <asp:Label ID="lblSem" runat="server" Text="Semesters"  Font-Size="Larger" Font-Bold="True" BackColor="White" ForeColor="Black"></asp:Label>
                <asp:DropDownList ID="DDSem" runat="server"  AutoPostBack="True" Width="50%" OnSelectedIndexChanged="DDSem_SelectedIndexChanged"> <%-- OnSelectedIndexChanged="DDSem_SelectedIndexChanged"--%>
                    <asp:ListItem Selected="True" Value="0">Select</asp:ListItem>
                    <asp:ListItem Value="1">Spring</asp:ListItem>
                    <asp:ListItem Value="2">Summer</asp:ListItem>
                    <asp:ListItem Value="3">Fall</asp:ListItem>
                </asp:DropDownList>  
            </div>
            <div class="col-md-4">
                <asp:Label ID="lblDay" runat="server" Text="Day" Font-Size="Larger" Font-Bold="True" BackColor="White" ForeColor="Black"></asp:Label>
                <asp:DropDownList ID="DDDay" runat="server"  AutoPostBack="True" Width="50%" OnSelectedIndexChanged="DDDay_SelectedIndexChanged" > <%--OnSelectedIndexChanged="DDDay_SelectedIndexChanged"--%>
                    <asp:ListItem Selected="True" Value="0">Select</asp:ListItem>
                    <asp:ListItem Value="Saturday">Saturday</asp:ListItem>
                    <asp:ListItem Value="Sunday">Sunday</asp:ListItem>
                    <asp:ListItem Value="Monday">Monday</asp:ListItem>
                    <asp:ListItem Value="Tuesday">Tuesday</asp:ListItem>
                    <asp:ListItem Value="Wednesday">Wednesday</asp:ListItem>
                    <asp:ListItem Value="Thurseday">Thurseday</asp:ListItem>
                    <asp:ListItem Value="Friday">Friday</asp:ListItem>
                    <asp:ListItem Value="Saturday-Monday">Saturday-Monday</asp:ListItem>
                    <asp:ListItem Value="Monday-Saturday">Monday-Saturday</asp:ListItem>
                    <asp:ListItem Value="Monday-Sunday">Monday-Sunday</asp:ListItem>
                </asp:DropDownList>
            </div>
            <div class="col-md-4">
                <asp:TextBox ID="txtDay" runat="server" Visible="False"  AutoPostBack="True"></asp:TextBox>
                <asp:Label ID="lblYear" runat="server" Text="Year"  BackColor="White" ForeColor="Black" Font-Size="Larger" Font-Bold="True" ></asp:Label>
                <asp:TextBox ID="txtYear" runat="server" AutoPostBack="True" Width="50%"></asp:TextBox>
            </div>
        </div>

        <div class="row">
            <div class="col-md-8"><br />
                <asp:Label ID="lblCCode" runat="server" BackColor="White" ForeColor="Black" Text="Coure Name" Font-Bold="True"></asp:Label>
                <asp:DropDownList ID="ddCoTSelect" runat="server"  AutoPostBack="True" Width="70%" OnSelectedIndexChanged="ddCoTSelect_SelectedIndexChanged2"></asp:DropDownList> <%--OnSelectedIndexChanged="ddCoTSelect_SelectedIndexChanged2"--%>
                <asp:TextBox ID="txtCTId" runat="server" AutoPostBack="True" Visible="False"  ></asp:TextBox>
            </div>
            <div class="col-md-4"><br />
                <asp:Label ID="lblFN" runat="server" BackColor="White" ForeColor="Black" Text=" Name of Faculty" Font-Bold="True"></asp:Label>
                <asp:DropDownList ID="txtFName" runat="server" AutoPostBack="True" width="35%" OnSelectedIndexChanged="txtFName_SelectedIndexChanged"></asp:DropDownList> <%--OnSelectedIndexChanged="txtFName_SelectedIndexChanged"--%>
                <asp:TextBox ID="txtDepId" runat="server" AutoPostBack="True" Visible="False" ></asp:TextBox>  
            </div>
        </div>

        <div class="row"><br />
            <div class="col-md-4"> 
                <asp:Label ID="lblDT" runat="server" BackColor="White" ForeColor="Black" Text="Time" Font-Bold="True"></asp:Label>
                <asp:TextBox ID="txtDatime" runat="server" AutoPostBack="True" width="65%"></asp:TextBox>  
            </div>
            <div class="col-md-4">
                <asp:Label ID="lblRNo" runat="server" BackColor="White" ForeColor="Black" Text="Room No" Font-Bold="True"></asp:Label> 
				<asp:TextBox ID="txtRoomNo" runat="server" AutoPostBack="True" width="45%"></asp:TextBox>
                <asp:TextBox ID="txtDept" runat="server" AutoPostBack="True" Visible="False"></asp:TextBox>      
                <asp:TextBox ID="txtFlor" runat="server" AutoPostBack="True" Visible="False"></asp:TextBox>
            </div>
            <div class="col-md-4"> 
                <asp:Label ID="lblMarks" runat="server" BackColor="White" ForeColor="Black" Text="Marks :" Font-Bold="True"></asp:Label>
                <asp:DropDownList ID="ddMarks" runat="server" AutoPostBack="True" width="50%" OnSelectedIndexChanged="ddMarks_SelectedIndexChanged" > <%--OnSelectedIndexChanged="ddMarks_SelectedIndexChanged"--%>
                    <asp:ListItem Selected="True" Value="0">Select</asp:ListItem>
                    <asp:ListItem Value="1">Theory</asp:ListItem>
                    <asp:ListItem Value="2">Lab</asp:ListItem>
                </asp:DropDownList>
            </div>
        </div>

        <div class="row"><br />
            <div class="col-md-4">
                <asp:Button ID="btnCreat" runat="server" Text="Create Course Outline" Width="75%" OnClick="btnCreat_Click" ForeColor="#003300" />  <%--OnClick="btnCreat_Click"--%>
            </div>
            <div class="col-md-4">
                <asp:Button ID="btnPrint" runat="server" Text="Print  Course Outline"  Width="60%" OnClientClick="return printpage();" ForeColor="#003300"  />
            </div>
            <div class="col-md-4">
                <asp:Button ID="btnRefresh" runat="server" Text="Refresh  Data"  Width="65%" OnClick="btnRefresh_Click" ForeColor="#003300" /> <%--OnClick="btnRefresh_Click"--%>
            </div>
        </div>

        <%--//--%>
        <%--/panel start/--%>
        <asp:Panel ID="Panel1" runat="server">
            <div class="row"><br /><br />
                <div class="col-md-8"> <%--/Semester Information/--%>
                    <label for="semester" class="col-sm-2 control-label">Semester </label>
                    <asp:TextBox ID="txtSems" runat="server" AutoPostBack="True" Width="50%"></asp:TextBox>
				    <asp:TextBox ID="txtSem" runat="server" AutoPostBack="True" Visible="False"></asp:TextBox>
                    <br /><br /><%--/End Semester Information/--%>

                            <%--/Semester Information/--%>
                    <label for="semester" class="col-md-2 control-label">Course Code </label>
				    <asp:TextBox ID="txtCCode" runat="server" Width="50%"></asp:TextBox>
                    <br /><br /><%--/End Semester Information/--%>

                            <%--/Semester Information/--%>
                    <label for="semester" class="col-sm-2 control-label">Course Title </label>
                    <asp:TextBox ID="txtCoId" runat="server"  Visible="false" AutoPostBack="True"></asp:TextBox>  
                    <asp:TextBox ID="txtTile" runat="server" AutoPostBack="True" Visible="true" Width="50%"></asp:TextBox>
                    <br /><br /><%--/End Semester Information/--%>

                            <%--/Semester Information/--%>
                    <label for="semester" class="col-sm-2 control-label">Credit Hour</label>
				    <asp:TextBox ID="txtCHour" runat="server" Width="50%"></asp:TextBox>
                    <br /><br /><%--/End Semester Information/--%>

                            <%--/Semester Information/--%>
                    <label for="semester" class="col-sm-2 control-label">Class Shedule </label>
				    <asp:TextBox ID="txtCShedule" runat="server"  Width="50%"></asp:TextBox>
                    <br /><br /><%--/End Semester Information/--%>

                            <%--/Semester Information/--%>
                    <label for="semester" class="col-sm-2 control-label">Room No</label>
				    <asp:TextBox ID="txtRomN" runat="server" Width="50%"></asp:TextBox>
                    <br /><br /><%--/End Semester Information/--%>

                                <%--/Semester Information/--%>
                    <label for="semester" class="col-sm-2 control-label">Faculty Name </label>
                 	<asp:TextBox ID="txtFacId" runat="server" Visible="False"></asp:TextBox> 
				    <asp:TextBox ID="txtFacName" runat="server" Visible="true"  Width="50%"></asp:TextBox>
                 	<asp:TextBox ID="txtDep" runat="server" Visible="False" ></asp:TextBox>
                    <br /><br /><%--/End Semester Information/--%>

                                <%--/Semester Information/--%>
                    <label for="semester" class="col-sm-2 control-label">Contact No </label>
				    <asp:TextBox ID="txtConNo" runat="server" Width="50%"></asp:TextBox>
                    <br /><br /><%--/End Semester Information/--%>
                                <%--/Semester Information/--%>

                    <label for="semester" class="col-sm-2 control-label">E-mail </label>
				    <asp:TextBox ID="txtEm" runat="server" Width="50%"></asp:TextBox>
                    <br /><br /><%--/End Semester Information/--%>

                                <%--/Semester Information/--%>
                    <label for="semester" class="col-sm-2 control-label">Office </label>
				    <asp:TextBox ID="txtOff" runat="server" Width="50%"></asp:TextBox>
                    <br /><br /><%--/End Semester Information/--%>
                </div>

                <%--/Mark distribution Information/--%>
                <div class="col-md-4">
                    <div>
					    <h4 style="text-align:center;">Mark Distributon</h4>
                    </div>
				    <asp:GridView ID="GridMarks" runat="server" AutoGenerateColumns="False" AllowCustomPaging="True" AllowPaging="True" AllowSorting="True" BackColor="White" ForeColor="#003366" Width="322px" Height="198px" >
					    <Columns>
						    <asp:TemplateField HeaderText="Mark Name">
							    <ItemTemplate>
								    <asp:Label ID="lblMarkName" runat="server" Text='<%#Bind("Mar_Dis_Name") %>'>'></asp:Label>
							    </ItemTemplate>
						    </asp:TemplateField>
						    <asp:TemplateField HeaderText="Mark Percentage">
							    <ItemTemplate>
								    <asp:Label ID="lblAssign" runat="server" Text='<%#Bind("Marks") %>'>'></asp:Label>
							    </ItemTemplate>
						    </asp:TemplateField>
					    </Columns>
				    </asp:GridView>
                </div> <!--End Mark Table-->
            </div>

            <div class="row">
                <div class="col-md-8"></div>
            </div>

            <%--/topics div start/--%>
            <div class="row">
                <div class="col-md-8">
                    <asp:GridView ID="GridDate" runat="server" AutoGenerateColumns="False" Width="873px"  BackColor="#FFFFCC">
                     <FooterStyle BackColor="White" ForeColor="#000066" />
                    <HeaderStyle BackColor="#006699" Font-Bold="True" ForeColor="White" />
                    <PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Left" />
                    <RowStyle ForeColor="#000066" />
                    <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
                    <SortedAscendingCellStyle BackColor="#F1F1F1" />
                    <SortedAscendingHeaderStyle BackColor="#007DBB" />
                    <SortedDescendingCellStyle BackColor="#CAC9C9" />
                    <SortedDescendingHeaderStyle BackColor="#00547E" />            
                    <Columns>         		
                        <asp:TemplateField HeaderText="Full Date">
                                <ItemTemplate>
							    <asp:Label ID="lblFullDate" runat="server" Text='<%#Bind("FullDate") %>'>'> </asp:Label>
						    </ItemTemplate>   
                        </asp:TemplateField>                
                        <asp:TemplateField HeaderText="Course Topics">
                            <ItemTemplate>
							    <asp:Label ID="txtCourseTopic" runat="server"  Text='<%#Eval ("Topic") %>' Width="70%"  />
						    </ItemTemplate>                           
                        </asp:TemplateField>
                            <asp:TemplateField HeaderText="Activities">
                            <ItemTemplate>
							    <asp:Label ID="txtActivities" runat="server"  Text='<%#Eval ("Activities") %>' Width="70%"  />
						    </ItemTemplate>                            
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
                </div>
            </div>
            <%--/ENd Of Panel/--%>
        </asp:Panel>
    </div>
    <script>
        function printpage() {
            var getPanel = document.getElementById("<%=Panel1.ClientID%>");
            var MainWindow = window.open('', '', 'height=500, width=800');
            MainWindow.document.write('<html><head><title>CourseOutLine</title>');
            MainWindow.document.write('</head><body>');
            MainWindow.document.write(getPanel.innerHTML);
            MainWindow.document.write('</body></html>');
            MainWindow.document.close();
            setTimeout(function () {
                MainWindow.print();
            }, 500)
            return false;
        }
    </script>

</asp:Content>
