using MvvmCross.Navigation;
using MvvmCross.ViewModels;
using SEB_Atrankos_uzduotis.Core.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SEB_Atrankos_uzduotis.Core
{
    public class AppStart : MvxAppStart
    {
        public AppStart(IMvxApplication mvxApplication, IMvxNavigationService mvxNavigationService) : base(mvxApplication, mvxNavigationService)
        {

        }
        protected override Task NavigateToFirstViewModel(object hint = null)
        {
            NavigationService.Navigate<TransactionsViewModel>();

            return Task.CompletedTask;
        }
    }
}
