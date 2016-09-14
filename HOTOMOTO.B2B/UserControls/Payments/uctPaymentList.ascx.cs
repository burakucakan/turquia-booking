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

public partial class UserControls_Payments_uctPaymentList : BaseUserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    public string ListTitle
    {
        get { return ltlRptTitle.Text; }
        set { ltlRptTitle.Text = value; }
    }

    public void FillPayments(string ReservationType, string UserID)
    {
        DataTable dtPayments = HOTOMOTO.BUS.Reservation.GetReservationByCustomerID(this.SessRoot.LanguageID, this.SessRoot.CustomerID, UserID, ReservationType);
        if (dtPayments.Rows.Count > 0)
        {
            UctPaging1.GeneratePager(ref dtPayments, ref rptPayments, 10);

            ltlError.Visible = false;
            rptPayments.Visible = true;
        }
        else
        {
            ltlError.Text = "! Rezervasyonunuz bulunmamaktadýr !";
            ltlError.Visible = true;
            rptPayments.Visible = false;
        }
    }

    protected void rptPayments_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if ((e.Item.ItemType == ListItemType.Item) || (e.Item.ItemType == ListItemType.AlternatingItem))
        {
            ((Literal)e.Item.FindControl("ltlCurrLeft")).Text = this.SessRoot.CurrencySymbolLeft;
            ((Literal)e.Item.FindControl("ltlCurrRight")).Text = this.SessRoot.CurrencySymbolRight;

            // Iconlarý Düzenle 
            ((Label)e.Item.FindControl("ltlPrice" + this.SessRoot.CurrencyID.ToString())).Visible = true;

            int ResType = int.Parse(((Literal)e.Item.FindControl("ltlReservationType")).Text);

            if ((ResType & (int)HOTOMOTO.BUS.Enumerations.ReservationTypes.Hotel) > 0)
            {
                ((Image)e.Item.FindControl("imgHotel")).Visible = true;
            }

            if ((ResType & (int)HOTOMOTO.BUS.Enumerations.ReservationTypes.Tour) > 0)
            {
                ((Image)e.Item.FindControl("imgTour")).Visible = true;
            }

            if ((ResType & (int)HOTOMOTO.BUS.Enumerations.ReservationTypes.Transfer) > 0)
            {
                ((Image)e.Item.FindControl("imgTransfer")).Visible = true;
            }

        }
    }

    protected void rptPayments_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        if ((e.Item.ItemType == ListItemType.Item) || (e.Item.ItemType == ListItemType.AlternatingItem))
        {

            Session["ReservationID"] = e.CommandArgument;

            int ResType = int.Parse(((Literal)e.Item.FindControl("ltlReservationType")).Text);

            if ((ResType & (int)HOTOMOTO.BUS.Enumerations.ReservationTypes.Hotel) > 0)
            {

                DataTable dtHotel = InitializeHotelDt();
                DataTable dtRoom = InitializeRoomDt();
                DataTable dtDBRoom = HOTOMOTO.BUS.Reservation.GetReservationRooms(this.SessRoot.LanguageID, Convert.ToInt32(Session["ReservationID"]));

                HOTOMOTO.APEX.Reservations objApRes;
                HOTOMOTO.APEX.Hotels objApHotel;
                int drNo = 0;
                foreach (DataRow dr in dtDBRoom.Rows)
                {
                    if ((drNo < 1) || (dtDBRoom.Rows[drNo]["HotelID"].ToString() != dtDBRoom.Rows[drNo - 1]["HotelID"].ToString()))
                    {
                        objApHotel = new HOTOMOTO.APEX.Hotels();
                        objApHotel.Load(Convert.ToInt32(dr["HotelID"]));

                        objApRes = new HOTOMOTO.APEX.Reservations();
                        objApRes.Load(Convert.ToInt32(Session["ReservationID"]));

                        DataRow drHotel = dtHotel.NewRow();
                        drHotel["HotelID"] = dr["HotelID"];
                        drHotel["HotelName"] = objApHotel.GetHotelName(this.SessRoot.LanguageID);
                        drHotel["ArrivalDate"] = dr["ReservationStartDate"];
                        drHotel["DepartureDate"] = dr["ReservationEndDate"];
                        drHotel["BookingStatus"] = Enum.GetName(typeof(HOTOMOTO.BUS.Enumerations.NewRequestable), objApRes.ReservationStatus);
                        dtHotel.Rows.Add(drHotel);
                    }
                    drNo++;

                    DataRow drRoom = dtRoom.NewRow();
                    drRoom["RowID"] = dr["RowID"];
                    drRoom["RoomID"] = dr["RoomID"];
                    drRoom["Capacity"] = dr["Capacity"];
                    drRoom["RoomName"] = dr["RoomName"];
                    drRoom["BedTypeID"] = dr["BedTypeID"];
                    drRoom["BedTypeName"] = dr["BedTypeName"];
                    drRoom["PricePerson"] = dr["PricePerson" + this.SessRoot.CurrencyID.ToString()];
                    drRoom["RoomTotalPrice"] = dr["RoomTotalPrice" + this.SessRoot.CurrencyID.ToString()];
                    dtRoom.Rows.Add(drRoom);
                }
                Session["Room"] = dtRoom;
                Session["Hotel"] = dtHotel;

                DataTable dtGuest = InitializeGuestDt();
                DataTable dtDBGuest = HOTOMOTO.BUS.Reservation.GetReservationGuests(Convert.ToInt32(Session["ReservationID"]));

                foreach (DataRow dr in dtDBGuest.Rows)
                {
                    DataRow drGuest = dtGuest.NewRow();
                    drGuest["RowID"] = dr["RowID"];
                    drGuest["RoomRowID"] = dr["RoomRowID"];
                    drGuest["GuestNameTitle"] = dr["GuestNameTitle"];
                    drGuest["GuestName"] = dr["GuestName"];
                    drGuest["T1"] = "false";
                    drGuest["T2"] = "false";
                    drGuest["T3"] = "false";
                    drGuest["T4"] = "false";
                    dtGuest.Rows.Add(drGuest);
                }
                Session["Guest"] = dtGuest;

                drNo = 0;

                DataTable dtRoomDetail = InitializeRoomDetailDt();
                int AdultCount = 0;
                int ChildCount = 0;
                int FirstChildAge = 0;
                int SecondChildAge = 0;
                foreach (DataRow dr in dtGuest.Rows)
                {
                    if ((drNo + 1 < dtGuest.Rows.Count) && (dtGuest.Rows[drNo]["RoomRowID"].ToString() == dtGuest.Rows[drNo + 1]["RoomRowID"].ToString()))
                    {
                        if (!CARETTA.COM.Util.IsNumeric(dr["GuestNameTitle"])) { AdultCount++; }
                        else
                        {
                            ChildCount++;
                            if (ChildCount == 1) { FirstChildAge = Convert.ToInt32(dtGuest.Rows[drNo]["GuestNameTitle"]); }
                            else { SecondChildAge = Convert.ToInt32(dtGuest.Rows[drNo]["GuestNameTitle"]); }
                        }
                    }
                    else
                    {
                        if (!CARETTA.COM.Util.IsNumeric(dr["GuestNameTitle"])) { AdultCount++; }
                        else { ChildCount++; }

                        DataRow drRoomDetail = dtRoomDetail.NewRow();
                        drRoomDetail["RoomIndex"] = Convert.ToInt32(dr["RoomRowID"]);
                        drRoomDetail["AdultCount"] = AdultCount;
                        drRoomDetail["ChildCount"] = ChildCount;
                        drRoomDetail["FirstChildAge"] = FirstChildAge;
                        drRoomDetail["SecondChildAge"] = SecondChildAge;
                        dtRoomDetail.Rows.Add(drRoomDetail);
                        AdultCount = 0;
                        ChildCount = 0;
                    }
                    drNo++;
                }

                this.SessRoot.RoomsDetail = dtRoomDetail;
            }
            
            if ((ResType & (int)HOTOMOTO.BUS.Enumerations.ReservationTypes.Tour) > 0)
            {
                DataTable dtTour = InitializeTourDt();
                DataTable dtDBTour = HOTOMOTO.BUS.Reservation.GetTourReservation(this.SessRoot.LanguageID, Convert.ToInt32(Session["ReservationID"]));

                foreach (DataRow dr in dtDBTour.Rows)
                {
                    DataRow drTour = dtTour.NewRow();
                    drTour["RowID"] = dr["RowID"];
                    drTour["TourID"] = dr["TourID"];
                    drTour["TourType"] = dr["TourType"];
                    drTour["TourPrice"] = dr["TourPrice" + this.SessRoot.CurrencyID.ToString()];
                    drTour["AdultCount"] = dr["AdultCount"];
                    drTour["ChildCount"] = dr["ChildCount"];
                    drTour["TourMinCapacity"] = dr["TourMinCapacity"];
                    drTour["TourName"] = dr["TourName"];
                    if (((HOTOMOTO.BUS.Enumerations.TourTypes)(Convert.ToInt16(dr["TourType"]))) == HOTOMOTO.BUS.Enumerations.TourTypes.Excursion)
                    {
                        drTour["TourDate"] = CARETTA.COM.Util.Left(dr["TourDateStart"].ToString(), 10);
                    }
                    else if (((HOTOMOTO.BUS.Enumerations.TourTypes)(Convert.ToInt16(dr["TourType"]))) == HOTOMOTO.BUS.Enumerations.TourTypes.Circuits) {
                        drTour["TourDate"] = CARETTA.COM.Util.Left(dr["TourDateStart"].ToString(), 10) + " - " + CARETTA.COM.Util.Left(dr["TourDateEnd"].ToString(), 10);
                    }
                    
                    dtTour.Rows.Add(drTour);
                }
                Session["Tour"] = dtTour;
            }

            if ((ResType & (int)HOTOMOTO.BUS.Enumerations.ReservationTypes.Transfer) > 0)
            {

                DataTable dtTransfer = InitializeTransferDt();
                DataTable dtDBTransfer = HOTOMOTO.BUS.Reservation.GetTransferReservation(this.SessRoot.LanguageID, Convert.ToInt32(Session["ReservationID"]));

                foreach (DataRow dr in dtDBTransfer.Rows)
                {
                    DataRow drTransfer = dtTransfer.NewRow();
                    drTransfer["TransferDirection"] = dr["TransferDirection"];
                    drTransfer["TransferType"] = dr["TransferType"];
                    drTransfer["GuestCount"] = dr["GuestCount"];
                    drTransfer["GuidancePrice"] = dr["GuidancePrice" + this.SessRoot.CurrencyID.ToString()];
                    drTransfer["Price"] = dr["Price" + this.SessRoot.CurrencyID.ToString()];
                    drTransfer["PortID"] = dr["PortID"];
                    drTransfer["PortName"] = dr["PortName"];
                    drTransfer["Notes"] = dr["Notes"];
                    drTransfer["Date"] = dr["Date"];
                    dtTransfer.Rows.Add(drTransfer);
                }
                Session["Transfer"] = dtTransfer;
            }

            Session["ReservationCode"] = e.CommandName;
            Session["Reservations"] = null;

            Response.Redirect("~/" + ConfigurationManager.AppSettings["SummaryPage"].ToString());
        }
    }

    private DataTable InitializeTransferDt()
    {
        DataTable dtTransfer = new DataTable();
        dtTransfer.Columns.AddRange(new DataColumn[] { 
                                new DataColumn("TransferDirection"), new DataColumn("TransferType"), new DataColumn("GuestCount"), 
                                new DataColumn("GuidancePrice"), new DataColumn("Price"), new DataColumn("PortID"), 
                                new DataColumn("PortName"), new DataColumn("Notes"), new DataColumn("Date") });
        return dtTransfer;
    }

    private DataTable InitializeTourDt()
    {
        DataTable dtTour = new DataTable();
        dtTour.Columns.AddRange(new DataColumn[] { 
                                new DataColumn("RowID"), new DataColumn("TourID"), new DataColumn("TourType"), 
                                new DataColumn("TourPrice"), new DataColumn("AdultCount"), new DataColumn("ChildCount"), 
                                new DataColumn("TourMinCapacity"), new DataColumn("TourName"), new DataColumn("TourDate") });
        return dtTour;
    }

    private DataTable InitializeRoomDt()
    {
        DataTable dtRoom = new DataTable();
        dtRoom.Columns.AddRange(new DataColumn[] { 
                                new DataColumn("RowID"), new DataColumn("RoomID"), new DataColumn("Capacity"), 
                                new DataColumn("RoomName"), new DataColumn("BedTypeID"), new DataColumn("BedTypeName"), 
                                new DataColumn("PricePerson"), new DataColumn("RoomTotalPrice") });
        return dtRoom;
    }

    private DataTable InitializeGuestDt()
    {
        DataTable dtGuest = new DataTable();
        dtGuest.Columns.AddRange(new DataColumn[] { 
                                new DataColumn("RowID"), new DataColumn("RoomRowID"), new DataColumn("GuestNameTitle"), 
                                new DataColumn("GuestName"), new DataColumn("T1"), new DataColumn("T2"), 
                                new DataColumn("T3"), new DataColumn("T4") });
        return dtGuest;
    }

    private DataTable InitializeHotelDt()
    {
        DataTable dtHotel = new DataTable();
        dtHotel.Columns.AddRange(new DataColumn[] { 
                                new DataColumn("HotelID"), new DataColumn("HotelName"), new DataColumn("ArrivalDate"), 
                                new DataColumn("DepartureDate"), new DataColumn("BookingStatus")  });
        return dtHotel;
    }

    private DataTable InitializeRoomDetailDt()
    {
        DataTable RoomDetailDt = new DataTable();
        RoomDetailDt.Columns.AddRange(new DataColumn[] { 
                                new DataColumn("RoomIndex"), new DataColumn("AdultCount"), new DataColumn("ChildCount"), 
                                new DataColumn("FirstChildAge"), new DataColumn("SecondChildAge")  });
        return RoomDetailDt;
    }

}