using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using RainMaker.BSS_Service;

namespace RainMaker.UserControls
{
    public partial class cntWebIssue : System.Web.UI.UserControl
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
                //Interaction.MsgBox("cntWebIssue_Load:" + ex.Message + "of cntWebIssue ", MsgBoxStyle.Critical, "BSS Addminstrator");
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
                string AssignedDNS = GetTroubleShootValue(pnlTS41_1AssignedDNS);
                string DNSResponding = GetTroubleShootValue(pnlTS41_3DNSResponding);
                string IsIPBlockedbyPTA = "";
                string EmailIssueIn = "";
                string EmailDomain = "";
                string MPPLSMTP_POPResponse = "";
                string MPPLSMTP_POPTelnet = "";
                string EmailIssueOn = "'";
                string FacingEmailIssueAt = "";
                string ISIPBlackListed = "";
                string ISWebsiteReachable = GetTroubleShootValue(pnlTS41_2Website);
                string CustomerQuery = "";
                string Remarks = tbTS41_4Remarks.Text;

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
                if (!CheckAnyValueIsEmpty(pnlTS41_1AssignedDNS))
                {
                    return false;
                }

                if (!CheckAnyValueIsEmpty(pnlTS41_2Website))
                {
                    return false;
                }

                if (!CheckAnyValueIsEmpty(pnlTS41_3DNSResponding))
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

        public void DignoseFormSenerio(string Flag, int ComplainID)
        {
            try
            {
                if (Flag == "Insert")
                {
                    objBL.CreateDynamicRadioButton("AssignedDNS", pnlTS41_1AssignedDNS);
                    objBL.CreateDynamicRadioButton("ISWebsiteReachable", pnlTS41_2Website);
                    objBL.CreateDynamicRadioButton("DNSResponding", pnlTS41_3DNSResponding);
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
                    objBL.CreateDynamicRadioButtonOnView("AssignedDNS", pnlTS41_1AssignedDNS, dt.Rows[0]["AssignedDNS"]);
                    objBL.CreateDynamicRadioButtonOnView("ISWebsiteReachable", pnlTS41_2Website, dt.Rows[0]["ISWebsiteReachable"]);
                    objBL.CreateDynamicRadioButtonOnView("DNSResponding", pnlTS41_3DNSResponding, dt.Rows[0]["DNSResponding"]);
                    tbTS41_4Remarks.Text = dt.Rows[0]["Remarks"];
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}