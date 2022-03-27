using AddressBook.ENT;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for StateDAL
/// </summary>
namespace AddressBook.DAL
{
    public class StateDAL : DatabaseConfig
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
        public StateDAL()
        {
            //
            // TODO: Add constructor logic here
            //
        }
        #endregion Constructor

        #region Insert Operation
        public Boolean Insert(StateENT entState)
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
                        objCmd.CommandText = "PR_State_Insert";
                        objCmd.Parameters.AddWithValue("@StateID", SqlDbType.Int).Direction = ParameterDirection.Output;
                        objCmd.Parameters.AddWithValue("@StateName", SqlDbType.VarChar).Value = entState.StateName;
                        objCmd.Parameters.AddWithValue("@StateCode", SqlDbType.VarChar).Value = entState.StateCode;
                        objCmd.Parameters.AddWithValue("@CountryID", SqlDbType.Int).Value = entState.CountryID;

                        #endregion Prepare Command

                        objCmd.ExecuteNonQuery();
                        entState.StateID = (SqlInt32)objCmd.Parameters["StateID"].Value;
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

        #region Update Operation
        public Boolean Update(StateENT entState)
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
                        objCmd.CommandText = "PR_State_UpdateByPK";
                        objCmd.Parameters.AddWithValue("@StateID", entState.StateID);
                        objCmd.Parameters.AddWithValue("@CountryID", entState.CountryID);
                        objCmd.Parameters.AddWithValue("@StateName", entState.StateName);
                        objCmd.Parameters.AddWithValue("@StateCode", entState.StateCode);

                        #endregion Prepare Command

                        objCmd.ExecuteNonQuery();
                        entState.StateID = (SqlInt32)objCmd.Parameters["StateID"].Value;
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
        public Boolean Delete(SqlInt32 StateID)
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
                        objCmd.CommandText = "PR_State_DeleteByPK";
                        objCmd.Parameters.AddWithValue("@StateID", StateID);
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
                        objCmd.CommandText = "PR_State_selectAll";
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
                        objCmd.CommandText = "PR_State_SelectForDropDownList";
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
        public StateENT SelectByPK(SqlInt32 StateID)
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
                        objCmd.CommandText = "PR_State_SelectByPK";
                        objCmd.Parameters.AddWithValue("@StateID", StateID);
                        #endregion Prepare Command

                        #region Read Data and Set Controls 
                        StateENT entState = new StateENT();
                        using (SqlDataReader objSDR = objCmd.ExecuteReader())
                        {
                            while (objSDR.Read())
                            {
                                if (!objSDR["StateID"].Equals(DBNull.Value))
                                    entState.StateID = Convert.ToInt32(objSDR["StateID"]);

                                if (!objSDR["CountryID"].Equals(DBNull.Value))
                                    entState.CountryID = Convert.ToInt32(objSDR["CountryID"]);

                                if (!objSDR["StateName"].Equals(DBNull.Value))
                                    entState.StateName = Convert.ToString(objSDR["StateName"]);

                                if (!objSDR["StateCode"].Equals(DBNull.Value))
                                    entState.StateCode = Convert.ToString(objSDR["StateCode"]);

                                if (!objSDR["CreationDate"].Equals(DBNull.Value))
                                    entState.CreationDate = Convert.ToDateTime(objSDR["CreationDate"]);
                            }
                        }
                        return entState;
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