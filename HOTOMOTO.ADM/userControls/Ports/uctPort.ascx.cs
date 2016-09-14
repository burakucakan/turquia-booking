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

public partial class userControls_Ports_uctPort : BaseUserControl 
{
    private string strValidationGroup = "PortValidation";

    public int PortID
    {
        get
        {
            if (Request.QueryString["portid"] != null)
            {
                ViewState.Add("PID", Convert.ToInt32(Request.QueryString["portid"]));
            }
            return ViewState["PID"] == null ? 0 : Convert.ToInt32(ViewState["PID"]);
        }
        set { ViewState.Add("PID", value); }
    }

    protected void Page_Init(object sender, EventArgs e)
    {
        UctMLTabs1.MLValidationGroup = strValidationGroup;
        UctMLTabs1.ClearControls();
        UctMLTabs1.AddTextArea("PN", "Adý", true, false, 0, 0);
        UctMLTabs1.AddTextArea("PD", "Tarifi", true, true, 500, 100);
        UctMLTabs1.GenerateTabs();
        UctAddress1.isPortAddress = true;
        
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Request.QueryString["portid"] != null)
            {
                this.PortID = Convert.ToInt32(Request.QueryString["portid"]);
            }

            LoadAll();

        }
    }
    protected void btnPublish_Click(object sender, ImageClickEventArgs e)
    {
        SaveAll();
    }

    public void LoadAll()
    {
        if (this.PortID != 0)
        {
            HOTOMOTO.APEX.Ports objPort;

            objPort = new HOTOMOTO.APEX.Ports();
            objPort.Load(this.PortID);

            cbIsActive.Checked = objPort.isActive;
            txtMultiplier.Text = objPort.Multipier.ToString();

            Hashtable htLanguages = HOTOMOTO.APEX.Languages.GetAllLanguages();
            foreach (HOTOMOTO.APEX.Languages Language in htLanguages.Values)
            {
                UctMLTabs1.SetValue(Language.LanguageID, "PN", objPort.GetTitle(Language.LanguageID));
                UctMLTabs1.SetValue(Language.LanguageID, "PD", objPort.GetDescription(Language.LanguageID));
            }

        }
    }

    public void SaveAll()
    {
        HOTOMOTO.APEX.Ports  objPort;

        objPort = new HOTOMOTO.APEX.Ports();
        if (this.PortID != 0)
        {
            objPort.Load(this.PortID);
        }
        objPort.isActive  = cbIsActive.Checked;
        objPort.Multipier = Convert.ToInt32(txtMultiplier.Text);


        if (this.PortID == 0)
        {
            objPort.CreateDate = DateTime.Now;
            objPort.CreatedBy = SessRoot.UserID;
        }

        Hashtable htLanguages = HOTOMOTO.APEX.Languages.GetAllLanguages();
        foreach (HOTOMOTO.APEX.Languages Language in htLanguages.Values)
        {
            objPort.SetDescription(UctMLTabs1.GetValue(Language.LanguageID, "PD"), Language.LanguageID);
            objPort.SetTitle(UctMLTabs1.GetValue(Language.LanguageID, "PN"), Language.LanguageID);
        }

        objPort.ModifiedBy = this.SessRoot.UserID;
        objPort.ModifyDate = DateTime.Now;

        if (this.PortID == 0)
        {
            this.PortID = objPort.Save();
        }
        else
        {
            objPort.PortID = this.PortID;
            objPort.Save();
        }

        UctAddress1.PortID = this.PortID;
        UctAddress1.SavePortAddress();

        Response.Redirect("~/Ports.aspx");
    }
}
