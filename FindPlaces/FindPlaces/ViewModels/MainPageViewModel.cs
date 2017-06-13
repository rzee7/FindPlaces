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
    public class MainPageViewModel : BindableBase
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
            Places = new ObservableCollection<Place>();
            IsEmpty = true;
        }

        #endregion

        #region Properties

        public string PreviousSearchQuery { get; set; }

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
            set
            {
                SetProperty(ref _searchQuery, value);
                if (string.IsNullOrEmpty(SearchQuery))
                {
                    Places.Clear();
                    IsEmpty = true;
                }
            }
        }

        private ObservableCollection<Place> _places;
        public ObservableCollection<Place> Places
        {
            get { return  _places; }
            set { SetProperty(ref _places, value); }
        }
        private string _nextPageToken;
        public string NextPageToken
        {
            get { return _nextPageToken; }
            set { SetProperty(ref _nextPageToken, value); }
        }

        private string _statusMessage;
        public string StatusMessage
        {
            get { return _statusMessage; }
            set { SetProperty(ref _statusMessage, value); }
        }

        private bool _isEmpty;
        public bool IsEmpty
        {
            get { return _isEmpty; }
            set { SetProperty(ref _isEmpty, value); if (IsEmpty) StatusMessage = Messages.NoResult; }
        }

        #endregion

        #region Commands

        private DelegateCommand<string> _searchCommand;
        public DelegateCommand<string> SearchCommand =>
            _searchCommand ?? (_searchCommand = new DelegateCommand<string>(OnSearch));

        #endregion

        #region Internal Operations

        async void OnSearch(string nextPageToken)
        {
            //Ignoring if same query, This seems bug in SearchBar Command, It executing every time you clicks text field
            if (SearchQuery.Equals(PreviousSearchQuery, StringComparison.CurrentCultureIgnoreCase) && string.IsNullOrEmpty(nextPageToken) && Places.Count > 0)
                return;
            if (!string.IsNullOrEmpty(nextPageToken))
            {
                StatusMessage = Messages.LoadingMore;
            }
            else
            {
                StatusMessage = Messages.DefaultStatus;
                Places.Clear();
            }
          
            IsEmpty = false;
            IsBusy = true;

            PreviousSearchQuery = SearchQuery;

            var fetchedPlaces = await _apiServuce.FetchData(SearchQuery.Trim());
            if (fetchedPlaces != null && fetchedPlaces.IsSuccess)
            {
                IsEmpty = false;
                NextPageToken = fetchedPlaces.NextPageToken;
                foreach (var item in fetchedPlaces.Places)
                {
                    Places.Add(item); //I'm aware this is slow but List has some limitation with INotify.
                }
            }
            else
            {
                IsBusy = false;
                await _dialogService.DisplayAlertAsync(Constants.DialogTitle, !string.IsNullOrEmpty(fetchedPlaces.Message) ? fetchedPlaces.Message : Messages.WentWrong, Constants.Ok);
                IsEmpty = true;
            }
            IsBusy = false;
        }

        #endregion
    }
}
