<%@ Page Title="" Language="C#" MasterPageFile="~/MainForms_Site.Master" AutoEventWireup="true" CodeBehind="MultipleComplainForm.aspx.cs" Inherits="RainMaker.ComplainManagement.MultipleComplainForm" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">





<div class="container-fluid">
        <div class="row">
        <main class="col-lg-offset-1 col-md-offset-1 col-sm-offset-1 col-xs-offset-2 col-sm-11 ml-sm-auto col-md-11 pt-3 customer content-area" role="main">
            <form id="Form1" runat="server">
             <telerik:RadScriptManager ID="RadScriptManager1" runat="server">
                </telerik:RadScriptManager>
               
               

     <asp:UpdatePanel ID="UPPanel2" runat="server">
        <ContentTemplate>
             <div class="customer content-area">
                
                    <form class="form-inline1 mt-2 mt-md-2 mb-md-3">
                     <div class="container-fluid">

                    <div class="row mb-md-3 mb-sm-3 border-box">

                     <div class="col-md-12 col-sm-12 col-lg-12">
                         <h4>Basic Information</h4>
                     </div>  

                     <div class="col-md-4 col-sm-12 col-lg-4">
                         
                         <asp:TextBox ID="tbLoggedBy" Enabled="false" class="form-control mr-sm-2 inputText" runat="server"></asp:TextBox>
                         <span class="floating-label">Logged By</span>

                      </div>

                      <div class="col-md-4 col-sm-12 col-lg-4">

                         <asp:TextBox ID="tbCallerName" class="form-control mr-sm-2 inputText" runat="server"></asp:TextBox>
                         <span class="floating-label">Caller Name</span>

                      </div>
                        
                      <div class="col-md-4 col-sm-12 col-lg-4 label-font">

                         <span>Engineer Name:</span>
                          <asp:Label ID="lblEngineerName" runat="server"></asp:Label>
                           <div> <asp:Label ID="lblDateTime" runat="server"></asp:Label></div>
                      </div>
                        
                      <div class="col-md-4 col-sm-12 col-lg-4">

                        <asp:DropDownList ID="cmbComplaintReportedVia" class="form-control" runat="server">
                            <asp:ListItem Selected="True">Select Complaint Reported Via</asp:ListItem>
                        </asp:DropDownList>
                        <span class="floating-label-select">Select Complaint Reported Via</span>
                    
                      </div>
                        
                      <div class="col-md-4 col-sm-12 col-lg-4">

                         <asp:TextBox ID="tbCallerNumber" class="form-control mr-sm-2 inputText" runat="server"></asp:TextBox>
                         <span class="floating-label">Caller Number</span>

                      </div>
                        <%--
                      <div class="col-md-4 col-sm-12 col-lg-4">

                        

                      </div>
