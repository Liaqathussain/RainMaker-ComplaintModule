using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace RainMaker.Dashboard
{
    public partial class OrderBook : System.Web.UI.Page
    {
  
        public MethodCalling obj = new MethodCalling();
        DataTable _objdt = new DataTable();
        protected void Page_Load(object sender, EventArgs e)
        {
            var dateAndTime = DateTime.Now;
            var date = dateAndTime.Date;
            DateTime Original = DateTime.Now;
            DateTime NextMonthDate = Original.AddMonths(1);
            DateTime firstDayOfMonth = new DateTime(Original.Year, Original.Month, 1);
            DateTime lastOfMonth = NextMonthDate.Date.AddDays(-(NextMonthDate.Day - 1)).AddMonths(1).AddDays(-1);
            loadMainHeaderDetails(Convert.ToString(firstDayOfMonth), lastOfMonth.ToString(), lblHeader1, lblSigupCount1, lblOTC1, lblMRC1);
            loadMainHeaderDetails(Convert.ToString(firstDayOfMonth), "1/1/1900", lblHeader2, lblSigupCount2, lblOTC2, lblMRC2);
            loadMainHeaderDetails("1/1/1900", Convert.ToString(lastOfMonth), lblHeader3, lblSignupCount3, lblOTC3, lblMRC3);
            loadDetailsViaLOB_CircuitStatus();
            loadDetailsViaLOB_Infra();
            loadDetailsViaOwner_InfraMedium();
        }

        protected void loadMainHeaderDetails(String FromDate, String ToDate, Label lblHeader, Label lblOrder, Label lblOTC, Label lblMRC)
        {
            try
            {
                _objdt = obj.GetOBGetMainDetails(FromDate, ToDate);
                if (_objdt.Rows.Count == 1)
                {
                    lblHeader.Text = _objdt.Rows[0]["Header"].ToString(); ;
                    lblOrder.Text = Convert.ToString(_objdt.Rows[0]["OrderCount"]);
                    lblOTC.Text = Convert.ToString(_objdt.Rows[0]["OTC"]);
                    lblMRC.Text = Convert.ToString(_objdt.Rows[0]["MRC"]);
                }
            }
            catch (Exception ex)
            {
            }
        }

        protected void loadDetailsViaLOB_Infra()
        {
            try
            {
                _objdt = obj.GetOBGetDetailsViaLOB_Infra();
                DataRow dr = _objdt.NewRow();
                dr[0] = "Total";
                dr[2] = GetTotal(_objdt, "No of Signups");
                dr[3] = string.Format("{0:n0}", GetTotal(_objdt, "OTC"));
                dr[4] = string.Format("{0:n0}", GetTotal(_objdt, "MRC"));
                _objdt.Rows.InsertAt(dr, _objdt.Rows.Count + 1);
                dtDetailsOI.HeaderStyle.HorizontalAlign = HorizontalAlign.Center;
                dtDetailsLI.DataSource = _objdt;
                dtDetailsLI.DataBind();
                dtDetailsLI.Rows[_objdt.Rows.Count - 1].Font.Bold = true;
                dtDetailsLI.RowStyle.Width = 50;
            
            }
            catch (Exception ex)
            {
            }
        }

        protected void loadDetailsViaLOB_CircuitStatus()
        {
            try
            {
                _objdt = obj.GetOBGetDetailsViaLOB_CircuitStatus();
                DataRow dr = _objdt.NewRow();
                dr[0] = "Total";
                dr[2] = GetTotal(_objdt, "No of Signups");
                dr[3] = string.Format("{0:n0}", GetTotal(_objdt, "OTC"));
                dr[4] = string.Format("{0:n0}", GetTotal(_objdt, "MRC"));
                _objdt.Rows.InsertAt(dr, _objdt.Rows.Count + 1);
                dtDetailsOI.HeaderStyle.HorizontalAlign = HorizontalAlign.Center;
                dtDetailsLS.DataSource = _objdt;
                dtDetailsLS.DataBind();
                dtDetailsLS.Rows[_objdt.Rows.Count - 1].Font.Bold = true;
                dtDetailsLI.RowStyle.Width = 50;

                
            }
            catch (Exception ex)
            {
            }
        }

        protected void loadDetailsViaOwner_InfraMedium()
        {
            try
            {
                _objdt = obj.GetOBGetDetailsViaOwner_InfraMedium();
                DataRow dr = _objdt.NewRow();
                dr[0] = "Total";
                dr[2] = GetTotal(_objdt, "No of Signups");
                dr[3] = string.Format("{0:n0}", GetTotal(_objdt, "OTC"));
                dr[4] = string.Format("{0:n0}", GetTotal(_objdt, "MRC"));
                _objdt.Rows.InsertAt(dr, _objdt.Rows.Count + 1);
                dtDetailsOI.HeaderStyle.HorizontalAlign = HorizontalAlign.Center;
                dtDetailsOI.DataSource = _objdt;
                dtDetailsOI.DataBind();
                dtDetailsOI.Rows[_objdt.Rows.Count - 1].Font.Bold = true;
                dtDetailsLI.RowStyle.Width = 50;
                
            }
            catch (Exception ex)
            {
            }
        }

        private string GetTotal(DataTable dt, string ColumnName)
        {
            try
            {

                long Total = 0;
                foreach (DataRow dr in dt.Rows)
                {
                    string price = dr[ColumnName].ToString();
                    long Fig = Convert.ToInt64(price.Replace(",",""));
                    Total += Fig;
                }

                return Convert.ToDecimal(Total).ToString("#,##0");
   
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

     
        protected void dtDetailsLI_RowDataBound(object o, GridViewRowEventArgs e)
        {
            try
            {
                if (e.Row.RowType == DataControlRowType.Header)
                {
                    foreach (TableCell cell in e.Row.Cells)
                    {
                        cell.BackColor = System.Drawing.Color.LightGray;
                        cell.HorizontalAlign = HorizontalAlign.Center;

                    }
                }

                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    e.Row.Cells[4].HorizontalAlign = HorizontalAlign.Right;
                    e.Row.Cells[3].HorizontalAlign = HorizontalAlign.Right;
                    e.Row.Cells[2].HorizontalAlign = HorizontalAlign.Right;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected void dtDetailsLS_RowDataBound(object o, GridViewRowEventArgs e)
        {
            try
            {
                if (e.Row.RowType == DataControlRowType.Header)
                {
                    foreach (TableCell cell in e.Row.Cells)
                    {
                        cell.BackColor = System.Drawing.Color.LightGray;
                        cell.HorizontalAlign = HorizontalAlign.Center;
                    }
                }

                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    e.Row.Cells[4].HorizontalAlign = HorizontalAlign.Right;
                    e.Row.Cells[3].HorizontalAlign = HorizontalAlign.Right;
                    e.Row.Cells[2].HorizontalAlign = HorizontalAlign.Right;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected void dtDetailsOI_RowDataBound(object o, GridViewRowEventArgs e)
        {
            try
            {
                if (e.Row.RowType == DataControlRowType.Header)
                {
                    foreach (TableCell cell in e.Row.Cells)
                    {
                        cell.BackColor = System.Drawing.Color.LightGray;
                        cell.HorizontalAlign = HorizontalAlign.Center;
                    }
                }

                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    e.Row.Cells[4].HorizontalAlign = HorizontalAlign.Right;
                    e.Row.Cells[3].HorizontalAlign = HorizontalAlign.Right;
                    e.Row.Cells[2].HorizontalAlign = HorizontalAlign.Right;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}