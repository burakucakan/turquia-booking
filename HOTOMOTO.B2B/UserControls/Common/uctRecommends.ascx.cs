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
using System.Data.SqlClient;

public partial class UserControls_Common_uctRecommends : BaseUserControl
{
    private string title;

    public string ptitle
    {
        get { return title; }
        set { title = value; }
    }

    public DataTable dtRecommendation
    {
        get { return (ViewState["dtRecommendation"] == null ? InitializeDtNewRcm() : (DataTable)(ViewState["dtRecommendation"])); }
        set { ViewState["dtRecommendation"] = value; }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            DataTable dtRcm = HOTOMOTO.BUS.Recommendations.GetRecommendations();
            int IDValue = 0;
            HOTOMOTO.BUS.Hotels objHotel;
            DataTable dtTempTour;
            foreach (DataRow dr in dtRcm.Rows)
            {
                IDValue = Convert.ToInt32(dr["IDValue"]);
                if (((HOTOMOTO.BUS.Enumerations.RecommendationType)Convert.ToInt32(dr["RecommendationType"])) == HOTOMOTO.BUS.Enumerations.RecommendationType.Hotel) {
                    objHotel = new HOTOMOTO.BUS.Hotels(IDValue, this.SessRoot.LanguageID);
                    AddNewRcm(objHotel.HotelName, objHotel.Description);
                }
                else if (((HOTOMOTO.BUS.Enumerations.RecommendationType)Convert.ToInt32(dr["RecommendationType"])) == HOTOMOTO.BUS.Enumerations.RecommendationType.Tour) {
                    dtTempTour = HOTOMOTO.BUS.Tour.GetTour(this.SessRoot.LanguageID, IDValue);
                    AddNewRcm(dtTempTour.Rows[0]["Name"].ToString(), dtTempTour.Rows[0]["Description"].ToString());
                }
            }
        }   
    }

    private void AddNewRcm(string Name, string Description) {
        DataRow dr = this.dtRecommendation.NewRow();
        dr["RowID"] = this.dtRecommendation.Rows.Count + 1;
        dr["Name"] = Name;
        dr["Description"] = Description;
        dtRecommendation.Rows.Add(dr);
    }

    private DataTable InitializeDtNewRcm() {
        DataTable dtNewRcm = new DataTable();
        dtNewRcm.Columns.AddRange(new DataColumn[] { new DataColumn("RowID"), new DataColumn("Name"), new DataColumn("Description") });
        this.dtRecommendation = dtNewRcm;
        return this.dtRecommendation;
    }

}
