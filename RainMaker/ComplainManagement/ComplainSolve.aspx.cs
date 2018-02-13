using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using RainMaker.Classes;
using System.Data;
using Telerik.Web.UI;

namespace RainMaker.ComplainManagement
{
    public partial class ComplainSolve : System.Web.UI.Page
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
            if (!IsPostBack)
            {
                
                UserID = Convert.ToInt32(Session["UserID"]);
                RoleID = Convert.ToInt32(Session["RoleID"]);
                DeptID = Convert.ToInt32(Session["DepartmentID"]);
                tbPersonSolvingComplain.Text = Session["Name"].ToString();
                EngineerName = Session["Name"].ToString();
                complaintID = Convert.ToInt32(base.Request.QueryString["ComplainID"]);
                lblstatus.Visible = false;
                lblSucessCount.Visible = false;
                lblFailedCount.Visible = false;
                Panel1.Visible = false;

                
                   
                    LoadMyCombos();
                    //GetComplainDetails(Convert.ToInt32(Session["ComplainID"]));
                    GetComplainDetails(complaintID);
                    loadGridView();

                

            }
        }


        private void LoadMyCombos()
        {
            
                try
                {
                   
                    objBL.LoadComplainStatus(cmbComplainStatus, "All");
                    objBL.loadAssignedDepartment(cmbAssignedDepartment, "Solve");
                    objBL.loadTypeDescbyOwnerID(cmbLastMileInfra, 0);
                    cmbAssignedDepartment.SelectedValue = "61";
                    cmbAssignedDepartment.Enabled = false;
                    cmbComplainStatus.SelectedValue = "1";
                    cmbComplainStatus.Enabled = false;
                    
                   
                }
                catch (Exception ex)
                {
                    throw ex;
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
                        //string[] str = tbComplainTicketNo.Text.Split(

                        string split = tbComplainTicketNo.Text;
                        string[] str = split.Split('-');
                        Count = 4;
                        Modified_Tick = string.Concat(str[0]) + "-" + string.Concat(str[1]) + "-" + string.Concat(str[2]);
                        dt = objBSS.SearchComplainCircuits(Modified_Tick, 0, "", "", "", "", 4, 0, 0, "",
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
                    }
                    else
                    {
                        lblTotalCount.Text = "0";
                        gvActiveCircuits.DataSource = null;
                        gvActiveCircuits.DataBind();
                        //gvActiveCircuits.Rows.Clear();
                    }

                }
                catch (Exception ex)
                {
                    throw ex;
                }
            
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
                    dtSolving.SelectedDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, DateTime.Now.Hour,DateTime.Now.Minute, DateTime.Now.Second);

                    if ((TicketTypeID.Equals(6)) & (Convert.ToInt32(Session["DepartmentID"]).Equals(1) || Convert.ToInt32(Session["DepartmentID"]).Equals(58) || Convert.ToInt32(Session["DepartmentID"]).Equals(59) || Convert.ToInt32(Session["DepartmentID"]).Equals(60)))
                    {
                            DataTable dt_DeplDet = objBSS.GetCircuitDeploymentDetatils(SignUpId);
                        

                            if (dt_DeplDet.Rows.Count > 0)
                            {
                                txtJoinName.Text = dt_DeplDet.Rows[0]["JoinName"].ToString();
                                txtTubeNameFromCustomer.Text = dt_DeplDet.Rows[0]["TubeNameFromCustomer"].ToString();
                                txtCoreColorFromCustomer.Text = dt_DeplDet.Rows[0]["CoreColorFromCustomer"].ToString();
                                txtTubeNameFromNode.Text = dt_DeplDet.Rows[0]["TubeNameFromNode"].ToString();
                                txtCoreColorFromNode.Text = dt_DeplDet.Rows[0]["CoreColorFromNode"].ToString();
                                txtCutDistance.Text = dt_DeplDet.Rows[0]["CutDistance"].ToString();
                                

                            }

                                pnlFiberDetails.Visible = true;
                    }
                        else
                        {
                            pnlFiberDetails.Visible = false;
                        }

                        if (TicketTypeID == 6)
                        {
                            cbCheckAll.Enabled = false;
                        }

                        //if (ComplainStatusID == 5 | ComplainStatusID == 1)
                        if (ComplainStatusID.Equals(5) || ComplainStatusID.Equals(1))
                        {
                            btnUpdate.Visible = false;
                        }

                        //else
                        //{
                        //    btnUpdate.Visible = true;
                        //}

                        tbComplainStatus.Text = dt.Rows[0]["ComplainStatus"];
                        cmbAssignedDepartment.SelectedValue = "61";
                        objBL.LoadProblemDignosedAt(cmbProblemDiagnosedat, Convert.ToInt32(cmbAssignedDepartment.SelectedValue));
                        objBL.LoadReasonOutage(cmbReasonofOutage, 0, 0, Convert.ToInt32(cmbAssignedDepartment.SelectedValue), 1, Convert.ToInt32(Session["UserID"]));
                        tbComplaintReceivedDT.Text = Convert.ToString(dt.Rows[0]["ComplaintReceivedDate"]);
                        AppDomain.CurrentDomain.SetData("LastUpdatedDate", Convert.ToDateTime(dt.Rows[0]["LastUpdatedDate"]));
                        tbRemarks.Text = dt.Rows[0]["Remarks"];
                        //ComplainStatusID = 1;
                        if (ComplainStatusID.Equals(1) || ComplainStatusID.Equals(5))
                        {
                            //tbPersonSolvingComplain.Text = dt.Rows[0]["PersonSolving"];
                            dtSolving.SelectedDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 5, 30, 0);
                            cmbProblemDiagnosedat.SelectedValue = Convert.ToString(dt.Rows[0]["ProblemDignoseEndID"]);
                            cmbReasonofOutage.SelectedValue = Convert.ToString(dt.Rows[0]["ReasonOutageID"]);
                            if (dt.Rows[0]["FCR"] == "True")
                            {
                                rbFCRYes.Checked = true;
                            }
                            else
                            {
                                rbFCRNo.Checked = true;
                            }

                            tbCauses.Text = dt.Rows[0]["Dignose_Causes"];
                            tbRootCauseAnalysis.Text = dt.Rows[0]["Dignose_RootCauseAnalysis"];
                            tbPreventiveMeasures.Text = dt.Rows[0]["Dignose_PreventativeMeasureTake"];
                            cmbLastMileInfra.SelectedValue = Convert.ToString(dt.Rows[0]["LastMileInfraID"]);
                        }
                    }
                }
            
           

            catch (Exception ex)
            {
                throw ex;
            }
    }

        protected void gvActiveCircuits_NeedDataSource(object sender, GridNeedDataSourceEventArgs e)
        {
            //dynamic dt = objBSS.GetComplainDetailByComplainID(Convert.ToInt32(Session["ComplainID"]));
            //gvActiveCircuits.DataSource = dt;
        }

      

        public void UpdateFiberDetails(int SignUpID)
        {
            try
            {
                //objBSS.UpdateFiberDetails(SignUpID, txtJoinName.Text, txtTubeNameFromCustomer.Text, txtCoreColorFromCustomer.Text, txtTubeNameFromNode.Text, txtTubeNameFromNode.Text,txtCutDistance.Text,UserID);
                //objBSS.UpdateFiberDetails(
                //if (objBSS.UpdateFiberDetails
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }


        public bool UpdateComplainDetails(int CompID)
        {

            //---------------------
            

                try
                {
                    int ComplainID = CompID;
                    string TicketNo = tbComplainTicketNo.Text;
                    int ComplaintStatusID = Convert.ToInt32(cmbComplainStatus.SelectedValue);
                    int AssignedByDeptID = DeptID;
                    int AssignedToDeptID = 61;
                    string AssignedToPersonName = tbPersonSolvingComplain.Text;
                    string AssignedByPersonName = tbPersonSolvingComplain.Text;
                    //DateTime LastUpdatedDate = AppDomain.CurrentDomain.GetData("LastUpdatedDate");
                    DateTime LastUpdatedDate = DateTime.Now;
                    DateTime ETA = Convert.ToDateTime("1/1/1990");
                    string PersonGivenETA = "";
                    DateTime ETTR = Convert.ToDateTime("1/1/1990");
                    string PersonSolving = "";
                    //DateTime ComplainSolvingDate = dtComplainSolving.Value;
                    DateTime ComplainSolvingDate = dtSolving.SelectedDate.Value;
                    string FCR = (rbFCRYes.Checked == false ? "Yes" : "No");                    
                    int ProblemDignoseEndID = Convert.ToInt32(cmbProblemDiagnosedat.SelectedValue);
                    int ReasonOutageID = Convert.ToInt32(cmbReasonofOutage.SelectedValue);
                    string Dignose_Causes = tbCauses.Text;
                    string Dignose_RootCauseAnalysis = tbRootCauseAnalysis.Text;
                    string Dignose_PreventativeMeasureTake = tbPreventiveMeasures.Text;
                    string LastMileInfraID = cmbLastMileInfra.SelectedValue;
                    string CustomerFeedBack = "";
                    string FurtherAction = "";
                    string NewComplainRef = "";
                    string QueryResponses = "";

                    string strWithTabsQR = tbRemarks.Text;
                    string lineQR = strWithTabsQR.Replace("\t", " ");
                    tbRemarks.Text = lineQR.Replace("\r\n", " ");

                    string Remarks = tbRemarks.Text;
                    int TransactionBy = UserID;
                    objBSS.UpdateComplain(ComplainID, TicketNo, ComplaintStatusID, AssignedByDeptID, AssignedToDeptID, AssignedToPersonName, AssignedByPersonName, LastUpdatedDate, ETA, PersonGivenETA,
                                          ETTR, PersonSolving, ComplainSolvingDate, FCR, ProblemDignoseEndID, ReasonOutageID, Dignose_Causes, Dignose_RootCauseAnalysis, Dignose_PreventativeMeasureTake, Convert.ToInt32(LastMileInfraID),
                                          CustomerFeedBack, FurtherAction, NewComplainRef, QueryResponses, Remarks, "", "", "", 1, 0, TransactionBy);



                    return true;

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


        protected void cmbProblemDiagnosedat_SelectedIndexChanged(object sender, EventArgs e)
        {
            dynamic dt = objBSS.GetComplainDetailByComplainID(Convert.ToInt32(Session["ComplainID"]));
            int AssignedDepartmentID = Convert.ToInt32(dt.Rows[0]["AssignedDeptID"]);
            if (!(Convert.ToInt32(cmbProblemDiagnosedat.SelectedValue).Equals(0)))
            {
                //objBL.LoadReasonOutage(cmbReasonofOutage, cmbProblemDiagnosedat.SelectedValue, 0, AssignedDepartmentID, 1);
                objBL.LoadReasonOutage(cmbReasonofOutage, Convert.ToInt32(cmbProblemDiagnosedat.SelectedValue), 0, AssignedDepartmentID, 1, Convert.ToInt32(Session["UserID"]));

                if (Convert.ToInt32(cmbProblemDiagnosedat.SelectedValue).Equals(2) || Convert.ToInt32(cmbProblemDiagnosedat.SelectedValue).Equals(7))
                {
                    Panel1.Visible = true;

                }
                else
                {
                    Panel1.Visible = false;

                }

            }


        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {

                btnUpdate.Enabled = false; 
            if (gvActiveCircuits.Rows.Count > 0)
            {
                foreach (GridViewRow row in gvActiveCircuits.Rows)
                {
                    int ComplainIDGridView = 0;
                    int SignUpGridView = 0;
                    
                    
                    //var cb = (CheckBox)row.Cells[0].FindControl("cb_Select");
                    CheckBox CheckBox1 = row.FindControl("cb_Select") as CheckBox;


                    if (CheckBox1 != null && CheckBox1.Checked == true)
                    {
                        //string strKey = item.GetDataKeyValue("ComplaintID").ToString();
                        ComplainIDGridView = Convert.ToInt32(row.Cells[1].Text);
                        SignUpGridView = Convert.ToInt32(row.Cells[2].Text);

                        if (UpdateComplainDetails(ComplainIDGridView))
                        {
                            if ((TicketTypeID.Equals(6)) & Convert.ToInt32(Session["DepartmentID"]).Equals(1) || Convert.ToInt32(Session["DepartmentID"]).Equals(58) || Convert.ToInt32(Session["DepartmentID"]).Equals(59) || Convert.ToInt32(Session["DepartmentID"]).Equals(60))
                            {
                                UpdateFiberDetails(SignUpGridView);
                                btnUpdate.Enabled = true; 
                            }

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



                            loadGridView();

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
                            }
                        }
                        else
                        {
                            lblstatus.Text = "None of any Complain Updated please try Again";
                            lblstatus.Visible = true;
                            btnUpdate.Enabled = true; 
                        }
                    }

                    else
                    {
                        lblstatus.Text = "None of any Complain Updated please select the complain from the grid";
                        lblstatus.Visible = true;
                        btnUpdate.Enabled = true; 
                    }
                }

            }
            else
            {
                lblstatus.Text = "There is no Circuits in Grid view";
                lblstatus.Visible = true;
                btnUpdate.Enabled = true; 
            }

            }
            catch (Exception ex)
            {

               
            }
        }

        protected void btnviewDetail_Click(object sender, EventArgs e)
        {
            Response.Redirect("~\\ComplainManagement\\ComplainForm.aspx?SignupID=" + Convert.ToInt32(Session["SignupID"]) + "&ComplainID=" + Convert.ToInt32(Session["ComplainID"]) + "&Flag=View");

        }

        protected void btncancel_Click(object sender, EventArgs e)
        {
            if (gvActiveCircuits.Rows.Count > 0)
            {
                foreach (GridViewRow item in gvActiveCircuits.Rows)
                {
                    int ComplainIDGridView = 0;
                    int SignUpGridView = 0;
                    GridViewRow dataitem = (GridViewRow)item;
                    TableCell cell = dataitem.Cells[0];
                    CheckBox CheckBox1 = (CheckBox)cell.Controls[0];
                    if (CheckBox1 != null && CheckBox1.Checked)
                    {
                        //string strKey = item.GetDataKeyValue("ComplaintID").ToString();
                        ComplainIDGridView = Convert.ToInt32(item.Cells[1].Text);
                        SignUpGridView = Convert.ToInt32(item.Cells[2].Text);

                        if (UpdateComplainDetails(ComplainIDGridView))
                        {
                            if ((TicketTypeID.Equals(6)) & Convert.ToInt32(Session["DepartmentID"]).Equals(1) || Convert.ToInt32(Session["DepartmentID"]).Equals(58) || Convert.ToInt32(Session["DepartmentID"]).Equals(59) || Convert.ToInt32(Session["DepartmentID"]).Equals(60))
                            {
                                UpdateFiberDetails(SignUpGridView);
                            }

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



                            loadGridView();

                            lblTotalCount.Text = "Total Count : " + Convert.ToString(SelectCount);
                            lblSucessCount.Text = "Solve Count : " + Convert.ToString(CircuitCount);
                            lblFailedCount.Text = "Failed Count: " + Convert.ToString(FailedCount);

                            lblTotalCount.Visible = true;
                            lblstatus.Visible = true;
                            lblSucessCount.Visible = true;
                            lblFailedCount.Visible = true;
                            //this.Close();
                            lblstatus.Text = "Record Save Sucessfully";
                            if (DataGridCount == 0)
                            {
                                //this.Close();
                            }
                        }
                        else
                        {
                            lblstatus.Text = "None of any Complain Updated please try Again";
                            lblstatus.Visible = true;
                        }
                    }

                    else
                    {
                        lblstatus.Text = "None of any Complain Updated please select the complain from the grid";
                        lblstatus.Visible = true;
                    }
                }
            }

            else
            {
                lblstatus.Text = "There is no Circuits in Grid view";
                lblstatus.Visible = true;
            }

        }

        protected void btnviewFiberHistory_Click(object sender, EventArgs e)
        {
            Response.Redirect("~\\ComplainManagement\\ViewFiberDetails.aspx?SignupID=" + Convert.ToInt32(Session["SignupID"]));
        }

        

      

        
        

       
        
    }
}