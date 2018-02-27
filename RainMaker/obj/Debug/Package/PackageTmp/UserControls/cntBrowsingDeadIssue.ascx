<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="cntBrowsingDeadIssue.ascx.cs" Inherits="RainMaker.UserControls.cntBrowsingDeadIssue" %>
<%--<div class="container-fluid">
        <div class="row">
         <main class="col-lg-offset-1 col-md-offset-1 col-sm-offset-1 col-xs-offset-1 col-sm-11 col-md-11 ml-sm-auto col-md-11 pt-3 customer content-area" role="main">

            <div class="customer content-area">
                
             
            <!-- COMPLAIN FORM -->  
            <div id="complain-form" class="tab-pane">--%>

              <!-- TAB CONTENT FOR PRIMARY INFO AND SECONDARY INFO -->
              <div class="tab-content">
                
                <!-- PRIMARY INFO -->
                <div id="ts-1" class="tab-pane fade in active">
                  
                  
    <asp:UpdatePanel runat="server">
        <ContentTemplate>
                    
     <div class="container-fluid">


                    <div class="col-md-2 col-sm-12 col-lg-2">
                         <label>Node Port Status: </label>
                      </div>
                        
                      <div class="col-md-10 col-sm-12 col-lg-10 radio-button-div">
                         <asp:Panel ID="pnlTS21_1NodePortStatus" runat="server">
                                                            </asp:Panel>
                      </div>
                        
                      <div class="col-md-2 col-sm-12 col-lg-2">
                         <label>Traffic Status at Node Port: </label>
                      </div>
                        
                      <div class="col-md-10 col-sm-12 col-lg-10 radio-button-div">
                         <asp:Panel ID="pnlTS21_2TrafficStatusatNodePort" runat="server">
                                                            </asp:Panel>
                      </div>

                      <div class="col-md-2 col-sm-12 col-lg-2">
                         <label>Traffic Utilization at Node Port: </label>
                      </div>
                        
                      <div class="col-md-10 col-sm-12 col-lg-10 radio-button-div">
                         <asp:Panel ID="pnlTS21_3TrafficUtilizationatNodePort" runat="server">
                                                            </asp:Panel>
                      </div>
                        
                      <div class="col-md-2 col-sm-12 col-lg-2">
                         <label>Traffic Utilization on STG: </label>
                      </div>
                        
                      <div class="col-md-10 col-sm-12 col-lg-10 radio-button-div">
                         <asp:Panel ID="pnlTS21_4TrafficUtilizationatSTG" runat="server">
                                                            </asp:Panel>
                      </div>
                        
                      <div class="col-md-2 col-sm-12 col-lg-2">
                         <label>Traffic Utilization on CTG: </label>
                      </div>
                        
                      <div class="col-md-10 col-sm-12 col-lg-10 radio-button-div">
                         <asp:Panel ID="pnlTS21_5TrafficUtilizationatCTG" runat="server">
                                                            </asp:Panel>
                      </div>
                        
                      <div class="col-md-2 col-sm-12 col-lg-2">
                         <label>Error Discards at Node Port: </label>
                      </div>
                        
                      <div class="col-md-10 col-sm-12 col-lg-10 radio-button-div">
                         <asp:Panel ID="pnlTS21_6ErrorDiscards" runat="server">
                                                            </asp:Panel>
                      </div>
                        
                      <div class="col-md-2 col-sm-12 col-lg-2">
                         <label>Last Mile Deivce Port Status: </label>
                      </div>
                        
                      <div class="col-md-10 col-sm-12 col-lg-10 radio-button-div">
                          <asp:Panel ID="pnlTS21_7LastMileDevicePowerStatus" runat="server">
                                                            </asp:Panel>
                      </div>
                        
                      <div class="col-md-2 col-sm-12 col-lg-2">
                         <label>CPE Status: </label>
                      </div>
                        
                      <div class="col-md-10 col-sm-12 col-lg-10 radio-button-div">
                         <asp:Panel ID="pnlTS21_8CPEStatus" runat="server">
                                                            </asp:Panel>
                      </div>


                    <div class="row mb-md-3 mb-sm-3 border-box">
                    </div>
                    </div>
                    
        </ContentTemplate>
    </asp:UpdatePanel>
                    </div>

                    <div id="ts-2" class="tab-pane fade">
                  
        <asp:UpdatePanel runat="server">
            <ContentTemplate>
            
                   
                    <div class="container-fluid">
                    
                    <div class="row mb-md-3 mb-sm-3 border-box">

                      <div class="col-md-2 col-sm-12 col-lg-2">
                         <label>Fiber LED Status </label>
                      </div>
                        
                      <div class="col-md-10 col-sm-12 col-lg-10 radio-button-div">
                         <asp:Panel ID="pnlTS22_1FiberLEDStatus" runat="server">
                                                            </asp:Panel>
                      </div>
                        
                      <div class="col-md-2 col-sm-12 col-lg-2">
                         <label>Traffic Status at CE Interface </label>
                      </div>
                        
                      <div class="col-md-10 col-sm-12 col-lg-10 radio-button-div">
                         <asp:Panel ID="pnlTS22_2TrafficStatusatCEInterface" runat="server">
                                                            </asp:Panel>
                      </div>

                      <div class="col-md-2 col-sm-12 col-lg-2">
                         <label> CE Interface Status </label>
                      </div>
                        
                      <div class="col-md-10 col-sm-12 col-lg-10 radio-button-div">
                         <asp:Panel ID="pnlTS22_3CEInterfaceStatus" runat="server">
                                                            </asp:Panel>
                      </div>
                        
                      <div class="col-md-2 col-sm-12 col-lg-2">
                         <label> Bandwidth Utilization </label>
                      </div>
                        
                      <div class="col-md-10 col-sm-12 col-lg-10 radio-button-div">
                         <asp:Panel ID="pnlTS22_4BandwidthUtilization" runat="server">
                                                            </asp:Panel>
                      </div>
                        
                      <div class="col-md-2 col-sm-12 col-lg-2">
                         <label>Device Rebooted </label>
                      </div>
                        
                      <div class="col-md-10 col-sm-12 col-lg-10 radio-button-div">
                         <asp:Panel ID="pnlTS22_5DeviceRebooted" runat="server">
                                                            </asp:Panel>
                      </div>
                        
                      <div class="col-md-2 col-sm-12 col-lg-2">
                         <label> Customer IP Response </label>
                      </div>
                        
                      <div class="col-md-10 col-sm-12 col-lg-10 radio-button-div">
                         <asp:Panel ID="pnlTS22_6CustomerIPResponse" runat="server">
                                                            </asp:Panel>
                      </div>
                        
                      <div class="col-md-2 col-sm-12 col-lg-2">
                         <label>Customer Bandwidth Issue </label>
                      </div>
                        
                      <div class="col-md-10 col-sm-12 col-lg-10 radio-button-div">
                         <asp:Panel ID="pnlTS22_7CustomerBandwidthIssue" runat="server">
                                    <asp:DropDownList ID="cmbTS22_7CustomerBandwidthIssue" runat="server">
                                     </asp:DropDownList>
                         </asp:Panel>
                      </div>
                        
                      

                    </div>
                        
                       </div>
                   </ContentTemplate>
        </asp:UpdatePanel>
                
                  </div>


                  <div id="ts-3" class="tab-pane fade">
                  
            <asp:UpdatePanel runat="server">
                <ContentTemplate>
                
                    <div class="container-fluid">
                    
                    <div class="row mb-md-3 mb-sm-3 border-box">

                      <div class="col-md-2 col-sm-12 col-lg-2">
                         <label>Gateway Responses: </label>
                      </div>
                        
                      <div class="col-md-10 col-sm-12 col-lg-10 radio-button-div">
                         <asp:Panel ID="pnlTS23_1GatewayResponses" runat="server">
                                                            </asp:Panel>
                      </div>
                        
                      <div class="col-md-2 col-sm-12 col-lg-2">
                         <label>Assigned DNS: </label>
                      </div>
                        
                      <div class="col-md-10 col-sm-12 col-lg-10 radio-button-div">
                         <asp:Panel ID="pnlTS23_2AssignedDNS" runat="server">
                                                            </asp:Panel>
                      </div>

                      <div class="col-md-2 col-sm-12 col-lg-2">
                         <label>DNS Responding: </label>
                      </div>
                        
                      <div class="col-md-10 col-sm-12 col-lg-10 radio-button-div">
                         <asp:Panel ID="pnlTS23_3DNSResponding" runat="server">
                                                            </asp:Panel>
                      </div>
                        
                      <div class="col-md-2 col-sm-12 col-lg-2">
                         <label>IP Blocked by PTA: </label>
                      </div>
                        
                      <div class="col-md-10 col-sm-12 col-lg-10 radio-button-div">
                         <asp:Panel ID="pnlTS23_4IPBlockedbyPTA" runat="server">
                                                            </asp:Panel>
                      </div>
                        
                      <div class="col-md-2 col-sm-12 col-lg-2">
                         <label>Remarks: </label>
                      </div>
                        
                      <div class="col-md-10 col-sm-12 col-lg-10"> 
                         <label>
                             
                             <asp:TextBox ID="tbTS23_5Remarks" class="form-control mr-sm-2 inputText" runat="server"></asp:TextBox>
                          
                         </label>
                      </div>
           
                    </div>
                        
                       </div>
                    </ContentTemplate>
            </asp:UpdatePanel>
                
                  </div>

                    </div>
                  <%--  </div>
                    </div>
                    </main>
                    </div>
                    </div>--%>