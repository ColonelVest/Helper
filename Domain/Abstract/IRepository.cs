using Domain.Entities;
using System.Collections.Generic;

namespace Domain.Abstract
{
    public interface IRepository
    {
        IEnumerable<Period> Periods
        {
            get;
        }
    }
}
