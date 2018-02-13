using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using RainMaker.BSS_Service;


namespace RainMaker.ComplainManagement
{
    public partial class ComplainForm : System.Web.UI.Page
    {
        BL objBL = new BL();
        public static int SignupID = 0;
        Service1SoapClient objBSS = new Service1SoapClient();

        static int UserID;
        static int DeptID;
        static int RoleID;
        static string InfraCode = "MT";
        static string ServiceUnitID;
        static string CircuitCode = "MP";
        public static string TicketNumber;
        static int ComplainID;
        static string Flag;
        static string EngineerName = null;
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    lblTicketNoAfterComplainGeneration.Visible = false;
                    Session["SignupID"] = Convert.ToInt32(base.Request.QueryString["SignupID"]);
                    SignupID = Convert.ToInt32(Session["SignupID"]);
                    Session["ComplainID"] = Convert.ToInt32(base.Request.QueryString["ComplainID"]);
                    Session["Flag"] = base.Request.QueryString["Flag"].ToString();
                    Flag=Session["Flag"].ToString();
                    ComplainID = Convert.ToInt32(Session["ComplainID"]) ;
                    EngineerName = Session["Name"].ToString();

                    UserID = Convert.ToInt16(Session["UserID"]);
                    DeptID = Convert.ToInt16(Session["DepartmentID"]);
                    RoleID = Convert.ToInt16(Session["RoleID"]);
                    tbPerson.Text = Session["Name"].ToString();
                    // loadCircuitCompleteDetails(Convert.ToInt16(Session["Complain_SignupID"]));
                    loadCircuitCompleteDetails(SignupID);
                    LoadMyCombos();
                    EngineerName = Session["Name"].ToString();

