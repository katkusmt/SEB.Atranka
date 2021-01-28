using SEB_Atrankos_uzduotis.Api;
using SEB_Atrankos_uzduotis.Api.DTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SEB_Atrankos_uzduotis.Core.Services
{
    public class TransactionsService : ITransactionsService
    {
        private readonly ITransactionsApi _api;

        public TransactionsService(ITransactionsApi api)
        {
            _api = api;
        }

        public async Task<ApiResponse<List<TransactionsDto>>> GetTransactions()
        {
            var transactions = await _api.GetTransactions<List<TransactionsDto>>();
            transactions.Result.Sort((x, y) => y.Date.CompareTo(x.Date));
            return transactions;
        }
    }
}
