using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VadtalDham.Common.Helpers
{
    public class StoredProcedures
    {
        #region LoginStoredProcedures

        public const string UserLogin = "sp_UserLogin";
        public const string ValidateUserTokenData = "sp_ValidateToken";
        public const string UpdateLoginToken = "sp_UpdateLoginToken";
        public const string GetUserDetailsByEmail = "sp_get_user_by_email";
        public const string OTPVerification = "sp_otp_verification";
        public const string UpdatePassword = "sp_update_password";
        public const string UpdateOTP = "sp_otp_update";


        #endregion

        #region ProductStoredProcedures

        public const string GetAllProduct = "sp_GetAll_Product";
        public const string DeleteProduct = "sp_delete_product";
        public const string AddProduct = "sp_add_product";
        public const string EditProduct = "sp_edit_product";
        public const string GetProductById = "sp_product_by_id";
        public const string UpdateProductStock = "sp_update_stock";

        #endregion

        #region PaginationStoredProcedures

        public const string Pagination = "sp_Pagination";

        #endregion

    }
}
