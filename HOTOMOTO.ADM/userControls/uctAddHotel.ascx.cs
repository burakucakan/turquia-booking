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

public partial class userControls_ucAddHotel : BaseUserControl
{
    string strValidationGroup = "vgHotelInsertion";
    string strTextBoxCssClass = "textBox p75";
    string strLabelCssClass = "label";
    //int intBusinessAddressType = 1;

    protected void Page_Load(object sender, EventArgs e)
    {
        UctSubMenu1.SearchPanelVisible = false;
        UctMessage1.Visible = false;

        if (!Page.IsPostBack)
        {
            // Otel zinciri
            CARETTA.COM.DDLHelper.BindDDL(ref ddlHotelChain, HOTOMOTO.APEX.HotelChains.GetAllHotelChainsDataSet(this.SessRoot.LanguageID).Tables[0], "ChainName", "HotelChainID", "0", " ", "0");
            // Otel sýnýfý
            CARETTA.COM.DDLHelper.BindDDL(ref ddlHotelClass, HOTOMOTO.APEX.HotelClasses.GetAllHotelClassesDataSet(this.SessRoot.LanguageID).Tables[0], "Title", "HotelClassID", "");

            if (Request.QueryString["hotelid"] != null)
            {
                LoadHotelData(int.Parse(Request.QueryString["hotelid"]));
                UctSubMenu1.AddLink("rooms.aspx?hotelid=" + Request.QueryString["hotelid"] , "Oda Listesi");
                UctSubMenu1.AddLink("addroom.aspx?hotelid=" + Request.QueryString["hotelid"], "Oda Ekle");
            }
            else
            {
                UctSubMenu1.AddLink("rooms.aspx", "Oda Listesi");
                UctSubMenu1.AddLink("addroom.aspx", "Oda Ekle");
            }

            
        }
    }

    /// <summary>
    /// Otel güncelleme için form alanlarýný doldurur.
    /// </summary>
    /// <param name="HotelID">Veritabanýndan alýnacak otelin id'si.</param>
    private void LoadHotelData(int HotelID)
    {
        HOTOMOTO.APEX.Hotels hotel = new HOTOMOTO.APEX.Hotels(this.SessRoot.LanguageID);
        hotel.Load(HotelID);

        // Otel sýnýfýný seç
        ddlHotelClass.SelectedIndex = -1;
        foreach (ListItem li in ddlHotelClass.Items)
        {
            if (int.Parse(li.Value) == hotel.HotelClassID)
            {
                li.Selected = true;
                break;
            }
        }

        // Otel zincirini seç
        ddlHotelChain.SelectedIndex = -1;
        foreach (ListItem li in ddlHotelChain.Items)
        {
            if (int.Parse(li.Value) == hotel.HotelChainID)
            {
                li.Selected = true;
                break;
            }
        }

        txtCheckin.Text = hotel.CheckInTime;
        txtCheckout.Text = hotel.CheckOutTime;
        chkRoomRequestable.Checked = hotel.isNewRoomRequestable;
        ddlFirstChildAge.SelectedValue = hotel.ChildFirstAgeLimit.ToString();
        txtFirstAgeDiscount.Text = hotel.ChildFirstAgeDiscount.ToString();
        ddlSecondChildAge.SelectedValue = hotel.ChildSecondAgeLimit.ToString();
        txtSecondAgeDiscount.Text = hotel.ChildSecondAgeDiscount.ToString();

        // Otel adreslerini doldur
        UctAddress1.LoadHotelAddress();
        UctHotelProperties1.LoadHotelProperties(HotelID);

        int tabIndex = 0;
        // Otel isimlerini doldur
        foreach (DataRow dr in HOTOMOTO.BUS.Language.GetAllLanguages().Rows)
        {
            if (((bool)dr[2]) == true)
            {
                ((TextBox)tabLanguages.Tabs[tabIndex].FindControl("txtHotelName" + dr[0].ToString())).Text = hotel.GetHotelName(Convert.ToInt32(dr[0]));
                ((TextBox)tabLanguages.Tabs[tabIndex].FindControl("txtHotelMotto" + dr[0].ToString())).Text = hotel.GetMotto(Convert.ToInt32(dr[0]));
                ((TextBox)tabLanguages.Tabs[tabIndex].FindControl("txtHotelDescription" + dr[0].ToString())).Text = hotel.GetDescription(Convert.ToInt32(dr[0]));
                ((TextBox)tabLanguages.Tabs[tabIndex].FindControl("txtHotelDirections" + dr[0].ToString())).Text = hotel.GetDirections(Convert.ToInt32(dr[0]));
                tabIndex++;
            }
        }

        //s
    }

