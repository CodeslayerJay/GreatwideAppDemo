using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GreatwideApp.UI.Models.ViewModels
{
    public class ProductFormModel
    {
        public ProductFormModel()
        {
            ProductModelSelectItems = new List<SelectListItem>();
        }
        public int ProductId { get; set; }
        public string Name { get; set; }

        [Display(Name = "Product Number")]
        public string ProductNumber { get; set; }
        public string Color { get; set; }

        [Display(Name = "List Price")]
        public decimal ListPrice { get; set; }
        
        [Display(Name = "Product Model")]
        public int ProductModelId { get; set; }

        [Display(Name = "Sell Start Date")]
        public DateTime SellStartDate { get; set; } = DateTime.Now;


        //public virtual ProductModelViewModel ProductModel { get; set; }

        public IEnumerable<SelectListItem> ProductModelSelectItems { get; set; }

    }
}
