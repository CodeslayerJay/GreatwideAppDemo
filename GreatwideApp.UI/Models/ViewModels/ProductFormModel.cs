using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GreatwideApp.UI.Models.ViewModels
{
    public class ProductFormModel
    {
        public int ProductId { get; set; }
        public string Name { get; set; }
        
        public string ProductNumber { get; set; }
        public string Color { get; set; }

        public decimal ListPrice { get; set; }
        
        public int ProductModelId { get; set; }

        public DateTime SellStartDate { get; set; } = DateTime.Now;


        //public virtual ProductModelViewModel ProductModel { get; set; }

        public IEnumerable<SelectListItem> ProductModelSelectItems { get; set; }

    }
}
