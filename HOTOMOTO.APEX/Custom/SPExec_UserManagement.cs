using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Data;

namespace HOTOMOTO.APEX.Custom {

    public class SPExec_UserManagement {

        public static DataTable GetUserList(int LanguageID, int RoleType) {
            SqlConnection conn = APEX.DBHelper.getConnection();
            SqlCommand cmd = APEX.DBHelper.getSprocCmd("cproc_GetUserList", conn);
            SqlDataAdapter da;
            SqlParameter param;
            DataTable dt = new DataTable();

            param = new SqlParameter("@LanguageID", SqlDbType.Int, 4);
            param.Direction = ParameterDirection.Input;
            param.Value = LanguageID;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@RoleType", SqlDbType.Int, 4);
            param.Direction = ParameterDirection.Input;
            param.Value = RoleType;
            cmd.Parameters.Add(param);

            da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            return dt;
        }

        //Customer a göre Kullanýcýlarý Getir 
        public static DataTable GetUsersByCustomerID(int CustomerID, int UserID) {            

            SqlConnection conn = APEX.DBHelper.getConnection();
            SqlCommand cmd = APEX.DBHelper.getSprocCmd("cproc_GetUsersByCustomerID", conn);

            SqlDataAdapter da;
            SqlParameter param;
            DataTable dt = new DataTable();

            param = new SqlParameter("@CustomerID", SqlDbType.Int, 4);
            param.Direction = ParameterDirection.Input;
            param.Value = CustomerID;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@UserID", SqlDbType.Int, 4);
            param.Direction = ParameterDirection.Input;
            param.Value = UserID;
            cmd.Parameters.Add(param);

            da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            return dt;
        }//Customer a göre Kullanýcýlarý Getir 

        //Üyelik Formundaki Eriþim Seçenekleri  
        public static DataTable GetAccessOptions(int LanguageID) {
            SqlConnection conn = APEX.DBHelper.getConnection();
            SqlCommand cmd = APEX.DBHelper.getSprocCmd("cproc_GetAccessOptions", conn);
            SqlDataAdapter da;
            SqlParameter param;
            DataTable dt = new DataTable();

            param = new SqlParameter("@LanguageID", SqlDbType.Int, 4);
            param.Direction = ParameterDirection.Input;
            param.Value = LanguageID;
            cmd.Parameters.Add(param);

            da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            return dt;
        }//Üyelik Formundaki Eriþim Seçenekleri  

        // Kullanýcý Yetkileri 
        public static DataTable GetAllPermissions(int LanguageID, int RoleType) {
            SqlConnection conn = APEX.DBHelper.getConnection();
            SqlCommand cmd = APEX.DBHelper.getSprocCmd("cproc_GetUserPerms", conn);
            SqlDataAdapter da;
            SqlParameter param;
            DataTable dt = new DataTable();

            param = new SqlParameter("@LanguageID", SqlDbType.Int, 4);
            param.Direction = ParameterDirection.Input;
            param.Value = LanguageID;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@RoleType", SqlDbType.Int, 4);
            param.Direction = ParameterDirection.Input;
            param.Value = RoleType;
            cmd.Parameters.Add(param);

            da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            return dt;
        }// Kullanýcý Yetkileri 

        // Adres Tiplerin Getir 
        public static DataTable GetAddressTypes(int LanguageID) {
            SqlConnection conn = APEX.DBHelper.getConnection();
            SqlCommand cmd = APEX.DBHelper.getSprocCmd("cproc_GetAddressTypes", conn);
            SqlDataAdapter da;
            SqlParameter param;
            DataTable dt = new DataTable();

            param = new SqlParameter("@LanguageID", SqlDbType.Int, 4);
            param.Direction = ParameterDirection.Input;
            param.Value = LanguageID;
            cmd.Parameters.Add(param);

            da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            return dt;
        }// Adres Tiplerin Getir 

        // Kullanýcý Daha Önce Kaydedilmiþ mi Kontrolü 
        public static int CheckUser(string UserName) {
            SqlConnection conn = APEX.DBHelper.getConnection();
            SqlCommand cmd = APEX.DBHelper.getSprocCmd("cproc_CheckUser", conn);
            SqlParameter param;

            param = new SqlParameter("@UserName", SqlDbType.NVarChar, 128);
            param.Direction = ParameterDirection.Input;
            param.Value = UserName;
            cmd.Parameters.Add(param);

            conn.Open();

            return (int)cmd.ExecuteScalar();
        }

        // UserID ye Göre Userý Ve Permission unu Çaðýrma  
        public static DataTable GetUserAndUserPerm(int LanguageID, int UserID) {
            SqlConnection conn = APEX.DBHelper.getConnection();
            SqlCommand cmd = APEX.DBHelper.getSprocCmd("cproc_GetUserAndUserPerm", conn);
            SqlDataAdapter da;
            SqlParameter param;
            DataTable dt = new DataTable();

            param = new SqlParameter("@LanguageID", SqlDbType.Int, 4);
            param.Direction = ParameterDirection.Input;
            param.Value = LanguageID;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@UserID", SqlDbType.Int, 4);
            param.Direction = ParameterDirection.Input;
            param.Value = UserID;
            cmd.Parameters.Add(param);

            da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            return dt;
        }// UserID ye Göre Userý Ve Permission unu Çaðýrma 
     
        // Kullanýcýnýn Adreslerini Getirme  
        public static DataTable GetUserAddress(int UserID) {
            SqlConnection conn = APEX.DBHelper.getConnection();
            SqlCommand cmd = APEX.DBHelper.getSprocCmd("cproc_GetUserAddress", conn);
            SqlDataAdapter da;
            SqlParameter param;
            DataTable dt = new DataTable();

            param = new SqlParameter("@UserID", SqlDbType.Int, 4);
            param.Direction = ParameterDirection.Input;
            param.Value = UserID;
            cmd.Parameters.Add(param);

            da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            return dt;
        }// Kullanýcýnýn Adreslerini Getirme   

        // Kullanýcýnýn Eriþim Seçeneklerini Getir 
        public static DataTable GetUserAccessOptions(int UserID) {
            SqlConnection conn = APEX.DBHelper.getConnection();
            SqlCommand cmd = APEX.DBHelper.getSprocCmd("cproc_GetUserAccessOptions", conn);
            SqlDataAdapter da;
            SqlParameter param;
            DataTable dt = new DataTable();

            param = new SqlParameter("@UserID", SqlDbType.Int, 4);
            param.Direction = ParameterDirection.Input;
            param.Value = UserID;
            cmd.Parameters.Add(param);

            da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            return dt;
        }// Kullanýcýnýn Eriþim Seçeneklerini Getir 

    }

}
