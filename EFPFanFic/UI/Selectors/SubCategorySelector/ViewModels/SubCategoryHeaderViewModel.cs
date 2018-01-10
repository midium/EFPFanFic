using Midium.Helpers.Observable;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFPFanFic.UI.Selectors.SubCategorySelector.ViewModels
{
    public class SubCategoryHeaderViewModel: ObservableObject
    {
        private bool _isNameSortAscending = true;
        private bool _isNameSorted = true;
        private bool _isAuthorSortAscending = true;
        private bool _isAuthorSorted = false;
        private bool _isFanFicSortAscending = true;
        private bool _isFanFicSorted = false;

        public bool IsNameSortAscending { get => _isNameSortAscending; set => _isNameSortAscending = value; }
        public bool IsNameSorted { get => _isNameSorted; set => _isNameSorted = value; }
        public bool IsAuthorSortAscending { get => _isAuthorSortAscending; set => _isAuthorSortAscending = value; }
        public bool IsAuthorSorted { get => _isAuthorSorted; set => _isAuthorSorted = value; }
        public bool IsFanFicSortAscending { get => _isFanFicSortAscending; set => _isFanFicSortAscending = value; }
        public bool IsFanFicSorted { get => _isFanFicSorted; set => _isFanFicSorted = value; }
    }
}
