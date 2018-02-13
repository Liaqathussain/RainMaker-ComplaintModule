using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using RainMaker.Classes;
using Telerik.Web.UI;
using System.IO;

namespace RainMaker.ComplainManagement
{
    public partial class ComplainForward : System.Web.UI.Page
    {
        public static string click = "";
        static int ComplainStatusID = 0;
        static int AssignmentDeptID = 0;
        static int TicketTypeID = 0;
        static int DataGridCount = 0;
        static int UserID = 0;
        static int RoleID = 0;
        static int DeptID = 0;
        static DataTable dt = new DataTable();
        int CircuitCount = 0;
        string RequestTypeAtNE = "";
        int FailedCount = 0;
        int SelectCount = 0;
        int AssginedDepart;
        string EngineerName = null;
        int complaintID = 0;
        BSS_Service.Service1SoapClient objBSS = new BSS_Service.Service1SoapClient();
        //BSS_ServiceLocal.Service1SoapClient objBSS = new BSS_ServiceLocal.Service1SoapClient();
        Cls_Territory objCls = new Cls_Territory();
        BL objBL = new BL();
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {

                if (!IsPostBack)
                {

                    click = "Complain Forward";
                    UserID = Convert.ToInt32(Session["UserID"]);
                    RoleID = Convert.ToInt32(Session["RoleID"]);
                    DeptID = Convert.ToInt32(Session["DepartmentID"]);

                    EngineerName = Session["Name"].ToString();

                    //complaintID=(Convert.ToInt32(Session["ComplainID"]));
                    complaintID = Convert.ToInt32(base.Request.QueryString["ComplainID"]);

                    //pnlComplainInProcessForm.Visible = true;


                    dynamic dt = objBSS.GetComplainDetailByComplainID(complaintID);
                    if (Convert.ToInt32(Session["DepartmentID"]).Equals(1) || Convert.ToInt32(Session["DepartmentID"]).Equals(3))
                    {
                        tbIPResponses.ReadOnly = false;
                        PnlRequestType.Visible = true;
                        //lblRequest.Visible = true;
                        //RadioRequestTypeNE.Visible = true;
                    }
                    else
                    {
                        tbIPResponses.ReadOnly = true;
                        PnlRequestType.Visible = false;
                        //lblRequest.Visible = false;
                    }
                    LoadMyCombos(click);
                    if (dt.Rows.Count > 0)
                    {

                        ViewState["Pic1"] = dt.Rows[0]["Picture1"].ToString();
                        ViewState["Pic2"] = dt.Rows[0]["Picture2"].ToString();

                        if (dt.Rows.Count < 2)
                        {
                            cbCheckAll.Enabled = false;
                        }


                        objBL.LoadComplainStatus(cmbComplainStatus, "Follow");
                        objBL.loadAssignedDepartment(cmbAssignedDepartment, "Follow");
                        tbLoggedBy0.Text = Session["Name"].ToString();
                        if (Convert.ToString(dt.Rows[0]["ETTR"]) != "")
                        {
                            RadDateTimePicker1.SelectedDate = (DateTime)dt.Rows[0]["ETTR"]; //(DateTime)Session["ETTR"];
                        }
                        if (Convert.ToString(dt.Rows[0]["ETA"]) != "")
                        {
                            RadDateTimePicker3.SelectedDate = (DateTime)dt.Rows[0]["ETA"]; //(DateTime)Session["ETA"];
                        }
                        tbInternalRemarks.Text = dt.Rows[0]["Remarks"]; //Session["Remarks"].ToString();

                        this.tbComplainTicketNo.Text = dt.Rows[0]["TicketNo"];
                        tbComplainLoggedBy.Text = dt.Rows[0]["LoggedBy"];
                        ComplainStatusID = dt.Rows[0]["ComplaintStatusID"];
                        tbComplaintReceivedDT.Text = Convert.ToString(dt.Rows[0]["ComplaintReceivedDate"]);
                        tbComplainStatus.Text = dt.Rows[0]["ComplainStatus"];

                        cmbAssignedDepartment.Text = dt.Rows[0]["AssignDepartment"];
                        cmbAssignedDepartment.SelectedValue = Convert.ToString(dt.Rows[0]["AssignedDeptID"]);

                        cmbComplainStatus.Text = dt.Rows[0]["ComplainStatus"];
                        cmbComplainStatus.SelectedValue = Convert.ToString(dt.Rows[0]["ComplaintStatusID"]);

                        tbLoggedBy0.ReadOnly = true;

                        TicketTypeID = Convert.ToInt32(dt.Rows[0]["TicketTypeID"]);
                        if (TicketTypeID == 6)
                        {
                            cbCheckAll.Enabled = false;
                        }

                        if (ComplainStatusID.Equals(1) || ComplainStatusID.Equals(5))
                        {
                            btnUpdate.Visible = false;
                        }

                        if (ComplainStatusID.Equals("6"))
                        {
                            cmbAssignedDepartment.Enabled = false;
                        }

                        tbInternalRemarks.Text = dt.Rows[0]["Remarks"];
                        if (Convert.ToString(dt.Rows[0]["LastUpdatedDate"]) != "")
                        {
                            AppDomain.CurrentDomain.SetData("LastUpdatedDate", Convert.ToDateTime(dt.Rows[0]["LastUpdatedDate"]));
                        }
                        if (dt.Rows[0]["ComplaintStatusID"] == 4)
                        {

                            EngineerName = Session["Name"].ToString();

                            tbComplainLoggedBy.Text = dt.Rows[0]["PersonGivenETA"];
                            RadDateTimePicker3.SelectedDate = dt.Rows[0]["ETA"];
                            RadDateTimePicker1.SelectedDate = dt.Rows[0]["ETTR"];
                            tbIPResponses.Text = dt.Rows[0]["QueryResponse"];
                            if (dt.Rows[0]["RequestTypeAtNE"] == "Support Request")
                            {
                                SupportRequest.Checked = true;
                            }
                            else if (dt.Rows[0]["RequestTypeAtNE"] == "Service Request")
                            {
                                ServiceRequest.Checked = true;
                            }

                        }
                        loadGridView(click);
                    }
                    else
                    {
                        ViewState["Pic1"] = "";
                        ViewState["Pic2"] = "";
                    }


                }

            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        private void LoadMyCombos(string click)
        {



            try
            {
                objBL.loadAssignedDepartment(cmbAssignedDepartment, "Follow");
                objBL.LoadComplainStatus(cmbComplainStatus, "Follow");
                cmbComplainStatus.SelectedValue = "4";


                if (Convert.ToInt32(Session["DeptID"]) == 15 | Convert.ToInt32(Session["DeptID"]) == 1)
                {
                    cmbAssignedDepartment.Enabled = true;
                }



                if (Convert.ToInt32(Session["DepartmentID"]).Equals(1) || Convert.ToInt32(Session["DepartmentID"]).Equals(58) || Convert.ToInt32(Session["DepartmentID"]).Equals(59) || Convert.ToInt32(Session["DepartmentID"]).Equals(60))
                {
                    pnlEscalation.Visible = true;
                    DataTable DTTeam = objBSS.GetTeamList();
                    cmbTeam.DataSource = DTTeam;

                    cmbTeam.DataTextField = "TeamName";
                    cmbTeam.DataValueField = "TeamID";
                    //cmbTeam.Items.Insert(0, new DropDownList("Please Select", "0"));
                    cmbTeam.DataBind();


                    //DataTable DTPriority = objCls.GetPriority(); 
                    DataTable DTPriority = objBSS.GetTeamPrioirty();
                    cmbPriority.DataSource = DTPriority;
                    cmbPriority.DataTextField = "OMPriorityName";
                    cmbPriority.DataValueField = "OMPriorityID";
                    //cmbPriority.Items.Insert(0, new RadComboBoxItem("Please Select", "0"));
                    cmbPriority.DataBind();

                }
                else
                {
                    cmbTeam.SelectedValue = "0";
                    cmbPriority.SelectedValue = "0";
                    pnlEscalation.Visible = false;
                }



            }
            catch (Exception ex)
            {
                throw ex;
            }



        }

        public void loadGridView(string click)
        {
            try
            {


                int Count = 0;
                string Modified_Tick = string.Empty;
                //if (Convert.ToInt32(Session["TicketTypeID"]) != 6 & Convert.ToInt32(Session["TicketTypeID"]) != 0)
                if (TicketTypeID != 6 & TicketTypeID != 0)
                {
                    //string[] str = tbComplainTicketNo.Text.Split("-");
                    string split = tbComplainTicketNo.Text;
                    string[] str = split.Split('-');
                    Count = 4;
                    Modified_Tick = string.Concat(str[0]) + "-" + string.Concat(str[1]) + "-" + string.Concat(str[2]);
                    dt = objBSS.SearchComplainCircuits(Modified_Tick, 0, "", "", "", "", 0, 0, 0, "",
                    0, 0, 0, 0, Convert.ToDateTime("1/1/1900"), Convert.ToDateTime("1/1/1900"), 0, 0, 0, Count,
                    "", 0, 0, 0, 0, 0);
                }
                else if (TicketTypeID == 6)
                {
                    Count = 3;
                    Modified_Tick = tbComplainTicketNo.Text;
                    dt = objBSS.SearchComplainCircuits(Modified_Tick, 0, "", "", "", "", 0, 0, 0, "",
                    0, 0, 0, 0, Convert.ToDateTime("1/1/1900"), Convert.ToDateTime("1/1/1900"), 0, 0, 0, Count,
                    "", 0, 0, 0, 0, 0);
                }


                DataGridCount = dt.Rows.Count;
                if (dt.Rows.Count > 0)
                {
                    lblTotalCount.Text = Convert.ToString(dt.Rows.Count);
                    gvActiveCircuits.DataSource = dt;
                    gvActiveCircuits.DataBind();
                    //GridViewRowInfo lastRow1 = RadGrid1.Rows[RadGrid1.Rows.Count - 1];
                    //lastRow1.IsSelected = true;

                    //foreach (GridViewRow row in GridView1.Rows)
                    //{

                    //    //string abc = row.Cells[3].Text;
                    //    if (row.Cells[5].Text == "Solved")
                    //    {

                    //    }
                    //}
                }
                else
                {
                    lblTotalCount.Text = "0";
                    gvActiveCircuits.DataSource = null;
                    //RadGrid1.Rows.clear();
                }
            }
            catch (Exception)
            {

                throw;
            }
        }



        protected void cmbComplainStatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (Convert.ToInt32(cmbComplainStatus.SelectedValue) == 6)
                {
                    //cmbAssignedDepartment.SelectedValue = "15";
                    //cmbAssignedDepartment.Enabled = false;

                    cmbAssignedDepartment.SelectedValue = "15";
                    cmbAssignedDepartment.Enabled = false;

                }
                else if (Convert.ToInt32(cmbComplainStatus.SelectedValue) == 4)
                {
                    //
                    cmbAssignedDepartment.SelectedValue = AssignmentDeptID.ToString();
                    cmbAssignedDepartment.Enabled = true;
                }
            }
            catch (Exception ex)
            {

            }

        }

