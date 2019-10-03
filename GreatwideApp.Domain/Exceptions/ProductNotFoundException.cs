using System;
using System.Collections.Generic;
using System.Text;

namespace GreatwideApp.Domain.Exceptions
{
    public class ProductNotFoundException : Exception
    {
        public ProductNotFoundException(int id) : base($"Product not found with id: {id}")
        {  }
    }
}
