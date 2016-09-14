using System;
using System.Collections;
using System.Data;

public class CacheMachine {

    private Hashtable m_htCache;
    private DataTable dtLanguages;

    public struct CacheTypes
    {
        public int Code;
        public int Period;
        public string Description;
    }

#region Cache Tiplerini Tanýmla
    private CacheTypes s_Countries;
    private CacheTypes s_Cities;
    private CacheTypes s_HotelClasses;

    public CacheTypes Countries 
    {
        get { return s_Countries; }
    }

    public CacheTypes Cities
    {
        get { return s_Cities; }
    }

    public CacheTypes HotelClasses {
        get {
            return s_HotelClasses;
        }
    }
#endregion

    public CacheMachine()
    {
        #region Cache Tiplerinin Deðerlerini Ata

        s_Countries.Code = 1;
        s_Countries.Period = int.Parse(System.Configuration.ConfigurationManager.AppSettings["Places"]);
        s_Countries.Description = "Ülkeler";

        s_Cities.Code = 2;
        s_Cities.Period = int.Parse(System.Configuration.ConfigurationManager.AppSettings["Places"]);
        s_Cities.Description = "Þehirler";

        #endregion

        m_htCache = new Hashtable();

        this.dtLanguages = HOTOMOTO.BUS.Language.GetAllLanguages();
    }

#region Class CachedData
    private class CachedData
    {
        DateTime m_dateTimeStamp;
        object m_objData;
        int m_intLanguageID;

        public DateTime TimeStamp
        {
            get { return m_dateTimeStamp; }
            set { m_dateTimeStamp = value; }
        }

        public object Data
        {
            get { return m_objData; }
            set { m_objData = value; }
        }

        public int LanguageID
        {
            get { return m_intLanguageID; }
            set { m_intLanguageID = value; }
        }

        public CachedData(object objData, int LanguageID)
        {
            m_dateTimeStamp = DateTime.Now;
            m_objData = objData;
            m_intLanguageID = LanguageID;
        }
    }
#endregion

#region Add/Remove/Clear

    private string ReturnStrKey(CacheTypes CacheType, int LanguageID)
    {
        return CacheType.Code.ToString() + "-" + CARETTA.COM.Util.ReplaceNumberToTwo(LanguageID);
    }

    private void Add(object objData, CacheTypes CacheType, int LanguageID)
    {
        string Key = ReturnStrKey(CacheType, LanguageID);

        if (m_htCache[Key]!=null)
        {
            ((CachedData)m_htCache[Key]).Data = objData;
            ((CachedData)m_htCache[Key]).TimeStamp = DateTime.Now;
            ((CachedData)m_htCache[Key]).LanguageID = LanguageID;
        }
        else
        {
            CachedData objCachedData = new CachedData(objData, LanguageID);
            m_htCache.Add(Key, objCachedData);
        }
    }

    public void RemoveItem(CacheTypes CacheType, int LanguageID)
    {
        if (this.m_htCache.Contains(ReturnStrKey(CacheType, LanguageID)))
        {
            this.m_htCache.Remove(ReturnStrKey(CacheType, LanguageID));
        }
    }

    public void Clear()
    {
        if ((m_htCache != null))
        {
            m_htCache.Clear();
        }
    }

#endregion

    public object Item(CacheTypes CacheType, int LanguageID)
    {
        string Key = ReturnStrKey(CacheType, LanguageID);
        if ((m_htCache[Key] != null))
        {
            if (((CachedData)m_htCache[Key]).TimeStamp.AddMinutes(CacheType.Period) > DateTime.Now)
            {
                //Cache expire etmemiþtir
                return ((CachedData)m_htCache[Key]).Data;
            }
        }

        //Cache Expire etmiþ Datayý tazele

        if (CacheType.Code == s_Countries.Code) { FillCountries(LanguageID);  }
        if (CacheType.Code == s_Countries.Code) { FillCities(LanguageID);     }
        if (CacheType.Code == s_HotelClasses.Code) { FillHotelClasses(LanguageID);  }

        return ((CachedData)m_htCache[Key]).Data;
    }

#region Items

    private void FillCountries(int LanguageID)
    {
        foreach (DataRow dr in dtLanguages.Rows)
        {
            this.Add(HOTOMOTO.BUS.CountriesAndCities.GetCountries(LanguageID), s_Countries, (int)dr["LanguageID"]);
        }
    }

    private void FillCities(int LanguageID)
    {
        foreach (DataRow dr in dtLanguages.Rows)
        {
    		this.Add(HOTOMOTO.BUS.CountriesAndCities.GetCities(LanguageID), s_Cities, (int)dr["LanguageID"]);
        }
    }

    private void FillHotelClasses(int LanguageID)
    {
        foreach (DataRow dr in dtLanguages.Rows)
        {
            this.Add(HOTOMOTO.BUS.Hotels.GetHotelClasses(LanguageID), s_HotelClasses, (int)dr["LanguageID"]);
        }
    }

#endregion

}
