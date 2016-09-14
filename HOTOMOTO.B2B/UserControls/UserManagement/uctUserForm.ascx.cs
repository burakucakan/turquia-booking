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

public partial class UserControls_UserManagement_uctUserForm : BaseUserControl {
    
    public int UpUserID {
        get {
            return (ViewState["UpUserID"] == null ? 0 : int.Parse(ViewState["UpUserID"].ToString()));
        }
        set {
            ViewState["UpUserID"] = value;
        }
    }

    public int Saved
    {
        get { return (ViewState["Saved"] == null ? -1 : int.Parse(ViewState["Saved"].ToString())); }
        set { ViewState["Saved"] = value; }
    }

    protected void Page_Load(object sender, EventArgs e) {

        if (!IsPostBack) {

            FillPerms();            // Yetkileri Yükle 

            hdUserCreateDate.Value = DateTime.Now.ToString();
        }

        LoadAddressTypes();     // Adres Tiplerini Getir 

        LoadAccessOptions();    // Üyelik Formu Ýçin Ek Ýletiþim Bilgilerini Getir

    }

    protected void Page_PreRender(object sender, EventArgs e)
    {
        if (this.Saved == 1)
        {
            ModalPopup1.Show(UserControls_ModalPopup_ModalPopup.Icons.info, "KULLANICI EKLEME", "Kullanýcýnýn Kaydý Yapýlmýþtýr", false);
        }
        this.Saved = -1;
    }

    // YETKÝLER                                                                       
    private void FillPerms() {
        DataTable dtPerm = HOTOMOTO.BUS.UserManagement.GetAllPermissions(this.SessRoot.LanguageID, HOTOMOTO.BUS.Enumerations.RoleType.B2B );
        CARETTA.COM.DDLHelper.BindDDL(ref ddlPerm, dtPerm, "Title", "UserPermissionID", "");
    }

    // UPDATE MODU                                                                    
    public void FillUser() {

        ErrPassword.Enabled = false;
        ErrPassword2.Enabled = false;
        txtUserName.Enabled = false;

        DataTable dtUser = HOTOMOTO.BUS.UserManagement.GetUserAndUserPerm(this.SessRoot.LanguageID, this.UpUserID);

        hdUserCreateDate.Value = dtUser.Rows[0]["CreateDate"].ToString();
        txtUserName.Text = CARETTA.COM.Encryption.Decrypt(dtUser.Rows[0]["UserName"].ToString(), ConfigurationManager.AppSettings["EncryptionKey"]);
        hdPassword.Value = CARETTA.COM.Encryption.Decrypt(dtUser.Rows[0]["Password"].ToString(), ConfigurationManager.AppSettings["EncryptionKey"]);
        ddlPerm.SelectedValue = dtUser.Rows[0]["UserPermissionID"].ToString();
        txtName.Text = dtUser.Rows[0]["FirstName"].ToString();
        txtLastName.Text = dtUser.Rows[0]["LastName"].ToString();
        txtEmail.Text = dtUser.Rows[0]["EmailAddress"].ToString();
    }         // Kullaýcýyý Çaðýr Bilgilerini Yükle

    public void FillUserAddress() {

        DataTable dtUserAddress = HOTOMOTO.BUS.UserManagement.GetUserAddress(this.UpUserID);

        foreach (DataRow dr in dtUserAddress.Rows) {
            ((TextBox)pnlAddress.FindControl("txtStreetAddress|" + dr["AddressTypeID"].ToString())).Text = dr["StreetAddress"].ToString();
            ((TextBox)pnlAddress.FindControl("txtPostalCode|" + dr["AddressTypeID"].ToString())).Text = dr["PostalCode"].ToString();
            ((TextBox)pnlAddress.FindControl("txtTown|" + dr["AddressTypeID"].ToString())).Text = dr["Town"].ToString();
            ((DropDownList)pnlAddress.FindControl("ddlCountries|" + dr["AddressTypeID"].ToString())).SelectedValue = dr["CountryID"].ToString();
            LoadCities((DropDownList)pnlAddress.FindControl("ddlCountries|" + dr["AddressTypeID"].ToString()));
            ((DropDownList)pnlAddress.FindControl("ddlCities|" + dr["AddressTypeID"].ToString())).SelectedValue = dr["CityID"].ToString();
            ((HiddenField)pnlAddress.FindControl("hdAddressCreateDate|" + dr["AddressTypeID"].ToString())).Value = dr["CreateDate"].ToString();
            ((HiddenField)pnlAddress.FindControl("hdAddressID|" + dr["AddressTypeID"].ToString())).Value = dr["AddressID"].ToString();
        }

    }  // Kullanýcýnýn Adres Bilgilerini Yükle 

