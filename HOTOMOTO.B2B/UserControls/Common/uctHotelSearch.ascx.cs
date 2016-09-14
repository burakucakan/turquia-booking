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

public partial class UserControls_Common_uctHotelSearch : BaseUserControl
{
    public int iStart {
        get { return (ViewState["iStart"] == null ? 0 : int.Parse(ViewState["iStart"].ToString())); }
        set { ViewState["iStart"] = value; }
    }

    public bool SearchPanelCollapsed {
        get { return ajCpSearch.Collapsed; }
        set { ajCpSearch.Collapsed = value; }
    }
   
    protected void Page_Load(object sender, EventArgs e)
    {       
        if (!IsPostBack) {
            
            SetDefaultValue();              //Baþlangýç deðerlerini ata

            FillSearchForm();               //Sessiondakileri kriterlerde seçili hale getir
            
            PopulateRooms();                //Sessionda var ise oda detaylarýný göster

        }
    }

    protected void btnOtelSearch_Click(object sender, EventArgs e) {

        if (Validation()) {     //Arama Kritelerini Kontrol Et

            AddSession();       //Arama Kriterlerini Session a ata

            Response.Redirect("Hotel.aspx?Step=" + (int)HOTOMOTO.BUS.Enumerations.QueryStrings.DetailSearch);

        }
    }

    public void ShowModal(UserControls_ModalPopup_ModalPopup.Icons Icon, string Title, string Message) {
        ModalPopup1.Show(Icon, Title, Message);
    }

#region ÝÞLEMLER

    private void SetDefaultValue() {

        //TODO: Resx Dosyasýndan Hata Mesajlarý Alýnmasý Gerek
        //TODO: Tarihlerin Hata Mesajlarý
        uctArrivalDate.ErrorMessage = "Lütfen Gidiþ Tarihini Seçiniz";
        uctDepartureDate.ErrorMessage = "Lütfen Geliþ Tarihini Seçiniz";

        int MaxQuantity = int.Parse(ConfigurationManager.AppSettings["SearchRoomMaxQuantity"].ToString());
        CARETTA.COM.DDLHelper.LoadNumberDDL(ref ddlRoomQuantity, MaxQuantity, 1, 0);

        this.SessRoot.SearchCountryID = int.Parse(ConfigurationManager.AppSettings["DefaultCountryID"].ToString());

        uctDDLCities.LoadCities(this.SessRoot.SearchCountryID);
        uctDDLCities.SelectedValue = ConfigurationManager.AppSettings["DefaultCityID"].ToString();        
    }

    private bool Validation() {
        //Resx Dosyasýndan hata mesajlarýnýn alýnmasý lazým
        string ErrorMesage = "";

        if (uctDDLCities.SelectedValue == "0") {
            ErrorMesage += "- Þehir Seçiniz <br><br>";
        }

        DateTime tryDate;

        try { tryDate = Convert.ToDateTime(uctDepartureDate.Date); }
        catch { ErrorMesage += "- Geliþ Tarihi düzgün giriniz <br><br>"; }

        try {
            tryDate = Convert.ToDateTime(uctArrivalDate.Date);
            if (tryDate < DateTime.Now.Date) {
                ErrorMesage += "- Gidiþ Tarihi Bugünün Tarihinden Küçük Olamaz <br><br>";
            }
            if (tryDate > Convert.ToDateTime(uctDepartureDate.Date)) {
                ErrorMesage += "- Geliþ Tarihi Gidiþ Tarihinden Küçük Olamaz <br><br>";
            }
        }
        catch { ErrorMesage += "- Gidiþ Tarihini doðru giriniz <br><br>"; }

        if (ddlRoomQuantity.SelectedValue == "0") {
            ErrorMesage += "- Oda Sayýsýný Seçiniz <br><br>";
        }

        int AdultCount = 0;
        int ChildCount = 0;

        for (int i = 1; i <= int.Parse(ddlRoomQuantity.SelectedValue); i++) {
            AdultCount = int.Parse(Request.Form[this.ClientID.Replace("_", "$") + "$" + "ddlAdultCount" + i.ToString()]);
            ChildCount = int.Parse(Request.Form[this.ClientID.Replace("_", "$") + "$" + "ddlChildCount" + i.ToString()]);

            if ((AdultCount + ChildCount) < 1) {
                ErrorMesage += "- Oda " + i.ToString() + " için Adult ve Varsa Çocuk Sayýlarýný Giriniz <br><br>";
            }

            if ((AdultCount + ChildCount) > 3) {
                ErrorMesage += "- Oda " + i.ToString() + " için en fazla 3 kiþi atayabilirsiniz<br><br>";
            }

        }


        if (ErrorMesage.Length > 0) {
            ShowModal(UserControls_ModalPopup_ModalPopup.Icons.alert, "Arama Hatasý", ErrorMesage);
            PopulateRooms();
            return false;
        }
        else {
            return true;
        }        
    
    }

