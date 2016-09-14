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

public partial class userControls_uctAddress : BaseUserControl {


    private int hotelID
    {
        get { return ((ViewState["HID"] == null) ? 0 : (int)ViewState["HID"]); }
        set { ViewState.Add("HID", value); }
    }

    public int PortID
    {
        get { return ((ViewState["PID"] == null) ? 0 : (int)ViewState["PID"]); }
        set { ViewState.Add("PID", value); }
    }

    public bool isPortAddress
    {
        get { return ((ViewState["PA"] == null) ? false : (bool)ViewState["PA"]); }
        set { ViewState.Add("PA", value); }
    }

	protected void Page_Load(object sender, EventArgs e) {
		if(!Page.IsPostBack) {
			CARETTA.COM.DDLHelper.BindDDL(ref ddlCountries, HOTOMOTO.BUS.CountriesAndCities.GetCountries(SessRoot.LanguageID), "CountryName", "CountryID", ConfigurationManager.AppSettings["DefaultCountryID"].ToString());

            if (!isPortAddress)
            {
                if (Request.QueryString["hotelid"] != null)
                {
                    this.hotelID = int.Parse(Request.QueryString["hotelid"]);
                    LoadHotelAddress();
                }
                else
                {
                    CARETTA.COM.DDLHelper.BindDDL(ref ddlCity, HOTOMOTO.BUS.CountriesAndCities.GetCitiesByCountryID(SessRoot.LanguageID, Convert.ToInt32(ddlCountries.SelectedValue)), "CityName", "CityID", "");
                }
            } else {
                if (Request.QueryString["portid"] != null)
                {
                    this.PortID = int.Parse(Request.QueryString["portid"]);
                    LoadPortAddress();
                } else {
                        CARETTA.COM.DDLHelper.BindDDL(ref ddlCity, HOTOMOTO.BUS.CountriesAndCities.GetCitiesByCountryID(SessRoot.LanguageID, Convert.ToInt32(ddlCountries.SelectedValue)), "CityName", "CityID", "");
                }
            }     
		}
	}

	public int CountryID {
		get { return Convert.ToInt32(ddlCountries.SelectedValue); }
		set { ddlCountries.SelectedIndex = value; }
	}

	public int CityID {
		get { return Convert.ToInt32(ddlCity.SelectedValue); }
		set { ddlCity.SelectedIndex = value; }
	}

	public string Town {
		get { return txtHotelTown.Text; }
		set { txtHotelTown.Text = value; }
	}

	public string StreetAddress {
		get { return txtStreetAddress.Text; }
		set { txtStreetAddress.Text = value; }
	}

	public string PostalCode {
		get { return txtPostalCode.Text; }
		set { txtPostalCode.Text = value; }
	}

	public void SetValidationGroup(string strValidationGroup) {
		reqfvHotelTown.ValidationGroup = strValidationGroup;
		reqfvPostalCode.ValidationGroup = strValidationGroup;
		reqfvStreetAddress.ValidationGroup = strValidationGroup;
	}
	protected void ddlCountries_SelectedIndexChanged(object sender, EventArgs e) {
		CARETTA.COM.DDLHelper.BindDDL(ref ddlCity, HOTOMOTO.BUS.CountriesAndCities.GetCitiesByCountryID(SessRoot.LanguageID, Convert.ToInt32(ddlCountries.SelectedValue)), "CityName", "CityID", "");
	}

	public void Clear() {
		txtHotelTown.Text = "";
		txtPostalCode.Text = "";
		txtStreetAddress.Text = "";
	}

	public void LoadHotelAddress() {
		DataTable dtHotelAddress = new DataTable();
		dtHotelAddress = HOTOMOTO.BUS.Hotels.GetHotelAddresses(SessRoot.LanguageID, this.hotelID);
		if(dtHotelAddress.Rows.Count > 0 && ddlCountries.Items.Count > 0) {
			ddlCountries.SelectedValue = dtHotelAddress.Rows[0]["CountryID"].ToString();
			CARETTA.COM.DDLHelper.BindDDL(ref ddlCity, HOTOMOTO.BUS.CountriesAndCities.GetCitiesByCountryID(SessRoot.LanguageID, Convert.ToInt32(dtHotelAddress.Rows[0]["CountryID"])), "CityName", "CityID", dtHotelAddress.Rows[0]["CityID"].ToString());

			txtHotelTown.Text = dtHotelAddress.Rows[0]["Town"].ToString();
			txtPostalCode.Text = dtHotelAddress.Rows[0]["PostalCode"].ToString();
			txtStreetAddress.Text = dtHotelAddress.Rows[0]["StreetAddress"].ToString();
		}
	}

