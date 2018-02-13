using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Telerik.Web.UI;
using RainMaker.BSS_Service;
using System.Data;

namespace RainMaker.ComplainManagement
{ 
    public partial class MultipleComplainForm : System.Web.UI.Page
    {
        static object Frm;
        static int UserID;
        static int RoleID;
        static int DeptID;
        static string InfraCode;
        static string CircuitCode;
        static string TicketTypeCode;
        static public string TicketNumber;
        static int CircuitCount = 0;
        static string parentTicket;
        static int SelectCount;
        static int TicketTypeID;
        static int SelectedCount = 0;
        BL objBL = new BL();
        Service1SoapClient objBSS = new Service1SoapClient();
        string EngineerName = null;
        //BSS_ServiceLocal.Service1SoapClient objBSS = new BSS_ServiceLocal.Service1SoapClient();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                DataTable dt = (DataTable)Session["GridView"];
                gvMultipleComplainForm.DataSource = dt;
                gvMultipleComplainForm.DataBind();

                BL objBL = new BL();
                objBL.LoadPocStatus(cmbPOCStatus);
                objBL.LoadComplainType(cmbComplainType);
                objBL.LoadInitialStatement(cmbInitialStatement);
                objBL.loadAssignedDepartment(cmbAssignedDepartment, "All");
                objBL.LoadComplainStatus(cmbComplainStatus, "All");
                objBL.LoadCaseCategory(cmbCaseCategory);
                objBL.LoadComplaintReportedVia(cmbComplaintReportedVia);
                lblDateTime.Text = DateTime.Today.ToString();
                tbLoggedBy.Text = Session["Name"].ToString();
                tbLoggedBy.Enabled = false;
                EngineerName = Session["Name"].ToString();
                tbPersonGivenETA.Text = Session["Name"].ToString();
                tbPersonGivenETA.Enabled = false;
                dtETA.SelectedDate = DateTime.MinValue;
                dtETTR.SelectedDate = DateTime.MinValue;
                dtETA.Enabled = false;
                dtETTR.Enabled = false;
                dtComplainReceived.SelectedDate = DateTime.Now;
                //objBL.loadLoggedBy(tbLoggedBy);
            }
        }


       

        #region "Helping Function"

        private void LoadMyCombos()
        {
            try
            {
                objBL.LoadComplaintReportedVia(cmbComplaintReportedVia);
                objBL.LoadCaseCategory(cmbCaseCategory);
                objBL.LoadPocStatus(cmbPOCStatus);
                objBL.LoadInitialStatement(cmbInitialStatement);
                objBL.loadAssignedDepartment(cmbAssignedDepartment, "All");
                objBL.LoadComplainType(cmbComplainType);
                objBL.LoadComplainStatus(cmbComplainStatus, "All");
                cmbComplainStatus.SelectedValue = "2";
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void GetParentTiket()
        {
            try
            {
                //TicketTypeCode = Session["Complain_TicketTypeCode"].ToString();
                TicketTypeCode = Session["Complain_TicketTypCode"].ToString();
                int seq = 0;
                CircuitCode = Session["Complain_CircuitOwnerCode"].ToString();
                string octate = objBSS.GetComplainParentTicket(CircuitCode, TicketTypeCode);
                string[] Str = octate.Split('-');
                if (Str.Length == 2)
                {
                    seq = Convert.ToInt32(Str[0]) + 1;
                }

                parentTicket = CircuitCode + "-" + TicketTypeCode + "-" + Convert.ToString(seq);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public string GetChildTicket(int Count)
        {
            try
            {
                TicketNumber = parentTicket + "-" + Convert.ToString(Count);
                return TicketNumber;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool CheckCustomerSelect()
        {
            bool @bool = false;

            try
            {
                foreach (GridDataItem item in gvMultipleComplainForm.Items)
                {
                    var cb = (CheckBox)item.FindControl("Select");
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

        public bool InsertComplain(int SigID, string TickNo)
        {
            try
            {
                DeptID = Convert.ToInt32(Session["DepartmentID"]);
                RoleID = Convert.ToInt32(Session["RoleID"]);
                UserID = Convert.ToInt32(Session["UserID"]);
                int SignupID = SigID;
                string TicketNo = TickNo;
                int InitailStatementID = Convert.ToInt32(cmbInitialStatement.SelectedValue);
                int ComplaintTypeID = Convert.ToInt32(cmbComplainType.SelectedValue);
                int TicketTypeID = Convert.ToInt32(Session["Complain_TicketTypeID"].ToString());
                int ComplaintStatusID = Convert.ToInt32(cmbComplainStatus.SelectedValue);
                int ProblemDignoseEndID = 5;
                string LoggedBy = tbLoggedBy.Text;
                int ComplaintReportedviaId = Convert.ToInt32(cmbComplaintReportedVia.SelectedValue);
                DateTime ComplaintReceivedDate = Convert.ToDateTime(dtComplainReceived.SelectedDate.Value);
                string PersonSolving = string.Empty;
                int CaseCategoryID = Convert.ToInt32(cmbCaseCategory.SelectedValue);
                string CallerName = tbCallerName.Text;
                string CallerNumber = tbCallerNumber.Text;
                string PoCName = tbPOCName.Text;
                string PoCNumber = tbPOCNumber.Text;
                int PoCStatusID = Convert.ToInt32(cmbPOCStatus.SelectedValue);
                int AssignedToDeptID = Convert.ToInt32(cmbAssignedDepartment.SelectedValue);
                int AssignedByDeptID = DeptID;
                string FCR = "";
                DateTime Hold_UnHoldTime = Convert.ToDateTime("1/1/1990");
                string RCA = "";
                string Partner = "";
                int LinkStatusID = 1;
                string Location = "";
                string Fault = "";
                string TxnOwner = "";
                DateTime ETA = default(DateTime);
                DateTime ETTR = default(DateTime);
                string PersonGivenETA = "";
                if (ComplaintStatusID == 4)
                {
                    ETA = dtETA.SelectedDate.Value;
                    ETTR = dtETTR.SelectedDate.Value;
                    PersonGivenETA = tbPersonGivenETA.Text;
                }
                else
                {
                    ETA = Convert.ToDateTime("1/1/1900");
                    ETTR = Convert.ToDateTime("1/1/1900");
                    PersonGivenETA = "";
                }
                string Remarks = tbRemarks.Text;
                string QueryResponse = "";
                string IPOpsComments = "";
                string AssignedPersonName = Session["Name"].ToString();
                int TransactionBy = UserID;

                //int ComplainID = objBSS.InsertComplain(SignupID, TicketNo, InitailStatementID, ComplaintTypeID, TicketTypeID, ComplaintStatusID, ProblemDignoseEndID, LoggedBy, ComplaintReportedviaId, ComplaintReceivedDate,
                //PersonSolving, CaseCategoryID, CallerName, CallerNumber, PoCName, PoCNumber, PoCStatusID, AssignedToDeptID, AssignedByDeptID, FCR,
                //Hold_UnHoldTime, RCA, Partner, LinkStatusID, Location, Fault, TxnOwner, ETA, ETTR, PersonGivenETA,
                //Remarks, QueryResponse, IPOpsComments, AssignedPersonName, TransactionBy);

                int ComplainID = objBSS.InsertComplain(SignupID, TicketNo, InitailStatementID, ComplaintTypeID, TicketTypeID, ComplaintStatusID, ProblemDignoseEndID, LoggedBy, ComplaintReportedviaId, ComplaintReceivedDate,
                PersonSolving, CaseCategoryID, CallerName, CallerNumber, PoCName, PoCNumber, PoCStatusID, AssignedToDeptID, AssignedByDeptID, FCR,
                Hold_UnHoldTime, RCA, Partner, LinkStatusID, Location, Fault, TxnOwner, ETA, ETTR, PersonGivenETA,
                Remarks, QueryResponse, IPOpsComments, AssignedPersonName, TransactionBy);

                if (ComplainID > 0)
                {
                    return true;
                }
                else
                {
                    return true;
                }


            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected void SaveToolStripButton_Click(object sender, EventArgs e)
        {
            try
            {


                CheckCustomerSelect();

                string msg = string.Empty;
                int TicketCount = 0;
                GetParentTiket();


                if (gvMultipleComplainForm.Items.Count > 0)
                {


                    foreach (GridDataItem row in gvMultipleComplainForm.Items)
                    {
                        var cb = (CheckBox)row.Cells[0].FindControl("cb_Select");


                        if (cb.Checked == true)
                        {
                            TicketCount = TicketCount + 1;
                            string ChildTicket = GetChildTicket(TicketCount);
                            int CellI = Convert.ToInt32(row.Cells[4].Text.ToString());
                            if (InsertComplain(CellI, ChildTicket))
                            {
                                CircuitCount = CircuitCount + 1;
                            }

                        }
                    }


                }
            }
            catch (Exception ex)
            {
                //Interaction.MsgBox(ex.Message, MsgBoxStyle.Critical, Title: "Message Box");
            }

        }

        #endregion

    }
}