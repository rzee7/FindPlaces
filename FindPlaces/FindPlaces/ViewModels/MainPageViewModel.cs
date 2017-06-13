using FindPlaces.Contracts;
using FindPlaces.Helper;
using FindPlaces.Models;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using Prism.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace FindPlaces.ViewModels
{
    public class MainPageViewModel : BindableBase, INavigationAware
    {
        #region Private fields

        IApiService _apiServuce;
        IPageDialogService _dialogService;
        #endregion

        #region Constructor

        public MainPageViewModel(IApiService apiService, IPageDialogService dialogService)
        {
            _apiServuce = apiService;
            _dialogService = dialogService;
        }

        #endregion

        #region Properties

        private string _title;
        public string Title
        {
            get { return _title; }
            set { SetProperty(ref _title, value); }
        }

        private bool _isBusy;
        public bool IsBusy
        {
            get { return _isBusy; }
            set { SetProperty(ref _isBusy, value); }
        }

        private string _searchQuery;
        public string SearchQuery
        {
            get { return _searchQuery; }
            set { SetProperty(ref _searchQuery, value); }
        }

        private ObservableCollection<Place> _places;
        public ObservableCollection<Place> Places
        {
            get { return  _places; }
            set { SetProperty(ref _places, value); }
        }

        #endregion

        #region Commands

        private DelegateCommand _searchCommand;
        public DelegateCommand SearchCommand =>
            _searchCommand ?? (_searchCommand = new DelegateCommand(OnSearch));

        #endregion

        #region Internal Operations

        async void OnSearch()
        {
            if (string.IsNullOrWhiteSpace(SearchQuery))
            {
                await _dialogService.DisplayAlertAsync(Constants.DialogTitle, Messages.QueryRequired, Constants.CancelButton);
                return;
            }
            var fetchedPlaces = await _apiServuce.FetchData(SearchQuery);
            if (fetchedPlaces != null && fetchedPlaces.IsSuccess)
            {
                Places = new ObservableCollection<Place>(fetchedPlaces.Places);
            }
            else
            {
                await _dialogService.DisplayAlertAsync(Constants.DialogTitle, !string.IsNullOrEmpty(fetchedPlaces.Message) ? fetchedPlaces.Message : Messages.WentWrong, Constants.Ok);
            }
        }

        #endregion

        #region INavigation Aware Implementation

        public void OnNavigatedFrom(NavigationParameters parameters)
        {

        }

        public void OnNavigatingTo(NavigationParameters parameters)
        {

        }

        public void OnNavigatedTo(NavigationParameters parameters)
        {
            if (parameters.ContainsKey("title"))
                Title = (string)parameters["title"] + " and Prism";
        }

        #endregion
    }
}
