using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Numerics;
using System.Data;

namespace RainMaker.Dashboard
{
    public partial class Revenue : System.Web.UI.Page
    {
        public MethodCalling obj = new MethodCalling();
        DataTable _objdt = new DataTable();

        protected void Page_Load(object sender, EventArgs e)
        {
            loadInvoices();
            loadRevenueCountMonthGreater3();
            loadRevenue();
            loadReciptMonthWise();
            loadSalesTaxMonth();

        }

        private Int64 GetTotal(DataTable dt, string ColumnName)
        {
            try
            {

                long Total = 0;
                foreach (DataRow dr in dt.Rows)
                {
                    string price = dr[ColumnName].ToString();
                    long Fig = Convert.ToInt64(price.Replace(",", ""));
                    Total += Fig;
                }

                return Convert.ToInt64(Total);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private string GetTotalString(DataTable dt, string ColumnName)
        {
            try
            {

                long Total = 0;
                foreach (DataRow dr in dt.Rows)
                {
                    string price = dr[ColumnName].ToString();
                    string p1 = price.Replace(".", "");
                    long Fig = Convert.ToInt64(p1.Replace(",", ""));
                    Total += Fig;
                }

                return Convert.ToDecimal(Total).ToString("#,##0");

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        protected void loadInvoices()
        {
            try
            {
                _objdt = obj.GetInvoicesMonthWiseLOB();
                DataRow dr = _objdt.NewRow();
                dr[0] = "Total";
                dr[1] = GetTotal(_objdt, "JAN");
                dr[2] = GetTotal(_objdt, "FEB");
                dr[3] = GetTotal(_objdt, "MAR");
                dr[4] = GetTotal(_objdt, "APR");
                dr[5] = GetTotal(_objdt, "MAY");
                dr[6] = GetTotal(_objdt, "JUN");
                dr[7] = GetTotal(_objdt, "JUL");
                dr[8] = GetTotal(_objdt, "AUG");
                dr[9] = GetTotal(_objdt, "SEP");
                dr[10] = GetTotal(_objdt, "OCT");
                dr[11] = GetTotal(_objdt, "NOV");
                dr[12] = GetTotal(_objdt, "DEC");
                _objdt.Rows.InsertAt(dr, _objdt.Rows.Count + 1);
                dtInvoices.HeaderStyle.HorizontalAlign = HorizontalAlign.Center;
                dtInvoices.DataSource = _objdt;
                dtInvoices.DataBind();
                dtInvoices.Rows[_objdt.Rows.Count - 1].Font.Bold = true;
                dtInvoices.RowStyle.Width = 50;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected void loadRevenueCountMonthGreater3()
        {
            try
            {
                _objdt = obj.GetRevenueCountMonthGreater3();
                DataRow dr = _objdt.NewRow();
                dr[0] = "Total";
                dr[1] = GetTotal(_objdt, "JAN");
                dr[2] = GetTotal(_objdt, "FEB");
                dr[3] = GetTotal(_objdt, "MAR");
                dr[4] = GetTotal(_objdt, "APR");
                dr[5] = GetTotal(_objdt, "MAY");
                dr[6] = GetTotal(_objdt, "JUN");
                dr[7] = GetTotal(_objdt, "JUL");
                dr[8] = GetTotal(_objdt, "AUG");
                dr[9] = GetTotal(_objdt, "SEP");
                dr[10] = GetTotal(_objdt, "OCT");
                dr[11] = GetTotal(_objdt, "NOV");
                dr[12] = GetTotal(_objdt, "DEC");
                _objdt.Rows.InsertAt(dr, _objdt.Rows.Count + 1);
                dtRevenueCount3.HeaderStyle.HorizontalAlign = HorizontalAlign.Center;
                dtRevenueCount3.DataSource = _objdt;
                dtRevenueCount3.DataBind();
                dtRevenueCount3.Rows[_objdt.Rows.Count - 1].Font.Bold = true;
                dtRevenueCount3.RowStyle.Width = 50;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected void loadRevenue()
        {
            try
            {
                _objdt = obj.GetRevenueMonthWiseLOB();
                DataRow dr = _objdt.NewRow();
                dr[0] = "Total";
                dr[1] = string.Format("{0:n0}", GetTotalString(_objdt, "JAN"));
                dr[2] = string.Format("{0:n0}", GetTotalString(_objdt, "FEB"));
                dr[3] = string.Format("{0:n0}", GetTotalString(_objdt, "MAR"));
                dr[4] = string.Format("{0:n0}", GetTotalString(_objdt, "APR"));
                dr[5] = string.Format("{0:n0}", GetTotalString(_objdt, "MAY"));
                dr[6] = string.Format("{0:n0}", GetTotalString(_objdt, "JUN"));
                dr[7] = string.Format("{0:n0}", GetTotalString(_objdt, "JUL"));
                dr[8] = string.Format("{0:n0}", GetTotalString(_objdt, "AUG"));
                dr[9] = string.Format("{0:n0}", GetTotalString(_objdt, "SEP"));
                dr[10] = string.Format("{0:n0}", GetTotalString(_objdt, "OCT"));
                dr[11] = string.Format("{0:n0}", GetTotalString(_objdt, "NOV"));
                dr[12] = string.Format("{0:n0}", GetTotalString(_objdt, "DEC"));
                _objdt.Rows.InsertAt(dr, _objdt.Rows.Count + 1);
                dtRevenue.HeaderStyle.HorizontalAlign = HorizontalAlign.Center;
                dtRevenue.DataSource = _objdt;
                dtRevenue.DataBind();
                dtRevenue.Rows[_objdt.Rows.Count - 1].Font.Bold = true;
                dtRevenue.RowStyle.Width = 50;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected void loadReciptMonthWise()
        {
            try
            {
                _objdt = obj.GetReceiptmonthwise();
                DataRow dr = _objdt.NewRow();
                dr[0] = "Total";
                dr[1] = string.Format("{0:n0}", GetTotalString(_objdt, "JAN"));
                dr[2] = string.Format("{0:n0}", GetTotalString(_objdt, "FEB"));
                dr[3] = string.Format("{0:n0}", GetTotalString(_objdt, "MAR"));
                dr[4] = string.Format("{0:n0}", GetTotalString(_objdt, "APR"));
                dr[5] = string.Format("{0:n0}", GetTotalString(_objdt, "MAY"));
                dr[6] = string.Format("{0:n0}", GetTotalString(_objdt, "JUN"));
                dr[7] = string.Format("{0:n0}", GetTotalString(_objdt, "JUL"));
                dr[8] = string.Format("{0:n0}", GetTotalString(_objdt, "AUG"));
                dr[9] = string.Format("{0:n0}", GetTotalString(_objdt, "SEP"));
                dr[10] = string.Format("{0:n0}", GetTotalString(_objdt, "OCT"));
                dr[11] = string.Format("{0:n0}", GetTotalString(_objdt, "NOV"));
                dr[12] = string.Format("{0:n0}", GetTotalString(_objdt, "DEC"));
                _objdt.Rows.InsertAt(dr, _objdt.Rows.Count + 1);
                dtReciptMonthWise.HeaderStyle.HorizontalAlign = HorizontalAlign.Center;
                dtReciptMonthWise.DataSource = _objdt;
                dtReciptMonthWise.DataBind();
                dtReciptMonthWise.Rows[_objdt.Rows.Count - 1].Font.Bold = true;
                dtReciptMonthWise.RowStyle.Width = 50;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected void loadSalesTaxMonth()
        {
            try
            {
                _objdt = obj.GetSalesTaxmonthwiseLOB();
                DataRow dr = _objdt.NewRow();
                dr[0] = "Total";
                dr[1] = string.Format("{0:n0}", GetTotalString(_objdt, "JAN"));
                dr[2] = string.Format("{0:n0}", GetTotalString(_objdt, "FEB"));
                dr[3] = string.Format("{0:n0}", GetTotalString(_objdt, "MAR"));
                dr[4] = string.Format("{0:n0}", GetTotalString(_objdt, "APR"));
                dr[5] = string.Format("{0:n0}", GetTotalString(_objdt, "MAY"));
                dr[6] = string.Format("{0:n0}", GetTotalString(_objdt, "JUN"));
                dr[7] = string.Format("{0:n0}", GetTotalString(_objdt, "JUL"));
                dr[8] = string.Format("{0:n0}", GetTotalString(_objdt, "AUG"));
                dr[9] = string.Format("{0:n0}", GetTotalString(_objdt, "SEP"));
                dr[10] = string.Format("{0:n0}", GetTotalString(_objdt, "OCT"));
                dr[11] = string.Format("{0:n0}", GetTotalString(_objdt, "NOV"));
                dr[12] = string.Format("{0:n0}", GetTotalString(_objdt, "DEC"));
                _objdt.Rows.InsertAt(dr, _objdt.Rows.Count + 1);
                dtSalesTaxMonth.HeaderStyle.HorizontalAlign = HorizontalAlign.Center;
                dtSalesTaxMonth.DataSource = _objdt;
                dtSalesTaxMonth.DataBind();
                dtSalesTaxMonth.Rows[_objdt.Rows.Count - 1].Font.Bold = true;
                dtSalesTaxMonth.RowStyle.Width = 50;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        //protected void dtRevenue_RowDataBound(object o, GridViewRowEventArgs e)
        //{
        //    try
        //    {
        //        if (e.Row.RowType == DataControlRowType.Header)
        //        {
        //            foreach (TableCell cell in e.Row.Cells)
        //            {
        //                cell.BackColor = System.Drawing.Color.LightGray;
        //                cell.HorizontalAlign = HorizontalAlign.Center;

        //            }
        //        }

        //        if (e.Row.RowType == DataControlRowType.DataRow)
        //        {

        //            e.Row.Cells[4].HorizontalAlign = HorizontalAlign.Right;
        //            e.Row.Cells[3].HorizontalAlign = HorizontalAlign.Right;
        //            e.Row.Cells[2].HorizontalAlign = HorizontalAlign.Right;
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}

        //protected void dtReciptMonthWise_RowDataBound(object o, GridViewRowEventArgs e)
        //{
        //    try
        //    {
        //        if (e.Row.RowType == DataControlRowType.Header)
        //        {
        //            foreach (TableCell cell in e.Row.Cells)
        //            {
        //                cell.BackColor = System.Drawing.Color.LightGray;
        //                cell.HorizontalAlign = HorizontalAlign.Center;

        //            }
        //        }

        //        if (e.Row.RowType == DataControlRowType.DataRow)
        //        {

        //            e.Row.Cells[4].HorizontalAlign = HorizontalAlign.Right;
        //            e.Row.Cells[3].HorizontalAlign = HorizontalAlign.Right;
        //            e.Row.Cells[2].HorizontalAlign = HorizontalAlign.Right;
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}

        //protected void dtSalesTaxMonth_RowDataBound(object o, GridViewRowEventArgs e)
        //{
        //    try
        //    {
        //        if (e.Row.RowType == DataControlRowType.Header)
        //        {
        //            foreach (TableCell cell in e.Row.Cells)
        //            {
        //                cell.BackColor = System.Drawing.Color.LightGray;
        //                cell.HorizontalAlign = HorizontalAlign.Center;

        //            }
        //        }

        //        if (e.Row.RowType == DataControlRowType.DataRow)
        //        {

        //            e.Row.Cells[4].HorizontalAlign = HorizontalAlign.Right;
        //            e.Row.Cells[3].HorizontalAlign = HorizontalAlign.Right;
        //            e.Row.Cells[2].HorizontalAlign = HorizontalAlign.Right;
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}


    }
}