    public void FillUserAccess() {
        DataTable dtUserAccess = HOTOMOTO.BUS.UserManagement.GetUserAccessOptions(this.UpUserID);

        foreach (DataRow dr in dtUserAccess.Rows) {
            ((TextBox)pnlAddress.FindControl("txtAccess|" + dr["AccessTypeID"].ToString())).Text = dr["AccessValue"].ToString();
            ((HiddenField)pnlAddress.FindControl("hdAccessOptionID|" + dr["AccessTypeID"].ToString())).Value = dr["AccessOptionID"].ToString();
        }
    }   // Kullanýcýya Ait AccessOptions Deðerlerini Yükle 


    // ÜLKELER ve ÞEHÝRLER                                                            
    void ddlCountry_SelectedIndexChanged(object sender, EventArgs e) {
        LoadCities(((DropDownList)sender));
    }
    private void LoadCities(DropDownList sender) {
        DropDownList ddlCountries = sender;
        DropDownList ddlCities = ((DropDownList)pnlAddress.FindControl(ddlCountries.ID.Replace("Countries", "Cities")));
        CARETTA.COM.DDLHelper.BindDDL(ref ddlCities, HOTOMOTO.BUS.CountriesAndCities.GetCitiesByCountryID(this.SessRoot.LanguageID, int.Parse(ddlCountries.SelectedValue)), "CityName", "CityID", "");
    }


    // ACCESS                                                                         
    private void LoadAccessOptions() {
        DataTable dtAccess = GetAccessOptions();

        Table tbl;
        TableRow tr;
        TableCell td;

        Literal ltlOptionTitle;
        TextBox txtOption;

        tbl = new Table();
        tbl.Width = Unit.Percentage(100);
        tbl.CellPadding = 3;
        tbl.CellSpacing = 3;

        int i = 0;


        while (i < dtAccess.Rows.Count) {

            tr = new TableRow();
            tr.CssClass = "rptItem5";

            td = new TableCell();
            td.ColumnSpan = 2;

            ltlOptionTitle = new Literal();
            ltlOptionTitle.Text = dtAccess.Rows[i]["MainType"].ToString();

            td.Controls.Add(ltlOptionTitle);
            tr.Cells.Add(td);

            tbl.Rows.Add(tr);

            while (i <= dtAccess.Rows.Count) {
                tr = new TableRow();
                tr.CssClass = "rptItem";

                tr.Cells.Add(CARETTA.COM.HTMLHelper.GetTdLiteral(dtAccess.Rows[i]["Type"].ToString() + ": ", "left", "25%"));

                td = new TableCell();
                td.Width = Unit.Percentage(75);

                txtOption = new TextBox();
                txtOption.Width = Unit.Percentage(85);
                txtOption.CssClass = "TextBox";
                txtOption.ID = "txtAccess" + "|" + dtAccess.Rows[i]["AccessTypeID"].ToString();

                td.Controls.Add(txtOption);


                HiddenField hdAccessOptionID = new HiddenField();
                hdAccessOptionID.ID = "hdAccessOptionID" + "|" + dtAccess.Rows[i]["AccessTypeID"].ToString();
                hdAccessOptionID.Value = "0";

                td.Controls.Add(hdAccessOptionID);


                HiddenField hdAccessTypeID = new HiddenField();
                hdAccessTypeID.ID = "hdAccessTypeID" + "|" + dtAccess.Rows[i]["AccessTypeID"].ToString();
                hdAccessTypeID.Value = "0";

                td.Controls.Add(hdAccessTypeID);


                HiddenField hdAccessCreateDate = new HiddenField();
                hdAccessCreateDate.ID = "hdAccessCreateDate" + "|" + dtAccess.Rows[i]["AccessTypeID"].ToString();
                hdAccessCreateDate.Value = DateTime.Now.ToString();

                td.Controls.Add(hdAccessCreateDate);

                tr.Cells.Add(td);
                tbl.Rows.Add(tr);

                if ((i + 1 > dtAccess.Rows.Count - 1) || (dtAccess.Rows[i + 1]["AccessMainTypeID"].ToString() != dtAccess.Rows[i]["AccessMainTypeID"].ToString())) {
                    break;
                }
                i++;
            }

            i++;
        }

        pnlAccess.Controls.Add(tbl);

    }
    private DataTable GetAccessOptions() {
        return HOTOMOTO.BUS.UserManagement.GetAccessOptions(this.SessRoot.LanguageID);
    }
    private DataTable InitializeAccessDt() {
        DataTable dtAddress = new DataTable();
        dtAddress.Columns.Add(new DataColumn("AccessOptionID"));
        dtAddress.Columns.Add(new DataColumn("AccessTypeID"));
        dtAddress.Columns.Add(new DataColumn("AccessValue"));
        dtAddress.Columns.Add(new DataColumn("CreateDate"));
        return dtAddress;
    }
    private void AddAccess(ref DataTable dtAccess, int AccessOptionID, int AccessTypeID, string AccessValue, DateTime CreateDate) {
        DataRow dr = dtAccess.NewRow();
        dr["AccessOptionID"] = AccessOptionID;
        dr["AccessTypeID"] = AccessTypeID;
        dr["AccessValue"] = AccessValue;
        dr["CreateDate"] = CreateDate;
        dtAccess.Rows.Add(dr);
    }


