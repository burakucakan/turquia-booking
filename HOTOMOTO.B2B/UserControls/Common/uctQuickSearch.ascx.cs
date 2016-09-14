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

public partial class UserControls_Common_uctQuickSearch : BaseUserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack) {
            SetDefaultValue();              //Ba�lang�� de�erlerini ata
        }
    }

    protected void btnOtelSearch_Click(object sender, EventArgs e) {
        if (Validation()) {         //Arama Kritelerini Kontrol Et

            AddSession();           //Arama Kriterlerini Session a ata
            Response.Redirect("Hotel.aspx?Step=2");

        }
    }

    protected void ddlRoomQuantity_SelectedIndexChanged(object sender, EventArgs e) {

        int MaxQuantity = Convert.ToInt16(ConfigurationManager.AppSettings["SearchRoomMaxQuantity"]);
        int RoomCount = int.Parse(ddlRoomQuantity.SelectedValue);
        DropDownList ddl;
        for (int i = 1; i <= MaxQuantity; i++) {
            if (RoomCount >= i) {
                ((Panel)this.FindControl("pnlRoom" + i.ToString())).Visible = true;                

                ddl = ((DropDownList)this.FindControl("ddlAdultCount" + i.ToString()));
                CARETTA.COM.DDLHelper.LoadNumberDDL(ref ddl, int.Parse(ConfigurationManager.AppSettings["SearchAdultMaxQuantity"]), 1, 0);

                ddl = ((DropDownList)this.FindControl("ddlChildCount" + i.ToString()));
                CARETTA.COM.DDLHelper.LoadNumberDDL(ref ddl, 2, 1, 0);

                ddl = ((DropDownList)this.FindControl("ddlFirstChildAge" + i.ToString()));
                CARETTA.COM.DDLHelper.LoadNumberDDL(ref ddl, int.Parse(ConfigurationManager.AppSettings["SearchChildMaxAge"]), 1, 0);

                ddl = ((DropDownList)this.FindControl("ddlSecondChildAge" + i.ToString()));
                CARETTA.COM.DDLHelper.LoadNumberDDL(ref ddl, int.Parse(ConfigurationManager.AppSettings["SearchChildMaxAge"]), 1, 0);
            }
            else {
                ((Panel)this.FindControl("pnlRoom" + i.ToString())).Visible = false;
            }
        }

    }

