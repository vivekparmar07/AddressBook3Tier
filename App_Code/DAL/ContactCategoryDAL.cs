using AddressBook.ENT;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for ContactCategoryDAL
/// </summary>
namespace AddressBook.DAL
{
    public class ContactCategoryDAL : DatabaseConfig
    {
        #region Local Variables
        protected String _Message;
        public String Message
        {
            get
            {
                return _Message;
            }
            set
            {
                _Message = value;
            }
        }
        #endregion Local Variables

        #region Constructor
        public ContactCategoryDAL()
        {
            //
            // TODO: Add constructor logic here
            //
        }
        #endregion Constructor

        #region Insert Operation
        public Boolean Insert(ContactCategoryENT entContactCategory)
        {
            using (SqlConnection objConn = new SqlConnection(ConnectionString))
            {
                if (objConn.State != ConnectionState.Open)
                    objConn.Open();
                using (SqlCommand objCmd = objConn.CreateCommand())
                {
                    try
                    {
                        #region Prepare Command

                        objCmd.CommandType = CommandType.StoredProcedure;
                        objCmd.CommandText = "PR_ContactCategory_Insert";
                        objCmd.Parameters.AddWithValue("@ContactCategoryID", SqlDbType.Int).Direction = ParameterDirection.Output;
                        objCmd.Parameters.AddWithValue("@ContactCategoryName", SqlDbType.VarChar).Value = entContactCategory.ContactCategoryName;

                        #endregion Prepare Command

                        objCmd.ExecuteNonQuery();
                        entContactCategory.ContactCategoryID = (SqlInt32)objCmd.Parameters["ContactCategoryID"].Value;
                        return true;
                    }
                    catch (SqlException SqlEs)
                    {
                        Message = SqlEs.InnerException.Message;
                        return false;
                    }
                    catch (Exception Es)
                    {
                        Message = Es.InnerException.Message;
                        return false;
                    }
                    finally
                    {
                        if (objConn.State == ConnectionState.Open)
                        {
                            objConn.Close();
                        }
                    }
                }
            }
        }
        #endregion Insert Operation

        #region Update Operation
        public Boolean Update(ContactCategoryENT entContactCategory)
        {
            using (SqlConnection objConn = new SqlConnection(ConnectionString))
            {
                if (objConn.State != ConnectionState.Open)
                    objConn.Open();
                using (SqlCommand objCmd = objConn.CreateCommand())
                {
                    try
                    {
                        #region Prepare Command

                        objCmd.CommandType = CommandType.StoredProcedure;
                        objCmd.CommandText = "PR_ContactCategory_Update";
                        objCmd.Parameters.AddWithValue("@ContactCategoryID", entContactCategory.ContactCategoryID);
                        objCmd.Parameters.AddWithValue("@ContactCategoryName", entContactCategory.ContactCategoryName);

                        #endregion Prepare Command

                        objCmd.ExecuteNonQuery();
                        entContactCategory.ContactCategoryID = (SqlInt32)objCmd.Parameters["ContactCategoryID"].Value;
                        return true;
                    }
                    catch (SqlException SqlEs)
                    {
                        Message = SqlEs.InnerException.Message;
                        return false;
                    }
                    catch (Exception Es)
                    {
                        Message = Es.InnerException.Message;
                        return false;
                    }
                    finally
                    {
                        if (objConn.State == ConnectionState.Open)
                        {
                            objConn.Close();
                        }
                    }
                }
            }
        }
        #endregion Update Operation

        #region Delete Operation
        public Boolean Delete(SqlInt32 ContactCategoryID)
        {
            using (SqlConnection objConn = new SqlConnection(ConnectionString))
            {
                if (objConn.State != ConnectionState.Open)
                    objConn.Open();
                using (SqlCommand objCmd = objConn.CreateCommand())
                {
                    try
                    {
                        #region Prepare Command
                        objCmd.Connection = objConn;
                        objCmd.CommandType = CommandType.StoredProcedure;
                        objCmd.CommandText = "PR_ContactCategory_DeleteByPK";
                        objCmd.Parameters.AddWithValue("@ContactCategoryID", ContactCategoryID);
                        #endregion Prepare Command

                        objCmd.ExecuteNonQuery();
                        return true;
                    }
                    catch (SqlException SqlEs)
                    {
                        Message = SqlEs.InnerException.Message;
                        return false;
                    }
                    catch (Exception Es)
                    {
                        Message = Es.InnerException.Message;
                        return false;
                    }
                    finally
                    {
                        if (objConn.State == ConnectionState.Open)
                        {
                            objConn.Close();
                        }
                    }
                }
            }
        }
        #endregion Delete Operation

