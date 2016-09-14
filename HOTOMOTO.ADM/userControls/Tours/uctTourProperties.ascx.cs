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

public partial class userControls_Tours_uctTourProperties : BaseUserControl
{
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
        if (!Page.IsPostBack)
        {
            LoadAll();
        }
    }
   

    protected void Page_Load(object sender, EventArgs e)
    {
        //if (!Page.IsPostBack)
        //{

        //    if (cblTProp.Items.Count == 0)
        //    {
        //        GenerateCBL();
        //    }
        //    //if (SessRoot.ChildID  > 0)
        //    //{
        //    //    
        //    //}
        //}
    }

    public void LoadAll()
    {
       
        GenerateCBL();
  
        if (this.TourID != 0)
        {
            DataTable dtTourProperties = new DataTable();
            dtTourProperties = HOTOMOTO.APEX.Custom.SPExec_Tour.GetTourPropertiesByTourID(this.SessRoot.LanguageID, this.TourID);
            foreach (DataRow drTourProperty in dtTourProperties.Rows)
            {
                foreach (ListItem liTourProperty in cblTProp.Items)
                {
                    if (Convert.ToInt32(drTourProperty["TourPropertyID"]) == Convert.ToInt32(liTourProperty.Value))
                        liTourProperty.Selected = true;
                }
            }
        }
    }


    private void GenerateCBL()
    {
        CARETTA.COM.CBLHelper.BindCBL(ref cblTProp, HOTOMOTO.APEX.TourProperties.GetAllTourPropertiesDataSet(this.SessRoot.LanguageID).Tables[0], "Property", "TourPropertyID");
    }

    public void SaveTourProperties()
    {
        HOTOMOTO.APEX.Custom.SPExec_Tour.RemoveTourPropertiesByTourID(this.TourID);

        HOTOMOTO.APEX.Tours_TourProperties objTTourProp = new HOTOMOTO.APEX.Tours_TourProperties();

        foreach (ListItem liTProp in cblTProp.Items)
        {
            if (liTProp.Selected)
            {
                objTTourProp = new HOTOMOTO.APEX.Tours_TourProperties();
                objTTourProp.TourID = this.TourID;
                objTTourProp.TourPropertyID = Convert.ToInt32(liTProp.Value);
                objTTourProp.Save();
            }
        }
    }


}
