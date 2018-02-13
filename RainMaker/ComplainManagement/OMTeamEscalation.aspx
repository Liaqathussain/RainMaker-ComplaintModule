<%@ Page Title="" Language="C#" MasterPageFile="~/MainForms_Site.Master" AutoEventWireup="true" CodeBehind="OMTeamEscalation.aspx.cs" Inherits="RainMaker.ComplainManagement.OMTeamEscalation" %>


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
    <asp:UpdatePanel ID="UPPanel2" runat="server">
                 <ContentTemplate> 
            <div class="customer">
               <form  class="form-inline1 mt-2 mt-md-2 mb-md-3">
                  <div class="container-fluid">
                  <div class="row mb-md-3 mb-sm-3 border-box">
             
                     <div class="col-md-12 col-sm-12 col-lg-12">
                         <h4>O&amp;M Team Escalation</h4>
                     </div>
                      
                     <div class="col-md-3 col-sm-12 col-lg-3">
                         
                         <asp:TextBox ID="txtSignUpID" class="form-control mr-sm-2" placeholder="AnySign Up ID" runat="server"></asp:TextBox>
                         
                     </div>
                      
                     <div class="col-md-3 col-sm-12 col-lg-3">
                         
                         <p>
                            <asp:DropDownList ID="cmbCity" class="form-control" runat="server">
                                <asp:ListItem Selected="True">Please Select City</asp:ListItem>
                            </asp:DropDownList>
                         </p>
                         
                     </div>
                      
                     <div class="col-md-3 col-sm-12 col-lg-3">
                         
                         <p>
                            <asp:DropDownList ID="cmbCustomerCode" class="form-control" runat="server">
                                <asp:ListItem Selected="True">Please Select Customer Code</asp:ListItem>
                            </asp:DropDownList>
                         </p>
                         
                     </div>
                    
                     <div class="col-md-3 col-sm-12 col-lg-3">
                         
                         <p>
                            <asp:DropDownList ID="cmbNode" class="form-control" runat="server">
                                <asp:ListItem Selected="True">Please Select Node</asp:ListItem>
                            </asp:DropDownList>
                         </p>
                         
                     </div>
                      
                 </div>
                      
                </div>
               </form>
            </div>
             
            <div class="customer-buttons">
            
                <div class="row">
                    <div class="col-sm-12 col-md-12 col-lg-12 col-xs-12">
                        <div class="text-right">
                         
                            <asp:Button ID="btnUpdate" class="btn btn-primary" runat="server" onclick="btnUpdate_Click" Text="Update" AutoPostBack="true"></asp:Button>
                            <asp:Button ID="btnSearch" class="btn btn-primary" runat="server" onclick="btnSearch_Click" Text="Search"></asp:Button>
                            
                        </div>
                    </div>

                    

                    <div class="col-md-6 text-right">
                       <label>
                            <asp:Label ID="lblStatus" runat="server" Text=""></asp:Label>
                      </label>
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
                  <!-- Use any of these as your table/grid/radgrid depending on your need -->
                                     
                 <asp:GridView class="table-responsive table table-striped mb-md-0" BorderWidth="3px" ID="GVTeam" runat="server"
                  AutoGenerateColumns="false" ShowFooter="true" Width="100%" OnSelectedIndexChanged="GVTeam_SelectedIndexChanged">
                 <Columns>
                              
                               <asp:TemplateField>
                                    <ItemTemplate>
                                    <asp:CheckBox ID="chkRow" Text="" AutoPostBack="false" Width="80px" runat="server" />
                                </ItemTemplate>

                                 </asp:TemplateField>
                                <asp:BoundField DataField="ComplaintID" HeaderText ="Complaint ID" />
                                <asp:BoundField DataField="TicketNo" HeaderText="Ticket No" />
                                <asp:BoundField DataField="CircuitName" HeaderText="Circuit Name" />
                                <asp:BoundField DataField="Node" HeaderText="Node" />
                                <asp:BoundField DataField="City" HeaderText="City" />

                          

                                <asp:TemplateField HeaderText="Team">
                                    <ItemTemplate>
                                        <asp:DropDownList ID="DropDownList1"  AppendDataBoundItems="true" runat="server" >
                                            <asp:ListItem Value="-1">Select</asp:ListItem>
                                        </asp:DropDownList>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Priority">
                                    <ItemTemplate>
                                        <asp:DropDownList ID="DropDownList2" runat="server" >
                                            <asp:ListItem Value="-1">Select</asp:ListItem>
                                        </asp:DropDownList>
                                    </ItemTemplate>
                                    <FooterStyle HorizontalAlign="Right" />
                                    
                                </asp:TemplateField>
                               
                            </Columns>
                 
                 
                 </asp:GridView>

                <%-- <telerik:RadGrid ID="radGrid1" class="table-responsive table table-striped mb-md-0" BorderWidth="3px" runat="server" AutoGenerateColumns="true"  Width="100%"  runat=server>
                 </telerik:RadGrid>--%>
                 
              
              
            </div>
            </ContentTemplate>
                  </asp:UpdatePanel>
             </form>
          </main>
          </div>
       </div>
    
</asp:Content>
