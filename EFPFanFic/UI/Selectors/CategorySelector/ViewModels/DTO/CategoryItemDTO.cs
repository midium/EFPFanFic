using Midium.Helpers.Observable;

namespace EFPFanFic.UI.Selectors.CategorySelector.ViewModels.DTO
{
    public class CategoryItemDTO : ObservableObject
    {

        string _categoryName;
        string _categoryUri;
        long _categoryItemsCount;

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

        public CategoryItemDTO(string categoryName, string categoryUri, long categoryItemsCount)
        {
            _categoryName = categoryName;
            _categoryUri = categoryUri;
            _categoryItemsCount = categoryItemsCount;
        }
    }
}
