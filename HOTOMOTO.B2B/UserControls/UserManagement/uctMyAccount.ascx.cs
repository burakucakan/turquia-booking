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

public partial class UserControls_UserManagement_uctMyAccount : BaseUserControl {
    protected void Page_PreRender(object sender, EventArgs e) {
        if (!IsPostBack) {

            uctUserForm1.UpUserID = this.SessRoot.UserID;

            uctUserForm1.FillUser();             // Kullan�c�n�n Bilgilerini Y�kle                   

            uctUserForm1.FillUserAddress();      // Kullan�c�n�n Adres Bilgilerini Y�kle             

            uctUserForm1.FillUserAccess();       // Kullan�c�ya Ait AccessOptions De�erlerini Y�kle  

        }
    }
}
