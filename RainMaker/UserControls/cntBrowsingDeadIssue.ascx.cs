using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using RainMaker.BSS_Service;

namespace RainMaker.UserControls
{
    public partial class cntBrowsingDeadIssue : System.Web.UI.UserControl
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
                // Interaction.MsgBox("cntBrowsingDeadissue_Load:" + ex.Message + "of cntBrowsingDeadissue ", MsgBoxStyle.Critical, "BSS Addminstrator");
            }

        }

        public bool InsertComplainTrouble(int CompID)
        {
            try
            {
                string ComplainID = Convert.ToString(CompID);
                string NodePortStatus = GetTroubleShootValue(pnlTS21_1NodePortStatus);
                string NodePortTrafficStatus = GetTroubleShootValue(pnlTS21_2TrafficStatusatNodePort);
                string NodePortTrafficUtilization = GetTroubleShootValue(pnlTS21_3TrafficUtilizationatNodePort);
                string NodePortErrDiscard = GetTroubleShootValue(pnlTS21_6ErrorDiscards);
                string STGTrafficUtilization = GetTroubleShootValue(pnlTS21_4TrafficUtilizationatSTG);
                string CTGTrafficUtilization = GetTroubleShootValue(pnlTS21_5TrafficUtilizationatCTG);
                string LastMilePowerStatus = GetTroubleShootValue(pnlTS21_7LastMileDevicePowerStatus);
                string FiberLEDStatus = GetTroubleShootValue(pnlTS22_1FiberLEDStatus);
                string CPEStaus = GetTroubleShootValue(pnlTS21_8CPEStatus);
                string CEInterfaceStatus = GetTroubleShootValue(pnlTS22_3CEInterfaceStatus);
                string CETrafficStatus = GetTroubleShootValue(pnlTS22_2TrafficStatusatCEInterface);
                string BandwidthUtilization = GetTroubleShootValue(pnlTS22_4BandwidthUtilization);
                string DeviceRebooted = GetTroubleShootValue(pnlTS22_5DeviceRebooted);
                string CustomerIPResponses = GetTroubleShootValue(pnlTS22_6CustomerIPResponse);
                string CustomerBandwidthIssue = null;
                if (cmbTS22_7CustomerBandwidthIssue.SelectedValue != "Please-Select")
                {
                    CustomerBandwidthIssue = Convert.ToString(cmbTS22_7CustomerBandwidthIssue.Text);
                }
                else
                {
                    CustomerBandwidthIssue = "";
                }
                string GatewayResponses = GetTroubleShootValue(pnlTS23_1GatewayResponses);
                string AssignedDNS = GetTroubleShootValue(pnlTS23_2AssignedDNS);
                string DNSResponding = GetTroubleShootValue(pnlTS23_3DNSResponding);
                string IsIPBlockedbyPTA = GetTroubleShootValue(pnlTS23_4IPBlockedbyPTA);
                string EmailIssueIn = "";
                string EmailDomain = "";
                string MPPLSMTP_POPResponse = "";
                string MPPLSMTP_POPTelnet = "";
                string EmailIssueOn = "";
                string FacingEmailIssueAt = "";
                string ISIPBlackListed = "";
                string ISWebsiteReachable = "";
                string CustomerQuery = "";
                string Remarks = tbTS23_5Remarks.Text;

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
                if (!CheckAnyValueIsEmpty(pnlTS21_1NodePortStatus))
                {
                    return false;
                }

                if (!CheckAnyValueIsEmpty(pnlTS21_2TrafficStatusatNodePort))
                {
                    return false;
                }

                if (!CheckAnyValueIsEmpty(pnlTS21_3TrafficUtilizationatNodePort))
                {
                    return false;
                }

                if (!CheckAnyValueIsEmpty(pnlTS21_6ErrorDiscards))
                {
                    return false;
                }

                if (!CheckAnyValueIsEmpty(pnlTS21_4TrafficUtilizationatSTG))
                {
                    return false;
                }

                if (!CheckAnyValueIsEmpty(pnlTS21_5TrafficUtilizationatCTG))
                {
                    return false;
                }

                if (!CheckAnyValueIsEmpty(pnlTS21_7LastMileDevicePowerStatus))
                {
                    return false;

                }

                if (!CheckAnyValueIsEmpty(pnlTS22_1FiberLEDStatus))
                {
                    return false;
                }

                if (!CheckAnyValueIsEmpty(pnlTS21_8CPEStatus))
                {
                    return false;
                }

                if (!CheckAnyValueIsEmpty(pnlTS22_3CEInterfaceStatus))
                {
                    return false;
                }

                if (!CheckAnyValueIsEmpty(pnlTS22_2TrafficStatusatCEInterface))
                {
                    return false;
                }

                if (!CheckAnyValueIsEmpty(pnlTS22_4BandwidthUtilization))
                {
                    return false;
                }

                if (!CheckAnyValueIsEmpty(pnlTS22_5DeviceRebooted))
                {
                    return false;
                }


                if (!CheckAnyValueIsEmpty(pnlTS22_6CustomerIPResponse))
                {
                    return false;
                }


                if (cmbTS22_7CustomerBandwidthIssue.SelectedValue == "Please-Select")
                {
                    return false;
                }


                if (!CheckAnyValueIsEmpty(pnlTS23_1GatewayResponses))
                {
                    return false;
                }


                if (!CheckAnyValueIsEmpty(pnlTS23_2AssignedDNS))
                {
                    return false;
                }


                if (!CheckAnyValueIsEmpty(pnlTS23_3DNSResponding))
                {
                    return false;
                }


                if (!CheckAnyValueIsEmpty(pnlTS23_4IPBlockedbyPTA))
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
                    objBL.CreateDynamicRadioButton("NodePortStatus", pnlTS21_1NodePortStatus);
                    objBL.CreateDynamicRadioButton("NodePortTrafficStatus", pnlTS21_2TrafficStatusatNodePort);
                    objBL.CreateDynamicRadioButton("NodePortTrafficUtilization", pnlTS21_3TrafficUtilizationatNodePort);
                    objBL.CreateDynamicRadioButton("STGTrafficUtilization", pnlTS21_4TrafficUtilizationatSTG);
                    objBL.CreateDynamicRadioButton("CTGTrafficUtilization", pnlTS21_5TrafficUtilizationatCTG);
                    objBL.CreateDynamicRadioButton("NodePortErrDiscard", pnlTS21_6ErrorDiscards);
                    objBL.CreateDynamicRadioButton("LastMilePowerStatus", pnlTS21_7LastMileDevicePowerStatus);
                    objBL.CreateDynamicRadioButton("CPEStatus", pnlTS21_8CPEStatus);
                    objBL.CreateDynamicRadioButton("FiberLEDStatus", pnlTS22_1FiberLEDStatus);
                    objBL.CreateDynamicRadioButton("CETrafficStatus", pnlTS22_2TrafficStatusatCEInterface);
                    objBL.CreateDynamicRadioButton("CEInterfaceStatus", pnlTS22_3CEInterfaceStatus);
                    objBL.CreateDynamicRadioButton("BandwidthUtilization", pnlTS22_4BandwidthUtilization);
                    objBL.CreateDynamicRadioButton("DeviceRebooted", pnlTS22_5DeviceRebooted);
                    objBL.CreateDynamicRadioButton("CustomerIPResponses", pnlTS22_6CustomerIPResponse);
                    objBL.CreateDynamicRadioButton("FacingBandwisthIssueAt", pnlTS22_7CustomerBandwidthIssue);
                    objBL.CreateDynamicRadioButton("GatewayResponses", pnlTS23_1GatewayResponses);
                    objBL.CreateDynamicRadioButton("AssignedDNS", pnlTS23_2AssignedDNS);
                    objBL.CreateDynamicRadioButton("DNSResponding", pnlTS23_3DNSResponding);
                    objBL.CreateDynamicRadioButton("IsIPBlockedbyPTA", pnlTS23_4IPBlockedbyPTA);
                    objBL.LoadCustBandwidthIssue(cmbTS22_7CustomerBandwidthIssue);
                }
                else if (Flag == "View" & ComplainID != 0)
                {
                    

                    GetComplainTroubleDetails(ComplainID);
                    objBL.LoadCustBandwidthIssue(cmbTS22_7CustomerBandwidthIssue);

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
                    objBL.CreateDynamicRadioButtonOnView("NodePortStatus", pnlTS21_1NodePortStatus, dt.Rows[0]["NodePortStatus"]);
                    objBL.CreateDynamicRadioButtonOnView("NodePortTrafficStatus", pnlTS21_2TrafficStatusatNodePort, dt.Rows[0]["NodePortTrafficStatus"]);
                    objBL.CreateDynamicRadioButtonOnView("NodePortTrafficUtilization", pnlTS21_3TrafficUtilizationatNodePort, dt.Rows[0]["NodePortTrafficUtilization"]);
                    objBL.CreateDynamicRadioButtonOnView("STGTrafficUtilization", pnlTS21_4TrafficUtilizationatSTG, dt.Rows[0]["STGTrafficUtilization"]);
                    objBL.CreateDynamicRadioButtonOnView("CTGTrafficUtilization", pnlTS21_5TrafficUtilizationatCTG, dt.Rows[0]["CTGTrafficUtilization"]);
                    objBL.CreateDynamicRadioButtonOnView("NodePortErrDiscard", pnlTS21_6ErrorDiscards, dt.Rows[0]["NodePortErrDiscard"]);
                    objBL.CreateDynamicRadioButtonOnView("LastMilePowerStatus", pnlTS21_7LastMileDevicePowerStatus, dt.Rows[0]["LastMilePowerStatus"]);
                    objBL.CreateDynamicRadioButtonOnView("CPEStatus", pnlTS21_8CPEStatus, dt.Rows[0]["CPEStaus"]);
                    objBL.CreateDynamicRadioButtonOnView("FiberLEDStatus", pnlTS22_1FiberLEDStatus, dt.Rows[0]["FiberLEDStatus"]);
                    objBL.CreateDynamicRadioButtonOnView("CETrafficStatus", pnlTS22_2TrafficStatusatCEInterface, dt.Rows[0]["CETrafficStatus"]);
                    objBL.CreateDynamicRadioButtonOnView("CEInterfaceStatus", pnlTS22_3CEInterfaceStatus, dt.Rows[0]["CEInterfaceStatus"]);
                    objBL.CreateDynamicRadioButtonOnView("BandwidthUtilization", pnlTS22_4BandwidthUtilization, dt.Rows[0]["BandwidthUtilization"]);
                    objBL.CreateDynamicRadioButtonOnView("DeviceRebooted", pnlTS22_5DeviceRebooted, dt.Rows[0]["DeviceRebooted"]);
                    objBL.CreateDynamicRadioButtonOnView("CustomerIPResponses", pnlTS22_6CustomerIPResponse, dt.Rows[0]["CustomerIPResponses"]);
                    cmbTS22_7CustomerBandwidthIssue.Text = dt.Rows[0]["CustomerBandwidthIssue"];
                    objBL.CreateDynamicRadioButtonOnView("GatewayResponses", pnlTS23_1GatewayResponses, dt.Rows[0]["GatewayResponses"]);
                    objBL.CreateDynamicRadioButtonOnView("AssignedDNS", pnlTS23_2AssignedDNS, dt.Rows[0]["AssignedDNS"]);
                    objBL.CreateDynamicRadioButtonOnView("DNSResponding", pnlTS23_3DNSResponding, dt.Rows[0]["DNSResponding"]);
                    objBL.CreateDynamicRadioButtonOnView("IsIPBlockedbyPTA", pnlTS23_4IPBlockedbyPTA, dt.Rows[0]["IsIPBlockedbyPTA"]);
                    tbTS23_5Remarks.Text = dt.Rows[0]["Remarks"];

                    

                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}