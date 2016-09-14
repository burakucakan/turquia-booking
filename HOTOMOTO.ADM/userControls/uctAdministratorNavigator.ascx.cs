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

public partial class userControls_uctAdministratorNavigator : BaseUserControl
{

    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void Page_PreRender(object sender, EventArgs e) {
        StringBuilder sb = new StringBuilder();
        string lastParentPlaceHolder = "#";
        foreach(DataRow dr in this.SessRoot.UserPermissionList.Rows) {
            //row index -> 0:UserCommandID, 1:Code, 2:Title, 3:Value, 4:isHidden, 5:ParentID, 6:ShowOrder

            if(((bool)dr[5]) == false && int.Parse(dr[4].ToString()) == 0) {
                sb.Replace(lastParentPlaceHolder, string.Empty);
                lastParentPlaceHolder = "[" + dr[1].ToString() + "]";
                sb.Append("<div class=\"stitle\"><strong>" + dr[2].ToString() + "</strong></div>");
                sb.Append("<div class=\"links\"><ul>" + lastParentPlaceHolder + "</ul></div>");
            } else if(((bool)dr[5]) == false && dr[1].ToString().Length == 2) {
                sb.Insert(sb.ToString().IndexOf(lastParentPlaceHolder), "<li><a href=\"" + dr[3].ToString() + "\">" + dr[2].ToString() + "</a></li>");
            }
        }
        sb.Replace(lastParentPlaceHolder, string.Empty);
        ltrMenuItems.Text = sb.ToString();
    }
}
