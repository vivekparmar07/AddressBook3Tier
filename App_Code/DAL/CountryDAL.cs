﻿using AddressBook.ENT;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for CountryDAL
/// </summary>
namespace AddressBook.DAL
{
    public class CountryDAL : DatabaseConfig
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
        public CountryDAL()
        {
            //
            // TODO: Add constructor logic here
            //
        }
        #endregion Constructor

        #region Insert Operation
        public Boolean Insert(CountryENT entCountry)
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
                        objCmd.CommandText = "PR_Country_Insert";
                        objCmd.Parameters.AddWithValue("@CountryID", SqlDbType.Int).Direction = ParameterDirection.Output;
                        objCmd.Parameters.AddWithValue("@CountryName", SqlDbType.VarChar).Value = entCountry.CountryName;
                        objCmd.Parameters.AddWithValue("@CountryCode", SqlDbType.VarChar).Value = entCountry.CountryCode;

                        #endregion Prepare Command

                        objCmd.ExecuteNonQuery();
                        entCountry.CountryID = (SqlInt32)objCmd.Parameters["CountryID"].Value;
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
        public Boolean Update(CountryENT entCountry)
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
                        objCmd.CommandText = "PR_Country_UpdateByPK";
                        objCmd.Parameters.AddWithValue("@Country", entCountry.CountryID);
                        objCmd.Parameters.AddWithValue("@CountryName", entCountry.CountryName);
                        objCmd.Parameters.AddWithValue("@CountryCode", entCountry.CountryCode);
                        
                        #endregion Prepare Command

                        objCmd.ExecuteNonQuery();
                        entCountry.CountryID = (SqlInt32)objCmd.Parameters["CountryID"].Value;
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
        public Boolean Delete(SqlInt32 CountryID)
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
                        objCmd.CommandText = "PR_Country_DeleteByPK";
                        objCmd.Parameters.AddWithValue("@CountryID", CountryID);
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
                        objCmd.CommandText = "PR_Country_selectAll";
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
                        objCmd.CommandText = "PR_Country_SelectForDropDownList";
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
        public CountryENT SelectByPK(SqlInt32 CountryID)
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
                        objCmd.CommandText = "PR_Country_selectByPK";
                        objCmd.Parameters.AddWithValue("@CountryID", CountryID);
                        #endregion Prepare Command

                        #region Read Data and Set Controls 
                        CountryENT entCountry = new CountryENT();
                        using (SqlDataReader objSDR = objCmd.ExecuteReader())
                        {
                            while (objSDR.Read())
                            {
                                if (!objSDR["CountryID"].Equals(DBNull.Value))
                                    entCountry.CountryID = Convert.ToInt32(objSDR["CountryID"]);

                                if (!objSDR["CountryName"].Equals(DBNull.Value))
                                    entCountry.CountryName = Convert.ToString(objSDR["CountryName"]);

                                if (!objSDR["CountryCode"].Equals(DBNull.Value))
                                    entCountry.CountryCode = Convert.ToString(objSDR["CountryCode"]);

                                if (!objSDR["CreationDate"].Equals(DBNull.Value))
                                    entCountry.CreationDate = Convert.ToDateTime(objSDR["CreationDate"]);
                            }
                        }
                        return entCountry;
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