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

public partial class UserControls_Hotel_uctHotelDetail : BaseUserControl {

    private int m_HotelID = 0;

    protected void Page_Load(object sender, EventArgs e) {
        
        if (!IsPostBack) {

            if (((Request.QueryString["HotelID"] != null) && CARETTA.COM.Util.IsNumeric(Request.QueryString["HotelID"]))) {
                m_HotelID = int.Parse(Request.QueryString["HotelID"]);
            }
            else { Response.Redirect("Default.aspx"); }
            
            FillData();         //Hotel Detayýný Getir ve Bilgileri Ekrana Yaz

            FillPlaces();       //Yakýn Yerleri Getir

        }//IsPostBack
    }


    protected void FillPlaces() {
        DataTable dtPlaces = HOTOMOTO.BUS.Hotels.GetHotelPlacesAndDistances(this.SessRoot.LanguageID, m_HotelID);
        if (dtPlaces.Rows.Count > 0) {
            rptPlaces.DataSource = dtPlaces;
            rptPlaces.DataBind();
        }
        else {
            pnlPlaces.Visible = false;
        }
    }

#region ÝÞLEMLER

    void FillData() {

        DataTable dtHotelDetail = HOTOMOTO.BUS.Hotels.GetHotelDetail(this.SessRoot.LanguageID, m_HotelID);

        ltlChainName.Text = dtHotelDetail.Rows[0]["ChainName"].ToString();
        ltlCityName.Text = dtHotelDetail.Rows[0]["CityName"].ToString();
        ltlCountryName.Text = dtHotelDetail.Rows[0]["CountryName"].ToString();
        ltlHotelName.Text = dtHotelDetail.Rows[0]["HotelName"].ToString();
        ltlDescription.Text = dtHotelDetail.Rows[0]["Description"].ToString();
        imgHotelBig.ImageUrl = imgHotelBig.ImageUrl.Replace("HotelDefault.jpg", dtHotelDetail.Rows[0]["ImageFileName"].ToString());

        dvStars.InnerHtml = HOTOMOTO.COM.ReturnClasses.GetHotelClassFormat(dtHotelDetail.Rows[0]["Star"].ToString()).ToString();
        dvHotelProperties.InnerHtml = HOTOMOTO.COM.ReturnProperties.GetProperties(this.SessRoot.LanguageID, m_HotelID, HOTOMOTO.BUS.Enumerations.PropertyTypes.Hotel).ToString();

        DataTable dtImages = HOTOMOTO.BUS.Hotels.GetHotelImages(m_HotelID);
        foreach (DataRow dr in dtImages.Rows) {
            if (((bool)dr["isDefault"])) {
                dtImages.Rows.Remove(dr);
                break;
            }
        }

        rptHotelImages.DataSource = dtImages;
        rptHotelImages.DataBind();
    }

#endregion

    protected void rptPlaces_ItemDataBound(object sender, RepeaterItemEventArgs e) {
        if ((e.Item.ItemType == ListItemType.Item) || (e.Item.ItemType == ListItemType.AlternatingItem)) {
            Label lblDesc = (Label)e.Item.FindControl("lblPlacesDescription");
            Panel pnlToolTip = (Panel)e.Item.FindControl("pnlToolTip");
            string ClrStr = lblDesc.Text.Replace("'", "");
            lblDesc.Attributes.Add("onmouseover", "ShowToolTip(this, '" + pnlToolTip.ClientID + "', '" + ClrStr + "');");
            pnlToolTip.Attributes.Add("onmouseout", "HideToolTip('" + pnlToolTip.ClientID + "');");
            lblDesc.Text = lblDesc.Text.Replace("<br>", "");
            lblDesc.Text = CARETTA.COM.Util.Left(lblDesc.Text, 170) + "...";
            lblDesc.Visible = true;
        }
    }//rptPlaces_ItemDataBound
}
