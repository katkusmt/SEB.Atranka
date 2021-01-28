using Android.App;
using Android.OS;
using Android.Widget;
using MvvmCross.Binding.BindingContext;
using MvvmCross.Platforms.Android.Presenters.Attributes;
using SEB_Atrankos_uzduotis.Core.Converters;
using SEB_Atrankos_uzduotis.Core.ViewModels;
using SEB_Atrankos_uzduotis.ListViews;

namespace SEB_Atrankos_uzduotis.Views
{
    [MvxActivityPresentation]
    [Activity(Theme = "@style/AppTheme", MainLauncher = true)]
    public class TransactionsView : BaseActivity<TransactionsViewModel>
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            SetContentView(Resource.Layout.TransactionsView);
            SetBindings();
        }

        public void SetBindings()
        {
            var set = this.CreateBindingSet<TransactionsView, TransactionsViewModel>();
            var totalAmountValue = FindViewById<TextView>(Resource.Id.TotalAmountValue);
            var totalAmountLabel = FindViewById<TextView>(Resource.Id.TotalAmountLabel);
            set.Bind(totalAmountValue).For(t => t.Text).To(vm => vm.TotalAmount);
            var transactionsListView = FindViewById<TransactionsListView>(Resource.Id.TransactionsListView);
            transactionsListView.ItemTemplateId = Resource.Layout.TransactionsItemView;
            var progressBar = FindViewById<ProgressBar>(Resource.Id.IsLoadingIndicator);
            set.Bind(progressBar).For(t => t.Alpha).To(vm => vm.IsLoading);
            set.Bind(transactionsListView).For(t => t.ItemsSource).To(vm => vm.Transactions);
            set.Bind(transactionsListView).For(t => t.Alpha).To(vm => vm.IsLoading).WithConversion<NotValueConverter>();
            set.Bind(totalAmountValue).For(t => t.Alpha).To(vm => vm.IsLoading).WithConversion<NotValueConverter>();
            set.Bind(totalAmountLabel).For(t => t.Alpha).To(vm => vm.IsLoading).WithConversion<NotValueConverter>();
            set.Apply();
        }
    }
}