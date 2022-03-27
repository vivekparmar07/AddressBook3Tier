using AddressBook.ENT;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for ContactDAL
/// </summary>
namespace AddressBook.DAL
{
    public class ContactDAL : DatabaseConfig
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
        public ContactDAL()
        {
            //
            // TODO: Add constructor logic here
            //
        }
        #endregion Constructor

        #region Insert Operation
        public Boolean Insert(ContactENT entContact)
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
                        objCmd.CommandText = "PR_Contact_Insert";
                        objCmd.Parameters.AddWithValue("@ContactID", SqlDbType.Int).Direction = ParameterDirection.Output;
                        objCmd.Parameters.AddWithValue("@ContactName", SqlDbType.VarChar).Value = entContact.ContactName;
                        objCmd.Parameters.AddWithValue("@Address", SqlDbType.VarChar).Value = entContact.Address;
                        objCmd.Parameters.AddWithValue("@CityID", SqlDbType.Int).Value = entContact.CityID;
                        objCmd.Parameters.AddWithValue("@StateID", SqlDbType.Int).Value = entContact.StateID;
                        objCmd.Parameters.AddWithValue("@CountryID", SqlDbType.Int).Value=entContact.CountryID;
                        objCmd.Parameters.AddWithValue("@ContactCategoryID", SqlDbType.Int).Value = entContact.ContactCategoryID;
                        objCmd.Parameters.AddWithValue("@Email", SqlDbType.VarChar).Value = entContact.Email;
                        objCmd.Parameters.AddWithValue("@FacebookID", SqlDbType.VarChar).Value = entContact.FacebookID;
                        objCmd.Parameters.AddWithValue("@LinkedinID", SqlDbType.VarChar).Value = entContact.LinkedInID;
                        objCmd.Parameters.AddWithValue("@WhatsAppNo", SqlDbType.VarChar).Value = entContact.WhatsappNo;
                        objCmd.Parameters.AddWithValue("@Age", SqlDbType.Int).Value = entContact.Age;
                        objCmd.Parameters.AddWithValue("@BloodGroup", SqlDbType.VarChar).Value = entContact.BloodGroup;
                        objCmd.Parameters.AddWithValue("@BirthDate", SqlDbType.DateTime).Value = entContact.BirthDate;
                        
                        #endregion Prepare Command

                        objCmd.ExecuteNonQuery();
                        entContact.ContactID = (SqlInt32)objCmd.Parameters["ContactID"].Value;
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
        public Boolean Update(ContactENT entContact)
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
                        objCmd.CommandText = "PR_Contact_Update";
                        objCmd.Parameters.AddWithValue("@ContactID", entContact.ContactID);
                        objCmd.Parameters.AddWithValue("@ContactName",entContact.ContactName);
                        objCmd.Parameters.AddWithValue("@Address",entContact.Address);
                        objCmd.Parameters.AddWithValue("@CityID",entContact.CityID);
                        objCmd.Parameters.AddWithValue("@StateID", entContact.StateID);
                        objCmd.Parameters.AddWithValue("@CountryID", entContact.CountryID);
                        objCmd.Parameters.AddWithValue("@ContactCategoryID", entContact.ContactCategoryID);
                        objCmd.Parameters.AddWithValue("@Email", entContact.Email);
                        objCmd.Parameters.AddWithValue("@FacebookID", entContact.FacebookID);
                        objCmd.Parameters.AddWithValue("@LinkedinID", entContact.LinkedInID);
                        objCmd.Parameters.AddWithValue("@WhatsAppNo", entContact.WhatsappNo);
                        objCmd.Parameters.AddWithValue("@Age", entContact.Age);
                        objCmd.Parameters.AddWithValue("@BloodGroup", entContact.BloodGroup);
                        objCmd.Parameters.AddWithValue("@BirthDate",entContact.BirthDate);

                        #endregion Prepare Command

                        objCmd.ExecuteNonQuery();
                        entContact.ContactID = (SqlInt32)objCmd.Parameters["ContactID"].Value;
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
        public Boolean Delete(SqlInt32 ContactID)
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
                        objCmd.CommandText = "PR_Contact_DeleteByPK";
                        objCmd.Parameters.AddWithValue("@ContactID", ContactID);
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
                        objCmd.CommandText = "PR_Contact_selectAll";
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


        #region SelectByPK
        public ContactENT SelectByPK(SqlInt32 ContactID)
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
                        objCmd.CommandText = "PR_Contact_SelectByPK";
                        objCmd.Parameters.AddWithValue("@ContactID", ContactID);
                        #endregion Prepare Command

                        #region Read Data and Set Controls 
                        ContactENT entContact = new ContactENT();
                        using (SqlDataReader objSDR = objCmd.ExecuteReader())
                        {
                            while (objSDR.Read())
                            {
                                if (!objSDR["ContactID"].Equals(DBNull.Value))
                                    entContact.ContactID = Convert.ToInt32(objSDR["ContactID"]);

                                if (!objSDR["Address"].Equals(DBNull.Value))
                                    entContact.Address = Convert.ToString(objSDR["Address"]);

                                if (!objSDR["BirthDate"].Equals(DBNull.Value))
                                    entContact.BirthDate = Convert.ToDateTime(objSDR["BirthDate"]);

                                if (!objSDR["BloodGroup"].Equals(DBNull.Value))
                                    entContact.BloodGroup = Convert.ToString(objSDR["BloodGroup"]);

                                if (!objSDR["FacebookID"].Equals(DBNull.Value))
                                    entContact.FacebookID = Convert.ToString(objSDR["FacebookID"]);

                                if (!objSDR["Email"].Equals(DBNull.Value))
                                    entContact.Email = Convert.ToString(objSDR["Email"]);

                                if (!objSDR["LinkedINID"].Equals(DBNull.Value))
                                    entContact.LinkedInID = Convert.ToString(objSDR["LinkedINID"]);

                                if (!objSDR["ContactName"].Equals(DBNull.Value))
                                    entContact.ContactName = Convert.ToString(objSDR["ContactName"]);

                                if (!objSDR["WhatsAppNo"].Equals(DBNull.Value))
                                    entContact.WhatsappNo = Convert.ToString(objSDR["WhatsAppNo"]);

                                if (!objSDR["ContactNo"].Equals(DBNull.Value))
                                    entContact.ContactNo = Convert.ToString(objSDR["ContactNo"]);

                                if (!objSDR["CityID"].Equals(DBNull.Value))
                                    entContact.CityID = Convert.ToInt32(objSDR["CityID"]);

                                if (!objSDR["ContactCategoryID"].Equals(DBNull.Value))
                                    entContact.ContactCategoryID = Convert.ToInt32(objSDR["ContactCategoryID"]);

                                if (!objSDR["StateID"].Equals(DBNull.Value))
                                    entContact.StateID = Convert.ToInt32(objSDR["StateID"]);

                                if (!objSDR["CountryID"].Equals(DBNull.Value))
                                    entContact.CountryID = Convert.ToInt32(objSDR["CountryID"]);

                                if (!objSDR["CreationDate"].Equals(DBNull.Value))
                                    entContact.CreationDate = Convert.ToDateTime(objSDR["CreationDate"]);
                            }
                        }
                        return entContact;
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
