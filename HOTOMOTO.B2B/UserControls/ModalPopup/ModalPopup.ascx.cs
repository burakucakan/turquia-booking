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

public partial class UserControls_ModalPopup_ModalPopup : System.Web.UI.UserControl
{
    string IconPath = "~/UserControls/ModalPopup/Images/";
    public enum Icons
    {
        alert,
        error,
        error2,
        info,
        info2,
        reload,
        stop,
        stop2
    }

    protected void Page_Load(object sender, EventArgs e) {

    }
    
    public string TargetControlID
    {
        set { ModalPopupExtender.TargetControlID = value; }
    }

    public Icons Icon
    {
        set { imgIcon.ImageUrl = IconPath + value.ToString() + ".png"; }
    }

    public string Title
    { 
        set { lblTitle.Text = value; }
    }

    public string Message
    {
        set { lblText.Text = value; }
    }

    public void Show(Icons Icon, string Title, string Message) {
        Show(Icon, Title, Message, IsPostBack);
    }

    public void Show(Icons Icon, string Title, string Message, bool Post)
    {
        this.Visible = true;
        imgIcon.ImageUrl = IconPath + Icon.ToString() + ".png";
        lblTitle.Text = Title;
        dvMessage.InnerHtml = Message;
        FormDeactive(Post);
        ModalPopupExtender.Show();
    }

    private void FormDeactive(bool AsyncPostBack) {
        if (AsyncPostBack) { 
            ScriptManager.RegisterClientScriptBlock(pnlModal, pnlModal.GetType(), "DeActive", "DeActive()", true); 
        } else { 
            dvScript.InnerHtml = "<script>DeActive()</script>"; 
        }
    }

}
