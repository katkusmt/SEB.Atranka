using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Util;
using Android.Views;
using Android.Widget;
using MvvmCross.Binding.BindingContext;
using MvvmCross.Platforms.Android.Binding.Views;
using MvvmCross.Plugin.Visibility;
using SEB_Atrankos_uzduotis.Core.ItemViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SEB_Atrankos_uzduotis.ListViews
{
    public class TransactionsListView : MvxListView
    {
        public TransactionsListView(Context context, IAttributeSet attrs) : base(context, attrs, new TransactionsListItemViewAdapter(context))
        {
            Divider.Alpha = 0;
        }

        private class TransactionsListItemViewAdapter : MvxAdapterWithChangedEvent
        {
            private readonly Context _context;
            public TransactionsListItemViewAdapter(Context context) : base(context)
            {
                _context = context;
            }

            protected override IMvxListItemView CreateBindableView(object dataContext, ViewGroup parent, int templateId)
            {
                return new TransactionsListItemView(_context, BindingContext.LayoutInflaterHolder, dataContext, parent, templateId);
            }

            public override View GetView(int position, View convertView, ViewGroup parent)
            {
                return base.GetView(position, convertView, parent);
            }
        }

        private class TransactionsListItemView : MvxListItemView
        {
            public TransactionsListItemView(
                Context context,
                IMvxLayoutInflaterHolder layoutInflaterHolder,
                object dataContext,
                ViewGroup parent,
                int templateId)
                : base(context, layoutInflaterHolder, dataContext, parent, templateId)
            {
                var set = this.CreateBindingSet<TransactionsListItemView, TransactionsItemViewModel>();

                var sectionTitle = Content.FindViewById<TextView>(Resource.Id.SectionTitle);
                set.Bind(sectionTitle).For(t => t.Text).To(vm => vm.SectionName);
                set.Bind(sectionTitle).For("Visibility").To(vm => vm.IsFirstInSection).WithConversion("Visibility");

                var separatorLine = Content.FindViewById<FrameLayout>(Resource.Id.SeparatorLine);
                set.Bind(separatorLine).For("Visibility").To(vm => vm.IsFirstInSection).WithConversion("Visibility");

                var expenseDescription = Content.FindViewById<TextView>(Resource.Id.ExpenseDescription);
                set.Bind(expenseDescription).For(t => t.Text).To(vm => vm.ExpenseDescription);

                var dateDay = Content.FindViewById<TextView>(Resource.Id.DateDay);
                set.Bind(dateDay).For(t => t.Text).To(vm => vm.DateDay);

                var dateMonth = Content.FindViewById<TextView>(Resource.Id.DateMonth);
                set.Bind(dateMonth).For(t => t.Text).To(vm => vm.DateMonth);

                var counterPartyName = Content.FindViewById<TextView>(Resource.Id.CounterPartyName);
                set.Bind(counterPartyName).For(t => t.Text).To(vm => vm.PartyName);

                var expenseAccount = Content.FindViewById<TextView>(Resource.Id.ExpenseAccount);
                set.Bind(expenseAccount).For(t => t.Text).To(vm => vm.PartyAccount);

                var expenseAmount = Content.FindViewById<TextView>(Resource.Id.ExpenseAmount);
                set.Bind(expenseAmount).For(t => t.Text).To(vm => vm.ExpenseAmount);

                set.Apply();
            }
        }
    }
}