        protected void cmbAssignedDepartment_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        //protected void btnSave_Click(object sender, EventArgs e)
        //{
        //    try
        //    {


        //    string[] Attachment = new string[2];
        //    Attachment[0] = "";
        //    Attachment[1] = "";
        //    int count = 1;
        //    if (RadAsyncUpload1.UploadedFiles.Count > 0)
        //    {
        //        foreach (UploadedFile file in RadAsyncUpload1.UploadedFiles)
        //        {
        //            //String targetFolder = Server.MapPath("~/Folder/");
        //            String targetFolder = Server.MapPath("~/Resorces/");

        //            //file.SaveAs(targetFolder);

        //            if (count == 1)
        //            {
        //                file.SaveAs(Path.Combine(targetFolder, tbComplainTicketNo.Text + "-P1.JPG"));
        //                Attachment[0] = tbComplainTicketNo.Text + "-P1.JPG";
        //                ViewState["Pic1"] = Attachment[0];
        //            }
        //            else
        //            {
        //                file.SaveAs(Path.Combine(targetFolder, tbComplainTicketNo.Text + "-P2.JPG"));
        //                Attachment[1] = tbComplainTicketNo.Text + "-P2.JPG";
        //                ViewState["Pic2"] = Attachment[1];
        //            }
        //            count = count + 1;
        //            //
        //        }
        //    }
        //    else
        //    {
        //        Attachment[0] = "";
        //        Attachment[1] = "";
        //    }

