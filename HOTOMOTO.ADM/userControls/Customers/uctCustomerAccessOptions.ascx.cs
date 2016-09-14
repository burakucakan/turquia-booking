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

public partial class userControls_Customers_uctCustomerAccessOptions : BaseUserControl 
{
    public int CustomerID
    {
        get { return ((ViewState["CID"] == null) ? 0 : (int)ViewState["CID"]); }
        set { ViewState.Add("CID", value); }
    }

    private int SelectedAOID
    {
        get { return ((ViewState["AOID"] == null) ? 0 : (int)ViewState["AOID"]); }
        set { ViewState.Add("AOID", value); }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            btnSave.Visible = false;

            CARETTA.COM.DDLHelper.BindDDL(ref ddlAMT, HOTOMOTO.APEX.AccessMainTypes.GetAllAccessMainTypesDataSet(SessRoot.LanguageID).Tables[0], "MainType", "AccessMainTypeID", "0","Seçiniz...","0");


            //CARETTA.COM.DDLHelper.BindDDL(ref ddlAT, HOTOMOTO.BUS.CountriesAndCities.GetCountries(SessRoot.LanguageID), "CountryName", "CountryID", ConfigurationManager.AppSettings["DefaultCountryID"].ToString());

            BindGrid();
        }
    }
    protected void btnAdd_Click(object sender, EventArgs e)
    {
        HOTOMOTO.APEX.AccessOptions objAO;
        HOTOMOTO.APEX.Customers_AccessOptions objCAO;

        objAO = new HOTOMOTO.APEX.AccessOptions();
        objAO.AccessTypeID = Convert.ToInt32(ddlAT.SelectedValue);
        objAO.AccessValue = txtV.Text;
        objAO.CreateDate = DateTime.Now;
        objAO.isActive = true;
        objAO.isDefault = chkIsDef.Checked;
        objAO.ShowOrder = 1;
        

        objCAO = new HOTOMOTO.APEX.Customers_AccessOptions();
        objCAO.AccessOptionID = objAO.Save();
        objCAO.CustomerID = this.CustomerID;
        objCAO.Save();

        BindGrid();
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        HOTOMOTO.APEX.AccessOptions objAO;
        objAO = new HOTOMOTO.APEX.AccessOptions();
        objAO.Load(this.SelectedAOID);
        objAO.AccessOptionID = this.SelectedAOID;
        objAO.AccessTypeID = Convert.ToInt32(ddlAT.SelectedValue);
        objAO.AccessValue = txtV.Text;
        objAO.CreateDate = DateTime.Now;
        objAO.isActive = true;
        objAO.isDefault = chkIsDef.Checked;
        objAO.ShowOrder = 1;
        objAO.Save();

        BindGrid();
    }
    protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        HOTOMOTO.APEX.AccessOptions objAO;
        HOTOMOTO.APEX.Customers_AccessOptions objCAO;
        HOTOMOTO.APEX.AccessTypes objAT;

        if (e.CommandName == "updateAO")
        {
            objAO = new HOTOMOTO.APEX.AccessOptions();
            objAT = new HOTOMOTO.APEX.AccessTypes();
             
            objAO.Load(Convert.ToInt32(e.CommandArgument));

            objAT.Load(objAO.AccessTypeID);
            ddlAMT.SelectedValue = objAT.AccessMainTypeID.ToString();
            CARETTA.COM.DDLHelper.BindDDL(ref ddlAT, HOTOMOTO.APEX.Custom.SPExec_Customer.GetAccessTypesByMainTypeID(this.SessRoot.LanguageID, Convert.ToInt32(ddlAMT.SelectedValue)), "Type", "AccessTypeID", "");

            ddlAT.SelectedValue = objAO.AccessTypeID.ToString();
            txtV.Text = objAO.AccessValue;
            chkIsDef.Checked = objAO.isDefault;
            this.SelectedAOID = Convert.ToInt32(e.CommandArgument);

            btnSave.Visible = true;
        }
        else if (e.CommandName == "deleteAO")
        {
            objCAO = new HOTOMOTO.APEX.Customers_AccessOptions();
            objCAO.Load(Convert.ToInt32(e.CommandArgument));
            objCAO.Delete();
            BindGrid();
        }
    }

    public void BindGrid()
    {
        DataTable dtCustomerAccessOptions = new DataTable();
        dtCustomerAccessOptions = HOTOMOTO.APEX.Custom.SPExec_Customer.GetCustomerAccessOptions(SessRoot.LanguageID, this.CustomerID);
        GridView1.DataSource = dtCustomerAccessOptions;
        GridView1.DataBind();
    }

    protected void ddlAMT_SelectedIndexChanged(object sender, EventArgs e)
    {
        CARETTA.COM.DDLHelper.BindDDL(ref ddlAT, HOTOMOTO.APEX.Custom.SPExec_Customer.GetAccessTypesByMainTypeID(this.SessRoot.LanguageID, Convert.ToInt32(ddlAMT.SelectedValue)), "Type", "AccessTypeID", "");

    }
}
