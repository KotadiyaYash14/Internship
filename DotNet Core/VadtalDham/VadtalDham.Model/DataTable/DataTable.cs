using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VadtalDham.Model.ViewModel.Product;
using VadtalDham.Model.ViewModel.UserPanel;

namespace VadtalDham.Model.DataTable
{
    public class DataTable
    {
        public string? sortColumn { get; set; }
        public string? sortOrder { get; set; }
        public int OffsetValue { get; set; }
        public int PagingSize { get; set; }
        public int? SearchText { get; set; }
    }
    public class DataTableResponse
    {
        public int draw { get; set; }
        public int recordsFiltered { get; set; }
        public int recordsTotal { get; set; }
        public List<MyModel> data { get; set; }
    }
}