                    //DignoseFormSenerio(Session["Flag"].ToString(), Convert.ToInt32(Session["ComplainID"]));
                    DignoseFormSenerio(Flag, ComplainID);
                    if (DeptID == 66)
                    {
                        cmbCaseCategory.SelectedValue = "3";
                    }
                }
                loadCircuitCompleteDetails(Convert.ToInt16(Session["SignupID"]));
            }
            catch (Exception ex)
            {
                //Interaction.MsgBox("frmOTS_Load:" + ex.Message + "of frmOts_SingleComplain ", MsgBoxStyle.Critical, "BSS Addminstrator");
            }
        }

        protected void LoadMyCombos()
        {
            loadRadioButtons();
            objBL.LoadComplainStatus(cmbComplainStatus, "All");
            objBL.LoadPocStatus(cmbPOCStatus);
            objBL.LoadComplainType(cmbComplainType);
            objBL.LoadInitialStatement(cmbInitialStatement);
            objBL.loadAssignedDepartment(cmbAssignedDepartment, "All");
            //objBL.LoadComplainStatus(cmbComplainStatus);
            objBL.LoadCaseCategory(cmbCaseCategory);
            objBL.LoadComplaintReportedVia(cmbComplaintReportedVia);

            tbLoggedBy.Text = Session["Name"].ToString();
            tbLoggedBy.Enabled = false;
            EngineerName = Session["Name"].ToString();
            tbPerson.Text = Session["Name"].ToString();
            dtETA.SelectedDate = DateTime.MinValue;
            dtETTR.SelectedDate = DateTime.MinValue;
            
        }

        private void loadRadioButtons()
        {
            if (!Page.IsPostBack)
            {



            }
        }

        private void loadCircuitCompleteDetails(int SignupID)
        {
            try
            {
                dynamic dt = objBSS.GetCircuitCompleteDetail(SignupID);
                if (dt.Rows.Count == 1)
                {
                    int ServiceUnit = Convert.ToInt16(dt.Rows[0]["ServiceUnitID"]);
                    tbSignupID.Text = Convert.ToString(dt.Rows[0]["SignupID"]);
                    tbCircuitName.Text = Convert.ToString(dt.Rows[0]["CircuitName"]);
                    //lblCustomerInfo.Text = Convert.ToString(dt.Rows[0]["CircuitName"]) + "Information";
                    tbServiceUnit.Text = Convert.ToString(dt.Rows[0]["ServiceUnit"]);
                    tbInfra.Text = Convert.ToString(dt.Rows[0]["Infra"]);
                    tbAddress.Text = Convert.ToString(dt.Rows[0]["Address"]);
                    tbBandwidth.Text = Convert.ToString(dt.Rows[0]["Bandwidth"]);
                    tbRegion.Text = Convert.ToString(dt.Rows[0]["RegionName"]);
                    tbCPMRemarks.Text = Convert.ToString(dt.Rows[0]["CPMRemarks"]);
                    tbDeploymentRemarks.Text = Convert.ToString(dt.Rows[0]["DeploymentRemarks"]);
                    tbOperationalRemarks.Text = Convert.ToString(dt.Rows[0]["OperationalRemarks"]);
                    tbCustomerEmail.Text = Convert.ToString(dt.Rows[0]["Contact_Email"]);
                    if (dt.Rows[0]["VOIP"] == "YES")
                    {
                        rbWhitelistedYes.Checked = true; //YES
                    }
                    else
                    {
                        rbWhitelistedNo.Checked = true;  //NO
                    }

                    if (dt.Rows[0]["VC"] == "YES")
                    {
                        rbVideoYes.Checked = true;  //YES
                    }
                    else
                    {
                        rbVideoNo.Checked = true;  //NO
                    }

                    //'====================================================================================================================

                    tbDeploymentDate.Text=Convert.ToString(dt.Rows[0]["DeploymentDate"]);
                    tbDeploymentPerson.Text = Convert.ToString(dt.Rows[0]["EngineerName"]);
                    tbKAMContactNo.Text = Convert.ToString(dt.Rows[0]["Contact_Phone"]);
                    tbKeyAccountManager.Text = Convert.ToString(dt.Rows[0]["SalesPersonName"]);
                    tb3rdPartyAccountID.Text = Convert.ToString(dt.Rows[0]["ThirdPartyAccountID"]);
                    //'====================================================================================================================
                    tbCustomerIPPool1.Text = Convert.ToString(dt.Rows[0]["Primary_IpAddres"]);
                    tbSubnetMask.Text = Convert.ToString(dt.Rows[0]["Primary_SubnetMask"]);
                    tbGatewayIP.Text = Convert.ToString(dt.Rows[0]["Primary_Gateway"]);
                    tbSwitchName.Text = Convert.ToString(dt.Rows[0]["Primary_SwitchName"]);
                    tbSwitchPort.Text = Convert.ToString(dt.Rows[0]["Primary_SwitchPort"]);
                    tbRingName.Text = Convert.ToString(dt.Rows[0]["Primary_RingName"]);
                    tbNodeName.Text = Convert.ToString(dt.Rows[0]["Primary_Node"]);
                    tbFiberLength.Text = Convert.ToString(dt.Rows[0]["Pri_DFN"]);
                    tbCPEModel.Text = Convert.ToString(dt.Rows[0]["Primary_CPE_Model"]);
                    tbWavelength.Text = Convert.ToString(dt.Rows[0]["CPEWaveLength"]);
                    tbCircuitOwner.Text = Convert.ToString(dt.Rows[0]["PrimaryCircuitOwnerName"]);
                    tbThirdParty.Text = Convert.ToString(dt.Rows[0]["CircuitOwner"]);
                    tbCPEAddress.Text = Convert.ToString(dt.Rows[0]["Primary_CPE_IpAddress"]);
                    tbCPEPort.Text = Convert.ToString(dt.Rows[0]["Primary_CPE_PortNo"]);
                    tbOLTIPAddress.Text = Convert.ToString(dt.Rows[0]["Primary_OLTPonPort"]);
                    tbOLTPonPort.Text = Convert.ToString(dt.Rows[0]["Primary_OLTIpAddress"]);
                    if (dt.Rows[0]["Primary_CPE_ModelID"] != 2)
                    {
                        rbClientDevice.SelectedIndex = 0;
                    }
                    else if (dt.Rows[0]["Primary_ODU_ModelID"] != 5)
                    {
                        rbClientDevice.SelectedIndex = 1;
                    }
                    else if (dt.Rows[0]["Primary_CPE_ModelID"] == 2 & dt.Rows[0]["Primary_ODU_ModelID"] == 5)
                    {
                        rbClientDevice.SelectedIndex = 2;
                    }

                    //'====================================================================================================================
                    tbCustomerIPPool21.Text = Convert.ToString(dt.Rows[0]["Secondary_IpAddress"]);
                    tbSubnetMask21.Text = Convert.ToString(dt.Rows[0]["Secondary_SubnetMask"]);
                    tbGatewayIP22.Text = Convert.ToString(dt.Rows[0]["Secondary_Gateway"]);
                    tbSwitchName21.Text = Convert.ToString(dt.Rows[0]["Secondary_SwitchName"]);
                    tbSwitchPort22.Text = Convert.ToString(dt.Rows[0]["Secondary_SwitchPort"]);
                    tbRingName21.Text = Convert.ToString(dt.Rows[0]["Secondary_RingName"]);
                    tbNodeName22.Text = Convert.ToString(dt.Rows[0]["Secondary_Node"]);
                    tbFiberLength21.Text = Convert.ToString(dt.Rows[0]["Sec_DFN"]);
                    tbCPEModel21.Text = Convert.ToString(dt.Rows[0]["Secondary_CPE_Model"]);
                    tbWavelength22.Text = Convert.ToString(dt.Rows[0]["Secondary_CPE_Wavelength"]);
                    tbBackupCircuitOwner.Text = Convert.ToString(dt.Rows[0]["Secondary_CircuitOwnerName"]);
                    tbBackupThirdPartyName.Text = Convert.ToString(dt.Rows[0]["BackupOwner"]);
                    tbCPEAddress21.Text = Convert.ToString(dt.Rows[0]["Secondary_CPE_IpAddress"]);
                    tbCPEPort22.Text = Convert.ToString(dt.Rows[0]["Secondary_CPE_PortNo"]);
                    tbOLTIPAddress22.Text = Convert.ToString(dt.Rows[0]["Secondary_OLTIpAddress"]);
                    tbOLTPonPort21.Text = Convert.ToString(dt.Rows[0]["Secondary_OLTPonPort"]);
                    if (dt.Rows[0]["Secondary_CPE_ModelID"] != 2)
                    {
                        rbClientDevice2.SelectedIndex = 0;
                    }
                    else if (dt.Rows[0]["Secondary_ODU_ModelID"] != 5)
                    {
                        rbClientDevice2.SelectedIndex = 1;
                    }
                    else if (dt.Rows[0]["Secondary_CPE_ModelID"] == 2 & dt.Rows[0]["Secondary_CPE_ModelID"] == 5)
                    {
                        rbClientDevice2.SelectedIndex = 2;
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void DignoseFormSenerio(string Flag, int ComplainID)
        {
            try
            {
                if (Flag == "Insert")
                {
                    tbLoggedBy.Text = Session["Name"].ToString();
                    CircuitCode = Session["Complain_CircuitOwnerCode"].ToString();
                    InfraCode = Session["Complain_InfraCode"].ToString();
                    dtComplainReceived.SelectedDate = DateTime.Now;
                }
                else if (Flag == "View" & ComplainID != 0)
                {
                    EngineerName = Session["Name"].ToString();

                    GetComplainDetails(ComplainID);
                    btSaveComplain.Visible = false;

                }
                else if (Flag == "Update" & ComplainID != 0)
                {
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
                if (dt.Rows.Count == 1)
                {
                    pnlTicketInfo.Visible = true;
                    lblTicketNo.Text = dt.Rows[0]["TicketNo"];
                    lblLoggedDateTime.Text = Convert.ToString(dt.Rows[0]["LoggedDateTime"]);
                    tbLoggedBy.Text = dt.Rows[0]["LoggedBy"];
                    tbCallerName.Text = dt.Rows[0]["CallerName"];
                    tbCallerNumber.Text = dt.Rows[0]["CallerNumber"];
                    tbPOCName.Text = dt.Rows[0]["PoCName"];
                    tbPOCNumber.Text = dt.Rows[0]["PoCNumber"];
                    dtComplainReceived.SelectedDate = (DateTime)dt.Rows[0]["ComplaintReceivedDate"];

                    cmbAssignedDepartment.DataTextField = dt.Rows[0]["AssignDepartment"];
                    cmbAssignedDepartment.SelectedValue = Convert.ToString(dt.Rows[0]["AssignedDeptID"]);

                    cmbComplainStatus.DataTextField = dt.Rows[0]["ComplainStatus"];
                    cmbComplainStatus.SelectedValue = Convert.ToString(dt.Rows[0]["ComplaintStatusID"]);

                    cmbCaseCategory.DataTextField = dt.Rows[0]["ComplainType"];
                    cmbCaseCategory.SelectedValue = Convert.ToString(dt.Rows[0]["CaseCategoryID"]);

                    cmbInitialStatement.DataTextField = dt.Rows[0]["InitailStatement"];
                    cmbInitialStatement.SelectedValue = Convert.ToString(dt.Rows[0]["InitialStatementID"]);

                    cmbComplainType.DataTextField = dt.Rows[0]["ComplainType"];
                    cmbComplainType.SelectedValue = Convert.ToString(dt.Rows[0]["ComplaintTypeID"]);

                    cmbPOCStatus.DataTextField = dt.Rows[0]["PocStatus"];
                    cmbPOCStatus.SelectedValue = Convert.ToString(dt.Rows[0]["PoCStatusID"]);

                    cmbComplaintReportedVia.DataTextField = dt.Rows[0]["ComplaintReportedvia"];
                    cmbComplaintReportedVia.SelectedValue = Convert.ToString(dt.Rows[0]["ComplaintReportedviaId"]);
                    if (Convert.ToString(cmbInitialStatement.SelectedValue) == "1" || Convert.ToString(cmbInitialStatement.SelectedValue) == "2" || Convert.ToString(cmbInitialStatement.SelectedValue) == "3")
                    {
                        cntIntial_LinkDownDrops.Visible = true;
                        //pnlLinkDownToLatencyIssue.Visible = true;
                        cntemailIsuee.Visible = false;
                        //pnlEmailIssue.Visible = false;
                        cntBrowsingDeadIssue.Visible = false;
                        //pnlFlappingIssueToBrowsingIssue.Visible = false;
                        cntWebIssue.Visible = false;
                        //pnlWebsiteIssue.Visible = false;
                        cntServiceRequest.Visible = false;
                        //pnlServiceRequesttoMiscIssue.Visible = false;
                    }
                    if (Convert.ToString(cmbInitialStatement.SelectedValue) == "4" || Convert.ToString(cmbInitialStatement.SelectedValue) == "5")
                    {
                        cntIntial_LinkDownDrops.Visible = false;
                        //pnlLinkDownToLatencyIssue.Visible = true;
                        cntemailIsuee.Visible = false;
                        //pnlEmailIssue.Visible = false;
                        cntBrowsingDeadIssue.Visible = true;
                        //pnlFlappingIssueToBrowsingIssue.Visible = false;
                        cntWebIssue.Visible = false;
                        //pnlWebsiteIssue.Visible = false;
                        cntServiceRequest.Visible = false;
                        //pnlServiceRequesttoMiscIssue.Visible = false;
                    }
                    if (Convert.ToString(cmbInitialStatement.SelectedValue) == "6")
                    {
                        cntIntial_LinkDownDrops.Visible = false;
                        //pnlLinkDownToLatencyIssue.Visible = true;
                        cntemailIsuee.Visible = true;
                        //pnlEmailIssue.Visible = false;
                        cntBrowsingDeadIssue.Visible = false;
                        //pnlFlappingIssueToBrowsingIssue.Visible = false;
                        cntWebIssue.Visible = false;
                        //pnlWebsiteIssue.Visible = false;
                        cntServiceRequest.Visible = false;
                        //pnlServiceRequesttoMiscIssue.Visible = false;
                    }
                    if (Convert.ToString(cmbInitialStatement.SelectedValue) == "7")
                    {
                        cntIntial_LinkDownDrops.Visible = false;
                        //pnlLinkDownToLatencyIssue.Visible = true;
                        cntemailIsuee.Visible = false;
                        //pnlEmailIssue.Visible = false;
                        cntBrowsingDeadIssue.Visible = false;
                        //pnlFlappingIssueToBrowsingIssue.Visible = false;
                        cntWebIssue.Visible = true;
                        //pnlWebsiteIssue.Visible = false;
                        cntServiceRequest.Visible = false;
                        //pnlServiceRequesttoMiscIssue.Visible = false;
                    }
                    if (Convert.ToString(cmbInitialStatement.SelectedValue) == "8" || Convert.ToString(cmbInitialStatement.SelectedValue) == "9")
                    {
                        cntIntial_LinkDownDrops.Visible = false;
                        //pnlLinkDownToLatencyIssue.Visible = true;
                        cntemailIsuee.Visible = false;
                        //pnlEmailIssue.Visible = false;
                        cntBrowsingDeadIssue.Visible = false;
                        //pnlFlappingIssueToBrowsingIssue.Visible = false;
                        cntWebIssue.Visible = false;
                        //pnlWebsiteIssue.Visible = false;
                        cntServiceRequest.Visible = true;
                        //pnlServiceRequesttoMiscIssue.Visible = false;
                    }
                    //cmbAssignedDepartment.SelectedValue = dt.Rows[0]["AssignedDeptID"];
                    //cmbCaseCategory.SelectedValue = dt.Rows[0]["CaseCategoryID"];
                    //cmbComplainStatus.SelectedValue = dt.Rows[0]["ComplaintStatusID"];
                    //cmbComplaintReportedVia.SelectedValue = dt.Rows[0]["ComplaintReportedviaId"];
                    //cmbComplainType.SelectedValue = dt.Rows[0]["ComplaintTypeID"];
                    //cmbInitialStatement.SelectedValue = dt.Rows[0]["InitialStatementID"];
                    //cmbPOCStatus.SelectedValue = dt.Rows[0]["PoCStatusID"];
                }
                else
                {
                    pnlTicketInfo.Visible = false;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public string GetTicketNumber()
        {
            try
            {
                CircuitCode = Convert.ToString(Session["Complain_CircuitOwnerCode"]);
                InfraCode = Convert.ToString(Session["Complain_InfraCode"]);
                int Seq = objBSS.GetComplainTicket(InfraCode, CircuitCode, "");
                string tick = CircuitCode + "-" + InfraCode + "-" + Convert.ToString(Seq);
                return tick;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public string GetRemarksfromControls()
        {
            try
            {
                if (cmbInitialStatement.SelectedValue == "1" || cmbInitialStatement.SelectedValue == "2" || cmbInitialStatement.SelectedValue == "3")
                {
                    TextBox tbTS12_5Remarks = (TextBox)cntIntial_LinkDownDrops.FindControl("tbTS12_5Remarks");

                    return tbTS12_5Remarks.Text;


                }
                else if (cmbInitialStatement.SelectedValue == "5" || cmbInitialStatement.SelectedValue == "4")
                {
                    TextBox tbTS23_5Remarks = (TextBox)cntIntial_LinkDownDrops.FindControl("tbTS23_5Remarks");
                    return tbTS23_5Remarks.Text;

                }
                else if (cmbInitialStatement.SelectedValue == "6")
                {
                    TextBox tbTS31_8Remarks = (TextBox)cntIntial_LinkDownDrops.FindControl("tbTS31_8Remarks");
                    return tbTS31_8Remarks.Text;

                }
                else if (cmbInitialStatement.SelectedValue == "7")
                {
                    TextBox tbTS41_4Remarks = (TextBox)cntIntial_LinkDownDrops.FindControl("tbTS41_4Remarks");
                    return tbTS41_4Remarks.Text;

                }
                else if (cmbInitialStatement.SelectedValue == "8" | cmbInitialStatement.SelectedValue == "9")
                {
                    TextBox tbTS51_2Remarks = (TextBox)cntIntial_LinkDownDrops.FindControl("tbTS51_2Remarks");
                    return tbTS51_2Remarks.Text;
                }
                else
                {
                    return string.Empty;
                }
            }
            catch (Exception ex)
            {
                return string.Empty;
            }
        }

        public bool CheckTroubleShootingSteps()
        {
            try
            {
                try
                {
                    if (cmbInitialStatement.SelectedValue == "1" | cmbInitialStatement.SelectedValue == "2" | cmbInitialStatement.SelectedValue == "3" | cmbInitialStatement.SelectedValue == "4")
                    {
                        if (!cntIntial_LinkDownDrops.CheckTroubleShooting())
                        {
                            return false;
                        }
                    }
                    //else if (cmbInitialStatement.SelectedValue == "5" | cmbInitialStatement.SelectedValue == "4")
                    //{
                    //    if (!cntBrowsingDeadIssue.CheckTroubleShooting())
                    //    {
                    //        return false;
                    //    }
                    //}
                    //else if (cmbInitialStatement.SelectedValue == "6")
                    //{
                    //    if (!cntemailIsuee.CheckTroubleShooting())
                    //    {
                    //        return false;
                    //    }
                    //}
                    //else if (cmbInitialStatement.SelectedValue == "7")
                    //{
                    //    if (!cntWebIssue.CheckTroubleShooting())
                    //    {
                    //        return false;
                    //    }

                    //}
                    else if (cmbInitialStatement.SelectedValue == "8" | cmbInitialStatement.SelectedValue == "9")
                    {

                    }

                    return true;
                }
                catch (Exception ex)
                {
                    return false;
                    //Interaction.MsgBox("cmbInitialStatement_SelectedIndexChanged:" + ex.Message + "of frmOts_SingleComplain ", MsgBoxStyle.Critical, "BSS Addminstrator");
                }


            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool InsertComplainTroubleShooting(int ComplainID)
        {
            try
            {
                if (cmbInitialStatement.SelectedValue == "1" || cmbInitialStatement.SelectedValue == "2" || cmbInitialStatement.SelectedValue == "3" || cmbInitialStatement.SelectedValue == "4")
                {
                    if (cntIntial_LinkDownDrops.InsertComplainTrouble(ComplainID))
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }


                }
                else if (cmbInitialStatement.SelectedValue == "5" || cmbInitialStatement.SelectedValue == "4")
                {

                    if (cntBrowsingDeadIssue.InsertComplainTrouble(ComplainID))
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }

                }
                else if (cmbInitialStatement.SelectedValue == "6")
                {

                    if (cntemailIsuee.InsertComplainTrouble(ComplainID))
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }

                }
                else if (cmbInitialStatement.SelectedValue == "7")
                {

                    if (cntWebIssue.InsertComplainTrouble(ComplainID))
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }

                }
                else if (cmbInitialStatement.SelectedValue == "8" || cmbInitialStatement.SelectedValue == "9")
                {

                    if (cntServiceRequest.InsertComplainTrouble(ComplainID))
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }

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

        protected void btSaveComplain_Click(object sender, EventArgs e)
        {
            try
            {
                btSaveComplain.Visible = false;
                if (!CheckTroubleShootingSteps())
                {
                    btSaveComplain.Visible = true;
                    ScriptManager.RegisterStartupScript(this.UPPanel2, typeof(string), "Alert", "alert('There is something missing in Troubleshooting Step');", true);
                    // Interaction.MsgBox("There is something missing in Troubleshooting Step", MsgBoxStyle.Information, "BSS Administrator");
                    return;
                }

                // DialogResult dgresult = MessageBox.Show("Are you sure to save the record?", "Business Support System", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                //if (dgresult == Windows.Forms.DialogResult.No)
                //{
                // return;
                //}

                if (cmbAssignedDepartment.SelectedValue == "0" | cmbCaseCategory.SelectedValue == "0" | cmbComplainStatus.SelectedValue == "0" | cmbComplaintReportedVia.SelectedValue == "0" | cmbComplainType.SelectedValue == "0" | cmbInitialStatement.SelectedValue == "0" | cmbPOCStatus.SelectedValue == "0")
                {
                    btSaveComplain.Visible = true;
                    ScriptManager.RegisterStartupScript(this.UPPanel2, typeof(string), "Alert", "alert('Please Select all validate fields');", true);
                    //Interaction.MsgBox("Please Select all validate fields", MsgBoxStyle.Information, "BSS Administrator");
                    return;
                }

                if (tbCallerName.Text == string.Empty | tbCallerNumber.Text == string.Empty | tbLoggedBy.Text == string.Empty | tbPOCName.Text == string.Empty | tbPOCNumber.Text == string.Empty)
                {
                    btSaveComplain.Visible = true;
                    ScriptManager.RegisterStartupScript(this.UPPanel2, typeof(string), "Alert", "alert('Please Select all validate fields');", true);
                    //Interaction.MsgBox("Please enter all validate fields", MsgBoxStyle.Information, "BSS Administrator");
                    return;
                }

                int SignupID = Convert.ToInt16(Session["Complain_SignupID"]);
                int InitailStatementID = Convert.ToInt16(cmbInitialStatement.SelectedValue);
                int ComplaintTypeID = Convert.ToInt16(cmbComplainType.SelectedValue);
                int TicketTypeID = Convert.ToInt16(Session["Complain_TicketTypeID"]);
                int ComplaintStatusID = Convert.ToInt16(cmbComplainStatus.SelectedValue);
                int ProblemDignoseEndID = 5;
                string LoggedBy = tbLoggedBy.Text;
                int ComplaintReportedviaId = Convert.ToInt16(cmbComplaintReportedVia.SelectedValue);
                DateTime ComplaintReceivedDate = dtComplainReceived.SelectedDate.Value;
                string PersonSolving = string.Empty;
                int CaseCategoryID = Convert.ToInt16(cmbCaseCategory.SelectedValue);
                string CallerName = tbCallerName.Text;
                string CallerNumber = tbCallerNumber.Text;
                string PoCName = tbPOCName.Text;
                string PoCNumber = tbPOCNumber.Text;
                int PoCStatusID = Convert.ToInt16(cmbPOCStatus.SelectedValue);
                int AssignedToDeptID = Convert.ToInt16(cmbAssignedDepartment.SelectedValue);
                int AssignedByDeptID = DeptID;
                string FCR = string.Empty;
                DateTime Hold_UnHoldTime = Convert.ToDateTime("1/1/1990");
                string RCA = string.Empty;
                string Partner = string.Empty;
                int LinkStatusID = 1;
                string Location = "";
                string Fault = "";
                string TxnOwner = "";
                DateTime ETA = default(DateTime);
                DateTime ETTR = default(DateTime);
                string PersonGivenETA = null;

                if (ComplaintStatusID == 4)
                {
                    ETA = dtETA.SelectedDate.Value;
                    ETTR = dtETTR.SelectedDate.Value;
                    PersonGivenETA = tbPerson.Text;
                }
                else
                {
                    ETA = Convert.ToDateTime("1/1/1900");
                    ETTR = Convert.ToDateTime("1/1/1900");
                    PersonGivenETA = "";
                }

                string Remarks = GetRemarksfromControls();
                string QueryResponse = "";
                string IPOpsComments = "";
                string AssignedPersonName = EngineerName;
                int TransactionBy = UserID;
                TicketNumber = GetTicketNumber();

                int ComplainID = objBSS.InsertComplain(SignupID, TicketNumber, InitailStatementID, ComplaintTypeID, TicketTypeID, ComplaintStatusID, ProblemDignoseEndID, LoggedBy, ComplaintReportedviaId, ComplaintReceivedDate,
                PersonSolving, CaseCategoryID, CallerName, CallerNumber, PoCName, PoCNumber, PoCStatusID, AssignedToDeptID, AssignedByDeptID, FCR,
                Hold_UnHoldTime, RCA, Partner, LinkStatusID, Location, Fault, TxnOwner, ETA, ETTR, PersonGivenETA,
                Remarks, QueryResponse, IPOpsComments, AssignedPersonName, TransactionBy);

                if (ComplainID > 0)
                {
                    if (InsertComplainTroubleShooting(ComplainID))
                    {
                        btSaveComplain.Visible = false;
                        lblTicketNoAfterComplainGeneration.Text = "Complained Save with Ticket No " + TicketNumber;
                        lblTicketNoAfterComplainGeneration.Visible = true;
                        //Response.Redirect("~\\SearchCircuits.aspx");
                        //Response.Redirect("~\\SearchCircuits.aspx?TicketNo=" + TicketNumber);
                        //Response.Redirect("~\\ViewFiberDetails.aspx?SignupID=" + Convert.ToInt32(Session["SignupID"]));
                        // Interaction.MsgBox("Complain Insert Sucessfully TicketNo is : " + TicketNumber, MsgBoxStyle.Information, "BSS Administrator");
                    }
                    else
                    {

                        objBSS.ExecQuery("Delete From Ots_Complains Where ComplaintID = " + Convert.ToString(ComplainID));
                        // Interaction.MsgBox("Complain not insert", MsgBoxStyle.Information, "BSS Administrator");
                    }
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this.btSaveComplain, typeof(string), "Alert", "alert('Complain not insert,please Try Again');", true);
                    btSaveComplain.Visible = true;
                    // Interaction.MsgBox("Complain not insert,please Try Again", MsgBoxStyle.Information, "BSS Administrator");
                }


            }
            catch (Exception ex)
            {
                
                // Interaction.MsgBox("SaveToolStripButton_Click_1:" + ex.Message + "of frmOts_SingleComplain ", MsgBoxStyle.Critical, "BSS Addminstrator");
            }
        }

        protected void cmbInitialStatement_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbAssignedDepartment.SelectedValue == "0")
            {
                String Message = "Please Select Assigned Department First";
                Page.ClientScript.RegisterStartupScript(this.GetType(), "alert", "<script>alert('" + Message + "');</script>"
            );
                // System.Web.HttpContext.Current.Response.Write("<script>alert('" + Message + "')</script>");
            }
            else
            {
                //if (Convert.ToString(cmbInitialStatement.SelectedValue) == "0" || Convert.ToString(cmbInitialStatement.SelectedValue) == "1" || Convert.ToString(cmbInitialStatement.SelectedValue) == "2")
                if (Convert.ToString(cmbInitialStatement.SelectedValue) == "1" || Convert.ToString(cmbInitialStatement.SelectedValue) == "2" || Convert.ToString(cmbInitialStatement.SelectedValue) == "3")
                {
                    cntIntial_LinkDownDrops.Visible = true;
                    //pnlLinkDownToLatencyIssue.Visible = true;
                    cntemailIsuee.Visible = false;
                    //pnlEmailIssue.Visible = false;
                    cntBrowsingDeadIssue.Visible = false;
                    //pnlFlappingIssueToBrowsingIssue.Visible = false;
                    cntWebIssue.Visible = false;
                    //pnlWebsiteIssue.Visible = false;
                    cntServiceRequest.Visible = false;
                    //pnlServiceRequesttoMiscIssue.Visible = false;
                }
                if (Convert.ToString(cmbInitialStatement.SelectedValue) == "4" || Convert.ToString(cmbInitialStatement.SelectedValue) == "5")
                {
                    cntIntial_LinkDownDrops.Visible = false;
                    //pnlLinkDownToLatencyIssue.Visible = true;
                    cntemailIsuee.Visible = false;
                    //pnlEmailIssue.Visible = false;
                    cntBrowsingDeadIssue.Visible = true;
                    //pnlFlappingIssueToBrowsingIssue.Visible = false;
                    cntWebIssue.Visible = false;
                    //pnlWebsiteIssue.Visible = false;
                    cntServiceRequest.Visible = false;
                    //pnlServiceRequesttoMiscIssue.Visible = false;
                }
                if (Convert.ToString(cmbInitialStatement.SelectedValue) == "6")
                {
                    cntIntial_LinkDownDrops.Visible = false;
                    //pnlLinkDownToLatencyIssue.Visible = true;
                    cntemailIsuee.Visible = true;
                    //pnlEmailIssue.Visible = false;
                    cntBrowsingDeadIssue.Visible = false;
                    //pnlFlappingIssueToBrowsingIssue.Visible = false;
                    cntWebIssue.Visible = false;
                    //pnlWebsiteIssue.Visible = false;
                    cntServiceRequest.Visible = false;
                    //pnlServiceRequesttoMiscIssue.Visible = false;
                }
                if (Convert.ToString(cmbInitialStatement.SelectedValue) == "7")
                {
                    cntIntial_LinkDownDrops.Visible = false;
                    //pnlLinkDownToLatencyIssue.Visible = true;
                    cntemailIsuee.Visible = false;
                    //pnlEmailIssue.Visible = false;
                    cntBrowsingDeadIssue.Visible = false;
                    //pnlFlappingIssueToBrowsingIssue.Visible = false;
                    cntWebIssue.Visible = true;
                    //pnlWebsiteIssue.Visible = false;
                    cntServiceRequest.Visible = false;
                    //pnlServiceRequesttoMiscIssue.Visible = false;
                }
                if (Convert.ToString(cmbInitialStatement.SelectedValue) == "8" || Convert.ToString(cmbInitialStatement.SelectedValue) == "9")
                {
                    cntIntial_LinkDownDrops.Visible = false;
                    //pnlLinkDownToLatencyIssue.Visible = true;
                    cntemailIsuee.Visible = false;
                    //pnlEmailIssue.Visible = false;
                    cntBrowsingDeadIssue.Visible = false;
                    //pnlFlappingIssueToBrowsingIssue.Visible = false;
                    cntWebIssue.Visible = false;
                    //pnlWebsiteIssue.Visible = false;
                    cntServiceRequest.Visible = true;
                    //pnlServiceRequesttoMiscIssue.Visible = false;
                }
            }

        }

        protected void cmbComplainStatus_SelectedIndexChanged(object sender, EventArgs e)
        {
             try
             {
                 if (cmbComplainStatus.SelectedValue == "4")
                 {
                   
                 }
                 else
                 {
                   
                 }
             }
             catch (Exception ex)
             {
                 //Interaction.MsgBox("cmbComplainStatus_SelectedIndexChanged:" + ex.Message + "of frmOts_SingleComplain ", MsgBoxStyle.Critical, "BSS Addminstrator");
             }

        }

     
      
      
    }
}