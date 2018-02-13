using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using RainMaker.BSS_Service;
using System.Data;
using Telerik.Web.UI;
using System.Drawing;

namespace RainMaker.UserControls
{
    public partial class cntComplainHistory : System.Web.UI.UserControl
    {

        int SignupID = 0;
        string CMSID = "";

        Service1SoapClient objBSS = new Service1SoapClient();
        BL obl = new BL();
        static DataTable dt;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string click = base.Request.QueryString["click"];
                if (click == "ViewSignupTransaction")
                {
                    SignupID = Convert.ToInt32(base.Request.QueryString["SignUpID"]);
                    CMSID = Convert.ToString(base.Request.QueryString["CMSID"]);
                    LoadCustomer(SignupID);
                    loadCircuitHistory(SignupID, CMSID);
                }
            }
        }

        public void LoadCustomer(int SignupID)
        {
            try
            {
                var dt = objBSS.GetCustomerSignupsbySignupID(SignupID);
                if (dt.Rows.Count > 0)
                {
                    lblName.InnerHtml = dt.Rows[0]["CircuitName"].ToString();
                    //AppDomain.CurrentDomain.SetData("Complain_CiruitName", dt.Rows(0)("CircuitName"));
                    lblAddress.InnerHtml = dt.Rows[0]["Address"].ToString();
                    lblSalesPerson.InnerHtml = dt.Rows[0]["SalesPersonName"].ToString();
                }
            }
            catch (Exception ex)
            {

            }

        }

        private void loadCircuitHistory(int SignupID, string CMSID)
        {
            try
            {
                var dt = objBSS.GetCustomerComplainHistroy(SignupID, CMSID);
                if (dt.Rows.Count != 0)
                {
                    GvCustomerOldCompTran.DataSource = dt;
                    GvCustomerOldCompTran.DataBind();
                    GvCustomerOldCompTran.MasterTableView.GetColumn("colView").Visible = true;
                   // CheckCircuitFLag();
                }
                else
                {
                    GvCustomerOldCompTran.DataSource = null;
                    GvCustomerOldCompTran.DataBind();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void CheckCircuitFLag()
        {
            try
            {
                if (GvCustomerOldCompTran.Items.Count > 0)
                {
                    foreach (GridDataItem item in GvCustomerOldCompTran.Items)
                    {
                        if (Convert.ToInt32(item["Flag"].Text) == 1)
                        {
                            item["colForwardComplain"].BackColor = Color.Gray;
                        }
                        else if (Convert.ToInt32(item["Flag"].Text) == 0)
                        {
                           item["colForwardComplain"].BackColor = Color.White;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected void GvCustomerOldCompTran_ItemCommand(object sender, GridCommandEventArgs e)
        {
            int index = e.Item.ItemIndex;
            GridDataItem item = (GridDataItem)GvCustomerOldCompTran.Items[index];
            Session["ComplainID"] = item["ComplaintID"].Text;
            string click = "View Hostory ComplaiID";
            Response.Redirect("~\\ComplainManagement\\ViewHistory.aspx?click=" + click);
           
            
                
        }

    }
}