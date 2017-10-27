using EFPFanFic.UI.Selectors.FanFicsSelector.ViewModels;
using Midium.Helpers.Observable;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFPFanFic.UI.Pages.ViewModels
{
    public class FanFicPageViewModel : ObservableObject
    {
        private string _fanFicPageName;
        private string _categoryName;
        private readonly FanFicSelectorViewModel _fanFicSelectorViewModel;

        public string FanFicPageName
        {
            get { return GetFormattedTitle(); }
            set
            {
                _fanFicPageName = value;
                OnPropertyChanged();
            }
        }

        public string CategoryName
        {
            get { return GetFormattedTitle(); }
            set
            {
                _categoryName = value;
                OnPropertyChanged();
            }
        }

        public FanFicSelectorViewModel FanFicSelectorViewModel { get => _fanFicSelectorViewModel; }

        private string GetFormattedTitle()
        {
            return string.Format("BROWSING '{0} - {1}' FAN FICTIONS", _categoryName,_fanFicPageName);
        }

        public FanFicPageViewModel(FanFicSelectorViewModel fanFicSelectorViewModel)
        {
            _fanFicSelectorViewModel = fanFicSelectorViewModel;
        }
    }
}
