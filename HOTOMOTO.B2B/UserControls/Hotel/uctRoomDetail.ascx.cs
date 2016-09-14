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

public partial class UserControls_Hotel_uctRoomDetail : BaseUserControl {

    private int m_RoomID;

    protected void Page_Load(object sender, EventArgs e) {

        if (!IsPostBack) {

            if ((Request.QueryString["RoomID"] != null) && (CARETTA.COM.Util.IsNumeric(Request.QueryString["RoomID"]))) {
                this.m_RoomID = int.Parse(Request.QueryString["RoomID"]);
                pnlRoomList.Visible = false;
                pnlRoomDetail.Visible = true;


                FillRoomDetail();           //Oda Bilgilerini Yükle

                FillImages();               //Resimleri Yükle

                FillProperties();           //Oda Propertilerini Yükle

                //FillRoomPrices();           //Oda Fiyatlarýný Yükle

            }
            else {
                pnlRoomList.Visible = true;
                pnlRoomDetail.Visible = false;

                FillRoomList();             //Oda Listesini Yükle
            }

        }//IsPostBack

    }

    void FillRoomList() {
        rptRoomList.DataSource = HOTOMOTO.BUS.Rooms.GetRoomAvailability(this.SessRoot.LanguageID, this.SessRoot.CurrentHotelID, this.SessRoot.ArrivalDate, this.SessRoot.DepartureDate);
        rptRoomList.DataBind();
    }

    void FillRoomDetail() {
        HOTOMOTO.BUS.Rooms objRoom = new HOTOMOTO.BUS.Rooms(m_RoomID, this.SessRoot.LanguageID);
        ltlRoomName.Text = objRoom.RoomName;
        ltlDescription.Text = objRoom.Description;
    }

    void FillImages() {
        
        DataTable dtImages = HOTOMOTO.BUS.Rooms.GetRoomImages(m_RoomID);

        if (dtImages.Rows.Count > 0) {
            imgBigPicture.ImageUrl = imgBigPicture.ImageUrl.Replace("RoomDefault.jpg", dtImages.Rows[0]["FileName"].ToString());
        }

        if (dtImages.Rows.Count > 1) {
            imgSmallPicture.ImageUrl = imgSmallPicture.ImageUrl.Replace("RoomDefault.jpg", dtImages.Rows[1]["FileName"].ToString());
        } else { 
            imgSmallPicture.Visible = false; }

    }

    void FillProperties() {
        DataTable dtProperties = HOTOMOTO.BUS.Rooms.GetPropertiesByRoomID(this.SessRoot.LanguageID, m_RoomID);
        GenerateHTML(dtProperties);
    }

    //void FillRoomPrices() {
    //    DataTable dtRoomPrices = HOTOMOTO.BUS.Rooms.GetRoomPriceAndAvailability(m_RoomID, this.SessRoot.CustomerID, this.SessRoot.ArrivalDate, this.SessRoot.DepartureDate) ;
    //    if (this.SessRoot.CurrencyID == HOTOMOTO.BUS.Enumerations.CurrencyTypes.USD) {
    //        dtRoomPrices.Columns.Remove("EURPrice");
    //        dtRoomPrices.Columns["USDPrice"].ColumnName = dtRoomPrices.Columns["USDPrice"].ColumnName.Replace("USD", "");
    //    }
    //    else if (this.SessRoot.CurrencyID == HOTOMOTO.BUS.Enumerations.CurrencyTypes.EUR) {
    //        dtRoomPrices.Columns.Remove("USDPrice");
    //        dtRoomPrices.Columns["EURPrice"].ColumnName = dtRoomPrices.Columns["EURPrice"].ColumnName.Replace("EUR", "").ToString();
    //    }
    //    rptPrices.DataSource = dtRoomPrices;
    //    rptPrices.DataBind();
    //}

    private void GenerateHTML(DataTable dtProperties) {
        StringBuilder sbProperties = new StringBuilder();

        sbProperties.Append("<table cellpadding=3 cellspacing=3>");

        for (int i = 0; i < dtProperties.Rows.Count; i++) {
            sbProperties.Append("<tr>");
            for (int j = 1; j <= 2; j++) {
                if (dtProperties.Rows.Count - 1 < i) {
                    sbProperties.Append("<td colspan=3>");
                    break;
                }
                else {
                    sbProperties.Append("<td style='padding-right:4px;'>");
                    sbProperties.Append("<img src='Images/Properties/RoomProperties/");
                    sbProperties.Append(dtProperties.Rows[i]["IconFileName"].ToString());
                    sbProperties.Append("' ");
                    sbProperties.Append("</td>");
                    sbProperties.Append("<td>");
                    sbProperties.Append(dtProperties.Rows[i]["Property"].ToString());
                    sbProperties.Append("</td>");
                    sbProperties.Append("<td width='10px'></td>");
                    i++;
                }
            }
            sbProperties.Append("</tr>");
            i--;
        }

        sbProperties.Append("</table>");

        dvProperties.InnerHtml = sbProperties.ToString();
    }

    protected void rptPrices_ItemDataBound(object sender, RepeaterItemEventArgs e) {
        if ((e.Item.ItemType == ListItemType.Item) || (e.Item.ItemType==ListItemType.AlternatingItem)) {
            ((Literal)e.Item.FindControl("ltlCurrencyLeft")).Text = this.SessRoot.CurrencySymbolLeft;
            ((Literal)e.Item.FindControl("ltlCurrencyRight")).Text = this.SessRoot.CurrencySymbolRight;
        }
    }

}
