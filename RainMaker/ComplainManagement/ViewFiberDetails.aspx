<%@ Page Title="" Language="C#" MasterPageFile="~/MainForms_Site.Master" AutoEventWireup="true" CodeBehind="ViewFiberDetails.aspx.cs" Inherits="RainMaker.ComplainManagement.ViewFiberDetails" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

<div class="container-fluid">
      <div class="row">
         <main class="col-lg-offset-1 col-md-offset-1 col-sm-offset-1 col-xs-offset-2 col-sm-11 ml-sm-auto col-md-11 pt-3 customer content-area" role="main">
            <div class="customer">
                <form id="Form1" runat="server">  
                <telerik:RadScriptManager ID="RadScriptManager1" runat="server">
                    </telerik:RadScriptManager>

                     <h3 class="center-block" style="text-align: center;">
                        View History</h3>
                
            <div class="table-responsive">
             
               <telerik:RadGrid ID="grdFiberDetails" AutoGenerateColumns="true" Skin="Office2007"  runat="server">
                </telerik:RadGrid>
            

                    
                </form>
            </div>
          </main>
        </div>
</div>

</asp:Content>
