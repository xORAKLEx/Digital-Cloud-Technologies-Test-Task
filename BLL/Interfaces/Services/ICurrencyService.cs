using BLL.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interfaces.Services
{
    public interface ICurrencyService
    {
        Task<IEnumerable<Market>> CryptingUpRequest();
    }
}
