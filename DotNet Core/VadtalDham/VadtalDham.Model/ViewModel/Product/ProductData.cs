using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VadtalDham.Model.ViewModel.Product
{
    public class ProductData
    {
        public int ProductId { get; set; }
        [Required(ErrorMessage = "Please Enter Product Name")]

        public string? ProductName { get; set; }
        [Required(ErrorMessage = "Please Enter Product Amount")]

        public decimal ProductAmount { get; set; }
        [Required(ErrorMessage = "Please Enter Product Stock")]

        public int ProductStock { get; set; }

        public bool Staus { get; set; }

        public int FilterTotalCount { get; set; }
    }
    public class MyModel
    {
        public int ProductId { get; set; }

        public string? ProductName { get; set; }

        public decimal ProductAmount { get; set; }

        public int ProductStock { get; set; }

        public bool Staus { get; set; }
    }
}
