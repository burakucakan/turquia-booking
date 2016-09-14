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

public partial class userControls_PriceLists_uctRoomPriceListDef : BaseUserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            BindGrid();
            pnlCustomers.Visible = false;
        }
    }

    

    public int PriceListID
    {
        get { return ViewState["PL"] == null ? 0 : Convert.ToInt32(ViewState["PL"]); }
        set { ViewState.Add("PL",value); }
    }
	

    void BindGrid()
    {
        DataTable dt;
        DataRow dr;
        dt = HOTOMOTO.APEX.RoomPriceLists.GetAllRoomPriceListsDataSet().Tables[0];
        dr = dt.NewRow();

        dr["RoomPriceListID"] = "0";
        dr["PriceListName"] = "";
        dr["isActive"] = false;
        dt.Rows.Add(dr);

        GridView1.DataSource = dt;
        GridView1.DataBind();

        foreach (GridViewRow gvRow in GridView1.Rows)
        {
            ((Button)gvRow.FindControl("btnActivate")).Visible = true;
            ((Button)gvRow.FindControl("btnUpdate")).Visible = true;
            ((Button)gvRow.FindControl("btnCustomers")).Visible = true;
            ((Button)gvRow.FindControl("btnAddList")).Visible = false;
        }

        ((Button)GridView1.Rows[GridView1.Rows.Count - 1].FindControl("btnActivate")).Visible = false;
        ((Button)GridView1.Rows[GridView1.Rows.Count - 1].FindControl("btnUpdate")).Visible = false;
        ((Button)GridView1.Rows[GridView1.Rows.Count - 1].FindControl("btnCustomers")).Visible = false;
        ((Button)GridView1.Rows[GridView1.Rows.Count - 1].FindControl("btnAddList")).Visible = true;

    }

    protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        string strName;
        int intID;
        HOTOMOTO.APEX.RoomPriceLists objRPL;

        if (e.CommandName == "addList")
        {
            strName = ((TextBox)GridView1.Rows[GridView1.Rows.Count - 1].FindControl("txtPLN")).Text;
            objRPL = new HOTOMOTO.APEX.RoomPriceLists();
            objRPL.CreateDate = DateTime.Now;
            objRPL.CreatedBy = this.SessRoot.UserID;
            objRPL.isActive = false;
            objRPL.isBasePrice = false;
            objRPL.ModifiedBy = this.SessRoot.UserID;
            objRPL.ModifyDate = DateTime.Now;
            objRPL.PriceListName = strName;
            objRPL.Save();
            BindGrid();
            pnlCustomers.Visible = false;
        }
        else if (e.CommandName == "activate")
        {
            //intID = ((Label)GridView1.Rows[GridView1.Rows.Count - 1].FindControl("lblRPLID")).Text;
            intID = Convert.ToInt32(e.CommandArgument);
            objRPL = new HOTOMOTO.APEX.RoomPriceLists();
            objRPL.Load(intID);
            objRPL.isActive = true;
            objRPL.ModifyDate = DateTime.Now;
            objRPL.ModifiedBy = this.SessRoot.UserID;
            objRPL.Save();
            BindGrid();
            pnlCustomers.Visible = false;
        }
        else if (e.CommandName == "deActivate")
        {
            //intID = ((Label)GridView1.Rows[GridView1.Rows.Count - 1].FindControl("lblRPLID")).Text;
            intID = Convert.ToInt32(e.CommandArgument);
            objRPL = new HOTOMOTO.APEX.RoomPriceLists();
            objRPL.Load(intID);
            objRPL.isActive = false;
            objRPL.ModifyDate = DateTime.Now;
            objRPL.ModifiedBy = this.SessRoot.UserID;
            objRPL.Save();
            BindGrid();
            pnlCustomers.Visible = false;
        }
        else if (e.CommandName == "updateName")
        {
            intID = Convert.ToInt32(e.CommandArgument);
            strName = ((TextBox)((Button)(e.CommandSource)).NamingContainer.FindControl("txtPLN")).Text;
            objRPL = new HOTOMOTO.APEX.RoomPriceLists();
            objRPL.Load(intID);
            objRPL.PriceListName = strName;
            objRPL.ModifyDate = DateTime.Now;
            objRPL.ModifiedBy = this.SessRoot.UserID;
            objRPL.Save();
            BindGrid();
            pnlCustomers.Visible = false;
        }
        else if (e.CommandName == "listCustomers")
        {
            lblPriceListName.Text = ((TextBox)((Button)(e.CommandSource)).NamingContainer.FindControl("txtPLN")).Text;
            this.PriceListID = Convert.ToInt32(e.CommandArgument);
            BindlbLCustomers();
            BindlbRCustomers();
            pnlCustomers.Visible = true;

            
        }
    }

    void BindlbLCustomers()
    {

        DataView dv;
        dv = HOTOMOTO.APEX.Customers.GetAllCustomersDataSet().Tables[0].DefaultView;
        dv.RowFilter = "CompanyName LIKE '%" + txtLCustName.Text + "%'";
        lbLCusts.DataSource = dv;
        lbLCusts.DataTextField = "CompanyName";
        lbLCusts.DataValueField = "CustomerID";
        lbLCusts.DataBind();
    }

    void BindlbRCustomers()
    {

        DataView dv;
        dv = HOTOMOTO.APEX.Custom.SPExec_Room.GetRoomPriceListCustomers(this.PriceListID).DefaultView;
        dv.RowFilter = "CompanyName LIKE '%" + txtRCustName.Text + "%'";
        lbRCusts.DataSource = dv;
        lbRCusts.DataTextField = "CompanyName";
        lbRCusts.DataValueField = "RowID";
        lbRCusts.DataBind();
    }

    protected void btnLCustSearch_Click(object sender, EventArgs e)
    {
        BindlbLCustomers();
    }
    protected void btnRCustSearch_Click(object sender, EventArgs e)
    {
        BindlbRCustomers();
    }
    protected void btnAdd_Click(object sender, EventArgs e)
    {
        HOTOMOTO.APEX.RoomPriceListCustomers objRPLC;

        foreach (ListItem liItem in lbLCusts.Items)
        {
            if (liItem.Selected)
            {
                objRPLC = new HOTOMOTO.APEX.RoomPriceListCustomers();
                objRPLC.CustomerID = Convert.ToInt32(liItem.Value);
                objRPLC.RoomPriceListID = this.PriceListID;
                objRPLC.Save();
            }
        }
        BindlbRCustomers();
    }
    protected void btnRem_Click(object sender, EventArgs e)
    {
        HOTOMOTO.APEX.RoomPriceListCustomers objRPLC;

        foreach (ListItem liItem in lbRCusts.Items)
        {
            if (liItem.Selected)
            {
                objRPLC = new HOTOMOTO.APEX.RoomPriceListCustomers();
                objRPLC.Load(Convert.ToInt32(liItem.Value));
                objRPLC.RowID = Convert.ToInt32(liItem.Value);
                objRPLC.Delete();
            }
        }
        BindlbRCustomers();
    }
}
