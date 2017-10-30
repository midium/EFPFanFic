using Midium.Helpers.Observable;

namespace EFPFanFic.UI.Selectors.CategorySelector.ViewModels.DTO
{
    public class CategoryItemDTO : ObservableObject
    {

        private string _categoryName;
        private string _categoryUri;
        private long _categoryItemsCount;
        private bool _isSelectedCategory;

        public string CategoryName {
            get { return _categoryName; }
            set
            {
                _categoryName = value;
                OnPropertyChanged();
            }
        }

        public long CategoryItemsCount
        {
            get { return _categoryItemsCount; }
            set
            {
                _categoryItemsCount = value;
                OnPropertyChanged();
            }
        }

        public string CategoryItemsPrettyfied
        {
            get
            {
                return string.Format("{0} items available", _categoryItemsCount.ToString());
            }
        }

        public string CategoryUri { get => _categoryUri; set => _categoryUri = value; }
        public bool IsSelectedCategory
        {
            get => _isSelectedCategory;
            set
            {
                _isSelectedCategory = value;
                OnPropertyChanged();
            }
        }

        public CategoryItemDTO(string categoryName, string categoryUri, long categoryItemsCount)
        {
            _categoryName = categoryName;
            _categoryUri = categoryUri;
            _categoryItemsCount = categoryItemsCount;
            _isSelectedCategory = false;
        }
    }
}
