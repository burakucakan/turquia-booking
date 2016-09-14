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

public partial class UserControls_Login_uctLogin : BaseUserControl
{
    protected void Page_Load(object sender, EventArgs e) {
        if (!IsPostBack) {

            IsLogin();                  //Login mi Kontrol et

            ReadCookie();               //Varsa Cookie deki bilgileri al

        }
    }

    protected void Page_Init(object sender, EventArgs e) {
        Response.Cache.SetNoStore();
    }

    //Þifre Gönderim Panelini Göster Gizle
    protected void lbForgotPass_Click(object sender, EventArgs e) {
        if (pnlForgotPassword.Visible) {
            pnlForgotPassword.Visible = false;
        }
        else {
            pnlForgotPassword.Visible = true;
        }
    }

    //Güvenli Giriþ OnClick
    protected void btnLogin_Click(object sender, EventArgs e) {
        DataTable dtLogin;

        //Kullanýcý Bilgilerini Kontrol Et
        dtLogin = HOTOMOTO.BUS.Authentication.LoginControl(txtCustomerNo.Text.Trim(), txtUserName.Text.Trim(), txtPass.Text.Trim());

        if (dtLogin.Rows.Count > 0)     //Kullanýcý Bilgileri Doðru, Giriþ Yapabilir
        {
            SetSession(dtLogin);            //Session Deðerlerini Ata

            WriteLoginCookie();             //Cookie Deðerleri Ata

            LoginLogSave();                 //Log Tablosuna Yaz

            GotoDefaultPage();              //Ana Sayfaya Yönlendir
        }
        else                            //Kullanýcý Bilgileri Yanlýþ Hata Mesajý Göster
        {
            ModalPopup1.Show(UserControls_ModalPopup_ModalPopup.Icons.error2, "LOGIN ERROR", "Böyle Bir Kullanýcý Bulunamadý!");
        }

    }


#region ÝÞLEMLER

    private void SetSession(DataTable dtLogin) {
        SessionRoot objSession = new SessionRoot((int)dtLogin.Rows[0]["UserID"]);
        objSession.LanguageID = 3; ////int.Parse(UctDDLLanguages1.SelectedValue);
        objSession.CustomerID = (int)dtLogin.Rows[0]["CustomerID"];
        objSession.UserID = (int)dtLogin.Rows[0]["UserID"];
        objSession.CustomerNo = (string)dtLogin.Rows[0]["CustomerCode"];
        objSession.UserRoleID = (int)dtLogin.Rows[0]["UserRoleID"];
        objSession.CurrencyID = ((HOTOMOTO.BUS.Enumerations.CurrencyTypes)dtLogin.Rows[0]["CurrencyID"]);
        objSession.CurrencySymbolLeft = (string)dtLogin.Rows[0]["SymbolLeft"];
        objSession.CurrencySymbolRight = (string)dtLogin.Rows[0]["SymbolRight"];
        objSession.UserIP = Request.ServerVariables["REMOTE_ADDR"];
        objSession.UserFirstName = (string)dtLogin.Rows[0]["FirstName"];
        objSession.UserLastName = (string)dtLogin.Rows[0]["LastName"];
        objSession.UserEmail = (string)dtLogin.Rows[0]["UserMail"];
        objSession.CompanyName = (string)dtLogin.Rows[0]["CompanyName"];
        objSession.LoginDate = DateTime.Now;

        Session.Add("SessionRoot", objSession);
    }

    private void WriteLoginCookie() {
        string strLoginCookieName;
        int intLoginCookieTimeout;

        strLoginCookieName = System.Configuration.ConfigurationManager.AppSettings["LoginCookieName"];
        intLoginCookieTimeout = int.Parse(System.Configuration.ConfigurationManager.AppSettings["LoginCookieTimeoutInMinutes"].ToString());

        if ((Request != null)) {
            if (((Request.Cookies[strLoginCookieName] != null))) {
                Response.Cookies.Set(Request.Cookies[strLoginCookieName]);
            }
            else {
                Response.Cookies.Set(new HttpCookie(strLoginCookieName));
            }

            Response.Cookies[strLoginCookieName]["LanguageID"] = this.SessRoot.LanguageID.ToString();
            Response.Cookies[strLoginCookieName]["CustomerNo"] = this.SessRoot.CustomerNo.ToString();
            Response.Cookies[strLoginCookieName].Expires = DateTime.Now.AddMinutes(intLoginCookieTimeout);
        }
    }

    private void ReadCookie() {
        string strLoginCookieName;

        strLoginCookieName = System.Configuration.ConfigurationManager.AppSettings["LoginCookieName"];
        if (Request.Cookies[strLoginCookieName] != null) {
            for (int i = Request.Cookies.Count - 1; i==0; i--) {
                if (Request.Cookies[i].Name == strLoginCookieName) {
                    try {
                        txtCustomerNo.Text = Request.Cookies[i]["CustomerNo"] == null ? "" : Request.Cookies[i]["CustomerNo"].ToString();
                        ////UctDDLLanguages1.SelectedValue = Request.Cookies[i]["LanguageID"] == null ? "1" : Request.Cookies[i]["LanguageID"].ToString();
                    }
                    catch (Exception) {
                    }
                }
            }
        }
        
    }

    private void LoginLogSave() {
        HOTOMOTO.BUS.Authentication.LogSave(this.SessRoot.UserID, this.SessRoot.UserIP, this.SessRoot.LoginDate);
    }

    private void IsLogin() {
        if (SessRoot != null) {
            GotoDefaultPage();
        }
    }

    private void GotoDefaultPage() {
        Response.Redirect("~/Default.aspx");
    }

#endregion



    //-----------------------------------------------------------------------------------------
    // TODO : HIZLI GÝRÝÞ ÝÇÝN DEVELOPMENT AÞAMASINDA -----------------------------------------
    //-----------------------------------------------------------------------------------------
    //protected void Page_PreRender(object sender, EventArgs e)
    //{
    //    if (Request.QueryString.Count < 1)
    //    {
    //        txtCustomerNo.Text = "11111111111";
    //        txtUserName.Text = "burak";
    //        txtPass.Text = "burak";
    //        UctDDLLanguages1.SelectedValue = "3";
    //        btnLogin_Click(new object(), new EventArgs());
    //    }
    //}
    //-----------------------------------------------------------------------------------------
    //-----------------------------------------------------------------------------------------





}