    void Page_Init(object sender, EventArgs e)
    {
        btnPublish.ValidationGroup = strValidationGroup;

        int tabIndex = 0;
        foreach (DataRow dr in HOTOMOTO.BUS.Language.GetAllLanguages().Rows)
        {
            if (((bool)dr[2]) == true)
            {
                TabPanel tab = new AjaxControlToolkit.TabPanel();
                tab.ID = tabIndex.ToString();
                tab.HeaderText = dr[1].ToString();

                Table table = new Table();
                TableRow tr;
                TableCell td;
                RequiredFieldValidator reqfv;

                // Otel adý alaný
                tr = new TableRow();
                Label lbl = new Label();
                lbl.CssClass = strLabelCssClass;
                TextBox txt = new TextBox();
                txt.CssClass = strTextBoxCssClass;

                lbl.Text = "Otel Adý : ";
                lbl.ID = "lblHotelName" + dr[0].ToString();
                txt.ID = "txtHotelName" + dr[0].ToString();
                txt.TextMode = TextBoxMode.SingleLine;
                txt.Text = "Name - Er" + dr[0].ToString();
                td = new TableCell();
                td.Controls.Add(lbl);
                tr.Cells.Add(td);
                td = new TableCell();
                td.Controls.Add(txt);
                tr.Cells.Add(td);

                reqfv = new RequiredFieldValidator();
                reqfv.ErrorMessage = "*";
                reqfv.ValidationGroup = strValidationGroup;
                reqfv.SetFocusOnError = true;
                reqfv.ControlToValidate = txt.ID;
                reqfv.ID = "reqfvHotelName" + dr[0].ToString();
                td = new TableCell();
                td.Controls.Add(reqfv);
                tr.Cells.Add(td);
                table.Rows.Add(tr);

                // Otel Sloganý
                tr = new TableRow();
                lbl = new Label();
                lbl.CssClass = strLabelCssClass;
                txt = new TextBox();
                txt.CssClass = strTextBoxCssClass;

                lbl.Text = "Otel Sloganý : ";
                lbl.ID = "lblHotelMotto" + dr[0].ToString();
                txt.ID = "txtHotelMotto" + dr[0].ToString();
                txt.TextMode = TextBoxMode.SingleLine;
                txt.Text = "Mot - Er" + dr[0].ToString();
                td = new TableCell();
                td.Controls.Add(lbl);
                tr.Cells.Add(td);
                td = new TableCell();
                td.Controls.Add(txt);
                tr.Cells.Add(td);

                //reqfv = new RequiredFieldValidator();
                //reqfv.ErrorMessage = "*";
                //reqfv.ValidationGroup = strValidationGroup;
                //reqfv.SetFocusOnError = true;
                //reqfv.ControlToValidate = txt.ID;
                //reqfv.ID = "reqfvHotelMotto" + dr[0].ToString();
                td = new TableCell();
                //td.Controls.Add(reqfv);
                tr.Cells.Add(td);
                table.Rows.Add(tr);

                // Otel Tanýmý
                tr = new TableRow();
                lbl = new Label();
                lbl.CssClass = strLabelCssClass;
                txt = new TextBox();
                txt.CssClass = strTextBoxCssClass;

                lbl.Text = "Otel Tanýmý : ";
                lbl.ID = "lblHotelDescription" + dr[0].ToString();
                txt.ID = "txtHotelDescription" + dr[0].ToString();
                txt.TextMode = TextBoxMode.MultiLine;
                txt.Text = "Desc - Er" + dr[0].ToString();
                td = new TableCell();
                td.VerticalAlign = VerticalAlign.Top;
                td.Controls.Add(lbl);
                tr.Cells.Add(td);
                td = new TableCell();
                td.CssClass = "txtarea";
                td.Controls.Add(txt);
                tr.Cells.Add(td);

                reqfv = new RequiredFieldValidator();
                reqfv.ErrorMessage = "*";
                reqfv.ValidationGroup = strValidationGroup;
                reqfv.SetFocusOnError = true;
                reqfv.ControlToValidate = txt.ID;
                reqfv.ID = "reqfvHotelDescription" + dr[0].ToString();
                td = new TableCell();
                td.VerticalAlign = VerticalAlign.Top;
                td.Controls.Add(reqfv);
                tr.Cells.Add(td);
                table.Rows.Add(tr);

                // Otel Yeri Tarifi
                tr = new TableRow();
                lbl = new Label();
                lbl.CssClass = strLabelCssClass;
                txt = new TextBox();
                txt.CssClass = strTextBoxCssClass;
                txt.Text = "Dir - Er" + dr[0].ToString();
                lbl.Text = "Otelin Yeri : ";
                lbl.ID = "lblHotelDirections" + dr[0].ToString();
                txt.ID = "txtHotelDirections" + dr[0].ToString();
                txt.TextMode = TextBoxMode.MultiLine;
                td = new TableCell();
                td.VerticalAlign = VerticalAlign.Top;
                td.Controls.Add(lbl);
                tr.Cells.Add(td);
                td = new TableCell();
                td.CssClass = "txtarea";
                td.Controls.Add(txt);
                tr.Cells.Add(td);

                //reqfv = new RequiredFieldValidator();
                //reqfv.ErrorMessage = "*";
                //reqfv.ValidationGroup = strValidationGroup;
                //reqfv.SetFocusOnError = true;
                //reqfv.ControlToValidate = txt.ID;
                //reqfv.ID = "reqfvHotelDirections" + dr[0].ToString();
                td = new TableCell();
                //td.VerticalAlign = VerticalAlign.Top;
                //td.Controls.Add(reqfv);
                tr.Cells.Add(td);
                table.Rows.Add(tr);

                tab.Controls.Add(table);
                tabLanguages.Tabs.Add(tab);
                tabIndex++;
            }
            if (tabLanguages.Tabs.Count > 0)
                tabLanguages.ActiveTabIndex = 0;
        }
    }

