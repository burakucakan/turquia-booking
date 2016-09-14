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

public partial class userControls_HotelSearch : BaseUserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            CARETTA.COM.DDLHelper.BindDDL(ref ddlCountry, HOTOMOTO.BUS.CountriesAndCities.GetCountries(SessRoot.LanguageID ), "CountryName", "CountryID", "");
        }
    }
    protected void ddlCountry_SelectedIndexChanged(object sender, EventArgs e)
    {
        CARETTA.COM.DDLHelper.BindDDL(ref ddlCity, HOTOMOTO.BUS.CountriesAndCities.GetCitiesByCountryID(SessRoot.LanguageID, Convert.ToInt32(ddlCountry.SelectedValue)), "CityName", "CityID", "");
    }
}
