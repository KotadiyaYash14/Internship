using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VadtalDham.Model.ViewModel.Product;

namespace VadtalDham.Services.Product
{
    public interface IProductServices
    {
        Task<List<ProductData>> GetAllProduct();

        Task<int> DeleteProduct(int id);

        Task<int> AddProduct(ProductData product);

        Task<int> EditProduct(ProductData product);

        Task<ProductData> GetProductById(int id);

        Task<int> UpdateProductStock(ProductData product);

        Task<List<ProductData>> GetProcuctDataTable(string sortColumn, string sortDirection, int OffsetValue, int PagingSize, string searchby);
    }
}
