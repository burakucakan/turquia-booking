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
using AjaxControlToolkit;
using System.Drawing;

public partial class userControls_uctAddRoom : BaseUserControl
{
    string strValidationGroup = "vgRoomInsertion";
    //string TxtCssClass = "textBox";
    //string LblCssClass = "label";


    public int HotelID
    {
        get { return ViewState["HID"] == null ? 0 : Convert.ToInt32(ViewState["HID"]) ; }
        set { ViewState.Add("HID",value); }
    }

    public int RoomID
    {
        get { return ViewState["RID"] == null ? 0 : Convert.ToInt32(ViewState["RID"]); }
        set { ViewState.Add("RID", value); }
    }
	
    protected void Page_Load(object sender, EventArgs e)
    { 
        UctMessage1.Visible = false;

        
        if (!Page.IsPostBack)
        {

            if (Request.QueryString["hotelid"] != null)
            {
                this.HotelID = Convert.ToInt32(Request.QueryString["hotelid"]);
            }
            if (Request.QueryString["roomid"] != null)
            {
                this.RoomID = Convert.ToInt32(Request.QueryString["roomid"]);
            }

            if ((this.RoomID != 0) && (this.HotelID != 0))
            {

                LoadRoomData();
            }
        }
    }
    // Odagüncelleme için
    private void LoadRoomData()
    {
        // Odanýn Load olmasý
        HOTOMOTO.APEX.Rooms Room = new HOTOMOTO.APEX.Rooms();
        Room.Load(this.RoomID);
        txtCapacity.Text = Room.Capacity.ToString();

        Hashtable htLanguages = HOTOMOTO.APEX.Languages.GetAllLanguages();

        foreach (HOTOMOTO.APEX.Languages Language in htLanguages.Values)
        {
            UctMLTabs1.SetValue(Language.LanguageID, "RoomName", Room.GetRoomName(Language.LanguageID));
            UctMLTabs1.SetValue(Language.LanguageID, "RoomDescription", Room.GetDescription(Language.LanguageID));
        }

        UctRoomProperties1.LoadByRoomID(this.RoomID);

        UctRoomImages1.LoadRoomImages(this.HotelID, this.RoomID);

    }

    void Page_Init(object sender, EventArgs e) {
        btnPublish.ValidationGroup = strValidationGroup;
        rvCapacity.ValidationGroup = strValidationGroup;
        rfvCapacity.ValidationGroup = strValidationGroup;
        UctMLTabs1.MLValidationGroup = strValidationGroup;
        UctMLTabs1.ClearControls();
        UctMLTabs1.AddTextArea("RoomName", "Oda Adý", true, false, 0, 0);
        UctMLTabs1.AddTextArea("RoomDescription", "Oda Tanýmý", true, true, 0, 0);
        UctMLTabs1.GenerateTabs();

    }

    protected void btnPublish_Click(object sender, ImageClickEventArgs e)
    {
        if (this.RoomID > 0)
        {
            if (!UctRoomImages1.isDefaultImageChosen(true))
            {
                UctMessage1.Type = MessageType.Error;
                UctMessage1.Message = "Varsayýlan resim seçiminde hata oluþtu!";
                UctMessage1.Visible = true;
            }
            else
            {
                // Odayý güncelleme
                HOTOMOTO.APEX.Rooms Room = new HOTOMOTO.APEX.Rooms();
                Room.Load(this.RoomID);
                Room.ModifyDate = DateTime.Now;
                Room.ModifiedBy = SessRoot.UserID;
                Room.Capacity = Convert.ToInt32(txtCapacity.Text);

                Hashtable htLanguages = HOTOMOTO.APEX.Languages.GetAllLanguages();

                foreach (HOTOMOTO.APEX.Languages Language in htLanguages.Values)
                {
                    Room.SetDescription(UctMLTabs1.GetValue(Language.LanguageID, "RoomDescription"), Language.LanguageID);
                    Room.SetRoomName(UctMLTabs1.GetValue(Language.LanguageID, "RoomName"), Language.LanguageID);
                }
                Room.Save();
                // Oda özellikleri
                UctRoomProperties1.UpdateRoomProperties(Room.RoomID);
                // Oda resimleri
                UctRoomImages1.SaveRoomImages(Room.HotelID, Room.RoomID);

                UctMessage1.Message = "Oda güncellenmiþtir...";
                UctMessage1.Type = MessageType.Information;
                UctMessage1.AddLink("Rooms.aspx?hotelid=" + this.HotelID , "Odalara git...");
                UctMessage1.Visible = true;
            }
        }
        else
        {
            if (!UctRoomImages1.isDefaultImageChosen(false))
            {
                UctMessage1.Type = MessageType.Error;
                UctMessage1.Message = "Varsayýlan resim seçiminde hata oluþtu!";
                UctMessage1.Visible = true;
            }
            else
            {
                UctMessage1.Visible = false;
                int RoomID = 0;

                HOTOMOTO.APEX.Rooms Room = new HOTOMOTO.APEX.Rooms();
                Room.HotelID = this.HotelID;
                Room.CreateDate = DateTime.Now;
                Room.Capacity = Convert.ToInt32(txtCapacity.Text);
                Room.ModifyDate = DateTime.Now;
                Room.CreatedBy = SessRoot.UserID;
                Room.ModifiedBy = SessRoot.UserID;
                Room.isActive = true;

                Hashtable htLanguages = HOTOMOTO.APEX.Languages.GetAllLanguages();
                foreach (HOTOMOTO.APEX.Languages Language in htLanguages.Values)
                {
                    Room.SetDescription(UctMLTabs1.GetValue(Language.LanguageID, "RoomDescription"), Language.LanguageID);
                    Room.SetRoomName(UctMLTabs1.GetValue(Language.LanguageID, "RoomName"), Language.LanguageID);
                }
                RoomID = Room.Save();
                // Oda özellikleri
                UctRoomProperties1.SaveRoomProperties(RoomID);
                // Oda resimleri
                UctRoomImages1.SaveRoomImages(53, RoomID);


                //if (chkContinue.Checked)
                //{
                UctMessage1.Message = "Oda eklenmiþtir...";
                UctMessage1.Type = MessageType.Information;
                UctMessage1.AddLink("Rooms.aspx?hotelid=" + this.HotelID, "Odalara git...");
                UctMessage1.Visible = true;
                //SessRoot.ChildID  = -1;
                //}
                //else
                //    Response.Redirect("");
            }
        }
    }

}
