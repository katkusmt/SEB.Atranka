using MvvmCross;
using MvvmCross.IoC;
using MvvmCross.ViewModels;
using SEB_Atrankos_uzduotis.Api;
using SEB_Atrankos_uzduotis.Core.Services;
using System;

namespace SEB_Atrankos_uzduotis.Core
{
    public class App : MvxApplication
    {
        public override void Initialize()
        {
            Mvx.IoCProvider.ConstructAndRegisterSingleton<ITransactionsApi, TransactionsApi>();
            Mvx.IoCProvider.ConstructAndRegisterSingleton<ITransactionsService, TransactionsService>();
        }
    }
}