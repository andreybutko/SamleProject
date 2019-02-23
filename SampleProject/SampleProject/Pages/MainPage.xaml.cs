using SampleProject.Service;
using SampleProject.ViewModel;
using Xamarin.Forms;

namespace SampleProject.Pages
{
    public partial class MainPage : ContentPage
    {
        public MainViewModel Context { get; set; }

        public MainPage()
        {
            InitializeComponent();
            BindingContext = new MainViewModel(new DataService());
            Context = (MainViewModel)BindingContext;
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            await Context.GetInfo();
        }


    }
}
