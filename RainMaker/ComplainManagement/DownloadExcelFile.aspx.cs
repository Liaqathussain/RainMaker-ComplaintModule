using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.IO;
using System.Web.UI.HtmlControls;

namespace RainMaker.ComplainManagement
{
    public partial class WebForm2 : System.Web.UI.Page
    {
        protected HtmlForm Form1;
        protected Label lblReportDate;
        protected Label lblReportTitle;
        protected DataGrid Results;


        private void Page_Load(object sender, EventArgs e)
        {
            

            DataView set1 = new DataView();
            if (this.Session["ds"] != null)
            {
                if (this.Session["REPORT"] != null)
                {

                    if (this.Session["REPORT"].ToString() == "BCOMPLAINS")
                    {
                        //this.lblReportTitle.Text = "Bluechip Clients Complain Summary Report";
                        //this.lblReportDate.Text = DateTime.Today.ToLongDateString();
                    }
                    else if (this.Session["REPORT"].ToString() == "SearchingCriterion")
                    {
                        //this.lblReportTitle.Text = "Complain Summary Report";
                        //this.lblReportDate.Text = DateTime.Today.ToLongDateString();
                    }
                    set1 = (DataView)this.Session["ds"];
                    Results = new DataGrid();
                    this.Results.DataSource = set1;
                    //exportToExcel(set1 , "BlueChipReports.xls");

                    foreach (DataColumn c in set1.Table.Columns)
                    {
                        this.Results.Columns.Add((CreateBoundColumn(c)));
                    }

                    this.Results.DataBind();

                    //FOR EXCEL
                    Response.ClearContent();
                    if (this.Session["REPORT"].ToString() == "BCOMPLAINS")
                    {
                        Response.AddHeader("content-disposition", "attachment; filename=Complain Reports.xls");
                    }
                    else if (this.Session["REPORT"].ToString() == "SearchingCriterion")
                    {
                        Response.AddHeader("content-disposition", "attachment; filename=Searching Criterion Reports.xls");
                    }

                    Response.ContentType = "application/excel";

                    StringWriter sw = new StringWriter();

                    HtmlTextWriter htw = new HtmlTextWriter(sw);

                    this.Results.RenderControl(htw);

                    Response.Write(sw.ToString());

                    Response.End();


                }

            }
        }
       

        public BoundColumn CreateBoundColumn(DataColumn c)
        {

            BoundColumn column = new BoundColumn();
            column.DataField = c.ColumnName;
            column.HeaderText = c.ColumnName.Replace("_", " ");
            if (column.HeaderText == "Remarks")
                column.ItemStyle.Width = 1800;
            //column.ItemStyle.Wrap=true;
            return column;

        }
        public static void exportToExcel(DataView source, string fileName)
        {

            //DataTable dt = new DataTable();
            //dt =source.Tables[0];
            //this.Results.DataSource = set1;
            HttpContext.Current.Response.Clear();
            HttpContext.Current.Response.ContentType = "application/vnd.ms-excel";
            // For xlsx file 2007
            //HttpContext.Current.Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
            string sep = "";
            foreach (DataColumn dc in source.Table.Columns)
            {
                HttpContext.Current.Response.Write(sep + dc.ColumnName);
                sep = "\t";
            }
            HttpContext.Current.Response.Write("\n");

            int i;
            foreach (DataRow dr in source.Table.Rows)
            {
                sep = "";
                for (i = 0; i < source.Table.Columns.Count; i++)
                {
                    HttpContext.Current.Response.Write(sep + dr[i].ToString());
                    sep = "\t";
                }
                HttpContext.Current.Response.Write("\n");
            }

        }

        #region Web Form Designer generated code
        override protected void OnInit(EventArgs e)
        {
            //
            // CODEGEN: This call is required by the ASP.NET Web Form Designer.
            //
            InitializeComponent();
            base.OnInit(e);
        }

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            //this.Results.SelectedIndexChanged += new System.EventHandler(this.Results_SelectedIndexChanged);
            //this.Load += new System.EventHandler(this.Page_Load);

        }
        #endregion


    }
}