        //}
        //    catch (Exception)
        //    {

        //        throw;
        //    }
        //}

        protected void ShowPic_Click(object sender, EventArgs e)
        {
            try
            {


                if (string.IsNullOrEmpty(tbComplainTicketNo.Text))
                {
                }
                else
                {
                    Response.Clear();
                    Response.ContentType = "application/octet-stream";
                    Response.AddHeader("Content-Disposition", "attachment; filename=\" " + tbComplainTicketNo.Text + "-P1.JPG");
                    Response.TransmitFile(HttpContext.Current.Server.MapPath("~/Resorces/" + tbComplainTicketNo.Text + "-P1.JPG"));
                    //view_pic1.ImageUrl = "~/Resorces/" + tbComplainTicketNo.Text + "-P1.JPG";
                    Response.End();
                }
            }
            catch (Exception ex)
            {


            }
        }

        protected void ShowPic2_Click(object sender, EventArgs e)
        {
            try
            {


                if (string.IsNullOrEmpty(tbComplainTicketNo.Text))
                {
                }
                else
                {
                    Response.Clear();
                    Response.ContentType = "application/octet-stream";
                    Response.AddHeader("Content-Disposition", "attachment; filename=\" " + tbComplainTicketNo.Text + "-P2.JPG");
                    Response.TransmitFile(HttpContext.Current.Server.MapPath("~/Resorces/" + tbComplainTicketNo.Text + "-P2.JPG"));
                    //view_pic1.ImageUrl = "~/Resorces/" + tbComplainTicketNo.Text + "-P2.JPG";
                    Response.End();
                }
            }
            catch (Exception ex)
            {


            }

        }


