<%@ Page Title="" Language="C#" MasterPageFile="~/MainForms_Site.Master" AutoEventWireup="true" CodeBehind="ComplaintAnalysis.aspx.cs" Inherits="RainMaker.Dashboard.ComplaintAnalysis" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

<div class="container-fluid">
      <div class="row">
         <main class="col-md-offset-3 col-sm-offset-3 col-lg-offset-3 col-sm-9 ml-sm-auto col-md-9 pt-3 customer" role="main">
            <div class="customer">
                <form id="Form1" runat="server">
                    
                      <div class="row" style="border-bottom:inset;">
                    <div class="col-lg-9">
                        <h1>
                            Complaint Analysis
                        </h1>
                    </div>    
                </div>
          
                <div class="row" style="border-bottom:inset;">
                    <div class="col-lg-7">
                        <h3>Total Complaints : <asp:Label ID="lblTotalCount" runat="server" Text="0"></asp:Label></h3>
                    </div>    
                </div>
                <br />
                <div class="row">

                    <div class="col-lg-4 col-md-6" >
                        <div class="panel panel-yellow">
                            <div class="panel-heading">
                                <div class="row">
								 <div style="text-align:center; font-size: 13px; background-color : white;color : grey;font-weight : bold;">Region Wise Complains</div>
                                    <br/>
									<div class="col-xs-3" id="RegionName">
										<a onclick="LoadComplainDetails('2','',0)" data-toggle="modal" data-target="#myModal"><div class="small_1">South</div></a>
										<a onclick="LoadComplainDetails('1','',0)" data-toggle="modal" data-target="#myModal"><div class="small_1">North</div></a>
										<a onclick="LoadComplainDetails('3','',0)" data-toggle="modal" data-target="#myModal"><div class="small_1">Central</div></a>
                                        <div class="spacer"></div>
                                        <div class="spacer"></div>
                                        <div class="spacer"></div>
                                  
                                    </div>
                                    <div class="col-xs-9 text-right" id="RegionValue">
										<div class="small_1"><asp:Label ID="lblSouth" runat="server" Text="0"></asp:Label></div>
										<div class="small_1"><asp:Label ID="lblNorth" runat="server" Text="0"></asp:Label></div>
										<div class="small_1"><asp:Label ID="lblCentral" runat="server" Text="0"></asp:Label></div>
                                      
                                    </div>
                                </div>
                            </div>      
                        </div>
                    </div>

                    <div class="col-lg-4 col-md-6">
                        <div class="panel panel-red">
                            <div class="panel-heading">
                                <div class="row">
								 <div style="text-align:center; font-size: 13px; background-color : white;color : grey;font-weight : bold;">DownTime Wise Complains</div>
                                    <br/>
									<%--<div class="col-xs-3">--%>
									<div class="col-xs-9">
									<a onclick="LoadComplainDetails('0','1_4','0')" data-toggle="modal" data-target="#myModal">	<div class="small_1">Aging 1 to 4</div> </a>
									<a onclick="LoadComplainDetails('0','4_8','0')" data-toggle="modal" data-target="#myModal">	<div class="small_1">Aging 4 to 8</div></a>
									<a onclick="LoadComplainDetails('0','8_12','0')" data-toggle="modal" data-target="#myModal">	<div class="small_1">Aging 8 to 12</div></a>
                                    <a onclick="LoadComplainDetails('0','12_24','0')" data-toggle="modal" data-target="#myModal">    <div class="small_1">Aging 12 to 24</div></a>
                                    <a onclick="LoadComplainDetails('0','24_36','0')" data-toggle="modal" data-target="#myModal">    <div class="small_1">Aging 24 to 36</div></a>
                                    <a onclick="LoadComplainDetails('0','+36','0')" data-toggle="modal" data-target="#myModal">    <div class="small_1">Aging 36 plus</div></a>
                                    
                                    </div>
                                    <div class="col-xs-3 text-right">
                                        <div class="small_1"><asp:Label ID="lbl1_4" runat="server" Text="0"></asp:Label></div>
                                        <div class="small_1"><asp:Label ID="lbl4_8" runat="server" Text="0"></asp:Label></div>
                                        <div class="small_1"><asp:Label ID="lbl8_12" runat="server" Text="0"></asp:Label></div>
                                        <div class="small_1"><asp:Label ID="lbl12_24" runat="server" Text="0"></asp:Label></div>
                                        <div class="small_1"><asp:Label ID="lbl24_36" runat="server" Text="0"></asp:Label></div>
                                        <div class="small_1"><asp:Label ID="lbl36p" runat="server" Text="0"></asp:Label></div>
                                    
                                    </div>
                                  </div>
                            </div>      
                        </div>
                    </div>
                       <div class="col-lg-4 col-md-6">
                        <div class="panel panel-green">
                            <div class="panel-heading">
                                <div class="row">
								 <div style="text-align:center; font-size: 13px; background-color : white;color : grey;font-weight : bold;">Department Wise Complains</div>
                                    <br/>
								<div id="mCarousel" class="carousel slide" data-ride="carousel" data-interval="0">

                    
  <!-- Wrapper for slides -->
  <div class="carousel-inner" style="margin:auto;" id="FirstCar">
    

  </div>

  <!-- Left and right controls -->
  <a class="left carousel-control" href="#mCarousel" data-slide="prev">
    <span class="glyphicon glyphicon-chevron-left"></span>
    <span class="sr-only">Previous</span>
  </a>
  <a class="right carousel-control" href="#mCarousel" data-slide="next">
    <span class="glyphicon glyphicon-chevron-right"></span>
    <span class="sr-only">Next</span>
  </a>
