using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Data;
using System.Web.UI.WebControls;
using RainMaker.BSS_Service;

namespace RainMaker
{
    public partial class MainForms_Site : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                SetMainControls();

            }


        }

        protected void SetMainControls()
        {
            try
            {

                BSS_Service.Service1SoapClient client = new BSS_Service.Service1SoapClient();

                //String roleid = "1";
                //lblName.Text = "Sami";
                //userImage.ImageUrl = "Images/default.png";
                //lblDesignation.Text = "Software DEveloper";


                String roleid = Session["RoleID"].ToString();
                var nameStr = Session["Name"].ToString().Split(' ');
                string name = nameStr[1];
                lblName.Text = name;
                userImage.ImageUrl = Session["Image"].ToString();
                lblDesignation.Text = Session["Desgination"].ToString();




                DataTable dt = client.GetModuleNameViaRole(Convert.ToInt16(roleid));

                var cls = dt.Rows[1][1].ToString();
                NavBar.InnerHtml = "";
                foreach (DataRow row in dt.Rows)
                {
                    if (row["ModuleName"].ToString() != "0")
                    {
                        NavBar.InnerHtml += " <li id='" + row["ModuleID"].ToString() + "'  onmouseover='reply_click(this.id)' class='nav-item main-nav-link'><a class='nav-link'><img src='" + row["ModuleImage"].ToString() + "'><span>" + row["ModuleName"].ToString() + "</span></a></li> ";


                        DataTable dt_child = client.GetFormsViaRole_ModuleId(Convert.ToInt16(roleid), Convert.ToInt16(row["ModuleID"]));




                        NavChild.InnerHtml += "<ul id=Module_" + row["ModuleID"].ToString() + " class= 'nav nav-pills flex-column sidebar-side-div' style='display:none;'>";
                        foreach (DataRow rowC in dt_child.Rows)
                        {
                            if (rowC["WebDisplayName"].ToString() != "0")
                            {

                                NavChild.InnerHtml += "<li class='nav-item' id ='" + rowC["FormIDName"].ToString() + "'><a class='nav-link active' href='" + ResolveUrl(rowC["Redirection"].ToString()) + "'>" + rowC["WebDisplayName"].ToString() + "</a></li> ";

                            }
                        }
                        NavChild.InnerHtml += "</ul>";
                    }
                    //   
                }
                NavBar.InnerHtml += "</ul>";
            }



            catch (Exception)
            {

                throw;
            }


        }
    }
}