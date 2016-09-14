using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Text.RegularExpressions;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

public partial class userControls_uctRoomPriceList : BaseUserControl {

	DataTable dtPrices;

	protected void Page_Load(object sender, EventArgs e) {
		if(!Page.IsPostBack) {
			ddlCities.DataTextField = "CityName";
			ddlCities.DataValueField = "CityID";
			ddlCities.DataSource = HOTOMOTO.BUS.CountriesAndCities.GetCitiesByCountryID(3,
				int.Parse(ConfigurationManager.AppSettings["DefaultCountryID"].ToString()));
			ddlCities.DataBind();
			ddlCities.Items.Insert(0, new System.Web.UI.WebControls.ListItem("Hepsi", "0"));

			ddlHotels.DataTextField = "HotelName";
			ddlHotels.DataValueField = "HotelID";
			ddlHotels.DataSource = HOTOMOTO.BUS.Hotels.GetHotelListByCity(3, int.Parse(ddlCities.SelectedValue));
			ddlHotels.DataBind();
			ddlHotels.Items.Insert(0, new System.Web.UI.WebControls.ListItem("Hepsi", "0"));

			ddlClasses.DataTextField = "Title";
			ddlClasses.DataValueField = "HotelClassID";
			ddlClasses.DataSource = HOTOMOTO.BUS.Hotels.GetHotelClasses(3);
			ddlClasses.DataBind();
			ddlClasses.Items.Insert(0, new System.Web.UI.WebControls.ListItem("Hepsi", "0"));

			ddlPriceLists.DataTextField = "PriceListName";
			ddlPriceLists.DataValueField = "RoomPriceListID";
			ddlPriceLists.DataSource = HOTOMOTO.BUS.Rooms.GetAllRoomPriceLists();
			ddlPriceLists.DataBind();
		}

		dtPrices = new DataTable();
		string[] columnNames = new string[] { "PriceListItemID", "HotelID", "HotelName", "RoomID", "RoomName", 
			"SNGEURPrice", "SNGUSDPrice", "DBLEURPrice", "DBLUSDPrice", "TRPEURPrice", "TRPUSDPrice" };
		foreach(string columnName in columnNames) {
			dtPrices.Columns.Add(columnName);
		}
	}

	protected void btnUpdate_Click(object sender, EventArgs e) {
		//check the validity of the input
		//start transaction
		//loop and save each field
		//end transaction
	}

	protected void rptRooms_ItemDataBound(object sender, RepeaterItemEventArgs e) {
		if((e.Item.ItemType == ListItemType.Item) || (e.Item.ItemType == ListItemType.AlternatingItem)) {
			foreach(string col in new string[] { "SNGEURPrice", "SNGUSDPrice", "DBLEURPrice", "DBLUSDPrice", "TRPEURPrice", "TRPUSDPrice" }) {
				((TextBox)e.Item.FindControl("txt" + col)).Text = string.Format("{0:0.00}", dtPrices.Rows[e.Item.ItemIndex][col].ToString());
			}
		}
	}
	protected void ddlCities_SelectedIndexChanged(object sender, EventArgs e) {
		ddlHotels.DataTextField = "HotelName";
		ddlHotels.DataValueField = "HotelID";
		ddlHotels.DataSource = HOTOMOTO.BUS.Hotels.GetHotelListByCity(3, int.Parse(ddlCities.SelectedValue));
		ddlHotels.DataBind();
		ddlHotels.Items.Insert(0, new System.Web.UI.WebControls.ListItem("Hepsi", "0"));
	}
	protected void btnSearch_Click(object sender, ImageClickEventArgs e) {
		int langid = this.SessRoot.LanguageID;
		int hotelid = int.Parse(this.ddlHotels.SelectedValue.ToString());
		int cityid = int.Parse(this.ddlCities.SelectedValue.ToString());
		int classid = int.Parse(this.ddlClasses.SelectedValue.ToString());

		DataTable dtTempHolder = HOTOMOTO.BUS.Rooms.GetRoomPriceListPrices(langid, hotelid, cityid, classid);

		int i = 0;
		foreach(DataRow dr in dtTempHolder.Rows) {
			float sngEURPrice = 0.0F;
			float sngUSDPrice = 0.0F;
			float dblEURPrice = 0.0F;
			float dblUSDPrice = 0.0F;
			float trpEURPrice = 0.0F;
			float trpUSDPrice = 0.0F;

			string roomPriceExp = dr["RoomPrices"].ToString();

			foreach(string parsedExp in roomPriceExp.Split('|')) {
				switch(parsedExp.Substring(0, parsedExp.IndexOf(':'))) {
					case "1":
						sngEURPrice = float.Parse(Regex.Matches(parsedExp, "\\d+")[1].Value);
						sngUSDPrice = float.Parse(Regex.Matches(parsedExp, "\\d+")[2].Value);
						break;
					case "2":
						dblEURPrice = float.Parse(Regex.Matches(parsedExp, "\\d+")[1].Value);
						dblUSDPrice = float.Parse(Regex.Matches(parsedExp, "\\d+")[2].Value);
						break;
					case "3":
						trpEURPrice = float.Parse(Regex.Matches(parsedExp, "\\d+")[1].Value);
						trpUSDPrice = float.Parse(Regex.Matches(parsedExp, "\\d+")[2].Value);
						break;
				}
			}

			dtPrices.Rows.Add(i, dr["HotelID"], dr["HotelName"], dr["RoomID"], dr["RoomName"],
				string.Format("{0:0.00}", sngEURPrice), string.Format("{0:0.00}", sngUSDPrice), 
				string.Format("{0:0.00}", dblEURPrice), string.Format("{0:0.00}", dblUSDPrice), 
				string.Format("{0:0.00}", trpEURPrice), string.Format("{0:0.00}", trpUSDPrice));
		}
		dtTempHolder = null;

		rptRooms.DataSource = dtPrices.DefaultView;
		rptRooms.DataBind();
	}
}
