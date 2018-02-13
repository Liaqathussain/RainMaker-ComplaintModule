using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Collections;
using RainMaker.Classes;

namespace RainMaker.ComplainManagement
{
    public partial class OMTeamEscalation : System.Web.UI.Page
    {
        BL objBL = new BL();
        Cls_Territory objCls = new Cls_Territory();
        BSS_Service.Service1SoapClient objBSS = new BSS_Service.Service1SoapClient();
        static DataTable dtForExcel;

        protected void Page_Load(object sender, EventArgs e)
        {

            if (!Page.IsPostBack)
            {

                lblStatus.Visible = false;
                LoadComboBox();
                BindGridView();
                SetInitialRow();

            }
            
            
        }

        private void SetInitialRow()
        {
            int SignupID=0;
            int City=0;
            int node=0;
            string team="";
            if (txtSignUpID.Text!="")
            {
                SignupID = Convert.ToInt32(txtSignUpID.Text);
            }
            if (cmbCity.SelectedValue != "0")
            {
                City = Convert.ToInt32(cmbCity.SelectedValue);
            }
            if (cmbNode.SelectedValue != "0")
            {
                node = Convert.ToInt32(cmbNode.SelectedValue);
            }
            System.DateTime sysdate = DateTime.MinValue;
            DataTable dt_SearchComplainCirciuits = objBSS.SearchComplainCircuits("", SignupID, "", "", "", "", 4, City, 0, "", 0, 0, 0, 0, sysdate, sysdate, 0, Convert.ToInt32(Session["DepartmentID"]), node, 0, "OM", 0, 0, 0, 0, 0);
            DataTable DTTeam = objBSS.GetTeamList();
            GVTeam.DataSource = dt_SearchComplainCirciuits;
            GVTeam.DataBind();
            //Store the DataTable in ViewState for future reference 
            ViewState["CurrentTable"] = dt_SearchComplainCirciuits;

            //Bind the Gridview 
            GVTeam.DataSource = dt_SearchComplainCirciuits;
            GVTeam.DataBind();

            dtForExcel = new DataTable();
            dtForExcel = dt_SearchComplainCirciuits;
           

            //After binding the gridview, we can then extract and fill the DropDownList with Data 
            for (int i = 0; i < dt_SearchComplainCirciuits.Rows.Count; i++)
            {
                DropDownList ddl1 = (DropDownList)GVTeam.Rows[i].Cells[1].FindControl("DropDownList1");
                DropDownList ddl2 = (DropDownList)GVTeam.Rows[i].Cells[2].FindControl("DropDownList2");
                    
                
                    FillDropDownList(ddl2);
                    FillDropDownList2(ddl1);

                    if (dt_SearchComplainCirciuits.Rows[i]["TeamName"].ToString() != "N/A")
                    {
                        foreach (DataRow row in DTTeam.Rows)
	                    {
                            if(row["TeamName"].ToString() ==dt_SearchComplainCirciuits.Rows[i]["TeamName"].ToString())
                            {
                                team=row["TeamID"].ToString();
                            }
	                    }

                        ddl1.SelectedValue=team;
                        ddl2.SelectedValue=dt_SearchComplainCirciuits.Rows[i]["Priority"].ToString();
                    }
                
            }


        }

   

        private void FillDropDownList2(DropDownList dd2)
        {
            try
            {

            //DataTable DTTeam = objCls.GetTeam();
            DataTable DTTeam = objBSS.GetTeamList();

            foreach (DataRow row in DTTeam.Rows)
            {
                //arr1.Add(new ListItem(row["TeamName"].ToString(), row["TeamID"].ToString()));                
                dd2.Items.Add(new ListItem(row["TeamName"].ToString(), row["TeamID"].ToString()));

            }
            dd2.DataBind();


            }
            catch (Exception ex)
            {

                throw;
            }
        }
        private ArrayList GetDummyData()
        {

            ArrayList arr = new ArrayList();


            arr.Add(new ListItem("1", "1"));
            arr.Add(new ListItem("2", "2"));
            arr.Add(new ListItem("3", "3"));
            arr.Add(new ListItem("4", "4"));
            arr.Add(new ListItem("5", "5"));
            arr.Add(new ListItem("6", "6"));
            arr.Add(new ListItem("7", "7"));
            arr.Add(new ListItem("8", "8"));
            arr.Add(new ListItem("9", "9"));
            arr.Add(new ListItem("10", "10"));
            arr.Add(new ListItem("11", "11"));
            arr.Add(new ListItem("12", "12"));
            arr.Add(new ListItem("13", "13"));
            arr.Add(new ListItem("14", "14"));
            arr.Add(new ListItem("15", "15"));

            return arr;
        }
        private void FillDropDownList(DropDownList ddl)
        {

            //DataTable DTTeam = objCls.GetPriority();
            DataTable DTTeam = objBSS.GetTeamPrioirty();

            foreach (DataRow row in DTTeam.Rows)
            {
                                
                ddl.Items.Add(new ListItem(row["OMPriorityID"].ToString(), row["OMPriorityName"].ToString()));

            }
            ddl.DataBind();

            
        }

