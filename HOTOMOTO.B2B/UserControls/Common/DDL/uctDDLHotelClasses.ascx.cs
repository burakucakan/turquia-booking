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

public partial class UserControls_Common_DDL_uctDDLHotelClasses : BaseUserControl {

    public string SelectedValue {
        get { return ddlHotelClass.SelectedValue; }
        set { ddlHotelClass.SelectedValue = value; }
    }

    public string SelectedText {
        get { return ddlHotelClass.Text; }
        set { ddlHotelClass.Text = value; }
    }

    public ListItem SelectedItem {
        get { return ddlHotelClass.SelectedItem; }
    }

    public ListItemCollection Items {
        get { return ddlHotelClass.Items; }
    }

    protected void Page_Load(object sender, EventArgs e) {
        if (!IsPostBack) {
            
            //Hotel Sýnýflarýn Yükle
            LoadHotelClasses();

        }
    }

    private void LoadHotelClasses() {
        CARETTA.COM.DDLHelper.BindDDL(ref ddlHotelClass, this.CachedHotelClasses, "Title", "HotelClassID", "", "All", "%");
    }
}
