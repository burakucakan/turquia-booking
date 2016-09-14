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

public partial class userControls_Transfer_uctTransferPrices : BaseUserControl 
{

    protected void Page_Init(object sender, EventArgs e)
    {
        //UctImageUpload1.FileUploaded += new userControls_Common_uctImageUpload.FileUploadedDelegate(UctImageUpload1_FileUploaded);
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            CARETTA.COM.DDLHelper.BindDDL(ref ddlTPL, HOTOMOTO.APEX.TransferPriceLists.GetAllTransferPriceListsDataSet().Tables[0], "Title", "TransferPriceListID", "");
            BindGrid();
        }
    }

    void BindGrid()
    {
        DataTable dt;
        DataRow dr;
        dt = HOTOMOTO.BUS.Transfer.GetTransferPriceListPrices(Convert.ToInt32(ddlTPL.SelectedValue));
        dr = dt.NewRow();
        dr["TransferPriceListPriceID"] = "0";
        dr["GuestCapacity"] = "0";
        dr["RegularPriceEUR"] = "0";
        dr["RegularPriceUSD"] = "0";
        dr["PrivatePriceEUR"] = "0";
        dr["PrivatePriceUSD"] = "0";
        dr["GuidancePriceEUR"] = "0";
        dr["GuidancePriceUSD"] = "0";
        dt.Rows.Add(dr);
        GridView1.DataSource = dt;
        GridView1.DataBind();
        foreach (GridViewRow gvRow in GridView1.Rows)
        {
            ((LinkButton)gvRow.FindControl("lbAdd")).Visible = false;
            ((CheckBox)gvRow.FindControl("chkD")).Visible = true;
            
        }
        ((LinkButton)GridView1.Rows[dt.Rows.Count - 1].FindControl("lbAdd")).Visible = true;
        ((CheckBox)GridView1.Rows[dt.Rows.Count - 1].FindControl("chkD")).Visible = false;
        ((LinkButton)GridView1.Rows[dt.Rows.Count - 1].FindControl("lbAdd")).CommandArgument = Convert.ToString(dt.Rows.Count - 1);

    }

   protected void AddPrice_Click(object sender, EventArgs e)
    {
        //throw new Exception("The method or operation is not implemented.");
        
    }

    protected void ddlTPL_SelectedIndexChanged(object sender, EventArgs e)
    {
        BindGrid();
    }
    protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        int intGuestCapacity = 0;
        double dblRegularPriceEUR = 0;
		double dblRegularPriceUSD = 0;
		double dblPrivatePriceEUR = 0;
		double dblPrivatePriceUSD = 0;
		double dblGuidancePriceEUR = 0;
        double dblGuidancePriceUSD = 0;
        int intIndex = 0;
        int intTransferPriceListID = 0;

        HOTOMOTO.APEX.TransferPriceListPrices objTPLP;
        HOTOMOTO.APEX.Prices objP;

        intIndex = Convert.ToInt32(e.CommandArgument);
        intTransferPriceListID = Convert.ToInt32(ddlTPL.SelectedValue);

        if (e.CommandName == "AddPrice")
        {

            intGuestCapacity = Convert.ToInt32(((TextBox)GridView1.Rows[intIndex].FindControl("txtC")).Text);
            dblRegularPriceEUR = Convert.ToDouble(((TextBox)GridView1.Rows[intIndex].FindControl("txtRE")).Text);
            dblRegularPriceUSD = Convert.ToDouble(((TextBox)GridView1.Rows[intIndex].FindControl("txtRU")).Text);
            dblPrivatePriceEUR = Convert.ToDouble(((TextBox)GridView1.Rows[intIndex].FindControl("txtPE")).Text);
            dblPrivatePriceUSD = Convert.ToDouble(((TextBox)GridView1.Rows[intIndex].FindControl("txtPU")).Text);
            dblGuidancePriceEUR = Convert.ToDouble(((TextBox)GridView1.Rows[intIndex].FindControl("txtGE")).Text);
            dblGuidancePriceUSD = Convert.ToDouble(((TextBox)GridView1.Rows[intIndex].FindControl("txtGU")).Text);
            objTPLP = new HOTOMOTO.APEX.TransferPriceListPrices();
            objTPLP.GuestCapacity = intGuestCapacity;
            
            if ((dblRegularPriceEUR == 0) && (dblRegularPriceUSD == 0))
            {
                objTPLP.RegularPriceID = 0;
            }
            else
            {
                objP = new HOTOMOTO.APEX.Prices();
                objP.EURPrice = dblRegularPriceEUR;
                objP.USDPrice = dblRegularPriceUSD;
                objTPLP.RegularPriceID = objP.Save();
            }

            if ((dblPrivatePriceEUR == 0) && (dblPrivatePriceUSD == 0))
            {
                objTPLP.PrivatePriceID = 0;
            }
            else
            {
                objP = new HOTOMOTO.APEX.Prices();
                objP.EURPrice = dblPrivatePriceEUR;
                objP.USDPrice = dblPrivatePriceUSD;
                objTPLP.PrivatePriceID = objP.Save();
            }

            if ((dblGuidancePriceEUR == 0) && (dblGuidancePriceUSD == 0))
            {
                objTPLP.GuidancePriceID = 0;
            }
            else
            {
                objP = new HOTOMOTO.APEX.Prices();
                objP.EURPrice = dblGuidancePriceEUR;
                objP.USDPrice = dblGuidancePriceUSD;
                objTPLP.GuidancePriceID = objP.Save();
            }

            objTPLP.TransferPriceListID = intTransferPriceListID;
            objTPLP.Save();
            BindGrid();
        }
    }
    protected void btnUpdate_Click(object sender, EventArgs e)
    {

        int intGuestCapacity = 0;
        double dblRegularPriceEUR = 0;
        double dblRegularPriceUSD = 0;
        double dblPrivatePriceEUR = 0;
        double dblPrivatePriceUSD = 0;
        double dblGuidancePriceEUR = 0;
        double dblGuidancePriceUSD = 0;

        int intTransferPriceListID = 0;
        int intTransferPriceListPriceID = 0;

        HOTOMOTO.APEX.TransferPriceListPrices objTPLP;
        HOTOMOTO.APEX.Prices objP;

        intTransferPriceListID = Convert.ToInt32(ddlTPL.SelectedValue);

        foreach (GridViewRow gvRow in GridView1.Rows)
        {
            if (gvRow.RowIndex != GridView1.Rows.Count - 1)
            {
                intTransferPriceListPriceID = Convert.ToInt32(((Label)gvRow.FindControl("lblTPLPID")).Text);
                intGuestCapacity = Convert.ToInt32(((TextBox)gvRow.FindControl("txtC")).Text);
                dblRegularPriceEUR = Convert.ToDouble(((TextBox)gvRow.FindControl("txtRE")).Text);
                dblRegularPriceUSD = Convert.ToDouble(((TextBox)gvRow.FindControl("txtRU")).Text);
                dblPrivatePriceEUR = Convert.ToDouble(((TextBox)gvRow.FindControl("txtPE")).Text);
                dblPrivatePriceUSD = Convert.ToDouble(((TextBox)gvRow.FindControl("txtPU")).Text);
                dblGuidancePriceEUR = Convert.ToDouble(((TextBox)gvRow.FindControl("txtGE")).Text);
                dblGuidancePriceUSD = Convert.ToDouble(((TextBox)gvRow.FindControl("txtGU")).Text);

                objTPLP = new HOTOMOTO.APEX.TransferPriceListPrices();
                objTPLP.Load(intTransferPriceListPriceID);
                objTPLP.Delete();

                objTPLP = new HOTOMOTO.APEX.TransferPriceListPrices();
                objTPLP.GuestCapacity = intGuestCapacity;

                if ((dblRegularPriceEUR == 0) && (dblRegularPriceUSD == 0))
                {
                    objTPLP.RegularPriceID = 0;
                }
                else
                {
                    objP = new HOTOMOTO.APEX.Prices();
                    objP.EURPrice = dblRegularPriceEUR;
                    objP.USDPrice = dblRegularPriceUSD;
                    objTPLP.RegularPriceID = objP.Save();
                }

                if ((dblPrivatePriceEUR == 0) && (dblPrivatePriceUSD == 0))
                {
                    objTPLP.PrivatePriceID = 0;
                }
                else
                {
                    objP = new HOTOMOTO.APEX.Prices();
                    objP.EURPrice = dblPrivatePriceEUR;
                    objP.USDPrice = dblPrivatePriceUSD;
                    objTPLP.PrivatePriceID = objP.Save();
                }

                if ((dblGuidancePriceEUR == 0) && (dblGuidancePriceUSD == 0))
                {
                    objTPLP.GuidancePriceID = 0;
                }
                else
                {
                    objP = new HOTOMOTO.APEX.Prices();
                    objP.EURPrice = dblGuidancePriceEUR;
                    objP.USDPrice = dblGuidancePriceUSD;
                    objTPLP.GuidancePriceID = objP.Save();
                }

                objTPLP.TransferPriceListID = intTransferPriceListID;
                objTPLP.Save();
            }
        }
        BindGrid();
    }
    protected void btnDeleteSelected_Click(object sender, EventArgs e)
    {
        int intTransferPriceListPriceID = 0;

        HOTOMOTO.APEX.TransferPriceListPrices objTPLP;

        foreach (GridViewRow gvRow in GridView1.Rows)
        {
            if (gvRow.RowIndex != GridView1.Rows.Count - 1)
            {
                if (((CheckBox)gvRow.FindControl("chkD")).Checked)
                {
                    intTransferPriceListPriceID = Convert.ToInt32(((Label)gvRow.FindControl("lblTPLPID")).Text);
                    objTPLP = new HOTOMOTO.APEX.TransferPriceListPrices();
                    objTPLP.Load(intTransferPriceListPriceID);
                    objTPLP.Delete();

                }
            }
        }

        BindGrid();

    }
}