    public void LoadPortAddress()
    {
        DataTable dtPortAddress = new DataTable();
        dtPortAddress = HOTOMOTO.BUS.Transfer.GetPortAddresses(SessRoot.LanguageID, this.PortID);
        if (dtPortAddress.Rows.Count > 0 && ddlCountries.Items.Count > 0)
        {
            ddlCountries.SelectedValue = dtPortAddress.Rows[0]["CountryID"].ToString();
            CARETTA.COM.DDLHelper.BindDDL(ref ddlCity, HOTOMOTO.BUS.CountriesAndCities.GetCitiesByCountryID(SessRoot.LanguageID, Convert.ToInt32(dtPortAddress.Rows[0]["CountryID"])), "CityName", "CityID", dtPortAddress.Rows[0]["CityID"].ToString());

            txtHotelTown.Text = dtPortAddress.Rows[0]["Town"].ToString();
            txtPostalCode.Text = dtPortAddress.Rows[0]["PostalCode"].ToString();
            txtStreetAddress.Text = dtPortAddress.Rows[0]["StreetAddress"].ToString();
        }
    }

    public void SavePortAddress()
    {
        DataTable dtPortAddress = new DataTable();
        dtPortAddress = HOTOMOTO.BUS.Transfer.GetPortAddresses(SessRoot.LanguageID, this.PortID);
        HOTOMOTO.APEX.Addresses address = new HOTOMOTO.APEX.Addresses();
        if (dtPortAddress.Rows.Count > 0)
            address.Load(Convert.ToInt32(dtPortAddress.Rows[0]["AddressID"]));
        else
        {
            address.AddressTypeID = 1;
            address.isDefault = true;
            address.isActive = true;
            address.CreateDate = DateTime.Now;
        }

        address.CountryID = int.Parse(ddlCountries.SelectedValue);
        if (ddlCity.Items.Count > 0)
            address.CityID = int.Parse(ddlCity.SelectedValue);
        else
            address.CityID = 0;

        address.Town = txtHotelTown.Text;
        address.PostalCode = txtPostalCode.Text;
        address.StreetAddress = txtStreetAddress.Text;
        int addressID = address.Save();

        if (dtPortAddress.Rows.Count == 0)
        {
            HOTOMOTO.APEX.Ports_Addresses portAddress = new HOTOMOTO.APEX.Ports_Addresses();
            portAddress.PortID = this.PortID;
            portAddress.AddressID = addressID;
            portAddress.Save();
        }
    }

	public void SaveHotelAddress() {
		DataTable dtHotelAddress = new DataTable();
		dtHotelAddress = HOTOMOTO.BUS.Hotels.GetHotelAddresses(SessRoot.LanguageID, this.hotelID);
		HOTOMOTO.APEX.Addresses address = new HOTOMOTO.APEX.Addresses();
		if(dtHotelAddress.Rows.Count > 0)
			address.Load(Convert.ToInt32(dtHotelAddress.Rows[0]["AddressID"]));
		else {
			address.AddressTypeID = 1;
			address.isDefault = true;
			address.isActive = true;
			address.CreateDate = DateTime.Now;
		}
		
		address.CountryID = int.Parse(ddlCountries.SelectedValue);
		if(ddlCity.Items.Count > 0)
			address.CityID = int.Parse(ddlCity.SelectedValue);
		else
			address.CityID = 0;

		address.Town = txtHotelTown.Text;
		address.PostalCode = txtPostalCode.Text;
		address.StreetAddress = txtStreetAddress.Text;
		int addressID = address.Save();

		if(dtHotelAddress.Rows.Count == 0) {
			HOTOMOTO.APEX.Hotels_Addresses hotelAddress = new HOTOMOTO.APEX.Hotels_Addresses();
			hotelAddress.HotelID = this.hotelID;
			hotelAddress.AddressID = addressID;
			hotelAddress.Save();
		}
	}
}
