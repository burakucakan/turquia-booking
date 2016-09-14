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

public partial class UserControls_Common_DDL_uctDDLCities : BaseUserControl
{
    public string SelectedValue
    {
        get { return ddlCities.SelectedValue; }
        set { ddlCities.SelectedValue = value; }
    }
    public string SelectedText
    {
        get { return ddlCities.Text; }
        set { ddlCities.Text = value; }
    }
    public ListItem SelectedItem
    {
        get { return ddlCities.SelectedItem; }
    }
    public ListItemCollection Items
    {
        get { return ddlCities.Items; }
    }

    private int m_CountryID; 
    public int CountryID {
        set { m_CountryID = value; }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        
    }

    public void LoadCities(int CountryID) {
        DataTable dtCities = HOTOMOTO.BUS.CountriesAndCities.GetCitiesByCountryID(this.SessRoot.LanguageID, CountryID);
        CARETTA.COM.DDLHelper.BindDDL(ref ddlCities, dtCities, "CityName", "CityID", "", "All Cities", "%");
        ItemControl();
    }

    public void LoadCities()
    {
        CARETTA.COM.DDLHelper.BindDDL(ref ddlCities, this.CachedCities, "Name", "CityID", "", ConfigurationManager.AppSettings["InitialText"], "0");
        ItemControl();
    }

    public void ItemControl() {
        if (ddlCities.Items.Count < 1) {
            ddlCities.Items.Add(new ListItem("City Not Found", "0"));
        }
    }

}
