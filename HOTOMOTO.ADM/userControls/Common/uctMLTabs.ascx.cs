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
using AjaxControlToolkit;

public partial class userControls_Common_uctMLTabs : System.Web.UI.UserControl
{

    private ArrayList m_ControlInfos;

    public ArrayList ControlInfos
    {
        get {
            if (m_ControlInfos == null)
            {
                m_ControlInfos = new ArrayList();
            }
            return m_ControlInfos; 
        }
    }

    private string lblCSSClass = "label";
    private string txtCSSClass = "textBox";


    public string MLValidationGroup
    {
        get { return ViewState["MLVG"] == null ? "" : ViewState["MLVG"].ToString(); }
        set { ViewState.Add("MLVG",value); }
    }

    public void ClearControls()
    {
        ViewState.Add("CIN", new ArrayList());
    }

    private class ControlInfo
    {
        private string m_labelText;
        private string m_code;
        private bool m_isReqired;
        private bool m_isMultiline;
        private int m_Width;
        private int m_Height;

        public string Code
        {
            get { return m_code; }
            set { m_code = value; }
        }

        public string LabelText
        {
            get { return m_labelText; }
            set { m_labelText = value; }
        }

        public bool IsReqired
        {
            get { return m_isReqired; }
            set { m_isReqired = value; }
        }

        public bool IsMultiline
        {
            get { return m_isMultiline; }
            set { m_isMultiline = value; }
        }

        public int Width
        {
            get { return m_Width; }
            set { m_Width = value; }
        }

        public int Height
        {
            get { return m_Height; }
            set { m_Height = value; }
        }
    }

    public void AddTextArea(string code, string labelText, bool isRequired, bool isMultiline, int width, int height)
    {
        ControlInfo objCI = new ControlInfo();
        objCI.Height= height;
        objCI.IsMultiline=isMultiline;
        objCI.IsReqired = isRequired;
        objCI.LabelText = labelText;
        objCI.Width = width;
        objCI.Code = code;
        this.ControlInfos.Add(objCI);
    }

    public string GetValue(int LanguageID, string Code)
    {
        int i;
        for (i = 0; i < tabLanguages.Tabs.Count; i++)
        {
            if (tabLanguages.Tabs[i].FindControl("txt" + Code + LanguageID.ToString()) != null)
            {
                return ((TextBox)tabLanguages.Tabs[i].FindControl("txt" + Code + LanguageID.ToString())).Text;
            }
        }

        return "";
    }

    public void SetValue(int LanguageID, string Code, string Value)
    {
        int i;
        for (i = 0; i < tabLanguages.Tabs.Count; i++)
        {
            if (tabLanguages.Tabs[i].FindControl("txt" + Code + LanguageID.ToString()) != null)
            {
                ((TextBox)tabLanguages.Tabs[i].FindControl("txt" + Code + LanguageID.ToString())).Text = Value;
            }
        }
    }


    void Page_Init(object sender, EventArgs e)
    {
        //GenerateTabs();
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        //GenerateTabs();
    }

    public void GenerateTabs()
    {
        if (tabLanguages.Tabs.Count != 0)
        {
            return;
        }

        Hashtable htLanguages = HOTOMOTO.APEX.Languages.GetAllLanguages();
        int TabIndex = 0;
        foreach (HOTOMOTO.APEX.Languages Language in htLanguages.Values)
        {
            if (Language.isActive == true)
            {

                TabPanel tab = new TabPanel();
                tab.ID = TabIndex.ToString();
                tab.HeaderText = Language.Language;
                Table tbl = new Table();
                tbl.Width = Unit.Percentage(100);
                foreach (ControlInfo ci in this.ControlInfos)
                {
                    TableRow tr = new TableRow();
                    TableCell tc = new TableCell();
                    Label lbl = new Label();
                    lbl.CssClass = lblCSSClass;
                    TextBox txt = new TextBox();
                    txt.CssClass = txtCSSClass;
                    if (ci.IsMultiline)
                    {
                        txt.TextMode = TextBoxMode.MultiLine;
                    }

                    lbl.Text = ci.LabelText + " :";
                    lbl.ID = "lbl" + ci.Code + Language.LanguageID.ToString();
                    tc.Controls.Add(lbl);
                    tr.Cells.Add(tc);

                    txt.ID = "txt" + ci.Code + Language.LanguageID.ToString();

                    if (ci.Width != 0)
                    {
                        txt.Width = Unit.Pixel(ci.Width);
                    }

                    if (ci.Height != 0)
                    {
                        txt.Height = Unit.Pixel(ci.Height);
                    }

                    tc = new TableCell();
                    tc.Controls.Add(txt);
                    tr.Cells.Add(tc);

                    if (ci.IsReqired)
                    {
                        RequiredFieldValidator reqfv = new RequiredFieldValidator();
                        reqfv.ErrorMessage = "*";
                        reqfv.ValidationGroup = MLValidationGroup;
                        reqfv.SetFocusOnError = true;
                        reqfv.ControlToValidate = txt.ID;
                        reqfv.ID = "reqfv" + ci.Code + Language.LanguageID.ToString();
                        tc = new TableCell();
                        tc.Controls.Add(reqfv);
                        tr.Cells.Add(tc);
                    }

                    tbl.Rows.Add(tr);

                }

                tab.Controls.Add(tbl);
                tabLanguages.Tabs.Add(tab);
                TabIndex++;
            }
            if (tabLanguages.Tabs.Count > 0)
                tabLanguages.ActiveTabIndex = 0;
        }
    }

}