    public void AddSession() {
        this.SessRoot.SearchCountryID = int.Parse(ConfigurationManager.AppSettings["DefaultCountryID"].ToString());
        this.SessRoot.SearchCityID = uctDDLCities.SelectedValue;

        if (txtHotelName.Text.Trim().Length > 0) {
            this.SessRoot.SearchHotelName = txtHotelName.Text;
        }
        else {
            this.SessRoot.SearchHotelName = "";
        }

        this.SessRoot.SearchHotelClass = UctDDLHotelClasses1.SelectedValue;
        this.SessRoot.ArrivalDate = Convert.ToDateTime(uctArrivalDate.Date);
        this.SessRoot.DepartureDate = Convert.ToDateTime(uctDepartureDate.Date);
        this.SessRoot.RoomQuantity = int.Parse(ddlRoomQuantity.SelectedValue);

        DataTable dtRoomsDetail = HOTOMOTO.COM.Util.InitializeRoomsDetail();
        DataRow dr;

        for (int i = 1; i <= this.SessRoot.RoomQuantity; i++) {
          
            dr = dtRoomsDetail.NewRow();

            dr["RoomIndex"] = i;
            dr["AdultCount"] = Request.Form[this.ClientID.Replace("_", "$") + "$" + "ddlAdultCount" + i.ToString()];
            dr["ChildCount"] = Request.Form[this.ClientID.Replace("_", "$") + "$" + "ddlChildCount" + i.ToString()];
            dr["FirstChildAge"] = Request.Form[this.ClientID.Replace("_", "$") + "$" + "ddlFirstChildAge" + i.ToString()];
            dr["SecondChildAge"] = Request.Form[this.ClientID.Replace("_", "$") + "$" + "ddlSecondChildAge" + i.ToString()];

            dtRoomsDetail.Rows.Add(dr);
        }

        this.SessRoot.RoomsDetail = dtRoomsDetail;
       
    }

    protected void ddlRoomQuantity_SelectedIndexChanged(object sender, EventArgs e) {
        PopulateRooms();
    }

    private void PopulateRooms() {
        string SelectedValues = String.Empty;
        if (this.iStart > int.Parse(ddlRoomQuantity.SelectedValue)) {
            pnlRooms.Controls.Clear();
        }

        for (int i = 0; i < int.Parse(ddlRoomQuantity.SelectedValue); i++) {
            if ((this.SessRoot.RoomsDetail != null) && (this.SessRoot.RoomsDetail.Rows.Count > 0))
            {
                SelectedValues = this.SessRoot.RoomsDetail.Rows[i]["AdultCount"].ToString() + "|";
                SelectedValues += this.SessRoot.RoomsDetail.Rows[i]["ChildCount"].ToString() + "|";
                SelectedValues += this.SessRoot.RoomsDetail.Rows[i]["FirstChildAge"].ToString() + "|";
                SelectedValues += this.SessRoot.RoomsDetail.Rows[i]["SecondChildAge"].ToString() + "|";
            }
            pnlRooms.Controls.Add(GenerateRoomHTML(i + 1, SelectedValues));
        }

        this.iStart = int.Parse(ddlRoomQuantity.SelectedValue) - 1;
    }

