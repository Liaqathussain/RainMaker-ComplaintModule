using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using RainMaker.Classes;
using RainMaker.BSS_Service;
using Telerik.Web.UI;
using System.Data;

namespace RainMaker.ComplainManagement
{
    public partial class ComplainManager : System.Web.UI.Page
    {

        int DeptID;
        BL objBL = new BL();
        //BSS_ServiceLocal.Service1SoapClient objBSS = new BSS_ServiceLocal.Service1SoapClient();
        BSS_Service.Service1SoapClient objBSS = new BSS_Service.Service1SoapClient();

        #region EVENTS
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                DeptID = Convert.ToInt16(Session["DepartmentID"]);
                LoadCombos();
            }
        }



        protected void btSearch_Click(object sender, EventArgs e)
        {
            //DeptID = Convert.ToInt16(Session["DepartmentID"]);
            SearchComplainCircuits();
        }

        protected void btnSendSMS_Click(object sender, EventArgs e)
        {
            try
            {
                if (gvComplainCircuits.Items.Count > 0)
                {
                    foreach (GridDataItem item in gvComplainCircuits.Items)
                    {
                        var cb = (CheckBox)item.FindControl("cb_Select");
                        if (cb.Checked == true)
                        {
                            //string ContactNo = Convert.ToInt32(item["ComplaintID"].Text);
                            string contactno = item["SMS"].Text;
                            contactno = "923343673008";
                            objBSS.SendSMS("External SMS", contactno, "Test", 1);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }


        protected void gvComplainCircuits_ItemCommand(object sender, Telerik.Web.UI.GridCommandEventArgs e)
        {
            if (e.CommandName == "Complain Closure" || e.CommandName == "Follow Up" || e.CommandName == "Solving" || e.CommandName == "View History" || e.CommandName == "Ticket No")
            {
                int index = e.Item.ItemIndex;
                GridDataItem item = (GridDataItem)gvComplainCircuits.Items[index];
                string click = e.CommandName;
                //Session["Complain_TicketNo"] = item["TicketNo"].Text;
                //Session["Complain_ComplainID"] = item["ComplaintID"].Text;

                Session["TicketNo"] = item["TicketNo"].Text;
                Session["Complain_TicketNo"] = item["TicketNo"].Text;
                Session["Complain_ComplainID"] = item["ComplaintID"].Text;
                //int SignupID = Convert.ToInt32(item["SignupID"].Text);
                Session["ComplainID"] = item["ComplaintID"].Text;
                Session["SignupID"] = item["SignupID"].Text;

                string ComplainStatusID = item["ComplaintStatusID"].Text;

                if (click.Equals("Ticket No"))
                {
                    //Response.Redirect("~\\ComplainForm.aspx?click=" + click);
                    Response.Redirect("~\\ComplainForm.aspx?SignupID=" + Convert.ToInt32(Session["SignupID"]) + "&ComplainID=" + Convert.ToInt32(Session["ComplainID"]) + "&Flag=View");

                }

                else
                {
                    if (ComplainStatusID.Equals("4") || ComplainStatusID.Equals("2"))
                    {
                        if (!(click.Equals("Complain Closure")))
                        {
                            Response.Redirect("~\\ComplainMisc.aspx?click=" + click);
                        }

                    }

                    else if (ComplainStatusID.Equals("1") || ComplainStatusID.Equals("5"))
                    {
                        if (click.Equals("Complain Closure") || click.Equals("Solving") || click.Equals("Follow Up") || click.Equals("Ticket No") || click.Equals("View History"))
                        {
                            Response.Redirect("~\\ComplainMisc.aspx?click=" + click);
                        }
                    }



                    else
                    {
                        Response.Redirect("~\\ComplainMisc.aspx?click=" + click);
                    }



                }




                //int SignupID = Convert.ToInt32(item["SignupID"].Text);
                //
                //Response.Redirect("~/InfraCosting.aspx?Distance=" + Distance + "&City=" + City + "&CircuitType=Primary");
            }
        }

        protected void btnClearCM_Click(object sender, EventArgs e)
        {
            ClearSearchFillters();
        }

        protected void btnExportCM_Click(object sender, EventArgs e)
        {
            //string alternateText = (sender as ImageButton).AlternateText;
            #region [ XSLX FORMAT ]
            //if (alternateText == "Xlsx" && CheckBox2.Checked)
            //{
            //    gvComplainCircuits.MasterTableView.GetColumn("LAT").HeaderStyle.BackColor = Color.LightGray;
            //    gvComplainCircuits.MasterTableView.GetColumn("LAT").ItemStyle.BackColor = Color.LightGray;
            //}
            #endregion
            //gvComplainCircuits.ExportSettings.Excel.Format = (GridExcelExportFormat)Enum.Parse(typeof(GridExcelExportFormat), alternateText);
            //gvComplainCircuits.ExportSettings.Excel.Format = (GridExcelExportFormat)Enum.Parse(typeof(GridExcelExportFormat),"");
            //gvComplainCircuits.ExportSettings.IgnorePaging = CheckBox1.Checked;


            gvComplainCircuits.ExportSettings.ExportOnlyData = true;
            gvComplainCircuits.ExportSettings.OpenInNewWindow = true;
            gvComplainCircuits.MasterTableView.ExportToExcel();



            //gvComplainCircuits.ExportSettings.IgnorePaging = false;
            //gvComplainCircuits.ExportSettings.ExportOnlyData = true;
            //gvComplainCircuits.ExportSettings.OpenInNewWindow = true;
        }

        #endregion


        #region FUNCTIONS

        private void ClearSearchFillters()
        {
            try
            {
                tbCMSID.Text = string.Empty;
                tbTicketNumber.Text = string.Empty;
                tbGPID.Text = string.Empty;
                tbSignupID.Text = string.Empty;
                tbSignupID.Text = string.Empty;
                cmbTicketType.SelectedValue = "0";
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void LoadCombos()
        {
            try
            {

                if (DeptID == 1 | DeptID == 10)
                {
                    cbQCFormat.Visible = true;
                }

                if (DeptID == 1 | DeptID == 4 | DeptID == 56 | DeptID == 57 | DeptID == 58 | DeptID == 59 | DeptID == 60)
                {
                    cbSDFormat.Visible = true;
                }

                if (DeptID == 1 | DeptID == 15)
                {
                    cmbCurrentDepartment.Enabled = true;
                }

                objBL.loadTicketType(cmbTicketType);
                objBL.LoadCaseCategory(cmbCaseCategory);
                objBL.loadAssignedDepartment(cmbCurrentDepartment, "All");
                objBL.LoadComplainType(cmbComplainType);
                objBL.LoadComplainStatus(cmbComplainStatus, "All");
                objBL.LoadCircuitOwner(cmbCircuitOwner);
                objBL.loadCities(cmbCity);
                objBL.LoadProblemDignosedAt(cmbProblemDiagnosedAt, 0);
                objBL.LoadReasonOutage(cmbReasonofOutage, 0, 0, 0, 1, Convert.ToInt32(Session["UserID"]));
                objBL.loadLoggedBy(cmbLoggedBy);
                objBL.LoadInitialStatement(cmbInitialStatement);
                objBL.loadCusCode(cmbCustomerCode, null, "Nothing");
                objBL.loadNode(cmbNode, 0, 0, "");
                objBL.LoadComplaintReportedVia(cmbReportedVia);
                objBL.loadAssignedDepartment(cmbForwardToDepartment, "All");
                objBL.loadAssignedDepartment(cmbForwardByDepartment, "All");
                objBL.LoadComplainStatus(cmbForwardStatus, "All");
                cmbCurrentDepartment.SelectedValue = DeptID.ToString();
            }
            catch (Exception ex)
            {
                // Interaction.MsgBox("frmOts_SearchComplainCircuits:" + ex.Message + "of frmOts_SearchComplainCircuits_Load ", MsgBoxStyle.Critical, "BSS Addminstrator");
            }
        }

        private void SearchComplainCircuits()
        {
            try
            {
                int Sign = 0;
                DeptID = Convert.ToInt16(Session["DepartmentID"]);
                if (tbSignupID.Text != string.Empty)
                {
                    Sign = Convert.ToInt32(tbSignupID.Text);
                }
                else
                {
                    Sign = 0;
                }

                int SearchFollow = 0;

                string Format = null;

                if (cbQCFormat.Checked == true)
                {
                    Format = "QC";
                }
                else if (cbSDFormat.Checked == true)
                {
                    Format = "SD";
                }
                else
                {
                    Format = "";
                }

                DataTable dt = objBSS.SearchComplainCircuits(tbTicketNumber.Text,
                Sign, tbCMSID.Text, tbGPID.Text, tbCircuitName.Text,
                (cmbTicketType.Text != "Select Ticket Type" ? cmbTicketType.Text : ""),
                Convert.ToInt16(cmbComplainStatus.SelectedValue),
                Convert.ToInt16(cmbCity.SelectedValue),
                Convert.ToInt16(cmbCircuitOwner.SelectedValue),
                (cmbLoggedBy.Text != "Select LoggedBy" ? cmbLoggedBy.Text : ""),
                Convert.ToInt16(cmbCaseCategory.SelectedValue),
                Convert.ToInt16(cmbInitialStatement.SelectedValue),
                Convert.ToInt16(cmbProblemDiagnosedAt.SelectedValue),
                Convert.ToInt16(cmbReasonofOutage.SelectedValue),
                dtToDate.SelectedDate.Value, dtFromDate.SelectedDate.Value,
                Convert.ToInt16(cmbCustomerCode.SelectedValue),
                Convert.ToInt16(cmbCurrentDepartment.SelectedValue),
                Convert.ToInt16(cmbNode.SelectedValue), 4,
                Format, SearchFollow, Convert.ToInt16(cmbReportedVia.SelectedValue),
                Convert.ToInt16(cmbForwardToDepartment.SelectedValue),
                Convert.ToInt16(cmbForwardByDepartment.SelectedValue),
                Convert.ToInt16(cmbForwardStatus.SelectedValue));

                lblTotalCount.Text = Convert.ToString(dt.Rows.Count);
                
                lblTotalCount.Visible=true;
                if (dt.Rows.Count > 0)
                {
                    gvComplainCircuits.DataSource = dt;
                    gvComplainCircuits.DataBind();
                    if (DeptID == 1 || DeptID == 15)
                    {
                        //gvComplainCircuits.MasterTableView.GetColumn("ComplainClosuer").Display = true;
                        //gvComplainCircuits.MasterTableView.GetColumn("col_followHis").Display = true;
                        gvComplainCircuits.MasterTableView.GetColumn("ComplainClosuer").Display = true;
                        //gvComplainCircuits.MasterTableView.GetColumn("TicketNo").Display = false;
                    }
                    else
                    {
                        gvComplainCircuits.MasterTableView.GetColumn("ComplainClosuer").Display = false;
                    }
                    //gvComplainCircuits.MasterTableView.GetColumn("TicketNo").Display = false;
                    gvComplainCircuits.MasterTableView.GetColumn("ComplaintID").Display = false;
                    gvComplainCircuits.MasterTableView.GetColumn("NodeID").Display = false;
                    gvComplainCircuits.MasterTableView.GetColumn("ComplaintStatusID").Display = false;
                    gvComplainCircuits.MasterTableView.GetColumn("colfollow").Display = true;
                    gvComplainCircuits.MasterTableView.GetColumn("colSolve").Display = true;
                    gvComplainCircuits.MasterTableView.GetColumn("colViewHistory").Display = true;
                    gvComplainCircuits.MasterTableView.GetColumn("InfraID").Display = false;
                    //ChangeToButtonColumn("SignupID", 6);
                    //ChangeToButtonColumn("TicketNo", 7);
                }
                else
                {
                    //lblTotalCount.Text = "0";
                    gvComplainCircuits.DataSource = null;
                    gvComplainCircuits.DataBind();
                    //Interaction.MsgBox("No Record Found", MsgBoxStyle.Information, "BSS Administrator");
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        #endregion

       
       


    }
}