using AddressBook.DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for StateBAL
/// </summary>
namespace AddressBook.BAL
{
    public class StateBAL
    {
        #region Local Variable

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

        #endregion Local Variable

        #region Constructor
        public StateBAL()
        {
            //
            // TODO: Add constructor logic here
            //
        }
        #endregion Constructor

        #region Select Operation 

        #region SelectForDropDownList

        public DataTable SelectForDropDownList()
        {
            StateDAL dalState = new StateDAL();
            return dalState.SelectForDropDownList();
        }

        #endregion SelectForDropDownList

        #endregion Select Operation

    }
}