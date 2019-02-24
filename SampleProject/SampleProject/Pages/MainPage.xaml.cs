using SampleProject.Service;
using SampleProject.ViewModel;
using System;
using Xamarin.Forms;

namespace SampleProject.Pages
{
    public partial class MainPage : ContentPage
    {
        public MainViewModel Context { get; set; }
        private const int UpdateFrequency = 5;
        public MainPage()
        {
            InitializeComponent();
            BindingContext = new MainViewModel(new DataService());
            Context = (MainViewModel)BindingContext;

            Device.StartTimer(TimeSpan.FromSeconds(UpdateFrequency), () =>
            {
                Device.BeginInvokeOnMainThread(RefreshData);
                return true;
            });
        }

        private async void RefreshData() => await Context.GetInfo();
    }
}
