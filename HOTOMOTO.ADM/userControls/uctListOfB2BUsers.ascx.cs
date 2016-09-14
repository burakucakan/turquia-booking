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

public partial class userControls_uctListOfB2BUsers : BaseUserControl
{

    DataView countriesData;

    protected void Page_Init(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            UctSubMenu1.AddLink("B2BUser.aspx", "B2B Kullanýcýsý Ekle");
        }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        countriesData = HOTOMOTO.BUS.UserManagement.GetUserList(this.SessRoot.LanguageID, 1).DefaultView;

        if (!IsPostBack)
        {
            ViewState["CurrentPage"] = 1;
        }

        if (UctSubMenu1.SearchText.Length > 0)
        {
            countriesData.RowFilter = "Fullname LIKE '" + UctSubMenu1.SearchText + "%'";
        }
    }

    protected void Page_PreRender(object sender, EventArgs e)
    {
        BindData(countriesData);
    }

    protected void BindData(DataView dv)
    {
        int PageLimit = this.SessRoot.PageItemAmount;

        PagedDataSource objPagedSource = new PagedDataSource();
        objPagedSource.DataSource = dv;
        objPagedSource.AllowPaging = true;
        objPagedSource.PageSize = PageLimit;
        objPagedSource.CurrentPageIndex = CurrentPage - 1;

        lbtPrevious.Visible = !objPagedSource.IsFirstPage;
        lbtNext.Visible = !objPagedSource.IsLastPage;
        lblPageCount.Text = objPagedSource.PageCount.ToString();
        CARETTA.COM.DDLHelper.LoadNumberDDL(ref this.ddlPageNumber, objPagedSource.PageCount);

        ddlPageLimit.SelectedValue = PageLimit.ToString();
        ddlPageNumber.SelectedValue = this.CurrentPage.ToString();

        rptUsers.DataSource = objPagedSource;
        rptUsers.DataBind();
    }

    private int CurrentPage
    {
        get { return ViewState["CurrentPage"] == null ? 0 : int.Parse(ViewState["CurrentPage"].ToString()); }
        set { ViewState["CurrentPage"] = value; }
    }

    protected void lbtPrevious_Click(object sender, EventArgs e)
    {
        this.CurrentPage -= 1;
    }
    protected void lbtNext_Click(object sender, EventArgs e)
    {
        this.CurrentPage += 1;
    }
    protected void ddlPageNumber_SelectedIndexChanged(object sender, EventArgs e)
    {
        this.CurrentPage = int.Parse(ddlPageNumber.SelectedValue);
    }
    protected void ddlPageLimit_SelectedIndexChanged(object sender, EventArgs e)
    {
        this.SessRoot.PageItemAmount = int.Parse(ddlPageLimit.SelectedValue);
    }
}
