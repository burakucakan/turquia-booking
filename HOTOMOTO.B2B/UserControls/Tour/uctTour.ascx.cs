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

public partial class UserControls_Tour_uctTour : BaseUserControl {

    public HOTOMOTO.BUS.Enumerations.TourTypes TourType {
        get {
            return (ViewState["TourType"] == null ? HOTOMOTO.BUS.Enumerations.TourTypes.Excursion : ((HOTOMOTO.BUS.Enumerations.TourTypes)((int)ViewState["TourType"])));
        }
        set {
            ViewState["TourType"] = value;
        }
    }

    private int MinCapacity = 1000; // Hepsi gelsin diye Maximum Kapasite 

    protected void Page_Load(object sender, EventArgs e) {

        //Aramanýn Tur Tipini Set Et 
        UctTourSearch1.TourType = this.TourType;

        //Arama Yapýlmýþsa
        if (!IsPostBack) {

            
            if (Request.QueryString["Step"] != null) {

                if (CARETTA.COM.Util.IsNumeric(Request.QueryString["Step"])) {

                    // Arama Türüne Göre Sonuçlarý Getir
                    GetTourList((HOTOMOTO.BUS.Enumerations.QueryStrings)Convert.ToInt16(Request.QueryString["Step"]));
                }
                else {
                    Response.Redirect("Default.aspx");
                }

            }

        }//ISPOSTBACK
    }

    private void GetTourList(HOTOMOTO.BUS.Enumerations.QueryStrings QueryString) {
        switch (QueryString) {

            case HOTOMOTO.BUS.Enumerations.QueryStrings.DetailSearch:
            LoadTourList();
            break;

            case HOTOMOTO.BUS.Enumerations.QueryStrings.All:
            this.SessRoot.ArrivalDate = DateTime.Now;
            this.SessRoot.DepartureDate = DateTime.Now.AddYears(2);
            LoadTourList(true);
            break;

            default:
            Response.Redirect("Default.aspx");
            break;
        }
    }

#region ÝÞLEMLER

    private void LoadTourList() {
        LoadTourList(false);
    }

    private void LoadTourList(bool All) {

        DataTable dtTourList;

        if (!All) {
            dtTourList = HOTOMOTO.BUS.Tour.GetTours(this.SessRoot.LanguageID, this.SessRoot.SearchCityID, this.SessRoot.ArrivalDate, this.SessRoot.DepartureDate, this.TourType, MinCapacity, "%", "%" + this.SessRoot.SearchTourName + "%");            
        }
        else {
            dtTourList = HOTOMOTO.BUS.Tour.GetAllTours(this.SessRoot.LanguageID, this.TourType);
        }

        if (dtTourList.Rows.Count > 0) {
            pnlTourList.Visible = true;

            uctPaging1.GeneratePager(ref dtTourList, ref rptTourList);

            UctTourSearch1.SearchPanelCollapsed = true;       //Arama Paneline Yukarý Kapa
        }
        else {
            pnlTourList.Visible = false;
            //Resx Dosyasýndan Hata Mesajlarý Alýnmasý
            UctTourSearch1.ShowModal(UserControls_ModalPopup_ModalPopup.Icons.info, "ARAMA SONUCU", "Aradýðýnýz Kriterlere Uygun Tur Bulunamadý!");
        }

    }

#endregion

    protected void rptTourList_ItemDataBound(object sender, RepeaterItemEventArgs e) {
        if ((e.Item.ItemType == ListItemType.Item) || (e.Item.ItemType == ListItemType.AlternatingItem)) {
            ((Literal)e.Item.FindControl("ltlCurrLeft")).Text = this.SessRoot.CurrencySymbolLeft;
            ((Literal)e.Item.FindControl("ltlCurrRight")).Text = this.SessRoot.CurrencySymbolRight;

            int TourID = int.Parse(((Literal)e.Item.FindControl("ltlTourID")).Text);
            ((HyperLink)e.Item.FindControl("hlTourDetail")).NavigateUrl = "javascript:TourDetail('" + TourID + "', " + (int)this.TourType + ");";

            Literal ltlPrice = ((Literal)e.Item.FindControl("ltl" + this.SessRoot.CurrencyID.ToString() + "Price"));
            ltlPrice.Visible = true;
            ltlPrice.Text = String.Format("{0:0.00}", ltlPrice.Text);
        }
    }

    protected void rptTourList_ItemCommand(object source, RepeaterCommandEventArgs e) {
        if ((e.Item.ItemType == ListItemType.AlternatingItem) || (e.Item.ItemType == ListItemType.Item)) {

            string TourID = ((Literal)(e.Item.FindControl("ltlTourID"))).Text.ToString();
            string TourName = ((HyperLink)(e.Item.FindControl("hlTourDetail"))).Text.ToString();
            string CityID = ((Literal)(e.Item.FindControl("ltlCityID"))).Text.ToString();

            this.SessRoot.CurrentTourID = int.Parse(TourID);
            this.SessRoot.CurrentTourName = TourName;
            this.SessRoot.SearchCityID = CityID;

            Response.Redirect("TourReservation.aspx?TourID=" + TourID + "&TourType=" + (int)this.TourType);

        }
    }

}
