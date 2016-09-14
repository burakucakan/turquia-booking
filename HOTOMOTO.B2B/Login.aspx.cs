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

public partial class Login_Login : BasePage
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    public void HandleError(object sender, AsyncPostBackErrorEventArgs e)
    {
        //Loga yazýlabilir
        DataTable dtError;
        int LanguageID = 1;
        if (this.SessRoot.LanguageID > 0) {
            LanguageID = this.SessRoot.LanguageID;
        }
        dtError = HOTOMOTO.BUS.Error.GetError(LanguageID, HOTOMOTO.BUS.Enumerations.ErrorMessageTypes.AsyncPostBack);
        if (dtError.Rows.Count > 0) {
            ScrMng1.AsyncPostBackErrorMessage = dtError.Rows[0]["ErrorTitle"].ToString() + dtError.Rows[0]["Message"].ToString() + "(" + DateTime.Now.ToString() + ")";
        }
    }
}
