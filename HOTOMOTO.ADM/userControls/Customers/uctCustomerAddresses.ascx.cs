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

public partial class userControls_Customers_uctCustomerAddresses : BaseUserControl
{
    public int CustomerID
    {
        get { return ((ViewState["CID"] == null) ? 0 : (int)ViewState["CID"]); }
        set { ViewState.Add("CID", value); }
    }

    private int SelectedAddressID
    {
        get { return ((ViewState["SID"] == null) ? 0 : (int)ViewState["SID"]); }
        set { ViewState.Add("SID", value); }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            btnSave.Visible = false;

            CARETTA.COM.DDLHelper.BindDDL(ref ddlAT, HOTOMOTO.APEX.AddressTypes.GetAllAddressTypesDataSet(SessRoot.LanguageID).Tables[0], "Type", "AddressTypeID","");


            CARETTA.COM.DDLHelper.BindDDL(ref ddlCountries, HOTOMOTO.BUS.CountriesAndCities.GetCountries(SessRoot.LanguageID), "CountryName", "CountryID", ConfigurationManager.AppSettings["DefaultCountryID"].ToString());

            CARETTA.COM.DDLHelper.BindDDL(ref ddlCity, HOTOMOTO.BUS.CountriesAndCities.GetCitiesByCountryID(SessRoot.LanguageID, Convert.ToInt32(ddlCountries.SelectedValue)), "CityName", "CityID", "");

            BindGrid();
        }
    }


    protected void ddlCountries_SelectedIndexChanged(object sender, EventArgs e)
    {
        CARETTA.COM.DDLHelper.BindDDL(ref ddlCity, HOTOMOTO.BUS.CountriesAndCities.GetCitiesByCountryID(SessRoot.LanguageID, Convert.ToInt32(ddlCountries.SelectedValue)), "CityName", "CityID", "");
    }
    protected void btnAdd_Click(object sender, EventArgs e)
    {
        HOTOMOTO.APEX.Addresses objAddress;
        objAddress = new HOTOMOTO.APEX.Addresses();
        objAddress.AddressTypeID = Convert.ToInt32(ddlAT.SelectedValue);
        objAddress.CityID = Convert.ToInt32(ddlCity.SelectedValue);
        objAddress.CountryID = Convert.ToInt32(ddlCountries.SelectedValue);
        objAddress.isActive = true;
        objAddress.isDefault = chkIsDef.Checked;
        objAddress.PostalCode = txtPostalCode.Text;
        objAddress.StreetAddress = txtStreetAddress.Text;
        objAddress.Town = txtHotelTown.Text;
        objAddress.CreateDate = DateTime.Now;
        
        HOTOMOTO.APEX.Customers_Addresses objCustomerAddresses;
        objCustomerAddresses = new HOTOMOTO.APEX.Customers_Addresses();
        objCustomerAddresses.AddressID = objAddress.Save();
        objCustomerAddresses.CustomerID = this.CustomerID;
        objCustomerAddresses.Save();

        BindGrid();

    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        HOTOMOTO.APEX.Addresses objAddress;
        objAddress = new HOTOMOTO.APEX.Addresses();
        objAddress.Load(this.SelectedAddressID);
        objAddress.AddressID = this.SelectedAddressID;
        objAddress.AddressTypeID = Convert.ToInt32(ddlAT.SelectedValue);
        objAddress.CityID = Convert.ToInt32(ddlCity.SelectedValue);
        objAddress.CountryID = Convert.ToInt32(ddlCountries.SelectedValue);
        objAddress.isActive = true;
        objAddress.isDefault = chkIsDef.Checked;
        objAddress.PostalCode = txtPostalCode.Text;
        objAddress.StreetAddress = txtStreetAddress.Text;
        objAddress.Town = txtHotelTown.Text;
        objAddress.Save();

        BindGrid();
    }
    protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        HOTOMOTO.APEX.Addresses objAddress;
        HOTOMOTO.APEX.Customers_Addresses objCustomerAddress;

        if (e.CommandName == "updateCust")
        {
            objAddress = new HOTOMOTO.APEX.Addresses();
            objAddress.Load(Convert.ToInt32(e.CommandArgument));
            ddlCountries.SelectedValue = objAddress.CountryID.ToString();
            CARETTA.COM.DDLHelper.BindDDL(ref ddlCity, HOTOMOTO.BUS.CountriesAndCities.GetCitiesByCountryID(SessRoot.LanguageID, Convert.ToInt32(ddlCountries.SelectedValue)), "CityName", "CityID", "");
            ddlCity.SelectedValue = objAddress.CityID.ToString();
            chkIsDef.Checked = objAddress.isDefault;
            ddlAT.SelectedValue = objAddress.AddressTypeID.ToString();
            txtPostalCode.Text = objAddress.PostalCode;
            txtStreetAddress.Text = objAddress.StreetAddress;
            txtHotelTown.Text = objAddress.Town;
            this.SelectedAddressID = Convert.ToInt32(e.CommandArgument);
            btnSave.Visible = true;
        }
        else if (e.CommandName == "deleteCust")
        {
            objCustomerAddress = new HOTOMOTO.APEX.Customers_Addresses();
            objCustomerAddress.Load(Convert.ToInt32(e.CommandArgument));
            objCustomerAddress.Delete();
            BindGrid();
        }
    }

    public void BindGrid()
    {
        DataTable dtCustomerAddress = new DataTable();
        dtCustomerAddress = HOTOMOTO.APEX.Custom.SPExec_Customer.GetCustomerAddresses(SessRoot.LanguageID, this.CustomerID);
        GridView1.DataSource = dtCustomerAddress;
        GridView1.DataBind();
        //if (dtPortAddress.Rows.Count > 0 && ddlCountries.Items.Count > 0)
        //{
        //    ddlCountries.SelectedValue = dtCustomerAddress.Rows[0]["CountryID"].ToString();
        //    CARETTA.COM.DDLHelper.BindDDL(ref ddlCity, HOTOMOTO.BUS.CountriesAndCities.GetCitiesByCountryID(SessRoot.LanguageID, Convert.ToInt32(dtPortAddress.Rows[0]["CountryID"])), "CityName", "CityID", dtPortAddress.Rows[0]["CityID"].ToString());

        //    txtHotelTown.Text = dtPortAddress.Rows[0]["Town"].ToString();
        //    txtPostalCode.Text = dtPortAddress.Rows[0]["PostalCode"].ToString();
        //    txtStreetAddress.Text = dtPortAddress.Rows[0]["StreetAddress"].ToString();
        //}
    }

}

