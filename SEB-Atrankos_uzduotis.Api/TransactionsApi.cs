using Newtonsoft.Json;
using SEB_Atrankos_uzduotis.Api.DTO;
using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace SEB_Atrankos_uzduotis.Api
{
    public class TransactionsApi : ITransactionsApi
    {
        private const string TransactionsUri = "https://sheet.best/api/sheets/ebb5bfdc-efda-4966-9ecf-d2c171d6985a";
        public async Task<ApiResponse<Dto>> GetTransactions<Dto>()
        {
            var client = new HttpClient();
            var result = new ApiResponse<Dto>();

            HttpResponseMessage response = await client.GetAsync(TransactionsUri);
            var content = await response.Content.ReadAsStringAsync();
            if (response.IsSuccessStatusCode)
            {
                result.Result = JsonConvert.DeserializeObject<Dto>(content);
            }
            else
            {
               result.ErrorMessage = await ParseErrorMessage(response);
            }

            return result;
        }

        private async Task<string> ParseErrorMessage(HttpResponseMessage response)
        {
            switch (response.StatusCode)
            {
                // allowed http statuses
                case HttpStatusCode.BadRequest:
                case HttpStatusCode.NoContent:
                case HttpStatusCode.Unauthorized:
                case HttpStatusCode.NotModified:
                case HttpStatusCode.UpgradeRequired:
                    {
                        string responseString = await response.Content.ReadAsStringAsync();
                        ErrorResponseDto error = JsonConvert.DeserializeObject<ErrorResponseDto>(responseString);

                        if (!string.IsNullOrEmpty(error?.Message))
                        {
                            return error.Message;
                        }

                        if (!string.IsNullOrEmpty(error?.OtherMessage))
                        {
                            return error.OtherMessage;
                        }

                        if (!string.IsNullOrEmpty(error?.ErrorDescription))
                        {
                            return error.ErrorDescription;
                        }

                        if (!string.IsNullOrEmpty(error?.Error))
                        {
                            return error.Error;
                        }

                        return null;
                    }

                // fatal error from server: 500, 404, 403 etc.
                default:
                    return null;
            }
        }
    }
}
