using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.IO;
using HOTOMOTO.COM;

public class BasePage : System.Web.UI.Page 
{
    public SessionRoot SessRoot
    {
        get
        {
            if ((Session != null))
            {
                if (Session.Contents["SessionRoot"] == null) { return null; }
                else { return (SessionRoot)Session["SessionRoot"]; }
            }
            else { 
                Session.Abandon();
                HttpContext.Current.Response.Redirect("Login.aspx");
                return null;
            }
        }
    }

    public object CacheMach(CacheMachine.CacheTypes CacheType, int LanguageID)
    {
        if (Application["CacheMachine"] == null)
        {
            CacheMachine cm = new CacheMachine();
            Application.Add("CacheMachine", cm);
        }
        return ((CacheMachine)Application["CacheMachine"]).Item(CacheType, LanguageID);
    }

    private void Page_Init(object sender, System.EventArgs e) {

        Response.Cache.SetNoStore();
        Response.Expires = -1;

        //Adresi "Https" Kontrolü yap
        UrlControl(System.IO.Path.GetFileNameWithoutExtension((Request.Path) + ".aspx").ToString(), Request.ServerVariables["SERVER_PORT"].ToString(), Request.ServerVariables["SERVER_NAME"].ToString(), Request.ServerVariables["URL"]);

        if (SessRoot != null) {         //Session Var Ýse

            //Kullanýcý Yetkilerini Yükle
            UserPermissionList();

            //Kullanýcýnýn Bulunduðu Yetkisini Kontrol Et, Yoksa Error.aspx e gönder
            PermissionControl();
        }
        else if (System.IO.Path.GetFileNameWithoutExtension((Request.Path) + ".aspx").ToString() != "Login.aspx") {
            Response.Redirect("~/Login.aspx");
        }
    }

#region ÝÞLEMLER

    private void UrlControl(string PageName, string ServerPort, string ServerName, string URL) {
        string strSecureURL  = "";
        if (PageName == ConfigurationManager.AppSettings["PaymentPage"].ToString()) {
            if (ServerPort == "80") {
                strSecureURL = "https://";
                Response.Redirect(strSecureURL.ToString() + ServerName + URL);
            }
        }
        else if (ServerPort == "443") {
            strSecureURL = "http://";
            Response.Redirect(strSecureURL.ToString() + ServerName + URL);
        }
    }

    private void UserPermissionList() {
        if (SessRoot != null) {
            this.SessRoot.UserPermissionList = HOTOMOTO.BUS.Authentication.GetUserPermissions(this.SessRoot.UserRoleID, this.SessRoot.LanguageID);
        }
    }

    private void PermissionControl() {
        if (SessRoot != null) {
            if (!this.SessRoot.HasUserPermission((System.IO.Path.GetFileNameWithoutExtension(Request.Path).ToString() + ".aspx"))) {
                string ErrorTitle = "";
                string Message = "";
                DataTable dtError = HOTOMOTO.BUS.Error.GetError(this.SessRoot.LanguageID, HOTOMOTO.BUS.Enumerations.ErrorMessageTypes.Access);
                if (dtError.Rows.Count > 0) {
                    ErrorTitle = dtError.Rows[0]["ErrorTitle"].ToString();
                    Message = dtError.Rows[0]["Message"].ToString();
                }
                Response.Redirect("Error.aspx?ErrorTitle=" + ErrorTitle + "&Message=" + Message);
            }
        }
    }

#endregion

}