        protected void btnviewDetails_Click(object sender, EventArgs e)
        {
            Response.Redirect("~\\ComplainManagement\\ComplainForm.aspx?SignupID=" + Convert.ToInt32(Session["SignupID"]) + "&ComplainID=" + complaintID + "&Flag=View");

        }

        private bool UpdateComplainDetails(int CompID)
        {
            try
            {
                int ComplainID = CompID;
                string TicketNo = tbComplainTicketNo.Text;
                int ComplaintStatusID = Convert.ToInt32(cmbComplainStatus.SelectedValue);
                int AssignedByDeptID = DeptID;
                int AssignedToDeptID = Convert.ToInt32(cmbAssignedDepartment.SelectedValue);
                string AssignedToPersonName = tbLoggedBy0.Text;
                string AssignedByPersonName = tbLoggedBy0.Text;
                DateTime LastUpdatedDate = Convert.ToDateTime(AppDomain.CurrentDomain.GetData("LastUpdatedDate"));
                DateTime ETA = Convert.ToDateTime(RadDateTimePicker1.SelectedDate);
                string PersonGivenETA = tbLoggedBy0.Text;
                DateTime ETTR = Convert.ToDateTime(RadDateTimePicker3.SelectedDate);
                string PersonSolving = "";
                DateTime ComplainSolvingDate = Convert.ToDateTime("1/1/1990");
                string FCR = "";
                int ProblemDignoseEndID = 5;
                int ReasonOutageID = 187;
                string Dignose_Causes = "";
                string Dignose_RootCauseAnalysis = "";
                string Dignose_PreventativeMeasureTake = "";
                string LastMileInfraID = "29";
                string CustomerFeedBack = "";
                string FurtherAction = "";
                string NewComplainRef = "";

                string strWithTabsQR = tbIPResponses.Text;
                string lineQR = strWithTabsQR.Replace("\t", " ");
                tbIPResponses.Text = lineQR.Replace("\r\n", " ");

                string QueryResponses = tbIPResponses.Text;

                string strInternal = tbInternalRemarks.Text;
                string lineInternal = strInternal.Replace("\t", " ");
                tbInternalRemarks.Text = lineInternal.Replace("\r\n", " ");

                string Remarks = tbInternalRemarks.Text;

                if (SupportRequest.Checked == true)
                {
                    RequestTypeAtNE = "Support Request";

                }
                else if (ServiceRequest.Checked == true)
                {
                    RequestTypeAtNE = "Service Request";

                }
                else if (SupportRequest.Checked == false & ServiceRequest.Checked == false)
                {
                    RequestTypeAtNE = "";
                }
                int teamid = 0;
                int teampriority = 0;

                if (DeptID == 1 || DeptID == 58 || DeptID == 59 || DeptID == 60)
                {
                    teamid = Convert.ToInt32(cmbTeam.SelectedValue);
                    teampriority = Convert.ToInt32(cmbPriority.SelectedValue);

                }
                else
                {
                    teamid = 1;
                    teampriority = 0;
                }



                int TransactionBy = Convert.ToInt32(Session["UserID"]);

                /*if (objBSS.UpdateComplain(ComplainID, TicketNo, ComplaintStatusID, AssignedByDeptID, AssignedToDeptID, AssignedToPersonName, AssignedByPersonName, LastUpdatedDate, ETA, PersonGivenETA,
                ETTR, PersonSolving, ComplainSolvingDate, FCR, ProblemDignoseEndID, ReasonOutageID, Dignose_Causes, Dignose_RootCauseAnalysis, Dignose_PreventativeMeasureTake, Convert.ToInt32(LastMileInfraID),

                CustomerFeedBack, FurtherAction, NewComplainRef, QueryResponses, Remarks, RequestTypeAtNE, "" ,"",1,0, TransactionBy))*/

                if (objBSS.UpdateComplain(ComplainID, TicketNo, ComplaintStatusID, AssignedByDeptID, AssignedToDeptID, AssignedToPersonName, AssignedByPersonName, LastUpdatedDate, ETA, PersonGivenETA,
               ETTR, PersonSolving, ComplainSolvingDate, FCR, ProblemDignoseEndID, ReasonOutageID, Dignose_Causes, Dignose_RootCauseAnalysis, Dignose_PreventativeMeasureTake, Convert.ToInt32(LastMileInfraID),
               CustomerFeedBack, FurtherAction, NewComplainRef, QueryResponses, Remarks, RequestTypeAtNE, ViewState["Pic1"].ToString(), ViewState["Pic2"].ToString(), teamid, teampriority, TransactionBy))

                //     if (objBSS.UpdateComplain(ComplainID, TicketNo, ComplaintStatusID, AssignedByDeptID, AssignedToDeptID, AssignedToPersonName, AssignedByPersonName, LastUpdatedDate, ETA, PersonGivenETA,
                //ETTR, PersonSolving, ComplainSolvingDate, FCR, ProblemDignoseEndID, ReasonOutageID, Dignose_Causes, Dignose_RootCauseAnalysis, Dignose_PreventativeMeasureTake, Convert.ToInt32(LastMileInfraID),

                //CustomerFeedBack, FurtherAction, NewComplainRef, QueryResponses, Remarks, RequestTypeAtNE, ViewState["Pic1"].ToString(), ViewState["Pic2"].ToString(), Convert.ToInt32(ViewState["TeamID"]), Convert.ToInt32(ViewState["PriorityID"]), TransactionBy))
                {
                    return true;
                }
                else
                {
                    return false;

                }

            }
            catch (Exception ex)
            {
                throw ex;
            }


            return true;
        }

