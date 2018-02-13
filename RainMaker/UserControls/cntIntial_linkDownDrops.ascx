<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="cntIntial_linkDownDrops.ascx.cs" Inherits="RainMaker.UserControls.cntIntial_linkDownDrops" %>

 <%-- <div class="container-fluid">
        <div class="row">
         <main class="col-lg-offset-1 col-md-offset-1 col-sm-offset-1 col-xs-offset-1 col-sm-11 col-md-11 ml-sm-auto col-md-11 pt-3 customer content-area" role="main">

            <div class="customer content-area">
                
            <!-- COMPLAIN FORM -->  
            <div id="complain-form" class="tab-pane">--%>
              
              <!-- MENUS FOR PRIMARY INFO AND SECONDARY INFO -->
              <ul class="nav nav-tabs">
                <li class="active">
                    <a data-toggle="tab" href="#ts-1">Troubleshooting Page 1</a>
                </li>
                <li>
                    <a data-toggle="tab" href="#ts-2">Troubleshooting Page 2</a>
                </li>
                <%--<li>
                    <a data-toggle="tab" href="#ts-3">Troubleshooting Page 3</a>
                </li>--%>
              </ul>

              <!-- TAB CONTENT FOR PRIMARY INFO AND SECONDARY INFO -->
              <div class="tab-content">
                
                <!-- PRIMARY INFO -->
                <div id="ts-1" class="tab-pane fade in active">
                  
     <asp:UpdatePanel runat="server">
         <ContentTemplate>
                    
                    <div class="container-fluid">

                    <div class="row mb-md-3 mb-sm-3 border-box">

                    <div class="container-fluid">
                        <div class="row">
                          <div class="col-md-2 col-sm-12 col-lg-2 radio-button-div">
                             <label>Node Port Status: </label>
                          </div>    
                        
                          <div class="col-md-10 col-sm-12 col-lg-10 radio-button-div">
                             <asp:Panel ID="pnlTS11_1NodePortStatus" runat="server" Width="500px">
                                                                </asp:Panel>
                          </div>
                        </div>
                    </div>

                    <div class="container-fluid">
                        <div class="row">
                        
                          <div class="col-md-2 col-sm-12 col-lg-2 radio-button-div">
                             <label>Traffic Status at Node Port: </label>
                          </div>
                        
                          <div class="col-md-10 col-sm-12 col-lg-10 radio-button-div">
                             <asp:Panel ID="pnlTS11_2TrafficStatusatNodePort" runat="server" Width="500px">
                                                                </asp:Panel>
                          </div>
                        </div>
                    </div>

                    <div class="container-fluid">
                        <div class="row">
                          <div class="col-md-2 col-sm-12 col-lg-2 radio-button-div">
                             <label>Traffic Utilization at Node Port: </label>
                          </div>
                        
                          <div class="col-md-10 col-sm-12 col-lg-10 radio-button-div">
                             <asp:Panel ID="pnlTS11_3TrafficUtilizationatNodePort" runat="server" Width="500px">
                                                                </asp:Panel>
                          </div>
                        </div>
                    </div>

                    <div class="container-fluid">
                        <div class="row">
                        
                          <div class="col-md-2 col-sm-12 col-lg-2 radio-button-div">
                             <label>Traffic Utilization on STG: </label>
                          </div>
                        
                          <div class="col-md-10 col-sm-12 col-lg-10 radio-button-div">
                             <asp:Panel ID="pnlTS11_4TrafficUtilizationonSTG" runat="server" Width="500px">
                                                                </asp:Panel>
                          </div>
                        </div>
                    </div>
                        
                    <div class="container-fluid">
                        <div class="row">
                          <div class="col-md-2 col-sm-12 col-lg-2 radio-button-div">
                             <label>Traffic Utilization on CTG: </label>
                          </div>
                        
                          <div class="col-md-10 col-sm-12 col-lg-10 radio-button-div">
                             <asp:Panel ID="pnlTS11_5TrafficUtilizationonCTG" runat="server" Width="500px">
                                                                </asp:Panel>
                          </div>
                        </div>
                    </div>
                        
                    <div class="container-fluid">
                        <div class="row">
                          <div class="col-md-2 col-sm-12 col-lg-2 radio-button-div">
                             <label>Error Discards at Node Port: </label>
                          </div>
                        
                          <div class="col-md-10 col-sm-12 col-lg-10 radio-button-div">
                             <asp:Panel ID="pnlTS11_6ErrorDiscardsatNodePort" runat="server" Width="500px">
                                                                </asp:Panel>
                          </div>
                        </div>
                    </div>

                    <div class="container-fluid">
                        <div class="row">
                        
                          <div class="col-md-2 col-sm-12 col-lg-2 radio-button-div">
                             <label>Last Mile Deivce Power Status: </label>
                          </div>
                        
                          <div class="col-md-10 col-sm-12 col-lg-10 radio-button-div">
                             <asp:Panel ID="pnlTS11_7LastMileDevicePowerStatus" runat="server" Width="500px">
                                                                </asp:Panel>
                          </div>
                        </div>
                    </div>
                        
                    <div class="container-fluid">
                        <div class="row">
                          <div class="col-md-2 col-sm-12 col-lg-2 radio-button-div">
                             <label>CPE Status: </label>
                          </div>
                        
                          <div class="col-md-10 col-sm-12 col-lg-10 radio-button-div">
                             <asp:Panel ID="pnlTS11_8CPEStatus" runat="server" Width="500px">
                                                                </asp:Panel>
                          </div>
                        </div>
                    </div>

                    <div class="container-fluid">
                        <div class="row">
                        
                          <div class="col-md-2 col-sm-12 col-lg-2 radio-button-div">
                             <label>CPE Interface Status: </label>
                          </div>
                        
                          <div class="col-md-10 col-sm-12 col-lg-10 radio-button-div">
                             <asp:Panel ID="pnlTS11_9CEInterfaceStatus" runat="server" Width="500px">
                                                                </asp:Panel>
                          </div>
                        </div>
                    </div>
                        
                    </div>

                    </div>
                    
                    
         </ContentTemplate>
     </asp:UpdatePanel>
                </div><!-- PRIMARY INFO ENDS HERE -->
                  
                  <!-- SECONDARY INFO -->
                  <div id="ts-2" class="tab-pane fade">
                  
         <asp:UpdatePanel runat="server">
             <ContentTemplate>
                   
                    <div class="container-fluid">
                    
                    <div class="row mb-md-3 mb-sm-3 border-box">

                    <div class="container-fluid">
                        <div class="row">
                          <div class="col-md-2 col-sm-12 col-lg-2 radio-button-div">
                             <label>Fiber LED Status: </label>
                          </div>
                          <div class="col-md-10 col-sm-12 col-lg-10 radio-button-div">
                             <asp:Panel ID="pnlTS12_1FiberLEDStatus" runat="server" Width="500px">
                             </asp:Panel>
                          </div>
                        </div>
                    </div>
                        
                    <div class="container-fluid">
                        <div class="row">
                          <div class="col-md-2 col-sm-12 col-lg-2 radio-button-div">
                             <label>Traffic Status at CE Interface: </label>
                          </div>
                        
                          <div class="col-md-10 col-sm-12 col-lg-10 radio-button-div">
                             <asp:Panel ID="pnlTS12_2TrafficStatusatCEInterface" runat="server" Width="200px">
                                                                </asp:Panel>
                          </div>
                        </div>
                    </div>

                    <div class="container-fluid">
                        <div class="row">

                          <div class="col-md-2 col-sm-12 col-lg-2 radio-button-div">
                             <label>Bandwidth Utilization: </label>
                          </div>
                        
                          <div class="col-md-10 col-sm-12 col-lg-10 radio-button-div">
                            <asp:Panel ID="pnlTS12_3BandwidthUtilization" runat="server" Width="200px">
                                                                </asp:Panel>
                          </div>
                        </div>
                    </div>

                    <div class="container-fluid">
                        <div class="row">
                        
                          <div class="col-md-2 col-sm-12 col-lg-2 radio-button-div">
                             <label>Device Rebooted: </label>
                          </div>
                        
                          <div class="col-md-10 col-sm-12 col-lg-10 radio-button-div">
                             <asp:Panel ID="pnlTS12_4DeviceRebooted" runat="server" Width="200px">
                                                                </asp:Panel>
                          </div>
                        </div>
                    </div>
                        
                    <div class="container-fluid">
                        <div class="row">
                          <div class="col-md-2 col-sm-12 col-lg-2 radio-button-div">
                             <label>Remarks: </label>
                          </div>
                        
                          <div class="col-md-10 col-sm-12 col-lg-10 radio-button-div">
                             <label>
                                 <asp:TextBox ID="tbTS12_5Remarks" class="form-control mr-sm-2" placeholder="remarks" runat="server"></asp:TextBox>
                              </label>
                          </div>
                        </div>
                    </div>
           
                    </div>
                        
                       </div>
                   
                
             </ContentTemplate>
         </asp:UpdatePanel>
                  </div><!-- SECONDARY INFO ENDS HERE -->
                    
              </div>
                    
                    
               <%-- </div><!-- COMPLAIN FORM ENDS HERE -->
                
              </div><!-- TAB CONTENT FOR CUSTOMER INFO AND COMPLAIN FORM -->
                     
          </main>
          </div>
       </div>--%>