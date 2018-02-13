<%@ Page Title="" Language="C#" MasterPageFile="~/MainForms_Site.Master" AutoEventWireup="true" CodeBehind="SingleSMS.aspx.cs" Inherits="RainMaker.SMS.SingleSMS" %>
    <asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
        <style>
           .sam
           {
               margin-right:-5px;
               margin-left:-5px;
           }
        </style>
    </asp:Content>
    <asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

        <div class="container-fluid">
            <div class="row">
                <main class="col-lg-offset-1 col-md-offset-1 col-sm-offset-1 col-xs-offset-1 col-sm-11 col-md-11 ml-sm-auto col-md-11 pt-3 customer content-area" role="main">
                    <div class="customer">
                        <form id="Form1" runat="server">
                         

                            <form class="form-inline1 mt-2 mt-md-2 mb-md-3">
                                <div class="container-fluid">

                                    <div class="row mb-md-3 mb-sm-3 border-box">

                                        <div class="col-md-12 col-sm-12 col-lg-12">
                                            <h4>Single SMS</h4>
                                        </div>

                                        <div class="row sam">

                                            <div class="col-md-4 col-sm-12 col-lg-4">

                                                <asp:TextBox ID="tbMobileNo" class="form-control mr-sm-2 inputText" runat="server"></asp:TextBox>
                                                <span class="floating-label">Mobile No</span>
                                                
                                            </div>
                                       
                                       
                                        </div>

    


                                        <div class="row sam" >
                                            <div class="col-md-6 col-sm-12 col-lg-6 ">
                                                <div class="form-group">

                                                    <asp:TextBox ID="tbSMS" class="form-control mr-sm-2 inputText" TextMode="multiline" Rows="5" runat="server" />
                                                    <span class="floating-label">Message</span>

                                                </div> 

                                            </div>

                                        </div>

                                                                           <div class="row sam">

                                            <div class="col-md-4 col-sm-12 col-lg-4">
                                             <asp:Label ID="lblSave" Visible="false" ForeColor="Blue" runat="server" Text=""></asp:Label>
                                            </div>
                                       
                                       
                                        </div>

                                    </div>

                                    <div class="customer-buttons" style="margin-right: 15px !important;">

                                        <div class="row">
                                            <div class="col-xs-12">
                                                <div class="text-left">

                                                    <asp:Button ID="btnSend" class="btn btn-primary" runat="server" Text="Send SMS" OnClick="btnSend_Click"></asp:Button>

                                                </div>
                                            </div>
                                        </div>
                                    </div>

                                </div>

                            </form>

                            </form>
                    </div>
                </main>
            </div>
        </div>
    </asp:Content>