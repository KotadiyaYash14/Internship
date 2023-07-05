using Dapper;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using VadtalDham.Common.Helpers;
using VadtalDham.Model.Config;
using VadtalDham.Model.ViewModel.Product;

namespace VadtalDham.Data.DbRepository.Product
{
    public class ProductRepository : BaseRepository, IProductRepository
    {
        #region Fields

        private readonly IConfiguration _configuration;

        #endregion

        #region Constructor

        public ProductRepository(IConfiguration configuration, IOptions<DataConfig> dataconfig) : base(dataconfig, configuration)
        {
            _configuration = configuration;
        }

        #endregion

        #region Methods


        /// <summary>
        /// Get All Product By Stored Procedure
        /// </summary>
        public async Task<List<ProductData>> GetAllProduct()
        {
            try
            {
                var Product = await QueryAsync<ProductData>(StoredProcedures.GetAllProduct, commandType: CommandType.StoredProcedure);
                return Product.ToList();
            }
            catch (Exception Exce)
            {
                throw Exce;
            }
        }

        /// <summary>
        /// Delete Product By Stored Procedure
        /// </summary>
        public async Task<int> DeleteProduct(int id)
        {
            try
            {
                var param = new DynamicParameters();
                param.Add("@@productid", id);
                return await ExecuteAsync<int>(StoredProcedures.DeleteProduct, param, commandType: CommandType.StoredProcedure);
            }
            catch (Exception Exce)
            {
                throw Exce;
            }
        }

        /// <summary>
        /// Add Product By Stored Procedure
        /// </summary>
        public async Task<int> AddProduct(ProductData product)
        {
            try
            {
                var param = new DynamicParameters();
                param.Add("@productid", null);
                param.Add("@productname", product.ProductName);
                param.Add("@productamount", product.ProductAmount);
                param.Add("@productstock", product.ProductStock);
                return await ExecuteAsync<int>(StoredProcedures.AddProduct, param, commandType: CommandType.StoredProcedure);
            }
            catch (Exception Exce)
            {
                throw Exce;
            }
        }

        /// <summary>
        /// Edit Product By Stored Procedure
        /// </summary>
        public async Task<int> EditProduct(ProductData product)
        {
            try
            {
                var param = new DynamicParameters();
                param.Add("@productid", product.ProductId);
                param.Add("@productname", product.ProductName);
                param.Add("@productamount", product.ProductAmount);
                var data =  await ExecuteAsync<int>(StoredProcedures.EditProduct, param, commandType: CommandType.StoredProcedure);
                return data;
            }
            catch (Exception Exce)
            {
                throw Exce;
            }
        }

        /// <summary>
        /// Get Product By Id Method Using Stored Procedure
        /// </summary>
        public async Task<ProductData> GetProductById(int id)
        {
            try
            {
                var param = new DynamicParameters();
                param.Add("@productid", id);
                return await QueryFirstOrDefaultAsync<ProductData>(StoredProcedures.GetProductById, param, commandType: CommandType.StoredProcedure);
            }
            catch (Exception Exce)
            {
                throw Exce;
            }
        }

        /// <summary>
        /// Update Product Stock Method By Stored Procedure
        /// </summary>
        public async Task<int> UpdateProductStock(ProductData product)
        {
            var param = new DynamicParameters();
            param.Add("@productid", product.ProductId);
            param.Add("@productstock", product.ProductStock);
            var data = await ExecuteAsync<int>(StoredProcedures.UpdateProductStock, param, commandType: CommandType.StoredProcedure);
            return data;
        }

        public async Task<List<ProductData>> GetProcuctDataTable(string sortColumn, string sortDirection, int OffsetValue, int PagingSize, string searchby)
        {
            var param = new DynamicParameters();
            param.Add("@sortColumn", sortColumn);
            param.Add("@sortOrder", sortDirection);
            param.Add("@OffsetValue", OffsetValue);
            param.Add("@PagingSize", PagingSize);
            param.Add("@SearchText", searchby);
            var data = await QueryAsync<ProductData>("sp_Pagination", param, commandType: CommandType.StoredProcedure);
            return data.ToList();
        }

        #endregion
    }
}
