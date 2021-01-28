using MvvmCross.ViewModels;

namespace SEB_Atrankos_uzduotis.Core.ViewModels
{
    public abstract class BaseViewModel<T> : MvxViewModel<T> where T : class
    {
        protected BaseViewModel()
        {
        }
    }
}
