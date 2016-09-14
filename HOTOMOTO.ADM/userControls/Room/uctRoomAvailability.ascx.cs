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

public partial class userControls_Room_uctRoomAvailability : BaseUserControl 
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
          
            CARETTA.COM.DDLHelper.BindDDL(ref ddlPL, HOTOMOTO.APEX.RoomPriceLists.GetAllRoomPriceListsDataSet().Tables[0], "PriceListName", "RoomPriceListID","");

            CARETTA.COM.DDLHelper.BindDDL(ref ddlHC, HOTOMOTO.APEX.HotelChains.GetAllHotelChainsDataSet(this.SessRoot.LanguageID).Tables[0], "ChainName", "HotelChainID", "0", "Tümü","0");

            CARETTA.COM.DDLHelper.BindDDL(ref ddlH, HOTOMOTO.APEX.Hotels.GetAllHotelsDataSet(this.SessRoot.LanguageID).Tables[0], "HotelName", "HotelID", "0", "Tümü", "0");

            ddlR.Items.Add(new ListItem("Hotel Seçiniz...", "0"));
            calEndDate.SetDate(DateTime.Now.AddMonths(1));

        }

    }
    
    protected void ddlHC_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlHC.SelectedValue == "0")
        {
            CARETTA.COM.DDLHelper.BindDDL(ref ddlH, HOTOMOTO.APEX.Hotels.GetAllHotelsDataSet(this.SessRoot.LanguageID).Tables[0], "HotelName", "HotelID", "0", "-- Tüm Hoteller --", "0");
        }
        else
        {
            CARETTA.COM.DDLHelper.BindDDL(ref ddlH, HOTOMOTO.APEX.Custom.SPExec_Hotel.GetHotelsByHotelChainID(this.SessRoot.LanguageID, Convert.ToInt32(ddlHC.SelectedValue)), "HotelName", "HotelID", "0", "-- Bu Listedeki Hoteller --", "0");
        }
    }
    protected void ddlH_SelectedIndexChanged(object sender, EventArgs e)
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
    protected void btnPrepare_Click(object sender, EventArgs e)
    {
        GenerateMultiUpdateTable();
    }

  

    private void GenerateMultiUpdateTable()
    {
        DataTable dtRes;
        DataRow drRes;
              

        dtRes = new DataTable();
        dtRes.Columns.Add("StartDate", Type.GetType("System.DateTime"));
        dtRes.Columns.Add("EndDate", Type.GetType("System.DateTime"));
        dtRes.Columns.Add("PriceUSD");
        dtRes.Columns.Add("PriceEUR");

        if (ddlR.SelectedIndex == 0)
        {
            return;
        }

        DateTime datStartDate;
        DateTime datEndDate;

        datStartDate = calStartDate.GetDate();
        datEndDate = calEndDate.GetDate();

        if (ddlG.SelectedValue == "day")
        {
            while (DateTime.Compare(datStartDate, datEndDate) <= 0)
            {
                drRes = dtRes.NewRow();
                drRes["StartDate"] = datStartDate;
                drRes["EndDate"] = datStartDate;
                drRes["PriceUSD"] = 0;
                drRes["PriceEUR"] = 0;
                dtRes.Rows.Add(drRes);
                datStartDate = datStartDate.AddDays(1);
            }
        }
        else if (ddlG.SelectedValue == "week")
        {
            while (datStartDate.DayOfWeek != DayOfWeek.Monday)
            {
                datStartDate = datStartDate.AddDays(-1);
            }
            while (DateTime.Compare(datStartDate, datEndDate) < 0)
            {
                drRes = dtRes.NewRow();
                drRes["StartDate"] = datStartDate;
                drRes["EndDate"] = datStartDate.AddDays(7);
                drRes["PriceUSD"] = 0;
                drRes["PriceEUR"] = 0;
                dtRes.Rows.Add(drRes);
                datStartDate = datStartDate.AddDays(7);
            }
        }
        else if (ddlG.SelectedValue == "month")
        {
            while (datStartDate.Day != 1)
            {
                datStartDate = datStartDate.AddDays(-1);
            }
            while (DateTime.Compare(datStartDate, datEndDate) < 0)
            {
                drRes = dtRes.NewRow();
                drRes["StartDate"] = datStartDate;
                drRes["PriceUSD"] = 0;
                drRes["PriceEUR"] = 0;
                datStartDate = datStartDate.AddDays(DateTime.DaysInMonth(datStartDate.Year,datStartDate.Month));
                drRes["EndDate"] = datStartDate.AddDays(-1);
                dtRes.Rows.Add(drRes);
            }
        }

        GridView1.DataSource = dtRes;
        GridView1.DataBind();

        HOTOMOTO.APEX.Rooms objRoom = new HOTOMOTO.APEX.Rooms();
        objRoom.Load(Convert.ToInt32(ddlR.SelectedValue));

        DataTable dtCap = new DataTable();
        dtCap.Columns.Add("Cap");

        for (int i = 0; i < Convert.ToInt32(objRoom.Capacity); i++)
        {
            dtCap.Rows.Add(i + 1);
        }

        
        DateTime datCurrentDate = new DateTime(2007,10,10);
        DataTable dtPrice;

        foreach (GridViewRow gvRow in GridView1.Rows)
        {
            ((Label)gvRow.Cells[0].FindControl("lblSD")).Text = ((DateTime)dtRes.Rows[gvRow.RowIndex]["StartDate"]).Day.ToString();
            ((Label)gvRow.Cells[0].FindControl("lblSM")).Text = ((DateTime)dtRes.Rows[gvRow.RowIndex]["StartDate"]).Month.ToString();
            ((Label)gvRow.Cells[0].FindControl("lblSY")).Text = ((DateTime)dtRes.Rows[gvRow.RowIndex]["StartDate"]).Year.ToString();

            ((Label)gvRow.Cells[0].FindControl("lblED")).Text = ((DateTime)dtRes.Rows[gvRow.RowIndex]["EndDate"]).Day.ToString();
            ((Label)gvRow.Cells[0].FindControl("lblEM")).Text = ((DateTime)dtRes.Rows[gvRow.RowIndex]["EndDate"]).Month.ToString();
            ((Label)gvRow.Cells[0].FindControl("lblEY")).Text = ((DateTime)dtRes.Rows[gvRow.RowIndex]["EndDate"]).Year.ToString();

            ((GridView)gvRow.Cells[0].FindControl("gvPrices")).DataSource = dtCap;
            ((GridView)gvRow.Cells[0].FindControl("gvPrices")).DataBind();

            if (ddlG.SelectedValue == "day")
            {
                //Availability' sini getir

                datCurrentDate = new DateTime(((DateTime)dtRes.Rows[gvRow.RowIndex]["StartDate"]).Year, ((DateTime)dtRes.Rows[gvRow.RowIndex]["StartDate"]).Month, ((DateTime)dtRes.Rows[gvRow.RowIndex]["StartDate"]).Day);

                ((TextBox)gvRow.Cells[0].FindControl("txtQ")).Text = Convert.ToString(HOTOMOTO.BUS.Rooms.GetRoomAvailabilityAtDate(Convert.ToInt32(ddlR.SelectedValue),datCurrentDate));
                if (((TextBox)gvRow.Cells[0].FindControl("txtQ")).Text == "-1")
                {
                    ((TextBox)gvRow.Cells[0].FindControl("txtQ")).BackColor = System.Drawing.Color.Red;
                    ((TextBox)gvRow.Cells[0].FindControl("txtQ")).ForeColor = System.Drawing.Color.White;
                    ((TextBox)gvRow.Cells[0].FindControl("txtQ")).Text = "";
                } else {
                    ((TextBox)gvRow.Cells[0].FindControl("txtQ")).BackColor = System.Drawing.Color.White;
                    ((TextBox)gvRow.Cells[0].FindControl("txtQ")).ForeColor = System.Drawing.Color.Black;
                }
            }

            foreach (GridViewRow gvRowInner in ((GridView)gvRow.Cells[0].FindControl("gvPrices")).Rows)
            {
                ((Label)gvRowInner.Cells[0].FindControl("lblCap")).Text = Convert.ToString(gvRowInner.RowIndex + 1);
                if (ddlG.SelectedValue == "day")
                {
                    dtPrice = HOTOMOTO.BUS.Rooms.GetRoomPrice(Convert.ToInt32(ddlR.SelectedValue), Convert.ToInt32(ddlPL.SelectedValue), gvRowInner.RowIndex + 1, datCurrentDate);
                    if (dtPrice.Rows.Count != 0)
                    {
                        ((TextBox)gvRowInner.FindControl("txtEUR")).Text = Convert.ToString(dtPrice.Rows[0]["EURPrice"]);
                        ((TextBox)gvRowInner.FindControl("txtUSD")).Text = Convert.ToString(dtPrice.Rows[0]["USDPrice"]);
                        ((Label)gvRowInner.FindControl("lblRPLP")).Text = Convert.ToString(dtPrice.Rows[0]["RoomPriceListPriceID"]);
                    }
                    else
                    {
                        ((TextBox)gvRowInner.FindControl("txtEUR")).BackColor = System.Drawing.Color.Red;
                        ((TextBox)gvRowInner.FindControl("txtEUR")).ForeColor = System.Drawing.Color.White;
                        ((TextBox)gvRowInner.FindControl("txtEUR")).Text = "";

                        ((TextBox)gvRowInner.FindControl("txtUSD")).BackColor = System.Drawing.Color.Red;
                        ((TextBox)gvRowInner.FindControl("txtUSD")).ForeColor = System.Drawing.Color.White;
                        ((TextBox)gvRowInner.FindControl("txtUSD")).Text = "";
                    }

                    //Fiyatlarýný getir
                }
            }



        }

    }

    protected void btnPrepare_Click1(object sender, EventArgs e)
    {
        
            GenerateMultiUpdateTable();
        
    }
    protected void btnSaveAva_Click(object sender, EventArgs e)
    {
        Save(false);
    }

    private void Save(bool OnlyAvailibilities)
    {
        DateTime datStartDate;
        DateTime datEndDate;
        DateTime originalStartDate;
        DateTime originalEndDate;
        int intQuantity;
        int intRoomID;
        string strRoomPriceListPriceID;
        string strEURPrice;
        string strUSDPrice;
        string strCapacity;

        if (ddlR.SelectedIndex == 0)
        {
            return;
        }

        HOTOMOTO.APEX.RoomAvailabilities objRoomAvailibility;


        foreach (DataRow drRoom in HOTOMOTO.APEX.Custom.SPExec_Room.SearchRooms(Convert.ToInt32(ddlHC.SelectedValue), Convert.ToInt32(ddlH.SelectedValue), Convert.ToInt32(ddlR.SelectedValue), 0).Rows)
        {
            intRoomID = Convert.ToInt32(drRoom["RoomID"]);


            foreach (GridViewRow gvRow in GridView1.Rows)
            {

                if (((CheckBox)gvRow.FindControl("chkD")).Checked)
                {

                    datStartDate = new DateTime(Convert.ToInt32(((Label)gvRow.FindControl("lblSY")).Text), Convert.ToInt32(((Label)gvRow.FindControl("lblSM")).Text), Convert.ToInt32(((Label)gvRow.FindControl("lblSD")).Text));
                    datEndDate = new DateTime(Convert.ToInt32(((Label)gvRow.FindControl("lblEY")).Text), Convert.ToInt32(((Label)gvRow.FindControl("lblEM")).Text), Convert.ToInt32(((Label)gvRow.FindControl("lblED")).Text));

                    originalStartDate = datStartDate;
                    originalEndDate = datEndDate;

                    if (((TextBox)gvRow.FindControl("txtQ")).Text != "")
                    {
                        if (CARETTA.COM.Util.IsNumeric(((TextBox)gvRow.FindControl("txtQ")).Text))
                        {
                            intQuantity = Convert.ToInt32(((TextBox)gvRow.FindControl("txtQ")).Text);
                            if (intQuantity > -1)
                            {

                                while (DateTime.Compare(datStartDate, datEndDate) <= 0)
                                {
                                    objRoomAvailibility = new HOTOMOTO.APEX.RoomAvailabilities();
                                    objRoomAvailibility.AvailabilityDate = datStartDate;
                                    objRoomAvailibility.RoomID = intRoomID;
                                    objRoomAvailibility.Delete();

                                    objRoomAvailibility.AvailabilityDate = datStartDate;
                                    objRoomAvailibility.RoomID = intRoomID;
                                    objRoomAvailibility.Quantity = intQuantity;
                                    objRoomAvailibility.Save();

                                    datStartDate = datStartDate.AddDays(1);
                                }
                            }
                        }
                    }


                    if (!OnlyAvailibilities)
                    {
                        foreach (GridViewRow gvRowInner in ((GridView)gvRow.Cells[0].FindControl("gvPrices")).Rows)
                        {
                            datStartDate = originalStartDate;
                            datEndDate = originalEndDate;

                            if ((((TextBox)gvRowInner.FindControl("txtEUR")).Text != "") && (((TextBox)gvRowInner.FindControl("txtUSD")).Text != ""))
                            {
                                while (DateTime.Compare(datStartDate, datEndDate) <= 0)
                                {
                                    strRoomPriceListPriceID = ((Label)gvRowInner.FindControl("lblRPLP")).Text;
                                    strCapacity = ((Label)gvRowInner.Cells[0].FindControl("lblCap")).Text;
                                    strUSDPrice = ((TextBox)gvRowInner.FindControl("txtUSD")).Text;
                                    strEURPrice = ((TextBox)gvRowInner.FindControl("txtEUR")).Text;

                                    if (strRoomPriceListPriceID == "")
                                    {
                                        strRoomPriceListPriceID = "0";
                                    }

                                    HOTOMOTO.BUS.Rooms.SaveRoomPrice(Convert.ToInt32(strRoomPriceListPriceID), Convert.ToInt32(ddlR.SelectedValue), Convert.ToInt32(ddlPL.SelectedValue), Convert.ToInt32(strCapacity), datStartDate, Convert.ToDouble(strUSDPrice), Convert.ToDouble(strEURPrice));

                                    datStartDate = datStartDate.AddDays(1);
                                }
                            }

                        }
                    }
                }

            }
        }

        if (ddlG.SelectedValue == "day")
        {
            GenerateMultiUpdateTable();
        }

    }


    protected void btnChkAll_Click(object sender, EventArgs e)
    {
        foreach (GridViewRow gvRow in GridView1.Rows)
        {

            ((CheckBox)gvRow.FindControl("chkD")).Checked = true;
         
        }
    }
    protected void btnUnChkAll_Click(object sender, EventArgs e)
    {
        foreach (GridViewRow gvRow in GridView1.Rows)
        {

            ((CheckBox)gvRow.FindControl("chkD")).Checked = false;

        }
    }
    protected void btnSaveAvaOnly_Click(object sender, EventArgs e)
    {
        Save(true);
    }
}
