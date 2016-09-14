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

public partial class Login : BasePage {

    protected void Page_Load(object sender, EventArgs e) {
		//if(!Page.IsPostBack) {
		//    CARETTA.COM.DDLHelper.BindDDL(ref ddlLanguages, HOTOMOTO.BUS.Language.GetAllLanguages(), "Language", "LanguageID", "");
		//}
        //txtUsername.Text = "admin";
        //txtPassword.Text = "123";

    }

    protected void btnLogin_Click(object sender, ImageClickEventArgs e) {

        DataTable dtUserInfo = HOTOMOTO.BUS.Authentication.LoginControl("1111111111", txtUsername.Text.Trim(), txtPassword.Text.Trim());
        //DataTable dtUserInfo = HOTOMOTO.BUS.Authentication.LoginControl("1111111111", "admin", "123");

        if(dtUserInfo.Rows.Count > 0) {
            SetSession(dtUserInfo);
            WriteLoginCookie();
            LoginLogSave();
            GotoDefaultPage();
        } else {
            uctErrorMessage.Css = MessageBlockCss.b230;
            uctErrorMessage.Type = MessageType.Error;
            uctErrorMessage.Message = "Hatalý kullanýcý adý veya parola. Lütfen kontrol edip tekrar deneyiniz.";
            uctErrorMessage.AddLink("forgotpassword.aspx", "Þifremi unuttum");
            uctErrorMessage.Visible = true;
        }
    }

    private void SetSession(DataTable dtUserInfo) {
        SessionRoot objSession = new SessionRoot((int)dtUserInfo.Rows[0]["UserID"]);
		objSession.LanguageID = 3; // int.Parse(this.ddlLanguages.SelectedValue);
        objSession.UserID = (int)dtUserInfo.Rows[0]["UserID"];
        objSession.UserRoleID = (int)dtUserInfo.Rows[0]["UserRoleID"];
        objSession.UserIP = Request.ServerVariables["REMOTE_ADDR"];
        objSession.UserFirstName = (string)dtUserInfo.Rows[0]["FirstName"];
        objSession.UserLastName = (string)dtUserInfo.Rows[0]["LastName"];
        objSession.UserEmail = (string)dtUserInfo.Rows[0]["UserMail"];
        objSession.LoginDate = DateTime.Now;

        Session.Add("SessionRoot", objSession);
    }

    private void WriteLoginCookie() {
        string strLoginCookieName;
        int intLoginCookieTimeout;

        strLoginCookieName = System.Configuration.ConfigurationManager.AppSettings["LoginCookieName"];
        intLoginCookieTimeout = int.Parse(System.Configuration.ConfigurationManager.AppSettings["LoginCookieTimeoutInMinutes"].ToString());

        if((Request != null)) {
            if(((Request.Cookies[strLoginCookieName] != null))) {
                Response.Cookies.Set(Request.Cookies[strLoginCookieName]);
            } else {
                Response.Cookies.Set(new HttpCookie(strLoginCookieName));
            }

			Response.Cookies[strLoginCookieName]["LanguageID"] = "3"; // this.ddlLanguages.SelectedValue.ToString();
            Response.Cookies[strLoginCookieName]["LastLoginDate"] = DateTime.Now.ToString();
            Response.Cookies[strLoginCookieName].Expires = DateTime.Now.AddMinutes(intLoginCookieTimeout);
        }
    }

    private void ReadCookie() {
        string strLoginCookieName;

        strLoginCookieName = System.Configuration.ConfigurationManager.AppSettings["LoginCookieName"];
        if(Request.Cookies[strLoginCookieName] != null) {
            //txtCustomerNo.Text = Request.Cookies[strLoginCookieName]["CustomerNo"] == null ? "" : Request.Cookies[strLoginCookieName]["CustomerNo"].ToString();
            //ddlLanguages.SelectedValue = Request.Cookies[strLoginCookieName]["LanguageID"] == null ? "1" : Request.Cookies[strLoginCookieName]["LanguageID"].ToString();
        }
    }
	
    private void LoginLogSave() {
        HOTOMOTO.BUS.Authentication.LogSave(this.SessRoot.UserID, this.SessRoot.UserIP, this.SessRoot.LoginDate);
    }

    private void IsLogin() {
        if(SessRoot != null) {
            GotoDefaultPage();
        }
    }

    private void GotoDefaultPage() {
        Response.Redirect("~/Default.aspx");
    }
}
