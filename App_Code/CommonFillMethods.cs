using AddressBook.BAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

/// <summary>
/// Summary description for ComoonFillMethods
/// </summary>
namespace AddressBook
{
    public class CommonFillMethods
    {
        public CommonFillMethods()
        {
            //
            // TODO: Add constructor logic here
            //
        }
        #region Fill DropDownListState
        public static void FillDropDownListState(DropDownList ddl)
        {
            StateBAL balState = new StateBAL();
            ddl.DataSource = balState.SelectForDropDownList();
            ddl.DataValueField = "StateID";
            ddl.DataTextField = "StateName";
            ddl.DataBind();
            ddl.Items.Insert(0, new ListItem("Select State", "-1"));
        }
        #endregion Fill DropDownListState

        #region Fill DropDownListCity
        public static void FillDropDownListCity(DropDownList ddl)
        {
            CityBAL balCity = new CityBAL();
            ddl.DataSource = balCity.SelectForDropDownList();
            ddl.DataValueField = "CityID";
            ddl.DataTextField = "CityName";
            ddl.DataBind();
            ddl.Items.Insert(0, new ListItem("Select City", "-1"));
        }
        #endregion Fill DropDownListCity
    }
}