        #region Select Operation

        #region SelectAll
        public DataTable SelectAll()
        {
            using (SqlConnection objConn = new SqlConnection(ConnectionString))
            {
                if (objConn.State != ConnectionState.Open)
                    objConn.Open();
                using (SqlCommand objCmd = objConn.CreateCommand())
                {
                    try
                    {
                        #region Prepare Command
                        objCmd.CommandType = CommandType.StoredProcedure;
                        objCmd.CommandText = "PR_ContactCategory_SelectAll";
                        #endregion Prepare Command

                        #region Read Data and Set Controls 
                        DataTable dt = new DataTable();
                        using (SqlDataReader objSDR = objCmd.ExecuteReader())
                        {
                            dt.Load(objSDR);
                        }
                        return dt;
                        #endregion Read Data and Set Controls
                    }
                    catch (SqlException SqlEs)
                    {
                        Message = SqlEs.InnerException.Message;
                        return null;
                    }
                    catch (Exception Es)
                    {
                        Message = Es.InnerException.Message;
                        return null;
                    }
                    finally
                    {
                        if (objConn.State == ConnectionState.Open)
                        {
                            objConn.Close();
                        }
                    }
                }
            }
        }

        #endregion SelectAll

        #region SelectForDropDownList
        public DataTable SelectForDropDownList()
        {
            using (SqlConnection objConn = new SqlConnection(ConnectionString))
            {
                if (objConn.State != ConnectionState.Open)
                    objConn.Open();
                using (SqlCommand objCmd = objConn.CreateCommand())
                {
                    try
                    {
                        #region Prepare Command
                        objCmd.CommandType = CommandType.StoredProcedure;
                        objCmd.CommandText = "PR_ContactCategory_SelectForDropDownList";
                        #endregion Prepare Command

                        #region Read Data and Set Controls 
                        DataTable dt = new DataTable();
                        using (SqlDataReader objSDR = objCmd.ExecuteReader())
                        {
                            dt.Load(objSDR);
                        }
                        return dt;
                        #endregion Read Data and Set Controls
                    }
                    catch (SqlException SqlEs)
                    {
                        Message = SqlEs.InnerException.Message;
                        return null;
                    }
                    catch (Exception Es)
                    {
                        Message = Es.InnerException.Message;
                        return null;
                    }
                    finally
                    {
                        if (objConn.State == ConnectionState.Open)
                        {
                            objConn.Close();
                        }
                    }
                }
            }
        }

        #endregion SelectForDropDownList

        #region SelectByPK
        public ContactCategoryENT SelectByPK(SqlInt32 ContactCategoryID)
        {
            using (SqlConnection objConn = new SqlConnection(ConnectionString))
            {
                if (objConn.State != ConnectionState.Open)
                    objConn.Open();
                using (SqlCommand objCmd = objConn.CreateCommand())
                {
                    try
                    {
                        #region Prepare Command
                        objCmd.CommandType = CommandType.StoredProcedure;
                        objCmd.CommandText = "PR_ContactCategory_SelectByPK";
                        objCmd.Parameters.AddWithValue("@ ContactCategoryID", ContactCategoryID);
                        #endregion Prepare Command

                        #region Read Data and Set Controls 
                        ContactCategoryENT entContactCategory = new ContactCategoryENT();
                        using (SqlDataReader objSDR = objCmd.ExecuteReader())
                        {
                            while (objSDR.Read())
                            {
                                if (!objSDR["ContactCategoryID"].Equals(DBNull.Value))
                                    entContactCategory.ContactCategoryID = Convert.ToInt32(objSDR["ContactCategoryID"]);

                                if (!objSDR["ContactCategoryName"].Equals(DBNull.Value))
                                    entContactCategory.ContactCategoryName = Convert.ToString(objSDR["ContactCategoryName"]);

                                if (!objSDR["CreationDate"].Equals(DBNull.Value))
                                    entContactCategory.CreationDate = Convert.ToDateTime(objSDR["CreationDate"]);
                            }
                        }
                        return entContactCategory;
                        #endregion Read Data and Set Controls
                    }
                    catch (SqlException SqlEs)
                    {
                        Message = SqlEs.InnerException.Message;
                        return null;
                    }
                    catch (Exception Es)
                    {
                        Message = Es.InnerException.Message;
                        return null;
                    }
                    finally
                    {
                        if (objConn.State == ConnectionState.Open)
                        {
                            objConn.Close();
                        }
                    }
                }
            }
        }
        #endregion SelectByPK

        #endregion Select Operation
    }
}
