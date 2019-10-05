using System;
using System.Collections.Generic;
using System.Text;

namespace GreatwideApp.Domain.Exceptions
{
    public class ProductSpecException : Exception
    {
        public ProductSpecException(string message) : base($"Must meet requirement: {message}")
        { }
    }
}