        public bool CheckCustomerSelect()
        {
            bool @bool = false;

            try
            {
                foreach (GridViewRow item in gvActiveCircuits.Rows)
                {
                    var cb = (CheckBox)item.FindControl("cb_Select");
                    if (cb.Checked == true)
                    {
                        @bool = true;
                        SelectCount = SelectCount + 1;
                    }
                }

                if (!@bool)
                {
                    //Interaction.MsgBox("Please Select Atleast one Clients", MsgBoxStyle.Critical, Title: "Message Box");
                    return @bool;
                }

            }
            catch (Exception ex)
            {
                //Interaction.MsgBox(ex.Message, MsgBoxStyle.Critical, Title: "Message Box");
            }
            return @bool;
        }


        protected void btnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("~\\ComplainManagement\\ComplainManager.aspx");
        }

        protected void btUpdateComplain_Click(object sender, EventArgs e)
        {

            btnUpdate.Enabled = false;
            if (Convert.ToInt32(cmbAssignedDepartment.SelectedValue) == 0 | Convert.ToInt32(cmbComplainStatus.SelectedValue) == 0)
            {
                lblstatus.Text = "Please Select all validate fields";
                lblstatus.Visible = true;
                btnUpdate.Enabled = true;
            }

            if (tbLoggedBy0.Text == string.Empty)
            {
                lblstatus.Text = "Please Select all validate fields";
                lblstatus.Visible = true;
                btnUpdate.Enabled = true;
            }

            if (Convert.ToInt32(Session["DeptID"]) == 3)
            {
                if (SupportRequest.Checked == true)
                {
                    Session["1"] = 1;
                }


                if (SupportRequest.Checked == false & ServiceRequest.Checked == false)
                {
                    lblstatus.Text = "Please Select Request Type before Forwading complain";
                    lblstatus.Visible = true;
                    btnUpdate.Enabled = true;
                }

            }


            if (Convert.ToInt32(Session["DepartmentID"]).Equals(1) || Convert.ToInt32(Session["DepartmentID"]).Equals(58) || Convert.ToInt32(Session["DepartmentID"]).Equals(59) || Convert.ToInt32(Session["DepartmentID"]).Equals(60))
            {
                if (Convert.ToInt32(cmbTeam.SelectedValue) == 0)
                {
                    lblstatus.Text = "Please Select Team before Forwading complain";
                    lblstatus.Visible = true;
                    btnUpdate.Enabled = true;
                }


                if (Convert.ToInt32(cmbPriority.SelectedValue) == 0)
                {
                    lblstatus.Text = "Please Select Priority before Forwading complain";
                    lblstatus.Visible = true;
                    btnUpdate.Enabled = true;
                }

            }
            

                foreach (GridViewRow item in gvActiveCircuits.Rows)
                {
                    int ComplainIDGridView = Convert.ToInt32(item.Cells[1].Text);
                    
                    CheckBox CheckBox1 = item.FindControl("cb_Select") as CheckBox;
                    if (CheckBox1 != null && CheckBox1.Checked)
                    {
                        ComplainIDGridView = Convert.ToInt32(item.Cells[1].Text);
                        if (UpdateComplainDetails(ComplainIDGridView))
                        {
                            CircuitCount = CircuitCount + 1;
                        }
                        else
                        {
                            FailedCount = FailedCount + 1;
                            lblstatus.Text = "Transaction failed";
                        }
                            }
                        }
                        CheckCustomerSelect();


                        if (CircuitCount > 0)
                        {
                            loadGridView(click);

                            lblTotalCount.Text = "Total Count : " + Convert.ToString(SelectCount);
                            lblSucessCount.Text = "Solve Count : " + Convert.ToString(CircuitCount);
                            lblFailedCount.Text = "Failed Count: " + Convert.ToString(FailedCount);

                            lblTotalCount.Visible = true;
                            lblstatus.Visible = true;
                            lblSucessCount.Visible = true;
                            lblFailedCount.Visible = true;
                            //this.Close();
                            lblstatus.Text = "Record Save Sucessfully";
                            btnUpdate.Enabled = true;
                            if (DataGridCount == 0)
                            {
                                //this.Close();
                                btnUpdate.Enabled = true;
                            }
                        }
                        else
                        {
                            lblstatus.Text = "None of any Complain Updated please try Again";
                            lblstatus.Visible = true;
                            btnUpdate.Enabled = true;
                        }
                    

                   



                }
    }
}

            
        
        

