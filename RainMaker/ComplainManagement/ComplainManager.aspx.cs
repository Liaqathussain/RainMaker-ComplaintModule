using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using RainMaker.Classes;
using RainMaker.BSS_Service;
using Telerik.Web.UI;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Reflection;
using iTextSharp.text;
using iTextSharp.text.pdf;
using OfficeOpenXml;
using OfficeOpenXml.Drawing;
using OfficeOpenXml.Style;
using Microsoft.Office.Interop;
using System.Threading;
using DocumentFormat.OpenXml.Spreadsheet;
using System.Text.RegularExpressions;

namespace RainMaker.ComplainManagement
{
    public partial class ComplainManager : System.Web.UI.Page
    {

        int DeptID;
        int RoleID=0;
        BL objBL = new BL();
        static System.Data.DataTable dtForExcel ;
        //BSS_ServiceLocal.Service1SoapClient objBSS = new BSS_ServiceLocal.Service1SoapClient();
        BSS_Service.Service1SoapClient objBSS = new BSS_Service.Service1SoapClient();

        #region EVENTS

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                RoleID = Convert.ToInt32(Session["RoleID"]);
                DeptID = Convert.ToInt16(Session["DepartmentID"]);
                LoadCombos();
                if (RoleID == 1)
                {
                    pnlSMS.Visible = true;
                }
                else
                {
                    pnlSMS.Visible = false;
                }
            }
        }



        protected void btSearch_Click(object sender, EventArgs e)
        {
            btSearch.Enabled = false;
            SearchComplainCircuits();
            btSearch.Enabled = true;
        }

        //protected void btnSendSMS_Click(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        if (gvComplainCircuits.Rows.Count > 0)
        //        {
        //            foreach (GridDataItem item in gvComplainCircuits.Rows)
        //            {
        //                var cb = (System.Web.UI.WebControls.CheckBox)item.FindControl("cb_Select");
        //                if (cb.Checked == true)
        //                {
        //                    //string ContactNo = Convert.ToInt32(item["ComplaintID"].Text);
        //                    string contactno = item["SMS"].Text;
        //                    contactno = "923212310024";
        //                    objBSS.SendSMS("External SMS", contactno, "Test", 1);
        //                }
        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        throw new Exception(ex.Message);
        //    }

        //}

        //protected void gvComplainCircuits_ItemCommand(object sender, Telerik.Web.UI.GridCommandEventArgs e)
        //{
        //    if (e.CommandName == "Complain Closure" || e.CommandName == "Complain Forward" || e.CommandName == "ComplainSolve" || e.CommandName == "View History" || e.CommandName == "Ticket No")
        //    {
        //        int index = e.Item.ItemIndex;
        //        GridDataItem item = (GridDataItem)gvComplainCircuits.Rows[index];
        //        string click = e.CommandName;
        //        //Session["Complain_TicketNo"] = item["TicketNo"].Text;
        //        //Session["ComplainID"] = item["ComplaintID"].Text;
        //        Session["Complain_HistoryFlag"] = 1;
        //        Session["TicketNo"] = item["TicketNo"].Text;
        //        Session["Complain_TicketNo"] = item["TicketNo"].Text;
        //        Session["ComplainID"] = item["ComplaintID"].Text;
        //        //int SignupID = Convert.ToInt32(item["SignupID"].Text);
        //        Session["ComplainID"] = item["ComplaintID"].Text;
        //        Session["SignupID"] = item["SignupID"].Text;

        //        string ComplainStatusID = item["ComplaintStatusID"].Text;

        //        if (click.Equals("Ticket No"))
        //        {
        //            //Response.Redirect("~\\ComplainForm.aspx?click=" + click);
        //            Response.Redirect("~\\ComplainManagement\\ComplainForm.aspx?SignupID=" + Convert.ToInt32(Session["SignupID"]) + "&ComplainID=" + Convert.ToInt32(Session["ComplainID"]) + "&Flag=View");

        //        }

        //        else if (click.Equals("View History"))
        //        {
        //            Response.Redirect("~\\ComplainManagement\\ViewHistory.aspx?click=" + click);
        //        }

        //        else
        //        {
        //            if (ComplainStatusID.Equals("4") || ComplainStatusID.Equals("2"))
        //            {
        //                if (!(click.Equals("Complain Closure")))
        //                {
        //                    string str = click.Replace(" ",string.Empty);
        //                    Response.Redirect("~\\ComplainManagement\\"+str+".aspx?click=" + click);
        //                }

        //            }

        //            else if (ComplainStatusID.Equals("1") || ComplainStatusID.Equals("5"))
        //            {
        //                if (click.Equals("ComplainSolve"))
        //                {
        //                    Response.Redirect("~\\ComplainManagement\\ComplainSolve.aspx?click=" + click);
        //                }
        //                else if (click.Equals("Complain Closure")) 
        //                {
        //                     Response.Redirect("~\\ComplainManagement\\ComplaintClose.aspx?click=" + click);
        //                }
        //                else if (click.Equals("Complain Forward"))
        //                {
        //                    Response.Redirect("~\\ComplainManagement\\ComplainForward.aspx?click=" + click);
                        
        //                }
                      
        //            }
                        


        //            else
        //            {
        //                Response.Redirect("~\\ComplainManagement\\ComplainSolve?click=" + click);
        //            }

        //        }
             
        //    }
        //}
        protected void gvComplainCircuits_OnDataBinding(object sender, GridViewCommandEventArgs e) { }
        protected void gvComplainCircuits_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Complain Closure" || e.CommandName == "Complain Forward" || e.CommandName == "ComplainSolve" || e.CommandName == "View History" || e.CommandName == "Ticket No")
            {
                int index = Convert.ToInt32(e.CommandArgument);
                GridViewRow item = gvComplainCircuits.Rows[index];
                string click = e.CommandName;
                //Session["Complain_TicketNo"] = item["TicketNo"].Text;
                //Session["ComplainID"] = item["ComplaintID"].Text;
                Session["Complain_HistoryFlag"] = 1;
                Session["TicketNo"] = item.Cells[7].Text;
                Session["Complain_TicketNo"] = item.Cells[7].Text;
                Session["ComplainID"] = item.Cells[5].Text;
                //int SignupID = Convert.ToInt32(item["SignupID"].Text);
                Session["ComplainID"] = item.Cells[5].Text;
                Session["SignupID"] = item.Cells[6].Text;
                //Session["SignupID"] = gvComplainCircuits.Rows(e.RowIndex).Cells("InfraID").Value;

                string ComplainStatusID = item.Cells[34].Text;

                if (click.Equals("Ticket No"))
                {
                    //Response.Redirect("~\\ComplainForm.aspx?click=" + click);
                    Response.Redirect("~\\ComplainManagement\\ComplainForm.aspx?SignupID=" + Session["SignupID"] + "&ComplainID=" + Session["ComplainID"] + "&Flag=View",true);
                    ScriptManager.RegisterStartupScript(Page, typeof(System.Web.UI.Page), "OpenWindow", "window.open('" + "../ComplainManagement/ComplainForm.aspx?SignupID=" + Session["SignupID"] + "&ComplainID=" + Session["ComplainID"] + "&Flag=View", true);
                }

                else if (click.Equals("View History"))
                {
                    Response.Redirect("~\\ComplainManagement\\ViewHistory.aspx?click=" + click);
                }

                else
                {
                    if (ComplainStatusID.Equals("4") || ComplainStatusID.Equals("2"))
                    {
                        if (!(click.Equals("Complain Closure")))
                        {
                            string str = click.Replace(" ", string.Empty);
                            ScriptManager.RegisterStartupScript(Page, typeof(System.Web.UI.Page), "OpenWindow", "window.open('" + "../ComplainManagement/ComplaintClose.aspx?ComplainID=" + Session["ComplainID"] + "&SignupID=" + Session["SignupID"] + "');", true);
                          //  Response.Redirect("~\\ComplainManagement\\" + str + ".aspx?click=" + click,true);
                           // ScriptManager.RegisterStartupScript(Page, typeof(System.Web.UI.Page), "OpenWindow", "window.open('" + "../ComplainManagement/" + str + ".aspx?ComplainID=" + Session["ComplainID"] + "&SignupID="+Session["SignupID"]+ "');", true);
                        }

                    }

                    else if (ComplainStatusID.Equals("1") || ComplainStatusID.Equals("5"))
                    {
                        if (click.Equals("ComplainSolve"))
                        {
                            string str = click.Replace(" ", string.Empty);
                            ScriptManager.RegisterStartupScript(Page, typeof(System.Web.UI.Page), "OpenWindow", "window.open('" + "../ComplainManagement/" + str + ".aspx?ComplainID=" + Session["ComplainID"] + "&SignupID=" + Session["SignupID"] + "');", true);
                        }
                        else if (click.Equals("Complain Closure"))
                        {
                            
                            ScriptManager.RegisterStartupScript(Page, typeof(System.Web.UI.Page), "OpenWindow", "window.open('" + "../ComplainManagement/ComplaintClose.aspx?ComplainID=" + Session["ComplainID"] + "&SignupID=" + Session["SignupID"] + "');", true);
                        }
                        else if (click.Equals("Complain Forward"))
                        {
                            string str = click.Replace(" ", string.Empty);
                            ScriptManager.RegisterStartupScript(Page, typeof(System.Web.UI.Page), "OpenWindow", "window.open('" + "../ComplainManagement/" + str + ".aspx?ComplainID=" + Session["ComplainID"] + "&SignupID=" + Session["SignupID"] + "');", true);

                        }

                    }



                    else
                    {
                        string str = click.Replace(" ", string.Empty);
                        ScriptManager.RegisterStartupScript(Page, typeof(System.Web.UI.Page), "OpenWindow", "window.open('" + "../ComplainManagement/" + str + ".aspx?ComplainID=" + Session["ComplainID"] + "&SignupID=" + Session["SignupID"] + "');", true);
                    }

                }

            }

        }

        protected void btnClearCM_Click(object sender, EventArgs e)
        {
            ClearSearchFillters();
        }

        protected void btnExport_Click(object sender, EventArgs e)
        {


            Session["REPORT"] = "BCOMPLAINS";
            DataView ds = new DataView(dtForExcel);
            Session["ds"] = ds;
            Response.Redirect("~\\ComplainManagement\\DownloadExcelFile.aspx");

            
           
        }

        #endregion


        #region FUNCTIONS

        

   

        

        void DownloadFile(string FPath)
        {
            String strRequest = Request.QueryString["file"];
            FileInfo file = new FileInfo(FPath);
            if (file.Exists)
            {
                Response.Clear();
                Response.AddHeader("Content-Disposition", "attachment; filename=" + file.Name);
                Response.AddHeader("Content-Length", file.Length.ToString());
                Response.ContentType = "application/octet-stream";
                Response.WriteFile(file.FullName);
                Response.End();
            }
            else
            {
                Response.Write("This file does not exist.");
            }
        }
        //private void CreateExcelFile(DataTable dt)
        //{

        //    try
        //    {
        //       HttpContext.Current.Response.ClearContent();
        //       HttpContext.Current.Response.Buffer = true;
        //       HttpContext.Current.Response.AddHeader("content-disposition", string.Format("attachment; filename={0}", "Customers.xls"));
        //       HttpContext.Current.Response.ContentType = "application/ms-excel";
               
        //        string str = string.Empty;
        //        foreach (DataColumn dtcol in dt.Columns)
        //        {
        //            HttpContext.Current.Response.Write(str + dtcol.ColumnName);
        //            str = "\t";
        //        }
        //        HttpContext.Current.Response.Write("\n");
        //        foreach (DataRow dr in dt.Rows)
        //        {
        //            str = "";
        //            for (int j = 0; j < dt.Columns.Count; j++)
        //            {
        //                HttpContext.Current.Response.Write(str + Convert.ToString(dr[j]));
        //                str = "\t";
        //            }
        //            HttpContext.Current.Response.Write("\n");
        //        }
        //        HttpContext.Current.Response.End();
                
        //    }
        //    catch (System.Exception ex)
        //    {
             
        //    }
            
        //} 
        private void ClearSearchFillters()
        {
            try
            {
                tbCMSID.Text = string.Empty;
                tbTicketNumber.Text = string.Empty;
                tbGPID.Text = string.Empty;
                tbSignupID.Text = string.Empty;
                tbSignupID.Text = string.Empty;
                cmbTicketType.SelectedValue = "0";
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void LoadCombos()
        {
            try
            {

                if (DeptID == 1 | DeptID == 10)
                {
                    cbQCFormat.Visible = true;
                }

                if (DeptID == 1 | DeptID == 4 | DeptID == 56 | DeptID == 57 | DeptID == 58 | DeptID == 59 | DeptID == 60)
                {
                    cbSDFormat.Visible = true;
                }

                if (DeptID == 1 | DeptID == 15)
                {
                    cmbCurrentDepartment.Enabled = true;
                }

                objBL.loadTicketType(cmbTicketType);
                objBL.LoadCaseCategory(cmbCaseCategory);
                objBL.loadAssignedDepartment(cmbCurrentDepartment, "All");
                objBL.LoadComplainType(cmbComplainType);
                objBL.LoadComplainStatus(cmbComplainStatus, "All");
                objBL.LoadCircuitOwner(cmbCircuitOwner);
                objBL.loadCities(cmbCity);
                objBL.LoadProblemDignosedAt(cmbProblemDiagnosedAt, 0);
                objBL.LoadReasonOutage(cmbReasonofOutage, 0, 0, 0, 1, Convert.ToInt32(Session["UserID"]));
                objBL.loadLoggedBy(cmbLoggedBy);
                objBL.LoadInitialStatement(cmbInitialStatement);
                objBL.loadCusCode(cmbCustomerCode, null, "Nothing");
                objBL.loadNode(cmbNode, 0, 0, "");
                objBL.LoadComplaintReportedVia(cmbReportedVia);
                objBL.loadAssignedDepartment(cmbForwardToDepartment, "All");
                objBL.loadAssignedDepartment(cmbForwardByDepartment, "All");
                objBL.LoadComplainStatus(cmbForwardStatus, "All");
                cmbCurrentDepartment.SelectedValue = DeptID.ToString();
            }
            catch (Exception ex)
            {
                // Interaction.MsgBox("frmOts_SearchComplainCircuits:" + ex.Message + "of frmOts_SearchComplainCircuits_Load ", MsgBoxStyle.Critical, "BSS Addminstrator");
            }
        }

        private void SearchComplainCircuits()
        {
            try
            {
                string Format = null;
                
                    if (cbQCFormat.Checked == true)
                    {
                        Format = "QC";
                    }
                    else if (cbSDFormat.Checked == true)
                    {
                        Format = "SD";
                    }
                    else
                    {
                        Format = "";
                    }

                    
                
                int Sign = 0;
                DeptID = Convert.ToInt16(Session["DepartmentID"]);
                if (tbSignupID.Text != string.Empty)
                {
                    Sign = Convert.ToInt32(tbSignupID.Text);
                }
                else
                {
                    Sign = 0;
                }

                int SearchFollow = 0;

                

                
                System.Data.DataTable dt = objBSS.SearchComplainCircuits(tbTicketNumber.Text,
                Sign, tbCMSID.Text, tbGPID.Text, tbCircuitName.Text,
                (cmbTicketType.Text != "Select Ticket Type" ? cmbTicketType.Text : ""),
                Convert.ToInt16(cmbComplainStatus.SelectedValue),
                Convert.ToInt16(cmbCity.SelectedValue),
                Convert.ToInt16(cmbCircuitOwner.SelectedValue),
                (cmbLoggedBy.Text != "Select LoggedBy" ? cmbLoggedBy.Text : ""),
                Convert.ToInt16(cmbCaseCategory.SelectedValue),
                Convert.ToInt16(cmbInitialStatement.SelectedValue),
                Convert.ToInt16(cmbProblemDiagnosedAt.SelectedValue),
                Convert.ToInt16(cmbReasonofOutage.SelectedValue),
                dtToDate.SelectedDate.Value, dtFromDate.SelectedDate.Value,
                Convert.ToInt16(cmbCustomerCode.SelectedValue),
                Convert.ToInt16(cmbCurrentDepartment.SelectedValue),
                Convert.ToInt16(cmbNode.SelectedValue), 4,
                Format, SearchFollow, Convert.ToInt16(cmbReportedVia.SelectedValue),
                Convert.ToInt16(cmbForwardToDepartment.SelectedValue),
                Convert.ToInt16(cmbForwardByDepartment.SelectedValue),
                Convert.ToInt16(cmbForwardStatus.SelectedValue));
                dtForExcel = dt;

                lblTotalCount.Text = Convert.ToString(dt.Rows.Count);
                
                lblTotalCount.Visible=true;

                
                
                if (dt.Rows.Count > 0)
                {
                    
                    
                    gvComplainCircuits.DataSource = dt;
                    gvComplainCircuits.DataBind();
                    gvComplainCircuits.HeaderRow.Cells[7].Visible = false;
                    foreach (GridViewRow row in gvComplainCircuits.Rows)
                    {
                        row.Cells[7].Visible = false;
                    }
                    if (DeptID == 1 || DeptID == 15 )
                    {
                        //gvComplainCircuits.Columns[7].Visible = false;
                        //gvComplainCircuits.MasterTableView.GetColumn("ComplainClosuer").Display = true;
                        //gvComplainCircuits.MasterTableView.GetColumn("col_followHis").Display = true;
                        //gvComplainCircuits.MasterTableView.GetColumn("ComplainClosuer").Display = true;
                        //gvComplainCircuits.MasterTableView.GetColumn("TicketNo").Display = false;
                    }
                    else
                    {
                       // gvComplainCircuits.MasterTableView.GetColumn("ComplainClosuer").Display = false;
                    }

                    //gvComplainCircuits.MasterTableView.GetColumn("TicketNo").Display = false;
                    //gvComplainCircuits.MasterTableView.GetColumn("ComplaintID").Display = false;
                    //gvComplainCircuits.MasterTableView.GetColumn("NodeID").Display = false;
                    //gvComplainCircuits.MasterTableView.GetColumn("ComplaintStatusID").Display = false;
                    //gvComplainCircuits.MasterTableView.GetColumn("colfollow").Display = true;
                    //gvComplainCircuits.MasterTableView.GetColumn("colSolve").Display = true;
                    //gvComplainCircuits.MasterTableView.GetColumn("colViewHistory").Display = true;
                    //gvComplainCircuits.MasterTableView.GetColumn("InfraID").Display = false;
                    //gvComplainCircuits.MasterTableView.GetColumn("TicketNo").Display=false;
                    //ChangeToButtonColumn("SignupID", 6);
                    //ChangeToButtonColumn("TicketNo", 7);
                }
                else
                {
                    //lblTotalCount.Text = "0";
                    gvComplainCircuits.DataSource = null;
                    gvComplainCircuits.DataBind();
                    //Interaction.MsgBox("No Record Found", MsgBoxStyle.Information, "BSS Administrator");
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        #endregion

        protected void btnClear_Click(object sender, EventArgs e)
        {
            Response.Redirect("~\\ComplainManagement\\ComplainManager.aspx");
        }

        protected void btnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("~\\Default.aspx");
        }      

        protected void gvComplainCircuits_NeedDataSource(object sender, GridNeedDataSourceEventArgs e)
        {
            if (!IsPostBack)
            {
                gvComplainCircuits.DataSource = null;
            }
            else
            {
                string Format = null;

                if (cbQCFormat.Checked == true)
                {
                    Format = "QC";
                }
                else if (cbSDFormat.Checked == true)
                {
                    Format = "SD";
                }
                else
                {
                    Format = "";
                }



                int Sign = 0;
                DeptID = Convert.ToInt16(Session["DepartmentID"]);
                if (tbSignupID.Text != string.Empty)
                {
                    Sign = Convert.ToInt32(tbSignupID.Text);
                }
                else
                {
                    Sign = 0;
                }

                int SearchFollow = 0;




                System.Data.DataTable dt = objBSS.SearchComplainCircuits(tbTicketNumber.Text,
                Sign, tbCMSID.Text, tbGPID.Text, tbCircuitName.Text,
                (cmbTicketType.Text != "Select Ticket Type" ? cmbTicketType.Text : ""),
                Convert.ToInt16(cmbComplainStatus.SelectedValue),
                Convert.ToInt16(cmbCity.SelectedValue),
                Convert.ToInt16(cmbCircuitOwner.SelectedValue),
                (cmbLoggedBy.Text != "Select LoggedBy" ? cmbLoggedBy.Text : ""),
                Convert.ToInt16(cmbCaseCategory.SelectedValue),
                Convert.ToInt16(cmbInitialStatement.SelectedValue),
                Convert.ToInt16(cmbProblemDiagnosedAt.SelectedValue),
                Convert.ToInt16(cmbReasonofOutage.SelectedValue),
                dtToDate.SelectedDate.Value, dtFromDate.SelectedDate.Value,
                Convert.ToInt16(cmbCustomerCode.SelectedValue),
                Convert.ToInt16(cmbCurrentDepartment.SelectedValue),
                Convert.ToInt16(cmbNode.SelectedValue), 4,
                Format, SearchFollow, Convert.ToInt16(cmbReportedVia.SelectedValue),
                Convert.ToInt16(cmbForwardToDepartment.SelectedValue),
                Convert.ToInt16(cmbForwardByDepartment.SelectedValue),
                Convert.ToInt16(cmbForwardStatus.SelectedValue));
                dtForExcel = dt;

                lblTotalCount.Text = Convert.ToString(dt.Rows.Count);

                lblTotalCount.Visible = true;



                if (dt.Rows.Count > 0)
                {


                    gvComplainCircuits.DataSource = dt;
                    if (DeptID == 1 || DeptID == 15)
                    {
                        //gvComplainCircuits.MasterTableView.GetColumn("ComplainClosuer").Display = true;
                        //gvComplainCircuits.MasterTableView.GetColumn("col_followHis").Display = true;
                        //gvComplainCircuits.MasterTableView.GetColumn("ComplainClosuer").Display = true;
                        //gvComplainCircuits.MasterTableView.GetColumn("TicketNo").Display = false;
                    }
                    else
                    {
                      //  gvComplainCircuits.MasterTableView.GetColumn("ComplainClosuer").Display = false;
                    }

                    //gvComplainCircuits.MasterTableView.GetColumn("TicketNo").Display = false;
                    //gvComplainCircuits.MasterTableView.GetColumn("ComplaintID").Display = false;
                    //gvComplainCircuits.MasterTableView.GetColumn("NodeID").Display = false;
                    //gvComplainCircuits.MasterTableView.GetColumn("ComplaintStatusID").Display = false;
                    //gvComplainCircuits.MasterTableView.GetColumn("colfollow").Display = true;
                    //gvComplainCircuits.MasterTableView.GetColumn("colSolve").Display = true;
                    //gvComplainCircuits.MasterTableView.GetColumn("colViewHistory").Display = true;
                    //gvComplainCircuits.MasterTableView.GetColumn("InfraID").Display = false;
                    //gvComplainCircuits.MasterTableView.GetColumn("TicketNo").Display = false;
                    //ChangeToButtonColumn("SignupID", 6);
                    //ChangeToButtonColumn("TicketNo", 7);
                }
                else
                {
                    lblNoRecordFound.Enabled = true;
                    lblNoRecordFound.Visible = true;
                   
                }
            }

        }

        protected void btnSendSMS_Click(object sender, EventArgs e)
        { 
            try
            {
                if (gvComplainCircuits.Rows.Count > 0)
                {
                    foreach (GridViewRow item in gvComplainCircuits.Rows)
                    {
                        var cb = (System.Web.UI.WebControls.CheckBox)item.FindControl("cb_Select");
                        if (cb.Checked == true)
                        {
                            string msg = tbMessage.Text;
                            
                            string contactno = item.Cells[33].Text;
                            //contactno = "923212310024";
                            //if ((contactno != "") || (contactno != "O") || (contactno != "0") || (contactno != "N/A"))
                            if(msg.Contains("&"))
                            {
                                msg=msg.Replace("&", "");
                            }
                            if (contactno.Contains('-'))
                            {

                                contactno = contactno.Replace("-", "");
                            }

                            if (contactno[0] == '0' || contactno[0] == '9')
                            {

                                if (Regex.IsMatch(contactno, @"^\d{11}$") || (Regex.IsMatch(contactno, @"^\d{12}$") & contactno[0]== '9' ))
                                {
                                    if (!(Regex.IsMatch(contactno, @"^\d{12}$") & contactno[0] == '9'))
                                    {
                                        contactno = "92" + contactno.Replace("0", "");
                                    }
                                    objBSS.SendSMS("External SMS", contactno, msg, 1);
                                    
                                }
                                else
                                {
                                    lblSMSSatatus.Text = "In Selection any one number is Invalid. Format should be follow as 923422448083";
                                }
                            }
                                
                            
                            else
                            {
                                lblSMSSatatus.Text = "In Selection any one number is Invalid. Format should be follow as 923422448083";
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            }

        protected void gvComplainCircuits_RowCreated(object sender, GridViewRowEventArgs e)
        {
        //    foreach (TableCell cell in e.Row.Cells)
        //    {
                
        //        BoundField field = (BoundField)((DataControlFieldCell)cell).ContainingField;

        //        if (field.DataField == "TicketNo")
        //        {

        //            field.Visible = false;

        //        }

        //    }
            
        }

        protected void gvComplainCircuits_DataBound(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                gvComplainCircuits.DataSource = null;
            }
            else
            {
                string Format = null;

                if (cbQCFormat.Checked == true)
                {
                    Format = "QC";
                }
                else if (cbSDFormat.Checked == true)
                {
                    Format = "SD";
                }
                else
                {
                    Format = "";
                }



                int Sign = 0;
                DeptID = Convert.ToInt16(Session["DepartmentID"]);
                if (tbSignupID.Text != string.Empty)
                {
                    Sign = Convert.ToInt32(tbSignupID.Text);
                }
                else
                {
                    Sign = 0;
                }

                int SearchFollow = 0;




                System.Data.DataTable dt = objBSS.SearchComplainCircuits(tbTicketNumber.Text,
                Sign, tbCMSID.Text, tbGPID.Text, tbCircuitName.Text,
                (cmbTicketType.Text != "Select Ticket Type" ? cmbTicketType.Text : ""),
                Convert.ToInt16(cmbComplainStatus.SelectedValue),
                Convert.ToInt16(cmbCity.SelectedValue),
                Convert.ToInt16(cmbCircuitOwner.SelectedValue),
                (cmbLoggedBy.Text != "Select LoggedBy" ? cmbLoggedBy.Text : ""),
                Convert.ToInt16(cmbCaseCategory.SelectedValue),
                Convert.ToInt16(cmbInitialStatement.SelectedValue),
                Convert.ToInt16(cmbProblemDiagnosedAt.SelectedValue),
                Convert.ToInt16(cmbReasonofOutage.SelectedValue),
                dtToDate.SelectedDate.Value, dtFromDate.SelectedDate.Value,
                Convert.ToInt16(cmbCustomerCode.SelectedValue),
                Convert.ToInt16(cmbCurrentDepartment.SelectedValue),
                Convert.ToInt16(cmbNode.SelectedValue), 4,
                Format, SearchFollow, Convert.ToInt16(cmbReportedVia.SelectedValue),
                Convert.ToInt16(cmbForwardToDepartment.SelectedValue),
                Convert.ToInt16(cmbForwardByDepartment.SelectedValue),
                Convert.ToInt16(cmbForwardStatus.SelectedValue));
                dtForExcel = dt;

                lblTotalCount.Text = Convert.ToString(dt.Rows.Count);

                lblTotalCount.Visible = true;



                if (dt.Rows.Count > 0)
                {


                    gvComplainCircuits.DataSource = dt;
                    if (DeptID == 1 || DeptID == 15)
                    {
                       // gvComplainCircuits.Columns[7].Visible = false;
                        //gvComplainCircuits.MasterTableView.GetColumn("ComplainClosuer").Display = true;
                        //gvComplainCircuits.MasterTableView.GetColumn("col_followHis").Display = true;
                        //gvComplainCircuits.MasterTableView.GetColumn("ComplainClosuer").Display = true;
                        //gvComplainCircuits.MasterTableView.GetColumn("TicketNo").Display = false;
                    }
                    else
                    {
                        //  gvComplainCircuits.MasterTableView.GetColumn("ComplainClosuer").Display = false;
                    }

                    //gvComplainCircuits.MasterTableView.GetColumn("TicketNo").Display = false;
                    //gvComplainCircuits.MasterTableView.GetColumn("ComplaintID").Display = false;
                    //gvComplainCircuits.MasterTableView.GetColumn("NodeID").Display = false;
                    //gvComplainCircuits.MasterTableView.GetColumn("ComplaintStatusID").Display = false;
                    //gvComplainCircuits.MasterTableView.GetColumn("colfollow").Display = true;
                    //gvComplainCircuits.MasterTableView.GetColumn("colSolve").Display = true;
                    //gvComplainCircuits.MasterTableView.GetColumn("colViewHistory").Display = true;
                    //gvComplainCircuits.MasterTableView.GetColumn("InfraID").Display = false;
                    //gvComplainCircuits.MasterTableView.GetColumn("TicketNo").Display = false;
                    //ChangeToButtonColumn("SignupID", 6);
                    //ChangeToButtonColumn("TicketNo", 7);
                }
                else
                {
                    lblNoRecordFound.Enabled = true;
                    lblNoRecordFound.Visible = true;

                }
            }

        }


        //public bool CheckSMSNum(string contact)
        //{
        //    if(contact.Contains('-') )
        //    {
                
        //       contact= contact.Replace("-","");
        //    }

        //    if (contact[0] == '0')
        //    {

        //        if (Regex.IsMatch(contact, @"^\d{11}$"))
        //        {
        //            contact = "92" + contact.Replace("0", "");

        //            return true;
        //        }
        //    }
        //    else
        //    {
        //        return false;
        //    }
        //}
       


    }
}