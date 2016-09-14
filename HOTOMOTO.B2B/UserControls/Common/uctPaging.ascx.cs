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

public partial class UserControls_Common_uctPaging : BaseUserControl
{
    private string SessionPageSize = "Sess_Pg_Sz";
    private string QsPageSize = "Pg_Sz__";
    private string QsPageNo = "Pg_No__";
    private string ConfigPageSizeName = "DefaultPageSize";
    private int PageSizeMulti = 5; // Maximum Kaç Katý Görünsün 
    private int AnyPageSize = 10;

    public int ConfigPageSize
    {
        get
        {
            if (ViewState["ConfigPageSize"] == null)
            {
                if (ConfigurationManager.AppSettings[ConfigPageSizeName] == null) { return AnyPageSize; }
                else { return int.Parse(ConfigurationManager.AppSettings[ConfigPageSizeName]); }
            }
            else { return int.Parse(ViewState["ConfigPageSize"].ToString()); }
        }
        set { ViewState["ConfigPageSize"] = value; }
    }

    public void GeneratePager(ref DataTable DataSource, ref Repeater BindObject, int ConfigPageSize) {
        this.ConfigPageSize = ConfigPageSize;
        GeneratePager(ref DataSource, ref BindObject);
    }

    public void GeneratePager(ref DataTable DataSource, ref Repeater BindObject)
    {
        this.Visible = true;

        int PageSize = 0;
        int CurrentPageIndex = 0;
        int RecordCount = DataSource.Rows.Count;
        int ConfigPageSize = this.ConfigPageSize;

        if (CARETTA.COM.Util.IsNumeric(Request.QueryString[this.QsPageSize]))
        {
            Session[this.SessionPageSize] = int.Parse(Request.QueryString[this.QsPageSize]);
        }

        int MaxPageNumber = Convert.ToInt32(Math.Ceiling((decimal)RecordCount / (decimal)ConfigPageSize));

        if (!IsPostBack)
        {
            lblRecordCount.Text = RecordCount.ToString();

            CARETTA.COM.DDLHelper.LoadNumberDDL(ref ddlPageSize, ConfigPageSize * PageSizeMulti, ConfigPageSize, ConfigPageSize);
            ddlPageSize.Attributes.Add("onchange", "ChangePage(this.options[this.selectedIndex].value, '" + this.QsPageSize +"')");
        }

        if (Session[this.SessionPageSize] != null)
        {
            int qSessionPageSize = Convert.ToInt32(Session[this.SessionPageSize]);
            if ((qSessionPageSize > 0) && (qSessionPageSize <= ConfigPageSize * PageSizeMulti))
            {
                PageSize = Convert.ToInt32(Session[this.SessionPageSize]);
                ddlPageSize.SelectedValue = PageSize.ToString();
                MaxPageNumber = Convert.ToInt32(Math.Ceiling((decimal)RecordCount / (decimal)PageSize));
            } else { PageSize = ConfigPageSize; }
        }
        else { PageSize = ConfigPageSize; }

        CARETTA.COM.DDLHelper.LoadNumberDDL(ref ddlPageNumber, MaxPageNumber, 1, 1);
        ddlPageNumber.Attributes.Add("onchange", "ChangePage(this.options[this.selectedIndex].value, '" + this.QsPageNo + "')");

        if (CARETTA.COM.Util.IsNumeric(Request.QueryString[this.QsPageNo]))
        {
            int qPage = int.Parse(Request.QueryString[this.QsPageNo]);
            if ((qPage > 0) && (qPage <= MaxPageNumber))
            {
                CurrentPageIndex = qPage - 1;
                ddlPageNumber.SelectedValue = qPage.ToString();
            }
        }

        if (int.Parse(ddlPageNumber.SelectedValue) > 1)
        {
            hlPrevious.Enabled = true;
            hlPrevious.NavigateUrl = "javascript: ChangePage('" + (int.Parse(ddlPageNumber.SelectedValue) - 1).ToString() + "', '" + this.QsPageNo + "')";
        }
        else { hlPrevious.Enabled = false; }

        if (int.Parse(ddlPageNumber.SelectedValue) + 1 <= MaxPageNumber)
        {
            hlNext.Enabled = true;
            hlNext.NavigateUrl = "javascript: ChangePage('" + (int.Parse(ddlPageNumber.SelectedValue) + 1).ToString() + "', '" + this.QsPageNo + "')";
        }
        else { hlNext.Enabled = false; }

        PagedDataSource pds = new PagedDataSource();
        pds.AllowPaging = true;
        pds.PageSize = PageSize;
        pds.DataSource = DataSource.DefaultView;
        pds.CurrentPageIndex = CurrentPageIndex;

        BindObject.DataSource = pds;
        BindObject.DataBind();
    }

}
