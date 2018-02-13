using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using RainMaker.BSS_Service;

namespace RainMaker.UserControls
{
    public partial class cntViewCustomerInfromation : System.Web.UI.UserControl
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
            string click = base.Request.QueryString["click"];
            if (click == "ViewCircuitTransaction")
            {
                SignupID = Convert.ToInt32(base.Request.QueryString["SignupID"]);
                loadCircuitCompleteDetails(SignupID);
            }
        }

        private void loadCircuitCompleteDetails(int SignupID)
        {
            dynamic dt = objBSS.GetCircuitCompleteDetail(SignupID);

            if (dt.Rows.Count == 1)
            {
                lblCircuitName.Text = Convert.ToString(dt.Rows[0]["CircuitName"]);
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
                tbDeploymentDate.Text = Convert.ToString(dt.Rows[0]["DeploymentDate"]);
                tbDeploymentPerson.Text = Convert.ToString(dt.Rows[0]["EngineerName"]);
                tbKAMContactNo.Text = Convert.ToString(dt.Rows[0]["Contact_Phone"]);
                tbKeyAccountManager.Text = Convert.ToString(dt.Rows[0]["SalesPersonName"]);
                tb3rdPartyAccountID.Text = Convert.ToString(dt.Rows[0]["ThirdPartyAccountID"]);
                
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
    }
}