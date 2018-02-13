using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Telerik.Web.UI;

namespace RainMaker.SMS
{
    public partial class DepartmentSMS : System.Web.UI.Page
    {
        BL objBL = new BL();
        //BSS_ServiceLocal.Service1SoapClient objBSS = new BSS_ServiceLocal.Service1SoapClient();
        BSS_Service.Service1SoapClient objBSS = new BSS_Service.Service1SoapClient();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                getCities();
                getGroup();
                GetEmployeeDetails(0, 0);
            }

        }

        public void getCities()
        {
            try
            {
                objBL.loadCities(cmbCity);

            }
            catch (Exception ex)
            {
                //Interaction.MsgBox(ex.Message, MsgBoxStyle.Critical, Title: "Error Message");
            }
        }

        public void getGroup()
        {
            try
            {
                objBL.GetGroups(cmbGroup);

            }
            catch (Exception ex)
            {
                //Interaction.MsgBox(ex.Message, MsgBoxStyle.Critical, Title: "Error Message");
            }
        }

        public void GetEmployeeDetails(int GroupID, int CityID)
        {
            try
            {
                dynamic dt = objBSS.GetEmployeeViaGroup(GroupID, CityID);
                if (dt.Rows.Count > 0)
                {
                    if (grdEmployee.DataSource == null)
                    {
                        grdEmployee.DataSource = dt;
                        grdEmployee.DataBind();
                    }
                    else
                    {
                        grdEmployee.DataSource = null;
                        grdEmployee.DataSource = dt;
                        grdEmployee.DataBind();
                    }


                }
                else
                {
                    grdEmployee.DataSource = null;
                }
            }
            catch (Exception ex)
            {
                //Interaction.MsgBox(ex.Message, MsgBoxStyle.Critical, Title: "Message Box");
            }
        }

        protected void cmbCity_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!cmbGroup.SelectedValue.Equals(0))
            {
                int groupID = Convert.ToInt32(cmbGroup.SelectedValue);
                int cityID = Convert.ToInt32(cmbCity.SelectedValue);

                GetEmployeeDetails(groupID, cityID);
            }
        }

        protected void cmbGroup_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!cmbGroup.SelectedValue.Equals(0))
            {
                int groupID = Convert.ToInt32(cmbGroup.SelectedValue);
                int cityID=Convert.ToInt32(cmbCity.SelectedValue);

                GetEmployeeDetails(groupID,cityID );
            }
        }

        protected void grdEmployee_NeedDataSource(object sender, GridNeedDataSourceEventArgs e)
        {
            GetEmployeeDetails(Convert.ToInt32(cmbGroup.SelectedValue), Convert.ToInt32(cmbCity.SelectedValue));
           
        }

        protected void chkIsSelectAll_changed(object sender, EventArgs e)
        {
            try
            {
                chkIsSelectAll.Enabled = false;
                if (chkIsSelectAll.Checked == true)
                {

                    foreach (GridDataItem item in grdEmployee.Items)
                    {
                        var cb = (CheckBox)item.FindControl("cb_Select");
                        if (cb.Checked == false)
                        {
                            cb.Checked = true;
                        }
                    }


                }
                else
                {
                    foreach (GridDataItem item in grdEmployee.Items)
                    {
                        var cb = (CheckBox)item.FindControl("cb_Select");
                        if (cb.Checked == true)
                        {
                            cb.Checked = false;
                        }
                    }
                }
                chkIsSelectAll.Enabled = true;

               
            }
            catch (Exception ex)
            {
                //Interaction.MsgBox(ex.Message, MsgBoxStyle.Critical, Title: "Message Box");
            }
        }

        protected void btnSend_Click(object sender, EventArgs e)
        {
            if (isValidate().Equals(true))
            {

                if (grdEmployee.Items.Count > 0)
                {
                    foreach (GridDataItem item in grdEmployee.Items)
                    {
                        var cb = (CheckBox)item.FindControl("cb_Select");
                        if (cb.Checked == true)
                        {
                            //string ContactNo = Convert.ToInt32(item["ComplaintID"].Text);
                            string contactno = item["SMSNo"].Text;
                            // contactno = "923343673008";
                            objBSS.SendSMS("External SMS", contactno, tbSMS.Text, 1);
                        }
                    }
                }
            }

            else
            {
                lblNotify.Text = "Either your message box is empty or none of the record is selected";
                lblNotify.Visible = true;
            }
        }

        public bool isValidate()
        {
            bool @bool = false;

            try
            {
                foreach (GridDataItem item in grdEmployee.Items)
                {
                    var cb = (CheckBox)item.FindControl("cb_Select");
                    if (cb.Checked == true)
                    {
                        @bool = true;
                    }
                }

                if (!@bool)
                {
                    return @bool;
                }

                if (tbSMS.Text.Equals(""))
                {
                    @bool = false;
                    return @bool;
                }

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
                //Interaction.MsgBox(ex.Message, MsgBoxStyle.Critical, Title: "Message Box");
            }
            return @bool;
        }
    }
}