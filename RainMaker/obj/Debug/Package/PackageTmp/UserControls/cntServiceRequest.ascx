<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="cntServiceRequest.ascx.cs" Inherits="RainMaker.UserControls.cntServiceRequest" %>


<%--<div class="container-fluid">
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
                  
                    <form class="form-inline1 mt-2 mt-md-2 mb-md-3">
                    <div class="container-fluid">

                    
                        
                      <div class="col-md-10 col-sm-12 col-lg-10 ">
                         <asp:TextBox ID="tbTS51_1CustomerRequest" runat="server">
                        </asp:TextBox>
                            <span class="floating-label">Customer Request/Query</span>
                      </div>
                        
                     
                        
                      <div class="col-md-10 col-sm-12 col-lg-10 radio-button-div">
                         <asp:TextBox ID="tbTS51_2Remarks" runat="server">
                         </asp:TextBox>
                            <span class="floating-label">Remarks</span>
                      </div>

                    </div>
                    </form>
                    </div>
                    </div>
                   <%-- </div>
                    </div>
                    </main>
                    </div>
                    </div>--%>