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

public partial class UserControls_Payments_uctPayments : BaseUserControl {

    protected void Page_Load(object sender, EventArgs e) {

        if (!IsPostBack) {

            // UserID nin -1 gönderilmesinin sebebi listede kendisinin de çýkmasý (Proc: UserID <> -1)
            DataTable dtUsers = HOTOMOTO.BUS.UserManagement.GetUsersByCustomerID(this.SessRoot.CustomerID, -1);

            CARETTA.COM.DDLHelper.BindDDL(ref ddlUsers, dtUsers, "Name", "UserID", "", "All Users", "%");
            UctPaymentList1.ListTitle = "PAYMENT HISTORY";

            GetReservations();
        }
    }

    private void GetReservations() {
        UctPaymentList1.FillPayments(ddlReservationTypes.SelectedValue, ddlUsers.SelectedValue);
    }

    protected void btnFilter_Click(object sender, EventArgs e) {
        GetReservations();
    }
}
