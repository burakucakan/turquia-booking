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

public partial class userControls_Tours_uctTourRecurrence : System.Web.UI.UserControl
{
    public int TourID
    {
        get { return ViewState["TID"] == null ? 0 : Convert.ToInt32(ViewState["TID"]); }
        set { ViewState.Add("TID", value); }
    }

    protected void Page_Load(object sender, EventArgs e)
    {

    }
}
