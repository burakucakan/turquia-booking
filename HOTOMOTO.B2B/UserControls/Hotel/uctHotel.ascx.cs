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
using System.Text;

public partial class UserControls_Hotel_uctHotel : BaseUserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {

        //Arama Yapýlmýþsa

        if (!IsPostBack)
        {
            if (Request.QueryString["Step"] != null)
            {
                if (CARETTA.COM.Util.IsNumeric(Request.QueryString["Step"]))
                {
                    // Arama Türüne Göre Sonuçlarý Getir
                    GetHotelList((HOTOMOTO.BUS.Enumerations.QueryStrings)Convert.ToInt16(Request.QueryString["Step"]));
                }
                else { Response.Redirect("Default.aspx"); }

            }
        }

    }

    private void GetHotelList(HOTOMOTO.BUS.Enumerations.QueryStrings QueryString) {
        switch (QueryString) {

            case HOTOMOTO.BUS.Enumerations.QueryStrings.DetailSearch:
                LoadHotelList();
                break;

            case HOTOMOTO.BUS.Enumerations.QueryStrings.All:
                this.SessRoot.SearchCountryID = int.Parse(ConfigurationManager.AppSettings["DefaultCountryID"].ToString());
                this.SessRoot.SearchCityID = "%";
                this.SessRoot.SearchHotelClass = "%";
                this.SessRoot.SearchHotelName = "%";
                this.SessRoot.ArrivalDate = DateTime.Now;
                this.SessRoot.DepartureDate = DateTime.Now.AddYears(2);
                this.SessRoot.RoomQuantity = 1;

                DataTable dtRoomsDetail = HOTOMOTO.COM.Util.InitializeRoomsDetail();

                DataRow dr = dtRoomsDetail.NewRow();
                dr["RoomIndex"] = "1";
                dr["AdultCount"] = "2";
                dr["ChildCount"] = "0";
                dr["FirstChildAge"] = "0";
                dr["SecondChildAge"] = "0";
                dtRoomsDetail.Rows.Add(dr);

                this.SessRoot.RoomsDetail = dtRoomsDetail;

                UctHotelSearch1.FillSearchForm();

                LoadHotelList();
                break;

            case HOTOMOTO.BUS.Enumerations.QueryStrings.Favorites:
                LoadFavorites();
                break;

            default:
                Response.Redirect("Default.aspx");
            break;
        }
    }

#region ÝÞLEMLER

    private void LoadHotelList() {

        DataTable dtHotelList;
        dtHotelList = HOTOMOTO.BUS.Hotels.GetHotelList(this.SessRoot.LanguageID, this.SessRoot.SearchCityID, "%" + this.SessRoot.SearchHotelName + "%", this.SessRoot.SearchHotelClass, this.SessRoot.RoomQuantity, this.SessRoot.ArrivalDate, this.SessRoot.DepartureDate);
        
        if (dtHotelList.Rows.Count > 0) {
            pnlHotelList.Visible = true;

            uctPaging1.GeneratePager(ref dtHotelList, ref rptHotelList);

            UctHotelSearch1.SearchPanelCollapsed = true;       //Arama Paneline Yukarý Kapa
        } 
        else {
            pnlHotelList.Visible = false;

            //Resx Dosyasýndan Hata Mesajlarý Alýnmasý
            UctHotelSearch1.ShowModal(UserControls_ModalPopup_ModalPopup.Icons.info, "ARAMA SONUCU", "Aradýðýnýz Kriterlere Uygun Otel Bulunamadý!");
        }

    }

    private void LoadFavorites() {
        DataTable dtHotelList = HOTOMOTO.BUS.Packages.GetFavoriteHotels(this.SessRoot.CustomerID, this.SessRoot.UserID);

        if (dtHotelList.Rows.Count > 0) {
            pnlHotelList.Visible = true;

            rptHotelList.DataSource = dtHotelList;
            rptHotelList.DataBind();

            uctPaging1.Visible = false;
            UctHotelSearch1.SearchPanelCollapsed = true;       //Arama Paneline Yukarý Kapa
        }
        else {
            pnlHotelList.Visible = false;
            //Resx Dosyasýndan Hata Mesajlarý Alýnmasý
            UctHotelSearch1.ShowModal(UserControls_ModalPopup_ModalPopup.Icons.info, "ARAMA SONUCU", "Aradýðýnýz Kriterlere Uygun Otel Bulunamadý!");
        }        
    }

