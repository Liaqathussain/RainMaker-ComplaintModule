<%@ Page Title="" Language="C#" MasterPageFile="~/MainForms_Site.Master" AutoEventWireup="true" CodeBehind="ComplainForm.aspx.cs" Inherits="RainMaker.ComplainManagement.ComplainForm" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">


<div class="container-fluid">
        <div class="row">
         <main class="col-md-offset-3 col-sm-offset-3 col-lg-offset-3 col-sm-9 ml-sm-auto col-md-9 pt-3 customer" role="main">
            <form id="Form1" runat="server">
             <telerik:RadScriptManager ID="RadScriptManager1" runat="server">
    </telerik:RadScriptManager>
            <div class="customer content-area">
                
              <!-- MENUS FOR CUSTOMER INF AND COMPLAIN FORM -->
              <ul class="nav nav-tabs">
                <li class="active">
                    <a data-toggle="tab" href="#customer-info">Customer Information</a>
                </li>
                <li>
                    <a data-toggle="tab" href="#complain-form">Complain Form</a>
                </li>
              </ul>
                
              <!-- TAB CONTENT FOR CUSTOMER INFO AND COMPLAIN FORM -->
              <div class="tab-content">
                <!-- CUSTOMER INFO -->
                <div id="customer-info" class="tab-pane fade in active">
                  
                    <form class="form-inline1 mt-2 mt-md-2 mb-md-3">
                    <div class="container-fluid">

                    <div class="row mb-md-3 mb-sm-3 border-box">

                     <div class="col-md-12 col-sm-12 col-lg-12">
                         <h4>Document Details</h4>
                     </div>  

                     <div class="col-md-3 col-sm-12 col-lg-3">
                         
                         <asp:TextBox ID="tbSignupID" class="form-control mr-sm-2" placeholder="Sign Up ID" runat="server"></asp:TextBox>
                         
                      </div>

                      <div class="col-md-3 col-sm-12 col-lg-3">

                         <asp:TextBox ID="tbServiceUnit" class="form-control mr-sm-2" placeholder="Service Unit" runat="server"></asp:TextBox>
                        
                      </div>
                        
                      <div class="col-md-3 col-sm-12 col-lg-3">

                         <asp:TextBox ID="tbInfra" class="form-control mr-sm-2" placeholder="Infra" runat="server"></asp:TextBox>

                      </div>
                        
                      <div class="col-md-3 col-sm-12 col-lg-3">

                         <asp:TextBox ID="tbRegion" class="form-control mr-sm-2" placeholder="Region" runat="server"></asp:TextBox>

                      </div>
                        
                      <div class="col-md-3 col-sm-12 col-lg-3">
                          
                         <asp:TextBox ID="tbCustomerEmail" class="form-control mr-sm-2" placeholder="Customer Email" runat="server"></asp:TextBox>

                      </div>
                        
                      <div class="col-md-3 col-sm-12 col-lg-3">
                          
                         <asp:TextBox ID="tbCircuitName" class="form-control mr-sm-2" placeholder="Circuit Name" runat="server"></asp:TextBox>

                      </div>
                        
                      <div class="col-md-6 col-sm-12 col-lg-6">

                         <asp:TextBox ID="tbAddress" class="form-control mr-sm-2" placeholder="Address" runat="server"></asp:TextBox>
                    
                      </div>
                        
                      <div class="col-md-4 col-sm-12 col-lg-4">
                          
                        <div class="form-group">
                            
                          <asp:TextBox ID="tbCPMRemarks" class="form-control" TextMode="multiline" Rows="5" placeholder="CPM Remarks" runat="server" />
                            
                        </div>

                      </div>
                        
                      <div class="col-md-4 col-sm-12 col-lg-4">
                          
                        <div class="form-group">
                            
                          <asp:TextBox ID="tbDeploymentRemarks" class="form-control" TextMode="multiline" Rows="5"  placeholder="Deployment Remarks" runat="server" />
                            
                        </div>
                          
                      </div>
                        
                      <div class="col-md-4 col-sm-12 col-lg-4">

                         <div class="form-group">
                            
                          <asp:TextBox ID="tbOperationalRemarks" class="form-control" TextMode="multiline" Rows="5" placeholder="Operational Remarks" runat="server" />
                             
                         </div>

                      </div>
                        
                      <div class="col-md-3 col-sm-12 col-lg-3">

                         <telerik:RadDatePicker ID="dtDeploymentDate" Runat="server" MinDate="1900-01-01" 
                                    SelectedDate="1900-01-01" 
                                    >
                                    <Calendar UseRowHeadersAsSelectors="False" UseColumnHeadersAsSelectors="False" ViewSelectorText="x"></Calendar>

                                    <DateInput DisplayDateFormat="M/d/yyyy" DateFormat="M/d/yyyy" SelectedDate="1900-01-01"></DateInput>

                                    <DatePopupButton ImageUrl="" HoverImageUrl=""></DatePopupButton>
                         </telerik:RadDatePicker>

                      </div>
                        
                      <div class="col-md-3 col-sm-12 col-lg-3">

                         <asp:TextBox ID="tbDeploymentPerson" class="form-control mr-sm-2" placeholder="Deployment Person" runat="server"></asp:TextBox>

                      </div>
                        
                      <div class="col-md-3 col-sm-12 col-lg-3">

                         <asp:TextBox ID="tbKAMContactNo" class="form-control mr-sm-2" placeholder="KAM Contact No" runat="server"></asp:TextBox>

                      </div>
                        
                      <div class="col-md-3 col-sm-12 col-lg-3">

                         <asp:TextBox ID="tb3rdPartyAccountID" class="form-control mr-sm-2" placeholder="3rd Party Account ID" runat="server"></asp:TextBox>

                      </div>
                        
                      <div class="col-md-3 col-sm-12 col-lg-3">

                         <asp:TextBox ID="tbBandwidth" class="form-control mr-sm-2" placeholder="Bandwidth" runat="server"></asp:TextBox>

                      </div>
                        
                      <div class="col-md-3 col-sm-12 col-lg-3">

                         <asp:TextBox ID="tbKeyAccountManager" class="form-control mr-sm-2" placeholder="Key Account Manager" runat="server"></asp:TextBox>
                        
                      </div>
  
                      <div class="col-md-3 col-sm-12 col-lg-3">

                            <span class="normal-top_padding bottom-border">IP Whitelisted for VOIP</span>&nbsp;
                            <label>
                                <asp:RadioButton ID="RadioButton1" name="ipwhite" runat="server" Text="Yes"></asp:RadioButton>
                            </label>
                            <label>
                                <asp:RadioButton ID="RadioButton2" name="ipwhite" runat="server" Text="No"></asp:RadioButton>
                            </label> 

                      </div>
                        
                      <div class="col-md-3 col-sm-12 col-lg-3">

                            <asp:RadioButtonList ID="rbVideo" runat="server" RepeatDirection="Horizontal">
                                                    <asp:ListItem>Yes</asp:ListItem>
                                                    <asp:ListItem>No</asp:ListItem>
                                                </asp:RadioButtonList>
                      </div>
                        
                    </div>
                        
                    </div>
                    </form>
                    
              <!-- MENUS FOR PRIMARY INFO AND SECONDARY INFO -->
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

                      <div class="col-md-2 col-sm-12 col-lg-2">
                         <label>Customer IP Pool: </label>
                      </div>
                        
                      <div class="col-md-5 col-sm-12 col-lg-5">
                          
                         <asp:TextBox ID="tbCustomerIPPool1" class="form-control mr-sm-2" runat="server"></asp:TextBox>
                          
                      </div>
                        
                      <div class="col-md-5 col-sm-12 col-lg-5">
                          
                        <asp:TextBox ID="tbCustomerIPPool2" class="form-control mr-sm-2" runat="server"></asp:TextBox>
                          
                      </div>
                        
                      <div class="col-md-2 col-sm-12 col-lg-2">
                         <label>Subnet Mask / Gateway IP: </label>
                      </div>
                        
                      <div class="col-md-5 col-sm-12 col-lg-5">
                        
                         <asp:TextBox ID="tbSubnetMask" class="form-control mr-sm-2" runat="server"></asp:TextBox>

                      </div>
                        
                      <div class="col-md-5 col-sm-12 col-lg-5">
                          
                        <asp:TextBox ID="tbGatewayIP" class="form-control mr-sm-2" runat="server"></asp:TextBox>
                          
                      </div>

                      <div class="col-md-2 col-sm-12 col-lg-2">
                         <label>Ring Name / Node Name: </label>
                      </div>
                        
                      <div class="col-md-5 col-sm-12 col-lg-5">
                          
                         <asp:TextBox ID="tbRingName" class="form-control mr-sm-2" runat="server"></asp:TextBox>
                          
                      </div>
                        
                      <div class="col-md-5 col-sm-12 col-lg-5">
                          
                        <asp:TextBox ID="tbNodeName" class="form-control mr-sm-2" runat="server"></asp:TextBox>

                      </div>
                        
                      <div class="col-md-2 col-sm-12 col-lg-2">
                         <label>Switch Name / Switch Port: </label>
                      </div>
                        
                      <div class="col-md-5 col-sm-12 col-lg-5">
                        
                         <asp:TextBox ID="tbSwitchName" class="form-control mr-sm-2" runat="server"></asp:TextBox>
                          
                         <asp:TextBox ID="tbSwitchPort" class="form-control mr-sm-2" runat="server"></asp:TextBox>

                      </div>
                        
                      <div class="col-md-5 col-sm-12 col-lg-5">
                          
                        <asp:TextBox ID="TextBox24" class="form-control mr-sm-2" runat="server"></asp:TextBox>
                       
                      </div>
                        
                      <div class="col-md-12 col-sm-12 col-lg-12">
                        
                      </div>
                        
                      <div class="col-md-2 col-sm-12 col-lg-2">
                         <label>Fiber Length / Client Device: </label>
                      </div>
                        
                      <div class="col-md-10 col-sm-12 col-lg-10">
                         
                                                    <telerik:RadTextBox ID="tbFiberLength" runat="server" Width="200px">
                                                    </telerik:RadTextBox>
                                                    <asp:RadioButtonList ID="rbClientDevice" runat="server" RepeatDirection="Horizontal">
                                                        <asp:ListItem>CPE</asp:ListItem>
                                                        <asp:ListItem>ODU</asp:ListItem>
                                                        <asp:ListItem>MC</asp:ListItem>
                                                    </asp:RadioButtonList>
                      </div>
                        
                      <div class="col-md-2 col-sm-12 col-lg-2">
                         <label>CPE Model / Wavelength: </label>
                      </div>
                        
                      <div class="col-md-5 col-sm-12 col-lg-5">
                        
                         <asp:TextBox ID="tbCPEModel" class="form-control mr-sm-2" runat="server"></asp:TextBox>
                 
                      </div>
                        
                      <div class="col-md-5 col-sm-12 col-lg-5">
                          
                        <asp:TextBox ID="tbWavelength" class="form-control mr-sm-2" runat="server"></asp:TextBox>
                         
                      </div>
                        
                      <div class="col-md-2 col-sm-12 col-lg-2">
                         <label>CPE Address / CPE Port: </label>
                      </div>
                        
                      <div class="col-md-5 col-sm-12 col-lg-5">
                          
                         <asp:TextBox ID="tbCPEAddress" class="form-control mr-sm-2" runat="server"></asp:TextBox>
                          
                      </div>
                        
                      <div class="col-md-5 col-sm-12 col-lg-5">
                        
                        <asp:TextBox ID="tbCPEPort" class="form-control mr-sm-2" runat="server"></asp:TextBox>
                        
                      </div>
                        
                      <div class="col-md-2 col-sm-12 col-lg-2">
                         <label>Circuit Owner / Third Part: </label>
                      </div>
                        
                      <div class="col-md-5 col-sm-12 col-lg-5">
                          
                         <asp:TextBox ID="tbCircuitOwner" class="form-control mr-sm-2" runat="server"></asp:TextBox>
                         
                      </div>
                        
                      <div class="col-md-5 col-sm-12 col-lg-5">
                          
                        <asp:TextBox ID="tbThirdParty" class="form-control mr-sm-2" runat="server"></asp:TextBox>
                         
                      </div>
                        
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
                    </form>
                    
                </div><!-- PRIMARY INFO ENDS HERE -->
                  
                <!-- SECONDARY INFO -->
                <div id="secondary-info" class="tab-pane fade">
                  
                   <form class="form-inline1 mt-2 mt-md-2 mb-md-3">
                    <div class="container-fluid">
                    
                    <div class="row mb-md-3 mb-sm-3 border-box">
                    
                      <div class="col-md-2 col-sm-12 col-lg-2">
                         <label>Customer IP Pool: </label>
                      </div>
                        
                      <div class="col-md-5 col-sm-12 col-lg-5">
                          
                         <asp:TextBox ID="tbCustomerIPPool21" class="form-control mr-sm-2" runat="server"></asp:TextBox>
                          
                      </div>
                        
                      <div class="col-md-5 col-sm-12 col-lg-5">
                          
                        <asp:TextBox ID="tbCustomerIPPool22" class="form-control mr-sm-2" runat="server"></asp:TextBox>
                        
                      </div>
                        
                      <div class="col-md-2 col-sm-12 col-lg-2">
                         <label>Subnet Mask / Gateway IP: </label>
                      </div>
                        
                      <div class="col-md-5 col-sm-12 col-lg-5">
                          
                         <asp:TextBox ID="tbSubnetMask21" class="form-control mr-sm-2" runat="server"></asp:TextBox>
                          
                      </div>
                        
                      <div class="col-md-5 col-sm-12 col-lg-5">
                          
                        <asp:TextBox ID="tbGatewayIP22" class="form-control mr-sm-2" runat="server"></asp:TextBox>
                         
                      </div>

                      <div class="col-md-2 col-sm-12 col-lg-2">
                         <label>Ring Name / Node Name: </label>
                      </div>
                        
                      <div class="col-md-5 col-sm-12 col-lg-5">
                          
                         <asp:TextBox ID="tbRingName21" class="form-control mr-sm-2" runat="server"></asp:TextBox>
                          
                      </div>
                        
                      <div class="col-md-5 col-sm-12 col-lg-5">
                          
                        <asp:TextBox ID="tbNodeName22" class="form-control mr-sm-2" runat="server"></asp:TextBox>
                       
                      </div>
                        
                      <div class="col-md-2 col-sm-12 col-lg-2">
                         <label>Switch Name / Switch Port: </label>
                      </div>
                        
                      <div class="col-md-5 col-sm-12 col-lg-5">
                          
                         <asp:TextBox ID="tbSwitchName21" class="form-control mr-sm-2" runat="server"></asp:TextBox>
                          
                         <asp:TextBox ID="tbSwitchPort22" class="form-control mr-sm-2" runat="server"></asp:TextBox>
                         
                      </div>
                        
                      <div class="col-md-5 col-sm-12 col-lg-5">
                          
                        <asp:TextBox ID="TextBox40" class="form-control mr-sm-2" runat="server"></asp:TextBox>
                        
                      </div>
                        
                      <div class="col-md-12 col-sm-12 col-lg-12">
                        
                      </div>
                        
                      <div class="col-md-2 col-sm-12 col-lg-2">
                         <label>Fiber Length / Client Device: </label>
                      </div>
                        
                      <div class="col-md-10 col-sm-12 col-lg-10">
                         
                                                    <telerik:RadTextBox ID="tbFiberLength21" runat="server" Width="200px">
                                                    </telerik:RadTextBox>
                                                    <asp:RadioButtonList ID="rbClientDevice2" runat="server" RepeatDirection="Horizontal">
                                                        <asp:ListItem>CPE</asp:ListItem>
                                                        <asp:ListItem>ODU</asp:ListItem>
                                                        <asp:ListItem>MC</asp:ListItem>
                                                    </asp:RadioButtonList>
                      </div>
                        
                      <div class="col-md-2 col-sm-12 col-lg-2">
                         <label>CPE Model / Wavelength: </label>
                      </div>
                        
                      <div class="col-md-5 col-sm-12 col-lg-5">
                        
                         <asp:TextBox ID="tbCPEModel21" class="form-control mr-sm-2" runat="server"></asp:TextBox>
                          
                      </div>
                        
                      <div class="col-md-5 col-sm-12 col-lg-5">
                          
                        <asp:TextBox ID="tbWavelength22" class="form-control mr-sm-2" runat="server"></asp:TextBox>
                         
                      </div>
                        
                      <div class="col-md-2 col-sm-12 col-lg-2">
                         <label>CPE Address / CPE Port: </label>
                      </div>
                        
                      <div class="col-md-5 col-sm-12 col-lg-5">
                          
                         <asp:TextBox ID="tbCPEAddress21" class="form-control mr-sm-2" runat="server"></asp:TextBox>
                          
                      </div>
                        
                      <div class="col-md-5 col-sm-12 col-lg-5">
                          
                        <asp:TextBox ID="tbCPEPort22" class="form-control mr-sm-2" runat="server"></asp:TextBox>
                         
                      </div>
                        
                      <div class="col-md-2 col-sm-12 col-lg-2">
                         <label>Backup Circuit Owner / Backup Third Party Name: </label><label>OLT Pan Port / OLT IP Address: </label>
                      </div>
                        
                      <div class="col-md-5 col-sm-12 col-lg-5">
                          
                         <asp:TextBox ID="tbBackupCircuitOwner" class="form-control mr-sm-2" runat="server"></asp:TextBox>
                          
                      </div>
                        
                      <div class="col-md-5 col-sm-12 col-lg-5">
                          
                        <asp:TextBox ID="tbBackupThirdPartyName" class="form-control mr-sm-2" runat="server"></asp:TextBox>
                        
                      </div>

                      <div class="col-md-5 col-sm-12 col-lg-5">
                          
                         <asp:TextBox ID="tbOLTPonPort21" class="form-control mr-sm-2" runat="server"></asp:TextBox>
                          
                      </div>
                        
                      <div class="col-md-5 col-sm-12 col-lg-5">
                          
                        <asp:TextBox ID="tbOLTIPAddress22" class="form-control mr-sm-2" runat="server"></asp:TextBox>
                        
                      </div>
                    
                </div>
                        
                       </div>
                    </form>
                
                  </div><!-- SECONDARY INFO ENDS HERE -->
                    
              </div>
                    
                </div><!-- CUSTOMER INFO ENDS HERE -->
                
                <!-- COMPLAIN FORM -->  
                <div id="complain-form" class="tab-pane">
                    
                    <form class="form-inline1 mt-2 mt-md-2 mb-md-3">
                    <div class="container-fluid">

                    <div class="row mb-md-3 mb-sm-3 border-box">

                     <div class="col-md-12 col-sm-12 col-lg-12">
                         <h4>Basic Information</h4>
                     </div>  

                     <div class="col-md-4 col-sm-12 col-lg-4">
                         
                         <asp:TextBox ID="tbLoggedBy" class="form-control mr-sm-2" placeholder="Logged By" runat="server"></asp:TextBox>

                      </div>

                      <div class="col-md-4 col-sm-12 col-lg-4">

                         <asp:TextBox ID="tbCallerName" class="form-control mr-sm-2" placeholder="Caller Name" runat="server"></asp:TextBox>

                      </div>
                        
                      <div class="col-md-4 col-sm-12 col-lg-4">

                         <p>Engineer Name:</p>
                         <p>Syed Muhammad Abdul Sami Abbas</p>

                      </div>
                        
                      <div class="col-md-4 col-sm-12 col-lg-4">

                        <asp:DropDownList ID="cmbComplaintReportedVia" class="form-control" runat="server">
                            <asp:ListItem Selected="True">Select Complaint Reported Via</asp:ListItem>
                        </asp:DropDownList>
                    
                      </div>
                        
                      <div class="col-md-4 col-sm-12 col-lg-4">

                         <asp:TextBox ID="tbCallerNumber" class="form-control mr-sm-2" placeholder="Caller Number" runat="server"></asp:TextBox>

                      </div>
                        
                      <div class="col-md-4 col-sm-12 col-lg-4">

                         <p>Date / Time:</p>
                         <p>12/8/2017 9:37:29 AM</p>

                      </div>
                        
                      <div class="col-md-4 col-sm-12 col-lg-4">

                        <asp:DropDownList ID="cmbCaseCategory" class="form-control" runat="server">
                            <asp:ListItem Selected="True">Select Case Category</asp:ListItem>
                        </asp:DropDownList>

                      </div>
                        
                      <div class="col-md-4 col-sm-12 col-lg-4">

                         <asp:TextBox ID="tbPOCName" class="form-control mr-sm-2" placeholder="POC Name" runat="server"></asp:TextBox>

                      </div>
                        
                      <div class="col-md-4 col-sm-12 col-lg-4">

                         <asp:TextBox ID="tbPOCNumber" class="form-control mr-sm-2" placeholder="POC Number" runat="server"></asp:TextBox>

                      </div>
                        
                      <div class="col-md-4 col-sm-12 col-lg-4">

                        <asp:DropDownList ID="cmbPOCStatus" class="form-control" runat="server">
                            <asp:ListItem Selected="True">Select POC Status</asp:ListItem>
                        </asp:DropDownList>
                        
                      </div>
                        
                      
                      <div class="col-md-12 col-sm-12 col-lg-12">
                         <h4>Other Information</h4>
                      </div>
                        
                      <div class="col-md-4 col-sm-12 col-lg-4">
                          
                        <asp:DropDownList ID="cmbComplainStatus" class="form-control" runat="server">
                            <asp:ListItem Selected="True">Select Complain Status</asp:ListItem>
                        </asp:DropDownList>
                          
                      </div>

                      <div class="col-md-4 col-sm-12 col-lg-4">

                        <asp:DropDownList ID="cmbAssignedDepartment" class="form-control" runat="server">
                            <asp:ListItem Selected="True">Select Assigned Department</asp:ListItem>
                        </asp:DropDownList>
                        
                      </div>
                        
                      <div class="col-md-4 col-sm-12 col-lg-4">

                         <asp:TextBox ID="TextBox54" class="form-control mr-sm-2" placeholder="Deployment Complaint Received Date/Time" runat="server"></asp:TextBox>

                      </div>
                        
                      <div class="col-md-4 col-sm-12 col-lg-4">

                        <asp:DropDownList ID="cmbInitialStatement" class="form-control" runat="server">
                            <asp:ListItem Selected="True">Select Initial Statement</asp:ListItem>
                        </asp:DropDownList>

                      </div>
                        
                      <div class="col-md-4 col-sm-12 col-lg-4">

                        <asp:DropDownList ID="cmbComplainType" class="form-control" runat="server">
                            <asp:ListItem Selected="True">Select Complain Type</asp:ListItem>
                        </asp:DropDownList>
                        
                      </div>
                        
                      <div class="col-md-4 col-sm-12 col-lg-4">

                         <telerik:RadDateTimePicker ID="dtETA" runat="server" MinDate="">
                                                    </telerik:RadDateTimePicker>
                      </div>
                        
                      <div class="col-md-4 col-sm-12 col-lg-4">

                         <telerik:RadDateTimePicker ID="dtETTR" runat="server" MinDate="">
                                                    </telerik:RadDateTimePicker>
                      </div>
                        
                      <%--<div class="col-md-4 col-sm-12 col-lg-4">

                         <asp:TextBox ID="TextBox57" class="form-control mr-sm-2" placeholder="ETTR Date/Time" runat="server"></asp:TextBox>

                      </div>--%>

                    </div>
                        
                    </div>
                    </form>
                    
                    <div class="customer-buttons" style="margin-right: 15px !important;">
            
                        <div class="row">
                            <div class="col-xs-12">
                                <div class="text-right">

                                    <asp:Button ID="btSaveComplain" runat="server" class="btn btn-primary" Text="Save Complain"></asp:Button>
                                    
                                    <asp:Button ID="btCancel" runat="server" Text="Cancel" class="btn btn-primary"></asp:Button>

                                </div>
                            </div>
                        </div>
                    </div>
                    
                    <div class="col-md-12 col-sm-12 col-lg-12">
                         <h4>Troubleshooting Step</h4>
                     </div>
                    <!-- MENUS FOR PRIMARY INFO AND SECONDARY INFO -->
              <ul class="nav nav-tabs">
                <li class="active">
                    <a data-toggle="tab" href="#ts-1">Troubleshooting Page 1</a>
                </li>
                <li>
                    <a data-toggle="tab" href="#ts-2">Troubleshooting Page 2</a>
                </li>
                <li>
                    <a data-toggle="tab" href="#ts-3">Troubleshooting Page 3</a>
                </li>
              </ul>

              <!-- TAB CONTENT FOR PRIMARY INFO AND SECONDARY INFO -->
              <div class="tab-content">
                
                <!-- PRIMARY INFO -->
                <div id="ts-1" class="tab-pane fade in active">
                  
                    <form class="form-inline1 mt-2 mt-md-2 mb-md-3">
                    <div class="container-fluid">

                    <div class="row mb-md-3 mb-sm-3 border-box">

                      <div class="col-md-2 col-sm-12 col-lg-2">
                         <label>Node Port Status: </label>
                      </div>
                        
                      <div class="col-md-10 col-sm-12 col-lg-10">
                         <label>
                             <asp:RadioButton ID="RadioButton11" name="node-status" runat="server" Text="Down"></asp:RadioButton>
                         </label>
                         <label>
                             <asp:RadioButton ID="RadioButton12" name="node-status" runat="server" Text="Up"></asp:RadioButton>
                         </label>
                      </div>
                        
                      <div class="col-md-2 col-sm-12 col-lg-2">
                         <label>Traffic Status at Node Port: </label>
                      </div>
                        
                      <div class="col-md-10 col-sm-12 col-lg-10">
                         <label>
                             <asp:RadioButton ID="RadioButton13" name="status-node-port" runat="server" Text="No Traffic"></asp:RadioButton>
                         </label>
                         <label>
                             <asp:RadioButton ID="RadioButton14" name="status-node-port" runat="server" Text="One Way Traffic"></asp:RadioButton>
                         </label>
                         <label>
                             <asp:RadioButton ID="RadioButton15" name="status-node-port" runat="server" Text="Two Way Traffic"></asp:RadioButton>
                         </label>
                      </div>

                      <div class="col-md-2 col-sm-12 col-lg-2">
                         <label>Traffic Utilization at Node Port: </label>
                      </div>
                        
                      <div class="col-md-10 col-sm-12 col-lg-10">
                         <label>
                             <asp:RadioButton ID="RadioButton16" name="traffic-node" runat="server" Text="< 10%"></asp:RadioButton>
                         </label>
                         <label>
                             <asp:RadioButton ID="RadioButton17" name="traffic-node" runat="server" Text="10% - 79%"></asp:RadioButton>
                         </label>
                         <label>
                             <asp:RadioButton ID="RadioButton18" name="traffic-node" runat="server" Text="80% - 100%"></asp:RadioButton>
                        </label>
                      </div>
                        
                      <div class="col-md-2 col-sm-12 col-lg-2">
                         <label>Traffic Utilization on STG: </label>
                      </div>
                        
                      <div class="col-md-10 col-sm-12 col-lg-10">
                         <label>
                             <asp:RadioButton ID="RadioButton19" name="stg" runat="server" Text="N/A"></asp:RadioButton>
                         </label>
                         <label>
                             <asp:RadioButton ID="RadioButton20" name="stg" runat="server" Text="No"></asp:RadioButton>
                         </label>
                         <label>
                             <asp:RadioButton ID="RadioButton21" name="stg" runat="server" Text="No"></asp:RadioButton>
                         </label>
                      </div>
                        
                      <div class="col-md-2 col-sm-12 col-lg-2">
                         <label>Traffic Utilization on CTG: </label>
                      </div>
                        
                      <div class="col-md-10 col-sm-12 col-lg-10">
                         <label>
                             <asp:RadioButton ID="RadioButton22" name="ctg" runat="server" Text="N/A"></asp:RadioButton>
                         </label>
                         <label>
                             <asp:RadioButton ID="RadioButton23" name="ctg" runat="server" Text="No"></asp:RadioButton>
                         </label>
                         <label>
                             <asp:RadioButton ID="RadioButton24" name="ctg" runat="server" Text="Yes"></asp:RadioButton>
                         </label>
                      </div>
                        
                      <div class="col-md-2 col-sm-12 col-lg-2">
                         <label>Error Discards at Node Port: </label>
                      </div>
                        
                      <div class="col-md-10 col-sm-12 col-lg-10">
                         <label>
                             <asp:RadioButton ID="RadioButton25" name="error" runat="server" Text="No"></asp:RadioButton>
                         </label>
                         <label>
                             <asp:RadioButton ID="RadioButton26" name="error" runat="server" Text="No"></asp:RadioButton>
                         </label>
                      </div>
                        
                      <div class="col-md-2 col-sm-12 col-lg-2">
                         <label>Last Mile Deivce Port Status: </label>
                      </div>
                        
                      <div class="col-md-10 col-sm-12 col-lg-10">
                         <label>
                             <asp:RadioButton ID="RadioButton27" name="device-port-status" runat="server" Text="Off"></asp:RadioButton>
                         </label>
                         <label>
                             <asp:RadioButton ID="RadioButton28" name="device-port-status" runat="server" Text="On"></asp:RadioButton>
                         </label>
                      </div>
                        
                      <div class="col-md-2 col-sm-12 col-lg-2">
                         <label>CPE Status: </label>
                      </div>
                        
                      <div class="col-md-10 col-sm-12 col-lg-10">
                         <label>
                             <asp:RadioButton ID="RadioButton29" name="cpe-status" runat="server" Text="Latency"></asp:RadioButton>
                         </label>
                         <label>
                             <asp:RadioButton ID="RadioButton30" name="cpe-status" runat="server" Text="N/A"></asp:RadioButton>
                         </label>
                         <label>
                             <asp:RadioButton ID="RadioButton31" name="cpe-status" runat="server" Text="Responding"></asp:RadioButton>
                         </label>
                         <label>
                             <asp:RadioButton ID="RadioButton32" name="cpe-status" runat="server" Text="RTO"></asp:RadioButton>
                         </label>
                      </div>
                        
                      

                    </div>

                    </div>
                    </form>
                    
                </div><!-- PRIMARY INFO ENDS HERE -->
                  
                <!-- SECONDARY INFO -->
                <div id="ts-2" class="tab-pane fade">
                  
                   <form class="form-inline1 mt-2 mt-md-2 mb-md-3">
                    <div class="container-fluid">
                    
                    <div class="row mb-md-3 mb-sm-3 border-box">

                      <div class="col-md-2 col-sm-12 col-lg-2">
                         <label>Node Port Status: </label>
                      </div>
                        
                      <div class="col-md-10 col-sm-12 col-lg-10">
                         <label>
                             <asp:RadioButton ID="RadioButton33" name="node-status" runat="server" Text="Down"></asp:RadioButton>
                         </label>
                         <label>
                             <asp:RadioButton ID="RadioButton34" name="node-status" runat="server" Text="Up"></asp:RadioButton>

                         </label>
                      </div>
                        
                      <div class="col-md-2 col-sm-12 col-lg-2">
                         <label>Traffic Status at Node Port: </label>
                      </div>
                        
                      <div class="col-md-10 col-sm-12 col-lg-10">
                         <label>
                             <asp:RadioButton ID="RadioButton35" name="status-node-port" runat="server" Text="No Traffic"></asp:RadioButton>
                         </label>
                         <label>
                             <asp:RadioButton ID="RadioButton36" name="status-node-port" runat="server" Text="One Way Traffic"></asp:RadioButton>
                         </label>
                         <label>
                             <asp:RadioButton ID="RadioButton37" name="status-node-port" runat="server" Text="Two Way Traffic"></asp:RadioButton>
                         </label>
                      </div>

                      <div class="col-md-2 col-sm-12 col-lg-2">
                         <label>Traffic Utilization at Node Port: </label>
                      </div>
                        
                      <div class="col-md-10 col-sm-12 col-lg-10">
                         <label>
                             <asp:RadioButton ID="RadioButton38" name="traffic-node" runat="server" Text="< 10%"></asp:RadioButton>
                         </label>
                         <label>
                             <asp:RadioButton ID="RadioButton39" name="traffic-node" runat="server" Text="10% - 79%"></asp:RadioButton>
                         </label>
                         <label>
                             <asp:RadioButton ID="RadioButton40" name="traffic-node" runat="server" Text="80% - 100%"></asp:RadioButton>
                         </label>
                      </div>
                        
                      <div class="col-md-2 col-sm-12 col-lg-2">
                         <label>Traffic Utilization on STG: </label>
                      </div>
                        
                      <div class="col-md-10 col-sm-12 col-lg-10">
                         <label>
                             <asp:RadioButton ID="RadioButton41" name="stg" runat="server" Text="N/A"></asp:RadioButton>
                         </label>
                         <label>
                             <asp:RadioButton ID="RadioButton42" name="stg" runat="server" Text="No"></asp:RadioButton>
                         </label>
                         <label>
                             <asp:RadioButton ID="RadioButton43" name="stg" runat="server" Text="Yes"></asp:RadioButton>
                         </label>
                      </div>
                        
                      <div class="col-md-2 col-sm-12 col-lg-2">
                         <label>Traffic Utilization on CTG: </label>
                      </div>
                        
                      <div class="col-md-10 col-sm-12 col-lg-10">
                         <label>
                             <asp:RadioButton ID="RadioButton44" name="ctg" runat="server" Text="N/A"></asp:RadioButton>
                         </label>
                         <label>
                             <asp:RadioButton ID="RadioButton45" name="ctg" runat="server" Text="No"></asp:RadioButton>
                         </label>
                         <label>
                             <asp:RadioButton ID="RadioButton46" name="ctg" runat="server" Text="Yes"></asp:RadioButton>
                         </label>
                      </div>
                        
                      <div class="col-md-2 col-sm-12 col-lg-2">
                         <label>Error Discards at Node Port: </label>
                      </div>
                        
                      <div class="col-md-10 col-sm-12 col-lg-10">
                         <label>
                             <asp:RadioButton ID="RadioButton47" name="error" runat="server" Text="No"></asp:RadioButton>
                         </label>
                         <label>
                             <asp:RadioButton ID="RadioButton48" name="error" runat="server" Text="No"></asp:RadioButton>
                         </label>
                      </div>
                        
                      <div class="col-md-2 col-sm-12 col-lg-2">
                         <label>Last Mile Deivce Port Status: </label>
                      </div>
                        
                      <div class="col-md-10 col-sm-12 col-lg-10">
                         <label>
                             <asp:RadioButton ID="RadioButton49" name="device-port-status" runat="server" Text="Off"></asp:RadioButton>
                         </label>
                         <label>
                             <asp:RadioButton ID="RadioButton50" name="device-port-status" runat="server" Text="On"></asp:RadioButton>
                         </label>
                      </div>
                        
                      <div class="col-md-2 col-sm-12 col-lg-2">
                         <label>CPE Status: </label>
                      </div>
                        
                      <div class="col-md-10 col-sm-12 col-lg-10">
                         <label>
                             <asp:RadioButton ID="RadioButton51" name="cpe-status" runat="server" Text="Latency"></asp:RadioButton>
                         </label>
                         <label>
                             <asp:RadioButton ID="RadioButton52" name="cpe-status" runat="server" Text="N/A"></asp:RadioButton>
                         </label>
                         <label>
                             <asp:RadioButton ID="RadioButton53" name="cpe-status" runat="server" Text="Responding"></asp:RadioButton>
                         </label>
                         <label>
                             <asp:RadioButton ID="RadioButton54" name="cpe-status" runat="server" Text="RTO"></asp:RadioButton>
                         </label>
                      </div>

                    </div>
                        
                       </div>
                    </form>
                
                  </div><!-- SECONDARY INFO ENDS HERE -->
                  
                  <!-- SECONDARY INFO -->
                  <div id="ts-3" class="tab-pane fade">
                  
                   <form class="form-inline1 mt-2 mt-md-2 mb-md-3">
                    <div class="container-fluid">
                    
                    <div class="row mb-md-3 mb-sm-3 border-box">

                      <div class="col-md-2 col-sm-12 col-lg-2">
                         <label>Gateway Responses: </label>
                      </div>
                        
                      <div class="col-md-10 col-sm-12 col-lg-10">
                         <label>
                             <asp:RadioButton ID="RadioButton55" name="gateway-responses" runat="server" Text="High Response Time"></asp:RadioButton>
                         </label>
                         <label>
                             <asp:RadioButton ID="RadioButton56" name="gateway-responses" runat="server" Text="Proper Responses"></asp:RadioButton>
                         </label>
                      </div>
                        
                      <div class="col-md-2 col-sm-12 col-lg-2">
                         <label>Assigned DNS: </label>
                      </div>
                        
                      <div class="col-md-10 col-sm-12 col-lg-10">
                         <label>
                             <asp:RadioButton ID="RadioButton57" name="assigned-dns" runat="server" Text="Google"></asp:RadioButton>
                         </label>
                         <label>
                             <asp:RadioButton ID="RadioButton58" name="assigned-dns" runat="server" Text="MPPL KHI"></asp:RadioButton>
                         </label>
                         <label>
                             <asp:RadioButton ID="RadioButton59" name="assigned-dns" runat="server" Text="MPPL LHE"></asp:RadioButton>
                         </label>
                         <label>
                             <asp:RadioButton ID="RadioButton60" name="assigned-dns" runat="server" Text="Own"></asp:RadioButton>
                         </label>
                      </div>

                      <div class="col-md-2 col-sm-12 col-lg-2">
                         <label>DNS Responding: </label>
                      </div>
                        
                      <div class="col-md-10 col-sm-12 col-lg-10">
                         <label>
                             <asp:RadioButton ID="RadioButton61" name="dns-response" runat="server" Text="Heavy Drops"></asp:RadioButton>
                         </label>
                         <label>
                             <asp:RadioButton ID="RadioButton62" name="dns-response" runat="server" Text="No"></asp:RadioButton>
                         </label>
                         <label>
                             <asp:RadioButton ID="RadioButton63" name="dns-response" runat="server" Text="Yes"></asp:RadioButton>
                         </label>
                      </div>
                        
                      <div class="col-md-2 col-sm-12 col-lg-2">
                         <label>IP Blocked by PTA: </label>
                      </div>
                        
                      <div class="col-md-10 col-sm-12 col-lg-10">
                         <label>
                             <asp:RadioButton ID="RadioButton64" name="ip-blocked" runat="server" Text="No"></asp:RadioButton>
                         </label>
                         <label>
                             <asp:RadioButton ID="RadioButton65" name="ip-blocked" runat="server" Text="Yes"></asp:RadioButton>
                         </label>
                      </div>
                        
                      <div class="col-md-2 col-sm-12 col-lg-2">
                         <label>Remarks: </label>
                      </div>
                        
                      <div class="col-md-10 col-sm-12 col-lg-10"> 
                         <label>
                             
                             <asp:TextBox ID="TextBox58" class="form-control mr-sm-2" placeholder="ctg" runat="server"></asp:TextBox>
                          
                         </label>
                      </div>
           
                    </div>
                        
                       </div>
                    </form>
                
                  </div><!-- SECONDARY INFO ENDS HERE -->
                    
              </div>
                    
                    
                </div><!-- COMPLAIN FORM ENDS HERE -->
                
             </div><!-- TAB CONTENT FOR CUSTOMER INFO AND COMPLAIN FORM -->
                
               
            </div><!-- CUSTOMER CLASS ENDS HERE -->
            </form>
          </main>
          </div>
       </div>



</asp:Content>
