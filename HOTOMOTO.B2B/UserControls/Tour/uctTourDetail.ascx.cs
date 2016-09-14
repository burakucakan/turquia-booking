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

public partial class UserControls_Tour_uctTourDetail : BaseUserControl {

    private int m_TourID = 0;
    private int m_MinCapacity = 1000;
    private HOTOMOTO.BUS.Enumerations.TourTypes m_TourType;

    protected void Page_Load(object sender, EventArgs e) {

        if (!IsPostBack) {

            QueryStringControl();   //Query Stringleri Kontrol Et 

            FillData();             //Tour Detayýný Getir ve Bilgileri Ekrana Yaz

        }//IsPostBack
    }

    private void QueryStringControl() {
        if (((Request.QueryString["TourID"] != null) && CARETTA.COM.Util.IsNumeric(Request.QueryString["TourID"]))) {
            m_TourID = int.Parse(Request.QueryString["TourID"]);
        }
        else {
            Response.Redirect("Default.aspx");
        }

        if (((Request.QueryString["TourType"] != null) && CARETTA.COM.Util.IsNumeric(Request.QueryString["TourType"]))) {
            m_TourType = ((HOTOMOTO.BUS.Enumerations.TourTypes)(int.Parse(Request.QueryString["TourType"])));
        }
        else {
            Response.Redirect("Default.aspx");
        }
    }

    void FillData() {

        DataTable dtTourDetail = HOTOMOTO.BUS.Tour.GetTours(this.SessRoot.LanguageID, this.SessRoot.SearchCityID, this.SessRoot.ArrivalDate, this.SessRoot.DepartureDate, m_TourType, m_MinCapacity, m_TourID.ToString());

        ltlTourName.Text = dtTourDetail.Rows[0]["Name"].ToString();
        ltlTourStartDate.Text = Convert.ToDateTime(dtTourDetail.Rows[0]["StartDate"]).ToShortDateString();
        ltlTourEndDate.Text = Convert.ToDateTime(dtTourDetail.Rows[0]["EndDate"]).ToShortDateString();
        ltlDescription.Text = dtTourDetail.Rows[0]["Description"].ToString();
        ltlRecommend.Text = dtTourDetail.Rows[0]["Recommendation"].ToString();
        ltlMinCapacity.Text = dtTourDetail.Rows[0]["MinCapacity"].ToString();

        DataTable dtTourImages = HOTOMOTO.BUS.Tour.GetTourImages(this.m_TourID);

        
        foreach (DataRow dr in dtTourImages.Rows) {
            if ((bool)dr["isDefault"]) {
                imgTourBig.ImageUrl = imgTourBig.ImageUrl.Replace("TourDefault.jpg", dr["Filename"].ToString());
                dtTourImages.Rows.Remove(dr);
                break;
            }
        }

        rptTourImages.DataSource = dtTourImages;
        rptTourImages.DataBind();
    }

}
