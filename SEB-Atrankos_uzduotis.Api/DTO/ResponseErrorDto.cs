using Newtonsoft.Json;

namespace SEB_Atrankos_uzduotis.Api.DTO
{
    public class ErrorResponseDto
    {
        [JsonProperty("message")]
        public string Message { get; set; }

        [JsonProperty("Message")]
        public string OtherMessage { get; set; }

        [JsonProperty("error_description")]
        public string ErrorDescription { get; set; }

        [JsonProperty("error")]
        public string Error { get; set; }
    }
}