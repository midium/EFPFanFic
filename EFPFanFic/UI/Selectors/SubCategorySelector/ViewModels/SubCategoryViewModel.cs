using EFPFanFic.UI.Selectors.SubCategorySelector.ViewModels.DTO;
using Midium.Helpers.Observable;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace EFPFanFic.UI.Selectors.SubCategorySelector.ViewModels
{
    public class SubCategoryViewModel : ObservableObject
    {
        private ObservableCollection<SubCategoryItemDTO> _subCategories = new ObservableCollection<SubCategoryItemDTO>();
        private SubCategoryItemDTO _selectedItem = null;

        private ICollectionView _filteredItems;
        private string filterString;

         public ICollectionView FilteredItems
        {
            get { return _filteredItems; }
            set
            {
                _filteredItems = value;
                OnPropertyChanged();
            }
        }

        public string FilterString
        {
            get { return filterString; }
            set
            {
                if (Equals(value, filterString)) return;
                filterString = value;
                FilteredItems.Refresh();
            }
        }

        public ObservableCollection<SubCategoryItemDTO> SubCategories
        {
            get => _subCategories;
            set
            {
                _subCategories = value;
                FilteredItems = CollectionViewSource.GetDefaultView(value);

                FilteredItems.Filter = i =>
                      {
                         // This will be invoked for every item in the underlying collection 
                         // every time Refresh is invoked
                         if (string.IsNullOrEmpty(FilterString)) return true;
                         SubCategoryItemDTO item = i as SubCategoryItemDTO;
                         return item.SubCategoryName.ToLower().Contains(FilterString.ToLower());
                      };
            }
        }

        public SubCategoryItemDTO SelectedItem { get => _selectedItem; set => _selectedItem = value; }
    }
}
