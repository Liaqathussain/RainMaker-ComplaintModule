<%@ Page Title="" Language="C#" MasterPageFile="~/MainForms_Site.Master" AutoEventWireup="true" CodeBehind="ComplainSolve.aspx.cs" Inherits="RainMaker.ComplainManagement.ComplainSolve" %>
    <%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
        <asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
        </asp:Content>
        <asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

            <div class="container-fluid">
                <div class="row">
                    <main class="col-lg-offset-1 col-md-offset-1 col-sm-offset-1 col-xs-offset-1 col-sm-11 col-md-11 ml-sm-auto col-md-11 pt-3 customer content-area" role="main">
                        <form id="form1" runat="server">

                            <telerik:RadScriptManager ID="RadScriptManager1" runat="server">
                            </telerik:RadScriptManager>
                            <asp:UpdatePanel ID="UPPanel2" runat="server">
                                <ContentTemplate>
                                    <div class="customer">
                                        <form class="form-inline1 mt-2 mt-md-2 mb-md-3">
                                            <div class="container-fluid">
                                             <asp:panel ID="BasicInfoPnl" Enabled="false" runat="server">
                                                <div class="row mb-md-3 mb-sm-3 border-box">

                                                    <div class="col-md-12 col-sm-12 col-lg-12">
                                                        <h4>Basic Information</h4>
                                                    </div>

                                                    <div class="col-md-4 col-sm-12 col-lg-4">

                                                        <asp:TextBox ID="tbComplainTicketNo" class="form-control mr-sm-2" runat="server"></asp:TextBox>
                                                        <span class="floating-label">Complain Ticket No</span>
                                                    </div>
                                                    <div class="col-md-4 col-sm-12 col-lg-4">
                                                        <asp:TextBox ID="tbComplaintReceivedDT" class="form-control mr-sm-2" runat="server"></asp:TextBox>
                                                        <span class="floating-label">Complain Received D/T</span>
                                                    </div>


                                                    <div class="col-md-4 col-sm-12 col-lg-4">

                                                        <asp:TextBox ID="tbComplainStatus" class="form-control mr-sm-2" runat="server"></asp:TextBox>
                                                        <span class="floating-label">Complain Status</span>
                                                    </div>

                                                    <div class="col-md-4 col-sm-12 col-lg-4">

                                                        <asp:TextBox ID="tbComplainLoggedBy" class="form-control mr-sm-2" runat="server"></asp:TextBox>
                                                        <span class="floating-label">Complain Logged By</span>

                                                    </div>

                                                    <div class="col-md-4 col-sm-12 col-lg-4 normal-top_padding">

                                                    </div>

                                                </div>
                                                </asp:panel>
                                                <div class="row mb-md-3 mb-sm-3 border-box">

                                                    <div class="col-md-12 col-sm-12 col-lg-12">
                                                        <h4>Solving Information</h4>
                                                    </div>

                                                    <div class="col-md-4 col-sm-12 col-lg-4">
                                                        <asp:TextBox ID="tbPersonSolvingComplain" class="form-control mr-sm-2" runat="server">
                                                        </asp:TextBox>
                                                        <span class="floating-label">Person Solving Complain</span>
                                                    </div>

                                                    <div class="col-md-4 col-sm-12 col-lg-4">

                                                        <asp:DropDownList ID="cmbComplainStatus" class="form-control" runat="server">
                                                            <asp:ListItem Selected="True">Please Select Complain Status</asp:ListItem>
                                                        </asp:DropDownList>
                                                        <span class="floating-label-select">Complain Status</span>
                                                    </div>


                                                    <div class="col-md-4 col-sm-12 col-lg-4">
                                                        <asp:DropDownList ID="cmbProblemDiagnosedat" runat="server" AutoPostBack="true" OnSelectedIndexChanged="cmbProblemDiagnosedat_SelectedIndexChanged" class="form-control">
                                                        </asp:DropDownList>
                                                        <span class="floating-label-select">Problem Diagnosed at</span>
                                                    </div>



                                                    <div class="col-md-4 col-sm-12 col-lg-4">
                                                        <asp:DropDownList ID="cmbAssignedDepartment" class="form-control" runat="server">

                                                        </asp:DropDownList>
                                                        <span class="floating-label-select">Assigned Department</span>
                                                    </div>

                                                    <div class="col-md-4 col-sm-12 col-lg-4">
                                                        <asp:DropDownList ID="cmbReasonofOutage" class="form-control" runat="server">

                                                        </asp:DropDownList>
                                                        <span class="floating-label-select">Reason of Outage</span>
                                                    </div>

                                                    <div class="col-md-4 col-sm-12 col-lg-4">
                                                        <asp:DropDownList ID="cmbLastMileInfra" class="form-control" runat="server">
                                                            <asp:ListItem Selected="True">Please Select Last Mile Infra</asp:ListItem>
                                                        </asp:DropDownList>
                                                        <span class="floating-label-select">Last Mile Infra</span>

                                                    </div>

                                                    <asp:Panel ID="Panel1" runat="server">

                                                        <div class="col-md-4 col-sm-12 col-lg-4">
                                                            <asp:TextBox ID="tbCauses" runat="server">
                                                            </asp:TextBox>
                                                            <span class="floating-label">Causes</span>
                                                        </div>

                                                        <div class="col-md-4 col-sm-12 col-lg-4">
                                                            <asp:TextBox ID="tbRootCauseAnalysis" runat="server">
                                                            </asp:TextBox>
                                                            <span class="floating-label">Root Cause Analysis</span>
                                                        </div>

                                                        <div class="col-md-4 col-sm-12 col-lg-4">
                                                            <asp:TextBox ID="tbPreventiveMeasures" runat="server">
                                                            </asp:TextBox>
                                                            <span class="floating-label">Preventive Measures</span>
                                                        </div>

                                                    </asp:Panel>

                                                    <div class="col-md-4 col-sm-12 col-lg-4">
                                                        <asp:TextBox ID="tbRemarks" class="form-control" TextMode="multiline" Rows="5" runat="server" />
                                                        <span class="floating-label">Internal Comments</span>
                                                    </div>




                                                    <div class="col-md-4 col-sm-12 col-lg-4">
                                                        <telerik:RadDateTimePicker ID="dtSolving" runat="server" Width="175px" MinDate="1900-01-01">

                                                        <DateInput ID="DateInput1" runat="server" DisplayDateFormat="M/d/yyyy" DateFormat="M/d/yyyy" SelectedDate="1900-01-01"></DateInput>
                                                        </telerik:RadDateTimePicker>
                                                        <span class="floating-label-date"> Date Solving</span>
                                                    </div>



                                                    <asp:panel ID="pnlFCR" runat="server">
                                                        <div class="col-md-4 col-sm-12 col-lg-4">
                                                            <label>FCR: </label>
                                                           <%-- <asp:RadioButtonList ID="rbFCR" runat="server">
                                                                <asp:ListItem>Yes</asp:ListItem>
                                                                <asp:ListItem>No</asp:ListItem>
                                                            </asp:RadioButtonList>--%>

                                                            <asp:radiobutton ID="rbFCRYes" text="Yes" GroupName="FCR" AutoPostBack="true" runat="server" />
                                                            <asp:radiobutton ID="rbFCRNo" text="No" GroupName="FCR" AutoPostBack="true" runat="server" />
                                                        </div>
                                                    </asp:panel>

                                                    <div class="text-right">
                                                        <asp:Button ID="btnViewDetail" AutoPostBack="true" class="btn btn-primary" runat="server" Text="View Details" OnClientClick="openInNewTab()">
                                                        </asp:Button>
                                                    </div>


                                                </div>

                                            

                                            <asp:Panel ID="pnlFiberDetails" runat="server" Visible="false">
                                                <div class="row mb-md-3 mb-sm-3 border-box">

                                                    <div class="col-md-12 col-sm-12 col-lg-12">
                                                        <h4>Fiber Details</h4>
                                                    </div>

                                                    <div class="col-md-4 col-sm-12 col-lg-4 ">

                                                        <asp:TextBox ID="txtJoinName" class="form-control mr-sm-2" placeholder="" runat="server"></asp:TextBox>
                                                        <span class="floating-label">Join Name</span>
                                                        </div>
                                                        <div class="col-md-4 col-sm-12 col-lg-4 ">

                                                        <asp:TextBox ID="txtTubeNameFromCustomer" class="form-control mr-sm-2" placeholder="" runat="server"></asp:TextBox>
                                                        <span class="floating-label">Tube Name From Customer</span>
                                                    </div>

                                                    <div class="col-md-4 col-sm-12 col-lg-4 ">

                                                        <asp:TextBox ID="txtCoreColorFromCustomer" class="form-control mr-sm-2" placeholder="" runat="server"></asp:TextBox>
                                                        <span class="floating-label">Core Color From Customer</span>
                                                        </div>
                                                        <div class="col-md-4 col-sm-12 col-lg-4 ">
                                                        <asp:TextBox ID="txtTubeNameFromNode" class="form-control mr-sm-2" placeholder="" runat="server"></asp:TextBox>
                                                        <span class="floating-label">Tube Name From Node</span>
                                                    </div>

                                                    <div class="col-md-4 col-sm-12 col-lg-4 ">
                                                        <asp:TextBox ID="txtCoreColorFromNode" class="form-control mr-sm-2" placeholder="" runat="server"></asp:TextBox>
                                                            <span class="floating-label">Core Color From Node</span>
                                                        </div>
                                                        <div class="col-md-4 col-sm-12 col-lg-4">
                                                        <asp:TextBox ID="txtCutDistance" class="form-control mr-sm-2" placeholder="" runat="server"></asp:TextBox>
                                                        <span class="floating-label">Cut Distance</span>
                                                    </div>
                                                    <div class="col-sm-12 col-md-12 col-lg-12 col-xs-12">
                                                        <div class="text-right">

                                                            <asp:Button ID="btnViewHistoryFiberDetails" runat="server" OnClick="btnviewFiberHistory_Click" AutoPostBack="true" class="btn btn-primary" Text="View History"></asp:Button>

                                                        </div>
                                                    </div>
                                                </div>
                                            </asp:Panel>

                                         </div>
                                    </form>
                                    </div>

                                    <div class="customer-buttons">

                                         <div class="row">

                        <div class="col-sm-12 col-md-12 col-lg-12 col-xs-12">
                            <div id="hide-div" class="text-right">

                                <asp:Button ID="btnUpdate"  runat="server" class="btn btn-primary" onClick="btnUpdate_Click"  OnClientClick="setLocation()" Text="Update">
                                </asp:Button>

                                
                                <asp:Button ID="btncancel" AutoPostBack="true" class="btn btn-primary" runat="server" Text="Cancel" OnClick="btncancel_Click"></asp:Button>
                            </div>
                        </div>

                        <div class="col-md-12 col-sm-12 col-lg-12">
                            <h4></h4>
                        </div>

                        <div class="col-md-6">
                            <asp:label runat="server" id="lbl1">List of Customers Effected:<span class="badge"><asp:label runat="server" id="lblTotalCount"></asp:label></span></asp:label>

                        </div>

                        <div class="col-md-6 text-right">
                            <label>
                           <asp:CheckBox ID="cbCheckAll" name="name" runat="server" Text="Check All"></asp:CheckBox>
                       </label>
                        </div>
                       <div class="col-md-6">
                                <asp:Label ID="lblstatus" runat="server" Text="Label"></asp:Label>
                                <asp:Label ID="lblSucessCount" runat="server" Text="Label"></asp:Label>
                                <asp:Label ID="lblFailedCount" runat="server" Text="Label"></asp:Label>

                      </div>
                    </div>

                                    </div>

                                    <div class="customer-table">
                    <form class="form-inline1 mt-2 mt-md-2 mb-md-3">

                        <div class="title-section white mt-md-3">
                            <div class="row">
                                <div class="col-md-6">
                                    <h4 class="pull-left">Customers Effected</h4>

                                        
                                </div>
                            </div>
                        </div>

                      

                                                    

                    </form>
                    <%--<telerik:RadGrid ID="gvActiveCircuits" runat="server" AllowPaging="True" AllowSorting="True" 
                                                    OnItemCommand="gvActiveCircuits_ItemCommand" OnNeedDataSource="gvActiveCircuits_NeedDataSource" 
                                                    GridLines="None" Skin="Office2007">
                                                        <ClientSettings>
                                                            <Selecting AllowRowSelect="True" />
                                                            <Scrolling AllowScroll="True" UseStaticHeaders="True" />
                                                        </ClientSettings>
                                                        <MasterTableView>
                                                            <CommandItemSettings ExportToPdfText="Export to Pdf" />
                                                            <Columns>
                                                                <telerik:GridTemplateColumn>
                                                                    <ItemTemplate>
                                                                        <asp:CheckBox ID="cb_Select" runat="server" ClientIDMode="AutoID"></asp:CheckBox>
                                                                    </ItemTemplate>
                                                                </telerik:GridTemplateColumn>
                                                            </Columns>
                                                        </MasterTableView>
                                                        <PagerStyle Mode="NextPrev" />
                                                        <HeaderContextMenu CssClass="GridContextMenu GridContextMenu_Default" EnableImageSprites="True">
                                                        </HeaderContextMenu>
                                                    </telerik:RadGrid>--%>
                     <div class="table-responsive">
                      
                        
                        <asp:GridView ID="gvActiveCircuits" runat="server" AllowPaging="True" AllowSorting="True"
                         GridLines="Both" Skin="Office2007" 
                            class="table-responsive table table-striped mb-md-0" BorderWidth="3px" 
                            >
                         <Columns>
                         <asp:TemplateField>
                         <ItemTemplate>
                         <asp:checkbox ID="cb_Select" runat="server" ClientIDMode="AutoID" />
                         </ItemTemplate>
                         </asp:TemplateField>
                         </Columns>
                         
                        
                        </asp:GridView>

                    </div>
                </div>

                                </ContentTemplate>
                            </asp:UpdatePanel>
                </form>
                </main>
            </div>
            </div>

            <script type="text/javascript">
////                function OnKeyPress(sender, eventArgs) {
////                    var c = eventArgs.get_keyCode();
////                    if (c == 13) {
////                        __doPostBack('btnUpdate', '');
////                        alert("ok");

////                    }
////                }


                function RowClick(sender, eventArgs) {
                    alert("Click on row instance: " + eventArgs.get_itemIndexHierarchical());
                }

          
            </script>
                   <script type="text/javascript">
                       function setLocation() {
                           document.getElementById('hide-div').style.display = 'none';

                       }

                       function openInNewTab() {
                           var qrStr = window.location.search;
                           var qrStr1 = window.location.search;
                           qrStr = qrStr.split("?")[1].split("=")[1];
                           qrStr1 = qrStr1.split("&")[1].split("=")[1];
                           var url = "\\ComplainManagement\\ComplainForm.aspx?SignupID=" + qrStr1 + "&ComplainID=" + qrStr + "&Flag=View";
                           var win = window.open(url, '_blank');
                           win.focus();
                       }
         </script>
        </asp:Content>