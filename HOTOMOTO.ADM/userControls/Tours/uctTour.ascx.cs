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

public partial class userControls_Tours_uctTour : BaseUserControl
{

    private string strValidationGroup = "TourValidation";

    public int TourID
    {
        get {
            if (Request.QueryString["tourid"] != null)
            {
                ViewState.Add("TIDA", Convert.ToInt32(Request.QueryString["tourid"]));
            }
            return ViewState["TIDA"] == null ? 0 : Convert.ToInt32(ViewState["TIDA"]); 
        }
        set { ViewState.Add("TIDA", value); }
    }

    protected void Page_Init(object sender, EventArgs e)
    {
        UctMLTabs1.MLValidationGroup = strValidationGroup;
        UctMLTabs1.ClearControls();
        UctMLTabs1.AddTextArea("TN", "Tur Adý", true, false, 0, 0);
        UctMLTabs1.AddTextArea("TD", "Tur Tanýmý", true, true, 500, 100);
        UctMLTabs1.AddTextArea("TR", "Tavsiye", true, true, 500, 50);
        UctMLTabs1.GenerateTabs();
    }


    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Request.QueryString["tourid"] != null)
            {
                this.TourID = Convert.ToInt32(Request.QueryString["tourid"]);
                UctTourCities1.TourID = this.TourID;
                UctTourImages1.TourID = this.TourID;
                UctTourProperties1.TourID = this.TourID;
            }
            
            LoadAll();
            
        }
        
        
    }

    protected void btnPublish_Click(object sender, ImageClickEventArgs e)
    {
        SaveAll();
    }

    public void LoadAll()
    {
        if (this.TourID != 0)
        {
            HOTOMOTO.APEX.Tours objTour;
            DataTable dtTourRecurrence;

            objTour = new HOTOMOTO.APEX.Tours();
            objTour.Load(this.TourID);

            cbAcc.Checked = objTour.hasAccomodation;
            txtPrAEUR.Text = objTour.AccomodationPriceEUR.ToString();
            txtPrAUSD.Text = objTour.AccomodationPriceUSD.ToString();

            Hashtable htLanguages = HOTOMOTO.APEX.Languages.GetAllLanguages();
            foreach (HOTOMOTO.APEX.Languages Language in htLanguages.Values)
            {
                UctMLTabs1.SetValue(Language.LanguageID, "TD", objTour.GetDescription(Language.LanguageID));
                UctMLTabs1.SetValue(Language.LanguageID, "TN", objTour.GetName(Language.LanguageID));
                UctMLTabs1.SetValue(Language.LanguageID, "TR", objTour.GetRecommendation(Language.LanguageID));
            }

            calEndDate.SetDate(objTour.EndDate);
            txtPrEUR.Text = objTour.EURPrice.ToString();
            cbTra.Checked = objTour.hasFlight;
            txtPRTUSD.Text = objTour.FlightPriceUSD.ToString();
            txtPRTEUR.Text = objTour.FlightPriceEUR.ToString();

            cbIsActive.Checked = objTour.isActive;
            txtMinCap.Text = objTour.MinCapacity.ToString();

            calStartDate.SetDate(objTour.StartDate);
            txtPrUSD.Text = objTour.USDPrice.ToString();

            UctTourCities1.TourID = this.TourID;
            UctTourCities1.LoadTourCities();

            UctTourProperties1.TourID = this.TourID;
            UctTourProperties1.LoadAll();

            UctTourImages1.TourID = this.TourID;
            UctTourImages1.LoadAll();

            dtTourRecurrence = new DataTable();
            dtTourRecurrence = HOTOMOTO.APEX.Custom.SPExec_Tour.GetTourRecurrencesByTourID(this.TourID);

            foreach (ListItem liDay in cblDays.Items)
            {
                liDay.Selected = false;
            }

            if (dtTourRecurrence.Rows.Count > 0)
            {
                ddlStartDay.SelectedValue = dtTourRecurrence.Rows[0]["StartDay"].ToString();

                if (Convert.ToBoolean(dtTourRecurrence.Rows[0]["isDaily"]))
                {
                    ddlisDaily.SelectedValue = "day";
                }
                else
                {
                    ddlisDaily.SelectedValue = "notday";
                }

                foreach (ListItem liDay in cblDays.Items)
                {
          
                    if ((liDay.Value == "monday") && (Convert.ToBoolean(dtTourRecurrence.Rows[0]["Monday"])))
                    {
                        liDay.Selected = true;
                    }
                    if ((liDay.Value == "tuesday") && (Convert.ToBoolean(dtTourRecurrence.Rows[0]["Tuesday"])))
                    {
                        liDay.Selected = true;
                    }
                    if ((liDay.Value == "wednesday") && (Convert.ToBoolean(dtTourRecurrence.Rows[0]["Wednesday"])))
                    {
                        liDay.Selected = true;
                    }
                    if ((liDay.Value == "thursday") && (Convert.ToBoolean(dtTourRecurrence.Rows[0]["Thursday"])))
                    {
                        liDay.Selected = true;
                    }
                    if ((liDay.Value == "friday") && (Convert.ToBoolean(dtTourRecurrence.Rows[0]["Friday"])))
                    {
                        liDay.Selected = true;
                    }
                    if ((liDay.Value == "saturday") && (Convert.ToBoolean(dtTourRecurrence.Rows[0]["Saturday"])))
                    {
                        liDay.Selected = true;
                    }
                    if ((liDay.Value == "sunday") && (Convert.ToBoolean(dtTourRecurrence.Rows[0]["Sunday"])))
                    {
                        liDay.Selected = true;
                    }
                }
            }

        }
    }

    public void SaveAll()
    {
        HOTOMOTO.APEX.Tours objTour;
        HOTOMOTO.APEX.TourRecurrence objTourRecurrences;
 
        objTour = new HOTOMOTO.APEX.Tours();
        if (this.TourID != 0)
        {
            objTour.Load(this.TourID);
        }
        objTour.hasAccomodation = cbAcc.Checked;
        objTour.AccomodationPriceEUR = 0;
        objTour.AccomodationPriceUSD = 0;
        if (cbAcc.Checked)
        {
            objTour.AccomodationPriceEUR = Convert.ToInt32(txtPrAEUR.Text);
            objTour.AccomodationPriceUSD = Convert.ToInt32(txtPrAUSD.Text);
        }
        objTour.CountryID = UctTourCities1.CountryID;

        if (this.TourID == 0)
        {
            objTour.CreateDate = DateTime.Now;
            objTour.CreatedBy = SessRoot.UserID;
        }

        Hashtable htLanguages = HOTOMOTO.APEX.Languages.GetAllLanguages();
        foreach (HOTOMOTO.APEX.Languages Language in htLanguages.Values)
        {
            objTour.SetDescription(UctMLTabs1.GetValue(Language.LanguageID, "TD"), Language.LanguageID);
            objTour.SetName(UctMLTabs1.GetValue(Language.LanguageID, "TN"), Language.LanguageID);
            objTour.SetRecommendation(UctMLTabs1.GetValue(Language.LanguageID, "TR"), Language.LanguageID);
        }
        objTour.EndCityID = UctTourCities1.EndCityID;
        objTour.EndDate = calEndDate.GetDate();
        objTour.EURPrice = Convert.ToDouble(txtPrEUR.Text);
        objTour.hasFlight = cbTra.Checked;
        objTour.FlightPriceEUR = 0;
        objTour.FlightPriceUSD = 0;
        if (cbTra.Checked)
        {
            objTour.FlightPriceEUR = Convert.ToInt32(txtPRTEUR.Text);
            objTour.FlightPriceUSD = Convert.ToInt32(txtPRTUSD.Text);
        }
        objTour.isActive = cbIsActive.Checked;
        objTour.isRecurrent = false;
        objTour.MinCapacity = Convert.ToInt32(txtMinCap.Text);
        objTour.ModifiedBy = this.SessRoot.UserID;
        objTour.ModifyDate = DateTime.Now;
        objTour.StartCityID = UctTourCities1.StartCityID;
        objTour.StartDate = calStartDate.GetDate();
        objTour.USDPrice = Convert.ToDouble(txtPrUSD.Text);

        if (this.TourID == 0)
        {
            this.TourID = objTour.Save();
        }
        else
        {
            objTour.TourID = this.TourID;
            objTour.Save();
        }

        HOTOMOTO.APEX.Custom.SPExec_Tour.RemoveTourRecurrenceByTourID(this.TourID);

        objTourRecurrences = new HOTOMOTO.APEX.TourRecurrence();
        objTourRecurrences.Monday = false;
        objTourRecurrences.Tuesday = false;
        objTourRecurrences.Wednesday = false;
        objTourRecurrences.Thursday = false;
        objTourRecurrences.Friday = false;
        objTourRecurrences.Saturday = false;
        objTourRecurrences.Sunday = false;

        foreach (ListItem liDay in cblDays.Items)
        {
            if ((liDay.Value == "monday") && (liDay.Selected))
            {
                objTourRecurrences.Monday = true;
            }
            if ((liDay.Value == "tuesday") && (liDay.Selected))
            {
                objTourRecurrences.Tuesday = true;
            }
            if ((liDay.Value == "wednesday") && (liDay.Selected))
            {
                objTourRecurrences.Wednesday  = true;
            }
            if ((liDay.Value == "thursday") && (liDay.Selected))
            {
                objTourRecurrences.Thursday = true;
            }
            if ((liDay.Value == "friday") && (liDay.Selected))
            {
                objTourRecurrences.Friday  = true;
            }
            if ((liDay.Value == "saturday") && (liDay.Selected))
            {
                objTourRecurrences.Saturday = true;
            }
            if ((liDay.Value == "sunday") && (liDay.Selected))
            {
                objTourRecurrences.Sunday = true;
            }
        }

        if (ddlisDaily.SelectedValue == "day")
        {
            objTourRecurrences.isDaily = true;
        }
        else
        {
            objTourRecurrences.isDaily = false;
        }

        objTourRecurrences.TourID = this.TourID;
        objTourRecurrences.StartDay = Convert.ToInt32(ddlStartDay.SelectedValue);
        objTourRecurrences.Save();

        UctTourCities1.TourID = this.TourID;
        UctTourCities1.SaveTourCities();

        UctTourProperties1.TourID = this.TourID;
        UctTourProperties1.SaveTourProperties();


        UctTourImages1.TourID = this.TourID;
        UctTourImages1.UploadAll();

        Response.Redirect("~/Tours.aspx");
    }

}
