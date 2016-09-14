using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

public class BaseUserControl : System.Web.UI.UserControl
{
    CacheMachine cm;
    public BaseUserControl()
    {
        cm = new CacheMachine();
    }

#region SessRoot / CacheMachine

    public SessionRoot SessRoot
    {
        get
        {
            if ((Session != null))
            {
                if (Session["SessionRoot"] == null) { return null; }
                else { return (SessionRoot)Session["SessionRoot"]; }
            }
            else { return null; }
        }
    }

    public object CacheMach(CacheMachine.CacheTypes CacheType, int LanguageID)
    {
        if (Application["CacheMachine"] == null)
        {
            Application.Add("CacheMachine", cm);
        }
        return ((CacheMachine)Application["CacheMachine"]).Item(CacheType, LanguageID);
    }

    public void RemoveFromCache(CacheMachine.CacheTypes CacheType, int LanguageID)
    {
        if (Application["CacheMachine"] == null)
        {
            Application.Add("CacheMachine", cm);
        }
        ((CacheMachine)Application["CacheMachine"]).RemoveItem(CacheType, LanguageID);
    }

#endregion

#region Cache Items
    public DataTable CachedCountries {
        get  { return (DataTable)this.CacheMach(cm.Countries, this.SessRoot.LanguageID); }
    }

    public DataTable CachedCities
    {
        get { return (DataTable)this.CacheMach(cm.Cities, this.SessRoot.LanguageID); }
    }

    public DataTable CachedHotelClasses {
        get {
            return (DataTable)this.CacheMach(cm.HotelClasses, this.SessRoot.LanguageID);
        }
    }
#endregion

}
