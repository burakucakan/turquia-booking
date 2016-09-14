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

public partial class userControls_uctHotelPlaceDistances : BaseUserControl
{
	int hotelID = 0;

	protected void Page_Load(object sender, EventArgs e) {

		if(Request.QueryString["hotelid"] != null)
			hotelID = int.Parse(Request.QueryString["hotelid"]);

		if(!Page.IsPostBack) {
			gvHotelPlaceDistances.DataSource = HOTOMOTO.APEX.Places.GetAllPlacesDataSet(this.SessRoot.LanguageID).Tables[0];
			gvHotelPlaceDistances.DataBind();

			if(hotelID > 0) {
				DataTable dtHotelPlaceDistance = new DataTable();
				dtHotelPlaceDistance = HOTOMOTO.BUS.Hotels.GetHotelPlacesAndDistances(SessRoot.LanguageID, hotelID);
				foreach(GridViewRow gvrHotelPlaceDistance in gvHotelPlaceDistances.Rows)
					foreach(DataRow drHotelPlaceDistance in dtHotelPlaceDistance.Rows)
						if(Convert.ToInt32(drHotelPlaceDistance["PlaceID"]) == Convert.ToInt32(gvrHotelPlaceDistance.Cells[1].Text)) {
							if(Convert.ToInt32(drHotelPlaceDistance["Distance"]) > 0)
								((TextBox)gvrHotelPlaceDistance.Cells[2].FindControl("txtHotelPlaceDistance")).Text = drHotelPlaceDistance["Distance"].ToString();
							if(Convert.ToInt32(drHotelPlaceDistance["Time"]) > 0)
								((TextBox)gvrHotelPlaceDistance.Cells[4].FindControl("txtHotelPlaceTime")).Text = drHotelPlaceDistance["Time"].ToString();
						}
			}
		}
	}
    
    protected void gvHotelPlaceDistances_DataBound(object sender, EventArgs e)
    {
        gvHotelPlaceDistances.Columns[1].Visible = false;
    }

    public void SetValidationGroup(string strValidationGroup)
    {
        foreach (GridViewRow gvr in gvHotelPlaceDistances.Rows)
        {
            ((RangeValidator)gvr.FindControl("ravHotelPlaceDistance")).ValidationGroup = strValidationGroup;
            ((RangeValidator)gvr.FindControl("ravHotelPlaceTime")).ValidationGroup = strValidationGroup;
        }
    }

    public void SaveHotelPlaceDistances(int HotelID)
    {
        foreach (GridViewRow gvr in gvHotelPlaceDistances.Rows)
        {
            if (!(((TextBox)gvr.Cells[2].FindControl("txtHotelPlaceDistance")).Text.Equals("")) && !(((TextBox)gvr.Cells[4].FindControl("txtHotelPlaceTime")).Text.Equals("")))
            {
                HOTOMOTO.APEX.HotelPlaceDistances hpd = new HOTOMOTO.APEX.HotelPlaceDistances();
                hpd.HotelID = HotelID;
                hpd.PlaceID = Convert.ToInt32(gvr.Cells[1].Text);
                hpd.Distance = Convert.ToInt32(((TextBox)gvr.Cells[2].FindControl("txtHotelPlaceDistance")).Text);
                hpd.Time = Convert.ToInt32(((TextBox)gvr.Cells[4].FindControl("txtHotelPlaceTime")).Text);
                hpd.Save();
            }// alta gerek olmayabilir
            else if (!(((TextBox)gvr.Cells[2].FindControl("txtHotelPlaceDistance")).Text.Equals("")))
            {
                HOTOMOTO.APEX.HotelPlaceDistances hpd = new HOTOMOTO.APEX.HotelPlaceDistances();
                hpd.HotelID = HotelID;
                hpd.PlaceID = Convert.ToInt32(gvr.Cells[1].Text);
                hpd.Distance = Convert.ToInt32(((TextBox)gvr.Cells[2].FindControl("txtHotelPlaceDistance")).Text);
                hpd.Time = 0;
                hpd.Save(); 
            }
            else if (!(((TextBox)gvr.Cells[2].FindControl("txtHotelPlaceTime")).Text.Equals("")))
            {
                HOTOMOTO.APEX.HotelPlaceDistances hpd = new HOTOMOTO.APEX.HotelPlaceDistances();
                hpd.HotelID = HotelID;
                hpd.PlaceID = Convert.ToInt32(gvr.Cells[1].Text);
                hpd.Distance = 0;
                hpd.Time = Convert.ToInt32(((TextBox)gvr.Cells[4].FindControl("txtHotelPlaceTime")).Text);
                hpd.Save();
            }
        }
    }

    public void UpdateHotelPlaceDistance()
    {
        //DataTable dtHotelPlaceDistance = new DataTable();
        //dtHotelPlaceDistance = HOTOMOTO.BUS.Hotels.GetHotelPlacesAndDistances(SessRoot.LanguageID, hotelID);

        HOTOMOTO.BUS.Hotels.RemovePlaceDistanceByHotelID(hotelID);

        SaveHotelPlaceDistances(hotelID);
       
    }
    
    protected void gvHotelPlaceDistances_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvHotelPlaceDistances.Columns[1].Visible = true;
        gvHotelPlaceDistances.PageIndex = e.NewPageIndex;
		gvHotelPlaceDistances.DataSource = HOTOMOTO.APEX.Places.GetAllPlacesDataSet(this.SessRoot.LanguageID).Tables[0];
		gvHotelPlaceDistances.DataBind();
    }
}
