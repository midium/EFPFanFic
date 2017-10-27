using Midium.Helpers.Observable;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFPFanFic.UI.Selectors.SubCategorySelector.ViewModels.DTO
{
    public class SubCategoryItemDTO : ObservableObject
    {
        string _subCategoryName;
        string _subCategoryAuthor;
        string _fanFicsPageUri;
        long _subCategoryItemsCount;

        public string SubCategoryName {
            get { return _subCategoryName; }
            set
            {
                _subCategoryName = value;
                OnPropertyChanged();
            }
        }

        public long SubCategoryItemsCount
        {
            get { return _subCategoryItemsCount; }
            set
            {
                _subCategoryItemsCount = value;
                OnPropertyChanged();
            }
        }

        public string FanFicsPageUri { get => _fanFicsPageUri; set => _fanFicsPageUri = value; }
        public string SubCategoryAuthor
        {
            get => _subCategoryAuthor;
            set
            {
                _subCategoryAuthor = value;
                OnPropertyChanged();
            }
        }

        public SubCategoryItemDTO(string subCategoryName, string subCategoryAuthor, string subCategoryUri, long subCategoryItemsCount)
        {
            _subCategoryName = subCategoryName;
            _subCategoryAuthor = subCategoryAuthor;
            _fanFicsPageUri = subCategoryUri;
            _subCategoryItemsCount = subCategoryItemsCount;
        }
    }
}
