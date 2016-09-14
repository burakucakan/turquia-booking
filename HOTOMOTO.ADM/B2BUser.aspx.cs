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

public partial class B2BUser : BasePage 
{
    protected void Page_Init(object sender, EventArgs e)
    {
        UctUser1.UserRoleType = HOTOMOTO.BUS.Enumerations.RoleType.B2B;
    }

    protected void Page_Load(object sender, EventArgs e)
    {

    }
}
