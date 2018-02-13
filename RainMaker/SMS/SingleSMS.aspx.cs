using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace RainMaker.SMS
{
    public partial class SingleSMS : System.Web.UI.Page
    {
        BL objBL = new BL();
        //BSS_ServiceLocal.Service1SoapClient objBSS = new BSS_ServiceLocal.Service1SoapClient();
        BSS_Service.Service1SoapClient objBSS = new BSS_Service.Service1SoapClient();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

            }
        }

        protected void btnSend_Click(object sender, EventArgs e)
        {
            if (isValidate().Equals(true))
            {
                objBSS.SendSMS("External SMS", tbMobileNo.Text, tbSMS.Text, 1);
                lblSave.Text = "Message send successfully";
                lblSave.Visible = true;
            }

            else
            {
                lblSave.Text = "Either your message box or mobile no is not given";
                lblSave.Visible = true;
            }
        }

        public bool isValidate()
        {
            bool @bool = true;

            try
            {

                if (tbSMS.Text.Equals("") || tbMobileNo.Text.Equals(""))
                {
                    @bool = false;
                    return @bool;
                }

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
                //Interaction.MsgBox(ex.Message, MsgBoxStyle.Critical, Title: "Message Box");
            }
            return @bool;
        }
    }
}