</div>
                                  </div>
                            </div>      
                        </div>
                    </div>
          
                            
                            
					
												
			  </div>
               
  

                <!-- /.row -->
          
                <!-- slider -->
                <div id="myCarousel" class="carousel slide" data-ride="carousel" data-interval="0">

                    
  <!-- Wrapper for slides -->
  <div class="carousel-inner" style="margin:auto;">
      <div class="item active" >
          
          <div class="col-lg-4 col-md-6">
                        <div class="panel panel-primary">
                            <div class="panel-heading">
                                <div class="row">
								 <div style="text-align:center; font-size: 13px; background-color : white;color : grey;font-weight : bold;"><asp:Label ID="Label1" runat="server" Text="OTS DownTime"></asp:Label></div>
                                
                                    <br/>
									<div class="col-xs-9">
										<div class="small_1">Aging 1 to 4</div>
										<div class="small_1">Aging 4 to 8</div>
										<div class="small_1">Aging 8 to 12</div>
                                        <div class="small_1">Aging 12 to 24</div>
                                        <div class="small_1">Aging 24 to 36</div>
                                        <div class="small_1">Aging 36 plus</div>
                                           
                                    </div>
                                    <div class="col-xs-3 text-right">
										<div class="small_1"><asp:Label ID="lblDeptOTS_14" runat="server" Text="0"></asp:Label></div>        
                                        <div class="small_1"><asp:Label ID="lblDeptOTS_48" runat="server" Text="0"></asp:Label></div>
                                        <div class="small_1"><asp:Label ID="lblDeptOTS_812" runat="server" Text="0"></asp:Label></div>
                                        <div class="small_1"><asp:Label ID="lblDeptOTS_1224" runat="server" Text="0"></asp:Label></div>
                                        <div class="small_1"><asp:Label ID="lblDeptOTS_2436" runat="server" Text="0"></asp:Label></div>
                                        <div class="small_1"><asp:Label ID="lblDeptOTS_36p" runat="server" Text="0"></asp:Label></div>
                                       
                                    </div>
                                </div>
                            </div>      
                        </div>
                    </div>

          <div class="col-lg-4 col-md-6">
                        <div class="panel panel-primary">
                            <div class="panel-heading">
                                <div class="row">
								 <div style="text-align:center; font-size: 13px; background-color : white;color : grey;font-weight : bold;"><asp:Label ID="Label13" runat="server" Text="IP-NOC DownTime"></asp:Label></div>
                                
                                    <br/>
									<div class="col-xs-9">
										<div class="small_1">Aging 1 to 4</div>
										<div class="small_1">Aging 4 to 8</div>
										<div class="small_1">Aging 8 to 12</div>
                                        <div class="small_1">Aging 12 to 24</div>
                                        <div class="small_1">Aging 24 to 36</div>
                                        <div class="small_1">Aging 36 plus</div>
                                         
                                    </div>
                                    <div class="col-xs-3 text-right">
										<div class="small_1"><asp:Label ID="lblDeptNOC_14" runat="server" Text="0"></asp:Label></div>
                                        <div class="small_1"><asp:Label ID="lblDeptNOC_48" runat="server" Text="0"></asp:Label></div>
                                        <div class="small_1"><asp:Label ID="lblDeptNOC_812" runat="server" Text="0"></asp:Label></div>
                                        <div class="small_1"><asp:Label ID="lblDeptNOC_1224" runat="server" Text="0"></asp:Label></div>
                                        <div class="small_1"><asp:Label ID="lblDeptNOC_2436" runat="server" Text="0"></asp:Label></div>
                                        <div class="small_1"><asp:Label ID="lblDeptNOC_36p" runat="server" Text="0"></asp:Label></div>
                                          
                                    </div>
                                </div>
                            </div>      
                        </div>
                    </div>

          <div class="col-lg-4 col-md-6">
                        <div class="panel panel-primary">
                            <div class="panel-heading">
                                <div class="row">
								 <div style="text-align:center; font-size: 13px; background-color : white;color : grey;font-weight : bold;"><asp:Label ID="Label19" runat="server" Text="O&M South DownTime"></asp:Label></div>
                                
                                    <br/>
									<div class="col-xs-9">
										<div class="small_1">Aging 1 to 4</div>
										<div class="small_1">Aging 4 to 8</div>
										<div class="small_1">Aging 8 to 12</div>
                                        <div class="small_1">Aging 12 to 24</div>
                                        <div class="small_1">Aging 24 to 36</div>
                                        <div class="small_1">Aging 36 plus</div>
                                             
                                    </div>
                                    <div class="col-xs-3 text-right">
										<div class="small_1"><asp:Label ID="lblDeptOMS_14" runat="server" Text="0"></asp:Label></div>
                                        <div class="small_1"><asp:Label ID="lblDeptOMS_48" runat="server" Text="0"></asp:Label></div>
                                        <div class="small_1"><asp:Label ID="lblDeptOMS_812" runat="server" Text="0"></asp:Label></div>
                                        <div class="small_1"><asp:Label ID="lblDeptOMS_1224" runat="server" Text="0"></asp:Label></div>
                                        <div class="small_1"><asp:Label ID="lblDeptOMS_2436" runat="server" Text="0"></asp:Label></div>
                                        <div class="small_1"><asp:Label ID="lblDeptOMS_36p" runat="server" Text="0"></asp:Label></div>
                                            
                                    </div>
                                </div>
                            </div>      
                        </div>
                    </div>

          </div>

      <div class="item">

         <div class="col-lg-4 col-md-6">
                <div class="panel panel-primary">
                    <div class="panel-heading">
                        <div class="row">
							<div style="text-align:center; font-size: 13px; background-color : white;color : grey;font-weight : bold;"><asp:Label ID="Label7" runat="server" Text="O&M Central DownTime"></asp:Label></div>
                                
                            <br/>
							<div class="col-xs-9">
								<div class="small_1">Aging 1 to 4</div>
								<div class="small_1">Aging 4 to 8</div>
								<div class="small_1">Aging 8 to 12</div>
                                <div class="small_1">Aging 12 to 24</div>
                                 <div class="small_1">Aging 24 to 36</div>
                                 <div class="small_1">Aging 36 plus</div>
                                                    
                            </div>
                            <div class="col-xs-3 text-right">
								<div class="small_1"><asp:Label ID="lblDeptOMC_14" runat="server" Text="0"></asp:Label></div>
                                <div class="small_1"><asp:Label ID="lblDeptOMC_48" runat="server" Text="0"></asp:Label></div>
                                <div class="small_1"><asp:Label ID="lblDeptOMC_812" runat="server" Text="0"></asp:Label></div>
                                <div class="small_1"><asp:Label ID="lblDeptOMC_1224" runat="server" Text="0"></asp:Label></div>
                                <div class="small_1"><asp:Label ID="lblDeptOMC_2436" runat="server" Text="0"></asp:Label></div>
                                <div class="small_1"><asp:Label ID="lblDeptOMC_36p" runat="server" Text="0"></asp:Label></div>
                                            
                            </div>
                        </div>
                    </div>      
                </div>
            </div>

         <div class="col-lg-4 col-md-6">
                <div class="panel panel-primary">
                    <div class="panel-heading">
                        <div class="row">
							<div style="text-align:center; font-size: 13px; background-color : white;color : grey;font-weight : bold;"><asp:Label ID="Label25" runat="server" Text="O&M North DownTime"></asp:Label></div>
                                
                            <br/>
							<div class="col-xs-9">
								<div class="small_1">Aging 1 to 4</div>
								<div class="small_1">Aging 4 to 8</div>
								<div class="small_1">Aging 8 to 12</div>
                                <div class="small_1">Aging 12 to 24</div>
                                <div class="small_1">Aging 24 to 36</div>
                                <div class="small_1">Aging 36 plus</div>
                                                 
                            </div>
                            <div class="col-xs-3 text-right">
								<div class="small_1"><asp:Label ID="lblDeptOMN_14" runat="server" Text="0"></asp:Label></div>
                                <div class="small_1"><asp:Label ID="lblDeptOMN_48" runat="server" Text="0"></asp:Label></div>
                                <div class="small_1"><asp:Label ID="lblDeptOMN_812" runat="server" Text="0"></asp:Label></div>
                                <div class="small_1"><asp:Label ID="lblDeptOMN_1224" runat="server" Text="0"></asp:Label></div>
                                <div class="small_1"><asp:Label ID="lblDeptOMN_2436" runat="server" Text="0"></asp:Label></div>
                                <div class="small_1"><asp:Label ID="lblDeptOMN_36p" runat="server" Text="0"></asp:Label></div>
                                         
                            </div>
                        </div>
                    </div>      
                </div>
            </div>

         <div class="col-lg-4 col-md-6">
                <div class="panel panel-primary">
                    <div class="panel-heading">
                        <div class="row">
							<div style="text-align:center; font-size: 13px; background-color : white;color : grey;font-weight : bold;"><asp:Label ID="Label31" runat="server" Text="Third Party DownTime"></asp:Label></div>
                                
                            <br/>
							<div class="col-xs-9">
								<div class="small_1">Aging 1 to 4</div>
								<div class="small_1">Aging 4 to 8</div>
								<div class="small_1">Aging 8 to 12</div>
                                <div class="small_1">Aging 12 to 24</div>
                                <div class="small_1">Aging 24 to 36</div>
                                <div class="small_1">Aging 36 plus</div>
                                                  
                            </div>
                            <div class="col-xs-3 text-right">
								<div class="small_1"><asp:Label ID="lblDeptTP_14" runat="server" Text="0"></asp:Label></div>
                                <div class="small_1"><asp:Label ID="lblDeptTP_48" runat="server" Text="0"></asp:Label></div>
                                <div class="small_1"><asp:Label ID="lblDeptTP_812" runat="server" Text="0"></asp:Label></div>
                                <div class="small_1"><asp:Label ID="lblDeptTP_1224" runat="server" Text="0"></asp:Label></div>
                                <div class="small_1"><asp:Label ID="lblDeptTP_2436" runat="server" Text="0"></asp:Label></div>
                                <div class="small_1"><asp:Label ID="lblDeptTP_36p" runat="server" Text="0"></asp:Label></div>
                                            
                            </div>
                        </div>
                    </div>      
                </div>
            </div>

          </div>

  </div>

  <!-- Left and right controls -->
  <a class="left carousel-control" href="#myCarousel" data-slide="prev">
    <span class="glyphicon glyphicon-chevron-left"></span>
    <span class="sr-only">Previous</span>
  </a>
  <a class="right carousel-control" href="#myCarousel" data-slide="next">
    <span class="glyphicon glyphicon-chevron-right"></span>
    <span class="sr-only">Next</span>
  </a>
