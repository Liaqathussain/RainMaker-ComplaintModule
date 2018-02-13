using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using Microsoft.VisualBasic;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Web.Services;
using System.Timers;

namespace RainMaker.Dashboard
{
    public class DataClass
    {
        public string label;
        public Int32 y;
    }

    public class PieChart2
    {
        public Int32 y;
        public string indexLabel;
        public string legend;
    }

    public class AllGraphLoading
    {
        public List<BarChart> Top10Chart = new List<BarChart>();
        public List<PieChart> InfrPieChart = new List<PieChart>();
        public List<BarChart> DepartChart = new List<BarChart>();
        public List<string> Lblstrings = new List<string>();
    }

    public class DepartData
    {
        public string DepartID;
        public string Name;

        public string ComplainCount;
    }

    public class ComplainData
    {
        public string SignupID;
        public string TicketNo;
        public string CircuitName;
        public string Address;
        public string City;
        public string Infra;
        public string ServiceUnit;
        public string ComplainType;
        public string ComplainRecievedDate;
        public string LastUpdatedDate;
        public string AssignedPersonName;
        public string TimeDuration;

        public string Remarks;
    }

    public partial class ComplaintAnalysis : System.Web.UI.Page
    {
        static MethodCalling obj = new MethodCalling();
        string Triger;
        public event ElapsedEventHandler Elapsed;
        private System.Timers.Timer aTimer;
        static DataTable dt_CC;
        static DataTable dt_IC;
        static DataTable dt_DC;

        protected void Page_Load(object sender, EventArgs e)
        {
                loadCompaliainsViaRegion();
                loadCompaliainsViaDownTime();
                LoadComplainTrigger("1-4", lblTriger1_4);
                LoadComplainTrigger("4-8", lblTriger4_8);
                LoadComplainTrigger("8-12", lblTriger8_12);
                LoadComplainTrigger("12-24", lblTriger12_24);
                LoadComplainTrigger("+24", lblTrigerPlus_24);
                loadCompCountsViaDownTimeViaDept();
                loadComplainSolveViaRFO();
        }

