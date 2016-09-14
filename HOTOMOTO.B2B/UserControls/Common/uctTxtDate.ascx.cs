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

public partial class UserControls_Common_uctTxtDate : System.Web.UI.UserControl {

    public string Date {
        get { return txtDate.Text; }
        set { txtDate.Text = value; }
    }

    public string ErrorMessage {
        set {
            RequiredFieldValidator1.ErrorMessage = value;
        }
    }
	
    protected void Page_Load(object sender, EventArgs e) {
    }
}
