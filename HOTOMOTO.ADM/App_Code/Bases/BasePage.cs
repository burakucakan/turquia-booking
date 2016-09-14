using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

/// <summary>
/// Summary description for BasePage
/// </summary>
public class BasePage : System.Web.UI.Page
{
    public BasePage()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    public SessionRoot SessRoot {
        get {
            if((Session != null)) {
                if(Session["SessionRoot"] == null) {
                    return null;
                } else {
                    return (SessionRoot)Session["SessionRoot"];
                }
            } else { 
                return null; 
            }
        }
    }

    private void Page_Init(object sender, System.EventArgs e) {
        
        if(SessRoot != null) {
            UserPermissionList();
            PermissionControl();
        } else if(System.IO.Path.GetFileName(Request.Path).ToString() != "Login.aspx") {
            Response.Redirect("~/Login.aspx");
        }
    }

    private void UserPermissionList() {
        if(SessRoot != null) {
            this.SessRoot.UserPermissionList = HOTOMOTO.BUS.Authentication.GetUserPermissions(this.SessRoot.UserRoleID, this.SessRoot.LanguageID);
        }
    }

    private void PermissionControl() {
        if(SessRoot != null) {
            if(!this.SessRoot.HasUserPermission(System.IO.Path.GetFileName(Request.Path).ToString())) {
                string ErrorTitle = "";
                string Message = "";
                DataTable dtError = HOTOMOTO.BUS.Error.GetError(this.SessRoot.LanguageID, HOTOMOTO.BUS.Enumerations.ErrorMessageTypes.Access);
                if(dtError.Rows.Count > 0) {
                    ErrorTitle = dtError.Rows[0]["ErrorTitle"].ToString();
                    Message = dtError.Rows[0]["Message"].ToString();
                }
                //Response.Redirect("Error.aspx?ErrorTitle=" + ErrorTitle + "&Message=" + Message);
            }
        }
    }
}
