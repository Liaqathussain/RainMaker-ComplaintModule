<%@ Page Title="" Language="C#" MasterPageFile="~/MainForms_Site.Master" AutoEventWireup="true" CodeBehind="ComplainForward.aspx.cs" Inherits="RainMaker.ComplainManagement.ComplainForward" %>

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
                                
                             <asp:updatepanel runat="server">
                                <contenttemplate>                   
                                <div class="customer">
                                    <form class="form-inline1 mt-2 mt-md-2 mb-md-3">
                                        <div class="container-fluid">

                                            <div class="row mb-md-3 mb-sm-3 border-box">
                                                <asp:panel ID="BasicInfoPnl" Enabled="false" runat="server">

                                                    <div class="col-md-12 col-sm-12 col-lg-12">
                                                        <h4>Basic Information</h4>
                                                    </div>

                                                    <div class="col-md-4 col-sm-12 col-lg-4">

                                                        <asp:TextBox ID="tbComplainTicketNo" class="form-control mr-sm-2" placeholder="Complain Ticket No" runat="server"></asp:TextBox>
                                                        <span class="floating-label">Complain Ticket No</span>
                                                    </div>
                                                    <div class="col-md-4 col-sm-12 col-lg-4 ">
                                                        <asp:TextBox ID="tbComplaintReceivedDT" class="form-control mr-sm-2" placeholder="Complain Received D/T" runat="server"></asp:TextBox>
                                                        <span class="floating-label">Complain Received D/T</span>
                                                    </div>

                                                    <div class="col-md-4 col-sm-12 col-lg-4">

                                                        <asp:TextBox ID="tbComplainStatus" class="form-control mr-sm-2" placeholder="Complain Status" runat="server"></asp:TextBox>
                                                        <span class="floating-label">Complain Status</span>
                                                    </div>
                                                    <div class="col-md-4 col-sm-12 col-lg-4">
                                                        <asp:TextBox ID="tbComplainLoggedBy" class="form-control mr-sm-2" placeholder="Complain Logged By" runat="server"></asp:TextBox>
                                                        <span class="floating-label">Complain Logged By</span>

                                                    </div>

                                                </asp:panel>

                                            </div>

                                            <div class="row mb-md-3 mb-sm-3 border-box">

                                                <div class="col-md-12 col-sm-12 col-lg-12">
                                                    <h4>Follow Up Information</h4>
                                                </div>

                                                <div class="col-md-4 col-sm-12 col-lg-4">
                                                    <asp:DropDownList ID="cmbComplainStatus" class="form-control" OnSelectedIndexChanged="cmbComplainStatus_SelectedIndexChanged" AutoPostBack="true" runat="server">

                                                    </asp:DropDownList>
                                                    <span class="floating-label-select">Complain Status</span>
                                                </div>

                                               

                                                <div class="col-md-4 col-sm-12 col-lg-4">

                                                        <asp:DropDownList ID="cmbAssignedDepartment" class="form-control" runat="server" onselectedindexchanged="cmbAssignedDepartment_SelectedIndexChanged">
                                                            <asp:ListItem Selected="True">Select Assigned Department</asp:ListItem>
                                                        </asp:DropDownList>
                                                        <span class="floating-label-select">Assigned Department</span>

                                                </div>

                                                <div class="col-md-4 col-sm-12 col-lg-4">
                                                        <asp:TextBox ID="tbLoggedBy0" class="form-control mr-sm-2" placeholder="Person Name ETA/ETTR" runat="server"></asp:TextBox>
                                                        <span class="floating-label">Person Name ETA/ETTR</span>
                                                </div>

                                                <%--<div class="row mb-md-3 mb-sm-3">--%>

                                                  <div class="container">
                                                    <div class="row">

                                                <div class="col-md-4 col-sm-12 col-lg-4">
                                                        <telerik:RadDateTimePicker ID="RadDateTimePicker1" runat="server" Width="175px" MinDate="1900-01-01">
                                                        </telerik:RadDateTimePicker>
                                                        <span class="floating-label-date">ETA Date/Time</span>
                                                </div>

                                                <div class="col-md-4 col-sm-12 col-lg-4 ">
                                                        <telerik:RadDateTimePicker ID="RadDateTimePicker3" MinDate="1900-01-01" runat="server">
                                                        </telerik:RadDateTimePicker>
                                                        <span class="floating-label-date">ETA Date/Time</span>
                                                    </div>
                                                    </div>
                                                    </div>
                                               <%-- </div>--%>
                                                

                                                  <%--  <div class="col-md-4 col-sm-12 col-lg-4">
                                                
                                                    <div class="file-upload">
                                                        <label for="upload" class="">Picture One Selector: </label>

                                                        <telerik:RadAsyncUpload ID="RadAsyncUpload1" class="file-upload__input" runat="server">
                                                        </telerik:RadAsyncUpload>
                                                    </div>
                                                
                                                    <div class="text-right">

                                                        <p>
                                                            <asp:LinkButton ID="ShowPic1" OnClick="ShowPic_Click" runat="server" class="btn btn-info btn-sm" >View Pic 1</asp:LinkButton>
                                                            <asp:LinkButton ID="ShowPic2" OnClick="ShowPic2_Click" runat="server" class="btn btn-info btn-sm" >View Pic 2</asp:LinkButton>
                                                        </p>

                                                    </div>

                                                     <div class="text-right">
                                                        <p>
                                                            <asp:Button ID="btnSave" class="btn btn-primary " runat="server" OnClick="btnSave_Click" Text="Save"></asp:Button>
                                                        </p>
                                                    </div>
                                                </div>--%>
                                                
                                                       <div class="container">
                                                    <div class="row">
                                                       <div class="col-md-4 col-sm-12 col-lg-4">

                                                        <asp:TextBox ID="tbInternalRemarks" runat="server" TextMode="MultiLine" Rows="5" class="form-control mr-sm-2"></asp:TextBox>
                                                        <span class="floating-label-textarea">Internal Remarks</span>

                                                    </div>
                                                    
                                                       <div class="col-md-4 col-sm-12 col-lg-4">

                                                        <asp:TextBox ID="tbIPResponses" class="form-control" TextMode="multiline" Rows="5" runat="server" />
                                                        <span class="floating-label-textarea">Query Responses</span>

                                                    </div>

                                                    </div>
                                                   </div>
                                                   
                                                    <div class="col-md-4 col-sm-4 col-lg-4 radio-button-div">
                                                   
                                                  
                                                     <asp:Panel ID="PnlRequestType" runat="server" >
                                                     <asp:Label ID="Label1" runat="server" Text="Request Type"></asp:Label>
                                                     <asp:RadioButton ID="SupportRequest" CssClass="radio-spacing" runat="server" Text="Support Request" GroupName="added"></asp:RadioButton>
                                                     <asp:RadioButton ID="ServiceRequest" runat="server" Text="Service Request" GroupName="added"></asp:RadioButton>
                                                    
                                                    </asp:Panel>
                                                       </div>
                                                
                                                
                                                
               

                                                    
                                                    <div class="col-md-12 col-sm-12 col-lg-12">

                                                        <div class="text-right">
                                                            <p>
                                                                <asp:Button ID="btnviewDetails" class="btn btn-primary " runat="server"  OnClientClick="openInNewTab()" Text="View Details"></asp:Button>
                                                            </p>
                                                        </div>

                                                    </div>
                                                

                                            </div>


                                            <asp:Panel ID="pnlEscalation" runat="server" Visible="false">
                                                <div class="row mb-md-3 mb-sm-3 border-box">


                                                    <div class="col-md-12 col-sm-12 col-lg-12">
                                                        <h4>Team Escalation</h4>
                                                    </div>

                                                    <div class="col-md-4 col-sm-12 col-lg-4 right-border">

                                                        <asp:DropDownList ID="cmbTeam" class="form-control" runat="server">
                                                            <asp:ListItem Selected="True">Please Select Team</asp:ListItem>
                                                        </asp:DropDownList>
                                                        <span class="floating-label-select">Select Team</span>

                                                    </div>

                                                    <div class="col-md-8 col-sm-12 col-lg-8 normal-top_padding">

                                                        <div class="col-md-4 col-sm-12 col-lg-4">

                                                            <asp:DropDownList ID="cmbPriority"  class="form-control" runat="server">
                                                                <asp:ListItem Selected="True">Please Select Priority</asp:ListItem>
                                                            </asp:DropDownList>
                                                            <span class="floating-label-select">Select Priority</span>

                                                        </div>


                                                    </div>


                                                </div>
                                            </asp:Panel>
                                                    
                                        </div>

                                       
                                    </form>

                         
                                    </div>

              

                                              
                         

                                <div  class="customer-buttons">
                                  
                                     <div class="row">
                                        <div class="col-sm-12 col-md-12 col-lg-12 col-xs-12">
                                            <div  class="text-right">
                                            <div id="hide-div">
                                                <asp:Button ID="btnUpdate" runat="server" class="btn btn-primary"  Text="Update" OnClientClick="setLocation()" onClick="btUpdateComplain_Click">
                                                </asp:Button>
                                          
                                                <asp:Button ID="Button1" AutoPostBack="true"  class="btn btn-primary" runat="server" Text="Back" onclick="btnBack_Click"></asp:Button>
                                            </div>
                                            </div>
                                        </div>
                                    </div>
                                    
                                   
                                    <div class="row">
                                        <div class="col-sm-12 col-md-12 col-lg-12 col-xs-12">
                                            <div class="col-md-6">
                                                List of Customers Effected: <span class="badge"><asp:label runat="server" id="lblTotalCount"></asp:label></span>
                                            </div>

                                            <div class="col-md-6 text-right">
                                                <label>
                                   <asp:CheckBox ID="cbCheckAll" name="name" runat="server" Text="Check All"></asp:CheckBox>
                               
                               </label>
                                            </div>

                                            <asp:Label ID="lblstatus" runat="server" ></asp:Label>
                                            <asp:Label ID="lblSucessCount" runat="server" ></asp:Label>

                                            <asp:Label ID="lblFailedCount" runat="server" ></asp:Label>
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

                               <%--         <telerik:RadGrid ID="gvActiveCircuits" runat="server" AllowPaging="True" AllowSorting="True" GridLines="None" Skin="Office2007">
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

                              </contenttemplate>
                            </asp:updatepanel>      
                        </form>
                    </main>
                </div>
            </div>


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