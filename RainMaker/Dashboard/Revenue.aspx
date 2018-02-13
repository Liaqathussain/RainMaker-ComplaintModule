<%@ Page Title="" Language="C#" MasterPageFile="~/MainForms_Site.Master" AutoEventWireup="true" CodeBehind="Revenue.aspx.cs" Inherits="RainMaker.Dashboard.Revenue" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

<div class="container-fluid">
      <div class="row">
          <main class="col-lg-offset-1 col-md-offset-1 col-sm-offset-1 col-xs-offset-1 col-sm-11 col-md-11 ml-sm-auto col-md-11 pt-3 customer content-area" role="main">
            <div class="customer">
                <form id="Form1" runat="server">
                      <!-- Page Heading -->
                <div class="row">
                    <div class="col-lg-12">
                        <h1 class="page-header">
                            <label>
                            <h2>Revenue</h2>
                            </label>
                        </h1>
                    </div>
          <br />
                </div>
                <!-- /.row -->
				<div class="row">
         
			      <div class="col-lg-12">
                    <div class="panel panel-default">
                        <div class="panel-heading">
                        <h3 class="panel-title">Revenue Count month wise LOB wise</h3>
                        </div>
                        <div class="panel-body" >
                            <div class="table-responsive" >
                            <asp:GridView BorderWidth="3px" ID="dtInvoices" runat="server" AutoGenerateColumns="true"  Width="100%"  ViewStateMode="Enabled" >
                            </asp:GridView>
                            </div>
                        </div>
                    </div>
                </div>
           
				</div>

                <br />

                <div class="row">         
			      <div class="col-lg-12">
                    <div class="panel panel-default">
                        <div class="panel-heading">
                        <h3 class="panel-title">Revenue Count month wise LOB wise 2017 (Greater than equat to 3 months after duedate)</h3>
                        </div>
                        <div class="panel-body" >
                            <div class="table-responsive" >
                            <asp:GridView  BorderWidth="3px"  ID="dtRevenueCount3" runat="server" AutoGenerateColumns="true"  Width="100%"  ViewStateMode="Enabled"  >
                            </asp:GridView>
                            </div>
                        </div>
                    </div>
                </div>
           
				</div>

                <br />

                <div class="row">
			      <div class="col-lg-12">
                    <div class="panel panel-default">
                        <div class="panel-heading">
                        <h3 class="panel-title">Revenue month wise LOB wise</h3>
                        </div>
                        <div class="panel-body" >
                            <div class="table-responsive" >
                            <asp:GridView BorderWidth="3px" ID="dtRevenue" runat="server" AutoGenerateColumns="true"  Width="100%"  ViewStateMode="Enabled">
                            </asp:GridView>
                            </div>
                        </div>
                    </div>
                </div>
              </div>

                     <br />

                <div class="row">
			      <div class="col-lg-12">
                    <div class="panel panel-default">
                        <div class="panel-heading">
                        <h3 class="panel-title">Receipt month wise</h3>
                        </div>
                        <div class="panel-body" >
                            <div class="table-responsive" >
                            <asp:GridView  BorderWidth="3px" ID="dtReciptMonthWise" runat="server" AutoGenerateColumns="true"  Width="100%"  ViewStateMode="Enabled">
                            </asp:GridView>
                            </div>
                        </div>
                    </div>
                </div>
              </div>

                <br />

             <div class="row">
			      <div class="col-lg-12">
                    <div class="panel panel-default">
                        <div class="panel-heading">
                        <h3 class="panel-title">Sales Tax month wise LOB wise</h3>
                        </div>
                        <div class="panel-body" >
                            <div class="table-responsive" >
                            <asp:GridView BorderWidth="3px"  ID="dtSalesTaxMonth" runat="server" AutoGenerateColumns="true"  Width="100%"  ViewStateMode="Enabled">
                            </asp:GridView>
                            </div>
                        </div>
                    </div>
                </div>
              </div>
             <div class="row">
                <!-- /.row -->

                </div>
                </form>
            </div>

             <script src="js/bootstrap.min.js"></script>

            <!-- Morris Charts JavaScript -->
            <script src="js/plugins/morris/raphael.min.js"></script>
            <script src="js/plugins/morris/morris.min.js"></script>
            <script src="js/plugins/morris/morris-data.js"></script>

          </main>
        </div>
</div>



</asp:Content>
