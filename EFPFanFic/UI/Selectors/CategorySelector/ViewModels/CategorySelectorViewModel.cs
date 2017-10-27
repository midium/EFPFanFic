using EFPFanFic.UI.Selectors.CategorySelector.ViewModels.DTO;
using System.Collections.ObjectModel;

namespace EFPFanFic.UI.Selectors.CategorySelector.ViewModels
{
    public class CategorySelectorViewModel
    {
        private ObservableCollection<DTO.CategoryItemDTO> _categories = new ObservableCollection<DTO.CategoryItemDTO>();

        public ObservableCollection<DTO.CategoryItemDTO> Categories { get => _categories; set => _categories = value; }

    }
}