--%>                        
                      <div class="col-md-4 col-sm-12 col-lg-4">

                        <asp:DropDownList ID="cmbCaseCategory" class="form-control" runat="server">
                            <asp:ListItem Selected="True">Select Case Category</asp:ListItem>
                        </asp:DropDownList>
                        <span class="floating-label-select">Select Case Category</span>
                      </div>
                        
                      <div class="col-md-4 col-sm-12 col-lg-4">

                         <asp:TextBox ID="tbPOCName" class="form-control mr-sm-2 inputText" runat="server"></asp:TextBox>
                         <span class="floating-label">POC Name</span>

                      </div>
                        
                      <div class="col-md-4 col-sm-12 col-lg-4">

                         <asp:TextBox ID="tbPOCNumber" class="form-control mr-sm-2 inputText" runat="server"></asp:TextBox>
                         <span class="floating-label">POC Number</span>

                      </div>
                        
                      <div class="col-md-4 col-sm-12 col-lg-4">

                        <asp:DropDownList ID="cmbPOCStatus" class="form-control" runat="server">
                            <asp:ListItem Selected="True">Select POC Status</asp:ListItem>
                        </asp:DropDownList>
                        <span class="floating-label-select">Select POC Status</span>
                      </div>
                        
                       <div class="container-fluid">
                            <div class="row">
                                  <div class="col-md-12 col-sm-12 col-lg-12">
                                     <h4>Other Information</h4>
                                  </div>
                            </div>
                       </div>
                        
                     <div class="container-fluid">
                        <div class="row">
                          <div class="col-md-4 col-sm-12 col-lg-4">
                          
                            <asp:DropDownList ID="cmbComplainStatus" class="form-control" runat="server">
                                <asp:ListItem Selected="True">Select Complain Status</asp:ListItem>

                            </asp:DropDownList>
                            <span class="floating-label-select">Select Complain Status</span>
                          </div>

                          <div class="col-md-4 col-sm-12 col-lg-4">

                            <asp:DropDownList ID="cmbAssignedDepartment" class="form-control" runat="server">
                                <asp:ListItem Selected="True">Select Assigned Department</asp:ListItem>
                            </asp:DropDownList>
                            <span class="floating-label-select">Select Assigned Department</span>
                        
                          </div>
                        
                      
                        
                          <div class="col-md-4 col-sm-12 col-lg-4">

                            <asp:DropDownList ID="cmbInitialStatement" class="form-control" runat="server">
                                <asp:ListItem Selected="True">Select Initial Statement</asp:ListItem>
                            </asp:DropDownList>
                            <span class="floating-label-select">Select Initial Statement</span>
                          </div>
                        </div>
                    </div>

                     <div class="container-fluid">
                        <div class="row">

                          <div class="col-md-4 col-sm-12 col-lg-4">

                            <asp:DropDownList ID="cmbComplainType" class="form-control" runat="server">
                                <asp:ListItem Selected="True">Select Complain Type</asp:ListItem>
                            </asp:DropDownList>
                            <span class="floating-label-select">Select Complain Type</span>
                          </div>

                          <div class="col-md-4 col-sm-12 col-lg-4">

                         <asp:TextBox ID="tbRemarks" TextMode="MultiLine" Rows="5" class="form-control mr-sm-2 inputText" runat="server"></asp:TextBox>
                         <span class="floating-label-textarea">Internal Comments</span>

                      </div>

                          <div class="col-md-4 col-sm-12 col-lg-4 table-margin-top" >

                                <%--<span>Complaint Received Date/Time</span>--%>
                                <telerik:RadDateTimePicker ID="dtComplainReceived" runat="server">
                                                    </telerik:RadDateTimePicker>
                                <span class="floating-label-date">Complaint Received Date/Time</span>

                          </div>

        

                        </div>
                    </div>
                        
                     <div class="container-fluid">
                        <div class="row">
                          <asp:Panel ID="pnlInProcess" runat="server" Enabled="false">

                              <div class="col-md-4 col-sm-12 col-lg-4">

                                 <asp:TextBox ID="tbPersonGivenETA" class="form-control mr-sm-2 inputText" runat="server"></asp:TextBox>
                                 <span class="floating-label">Person Given ETA/ETTR</span>
                         
                              </div>

                              <div class="col-md-4 col-sm-12 col-lg-4">

                                    <%--<span>ETTR Date/Time</span>--%>
                                    <telerik:RadDateTimePicker ID="dtETTR" runat="server" MinDate="">
                                    </telerik:RadDateTimePicker>
                                    <span class="floating-label-date-disable">ETTR Date/Time</span>

                              </div>
                        
                              <div class="col-md-4 col-sm-12 col-lg-4">

                                     <%--<asp:TextBox ID="dtETA" class="form-control mr-sm-2 inputText" runat="server"></asp:TextBox>--%>
                         

                                        <telerik:RadDateTimePicker ID="dtETA" runat="server" MinDate="">
                                        </telerik:RadDateTimePicker>
                                        <span class="floating-label-date-disable">ETA Date/Time</span>
                        
                               </div>

                               <div class="col-md-4 col-sm-12 col-lg-4">

                                      <asp:Panel ID="pnlTicketInfo" runat="server" Visible="false">
                                          
                                        <p>
                                            <span class=""> Ticket No. :</span>                                               
                                                
                                            <asp:Label ID="lblTicketNo" runat="server" Text="Label"></asp:Label>
                                        </p>

                                        <p>          
                                            <span class=""> Logged Date/Time</span>
                                             
                                            <asp:Label ID="lblLoggedDateTime" runat="server" Text="Label"></asp:Label>
                                        </p>
                                                
                                       </asp:Panel>
                        
                               </div>

                           </asp:Panel>
                        </div>
                    </div>

                      


                    </div>
                        
                    </div>
                    </form>
                    
                    <div class="customer-buttons-multiple">

                        <div class="row">
                            <div class="col-xs-12 col-md-12 col-lg-12">
                                <div class="text-right">


                                    <asp:Button ID="btSaveComplain" runat="server"
                                        Text="Save Complain" OnClick="SaveToolStripButton_Click"></asp:Button>

                                    <asp:Button ID="btClose" class="btn btn-primary" runat="server" Text="Back"></asp:Button>

                                </div>
                            </div>
                        </div>
            
                    </div>

                    <div class="row">
                        <div class="col-md-12">
                         <div class="col-md-4 col-sm-12 col-lg-4">
                                <p class="pull-left">Selected Count:<asp:Label ID="tbSelectedCount" runat="server" Text="0"></asp:Label></p>
                           </div>
                           <div class="col-md-4 col-sm-12 col-lg-4">
                               <asp:TextBox ID="TextBox1" class="form-control mr-sm-2 inputText" runat="server"></asp:TextBox>
                                <span class="floating-label">Primary IP Address</span>
                           </div>
                          
                           <div class="col-md-4 col-sm-12 col-lg-4 pull-right">
                                <p class="pull-right"> <asp:CheckBox ID="cbCheckAll" runat="server" Text="Check All" /></p>
                           </div>
                       </div>
                    </div>
                    
                  

              
      
                </div>

                  

              <div class="customer-table">
               <form  class="form-inline1 mt-2 mt-md-2 mb-md-3">

                  <div class="title-section white mt-md-3">
                    <div class="row">
                        <div class="col-md-6">
                            <h4 class="pull-left">Complain Details</h4>
                        </div>
                    </div>
                  </div>

                 <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
        <div class="table-responsive">
                       <telerik:RadGrid ID="gvMultipleComplainForm" runat="server" AllowPaging="True" AllowSorting="True"
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
                                            <telerik:GridButtonColumn CommandName="Complain" HeaderText="Complain" Text="Complain"
                                                UniqueName="column1">
                                            </telerik:GridButtonColumn>
                                        </Columns>
                                    </MasterTableView>
                                    <PagerStyle Mode="NextPrev" />
                                    <HeaderContextMenu CssClass="GridContextMenu GridContextMenu_Default" EnableImageSprites="True">
                                    </HeaderContextMenu>
                                </telerik:RadGrid>
                    </div>
                    </ContentTemplate>
                    </asp:UpdatePanel>
    
   
                  

              </form>

            </div>

                 
           </ContentTemplate>
            </asp:UpdatePanel>

            </form>
          </main>
          </div>
       </div>
</asp:Content>