    // ADDRESS                                                                        
    private void LoadAddressTypes() {
        DataTable dtAddress = GetAddressTypes();

        Table tbl;
        TableRow tr;
        TableCell td;

        Literal ltlAddressTitle;
        TextBox txtAddress;
        DropDownList ddl;

        tbl = new Table();
        tbl.Width = Unit.Percentage(100);
        tbl.CellPadding = 3;
        tbl.CellSpacing = 3;


        foreach (DataRow dr in dtAddress.Rows) {

            tr = new TableRow();
            tr.CssClass = "rptItem5";

            td = new TableCell();
            td.ColumnSpan = 2;

            ltlAddressTitle = new Literal();
            ltlAddressTitle.Text = dr["Type"].ToString();

            td.Controls.Add(ltlAddressTitle);

            HiddenField hdAddressID = new HiddenField();
            hdAddressID.ID = "hdAddressID" + "|" + dr["AddressTypeID"].ToString();
            hdAddressID.Value = "0";

            td.Controls.Add(hdAddressID);

            HiddenField hdAddressCreateDate = new HiddenField();
            hdAddressCreateDate.ID = "hdAddressCreateDate" + "|" + dr["AddressTypeID"].ToString();
            hdAddressCreateDate.Value = DateTime.Now.ToString();

            td.Controls.Add(hdAddressCreateDate);


            tr.Cells.Add(td);
            tbl.Rows.Add(tr);


            tr = new TableRow();
            tr.CssClass = "rptItem";

            tr.Cells.Add(CARETTA.COM.HTMLHelper.GetTdLiteral("Adres: ", "left", "25%"));

            td = new TableCell();
            td.Width = Unit.Percentage(75);

            txtAddress = new TextBox();
            txtAddress.Width = Unit.Percentage(85);
            txtAddress.TextMode = TextBoxMode.MultiLine;
            txtAddress.Height = Unit.Pixel(35);
            txtAddress.CssClass = "TextBox";
            txtAddress.ID = "txtStreetAddress" + "|" + dr["AddressTypeID"].ToString();

            td.Controls.Add(txtAddress);

            tr.Cells.Add(td);
            tbl.Rows.Add(tr);



            tr = new TableRow();
            tr.CssClass = "rptItem";

            tr.Cells.Add(CARETTA.COM.HTMLHelper.GetTdLiteral("Posta Kodu: ", "left", "25%"));

            td = new TableCell();
            td.Width = Unit.Percentage(75);

            txtAddress = new TextBox();
            txtAddress.Width = Unit.Percentage(85);
            txtAddress.CssClass = "TextBox";
            txtAddress.ID = "txtPostalCode" + "|" + dr["AddressTypeID"].ToString();

            td.Controls.Add(txtAddress);

            tr.Cells.Add(td);
            tbl.Rows.Add(tr);



            tr = new TableRow();
            tr.CssClass = "rptItem";

            tr.Cells.Add(CARETTA.COM.HTMLHelper.GetTdLiteral("Ýlçe: ", "left", "25%"));

            td = new TableCell();
            td.Width = Unit.Percentage(75);

            txtAddress = new TextBox();
            txtAddress.Width = Unit.Percentage(85);
            txtAddress.CssClass = "TextBox";
            txtAddress.ID = "txtTown" + "|" + dr["AddressTypeID"].ToString();

            td.Controls.Add(txtAddress);

            tr.Cells.Add(td);
            tbl.Rows.Add(tr);



            tr = new TableRow();
            tr.CssClass = "rptItem";

            tr.Cells.Add(CARETTA.COM.HTMLHelper.GetTdLiteral("Ülke: ", "left", "25%"));

            td = new TableCell();
            td.Width = Unit.Percentage(75);

            ddl = new DropDownList();
            ddl.Width = Unit.Percentage(88);
            ddl.CssClass = "DropDownList";
            ddl.ID = "ddlCountries" + "|" + dr["AddressTypeID"].ToString();
            ddl.AutoPostBack = true;
            ddl.SelectedIndexChanged += new EventHandler(ddlCountry_SelectedIndexChanged);

            td.Controls.Add(ddl);

            CARETTA.COM.DDLHelper.BindDDL(ref ddl, this.CachedCountries, "CountryName", "CountryID", "");

            tr.Cells.Add(td);
            tbl.Rows.Add(tr);



            tr = new TableRow();
            tr.CssClass = "rptItem";

            tr.Cells.Add(CARETTA.COM.HTMLHelper.GetTdLiteral("Þehir: ", "left", "25%"));

            td = new TableCell();
            td.Width = Unit.Percentage(75);

            ddl = new DropDownList();
            ddl.Width = Unit.Percentage(88);
            ddl.CssClass = "DropDownList";
            ddl.ID = "ddlCities" + "|" + dr["AddressTypeID"].ToString();

            td.Controls.Add(ddl);

            tr.Cells.Add(td);
            tbl.Rows.Add(tr);

        }

        pnlAddress.Controls.Add(tbl);

        int CountrySpainID = Convert.ToInt32(ConfigurationManager.AppSettings["CountrySpainID"]);
        DropDownList ddlInCountries;
        foreach (DataRow dr in dtAddress.Rows) {
            ddlInCountries = ((DropDownList)pnlAccess.FindControl("ddlCountries" + "|" + dr["AddressTypeID"].ToString()));
            ddlInCountries.SelectedValue = CountrySpainID.ToString();
            if (ddlInCountries != null) {
                LoadCities(ddlInCountries);
            }
        }

    }
    private DataTable GetAddressTypes() {
        return HOTOMOTO.BUS.UserManagement.GetAddressTypes(this.SessRoot.LanguageID);
    }
    private DataTable InitializeAddressDt() {
        DataTable dtAddress = new DataTable();
        dtAddress.Columns.Add(new DataColumn("AddressID"));
        dtAddress.Columns.Add(new DataColumn("AddressTypeID"));
        dtAddress.Columns.Add(new DataColumn("StreetAddress"));
        dtAddress.Columns.Add(new DataColumn("PostalCode"));
        dtAddress.Columns.Add(new DataColumn("Town"));
        dtAddress.Columns.Add(new DataColumn("CountryID"));
        dtAddress.Columns.Add(new DataColumn("CityID"));
        dtAddress.Columns.Add(new DataColumn("CreateDate"));
        return dtAddress;
    }
    private void AddAddress(ref DataTable dtAddress, int AddressID, int AddressTypeID, string StreetAddress, string PostalCode, string Town, int CountryID, int CityID, DateTime CreateDate) {
        DataRow dr = dtAddress.NewRow();
        dr["AddressID"] = AddressID;
        dr["AddressTypeID"] = AddressTypeID;
        dr["StreetAddress"] = StreetAddress;
        dr["PostalCode"] = PostalCode;
        dr["Town"] = Town;
        dr["CountryID"] = CountryID;
        dr["CityID"] = CityID;
        dr["CreateDate"] = CreateDate;
        dtAddress.Rows.Add(dr);
    }


