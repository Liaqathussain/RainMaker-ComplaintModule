<%@ Page Title="" Language="C#" MasterPageFile="~/MainForms_Site.Master" AutoEventWireup="true" CodeBehind="CustomerAnalysis.aspx.cs" Inherits="RainMaker.Dashboard.CustomerAnalysis" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

<div class="container-fluid">
      <div class="row">
         <main class="col-md-offset-3 col-sm-offset-3 col-lg-offset-3 col-sm-9 ml-sm-auto col-md-9 pt-3 customer" role="main">
            <div class="customer">
                <form id="Form1" runat="server">
                    
                    <div class="row">
                        <div class="container">
                            <div id="LoadingOverlay">
                                <div class="banner">LOADING PLEASE WAIT ...        
                               </div>
                            </div>
                         </div>
                        
                        <div class="col-lg-12">
                            <h1 class="page-header">Customer Analysis
                            </h1>
                        </div>

                    </div>

                    <div class="row">

                        <div class="col-lg-2 col-md-6">
                            <div class="panel panel-green">
                                <div class="panel-heading">
                                    <div class="row">
                                        <div class="col-xs-3">
                                            <br />
                                            <i class="fa fa fa-user fa-2x" aria-hidden="true"></i>
                                        </div>
                                        <div class="col-xs-9 text-right">

                                            <div class="huge">
                                                <label id="lblActive">0</label>
                                            </div>
                                            <div>Active Circuits</div>
                                        </div>
                                    </div>
                                </div>

                            </div>
                        </div>

                        <div class="col-lg-2 col-md-6">
                            <div class="panel panel-maroon">
                                <div class="panel-heading">
                                    <div class="row">
                                        <div class="col-xs-3 text-left">
                                            <br />

                                            <i class="fa fa-random fa-2x" aria-hidden="true"></i>
                                        </div>

                                        <div class="col-xs-9 text-right">

                                            <div class="huge">

                                                <label id="lblCPE">0</label>
                                            </div>
                                            <div>CPE Down Circuits</div>

                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>

                        <div class="col-lg-2 col-md-6">
                            <div class="panel panel-red">
                                <div class="panel-heading">
                                    <div class="row">
                                        <div class="col-xs-3">
                                            <br />
                                            <i class="fa fa-arrow-circle-down fa-2x" aria-hidden="true"></i>
                                        </div>
                                        <div class="col-xs-9 text-right">

                                            <div class="huge">
                                                <label id="lblInterfaceDown">0</label>
                                            </div>
                                            <div>Interface Down</div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>

                        <div class="col-lg-2 col-md-6">
                            <div class="panel panel-yellow">
                                <div class="panel-heading">
                                    <div class="row">
                                        <div class="col-xs-3">
                                            <br />
                                            <i class="fa fa-line-chart fa-2x" aria-hidden="true"></i>
                                        </div>
                                        <div class="col-xs-9 text-right">

                                            <div class="huge">
                                                <label id="lblNew">0</label>
                                            </div>
                                            <div>New Connection</div>
                                        </div>
                                    </div>
                                </div>

                            </div>
                        </div>

                        <div class="col-lg-2 col-md-6">
                            <div class="panel panel-primary">
                                <div class="panel-heading">
                                    <div class="row">
                                        <div class="col-xs-3">
                                            <br />
                                            <i class="fa fa-external-link-square fa-2x" aria-hidden="true"></i>
                                        </div>
                                        <div class="col-xs-9 text-right">
                                            <div class="huge">
                                                <label id="lblInProcess">0</label>
                                            </div>
                                            <div>InProgress Circuits</div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>

                        <div class="col-lg-2 col-md-6">
                            <div class="panel panel-maroon2">
                                <div class="panel-heading">
                                    <div class="row">
                                        <div class="col-xs-3">
                                            <br />
                                            <i class="fa fa-ban fa-2x" aria-hidden="true"></i>
                                        </div>
                                        <div class="col-xs-9 text-right">

                                            <div class="huge">
                                                <label id="lblBlock">0</label>
                                            </div>
                                            <div>Blocked Circuits</div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>



                    </div>

                    <div class="row">

                        <div class="col-lg-12">
                            <div class="panel panel-default">
                                <div class="panel-heading"></div>
                                <div class="panel-body">
                                    <div class="table-responsive">
                                        <div id="SplineChart" style="height: 300px; width: 100%; overflow: hidden"></div>
                                    </div>
                                </div>
                            </div>
                        </div>

                        <div class="col-lg-12">
                            <div class="panel panel-default">
                                <div class="panel-heading">
                                </div>
                                <div class="panel-body">
                                    <div class="table-responsive">
                                        <div id="PieChart" style="height: 300px; width: 100%; overflow: hidden"></div>
                                    </div>
                                </div>
                            </div>
                        </div>

                    </div>

                    <div class="row">

                        <div class="col-lg-6">
                            <div class="panel panel-green">
                                <div class="panel-heading">
                                </div>
                                <div class="panel-body">
                                    <div class="flot-chart">
                                        <div class="table-responsive">
                                            <div id="Bar1Chart" style="height: 300px; width: 100%;"></div>
                                            <br />
                                            <h5 style="font-family: Calibri; font-size: small; font-style: italic; color: #008000">Note : TDM Circuit are not segregated via Region</h5>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>

                        <div class="col-lg-6">
                            <div class="panel panel-red">
                                <div class="panel-heading"></div>
                                <div class="panel-body">
                                    <div class="flot-chart">
                                        <div class="table-responsive">
                                            <div id="BarChart" style="height: 300px; width: 100%;"></div>
                                            <br />
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>

                    </div>

                    
                </form>
            </div>
          </main>
        </div>
