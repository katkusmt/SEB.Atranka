using System.Threading.Tasks;

namespace SEB_Atrankos_uzduotis.Api
{
    public interface ITransactionsApi
    {
        Task<ApiResponse<Dto>> GetTransactions<Dto>();
    }
}
