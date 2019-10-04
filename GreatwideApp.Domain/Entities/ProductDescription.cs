using System;
using System.Collections.Generic;

namespace GreatwideApp.Domain.Entities
{
    
    public class ProductDescription
    {
        
        public int ProductDescriptionId { get; set; }
        //[Required]
        //[StringLength(400)]
        public string Description { get; set; }
        //[Column("rowguid")]
        public Guid Rowguid { get; set; }
        //[Column(TypeName = "datetime")]
        public DateTime ModifiedDate { get; set; }

    }
}
