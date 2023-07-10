using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNetCoreWebAPI.Common.Helpers
{
    public class BaseApiMessage
    {
        #region Login

        public const string LoginSuccess = "Login Success";
        public const string LoginFailed = "Login Failed";

        #endregion

        #region Register

        public const string RegisterSuccess = "Register Success";
        public const string RegisterFailed = "Register Failed";

        #endregion

        #region CommonMessage

        public const string SomethingWentWrong = "Something went wrong";

        #endregion

        #region Country

        public const string CountryFetched = "Country Fetched Successfully";
        public const string AddCountry = "Country Added Successfully";
        public const string EditCountry = "Country Edit Successfully";
        public const string CountryAlreadyExists = "Country Already Exists";
        public const string DeleteCountry = "Country Deleted Successfully";
        public const string CountryDoesNotExists = "Country Doesn't Exists";
        public const string CountryInUse = "Country is Already Used in Another Schema";

        #endregion

        #region State

        public const string StateFetched = "State Fetched Successfully";
        public const string AddState = "State Added Successfully";
        public const string EditState = "State Edit Successfully";
        public const string StateAlreadyExists = "State Already Exists";
        public const string DeleteState = "State Deleted Successfully";
        public const string StateDoesNotExists = "State Doesn't Exists";
        public const string StateInUse = "State is Already Used in Another Schema";

        #endregion
    }
}
