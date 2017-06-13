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
        #region OnAppearing

        protected override void OnAppearing()
        {
            base.OnAppearing();
            mainLayout.BindingContext = this.BindingContext; //Need to pass BindingConetext control to control.
        }

        #endregion

        #region ListView Items Appearing

        private void ListView_ItemAppearing(object sender, ItemVisibilityEventArgs e)
        {
            if (ViewModel.IsBusy && ViewModel.Places.Count == 0)
                return;
            if (e.Item.Equals(ViewModel.Places[ViewModel.Places.Count - 1]))
            {
                //Hungry! Loading More Items
                ViewModel.SearchCommand.Execute(ViewModel.NextPageToken);
            }
        }

        #endregion
    }
}
