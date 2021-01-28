using SEB_Atrankos_uzduotis.Api;
using SEB_Atrankos_uzduotis.Api.DTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SEB_Atrankos_uzduotis.Core.Services
{
    public interface ITransactionsService
    {
        Task<ApiResponse<List<TransactionsDto>>> GetTransactions();
    }
}
