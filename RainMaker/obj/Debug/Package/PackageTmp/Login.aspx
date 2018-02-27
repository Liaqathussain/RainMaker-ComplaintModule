<%@ Page Title="" Language="C#" MasterPageFile="~/Form_Site2.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="RainMaker.WebForm1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<div class="inner cover">

    <div class="logo"><img src="../Images/logo_rainmaker.png"></div>
   
    <form id="Form1" class="form-signin" runat="server">                    
        <h2 class="form-signin-heading">Sign In</h2>
        <asp:TextBox ID="tbUser" runat="server" class="form-control" placeholder="Username"></asp:TextBox>
        <asp:TextBox ID="tbPassword" runat="server" class="form-control password-security" placeholder="Password" autocomplete="off"></asp:TextBox>
        <asp:Button ID="Button1" runat="server" placeholder="Button" class="btn btn-lg btn-primary btn-block" Text="Login" onclick="Button1_Click"/>
        <br />
        <asp:Label ID="lblnotify" runat="server" Text="Label" Visible="false"></asp:Label>
       
        <%--<div class="row">
            <div class="col-md-6">
                <div class="pull-left">
                    <label>
                        <a href="signup.html">Create New Account</a> 
                    </label>
                </div>
            </div>
            <div class="col-md-6">
                <div class="pull-right">
                    <label>
                            <a href="forgot.html">Forgot Password?</a> 
                    </label>
                </div>
            </div>
        </div>--%>

    </form>
                
</div>

</asp:Content>
