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

public partial class UserControls_Common_DDL_uctDDLTime : BaseUserControl {

    public string Time {
        get { return ddlHour.SelectedValue + ":" + ddlMinute.SelectedValue ; }
        set {             
            ddlHour.SelectedValue = CARETTA.COM.Util.Left(value, 2);
            ddlMinute.SelectedValue = CARETTA.COM.Util.Right(value, 2);
        }
    }

    public double Hour {
        get { return Convert.ToDouble(ddlHour.SelectedValue); }
        set { ddlHour.SelectedValue = value.ToString(); }
    }

    public double Minute {
        get { return Convert.ToDouble(ddlMinute.SelectedValue); }
        set { ddlMinute.SelectedValue = value.ToString(); }
    }

    protected void Page_Load(object sender, EventArgs e) {
        if (!IsPostBack) {
            LoadDDL();
        }
    }

    protected void LoadDDL() {
        CARETTA.COM.DDLHelper.LoadNumberDDL(ref ddlHour, 23, 1, 0);
        CARETTA.COM.DDLHelper.LoadNumberDDL(ref ddlMinute, 59, 1, 0);
        foreach (ListItem li in ddlHour.Items) {
            li.Text = li.Text.PadLeft(2, '0');
            li.Value = li.Value.PadLeft(2, '0');
        }
        foreach (ListItem li in ddlMinute.Items) {
            li.Text = li.Text.PadLeft(2, '0');
            li.Value = li.Value.PadLeft(2, '0');
        }
    }

}
