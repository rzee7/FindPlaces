using FindPlaces.ViewModels;
using Xamarin.Forms;

namespace FindPlaces.Views
{
    public partial class MainPage : ContentPage
    {
        internal MainPageViewModel ViewModel { get { return BindingContext as MainPageViewModel; } }
        public MainPage()
        {
            InitializeComponent();
        }

        private void ListView_ItemAppearing(object sender, ItemVisibilityEventArgs e)
        {
            if (ViewModel.IsBusy && ViewModel.Places.Count == 0)
                return;
            if (e.Item.Equals(ViewModel.Places[ViewModel.Places.Count - 1]))
            {
                //Load Items
            }
        }
    }
}
