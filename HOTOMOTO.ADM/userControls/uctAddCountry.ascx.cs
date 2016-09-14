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

public partial class userControls_uctAddCountry : BaseUserControl {

	HOTOMOTO.APEX.Countries cs;

    protected void Page_Init(object sender, EventArgs e) {
		if(Request.QueryString["id"] != "") {
			//cs.Load(int.Parse(Request.QueryString["id"]));
		}
		DataTable dtLanguages = HOTOMOTO.BUS.CountriesAndCities.GetCountries(this.SessRoot.LanguageID);

        int i = 0;
		//rowindex 0:LanguageID 1:Language 2:isActive
        foreach(DataRow dr in dtLanguages.Rows) {
            if(((bool)dr["isActive"]) == true) {

                AjaxControlToolkit.TabPanel tab = new AjaxControlToolkit.TabPanel();
                tab.ID = i.ToString();
                tab.HeaderText = dr[1].ToString();

                Label lblCountryName = new Label();
                lblCountryName.Text = "Ülke adý";
                lblCountryName.CssClass = "label";
                tab.Controls.Add(lblCountryName);

                TextBox txt = new TextBox();
                txt.ID = "txtLanguage" + i.ToString();
                txt.CssClass = "textBox p50";
				txt.Text = cs.CountryName;
				tab.Controls.Add(txt);

                TabContainer1.Tabs.Add(tab);
                i++;
            }
        }
        if(TabContainer1.Tabs.Count > 0)
            TabContainer1.ActiveTabIndex = 0;
    }

    protected void Page_Load(object sender, EventArgs e) {

    }

    protected void btnPublish_Click(object sender, ImageClickEventArgs e) {
		

        //HOTOMOTO.APEX.Countries cs = new HOTOMOTO.APEX.Countries(1);

        //cs.SetName("Turkey", 1);
        //cs.SetName("Turquia", 2);
        //cs.SetName("Türkiye", 3);

        //cs.Save();

        UctMessage1.Message = "Formdaki bütün alanlarý doldurunuz!";
        UctMessage1.Type = MessageType.Error;
        UctMessage1.Visible = true;
    }
}
