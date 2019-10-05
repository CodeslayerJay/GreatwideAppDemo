using System;
using System.Collections.Generic;
using System.Text;

namespace GreatwideApp.Domain.Interfaces
{
    public interface IQueryFilter
    {
        int Size { get; set; }
        int Skip { get; set; }
        bool OrderByDescending { get; set; }
    }
}
