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

public partial class UserControls_Common_uctQuickLinks : BaseUserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack) {
            AddAttributes();
        }
    }

    private void AddAttributes()
    {
        hlAddFavorites.Attributes.Add("onclick", "AddFavorites('http://www.turquia.com','TURQUIA'); return false;");
        hlStHomePage.Attributes.Add("onclick", "this.style.behavior='url(#default#homepage)';this.setHomePage('http://www.turquia.com'); return false;");
    }

    protected void lbLogOut_Click(object sender, EventArgs e) {
        Session.Clear();
        Session.Abandon();
        Response.Redirect("Login.aspx");
    }
}
