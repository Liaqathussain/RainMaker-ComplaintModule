using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Data;
using System.Web.UI.WebControls;

namespace RainMaker
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        

        String IsADAuthenticate = null;
        protected void Page_Load(object sender, EventArgs e)
        {
          
            
           
        }



        protected void Button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (tbUser.Text == string.Empty || tbPassword.Text == string.Empty)
                {
                    lblnotify.Text = "Please enter username or password";
                    lblnotify.Visible = true;
                    return;
                }

                BSS_Service.Service1SoapClient client = new BSS_Service.Service1SoapClient();
                //BSS_ServiceLocal.Service1SoapClient client = new BSS_ServiceLocal.Service1SoapClient();
                DataTable dt = client.AuthenticateUser(tbUser.Text, tbPassword.Text);

                if (dt.Rows.Count == 1)
                {
                    
                    IsADAuthenticate = dt.Rows[0]["IsADAuthenticate"].ToString();
                    Session["UserID"] = dt.Rows[0]["UserID"];
                    Session["Name"] = dt.Rows[0]["Name"];
                    Session["ManagerID"] = dt.Rows[0]["ManagerID"];
                    Session["RoleID"] = dt.Rows[0]["RoleID"];
                    Session["DepartmentID"] = dt.Rows[0]["DepartmentID"];
                    Session["Desgination"] = dt.Rows[0]["Desgination"];
                    Session["Image"] = dt.Rows[0]["Image"];

                    if (IsADAuthenticate == "1")
                    {
                        if (client.Ldap_Authentication(tbUser.Text, tbPassword.Text) == true)
                        {
                            //HttpContext.Current.RewritePath("Default.aspx");
                            Server.Transfer(ResolveUrl("Default.aspx"), true);
                            //Server.Transfer("~/NRF/MapCoordinates.aspx", true);

                        }
                        else
                        {
                            lblnotify.Visible = true;
                            lblnotify.Text = "You are not authenticated from domain.";
                            return;
                        }
                    }
                    else if (IsADAuthenticate == "0")
                    {
                        //Server.Transfer("Default.aspx", true);
                        Response.Redirect("/Default.aspx", true);
                        //Response.Redirect("~/NRF/MapCoordinates.aspx", true);
                    }
                }
                else
                {
                    lblnotify.Visible = true;
                    lblnotify.Text = "Invalid username or password";
                }
            }
            catch (InvalidCastException)
            {
            }

        }
        }
}