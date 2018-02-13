<%@ Page Title="" Language="C#" MasterPageFile="~/MainForms_Site.Master" AutoEventWireup="true" CodeBehind="OrderBook.aspx.cs" Inherits="RainMaker.Dashboard.OrderBook" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
<style type="text/css">
         .flot-chart 
         {
             margin-top: 0px;
         }

         .spacer
         {
            height:23px;
        }

         .CenterText {
             text-align:center !important;   
         }
     </style>
    

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

<div class="container-fluid">
      <div class="row">
         <main class="col-md-offset-3 col-sm-offset-3 col-lg-offset-3 col-sm-9 ml-sm-auto col-md-9 pt-3 customer" role="main">
            <div class="customer">
                <form id="Form1" runat="server">


                           <!-- Page Heading -->
                <div class="row" style="border-bottom:inset;">
                    <div class="col-lg-9">
                        <h1>
                            Multinet Order Book
                        </h1>
                    </div>    
                </div>
          
                <br />
                <div class="row">

                    <div class="col-lg-4 col-md-6" >
                        <div class="panel panel-yellow">
                            <div class="panel-heading">
                                <div class="row">
								 <div style="text-align:center; font-size: 13px; background-color : white;color : grey;font-weight : bold;"><asp:Label ID="lblHeader1" runat="server" Text=""></asp:Label></div>
                                    <br/>
                                    
									<div class="col-xs-6">
									<div class="small_1"><asp:Label ID="Label2" runat="server" Text="No of Signups"></asp:Label></div>
									<div class="small_1"><asp:Label ID="Label3" runat="server" Text="OTC"></asp:Label></div>
									<div class="small_1"><asp:Label ID="Label4" runat="server" Text="MRC"></asp:Label></div> 
                                    </div>
                                    <div class="col-xs-6 text-right">
										<div class="small_1"><asp:Label ID="lblSigupCount1" runat="server" Text="0"></asp:Label></div>
										<div class="small_1"><asp:Label ID="lblOTC1" runat="server" Text="0"></asp:Label></div>
										<div class="small_1"><asp:Label ID="lblMRC1" runat="server" Text="0"></asp:Label></div>                          
                                    </div>
                                </div>
                            </div>      
                        </div>
                    </div>

                    <div class="col-lg-4 col-md-6">
                        <div class="panel panel-red">
                            <div class="panel-heading">
                                <div class="row">
								  <div style="text-align:center; font-size: 13px; background-color : white;color : grey;font-weight : bold;"><asp:Label ID="lblHeader2" runat="server" Text=""></asp:Label></div>
                                    <br/>
                                    
									<div class="col-xs-6">
									<div class="small_1"><asp:Label ID="Label6" runat="server" Text="No of Signups"></asp:Label></div>
									<div class="small_1"><asp:Label ID="Label8" runat="server" Text="OTC"></asp:Label></div>
									<div class="small_1"><asp:Label ID="Label9" runat="server" Text="MRC"></asp:Label></div> 
                                    </div>
                                    <div class="col-xs-6 text-right">
										<div class="small_1"><asp:Label ID="lblSigupCount2" runat="server" Text="0"></asp:Label></div>
										<div class="small_1"><asp:Label ID="lblOTC2" runat="server" Text="0"></asp:Label></div>
										<div class="small_1"><asp:Label ID="lblMRC2" runat="server" Text="0"></asp:Label></div>                          
                                    </div>

                                  </div>
                            </div>      
                        </div>
                    </div>
                       
                    <div class="col-lg-4 col-md-6">
                        <div class="panel panel-green">
                            <div class="panel-heading">
                                <div class="row">
								  <div style="text-align:center; font-size: 13px; background-color : white;color : grey;font-weight : bold;"><asp:Label ID="lblHeader3" runat="server" Text=""></asp:Label></div>
                                    <br/>
                                    
									<div class="col-xs-6">
									<div class="small_1"><asp:Label ID="Label10" runat="server" Text="No of Signups"></asp:Label></div>
									<div class="small_1"><asp:Label ID="Label11" runat="server" Text="OTC"></asp:Label></div>
									<div class="small_1"><asp:Label ID="Label12" runat="server" Text="MRC"></asp:Label></div> 
                                    </div>
                                    <div class="col-xs-6 text-right">
										<div class="small_1"><asp:Label ID="lblSignupCount3" runat="server" Text="0"></asp:Label></div>
										<div class="small_1"><asp:Label ID="lblOTC3" runat="server" Text="0"></asp:Label></div>
										<div class="small_1"><asp:Label ID="lblMRC3" runat="server" Text="0"></asp:Label></div>                          
                                    </div>

                                  </div>
                            </div>      
                        </div>
                    </div>
                            
                </div> 
                <!-- /.row1 -->         
					
		     <br />

               <div class="row">
         
			      <div class="col-lg-12">
                    <div class="panel panel-default">
                        <div class="panel-heading">
                        <h3 class="panel-title">Signup Orders via LOB and Infra of Current and Next Month</h3>
                        </div>
                        <div class="panel-body" >
                            <div class="table-responsive" >
                            <asp:GridView  BorderWidth="3px"  ID="dtDetailsLI" runat="server" AutoGenerateColumns="true"  Width="100%"   OnRowDataBound="dtDetailsLI_RowDataBound">
                            </asp:GridView>
                            </div>
                        </div>
                    </div>
                </div>
 </div>
               <div class="row">
                <div class="col-lg-12">
                    <div class="panel panel-default">
                        <div class="panel-heading">
                        <h3 class="panel-title" ><a style="font:italic">Signup Orders via LOB and Circuit Status of Current and Next Month</a></h3>
                        </div>
                        <div class="panel-body" >
                            <div class="table-responsive" >
                            <asp:GridView BorderWidth="3px"   ID="dtDetailsLS" runat="server" AutoGenerateColumns="true"  Width="100%" OnRowDataBound="dtDetailsLS_RowDataBound">
                            </asp:GridView>
                            </div>
                        </div>
                    </div>
                </div>
           
				</div>
                <!-- /.row2 -->         
					
                <div class="row"> 
                     <div class="col-lg-12">
                    <div class="panel panel-default">
                        <div class="panel-heading">
                        <h3 class="panel-title">Signup Orders via Circuit Owner and Infra Medium of Current and Next Month</h3>
                        </div>
                        <div class="panel-body" >
                            <div class="table-responsive" >
                            <asp:GridView  BorderWidth="3px"  ID="dtDetailsOI" runat="server" AutoGenerateColumns="true"  Width="100%"  ViewStateMode="Enabled" OnRowDataBound="dtDetailsOI_RowDataBound"  >
                            </asp:GridView>
                            </div>
                        </div>
                    </div>
                </div>
                    
                </div>
   

                </form>
            </div>

             <script src="js/bootstrap.min.js"></script>

          </main>
        </div>
</div>

</asp:Content>
