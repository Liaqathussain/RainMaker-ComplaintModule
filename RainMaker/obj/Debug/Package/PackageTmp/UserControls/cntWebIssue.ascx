<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="cntWebIssue.ascx.cs" Inherits="RainMaker.UserControls.cntWebIssue" %>

<%--
<div class="container-fluid">
        <div class="row">
         <main class="col-lg-offset-1 col-md-offset-1 col-sm-offset-1 col-xs-offset-1 col-sm-11 col-md-11 ml-sm-auto col-md-11 pt-3 customer content-area" role="main">

            <div class="customer content-area">
                
             
            <!-- COMPLAIN FORM -->  
            <div id="complain-form" class="tab-pane">
--%>
              <!-- TAB CONTENT FOR PRIMARY INFO AND SECONDARY INFO -->
              <div class="tab-content">
                
                <!-- PRIMARY INFO -->
                <div id="ts-1" class="tab-pane fade in active">
                  
                    
    <asp:UpdatePanel runat="server">
        <ContentTemplate>
        
                    <div class="container-fluid">

                    <div class="row mb-md-3 mb-sm-3 border-box">

                      <div class="col-md-2 col-sm-12 col-lg-2 radio-button-div">
                         <label>Assigned DNS </label>
                      </div>
                        
                      <div class="col-md-10 col-sm-12 col-lg-10 radio-button-div">
                         <asp:Panel ID="pnlTS41_1AssignedDNS" runat="server">
                                                    </asp:Panel>
                      </div>
                        
                      <div class="col-md-2 col-sm-12 col-lg-2 radio-button-div">
                         <label> Website in opening at our end </label>
                      </div>
                        
                      <div class="col-md-10 col-sm-12 col-lg-10 radio-button-div">
                          <asp:Panel ID="pnlTS41_2Website" runat="server">
                                                    </asp:Panel>                    
                      </div>
                                            
                         <div class="col-md-2 col-sm-12 col-lg-2 radio-button-div">
                         <label>DNS Responding </label>
                      </div>
                        
                      <div class="col-md-10 col-sm-12 col-lg-10 radio-button-div">
                         <asp:Panel ID="pnlTS41_3DNSResponding" runat="server">
                                                    </asp:Panel>
                      </div>
                        
                     
                        
                      <div class="col-md-10 col-sm-12 col-lg-10">
                         <asp:TextBox ID="tbTS41_4Remarks" runat="server">
                           </asp:TextBox>
                           <span class="floating-label">Remarks</span>
                      </div>

                    </div>
                    </div>
                    </ContentTemplate>
    </asp:UpdatePanel>
                    </div>
                    </div>
                    <%--</div>
                    </div>
                    </main>
                    </div>
                    </div>--%>