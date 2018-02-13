using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using RainMaker.BSS_Service;

namespace RainMaker.UserControls
{
    public partial class cntIntial_linkDownDrops : System.Web.UI.UserControl
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
                //Interaction.MsgBox("cntIntial_LinkDownDrops_Load:" + ex.Message + "of cntIntial_LinkDownDrops ", MsgBoxStyle.Critical, "BSS Addminstrator");
            }
        }

        public void DignoseFormSenerio(string Flag, int ComplainID)
        {
            try
            {
                if (Flag == "Insert")
                {
                    objBL.CreateDynamicRadioButton("NodePortStatus", pnlTS11_1NodePortStatus);
                    objBL.CreateDynamicRadioButton("NodePortTrafficStatus", pnlTS11_2TrafficStatusatNodePort);
                    objBL.CreateDynamicRadioButton("NodePortTrafficUtilization", pnlTS11_3TrafficUtilizationatNodePort);
                    objBL.CreateDynamicRadioButton("STGTrafficUtilization", pnlTS11_4TrafficUtilizationonSTG);
                    objBL.CreateDynamicRadioButton("CTGTrafficUtilization", pnlTS11_5TrafficUtilizationonCTG);
                    objBL.CreateDynamicRadioButton("NodePortErrDiscard", pnlTS11_6ErrorDiscardsatNodePort);
                    objBL.CreateDynamicRadioButton("LastMilePowerStatus", pnlTS11_7LastMileDevicePowerStatus);
                    objBL.CreateDynamicRadioButton("CPEStatus", pnlTS11_8CPEStatus);
                    objBL.CreateDynamicRadioButton("FiberLEDStatus", pnlTS12_1FiberLEDStatus);
                    objBL.CreateDynamicRadioButton("CETrafficStatus", pnlTS12_2TrafficStatusatCEInterface);
                    objBL.CreateDynamicRadioButton("CEInterfaceStatus", pnlTS11_9CEInterfaceStatus);
                    objBL.CreateDynamicRadioButton("BandwidthUtilization", pnlTS12_3BandwidthUtilization);
                    objBL.CreateDynamicRadioButton("DeviceRebooted", pnlTS12_4DeviceRebooted);
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
                    objBL.CreateDynamicRadioButtonOnView("NodePortStatus", pnlTS11_1NodePortStatus, dt.Rows[0]["NodePortStatus"]);
                    objBL.CreateDynamicRadioButtonOnView("NodePortTrafficStatus", pnlTS11_2TrafficStatusatNodePort, dt.Rows[0]["NodePortTrafficStatus"]);
                    objBL.CreateDynamicRadioButtonOnView("NodePortTrafficUtilization", pnlTS11_3TrafficUtilizationatNodePort, dt.Rows[0]["NodePortTrafficUtilization"]);
                    objBL.CreateDynamicRadioButtonOnView("STGTrafficUtilization", pnlTS11_4TrafficUtilizationonSTG, dt.Rows[0]["STGTrafficUtilization"]);
                    objBL.CreateDynamicRadioButtonOnView("CTGTrafficUtilization", pnlTS11_5TrafficUtilizationonCTG, dt.Rows[0]["CTGTrafficUtilization"]);
                    objBL.CreateDynamicRadioButtonOnView("NodePortErrDiscard", pnlTS11_6ErrorDiscardsatNodePort, dt.Rows[0]["NodePortErrDiscard"]);
                    objBL.CreateDynamicRadioButtonOnView("LastMilePowerStatus", pnlTS11_7LastMileDevicePowerStatus, dt.Rows[0]["LastMilePowerStatus"]);
                    objBL.CreateDynamicRadioButtonOnView("CPEStatus", pnlTS11_8CPEStatus, dt.Rows[0]["CPEStaus"]);
                    objBL.CreateDynamicRadioButtonOnView("FiberLEDStatus", pnlTS12_1FiberLEDStatus, dt.Rows[0]["FiberLEDStatus"]);
                    objBL.CreateDynamicRadioButtonOnView("CETrafficStatus", pnlTS12_2TrafficStatusatCEInterface, dt.Rows[0]["CETrafficStatus"]);
                    objBL.CreateDynamicRadioButtonOnView("CEInterfaceStatus", pnlTS11_9CEInterfaceStatus, dt.Rows[0]["CEInterfaceStatus"]);
                    objBL.CreateDynamicRadioButtonOnView("BandwidthUtilization", pnlTS12_3BandwidthUtilization, dt.Rows[0]["BandwidthUtilization"]);
                    objBL.CreateDynamicRadioButtonOnView("DeviceRebooted", pnlTS12_4DeviceRebooted, dt.Rows[0]["DeviceRebooted"]);
                    tbTS12_5Remarks.Text = dt.Rows[0]["Remarks"];
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool InsertComplainTrouble(int CompID)
        {

            try
            {
                string ComplainID = Convert.ToString(CompID);
                string NodePortStatus = GetTroubleShootValue(pnlTS11_1NodePortStatus);
                string NodePortTrafficStatus = GetTroubleShootValue(pnlTS11_2TrafficStatusatNodePort);
                string NodePortTrafficUtilization = GetTroubleShootValue(pnlTS11_3TrafficUtilizationatNodePort);
                string NodePortErrDiscard = GetTroubleShootValue(pnlTS11_6ErrorDiscardsatNodePort);
                string STGTrafficUtilization = GetTroubleShootValue(pnlTS11_4TrafficUtilizationonSTG);
                string CTGTrafficUtilization = GetTroubleShootValue(pnlTS11_5TrafficUtilizationonCTG);
                string LastMilePowerStatus = GetTroubleShootValue(pnlTS11_7LastMileDevicePowerStatus);
                string FiberLEDStatus = GetTroubleShootValue(pnlTS12_1FiberLEDStatus);
                string CPEStaus = GetTroubleShootValue(pnlTS11_8CPEStatus);
                string CEInterfaceStatus = GetTroubleShootValue(pnlTS11_9CEInterfaceStatus);
                string CETrafficStatus = GetTroubleShootValue(pnlTS12_2TrafficStatusatCEInterface);
                string BandwidthUtilization = GetTroubleShootValue(pnlTS12_3BandwidthUtilization);
                string DeviceRebooted = GetTroubleShootValue(pnlTS12_4DeviceRebooted);
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
                string EmailIssueOn = "";
                string FacingEmailIssueAt = "";
                string ISIPBlackListed = "";
                string ISWebsiteReachable = "";
                string CustomerQuery = "";
                string Remarks = tbTS12_5Remarks.Text;

                if (objBSS.InsertComplainTroubleshooting(ComplainID, NodePortStatus, NodePortTrafficStatus, NodePortTrafficUtilization, NodePortErrDiscard, STGTrafficUtilization, CTGTrafficUtilization, LastMilePowerStatus, FiberLEDStatus, CPEStaus,
                CEInterfaceStatus, CETrafficStatus, BandwidthUtilization, DeviceRebooted, CustomerIPResponses, CustomerBandwidthIssue, GatewayResponses, AssignedDNS, DNSResponding, IsIPBlockedbyPTA,
                EmailIssueIn, EmailDomain, MPPLSMTP_POPResponse, MPPLSMTP_POPTelnet, FacingEmailIssueAt, EmailIssueOn, ISIPBlackListed, ISWebsiteReachable, CustomerQuery, Remarks))
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
                if (!CheckAnyValueIsEmpty(pnlTS11_1NodePortStatus))
                {
                    return false;
                }

                if (!CheckAnyValueIsEmpty(pnlTS11_2TrafficStatusatNodePort))
                {
                    return false;
                }

                if (!CheckAnyValueIsEmpty(pnlTS11_3TrafficUtilizationatNodePort))
                {
                    return false;
                }

                if (!CheckAnyValueIsEmpty(pnlTS11_6ErrorDiscardsatNodePort))
                {
                    return false;
                }

                if (!CheckAnyValueIsEmpty(pnlTS11_4TrafficUtilizationonSTG))
                {
                    return false;
                }

                if (!CheckAnyValueIsEmpty(pnlTS11_5TrafficUtilizationonCTG))
                {
                    return false;
                }

                if (!CheckAnyValueIsEmpty(pnlTS11_7LastMileDevicePowerStatus))
                {
                    return false;
                }

                if (!CheckAnyValueIsEmpty(pnlTS12_1FiberLEDStatus))
                {
                    return false;
                }

                if (!CheckAnyValueIsEmpty(pnlTS11_8CPEStatus))
                {
                    return false;
                }

                if (!CheckAnyValueIsEmpty(pnlTS11_9CEInterfaceStatus))
                {
                    return false;
                }

                if (!CheckAnyValueIsEmpty(pnlTS12_2TrafficStatusatCEInterface))
                {
                    return false;
                }

                if (!CheckAnyValueIsEmpty(pnlTS12_3BandwidthUtilization))
                {
                    return false;
                }

                if (!CheckAnyValueIsEmpty(pnlTS12_4DeviceRebooted))
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
            try {
            string val = String.Empty;
                
                var rd = pnl.Controls.OfType<RadioButton>().FirstOrDefault(c => c.Checked == true);
            if ((rd.Text == null)) {
                val = String.Empty;
            }
            else {
                val = rd.Text.ToString();
            }
            
            return val;
        }
        catch (Exception ex) {
            throw ex;
        }
        }

    }
}