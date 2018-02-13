<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="cntviewcomphist.ascx.cs" Inherits="RainMaker.UserControls.cntviewcomphist" %>

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
                                            <td class="webcontrols-details">Customer Name</td>
                                            <td><label ID="lbl_CusName" runat="server">Customer Name:</label></td>
                                         </tr>
                                         <tr>
                                            <td class="webcontrols-details">Ticket Number</td>
                                            <td><label ID="lbl_TicNum" runat="server">
                                                   Ticket Number:</label>
                                                   </td>
                                         </tr>
                                         <tr>
                                            <td class="webcontrols-details">Complain Recieved Time</td>
                                            <td><label ID="lbl_ComRec" runat="server">
                                                  Complain Recieved Time:</label></td>
                                         </tr>
                                         <tr>
                                            <td class="webcontrols-details" class="webcontrols-details">Last Updated Time</td>
                                            <td><label ID="lbl_LUT" runat="server">
                                                  Last Updated Time:</label></td>
                                         </tr>
                                         <tr>
                                            <td class="webcontrols-details" class="webcontrols-details">Complain Status</td>
                                            <td> <label ID="lbl_CS" runat="server">
                                                    Complain Status:</label></td>
                                         </tr>
                                         <tr>
                                            <td class="webcontrols-details" class="webcontrols-details">Assigned Department</td>
                                            <td><label ID="lbl_AD" runat="server">
                                                     Assigned Department:</label></td>
                                         </tr>
                                         <tr>
                                            <td class="webcontrols-details" class="webcontrols-details">Caller Name/Number</td>
                                            <td><label ID="lbl_CN" runat="server">
                                                       Caller Name/Number:</label></td>
                                         </tr>
                                         <tr>
                                            <td class="webcontrols-details" class="webcontrols-details">Last Remarks</td>
                                            <td>
                                                <p>
                                                    <label ID="lbl_LR" runat="server">Last Remarks:</label>
                                                </p>
                                            </td>
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
                             <telerik:RadGrid ID="gvComplainCircuits" runat="server"  AllowSorting="True"
                            GridLines="None" Skin="Office2007">
                            <ClientSettings>
                                <Selecting AllowRowSelect="True" />
                                <Scrolling AllowScroll="True" UseStaticHeaders="True" />
                            </ClientSettings>
                            <MasterTableView  >
                                <CommandItemSettings ShowExportToExcelButton="true" ExportToPdfText="Export to Pdf" />
                                
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

                