<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="cntComplainHistory.ascx.cs" Inherits="RainMaker.UserControls.cntComplainHistory" %>
        <%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
          <div class="customer">

                   <form class="form-inline1 mt-2 mt-md-2 mb-md-3">
                      <div class="container-fluid">
                      <%--<div class="row mb-md-3 mb-sm-3 border-box">--%>

                         <div class="col-md-12 col-sm-12 col-lg-12 col-xs-12">

                             <div class="customer-table">
                               <form class="form-inline1 mt-2 mt-md-2 mb-md-3">


                                  <table class="table table-responsive table-bordered mb-md-0">
                                      <tbody>
                                         <tr>
                                            <td class="webcontrols-details">Circuit Name</td>
                                            <td><label ID="lblName" runat="server">Circuit Name:</label></td>
                                         </tr>
                                         <tr>
                                            <td class="webcontrols-details">Address</td>
                                            <td><label ID="lblAddress" runat="server">
                                                   Address:</label>
                                                   </td>
                                         </tr>
                                         <tr>
                                            <td class="webcontrols-details">Sales Person</td>
                                            <td><label ID="lblSalesPerson" runat="server">
                                                  Sales Person:</label></td>
                                         </tr>
                                         
                                      </tbody>
                                 </table>

                              </form>
                         </div>

                     </div>

                 <%--</div>--%>

            </div>
           </form>
                      
                     
                <div class="container-fluid">
                    <div class="customer-table">
                        <form class="form-inline1 mt-2 mt-md-2 mb-md-3">
                        <div class="table-responsive">
                             <telerik:RadGrid ID="GvCustomerOldCompTran" runat="server"  AllowSorting="True"
                            GridLines="None" Skin="Office2007" 
                                 onitemcommand="GvCustomerOldCompTran_ItemCommand">
                            <ClientSettings>
                                <Selecting AllowRowSelect="True" />
                                <Scrolling AllowScroll="True" UseStaticHeaders="True" />
                            </ClientSettings>
                            <MasterTableView  >
                                <CommandItemSettings ShowExportToExcelButton="true" ExportToPdfText="Export to Pdf" />
                                <Columns>
                               <telerik:GridButtonColumn CommandName="View Complain" 
                                        HeaderText="View Complain" Text="View" UniqueName="colView">
                                    </telerik:GridButtonColumn>
                                    </Columns>
                            </MasterTableView>
                            <PagerStyle Mode="NextPrev" />
                            <HeaderContextMenu CssClass="GridContextMenu GridContextMenu_Default" EnableImageSprites="True">
                            </HeaderContextMenu>
                        </telerik:RadGrid>
                        </div>
                        </form>
                    </div>
                </div>
        </div>