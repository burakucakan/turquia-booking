using System;
using System.Collections;
using System.Data;

public class SessionRoot
{

#region LOCAL DEÐÝÞKENLER

    //Development Ýle Ýlgili Deðerler
    private bool m_boIsDevelopment;

    //Kullanýcý Ýle Ýlgili Deðerler
    private int m_intLanguageID;
    private int m_intCustomerID;
    private int m_intUserID;
    private string m_strCustomerNo;
    private string m_strUserIP;
    private int m_intUserRoleID;
    private HOTOMOTO.BUS.Enumerations.CurrencyTypes m_CurrencyID;
    private string m_CurrencySymbolLeft;
    private string m_CurrencySymbolRight;
    private string m_strFirstName;
    private string m_strLastName;
    private string m_strEmail;
    private string m_strCompanyName;
    private DateTime m_dtLoginDate;
    private DataTable m_dtUserPermissionList;

    //Kullanýcýnýn Rezervasyon Deðerleri
    private int m_SearchCountryID = 0;
    private string m_SearchCityID = "0";
    private string m_SearchHotelName = "%";
    private string m_SearchHotelClass = "%";
    private DateTime m_SearchArrivalDate = DateTime.Now;
    private DateTime m_SearchDepartureDate = DateTime.Now.AddDays(7);
    private int m_SearchRoomQuantity = 0;
    private DataTable m_SearchRoomsDetail;
    private string m_SearchTourName = "%";
    private HOTOMOTO.BUS.Enumerations.NewRequestable m_NewRequestable = HOTOMOTO.BUS.Enumerations.NewRequestable.Available;

    private int m_CurrentHotelID = 0;
    private string m_CurrentHotelName = String.Empty;
    private int m_CurrentTourID;
    private string m_CurrentTourName;

#endregion

#region DataSource Management

    private Hashtable m_htDataSources;

    private enum DataSourceTypes {
        BankDataTable = 1,
        CrediCardDataTable = 2,
        BankInstalmentDataTable = 3,
        CustomerDataTable = 4,
        UserDataTable = 5,
        UserManagementDataTable = 6
    }

    private void AddDataSource(DataSourceTypes dataSourceType, object dataSource) {
        if(m_htDataSources.ContainsKey(dataSourceType)) {
            m_htDataSources.Remove(dataSourceType);
        }
        m_htDataSources.Add(dataSourceType, dataSource);
    }

    private object GetDataSource(DataSourceTypes dataSourceType) {
        if(m_htDataSources.ContainsKey(dataSourceType)) {
            return m_htDataSources[dataSourceType];
        } else {
            return null;
        }
    }

#endregion

#region Development Ýle Ýlgili Propertyler

    public bool IsDevelopment
    {
        get { return m_boIsDevelopment; }
        set { m_boIsDevelopment = value; }
    }

#endregion

#region Kullanýcý Ýle Ýlgili Propertyler

    public int LanguageID
    {
        get { return m_intLanguageID; }
        set { m_intLanguageID = value; }
    }
    public int CustomerID
    {
        get { return m_intCustomerID; }
        set { m_intCustomerID = value; }
    }
    public int UserID
    {
        get { return m_intUserID; }
        set { m_intUserID = value; }
    }
    public string CustomerNo
    {
        get { return m_strCustomerNo; }
        set { m_strCustomerNo = value; }
    }
    public int UserRoleID
    {
        get { return m_intUserRoleID; }
        set { m_intUserRoleID = value; }
    }
    public HOTOMOTO.BUS.Enumerations.CurrencyTypes CurrencyID
    {
        get { return m_CurrencyID; }
        set { m_CurrencyID = value; }
    }
    public string CurrencySymbolLeft
    {
        get { return m_CurrencySymbolLeft; }
        set { m_CurrencySymbolLeft = value; }
    }
    public string CurrencySymbolRight
    {
        get { return m_CurrencySymbolRight; }
        set { m_CurrencySymbolRight = value; }
    }
    public string UserIP
    {
        get { return m_strUserIP; }
        set { m_strUserIP = value; }
    }
    public string UserFirstName
    {
        get { return m_strFirstName; }
        set { m_strFirstName = value; }
    }
    public string UserLastName
    {
        get { return m_strLastName; }
        set { m_strLastName = value; }
    }
    public string UserEmail
    {
        get { return m_strEmail; }
        set { m_strEmail = value; }
    }
    public string CompanyName
    {
        get { return m_strCompanyName; }
        set { m_strCompanyName = value; }
    }
    public DateTime LoginDate
    {
        get { return m_dtLoginDate; }
        set { m_dtLoginDate = value; }
    }
    public DataTable UserPermissionList
    {
        get { return m_dtUserPermissionList; }
        set { m_dtUserPermissionList = value; }
    }

#endregion

#region Kullanýcýnýn Rezervasyon Propertyleri

    public int SearchCountryID
    {
        get { return m_SearchCountryID; }
        set { m_SearchCountryID = value; }
    }

    public string SearchCityID
    {
        get { return m_SearchCityID; }
        set { m_SearchCityID = value; }
    }

    public string SearchHotelName
    {
        get { return m_SearchHotelName; }
        set { m_SearchHotelName = value; }
    }

    public string SearchHotelClass
    {
        get { return m_SearchHotelClass; }
        set { m_SearchHotelClass = value; }
    }

    public DateTime ArrivalDate {
        get { return m_SearchArrivalDate; }
        set { m_SearchArrivalDate = value; }
    }

    public DateTime DepartureDate {
        get { return m_SearchDepartureDate; }
        set { m_SearchDepartureDate = value; }
    }


    public int RoomQuantity
    {
        get { return m_SearchRoomQuantity; }
        set { m_SearchRoomQuantity = value; }
    }

    public DataTable RoomsDetail
    {
        get { return m_SearchRoomsDetail; }
        set { m_SearchRoomsDetail = value; }
    }

    public int CurrentHotelID
    {
        get { return m_CurrentHotelID; }
        set { m_CurrentHotelID = value; }
    }

    public string CurrentHotelName
    {
        get { return m_CurrentHotelName; }
        set { m_CurrentHotelName = value; }
    }

    public int CurrentTourID
    {
        get { return m_CurrentTourID; }
        set { m_CurrentTourID = value; }
    }

    public string CurrentTourName
    {
        get { return m_CurrentTourName; }
        set { m_CurrentTourName = value; }
    }

    public string SearchTourName
    {
        get { return m_SearchTourName; }
        set { m_SearchTourName = value; }
    }

    public HOTOMOTO.BUS.Enumerations.NewRequestable NewRequestable
    {
        get { return m_NewRequestable; }
        set { m_NewRequestable = value; }
    }
#endregion

    public SessionRoot(int userID)
    {
        this.m_intUserID = userID;

        m_htDataSources = new Hashtable();
    }

    /// <summary>
    /// Kullanýcýnýn bu sayfaya yetkisi var mý?
    /// </summary>
    /// <param name="PermType"></param>
    /// <returns></returns>
    public bool HasUserPermission(string PermType) {
        foreach (DataRow dr in UserPermissionList.Rows) {
            if (dr["Value"].ToString().ToUpper() == PermType.ToUpper()) {
                return true;
            }
        }
        return false;
    }

}
