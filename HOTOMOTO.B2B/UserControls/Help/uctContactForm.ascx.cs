using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using CARETTA.COM;
using System.Text;

public partial class UserControls_Help_uctContactForm : BaseUserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack) {
        	ltlUserName.Text = this.SessRoot.UserFirstName + " " + this.SessRoot.UserLastName;
        } 
    }
    protected void btnSend_Click(object sender, EventArgs e)
    {
        StringBuilder sbBody = new StringBuilder();
        sbBody.Append("<font face='Tahoma' style='font-size: 12px;'>");
        sbBody.Append("<b><font color='#800000'>TURQUIA DESTEK FORMU</font></b><br><br>");
        sbBody.Append("<b>Gönderen:</b> " + this.SessRoot.UserFirstName + " " + this.SessRoot.UserLastName + "<br><br>");
        sbBody.Append("<b>Mesaj;</b><br>");
        sbBody.Append(txtMessage.Text);
        sbBody.Append("</font>");

        Mailing objMail = new Mailing(ConfigurationManager.AppSettings["EMailServer"].ToString());
        if (objMail.SendEMail(ConfigurationManager.AppSettings["MailFrom"].ToString(), ConfigurationManager.AppSettings["MailTo"].ToString(), "TURQUIA WEB - DESTEK", sbBody.ToString(), "", "", System.Net.Mail.MailPriority.Normal))
        {
            pnlMailFormSendSucc.Visible = true;
        }
        else
        {
            pnlMailFormSendErr.Visible = true;
        }

        pnlMailForm.Visible = false;
    }
}
