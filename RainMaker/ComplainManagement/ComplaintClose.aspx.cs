using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using RainMaker.Classes;
using Telerik.Web.UI;

namespace RainMaker.ComplainManagement
{
    public partial class ComplainClose : System.Web.UI.Page
    {
        
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

        protected void gvActiveCircuits_ItemCommand(object sender, GridCommandEventArgs e)
        {

        }


        protected void Page_Load(object sender, EventArgs e)
        {
            if (this.Session["UserID"] != null)
            {
            if (!IsPostBack)
            {
                
                UserID = Convert.ToInt32(Session["UserID"]);
                RoleID = Convert.ToInt32(Session["RoleID"]);
                DeptID = Convert.ToInt32(Session["DepartmentID"]);
                //tbPersonSolvingComplain.Text = Session["Name"].ToString();
                EngineerName = Session["Name"].ToString();
                complaintID = Convert.ToInt32(base.Request.QueryString["ComplainID"]);
               // lblDateTime.Text = Convert.ToString(DateTime.Now);
                lblstatus.Visible = false;
                lblSucessCount.Visible = false;
                lblFailedCount.Visible = false;
               frmOts_ComplainClousrevb_Load();

                
            }
            }
            else
            {
                Response.Redirect("/Login.aspx", true);
            }

        }

        private void frmOts_ComplainClousrevb_Load()
        {
            try
            {
                LoadMyCombos("Complain Closure");
                tbComplainTicketNo.Text = Session["TicketNo"].ToString();
                GetComplainDetails(complaintID);
                loadGridView();
            }
            catch (Exception ex)
            {
                //  Interaction.MsgBox("frmOts_ComplainClousrevb_Load:" + ex.Message + "of frmOts_ComplainClousrevb ", MsgBoxStyle.Critical, "BSS Addminstrator");
            }
        }

        public void loadGridView()
        {
            
                try
                {
                    int Count = 0;
                    string Modified_Tick = string.Empty;
                    if (TicketTypeID != 6 & TicketTypeID != 0)
                    {
                        string[] str = tbComplainTicketNo.Text.Split('-');
                        Modified_Tick = "0" + "-" + "1" + "-" + "2";
                        Count = 4;
                        dt = objBSS.SearchComplainCircuits(Modified_Tick, 0, "", "", "", "", 1, 0, 0, "",
                        0, 0, 0, 0, Convert.ToDateTime("1/1/1900"), Convert.ToDateTime("1/1/1900"), 0, 0, 0, Count,
                        "", 0, 0, 0, 0, 0);

                    }
                    else if (TicketTypeID == 6)
                    {
                        Modified_Tick = tbComplainTicketNo.Text;
                        Count = 3;
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
                    }
                    else
                    {
                        //  lblCount.Text = "0";
                        gvActiveCircuits.DataSource = null;
                        gvActiveCircuits.DataBind();
                    }

                
                }
                catch (Exception ex)
                {
                    throw ex;
                }

            

        }
       
        private void LoadMyCombos(string click)
        {
            if (click == "Complain Closure")
            {
                try
                {
                    objBL.loadAssignedDepartment(cmbAssignedtoDepartment, "Close");
                    cmbAssignedtoDepartment.SelectedValue = "8";
                    cmbAssignedtoDepartment.Enabled = false;
                    objBL.LoadComplainStatus(cmbComplaintStatus, "All");
                    cmbComplaintStatus.SelectedValue = "5";
                    //cmbComplaintStatus.Text = "Closed";
                    //cmbComplaintStatus.SelectedValue = "5";
                    cmbComplaintStatus.Enabled = false;
                    FurtherAction.Enabled = false;

                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
           
        }

        protected void btnviewDetails_Click(object sender, EventArgs e)
        {
            Response.Redirect("~\\ComplainManagement\\ComplainForm.aspx?SignupID=" + Convert.ToInt32(Session["SignupID"]) + "&ComplainID=" + complaintID + "&Flag=View");
        }

        protected void rbRe_CheckedChanged(object sender, EventArgs e)
        {
            try 
            {
                objBL.loadAssignedDepartment(cmbAssignedtoDepartment, "Follow");
                objBL.LoadComplainStatus(cmbComplaintStatus, "All");
                cmbComplaintStatus.SelectedValue = "4";
                cmbComplaintStatus.Enabled = false;
                cmbAssignedtoDepartment.Enabled = true;
                cmbAssignedtoDepartment.SelectedValue = "0";
               
            } 
            catch (Exception ex)
            {
            }

        }

        protected void rbN_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                objBL.loadAssignedDepartment(cmbAssignedtoDepartment, "Close");
                objBL.LoadComplainStatus(cmbComplaintStatus, "All");
                cmbAssignedtoDepartment.SelectedValue = "8";
                cmbAssignedtoDepartment.Enabled = false;    
                cmbComplaintStatus.SelectedValue = "5";
                cmbComplaintStatus.Enabled = false;

            }
            catch (Exception ex)
            { 
            }
        }

