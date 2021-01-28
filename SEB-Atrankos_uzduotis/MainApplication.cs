using Android.App;
using Android.Runtime;
using MvvmCross.Platforms.Android.Views;
using SEB_Atrankos_uzduotis.Core;
using System;

namespace SEB_Atrankos_uzduotis
{
    [Application]
    class MainApplication : MvxAndroidApplication<Setup, App>
    {
        public MainApplication(IntPtr javaReference, JniHandleOwnership transfer) : base(javaReference, transfer)
        {

        }
    }
}