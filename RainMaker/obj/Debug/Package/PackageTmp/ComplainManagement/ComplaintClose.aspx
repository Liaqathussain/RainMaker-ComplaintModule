<%@ Page Title="" Language="C#" MasterPageFile="~/MainForms_Site.Master" AutoEventWireup="true" CodeBehind="ComplaintClose.aspx.cs" Inherits="RainMaker.ComplainManagement.ComplainClose" %>

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
                            <asp:UpdatePanel ID="UPPanel3" runat="server">
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

                                                            <asp:TextBox ID="tbComplainTicketNo" class="form-control mr-sm-2" placeholder="Complain Ticket No" runat="server"></asp:TextBox>
                                                            <span class="floating-label">Complain Ticket No</span>
                                                        </div>

                                                        <div class="col-md-4 col-sm-12 col-lg-4">

                                                            <asp:TextBox ID="tbComplaintReceivedDT" class="form-control mr-sm-2" placeholder="Complain Received D/T" runat="server"></asp:TextBox>
                                                            <span class="floating-label">Complain Received D/T</span>
                                                        </div>

                                                        <div class="col-md-4 col-sm-12 col-lg-4">

                                                            <asp:TextBox ID="tbComplainStatus" class="form-control mr-sm-2" placeholder="Complain Status" runat="server"></asp:TextBox>
                                                            <span class="floating-label">Complain Status</span>

                                                        </div>

                                                        <div class="col-md-4 col-sm-12 col-lg-4">
                                                            <asp:TextBox ID="tbComplainLoggedBy" class="form-control mr-sm-2" placeholder="Complain Logged By" runat="server"></asp:TextBox>

                                                        </div>

                                                    </div>
                                                </asp:panel>

                                                <div class="row mb-md-3 mb-sm-3 border-box">

                                                    <div class="col-md-12 col-sm-12 col-lg-12">
                                                        <h4>Closing Information</h4>
                                                    </div>

                                                    <div class="col-md-4 col-sm-12 col-lg-4">

                                                        <asp:DropDownList ID="cmbComplaintStatus" class="form-control" runat="server">
                                                            <asp:ListItem Selected="True">Please Select Complaint Status</asp:ListItem>
                                                        </asp:DropDownList>
                                                        <span class="floating-label-select">Complaint Status</span>
                                                    </div>

                                                    <div class="col-md-4 col-sm-12 col-lg-4">

                                                        <asp:DropDownList ID="cmbAssignedtoDepartment" class="form-control" runat="server">
                                                            <asp:ListItem Selected="True">Please Select Assigned to Department</asp:ListItem>
                                                        </asp:DropDownList>
                                                        <span class="floating-label-select">Assigned to Department</span>

                                                    </div>

                                                    <div class="col-md-4 col-sm-12 col-lg-4">

                                                        <asp:TextBox ID="tbNewComplaintReference" class="form-control mr-sm-2" runat="server"></asp:TextBox>
                                                        <span class="floating-label">Complaint Reference</span>

                                                    </div>

                                                    <%--<div class="col-md-4 col-sm-12 col-lg-4">

                                                    <asp:DropDownList ID="DropDownList4" class="form-control" runat="server">
                                                        <asp:ListItem Selected="True">Please Select Assigned to Department</asp:ListItem>
                                                    </asp:DropDownList>

                                            </div>--%>

                                                        <div class="col-md-4 col-sm-12 col-lg-4">

                                                            <asp:TextBox ID="tbRemarks" class="form-control" TextMode="multiline" Rows="5" placeholder="Remarks" runat="server" />
                                                            <span class="floating-label">Remarks</span>

                                                        </div>

                                                        <%--<div class="col-md-4 col-sm-12 col-lg-4">

                                                    <asp:DropDownList ID="cmbAssignedtoDepartment" class="form-control" runat="server">
                                                        <asp:ListItem Selected="True">Please Select Assigned to Department</asp:ListItem>
                                                    </asp:DropDownList>

                                            </div>--%>

                                                            <div class="col-md-4 col-sm-12 col-lg-4">
                                                                <label>Customer Feedback: </label>
                                                                <asp:RadioButtonList ID="rbCustomerFeedback" runat="server" OnSelectedIndexChanged="rbCustomerFeedback_SelectedIndexChanged" AutoPostBack="true" RepeatDirection="Horizontal">
                                                                    <asp:ListItem Selected="True">Positive</asp:ListItem>
                                                                    <asp:ListItem>Negative</asp:ListItem>
                                                                </asp:RadioButtonList>
                                                            </div>

                                                            <asp:panel ID="FurtherAction" runat="server">
                                                                <div class="col-md-4 col-sm-12 col-lg-4">

                                                                    <label>Further Action: </label>
                                                                        <asp:RadioButton ID="rbRe" GroupName="rbFurtherAction"  runat="server" Text="Re-Initiated" oncheckedchanged="rbRe_CheckedChanged" AutoPostBack="true"></asp:RadioButton>
                                                                        <asp:RadioButton ID="rbNewComplaintLogged" GroupName="rbFurtherAction" runat="server" Text="New Complaint Logged"></asp:RadioButton>
                                                                        <asp:RadioButton ID="rbN" runat="server" GroupName="rbFurtherAction" Text="N/A" oncheckedchanged="rbN_CheckedChanged"></asp:RadioButton>
                                                                </div>

                                                            </asp:panel>

                                                            <div class="col-md-12 col-sm-12 col-lg-12">

                                                                <div class="text-right">
                                                                    <p>
                                                                        <asp:Button ID="btnviewDetails" class="btn btn-primary " runat="server" OnClientClick="openInNewTab()" Text="View Details"></asp:Button>
                                                                    </p>
                                                                </div>

                                                            </div>
                                                </div>
                                            </div>
                                        </form>
                                    </div>

                                    <div class="customer-buttons">

                                        <div class="row">
                                            <div class="col-sm-12 col-md-12 col-lg-12 col-xs-12">
                                                <div id="hide-div" class="text-right">

                                                    <asp:Button ID="btnUpdate" AutoPostBack="true" runat="server" class="btn btn-primary" onClick="btnUpdate_Click" OnClientClick="setLocation()" Text="Update">
                                                    </asp:Button>

                                                    <asp:Button ID="btnBack" class="btn btn-primary" runat="server" Text="Back" 
                                                        onclick="btnBack_Click"></asp:Button>

                                                </div>
                                            </div>

                                            <div class="col-md-12 col-sm-12 col-lg-12">
                                                <h4></h4>
                                            </div>

                                            <div class="col-md-6">
                                                List of Customers Effected: <span class="badge"><asp:label runat="server" id="lblTotalCount"></asp:label></span>
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
                                       <%-- <telerik:RadGrid ID="gvActiveCircuits" runat="server" AllowPaging="True" AllowSorting="True" GridLines="None" Skin="Office2007">
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
                function OnKeyPress(sender, eventArgs) {
                    var c = eventArgs.get_keyCode();
                    if (c == 13) {
                        __doPostBack('btnUpdate', '');
                        alert("ok");

                    }
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