</div>

     <!-- jQuery -->
        <script src="../Scripts/js/jquery.js"></script>

        <!-- Bootstrap Core JavaScript -->
        <script src="../Scripts/js/bootstrap.min.js"></script>

        <!-- Morris Charts JavaScript -->

        <script src="../Scripts/js/canvasjs.min.js"></script>
        <script src="../Scripts/js/jquery.js"></script>


        <script type="text/javascript">

            $(document).ready(function () {


            });



            LoadComplainDetails();
            function LoadComplainDetails() {
                $.ajax({
                    type: "POST",
                    url: 'CustomerAnalysis.aspx/loadAllData',
                    contentType: "application/json; charset=utf-8",
                    complete: function () {

                        $('#LoadingOverlay').hide();
                        $("#pagea").css("opacity", "1");
                    },
                    success: function (data) {


                        var result = data.d;
                        var ds = data.d.Lblstrings;
                        if (ds.length > 0) {
                            console.log(ds[0]);

                            $('#lblActive').html(ds[0]);
                            $('#lblCPE').html(ds[1]);
                            $('#lblInterfaceDown').html(ds[2]);
                            $('#lblNew').html(ds[3]);
                            $('#lblInProcess').html(ds[4]);
                            $('#lblBlock').html(ds[5]);
                        }
                        else {
                            $('#lblActive').html("0");
                            $('#lblCPE').html("0");
                            $('#lblInterfaceDown').html("0");
                            $('#lblNew').html("0");
                            $('#lblInProcess').html("0");
                            $('#lblBlock').html("0");
                        }
                        LoadServiceWise(result.PieChart);
                        LoadLast12Month(result.SplineChart);
                        LoadLOBwise(result.BarChart);
                        LoadRegionwise(result.Bar1Chart);


                    },
                    failure: function () {
                        alert("error");
                    }
                });



            }

            function LoadLOBwise(data) {
                var chart = new CanvasJS.Chart("BarChart",
                {
                    title: {
                        text: "LOB WISE DEPLOYMENTS",
                        fontWeight: "bold",
                        fontFamily: "calibri"
                    },
                    animationEnabled: true,
                    axisY: {
                        title: "Count"
                    },
                    axisX: {
                        title: "Line of Business"
                    },
                    legend: {
                        verticalAlign: "bottom",
                        horizontalAlign: "center"
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
                for (var i = 0; i < result.length; i++) {
                    chart.options.data[0].dataPoints.push({ y: result[i].y, label: result[i].label });

                }

                chart.render();


            }

            function LoadLast12Month(data) {
                var chart = new CanvasJS.Chart("SplineChart",
                {
                    title: {
                        text: "LAST 12 MONTH DEPLOYMENTS",
                        fontWeight: "bold",
                        fontFamily: "calibri"
                    },
                    animationEnabled: true,
                    axisY: {
                        title: "Count",
                        lineColor: "#369EAD"
                    },

                    axisX: {
                        title: "Months"
                    },
                    data: [
                    {
                        type: "spline",
                        name: "speed",
                        dataPoints: [
                        ]
                    }
                    ]
                });


                var result = data;
                for (var i = 0; i < result.length; i++) {
                    chart.options.data[0].dataPoints.push({ y: result[i].y, indexLabel: result[i].x });
                }
                chart.render();

            }

            function LoadServiceWise(data) {
                var chart = new CanvasJS.Chart("PieChart",
              {
                  title: {
                      text: "SERVICE WISE DEPLOYMENTS",
                      fontWeight: "bold",
                      fontFamily: "calibri"
                  },
                  animationEnabled: true,
                  legend: {
                      verticalAlign: "bottom",
                      horizontalAlign: "left"
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

            function LoadRegionwise(data) {
                var chart = new CanvasJS.Chart("Bar1Chart",
               {
                   title: {
                       text: "REGION WISE DEPLOYMENTS",
                       fontWeight: "bold",
                       fontFamily: "calibri"
                   },
                   animationEnabled: true,
                   axisY: {
                       title: "Count"
                   },
                   axisX: {
                       title: "Region"
                   },
                   legend: {
                       verticalAlign: "bottom",
                       horizontalAlign: "center"
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
                for (var i = 0; i < data.length; i++) {
                    chart.options.data[0].dataPoints.push({ y: result[i].y, label: result[i].label });

                }

                chart.render();

            }

            $(window).load(function () {


            });
        </script>

</asp:Content>
