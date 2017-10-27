using EFPFanFic.UI.Selectors.SubCategorySelector.ViewModels;
using Midium.Helpers.Observable;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFPFanFic.UI.Pages.ViewModels
{
    public class CategoryPageViewModel : ObservableObject
    {
        private bool _isCategorySelected;
        private string _categoryName;
        private SubCategoryViewModel _subCategorySelectorViewModel;

        public bool IsCategorySelected
        {
            get => _isCategorySelected;
            set
            {
                _isCategorySelected = value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(IsCategoryNotSelected));
            }
        }

        public bool IsCategoryNotSelected
        {
            get => !_isCategorySelected;
        }

        public string CategoryName
        {
            get { return string.Format("BROWSING CATEGORY '{0}'", _categoryName.ToUpper()); }
            set
            {
                _categoryName = value;
                OnPropertyChanged();
            }
        }

        public CategoryPageViewModel(SubCategoryViewModel subCategorySelectorViewModel)
        {
            IsCategorySelected = false;
            CategoryName = string.Empty;
            _subCategorySelectorViewModel = subCategorySelectorViewModel;
        }

        public SubCategoryViewModel SubCategorySelector { get => _subCategorySelectorViewModel; }
    }
}
