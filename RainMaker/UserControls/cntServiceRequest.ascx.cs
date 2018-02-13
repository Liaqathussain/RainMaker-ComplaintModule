using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using RainMaker.BSS_Service;

namespace RainMaker.UserControls
{
    public partial class cntServiceRequest : System.Web.UI.UserControl
    {
        BL objBL = new BL();
        Service1SoapClient objBSS = new Service1SoapClient();

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (Session["Flag"].ToString() == "View")
                {
                    if (!IsPostBack)
                    {
                        DignoseFormSenerio(Session["Flag"].ToString(), Convert.ToInt32(Session["ComplainID"]));
                    }
                }
                else
                {
                    if (IsPostBack)
                    {
                        DignoseFormSenerio(Session["Flag"].ToString(), Convert.ToInt32(Session["ComplainID"]));
                    }
                }
            }
            catch (Exception ex)
            {
                //Interaction.MsgBox("cntServiceRequest:" + ex.Message + "of cntServiceRequest_Load ", MsgBoxStyle.Critical, "BSS Addminstrator");
            }
        }

        public bool InsertComplainTrouble(int CompID)
        {

            try
            {
                string ComplainID = Convert.ToString(CompID);
                string NodePortStatus = "";
                string NodePortTrafficStatus = "";
                string NodePortTrafficUtilization = "";
                string NodePortErrDiscard = "";
                string STGTrafficUtilization = "";
                string CTGTrafficUtilization = "";
                string LastMilePowerStatus = "";
                string FiberLEDStatus = "";
                string CPEStaus = "";
                string CEInterfaceStatus = "";
                string CETrafficStatus = "";
                string BandwidthUtilization = "";
                string DeviceRebooted = "";
                string CustomerIPResponses = "";
                string CustomerBandwidthIssue = "";
                string GatewayResponses = "";
                string AssignedDNS = "";
                string DNSResponding = "";
                string IsIPBlockedbyPTA = "";
                string EmailIssueIn = "";
                string EmailDomain = "";
                string MPPLSMTP_POPResponse = "";
                string MPPLSMTP_POPTelnet = "";
                string EmailIssueOn = "'";
                string FacingEmailIssueAt = "";
                string ISIPBlackListed = "";
                string ISWebsiteReachable = "";
                string CustomerQuery = tbTS51_1CustomerRequest.Text;
                string Remarks = tbTS51_2Remarks.Text;

                if (objBSS.InsertComplainTroubleshooting(ComplainID, NodePortStatus, NodePortTrafficStatus, NodePortTrafficUtilization, NodePortErrDiscard, STGTrafficUtilization, CTGTrafficUtilization, LastMilePowerStatus, FiberLEDStatus, CPEStaus,
                CEInterfaceStatus, CETrafficStatus, BandwidthUtilization, DeviceRebooted, CustomerIPResponses, CustomerBandwidthIssue, GatewayResponses, AssignedDNS, DNSResponding, IsIPBlockedbyPTA,
                EmailIssueIn, EmailDomain, MPPLSMTP_POPResponse, MPPLSMTP_POPTelnet, EmailIssueOn, FacingEmailIssueAt, ISIPBlackListed, ISWebsiteReachable, CustomerQuery, Remarks))
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
                return false;
            }
        }

        public void DignoseFormSenerio(string Flag, int ComplainID)
        {
            try
            {

                if (Flag == "Insert")
                {
                }
                else if (Flag == "View" & ComplainID != 0)
                {
                    GetComplainTroubleDetails(ComplainID);

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

        public void GetComplainTroubleDetails(int ComplainID)
        {
            try
            {
                dynamic dt = objBSS.GetComplainTroubleShooting_ByComplainID(ComplainID);
                if (dt.Rows.Count == 1)
                {
                    tbTS51_1CustomerRequest.Text = dt.Rows[0]["CustomerQuery"];
                    tbTS51_2Remarks.Text = dt.Rows[0]["Remarks"];
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}