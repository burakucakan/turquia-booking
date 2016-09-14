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

public partial class userControls_uctRoomProperties : BaseUserControl
{
	
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {

            if (cblRoomProperties.Items.Count == 0)
            {
                GenerateCBL();
            }
            //if (SessRoot.ChildID  > 0)
            //{
            //    
            //}
        }
    }

    public void LoadByRoomID(int RoomID)
    {
        GenerateCBL();
        DataTable dtRoomProperties = new DataTable();
        dtRoomProperties = HOTOMOTO.BUS.Rooms.GetPropertiesByRoomID(this.SessRoot.LanguageID, RoomID);
        foreach (DataRow drRoomProperty in dtRoomProperties.Rows)
            foreach (ListItem liRoomProperty in cblRoomProperties.Items)
            {
                if (Convert.ToInt32(drRoomProperty["RoomPropertyID"]) == Convert.ToInt32(liRoomProperty.Value))
                    liRoomProperty.Selected = true;
            }
    }

    private void GenerateCBL()
    {
        CARETTA.COM.CBLHelper.BindCBL(ref cblRoomProperties, HOTOMOTO.APEX.RoomProperties.GetAllRoomPropertiesDataSet(this.SessRoot.LanguageID).Tables[0], "Property", "RoomPropertyID");
    }

    public void SaveRoomProperties(int RoomID)
    {
        foreach (ListItem liRoomProperty in cblRoomProperties.Items)
        {
            if (liRoomProperty.Selected)
            {
                HOTOMOTO.APEX.Rooms_RoomProperties RoomProperty = new HOTOMOTO.APEX.Rooms_RoomProperties();
                RoomProperty.RoomID = RoomID;
                RoomProperty.RoomPropertyID = Convert.ToInt32(liRoomProperty.Value);
                RoomProperty.Save();
            }
        }
    }

    public void UpdateRoomProperties(int RoomID)
    {
        DataTable dtRoomProperties = new DataTable();
        HOTOMOTO.BUS.Rooms.RemoveRoomPropertiesByRoomID(RoomID);

        SaveRoomProperties(RoomID);

    }
}
