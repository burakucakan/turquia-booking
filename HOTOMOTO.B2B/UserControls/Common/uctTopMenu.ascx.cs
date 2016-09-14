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

public partial class UserControls_Common_uctTopMenu : BaseUserControl {

    protected void Page_Load(object sender, EventArgs e) {
        if (!IsPostBack) {
            LoadMenu();
        }
    }

    private void LoadMenu() {

        DataTable dtPermsList = this.SessRoot.UserPermissionList.Copy();

        DataTable dtMenu = new DataTable();
        dtMenu.Columns.AddRange(
            new DataColumn[] {
            new DataColumn("UserCommandID"), new DataColumn("Title"), new DataColumn("Link") }
            );

        DataRow drMenu;

        foreach (DataRow dr in dtPermsList.Rows) {
            if ((!Convert.ToBoolean(dr["isHidden"])) && (Convert.ToInt16(dr["ParentID"]) == 0)) {
                drMenu = dtMenu.NewRow();
                drMenu["UserCommandID"] = dr["UserCommandID"];
                drMenu["Title"] = dr["Title"];
                drMenu["Link"] = dr["Value"];
                dtMenu.Rows.Add(drMenu);
            }
        }

        rptTopMenu.DataSource = dtMenu;
        rptTopMenu.DataBind();

    }

}