          private void loadCompCountsViaDownTimeViaDept()
        {
            try
            {
                loadCompViaDownTimeViaDept(15, lblDeptOTS_14, lblDeptOTS_48, lblDeptOTS_812, lblDeptOTS_1224, lblDeptOTS_2436, lblDeptOTS_36p);
                loadCompViaDownTimeViaDept(3, lblDeptNOC_14, lblDeptNOC_48, lblDeptNOC_812, lblDeptNOC_1224, lblDeptNOC_2436, lblDeptNOC_36p);
                loadCompViaDownTimeViaDept(59, lblDeptOMS_14, lblDeptOMS_48, lblDeptOMS_812, lblDeptOMS_1224, lblDeptOMS_2436, lblDeptOMS_36p);
                loadCompViaDownTimeViaDept(60, lblDeptOMN_14, lblDeptOMN_48, lblDeptOMN_812, lblDeptOMN_1224, lblDeptOMN_2436, lblDeptOMN_36p);
                loadCompViaDownTimeViaDept(58, lblDeptOMC_14, lblDeptOMC_48, lblDeptOMC_812, lblDeptOMC_1224, lblDeptOMC_2436, lblDeptOMC_36p);
                loadCompViaDownTimeViaDept(100, lblDeptTP_14, lblDeptTP_48, lblDeptTP_812, lblDeptTP_1224, lblDeptTP_2436, lblDeptTP_36p);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        //Private Sub loadCompaliainsChartViaDept()
        //    Try

        //        cht_ComplainViaDept.Series("SerOpen").Points.AddXY("OTS", GetComplainCountForGraph(2, 15))
        //        cht_ComplainViaDept.Series("SerInProcess").Points.AddXY("OTS", GetComplainCountForGraph(4, 15))

        //        cht_ComplainViaDept.Series("SerOpen").Points.AddXY("IP NOC", GetComplainCountForGraph(2, 3))
        //        cht_ComplainViaDept.Series("SerInProcess").Points.AddXY("IP NOC", GetComplainCountForGraph(4, 3))

        //        cht_ComplainViaDept.Series("SerOpen").Points.AddXY("O&M South", GetComplainCountForGraph(2, 59))
        //        cht_ComplainViaDept.Series("SerInProcess").Points.AddXY("O&M South", GetComplainCountForGraph(4, 59))

        //        cht_ComplainViaDept.Series("SerOpen").Points.AddXY("O&M North", GetComplainCountForGraph(2, 60))
        //        cht_ComplainViaDept.Series("SerInProcess").Points.AddXY("O&M North", GetComplainCountForGraph(4, 60))

        //        cht_ComplainViaDept.Series("SerOpen").Points.AddXY("O&M Central", GetComplainCountForGraph(2, 58))
        //        cht_ComplainViaDept.Series("SerInProcess").Points.AddXY("O&M Central", GetComplainCountForGraph(4, 58))

        //        cht_ComplainViaDept.Series("SerOpen").Points.AddXY("ThirdParty", GetComplainCountForGraph(2, 100))
        //        cht_ComplainViaDept.Series("SerInProcess").Points.AddXY("ThirdParty", GetComplainCountForGraph(4, 100))

        //    Catch ex As Exception
        //        Throw ex
        //    End Try
        //End Sub

        private void loadCompaliainsViaRegion()
        {
            try
            {
                DataTable dt_R = new DataTable();
                dt_R = obj.GetComplainsViaRegion();
                if (dt_R.Rows.Count == 1)
                {
                    lblSouth.Text = Convert.ToString(dt_R.Rows[0]["South"]);
                    lblNorth.Text = Convert.ToString(dt_R.Rows[0]["North"]);
                    lblCentral.Text = Convert.ToString(dt_R.Rows[0]["Central"]);
                    lblTotalCount.Text = Convert.ToString(dt_R.Rows[0]["RegionTotal"]);
                }
                else
                {
                    lblSouth.Text = "0";
                    lblNorth.Text = "0";
                    lblCentral.Text = "0";

                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void loadCompaliainsViaDownTime()
        {
            try
            {
                DataTable dt_D = new DataTable();
                dt_D = obj.GetComplainsViaDownTime();
                if (dt_D.Rows.Count == 1)
                {
                    lbl1_4.Text = Convert.ToString(dt_D.Rows[0]["1_4"]);
                    lbl4_8.Text = Convert.ToString(dt_D.Rows[0]["4_8"]);
                    lbl8_12.Text = Convert.ToString(dt_D.Rows[0]["8_12"]);
                    lbl12_24.Text = Convert.ToString(dt_D.Rows[0]["12_24"]);
                    lbl24_36.Text = Convert.ToString(dt_D.Rows[0]["24_36"]);
                    lbl36p.Text = Convert.ToString(dt_D.Rows[0]["36Plus"]);
                }
                else
                {
                    lbl1_4.Text = "0";
                    lbl4_8.Text = "0";
                    lbl8_12.Text = "0";
                    lbl12_24.Text = "0";
                    lbl24_36.Text = "0";
                    lbl36p.Text = "0";
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void loadCompViaDownTimeViaDept(int AssigDeptID, Label lblDep1_4, Label lblDep4_8, Label lblDep8_12, Label lblDep12_24, Label lblDep24_36, Label lblDep36plus)
        {
            try
            {
                DataTable dt = new DataTable();
                dt.Clear();
                dt = obj.GetCompViaDownTimeViaDept(AssigDeptID);
                if (dt.Rows.Count == 1)
                {
                    lblDep1_4.Text = Convert.ToString(dt.Rows[0]["1_4"]);
                    lblDep4_8.Text = Convert.ToString(dt.Rows[0]["4_8"]);
                    lblDep8_12.Text = Convert.ToString(dt.Rows[0]["8_12"]);
                    lblDep12_24.Text = Convert.ToString(dt.Rows[0]["12_24"]);
                    lblDep24_36.Text = Convert.ToString(dt.Rows[0]["24_36"]);
                    lblDep36plus.Text = Convert.ToString(dt.Rows[0]["36Plus"]);
                }
                else
                {
                    lblDep1_4.Text = "0";
                    lblDep4_8.Text = "0";
                    lblDep8_12.Text = "0";
                    lblDep12_24.Text = "0";
                    lblDep24_36.Text = "0";
                    lblDep36plus.Text = "0";

                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        //Private Sub loadComplainViaInfra()
        //    Try
        //        Dim dt_CI As New DataTable
        //        dt_CI = obj.GetComplainsViaInfra
        //        If dt_CI.Rows.Count > 0 Then
        //            cht_ComplainInfra.DataSource = dt_CI
        //            cht_ComplainInfra.DataBind()
        //            cht_ComplainInfra.Series("Series1")("PieLabelStyle") = "Outside"
        //            cht_ComplainInfra.Series("Series1")("PieLineColor") = "Black"
        //        End If

        //    Catch ex As Exception
        //        Throw ex
        //    End Try
        //End Sub


        [WebMethod()]
        public static AllGraphLoading loadAllGraph()
        {
            try
            {
                AllGraphLoading list = new AllGraphLoading();


                if (dt_CC == null)
                {
                    dt_CC = new DataTable();
                }

                if (dt_IC == null)
                {
                    dt_IC = new DataTable();
                }

                if (dt_DC == null)
                {
                    dt_DC = new DataTable();
                }

                if (obj == null)
                {
                    obj = new MethodCalling();
                }


                dt_CC = obj.GetComplainsViaCustomer();

                if (dt_CC.Rows.Count > 0)
                {
                    foreach (DataRow row in dt_CC.Rows)
                    {
                        BarChart data = new BarChart();
                        data.y = Convert.ToInt32(row["ComplainsCount"].ToString());
                        data.label = row["Customer"].ToString();
                        list.Top10Chart.Add(data);
                    }
                }


                dt_DC = obj.GetComplainDetailsviaDepart();

                if (dt_DC.Rows.Count > 0)
                {
                    foreach (DataRow row in dt_DC.Rows)
                    {
                        BarChart data = new BarChart();
                        data.y = Convert.ToInt32(row["ComplainCount"].ToString());
                        data.label = row["AssignDepartment"].ToString();
                        list.DepartChart.Add(data);
                    }
                }

                dt_IC = obj.GetComplainsViaInfra();

                if (dt_IC.Rows.Count > 0)
                {
                    foreach (DataRow row in dt_IC.Rows)
                    {
                        PieChart data = new PieChart();
                        data.y = Convert.ToInt32(row["ComplainsCount"].ToString());
                        data.indexLabel = row["Infra"].ToString();
                        list.InfrPieChart.Add(data);
                    }
                }


                return list;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }



        private void loadComplainSolveViaRFO()
        {

            try
            {
                DataTable dt_RFO = new DataTable();
                dt_RFO = obj.GetComplainSolvedViaRFO();
                if (dt_RFO.Rows.Count == 1)
                {
                    lblFibrePre.Text = Convert.ToString(dt_RFO.Rows[0]["FiberPre"]);
                    lblLH_FiberPre.Text = Convert.ToString(dt_RFO.Rows[0]["LH_FiberPre"]);
                    lblOFCBreakage.Text = Convert.ToString(dt_RFO.Rows[0]["OFCBreakage"]);
                    lblLH_OFCBreakage.Text = Convert.ToString(dt_RFO.Rows[0]["LH_OFCBreakage"]);
                }
                else
                {
                    lblFibrePre.Text = "0";
                    lblLH_FiberPre.Text = "0";
                    lblOFCBreakage.Text = "0";
                    lblLH_OFCBreakage.Text = "0";
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public string GetComplainCountForGraph(int ComplaintStatusID, int AssignedDeptID)
        {
            try
            {
                DataTable dt_CCount = new DataTable();
                dt_CCount = obj.GetComplainCount(ComplaintStatusID, AssignedDeptID);
                if (dt_CCount.Rows.Count == 1)
                {
                    return Convert.ToString(dt_CCount.Rows[0]["ComplainCount"]);
                }
                else
                {
                    return "0";
                }
            }
            catch (Exception ex)
            {
                return "0";
            }
        }

        private void LoadComplainTrigger(string Flag, Label Lbl)
        {
            try
            {
                DataTable dt_Tr = new DataTable();
                Triger = string.Empty;
                dt_Tr = obj.GetTigger(Flag);
                if (dt_Tr.Rows.Count > 0)
                {
                    for (int i = 0; i <= dt_Tr.Rows.Count - 1; i++)
                    {
                        Triger = Triger + " " + dt_Tr.Rows[i]["Tigger"];
                    }
                    Lbl.Text = Triger;
                }
                else
                {
                    Lbl.Text = "No Complains for respective Aging";
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [WebMethod()]
        public static List<DepartData> Loader(string Flag)
        {

            DataTable dt_Dep = new DataTable();
            dt_Dep = obj.GetComplainDetailsviaDepart();
            List<DepartData> list = new List<DepartData>();
            foreach (DataRow row in dt_Dep.Rows)
            {
                DepartData data = new DepartData();
                data.DepartID = row["AssignedDeptID"].ToString();
                data.Name = row["AssignDepartment"].ToString();
                data.ComplainCount = row["ComplainCount"].ToString();
                list.Add(data);
            }
            return list;
        }

        [WebMethod()]
        public static List<ComplainData> Complains(string RegionID, string Aging, string AssignedDept)
        {

            DataTable dt_Tr = new DataTable();

            dt_Tr = obj.GetCompDetailsOnLabelClick(Convert.ToInt32(RegionID), Aging, Convert.ToInt32(AssignedDept));



            List<ComplainData> list = new List<ComplainData>();

            foreach (DataRow row in dt_Tr.Rows)
            {
                ComplainData data = new ComplainData();
                data.SignupID = row["SignupID"].ToString();
                data.TicketNo = row["TicketNo"].ToString();
                data.CircuitName = row["CircuitName"].ToString();
                data.Address = row["Address"].ToString();
                data.City = row["City"].ToString();
                data.Infra = row["Infra"].ToString();
                data.ServiceUnit = row["ServiceUnit"].ToString();
                data.ComplainType = row["ComplainType"].ToString();
                data.ComplainRecievedDate = row["ComplaintReceivedDate"].ToString();
                data.LastUpdatedDate = row["LastUpdatedDate"].ToString();
                data.AssignedPersonName = row["AssignedPersonName"].ToString();
                data.TimeDuration = row["TimeDuration"].ToString();
                data.Remarks = row["Remarks"].ToString();
                list.Add(data);
            }
            return list;
        }
       
    }
}