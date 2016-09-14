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

public partial class userControls_uctBulletinQuickAdd : BaseUserControl {
    
    ArrayList messages;
    int nextMessageID;

    protected void Page_Load(object sender, EventArgs e) {
        if(!Page.IsPostBack) {
            messages = new ArrayList();
            nextMessageID = 1;
            ViewState.Add("messages", messages);
            ViewState.Add("nextMessageID", nextMessageID);
        } else {
            messages = (ArrayList)ViewState["messages"];
            nextMessageID = int.Parse(ViewState["nextMessageID"].ToString());
        }
    }

    protected void btnYayinla_Click(object sender, ImageClickEventArgs e) {
        messages.Add(new Message(nextMessageID++, txtBulten.Text, DateTime.Now));

        ViewState["nextMessageID"] = nextMessageID;

        rptBulten.DataSource = messages;
        rptBulten.DataBind();
    }
}
