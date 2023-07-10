using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNetCoreWebAPI.Common.Helpers
{
    public class StoredProcedure
    {
        #region Login

        public const string UserLogin = "sp_UserLogin";
        public const string RegisterUser = "sp_RegisterUser";
        public const string ValidateUserTokenData = "sp_ValidateToken";
        public const string UpdateLoginToken = "sp_UpdateLoginToken";

        #endregion

        #region Country

        public const string CountryList = "sp_GetAllcountry";
        public const string AddEditCountry = "sp_add_edit_country";
        public const string DeleteCountry = "sp_delete_country";

        #endregion

        #region State

        public const string StateList = "sp_get_all_state";
        public const string AddEditState = "sp_add_edit_state";
        public const string DeleteState = "sp_delete_state";

        #endregion
    }
}
