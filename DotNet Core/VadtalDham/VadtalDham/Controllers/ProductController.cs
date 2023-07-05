using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Diagnostics;
using System.Diagnostics.Metrics;
using VadtalDham.Filter;
using VadtalDham.Model.DataTable;
using VadtalDham.Model.ViewModel.Product;
using VadtalDham.Model.ViewModel.UserPanel;
using VadtalDham.Models;
using VadtalDham.Services.Product;

namespace VadtalDham.Controllers
{
    [TypeFilter(typeof(CustomAuthorizationFilter))]
    [ResponseCache(Duration = 120, Location = ResponseCacheLocation.Any, NoStore = true)]
    public class ProductController : Controller
    {
        #region Fields 

        private IProductServices productServices;

        #endregion

        #region Constructor

        public ProductController(IProductServices _productServices)
        {
            productServices = _productServices;
        }

        #endregion

        /// <summary>
        /// Index Method
        /// </summary>

        public IActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// Get All Product From Database
        /// </summary>

        public async Task<IActionResult> ProductList()
        {
            try
            {
                return View();
            }
            catch (Exception Exce)
            {
                throw Exce;
            }
        }

        /// <summary>
        /// Delete Product Method
        /// </summary>

        public async Task<IActionResult> DeleteProduct(int id)
        {
            try
            {
                await productServices.DeleteProduct(id);
                TempData["Delete"] = "Deleted";
                return RedirectToAction("ProductList");
            }
            catch (Exception Exce)
            {
                throw Exce;
            }
        }

        /// <summary>
        ///  Add Product Method
        /// </summary>

        public IActionResult AddProduct()
        {
            try
            {
                return View();
            }
            catch (Exception Exce)
            {
                throw Exce;
            }
        }

        /// <summary>
        /// Add Product Post Method
        /// </summary>

        [HttpPost]
        public async Task<IActionResult> AddProduct(ProductData product)
        {
            try
            {
                var Product = await productServices.AddProduct(product);
                if (Product == -1 && product.ProductId == 0)
                {
                    TempData["Available"] = "Product Already Exists You Can't Add It";
                    return RedirectToAction("ProductList");
                }
                else if (product.ProductId == 0 && Product != 0)
                {
                    TempData["Register"] = "Product added Successfully";
                    return RedirectToAction("ProductList");
                }
                else
                {
                    return RedirectToAction("ProductList");
                }
            }
            catch (Exception Exce)
            {
                throw Exce;
            }
        }

        /// <summary>
        ///  Edit Product Method
        /// </summary>

        public async Task<IActionResult> EditProduct(int id)
        {
            try
            {
                var Product = await productServices.GetProductById(id);
                return RedirectToAction("ProductList", Product);
            }
            catch (Exception Exce)
            {
                throw Exce;
            }
        }

        /// <summary>
        ///  Edit Product Post Method
        /// </summary>

        [HttpPost]
        public async Task<IActionResult> EditProduct(ProductData product)
        {
            try
            {
                var Product = await productServices.EditProduct(product);
                if (product.ProductId != 0 && Product != 0)
                {
                    TempData["Update"] = "Product Updated Successfully";
                    return RedirectToAction("ProductList");
                }
                else
                {
                    return RedirectToAction("ProductList");
                }
            }
            catch (Exception Exce)
            {
                throw Exce;
            }
        }

        /// <summary>
        ///  Update Product Stock Method
        /// </summary>
   
        public IActionResult UpdateProductStock()
        {
            try
            {
                return View();
            }
            catch (Exception Exce)
            {
                throw Exce;
            }
        }

        /// <summary>
        ///  Update Product Stock Post Method
        /// </summary>

        [HttpPost]
        public async Task<IActionResult> UpdateProductStock(ProductData product)
        {
            try
            {
                product.ProductId = Convert.ToInt32(TempData["ProductId"]);
                var Product = await productServices.UpdateProductStock(product);
                if (product.ProductId != 0 && Product != 0)
                {
                    TempData["UpdateStock"] = "Product Stock Updated Successfully";
                    return RedirectToAction("ProductList");
                }
                else
                {
                    return RedirectToAction("ProductList");
                }
            }
            catch (Exception Exce)
            {
                throw Exce;
            }
        }

        /// <summary>
        ///  Json Method for get product list
        /// </summary>

        public async Task<JsonResult> GetListOfProduct()
        {
            List<ProductData> Product = await productServices.GetAllProduct();
            var jsonProduct = JsonConvert.SerializeObject(Product);
            return Json(jsonProduct);
        }

        /// <summary>
        ///  Json Method for get product list by id
        /// </summary>
 
        public async Task<JsonResult> GetProductById(int id)
        {
            TempData["ProductId"] = id;
            ProductData Product = await productServices.GetProductById(id);
            var jsonProduct = JsonConvert.SerializeObject(Product);
            return Json(jsonProduct);
        }

        [HttpPost]
        public async Task<IActionResult> DataTableProductList()
        {
            var productdata = await productServices.GetAllProduct();

            var count = productdata.Count();
            IEnumerable<ProductData> product;

            HttpContext context = HttpContext;
            context.Response.ContentType = "text/plain";

            List<string> columns = new List<string>();
            columns.Add("productId");
            columns.Add("productName");
            columns.Add("productAmount");
            columns.Add("productStock");
            columns.Add("staus");

            Int32 ajaxDraw = Convert.ToInt32(context.Request.Form["draw"]);

            //OffsetValue  
            Int32 OffsetValue = Convert.ToInt32(context.Request.Form["start"]);

            //No of Records shown per page  
            Int32 PagingSize = Convert.ToInt32(context.Request.Form["length"]);

            //Getting value from the seatch TextBox  
            string searchby = context.Request.Form["search[value]"];

            //Index of the Column on which Sorting needs to perfor
            string sortColumn = context.Request.Form["order[0][column]"];

            //Finding the column name from the list based upon the column Index
            sortColumn = columns[Convert.ToInt32(sortColumn)];

            //Sorting Direction  
            string sortDirection = context.Request.Form["order[0][dir]"];

            //Get the Data from the Database  
            List<ProductData> ListOfProductData = await productServices.GetProcuctDataTable(sortColumn, sortDirection, OffsetValue, PagingSize, searchby);

            Int32 recordTotal = 0;
            List<MyModel> products = new List<MyModel>();

            if (ListOfProductData != null)
            {
                for (int i = 0; i < ListOfProductData.Count(); i++)
                {
                    MyModel mymodel = new MyModel();
                    mymodel.ProductId = ListOfProductData[i].ProductId;
                    mymodel.ProductName = ListOfProductData[i].ProductName;
                    mymodel.ProductAmount = ListOfProductData[i].ProductAmount;
                    mymodel.ProductStock = ListOfProductData[i].ProductStock;
                    mymodel.Staus = ListOfProductData[i].Staus;
                    products.Add(mymodel);

                }
                recordTotal = ListOfProductData.Count() > 0 ? Convert.ToInt32(ListOfProductData.FirstOrDefault().FilterTotalCount) : 0;
            }
            Int32 recordFiltered = recordTotal;
            DataTableResponse objDataTableResponse = new DataTableResponse()
            {
                draw = ajaxDraw,
                recordsFiltered = recordTotal,
                recordsTotal = recordTotal,
                data = products
            };

            return Json(objDataTableResponse);
        }
    }
}