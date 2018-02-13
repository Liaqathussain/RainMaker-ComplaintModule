using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using RainMaker.Classes;
using Telerik.Web.UI;
using System.Data;

namespace RainMaker.ComplainManagement
{
    public partial class ViewHistory : System.Web.UI.Page
    {
        public static string click = "";
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

        BSS_Service.Service1SoapClient objBSS = new BSS_Service.Service1SoapClient();
        //BSS_ServiceLocal.Service1SoapClient objBSS = new BSS_ServiceLocal.Service1SoapClient();
        Cls_Territory objCls = new Cls_Territory();
        BL objBL = new BL();


        protected void gvActiveCircuits_ItemCommand(object sender, GridCommandEventArgs e)
        {

        }

        protected void Page_Load(object sender, EventArgs e)
        {
            
                click = base.Request.QueryString["click"].ToString();

                if (click == "ViewCircuitTransaction")
                {
                    pnlViewCustomerInfromation.Visible = true;
                    cntViewCustomerInfromation.Visible = true;
                    pnlviewcomphist.Visible = false;
                    cntviewcomphist.Visible = false;
                    pnlComplainHistorys.Visible = false;
                    cntComplainHistory.Visible = false;
                    
                }
                else if(click == "View History" || click=="View Hostory ComplaiID")
                {
                   pnlviewcomphist.Visible = true;
                   cntviewcomphist.Visible = true;

                   pnlViewCustomerInfromation.Visible = false;
                   cntViewCustomerInfromation.Visible = false;
                   
                   pnlComplainHistorys.Visible = false;
                   cntComplainHistory.Visible = false;
                }

                else if (click == "ViewSignupTransaction")
                {
                    pnlComplainHistorys.Visible = true;
                    cntComplainHistory.Visible = true;

                    pnlviewcomphist.Visible = false;
                    cntviewcomphist.Visible = false;

                    pnlViewCustomerInfromation.Visible = false;
                    cntViewCustomerInfromation.Visible = false;
                    
                }

                
                   
                
            }

        
        

      

    }
}