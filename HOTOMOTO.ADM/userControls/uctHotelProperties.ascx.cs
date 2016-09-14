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

public partial class userControls_uctHotelProperties : BaseUserControl {
	
	private int hotelID = 0;

	protected void Page_Load(object sender, EventArgs e) {
		if(Request.QueryString["hotelid"] != null)
			this.hotelID = int.Parse(Request.QueryString["hotelid"]);

		if(!Page.IsPostBack) {
			cblHotelProperties.DataValueField = "HotelPropertyID";
			cblHotelProperties.DataTextField = "Property";
			cblHotelProperties.DataSource = HOTOMOTO.APEX.HotelProperties.GetAllHotelPropertiesDataSet(this.SessRoot.LanguageID).Tables[0];
			cblHotelProperties.DataBind();
			if(this.hotelID != 0)
				LoadHotelProperties(hotelID);
		}
	}

	public void LoadHotelProperties(int HotelID) {
		DataTable dtHotelProperties = new DataTable();
		dtHotelProperties = HOTOMOTO.BUS.Hotels.GetHotelProperties(SessRoot.LanguageID, HotelID);

		foreach(DataRow drHotelProperty in dtHotelProperties.Rows) {
			foreach(ListItem liHotelProperty in cblHotelProperties.Items) {
				if(Convert.ToInt32(drHotelProperty["HotelPropertyID"]) == int.Parse(liHotelProperty.Value))
					liHotelProperty.Selected = true;
			}
		}
	}

	public void SaveHotelProperties(int HotelID) {
		foreach(ListItem liHotelProperty in cblHotelProperties.Items) {
			if(liHotelProperty.Selected) {
				HOTOMOTO.APEX.Hotels_HotelProperties HotelProperty = new HOTOMOTO.APEX.Hotels_HotelProperties();
				HotelProperty.HotelID = HotelID;
				HotelProperty.HotelPropertyID = Convert.ToInt32(liHotelProperty.Value);
				HotelProperty.Save();
			}
		}
	}

	public void UpdateHotelProperies() {
		DataTable dtHotelProperties = new DataTable();
		dtHotelProperties = HOTOMOTO.BUS.Hotels.GetHotelProperties(SessRoot.LanguageID, this.hotelID);

		foreach(ListItem liHotelProperty in cblHotelProperties.Items)
			if(liHotelProperty.Selected) {
				bool IsFormerProperty = false;
				foreach(DataRow drRoomProperty in dtHotelProperties.Rows)
					if(Convert.ToInt32(drRoomProperty["HotelPropertyID"]) == Convert.ToInt32(liHotelProperty.Value)) {
						IsFormerProperty = true;
						break;
					}
				if(!IsFormerProperty) {
					HOTOMOTO.APEX.Hotels_HotelProperties RoomProperty = new HOTOMOTO.APEX.Hotels_HotelProperties();
					RoomProperty.HotelID = this.hotelID;
					RoomProperty.HotelPropertyID = Convert.ToInt32(liHotelProperty.Value);
					RoomProperty.Save();
				}
			} else {
				bool IsFormerProperty = false;
				foreach(DataRow drRoomProperty in dtHotelProperties.Rows)
					if(Convert.ToInt32(drRoomProperty["HotelPropertyID"]) == Convert.ToInt32(liHotelProperty.Value)) {
						IsFormerProperty = true;
						break;
					}
				if(IsFormerProperty) {
					HOTOMOTO.BUS.Hotels.RemovePropertyFromHotel(this.hotelID, Convert.ToInt32(liHotelProperty.Value));
				}
			}
	}
}
