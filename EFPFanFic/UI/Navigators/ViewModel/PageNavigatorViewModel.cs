using EFPFanFic.UI.Navigators.Commands;
using Midium.Helpers.Observable;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFPFanFic.UI.Navigators.ViewModel
{
    public class PageNavigatorViewModel : ObservableObject
    {
        private bool _isFirstButtonEnabled;
        private bool _isPreviousButtonEnabled;
        private bool _isNextButtonEnabled;
        private bool _isLastButtonEnabled;
        private int _currentPage;
        private int _maxPages;

        private FirstPageCommand _firstPageCommand;
        private PreviousPageCommand _previousPageCommand;
        private NextPageCommand _nextPageCommand;
        private LastPageCommand _lastPageCommand;

        public event Action GotoFirstPage;
        public event Action GotoPreviousPage;
        public event Action GotoNextPage;
        public event Action GotoLastPage;

        public PageNavigatorViewModel(int currentPage, int maxPages)
        {
            _isFirstButtonEnabled = currentPage > 1;
            _isPreviousButtonEnabled = currentPage > 1;
            _isNextButtonEnabled = currentPage < maxPages;
            _isLastButtonEnabled = currentPage < maxPages;
            _currentPage = currentPage;
            _maxPages = maxPages;

            InitiateCommands();
        }

        ~PageNavigatorViewModel()
        {
            DestroyCommands();
        }

        private void InitiateCommands()
        {
            _firstPageCommand = new FirstPageCommand();
            _firstPageCommand.FirstPage += _FirstPage;

            _previousPageCommand = new PreviousPageCommand();
            _previousPageCommand.PreviousPage += _PreviousPage;

            _nextPageCommand = new NextPageCommand();
            _nextPageCommand.NextPage += _NextPage;

            _lastPageCommand = new LastPageCommand();
            _lastPageCommand.LastPage += _LastPage;
        }

        private void DestroyCommands()
        {
            if(_firstPageCommand != null)
                _firstPageCommand.FirstPage -= _FirstPage;

            if(_previousPageCommand != null)
                _previousPageCommand.PreviousPage -= _PreviousPage;

            if(_nextPageCommand != null)
                _nextPageCommand.NextPage -= _NextPage;

            if(_lastPageCommand != null)
                _lastPageCommand.LastPage -= _LastPage;

        }

        private void _LastPage()
        {
            if (GotoLastPage != null)
                GotoLastPage();
        }

        private void _NextPage()
        {
            if (GotoNextPage != null)
                GotoNextPage();
        }

        private void _PreviousPage()
        {
            if (GotoPreviousPage != null)
                GotoPreviousPage();
        }

        private void _FirstPage()
        {
            if (GotoFirstPage != null)
                GotoFirstPage();
        }

        public bool IsFirstButtonEnabled
        {
            get => _isFirstButtonEnabled;
            set { _isFirstButtonEnabled = value; OnPropertyChanged(); }
        }
        public bool IsPreviousButtonEnabled
        {
            get => _isPreviousButtonEnabled;
            set { _isPreviousButtonEnabled = value; OnPropertyChanged(); }
        }
        public bool IsNextButtonEnabled
        {
            get => _isNextButtonEnabled;
            set { _isNextButtonEnabled = value; OnPropertyChanged(); }
        }
        public bool IsLastButtonEnabled
        {
            get => _isLastButtonEnabled;
            set { _isLastButtonEnabled = value; OnPropertyChanged(); }
        }
        public int CurrentPage
        {
            get => _currentPage;
            set { _currentPage = value; OnPropertyChanged(nameof(NavigationInfo)); }
        }
        public int MaxPages
        {
            get => _maxPages;
            set { _maxPages = value; OnPropertyChanged(nameof(NavigationInfo)); }
        }
        public string NavigationInfo
        {
            get { return string.Format("Page {0} of {1}", _currentPage, _maxPages); }
        }

        public FirstPageCommand FirstPageCommand { get => _firstPageCommand; }
        public PreviousPageCommand PreviousPageCommand { get => _previousPageCommand; }
        public NextPageCommand NextPageCommand { get => _nextPageCommand; }
        public LastPageCommand LastPageCommand { get => _lastPageCommand; }
    }
}
