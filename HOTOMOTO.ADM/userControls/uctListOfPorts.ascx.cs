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

public partial class userControls_uctListOfPorts : BaseUserControl 
{
    private int CurrentPage
    {
        get { return ViewState["CurrentPage"] == null ? 0 : int.Parse(ViewState["CurrentPage"].ToString()); }
        set { ViewState["CurrentPage"] = value; }
    }

    DataView dvData;

    protected void Page_Init(object sender, EventArgs e)
    {
        UctSubMenu1.AddLink("Port.aspx", "Liman veya Havalimaný Ekle");
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        dvData = HOTOMOTO.BUS.Transfer.GetPortDetails(SessRoot.LanguageID, 0).DefaultView;

        if (!IsPostBack)
        {
            ViewState["CurrentPage"] = 1;
        }

        if (UctSubMenu1.SearchText.Length > 0)
        {
            dvData.RowFilter = "Title LIKE '%" + UctSubMenu1.SearchText + "%'";
        }
    }

    protected void Page_PreRender(object sender, EventArgs e)
    {
        BindData(dvData);
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

        rpt1.DataSource = objPagedSource;
        rpt1.DataBind();
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
