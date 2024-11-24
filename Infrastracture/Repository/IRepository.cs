using Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastracture.Repository
{
    public interface IRepository
    {
        Task AddAsync(Balance balance);
        Task AddRangeAsync(List<Balance> balances);
    }
}