    protected void btnSave_Click(object sender, EventArgs e) {

        string UserName = CARETTA.COM.Encryption.Encrypt(txtUserName.Text.Trim(), ConfigurationManager.AppSettings["EncryptionKey"]);
        string Password = String.Empty;

        if (this.UpUserID != 0) {
            Password = CARETTA.COM.Encryption.Encrypt(hdPassword.Value, ConfigurationManager.AppSettings["EncryptionKey"]);
        }
        else {
            Password = CARETTA.COM.Encryption.Encrypt(txtPassword.Text.Trim(), ConfigurationManager.AppSettings["EncryptionKey"]);
        }

        if (((this.UpUserID == 0) && (HOTOMOTO.BUS.UserManagement.CheckUser(CARETTA.COM.Encryption.Encrypt(UserName, ConfigurationManager.AppSettings["EncryptionKey"].ToString())) == 0)) || (this.UpUserID != 0)) {

            DataTable dtAddressTypes = GetAddressTypes();
            DataTable dtAccessOptions = GetAccessOptions();

            DataTable dtAddress = InitializeAddressDt();
            DataTable dtAccess = InitializeAccessDt();

            foreach (DataRow dr in dtAddressTypes.Rows) {
                AddAddress(ref dtAddress, int.Parse(((HiddenField)pnlAddress.FindControl("hdAddressID" + "|" + dr["AddressTypeID"].ToString())).Value),
                            Convert.ToInt32(dr["AddressTypeID"]),
                            ((TextBox)pnlAddress.FindControl("txtStreetAddress" + "|" + dr["AddressTypeID"].ToString())).Text,
                            ((TextBox)pnlAddress.FindControl("txtPostalCode" + "|" + dr["AddressTypeID"].ToString())).Text,
                            ((TextBox)pnlAddress.FindControl("txtTown" + "|" + dr["AddressTypeID"].ToString())).Text,
                            int.Parse(((DropDownList)pnlAddress.FindControl("ddlCountries" + "|" + dr["AddressTypeID"].ToString())).Text),
                            int.Parse(((DropDownList)pnlAddress.FindControl("ddlCities" + "|" + dr["AddressTypeID"].ToString())).Text),
                            Convert.ToDateTime(((HiddenField)pnlAddress.FindControl("hdAddressCreateDate|" + dr["AddressTypeID"].ToString())).Value));

            }

            foreach (DataRow dr in dtAccessOptions.Rows) {
                AddAccess(ref dtAccess, int.Parse(((HiddenField)pnlAccess.FindControl("hdAccessOptionID" + "|" + dr["AccessTypeID"].ToString())).Value),
                            Convert.ToInt32(dr["AccessTypeID"]),
                            ((TextBox)pnlAccess.FindControl("txtAccess" + "|" + dr["AccessTypeID"].ToString())).Text,
                            Convert.ToDateTime(((HiddenField)pnlAddress.FindControl("hdAccessCreateDate|" + dr["AccessTypeID"].ToString())).Value));
            }


            HOTOMOTO.BUS.UserManagement objUser = new HOTOMOTO.BUS.UserManagement();
            objUser.Save(this.UpUserID, this.SessRoot.LanguageID,
                        int.Parse(ddlPerm.SelectedValue), this.SessRoot.UserRoleID,
                        UserName, Password,
                        txtName.Text, txtLastName.Text, this.SessRoot.UserID, this.SessRoot.CustomerID, txtEmail.Text,
                        Convert.ToDateTime(hdUserCreateDate.Value),
                        this.SessRoot.UserID, dtAddress, dtAccess);

            this.Saved = 1;
        }
        else {
            ModalPopup1.Show(UserControls_ModalPopup_ModalPopup.Icons.error, "KULLANICI EKLEME HATASI", "Bu Kullanýcý Ýsmi Kullanýlmaktadýr");
        }
    }
}
