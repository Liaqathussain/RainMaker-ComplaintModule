<%@ Page Title="" Language="C#" MasterPageFile="~/MainForms_Site.Master" AutoEventWireup="true" CodeBehind="ComplainForm.aspx.cs" Inherits="RainMaker.ComplainManagement.ComplainForm" %>

<%@ Register TagPrefix="My" TagName="cntBrowsingDeadIssue" Src="~/UserControls/cntBrowsingDeadIssue.ascx" %>
<%@ Register TagPrefix="My" TagName="cntemailIsuee" Src="~/UserControls/cntemailIsuee.ascx" %>
<%@ Register TagPrefix="My" TagName="cntIntial_LinkDownDrops" Src="~/UserControls/cntIntial_LinkDownDrops.ascx" %>
<%@ Register TagPrefix="My" TagName="cntWebIssue" Src="~/UserControls/cntWebIssue.ascx" %>
<%@ Register TagPrefix="My" TagName="cntServiceRequest" Src="~/UserControls/cntServiceRequest.ascx" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

<div class="container-fluid">
        <div class="row">
        <main class="col-lg-offset-1 col-md-offset-1 col-sm-offset-1 col-xs-offset-2 col-sm-11 ml-sm-auto col-md-11 pt-3 customer content-area" role="main">
            <form id="Form1" runat="server">
             <telerik:RadScriptManager ID="RadScriptManager1" runat="server"></telerik:RadScriptManager>

     <asp:UpdatePanel ID="UPPanel2" runat="server">
        <ContentTemplate>
             <div class="customer content-area">
                
              <!-- MENUS FOR CUSTOMER INF AND COMPLAIN FORM -->
              <ul class="nav nav-tabs">

                <li class="active">
                    <a data-toggle="tab" href="#complain-form">Complain Form</a>
                </li>
                <li >
                    <a data-toggle="tab" href="#customer-info">Customer Information</a>
                </li>
              
              </ul>
                
              <!-- TAB CONTENT FOR CUSTOMER INFO AND COMPLAIN FORM -->
              <div class="tab-content">
                
                           <div id="complain-form" class="tab-pane fade in active">
                    
                    

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
                        
                      
                        
                      <div class="col-md-4 col-sm-12 col-lg-4">

                        <asp:DropDownList ID="cmbComplaintReportedVia" class="form-control" runat="server">
                            <asp:ListItem Selected="True"> Complaint Reported Via</asp:ListItem>
                        </asp:DropDownList>
                        <span class="floating-label-select"> Complaint Reported Via</span>
                    
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
                            <asp:ListItem Selected="True"> Case Category</asp:ListItem>
                        </asp:DropDownList>
                        <span class="floating-label-select"> Case Category</span>
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
                            <asp:ListItem Selected="True"> POC Status</asp:ListItem>
                        </asp:DropDownList>
                        <span class="floating-label-select"> POC Status</span>
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
                          
                            <asp:DropDownList ID="cmbComplainStatus" AutoPostBack="true" class="form-control" runat="server" 
                                  onselectedindexchanged="cmbComplainStatus_SelectedIndexChanged">
                                <asp:ListItem Selected="True"> Complain Status</asp:ListItem>
                            </asp:DropDownList>
                            <span class="floating-label-select"> Complain Status</span>
                          </div>

                          <div class="col-md-4 col-sm-12 col-lg-4">

                            <asp:DropDownList ID="cmbAssignedDepartment" class="form-control" runat="server">
                                <asp:ListItem Selected="True"> Assigned Department</asp:ListItem>
                            </asp:DropDownList>
                            <span class="floating-label-select"> Assigned Department</span>
                        
                          </div>
                        
                      
                        
                          <div class="col-md-4 col-sm-12 col-lg-4">

                           
                            <%--<asp:DropDownList ID="cmbInitialStatement" OnSelectedIndexChanged="cmbInitialStatement_SelectedIndexChanged" class="form-control" runat="server">
                                <asp:ListItem Selected="True">Select Initial Statement</asp:ListItem>
                            </asp:DropDownList>--%>

                            <%--<asp:DropDownList ID="cmbInitialStatement" OnSelectedIndexChanged="cmbInitialStatement_SelectedIndexChanged" EnableViewState="true" ViewStateMode="Enabled" class="form-control" runat="server">
                                <asp:ListItem Selected="True">Select Initial Statement</asp:ListItem>
                            </asp:DropDownList>--%>

                                 
                                    <asp:DropDownList ID="cmbInitialStatement" runat="server" OnSelectedIndexChanged="cmbInitialStatement_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>
                            <span class="floating-label-select"> Initial Statement</span>
                         

                          </div>
                        </div>
                    </div>

                     <div class="container-fluid">
                        <div class="row">

                          <div class="col-md-4 col-sm-12 col-lg-4">

                            <asp:DropDownList ID="cmbComplainType" class="form-control" runat="server">
                                <asp:ListItem Selected="True">Select Complain Type</asp:ListItem>
                            </asp:DropDownList>
                            <span class="floating-label-select"> Complain Type</span>
                          </div>

                          <div class="col-md-4 col-sm-12 col-lg-4">

                                 <asp:TextBox ID="tbPerson"  class="form-control mr-sm-2 inputText" runat="server"></asp:TextBox>
                                 <span class="floating-label">Person Given ETA/ETTR</span>
                         
                              </div>

                          
                        </div>
                    </div>
                        
                    
                       
                         

                         <div class="col-md-4 col-sm-12 col-lg-4 table-margin-top" >

                                <%--<span>Complaint Received Date/Time</span>--%>
                                <telerik:RadDateTimePicker ID="dtComplainReceived" runat="server">
                                                    </telerik:RadDateTimePicker>
                                <span class="floating-label-date">Complaint Received Date/Time</span>

                          </div>
                              

                              <div class="col-md-4 col-sm-12 col-lg-4 table-margin-top">

                                    <%--<span>ETTR Date/Time</span>--%>
                                    <telerik:RadDateTimePicker ID="dtETTR" runat="server" MinDate="">
                                    </telerik:RadDateTimePicker>
                                    <span class="floating-label-date">ETTR Date/Time</span>

                              </div>
                        
                              <div class="col-md-4 col-sm-12 col-lg-4 table-margin-top">

                                     <%--<asp:TextBox ID="dtETA" class="form-control mr-sm-2 inputText" runat="server"></asp:TextBox>--%>
                         

                                        <telerik:RadDateTimePicker  ID="dtETA" runat="server" MinDate="">
                                        </telerik:RadDateTimePicker>
                                        <span class="floating-label-date">ETA Date/Time</span>
                        
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

                           
                      
                

                      


                    </div>
                        
                    </div>
                    </form>
                    
                    <div class="customer-buttons" style="margin-right: 15px !important;">
            
                        <div class="row">
                            <asp:Label ID="lblTicketNoAfterComplainGeneration"  runat="server"></asp:Label>
                            <div class="col-xs-12">
                                <div class="text-right">

                                    <asp:Button ID="btSaveComplain" class="btn btn-primary" runat="server" Text="Save Complain"
                                     OnClick="btSaveComplain_Click"></asp:Button>
                                  
                             

                                    <asp:Button ID="btCancel" class="btn btn-primary" runat="server" Text="Cancel"></asp:Button>

                                    

                                </div>
                            </div>
                        </div>
                    </div>
                    
                    <div class="col-md-12 col-sm-12 col-lg-12">
                         <h4>Troubleshooting Step</h4>
                     </div>
                    
                    
         
                     <My:cntIntial_LinkDownDrops runat="server" ID="cntIntial_LinkDownDrops" Visible="false" />
                      <My:cntemailIsuee runat="server" ID="cntemailIsuee" Visible="false" />
                      <My:cntBrowsingDeadIssue runat="server" ID="cntBrowsingDeadIssue" Visible="false" />
                     <My:cntWebIssue runat="server" ID="cntWebIssue" Visible="false" />
                     <My:cntServiceRequest runat="server" ID="cntServiceRequest" Visible="false" />
                </div><!-- COMPLAIN FORM ENDS HERE -->
                
                
                
                <!-- CUSTOMER INFO -->


                <div id="customer-info" class="tab-pane">
                  
                    <form class="form-inline1 mt-2 mt-md-2 mb-md-3">
                    <div class="container-fluid">

                    <div class="row mb-md-3 mb-sm-3 border-box">

                     <div class="container-fluid">
                        <div class="row">
                         <div class="col-md-12 col-sm-12 col-lg-12">
                             <h4>Document Details</h4>
                         </div>  
                        </div>
                     </div>

                     <div class="container-fluid">
                        <div class="row">

                        
                         <div class="col-md-3 col-sm-12 col-lg-3">
                         
                             <asp:TextBox ID="tbSignupID" class="form-control mr-sm-2 inputText" placeholder="Sign Up ID" runat="server"></asp:TextBox>
                             <span class="floating-label">Sign Up ID</span>
                         
                          </div>

                          <div class="col-md-3 col-sm-12 col-lg-3">

                             <asp:TextBox ID="tbServiceUnit" class="form-control mr-sm-2 inputText" runat="server"></asp:TextBox>
                             <span class="floating-label">Service Unit</span>
                        
                          </div>
                        
                          <div class="col-md-3 col-sm-12 col-lg-3">

                             <asp:TextBox ID="tbInfra" class="form-control mr-sm-2 inputText" runat="server"></asp:TextBox>
                             <span class="floating-label">Infra</span>

                          </div>
                        
                          <div class="col-md-3 col-sm-12 col-lg-3">

                             <asp:TextBox ID="tbRegion" class="form-control mr-sm-2 inputText" runat="server"></asp:TextBox>
                             <span class="floating-label">Region</span>

                          </div>

                        </div>
                    </div>

                    <div class="container-fluid">
                        <div class="row">
                        
                          <div class="col-md-3 col-sm-12 col-lg-3">
                          
                             <asp:TextBox ID="tbCustomerEmail" class="form-control mr-sm-2 inputText" runat="server"></asp:TextBox>
                             <span class="floating-label">Customer Email</span>

                           </div>
                        
                          <div class="col-md-3 col-sm-12 col-lg-3">
                          
                             <asp:TextBox ID="tbCircuitName" class="form-control mr-sm-2 inputText" runat="server"></asp:TextBox>
                             <span class="floating-label">Circuit Name</span>

                          </div>
                        
                          <div class="col-md-6 col-sm-12 col-lg-6">

                             <asp:TextBox ID="tbAddress" class="form-control mr-sm-2 inputText" runat="server"></asp:TextBox>
                             <span class="floating-label">Address</span>
                    
                          </div>

                        </div>
                    </div>

                    <div class="container-fluid">
                        <div class="row">
                        
                          <div class="col-md-3 col-sm-12 col-lg-3">
                             <asp:TextBox ID="tbDeploymentDate" runat="server" Enabled="false"></asp:TextBox>
                                <span class="floating-label ">Deployment Date</span>

                          </div>
                        
                          <div class="col-md-3 col-sm-12 col-lg-3">

                             <asp:TextBox ID="tbDeploymentPerson" class="form-control mr-sm-2 inputText" runat="server"></asp:TextBox>
                             <span class="floating-label">Deployment Person</span>

                          </div>
                        
                          <div class="col-md-3 col-sm-12 col-lg-3">

                             <asp:TextBox ID="tbKAMContactNo" class="form-control mr-sm-2 inputText" runat="server"></asp:TextBox>
                             <span class="floating-label">KAM Contact No</span>

                          </div>
                        
                          <div class="col-md-3 col-sm-12 col-lg-3">

                             <asp:TextBox ID="tb3rdPartyAccountID" class="form-control mr-sm-2 inputText" runat="server"></asp:TextBox>
                             <span class="floating-label">3rd Party Account ID</span>

                          </div>
                        </div>
                    </div>

                    <div class="container-fluid">
                        <div class="row">
                        
                          <div class="col-md-3 col-sm-12 col-lg-3">

                             <asp:TextBox ID="tbBandwidth" class="form-control mr-sm-2 inputText" runat="server"></asp:TextBox>
                             <span class="floating-label">Bandwidth</span>

                          </div>
                        
                          <div class="col-md-3 col-sm-12 col-lg-3">

                             <asp:TextBox ID="tbKeyAccountManager" class="form-control mr-sm-2 inputText" runat="server"></asp:TextBox>
                             <span class="floating-label">Key Account Manager</span>
                        
                          </div>

                          <div class="col-md-6 col-sm-12 col-lg-6">
                          
                            <div class="form-group">
                            
                              <asp:TextBox ID="tbCPMRemarks" class="form-control mr-sm-2 inputText" TextMode="multiline" Rows="5" runat="server" />
                              <span class="floating-label">CPM Remarks</span>
                            
                            </div>

                          </div>
                        </div>
                    </div>

                    <div class="container-fluid">
                        <div class="row">
                        
                          <div class="col-md-6 col-sm-12 col-lg-6">
                          
                            <div class="form-group">
                            
                              <asp:TextBox ID="tbDeploymentRemarks" class="form-control mr-sm-2 inputText" TextMode="multiline" Rows="5"  runat="server" />
                              <span class="floating-label">Deployment Remarks</span>
                            
                            </div>
                          
                          </div>
                        
                          <div class="col-md-6 col-sm-12 col-lg-6">

                             <div class="form-group">
                            
                              <asp:TextBox ID="tbOperationalRemarks" class="form-control mr-sm-2 inputText" TextMode="multiline" Rows="5"  runat="server" />
                              <span class="floating-label">Operational Remarks</span>
                             
                             </div>

                          </div>
                        </div>
                    </div>

                    <div class="container-fluid">
                        <div class="row">
                        
                          <div class="col-md-3 col-sm-14 col-lg-3 radio-button-div">

                          <asp:panel ID="rbVOIP" runat="server">
                            <div class="col-md-12">
                                <span>IP Whitelisted for VOIP</span>
                            
                                <%--<asp:RadioButtonList ID="rbVOIP" runat="server" RepeatDirection="Horizontal">
                                    <asp:ListItem>Yes</asp:ListItem>
                                    <asp:ListItem>No</asp:ListItem>
                                </asp:RadioButtonList>--%>
                                
                                <asp:RadioButton ID="rbWhitelistedYes" GroupName="rbWhitelisted" runat="server" Text="Yes"></asp:RadioButton>
                                <asp:RadioButton ID="rbWhitelistedNo" GroupName="rbWhitelisted" runat="server" Text="No" ></asp:RadioButton>
                            </div>
                            </asp:panel>
                          </div>
                          
                          <div class="col-md-3 col-sm-12 col-lg-3 radio-button-div">

                         <asp:panel ID="rbVideo" runat="server">
                            <div class="col-md-12">
                                <span>Video Conferencing</span>
                            
                                <%--<asp:RadioButtonList ID="rbVideo" runat="server" RepeatDirection="Horizontal">
                                    <asp:ListItem>Yes</asp:ListItem>
                                    <asp:ListItem>No</asp:ListItem>
                                </asp:RadioButtonList>--%>
                                    <asp:RadioButton ID="rbVideoYes" runat="server" Text="Yes"></asp:RadioButton>
                                    <asp:RadioButton ID="rbVideoNo" runat="server" Text="No"></asp:RadioButton>

                            </div>

                            </asp:panel>
                          </div>
  
                        </div>
                    </div>
                </div>
            </div>   
        </form>

              <ul class="nav nav-tabs">
                <li class="active">
                    <a data-toggle="tab" href="#primary-info">Primary Information</a>
                </li>
                <li>
                    <a data-toggle="tab" href="#secondary-info">Secondary Information</a>
                </li>
              </ul>

              <!-- TAB CONTENT FOR PRIMARY INFO AND SECONDARY INFO -->
              <div class="tab-content">
                
                <!-- PRIMARY INFO -->
                <div id="primary-info" class="tab-pane fade in active">
                  
                    <form class="form-inline1 mt-2 mt-md-2 mb-md-3">
                    <div class="container-fluid">

                    <div class="row mb-md-3 mb-sm-3 border-box">

                    <div class="container-fluid">
                        <div class="row">
                          <div class="col-md-2 col-sm-12 col-lg-2">
                             <label>Customer IP Pool: </label>
                          </div>
                        
                          <div class="col-md-5 col-sm-12 col-lg-5">
                          
                             <asp:TextBox ID="tbCustomerIPPool1" class="form-control mr-sm-2" runat="server"></asp:TextBox>
                          
                          </div>
                        
                          <div class="col-md-5 col-sm-12 col-lg-5">
                          
                            <asp:TextBox ID="tbCustomerIPPool2" class="form-control mr-sm-2" runat="server"></asp:TextBox>
                          
                          </div>
                        </div>
                    </div>


                    <div class="container-fluid">
                        <div class="row">    
                          <div class="col-md-2 col-sm-12 col-lg-2">
                             <label>Subnet Mask / Gateway IP: </label>
                          </div>
                        
                          <div class="col-md-5 col-sm-12 col-lg-5">
                        
                             <asp:TextBox ID="tbSubnetMask" class="form-control mr-sm-2" runat="server"></asp:TextBox>

                        </div>
                        
                          <div class="col-md-5 col-sm-12 col-lg-5">
                          
                            <asp:TextBox ID="tbGatewayIP" class="form-control mr-sm-2" runat="server"></asp:TextBox>
                          
                          </div>
                        </div>
                    </div>

                    <div class="container-fluid">
                        <div class="row">
                          <div class="col-md-2 col-sm-12 col-lg-2">
                             <label>Ring Name / Node Name: </label>
                          </div>
                        
                          <div class="col-md-5 col-sm-12 col-lg-5">
                          
                             <asp:TextBox ID="tbRingName" class="form-control mr-sm-2" runat="server"></asp:TextBox>
                          
                          </div>
                        
                          <div class="col-md-5 col-sm-12 col-lg-5">
                          
                            <asp:TextBox ID="tbNodeName" class="form-control mr-sm-2" runat="server"></asp:TextBox>

                          </div>
                        </div>
                    </div>
                        

                    <div class="container-fluid">
                        <div class="row">
                          <div class="col-md-2 col-sm-12 col-lg-2">
                             <label>Switch Name / Switch Port: </label>
                          </div>
                        
                          <div class="col-md-5 col-sm-12 col-lg-5">
                        
                             <asp:TextBox ID="tbSwitchName" class="form-control mr-sm-2" runat="server"></asp:TextBox>
                      
                          </div>
                        
                          <div class="col-md-5 col-sm-12 col-lg-5">
                             <asp:TextBox ID="tbSwitchPort" class="form-control mr-sm-2" runat="server"></asp:TextBox>
                          </div>                        
                      </div>
                    </div>

                    <div class="container-fluid">
                        <div class="row">
                          <div class="col-md-2 col-sm-12 col-lg-2">
                             <label>Fiber Length / Client Device: </label>
                          </div>
                          <div class="col-md-5 col-sm-12 col-lg-5">
                          
                            <asp:TextBox ID="tbFiberLength" class="form-control mr-sm-2" runat="server"></asp:TextBox>                       
                       
                          </div>
                        
                          <div class="col-md-5 col-sm-12 col-lg-5 radio-button-div">
                             <label class="radio-spacing">
                                 <asp:RadioButtonList ID="rbClientDevice" runat="server" RepeatDirection="Horizontal">
                                                            <asp:ListItem>CPE</asp:ListItem>
                                                            <asp:ListItem>ODU</asp:ListItem>
                                                            <asp:ListItem>MC</asp:ListItem>
                                                        </asp:RadioButtonList>
                             </label>
                          </div>
                        </div>
                     </div>
                        
                    <div class="container-fluid">
                        <div class="row">
                          <div class="col-md-2 col-sm-12 col-lg-2">
                             <label>CPE Model / Wavelength: </label>
                          </div>
                        
                          <div class="col-md-5 col-sm-12 col-lg-5">
                        
                             <asp:TextBox ID="tbCPEModel" class="form-control mr-sm-2" runat="server"></asp:TextBox>
                 
                          </div>
                        
                          <div class="col-md-5 col-sm-12 col-lg-5">
                          
                            <asp:TextBox ID="tbWavelength" class="form-control mr-sm-2" runat="server"></asp:TextBox>
                         
                          </div>
                        </div>
                       </div>
                        
                    <div class="container-fluid">
                        <div class="row">

                          <div class="col-md-2 col-sm-12 col-lg-2">
                             <label>CPE Address / CPE Port: </label>
                          </div>
                        
                          <div class="col-md-5 col-sm-12 col-lg-5">
                          
                             <asp:TextBox ID="tbCPEAddress" class="form-control mr-sm-2" runat="server"></asp:TextBox>
                          
                          </div>
                        
                          <div class="col-md-5 col-sm-12 col-lg-5">
                        
                            <asp:TextBox ID="tbCPEPort" class="form-control mr-sm-2" runat="server"></asp:TextBox>
                        
                          </div>

                        </div>
                    </div>
                        
                    <div class="container-fluid">
                        <div class="row">

                          <div class="col-md-2 col-sm-12 col-lg-2">
                             <label>Circuit Owner / Third Part: </label>
                          </div>
                        
                          <div class="col-md-5 col-sm-12 col-lg-5">
                          
                             <asp:TextBox ID="tbCircuitOwner" class="form-control mr-sm-2" runat="server"></asp:TextBox>
                         
                          </div>
                        
                          <div class="col-md-5 col-sm-12 col-lg-5">
                          
                            <asp:TextBox ID="tbThirdParty" class="form-control mr-sm-2" runat="server"></asp:TextBox>
                         
                           </div>
                        </div>
                    </div>
                      
                    <div class="container-fluid">
                         <div class="row">  
                          <div class="col-md-2 col-sm-12 col-lg-2">
                             <label>OLT Pan Port / OLT IP Address: </label>
                          </div>
                        
                          <div class="col-md-5 col-sm-12 col-lg-5">
                          
                             <asp:TextBox ID="tbOLTPonPort" class="form-control mr-sm-2" runat="server"></asp:TextBox>
                         
                          </div>
                        
                          <div class="col-md-5 col-sm-12 col-lg-5">
                          
                            <asp:TextBox ID="tbOLTIPAddress" class="form-control mr-sm-2" runat="server"></asp:TextBox>
                          
                          </div>
                        </div>
                    </div>

                    </div>

                    </div>
                    </form>
                    
                </div><!-- PRIMARY INFO ENDS HERE -->
                  
                <!-- SECONDARY INFO -->
                <div id="secondary-info" class="tab-pane fade">
                  
                   <form class="form-inline1 mt-2 mt-md-2 mb-md-3">
                    <div class="container-fluid">
                    
                    <div class="row mb-md-3 mb-sm-3 border-box">
                    
                    <div class="container-fluid">
                        <div class="row">
                        
                              <div class="col-md-2 col-sm-12 col-lg-2">
                                 <label>Customer IP Pool: </label>
                              </div>
                        
                              <div class="col-md-5 col-sm-12 col-lg-5">
                          
                                 <asp:TextBox ID="tbCustomerIPPool21" class="form-control mr-sm-2" runat="server"></asp:TextBox>
                          
                              </div>
                        
                              <div class="col-md-5 col-sm-12 col-lg-5">
                          
                                <asp:TextBox ID="tbCustomerIPPool22" class="form-control mr-sm-2" runat="server"></asp:TextBox>
                        
                              </div>

                         </div>
                     </div>
                        

                    <div class="container-fluid">
                        <div class="row">
                          <div class="col-md-2 col-sm-12 col-lg-2">
                             <label>Subnet Mask / Gateway IP: </label>
                          </div>
                        
                          <div class="col-md-5 col-sm-12 col-lg-5">
                          
                             <asp:TextBox ID="tbSubnetMask21" class="form-control mr-sm-2" runat="server"></asp:TextBox>
                          
                          </div>
                        
                          <div class="col-md-5 col-sm-12 col-lg-5">
                          
                            <asp:TextBox ID="tbGatewayIP22" class="form-control mr-sm-2" runat="server"></asp:TextBox>
                         
                          </div>
                        </div>
                    </div>

                    <div class="container-fluid">
                        <div class="row">
                          <div class="col-md-2 col-sm-12 col-lg-2">
                             <label>Ring Name / Node Name: </label>
                          </div>
                        
                          <div class="col-md-5 col-sm-12 col-lg-5">
                          
                             <asp:TextBox ID="tbRingName21" class="form-control mr-sm-2" runat="server"></asp:TextBox>
                          
                          </div>
                        
                          <div class="col-md-5 col-sm-12 col-lg-5">
                          
                            <asp:TextBox ID="tbNodeName22" class="form-control mr-sm-2" runat="server"></asp:TextBox>
                       
                          </div>
                        </div>
                    </div>
                        
                    <div class="container-fluid">
                        <div class="row">
                          <div class="col-md-2 col-sm-12 col-lg-2">
                             <label>Switch Name / Switch Port: </label>
                          </div>
                        
                          <div class="col-md-5 col-sm-12 col-lg-5">
                          
                             <asp:TextBox ID="tbSwitchName21" class="form-control mr-sm-2" runat="server"></asp:TextBox>

                          </div>

                          <div class="col-md-5 col-sm-12 col-lg-5">
                          
                             <asp:TextBox ID="tbSwitchPort22" class="form-control mr-sm-2" runat="server"></asp:TextBox>
                         
                          </div>
                        </div>
                    </div>
                        
                    <div class="container-fluid">
                        <div class="row">                        
                          <div class="col-md-2 col-sm-12 col-lg-2">
                             <label>Fiber Length / Client Device: </label>
                          </div>
                          <div class="col-md-5 col-sm-12 col-lg-5">
                          
                            <asp:TextBox ID="tbFiberLength21" class="form-control mr-sm-2" runat="server"></asp:TextBox>
                        
                          </div>
                          <div class="col-md-5 col-sm-12 col-lg-5 radio-button-div">
                             <label class="radio-spacing">
                                 <asp:RadioButtonList ID="rbClientDevice2" runat="server" RepeatDirection="Horizontal">
                                                            <asp:ListItem>CPE</asp:ListItem>
                                                            <asp:ListItem>ODU</asp:ListItem>
                                                            <asp:ListItem>MC</asp:ListItem>
                                                        </asp:RadioButtonList>
                             </label>
                          </div>
                        </div>
                    </div>

                    <div class="container-fluid">
                        <div class="row">
                          <div class="col-md-2 col-sm-12 col-lg-2">
                             <label>CPE Model / Wavelength: </label>
                          </div>
                        
                          <div class="col-md-5 col-sm-12 col-lg-5">
                        
                             <asp:TextBox ID="tbCPEModel21" class="form-control mr-sm-2" runat="server"></asp:TextBox>
                          
                          </div>
                        
                          <div class="col-md-5 col-sm-12 col-lg-5">
                          
                            <asp:TextBox ID="tbWavelength22" class="form-control mr-sm-2" runat="server"></asp:TextBox>
                         
                          </div>
                        </div>
                    </div>
                      
                    <div class="container-fluid">
                        <div class="row">  
                          <div class="col-md-2 col-sm-12 col-lg-2">
                             <label>CPE Address / CPE Port: </label>
                          </div>
                        
                          <div class="col-md-5 col-sm-12 col-lg-5">
                          
                             <asp:TextBox ID="tbCPEAddress21" class="form-control mr-sm-2" runat="server"></asp:TextBox>
                          
                          </div>
                        
                          <div class="col-md-5 col-sm-12 col-lg-5">
                          
                            <asp:TextBox ID="tbCPEPort22" class="form-control mr-sm-2" runat="server"></asp:TextBox>
                         
                          </div>
                        </div>
                    </div>
                      
                    <div class="container-fluid">
                        <div class="row">  
                          <div class="col-md-2 col-sm-12 col-lg-2">
                             <label>Backup Circuit Owner / Backup Third Party Name: </label>
                          </div>
                        
                          <div class="col-md-5 col-sm-12 col-lg-5">
                          
                             <asp:TextBox ID="tbBackupCircuitOwner" class="form-control mr-sm-2" runat="server"></asp:TextBox>
                          
                          </div>
                        
                          <div class="col-md-5 col-sm-12 col-lg-5">
                          
                            <asp:TextBox ID="tbBackupThirdPartyName" class="form-control mr-sm-2" runat="server"></asp:TextBox>
                        
                          </div>
                        </div>
                    </div>

                    <div class="container-fluid">
                        <div class="row">
                          <div class="col-md-2 col-sm-12 col-lg-2">
                             <label>OLT Pan Port / OLT IP Address: </label>
                          </div>
                          <div class="col-md-5 col-sm-12 col-lg-5">
                          
                             <asp:TextBox ID="tbOLTPonPort21" class="form-control mr-sm-2" runat="server"></asp:TextBox>
                          
                          </div>
                        
                          <div class="col-md-5 col-sm-12 col-lg-5">
                          
                            <asp:TextBox ID="tbOLTIPAddress22" class="form-control mr-sm-2" runat="server"></asp:TextBox>
                        
                          </div>
                        </div>
                    </div>
                    
                </div>
                        
                       </div>
                    </form>
                
                  </div><!-- SECONDARY INFO ENDS HERE -->
                    
              </div>
               
                    </div>
                    
              <!-- MENUS FOR PRIMARY INFO AND SECONDARY INFO -->
                   <!-- COMPLAIN FORM --> 
                  
     
              
                </div><!-- CUSTOMER INFO ENDS HERE -->
                
               
              </div><!-- TAB CONTENT FOR CUSTOMER INFO AND COMPLAIN FORM -->
                
               
            
            </ContentTemplate>
            </asp:UpdatePanel>
            </form>
          </main>
          </div>
       </div>




</asp:Content>
