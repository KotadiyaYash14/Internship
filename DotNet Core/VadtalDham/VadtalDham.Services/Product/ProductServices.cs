using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VadtalDham.Data.DbRepository.Product;
using VadtalDham.Model.ViewModel.Product;

namespace VadtalDham.Services.Product
{
    public class ProductServices : IProductServices
    {
        #region Fields

        private IProductRepository productRepository;

        #endregion

        #region Constructor

        public ProductServices(IProductRepository _productRepository)
        {
            productRepository = _productRepository;
        }

        #endregion

        #region Methods


        /// <summary>
        /// Get Product List Method
        /// </summary>
        public async Task<List<ProductData>> GetAllProduct()
        {
           return await productRepository.GetAllProduct();
        }

        /// <summary>
        /// Delete Product Method
        /// </summary>
        public async Task<int> DeleteProduct(int id)
        {
           return await productRepository.DeleteProduct(id);
        }

        /// <summary>
        /// Add Product Method
        /// </summary>
        public async Task<int> AddProduct(ProductData product)
        {
           return await productRepository.AddProduct(product);
        }

        /// <summary>
        /// Edit Product Method
        /// </summary>
        public async Task<int> EditProduct(ProductData product)
        {
            return await productRepository.EditProduct(product);
        }

        /// <summary>
        /// Get Product By Id Method
        /// </summary>
        public async Task<ProductData> GetProductById(int id)
        {
          return await productRepository.GetProductById(id);
        }

        /// <summary>
        /// Update Product Stock Method
        /// </summary>
        public async Task<int> UpdateProductStock(ProductData product)
        {
            return await productRepository.UpdateProductStock(product);
        }

        public async Task<List<ProductData>> GetProcuctDataTable(string sortColumn, string sortDirection, int OffsetValue, int PagingSize, string searchby)
        {
            return await productRepository.GetProcuctDataTable(sortColumn, sortDirection, OffsetValue, PagingSize, searchby);
        }
        #endregion
    }
}
