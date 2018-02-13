using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace RainMaker.ComplainManagement
{
    public partial class ViewFiberDetails : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            BSS_Service.Service1SoapClient objBSS = new BSS_Service.Service1SoapClient();
            int _SignupID = 0;
            if (!IsPostBack)
            {
                //btSave.Attributes.Add("onclick", "popWin();return false;"); 
                _SignupID = Convert.ToInt32(base.Request.QueryString["SignupID"]);
                DataTable dt_FiberDetails = objBSS.GetFiberDetailsLogs(_SignupID);
                //grdFiberDetails.
                grdFiberDetails.DataSource = dt_FiberDetails;
                grdFiberDetails.DataBind();


            }

        }
    }
}