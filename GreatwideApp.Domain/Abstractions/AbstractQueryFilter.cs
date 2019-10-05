using GreatwideApp.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace GreatwideApp.Domain.Abstractions
{
    public abstract class AbstractQueryFilter : IQueryFilter
    {
        public int Size { get; set; }
        public int Skip { get; set; }
        public bool OrderByDescending { get; set; }

        // Add abstractions here
    }
}
