using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using RainMaker.Classes;
using RainMaker.BSS_Service;
using System.Data;
using System.Drawing;
using Telerik.Web.UI;

namespace RainMaker.ComplainManagement
{
    public partial class Searching_Criterion : System.Web.UI.Page
    {
        BL obl = new BL();
        Service1SoapClient objBSS = new Service1SoapClient();
        static DataTable dtForExcel;
       

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadCombo();
                dtSLA.SelectedDate = DateTime.Now;
                
            }
        }

        public void LoadCombo()
        {
            obl.loadCusCode(cmbCustomerCode,null,"Serach");
        }

        protected void btSearch_Click(object sender, EventArgs e)
        {
            SearchCustomerDetails();
        }

        protected void btnExportCM_Click(object sender, EventArgs e)
        {
            Session["REPORT"] = "SearchingCriterion";
            DataView ds = new DataView(dtForExcel);
            Session["ds"] = ds;
            Response.Redirect("~\\ComplainManagement\\DownloadExcelFile.aspx");
        
        }

        protected void btnClear_Click(object sender, EventArgs e)
        {

        }

        protected void btnBack_Click(object sender, EventArgs e)
        {

        }


        private void CountDiffernetDomain(string Flag, int RegionID, int StatusID, Label lbl)
        {
            try
            {
                DataTable dt;

                
                    if(tbExtraIPPool.Text != "")
                    {
                        dt= objBSS.GetcountofCircuits(0, "", "", RegionID, StatusID, "",Convert.ToInt16(cmbCustomerCode.SelectedValue), tbCustomerIPPool.Text, 1, tbExtraIPPool.Text, 0, 0, Flag);
                    }
                    else
                    {
                        dt = objBSS.GetcountofCircuits(0, "", "", RegionID, StatusID, "", Convert.ToInt16(cmbCustomerCode.SelectedValue), tbCustomerIPPool.Text, 0, tbExtraIPPool.Text, 0, 0, Flag);
                    }
                
                if ((Flag == "Count"))
                {
                    if ((dt.Rows.Count == 1))
                    {
                        lbl.Text = dt.Rows[0]["CircuitCount"].ToString();                        
                        //lblNoRecord.Visible = false;
                    }
                    else
                    {
                        lbl.Text = "0";
                    }

                }

                if ((Flag == "Details"))
                {
                    if ((dt.Rows.Count != 0))
                    {
                        lbl.Text = dt.Rows[0]["Customer"].ToString();
                         ClearFilter();
                        //lblNoRecord.Visible = false;
                    }
                    else
                    {
                        lbl.Text = "0";
                    }

                }

                if ((Flag == "Complains"))
                {
                    if ((dt.Rows.Count != 0))
                    {
                        lbl.Text = dt.Rows[0]["CircuitCount"].ToString();
                        this.ClearFilter();
                        //lblNoRecord.Visible = false;
                    }
                    else
                    {
                        lbl.Text = "0";
                    }

                }

            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        private void ClearFilter()
        {
            try
            {
                tbCustomerIPPool.Text = String.Empty;
                //  cmbCustomer.SelectedValue = 0
                tbExtraIPPool.Text = String.Empty;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        private void GetCustomerSLA(int RegionID)
        {
            try
            {

                
                DataTable dt = objBSS.GetCustomerSLA(Convert.ToInt16(cmbCustomerCode.SelectedValue), RegionID,"4",Convert.ToDateTime(dtSLA.SelectedDate));
                dtForExcel = new DataTable();
                dtForExcel = dt;
                if ((dt.Rows.Count > 0))
                {
                    gvCircuitSLAView.DataSource = dt;
                    gvCircuitSLAView.DataBind();


                    checkMonthSLA();
                    checkYearSLA();

                    gvCircuitSLAView.MasterTableView.GetColumn("ViewComplain").Display = true;
                }
                else
                {
                    gvCircuitSLAView.DataSource = null;
                    gvCircuitSLAView.MasterTableView.GetColumn("ViewComplain").Display = true;
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        private void SearchCustomerDetails()
        {
            try
            {
                if ((cmbCustomerCode.SelectedValue != "0"))
                {
                    this.CountDiffernetDomain("Count", 1, 4, lblNorthCount);
                    this.CountDiffernetDomain("Count", 2, 4, lblSouthCount);
                    this.CountDiffernetDomain("Count", 3, 4, lblCentralCount);
                    this.CountDiffernetDomain("Count", 0, 4, lblAllCount);
                    this.CountDiffernetDomain("Count", 0, 4, lblTotalActive);
                    this.CountDiffernetDomain("Count", 0, 5, lblBlockCircuits);
                    this.CountDiffernetDomain("Complains", 0, 0, lblComplaintRec);
                    this.CountDiffernetDomain("Details", 0, 4, lblCustomerName);
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        protected void cmbCustomerCode_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        protected void lnkSounth_Click(object sender, EventArgs e)
        {
            GetCustomerSLA(2);
        }

        protected void LnkNorth_Click(object sender, EventArgs e)
        {
            GetCustomerSLA(1);
        }

        protected void lnkCentral_Click(object sender, EventArgs e)
        {
            GetCustomerSLA(3);
        }

        protected void linkAll_Click(object sender, EventArgs e)
        {
            GetCustomerSLA(0);
        }

        protected void gvCircuitSLAView_NeedDataSource(object sender, Telerik.Web.UI.GridNeedDataSourceEventArgs e)
        {
            if (!IsPostBack)
            {
                gvCircuitSLAView.DataSource = null;
            }
        }


        protected void gvCircuitSLAView_OnItemCommand(object sender, Telerik.Web.UI.GridCommandEventArgs e)
        {
            try
            {
                string Check = e.CommandName;
                int index = e.Item.ItemIndex;
                GridDataItem item = (GridDataItem)gvCircuitSLAView.Items[index];
                string click = "ViewCircuitTransaction";
                Response.Redirect("~\\ComplainManagement\\ViewHistory.aspx?SignupID=" + Convert.ToInt32(item["SignupID"].Text) + "&click=" + click);

            }
            catch (Exception ex)
            {
            }
            
        }


        private void checkMonthSLA()
        {
            try
            {
                if ((gvCircuitSLAView.Items.Count > 0))
                {
                    foreach (GridDataItem item in gvCircuitSLAView.Items)
                    {
                        if ((Convert.ToDouble(item["MontlySLA"].Text) >= 99.16))
                        {
                            item["MontlySLA"].ForeColor = Color.Green;
                        }
                        else if ((Convert.ToDouble(item["MontlySLA"].Text) < 99.16))
                        {
                            item["MontlySLA"].ForeColor = Color.Red;
                        }

                    }

                }

            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        private void checkYearSLA()
        {
            try
            {
                if ((gvCircuitSLAView.Items.Count > 0))
                {
                    foreach (GridDataItem item in gvCircuitSLAView.Items)
                    {
                        if ((Convert.ToDouble(item["YrarlySLA"].Text) >= 99.16))
                        {
                            item["YrarlySLA"].ForeColor = Color.Green;
                        }
                        else if ((Convert.ToDouble(item["YrarlySLA"].Text) < 99.16))
                        {
                            item["YrarlySLA"].ForeColor = Color.Red;
                        }

                    }

                }

            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
    }
}