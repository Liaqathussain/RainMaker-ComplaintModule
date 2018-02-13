using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace RainMaker.Dashboard
{
    public partial class SmartSearch : System.Web.UI.Page
    {
        public MethodCalling obj = new MethodCalling();
        DataTable _objdt = new DataTable();

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void loadSearches(object sender, System.EventArgs e)
        {
            string Detail = null;
            Detail = SmartText.Text;
            _objdt = obj.GetComplainsViaSmartSearch(Detail);
            CountLabel.InnerText = _objdt.Rows.Count.ToString();
            SearchResults.DataSource = _objdt;
            SearchResults.DataBind();
        }
    }
}