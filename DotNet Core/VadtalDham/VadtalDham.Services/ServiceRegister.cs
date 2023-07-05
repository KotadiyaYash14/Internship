using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VadtalDham.Services.Product;
using VadtalDham.Services.UserPanel;

namespace VadtalDham.Services
{
    public class ServiceRegister
    {
        public static Dictionary<Type, Type> GetTypes()
        {
            var ServiceDictionary = new Dictionary<Type, Type>()
            {
                { typeof ( IUserPanelServices ), typeof ( UserPanelServices ) },
                { typeof( IProductServices ), typeof ( ProductServices ) }
            };
            return ServiceDictionary;
        }
    }
}