#endregion

    protected string CtrlNewRoomStatus(string Status) { //Resxten alýnsýn
        HOTOMOTO.BUS.Enumerations.NewRequestable enStatus = ((HOTOMOTO.BUS.Enumerations.NewRequestable)int.Parse(Status));
        if (enStatus == HOTOMOTO.BUS.Enumerations.NewRequestable.Available) {
            return "Available";
        }
        else if (enStatus == HOTOMOTO.BUS.Enumerations.NewRequestable.OnRequest) {
            return "On Request";
        }
        return string.Empty;
    }

    protected void rptHotelList_ItemCommand(object source, RepeaterCommandEventArgs e) {

        if ((e.Item.ItemType == ListItemType.AlternatingItem) || (e.Item.ItemType == ListItemType.Item)) {

            string HotelID = ((Literal)(e.Item.FindControl("ltlHotelID"))).Text.ToString();
            string HotelName = ((HyperLink)(e.Item.FindControl("hlHotelDetail"))).Text.ToString();
            string CityID = ((Literal)(e.Item.FindControl("ltlCityID"))).Text.ToString();
            
            this.SessRoot.CurrentHotelID = int.Parse(HotelID);
            this.SessRoot.CurrentHotelName = HotelName;
            this.SessRoot.SearchCityID = CityID;
            this.SessRoot.NewRequestable = ((HOTOMOTO.BUS.Enumerations.NewRequestable)int.Parse(e.CommandArgument.ToString()));

            Response.Redirect("HotelReservation.aspx?HotelID=" + HotelID);

        }
            
    }

    protected void rptHotelList_ItemDataBound(object sender, RepeaterItemEventArgs e) {
        if ((e.Item.ItemType == ListItemType.Item) || (e.Item.ItemType == ListItemType.AlternatingItem)) {
            ((Literal)e.Item.FindControl("ltlCurrLeft")).Text = this.SessRoot.CurrencySymbolLeft;
            ((Literal)e.Item.FindControl("ltlCurrRight")).Text = this.SessRoot.CurrencySymbolRight;

            int HotelID = int.Parse(((Literal)e.Item.FindControl("ltlHotelID")).Text);            
            DataTable dtRoomsDetail = ((DataTable)this.SessRoot.RoomsDetail);
            float TotalPrice = 0;
            DataTable dtPrice;
            foreach (DataRow dr in dtRoomsDetail.Rows) {
                dtPrice = HOTOMOTO.BUS.Rooms.GetHotelSearchRoomPrice(HotelID, this.SessRoot.CustomerID, Convert.ToInt16(dr["AdultCount"]), Convert.ToInt16(dr["ChildCount"]), Convert.ToInt16(dr["FirstChildAge"]), Convert.ToInt16(dr["SecondChildAge"]), this.SessRoot.ArrivalDate, this.SessRoot.DepartureDate);
                if (this.SessRoot.CurrencyID == HOTOMOTO.BUS.Enumerations.CurrencyTypes.USD)
                {
                    if (dtPrice.Rows[0]["USDTotal"] != DBNull.Value)
                    { TotalPrice += Convert.ToSingle(dtPrice.Rows[0]["USDTotal"]); }
                }
                else if (this.SessRoot.CurrencyID == HOTOMOTO.BUS.Enumerations.CurrencyTypes.EUR)
                {
                    if (dtPrice.Rows[0]["EURTotal"] != DBNull.Value)
                    { TotalPrice += Convert.ToSingle(dtPrice.Rows[0]["EURTotal"]); }
                }
                
            }

            ((Literal)e.Item.FindControl("ltlPrice")).Text = String.Format("{0:0.00}", TotalPrice);
        }
    }

}