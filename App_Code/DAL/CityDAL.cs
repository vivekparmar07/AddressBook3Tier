using AddressBook.ENT;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for CityDAL
/// </summary>
namespace AddressBook.DAL
{
    public class CityDAL : DatabaseConfig
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
        public CityDAL()
        {
            //
            // TODO: Add constructor logic here
            //
        }
        #endregion Constructor

        #region Insert Operation

        #region Insert
        public Boolean Insert(CityENT entCity)
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
                        objCmd.CommandText = "PR_City_Insert";
                        objCmd.Parameters.AddWithValue("@CityID", SqlDbType.Int).Direction=ParameterDirection.Output;
                        objCmd.Parameters.AddWithValue("@CityName", SqlDbType.VarChar).Value = entCity.CityName;
                        objCmd.Parameters.AddWithValue("@PinCode", SqlDbType.VarChar).Value = entCity.Pincode;
                        objCmd.Parameters.AddWithValue("@STDCode", SqlDbType.VarChar).Value = entCity.STDCode;
                        objCmd.Parameters.AddWithValue("@StateID", SqlDbType.Int).Value = entCity.StateId;
                            
                        #endregion Prepare Command

                        objCmd.ExecuteNonQuery();
                        entCity.CityID = (SqlInt32)objCmd.Parameters["CityID"].Value;
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

        #endregion Insert

        #endregion Insert 

        #region Update Operation

        #region Update
        public Boolean Update(CityENT entCity)
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
                        objCmd.CommandText = "PR_City_UpdateByPK";
                        objCmd.Parameters.AddWithValue("@CityID", entCity.CityID);
                        objCmd.Parameters.AddWithValue("@CityName", entCity.CityName);
                        objCmd.Parameters.AddWithValue("@PinCode", entCity.Pincode);
                        objCmd.Parameters.AddWithValue("@STDCode", entCity.STDCode);
                        objCmd.Parameters.AddWithValue("@StateID", entCity.StateId);

                        #endregion Prepare Command

                        objCmd.ExecuteNonQuery();
                        entCity.CityID = (SqlInt32)objCmd.Parameters["CityID"].Value;
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

        #endregion Update

        #endregion Update Operation

        #region Delete Operation

        #region Delete
        public Boolean Delete(SqlInt32 CityID)
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
                        objCmd.CommandText = "PR_City_DeleteByPK";
                        objCmd.Parameters.AddWithValue("@CityID", CityID);
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

        #endregion Delete

        #endregion Delete Operation

        #region Select Operation

        #region SelectAll
        public DataTable SelectAll()
        {
            using (SqlConnection objConn = new SqlConnection(ConnectionString))
            {
                if(objConn.State != ConnectionState.Open)
                    objConn.Open();
                using (SqlCommand objCmd = objConn.CreateCommand())
                {
                    try
                    {
                        #region Prepare Command
                        objCmd.CommandType = CommandType.StoredProcedure;
                        objCmd.CommandText = "PR_City_selectAll";
                        #endregion Prepare Command

                        #region Read Data and Set Controls 
                        DataTable dt = new DataTable();
                        using(SqlDataReader objSDR=objCmd.ExecuteReader())
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
                        objCmd.CommandText = "PR_City_SelectForDropDownList";
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
        public CityENT SelectByPK(SqlInt32 CityID)
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
                        objCmd.CommandText = "PR_City_SelectByPK";
                        objCmd.Parameters.AddWithValue("@CityID", CityID);
                        #endregion Prepare Command

                        #region Read Data and Set Controls 
                        CityENT entCity = new CityENT();
                        using (SqlDataReader objSDR = objCmd.ExecuteReader())
                        {
                            while(objSDR.Read())
                            {
                                if (!objSDR["CityID"].Equals(DBNull.Value))
                                    entCity.CityID = Convert.ToInt32(objSDR["CityID"]);

                                if (!objSDR["PinCode"].Equals(DBNull.Value))
                                    entCity.Pincode = Convert.ToString(objSDR["PinCode"]);

                                if (!objSDR["CityName"].Equals(DBNull.Value))
                                    entCity.CityName = Convert.ToString(objSDR["CityName"]);

                                if (!objSDR["STDCode"].Equals(DBNull.Value))
                                    entCity.STDCode = Convert.ToString(objSDR["STDCode"]);

                                if (!objSDR["StateID"].Equals(DBNull.Value))
                                    entCity.StateId = Convert.ToInt32(objSDR["StateID"]);

                                if (!objSDR["CreationDate"].Equals(DBNull.Value))
                                    entCity.CreationDate = Convert.ToDateTime(objSDR["CreationDate"]);
                            }
                        }
                        return entCity;
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