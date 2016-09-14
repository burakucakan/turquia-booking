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

public partial class UserControls_Tour_uctTourSearch : BaseUserControl {

    public HOTOMOTO.BUS.Enumerations.TourTypes TourType {
        get {
            return (ViewState["TourType"] == null ? HOTOMOTO.BUS.Enumerations.TourTypes.Excursion : ((HOTOMOTO.BUS.Enumerations.TourTypes)((int)ViewState["TourType"])));
        }
        set {
            ViewState["TourType"] = value;
        }
    }

    public bool SearchPanelCollapsed {
        get { return ajCpSearch.Collapsed; }
        set { ajCpSearch.Collapsed = value; }
    }

    protected void Page_Load(object sender, EventArgs e) {
        if (!IsPostBack) {

            SetDefaultValue();              //Ba�lang�� de�erlerini ata

            FillSearchForm();               //Sessiondakileri kriterlerde se�ili hale getir

        }
    }

    protected void btnTour_Click(object sender, EventArgs e) {

        if (Validation()) {     //Arama Kritelerini Kontrol Et

            AddSession();       //Arama Kriterlerini Session a ata
            
            Response.Redirect(this.TourType.ToString() + ".aspx?Step=" + (int)HOTOMOTO.BUS.Enumerations.QueryStrings.DetailSearch);

        }
    }

    public void ShowModal(UserControls_ModalPopup_ModalPopup.Icons Icon, string Title, string Message) {
        ModalPopup1.Show(Icon, Title, Message);
    }

#region ��LEMLER

    private void SetDefaultValue() {
        //Resx Dosyas�ndan Hata Mesajlar� Al�nmas� Gerek
        //Tarihlerin Hata Mesajlar�
        uctArrivalDate.ErrorMessage = "L�tfen Gidi� Tarihini Se�iniz";
        uctDepartureDate.ErrorMessage = "L�tfen Geli� Tarihini Se�iniz";

        this.SessRoot.SearchCountryID = int.Parse(ConfigurationManager.AppSettings["DefaultCountryID"].ToString());

        uctDDLCities.LoadCities(this.SessRoot.SearchCountryID);
        uctDDLCities.SelectedValue = ConfigurationManager.AppSettings["DefaultCityID"].ToString();
    }

    public void FillSearchForm() {
        uctArrivalDate.Date = this.SessRoot.ArrivalDate.ToShortDateString();
        uctDepartureDate.Date = this.SessRoot.DepartureDate.ToShortDateString();
        uctDDLCities.SelectedValue = this.SessRoot.SearchCityID.Replace("%", ConfigurationManager.AppSettings["DefaultCityID"].ToString());
        txtTourName.Text = this.SessRoot.SearchTourName.ToString().Replace("%", "");
    }

    private bool Validation() {
        //Resx Dosyas�ndan hata mesajlar�n�n al�nmas� laz�m
        string ErrorMesage = "";

        if (uctDDLCities.SelectedValue == "0") {
            ErrorMesage += "- �ehir Se�iniz <br><br>";
        }

        DateTime tryDate;

        try {
            tryDate = Convert.ToDateTime(uctDepartureDate.Date);
        }
        catch {
            ErrorMesage += "- Geli� Tarihi d�zg�n giriniz <br><br>";
        }

        try {
            tryDate = Convert.ToDateTime(uctArrivalDate.Date);
            if (tryDate < DateTime.Now.Date) {
                ErrorMesage += "- Gidi� Tarihi Bug�n�n Tarihinden K���k Olamaz <br><br>";
            }
            if (tryDate > Convert.ToDateTime(uctDepartureDate.Date)) {
                ErrorMesage += "- Geli� Tarihi Gidi� Tarihinden K���k Olamaz <br><br>";
            }
        }
        catch {
            ErrorMesage += "- Gidi� Tarihini do�ru giriniz <br><br>";
        }

        if (ErrorMesage.Length > 0) {
            ShowModal(UserControls_ModalPopup_ModalPopup.Icons.alert, "Arama Hatas�", ErrorMesage);
            return false;
        }
        else {
            return true;
        }

    }

    public void AddSession() {
        this.SessRoot.SearchCountryID = int.Parse(ConfigurationManager.AppSettings["DefaultCountryID"].ToString());
        this.SessRoot.SearchCityID = uctDDLCities.SelectedValue;

        if (txtTourName.Text.Trim().Length > 0) {
            this.SessRoot.SearchTourName = txtTourName.Text;
        }
        else {
            this.SessRoot.SearchTourName = "";
        }

        this.SessRoot.ArrivalDate = Convert.ToDateTime(uctArrivalDate.Date);
        this.SessRoot.DepartureDate = Convert.ToDateTime(uctDepartureDate.Date);
    }

#endregion ��LEMLER

}
