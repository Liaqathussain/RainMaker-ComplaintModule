<%@ Page Title="" Language="C#" MasterPageFile="~/MainForms_Site.Master" AutoEventWireup="true" CodeBehind="SearchingCriterion.aspx.cs" Inherits="RainMaker.ComplainManagement.Searching_Criterion" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

<div  class="container-fluid">
<div class="row">
    <main class="col-lg-offset-1 col-md-offset-1 col-sm-offset-1 col-xs-offset-2 col-sm-11 ml-sm-auto col-md-11 pt-3 customer content-area" role="main">
        <form id="Form1" runat="server">
            <telerik:RadScriptManager ID="RadScriptManager1" runat="server">
            </telerik:RadScriptManager>
            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                <ContentTemplate>
                    <div class="customer">
                        <form class="form-inline1 mt-2 mt-md-2 mb-md-3">
                            <div class="container-fluid">

                                <div class="row mb-md-12 mb-sm-12 border-box">
                                    <h4 style="margin-left: 15px;">Searching Filters</h4>

                                    <div class="col-md-3 col-sm-12 col-lg-3">

                                        <asp:DropDownList ID="cmbCustomerCode" class="form-control" runat="server" onselectedindexchanged="cmbCustomerCode_SelectedIndexChanged">

                                        </asp:DropDownList>
                                    </div>

                                    <div class="col-md-3 col-sm-12 col-lg-3">
                                        <asp:TextBox ID="tbCustomerIPPool" class="form-control mr-sm-2" placeholder="Customer IP Pool" runat="server"></asp:TextBox>
                                    </div>
                                    <div class="col-md-3 col-sm-12 col-lg-3">
                                        <asp:TextBox ID="tbExtraIPPool" class="form-control mr-sm-2" placeholder="Extra IP Pool" runat="server"></asp:TextBox>
                                    </div>

                                </div>

                                <div class="row mb-md-12 mb-sm-12 border-box">
                                    <h4 style="margin-left: 15px;">Circuit Branches Details</h4>
                                    <div class="row">
                                        <asp:label ID="lblCustomerName" style="margin-left: 45px;" runat="server">Customer Name</asp:label>

                                    </div>

                                    <div class="col-md-4 col-sm-12 col-lg-4  border-box" style="margin-left:21px">
                                        <div class="container-fluid">

                                            <table class="table table-responsive table-bordered mb-md-0">
                                                
                                                <caption>
                                                    Total Branches Count And Their SLA
                                                    
                                                    <tbody>
                                                        <tr>
                                                            <td class="webcontrols-details">
                                                                Total Active Branches</td>
                                                            <td>
                                                                <asp:Label ID="lblTotalActive" runat="server">:</asp:Label>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td class="webcontrols-details">
                                                                Total Block Branches</td>
                                                            <td>
                                                                <asp:Label ID="lblBlockCircuits" runat="server">
                                                                    </asp:Label>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td class="webcontrols-details">
                                                                Total Complain Recieved Time</td>
                                                            <td>
                                                                <asp:Label ID="lblComplaintRec" runat="server">
                                                                    </asp:Label>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td class="webcontrols-details">
                                                                Accumulated SLA</td>
                                                            <td>
                                                                <asp:Label ID="Label1" runat="server">
                                                                    99.16%</asp:Label>
                                                            </td>
                                                        </tr>
                                                    </tbody>
                                                </caption>
                                            </table>

                                        </div>
                                    </div>

                                    <div class="col-md-4 col-sm-12 col-lg-4  border-box" style="margin-left:100px">
                                        <div class="container-fluid">
                                            <table class="table table-responsive table-bordered mb-md-0">
                                                
                                                <caption>
                                                    Region Wise Customer Information(Active Circuits)
                                                   
                                                    <tbody>
                                                        <tr>
                                                            <td style="padding-top: 37px;">
                                                                Date Filter</td>
                                                            <td>
                                                                <telerik:RadDatePicker ID="dtSLA" Runat="server" MinDate="1900-01-01" SelectedDate="1900-01-01">
                                                                    <Calendar ID="Calendar1" runat="server" UseColumnHeadersAsSelectors="False" UseRowHeadersAsSelectors="False" ViewSelectorText="x">
                                                                    </Calendar>
                                                                    <DateInput ID="DateInput1" runat="server" DateFormat="M/d/yyyy" DisplayDateFormat="M/d/yyyy" SelectedDate="1900-01-01">
                                                                    </DateInput>
                                                                    <DatePopupButton runat="server" />
                                                                </telerik:RadDatePicker>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td class="webcontrols-details">
                                                                <asp:LinkButton ID="lnkSounth" runat="server" onclick="lnkSounth_Click">South</asp:LinkButton>
                                                            </td>
                                                            <td>
                                                                <asp:Label ID="lblSouthCount" runat="server"></asp:Label>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td class="webcontrols-details">
                                                                <asp:LinkButton ID="LnkNorth" runat="server" onclick="LnkNorth_Click">North</asp:LinkButton>
                                                            </td>
                                                            <td>
                                                                <asp:Label ID="lblNorthCount" runat="server">
                                                                </asp:Label>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td class="webcontrols-details">
                                                                <asp:LinkButton ID="lnkCentral" runat="server" onclick="lnkCentral_Click">Central</asp:LinkButton>
                                                            </td>
                                                            <td>
                                                                <asp:Label ID="lblCentralCount" runat="server">
                                                                </asp:Label>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td class="webcontrols-details">
                                                                <asp:LinkButton ID="linkAll" runat="server" onclick="linkAll_Click">ALL</asp:LinkButton>
                                                            </td>
                                                            <td>
                                                                <asp:Label ID="lblAllCount" runat="server">
                                                                </asp:Label>
                                                            </td>
                                                        </tr>
                                                    </tbody>
                                                </caption>
                                            </table>

                                        </div>

                                    </div>
                                </div>

                            </div>
                        </form>

                    </div>

                    <div class="customer-buttons">

                        <div  class="row">
                            <div class="col-xs-12">
                                <div  class="text-right">

                                    <asp:Button ID="btSearch" runat="server" Text="Search" onclick="btSearch_Click" />

                                    <asp:Button ID="ExportToExcel" class="btn btn-primary" runat="server" Text="Export to Excel" OnClick="btnExportCM_Click"></asp:Button>

                                    <asp:Button ID="btnClear" class="btn btn-primary" runat="server" Text="Clear" onclick="btnClear_Click"></asp:Button>

                                    <asp:Button ID="btnBack" class="btn btn-primary" runat="server" Text="Back" onclick="btnBack_Click"></asp:Button>

                                </div>
                            </div>
                        </div>
                    </div>

                      <div class="customer-table">
                        <form  class="form-inline1 mt-2 mt-md-2 mb-md-3">
           
                
              <div class="title-section white mt-md-3">
                <div class="row">
                    <div class="col-md-12">
                        <h4 class="pull-left">Complain Details</h4>
                    </div>
                </div>
              </div>

              <div class="table-responsive">
                <asp:updatepanel ID="Updatepanel2" runat="server">
                    <contenttemplate>
                         <telerik:RadGrid ID="gvCircuitSLAView" runat="server"  AllowSorting="True"
                            GridLines="None" Skin="Office2007" 
                             OnItemCommand="gvCircuitSLAView_OnItemCommand" 
                             onneeddatasource="gvCircuitSLAView_NeedDataSource">
                            <ClientSettings>
                                <Selecting AllowRowSelect="True" />
                                <Scrolling AllowScroll="True" UseStaticHeaders="True" />
                            </ClientSettings>
                            <MasterTableView  >
                                <CommandItemSettings ShowExportToExcelButton="true" ExportToPdfText="Export to Pdf" />
                                <Columns>
                               <telerik:GridButtonColumn CommandName="View Complain" 
                                        HeaderText="View Complain" Text="View Complain" UniqueName="ViewComplain">
                                    </telerik:GridButtonColumn>
                                    </Columns>
                            </MasterTableView>
                            <PagerStyle Mode="NextPrev" />
                            <HeaderContextMenu CssClass="GridContextMenu GridContextMenu_Default" EnableImageSprites="True">
                            </HeaderContextMenu>
                        </telerik:RadGrid>
                 
                   </contenttemplate>
                </asp:updatepanel>
                </div>
                </form>
              </div>
              
          

        
                </ContentTemplate>
            </asp:UpdatePanel>

        </form>

    </main>
</div>
</div>

</asp:Content>