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
using HOTOMOTO.BUS;

public partial class userControls_Reservation_uctReservationApproval : BaseUserControl 
{

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            CARETTA.COM.DDLHelper.BindDDL(ref ddlH, HOTOMOTO.APEX.Hotels.GetAllHotelsDataSet(this.SessRoot.LanguageID).Tables[0], "HotelName", "HotelID", "0", "Tümü", "0");

            CARETTA.COM.DDLHelper.BindDDL(ref ddlT, HOTOMOTO.BUS.Tour.GetToursWithDetails(SessRoot.LanguageID), "Name", "TourID", "0", "Tümü", "0");

            CARETTA.COM.DDLHelper.BindDDL(ref ddlTr, HOTOMOTO.BUS.Transfer.GetPortDetails(SessRoot.LanguageID, 0), "Title", "PortID", "0", "Tümü", "0");

            UctSuggest1.DataSource = HOTOMOTO.APEX.Customers.GetAllCustomersDataSet().Tables[0];
            UctSuggest1.DataTextField = "CompanyName";
            UctSuggest1.DataValueField = "CustomerID";
            UctSuggest1.DataBindLb();

            ddlR.Items.Add(new ListItem("Hotel Seçiniz...", "0"));

            calBSDate.SetDate(DateTime.Now.AddMonths(-1));
            calREDate.SetDate(DateTime.Now.AddYears(1));
        }
    }




    protected void btnSearch_Click(object sender, EventArgs e)
    {
        GetReservations(1, true);
    }


    void GetReservations(int nrPage, bool calculateNrPages)
    {
        string strReservationType = "";
        int intNrPages = 0;
        DataTable dt;
        bool blnOthersSelected = false;

        int intTourID = 0;
        int intHotelID = 0;
        int intPortID = 0;
        int intRoomID = 0;

        intTourID = Convert.ToInt32(ddlT.SelectedValue);
        intRoomID = Convert.ToInt32(ddlR.SelectedValue);
        intHotelID = Convert.ToInt32(ddlH.SelectedValue);
        intPortID = Convert.ToInt32(ddlTr.SelectedValue);

        if (intTourID == 0 && (intRoomID != 0 || intHotelID != 0 || intPortID != 0))
        {
            intTourID = -1;
        }

        if (intPortID == 0 && (intRoomID != 0 || intHotelID != 0 || intTourID != 0))
        {
            intPortID = -1;
        }

        if ((intRoomID == 0 && intHotelID == 0) && (intTourID != 0 || intPortID != 0))
        {
            intRoomID = -1;
            intHotelID = -1;
        }

        strReservationType = "%";

        if (calculateNrPages)
        {
            intNrPages = HOTOMOTO.APEX.Custom.SPExec_Reservation.GetReservationsForApproval(this.SessRoot.LanguageID,
                Convert.ToInt32(UctSuggest1.SelectedValue),
                strReservationType,
                intHotelID,
                intTourID ,
                intPortID ,
                intRoomID,
                calBSDate.GetDate(),
                calBEDate.GetDate(),
                calRSDate.GetDate(),
                calREDate.GetDate(),
                10000,
                1).Rows.Count;

            intNrPages = Convert.ToInt32(Math.Ceiling(((decimal)intNrPages / (decimal)GridView1.PageSize)));
            ddlPages.Items.Clear();
            for (int i = 0; i < intNrPages; i++)
            {
                ddlPages.Items.Add(new ListItem(Convert.ToString(i + 1), Convert.ToString(i + 1)));
            }
        }

        dt = HOTOMOTO.APEX.Custom.SPExec_Reservation.GetReservationsForApproval(this.SessRoot.LanguageID,
            Convert.ToInt32(UctSuggest1.SelectedValue),
            strReservationType,
            intHotelID,
                intTourID,
                intPortID,
                intRoomID,
            calBSDate.GetDate(),
            calBEDate.GetDate(),
            calRSDate.GetDate(),
            calREDate.GetDate(),
            GridView1.PageSize,
            nrPage);
        GridView1.DataSource = dt;
        GridView1.DataBind();

        foreach (GridViewRow gvRow in GridView1.Rows)
        {
            if (((HOTOMOTO.BUS.Enumerations.NewRequestable)dt.Rows[gvRow.RowIndex]["ReservationStatus"]) == HOTOMOTO.BUS.Enumerations.NewRequestable.OnRequest)
            {
                ((Label)gvRow.FindControl("lblS")).Text = "Oda K.";
            }
        }

    }

    protected void ddlPages_SelectedIndexChanged(object sender, EventArgs e)
    {
        GetReservations(Convert.ToInt32(ddlPages.SelectedValue), false);
    }

    protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "Approve")
        {
            HOTOMOTO.APEX.Custom.SPExec_Reservation.ReservationApproval(Convert.ToInt32(e.CommandArgument), 1, "", DateTime.Now, 0, 0, 0, 0);
        } else
        {
            HOTOMOTO.APEX.Custom.SPExec_Reservation.ReservationApproval(Convert.ToInt32(e.CommandArgument), 0, "", DateTime.Now, 0, 0, 0, 0);
        }
        GetReservations(1, false);
    }
    protected void ddlH_SelectedIndexChanged1(object sender, EventArgs e)
    {
        if (ddlH.SelectedValue == "0")
        {
            ddlR.Items.Clear();
            ddlR.Items.Add(new ListItem("Hotel Seçiniz...", "0"));
        }
        else
        {
            CARETTA.COM.DDLHelper.BindDDL(ref ddlR, HOTOMOTO.APEX.Custom.SPExec_Room.GetRoomsByHotelID(this.SessRoot.LanguageID, Convert.ToInt32(ddlH.SelectedValue)), "RoomName", "RoomID", "0", "-- Hotelin Tüm Odalarý --", "0");
        }
    }
}
