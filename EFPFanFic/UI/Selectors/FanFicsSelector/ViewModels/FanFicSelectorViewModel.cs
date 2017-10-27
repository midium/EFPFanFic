using EFPFanFic.Business.Scapers.Entities.Base;
using EFPFanFic.UI.Navigators.ViewModel;
using EFPFanFic.UI.Search.ViewModels;
using Midium.Helpers.Observable;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFPFanFic.UI.Selectors.FanFicsSelector.ViewModels
{
    public class FanFicSelectorViewModel : ObservableObject
    {
        private ObservableCollection<FanFicItemViewModel> _fanFics = new ObservableCollection<FanFicItemViewModel>();
        private PageNavigatorViewModel _pageNavigatorViewModel;
        private FanFicSearcherViewModel _fanFicSearcherViewModel;

        public event Action SearchFanFics;
        public event Action<FanFicItemViewModel> SaveAsPDF;
        public event Action<FanFicItemViewModel> ReadFanFic;
        public event Action GotoFirstPage;
        public event Action GotoPreviousPage;
        public event Action GotoNextPage;
        public event Action GotoLastPage;

        public ObservableCollection<FanFicItemViewModel> FanFics
        {
            get => _fanFics;
            set
            {
                RemoveFanFicItemHandlers();
                _fanFics = value;
                AddFanFicItemHandlers();
                OnPropertyChanged();
            }
        }

        public PageNavigatorViewModel PageNavigatorViewModel
        {
            get => _pageNavigatorViewModel;
            set
            {
                _pageNavigatorViewModel = value;
                OnPropertyChanged();
            }
        }

        public FanFicSearcherViewModel FanFicSearcherViewModel
        {
            get => _fanFicSearcherViewModel;
            set
            {
                _fanFicSearcherViewModel = value;
                OnPropertyChanged();
            }
        }

        public FanFicSelectorViewModel(ObservableCollection<FanFicItemViewModel> fanFics, int currentPage, int totalPages,
                                        List<EntityBase> ratingOptions, List<EntityBase> genresOptions,List<EntityBase> storyLengthOptions,
                                        List<EntityBase> storyStatusOptions, List<EntityBase> coupleTypesOptions, List<EntityBase> charactersOptions,
                                        List<EntityBase> couplesOptions,List<EntityBase> contextOptions,
                                        List<EntityBase> notesOptions,List<EntityBase> warnsOptions)
        {
            _fanFics = fanFics;

            AddFanFicItemHandlers();

            _fanFicSearcherViewModel = new FanFicSearcherViewModel(ratingOptions, genresOptions, storyLengthOptions, storyStatusOptions,
                                                                    coupleTypesOptions, charactersOptions, couplesOptions, contextOptions,
                                                                    notesOptions, warnsOptions);
            _fanFicSearcherViewModel.SearchFanFics += _SearchFanFics;

            _pageNavigatorViewModel = new PageNavigatorViewModel(currentPage, totalPages);
            _pageNavigatorViewModel.GotoFirstPage += _GotoFirstPage;
            _pageNavigatorViewModel.GotoPreviousPage += _GotoPreviousPage;
            _pageNavigatorViewModel.GotoNextPage += _GotoNextPage;
            _pageNavigatorViewModel.GotoLastPage += _GotoLastPage;
        }

        private void _SearchFanFics()
        {
            if (SearchFanFics != null)
                SearchFanFics();
        }

        private void RemoveFanFicItemHandlers()
        {
            if (_fanFics != null)
                foreach (FanFicItemViewModel fi in _fanFics)
                {
                    fi.SaveAsPDF -= Fi_SaveAsPDF;
                    fi.ReadFanFic -= Fi_ReadFanFic;
                }

        }

        private void AddFanFicItemHandlers()
        {
            if (_fanFics != null)
                foreach (FanFicItemViewModel fi in _fanFics)
                {
                    fi.SaveAsPDF += Fi_SaveAsPDF;
                    fi.ReadFanFic += Fi_ReadFanFic;
                }
        }

        private void Fi_ReadFanFic(FanFicItemViewModel fanFicData)
        {
            if (ReadFanFic != null)
                ReadFanFic(fanFicData);
        }

        private void Fi_SaveAsPDF(FanFicItemViewModel fanFicData)
        {
            if (SaveAsPDF != null)
                SaveAsPDF(fanFicData);
        }

        private void _GotoLastPage()
        {
            if (GotoLastPage != null)
                GotoLastPage();
        }

        private void _GotoNextPage()
        {
            if (GotoNextPage != null)
                GotoNextPage();
        }

        private void _GotoPreviousPage()
        {
            if (GotoPreviousPage != null)
                GotoPreviousPage();
        }

        private void _GotoFirstPage()
        {
            if (GotoFirstPage != null)
                GotoFirstPage();
        }
    }
}
