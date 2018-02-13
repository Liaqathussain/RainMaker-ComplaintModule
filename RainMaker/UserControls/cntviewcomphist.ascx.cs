using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using RainMaker.Classes;
using System.Data;

namespace RainMaker.UserControls
{
    public partial class cntviewcomphist : System.Web.UI.UserControl
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
        int Flag ;
        string RequestTypeAtNE = "";
        int FailedCount = 0;
        int SelectCount = 0;
        int AssginedDepart;
        int complaintID = 0;
        

        BSS_Service.Service1SoapClient objBSS = new BSS_Service.Service1SoapClient();
        //BSS_ServiceLocal.Service1SoapClient objBSS = new BSS_ServiceLocal.Service1SoapClient();
        Cls_Territory objCls = new Cls_Territory();
        BL objBL = new BL();
        protected void Page_Load(object sender, EventArgs e)
        {

                click = base.Request.QueryString["click"];
                UserID = Convert.ToInt32(Session["UserID"]);
                RoleID = Convert.ToInt32(Session["RoleID"]);
                DeptID = Convert.ToInt32(Session["DepartmentID"]);
                Flag =   Convert.ToInt32(Session["Complain_HistoryFlag"]);
                complaintID = Convert.ToInt32(base.Request.QueryString["ComplainID"]);
                if (click == "View History" || click=="View Hostory ComplaiID")
                {

                    //ViewHistorypPnl.Visible = true;
                    LoadCustomer(1);
                    loadGridview();
                    

                }
                    

                else
                {
                    ViewState["Pic1"] = "";
                    ViewState["Pic2"] = "";
                }
            
        }

       
        public void LoadCustomer(int Flag)
        {
            try
            {
                if (Flag == 1)//Using BSS DB to show reports
                {
                    dt = objBSS.GetComplainDetailByComplainID(complaintID);
                    
                    if (dt.Rows.Count > 0)
                    {
                        lbl_CusName.InnerHtml = dt.Rows[0]["CircuitName"].ToString();
                        lbl_TicNum.InnerHtml = dt.Rows[0]["TicketNo"].ToString();
                        lbl_ComRec.InnerHtml = Convert.ToString(dt.Rows[0]["ComplaintReceivedDate"]);
                        lbl_LUT.InnerHtml = Convert.ToString(dt.Rows[0]["LastUpdatedDate"]);
                        lbl_CS.InnerHtml = dt.Rows[0]["ComplainStatus"].ToString();
                        lbl_AD.InnerHtml = dt.Rows[0]["AssignDepartment"].ToString();
                        lbl_CN.InnerHtml = dt.Rows[0]["CallerName"] + "/" + dt.Rows[0]["CallerNumber"];
                        lbl_LR.InnerHtml = dt.Rows[0]["Remarks"].ToString();

                    }


                }

            }
            catch (Exception ex)
            {
                // Interaction.MsgBox(ex.Message(), MsgBoxStyle.Information, "BSS Administrator");
            }

        }

        public void loadGridview()
        {
            try
            {
                 dt = objBSS.GetComplainHistory(complaintID,Flag);
                    if (dt.Rows.Count > 0)
                    {
                        gvComplainCircuits.DataSource = dt;
                        gvComplainCircuits.DataBind();
                        gvComplainCircuits.MasterTableView.GetColumn("ComplainID").Visible = false;
                        gvComplainCircuits.MasterTableView.GetColumn("Flag").Visible = false;
                        gvComplainCircuits.Columns[1].Visible = false;
                        gvComplainCircuits.Columns[18].Visible = false;
                        gvComplainCircuits.Columns[0].Visible = false;
                        gvComplainCircuits.Columns[12].Visible = false;
                       
                     }


                }
           
            catch (Exception ex)
            {
            }

        }
        

    }
}