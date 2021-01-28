

using MvvmCross.Platforms.Android.Views;
using MvvmCross.ViewModels;

namespace SEB_Atrankos_uzduotis
{
    public abstract class BaseActivity<TViewModel> : MvxActivity<TViewModel> where TViewModel : MvxViewModel
    { 
        protected BaseActivity()
        {
        }
    }
}