</div>
                <!-- slider -->

                <br />


            <div class=" breadcrumb  row" style="background-color:#f5f5f5" >
            <div class="  col-lg-2 col-md-2 col-xs-2" style="color:red;">*Aging 1 - 4</div>
			<ol class=" col-lg-10 col-md-10 col-xs-10">
				<marquee behavior="scroll" direction="left" onmouseover="this.stop();" onmouseout="this.start();"><asp:Label ID="lblTriger1_4" runat="server" Text="Triger"></asp:Label></marquee>
			</ol>
            </div>

            <div class=" breadcrumb row"  style="background-color:#f5f5f5">
            <div class=" col-lg-2 col-md-2 col-xs-2 " style="color:red;">*Aging 4 - 8</div>
			<ol class="col-lg-10 col-md-10 col-xs-10">
				<marquee behavior="scroll" direction="left" onmouseover="this.stop();" onmouseout="this.start();"><asp:Label ID="lblTriger4_8" runat="server" Text="Triger"></asp:Label></marquee>
			</ol>
            </div>

            <div class=" breadcrumb row" style="background-color:#f5f5f5">
            <div class="col-lg-2 col-md-2 col-xs-2 " style="color:red">*Aging 8 - 12</div>
			<ol class="col-lg-10 col-md-10 col-xs-10">
				<marquee behavior="scroll" direction="left" onmouseover="this.stop();" onmouseout="this.start();"><asp:Label ID="lblTriger8_12" runat="server" Text="Triger"></asp:Label></marquee>
			</ol>
            </div>

            <div class=" breadcrumb row" style="background-color:#f5f5f5">
            <div class="col-lg-2 col-md-2 col-xs-2 " style="color:red;">*Aging 12 to 24</div>
            <ol class="col-lg-10 col-md-10 col-xs-10">
            <marquee behavior="scroll" direction="left" onmouseover="this.stop();" onmouseout="this.start();"><asp:Label ID="lblTriger12_24" runat="server" Text="Triger"></asp:Label></marquee>
            </ol>
            </div>

            <div class=" breadcrumb row" style="background-color:#f5f5f5">
            <div class=" breadcrumb col-lg-2 " style="color:red;">*Aging 24 plus</div>
            <ol class="breadcrumb col-lg-10" >
            <marquee behavior="scroll" direction="left" onmouseover="this.stop();" onmouseout="this.start();"><asp:Label ID="lblTrigerPlus_24" runat="server" Text="Triger"></asp:Label></marquee>
            </ol>
            </div>

      
             
            <%-- New Row for Customer Graph & RFO Table --%>  
                <div class="row">

                       <div class="col-lg-12">
                            <div class="panel panel-default">
                                <div class="panel-heading"></div>
                                <div class="panel-body">
                                    <div class="flot-chart">
                                        <div class="table-responsive">
                                            <div id="Top10Chart" style="height: 350px; width: 100%;"></div>
                                            <br/>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>

                </div>     
            
            
            <%-- New Row for Customer Graph & RFO Table --%>  
                <div class="row">
                
                    <div class="col-lg-6">
                        <div class="panel panel-default">
                            <div class="panel-heading">                            
                            </div>
                            <div class="panel-body" Height="400px">
                                <div class ="flot-chart">
								 <div class="table-responsive">
                                     <div id="InfraChart" style="height: 300px; width: 100%;overflow:hidden;"></div>
                                   </div>
                                </div>
                            </div>
                        </div>
                    </div>

                    <div class="col-lg-6"  >
                    <div class="panel panel-default">
                        <div class="panel-heading">
                        <h3 class="panel-title">Complain Solved On Force Majeure last 24 hours</h3>
                        </div>
                        <div class="panel-body" >
                          
                                <div class="table-responsive" >
                                    <table class="table table-bordered table-hover"   Height="360px">
                                        <thead>
                                        <tr>
                                        <th>Reson of Outage</th>
                                        <th>Complain Count</th>
                                        </tr>
                                        </thead>
                                        <tbody>
                                        <tr>
                                        <td>Force Majeure Fiber Pressure</td>
                                        <td><asp:Label ID="lblFibrePre" runat="server" Text="Label"></asp:Label></td>
                                        </tr>
                                        <tr>
                                        <td>Force Majeure Long Haul Fiber Pressure</td>
                                        <td><asp:Label ID="lblLH_FiberPre" runat="server" Text="Label"></asp:Label></td>
                                        </tr>
                                        <tr>
                                        <td>Force Majeure Long Haul OFC Breakage</td>
                                        <td><asp:Label ID="lblLH_OFCBreakage" runat="server" Text="Label"></asp:Label></td>

                                        </tr>
                                        <tr>
                                        <td>Force Majeure OFC Breakage</td>
                                        <td><asp:Label ID="lblOFCBreakage" runat="server" Text="Label"></asp:Label></td>
                                        </tr>
                                       </tbody>
                                    </table>
                                </div>
                            </div>
              </div>
            </div>
           
               </div>

        <%-- New Row for Customer Graph & RFO Table --%>  
                <div class="row">   

                    <div class="col-lg-12">
                        <div class="panel panel-default">
                            <div class="panel-heading">                 
                            </div>
                            <div class="panel-body">
                                <div class="flot-chart">
								 <div class="table-responsive">
                                     <div id="DepartmentChart" style="height: 350px; width: 100%;overflow:hidden"></div>
                              </div>
							   </div>
                        </div>
                    </div>
                </div>

                </div>

            <div id="models">

                <div id="myModal" class="modal fade table-responsive " role="dialog" ><div class="modal-dialog table-responsive " id="modalinner"  style="height:60%;width:70%;"> <!-- Modal content--> </div></div>

            </div>
                    
                </form>
            </div>
          </main>

          <!-- jQuery -->
         
        <!-- jQuery -->
        <script src="../Scripts/js/jquery.js"></script>

        <!-- Bootstrap Core JavaScript -->
        <script src="../Scripts/js/bootstrap.min.js"></script>

        <!-- Morris Charts JavaScript -->

        <script src="../Scripts/js/canvasjs.min.js"></script>
        <script src="../Scripts/js/jquery.js"></script>



  <script>

      LoadMPPLData();

      function LoadMPPLData() {
          $.ajax({
              type: "POST",
              async: false,
              url: 'ComplaintAnalysis.aspx/Loader',
              contentType: "application/json; charset=utf-8",
              data: "{'Flag':'MPPL'}",
              success: function (data) {
                  console.log(data);
                  DataCreator(data.d, "#FirstCar")
              },
              failure: function () {
                  alert("error");
              }
          });
      }

      function DataCreator(data, container) {
          var z = 0;
          var a = 0;
          var mod = data.length % 6;
          var divide = data.length / 6;
          var intvalue = Math.trunc(divide);
          var loopVal = intvalue * 6
          if (container == "#FirstCar")
          { z = 6; }

          var container = $(container);
          var containerHtml = $(container).html();
          for (j = 0; j < loopVal; j += 6) {
              if (j == 0) {
                  containerHtml += "<div class=\"item active\"><div class=\"col-lg-12 col-md-12\"><div class=\"row\"><div class=\"col-xs-9\">";
              }

              else {
                  containerHtml += "<div class=\"item \"><div class=\"col-lg-12 col-md-12\"><div class=\"row\"><div class=\"col-xs-9\">";
              }

              if (j < loopVal) {

                  for (var i = j; i < j + z; i++) {

                      containerHtml += "<a onclick=\"LoadComplainDetails('0','','" + data[i].DepartID + "')\" data-toggle=\"modal\" data-target=\"#myModal\"><div class=\"small_1\"  >" + data[i].Name + "</div></a>";
                      a = a + 1;
                  }

                  containerHtml += "</div><div class=\"col-xs-3\">";
                  for (var i = j; i < j + z; i++) {
                      containerHtml += "<div class=\"small_1\">" + data[i].ComplainCount + "</div>";
                  }
                  containerHtml += "</div></div></div></div>";
                  //container.html(containerHtml);
              }


          }

          if (mod > 0) {

              containerHtml += "<div class=\"item \"><div class=\"col-lg-12 col-md-12\"><div class=\"row\"><div class=\"col-xs-9\">";
              for (var i = a; i < data.length; i++) {
                  containerHtml += "<a onclick=\"LoadComplainDetails('" + data[i].DepartID + "')\" data-toggle=\"modal\" data-target=\"#myModal\"><div class=\"small_1\"  >" + data[i].Name + "</div></a>";
              }

              containerHtml += "</div><div class=\"col-xs-3\">";
              for (var i = a; i < data.length; i++) {
                  containerHtml += "<div class=\"small_1\">" + data[i].ComplainCount + "</div>";
              }

              containerHtml += "</div></div></div></div>";

          }
          container.html(containerHtml);


      }

      function LoadComplainDetails(RegionID, Aging, AssignedDept) {

          $.ajax({
              type: "POST",
              async: false,
              url: 'ComplaintAnalysis.aspx/Complains',
              contentType: "application/json; charset=utf-8",
              data: "{'RegionID':'" + RegionID + "','Aging':'" + Aging + "','AssignedDept':'" + AssignedDept + "'}",
              success: function (data) {
                  LoadComplain(data.d)
              },
              failure: function () {
                  alert("error");
              }
          });



      }

      function LoadComplain(data) {
          var container = $('#modalinner');
          var html = "<div class=\"modal-content table-responsive \" style=\"overflow-y:scroll; \"><div class=\"modal-header\"> <button type=\"button\" class=\"close\" data-dismiss=\"modal\">&times;</button> <h4 class=\"modal-title\">Complain Details </h4></div><div class=\"modal-body\">  ";
          html += "<table class=\"table table-bordered table-responsive table-condensed table-striped\"><thead><th>SignupID</th><th> TicketNo </th><th>CircuitName </th><th>Address </th><th>City </th><th>Infra </th><th>ServiceUnit </th><th>ComplainType</th><th>ComplainRecievedDate </th><th>LastUpdatedDate </th><th>AssignedPersonName </th><th>TimeDuration </th><th>Remarks </th></thead><tbody>";
          for (var i = 0; i < data.length; i++)
              html += "<tr><td>" + data[i].SignupID + "</td><td>" + data[i].TicketNo + "</td><td>" + data[i].CircuitName + "</td><td>" + data[i].Address + "</td><td>" + data[i].City + "</td><td>" + data[i].Infra + "</td><td>" + data[i].ServiceUnit + "</td><td>" + data[i].ComplainType + "</td><td>" + data[i].ComplainRecievedDate + "</td><td>" + data[i].LastUpdatedDate + "</td><td>" + data[i].AssignedPersonName + "</td><td>" + data[i].TimeDuration + "</td><td>" + data[i].Remarks + "</td></tr>";
          html += "</tbody></table><button type=\"button\" class=\"btn btn-default\" data-dismiss=\"modal\">Close</button></div>  </div> ";
          container.html(html);

      }

 </script>

    <!-- Bootstrap Core JavaScript -->
 
  <%--    milliseconds, so 10 seconds = 10000ms--%>
    <script language="JavaScript" type="text/javascript">setTimeout("location.href = 'ComplaintAnalysis.aspx'", 900000);

        LoadComplainAllGraphs();

        function LoadComplainAllGraphs() {
            $.ajax({
                type: "POST",
                url: 'ComplaintAnalysis.aspx/loadAllGraph',
                contentType: "application/json; charset=utf-8",
                success: function (data) {
                    var result = data.d;
                    LoadTop10wise(result.Top10Chart);
                    LoadDepartmentwise(result.DepartChart);
                    LoadInfraWise(result.InfrPieChart);
                },
                failure: function () {
                    alert("error");
                }
            });



        }

        function LoadTop10wise(data) {
            var chart = new CanvasJS.Chart("Top10Chart",
            {
                title: {
                    text: "TOP 10 Customer having Maximum Complaint's",
                    fontWeight: "bold",
                    fontFamily: "calibri"

                },
                animationEnabled: true,
                axisY: {
                    title: "Count",
                    labelFontSize: 15,
                    labelFontFamily: "Calibri",
                },
                axisX: {
                    title: "Customer Name",
                    labelAutoFit: false,
                    labelAngle: -45,
                    labelFontSize: 10,
                    labelFontFamily: "Calibri",

                },
                legend: {
                    verticalAlign: "bottom",
                    horizontalAlign: "center",

                },
                theme: "theme2",
                data: [

                {

                    type: "column",
                    showInLegend: false,
                    legendMarkerColor: "grey",
                    legendText: "",
                    dataPoints: [
                    ]
                }
                ]
            });

            var result = data;
            console.log(result);
            for (var i = 0; i < result.length; i++) {
                chart.options.data[0].dataPoints.push({ y: result[i].y, label: result[i].label });
            }
            chart.render();
        }


        function LoadDepartmentwise(data) {
            var chart = new CanvasJS.Chart("DepartmentChart",
           {
               title: {
                   text: "DEPARTMENT WISE COMPLAINT'S",
                   fontWeight: "bold",
                   fontFamily: "calibri"
               },
               animationEnabled: true,
               axisY: {
                   title: "Count",
               },
               axisX: {
                   title: "Department",
                   labelAutoFit: false,
                   labelAngle: -45,
                   labelFontSize: 10,
                   labelFontFamily: "Calibri",

               },
               legend: {
                   verticalAlign: "bottom",
                   horizontalAlign: "center"
               },
               theme: "theme1",
               data: [

               {
                   type: "column",
                   showInLegend: false,
                   legendMarkerColor: "grey",

                   legendText: "",
                   dataPoints: [

                   ]
               }
               ]
           });

            var result = data;
            for (var i = 0; i < 10; i++) {
                chart.options.data[0].dataPoints.push({ y: result[i].y, label: result[i].label });

            }

            chart.render();

        }

        function LoadInfraWise(data) {
            var chart = new CanvasJS.Chart("InfraChart",
          {
              title: {
                  text: "INFRA WISE COMPLAINT'S",
                  fontWeight: "bold",
                  fontFamily: "calibri"
              },
              animationEnabled: true,
              legend: {
                  verticalAlign: "bottom",
                  horizontalAlign: "left",
                  legendAutoFit: false,
                  legendAngle: 40
              },
              data: [
              {
                  indexLabelFontSize: 15,
                  indexLabelFontFamily: "Calibri",
                  indexLabelFontColor: "darkgrey",
                  indexLabelLineColor: "darkgrey",
                  indexLabelPlacement: "Outside",
                  type: "pie",
                  showInLegend: false,
                  toolTipContent: "{y} - <strong>#percent%</strong>",


                  dataPoints: [

                  ]
              }
              ]
          });

            var result = data;
            for (var i = 0; i < result.length; i++) {
                chart.options.data[0].dataPoints.push({ y: result[i].y, indexLabel: result[i].indexLabel + "|Count:" + result[i].y });
            }

            chart.render();
        }

    </script>


        </div>
</div>

    

</asp:Content>
