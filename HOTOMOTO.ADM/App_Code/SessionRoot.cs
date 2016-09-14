using System;
using System.Data;
using System.Collections;

public class SessionRoot {
    private bool m_bolIsDebug;
    private int m_intLanguageID;
    private int m_intUserID;
    private int m_strUserRoleID;
    private string m_strUserIP;
    private string m_strFirstName;
    private string m_strLastName;
    private string m_strEmail;
    private int m_intParentID;
    private int m_intChildID;
    private int m_intCurrentPageID;
    private int m_intPageItemAmount;
    private DateTime m_dtLoginDate;
    private DataTable m_dtUserPermissionList;

    private Hashtable m_htDataSources;

    private enum DataSourceTypes {
        UserDataTable = 1,
        UserManagementDataTable = 2
    }

    public SessionRoot(int userID) {
        this.m_intUserID = userID;

        m_htDataSources = new Hashtable();
        m_intPageItemAmount = int.Parse(System.Configuration.ConfigurationManager.AppSettings["DefaultPageLimit"]);
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

    public bool HasUserPermission(string PermType) {
        foreach(DataRow dr in UserPermissionList.Rows) {
            if(dr["Value"].ToString().ToUpper() == PermType.ToUpper()) {
                return true;
            }
        }
        return false;
    }

    public bool IsDebug {
        get { return m_bolIsDebug; }
        set { m_bolIsDebug = value; }
    }

    public int LanguageID {
        get { return m_intLanguageID; }
        set { m_intLanguageID = value; }
    }
    public int UserID {
        get { return m_intUserID; }
        set { m_intUserID = value; }
    }
    public int UserRoleID {
        get { return m_strUserRoleID; }
        set { m_strUserRoleID = value; }
    }
    public string UserIP {
        get { return m_strUserIP; }
        set { m_strUserIP = value; }
    }
    public string UserFirstName {
        get { return m_strFirstName; }
        set { m_strFirstName = value; }
    }
    public string UserLastName {
        get { return m_strLastName; }
        set { m_strLastName = value; }
    }
    public string UserEmail {
        get { return m_strEmail; }
        set { m_strEmail = value; }
    }
	public int ParentID {
		get { return m_intParentID; }
		set { m_intParentID = value; }
	}
    public int ChildID {
        get { return m_intChildID; }
        set { m_intChildID = value; }
    }
    public int CurrentPageID {
        get { return m_intCurrentPageID; }
        set { m_intCurrentPageID = value; }
    }
    public int PageItemAmount {
        get { return m_intPageItemAmount; }
        set { m_intPageItemAmount = value; }
    }
    public DateTime LoginDate {
        get { return m_dtLoginDate; }
        set { m_dtLoginDate = value; }
    }
    public DataTable UserPermissionList {
        get { return m_dtUserPermissionList; }
        set { m_dtUserPermissionList = value; }
    }
}