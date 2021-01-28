﻿using Newtonsoft.Json;
using System;

namespace SEB_Atrankos_uzduotis.Api.DTO
{
    public class TransactionsDto
    {
        [JsonProperty("counterPartyName")]
        public string PartyName { get; set; }

        [JsonProperty("counterPartyAccount")]
        public string PartyAccount { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("date")]
        public DateTime Date { get; set; }

        [JsonProperty("type")]
        public string CardType { get; set; }
        
        [JsonProperty("amount")]
        public double ExpenseAmount { get; set; }

    }
}