        protected void rbCustomerFeedback_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (rbCustomerFeedback.SelectedValue.Equals("Negative"))
            {
                FurtherAction.Enabled = true;     
                cmbAssignedtoDepartment.Enabled =true;
                cmbComplaintStatus.SelectedValue = "4";              
            }

            if (rbCustomerFeedback.SelectedValue.Equals("Positive"))
            {
                FurtherAction.Enabled = false;
                rbN.Checked = true;
                objBL.loadAssignedDepartment(cmbAssignedtoDepartment, "Close");
                objBL.LoadComplainStatus(cmbComplaintStatus, "All");
                cmbAssignedtoDepartment.SelectedValue = "8";
                cmbAssignedtoDepartment.Enabled = false;
                cmbComplaintStatus.SelectedValue = "5";
                cmbComplaintStatus.Enabled = false;
                
            }
        }

        protected void gvActiveCircuits_NeedDataSource(object sender, GridNeedDataSourceEventArgs e)
        {
            //dynamic dt = objBSS.GetComplainDetailByComplainID(Convert.ToInt32(Session["ComplainID"]));
            //gvActiveCircuits.DataSource = dt;
        }

        public void GetComplainDetails(int ComplainID)
        {
            try
            {
                dynamic dt = objBSS.GetComplainDetailByComplainID(ComplainID);
                if (dt.Rows.Count > 0)
                {
                    //tbTicketNo.Text = dt.Rows(0)("TicketNo");
                    tbComplainTicketNo.Text = dt.Rows[0]["TicketNo"];
                    tbComplainLoggedBy.Text = dt.Rows[0]["LoggedBy"];
                    ComplainStatusID = dt.Rows[0]["ComplaintStatusID"];
                    TicketTypeID = dt.Rows[0]["TicketTypeID"];
                    tbRemarks.Text = dt.Rows[0]["Remarks"];
                    int SignUpId = dt.Rows[0]["SignUpID"];

                    

                    if (TicketTypeID == 6)
                    {
                        cbCheckAll.Enabled = false;
                    }

                    //if (ComplainStatusID == 5 | ComplainStatusID == 1)
                    if (ComplainStatusID.Equals(5))
                    {
                        //btnUpdate.Visible = false;
                    }

                    //else
                    //{
                    //    btnUpdate.Visible = true;
                    //}

                    tbComplainStatus.Text = dt.Rows[0]["ComplainStatus"];
                    cmbAssignedtoDepartment.SelectedValue = Convert.ToString(dt.Rows[0]["AssignedDeptID"]);
                   
                    
                    tbComplaintReceivedDT.Text = Convert.ToString(dt.Rows[0]["ComplaintReceivedDate"]);
                    AppDomain.CurrentDomain.SetData("LastUpdatedDate", Convert.ToDateTime(dt.Rows[0]["LastUpdatedDate"]));
                    
                    
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected void btnviewFiberHistory_Click(object sender, EventArgs e)
        {
           
            Response.Redirect("~\\ComplainManagement\\ViewFiberDetails.aspx?SignupID=" + Convert.ToInt32(Session["SignupID"]));
        
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

        public bool UpdateComplainDetails(int CompID)
        {
            
                try
                {
                    int ComplainID = CompID;
                    string TicketNo = tbComplainTicketNo.Text;
                    int ComplaintStatusID = ComplainStatusID;
                    int AssignedByDeptID = DeptID;
                    int AssignedToDeptID = AssginedDepart;
                    string AssignedToPersonName = Session["Name"].ToString();
                    string AssignedByPersonName = Session["Name"].ToString();
                    DateTime LastUpdatedDate = DateTime.Now;
                    DateTime ETA = DateTime.Now;
                    string PersonGivenETA = "";
                    DateTime ETTR = DateTime.Now;
                    string PersonSolving = "";
                    DateTime ComplainSolvingDate = DateTime.Now;
                    string FCR = "";
                    int ProblemDignoseEndID = 5;
                    int ReasonOutageID = 187;
                    string Dignose_Causes = "";
                    string Dignose_RootCauseAnalysis = "";
                    string Dignose_PreventativeMeasureTake = "";
                    string LastMileInfraID = "29";
                    string CustomerFeedBack = rbCustomerFeedback.SelectedValue;
                    string FurtherAction = (rbRe.Checked == true ? "Re-Initiated" : (rbNewComplaintLogged.Checked == true ? "New Complaint Logged" : "N/A"));

                    string NewComplainRef = tbNewComplaintReference.Text;
                    string QueryResponses = "";

                    string strWithTabsQR = tbRemarks.Text;
                    string lineQR = strWithTabsQR.Replace("\t", " ");
                    tbRemarks.Text = lineQR.Replace("\r\n", " ");


                    string Remarks = tbRemarks.Text;
                    int TransactionBy = UserID;

                    //if(rbN.Checked==true)
                    //{
                    //    FurtherAction="N/A";
                    //}
                    //else if (rbRe.Checked == true)
                    //{
                    //    FurtherAction = "Re-Initiated";
                    //}
                    //else if (rbNewComplaintLogged.Checked == true)
                    //{
                    //    FurtherAction = "New Complaint Logged";
                    //}

                    if (objBSS.UpdateComplain(ComplainID, TicketNo, ComplaintStatusID, AssignedByDeptID, AssignedToDeptID, AssignedToPersonName, AssignedByPersonName, LastUpdatedDate, ETA, PersonGivenETA,
                    ETTR, PersonSolving, ComplainSolvingDate, FCR, ProblemDignoseEndID, ReasonOutageID, Dignose_Causes, Dignose_RootCauseAnalysis, Dignose_PreventativeMeasureTake, Convert.ToInt32(LastMileInfraID),

                    CustomerFeedBack, FurtherAction, NewComplainRef, QueryResponses, Remarks, "", "", "", 1, 0, TransactionBy))
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
                
            
            

        }

     
        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            btnUpdate.Enabled = false;
            this.Visible = false;
            CheckCustomerSelect();
            if (rbCustomerFeedback.SelectedValue == "Positive")
            {
                AssginedDepart = 8;
                ComplainStatusID = 5;
            }
            else if (rbCustomerFeedback.SelectedValue == "Negative" && rbNewComplaintLogged.Checked == true)
            {
                AssginedDepart = 8;
                ComplainStatusID = 5;
            }
            else if (rbCustomerFeedback.SelectedValue == "Negative" & rbRe.Checked == true)
            {
                AssginedDepart = Convert.ToInt32(cmbAssignedtoDepartment.SelectedValue);
                ComplainStatusID = 4;
            }

            if (gvActiveCircuits.Rows.Count > 0)
            {
                foreach (GridViewRow item in gvActiveCircuits.Rows)
                {
                    int ComplainIDGridView = 0;
                    CheckBox CheckBox1 = item.FindControl("cb_Select") as CheckBox;
                    if (CheckBox1 != null && CheckBox1.Checked)
                    {
                        //string strKey = item.GetDataKeyValue("ComplaintID").ToString();
                        ComplainIDGridView = Convert.ToInt32(item.Cells[1].Text);
                        if (UpdateComplainDetails(ComplainIDGridView))
                        {
                            CircuitCount = CircuitCount + 1;
                        }
                        else
                        {
                            FailedCount = FailedCount + 1;
                        }
                        //    }
                        //}
                        CheckCustomerSelect();


                        if (CircuitCount > 0)
                        {
                            gvActiveCircuits.DataSource = null;
                            loadGridView();
                            lblSucessCount.Text = "Solve Count : " + Convert.ToString(CircuitCount);
                            lblFailedCount.Text = "Failed Count: " + Convert.ToString(FailedCount);
                            
                            lblTotalCount.Visible = true;
                            lblstatus.Visible = true;
                            lblSucessCount.Visible = true;
                            lblFailedCount.Visible = true;             
                            lblstatus.Text = "Record Save Sucessfully";
                            this.Visible = true;
                            btnUpdate.Enabled = true;
                        }
                        else

                        {
                            lblstatus.Text = "None of any Complain Updated please try Again";
                            lblstatus.Visible = true;
                            btnUpdate.Enabled = true;
                            this.Visible = true;
                          
                           
                        }
                    }

                    else
                    {

                        lblstatus.Text = "None of any Complain Updated please select the complain from the grid";
                        lblstatus.Visible = true;
                        btnUpdate.Enabled = true;
                        this.Visible = true;
                    }
                }
            }

            else
            {
                btnUpdate.Enabled = true;
                //lblstatus.Text = "There is no Circuits in Grid view";
                //lblstatus.Visible = true;
            }
        }

        protected void btnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("~\\ComplainManagement\\ComplainManager.aspx");
        }

       
    }
}