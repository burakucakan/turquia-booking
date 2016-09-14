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

public partial class UserControls_Common_DDL_uctDDLLanguages : System.Web.UI.UserControl
{
    public string SelectedValue
    {
        get { return ddlLanguages.SelectedValue; }
        set { ddlLanguages.SelectedValue = value; }
    }
    public string SelectedText
    {
        get { return ddlLanguages.Text; }
        set { ddlLanguages.Text = value; }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            CARETTA.COM.DDLHelper.BindDDL(ref ddlLanguages, HOTOMOTO.BUS.Language.GetAllLanguages(), "Language", "LanguageID", "", "", "");
        }
    }
}
