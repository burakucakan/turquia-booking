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

public partial class UserControls_Help_uctHelp : BaseUserControl
{
    private DataTable vwDtHelp
    {
        get
        {
            return (DataTable)ViewState["vwDtHelp"];
        }
        set
        {
            ViewState["vwDtHelp"] = value;
        }
    }

    public int HelpID
    {
        get { return (ViewState["HelpID"] == null ? -1 : int.Parse(ViewState["HelpID"].ToString())); }
        set { ViewState["HelpID"] = value; }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            LoadTopics();

            if (CARETTA.COM.Util.IsNumeric(Request.QueryString["HelpID"]))
            {
                this.HelpID = int.Parse(Request.QueryString["HelpID"]);
            }

            LoadDetail(this.HelpID);
        }
    }

    private void LoadTopics()
    {
        vwDtHelp = HOTOMOTO.BUS.Help.GetAllHelp(this.SessRoot.LanguageID);
        
        if (vwDtHelp.Rows.Count > 0) {            
            rptHelpTopics.DataSource = vwDtHelp;
            rptHelpTopics.DataBind();
            this.HelpID = Convert.ToInt32(vwDtHelp.Rows[0]["HelpID"]);
        }

    }

    private void LoadDetail(int HelpID)
    {
        foreach (DataRow dr in vwDtHelp.Rows)
        {
            if ((int)dr["HelpID"] == HelpID)
            {
                ltlActiveHelpTopic.Text = dr["Title"].ToString();
                ltlActiveHelpContent.Text =  CARETTA.COM.Util.Nl2Br(dr["Description"].ToString());
                break;
            }
        }
    }

    protected void rptHelpTopics_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        LoadDetail(Convert.ToInt32(e.CommandArgument));
    }
}
