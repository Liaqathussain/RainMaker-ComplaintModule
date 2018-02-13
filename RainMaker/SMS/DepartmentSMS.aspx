<%@ Page Title="" Language="C#" MasterPageFile="~/MainForms_Site.Master" AutoEventWireup="true" CodeBehind="DepartmentSMS.aspx.cs" Inherits="RainMaker.SMS.DepartmentSMS" %>

    <%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
        <asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
        <style>
           .sam
           {
               margin-right:1px;
               margin-left:47px;
           }
        </style>
        </asp:Content>
        <asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

            <div class="container-fluid">
                <div class="row">
                    <main class="col-lg-offset-1 col-md-offset-1 col-sm-offset-1 col-xs-offset-2 col-sm-11 ml-sm-auto col-md-11 pt-3 customer content-area" role="main">
                        <div class="customer">
                            <form id="Form1" runat="server">
                                <telerik:RadScriptManager ID="RadScriptManager1" runat="server">
                                </telerik:RadScriptManager>

                               
                                <%--<asp:Button ID="btnViewHistoryFiberDetails" OnClick="btnviewFiberHistory_Click" runat="server" Text="View History" />--%>
                                    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                        <ContentTemplate>
                                            <div class="container">

                                             <div class="col-md-12 col-sm-12 col-lg-12">
                                            <h4>Department SMS</h4>
                                        </div>
                                        <br />
                                        <br />
                                        <br />
                                        
                                                <div class="row">

                                                    <div class="col-md-4 col-sm-12 col-lg-4">
                                                        <asp:DropDownList ID="cmbCity" OnSelectedIndexChanged="cmbCity_SelectedIndexChanged" AutoPostBack="true" runat="server"></asp:DropDownList>
                                                        <span class="floating-label-select">City</span>
                                                    </div>

                                                    <div class="col-md-4 col-sm-12 col-lg-4">
                                                        <asp:DropDownList ID="cmbGroup" runat="server" OnSelectedIndexChanged="cmbGroup_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>
                                                        <span class="floating-label-select">Groups</span>
                                                    </div>

                                                </div>

                                                <div class="row">
                                                   <div class="col-md-4 col-sm-12 col-lg-4">
                                                    <asp:CheckBox ID="chkIsSelectAll" OnCheckedChanged="chkIsSelectAll_changed" AutoPostBack="true" runat="server" Text="Select All" />
                                                    </div>
                                                </div>
                                                

                                                 <telerik:RadGrid ID="grdEmployee" runat="server" AllowPaging="false" AllowSorting="true" GridLines="None" Skin="Office2007" OnNeedDataSource="grdEmployee_NeedDataSource" >
                                            <ClientSettings>
                                                <Selecting AllowRowSelect="True" />
                                                <Scrolling AllowScroll="True" UseStaticHeaders="True" />
                                            </ClientSettings>
                                            <MasterTableView>
                                                <CommandItemSettings ExportToPdfText="Export to Pdf" />
                                                <Columns>
                                                    <telerik:GridTemplateColumn>
                                                        <ItemTemplate>
                                                            <asp:CheckBox ID="cb_Select" runat="server" ClientIDMode="AutoID"></asp:CheckBox>
                                                        </ItemTemplate>
                                                    </telerik:GridTemplateColumn>
                                                   
                                                </Columns>
                                            </MasterTableView>
                                            
                                            <HeaderContextMenu CssClass="GridContextMenu GridContextMenu_Default" EnableImageSprites="True">
                                            </HeaderContextMenu>
                                        </telerik:RadGrid>
                                                <br>
                                                </br>

                                        
                                    
                                    <div class="col-md-4 col-sm-12 col-lg-4 ">
                                        <%--<telerik:RadTextBox ID="tbSMS" runat="server" TextMode="MultiLine" Width="500px" Height="100px" >
                                </telerik:RadTextBox>--%>
                                            <asp:TextBox ID="tbSMS" TextMode="MultiLine" class="form-control mr-sm-2 " Rows="5" Width="334px" runat="server"></asp:TextBox>
                                            <span class="floating-label-textarea">Sms</span>

                                    </div>

                                    <asp:Button ID="btnSend" class="btn btn-primary" runat="server" OnClick="btnSend_Click" Text="Send"></asp:Button>

                                    <asp:Label ID="lblNotify" Visible="false" ForeColor="Red" runat="server" Text=""></asp:Label>

                                    </ContentTemplate>
                                    </asp:UpdatePanel>
                            </form>
                        </div>
                    </main>
                </div>

        </asp:Content>