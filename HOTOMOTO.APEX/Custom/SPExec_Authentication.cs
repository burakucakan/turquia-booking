using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Text;
using System.Data;

namespace HOTOMOTO.APEX.Custom
{
    public class SPExec_Authentication
    {
        //Login Kontrol
        public static DataTable LoginControl(string CustomerCode, string UserName, string Password)
        {
            SqlConnection conn = APEX.DBHelper.getConnection();
            SqlCommand cmd = APEX.DBHelper.getSprocCmd("cproc_LoginControl", conn);
            SqlDataAdapter da;
            SqlParameter param;
            DataTable dt = new DataTable();

            param = new SqlParameter("@CustomerCode", SqlDbType.Char, 10);
            param.Direction = ParameterDirection.Input;
            param.Value = CustomerCode;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@UserName", SqlDbType.NVarChar, 128);
            param.Direction = ParameterDirection.Input;
            param.Value = UserName;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@Password", SqlDbType.NVarChar, 128);
            param.Direction = ParameterDirection.Input;
            param.Value = Password;
            cmd.Parameters.Add(param);

            da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            return dt;
        }//Login Kontrol

        //Kullanýcýnýn yetkisine ve dile göre menüyü getir
        public static DataTable GetUserPermissions(int LanguageID, int UserRoleID)
        {
            SqlConnection conn = APEX.DBHelper.getConnection();
            SqlCommand cmd = APEX.DBHelper.getSprocCmd("cproc_UserPermissions", conn);
            SqlDataAdapter da;
            SqlParameter param;
            DataTable dt = new DataTable();

            param = new SqlParameter("@LanguageID", SqlDbType.Int, 4);
            param.Direction = ParameterDirection.Input;
            param.Value = LanguageID;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@UserRoleID", SqlDbType.Int, 4);
            param.Direction = ParameterDirection.Input;
            param.Value = UserRoleID;
            cmd.Parameters.Add(param);

            da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            return dt;
        }//Kullanýcýnýn yetkisine ve dile göre menüyü getir


    }
}
