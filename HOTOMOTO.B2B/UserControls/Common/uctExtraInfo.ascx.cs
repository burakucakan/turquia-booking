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

public partial class UserControls_Common_uctExtraInfo : BaseUserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack) {
            SetDefaultValue();      //Açýlýþ Deðerlerini Yükle            
        }
    }

    protected void Page_Init(object sender, EventArgs e) 
    {
        ImgNoEnter.Attributes.Add("onclick", "return false;");
    }

    private void SetDefaultValue() {
        ltlIP.Text = "IP: " + Request.ServerVariables["REMOTE_ADDR"];
    }

}
