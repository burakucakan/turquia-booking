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

public partial class UserControls_Error_uctError : System.Web.UI.UserControl {
    protected void Page_Load(object sender, EventArgs e) {
        WriteError();       //Hata Mesajýný QueryStringten Alýp Yazdýr
    }

    private void WriteError() {
        if (!IsPostBack) {
            if (Request.QueryString["ErrorTitle"] != null) {
                lblTitle.Text = Request.QueryString["ErrorTitle"].ToString();
            }
            if (Request.QueryString["Message"] != null) {
                lblMessage.Text = Request.QueryString["Message"].ToString();
            }
        }
    }
}
