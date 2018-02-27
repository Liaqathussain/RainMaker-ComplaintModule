<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="cntemailIsuee.ascx.cs" Inherits="RainMaker.UserControls.cntemailIsuee" %>

<%--   <div class="container-fluid">
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
                         <label>Issue In: </label>
                      </div>
                        
                      <div class="col-md-10 col-sm-12 col-lg-10 radio-button-div">
                         <asp:Panel ID="pnlTS31_1Issuein"  runat="server">
                                                    </asp:Panel>
                      </div>
                        
                      <div class="col-md-2 col-sm-12 col-lg-2 radio-button-div">
                         <label>Domain: </label>
                      </div>
                        
                      <div class="col-md-10 col-sm-12 col-lg-10 radio-button-div">
                          <asp:Panel ID="pnlTS31_2Domain" runat="server">
                                                    </asp:Panel>                    
                      </div>
                                            
                         <div class="col-md-2 col-sm-12 col-lg-2 radio-button-div">
                         <label>MPPL SMTP/POP Response: </label>
                      </div>
                        
                      <div class="col-md-10 col-sm-12 col-lg-10 radio-button-div">
                         <asp:Panel ID="pnlTS31_3MPPLResponse" runat="server">
                                                    </asp:Panel>
                      </div>
                        
                      <div class="col-md-2 col-sm-12 col-lg-2 radio-button-div">
                         <label>MPPL SMTP/POP Telnet: </label>
                      </div>
                        
                      <div class="col-md-10 col-sm-12 col-lg-10 radio-button-div">
                         <asp:Panel ID="pnlTS31_4MPPLTelnet" runat="server">
                                                    </asp:Panel>
                      </div>
                        
                      <div class="col-md-2 col-sm-12 col-lg-2 radio-button-div">
                         <label>Issue On: </label>
                      </div>
                        
                      <div class="col-md-10 col-sm-12 col-lg-10 radio-button-div">
                         <asp:Panel ID="pnlTS31_5IssueOn" runat="server">
                                                    </asp:Panel>
                      </div>
                        
                      
                        
                      <div class="col-md-2 col-sm-12 col-lg-2 radio-button-div">
                         <label>Domain on which facing problem: </label>
                      </div>
                        
                      <div class="col-md-10 col-sm-12 col-lg-10 radio-button-div">
                         
                         <asp:Panel ID="pnlTS31_6DomainOnWhichfacingProblem" runat="server">
                          <asp:TextBox ID="tbEmail_DomainFacingProblem" runat="server">
                                                        </asp:TextBox>
                         </asp:Panel>
                            
                      </div>
                        
                      <div class="col-md-2 col-sm-12 col-lg-2 radio-button-div">
                         <label>IP Blacklisted on international servers: </label>
                      </div>
                        
                      <div class="col-md-10 col-sm-12 col-lg-10 radio-button-div">
                         <asp:Panel ID="pnlTS31_7IPBlacklisted" runat="server">
                                                    </asp:Panel>
                      </div>
                        
                      <div class="col-md-2 col-sm-12 col-lg-2 radio-button-div">
                         <label>Remarks: </label>
                      </div>
                        
                      <div class="col-md-10 col-sm-12 col-lg-10 radio-button-div">
                         <label>
                             <asp:TextBox ID="tbTS31_8Remarks" class="form-control mr-sm-2" placeholder="Remarks" runat="server"></asp:TextBox>
                         </label>
                      </div>
                        
                    </div>

                    </div>
                    </ContentTemplate>
    </asp:UpdatePanel>
                    
                </div><!-- PRIMARY INFO ENDS HERE -->
                    
              </div>
                    
                    
              <%--  </div><!-- COMPLAIN FORM ENDS HERE -->
                
              </div><!-- TAB CONTENT FOR CUSTOMER INFO AND COMPLAIN FORM -->
                     
          </main>
          </div>
       </div>--%>
