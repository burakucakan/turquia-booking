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

public partial class userControls_Tours_uctTourCities : BaseUserControl
{

    public int TourID
    {
        get {
            if (Request.QueryString["tourid"] != null)
            {
                ViewState.Add("TIDA", Convert.ToInt32(Request.QueryString["tourid"]));
            }
            return ViewState["TIDA"] == null ? 0 : Convert.ToInt32(ViewState["TIDA"]); 
        }
        set { ViewState.Add("TIDA", value); }
    }

    public int StartCityID
    {
        get
        {
            if (lbCountCity.Items.Count > 0)
            {
                return Convert.ToInt32(lbCountCity.Items[0].Value);
            }
            return 0;
        }
    }

    public int EndCityID
    {
        get
        {
            if (lbCountCity.Items.Count > 0)
            {
                return Convert.ToInt32(lbCountCity.Items[lbCountCity.Items.Count-1].Value);
            }
            return 0;
        }
    }

    public int CountryID
    {
        get
        {
            if (ddlCountries.SelectedIndex > 0)
            {
                return Convert.ToInt32(ddlCountries.SelectedValue);
            }
            return 0;
        }
    }

    public ListItemCollection Cities
    {
        get
        {
            return lbCountCity.Items;
        }
    }

    protected void Page_Init(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            CARETTA.COM.DDLHelper.BindDDL(ref ddlCountries, HOTOMOTO.APEX.Countries.GetAllCountriesDataSet(this.SessRoot.LanguageID).Tables[0], "CountryName", "CountryID", "0", "Ülke Seçiniz", "0");

            ddlCities.Items.Add(new ListItem("Ülke Seçiniz", "0"));

        }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        
    }
    protected void btnAdd_Click(object sender, EventArgs e)
    {
        if (ddlCities.SelectedIndex > 0)
        {
            ListItem li = new ListItem();
            li.Text = ddlCities.SelectedItem.Text;
            li.Value =  ddlCities.SelectedValue;
            if (!lbCountCity.Items.Contains(li))
            {
                lbCountCity.Items.Add(li);
            }
        }
    }
    protected void btnRem_Click(object sender, EventArgs e)
    {
        for (int i = lbCountCity.Items.Count - 1; i > -1; i--)
        {
            if (lbCountCity.Items[i].Selected)
            {
                lbCountCity.Items.RemoveAt(i);
            }
        }
    }
    protected void btnUp_Click(object sender, EventArgs e)
    {
        string strValue = "";
        string strText = "";
        string strNewValue = "";
        string strNewText = "";

        int intItemIndex = -1;

        intItemIndex = lbCountCity.SelectedIndex;

        if (intItemIndex > 0)
        {
            strText = lbCountCity.SelectedItem.Text;
            strValue = lbCountCity.SelectedValue;
            strNewText = lbCountCity.Items[intItemIndex - 1].Text;
            strNewValue = lbCountCity.Items[intItemIndex - 1].Value;
            lbCountCity.Items.RemoveAt(intItemIndex);
            lbCountCity.Items[intItemIndex - 1].Text = strText;
            lbCountCity.Items[intItemIndex - 1].Value = strValue;
            lbCountCity.Items.Insert(intItemIndex, new ListItem(strNewText, strNewValue));
            lbCountCity.SelectedIndex = intItemIndex - 1;
        }
    }
    protected void btnDown_Click(object sender, EventArgs e)
    {
        string strValue = "";
        string strText = "";
        string strNewValue = "";
        string strNewText = "";

        int intItemIndex = -1;

        intItemIndex = lbCountCity.SelectedIndex;

        if (intItemIndex < lbCountCity.Items.Count - 1)
        {
            strText = lbCountCity.SelectedItem.Text;
            strValue = lbCountCity.SelectedValue;
            strNewText = lbCountCity.Items[intItemIndex + 1].Text;
            strNewValue = lbCountCity.Items[intItemIndex + 1].Value;
            lbCountCity.Items.RemoveAt(intItemIndex);
            lbCountCity.Items[intItemIndex].Text = strText;
            lbCountCity.Items[intItemIndex].Value = strValue;
            lbCountCity.Items.Insert(intItemIndex, new ListItem(strNewText, strNewValue));
            lbCountCity.SelectedIndex = intItemIndex + 1;
        }
    }
    protected void ddlCountries_SelectedIndexChanged(object sender, EventArgs e)
    {
        FillDdlCities();
    }

    private void FillDdlCities()
    {
        if (ddlCountries.SelectedIndex > 0)
        {
            CARETTA.COM.DDLHelper.BindDDL(ref ddlCities, HOTOMOTO.APEX.Cities.GetCitiesByCountry(Convert.ToInt32(ddlCountries.SelectedValue), this.SessRoot.LanguageID).Tables[0], "CityName", "CityID", "0", "Þehir Seçiniz", "0");
        }
        else
        {
            ddlCities.Items.Clear();
            ddlCities.Items.Add(new ListItem("Ülke Seçiniz", "0"));
        }
    }

    public void SaveTourCities()
    {
        HOTOMOTO.APEX.Tours_Cities objTourCities;

        HOTOMOTO.APEX.Custom.SPExec_Tour.RemoveTourCitiesByTourID(this.TourID);

        foreach (ListItem li in lbCountCity.Items)
        {
            objTourCities = new HOTOMOTO.APEX.Tours_Cities();
            objTourCities.CityID = Convert.ToInt32(li.Value);
            objTourCities.TourID = this.TourID;
            objTourCities.Save();
        }
    }

    public void LoadTourCities()
    {

        DataTable dtCitites = HOTOMOTO.APEX.Custom.SPExec_Tour.GetTourCitiesByTourID(this.SessRoot.LanguageID, this.TourID);

        lbCountCity.DataSource = dtCitites;
        lbCountCity.DataTextField = "CityName";
        lbCountCity.DataValueField = "CityID";
        lbCountCity.DataBind();
        lbCountCity.SelectedIndex = -1;

        ddlCountries.SelectedIndex = -1;

        if (dtCitites.Rows.Count > 0)
        {
            foreach (ListItem li in ddlCountries.Items)
            {
                if (li.Value == dtCitites.Rows[0]["CountryID"].ToString())
                {
                    li.Selected = true;
                    FillDdlCities();
                    return;
                }
            }
           
        }

    }

}
