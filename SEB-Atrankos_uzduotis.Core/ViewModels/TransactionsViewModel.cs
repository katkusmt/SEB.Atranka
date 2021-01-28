using MvvmCross.ViewModels;
using SEB_Atrankos_uzduotis.Core.ItemViewModels;
using SEB_Atrankos_uzduotis.Core.Services;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SEB_Atrankos_uzduotis.Core.ViewModels
{
    public class TransactionsViewModel : BaseViewModel<object>
    {
        private readonly ITransactionsService _transactionsService;
        private List<List<int>> _sections;
        private int _lastYear = -1;
        private bool _isLoading = true;
        private double _totalAmount;

        public TransactionsViewModel(ITransactionsService transactionsService)
        {
            _transactionsService = transactionsService;
            Transactions = new MvxObservableCollection<TransactionsItemViewModel>();
            _sections = new List<List<int>>();
        }

        public MvxObservableCollection<TransactionsItemViewModel> Transactions { get; set; }

        public bool IsLoading
        {
            get => _isLoading;
            set => SetProperty(ref _isLoading, value);
        }

        public async override Task Initialize()
        {
            await GetTransactions();
            await base.Initialize(); ;
        }

        public string TotalAmount 
        {
            get => _totalAmount.ToString() + " $";
        }

        public async Task GetTransactions()
        {
            var response = await _transactionsService.GetTransactions();

            if (response.Result != null)
            {
                foreach (var item in response.Result)
                {
                    var year = item.Date.Year;
                    if(_lastYear != year)
                    {
                        _lastYear = year;
                        _sections.Add(new List<int>());
                    }
                    Transactions.Add(new TransactionsItemViewModel(item, _sections[_sections.Count - 1].Count == 0));
                    _sections[_sections.Count - 1].Add(_lastYear);
                    _totalAmount += item.Amount;
                }
            }

            await RaisePropertyChanged(nameof(Transactions));
            await RaisePropertyChanged(nameof(TotalAmount));
            IsLoading = false;
        }

        public override void Prepare(object parameter)
        {
        }
    }
}
