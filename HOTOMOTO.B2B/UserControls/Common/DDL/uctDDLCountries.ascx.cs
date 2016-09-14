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

public partial class UserControls_Common_DDL_uctDDLCountries : BaseUserControl
{
    public string SelectedValue
    {
        get { return ddlCountries.SelectedValue; }
        set { ddlCountries.SelectedValue = value; }
    }
    public string SelectedText
    {
        get { return ddlCountries.Text; }
        set { ddlCountries.Text = value; }
    }
    public ListItem SelectedItem
    {
        get { return ddlCountries.SelectedItem; }
    }
    public ListItemCollection Items
    {
        get { return ddlCountries.Items; }
    }

    public bool AutoPostBack {
        set { ddlCountries.AutoPostBack = value; }
    }

    public event evChangeCountryEventHandler evChangeCountry;
    public delegate void evChangeCountryEventHandler(string CountryID);

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            //Ülkeleri Yükle
            LoadCountries();
            ddlCountries.SelectedValue = ConfigurationManager.AppSettings["DefaultCountryID"].ToString();
            ChangeCountry();
        }
    }

    private void LoadCountries()
    {
        CARETTA.COM.DDLHelper.BindDDL(ref ddlCountries, this.CachedCountries, "CountryName", "CountryID", "-1");
    }

    protected void ddlCountries_SelectedIndexChanged(object sender, EventArgs e) {
        ChangeCountry();
    }

    protected void ChangeCountry() {
        if (evChangeCountry != null) {
            evChangeCountry(ddlCountries.SelectedValue);
        }
    }
}
