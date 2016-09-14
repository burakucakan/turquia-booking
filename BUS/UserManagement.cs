using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using HOTOMOTO.APEX;
using System.Collections;

namespace HOTOMOTO.BUS {

    public class UserManagement {

        public static DataTable GetUserList(int LanguageID, int RoleType) {
            DataTable dt;
            try {
                dt = APEX.Custom.SPExec_UserManagement.GetUserList(LanguageID, RoleType);
            } catch(Exception) {
                dt = null;
                throw;
            }
            return dt;
        }

        public static DataTable GetUsersByCustomerID(int CustomerID, int UserID) {
            DataTable dt;
            try {
                dt = APEX.Custom.SPExec_UserManagement.GetUsersByCustomerID(CustomerID, UserID);
            }
            catch (Exception) {
                dt = null;
                throw;
            }
            return dt;
        }

        public static DataTable GetAccessOptions(int LanguageID) {
            DataTable dt;
            try {
                dt = APEX.Custom.SPExec_UserManagement.GetAccessOptions(LanguageID);                
            }
            catch (Exception) {
                dt = null;
                throw;
            }
            return dt;
        }

        public static DataTable GetAllPermissions(int LanguageID, HOTOMOTO.BUS.Enumerations.RoleType UserRoleID) {
            DataTable dt;
            try {
                dt = APEX.Custom.SPExec_UserManagement.GetAllPermissions(LanguageID, (int)UserRoleID);
            }
            catch (Exception) {
                dt = null;
                throw;
            }
            return dt;
        }

        public static DataTable GetAddressTypes(int LanguageID) {
            DataTable dt;
            try {
                dt = APEX.Custom.SPExec_UserManagement.GetAddressTypes(LanguageID);
            }
            catch (Exception) {
                dt = null;
                throw;
            }
            return dt;
        }

        public static DataTable GetUserAndUserPerm(int LanguageID, int UserID) {
            DataTable dt;
            try {
                dt = APEX.Custom.SPExec_UserManagement.GetUserAndUserPerm(LanguageID, UserID);
            }
            catch (Exception) {
                dt = null;
                throw;
            }
            return dt;
        }

        public static DataTable GetUserAddress(int UserID) {
            DataTable dt;
            try {
                dt = APEX.Custom.SPExec_UserManagement.GetUserAddress(UserID);
            }
            catch (Exception) {
                dt = null;
                throw;
            }
            return dt;
        }

        public static DataTable GetUserAccessOptions(int UserID) {
            DataTable dt;
            try {
                dt = APEX.Custom.SPExec_UserManagement.GetUserAccessOptions(UserID);
            }
            catch (Exception) {
                dt = null;
                throw;
            }
            return dt;
        }

        public static int CheckUser(string UserName) {
            int UserCount = 0;
            try {
                UserCount = APEX.Custom.SPExec_UserManagement.CheckUser(UserName);
            }
            catch (Exception) {
                UserCount = 0;
                throw;
            }
            return UserCount;
        }

        public void Save(int UserID, int LanguageID, int UserPermissionID, int UserRoleID, string UserName, string Password, 
                        string FirstName, string LastName, int CreatedBy, int CustomerID, string EmailAddress, 
                        DateTime CreateDate, int ModifiedBy, DataTable dtAddres, DataTable dtAccessOptions) {
            try {

                APEX.Users objUser = new APEX.Users();

                if (UserID > 0) {
                    objUser.Load(UserID);
                }
                objUser.CreateDate = CreateDate;
                objUser.CreatedBy = CreatedBy;
                objUser.CustomerID = CustomerID;
                objUser.EmailAddress = EmailAddress;
                objUser.FirstName = FirstName;
                objUser.isActive = true;
                objUser.isEmailConfirmed = false;
                objUser.LastName = LastName;
                objUser.ModifiedBy = ModifiedBy;
                objUser.ModifyDate = DateTime.Now;
                objUser.Password = Password;
                objUser.UserName = UserName;
                objUser.UserPermissionID = UserPermissionID;
                objUser.UserRoleID = UserRoleID;
                int UserIdentity = objUser.Save();

                APEX.Addresses objAddress;
                APEX.Users_Addresses objUsersAddress;

                int Identity = 0;

                foreach (DataRow dr in dtAddres.Rows) {
                    objAddress = new Addresses();
                    if (UserID > 0) {
                        objAddress.Load(Convert.ToInt32(dr["AddressID"]));
                    }
                    objAddress.AddressTypeID = Convert.ToInt32(dr["AddressTypeID"]);
                    objAddress.CityID = Convert.ToInt32(dr["CityID"]);
                    objAddress.CountryID = Convert.ToInt32(dr["CountryID"]);
                    objAddress.CreateDate = Convert.ToDateTime(dr["CreateDate"]);
                    objAddress.isActive = true;
                    objAddress.isDefault = true;
                    objAddress.PostalCode = dr["PostalCode"].ToString();
                    objAddress.StreetAddress = dr["StreetAddress"].ToString();
                    objAddress.Town = dr["Town"].ToString();
                    Identity = objAddress.Save();

                    if (UserID == 0) {
                        objUsersAddress = new Users_Addresses();
                        objUsersAddress.AddressID = Identity;
                        objUsersAddress.UserID = UserIdentity;
                        objUsersAddress.Save();
                    }
                }

                APEX.AccessOptions objAccessOptions;
                APEX.Users_AccessOptions objUserAccessOptions;

                foreach (DataRow dr in dtAccessOptions.Rows) {
                    objAccessOptions = new AccessOptions();
                    if (UserID > 0) {
                        objAccessOptions.Load(Convert.ToInt32(dr["AccessOptionID"]));
                    }
                    objAccessOptions.AccessTypeID = Convert.ToInt32(dr["AccessTypeID"]);
                    objAccessOptions.AccessValue = dr["AccessValue"].ToString();
                    objAccessOptions.CreateDate = Convert.ToDateTime(dr["CreateDate"]);
                    objAccessOptions.isActive = true;
                    objAccessOptions.isDefault = true;
                    objAccessOptions.ShowOrder = 1;
                    Identity = objAccessOptions.Save();

                    if (UserID == 0) {
                        objUserAccessOptions = new Users_AccessOptions();
                        objUserAccessOptions.AccessOptionID = Identity;
                        objUserAccessOptions.UserID = UserIdentity;
                        objUserAccessOptions.Save();
                    }
                }

            }
            catch (Exception) {                
                throw;
            }
        }

        public static bool DeleteUser(int UserID) {
            try {
                
                APEX.Users objUser = new APEX.Users();
                objUser.Load(UserID);
                
                int Err = objUser.Delete();

                if (Err == 0) {
                    return true;
                }
                else {
                    return false;
                }
            }
            catch (Exception) {
                return false;
            }
        }

    }

}
