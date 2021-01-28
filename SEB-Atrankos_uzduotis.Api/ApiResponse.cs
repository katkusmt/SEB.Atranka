using System;
using System.Collections.Generic;
using System.Text;

namespace SEB_Atrankos_uzduotis.Api
{
    public class ApiResponse<Dto> : ApiResponse
    {
        public Dto Result { get; set; }
    }

    public class ApiResponse
    {
        public string ErrorMessage { get; set; }
    }
}
