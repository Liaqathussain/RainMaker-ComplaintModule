<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="cntViewCustomerInfromation.ascx.cs" Inherits="RainMaker.UserControls.cntViewCustomerInfromation" %>


<           <div class="customer">
                   
                   <div class="container-fluid">
                        <div class="row">
                         <div class="col-md-12 col-sm-12 col-lg-12">
                             <asp:Label ID="lblCircuitName" runat="server"></asp:Label>
                         </div>  
                        </div>
                     </div>
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