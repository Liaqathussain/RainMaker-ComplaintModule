using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using RainMaker.BSS_Service;

namespace RainMaker.UserControls
{
    public partial class cntemailIsuee : System.Web.UI.UserControl
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
                //Interaction.MsgBox("cntemailIsuee_Load:" + ex.Message + "of cntIntial_LinkDownDrops ", MsgBoxStyle.Critical, "BSS Addminstrator");
            }

        }

        private void cntemailIsuee_Load(System.Object sender, System.EventArgs e)
        {


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
                string EmailIssueIn = GetTroubleShootValue(pnlTS31_1Issuein);
                string EmailDomain = GetTroubleShootValue(pnlTS31_2Domain);
                string MPPLSMTP_POPResponse = GetTroubleShootValue(pnlTS31_3MPPLResponse);
                string MPPLSMTP_POPTelnet = GetTroubleShootValue(pnlTS31_4MPPLTelnet);
                string EmailIssueOn = GetTroubleShootValue(pnlTS31_5IssueOn);
                string FacingEmailIssueAt = tbEmail_DomainFacingProblem.Text;
                string ISIPBlackListed = GetTroubleShootValue(pnlTS31_7IPBlacklisted);
                string ISWebsiteReachable = "";
                string CustomerQuery = "";
                string Remarks = tbTS31_8Remarks.Text;

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

      
        public bool CheckTroubleShooting()
        {
            try
            {
                if (!CheckAnyValueIsEmpty(pnlTS31_1Issuein))
                {
                    return false;
                }

                if (!CheckAnyValueIsEmpty(pnlTS31_2Domain))
                {
                    return false;
                }

                if (!CheckAnyValueIsEmpty(pnlTS31_3MPPLResponse))
                {
                    return false;
                }

                if (!CheckAnyValueIsEmpty(pnlTS31_4MPPLTelnet))
                {
                    return false;
                }

                if (!CheckAnyValueIsEmpty(pnlTS31_5IssueOn))
                {
                    return false;
                }

                if (tbEmail_DomainFacingProblem.Text == string.Empty)
                {
                    return false;
                }

                if (!CheckAnyValueIsEmpty(pnlTS31_7IPBlacklisted))
                {
                    return false;
                }

                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public string GetTroubleShootValue(Panel pnl)
        {
            try
            {
                string val = String.Empty;

                var rd = pnl.Controls.OfType<RadioButton>().FirstOrDefault(c => c.Checked == true);
                if ((rd.Text == null))
                {
                    val = String.Empty;
                }
                else
                {
                    val = rd.Text.ToString();
                }

                return val;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool CheckAnyValueIsEmpty(Panel pnl)
        {
            try
            {
                var rd = pnl.Controls.OfType<RadioButton>().FirstOrDefault(c => c.Checked == true);

                if (rd == null)
                {
                    return false;
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

        public void DignoseFormSenerio(string Flag, int ComplainID)
        {
            try
            {
                if (Flag == "Insert")
                {
                    objBL.CreateDynamicRadioButton("EmailIssueIn", pnlTS31_1Issuein);
                    objBL.CreateDynamicRadioButton("EmailDomain", pnlTS31_2Domain);
                    objBL.CreateDynamicRadioButton("MPPLSMTP_POPResponse", pnlTS31_3MPPLResponse);
                    objBL.CreateDynamicRadioButton("MPPLSMTP_POPTelnet", pnlTS31_4MPPLTelnet);
                    objBL.CreateDynamicRadioButton("EmailIssueOn", pnlTS31_5IssueOn);
                    objBL.CreateDynamicRadioButton("ISIPBlackListed", pnlTS31_7IPBlacklisted);
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
                    objBL.CreateDynamicRadioButtonOnView("EmailIssueIn", pnlTS31_1Issuein, dt.Rows[0]["EmailIssueIn"]);
                    objBL.CreateDynamicRadioButtonOnView("EmailDomain", pnlTS31_2Domain, dt.Rows[0]["EmailDomain"]);
                    objBL.CreateDynamicRadioButtonOnView("MPPLSMTP_POPResponse", pnlTS31_3MPPLResponse, dt.Rows[0]["MPPLSMTP_POPResponse"]);
                    objBL.CreateDynamicRadioButtonOnView("MPPLSMTP_POPTelnet", pnlTS31_4MPPLTelnet, dt.Rows[0]["MPPLSMTP_POPTelnet"]);
                    objBL.CreateDynamicRadioButtonOnView("EmailIssueOn", pnlTS31_5IssueOn, dt.Rows[0]["EmailIssueOn"]);
                    tbEmail_DomainFacingProblem.Text = dt.Rows[0]["FacingEmailIssueAt"];
                    objBL.CreateDynamicRadioButtonOnView("ISIPBlackListed", pnlTS31_7IPBlacklisted, dt.Rows[0]["ISIPBlackListed"]);
                    tbTS31_8Remarks.Text = dt.Rows[0]["Remarks"];
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}