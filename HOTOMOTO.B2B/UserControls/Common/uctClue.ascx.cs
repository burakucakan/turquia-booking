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

public partial class UserControls_Common_uctClue : BaseUserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {

        if (!IsPostBack)
        {
            SetTip();
        }

    }

    private void SetTip()
    {
        DataTable dtTips = HOTOMOTO.BUS.Help.GetRandomTip(this.SessRoot.LanguageID);
        if (dtTips.Rows.Count > 0)
        {
            ltlClueTitle.Text = dtTips.Rows[0]["Title"].ToString();
            ltlDescription.Text = CARETTA.COM.Util.Nl2Br(CARETTA.COM.Util.ClearHtmlTags(CARETTA.COM.Util.Left(dtTips.Rows[0]["Description"].ToString(), 200)));
            hlDetail.NavigateUrl = "~/Help.aspx?HelpID=" + dtTips.Rows[0]["HelpID"].ToString();
        }
    }
}
