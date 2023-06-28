using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreDemoApp.Common.Helpers
{
    public class StoredProcedures
    {
        #region LoginStoredProcedures

        public const string UserLogin = "sp_UserLogin";
        public const string RegisterUser = "sp_RegisterUser";
        public const string ValidateUserTokenData = "sp_ValidateToken";
        public const string UpdateLoginToken = "sp_UpdateLoginToken";

        #endregion

        #region Country

        public const string GetAllCountry = "sp_GetAllcountry";
        public const string AddEditCountry = "sp_add_edit_country";
        public const string GetCountryById = "sp_GetCountryById";
        public const string DeleteCountry = "sp_delete_country";

        #endregion

        #region State

        public const string GetAllState = "sp_get_all_state";
        public const string DeleteState = "sp_delete_state";
        public const string AddEditState = "sp_add_edit_state";
        public const string GetStateById = "sp_GetStateById";

        #endregion

        #region City

        public const string GetAllCity = "sp_get_all_city";
        public const string DeleteCity = "sp_delete_city";
        public const string AddEditCity = "sp_add_edit_city";
        public const string GetStateByCountryId = "sp_Get_State_By_CountryId";
        public const string GetCityById = "sp_GetCityById";

        #endregion
    }
}