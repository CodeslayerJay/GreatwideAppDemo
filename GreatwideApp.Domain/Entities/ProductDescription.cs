using System;
using System.Collections.Generic;

namespace GreatwideApp.Domain.Entities
{
    
    public class ProductDescription
    {
        
        public int ProductDescriptionId { get; set; }
       
        public string Description { get; set; }
        
        public Guid Rowguid { get; set; }
        
        public DateTime ModifiedDate { get; set; } = DateTime.Now;

    }
}
