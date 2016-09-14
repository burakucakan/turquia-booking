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

public partial class userControls_uctMessage : BaseUserControl {
    
    protected void Page_Load(object sender, EventArgs e) {
        pnlMessage.CssClass = "b710";
    }

    protected void Page_Init(object sender, EventArgs e) {
        AddSubMenuItems();
    }

    protected void btnSearch_Click(object sender, ImageClickEventArgs e) {
        //
    }

    public string SearchText {
        get { return this.txtSearch.Text; }
        set { this.txtSearch.Text = value; }
    }

    public bool SearchPanelVisible {
        set { this.pnlSearch.Visible = value; }
    }

    private void AddSubMenuItems() {
        int currentItemID = -1;
        foreach(DataRow dr in this.SessRoot.UserPermissionList.Rows) {
            if(dr[3].ToString() == System.IO.Path.GetFileName(Request.Path).ToString())
                currentItemID = (int)dr[0];
        }
        foreach(DataRow dr in this.SessRoot.UserPermissionList.Rows) {
            if((bool)dr[5] == false && (int)dr[4] == currentItemID)
                AddLink(dr[3].ToString(), dr[2].ToString());
        }
    }

    public void AddLink(string Link, string Title) {
        ltrLinks.Text = "<span class\"hotlinks\">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<a href=\"" + Link + "\">" + Title + "</a></span>" + ltrLinks.Text;
    }
}