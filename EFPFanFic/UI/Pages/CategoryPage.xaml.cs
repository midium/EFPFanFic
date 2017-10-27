using EFPFanFic.UI.Pages.ViewModels;
using EFPFanFic.UI.Selectors.SubCategorySelector.ViewModels.DTO;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace EFPFanFic.UI.Pages
{
    /// <summary>
    /// Interaction logic for CategoryPage.xaml
    /// </summary>
    public partial class CategoryPage : UserControl
    {
        private CategoryPageViewModel _categoryPageViewModel;
        public event Action<SubCategoryItemDTO> SubCategorySelectionChanged;

        public CategoryPage(CategoryPageViewModel categoryPageViewModel)
        {
            InitializeComponent();
            _categoryPageViewModel = categoryPageViewModel;
            this.DataContext = categoryPageViewModel;
        }

        private void SubCategorySelector_ClearSearch()
        {
            _categoryPageViewModel.SubCategorySelector.FilterString = string.Empty;
        }

        private void SubCategorySelector_SearchItem(string itemName)
        {
            _categoryPageViewModel.SubCategorySelector.FilterString = itemName;
        }

        private void SubCategorySelector_SubCategorySelectionChanged(SubCategoryItemDTO subCategoryDTO)
        {
            if (SubCategorySelectionChanged != null)
                SubCategorySelectionChanged(subCategoryDTO);
        }

    }
}
