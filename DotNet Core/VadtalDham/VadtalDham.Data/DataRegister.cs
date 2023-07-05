using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VadtalDham.Data.DbRepository.Product;
using VadtalDham.Data.DbRepository.UserPanel;

namespace VadtalDham.Data
{
    public class DataRegister
    {
        public static Dictionary<Type, Type> GetTypes()
        {
            var types = new Dictionary<Type, Type>()
            {
                { typeof( IUserPanelRepository ), typeof(UserPanelRepository ) },
                { typeof(IProductRepository ), typeof(ProductRepository ) }
            };
            return types;
        }
    }
}
