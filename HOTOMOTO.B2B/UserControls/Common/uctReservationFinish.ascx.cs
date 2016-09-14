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

public partial class UserControls_Common_uctReservationFinish : BaseUserControl {
    protected void Page_Load(object sender, EventArgs e) {
        if (!IsPostBack) {

            if (CARETTA.COM.Util.ReturnRefererPageName() != ConfigurationManager.AppSettings["PaymentPage"].ToString()) {
                Response.Redirect("Default.aspx");
            }

            RemoveSessions();       // T�m Sessionlar� Bo�alt

        }
    }

    void RemoveSessions() {
        Session.Remove("ReservationID");
        Session.Remove("ReservationCode");

        // Her ihtimale kar�� �nceden silinmesi gerekenleri de sil  
        Session.Remove("Room");
        Session.Remove("Tour");
        Session.Remove("Transfer");
        Session.Remove("Guest");
        Session.Remove("Reservations");
    }

}
