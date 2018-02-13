using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.VisualBasic;
using System.Collections;
using System.Data;
using System.Diagnostics;
using System.Web.Services;

namespace RainMaker.Dashboard
{

    public class BarChart
    {

        public string label;

        public Int32 y;
    }

    public class SplineChart
    {
        public string x;
        public Int32 y;
    }

    public class PieChart
    {
        public Int32 y;
        public string indexLabel;
        public string legend;
    }

    public class ALLDATA
    {
        public List<BarChart> BarChart = new List<BarChart>();
        public List<PieChart> PieChart = new List<PieChart>();
        public List<SplineChart> SplineChart = new List<SplineChart>();
        public List<BarChart> Bar1Chart = new List<BarChart>();
        public List<string> Lblstrings = new List<string>();
    }

    public partial class CustomerAnalysis : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        static MethodCalling obj;
        static DataTable dt_Lob;
        static DataTable dt_RG;
        static DataTable dt_MD;
        static DataTable dt_SD;
        static DataTable dt_12;

        [WebMethod]
        public static ALLDATA loadAllData()
        {
            try
            {
                ALLDATA list = new ALLDATA();


                if (dt_Lob == null)
                {
                    dt_Lob = new DataTable();
                }

                if (dt_RG == null)
                {
                    dt_RG = new DataTable();
                }

                if (dt_MD == null)
                {
                    dt_MD = new DataTable();
                }

                if (dt_SD == null)
                {
                    dt_SD = new DataTable();
                }

                if (dt_12 == null)
                {
                    dt_12 = new DataTable();
                }

                if (obj == null)
                {
                    obj = new MethodCalling();
                }


                dt_Lob = obj.GetDeploymentViaLOB();


                foreach (DataColumn column in dt_Lob.Columns)
                {
                    BarChart data = new BarChart();
                    data.y = Convert.ToInt32(dt_Lob.Rows[0][column.ColumnName]);
                    data.label = column.ColumnName;
                    list.BarChart.Add(data);
                }

                dt_RG = obj.GetDeploymentViaRegion();

                foreach (DataColumn column in dt_RG.Columns)
                {
                    BarChart data = new BarChart();
                    data.y = Convert.ToInt32(dt_RG.Rows[0][column.ColumnName]);
                    data.label = column.ColumnName;
                    list.Bar1Chart.Add(data);
                }

                dt_SD = obj.GetDeploymentViaService();


                foreach (DataRow row in dt_SD.Rows)
                {
                    PieChart data = new PieChart();

                    data.y = Convert.ToInt32(row["Count"]);
                    data.legend = row["ServiceUnit"].ToString();
                    data.indexLabel = row["ServiceUnit"].ToString();
                    list.PieChart.Add(data);
                }

                dt_12 = obj.GetDeployofLast12Months();



                foreach (DataRow row in dt_12.Rows)
                {
                    SplineChart data = new SplineChart();

                    data.y = Convert.ToInt32(row["Count"]);
                    data.x = row["Period"].ToString();
                    list.SplineChart.Add(data);
                }

                dt_MD = obj.GetDeploymentMainDetails();


                foreach (DataColumn column in dt_MD.Columns)
                {
                    list.Lblstrings.Add(dt_MD.Rows[0][column.ColumnName].ToString());

                }
                return list;
            }
            catch (Exception ex)
            {
                throw ex;
            }





        }
    }
}