    private Panel GenerateRoomHTML(int ID, string SelectedValues) {
        Panel pnlTitle = new Panel();
        pnlTitle.Width = Unit.Percentage(94);
        //pnlTitle.Style.Add("padding-left", "13");
        pnlTitle.Style.Add("text-align", "left");

        Label glbTitle = new Label();
        glbTitle.CssClass = "clRed";
        glbTitle.ID = "lblTitleRoom" + ID.ToString();
        glbTitle.Text = "ROOM " + ID.ToString();
        pnlTitle.Controls.Add(glbTitle);

        //Kriterler Tablosu--------------------------------------------
        Table gTblCriteria = new Table();
        gTblCriteria.Width = Unit.Percentage(96);
        gTblCriteria.CellPadding = 3;
        gTblCriteria.CellSpacing = 3;
        gTblCriteria.Height = Unit.Pixel(40);
        gTblCriteria.CssClass = "Box";
        
        TableRow gTblRowCriteria = new TableRow();
        //Resx
        gTblRowCriteria.Cells.Add(CARETTA.COM.HTMLHelper.GetTdLiteral("Adult Count: ", "right"));
        gTblRowCriteria.Cells.Add(GetTdDDL("AdultCount" + ID.ToString(), int.Parse(ConfigurationManager.AppSettings["SearchAdultMaxQuantity"]), 0));
        
        gTblRowCriteria.Cells.Add(CARETTA.COM.HTMLHelper.GetTdLiteral("Child Count: ", "right"));
        gTblRowCriteria.Cells.Add(GetTdDDL("ChildCount" + ID.ToString(), 2, 0));

        gTblRowCriteria.Cells.Add(CARETTA.COM.HTMLHelper.GetTdLiteral("First Child Age: ", "right"));
        gTblRowCriteria.Cells.Add(GetTdDDL("FirstChildAge" + ID.ToString(), int.Parse(ConfigurationManager.AppSettings["SearchChildMaxAge"]), 0));
        
        gTblRowCriteria.Cells.Add(CARETTA.COM.HTMLHelper.GetTdLiteral("Second Child Age: ", "right"));
        gTblRowCriteria.Cells.Add(GetTdDDL("SecondChildAge" + ID.ToString(), int.Parse(ConfigurationManager.AppSettings["SearchChildMaxAge"]), 0));

        if (SelectedValues != String.Empty)
        {
            ((DropDownList)gTblRowCriteria.Cells[1].Controls[0]).SelectedValue = SelectedValues.Split('|').GetValue(0).ToString();
            ((DropDownList)gTblRowCriteria.Cells[3].Controls[0]).SelectedValue = SelectedValues.Split('|').GetValue(1).ToString();
            ((DropDownList)gTblRowCriteria.Cells[5].Controls[0]).SelectedValue = SelectedValues.Split('|').GetValue(2).ToString();
            ((DropDownList)gTblRowCriteria.Cells[7].Controls[0]).SelectedValue = SelectedValues.Split('|').GetValue(3).ToString();
        }

        gTblCriteria.Rows.Add(gTblRowCriteria);
        //----------------------------------------Kriterler Tablosu

        Panel pnlRoom = new Panel();
        pnlRoom.ID = "pnlRoom" + ID.ToString();
        pnlRoom.Width = Unit.Percentage(100);
        pnlRoom.Style.Add("text-align", "center");
        pnlRoom.Controls.Add(pnlTitle);
        pnlRoom.Controls.Add(gTblCriteria);

        Panel pnlSeperator = new Panel();
        pnlSeperator.Height = Unit.Pixel(15);
        pnlRoom.Controls.Add(pnlSeperator);
        return pnlRoom;
    }

    private TableCell GetTdDDL(string ID, int Count, int Start) {
        TableCell Cell = new TableCell();
        DropDownList ddl = new DropDownList();
        ddl.ID = "ddl" + ID.ToString();
        Cell.Style.Add("text-align", "left");
        CARETTA.COM.DDLHelper.LoadNumberDDL(ref ddl, Count, 1, Start);
        Cell.Controls.Add(ddl);
        return Cell;
    }

    public void FillSearchForm() {
        uctArrivalDate.Date = this.SessRoot.ArrivalDate.ToShortDateString();
        uctDepartureDate.Date = this.SessRoot.DepartureDate.ToShortDateString();        
        uctDDLCities.SelectedValue = this.SessRoot.SearchCityID.Replace("%", ConfigurationManager.AppSettings["DefaultCityID"].ToString());
        ddlRoomQuantity.SelectedValue = this.SessRoot.RoomQuantity.ToString();
        txtHotelName.Text = this.SessRoot.SearchHotelName.ToString().Replace("%", "");
    }

#endregion


}
