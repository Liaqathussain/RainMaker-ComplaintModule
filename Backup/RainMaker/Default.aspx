<%@ Page Title="" Language="C#" MasterPageFile="~/MainForms_Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="RainMaker.WebForm2" %>
<%@ MasterType VirtualPath="~/MainForms_Site.master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

<div class="container-fluid">
      <div class="row">
         <main class="col-md-offset-3 col-sm-offset-3 col-lg-offset-3 col-sm-9 ml-sm-auto col-md-9 pt-3 customer" role="main">
            <div class="customer">
                <form id="Form1" runat="server">
                    
                    

                    <div class="col-md-4">
                    
                        <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
                        <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
                        <asp:DropDownList ID="DropDownList1" runat="server">
                            <asp:ListItem Selected="True">Please select your age</asp:ListItem>
                        </asp:DropDownList>

                        <asp:ImageButton ID="ImageButton1" ImageUrl="Images/home-icon.png" runat="server"></asp:ImageButton>
                        <asp:Button ID="Button1" runat="server" Text="Button"></asp:Button>
                        <asp:Button ID="Button2" runat="server" Text="Button"></asp:Button>

                        <asp:FileUpload ID="FileUpload1" runat="server"></asp:FileUpload>

                     <%--   <telerik:RadDatePicker ID="dtToDate" Runat="server" MinDate="1900-01-01" 
                                    SelectedDate="1900-01-01" 
                                    >
                                    <Calendar UseRowHeadersAsSelectors="False" UseColumnHeadersAsSelectors="False" ViewSelectorText="x"></Calendar>

                                    <DateInput DisplayDateFormat="M/d/yyyy" DateFormat="M/d/yyyy" SelectedDate="1900-01-01"></DateInput>

                                    <DatePopupButton ImageUrl="" HoverImageUrl=""></DatePopupButton>
                        </telerik:RadDatePicker>--%>
                        
                        <asp:HyperLink ID="HyperLink1" href="#" runat="server">This is link</asp:HyperLink>

                    </div>

                    <div class="col-md-12">
                    
                         <asp:RadioButton ID="RadioButton1" runat="server" Text="Radio Button"></asp:RadioButton>
                         <asp:CheckBox ID="CheckBox1" runat="server" Text="Check Box"></asp:CheckBox>
                         <asp:Label ID="Label1" runat="server" Text="Simple Label"></asp:Label>
                         <asp:LinkButton ID="LinkButton1" runat="server">LinkButton</asp:LinkButton>

                    </div>

                    <div class="col-md-12">
                    

                    <div id="ctl00_MainContent_grdEmployee" class="RadGrid RadGrid_Office2007" tabindex="0">

		<div id="ctl00_MainContent_grdEmployee_GridHeader" class="rgHeaderDiv" style="padding-right: 17px; overflow: hidden;">

            <table cellspacing="0" class="title-section white mt-md-3" id="ctl00_MainContent_grdEmployee_ctl00_Header" style="width: 100%; table-layout: fixed; overflow: hidden; empty-cells: show;">
	            <colgroup>
		            <col style="width: 10px;">
		            <col style="width: 62px;">
		            <col style="width: 62px;">
		            <col style="width: 62px;">
		            <col style="width: 62px;">
	            </colgroup>
                <thead>
		            <tr>
			            <th scope="col" class="rgHeader">&nbsp;</th>
                        <th scope="col" class="rgHeader"><a title="Click here to sort" href="javascript:__doPostBack('ctl00$MainContent$grdEmployee$ctl00$ctl02$ctl00$ctl00','')">Employee Code</a></th>
                        <th scope="col" class="rgHeader"><a title="Click here to sort" href="javascript:__doPostBack('ctl00$MainContent$grdEmployee$ctl00$ctl02$ctl00$ctl01','')">Name</a></th>
                        <th scope="col" class="rgHeader"><a title="Click here to sort" href="javascript:__doPostBack('ctl00$MainContent$grdEmployee$ctl00$ctl02$ctl00$ctl02','')">SMS No</a></th>
                        <th scope="col" class="rgHeader"><a title="Click here to sort" href="javascript:__doPostBack('ctl00$MainContent$grdEmployee$ctl00$ctl02$ctl00$ctl03','')">City Name</a></th>
		            </tr>
	            </thead>
                <tbody style="display:none;">
                    <tr><td colspan="5"></td></tr>
                </tbody>
            </table>

	</div>

	<div  class="rgDataDiv" style="overflow:auto;width:100%;height:300px;">

    <table cellspacing="0" class="rgMasterTable rgClipCells" id="ctl00_MainContent_grdEmployee_ctl00" style="width: 100%; table-layout: fixed; overflow: hidden; empty-cells: show;">
	    <colgroup>
		    <col style="width: 10px;">
		    <col style="width: 62px;">
		    <col style="width: 62px;">
		    <col style="width: 62px;">
		    <col style="width: 62px;">
	    </colgroup>
    <tbody>
	<tr class="rgRow" id="ctl00_MainContent_grdEmployee_ctl00__0">
		<td>
            <input id="ctl00_MainContent_grdEmployee_ctl00_ctl04_cb_Select" type="checkbox" name="ctl00$MainContent$grdEmployee$ctl00$ctl04$cb_Select">
        </td>
        <td>EMP00953</td>
        <td> Aamir Hayat Mansoor</td><td>923444482697</td>
        <td>Dera Ismail Khan</td>
	</tr>
    <tr class="rgRow" id="Tr1">
		<td>
            <input id="Checkbox2" type="checkbox" name="ctl00$MainContent$grdEmployee$ctl00$ctl04$cb_Select">
        </td>
        <td>EMP00953</td>
        <td> Aamir Hayat Mansoor</td><td>923444482697</td>
        <td>Dera Ismail Khan</td>
	</tr>
	</tbody>

    </table>	
    
    </div>
    <input id="ctl00_MainContent_grdEmployee_ClientState" name="ctl00_MainContent_grdEmployee_ClientState" type="hidden" autocomplete="off" value="{&quot;selectedIndexes&quot;:[],&quot;reorderedColumns&quot;:[],&quot;expandedItems&quot;:[],&quot;expandedGroupItems&quot;:[],&quot;expandedFilterItems&quot;:[],&quot;deletedItems&quot;:[],&quot;hidedColumns&quot;:[],&quot;showedColumns&quot;:[],&quot;scrolledPosition&quot;:&quot;0,0&quot;,&quot;popUpLocations&quot;:{},&quot;draggedItemsIndexes&quot;:[]}">
</div>
                    
                    
                    
                    
                    </div>
                    
                    
                    
                </form>
            </div>
          </main>
        </div>
</div>

</asp:Content>