    // Yayýnla butonu
    protected void btnPublish_Click(object sender, ImageClickEventArgs e)
    {
        SaveHotel();
    }

    private void SaveHotel()
    {
        int hotelID = 0;
        if (Request.QueryString["hotelid"] != null)
            hotelID = int.Parse(Request.QueryString["hotelid"]);

        if (hotelID > 0)
        {
            if (!UctHotelImages1.isDefaultImageChosen(true))
            {
                UctMessage1.Type = MessageType.Error;
                UctMessage1.Message = "Varsayýlan resim seçiminde hata oluþtu!";
                UctMessage1.Visible = true;
            }
            else
            {


                int HotelID = 0;
                
                

                

                

                HOTOMOTO.APEX.Hotels Hotel = new HOTOMOTO.APEX.Hotels();
                Hotel.Load(hotelID);
                Hotel.ModifiedBy = SessRoot.UserID;
                Hotel.ModifyDate = DateTime.Now;

                Hotel.HotelChainID = Convert.ToInt32(ddlHotelChain.SelectedValue);
                if (ddlHotelClass.Items.Count > 0)
                    Hotel.HotelClassID = Convert.ToInt32(ddlHotelClass.SelectedValue);
                else
                    Hotel.HotelClassID = 0;

                Hotel.CheckInTime = txtCheckin.Text;
                Hotel.CheckOutTime = txtCheckout.Text;
                Hotel.isNewRoomRequestable = chkRoomRequestable.Checked;
                Hotel.ChildFirstAgeLimit = int.Parse(ddlFirstChildAge.SelectedValue);
                Hotel.ChildFirstAgeDiscount = int.Parse(txtFirstAgeDiscount.Text);
                Hotel.ChildSecondAgeLimit = int.Parse(ddlSecondChildAge.SelectedValue);
                Hotel.ChildSecondAgeDiscount = int.Parse(txtSecondAgeDiscount.Text);

                Hotel.CountryID = UctAddress1.CountryID;
                Hotel.CityID = UctAddress1.CityID;
                Hotel.ModifiedBy = SessRoot.UserID;
                Hotel.ModifyDate = DateTime.Now;
                Hotel.isActive = true;

                // Otelin dile baðlý özelliklerini güncelle
                Hashtable htLanguages = HOTOMOTO.APEX.Languages.GetAllLanguages();

                int tabIndex = 0;
                foreach (HOTOMOTO.APEX.Languages Language in htLanguages.Values)
                {
                    Hotel.SetDescription(((TextBox)tabLanguages.Tabs[tabIndex].FindControl("txtHotelDescription" + (tabIndex + 1))).Text, Language.LanguageID);
                    Hotel.SetDirections(((TextBox)tabLanguages.Tabs[tabIndex].FindControl("txtHotelDirections" + (tabIndex + 1))).Text, Language.LanguageID);
                    Hotel.SetMotto(((TextBox)tabLanguages.Tabs[tabIndex].FindControl("txtHotelMotto" + (tabIndex + 1))).Text, Language.LanguageID);
                    Hotel.SetHotelName(((TextBox)tabLanguages.Tabs[tabIndex].FindControl("txtHotelName" + (tabIndex + 1))).Text, Language.LanguageID);
                    tabIndex++;
                }

                Hotel.Save();

                // HotelPlaceDistance tablosunu güncelleme
                UctHotelPlaceDistances1.UpdateHotelPlaceDistance();

                //    // Otel özelliklerini güncelleme
                UctHotelProperties1.UpdateHotelProperies();

                //    // Otel adresini güncelleme
                UctAddress1.SaveHotelAddress();

                //    // Oda resimleri
                UctHotelImages1.UpdateHotelImages(Hotel.HotelID);

                UctMessage1.Message = "Otel güncellenmiþtir...";
                UctMessage1.Type = MessageType.Information;
                UctMessage1.AddLink("Hotels.aspx", "Oteller...");
                UctMessage1.Visible = true;
            }
        }
        else
        {
            if (!UctHotelImages1.isDefaultImageChosen(false))
            {
                UctMessage1.Type = MessageType.Error;
                UctMessage1.Message = "Varsayýlan resim seçiminde hata oluþtu!";
                UctMessage1.Visible = true;
            }
            else
            {
                UctMessage1.Visible = false;
                // Adresi kaydetme
                int AddressID = 0;
                HOTOMOTO.APEX.Addresses address = new HOTOMOTO.APEX.Addresses();
                address.CountryID = UctAddress1.CountryID;
                address.CityID = UctAddress1.CityID;
                address.PostalCode = UctAddress1.PostalCode;
                address.StreetAddress = UctAddress1.StreetAddress;
                address.Town = UctAddress1.Town;
                address.AddressTypeID = 1;
                address.isDefault = true;
                address.isActive = true;
                address.CreateDate = DateTime.Now;
                AddressID = address.Save();

                // Otelin dile göre deðiþmeyen özelliklerini kaydetme
                int HotelID = 0;
                HOTOMOTO.APEX.Hotels hotel = new HOTOMOTO.APEX.Hotels(this.SessRoot.LanguageID);
                hotel.HotelChainID = Convert.ToInt32(ddlHotelChain.SelectedValue);
                if (ddlHotelClass.Items.Count > 0)
                    hotel.HotelClassID = Convert.ToInt32(ddlHotelClass.SelectedValue);
                else
                    hotel.HotelClassID = 0;

                hotel.CheckInTime = txtCheckin.Text;
                hotel.CheckOutTime = txtCheckout.Text;
                hotel.isNewRoomRequestable = chkRoomRequestable.Checked;
                hotel.ChildFirstAgeLimit = int.Parse(ddlFirstChildAge.SelectedValue);
                hotel.ChildFirstAgeDiscount = int.Parse(txtFirstAgeDiscount.Text);
                hotel.ChildSecondAgeLimit = int.Parse(ddlSecondChildAge.SelectedValue);
                hotel.ChildSecondAgeDiscount = int.Parse(txtSecondAgeDiscount.Text);

                hotel.CountryID = UctAddress1.CountryID;
                hotel.CityID = UctAddress1.CityID;
                hotel.CreatedBy = SessRoot.UserID;
                hotel.CreateDate = DateTime.Now;
                hotel.ModifiedBy = SessRoot.UserID;
                hotel.ModifyDate = DateTime.Now;
                hotel.isActive = true;

                // Otelin dile baðlý özelliklerini kaydetme
                Hashtable htLanguages = HOTOMOTO.APEX.Languages.GetAllLanguages();
                int TabIndex = 0;
                foreach (HOTOMOTO.APEX.Languages Language in htLanguages.Values)
                {
                    hotel.SetDescription(((TextBox)tabLanguages.Tabs[TabIndex].FindControl("txtHotelDescription" + (TabIndex + 1))).Text, Language.LanguageID);
                    hotel.SetDirections(((TextBox)tabLanguages.Tabs[TabIndex].FindControl("txtHotelDirections" + (TabIndex + 1))).Text, Language.LanguageID);
                    hotel.SetMotto(((TextBox)tabLanguages.Tabs[TabIndex].FindControl("txtHotelMotto" + (TabIndex + 1))).Text, Language.LanguageID);
                    hotel.SetHotelName(((TextBox)tabLanguages.Tabs[TabIndex].FindControl("txtHotelName" + (TabIndex + 1))).Text, Language.LanguageID);
                    TabIndex++;
                }
                HotelID = hotel.Save();

                // Hotel-Adres tablosuna kaydetme
                HOTOMOTO.APEX.Hotels_Addresses HotelAddress = new HOTOMOTO.APEX.Hotels_Addresses();
                HotelAddress.HotelID = HotelID;
                HotelAddress.AddressID = AddressID;
                HotelAddress.Save();

                // Hotel-Mesafe tablosuna girilmesi
                UctHotelPlaceDistances1.SaveHotelPlaceDistances(HotelID);

                //        // Hotel-Properties tablosuna girilmesi
                UctHotelProperties1.SaveHotelProperties(HotelID);

                //        // HotelImages tablosunun dolmasý
                UctHotelImages1.SaveHotelImages(HotelID);

                if (chkContinue.Checked)
                {
                    //UctAddress1.CleanValues();
                    UctMessage1.Message = "Otel eklenmiþtir...";
                    UctMessage1.Type = MessageType.Information;
                    UctMessage1.AddLink("Hotels.aspx", "Oteller...");
                    UctMessage1.Visible = true;
                }
                else
                    Response.Redirect("~/Default.aspx");
            }
        }
    }

}
