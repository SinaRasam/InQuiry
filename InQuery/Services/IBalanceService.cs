using Core;
using InQuiry.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastracture.Repository
{
    public interface IBalanceService
    {
        Task<APIResult<List<BalanceDto>>> GetApiAsync(string address);
    }
}
