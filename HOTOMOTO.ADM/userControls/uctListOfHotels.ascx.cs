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

public partial class UserControls_uctListOfHotels : BaseUserControl {

    DataView hotelsData;

    protected void Page_Load(object sender, EventArgs e) {
        hotelsData = HOTOMOTO.BUS.Hotels.GetHotelsWithDetails(SessRoot.LanguageID).DefaultView;

        if(!IsPostBack) {
            ViewState["CurrentPage"] = 1;
        }

        if(UctSubMenu1.SearchText.Length > 0) {
            hotelsData.RowFilter = "HotelName LIKE '%" + UctSubMenu1.SearchText + "%'";
        }
    }

    protected void Page_PreRender(object sender, EventArgs e) {
        BindData(hotelsData);
    }

    protected void BindData(DataView dv) {
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

        rptHotels.DataSource = objPagedSource;
        rptHotels.DataBind();
    }

    private int CurrentPage {
        get { return ViewState["CurrentPage"] == null ? 0 : int.Parse(ViewState["CurrentPage"].ToString()); }
        set { ViewState["CurrentPage"] = value; }
    }

    protected void lbtPrevious_Click(object sender, EventArgs e) {
        this.CurrentPage -= 1;
    }
    protected void lbtNext_Click(object sender, EventArgs e) {
        this.CurrentPage += 1;
    }
    protected void ddlPageNumber_SelectedIndexChanged(object sender, EventArgs e) {
        this.CurrentPage = int.Parse(ddlPageNumber.SelectedValue);
    }
    protected void ddlPageLimit_SelectedIndexChanged(object sender, EventArgs e) {
        this.SessRoot.PageItemAmount = int.Parse(ddlPageLimit.SelectedValue);
    }
}