        private void BindGridView()
        {
            System.DateTime sysdate = DateTime.MinValue;
            System.DateTime sysdatemax = DateTime.MaxValue;
            DataTable dt_SearchComplainCirciuits = objBSS.SearchComplainCircuits("", 0, "", "", "", "", 4, 0, 0, "", 0, 0, 0, 0, sysdate, sysdate, 0, Convert.ToInt32(Session["DepartmentID"]), 0, 0, "OM", 0, 0, 0, 0, 0);
            GVTeam.DataSource = dt_SearchComplainCirciuits;
            GVTeam.DataBind();
        }



        public void LoadComboBox()
        {

            objBL.loadCities(cmbCity);
            objBL.loadNode(cmbNode, 0, 0, "");
            objBL.loadCusCode(cmbCustomerCode, null, null);
            

        }



     

        protected void GVTeam_SelectedIndexChanged(object sender, EventArgs e)
        {
            

        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
             foreach (GridViewRow row in GVTeam.Rows)
            {
                if (row.RowType == DataControlRowType.DataRow)
                {

                    CheckBox chkRow = (row.Cells[0].FindControl("chkRow") as CheckBox);
                    if (chkRow.Checked)
                    {
                        string ComplaintID = row.Cells[1].Text;
                        string TicketNo = row.Cells[2].Text;
                        DropDownList ddl = (DropDownList)GVTeam.Rows[row.RowIndex].FindControl("DropDownList1");
                        string TeamID = ddl.SelectedValue.ToString();
                        string TeamName = ddl.SelectedItem.ToString();

                        DropDownList dd2 = (DropDownList)GVTeam.Rows[row.RowIndex].FindControl("DropDownList2");

                        string PriorityID = dd2.SelectedValue.ToString();
                        int DeptID = Convert.ToInt32(Session["DepartmentID"]);
                        int userid = Convert.ToInt32(Session["UserID"]);
                        string Remarks = "Assigning Complain: " + TicketNo + " To " + TeamName + " with " + PriorityID + " priority by " + Session["Name"] + " of " + DeptID;
                        int AssignedDeptID = 0;
                        //string Remarks = "test";
                        dynamic dt_GetAssignedDeptId = objBSS.GetComplainDetailByComplainID(Convert.ToInt32(ComplaintID));
                        if (dt_GetAssignedDeptId.Rows.Count > 0)
                        {
                            AssignedDeptID = Convert.ToInt32(dt_GetAssignedDeptId.Rows[0]["AssignedDeptID"]);
                        }
                        //objBSS.AssignedComplainsToTeam(ComplaintID, TeamID, PriorityID, Remarks, DeptID, Session["Name"].ToString(), userid);
                        //objBSS.AssignedComplainsToTeam(Convert.ToInt32(ComplaintID), Convert.ToInt32(TeamID), Convert.ToInt32(PriorityID), Remarks, DeptID.ToString(), Session["Name"].ToString(), userid);
                        //objBSS.AssignedComplainsToTeam(Convert.ToInt32(ComplaintID), Convert.ToInt32(TeamID), Convert.ToInt32(PriorityID), Remarks, "1", Session["Name"].ToString(), userid);
                        if (!(TeamID.Equals("-1") || PriorityID.Equals("-1")))
                        {
                            objBSS.AssignedComplainsToTeam(Convert.ToInt32(ComplaintID), Convert.ToInt32(TeamID), Convert.ToInt32(PriorityID), Remarks, AssignedDeptID, Session["Name"].ToString(), userid);
                        }

                        else
                        {
                            lblStatus.Text = "Please select Team and Priority";
                            lblStatus.Visible = true;
                        }

                        //string country = (row.Cells[2].FindControl("lblCountry") as Label).Text;

                    }
                }
            }
             Response.Redirect("~\\ComplainManagement\\OMTeamEscalation.aspx");

            
        }
        
        protected void btnSearch_Click(object sender, EventArgs e)
        {

            System.DateTime sysdate = DateTime.MinValue;
            System.DateTime sysdatemax = DateTime.MaxValue;
            if (txtSignUpID.Text.Equals(""))
            {
                txtSignUpID.Text = "0";
            }
            
            //DataTable dt_SearchComplainCirciuits = objBSS.SearchComplainCircuits("", Convert.ToInt32(txtSignUpID.Text), "", "", "", "", 4, Convert.ToInt32(cmbCity.SelectedValue), 0, "", 0, 0, 0, 0, sysdate, sysdate, 0, Convert.ToInt32(Session["DepartmentID"]), Convert.ToInt32(cmbNode.SelectedValue) , 0, "OM", 0, 0, 0, 0, 0);
            //DataTable dt_SearchComplainCirciuits = objBSS.SearchComplainCircuits("", Convert.ToInt32(txtSignUpID.Text), "", "", "", "", 4, Convert.ToInt32(cmbCity.SelectedValue), 0, "", 0, 0, 0, 0, sysdate, sysdate, 0, Convert.ToInt32(Session["DepartmentID"]), Convert.ToInt32(cmbNode.SelectedValue), 0, "OM", 0, 0, 0, 0, 0);
            
            //GVTeam.DataSource = dt_SearchComplainCirciuits;
            //GVTeam.DataBind();
            SetInitialRow();

            
           
        }

       

    }
}