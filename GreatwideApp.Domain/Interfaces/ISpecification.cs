using System;
using System.Collections.Generic;
using System.Text;

namespace GreatwideApp.Domain.Interfaces
{
    public interface ISpecification<T>
    {
        bool IsSatisfiedBy(T candidate);
    }
}
