<%@ Page Title="" Language="C#" MasterPageFile="~/MainForms_Site.Master" AutoEventWireup="true" CodeBehind="ViewHistory.aspx.cs" Inherits="RainMaker.ComplainManagement.ViewHistory" %>
    <%@ Register TagPrefix="My" TagName="cntviewcomphist" Src="~/UserControls/cntviewcomphist.ascx" %>
    <%@ Register TagPrefix="My" TagName="cntViewCustomerInfromation" Src="~/UserControls/cntViewCustomerInfromation.ascx" %>
    <%@ Register TagPrefix="My" TagName="cntComplainHistory" Src="~/UserControls/cntComplainHistory.ascx" %>
        <%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
            <asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
            </asp:Content>
            <asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

                <div class="container-fluid">
                    <div class="row">
                        <main class="col-lg-offset-1 col-md-offset-1 col-sm-offset-1 col-xs-offset-2 col-sm-11 ml-sm-auto col-md-11 pt-3 customer content-area" role="main">
                            <form id="Form1" runat="server">
                                <telerik:RadScriptManager ID="RadScriptManager1" runat="server"></telerik:RadScriptManager>

                                <asp:panel ID="pnlviewcomphist" runat="server">
                                <My:cntviewcomphist runat="server" ID="cntviewcomphist" Visible="false" />
                                </asp:panel>
                                <asp:panel ID="pnlViewCustomerInfromation" runat="server">
                                <my:cntViewCustomerInfromation runat="server" ID="cntViewCustomerInfromation" Visible="false"></my:cntViewCustomerInfromation>
                                </asp:panel>
                                <asp:panel ID="pnlComplainHistorys" runat="server">
                                <My:cntComplainHistory runat="server" ID="cntComplainHistory" Visible="false"/>
                                </asp:panel>
                            </form>
                        </main>
                    </div>
                </div>

            </asp:Content>