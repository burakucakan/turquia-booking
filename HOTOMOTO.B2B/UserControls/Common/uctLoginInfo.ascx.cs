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

public partial class UserControls_Common_uctLoginInfo : BaseUserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack) {
            SetDefaultValue();      //Açýlýþ Deðerlerini Yükle            
        }

        if (Session["Reservations"] != null)
        {
            hlReservation.Enabled = true;
            hlReservation.NavigateUrl += ConfigurationManager.AppSettings["SummaryPage"].ToString() + "?SummaryType=" + ((int)HOTOMOTO.BUS.Enumerations.SummaryType.NewReservation).ToString();
        }
        else if ((Session["ReservationCode"] != null) && (CARETTA.COM.Util.ReturnPageName() != ConfigurationManager.AppSettings["ReservationFinish"].ToString()))
        {
            hlReservation.Text = "Ödeme Sayfasý"; // Resx yazý 
            hlReservation.Enabled = true;
            hlReservation.NavigateUrl += ConfigurationManager.AppSettings["PaymentPage"].ToString();
        }
    }

    private void SetDefaultValue() {
        ltlDate.Text = DateTime.Now.ToShortDateString();
        ltlUserName.Text += this.SessRoot.UserFirstName + " " + this.SessRoot.UserLastName;
        ltlEntryDate.Text = this.SessRoot.LoginDate.ToShortTimeString();
    }
}
