using SEB_Atrankos_uzduotis.Api.DTO;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace SEB_Atrankos_uzduotis.Core.ItemViewModels
{
    public class TransactionsItemViewModel
    {
        public TransactionsItemViewModel(TransactionsDto transactionsDto, bool isSectionVisible)
        {
            ExpenseDescription = transactionsDto.Description;
            DateDay = transactionsDto.Date.Day;
            DateMonth = transactionsDto.Date.ToString("MMM", CultureInfo.InvariantCulture);
            ExpenseAmount = transactionsDto.ExpenseAmount + " $";
            SectionName = transactionsDto.Date.Year.ToString();
            IsFirstInSection = isSectionVisible;
            PartyName = transactionsDto.PartyName;
            PartyAccount = transactionsDto.PartyAccount;
        }

        public string ExpenseDescription { get; set; }

        public string PartyName { get; set; }

        public string PartyAccount { get; set; }

        public int DateDay { get; set; }

        public string DateMonth { get; set; }
        
        public string ExpenseAmount { get; set; }

        public string SectionName { get; set; }

        public bool IsFirstInSection { get; set; }
    }
}
