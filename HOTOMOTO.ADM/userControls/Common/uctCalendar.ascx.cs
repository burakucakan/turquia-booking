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
using CARETTA.COM;

public partial class Admin_UserControls_Common_uctCalendar : System.Web.UI.UserControl
{

 
    public bool IsEmpty
    {
        get {
            if (ViewState["IE"] == null)
            {
                ViewState.Add("IE", false);
            }
            return (bool)ViewState["IE"]; }
        set { ViewState.Add("IE",value); }
    }

    private  DateTime  TheSetDate
    {
        get
        {
            if (ViewState["DS"] == null)
            {
                ViewState.Add("DS", DateTime.MaxValue);
            }
            return (DateTime)ViewState["DS"];
        }
        set { ViewState.Add("DS", value); }
    }

    protected void Page_Init(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            Initialize();
        }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        
    }

    public void Initialize()
    {
        
            DDLHelper.LoadNumberDDL(ref drpDay, 31);
            DDLHelper.LoadNumberDDL(ref drpMonth, 12);
            DDLHelper.LoadNumberDDL(ref drpYear, DateTime.Today.Year + 10, 1, 1920);
            if (IsEmpty)
            {
                drpDay.Items.Insert(0, new ListItem("---", "0"));
                drpMonth.Items.Insert(0, new ListItem("---", "0"));
                drpYear.Items.Insert(0, new ListItem("---", "0"));
            }
            else
            {
                if (this.TheSetDate == DateTime.MaxValue)
                {
                    drpDay.SelectedValue = DateTime.Now.Day.ToString();
                    drpMonth.SelectedValue = DateTime.Now.Month.ToString();
                    drpYear.SelectedValue = DateTime.Now.Year.ToString();
                }
                else
                {
                    drpDay.SelectedValue = this.TheSetDate.Day.ToString();
                    drpMonth.SelectedValue = this.TheSetDate.Month.ToString();
                    drpYear.SelectedValue = this.TheSetDate.Year.ToString();
                }
               
            }
    }



    public void SetDate(DateTime inDat)
    {
        drpDay.SelectedValue = inDat.Day.ToString() ;
        drpMonth.SelectedValue = inDat.Month.ToString();
        drpYear.SelectedValue = inDat.Year.ToString();
        this.TheSetDate = inDat;
    }

    public DateTime GetDate()
    {

        int intDay, intMonth, intYear;
        intDay = Convert.ToInt32(drpDay.SelectedValue);
        intMonth = Convert.ToInt32(drpMonth.SelectedValue);
        intYear = Convert.ToInt32(drpYear.SelectedValue);

        if ((intDay != 0) && (intMonth != 0) && (intYear != 0))
        {
            try
            {
                return new DateTime(intYear, intMonth, intDay);
            }
            catch (Exception ex)
            {
                return DateTime.MaxValue;
            }
        }
        else
        {
            return DateTime.MaxValue;
        }

    }

}