#region ��LEMLER

    private void SetDefaultValue() {
        //Resx Dosyas�ndan Hata Mesajlar� Al�nmas� Gerek
        //Tarihlerin Hata Mesajlar�
        UctArrivalDate.ErrorMessage = "L�tfen Gidi� Tarihini Se�iniz";
        UctDepartureDate.ErrorMessage = "L�tfen Geli� Tarihini Se�iniz";

        int MaxQuantity = int.Parse(ConfigurationManager.AppSettings["SearchRoomMaxQuantity"].ToString());
        CARETTA.COM.DDLHelper.LoadNumberDDL(ref ddlRoomQuantity, MaxQuantity, 1, 0);

        //Tarihlere bug�n�n ve 1 hafta sonras�n�n tarihleri gir
        UctArrivalDate.Date = DateTime.Now.Date.ToShortDateString();
        UctDepartureDate.Date = DateTime.Now.AddDays(7).ToShortDateString();

        this.SessRoot.SearchCountryID = int.Parse(ConfigurationManager.AppSettings["DefaultCountryID"].ToString());

        UctDDLCities1.LoadCities(this.SessRoot.SearchCountryID);
        UctDDLCities1.SelectedValue = ConfigurationManager.AppSettings["DefaultCityID"].ToString();
    }

    private bool Validation() {
        //Resx Dosyas�ndan hata mesajlar�n�n al�nmas� laz�m
        string ErrorMesage = "";

        if (UctDDLCities1.SelectedValue == "0") {
            ErrorMesage += "- �ehir Se�iniz <br><br>";
        }

        DateTime tryDate;

        try { tryDate = Convert.ToDateTime(UctDepartureDate.Date); }
        catch { ErrorMesage += "- Geli� Tarihi d�zg�n giriniz <br><br>"; }

        try {
            tryDate = Convert.ToDateTime(UctArrivalDate.Date);
            if (tryDate < DateTime.Now.Date) {
                ErrorMesage += "- Gidi� Tarihi Bug�n�n Tarihinden K���k Olamaz <br><br>";
            }
            if (tryDate > Convert.ToDateTime(UctDepartureDate.Date)) {
                ErrorMesage += "- Geli� Tarihi Gidi� Tarihinden K���k Olamaz <br><br>";
            }
        }
        catch { ErrorMesage += "- Gidi� Tarihini do�ru giriniz <br><br>"; }

        if (ddlRoomQuantity.SelectedValue == "0") {
            ErrorMesage += "- Oda Say�s�n� Se�iniz";
        }


        int AdultCount = 0;
        int ChildCount = 0;

        for (int i = 1; i <= int.Parse(ddlRoomQuantity.SelectedValue); i++) {
            AdultCount = int.Parse(((DropDownList)this.FindControl("ddlAdultCount" + i.ToString())).SelectedValue);
            ChildCount = int.Parse(((DropDownList)this.FindControl("ddlChildCount" + i.ToString())).SelectedValue);

            if ((AdultCount + ChildCount) < 1) {
                ErrorMesage += "- Oda " + i.ToString() + " i�in Adult ve Varsa �ocuk Say�lar�n� Giriniz <br><br>";
            }

            if ((AdultCount + ChildCount) > 3) {
                ErrorMesage += "- Oda " + i.ToString() + " i�in en fazla 3 ki�i atayabilirsiniz<br><br>";
            }

        }


        if (ErrorMesage.Length > 0) {
            ModalPopup1.Show(UserControls_ModalPopup_ModalPopup.Icons.alert, "Arama Hatas�", ErrorMesage);
            return false;
        }
        else {
            return true;
        }

    }

    private void AddSession() {
        this.SessRoot.SearchCountryID = int.Parse(ConfigurationManager.AppSettings["DefaultCountryID"].ToString());
        this.SessRoot.SearchCityID = UctDDLCities1.SelectedValue;
        this.SessRoot.SearchHotelName = "%";
        this.SessRoot.SearchHotelClass = "%";
        this.SessRoot.ArrivalDate = Convert.ToDateTime(UctArrivalDate.Date);
        this.SessRoot.DepartureDate = Convert.ToDateTime(UctDepartureDate.Date);
        this.SessRoot.RoomQuantity = int.Parse(ddlRoomQuantity.SelectedValue);

        DataTable dtRoomsDetail = new DataTable();

        dtRoomsDetail.Columns.Add(new DataColumn("RoomIndex"));
        dtRoomsDetail.Columns.Add(new DataColumn("AdultCount"));
        dtRoomsDetail.Columns.Add(new DataColumn("ChildCount"));
        dtRoomsDetail.Columns.Add(new DataColumn("FirstChildAge"));
        dtRoomsDetail.Columns.Add(new DataColumn("SecondChildAge"));

        DataRow dr;

        for (int i = 1; i <= this.SessRoot.RoomQuantity; i++) {

            dr = dtRoomsDetail.NewRow();

            dr["RoomIndex"] = i;
            dr["AdultCount"] = ((DropDownList)this.FindControl("ddlAdultCount" + i.ToString())).SelectedValue;
            dr["ChildCount"] = ((DropDownList)this.FindControl("ddlChildCount" + i.ToString())).SelectedValue;
            dr["FirstChildAge"] = ((DropDownList)this.FindControl("ddlFirstChildAge" + i.ToString())).SelectedValue;
            dr["SecondChildAge"] = ((DropDownList)this.FindControl("ddlSecondChildAge" + i.ToString())).SelectedValue;

            dtRoomsDetail.Rows.Add(dr);
        }

        this.SessRoot.RoomsDetail = dtRoomsDetail;
    }

#endregion

}
