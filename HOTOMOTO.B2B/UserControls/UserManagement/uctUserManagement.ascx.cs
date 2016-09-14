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
using System.Text;

public partial class UserControls_UserManagement_uctUserManagement : BaseUserControl {

    public int UpUserID {
        get {   
            return (ViewState["UpUserID"] == null ? 0 : int.Parse(ViewState["UpUserID"].ToString()));
        }
        set {
            ViewState["UpUserID"] = value;
        }
    }

    protected void Page_PreRender(object sender, EventArgs e) {
        LoadUsers();            // M��teriye Ait Kullan�c�lar� Getir 
    }

    // KULLANICI L�STES�                                                              
    private void LoadUsers() {
        DataTable dtUsers = HOTOMOTO.BUS.UserManagement.GetUsersByCustomerID(this.SessRoot.CustomerID, this.SessRoot.UserID);
        rptUsers.DataSource = dtUsers;
        rptUsers.DataBind();
    }
    protected void rptUsers_ItemDataBound(object sender, RepeaterItemEventArgs e) {
        if ((e.Item.ItemType == ListItemType.Item) || (e.Item.ItemType == ListItemType.AlternatingItem)) {
            Literal ltlUser = ((Literal)e.Item.FindControl("ltlUser"));
            ltlUser.Text = CARETTA.COM.Encryption.Decrypt(ltlUser.Text.Trim());
        }
    }
    protected void rptUsers_ItemCommand(object source, RepeaterCommandEventArgs e) {
        if ((e.Item.ItemType == ListItemType. Item) || (e.Item.ItemType == ListItemType.AlternatingItem)) {
            LinkButton lnkSender = ((LinkButton)e.CommandSource);
            this.UpUserID = int.Parse(lnkSender.CommandArgument);
            uctUserForm1.UpUserID = this.UpUserID;
            if (lnkSender.ID == "lbEdit") {

                uctUserForm1.FillUser();             // Kullan�c�n�n Bilgilerini Y�kle                   

                uctUserForm1.FillUserAddress();      // Kullan�c�n�n Adres Bilgilerini Y�kle             

                uctUserForm1.FillUserAccess();       // Kullan�c�ya Ait AccessOptions De�erlerini Y�kle  

            }
            else if (lnkSender.ID == "lbDelete") {
                DeleteUser();
            }

        }
    }

    private void DeleteUser() {
        if (HOTOMOTO.BUS.UserManagement.DeleteUser(this.UpUserID)) {

            LoadUsers();            // M��teriye Ait Kullan�c�lar� Getir 

            ModalPopup1.Show(UserControls_ModalPopup_ModalPopup.Icons.info2, "KULLANICI S�LME", "Se�mi� Oldu�unuz Kullan�c� Silinmi�tir", false);
        }
        else {
            ModalPopup1.Show(UserControls_ModalPopup_ModalPopup.Icons.info2, "KULLANICI S�LME HATASI", "Se�mi� Oldu�unuz Kullan�c� Silinemedi", false);
        }
    }
 
    protected void btnNew_Click(object sender, EventArgs e) {
        Response.Redirect("UserManagement.aspx");
    }
}
